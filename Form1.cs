using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Media;
using System.Net.Mime;
using System.Text;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Text.RegularExpressions;
using System.Text.Unicode;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ChatListener
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            _cfg = ConfigLoader.Load(@"D:\Desktop\Side Goods\ChatListener\ChatListener\Config.json");
            SetButtons();
            _jso = new JsonSerializerOptions
            {
                Encoder = JavaScriptEncoder.Create(UnicodeRanges.All)
            };
            InitWriters();
            TwitchIrcClient t = new TwitchIrcClient();
            
            _viewers = new Dictionary<string, List<string>>();
            foreach (var channel in _cfg.Channels)
            {
                _viewers.Add(channel,new List<string>());
            }
            
            t.OnConnect += (sender, args) =>
            {
                foreach (var channel in _cfg.Channels)
                {
                    t.Join(channel);
                }
            };
            t.OnJoin += (sender, args) =>
            {
                _viewers[((MembershipEventArgs)args).channel].Add(((MembershipEventArgs)args).nickname);
                if (((MembershipEventArgs)args).channel==_currentChannel) UpdateViewers();
            };
            t.OnPart += (sender, args) =>
            {
                _viewers[((MembershipEventArgs)args).channel].Remove(((MembershipEventArgs)args).nickname);
                if (((MembershipEventArgs)args).channel==_currentChannel) UpdateViewers();
            };
            t.OnMessage += Log;
            t.Connect();

        }

        private void CheckForPing(MsgEventArgs e)
        {
            string pattern = "([^а-яё]|^)[bвшw]+[мm]+[уыаyau]+[гg]+(а|и|е|у|ой|a)*([^а-яё_a-z]|$)+";
            if (Regex.IsMatch(e.Message, pattern,RegexOptions.IgnoreCase))
            {
                SoundPlayer soundPlayer = new SoundPlayer();
                soundPlayer.SoundLocation = _cfg.PingSound;
                soundPlayer.Play();
                textboxPing.Text += $"{e.Channel} {e.User} {e.Message}\r\n";
            }
        }
        
        private void Log(object sender, EventArgs e)
        {
            if (_cfg.NotLog.Contains(((MsgEventArgs)e).Tags.DisplayName.ToLower())) return;
            CheckForPing((MsgEventArgs)e);
            FileWrite fw = new FileWrite
            {
                Message = ((MsgEventArgs)e).Message,
                DateTime = ((MsgEventArgs)e).Time,
                MessageType = ((MsgEventArgs)e).MessageType,
                DisplayName = ((MsgEventArgs)e).Tags.DisplayName,
                Color = ((MsgEventArgs)e).Tags.Color
            };
            var data = Encoding.UTF8.GetBytes(JsonSerializer.Serialize(fw,_jso)+"\n"); 
            _writers[((MsgEventArgs)e).Channel].Write(data,0,data.Length);
            _writers[((MsgEventArgs)e).Channel].Flush();
            if (_currentChannel == ((MsgEventArgs)e).Channel) AddText(fw);
        }

        private string[] ReadLines(string channel)
        {
            var sr = new StreamReader(new FileStream($"{_cfg.LogPath}\\{channel.Substring(1, channel.Length - 1)}.log",
                FileMode.Open,
                FileAccess.Read, FileShare.ReadWrite));
            var fileLines = sr.ReadToEnd().Split('\n').Reverse().ToArray();
            string[] lines = new string[scrollMsgCount.Value];
            int i = 0;
            foreach (var line in fileLines)
            {
                lines[i]=line;
                if(++i==scrollMsgCount.Value || fileLines.Length<=i) break;
            }
            return lines.Reverse().ToArray();
        }

        private void SetButtons()
        {
            foreach (var channel in _cfg.Channels)
            {
                Button chnlBtn = new Button();
                chnlBtn.Dock = DockStyle.Top;
                chnlBtn.Text = channel;
                chnlBtn.Height = 30;
                chnlBtn.Click += ReadChannel;
                chnlBtn.FlatStyle = FlatStyle.Flat;
                chnlBtn.FlatAppearance.BorderSize = 0;
                chnlBtn.Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Bold, GraphicsUnit.Point, ((byte)(204)));
                chnlBtn.ForeColor = Color.FromArgb(213, 227,214);
                chnlBtn.FlatAppearance.BorderColor = Color.FromArgb(213, 227,214);
                panelChannels.Controls.Add(chnlBtn);
            }
        }

        private void chnlBtnSwitch(object sender)
        {
            foreach (Button btn in panelChannels.Controls)
            {
                btn.FlatAppearance.BorderSize = 0;
            }
            ((Button)sender).FlatAppearance.BorderSize = 2;
        }
        private void ReadChannel(object sender, EventArgs e)
        {
            if (_currentChannel==((Button)sender).Text) return;
            
            _currentChannel = ((Button)sender).Text;
            labelChannel.Text = $"Current channel: {_currentChannel.Substring(1,_currentChannel.Length-1)}";
            textboxChat.Text = "";
            UpdateViewers();
            foreach (var line in ReadLines(_currentChannel))
            {
                if (!String.IsNullOrEmpty(line)) AddText(JsonSerializer.Deserialize<FileWrite>(line));
            }
            chnlBtnSwitch(sender);
        }

        private void UpdateViewers()
        {
            textboxViewers.Text = String.Join(", ",_viewers[_currentChannel]);
        }
        private void AddText(FileWrite fw)
        {
            AddСhatText($"{fw.MessageType} ",textboxChat.ForeColor);
            Color userColor = ColorTranslator.FromHtml(fw.Color);
            AddСhatText($"{fw.DisplayName} ",userColor,true);
            AddСhatText($"{fw.Message}\r\n",fw.MessageType=="chat" ? textboxChat.ForeColor : userColor);
            var textSplit = new List<string>(textboxChat.Text.Split('\n'));
            if (textboxChat.Text.Split('\n').Length > scrollMsgCount.Value)
            {
                textboxChat.Text = String.Join("\n", textSplit.GetRange(1, textSplit.Count - 1));
            }
            textboxChat.SelectionStart = textboxChat.TextLength;
            textboxChat.ScrollToCaret();
        }

        private void AddСhatText(string text, Color color, bool bold = false)
        {
            textboxChat.SelectionStart = textboxChat.TextLength;
            textboxChat.SelectionLength = 0;
            textboxChat.SelectionColor = color;
            textboxChat.SelectionFont = new Font(textboxChat.SelectionFont.FontFamily,textboxChat.SelectionFont.Size,bold ? FontStyle.Bold : FontStyle.Regular);
            textboxChat.AppendText(text);
            textboxChat.SelectionColor = textboxChat.ForeColor;
        }

        private void InitWriters()
        {
            _writers = new Dictionary<string, FileStream>();
            foreach (var channel in _cfg.Channels)
            {
                _writers.Add(channel,new FileStream($"{_cfg.LogPath}\\{channel.Substring(1, channel.Length - 1)}.log", FileMode.Append,
                    FileAccess.Write,FileShare.ReadWrite));
            }
        }

        private JsonSerializerOptions _jso;
        private string _currentChannel;
        private ConfigLoader.Config _cfg;
        private Dictionary<string, FileStream> _writers;
        private Dictionary<string, List<string>> _viewers;

        private class FileWrite
        {
            [JsonPropertyName("display-name")]
            public string DisplayName { get; set; }
            [JsonPropertyName("message")]
            public string Message { get; set; }
            [JsonPropertyName("message-type")]
            public string MessageType { get; set; }
            [JsonPropertyName("date-time")]
            public long DateTime { get; set; }
            
            [JsonPropertyName("color")]
            public string Color { get; set; }
        }

        private void scrollMsgCount_Scroll(object sender, ScrollEventArgs e)
        {
            labelMsgCount.Text = $"Messages count = {scrollMsgCount.Value}";
        }
    }
}