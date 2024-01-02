namespace RunAsUser {
    partial class RunAsUser {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.lstMain = new System.Windows.Forms.ListView();
            this.colName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colFile = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colArgs = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colUsername = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colDomain = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnRemove = new System.Windows.Forms.Button();
            this.btnRun = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.grpEdit = new System.Windows.Forms.GroupBox();
            this.btnEditDomain = new System.Windows.Forms.Button();
            this.btnEditPassword = new System.Windows.Forms.Button();
            this.btnEditUsername = new System.Windows.Forms.Button();
            this.btnEditArgs = new System.Windows.Forms.Button();
            this.btnEditFile = new System.Windows.Forms.Button();
            this.btnEditName = new System.Windows.Forms.Button();
            this.txtEditDomain = new System.Windows.Forms.TextBox();
            this.lblEditDomain = new System.Windows.Forms.Label();
            this.txtEditPassword = new System.Windows.Forms.TextBox();
            this.lblEditPassword = new System.Windows.Forms.Label();
            this.txtEditUsername = new System.Windows.Forms.TextBox();
            this.lblEditUsername = new System.Windows.Forms.Label();
            this.txtEditArgs = new System.Windows.Forms.TextBox();
            this.lblEditArgs = new System.Windows.Forms.Label();
            this.txtEditFile = new System.Windows.Forms.TextBox();
            this.lblEditFile = new System.Windows.Forms.Label();
            this.txtEditName = new System.Windows.Forms.TextBox();
            this.lblEditName = new System.Windows.Forms.Label();
            this.ofdFileSelector = new System.Windows.Forms.OpenFileDialog();
            this.scMain = new System.Windows.Forms.SplitContainer();
            this.grpEdit.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.scMain)).BeginInit();
            this.scMain.Panel1.SuspendLayout();
            this.scMain.Panel2.SuspendLayout();
            this.scMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // lstMain
            // 
            this.lstMain.AllowColumnReorder = true;
            this.lstMain.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colName,
            this.colFile,
            this.colArgs,
            this.colUsername,
            this.colDomain});
            this.lstMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstMain.FullRowSelect = true;
            this.lstMain.GridLines = true;
            this.lstMain.HideSelection = false;
            this.lstMain.LabelEdit = true;
            this.lstMain.Location = new System.Drawing.Point(0, 0);
            this.lstMain.MultiSelect = false;
            this.lstMain.Name = "lstMain";
            this.lstMain.Size = new System.Drawing.Size(804, 335);
            this.lstMain.TabIndex = 0;
            this.lstMain.UseCompatibleStateImageBehavior = false;
            this.lstMain.View = System.Windows.Forms.View.Details;
            // 
            // colName
            // 
            this.colName.Text = "Name";
            this.colName.Width = 100;
            // 
            // colFile
            // 
            this.colFile.Text = "File";
            this.colFile.Width = 250;
            // 
            // colArgs
            // 
            this.colArgs.Text = "Arguments";
            this.colArgs.Width = 250;
            // 
            // colUsername
            // 
            this.colUsername.Text = "Username";
            this.colUsername.Width = 100;
            // 
            // colDomain
            // 
            this.colDomain.Text = "Domain";
            this.colDomain.Width = 100;
            // 
            // btnAdd
            // 
            this.btnAdd.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.btnAdd.Location = new System.Drawing.Point(3, 12);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(100, 23);
            this.btnAdd.TabIndex = 1;
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyleBackColor = true;
            // 
            // btnRemove
            // 
            this.btnRemove.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.btnRemove.Enabled = false;
            this.btnRemove.Location = new System.Drawing.Point(109, 12);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(100, 23);
            this.btnRemove.TabIndex = 2;
            this.btnRemove.Text = "Remove";
            this.btnRemove.UseVisualStyleBackColor = true;
            // 
            // btnRun
            // 
            this.btnRun.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.btnRun.Enabled = false;
            this.btnRun.Location = new System.Drawing.Point(3, 300);
            this.btnRun.Name = "btnRun";
            this.btnRun.Size = new System.Drawing.Size(100, 23);
            this.btnRun.TabIndex = 3;
            this.btnRun.Text = "Run";
            this.btnRun.UseVisualStyleBackColor = true;
            // 
            // btnExit
            // 
            this.btnExit.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.btnExit.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnExit.Location = new System.Drawing.Point(109, 300);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(100, 23);
            this.btnExit.TabIndex = 4;
            this.btnExit.Text = "Exit";
            this.btnExit.UseVisualStyleBackColor = true;
            // 
            // grpEdit
            // 
            this.grpEdit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.grpEdit.Controls.Add(this.btnEditDomain);
            this.grpEdit.Controls.Add(this.btnEditPassword);
            this.grpEdit.Controls.Add(this.btnEditUsername);
            this.grpEdit.Controls.Add(this.btnEditArgs);
            this.grpEdit.Controls.Add(this.btnEditFile);
            this.grpEdit.Controls.Add(this.btnEditName);
            this.grpEdit.Controls.Add(this.txtEditDomain);
            this.grpEdit.Controls.Add(this.lblEditDomain);
            this.grpEdit.Controls.Add(this.txtEditPassword);
            this.grpEdit.Controls.Add(this.lblEditPassword);
            this.grpEdit.Controls.Add(this.txtEditUsername);
            this.grpEdit.Controls.Add(this.lblEditUsername);
            this.grpEdit.Controls.Add(this.txtEditArgs);
            this.grpEdit.Controls.Add(this.lblEditArgs);
            this.grpEdit.Controls.Add(this.txtEditFile);
            this.grpEdit.Controls.Add(this.lblEditFile);
            this.grpEdit.Controls.Add(this.txtEditName);
            this.grpEdit.Controls.Add(this.lblEditName);
            this.grpEdit.Enabled = false;
            this.grpEdit.Location = new System.Drawing.Point(3, 41);
            this.grpEdit.Name = "grpEdit";
            this.grpEdit.Size = new System.Drawing.Size(206, 253);
            this.grpEdit.TabIndex = 5;
            this.grpEdit.TabStop = false;
            this.grpEdit.Text = "Edit";
            // 
            // btnEditDomain
            // 
            this.btnEditDomain.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEditDomain.Location = new System.Drawing.Point(176, 225);
            this.btnEditDomain.Name = "btnEditDomain";
            this.btnEditDomain.Size = new System.Drawing.Size(24, 23);
            this.btnEditDomain.TabIndex = 23;
            this.btnEditDomain.Text = "...";
            this.btnEditDomain.UseVisualStyleBackColor = true;
            // 
            // btnEditPassword
            // 
            this.btnEditPassword.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEditPassword.Location = new System.Drawing.Point(176, 186);
            this.btnEditPassword.Name = "btnEditPassword";
            this.btnEditPassword.Size = new System.Drawing.Size(24, 23);
            this.btnEditPassword.TabIndex = 22;
            this.btnEditPassword.Text = "...";
            this.btnEditPassword.UseVisualStyleBackColor = true;
            // 
            // btnEditUsername
            // 
            this.btnEditUsername.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEditUsername.Location = new System.Drawing.Point(176, 147);
            this.btnEditUsername.Name = "btnEditUsername";
            this.btnEditUsername.Size = new System.Drawing.Size(24, 23);
            this.btnEditUsername.TabIndex = 21;
            this.btnEditUsername.Text = "...";
            this.btnEditUsername.UseVisualStyleBackColor = true;
            // 
            // btnEditArgs
            // 
            this.btnEditArgs.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEditArgs.Location = new System.Drawing.Point(176, 108);
            this.btnEditArgs.Name = "btnEditArgs";
            this.btnEditArgs.Size = new System.Drawing.Size(24, 23);
            this.btnEditArgs.TabIndex = 20;
            this.btnEditArgs.Text = "...";
            this.btnEditArgs.UseVisualStyleBackColor = true;
            // 
            // btnEditFile
            // 
            this.btnEditFile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEditFile.Location = new System.Drawing.Point(176, 69);
            this.btnEditFile.Name = "btnEditFile";
            this.btnEditFile.Size = new System.Drawing.Size(24, 23);
            this.btnEditFile.TabIndex = 19;
            this.btnEditFile.Text = "...";
            this.btnEditFile.UseVisualStyleBackColor = true;
            // 
            // btnEditName
            // 
            this.btnEditName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEditName.Location = new System.Drawing.Point(176, 30);
            this.btnEditName.Name = "btnEditName";
            this.btnEditName.Size = new System.Drawing.Size(24, 23);
            this.btnEditName.TabIndex = 18;
            this.btnEditName.Text = "...";
            this.btnEditName.UseVisualStyleBackColor = true;
            // 
            // txtEditDomain
            // 
            this.txtEditDomain.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtEditDomain.Location = new System.Drawing.Point(6, 227);
            this.txtEditDomain.Name = "txtEditDomain";
            this.txtEditDomain.Size = new System.Drawing.Size(170, 20);
            this.txtEditDomain.TabIndex = 17;
            // 
            // lblEditDomain
            // 
            this.lblEditDomain.AutoSize = true;
            this.lblEditDomain.Location = new System.Drawing.Point(6, 211);
            this.lblEditDomain.Name = "lblEditDomain";
            this.lblEditDomain.Size = new System.Drawing.Size(43, 13);
            this.lblEditDomain.TabIndex = 16;
            this.lblEditDomain.Text = "Domain";
            // 
            // txtEditPassword
            // 
            this.txtEditPassword.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtEditPassword.Location = new System.Drawing.Point(6, 188);
            this.txtEditPassword.Name = "txtEditPassword";
            this.txtEditPassword.PasswordChar = '●';
            this.txtEditPassword.Size = new System.Drawing.Size(170, 20);
            this.txtEditPassword.TabIndex = 15;
            // 
            // lblEditPassword
            // 
            this.lblEditPassword.AutoSize = true;
            this.lblEditPassword.Location = new System.Drawing.Point(6, 172);
            this.lblEditPassword.Name = "lblEditPassword";
            this.lblEditPassword.Size = new System.Drawing.Size(53, 13);
            this.lblEditPassword.TabIndex = 14;
            this.lblEditPassword.Text = "Password";
            // 
            // txtEditUsername
            // 
            this.txtEditUsername.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtEditUsername.Location = new System.Drawing.Point(6, 149);
            this.txtEditUsername.Name = "txtEditUsername";
            this.txtEditUsername.Size = new System.Drawing.Size(170, 20);
            this.txtEditUsername.TabIndex = 13;
            // 
            // lblEditUsername
            // 
            this.lblEditUsername.AutoSize = true;
            this.lblEditUsername.Location = new System.Drawing.Point(6, 133);
            this.lblEditUsername.Name = "lblEditUsername";
            this.lblEditUsername.Size = new System.Drawing.Size(55, 13);
            this.lblEditUsername.TabIndex = 12;
            this.lblEditUsername.Text = "Username";
            // 
            // txtEditArgs
            // 
            this.txtEditArgs.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtEditArgs.Location = new System.Drawing.Point(6, 110);
            this.txtEditArgs.Name = "txtEditArgs";
            this.txtEditArgs.Size = new System.Drawing.Size(170, 20);
            this.txtEditArgs.TabIndex = 11;
            // 
            // lblEditArgs
            // 
            this.lblEditArgs.AutoSize = true;
            this.lblEditArgs.Location = new System.Drawing.Point(6, 94);
            this.lblEditArgs.Name = "lblEditArgs";
            this.lblEditArgs.Size = new System.Drawing.Size(57, 13);
            this.lblEditArgs.TabIndex = 10;
            this.lblEditArgs.Text = "Arguments";
            // 
            // txtEditFile
            // 
            this.txtEditFile.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtEditFile.Location = new System.Drawing.Point(6, 71);
            this.txtEditFile.Name = "txtEditFile";
            this.txtEditFile.Size = new System.Drawing.Size(170, 20);
            this.txtEditFile.TabIndex = 9;
            // 
            // lblEditFile
            // 
            this.lblEditFile.AutoSize = true;
            this.lblEditFile.Location = new System.Drawing.Point(6, 55);
            this.lblEditFile.Name = "lblEditFile";
            this.lblEditFile.Size = new System.Drawing.Size(23, 13);
            this.lblEditFile.TabIndex = 8;
            this.lblEditFile.Text = "File";
            // 
            // txtEditName
            // 
            this.txtEditName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtEditName.Location = new System.Drawing.Point(6, 32);
            this.txtEditName.Name = "txtEditName";
            this.txtEditName.Size = new System.Drawing.Size(170, 20);
            this.txtEditName.TabIndex = 7;
            // 
            // lblEditName
            // 
            this.lblEditName.AutoSize = true;
            this.lblEditName.Location = new System.Drawing.Point(6, 16);
            this.lblEditName.Name = "lblEditName";
            this.lblEditName.Size = new System.Drawing.Size(35, 13);
            this.lblEditName.TabIndex = 6;
            this.lblEditName.Text = "Name";
            // 
            // ofdFileSelector
            // 
            this.ofdFileSelector.Filter = "Executable Files|*.exe;*.com;*.bat;*.cmd;*.scr|All Files|*.*";
            this.ofdFileSelector.Title = "Select Executable";
            // 
            // scMain
            // 
            this.scMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.scMain.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.scMain.Location = new System.Drawing.Point(0, 0);
            this.scMain.Name = "scMain";
            // 
            // scMain.Panel1
            // 
            this.scMain.Panel1.Controls.Add(this.lstMain);
            // 
            // scMain.Panel2
            // 
            this.scMain.Panel2.Controls.Add(this.grpEdit);
            this.scMain.Panel2.Controls.Add(this.btnRemove);
            this.scMain.Panel2.Controls.Add(this.btnRun);
            this.scMain.Panel2.Controls.Add(this.btnAdd);
            this.scMain.Panel2.Controls.Add(this.btnExit);
            this.scMain.Size = new System.Drawing.Size(1029, 335);
            this.scMain.SplitterDistance = 804;
            this.scMain.TabIndex = 6;
            // 
            // RunAsUser
            // 
            this.AcceptButton = this.btnRun;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnExit;
            this.ClientSize = new System.Drawing.Size(1029, 335);
            this.Controls.Add(this.scMain);
            this.Name = "RunAsUser";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Run As User Config";
            this.grpEdit.ResumeLayout(false);
            this.grpEdit.PerformLayout();
            this.scMain.Panel1.ResumeLayout(false);
            this.scMain.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.scMain)).EndInit();
            this.scMain.ResumeLayout(false);
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.ListView lstMain;
        private System.Windows.Forms.ColumnHeader colName;
        private System.Windows.Forms.ColumnHeader colFile;
        private System.Windows.Forms.ColumnHeader colArgs;
        private System.Windows.Forms.ColumnHeader colUsername;
        private System.Windows.Forms.ColumnHeader colDomain;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnRemove;
        private System.Windows.Forms.Button btnRun;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.GroupBox grpEdit;
        private System.Windows.Forms.Label lblEditName;
        private System.Windows.Forms.TextBox txtEditName;
        private System.Windows.Forms.TextBox txtEditDomain;
        private System.Windows.Forms.Label lblEditDomain;
        private System.Windows.Forms.TextBox txtEditPassword;
        private System.Windows.Forms.Label lblEditPassword;
        private System.Windows.Forms.TextBox txtEditUsername;
        private System.Windows.Forms.Label lblEditUsername;
        private System.Windows.Forms.TextBox txtEditArgs;
        private System.Windows.Forms.Label lblEditArgs;
        private System.Windows.Forms.TextBox txtEditFile;
        private System.Windows.Forms.Label lblEditFile;
        private System.Windows.Forms.Button btnEditName;
        private System.Windows.Forms.Button btnEditUsername;
        private System.Windows.Forms.Button btnEditArgs;
        private System.Windows.Forms.Button btnEditFile;
        private System.Windows.Forms.Button btnEditDomain;
        private System.Windows.Forms.Button btnEditPassword;
        private System.Windows.Forms.OpenFileDialog ofdFileSelector;
        private System.Windows.Forms.SplitContainer scMain;
    }
}
