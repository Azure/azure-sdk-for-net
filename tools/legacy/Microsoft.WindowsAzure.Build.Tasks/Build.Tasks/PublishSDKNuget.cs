// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Microsoft.WindowsAzure.Build.Tasks
{
    using System;
    using Microsoft.Build.Framework;
    using Microsoft.Build.Utilities;
    using Microsoft.WindowsAzure.Build.Tasks.ExecProcess;
    using Microsoft.WindowsAzure.Build.Tasks.Utilities;
    using System.IO;
    using System.Collections.Generic;
    using System.Linq;
    using System.Diagnostics;

    public class PublishSDKNuget : Task
    {
        #region fields
        /// <summary>
        /// 
        /// </summary>
        private bool _publishAllNugetsunderScope;
        private bool _buildEngineInitialized;
        private string _apiKey;
        #endregion

        public PublishSDKNuget()
        {
            _publishAllNugetsunderScope = false;
            _buildEngineInitialized = false;

            //By default do not skip publishing both nuget and symbols
            SkipNugetPublishing = false;
            SkipSymbolPublishing = false;
        }

        internal bool IsBuildEngineInitialized
        {
            get
            {
                if(this.BuildEngine != null)
                {
                    _buildEngineInitialized = true;
                }

                return _buildEngineInitialized;
            }
        }

        #region Required Properties

        /// <summary>
        /// Gets or sets Nuget Package Name that needs to be published
        /// </summary>
        [Required]
        public string NugetPackageName { get; set; }
        
        /// <summary>
        /// Gets or sets output path for nuget that got packaged/generated
        /// </summary>
        [Required]
        public string PackageOutputPath { get; set; }
        
        /// <summary>
        /// Gets or sets nuget publishing path.
        /// Official Nuget Path is https://www.nuget.org/api/v2/package/
        /// </summary>
        [Required]
        public string PublishNugetToPath { get; set; }
        #endregion

        /// <summary>
        /// Sets or gets the path to Nuget.exe
        /// </summary>
        public string NugetExePath { get; set; }
        /// <summary>
        /// GitHub userId
        /// </summary>
        public string UserId { get; set; }
        
        /// <summary>
        /// Publish all nuget found under particular scope
        /// e.g. publish all nugets under KeyVault
        /// </summary>
        public bool publishAllNugetsUnderScope { get { return _publishAllNugetsunderScope; } set { _publishAllNugetsunderScope = value; } }

        /// <summary>
        /// Gets or Sets relative scope Path (e.g. SDKs\Compute relative path after root\src)
        /// </summary>
        public string scopePath { get; set; }

        public bool SkipSymbolPublishing { get; set; }
        
        public bool SkipNugetPublishing { get; set; }

        public bool TaskDebugOutput { get; set; }

        public List<NugetPublishStatus> NugetPublishStatus { get; private set; }

        /// <summary>
        /// API key to be used to publish the nuget package
        /// </summary>
        public string ApiKey
        {
            get
            {
                if(string.IsNullOrEmpty(_apiKey))
                {
                    if(!string.IsNullOrEmpty(PublishNugetToPath))
                    {
                        if(PublishNugetToPath.StartsWith(Constants.NugetDefaults.NUGET_PUBLISH_URL))
                        {
                            _apiKey = System.Environment.GetEnvironmentVariable(Constants.NugetDefaults.SDK_NUGET_APIKEY_ENV);
                            Check.NotNull(_apiKey, "ApiKeyRetrieval");
                        }
                        else
                        {
                            // If local path or file share, we publish using a default api key
                            Check.DirectoryExists(PublishNugetToPath);
                            _apiKey = Constants.NugetDefaults.DEFAULT_API_KEY;
                        }
                    }
                }

                return _apiKey;
            }
            set
            {
                _apiKey = value;
            }

        }

        public override bool Execute()
        {
            //NugetExec nug = null;
            try
            {
                DebugInfo();

                if (publishAllNugetsUnderScope)
                {
                    // Check.DirectoryExists(publishNugetToPath);
                    throw new NotSupportedException("Publishing multiple nugets....This feature is currently Not Supported");
                }
                else
                {
                    Check.NotEmptyNotNull(NugetPackageName, "NugetPackageName");
                    Check.NotEmptyNotNull(PackageOutputPath, "PackageOutputPath");
                    Check.NotEmptyNotNull(PublishNugetToPath, "PublishNugetToPath");

                    NugetPublishStatus = ExecPublishCommand();
                    ThrowForNonZeroExitCode(NugetPublishStatus);
                }

                return true;
            }
            catch(Exception ex)
            {
                LogException(ex);
                throw ex;
            }
        }

        private Tuple<string, string> GetNugetPkgs(string nugetPkgName)
        {
            string nugPattern = string.Format("*{0}*.nupkg", nugetPkgName);
            string nugSymPkgPattern = string.Format("*{0}*.symbols.nupkg", nugetPkgName);
            IEnumerable<string> dupeFiles = Directory.EnumerateFiles(PackageOutputPath, nugPattern);
            IEnumerable<string> foundSymbolPkgFiles = Directory.EnumerateFiles(PackageOutputPath, nugSymPkgPattern);

            var foundNugetPkgFiles = dupeFiles.Except<string>(foundSymbolPkgFiles, new ObjectComparer<string>((left, right) => left.Equals(right, StringComparison.OrdinalIgnoreCase)));

            string nupkg = string.Empty;
            string nuSymPkg = string.Empty;

            if (foundNugetPkgFiles.Any<string>())
            {
                nupkg = foundNugetPkgFiles.First<string>();
                Check.NotEmptyNotNull(nupkg, "NugetPackage");
            }

            if (foundSymbolPkgFiles.Any<string>())
            {
                nuSymPkg = foundSymbolPkgFiles.First<string>();
                Check.NotEmptyNotNull(nuSymPkg, "Nuget Symbol Package");
            }

            return new Tuple<string, string>(nupkg, nuSymPkg);
        }

        private void ThrowForNonZeroExitCode(List<NugetPublishStatus> statusList)
        {
            foreach(NugetPublishStatus status in statusList)
            {
                if(status.NugetPublishExitCode != 0)
                {
                    string exMessage = string.Format("{0}\r\n ExitCode:{1}\r\n {2}\r\n", status.PublishArgs, status.NugetPublishExitCode.ToString(), status.NugetPublishStatusOutput);
                    throw new ApplicationException(exMessage);
                }
                else
                {
                    LogInfo(status.PublishArgs);
                    LogInfo(status.NugetPublishStatusOutput);
                }
            }
        }

        private List<NugetPublishStatus> ExecPublishCommand()
        {
            NugetExec nug = null;
            Tuple<string, string> nupkgs = GetNugetPkgs(NugetPackageName);

            if (string.IsNullOrEmpty(NugetExePath))
            {
                nug = new NugetExec();
            }
            else
            {
                nug = new NugetExec(NugetExePath);
            }

            nug.PublishToPath = PublishNugetToPath;
            nug.SkipPublishingNuget = SkipNugetPublishing;
            nug.SkipPublishingSymbols = SkipSymbolPublishing;
            nug.ApiKey = ApiKey;

            if (SkipNugetPublishing == true && SkipSymbolPublishing == true)
            {
                throw new ApplicationException("Requested to skip Publishing Nuget and Symbols");
            }

            List<NugetPublishStatus> publishStatusList = nug.Publish(nupkgs);
            return publishStatusList;
        }

        private void DebugInfo()
        {
            if(TaskDebugOutput)
            {
                LogInfo("UserId: {0}", UserId);
                LogInfo("Nuget Package Name: {0}", NugetPackageName);
                LogInfo("Nuget Output Path: {0}", PackageOutputPath);
                LogInfo("Nuget Publish Path: {0}", PublishNugetToPath);
                LogInfo("NugetExe Path: {0}", NugetExePath);
            }
        }

        #region Logging
        private void LogInfo(string messageToLog)
        {
            if(IsBuildEngineInitialized)
            {
                Log.LogMessage(messageToLog);
            }
            else
            {
                Debug.WriteLine(messageToLog);
            }
        }

        private void LogInfo(string outputFormat, params string[] info)
        {
            LogInfo(string.Format(outputFormat, info));
        }

        private void LogException(Exception ex)
        {
            if (IsBuildEngineInitialized)
            {
                Log.LogErrorFromException(ex);
            }
            else
            {
                Debug.WriteLine(ex.ToString());
            }
        }
        
        private void LogError(string errorMessage)
        {
            if (IsBuildEngineInitialized)
            {
                Log.LogError(errorMessage);
            }
            else
            {
                Debug.WriteLine(errorMessage);
            }
        }

        #endregion

    }
}
