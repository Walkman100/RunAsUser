using System;
using System.Collections.Generic;
using System.Linq;

namespace RunAsUser {
    internal static class Helpers {
        public static void StartConfig(SavedConfiguration config) =>
            Start(config.Filename, config.Arguments, config.UserName, GetSecureString(config.Password), config.Domain);
        public static System.Diagnostics.Process Start(string fileName, string arguments = null, string userName = null, System.Security.SecureString password = null, string domain = null) {
            domain ??= Environment.MachineName;

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
    }
}
