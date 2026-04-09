using Microsoft.Win32;
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
                        cefPort = key.GetValue("cef_port") as string;
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
            catch (Exception ex)  //just for demonstration...it's always best to handle specific exceptions
            {
                //react appropriately
            }
        }

        private void launch_Click(object sender, EventArgs e)
        {
            try
            {
                Process.Start("C:\\RAGEMP\\update.exe");
            }
            catch (Exception ex)
            {
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
                        myKey.SetValue("cef_port", "6969", RegistryValueKind.String);
                        myKey.Close();
                    }
                }
                else
                {
                    using RegistryKey? myKey = Registry.CurrentUser.OpenSubKey(@"Software\RAGE-MP", true);
                    if (myKey != null)
                    {
                        myKey.DeleteValue("cef_port", false);
                        myKey.Close();
                    }
                }
            }
            catch (Exception ex)  //just for demonstration...it's always best to handle specific exceptions
            {
                //react appropriately
            }
        }
    }
}
