namespace ChineseCheckers
{
    partial class mainForm
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tutorialToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.chineseCheckersLabel = new System.Windows.Forms.Label();
            this.numHumansBox = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.numNPCbox = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.startGameBtn = new System.Windows.Forms.Button();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(568, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(132, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tutorialToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // tutorialToolStripMenuItem
            // 
            this.tutorialToolStripMenuItem.Name = "tutorialToolStripMenuItem";
            this.tutorialToolStripMenuItem.Size = new System.Drawing.Size(115, 22);
            this.tutorialToolStripMenuItem.Text = "Tutorial";
            this.tutorialToolStripMenuItem.Click += new System.EventHandler(this.helpTutorial_Click);
            // 
            // chineseCheckersLabel
            // 
            this.chineseCheckersLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.chineseCheckersLabel.AutoSize = true;
            this.chineseCheckersLabel.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.chineseCheckersLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F);
            this.chineseCheckersLabel.Location = new System.Drawing.Point(8, 39);
            this.chineseCheckersLabel.Name = "chineseCheckersLabel";
            this.chineseCheckersLabel.Size = new System.Drawing.Size(146, 20);
            this.chineseCheckersLabel.TabIndex = 5;
            this.chineseCheckersLabel.Text = "Chinese Checkers";
            this.chineseCheckersLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // numHumansBox
            // 
            this.numHumansBox.FormattingEnabled = true;
            this.numHumansBox.Items.AddRange(new object[] {
            "0",
            "1",
            "2",
            "3",
            "4",
            "5",
            "6"});
            this.numHumansBox.Location = new System.Drawing.Point(202, 232);
            this.numHumansBox.MaxDropDownItems = 7;
            this.numHumansBox.Name = "numHumansBox";
            this.numHumansBox.Size = new System.Drawing.Size(35, 21);
            this.numHumansBox.TabIndex = 7;
            this.numHumansBox.SelectedIndexChanged += new System.EventHandler(this.numHumansBox_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(243, 235);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 13);
            this.label2.TabIndex = 9;
            this.label2.Text = "Human players";
            // 
            // numNPCbox
            // 
            this.numNPCbox.AutoSize = true;
            this.numNPCbox.Location = new System.Drawing.Point(224, 256);
            this.numNPCbox.Name = "numNPCbox";
            this.numNPCbox.Size = new System.Drawing.Size(13, 13);
            this.numNPCbox.TabIndex = 10;
            this.numNPCbox.Text = "0";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(243, 256);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(88, 13);
            this.label1.TabIndex = 11;
            this.label1.Text = "Computer players";
            // 
            // startGameBtn
            // 
            this.startGameBtn.Location = new System.Drawing.Point(202, 272);
            this.startGameBtn.Name = "startGameBtn";
            this.startGameBtn.Size = new System.Drawing.Size(129, 23);
            this.startGameBtn.TabIndex = 12;
            this.startGameBtn.Text = "Start Game";
            this.startGameBtn.UseVisualStyleBackColor = true;
            this.startGameBtn.Click += new System.EventHandler(this.startGameBtn_Click);
            // 
            // mainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::ChineseCheckers.Properties.Resources.menuart;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(568, 325);
            this.Controls.Add(this.startGameBtn);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.numNPCbox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.numHumansBox);
            this.Controls.Add(this.chineseCheckersLabel);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "mainForm";
            this.Text = "mainForm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.mainForm_FormClosing);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tutorialToolStripMenuItem;
        private System.Windows.Forms.Label chineseCheckersLabel;
        private System.Windows.Forms.ComboBox numHumansBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label numNPCbox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button startGameBtn;
    }
}

