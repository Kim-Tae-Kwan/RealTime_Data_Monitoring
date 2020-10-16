namespace BogusMqttWinPubApp
{
    partial class MainForm
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.metroLabel1 = new MetroFramework.Controls.MetroLabel();
            this.TxtBrokerIP = new MetroFramework.Controls.MetroTextBox();
            this.BtnConnect = new MetroFramework.Controls.MetroButton();
            this.RtbLog = new System.Windows.Forms.RichTextBox();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.SuspendLayout();
            // 
            // metroLabel1
            // 
            this.metroLabel1.AutoSize = true;
            this.metroLabel1.Location = new System.Drawing.Point(23, 60);
            this.metroLabel1.Name = "metroLabel1";
            this.metroLabel1.Size = new System.Drawing.Size(103, 19);
            this.metroLabel1.TabIndex = 0;
            this.metroLabel1.Text = "MQTT Broker IP";
            // 
            // TxtBrokerIP
            // 
            // 
            // 
            // 
            this.TxtBrokerIP.CustomButton.Image = null;
            this.TxtBrokerIP.CustomButton.Location = new System.Drawing.Point(516, 1);
            this.TxtBrokerIP.CustomButton.Name = "";
            this.TxtBrokerIP.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.TxtBrokerIP.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.TxtBrokerIP.CustomButton.TabIndex = 1;
            this.TxtBrokerIP.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.TxtBrokerIP.CustomButton.UseSelectable = true;
            this.TxtBrokerIP.CustomButton.Visible = false;
            this.TxtBrokerIP.Lines = new string[] {
        "localhost"};
            this.TxtBrokerIP.Location = new System.Drawing.Point(132, 60);
            this.TxtBrokerIP.MaxLength = 32767;
            this.TxtBrokerIP.Name = "TxtBrokerIP";
            this.TxtBrokerIP.PasswordChar = '\0';
            this.TxtBrokerIP.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.TxtBrokerIP.SelectedText = "";
            this.TxtBrokerIP.SelectionLength = 0;
            this.TxtBrokerIP.SelectionStart = 0;
            this.TxtBrokerIP.ShortcutsEnabled = true;
            this.TxtBrokerIP.Size = new System.Drawing.Size(538, 23);
            this.TxtBrokerIP.TabIndex = 1;
            this.TxtBrokerIP.Text = "localhost";
            this.TxtBrokerIP.UseSelectable = true;
            this.TxtBrokerIP.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.TxtBrokerIP.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // BtnConnect
            // 
            this.BtnConnect.Location = new System.Drawing.Point(676, 60);
            this.BtnConnect.Name = "BtnConnect";
            this.BtnConnect.Size = new System.Drawing.Size(101, 23);
            this.BtnConnect.TabIndex = 2;
            this.BtnConnect.Text = "Connect";
            this.BtnConnect.UseSelectable = true;
            this.BtnConnect.Click += new System.EventHandler(this.BtnConnect_Click);
            // 
            // RtbLog
            // 
            this.RtbLog.Location = new System.Drawing.Point(23, 89);
            this.RtbLog.Name = "RtbLog";
            this.RtbLog.Size = new System.Drawing.Size(754, 338);
            this.RtbLog.TabIndex = 3;
            this.RtbLog.Text = "";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.RtbLog);
            this.Controls.Add(this.BtnConnect);
            this.Controls.Add(this.TxtBrokerIP);
            this.Controls.Add(this.metroLabel1);
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.Resizable = false;
            this.Text = "MQTT Fake Publisher";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MetroFramework.Controls.MetroLabel metroLabel1;
        private MetroFramework.Controls.MetroTextBox TxtBrokerIP;
        private MetroFramework.Controls.MetroButton BtnConnect;
        private System.Windows.Forms.RichTextBox RtbLog;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
    }
}

