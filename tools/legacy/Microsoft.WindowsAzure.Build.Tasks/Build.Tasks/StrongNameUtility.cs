// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
using System.Diagnostics;
using System.IO;
using System.Linq;

namespace Microsoft.WindowsAzure.Build.Tasks
{
    /// <summary>
    /// Utility class for managing the Process used to work with the sn.exe
    /// tool in the Windows SDK.
    /// </summary>
    internal class StrongNameUtility
    {
        private string _snPath;

        public StrongNameUtility()
        {
        }

        public bool ValidateStrongNameToolExistance(string windowsSdkPath)
        {
            // Location the .NET strong name signing utility
            _snPath = FindFile(windowsSdkPath, "sn.exe");
            if (_snPath == null)
            {
                return false;
            }

            return true;
        }

        public bool Execute(string arguments, out string output)
        {
            int exitCode;
            output = null;

            ProcessStartInfo processInfo = new ProcessStartInfo(_snPath)
            {
                Arguments =  arguments,
                UseShellExecute = false,
                RedirectStandardOutput = true,
            };

            using (Process process = Process.Start(processInfo))
            {
                output = process.StandardOutput.ReadToEnd();
                process.WaitForExit();

                exitCode = process.ExitCode;
            }

            return exitCode == 0;
        }

        private static string FindFile(string path, string filenameOfInterest)
        {
            foreach (string d in Directory.GetDirectories(path))
            {
                var result = Directory.GetFiles(d, filenameOfInterest).FirstOrDefault();
                if (result != null)
                {
                    return result;
                }

                return FindFile(d, filenameOfInterest);
            }

            return null;
        }
    }
}
