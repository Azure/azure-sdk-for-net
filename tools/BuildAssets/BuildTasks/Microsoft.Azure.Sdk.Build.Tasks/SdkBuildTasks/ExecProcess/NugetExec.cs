// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

//namespace Microsoft.WindowsAzure.Build.Tasks.ExecProcess
namespace Microsoft.Azure.Sdk.Build.ExecProcess
{
    using Microsoft.Build.Utilities;
    using Microsoft.WindowsAzure.Build.Tasks.Utilities;
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;

    public class NugetExec : ShellExec
    {
        #region Fields
        string _defaultNugetArgsFormat;
        string _publishToPath;
        string _publishSymbolToPath;
        string _nugetExePath;
        #endregion

        private TaskLoggingHelper TaskLogger { get; set; }

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
                // We check if nuget publishing is happening to a non-standard location (e.g. local hard drive or anything other than the officialy nuget publish location
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

        public NugetExec(string nugetExePath, TaskLoggingHelper logger): this(nugetExePath)
        {
            TaskLogger = logger;
        }

        public NugetExec() : this(Constants.NugetDefaults.NUGET_PATH)
        {
        }

        public NugetExec(TaskLoggingHelper logger) : this()
        {
            TaskLogger = logger;
        }

        #region Publish
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

            return new NugetPublishStatus()
            {
                NugetPackagePath = nupkgPath,
                NugetPublishExitCode = exitCode,
                NugetPublishStatusOutput = output,
                PublishArgs = displayArgs,
                CaughtException = this.LastException
            };
        }

        public List<Tuple<NugetPublishStatus, NugetPublishStatus>> Publish(List<Tuple<string, string>> pkgList)
        {
            List<Tuple<NugetPublishStatus, NugetPublishStatus>> statusList = new List<Tuple<NugetPublishStatus, NugetPublishStatus>>();

            foreach (Tuple<string, string> pkgTup in pkgList)
            {
                statusList.Add(Publish(pkgTup));
            }

            return statusList;
        }


        public Tuple<NugetPublishStatus, NugetPublishStatus> Publish(Tuple<string, string> nugPkgs)
        {
            StringBuilder sb = new StringBuilder();
            NugetPublishStatus nugetStatus = null;
            NugetPublishStatus symbolStatus = null;
            List<Tuple<NugetPublishStatus, NugetPublishStatus>> statusList = new List<Tuple<NugetPublishStatus, NugetPublishStatus>>();

           
            // Check if publishing nuget has to be skipped
            if (SkipPublishingNuget == false)
            {
                nugetStatus = Publish(nugPkgs.Item1);
            }

            // Check if publishing symbols has to be skipped
            if (SkipPublishingSymbols == false)
            {
                // Check if nuget was published, not checking will result in nullRef
                if (SkipPublishingNuget == false)
                {
                    if (nugetStatus.NugetPublishExitCode == 0)
                    {
                        symbolStatus = Publish(nugPkgs.Item2);
                    }
                }
                else
                {
                    symbolStatus = Publish(nugPkgs.Item2);
                }
            }

            Tuple<NugetPublishStatus, NugetPublishStatus> status = new Tuple<NugetPublishStatus, NugetPublishStatus>(nugetStatus, symbolStatus);
            //statusList.Add(new Tuple<NugetPublishStatus, NugetPublishStatus>(nugetStatus, symbolStatus));
            return status;
        }

        #endregion

        #region Caches
        public List<string> GetRestoreCacheLocation(string workingDir = "")
        {
            string procOutput = string.Empty;
            string args = @"locals all -list";
            string[] outputSplitToken = new string[] { Environment.NewLine };
            string[] cacheLocationSplitToken = new string[] { " " }; 
            List<string> cacheLocationPath = new List<string>();
            int exitCode = -1;

            if(string.IsNullOrEmpty(workingDir))
            {
                exitCode = ExecuteCommand(args);
            }
            else
            {
                exitCode = ExecuteCommand(args, workingDir);
            }

            if(exitCode != 0)
            {
                procOutput = this.AnalyzeExitCode();
            }
            else
            {
                procOutput = this.GetOutput();

                foreach(string cacheLoc in procOutput.Split(outputSplitToken, StringSplitOptions.RemoveEmptyEntries ))
                {
                    string[] locTokens = cacheLoc.Split(cacheLocationSplitToken, StringSplitOptions.RemoveEmptyEntries);

                    //TODO: find a much robust way to deal with the split tokens
                    if(locTokens?.Length == 2)
                    {
                        // we are assuming that there will not be any duplicate locations nuget adds on a machine.
                        // TODO: check how nuget behaves on non-windows for .NET Core
                        //string loc = Path.Combine(locTokens[1], locTokens[2]);
                        string loc = locTokens[1];
                        cacheLocationPath.Add(loc);
                    }
                }
            }

            return cacheLocationPath;
        }
        #endregion

        #region Restore
        public NugetProcStatus RestoreProject(List<string> projectList)
        {
            string slnFilePath = string.Empty;

            foreach (string projPath in projectList)
            {
                slnFilePath = GetSlnFilePath(projPath);

                if (!string.IsNullOrEmpty(slnFilePath))
                {
                    break;
                }
            }

            string args = string.Format("restore {0}", slnFilePath);
            int exitcode = ExecuteCommand(args);

            return new NugetProcStatus()
            {
                ExitCode = exitcode,
                ProcInputArgs = args
            };
        }

        private string GetSlnFilePath(string projectPath)
        {
            //This is poor mans method to get sln. Assuming the solution for the provided is in the rootpath

            int depth = 3;
            int currentDepth = 1;
            string dirPath = Path.GetDirectoryName(projectPath);
            string slnFilePath = string.Empty;

            while(currentDepth <= depth)
            {
                if(Directory.Exists(dirPath))
                {
                    var slnFiles = Directory.EnumerateFiles(dirPath, "*.sln", SearchOption.TopDirectoryOnly);
                    if(slnFiles.Any<string>())
                    {
                        slnFilePath = slnFiles.FirstOrDefault<string>();
                        break;
                    }

                    dirPath = Directory.GetParent(dirPath).FullName;
                    currentDepth++;
                }
            }

            return slnFilePath;
        }

        #endregion

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

        public Exception CaughtException { get; set; }
    }


    public class NugetProcStatus
    {
        public int ExitCode { get; set; }
        public string ProcErrorOutput { get; set; }

        public string ProcInputArgs { get; set; }
    }
}
