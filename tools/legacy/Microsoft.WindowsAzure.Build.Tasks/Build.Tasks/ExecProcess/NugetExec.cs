// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Microsoft.WindowsAzure.Build.Tasks.Utilities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microsoft.WindowsAzure.Build.Tasks.ExecProcess
{
    public class NugetExec : ShellExec
    {
        #region Fields
        string _defaultNugetArgsFormat;
        string _publishToPath;
        string _publishSymbolToPath;
        string _nugetExePath;
        #endregion


        public string ApiKey { get; set; }

        public string PublishToPath
        {
            get
            {
                if(string.IsNullOrEmpty(_publishToPath))
                {
                    _publishToPath = Constants.NugetDefaults.NUGET_PUBLISH_URL;
                }

                return _publishToPath;
            }

            set
            {
                _publishToPath = value;
            }
        }

        public string PublishSymbolToPath
        {
            get
            {
                // We check if nuget publishing is happening to a non-standard location (e.g. local hard drive or anything other than the officially nuget publish location
                // If anything non-standard nuget publish location, symbol path will be same as the provided nuget publish location
                if (string.IsNullOrEmpty(_publishSymbolToPath))
                {
                    if (string.IsNullOrEmpty(PublishToPath))
                    {
                        _publishSymbolToPath = Constants.NugetDefaults.NUGET_SYMBOL_PUBLISH_URL;
                    }
                    else if(PublishToPath.Contains(Constants.NugetDefaults.NUGET_PUBLISH_URL))
                    {
                        _publishSymbolToPath = Constants.NugetDefaults.NUGET_SYMBOL_PUBLISH_URL;
                    }
                    else
                    {
                        _publishSymbolToPath = PublishToPath;
                    }
                    
                }

                return _publishSymbolToPath;
            }

            set
            {
                _publishSymbolToPath = value;
            }
        }

        public string NugetExePath
        {
            get
            {
                if(string.IsNullOrEmpty(_nugetExePath))
                {
                    _nugetExePath = Constants.NugetDefaults.NUGET_PATH;
                }

                return _nugetExePath;
            }

            set
            {
                _nugetExePath = value;
            }
        }

        public bool SkipPublishingNuget { get; set; }

        public bool SkipPublishingSymbols { get; set; }
        

        public NugetExec(string nugetExePath): base(nugetExePath)
        {
            _defaultNugetArgsFormat = "push {0} -source {1} -ApiKey {2} -NonInteractive -Timeout {3}";
        }

        public NugetExec() : this(Constants.NugetDefaults.NUGET_PATH)
        {
        }

        public NugetPublishStatus Publish(string nupkgPath)
        {
            string args = string.Empty;
            string displayArgs = string.Empty;
            if(nupkgPath.Contains("symbols"))
            {
                args = string.Format("push {0} -source {1} -NonInteractive -Timeout {2} -SymbolSource {3} -ApiKey {4} ", nupkgPath, PublishSymbolToPath, Constants.NugetDefaults.NUGET_TIMEOUT, PublishSymbolToPath, ApiKey);
                displayArgs = string.Format("push {0} -source {1} -NonInteractive -Timeout {2} -SymbolSource {3} -ApiKey {4} ", nupkgPath, PublishSymbolToPath, Constants.NugetDefaults.NUGET_TIMEOUT, PublishSymbolToPath, "<ApiKey>");
            }
            else
            {
                args = string.Format(_defaultNugetArgsFormat, nupkgPath, PublishToPath, ApiKey, Constants.NugetDefaults.NUGET_TIMEOUT);
                displayArgs = string.Format("{0} push {1} -source {2} -ApiKey {3} -NonInteractive -Timeout {4}", NugetExePath, nupkgPath, PublishToPath, "<ApiKey>", Constants.NugetDefaults.NUGET_TIMEOUT);
            }
            
            int exitCode = ExecuteCommand(args);
            string output = this.AnalyzeExitCode();

            return new NugetPublishStatus() { NugetPackagePath = nupkgPath, NugetPublishExitCode = exitCode, NugetPublishStatusOutput = output, PublishArgs = displayArgs };
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="nugPkgs"></param>
        /// <returns></returns>
        public List<NugetPublishStatus> Publish(Tuple<string, string> nugPkgs)
        {
            StringBuilder sb = new StringBuilder();
            List<NugetPublishStatus> publishStatusList = new List<NugetPublishStatus>();
            NugetPublishStatus nugPubStatus = null;

            // Check if publishing nuget has to be skipped
            if (SkipPublishingNuget == false)
            {
                nugPubStatus = Publish(nugPkgs.Item1);
                publishStatusList.Add(nugPubStatus);
            }

            // Check if publishing symbols has to be skipped
            if (SkipPublishingSymbols == false)
            {
                // Check if nuget was published, not checking will result in nullRef
                if (SkipPublishingNuget == false)
                {
                    if (nugPubStatus.NugetPublishExitCode == 0)
                    {
                        publishStatusList.Add(Publish(nugPkgs.Item2));
                    }
                }
                else
                {
                    publishStatusList.Add(Publish(nugPkgs.Item2));
                }
            }

            return publishStatusList;
        }
    }
    
    /// <summary>
    /// Structure to get publish status
    /// </summary>
    public class NugetPublishStatus
    {
        public string NugetPackagePath { get; set; }

        public int NugetPublishExitCode { get; set; }

        public string NugetPublishStatusOutput { get; set; }

        public string PublishArgs { get; set; }
    }
}
