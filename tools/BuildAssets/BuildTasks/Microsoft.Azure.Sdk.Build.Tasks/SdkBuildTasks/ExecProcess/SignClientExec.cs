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

    /// <summary>
    /// TODO: Make exec base as Task
    /// </summary>
    public class SignClientExec : ShellExec
    {
        //ESRPClient sign ​-a c:/somefolder/auth.json, -c c:/somefolder/config.json -p c:/somefolder/policy.json -i c:/somefolder/input.json -o c:/somefolder/output.json

        private const int SignUtilityDefaultTimeOut = 360000;

        private string signClientExecName = "ESRPClient.exe";
        private string ciConfigDir;

        /// <summary>
        /// Root direcotry for CI tools
        /// </summary>

        public string CiToolsRootDir { get; set; }

        /// <summary>
        /// Signing Client input file
        /// </summary>
        public string SigningInputManifestFilePath { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string SigningResultOutputFilePath { get; set; }

        /// <summary>
        /// Defautl time for the shell process
        /// </summary>
        protected override int DefaultTimeOut => SignUtilityDefaultTimeOut;

        /// <summary>
        /// Build commandline args string
        /// </summary>
        /// <returns></returns>
        protected override string BuildShellProcessArgs()
        {
            return string.Format("{0} -a {1} -c {2} -p {3} -i {4} -o {5}", "Sign", Path.Combine(ciConfigDir, "AdxSdkAuth.json"),
                Path.Combine(ciConfigDir, "Config.json"), Path.Combine(ciConfigDir, "Policy.json"), SigningInputManifestFilePath, SigningResultOutputFilePath);
        }


        public SignClientExec() : base() { }

        public SignClientExec(string commandPath) : base(commandPath) { }


        public override int ExecuteCommand()
        {
            VerifyRequiredProperties();

            int exitCode = ExecuteCommand(BuildShellProcessArgs());
            //string output = this.AnalyzeExitCode();
            return exitCode;
        }

        private void VerifyRequiredProperties()
        {
            //OnPremiseBuildTasks
            Check.DirectoryExists(CiToolsRootDir);
            var clientExes = Directory.EnumerateFiles(CiToolsRootDir, signClientExecName, SearchOption.AllDirectories);
            Check.NotNull(clientExes, "SignUtility not found");
            if(clientExes.Any<string>())
            {
                this.ShellProcessCommandPath = clientExes.First<string>();
                Check.FileExists(this.ShellProcessCommandPath);
            }

            ciConfigDir = Path.Combine(CiToolsRootDir, @"tools\ESRPClient\configs");
            Check.DirectoryExists(ciConfigDir);
            Check.FileExists(Path.Combine(ciConfigDir, "AdxSdkAuth.json"));
            Check.FileExists(Path.Combine(ciConfigDir, "Config.json"));
            Check.FileExists(Path.Combine(ciConfigDir, "Policy.json"));
        }
    }
}
