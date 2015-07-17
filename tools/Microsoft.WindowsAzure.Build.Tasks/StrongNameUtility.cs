//
// Copyright (c) Microsoft.  All rights reserved.
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//   http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
//
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
