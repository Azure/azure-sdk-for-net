// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Microsoft.WindowsAzure.Build.Tasks
{
    using System;
    using Microsoft.Build.Framework;
    using Microsoft.Build.Utilities;
    using Microsoft.WindowsAzure.Build.Tasks.Utilities;
    using System.IO;
    using System.Collections.Generic;
    using System.Linq;
    using System.Diagnostics;
    using Microsoft.Azure.Sdk.Build.ExecProcess;
    using Microsoft.Azure.Sdk.Build.Tasks.Utilities;

    public class PublishSDKNugetTask : Task
    {
        #region fields
        /// <summary>
        /// 
        /// </summary>
        private bool _publishAllNugetsunderScope;
        private bool _buildEngineInitialized;
        private string _apiKey;
        private List<string> authUsers;
        private List<string> authScopes;
        #endregion

        #region Properties
        internal bool IsBuildEngineInitialized
        {
            get
            {
                if (this.BuildEngine != null)
                {
                    _buildEngineInitialized = true;
                }

                return _buildEngineInitialized;
            }
        }

        #region Required Properties
       

        /// <summary>
        /// Gets or Sets relative scope Path (e.g. SDKs\Compute relative path after root\src)
        /// </summary>
        [Required]
        public string ScopePath { get; set; }
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
        /// Gets or sets Nuget Package Name that needs to be published
        /// </summary>
        public string NugetPackageName { get; set; }
        /// <summary>
        /// Sets or gets the path to Nuget.exe
        /// </summary>
        public string NugetExePath { get; set; }
        /// <summary>
        /// GitHub userId
        /// </summary>
        public string CIUserId { get; set; }

        /// <summary>
        /// Publish all nuget found under particular scope
        /// e.g. publish all nugets under KeyVault
        /// </summary>
        //public bool publishAllNugetsUnderScope { get { return _publishAllNugetsunderScope; } set { _publishAllNugetsunderScope = value; } }


        public bool SkipSymbolPublishing { get; set; }

        public bool SkipNugetPublishing { get; set; }

        public bool TaskDebugOutput { get; set; }

        public bool MultiPackagePublish { get; set; }

        public List<Tuple<NugetPublishStatus, NugetPublishStatus>> NugetPublishStatus { get; private set; }

        /// <summary>
        /// API key to be used to publish the nuget pakcage
        /// </summary>
        public string ApiKey
        {
            get
            {
                if (string.IsNullOrEmpty(_apiKey))
                {
                    if (!string.IsNullOrEmpty(PublishNugetToPath))
                    {
                        if (PublishNugetToPath.StartsWith(Constants.NugetDefaults.NUGET_PUBLISH_URL))
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

        #endregion

        public PublishSDKNugetTask()
        {            
            _publishAllNugetsunderScope = false;
            _buildEngineInitialized = false;
            authUsers = new List<string>() { "hovsepm", "shahabhijeet", "praries880", "anuchandy", "jianghaolu", "lmazuel" };
            authScopes = new List<string>() { "all", "sdks", "sdkcommon", "azurestack" };
            //By default do not skip publishing both nuget and symbols
            SkipNugetPublishing = false;
            SkipSymbolPublishing = true;
        }

        private void Init()
        {
            if (authScopes.Where<string>((scope) => scope.Equals(ScopePath, StringComparison.OrdinalIgnoreCase)).Any<string>())
            {
                //TODO: Add a way to integrate with AAD and add a feature to depend on Security group. This is a temp fix
                if (!authUsers.Where<string>((u) => u.Equals(CIUserId, StringComparison.OrdinalIgnoreCase)).Any<string>())
                {
                    throw new NotSupportedException(string.Format("User '{0}' do not have permissions to publish multiple nugets from scope '{1}', This feature is currently Not Supported", CIUserId, ScopePath));
                }
            }
            //else
            //{
            //    if (!authUsers.Where<string>((u) => u.Equals(CIUserId, StringComparison.OrdinalIgnoreCase)).Any<string>())
            //    {
            //        throw new NotSupportedException(string.Format("User '{0}' do not have permissions to publish multiple nugets from scope '{1}', This feature is currently Not Supported", CIUserId, ScopePath));
            //    }
            //}

            Check.NotEmptyNotNull(PackageOutputPath, "PackageOutputPath");
            Check.NotEmptyNotNull(PublishNugetToPath, "PublishNugetToPath");
        }

        public override bool Execute()
        {
            try
            {
                DebugInfo();
                Init();
                NugetPublishStatus = ExecPublishCommand();
                ThrowForNonZeroExitCode(NugetPublishStatus);
                return true;
            }
            catch (Exception ex)
            {
                LogException(ex);
                throw ex;
            }
        }

        private List<Tuple<string, string>> GetAllNugetPackages()
        {
            var nugetPkgs = Directory.EnumerateFiles(PackageOutputPath, "*.nupkg", SearchOption.AllDirectories);
            var symPkgs = Directory.EnumerateFiles(PackageOutputPath, "*.snupkg", SearchOption.AllDirectories);
            //var nugetPkgs = dupeFiles.Except<string>(symPkgs, new ObjectComparer<string>((left, right) => left.Equals(right, StringComparison.OrdinalIgnoreCase)));

            List<Tuple<string, string>> pkgList = new List<Tuple<string, string>>();

            foreach (string pkgPath in nugetPkgs)
            {
                string pkgName = Path.GetFileNameWithoutExtension(pkgPath);
                //string symName = Path.GetFileNameWithoutExtension(pkgPath);
                //var searchedSymPkgs = symPkgs.Where<string>((sym) => (Path.GetFileNameWithoutExtension(sym)).StartsWith(pkgName));
                if (symPkgs.Any<string>())
                {
                    foreach (string symPath in symPkgs)
                    {
                        string symPkgName = Path.GetFileNameWithoutExtension(symPath);
                        //string nupkgName = string.Concat(pkgName, ".symbols");
                        if (symPkgName.Equals(pkgName, StringComparison.OrdinalIgnoreCase))
                        {
                            Tuple<string, string> tup = new Tuple<string, string>(pkgPath, symPath);
                            pkgList.Add(tup);
                        }
                    }
                }
            }

            return pkgList;
        }


        //private List<Tuple<string, string>> GetAllNugetPackages()
        //{
        //    var dupeFiles = Directory.EnumerateFiles(PackageOutputPath, "*.nupkg", SearchOption.AllDirectories);
        //    var symPkgs = Directory.EnumerateFiles(PackageOutputPath, "*.snupkg", SearchOption.AllDirectories);
        //    var nugetPkgs = dupeFiles.Except<string>(symPkgs, new ObjectComparer<string>((left, right) => left.Equals(right, StringComparison.OrdinalIgnoreCase)));

        //    List<Tuple<string, string>> pkgList = new List<Tuple<string, string>>();

        //    foreach(string pkgPath in nugetPkgs)
        //    {
        //        string pkgName = Path.GetFileNameWithoutExtension(pkgPath);
        //        string symName = Path.GetFileNameWithoutExtension(pkgPath);
        //        var searchedSymPkgs = symPkgs.Where<string>((sym) => (Path.GetFileNameWithoutExtension(sym)).StartsWith(pkgName));
        //        if(searchedSymPkgs.Any<string>())
        //        {
        //            foreach(string symPath in searchedSymPkgs)
        //            {
        //                string symPkgName = Path.GetFileNameWithoutExtension(symPath);
        //                string nupkgName = string.Concat(pkgName, ".symbols");
        //                if(symPkgName.Equals(nupkgName, StringComparison.OrdinalIgnoreCase))
        //                {
        //                    Tuple<string, string> tup = new Tuple<string, string>(pkgPath, symPath);
        //                    pkgList.Add(tup);
        //                }
        //            }
        //        }
        //    }

        //    return pkgList;
        //}

        private Tuple<string, string> GetNugetPkgs(string nugetPkgName)
        {
            string nugPattern = string.Format("*{0}*.nupkg", nugetPkgName);
            string nugSymPkgPattern = string.Format("*{0}*.snupkg", nugetPkgName);

            LogInfo("Trying to find nuget packages '{0}' and '{1}' under dir '{2}'", nugPattern, nugSymPkgPattern, PackageOutputPath);
            IEnumerable<string> dupeFiles = Directory.EnumerateFiles(PackageOutputPath, nugPattern, SearchOption.AllDirectories);
            IEnumerable<string> foundSymbolPkgFiles = Directory.EnumerateFiles(PackageOutputPath, nugSymPkgPattern, SearchOption.AllDirectories);
            IEnumerable<string> pkgOutputContents = Directory.EnumerateFiles(PackageOutputPath);

            if(dupeFiles != null)
            {
                if(dupeFiles.Any<string>())
                {
                    LogInfo("Found '{0}' nuget packages", dupeFiles.Count<string>().ToString());
                }
                else
                {
                    LogError("Unable to find any nuget packages for the pattern '{0}' in directory '{1}'", nugPattern, PackageOutputPath);
                }
            }
            else
            {
                LogInfo("Unable to find any nuget packages for the pattern '{0}' in directory '{1}'", nugPattern, PackageOutputPath);
            }

            if (foundSymbolPkgFiles != null)
            {
                if (foundSymbolPkgFiles.Any<string>())
                {
                    LogInfo("Found '{0}' nuget symbols packages", foundSymbolPkgFiles.Count<string>().ToString());
                }
                else
                {
                    LogError("Unable to find any nuget symbol packages for the pattern '{0}' in directory '{1}'", nugSymPkgPattern, PackageOutputPath);
                }
            }
            else
            {
                LogError("Unable to find any nuget symbol packages for the pattern '{0}' in directory '{1}'", nugSymPkgPattern, PackageOutputPath);
            }

            if(pkgOutputContents != null)
            {
                if(pkgOutputContents.Any<string>())
                {
                    foreach(string fl in pkgOutputContents)
                    {
                        LogInfo(String.Format("Found '{0}'", fl));
                    }
                }
            }

            //var foundNugetPkgFiles = dupeFiles.Except<string>(foundSymbolPkgFiles, new ObjectComparer<string>((left, right) => left.Equals(right, StringComparison.OrdinalIgnoreCase)));
            IEnumerable<string> foundNugetPkgFiles = dupeFiles;

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

            LogInfo("Returning '{0}' and '{1}'", nupkg, nuSymPkg);
            return new Tuple<string, string>(nupkg, nuSymPkg);
        }

        private void ThrowForNonZeroExitCode(List<Tuple<NugetPublishStatus, NugetPublishStatus>> statusList)
        {
            foreach(Tuple<NugetPublishStatus, NugetPublishStatus> tup in statusList)
            {
                ThrowForNonZeroExitCode(tup?.Item1);
                ThrowForNonZeroExitCode(tup?.Item2);
            }
        }

        private void ThrowForNonZeroExitCode(NugetPublishStatus status)
        {
            if (status == null) return;

            if (status.NugetPublishExitCode != 0)
            {
                string exMessage = string.Format("{0}\r\n ExitCode:{1}\r\n {2}\r\n", status.PublishArgs, status.NugetPublishExitCode.ToString(), status.NugetPublishStatusOutput);
                string lsExMsg = exMessage.ToLower();

                //We are facing an unusual error only for our service account where it's exiting with a non-zero exit code due to unable to establish Trust relationship with the nuget server
                //As archiving symbols has to be done in the same step as building/publishing, we cannot afford to fail at this stage.
                //Swallowing this error for time being as the nuget is published successfully and there is no way to reproduce this using normal account.
                //Will need time to setup a repro where a request can be run interactively for service account and run a netmon trace to get more information.
                if (exMessage.ToLower().Contains("ssl/tls secure channel"))
                {
                    ApplicationException appEx = new ApplicationException(exMessage);
                    LogWarningFromException(appEx);
                }
                else
                { 
                    if (status.CaughtException != null)
                    {
                        throw new ApplicationException(exMessage, status.CaughtException);
                    }
                    else
                    {
                        throw new ApplicationException(exMessage);
                    }
                }
            }
            else
            {
                LogInfo(status.PublishArgs);
                LogInfo(status.NugetPublishStatusOutput);
            }
        }

        private void ThrowForNonZeroExitCode(List<NugetPublishStatus> statusList)
        {
            foreach(NugetPublishStatus status in statusList)
            {
                if(status.NugetPublishExitCode != 0)
                {
                    string exMessage = string.Format("{0}\r\n ExitCode:{1}\r\n {2}\r\n", status.PublishArgs, status.NugetPublishExitCode.ToString(), status.NugetPublishStatusOutput);
                    if(status.CaughtException != null)
                    {
                        throw new ApplicationException(exMessage, status.CaughtException);
                    }
                    else
                    {
                        throw new ApplicationException(exMessage);
                    }
                }
                else
                {
                    LogInfo(status.PublishArgs);
                    LogInfo(status.NugetPublishStatusOutput);
                }
            }
        }

        private List<Tuple<NugetPublishStatus, NugetPublishStatus>> ExecPublishCommand()
        {
            NugetExec nug = null;
            List<Tuple<string, string>> pkgList = null;
            Tuple<string, string> nupkgs = null;
            List<Tuple<NugetPublishStatus, NugetPublishStatus>> statusList = new List<Tuple<NugetPublishStatus, NugetPublishStatus>>();

            if (string.IsNullOrEmpty(NugetExePath))
            {
                nug = new NugetExec(this.Log);
            }
            else
            {
                nug = new NugetExec(NugetExePath, this.Log);
            }

            nug.PublishToPath = PublishNugetToPath;
            nug.SkipPublishingNuget = SkipNugetPublishing;
            nug.SkipPublishingSymbols = SkipSymbolPublishing;
            nug.ApiKey = ApiKey;

            if (SkipNugetPublishing == true && SkipSymbolPublishing == true)
            {
                throw new ApplicationException("Requested to skip Publishing Nuget and Symbols");
            }

            if (!ScopePath.Equals("all", StringComparison.OrdinalIgnoreCase) && MultiPackagePublish == true)
            {
                pkgList = GetAllNugetPackages();
                LogInfo("Packages to be published: {0}", pkgList.Count.ToString());

                if (pkgList.Count >= 2)
                {
                    if (!authUsers.Where<string>((u) => u.Equals(CIUserId, StringComparison.OrdinalIgnoreCase)).Any<string>())
                    {
                        throw new NotSupportedException(string.Format("Trying to publish '{0}' packges. User '{1}' do not have permissions to publish multiple nugets from scope '{2}', This feature is currently Not Supported", pkgList.Count.ToString(), CIUserId, ScopePath));
                    }
                }

                if(pkgList.Any<Tuple<string, string>>())
                {
                    foreach (Tuple<string, string> npkg in pkgList)
                    {
                        LogInfo("Publishing nuget package: '{0}' and Symbols package '{1}'", npkg.Item1, npkg.Item2);
                    }

                    statusList = nug.Publish(pkgList);
                }
            }

            if (!ScopePath.Equals("all", StringComparison.OrdinalIgnoreCase) && MultiPackagePublish == false)
            {
                nupkgs = GetNugetPkgs(NugetPackageName);
                
                if(!string.IsNullOrWhiteSpace(nupkgs.Item1))
                {
                    LogInfo("Publishing nuget package: '{0}'", nupkgs.Item1);
                    LogInfo("Publishing nuget symbols package: '{0}'", nupkgs.Item2);
                    Tuple<NugetPublishStatus, NugetPublishStatus> singlePkg = nug.Publish(nupkgs);
                    statusList.Add(singlePkg);
                }
                else
                {
                    LogException(new ApplicationException("No nuget packages found for publishing"));
                }
            }



            return statusList;
        }

        private void DebugInfo()
        {
            if(TaskDebugOutput)
            {
                LogInfo("UserId: {0}", CIUserId);
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
                Log.LogErrorFromException(ex, showStackTrace: true);
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

        private void LogError(string errorMessage, params string[] args)
        {
            LogError(string.Format(errorMessage, args));
        }

        private void LogWarning(string warningMessage, params string[] args)
        {
            Log.LogWarning(warningMessage, args);
        }

        private void LogWarningFromException(Exception ex)
        {
            Log.LogWarningFromException(ex, true);
        }

        #endregion
    }
}
