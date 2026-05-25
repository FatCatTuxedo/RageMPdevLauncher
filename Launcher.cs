using Microsoft.Win32;
using System.ComponentModel;
using System.Configuration;
using System.Diagnostics;

namespace RageMPdevLauncher
{
    public partial class RAGEMPdevLauncher : Form
    {
        string subKeyPath = "Software\\RAGE-MP";
        string? legacyPath = ConfigurationManager.AppSettings["legacy_path"];
        string? enhancedPath = ConfigurationManager.AppSettings["enhanced_path"];
        string? ragempPath = ConfigurationManager.AppSettings["ragemp_path"];
        string? cefPort = ConfigurationManager.AppSettings["cef_port"];
        public RAGEMPdevLauncher()
        {
            InitializeComponent();
            string? game_v_path = null;
            string? cefPort = null;
            ragemp_path_label.Text = ragempPath != null ? ragempPath : "Not Set";
            legacyPathLabel.Text = legacyPath != null ? legacyPath : "Not Set";
            enhancedPathLabel.Text = enhancedPath != null ? enhancedPath : "Not Set";
            try
            {
                using (RegistryKey? key = Registry.CurrentUser.OpenSubKey(subKeyPath))
                {
                    if (key != null)
                    {
                        game_v_path = key.GetValue("game_v_path") as string;
                        cefPort = key.GetValue("launch.cefPort") as string;
                        if (cefPort != null)
                        {
                            cefDebug.Checked = true;
                        }
                        if (game_v_path != null)
                        {
                            if (game_v_path.Contains("Enhanced"))
                            {
                                enhanced.Checked = true;
                            }
                            else
                            {
                                legacy.Checked = true;
                            }
                        }
                        else
                        {
                            legacy.Checked = true;
                        }
                    }
                    else
                        MessageBox.Show("An error occurred while reading the registry: RageMP key not found");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while reading the registry: " + ex.Message);
            }
        }

        private void launch_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(ragempPath))
            {
                MessageBox.Show("RAGEMP Path is not set in the configuration file.");
                return;
            }
            const int ERROR_CANCELLED = 1223; //The operation was canceled by the user.

            ProcessStartInfo info = new ProcessStartInfo($@"{ragempPath}\updater.exe");
            info.WorkingDirectory = ragempPath;
            info.UseShellExecute = true;
            info.Verb = "runas";
            try
            {
                Process.Start(info);
            }
            catch (Win32Exception ex)
            {
                if (ex.NativeErrorCode == ERROR_CANCELLED)
                    MessageBox.Show("RAGE MP requires admin rights to run.");
                else
                    throw;
            }
        }

        private void legacy_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(legacyPath))
                {
                    MessageBox.Show("Legacy Path is not set in the configuration file.");
                    return;
                }
                using RegistryKey? myKey = Registry.CurrentUser.OpenSubKey(subKeyPath, true);
                if (myKey != null)
                {
                    myKey.SetValue("game_v_path", legacyPath, RegistryValueKind.String);
                    myKey.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while setting the registry: " + ex.Message);
            }
        }

        private void enhanced_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(enhancedPath))
                {
                    MessageBox.Show("Enhanced Path is not set in the configuration file.");
                    return;
                }
                using RegistryKey? myKey = Registry.CurrentUser.OpenSubKey(subKeyPath, true);
                if (myKey != null)
                {
                    myKey.SetValue("game_v_path", enhancedPath, RegistryValueKind.String);
                    myKey.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while setting the registry: " + ex.Message);
            }
        }

        private void cefDebug_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(cefPort))
                {
                    MessageBox.Show("CEF Port is not set in the configuration file.");
                    return;
                }
                if (cefDebug.Checked)
                {
                    using RegistryKey? myKey = Registry.CurrentUser.OpenSubKey(subKeyPath, true);
                    if (myKey != null)
                    {
                        myKey.SetValue("launch.cefPort", cefPort, RegistryValueKind.String);
                        myKey.Close();
                    }
                }
                else
                {
                    using RegistryKey? myKey = Registry.CurrentUser.OpenSubKey(subKeyPath, true);
                    if (myKey != null)
                    {
                        myKey.DeleteValue("launch.cefPort", false);
                        myKey.Close();
                    }
                }
            }
            catch (Exception ex)  //just for demonstration...it's always best to handle specific exceptions
            {
                MessageBox.Show("An error occurred while setting the registry: " + ex.Message);
            }
        }

        private void settingsRagePath_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folderDlg = new FolderBrowserDialog();
            folderDlg.ShowNewFolderButton = false;
            folderDlg.UseDescriptionForTitle = true;
            folderDlg.Description = "Select your RAGE MP folder (where updater.exe is located)";
            folderDlg.SelectedPath = ragempPath != null ? ragempPath : Environment.SpecialFolder.MyComputer.ToString();
            DialogResult result = folderDlg.ShowDialog();
            if (result == DialogResult.OK)
            {
                if (File.Exists(folderDlg.SelectedPath + "/updater.exe"))
                {
                    MessageBox.Show("RAGE MP Path set to: " + folderDlg.SelectedPath);
                    ragempPath = folderDlg.SelectedPath;
                    ConfigurationManager.AppSettings["ragemp_path"] = ragempPath;
                }
                else
                {
                    MessageBox.Show("The selected folder does not contain updater.exe. Please select the correct RAGE MP folder.");
                }
            }
            else
            {
                MessageBox.Show("Cancelled, the path was not changed.");
            }
        }

        private void settingsEnhancedPath_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folderDlg = new FolderBrowserDialog();
            folderDlg.ShowNewFolderButton = false;
            folderDlg.UseDescriptionForTitle = true;
            folderDlg.Description = "Select your GTA V Enhanced folder (where GTA5_Enhanced.exe is located)";
            folderDlg.SelectedPath = enhancedPath != null ? enhancedPath : Environment.SpecialFolder.MyComputer.ToString();
            DialogResult result = folderDlg.ShowDialog();
            if (result == DialogResult.OK)
            {
                if (File.Exists(folderDlg.SelectedPath + "/GTA5_Enhanced.exe"))
                {
                    MessageBox.Show("GTA V Enhanced Path set to: " + folderDlg.SelectedPath);
                    enhancedPath = folderDlg.SelectedPath;
                    ConfigurationManager.AppSettings["enhanced_path"] = enhancedPath;
                }
                else
                {
                    MessageBox.Show("The selected folder does not contain GTA5_Enhanced.exe. Please select the correct GTA V Enhanced folder.");
                }
            }
            else
            {
                MessageBox.Show("Cancelled, the path was not changed.");
            }
        }

        private void settingsLegacyPath_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folderDlg = new FolderBrowserDialog();
            folderDlg.ShowNewFolderButton = false;
            folderDlg.UseDescriptionForTitle = true;
            folderDlg.Description = "Select your GTA V Legacy folder (where GTA5.exe is located)";
            folderDlg.SelectedPath = legacyPath != null ? legacyPath : Environment.SpecialFolder.MyComputer.ToString();
            DialogResult result = folderDlg.ShowDialog();
            if (result == DialogResult.OK)
            {
                if (File.Exists(folderDlg.SelectedPath + "/GTA5.exe"))
                {
                    MessageBox.Show("GTA V Legacy Path set to: " + folderDlg.SelectedPath);
                    legacyPath = folderDlg.SelectedPath;
                    ConfigurationManager.AppSettings["legacy_path"] = legacyPath;
                }
                else
                {
                    MessageBox.Show("The selected folder does not contain GTA5.exe. Please select the correct GTA V Legacy folder.");
                }
            }
            else
            {
                MessageBox.Show("Cancelled, the path was not changed.");
            }
        }
    }
}
