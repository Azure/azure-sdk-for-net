namespace Microsoft.Azure.Build.BootstrapTasks
{
    using System;
    using Microsoft.Build.Framework;
    using Microsoft.Build.Utilities;
    using System.Collections.Generic;
    using System.IO;
    using System.Net;

    /// <summary>
    /// Bootstrap task, which simply copies all build tools to local branch
    /// </summary>
    public class GetBuildTools : Task
    {
        #region Fields
        const string COPY_TO_RELATIVEPATH = @"tools\SdkBuildTools\";
        const string COPY_FROM_RELATIVEPATH = @"tools\BuildAssets\";
        const string DEFAULT_REMOTE_ROOT_DIR = "https://raw.githubusercontent.com/Azure/azure-sdk-for-net/NetSdkBuild/";

        private WebClient _webCopier;
        private TaskLogger _buildToolsLogger;
        private string _localBranchCopyToRootDir;
        #endregion

        #region Properties

        #region Required Properties
        /// <summary>
        /// Sets/Gets Local branch Root Directory
        /// </summary>
        [Required]
        public string LocalBranchRootDir { get; set; }
        #endregion

        /// <summary>
        /// Remote root directory (e.g. http://github.com/azure/azure-sdk-for-net/<branchName>)
        /// </summary>
        public string RemoteRootDir { get; set; }

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
            //Init();
        }

        private void Init()
        {
            if (string.IsNullOrEmpty(LocalBranchRootDir))
            {
                throw new ApplicationException("Cannot have 'LocalBranchRootDir' null or empty");
            }
            else if (!Directory.Exists(LocalBranchRootDir))
            {
                throw new DirectoryNotFoundException(string.Format("Specified directory '{0}' is either invalid or does not exists", LocalBranchRootDir));
            }
            else
            {
                LocalBranchCopyToRootDir = Path.Combine(LocalBranchRootDir, COPY_TO_RELATIVEPATH);
            }

            if (string.IsNullOrEmpty(RemoteRootDir))
            {
                RemoteRootDir = DEFAULT_REMOTE_ROOT_DIR;
            }

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

            BuildToolsLogger.LogInfo("RemoteCopyFromRootDir '{0}'", RemoteCopyFromRootDir);
            BuildToolsLogger.LogInfo("LocalBranchCopyToRootDir '{0}'", LocalBranchCopyToRootDir);
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

                unableToCopyFilePath = new List<string>();
                LocalMetaDataFilePath = CopyFile(RemoteMetaDataFilePath);

                string[] filesToCopy = File.ReadAllLines(LocalMetaDataFilePath);

                foreach (string fl in filesToCopy)
                {
                    copyFrom = Path.Combine(RemoteCopyFromRootDir, fl);
                    copyTo = Path.Combine(LocalBranchCopyToRootDir, fl);
                    //CopyFile(copyFrom, copyTo);
                }

                ReportErrors();
            }
            catch (Exception ex)
            {
                BuildToolsLogger.LogException(ex);
            }
            finally
            {
                WebCopier?.Dispose();
                VerifyCopiedFiles();
            }

            return true;
        }

        /// <summary>
        /// Verify whether all files have been copied
        /// </summary>
        /// <returns></returns>
        private void VerifyCopiedFiles()
        {
            if(!File.Exists(LocalMetaDataFilePath))
            {
                BuildToolsLogger.LogException(new Exception("Could not find file: "+LocalMetaDataFilePath));  
                return; 
            }
            foreach(var f in File.ReadAllLines(LocalMetaDataFilePath))
            {
                var fPath = Path.Combine(LocalBranchCopyToRootDir, f);
                if(!File.Exists(fPath))
                {
                    BuildToolsLogger.LogException(new Exception("Could not find file: "+fPath));   
                }
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
                BuildToolsLogger.LogInfo("Copying {0}", destinationPath);
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