using Microsoft.Win32;
using System.ComponentModel;
using System.Diagnostics;

namespace RageMPdevLauncher
{
    public partial class RAGEMPdevLauncher : Form
    {
        private const string SubKeyPath = "Software\\RAGE-MP";
        private bool isInitializing = false;

        private string? legacyPath;
        private string? enhancedPath;
        private string? cefPort;
        private string? ragempPath;

        public RAGEMPdevLauncher()
        {
            InitializeComponent();

            isInitializing = true;
            try
            {
                LoadRegistryValues();
                ApplyValuesToUi();
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while reading the registry: " + ex.Message);
            }
            finally
            {
                isInitializing = false;
            }
        }

        private void LoadRegistryValues()
        {
            using RegistryKey? key = Registry.CurrentUser.OpenSubKey(SubKeyPath);
            if (key is null)
            {
                MessageBox.Show("An error occurred while reading the registry: RageMP key not found");
                return;
            }

            legacyPath = key.GetValue("legacy_path") as string;
            enhancedPath = key.GetValue("enhanced_path") as string;
            string? gameVPath = key.GetValue("game_v_path") as string;
            cefPort = key.GetValue("launch.cefPort") as string;
            ragempPath = key.GetValue("rage_path") as string;

            if (ragempPath is null)
                MessageBox.Show("RAGEMP Path is not set in the registry. Is RAGEMP installed?");

            if (enhancedPath is null)
                MessageBox.Show("GTA V Enhanced Path is not set in the registry. Please set it in settings tab.");

            if (legacyPath is null)
                MessageBox.Show("GTA V Legacy Path is not set in the registry. Please set it in settings tab.");

            // Set which game version is selected by registry value
            if (!string.IsNullOrEmpty(gameVPath))
            {
                if (gameVPath.Contains("Enhanced", StringComparison.OrdinalIgnoreCase))
                    enhanced.Checked = true;
                else
                    legacy.Checked = true;
            }
            else
            {
                legacy.Checked = true;
            }

            if (!string.IsNullOrEmpty(cefPort))
                cefDebug.Checked = true;
        }

        private void ApplyValuesToUi()
        {
            legacyPathLabel.Text = legacyPath ?? "Not Set";
            enhancedPathLabel.Text = enhancedPath ?? "Not Set";
        }

        private void launch_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(ragempPath))
            {
                MessageBox.Show("RAGEMP Path is not set in the configuration file.");
                return;
            }

            string updater = Path.Combine(ragempPath, "updater.exe");
            if (!File.Exists(updater))
            {
                MessageBox.Show("Updater not found at: " + updater);
                return;
            }

            const int ERROR_CANCELLED = 1223; // The operation was canceled by the user.

            ProcessStartInfo info = new ProcessStartInfo(updater)
            {
                WorkingDirectory = ragempPath,
                UseShellExecute = true,
                Verb = "runas"
            };

            try
            {
                Process.Start(info);
            }
            catch (Win32Exception ex)
            {
                if (ex.NativeErrorCode == ERROR_CANCELLED)
                    MessageBox.Show("RAGE MP requires admin rights to run.");
                else
                    MessageBox.Show("Error Launching RAGE MP: " + ex.Message);
            }
        }

        private void legacy_CheckedChanged(object sender, EventArgs e)
        {
            if (isInitializing) return;

            try
            {
                if (string.IsNullOrEmpty(legacyPath))
                {
                    MessageBox.Show("Legacy Path is not set in the configuration file.");
                    return;
                }

                if (legacy.Checked)
                    SetRegistryValue("game_v_path", legacyPath);
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while setting the registry: " + ex.Message);
            }
        }

        private void enhanced_CheckedChanged(object sender, EventArgs e)
        {
            if (isInitializing) return;

            try
            {
                if (string.IsNullOrEmpty(enhancedPath))
                {
                    MessageBox.Show("Enhanced Path is not set in the configuration file.");
                    return;
                }

                if (enhanced.Checked)
                    SetRegistryValue("game_v_path", enhancedPath);
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while setting the registry: " + ex.Message);
            }
        }

        private void cefDebug_CheckedChanged(object sender, EventArgs e)
        {
            if (isInitializing) return;

            try
            {

                if (cefDebug.Checked)
                    SetRegistryValue("launch.cefPort", "6969");
                else
                    DeleteRegistryValue("launch.cefPort");
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while setting the registry: " + ex.Message);
            }
        }

        private void settingsEnhancedPath_Click(object sender, EventArgs e)
        {
            try
            {
                using FolderBrowserDialog folderDlg = new FolderBrowserDialog
                {
                    ShowNewFolderButton = false,
                    UseDescriptionForTitle = true,
                    Description = "Select your GTA V Enhanced folder (where GTA5_Enhanced.exe is located)",
                    SelectedPath = enhancedPath ?? string.Empty
                };

                if (folderDlg.ShowDialog() == DialogResult.OK)
                {
                    string candidate = Path.Combine(folderDlg.SelectedPath, "GTA5_Enhanced.exe");
                    if (File.Exists(candidate))
                    {
                        enhancedPath = folderDlg.SelectedPath;
                        //MessageBox.Show("GTA V Enhanced Path set to: " + enhancedPath);
                        SetRegistryValue("enhanced_path", enhancedPath);
                        enhancedPathLabel.Text = enhancedPath;
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
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while setting the path: " + ex.Message);
            }
        }

        private void settingsLegacyPath_Click(object sender, EventArgs e)
        {
            try
            {
                using FolderBrowserDialog folderDlg = new FolderBrowserDialog
                {
                    ShowNewFolderButton = false,
                    UseDescriptionForTitle = true,
                    Description = "Select your GTA V Legacy folder (where GTA5.exe is located)",
                    SelectedPath = legacyPath ?? string.Empty
                };

                if (folderDlg.ShowDialog() == DialogResult.OK)
                {
                    string candidate = Path.Combine(folderDlg.SelectedPath, "GTA5.exe");
                    if (File.Exists(candidate))
                    {
                        legacyPath = folderDlg.SelectedPath;
                        //MessageBox.Show("GTA V Legacy Path set to: " + legacyPath);
                        SetRegistryValue("legacy_path", legacyPath);
                        legacyPathLabel.Text = legacyPath;
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
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while setting the path: " + ex.Message);
            }
        }

        // Registry helper methods
        private void SetRegistryValue(string name, string? value)
        {
            using RegistryKey? key = Registry.CurrentUser.CreateSubKey(SubKeyPath);
            key?.SetValue(name, value ?? string.Empty, RegistryValueKind.String);
        }

        private void DeleteRegistryValue(string name)
        {
            using RegistryKey? key = Registry.CurrentUser.OpenSubKey(SubKeyPath, writable: true);
            key?.DeleteValue(name, throwOnMissingValue: false);
        }
    }
}
