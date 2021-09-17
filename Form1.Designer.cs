namespace ChatListener
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }

            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.textboxChat = new System.Windows.Forms.RichTextBox();
            this.panelChannels = new System.Windows.Forms.Panel();
            this.labelChannel = new System.Windows.Forms.Label();
            this.textboxViewers = new System.Windows.Forms.RichTextBox();
            this.textboxPing = new System.Windows.Forms.RichTextBox();
            this.scrollMsgCount = new System.Windows.Forms.HScrollBar();
            this.labelMsgCount = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // textboxChat
            // 
            this.textboxChat.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.textboxChat.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textboxChat.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textboxChat.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(213)))), ((int)(((byte)(227)))), ((int)(((byte)(214)))));
            this.textboxChat.Location = new System.Drawing.Point(12, 12);
            this.textboxChat.Name = "textboxChat";
            this.textboxChat.ReadOnly = true;
            this.textboxChat.Size = new System.Drawing.Size(276, 606);
            this.textboxChat.TabIndex = 0;
            this.textboxChat.Text = "Chat";
            // 
            // panelChannels
            // 
            this.panelChannels.Location = new System.Drawing.Point(529, 78);
            this.panelChannels.Name = "panelChannels";
            this.panelChannels.Size = new System.Drawing.Size(200, 540);
            this.panelChannels.TabIndex = 1;
            // 
            // labelChannel
            // 
            this.labelChannel.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelChannel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(213)))), ((int)(((byte)(227)))), ((int)(((byte)(214)))));
            this.labelChannel.Location = new System.Drawing.Point(303, 9);
            this.labelChannel.Name = "labelChannel";
            this.labelChannel.Size = new System.Drawing.Size(209, 38);
            this.labelChannel.TabIndex = 2;
            this.labelChannel.Text = "Channel";
            this.labelChannel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // textboxViewers
            // 
            this.textboxViewers.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.textboxViewers.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textboxViewers.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.textboxViewers.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(213)))), ((int)(((byte)(227)))), ((int)(((byte)(214)))));
            this.textboxViewers.Location = new System.Drawing.Point(304, 94);
            this.textboxViewers.Name = "textboxViewers";
            this.textboxViewers.ReadOnly = true;
            this.textboxViewers.Size = new System.Drawing.Size(208, 159);
            this.textboxViewers.TabIndex = 3;
            this.textboxViewers.Text = "";
            // 
            // textboxPing
            // 
            this.textboxPing.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.textboxPing.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textboxPing.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.textboxPing.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(213)))), ((int)(((byte)(227)))), ((int)(((byte)(214)))));
            this.textboxPing.Location = new System.Drawing.Point(304, 366);
            this.textboxPing.Name = "textboxPing";
            this.textboxPing.ReadOnly = true;
            this.textboxPing.Size = new System.Drawing.Size(208, 252);
            this.textboxPing.TabIndex = 3;
            this.textboxPing.Text = "";
            // 
            // scrollMsgCount
            // 
            this.scrollMsgCount.LargeChange = 5;
            this.scrollMsgCount.Location = new System.Drawing.Point(304, 304);
            this.scrollMsgCount.Maximum = 40;
            this.scrollMsgCount.Minimum = 20;
            this.scrollMsgCount.Name = "scrollMsgCount";
            this.scrollMsgCount.Size = new System.Drawing.Size(208, 16);
            this.scrollMsgCount.TabIndex = 4;
            this.scrollMsgCount.Value = 30;
            this.scrollMsgCount.Scroll += new System.Windows.Forms.ScrollEventHandler(this.scrollMsgCount_Scroll);
            // 
            // labelMsgCount
            // 
            this.labelMsgCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold);
            this.labelMsgCount.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(213)))), ((int)(((byte)(227)))), ((int)(((byte)(214)))));
            this.labelMsgCount.Location = new System.Drawing.Point(303, 276);
            this.labelMsgCount.Name = "labelMsgCount";
            this.labelMsgCount.Size = new System.Drawing.Size(208, 25);
            this.labelMsgCount.TabIndex = 5;
            this.labelMsgCount.Text = "Messages count = 30\r\n";
            this.labelMsgCount.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(213)))), ((int)(((byte)(227)))), ((int)(((byte)(214)))));
            this.label1.Location = new System.Drawing.Point(304, 56);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(207, 27);
            this.label1.TabIndex = 6;
            this.label1.Text = "Viewers";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold);
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(213)))), ((int)(((byte)(227)))), ((int)(((byte)(214)))));
            this.label2.Location = new System.Drawing.Point(304, 332);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(207, 31);
            this.label2.TabIndex = 7;
            this.label2.Text = "Recent pings";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold);
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(213)))), ((int)(((byte)(227)))), ((int)(((byte)(214)))));
            this.label3.Location = new System.Drawing.Point(529, 22);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(200, 53);
            this.label3.TabIndex = 8;
            this.label3.Text = "Available channels";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.ClientSize = new System.Drawing.Size(741, 631);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.labelMsgCount);
            this.Controls.Add(this.scrollMsgCount);
            this.Controls.Add(this.textboxPing);
            this.Controls.Add(this.textboxViewers);
            this.Controls.Add(this.labelChannel);
            this.Controls.Add(this.panelChannels);
            this.Controls.Add(this.textboxChat);
            this.Name = "Form1";
            this.Text = "ChatListener";
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.Label label3;

        private System.Windows.Forms.Label label2;

        private System.Windows.Forms.Label label1;

        private System.Windows.Forms.HScrollBar scrollMsgCount;
        private System.Windows.Forms.Label labelMsgCount;

        private System.Windows.Forms.RichTextBox textboxPing;

        private System.Windows.Forms.RichTextBox textboxViewers;

        private System.Windows.Forms.Panel panelChannels;
        private System.Windows.Forms.RichTextBox textboxChat;
        private System.Windows.Forms.Label labelChannel;

        #endregion
    }
}