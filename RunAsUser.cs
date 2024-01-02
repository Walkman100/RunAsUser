using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace RunAsUser {
    public partial class RunAsUser : Form {
        readonly WalkmanLib.Theme theme = WalkmanLib.Theme.Default;
        readonly Dictionary<string, WalkmanLib.FlagInfo> flags;

        public RunAsUser() {
            flags = new Dictionary<string, WalkmanLib.FlagInfo>() {
                { "run", new WalkmanLib.FlagInfo() {
                    shortFlag = 'r',
                    hasArgs = true,
                    optionalArgs = false,
                    argsInfo = "[config name]",
                    description = "Run a saved confifuration",
                    action = commandLineStart,
                } },
                { "help", new WalkmanLib.FlagInfo() {
                    shortFlag = 'h',
                    description = "Show Help",
                    hasArgs = true,
                    optionalArgs = true,
                    argsInfo = "[flag]",
                    action = showUsage,
                } }
            };
            InitializeComponent();
            lstMain.SetDoubleBuffered(true);

            if (WalkmanLib.GetDarkThemeEnabled() ?? false)
                theme = WalkmanLib.Theme.Dark;
            lstMain.DrawColumnHeader += WalkmanLib.CustomPaint.ListView_DrawCustomColumnHeader;
            lstMain.DrawItem += WalkmanLib.CustomPaint.ListView_DrawDefaultItem;
            lstMain.DrawSubItem += WalkmanLib.CustomPaint.ListView_DrawDefaultSubItem;
            lstMain.Tag = theme.ListViewColumnColors;
            WalkmanLib.ApplyTheme(theme, this, true);
            Settings.Init();

            string[] args = Environment.GetCommandLineArgs().Skip(1).ToArray();
            var res = WalkmanLib.ProcessArgs(args, flags);
            if (res.gotError) {
                MessageBox(res.errorInfo, "Error processing arguments", style: MessageBoxIcon.Error);

                while (0 == 0) {
                    Application.Exit();
                    Environment.Exit(-1);
                }
            }
        }

        private bool showUsage(string input) {
            using (var sw = new System.IO.StringWriter()) {
                WalkmanLib.EchoHelp(flags, input, sw);
                MessageBox(sw.ToString(), "Program Usage", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            Application.Exit();
            Environment.Exit(0);
            return true;
        }

        private bool commandLineStart(string name) {
            var config = Settings.SavedConfigurations.FirstOrDefault(c => c.Name == name);
            if (config == null) {
                MessageBox($"Could not find config \"{name}\"!", caption: "Error Running Config", style: MessageBoxIcon.Error);

                Application.Exit();
                Environment.Exit(-1);
                return true;
            }
            Helpers.StartConfig(config);

            Application.Exit();
            Environment.Exit(0);
            return true;
        }

        public DialogResult MessageBox(string text, string caption = null, MessageBoxButtons buttons = MessageBoxButtons.OK, MessageBoxIcon style = MessageBoxIcon.None, WinVersionStyle winVersion = WinVersionStyle.Win10) =>
            WalkmanLib.CustomMsgBox(text, theme, caption ?? this.Text, buttons, style, winVersion, ownerForm: this);
    }
}
