// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Microsoft.Azure.Sdk.Build.Tasks
{
    using Microsoft.Azure.Sdk.Build.Tasks.BaseTasks;
    using Microsoft.Build.Framework;
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.IO;
    using System.Linq;
    using System.Text;

    /// <summary>
    /// Archive Symbols Task will
    /// 1) Copy the build output to an UNC Path (provided from Jenkins Job in order to hardcode paths and to avoid publishing internal UNC paths)
    /// 2) Create the required request file
    /// 3) Execute the request to queue up the Symbols Archiving request
    /// 
    /// In case the Archive requests and you ever need to queuen up a new request for symbol archive
    /// Use the cmdline printed in the log (requestOutput\requestOutput.txt) to execute from command line to queue up a new request for the same exact symbols
    /// 
    /// TODO:
    ///     Symbols service has no automated way to inform if the request was processed
    ///     Currently an email is sent
    /// </summary>
    public class ArchiveSymbolsTask : NetSdkTask
    {
        #region const
        const string OUTPUT_ROOTDIRNAME_DEBUG = "Debug";
        const string OUTPUT_ROOTDIRNAME_RELEASE = "Release";
        #endregion

        #region fields
        private string _symbolsArchiveRootDir;
        private string _buildJobId;
        private List<string> _assemblyList;
        #endregion

        protected override INetSdkTask TaskInstance => this;

        /// <summary>
        /// List of ITaskItem that represents built assembly files        
        /// </summary>
        [Required]
        public ITaskItem[] BuiltAssemblyFileCollection { get; set; }

        /// <summary>
        /// UNC path where symbols/assemblies will be copied which is used by the Symbols Archive process that will process your archive requests at a later stage
        /// </summary>
        [Required]
        public string ArchiveSymbolsRootDir
        {
            get
            {
                if (!Directory.Exists(_symbolsArchiveRootDir))
                {
                    string alternatePath = System.Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                    if (!File.Exists(alternatePath))
                    {
                        string expMsg = string.Format("Provided path '{0}', does not exists and unable to determine alternate Symbols Archive directory path.", _symbolsArchiveRootDir);
                        throw new ApplicationException(expMsg);
                    }
                }

                return _symbolsArchiveRootDir;
            }
            set
            {
                _symbolsArchiveRootDir = value;
            }
        }

        /// <summary>
        /// List of symbol archive request files
        /// This is primarily used for test purpose
        /// </summary>
        [Output]
        public List<string> SymbolsRequestFileList { get; set; }


        /// <summary>
        /// In case the process of archiving symbols fail, this email will be used to communicate the current status of your archive request
        /// </summary>
        public string ArchiveSymbolsRequestStatusEmail { get; set; }

        /// <summary>
        /// This is an internal list that is used to process assembly list
        /// Rather than dealing with ITaskItems, this is a list of ITaskItem.ItemSpec
        /// </summary>
        private List<string> BuiltAssemblyList
        {
            get
            {
                if(_assemblyList == null)
                {
                    if(BuiltAssemblyFileCollection != null)
                    {
                        if(BuiltAssemblyFileCollection.Any<ITaskItem>())
                        {
                            _assemblyList = BuiltAssemblyFileCollection.Select<ITaskItem, string>((item) => item.ItemSpec)?.ToList<string>();
                        }
                        else
                        {
                            _assemblyList = new List<string>();
                        }
                    }
                }

                return _assemblyList;
            }
        }

        /// <summary>
        /// In Jenkins ${BUILD_NUMBER} provides the JobId
        /// </summary>
        public string BuildJobId
        {
            get
            {
                if(string.IsNullOrWhiteSpace(_buildJobId))
                {
                    Random r = new Random(DateTime.Now.Minute);
                    _buildJobId = string.Format("rnd{0}", r.Next(99999).ToString());
                }

                return _buildJobId;
            }

            set
            {
                _buildJobId = value;
            }
        }

        /// <summary>
        /// True: Will not execute to queue up symbols request, will only create the request file and copy symbols to the SysmbolArchiveRootDir
        /// False: Will create request file as well as execute to queue up symbol archive request
        /// </summary>
        public bool SkipExecuteSymbolsRequest { get; set; }
        
        /// <summary>
        /// Project name registered with Symbol Archiving service
        /// If not provided default name will be used set by the Azure .NET SDK team
        /// </summary>
        public string ArchiveSymbolsRequestProjectName { get; set; }

        public ArchiveSymbolsTask()
        {
            SymbolsRequestFileList = new List<string>();
            SkipExecuteSymbolsRequest = false;
        }

        public override bool Execute()
        {
            TaskLogger.LogInfo("Executing Archiving Task.....");

            List<SymbolsCopyInfo> symbolList = GetSymbolsInfo();

            foreach(SymbolsCopyInfo symInfo in symbolList)
            {
                symInfo.CreateSymbolRequest();
                SymbolsRequestFileList.Add(symInfo.SymbolRequestFilePath);

                if(SkipExecuteSymbolsRequest == false)
                {
                    symInfo.SendSymbolRequest();
                    
                    if(!string.IsNullOrWhiteSpace(symInfo.ArchiveRequestErrorOutput))
                    {
                        ApplicationException aEx = new ApplicationException(symInfo.ArchiveRequestErrorOutput);
                        TaskLogger.LogException(aEx);
                    }
                    else
                    {
                        TaskLogger.LogInfo(symInfo.ArchiveRequestOutput);
                    }
                }
            }

            return true;
        }

        private List<SymbolsCopyInfo> GetSymbolsInfo()
        {
            // Symbol archive Path format: 12-12-2018\BuildJobId-4DigitRandomNumber\PackageName
            int randomMaxValue = 9999;
            Random rnd = new Random(DateTime.Now.Second);
            string dateStr = DateTime.Now.ToString("dd-MM-yyyy");
            string jobId = string.Format("{0}-{1}", BuildJobId, rnd.Next(randomMaxValue));
            int requestIdCount = 1;

            List<SymbolsCopyInfo> symReqList = new List<SymbolsCopyInfo>();
            Dictionary<string, string> uniqueDirPath = new Dictionary<string, string>();
            // Iterate all the file path
            // First get the "release" directory each release directory has target framework directory
            // for e.g. net452, netstandard1.4, these directories will be copied to the symbols directory, because the symbol service will have to
            // archive copy both target symbols
            // We then go two level up, that will give us the ResourceProvider directory
            // This directory helps in creating distinct directory names to avoid collision in scenario where there are more than
            // one nuget package is getting published

            foreach(string asmFile in BuiltAssemblyList)
            {
                TaskLogger.LogInfo("Trying to find {0} dir in the directory hierarchy", OUTPUT_ROOTDIRNAME_RELEASE);
                string outputRootDir = FindDir(asmFile, OUTPUT_ROOTDIRNAME_RELEASE);
                if(string.IsNullOrWhiteSpace(outputRootDir))
                {
                    TaskLogger.LogInfo("Trying to find {0} dir in the directory hierarchy", OUTPUT_ROOTDIRNAME_DEBUG);
                    outputRootDir = FindDir(asmFile, OUTPUT_ROOTDIRNAME_DEBUG);
                }

                TaskLogger.LogInfo("Found dir '{0}'", outputRootDir);

                if(!string.IsNullOrWhiteSpace(outputRootDir))
                {
                    if(!uniqueDirPath.ContainsKey(outputRootDir))
                    {
                        //TaskLogger.LogInfo("Processing ")
                        uniqueDirPath.Add(outputRootDir, outputRootDir);
                        string sdkDir = FindDir(outputRootDir, "bin");
                        if (!string.IsNullOrWhiteSpace(sdkDir))
                        {
                            //ASSUMPTION: the output path for compiled will be the default path that VS has ProjectDir\bin\debug|release\FxVersion\
                            sdkDir = Path.GetDirectoryName(sdkDir);
                            string rpName = Path.GetFileName(sdkDir);
                            string archiveDir = Path.Combine(ArchiveSymbolsRootDir, dateStr, jobId, rpName);
                            string reqId = string.Format("{0}-{1}", jobId, (requestIdCount++).ToString());
                            SymbolsCopyInfo symInfo = new SymbolsCopyInfo(outputRootDir, sdkDir, archiveDir, reqId);
                            symInfo.AssemblyFileVersion = FileVersionInfo.GetVersionInfo(asmFile).ProductVersion;
                            symInfo.SymbolRequestingProjectName = ArchiveSymbolsRequestProjectName;
                            symInfo.StatusEmailTo = ArchiveSymbolsRequestStatusEmail;
                            symReqList.Add(symInfo);

                            TaskLogger.LogInfo("Creating archive request for '{0}' remoteDir '{1}'", symInfo.SrcDirPath, symInfo.DestDirPath);
                        }
                    }
                }
            }

            return symReqList;
        }

        /// <summary>
        /// Finds directory that is being passed in <paramref name="dirName"/>
        /// Walks one directory up at a time until it finds <paramref name="dirName"/>
        /// This function assumes <paramref name="filePath"/> is indeed a file path and not directory path
        /// </summary>
        /// <param name="filePath"></param>
        /// <param name="dirName"></param>
        /// <returns></returns>
        internal string FindDir(string filePath, string dirName)
        {
            string parentDir = string.Empty;
            string currDirPath = Directory.GetCurrentDirectory();

            if(!string.IsNullOrWhiteSpace(filePath))
            {
                currDirPath = Path.GetDirectoryName(filePath);
                string dirRoot = Directory.GetDirectoryRoot(currDirPath);

                while (currDirPath != dirRoot)
                {
                    //We use GetFileName, as it works for non-existant paths
                    string cDir = Path.GetFileName(currDirPath);

                    if(cDir.Equals(dirName, StringComparison.OrdinalIgnoreCase))
                    {
                        parentDir = currDirPath;
                        break;
                    }

                    currDirPath = Path.GetDirectoryName(currDirPath);
                }
            }

            return parentDir;
        }
    }

    /// <summary>
    /// Internal data structure to hold Symbol Archive request meta data
    /// </summary>
    internal class SymbolsCopyInfo
    {
        #region const
        const string SYM_PROJECT_NAME = "AzureDotNetSdks";
        #endregion

        #region fields
        string _symbolRequestProjectName;
        #endregion

        #region Properties
        public string AssemblyFileVersion { get; set; }
        public string SrcDirPath { get; set; }
        public string RPDirPath { get; set; }

        public string RPName
        {
            get
            {
                return Path.GetFileName(RPDirPath);
            }
        }
        public string DestDirPath { get; set; }

        public string SymbolRequestFilePath { get; set; }

        public string RequestId { get; set; }

        public string StatusEmailTo { get; set; }

        public string ArchiveRequestOutput { get; set; }

        public string ArchiveRequestErrorOutput { get; set; }

        public string SymbolRequestingProjectName
        {
            get
            {
                if(string.IsNullOrWhiteSpace(_symbolRequestProjectName))
                {
                    _symbolRequestProjectName = SYM_PROJECT_NAME;
                }

                return _symbolRequestProjectName;
            }

            set
            {
                _symbolRequestProjectName = value;
            }
        }

        #endregion

        public SymbolsCopyInfo(string srcDir, string rpDir, string destDir, string reqId)
        {
            SrcDirPath = srcDir;
            RPDirPath = rpDir;
            DestDirPath = destDir;
            RequestId = reqId;
        }

        public void CreateSymbolRequest()
        {
            CopySymbols(this.SrcDirPath, this.DestDirPath, copySubDirs: true);
            CreateRequestFile();
        }

        public void SendSymbolRequest()
        {
            StringBuilder sb = new StringBuilder();
            string errOutput = string.Empty;
            Process proc = null;
            string outputFilePath = string.Empty;
            string outputDir = string.Empty;

            try
            {   
                outputDir = Path.Combine(Path.GetDirectoryName(this.SymbolRequestFilePath), "requestOutput");
                outputFilePath = Path.Combine(outputDir, "requestOutput.txt");

                string args = string.Format(@" /c \\symbols\tools\createrequest.cmd -i {0} -d {1} -c -a", this.SymbolRequestFilePath, outputDir);
                ProcessStartInfo procInfo = new ProcessStartInfo("cmd.exe");
                procInfo.Arguments = args;
                procInfo.CreateNoWindow = true;
                procInfo.UseShellExecute = false;
                procInfo.RedirectStandardError = true;
                procInfo.RedirectStandardOutput = true;

                proc = new Process();
                proc.StartInfo = procInfo;
                proc.Start();
                proc.WaitForExit(60000);

                //errOutput = proc?.StandardError?.ReadToEnd();
                string output = proc?.StandardOutput?.ReadToEnd();

                sb.AppendLine(args);
                sb.AppendLine();
                sb.AppendLine(output);
            }
            catch (Exception ex)
            {
                errOutput = proc?.StandardError?.ReadToEnd();
                sb.AppendLine();
                sb.AppendLine(errOutput);
                sb.AppendLine();
                sb.AppendLine();
                sb.AppendLine(ex.ToString());
                throw ex;
            }
            finally
            {
                if (sb.Length > 0)
                {
                    if (File.Exists(outputFilePath))
                    {
                        File.Delete(outputFilePath);
                    }

                    File.WriteAllText(outputFilePath, sb.ToString());

                    var errFiles = Directory.EnumerateFiles(outputDir, "*.err", SearchOption.TopDirectoryOnly);

                    if (errFiles != null)
                    {
                        if (errFiles.Any<string>())
                        {
                            string ef = errFiles.First<string>();
                            sb.AppendLine();
                            sb.AppendLine(File.ReadAllText(ef));
                            sb.AppendLine();
                            this.ArchiveRequestErrorOutput = sb.ToString();
                        }
                    }

                    this.ArchiveRequestOutput = sb.ToString();
                }
            }
        }

        private void CopySymbols(string sourceDirName, string destDirName, bool copySubDirs)
        {
            // Get the subdirectories for the specified directory.
            DirectoryInfo dir = new DirectoryInfo(sourceDirName);

            if (!dir.Exists)
            {
                throw new DirectoryNotFoundException(
                    "Source directory does not exist or could not be found: "
                    + sourceDirName);
            }

            DirectoryInfo[] dirs = dir.GetDirectories();
            // If the destination directory doesn't exist, create it.
            if (!Directory.Exists(destDirName))
            {
                Directory.CreateDirectory(destDirName);
            }

            // Get the files in the directory and copy them to the new location.
            FileInfo[] files = dir.GetFiles();
            foreach (FileInfo file in files)
            {
                string temppath = Path.Combine(destDirName, file.Name);
                file.CopyTo(temppath, false);
            }

            // If copying subdirectories, copy them and their contents to new location.
            if (copySubDirs)
            {
                foreach (DirectoryInfo subdir in dirs)
                {
                    string temppath = Path.Combine(destDirName, subdir.Name);
                    CopySymbols(subdir.FullName, temppath, copySubDirs);                    
                }
            }
        }

        private void CreateRequestFile()
        {
            StringBuilder reqSB = new StringBuilder();

            reqSB.AppendLine(string.Format("Build={0}", this.AssemblyFileVersion));
            reqSB.AppendLine(string.Format("BuildId={0}", RequestId));
            reqSB.AppendLine(string.Format("BuildRemark={0}", "rtm"));

            reqSB.AppendLine(string.Format("Directory={0}", DestDirPath));

            reqSB.AppendLine(string.Format("ProductGroup={0}", this.SymbolRequestingProjectName));
            reqSB.AppendLine(string.Format("ProductName={0}", this.SymbolRequestingProjectName));
            reqSB.AppendLine(string.Format("Project={0}", this.SymbolRequestingProjectName));
            
            reqSB.AppendLine(string.Format("Recursive={0}", "yes"));
            reqSB.AppendLine(string.Format("Release={0}", "rtm"));

            reqSB.AppendLine(string.Format("StatusMail={0}", StatusEmailTo));
            reqSB.AppendLine(string.Format("SubmitToArchive={0}", "all"));
            reqSB.AppendLine(string.Format("SubmitToInternet={0}", "yes"));

            //TODO: parameterize the below property if we need to track much more closely
            reqSB.AppendLine(string.Format("UserName={0}", "abhishah"));

            string reqFileName = string.Format("{0}-{1}.txt", RequestId, RPName);
            string filePath = Path.Combine(this.DestDirPath, reqFileName);

            this.SymbolRequestFilePath = filePath;

            if(File.Exists(filePath))
            {
                File.Delete(filePath);
            }

            File.WriteAllText(filePath, reqSB.ToString());
        }

        private bool VerifySymbolArchiveRequest()
        {
            var srcFiles = Directory.EnumerateFiles(this.SrcDirPath, "*", SearchOption.AllDirectories);
            var destFiles = Directory.EnumerateFiles(this.DestDirPath, "*", SearchOption.AllDirectories);

            int srcCount = srcFiles.Count<string>();
            int destCount = destFiles.Count<string>();

            if(!File.Exists(this.SymbolRequestFilePath))
            {
                throw new FileNotFoundException("Unable to find created Symbol request file '{0}'", this.SymbolRequestFilePath);
            }

            if(!srcCount.Equals(destCount))
            {
                throw new ApplicationException(string.Format("FILE COUNT MISMATCH: Source symbol directory '{0}' file count: '{1}', and copied file count '{2}' in destination location '{3}' do not match", srcCount, this.SrcDirPath, this.DestDirPath, destCount));
            }

            return true;
        }
    }
}
