// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Microsoft.Azure.Build.BootstrapTasks
{
    using System;
    using Microsoft.Build.Framework;
    using Microsoft.Build.Utilities;
    using System.Collections.Generic;
    using System.IO;
    using System.Net;
    using System.Linq;
    using System.Text.RegularExpressions;

    /// <summary>
    /// Bootstrap task, which simply copies all build tools to local branch
    /// </summary>
    public class GetBuildTools : Task
    {

        #region CONST
        const string DEFAULT_RAW_URI_Prefix = @"https://raw.githubusercontent.com";
        const string DEFAULT_FORK = "Azure";
        const string DEFAULT_BRANCH_NAME = "SdkBuildTools";
        const string AKAMS_URI = @"http://aka.ms/AzNetSDKBuildTools";

        const string COPY_TO_RELATIVEPATH = @"tools\SdkBuildTools\";
        const string COPY_FROM_RELATIVEPATH = @"tools\BuildAssets\";
        const string DEFAULT_REMOTE_ROOT_DIR = "https://raw.githubusercontent.com/Azure/azure-sdk-for-net/";
        //const string DEFAULT_REMOTE_ROOT_DIR = "https://raw.githubusercontent.com/Azure/azure-sdk-for-net/SdkBuildTools/";
        #endregion

        #region Fields
        private string _remoteRootDir;
        private string _remoteBranchName;
        private string _localBranchRootDir;

        private WebClient _webCopier;
        private TaskLogger _buildToolsLogger;
        private string _localBranchCopyToRootDir;
        #endregion

        #region Properties

        #region Required Properties
        /// <summary>
        /// Sets/Gets Local branch Root Directory
        /// </summary>
        //[Required]
        //public string LocalBranchRootDir { get; set; }

        [Required]
        public string LocalBranchRootDir
        { 
            get
            {
                return _localBranchRootDir;
            }

            set
            {
                _localBranchRootDir = value;

                if (string.IsNullOrEmpty(_localBranchRootDir))
                {
                    throw new ApplicationException("Cannot have 'LocalBranchRootDir' null or empty");
                }
                else if (!Directory.Exists(_localBranchRootDir))
                {
                    throw new DirectoryNotFoundException(string.Format("Specified directory '{0}' is either invalid or does not exists", _localBranchRootDir));
                }
                else
                {
                    LocalBranchCopyToRootDir = Path.Combine(_localBranchRootDir, COPY_TO_RELATIVEPATH);
                }
            }
        }

        public string RemoteBranchName
        {
            get
            {
                if(string.IsNullOrEmpty(_remoteBranchName))
                {
                    _remoteBranchName = DEFAULT_BRANCH_NAME;
                }

                return _remoteBranchName;
            }

            set { _remoteBranchName = value; } }

        public string ForkName { get; set; }

        public bool WhatIf { get; set; }

        public bool OverrideLocal { get; set; }
        #endregion

        #region other properties
        /// <summary>
        /// Remote root directory (e.g. http://github.com/azure/azure-sdk-for-net/<branchName>)
        /// </summary>
        public string RemoteRootDir
        {
            get
            {
                if (string.IsNullOrEmpty(_remoteRootDir))
                {
                    if (Directory.Exists(LocalBranchRootDir))
                    {
                        string localCopyFrom = Path.Combine(LocalBranchRootDir, COPY_FROM_RELATIVEPATH);
                        if (Directory.Exists(localCopyFrom))
                        {
                            if (OverrideLocal == false) //this helps for not copying local buildAssets but rather from remote location (applicable for scenarios running in build tools branch)
                            {
                                _remoteRootDir = LocalBranchRootDir;
                            }
                        }
                    }

                    if (string.IsNullOrEmpty(_remoteRootDir))
                    {
                        Uri remoteUri = GetRemoteUri();
                        if (remoteUri == null)
                        {
                            //_remoteRootDir = Path.Combine(DEFAULT_RAW_URI_Prefix, DEFAULT_FORK, DEFAULT_BRANCH_NAME);
                            _remoteRootDir = string.Join(Path.AltDirectorySeparatorChar.ToString(), DEFAULT_RAW_URI_Prefix, DEFAULT_FORK, DEFAULT_BRANCH_NAME);
                        }
                        else
                        {
                            string url = remoteUri.ToString();
                            Regex regex = new Regex("readme.md", RegexOptions.IgnoreCase);
                            if (regex.IsMatch(url))
                            {
                                _remoteRootDir = regex.Replace(url, "");
                            }
                            else
                            {
                                BuildToolsLogger.LogException(new Exception(string.Format("Url {0} does not contain readme.md", url)));
                            }
                        }
                    }
                }

                return _remoteRootDir;
            }

            set { _remoteRootDir = value; }
        }

        /// <summary>
        /// Local branch root directory where files need to be copied to
        /// </summary>
        public string LocalBranchCopyToRootDir { get; set; }

        /// <summary>
        /// Remote directory from where files need to be copied from
        /// </summary>
        public string RemoteCopyFromRootDir { get; set; }

        /// <summary>
        /// Local file path for copied Meta data file
        /// </summary>
        public string LocalMetaDataFilePath { get; set; }

        /// <summary>
        /// Remote file path from where meta data file needs to be copied from
        /// </summary>
        public string RemoteMetaDataFilePath { get; internal set; }

        /// <summary>
        /// Stores all the file paths that resulted in any exception (either not found on source or unable to copy on destination)
        /// </summary>
        public List<string> unableToCopyFilePath;

        /// <summary>
        /// Output debug traces during execution of task
        /// </summary>
        public bool DebugTrace { get; set; }

        #endregion

        #region Misc external objects
        /// <summary>
        /// Logger
        /// </summary>
        internal TaskLogger BuildToolsLogger
        {
            get
            {
                if (_buildToolsLogger == null)
                {
                    _buildToolsLogger = new TaskLogger(DebugTrace);
                    _buildToolsLogger.BuildEngine = this.BuildEngine;
                }

                return _buildToolsLogger;
            }
        }

        /// <summary>
        /// WebClient to copy files
        /// </summary>
        internal WebClient WebCopier
        {
            get
            {
                if (_webCopier == null)
                {
                    _webCopier = new WebClient();
                }
                return _webCopier;
            }
        }

        #endregion

        #endregion

        #region Constrcutor/Init

 
        public GetBuildTools(string localRootDir, string remoteRootDir)
        {
            LocalBranchRootDir = localRootDir;
            RemoteRootDir = remoteRootDir;
            Init();
        }
        /// <summary>
        /// Constructor
        /// </summary>
        public GetBuildTools()
        {
            // Init();
        }

        private void Init()
        {
            //if(string.IsNullOrEmpty(RemoteBranchName))
            //{
            //    RemoteBranchName = DEFAULT_BRANCH_NAME;
            //}

            //if (string.IsNullOrEmpty(LocalBranchRootDir))
            //{
            //    throw new ApplicationException("Cannot have 'LocalBranchRootDir' null or empty");
            //}
            //else if (!Directory.Exists(LocalBranchRootDir))
            //{
            //    throw new DirectoryNotFoundException(string.Format("Specified directory '{0}' is either invalid or does not exists", LocalBranchRootDir));
            //}
            //else
            //{
            //    LocalBranchCopyToRootDir = Path.Combine(LocalBranchRootDir, COPY_TO_RELATIVEPATH);
            //}

            //if (string.IsNullOrEmpty(RemoteRootDir))
            //{
            //    string localCopyFrom = Path.Combine(LocalBranchRootDir, COPY_FROM_RELATIVEPATH);
            //    if(!Directory.Exists(localCopyFrom))
            //    {
            //        //RemoteRootDir = DEFAULT_REMOTE_ROOT_DIR;
            //        RemoteRootDir = Path.Combine(DEFAULT_REMOTE_ROOT_DIR, RemoteBranchName, Path.AltDirectorySeparatorChar.ToString());
            //    }
            //    else
            //    {
            //        RemoteRootDir = LocalBranchRootDir;
            //    }
            //}

            if (RemoteRootDir.StartsWith("http"))
            {
                RemoteCopyFromRootDir = new Uri(new Uri(RemoteRootDir), COPY_FROM_RELATIVEPATH).ToString();
                RemoteMetaDataFilePath = new Uri(new Uri(RemoteCopyFromRootDir), "metaData/FilesToCopy.txt").ToString();
            }
            else
            {
                RemoteCopyFromRootDir = Path.Combine(RemoteRootDir, COPY_FROM_RELATIVEPATH);
                RemoteMetaDataFilePath = Path.Combine(RemoteCopyFromRootDir, @"metaData\FilesToCopy.txt");
            }

            BuildToolsLogger.LogDebugInfo("RemoteCopyFromRootDir: '{0}'", RemoteCopyFromRootDir);
            BuildToolsLogger.LogDebugInfo("LocalBranchCopyToRootDir: '{0}'", LocalBranchCopyToRootDir);
        }
        #endregion

        /// <summary>
        /// Copies tasks and targets to local branch
        /// </summary>
        /// <returns></returns>
        public override bool Execute()
        {
            try
            {
                Init();
                IBuildEngine buildEng = this.BuildEngine;
                string copyFrom = string.Empty;
                string copyTo = string.Empty;
                string fileName = string.Empty;

                if (WhatIf == true)
                {
                    BuildToolsLogger.LogInfo("Build tools will be copied FROM: '{0}'", RemoteCopyFromRootDir);
                    BuildToolsLogger.LogInfo("Build tools will be copied TO: '{0}'", LocalBranchCopyToRootDir);
                }
                else
                {
                    BuildToolsLogger.LogInfo("Updating Tools.....");
                    unableToCopyFilePath = new List<string>();
                    LocalMetaDataFilePath = CopyFile(RemoteMetaDataFilePath);

                    string[] filesToCopy = File.ReadAllLines(LocalMetaDataFilePath);

                    foreach (string fl in filesToCopy)
                    {
                        copyFrom = Path.Combine(RemoteCopyFromRootDir, fl);
                        copyTo = Path.Combine(LocalBranchCopyToRootDir, fl);
                        BuildToolsLogger.LogDebugInfo(string.Format("Copying {0} to {1}", copyFrom, copyTo));
                        CopyFile(copyFrom, copyTo);
                    }

                    CopyPowershellModules(Path.Combine(LocalBranchCopyToRootDir), filesToCopy);
                    ReportErrors();
                }
            }
            catch (Exception ex)
            {
                if (ex is FileNotFoundException)
                {
                    unableToCopyFilePath.Add(((FileNotFoundException)ex).FileName);
                }
                BuildToolsLogger.LogException(ex);
            }
            finally
            {
                WebCopier?.Dispose();
            }

            return true;
        }

        private Uri GetRemoteUri()
        {
            Uri remoteUri = null;
            HttpWebRequest req = null;

            try
            {
                req = (HttpWebRequest)WebRequest.Create(AKAMS_URI);
                req.Method = "HEAD";
                //req.AllowAutoRedirect = false;

                HttpWebResponse myResp = (HttpWebResponse)req.GetResponse();
                //if (myResp.StatusCode == HttpStatusCode.Redirect)
                if (myResp.StatusCode == HttpStatusCode.OK)
                {
                    string url = myResp.ResponseUri.ToString();
                    if(!url.ToLower().Contains("microsoft"))
                    {
                        remoteUri = myResp.ResponseUri;
                        //BuildToolsLogger.LogInfo("redirected to:" + myResp.GetResponseHeader("Location"));
                    }
                }
                if (remoteUri == null)
                {
                    BuildToolsLogger.LogDebugInfo("Unable to retrieve aka.ms uri");
                }
            }
            catch { }

            return remoteUri;
        }


        /// <summary>
        /// Copy powershell modules to the user profile powershell dir
        /// </summary>
        /// <param name="psModulesDir">Powershell modules source dir</param>
        /// <param name="filesToCopy">List of files to copy to tools dir</param>
        /// <returns></returns>

        private void CopyPowershellModules(string psModulesDir, string[] filesToCopy)
        {
            string userProfilePSModulesPath = new Uri(Environment.GetEnvironmentVariable("USERPROFILE") + "\\Documents\\WindowsPowerShell\\Modules").AbsolutePath;
            
            IEnumerable<string> psModulesToCopy = filesToCopy.Where(p=>p.StartsWith("psModules"));
            foreach (var module in psModulesToCopy)
            {
                var srcFile = Path.GetFullPath(Path.Combine(psModulesDir, module));
                var destFile = Path.GetFullPath(Path.Combine(userProfilePSModulesPath, module.Replace("psModules/", "")));
                BuildToolsLogger.LogDebugInfo(string.Format("Copying {0} to {1}", srcFile, destFile));
                CopyFile(srcFile, destFile);
            }
        }

        /// <summary>
        /// Copy files
        /// </summary>
        /// <param name="sourceFile">Source full file path</param>
        /// <param name="destinationPath">destination full file path</param>
        /// <returns></returns>
        private string CopyFile(string sourceFile, string destinationPath = "")
        {
            if (string.IsNullOrEmpty(destinationPath))
            {
                destinationPath = LocalBranchCopyToRootDir;
                string fileName = Path.GetFileName(sourceFile);
                destinationPath = Path.Combine(destinationPath, fileName);
            }

            CreateDirectory(destinationPath);

            if (sourceFile.StartsWith("http"))
            {
                WebCopier.DownloadFile(sourceFile, destinationPath);
            }
            else
            {
                File.Copy(sourceFile, destinationPath, true);
            }

            if (!File.Exists(destinationPath))
            {
                unableToCopyFilePath.Add(destinationPath);
                destinationPath = string.Empty;
            }
            else
            {
                BuildToolsLogger.LogDebugInfo("Copying to {0}", destinationPath);
            }

            return destinationPath;
        }

        /// <summary>
        /// Create directory if does not exists
        /// </summary>
        /// <param name="filePath">File path for which directory path will be checked and created</param>
        private void CreateDirectory(string filePath)
        {
            string dirPath = Path.GetDirectoryName(filePath);
            if (!Directory.Exists(dirPath))
            {
                Directory.CreateDirectory(dirPath);
            }
        }

        /// <summary>
        /// Iterates list that holds files that resulted in exepction and logs to the logger
        /// </summary>
        private void ReportErrors()
        {
            foreach (string fileNotCopied in unableToCopyFilePath)
            {
                BuildToolsLogger.LogError(string.Format("Unable to copy '{0}'", fileNotCopied));
            }
        }
    }
}