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
                    description = "Run a saved configuration",
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
            lstMain.Items.AddRange(Settings.SavedConfigurations.Select(createItem).ToArray());

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

        private void RunAsUser_Load(object sender, EventArgs e) {

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

        // ListView helpers
        private ListViewItem updateItem(ListViewItem item, SavedConfiguration itemInfo) {
            item.Tag = itemInfo;
            item.Text = itemInfo.Name;
            item.SubItems[1].Text = itemInfo.Filename;
            item.SubItems[2].Text = itemInfo.Arguments;
            item.SubItems[3].Text = itemInfo.UserName;
            item.SubItems[4].Text = itemInfo.Domain;
            return item;
        }
        private ListViewItem createItem(SavedConfiguration itemInfo) =>
            updateItem(new ListViewItem(Enumerable.Repeat(string.Empty, 5).ToArray()), itemInfo);
        private SavedConfiguration getItemInfo(ListViewItem item) =>
            (SavedConfiguration)item.Tag;

        private void loadToEdit(SavedConfiguration data) {
            if (data == null) {
                grpEdit.Enabled = false;
                txtEditName.Text = null;
                txtEditFile.Text = null;
                txtEditArgs.Text = null;
                txtEditUsername.Text = null;
                txtEditPassword.Text = null;
                txtEditDomain.Text = null;
            } else {
                grpEdit.Enabled = true;
                txtEditName.Text = data.Name;
                txtEditFile.Text = data.Filename;
                txtEditArgs.Text = data.Arguments;
                txtEditUsername.Text = data.UserName;
                txtEditPassword.Text = data.Password;
                txtEditDomain.Text = data.Domain;
            }
        }
        private SavedConfiguration saveToItem() =>
            new SavedConfiguration() {
                Name = txtEditName.Text,
                Filename = txtEditFile.Text,
                Arguments = txtEditArgs.Text,
                UserName = txtEditUsername.Text,
                Password = txtEditPassword.Text,
                Domain = txtEditDomain.Text,
            };

        public DialogResult MessageBox(string text, string caption = null, MessageBoxButtons buttons = MessageBoxButtons.OK, MessageBoxIcon style = MessageBoxIcon.None, WinVersionStyle winVersion = WinVersionStyle.Win10) =>
            WalkmanLib.CustomMsgBox(text, theme, caption ?? this.Text, buttons, style, winVersion, ownerForm: this);
        private void saveItemsToSettings() =>
            Settings.UpdateConfigurations(lstMain.Items.OfType<ListViewItem>().Select(getItemInfo).ToList());

        private void lstMain_SelectedIndexChanged(object sender, EventArgs e) {
            bool itemSelected = lstMain.SelectedItems.Count > 0;
            grpEdit.Enabled = itemSelected;
            btnRemove.Enabled = itemSelected;
            btnRun.Enabled = itemSelected;
            loadToEdit(itemSelected ? getItemInfo(lstMain.SelectedItems[0]) : null);
        }

        private void lstMain_ItemActivate(object sender, EventArgs e) =>
            btnRun.PerformClick();
        private void lstMain_AfterLabelEdit(object sender, LabelEditEventArgs e) =>
            saveItemsToSettings();
        private void lstMain_ColumnClick(object sender, ColumnClickEventArgs e) {
            if (e.Column == 0) {
                lstMain.Sorting = lstMain.Sorting == SortOrder.Ascending ? SortOrder.Descending : SortOrder.Ascending;
            }
        }
        private void btnAdd_Click(object sender, EventArgs e) {
            lstMain.Items.Add(createItem(new SavedConfiguration())).Selected = true;
            lstMain.Select();
            lstMain.Focus();
            btnEditFile.PerformClick();
        }
        private void btnRemove_Click(object sender, EventArgs e) {
            lstMain.Items.Remove(lstMain.SelectedItems[0]);
            lstMain.Select();
            lstMain.Focus();
            saveItemsToSettings();
        }
        private async void btnRun_Click(object sender, EventArgs e) {
            try {
                scMain.IsSplitterFixed = true;
                lstMain.Enabled = false;
                btnAdd.Enabled = false;
                btnRemove.Enabled = false;
                grpEdit.Enabled = false;
                btnRun.Enabled = false;
                await System.Threading.Tasks.Task.Run(() => Helpers.StartConfig(getItemInfo(lstMain.SelectedItems[0])));
            } finally {
                scMain.IsSplitterFixed = false;
                lstMain.Enabled = true;
                btnAdd.Enabled = true;
                btnRemove.Enabled = true;
                grpEdit.Enabled = true;
                btnRun.Enabled = true;
            }
        }

        private void btnExit_Click(object sender, EventArgs e) =>
            Application.Exit();

        private void txtBoxesChanged(object sender, EventArgs e) {
            if (lstMain.SelectedItems.Count > 0) {
                updateItem(lstMain.SelectedItems[0], saveToItem());
                saveItemsToSettings();
            }
        }

        private void btnEditName_Click(object sender, EventArgs e) {
            var name = txtEditName.Text;
            if (WalkmanLib.InputDialog(ref name, theme, "Enter Config Name", this.Text, owner: this) == DialogResult.OK)
                txtEditName.Text = name;
        }
        private void btnEditFile_Click(object sender, EventArgs e) {
            if (!string.IsNullOrWhiteSpace(txtEditFile.Text))
                ofdFileSelector.InitialDirectory = System.IO.Path.GetDirectoryName(txtEditFile.Text);
            ofdFileSelector.FileName = System.IO.Path.GetFileName(txtEditFile.Text);
            if (ofdFileSelector.ShowDialog() == DialogResult.OK)
                txtEditFile.Text = ofdFileSelector.FileName;
        }
        private void btnEditArgs_Click(object sender, EventArgs e) {
            var args = txtEditArgs.Text;
            if (WalkmanLib.InputDialog(ref args, theme, "Enter Program Args", this.Text, owner: this) == DialogResult.OK)
                txtEditArgs.Text = args;
        }
        private void btnEditUsername_Click(object sender, EventArgs e) {
            var usersList = string.Join(Environment.NewLine, new[] { "Available Users:" }.Concat(Helpers.GetLocalUserNames()));
            var username = txtEditUsername.Text;
            if (WalkmanLib.InputDialog(ref username, theme, "Enter Username", this.Text, usersList, owner: this) == DialogResult.OK)
                txtEditUsername.Text = username;
        }
        private void btnEditPassword_Click(object sender, EventArgs e) {
            var pwd = txtEditPassword.Text;
            if (WalkmanLib.InputDialog(ref pwd, theme, "Enter Password", this.Text, owner: this) == DialogResult.OK)
                txtEditPassword.Text = pwd;
        }
        private void btnEditDomain_Click(object sender, EventArgs e) {
            var domain = txtEditDomain.Text;
            if (WalkmanLib.InputDialog(ref domain, theme, "Enter Domain Name", this.Text, "Leave blank for local machine", owner: this) == DialogResult.OK)
                txtEditDomain.Text = domain;
        }
    }
}
