using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace RunAsUser {
    public partial class RunAsUser : Form {
        public RunAsUser() {
            InitializeComponent();
            lstMain.SetDoubleBuffered(true);
        }
    }
}
