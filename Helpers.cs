using System;
using System.Collections.Generic;
using System.Linq;
using System.Management;

namespace RunAsUser {
    internal static class Helpers {
        public static System.Diagnostics.Process StartConfig(SavedConfiguration config) =>
            Start(config.Filename, config.Arguments, config.UserName, GetSecureString(config.Password), config.Domain);
        public static System.Diagnostics.Process Start(string fileName, string arguments = null, string userName = null, System.Security.SecureString password = null, string domain = null) {
            domain ??= Environment.MachineName;
            string workingDirectory = null;
            try {
                workingDirectory = System.IO.Path.GetDirectoryName(fileName);
            } catch { }

            if (userName == null)
                return System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo(fileName, arguments) {
                    ErrorDialog = true,
                });
            else
                return System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo(fileName, arguments) {
                    ErrorDialog = true,
                    UserName = userName,
                    Password = password,
                    Domain = domain,
                    LoadUserProfile = true,
                    UseShellExecute = false,
                    WorkingDirectory = workingDirectory,
                });
        }

        public static System.Security.SecureString GetSecureString(string password) {
            if (password == null)
                return null;

            var rtn = new System.Security.SecureString();
            foreach (var ch in password)
                rtn.AppendChar(ch);
            rtn.MakeReadOnly();

            return rtn;
        }

        public static IEnumerable<object> GetLocalUserNames() { // uses System.Management
            var query = new SelectQuery("Win32_UserAccount");
            var searcher = new ManagementObjectSearcher(query);

            return searcher.Get().Cast<ManagementBaseObject>().Select(envVar => envVar["Name"]);
        }
    }
}
