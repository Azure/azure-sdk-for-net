// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Microsoft.Azure.Sdk.Build.ExecProcess
{
    using Microsoft.Azure.Sdk.Build.Tasks.Utilities;
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class SignClientExec : ShellExec
    {
        //ESRPClient sign ​-a c:/somefolder/auth.json, -c c:/somefolder/config.json -p c:/somefolder/policy.json -i c:/somefolder/input.json -o c:/somefolder/output.json

        private const int SignUtilityDefaultTimeOut = 120000;
        private string ciConfigDir= @"tools\ESRPClientUtility\configs";
        private string _signUtilityCommandLineArgs;
        /// <summary>
        /// Path to the CI Sign tools directory
        /// </summary>
        public string CiSignToolsPath { get; set; }

        private string SignUtilityFullPath = "";

        public string InputArg { get; set; }

        public string OutputArg { get; set; }

        protected override int DefaultTimeOut => SignUtilityDefaultTimeOut;

        public string SignUtilityCommandLineArgs
        {
            get
            {
                if(string.IsNullOrEmpty(_signUtilityCommandLineArgs))
                {
                    _signUtilityCommandLineArgs = string.Format("{0} -a {1} -c {2} -p {3} -i {4} -o {5}", "Sign", SignUtilityFullPath, Path.Combine(ciConfigDir, "Auth.json"),
                        Path.Combine(ciConfigDir, "Config.json"), Path.Combine(ciConfigDir, "Policy.json"), InputArg, OutputArg);
                }

                return _signUtilityCommandLineArgs;
            }
        }

        protected override string BuildShellProcessArgs()
        {
            if (string.IsNullOrEmpty(_signUtilityCommandLineArgs))
            {
                _signUtilityCommandLineArgs = string.Format("{0} -a {1} -c {2} -p {3} -i {4} -o {5}", "Sign", Path.Combine(ciConfigDir, "Auth.json"),
                    Path.Combine(ciConfigDir, "Config.json"), Path.Combine(ciConfigDir, "Policy.json"), InputArg, OutputArg);
            }

            return _signUtilityCommandLineArgs;
        }


        public SignClientExec() : base()
        {

        }

        public SignClientExec(string commandPath) : base(commandPath)
        {
            //this.ShellProcessCommandPath = commandPath;
        }


        public override int ExecuteCommand()
        {

            //OnPremiseBuildTasks
            Check.DirectoryExists(CiSignToolsPath);
            ciConfigDir = Path.Combine(CiSignToolsPath, ciConfigDir);
            Check.DirectoryExists(ciConfigDir);
            SignUtilityFullPath = Path.Combine(CiSignToolsPath, @"tools\ESRPClientUtility\EsrpClient.1.0.24\tools\EsrpClient.exe");
            Check.FileExists(SignUtilityFullPath);

            this.ShellProcessCommandPath = SignUtilityFullPath;

            int exitCode = ExecuteCommand(BuildShellProcessArgs());
            string output = this.AnalyzeExitCode();
            return exitCode;
        }


        private void SignNuget()
        {
            int exitCode = ExecuteCommand(BuildShellProcessArgs());
            string output = this.AnalyzeExitCode();
        }
    }
}
