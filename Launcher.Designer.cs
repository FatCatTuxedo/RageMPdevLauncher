namespace RageMPdevLauncher
{
    partial class RAGEMPdevLauncher
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RAGEMPdevLauncher));
            groupBox1 = new GroupBox();
            enhanced = new RadioButton();
            legacy = new RadioButton();
            cefDebug = new CheckBox();
            launch = new Button();
            tabControl = new TabControl();
            LauncherPage = new TabPage();
            pictureBox1 = new PictureBox();
            SettingsPage = new TabPage();
            groupBox4 = new GroupBox();
            legacyPathLabel = new Label();
            settingsLegacyPath = new Button();
            groupBox3 = new GroupBox();
            enhancedPathLabel = new Label();
            settingsEnhancedPath = new Button();
            groupBox2 = new GroupBox();
            ragemp_path_label = new Label();
            settingsRagePath = new Button();
            groupBox1.SuspendLayout();
            tabControl.SuspendLayout();
            LauncherPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SettingsPage.SuspendLayout();
            groupBox4.SuspendLayout();
            groupBox3.SuspendLayout();
            groupBox2.SuspendLayout();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(enhanced);
            groupBox1.Controls.Add(legacy);
            groupBox1.Location = new Point(6, 6);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(376, 82);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "Game Version";
            // 
            // enhanced
            // 
            enhanced.AutoSize = true;
            enhanced.Location = new Point(6, 47);
            enhanced.Name = "enhanced";
            enhanced.Size = new Size(77, 19);
            enhanced.TabIndex = 1;
            enhanced.TabStop = true;
            enhanced.Text = "Enhanced";
            enhanced.UseVisualStyleBackColor = true;
            enhanced.CheckedChanged += enhanced_CheckedChanged;
            // 
            // legacy
            // 
            legacy.AutoSize = true;
            legacy.Location = new Point(6, 22);
            legacy.Name = "legacy";
            legacy.Size = new Size(62, 19);
            legacy.TabIndex = 0;
            legacy.TabStop = true;
            legacy.Text = "Legacy";
            legacy.UseVisualStyleBackColor = true;
            legacy.CheckedChanged += legacy_CheckedChanged;
            // 
            // cefDebug
            // 
            cefDebug.AutoSize = true;
            cefDebug.Location = new Point(393, 19);
            cefDebug.Name = "cefDebug";
            cefDebug.Size = new Size(101, 19);
            cefDebug.TabIndex = 1;
            cefDebug.Text = "CEF Debuging";
            cefDebug.UseVisualStyleBackColor = true;
            cefDebug.CheckedChanged += cefDebug_CheckedChanged;
            // 
            // launch
            // 
            launch.Location = new Point(388, 44);
            launch.Name = "launch";
            launch.Size = new Size(136, 41);
            launch.TabIndex = 2;
            launch.Text = "Launch RAGE MP";
            launch.UseVisualStyleBackColor = true;
            launch.Click += launch_Click;
            // 
            // tabControl
            // 
            tabControl.Controls.Add(LauncherPage);
            tabControl.Controls.Add(SettingsPage);
            tabControl.Location = new Point(12, 12);
            tabControl.Name = "tabControl";
            tabControl.SelectedIndex = 0;
            tabControl.Size = new Size(538, 202);
            tabControl.TabIndex = 3;
            // 
            // LauncherPage
            // 
            LauncherPage.Controls.Add(pictureBox1);
            LauncherPage.Controls.Add(launch);
            LauncherPage.Controls.Add(groupBox1);
            LauncherPage.Controls.Add(cefDebug);
            LauncherPage.Location = new Point(4, 24);
            LauncherPage.Name = "LauncherPage";
            LauncherPage.Padding = new Padding(3);
            LauncherPage.Size = new Size(530, 174);
            LauncherPage.TabIndex = 0;
            LauncherPage.Text = "Launcher";
            LauncherPage.UseVisualStyleBackColor = true;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.icon;
            pictureBox1.Location = new Point(6, 94);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(518, 74);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 3;
            pictureBox1.TabStop = false;
            // 
            // SettingsPage
            // 
            SettingsPage.Controls.Add(groupBox4);
            SettingsPage.Controls.Add(groupBox3);
            SettingsPage.Controls.Add(groupBox2);
            SettingsPage.Location = new Point(4, 24);
            SettingsPage.Name = "SettingsPage";
            SettingsPage.Padding = new Padding(3);
            SettingsPage.Size = new Size(530, 174);
            SettingsPage.TabIndex = 1;
            SettingsPage.Text = "Settings";
            SettingsPage.UseVisualStyleBackColor = true;
            // 
            // groupBox4
            // 
            groupBox4.Controls.Add(legacyPathLabel);
            groupBox4.Controls.Add(settingsLegacyPath);
            groupBox4.Location = new Point(6, 119);
            groupBox4.Name = "groupBox4";
            groupBox4.Size = new Size(518, 47);
            groupBox4.TabIndex = 3;
            groupBox4.TabStop = false;
            groupBox4.Text = "GTA V Legacy Path";
            // 
            // legacyPathLabel
            // 
            legacyPathLabel.Location = new Point(9, 22);
            legacyPathLabel.Name = "legacyPathLabel";
            legacyPathLabel.Size = new Size(441, 19);
            legacyPathLabel.TabIndex = 1;
            legacyPathLabel.Text = "C:\\Program Files (x86)\\Steam\\steamapps\\common\\Grand Theft Auto V";
            // 
            // settingsLegacyPath
            // 
            settingsLegacyPath.Location = new Point(456, 18);
            settingsLegacyPath.Name = "settingsLegacyPath";
            settingsLegacyPath.Size = new Size(56, 23);
            settingsLegacyPath.TabIndex = 0;
            settingsLegacyPath.Text = "Change";
            settingsLegacyPath.UseVisualStyleBackColor = true;
            settingsLegacyPath.Click += settingsLegacyPath_Click;
            // 
            // groupBox3
            // 
            groupBox3.Controls.Add(enhancedPathLabel);
            groupBox3.Controls.Add(settingsEnhancedPath);
            groupBox3.Location = new Point(6, 65);
            groupBox3.Name = "groupBox3";
            groupBox3.Size = new Size(518, 48);
            groupBox3.TabIndex = 2;
            groupBox3.TabStop = false;
            groupBox3.Text = "GTA V Enhanced Path";
            // 
            // enhancedPathLabel
            // 
            enhancedPathLabel.Location = new Point(9, 22);
            enhancedPathLabel.Name = "enhancedPathLabel";
            enhancedPathLabel.Size = new Size(442, 19);
            enhancedPathLabel.TabIndex = 1;
            enhancedPathLabel.Text = "C:\\Program Files (x86)\\Steam\\steamapps\\common\\Grand Theft Auto V Enhanced";
            // 
            // settingsEnhancedPath
            // 
            settingsEnhancedPath.Location = new Point(457, 18);
            settingsEnhancedPath.Name = "settingsEnhancedPath";
            settingsEnhancedPath.Size = new Size(56, 23);
            settingsEnhancedPath.TabIndex = 0;
            settingsEnhancedPath.Text = "Change";
            settingsEnhancedPath.UseVisualStyleBackColor = true;
            settingsEnhancedPath.Click += settingsEnhancedPath_Click;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(ragemp_path_label);
            groupBox2.Controls.Add(settingsRagePath);
            groupBox2.Location = new Point(6, 8);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(518, 51);
            groupBox2.TabIndex = 1;
            groupBox2.TabStop = false;
            groupBox2.Text = "RAGEMP Path";
            // 
            // ragemp_path_label
            // 
            ragemp_path_label.Location = new Point(9, 22);
            ragemp_path_label.Name = "ragemp_path_label";
            ragemp_path_label.Size = new Size(441, 19);
            ragemp_path_label.TabIndex = 1;
            ragemp_path_label.Text = "RAGE MP Path";
            // 
            // settingsRagePath
            // 
            settingsRagePath.Location = new Point(456, 18);
            settingsRagePath.Name = "settingsRagePath";
            settingsRagePath.Size = new Size(56, 23);
            settingsRagePath.TabIndex = 0;
            settingsRagePath.Text = "Change";
            settingsRagePath.UseVisualStyleBackColor = true;
            settingsRagePath.Click += settingsRagePath_Click;
            // 
            // RAGEMPdevLauncher
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(553, 218);
            Controls.Add(tabControl);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "RAGEMPdevLauncher";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "RAGE MP Dev Launcher";
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            tabControl.ResumeLayout(false);
            LauncherPage.ResumeLayout(false);
            LauncherPage.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            SettingsPage.ResumeLayout(false);
            groupBox4.ResumeLayout(false);
            groupBox3.ResumeLayout(false);
            groupBox2.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private GroupBox groupBox1;
        private RadioButton enhanced;
        private RadioButton legacy;
        private CheckBox cefDebug;
        private Button launch;
        private TabControl tabControl;
        private TabPage LauncherPage;
        private TabPage SettingsPage;
        private Button settingsRagePath;
        private GroupBox groupBox2;
        private Label ragemp_path_label;
        private GroupBox groupBox3;
        private Label enhancedPathLabel;
        private Button settingsEnhancedPath;
        private GroupBox groupBox4;
        private Label legacyPathLabel;
        private Button settingsLegacyPath;
        private PictureBox pictureBox1;
    }
}
