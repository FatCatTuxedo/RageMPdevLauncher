using Microsoft.Win32;
using System.ComponentModel;
using System.Diagnostics;

namespace RageMPdevLauncher
{
    public partial class RAGEMPdevLauncher : Form
    {
        public RAGEMPdevLauncher()
        {
            InitializeComponent();
            string? game_v_path = null;
            string? cefPort = null;
            try
            {
                using (RegistryKey? key = Registry.CurrentUser.OpenSubKey("Software\\RAGE-MP"))
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
                            if (game_v_path.Contains("legacy"))
                            {
                                legacy.Checked = true;
                            }
                            else
                            {
                                enhanced.Checked = true;
                            }
                        }
                        else
                        {
                            legacy.Checked = true;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while reading the registry: " + ex.Message);
            }
        }

        private void launch_Click(object sender, EventArgs e)
        {
            const int ERROR_CANCELLED = 1223; //The operation was canceled by the user.

            ProcessStartInfo info = new ProcessStartInfo(@"C:\RAGEMP\updater.exe");
            info.WorkingDirectory = @"C:\RAGEMP\";
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
                using RegistryKey? myKey = Registry.CurrentUser.OpenSubKey(@"Software\RAGE-MP", true);
                if (myKey != null)
                {
                    myKey.SetValue("game_v_path", "C:\\Program Files (x86)\\Steam\\steamapps\\common\\Grand Theft Auto V", RegistryValueKind.String);
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
                using RegistryKey? myKey = Registry.CurrentUser.OpenSubKey(@"Software\RAGE-MP", true);
                if (myKey != null)
                {
                    myKey.SetValue("game_v_path", "C:\\Program Files (x86)\\Steam\\steamapps\\common\\Grand Theft Auto V Enhanced", RegistryValueKind.String);
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
                if (cefDebug.Checked)
                {
                    using RegistryKey? myKey = Registry.CurrentUser.OpenSubKey(@"Software\RAGE-MP", true);
                    if (myKey != null)
                    {
                        myKey.SetValue("launch.cefPort", "6969", RegistryValueKind.String);
                        myKey.Close();
                    }
                }
                else
                {
                    using RegistryKey? myKey = Registry.CurrentUser.OpenSubKey(@"Software\RAGE-MP", true);
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
    }
}
