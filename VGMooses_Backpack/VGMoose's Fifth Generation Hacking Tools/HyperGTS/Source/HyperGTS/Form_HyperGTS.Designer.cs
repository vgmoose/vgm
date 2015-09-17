namespace HyperGTS
{
    partial class Form_HyperGTS
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_HyperGTS));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.LL_DNS_ClearLog = new System.Windows.Forms.LinkLabel();
            this.LA_DNS_Status = new System.Windows.Forms.Label();
            this.TB_DNS_IP = new System.Windows.Forms.TextBox();
            this.LB_DNS_Log = new System.Windows.Forms.ListBox();
            this.BT_DNS = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.BGW_DNS = new System.ComponentModel.BackgroundWorker();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.RB_GTS_SendFolder = new System.Windows.Forms.RadioButton();
            this.RB_GTS_SendOne = new System.Windows.Forms.RadioButton();
            this.label2 = new System.Windows.Forms.Label();
            this.LL_GTS_clearLog = new System.Windows.Forms.LinkLabel();
            this.BT_GTS = new System.Windows.Forms.Button();
            this.LA_GTS_Status = new System.Windows.Forms.Label();
            this.CB_GTS_SendAfterReceive = new System.Windows.Forms.CheckBox();
            this.LB_GTS_Log = new System.Windows.Forms.ListBox();
            this.CB_GTS_Reject = new System.Windows.Forms.CheckBox();
            this.BT_GTS_SendPKMN = new System.Windows.Forms.Button();
            this.TB_GTS_SendPKMN = new System.Windows.Forms.TextBox();
            this.CB_GTS_SendPKMN = new System.Windows.Forms.CheckBox();
            this.OFD_SendPKMN = new System.Windows.Forms.OpenFileDialog();
            this.BGW_GTS = new System.ComponentModel.BackgroundWorker();
            this.label3 = new System.Windows.Forms.Label();
            this.LL_Help = new System.Windows.Forms.LinkLabel();
            this.FBD_GTS_SendFolder = new System.Windows.Forms.FolderBrowserDialog();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.LL_DNS_ClearLog);
            this.groupBox1.Controls.Add(this.LA_DNS_Status);
            this.groupBox1.Controls.Add(this.TB_DNS_IP);
            this.groupBox1.Controls.Add(this.LB_DNS_Log);
            this.groupBox1.Controls.Add(this.BT_DNS);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(255, 305);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "DNS-Server";
            // 
            // LL_DNS_ClearLog
            // 
            this.LL_DNS_ClearLog.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.LL_DNS_ClearLog.AutoSize = true;
            this.LL_DNS_ClearLog.Location = new System.Drawing.Point(202, 84);
            this.LL_DNS_ClearLog.Name = "LL_DNS_ClearLog";
            this.LL_DNS_ClearLog.Size = new System.Drawing.Size(47, 13);
            this.LL_DNS_ClearLog.TabIndex = 3;
            this.LL_DNS_ClearLog.TabStop = true;
            this.LL_DNS_ClearLog.Text = "clear log";
            this.LL_DNS_ClearLog.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.LL_DNS_ClearLog_LinkClicked);
            // 
            // LA_DNS_Status
            // 
            this.LA_DNS_Status.AutoSize = true;
            this.LA_DNS_Status.BackColor = System.Drawing.Color.Red;
            this.LA_DNS_Status.Location = new System.Drawing.Point(10, 84);
            this.LA_DNS_Status.Name = "LA_DNS_Status";
            this.LA_DNS_Status.Size = new System.Drawing.Size(71, 13);
            this.LA_DNS_Status.TabIndex = 1;
            this.LA_DNS_Status.Text = "DNS stopped";
            // 
            // TB_DNS_IP
            // 
            this.TB_DNS_IP.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.TB_DNS_IP.Location = new System.Drawing.Point(9, 32);
            this.TB_DNS_IP.Name = "TB_DNS_IP";
            this.TB_DNS_IP.Size = new System.Drawing.Size(240, 20);
            this.TB_DNS_IP.TabIndex = 1;
            this.TB_DNS_IP.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // LB_DNS_Log
            // 
            this.LB_DNS_Log.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.LB_DNS_Log.FormattingEnabled = true;
            this.LB_DNS_Log.HorizontalScrollbar = true;
            this.LB_DNS_Log.Location = new System.Drawing.Point(10, 100);
            this.LB_DNS_Log.Name = "LB_DNS_Log";
            this.LB_DNS_Log.Size = new System.Drawing.Size(239, 199);
            this.LB_DNS_Log.TabIndex = 2;
            // 
            // BT_DNS
            // 
            this.BT_DNS.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.BT_DNS.Location = new System.Drawing.Point(9, 58);
            this.BT_DNS.Name = "BT_DNS";
            this.BT_DNS.Size = new System.Drawing.Size(240, 23);
            this.BT_DNS.TabIndex = 1;
            this.BT_DNS.Text = "START DNS";
            this.BT_DNS.UseVisualStyleBackColor = true;
            this.BT_DNS.Click += new System.EventHandler(this.BT_DNS_Click);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(133, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "IP of the fake GTS-Server:";
            // 
            // BGW_DNS
            // 
            this.BGW_DNS.WorkerReportsProgress = true;
            this.BGW_DNS.WorkerSupportsCancellation = true;
            this.BGW_DNS.DoWork += new System.ComponentModel.DoWorkEventHandler(this.BGW_DNS_DoWork);
            this.BGW_DNS.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.BGW_DNS_RunWorkerCompleted);
            this.BGW_DNS.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.BGW_DNS_ProgressChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.RB_GTS_SendFolder);
            this.groupBox2.Controls.Add(this.RB_GTS_SendOne);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.LL_GTS_clearLog);
            this.groupBox2.Controls.Add(this.BT_GTS);
            this.groupBox2.Controls.Add(this.LA_GTS_Status);
            this.groupBox2.Controls.Add(this.CB_GTS_SendAfterReceive);
            this.groupBox2.Controls.Add(this.LB_GTS_Log);
            this.groupBox2.Controls.Add(this.CB_GTS_Reject);
            this.groupBox2.Controls.Add(this.BT_GTS_SendPKMN);
            this.groupBox2.Controls.Add(this.TB_GTS_SendPKMN);
            this.groupBox2.Controls.Add(this.CB_GTS_SendPKMN);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(0, 0);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(372, 305);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Fake GTS";
            // 
            // RB_GTS_SendFolder
            // 
            this.RB_GTS_SendFolder.AutoSize = true;
            this.RB_GTS_SendFolder.Enabled = false;
            this.RB_GTS_SendFolder.Location = new System.Drawing.Point(190, 14);
            this.RB_GTS_SendFolder.Name = "RB_GTS_SendFolder";
            this.RB_GTS_SendFolder.Size = new System.Drawing.Size(90, 17);
            this.RB_GTS_SendFolder.TabIndex = 9;
            this.RB_GTS_SendFolder.Text = "all from folder:";
            this.RB_GTS_SendFolder.UseVisualStyleBackColor = true;
            this.RB_GTS_SendFolder.CheckedChanged += new System.EventHandler(this.RB_GTS_SendFolder_CheckedChanged);
            // 
            // RB_GTS_SendOne
            // 
            this.RB_GTS_SendOne.AutoSize = true;
            this.RB_GTS_SendOne.Checked = true;
            this.RB_GTS_SendOne.Enabled = false;
            this.RB_GTS_SendOne.Location = new System.Drawing.Point(115, 14);
            this.RB_GTS_SendOne.Name = "RB_GTS_SendOne";
            this.RB_GTS_SendOne.Size = new System.Drawing.Size(69, 17);
            this.RB_GTS_SendOne.TabIndex = 8;
            this.RB_GTS_SendOne.TabStop = true;
            this.RB_GTS_SendOne.Text = "one .pkm";
            this.RB_GTS_SendOne.UseVisualStyleBackColor = true;
            this.RB_GTS_SendOne.CheckedChanged += new System.EventHandler(this.RB_GTS_SendOne_CheckedChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 64);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(98, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Receive Pokemon:";
            // 
            // LL_GTS_clearLog
            // 
            this.LL_GTS_clearLog.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.LL_GTS_clearLog.AutoSize = true;
            this.LL_GTS_clearLog.Location = new System.Drawing.Point(319, 135);
            this.LL_GTS_clearLog.Name = "LL_GTS_clearLog";
            this.LL_GTS_clearLog.Size = new System.Drawing.Size(47, 13);
            this.LL_GTS_clearLog.TabIndex = 6;
            this.LL_GTS_clearLog.TabStop = true;
            this.LL_GTS_clearLog.Text = "clear log";
            this.LL_GTS_clearLog.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.LL_GTS_clearLog_LinkClicked);
            // 
            // BT_GTS
            // 
            this.BT_GTS.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.BT_GTS.Location = new System.Drawing.Point(6, 105);
            this.BT_GTS.Name = "BT_GTS";
            this.BT_GTS.Size = new System.Drawing.Size(364, 23);
            this.BT_GTS.TabIndex = 6;
            this.BT_GTS.Text = "START GTS";
            this.BT_GTS.UseVisualStyleBackColor = true;
            this.BT_GTS.Click += new System.EventHandler(this.button1_Click);
            // 
            // LA_GTS_Status
            // 
            this.LA_GTS_Status.AutoSize = true;
            this.LA_GTS_Status.BackColor = System.Drawing.Color.Red;
            this.LA_GTS_Status.Location = new System.Drawing.Point(6, 135);
            this.LA_GTS_Status.Name = "LA_GTS_Status";
            this.LA_GTS_Status.Size = new System.Drawing.Size(70, 13);
            this.LA_GTS_Status.TabIndex = 4;
            this.LA_GTS_Status.Text = "GTS stopped";
            // 
            // CB_GTS_SendAfterReceive
            // 
            this.CB_GTS_SendAfterReceive.AutoSize = true;
            this.CB_GTS_SendAfterReceive.Location = new System.Drawing.Point(122, 83);
            this.CB_GTS_SendAfterReceive.Name = "CB_GTS_SendAfterReceive";
            this.CB_GTS_SendAfterReceive.Size = new System.Drawing.Size(224, 17);
            this.CB_GTS_SendAfterReceive.TabIndex = 5;
            this.CB_GTS_SendAfterReceive.Text = "Start sending the Pokemon after receiving";
            this.CB_GTS_SendAfterReceive.UseVisualStyleBackColor = true;
            // 
            // LB_GTS_Log
            // 
            this.LB_GTS_Log.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.LB_GTS_Log.FormattingEnabled = true;
            this.LB_GTS_Log.HorizontalScrollbar = true;
            this.LB_GTS_Log.Location = new System.Drawing.Point(6, 152);
            this.LB_GTS_Log.Name = "LB_GTS_Log";
            this.LB_GTS_Log.Size = new System.Drawing.Size(364, 147);
            this.LB_GTS_Log.TabIndex = 5;
            // 
            // CB_GTS_Reject
            // 
            this.CB_GTS_Reject.AutoSize = true;
            this.CB_GTS_Reject.Checked = true;
            this.CB_GTS_Reject.CheckState = System.Windows.Forms.CheckState.Checked;
            this.CB_GTS_Reject.Location = new System.Drawing.Point(122, 63);
            this.CB_GTS_Reject.Name = "CB_GTS_Reject";
            this.CB_GTS_Reject.Size = new System.Drawing.Size(238, 17);
            this.CB_GTS_Reject.TabIndex = 4;
            this.CB_GTS_Reject.Text = "Reject the Pokemon (it remains on the game)";
            this.CB_GTS_Reject.UseVisualStyleBackColor = true;
            // 
            // BT_GTS_SendPKMN
            // 
            this.BT_GTS_SendPKMN.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BT_GTS_SendPKMN.Enabled = false;
            this.BT_GTS_SendPKMN.Location = new System.Drawing.Point(341, 30);
            this.BT_GTS_SendPKMN.Name = "BT_GTS_SendPKMN";
            this.BT_GTS_SendPKMN.Size = new System.Drawing.Size(27, 23);
            this.BT_GTS_SendPKMN.TabIndex = 2;
            this.BT_GTS_SendPKMN.Text = "...";
            this.BT_GTS_SendPKMN.UseVisualStyleBackColor = true;
            this.BT_GTS_SendPKMN.Click += new System.EventHandler(this.BT_GTS_SendPKMN_Click);
            // 
            // TB_GTS_SendPKMN
            // 
            this.TB_GTS_SendPKMN.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.TB_GTS_SendPKMN.Enabled = false;
            this.TB_GTS_SendPKMN.Location = new System.Drawing.Point(6, 32);
            this.TB_GTS_SendPKMN.Name = "TB_GTS_SendPKMN";
            this.TB_GTS_SendPKMN.Size = new System.Drawing.Size(331, 20);
            this.TB_GTS_SendPKMN.TabIndex = 1;
            // 
            // CB_GTS_SendPKMN
            // 
            this.CB_GTS_SendPKMN.AutoSize = true;
            this.CB_GTS_SendPKMN.Location = new System.Drawing.Point(6, 15);
            this.CB_GTS_SendPKMN.Name = "CB_GTS_SendPKMN";
            this.CB_GTS_SendPKMN.Size = new System.Drawing.Size(102, 17);
            this.CB_GTS_SendPKMN.TabIndex = 0;
            this.CB_GTS_SendPKMN.Text = "Send Pokemon:";
            this.CB_GTS_SendPKMN.UseVisualStyleBackColor = true;
            this.CB_GTS_SendPKMN.CheckedChanged += new System.EventHandler(this.CB_GTS_SendPKMN_CheckedChanged);
            // 
            // OFD_SendPKMN
            // 
            this.OFD_SendPKMN.DefaultExt = "pkm";
            this.OFD_SendPKMN.FileName = "pkm.pkm";
            this.OFD_SendPKMN.Filter = ".pkm Files|*.pkm";
            this.OFD_SendPKMN.SupportMultiDottedExtensions = true;
            // 
            // BGW_GTS
            // 
            this.BGW_GTS.WorkerReportsProgress = true;
            this.BGW_GTS.WorkerSupportsCancellation = true;
            this.BGW_GTS.DoWork += new System.ComponentModel.DoWorkEventHandler(this.BGW_GTS_DoWork);
            this.BGW_GTS.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.BGW_GTS_RunWorkerCompleted);
            this.BGW_GTS.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.BGW_GTS_ProgressChanged);
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.Location = new System.Drawing.Point(2, 311);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(594, 23);
            this.label3.TabIndex = 2;
            this.label3.Text = "HyperGTS by Madaruwode, based on Fake GTS server v0.2 (M@T) / sendpkm.py (LordLan" +
                "don), fake_gts.py (Eevee)";
            this.label3.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // LL_Help
            // 
            this.LL_Help.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.LL_Help.Location = new System.Drawing.Point(602, 311);
            this.LL_Help.Name = "LL_Help";
            this.LL_Help.Size = new System.Drawing.Size(31, 23);
            this.LL_Help.TabIndex = 3;
            this.LL_Help.TabStop = true;
            this.LL_Help.Text = "Help";
            this.LL_Help.TextAlign = System.Drawing.ContentAlignment.TopRight;
            this.LL_Help.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.LL_Help_LinkClicked);
            // 
            // FBD_GTS_SendFolder
            // 
            this.FBD_GTS_SendFolder.Description = "Select the Folder where the .pkm are in:";
            this.FBD_GTS_SendFolder.ShowNewFolderButton = false;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer1.IsSplitterFixed = true;
            this.splitContainer1.Location = new System.Drawing.Point(5, 3);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.groupBox1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.groupBox2);
            this.splitContainer1.Size = new System.Drawing.Size(628, 305);
            this.splitContainer1.SplitterDistance = 255;
            this.splitContainer1.SplitterWidth = 1;
            this.splitContainer1.TabIndex = 10;
            // 
            // Form_HyperGTS
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(635, 328);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.LL_Help);
            this.Controls.Add(this.label3);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(651, 250);
            this.Name = "Form_HyperGTS";
            this.Text = "HyperGTS";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ListBox LB_DNS_Log;
        private System.Windows.Forms.Button BT_DNS;
        private System.Windows.Forms.Label label1;
        private System.ComponentModel.BackgroundWorker BGW_DNS;
        private System.Windows.Forms.TextBox TB_DNS_IP;
        private System.Windows.Forms.LinkLabel LL_DNS_ClearLog;
        private System.Windows.Forms.Label LA_DNS_Status;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button BT_GTS_SendPKMN;
        private System.Windows.Forms.TextBox TB_GTS_SendPKMN;
        private System.Windows.Forms.CheckBox CB_GTS_SendPKMN;
        private System.Windows.Forms.CheckBox CB_GTS_Reject;
        private System.Windows.Forms.CheckBox CB_GTS_SendAfterReceive;
        private System.Windows.Forms.LinkLabel LL_GTS_clearLog;
        private System.Windows.Forms.Button BT_GTS;
        private System.Windows.Forms.Label LA_GTS_Status;
        private System.Windows.Forms.ListBox LB_GTS_Log;
        private System.Windows.Forms.OpenFileDialog OFD_SendPKMN;
        private System.ComponentModel.BackgroundWorker BGW_GTS;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.LinkLabel LL_Help;
        private System.Windows.Forms.RadioButton RB_GTS_SendOne;
        private System.Windows.Forms.RadioButton RB_GTS_SendFolder;
        private System.Windows.Forms.FolderBrowserDialog FBD_GTS_SendFolder;
        private System.Windows.Forms.SplitContainer splitContainer1;
    }
}

