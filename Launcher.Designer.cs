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
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(enhanced);
            groupBox1.Controls.Add(legacy);
            groupBox1.Location = new Point(12, 12);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(123, 82);
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
            cefDebug.Location = new Point(141, 12);
            cefDebug.Name = "cefDebug";
            cefDebug.Size = new Size(101, 19);
            cefDebug.TabIndex = 1;
            cefDebug.Text = "CEF Debuging";
            cefDebug.UseVisualStyleBackColor = true;
            cefDebug.CheckedChanged += cefDebug_CheckedChanged;
            // 
            // launch
            // 
            launch.Location = new Point(141, 45);
            launch.Name = "launch";
            launch.Size = new Size(101, 41);
            launch.TabIndex = 2;
            launch.Text = "Launch RAGE MP";
            launch.UseVisualStyleBackColor = true;
            launch.Click += launch_Click;
            // 
            // RAGEMPdevLauncher
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(254, 98);
            Controls.Add(launch);
            Controls.Add(cefDebug);
            Controls.Add(groupBox1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "RAGEMPdevLauncher";
            Text = "RAGE MP Dev Launcher";
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private GroupBox groupBox1;
        private RadioButton enhanced;
        private RadioButton legacy;
        private CheckBox cefDebug;
        private Button launch;
    }
}
