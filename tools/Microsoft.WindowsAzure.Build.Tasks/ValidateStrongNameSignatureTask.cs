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

using System;
using Microsoft.Build.Framework;
using Microsoft.Build.Utilities;

namespace Microsoft.WindowsAzure.Build.Tasks
{
    /// <summary>
    /// A simple Microsoft Build task for validating the strong name signature
    /// on a .NET assembly.
    /// </summary>
    public class ValidateStrongNameSignatureTask : Task
    {
        /// <summary>
        /// Gets or sets the path to the Windows SDK on the machine.
        /// </summary>
        [Required]
        public string WindowsSdkPath { get; set; }

        /// <summary>
        /// Gets or sets the assembly whose strong name needs to be verified.
        /// </summary>
        [Required]
        public ITaskItem Assembly { get; set; }

        /// <summary>
        /// Gets or sets the expected strong name token for the assembly.
        /// </summary>
        [Required]
        public string ExpectedTokenSignature { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the assembly is expected to
        /// be delay signed.
        /// </summary>
        public bool ExpectedDelaySigned { get; set; }

        /// <summary>
        /// Executes the task to validate the strong name information for the
        /// assembly using the input values expected by the task.
        /// </summary>
        /// <returns>Returns a value indicating whether the task has been
        /// successful and the build should continue.</returns>
        public override bool Execute()
        {
            try
            {
                StrongNameUtility utility = new StrongNameUtility();
                if (!utility.ValidateStrongNameToolExistance(WindowsSdkPath))
                {
                    Log.LogError("The strong name tool (sn.exe) could not be located within the Windows SDK directory structure ({0})).", WindowsSdkPath);
                    return false;
                }

                string path = Assembly.ItemSpec;

                // Check the public key token of the assembly.
                // -q -T: Display token for public key.
                string output;
                string arguments = "-q -T \"" + path + "\"";
                bool success = utility.Execute(arguments, out output);

                if (!success)
                {
                    Log.LogError("The assembly \"" + path + "\" has not been strong named signed.");
                    Log.LogError(output);

                    return false;
                }

                // Read the public key token.
                int lastSpace = output.LastIndexOf(' ');
                if (lastSpace >= 0)
                {
                    output = output.Substring(lastSpace + 1).Trim();
                }

                if (output != ExpectedTokenSignature)
                {
                    Log.LogError("The assembly \"{0}\" had the strong name token of \"{1}\", but was expected to have the token \"{2}\"",
                        path,
                        output,
                        ExpectedTokenSignature);
                    return false;
                }

                Log.LogMessage("The assembly \"{0}\" had the expected strong name token of \"{1}\"",
                    path,
                    output);

                // Validate that it is or is not delay signed.
                // -q -v[f]: Verify <assembly> for strong name signature self 
                // consistency. If -vf is specified, force verification even if
                // disabled in the registry.
                output = null;
                arguments = "-q -vf \"" + path + "\"";
                success = utility.Execute(arguments, out output);

                success = (success == (!ExpectedDelaySigned));

                string message;
                if (ExpectedDelaySigned && success || !ExpectedDelaySigned && !success)
                {
                    message = "The assembly \"{0}\" was delay signed.";
                }
                else if (ExpectedDelaySigned && !success)
                {
                    message = "The assembly \"{0}\" was not delay signed.";
                }
                else
                {
                    message = "The assembly \"{0}\" has been fully signed.";
                }

                if (success)
                {
                    Log.LogMessage(MessageImportance.High, message, path);
                } 
                else
                {
                    Log.LogError(message, path);
                }

                return success;
            }
            catch (Exception ex)
            {
                Log.LogErrorFromException(ex);
                return false;
            }
        }
    }
}
