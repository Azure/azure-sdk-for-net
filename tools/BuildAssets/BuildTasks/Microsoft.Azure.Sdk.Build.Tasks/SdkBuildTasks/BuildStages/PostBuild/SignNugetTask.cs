// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Microsoft.Azure.Sdk.Build.Tasks.BuildStages.PostBuild
{
    using Microsoft.Azure.Sdk.Build.ExecProcess;
    using Microsoft.Azure.Sdk.Build.Tasks.BaseTasks;
    using Microsoft.Azure.Sdk.Build.Tasks.Models.Esrp.Sign;
    using Microsoft.Azure.Sdk.Build.Tasks.Utilities;
    using Microsoft.Build.Framework;
    using Microsoft.WindowsAzure.Build.Tasks.Utilities;
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;

    public class SignNugetTask : NetSdkTask
    {

        protected override INetSdkTask TaskInstance { get => this; }

        public override string NetSdkTaskName => "PreSignTask";

        public bool DebugTrace { get; set; }

        #region Input
        [Required]
        public string InNugetPackageRootDir { get; set; }
        /// <summary>
        /// Space delimited extension list including . char
        /// e.g. .nupkg .dll
        /// </summary>
        [Required]
        public string InSearchExtensionToSearch { get; set; }

        /// <summary>
        /// Root directory path where files will be searched for
        /// provided space separated extension list <see cref="InSearchExtensionToSearch"/>
        /// </summary>
        [Required]
        public string InSignedFilesRootDirPath { get; set; }

        /// <summary>
        /// List of full file path that needs to be signed
        /// </summary>
        //public string[] InFilesToSignWithFullPath { get; set; }

        /// <summary>
        /// Root directory for creating manifest files needed for signing service
        /// </summary>
        [Required]
        public string InSignManifestDirPath { get; set; }

        [Required]
        public string InSignBuildName { get; set; }

        [Required]
        public string CiToolsRootDir { get; set; }

        /// <summary>
        /// Possible values
        /// 1) nuget
        /// more types will be added
        /// </summary>
        [Required]
        public string InSigningOperation { get; set; }

#endregion

        #region output
        [Output]
        public string[] OutSignManifestFiles { get; set; }
        #endregion


        #region private internal fields
        List<string> SignFileListFromProjects { get; set; }

        List<string> SignFileListFromFullPath { get; set; }

        List<string> SignFileListFromRootDir { get; set; }

        #endregion

        public SignNugetTask()
        {
            DebugTraceEnabled = DebugTrace;

            SignFileListFromProjects = new List<string>();
            SignFileListFromFullPath = new List<string>();
            SignFileListFromRootDir = new List<string>();
        }

        public override bool Execute()
        {
            List<string> manifestList = GenerateManifestFiles();
            SignClientExec signClient = new SignClientExec();
            signClient.CiToolsRootDir = CiToolsRootDir;
            signClient.SigningInputManifestFilePath = manifestList.First<string>();

            Check.FileExists(signClient.SigningInputManifestFilePath);

            string sf = signClient.SigningInputManifestFilePath;
            string signOutputFilePath = Path.Combine(Path.GetDirectoryName(sf), String.Concat(Path.GetFileNameWithoutExtension(sf), "_output", ".json"));
            signClient.SigningResultOutputFilePath = signOutputFilePath;

            int exitCode = signClient.ExecuteCommand();
            string signTaskOutput = signClient.AnalyzeExitCode();

            this.TaskLogger.LogDebugInfo(signTaskOutput);

            return true;
        }

        #region Create Manifest
        private void InitFileList()
        {

            #region from root directory and searching providing file extensions
            // Build file list from provided root directory and file extension
            // this will include search for list of files with expected file extensions in the root directory

            if (string.IsNullOrEmpty(InSignedFilesRootDirPath))
            {
                this.TaskLogger.LogDebugInfo("'SignedFilesRootDirPath' Provided directory path is empty");
            }
            else
            {
                if (!Directory.Exists(InSignedFilesRootDirPath))
                {
                    this.TaskLogger.LogDebugInfo("Provided directory root '{0}' does not exists, files from the provided will be skipped", InSignedFilesRootDirPath);
                }
                else
                {
                    char[] extSplitToken = new char[] { ' ' };
                    string[] fileExt = InSearchExtensionToSearch.Split(extSplitToken, StringSplitOptions.RemoveEmptyEntries);

                    List<string> searchedFiles = new List<string>();
                    foreach (string extToSearch in fileExt)
                    {
                        string searchPattern = string.Concat("*", extToSearch);
                        var enumFiles = Directory.EnumerateFiles(InSignedFilesRootDirPath, searchPattern, SearchOption.AllDirectories);
                        if (enumFiles.Any<string>())
                        {
                            searchedFiles.AddRange(enumFiles.ToList<string>());
                        }
                    }

                    if (searchedFiles != null)
                    {
                        if (searchedFiles.Any<string>())
                        {
                            SignFileListFromRootDir.AddRange(searchedFiles);
                        }
                    }
                }
            }

            #endregion
        }

        private List<string> GenerateManifestFiles()
        {
            InitFileList();

            List<string> manifestFileList = new List<string>();

            if (SignFileListFromRootDir.Count > 0)
            {
                SignRequest projSignReq = CreateSignRequestModel(SignFileListFromRootDir, InSignedFilesRootDirPath);
                if (projSignReq != null)
                {
                    manifestFileList.Add(projSignReq.ToJsonFile(Path.Combine(InSignManifestDirPath, Constants.SigningConstants.SigningsRootDirFilesManifestFileName)));
                }
            }

            return manifestFileList;
        }
        

        private SignRequest CreateSignRequestModel(List<string> fileList, string rootDirSplitToken)
        {
            if (Directory.Exists(rootDirSplitToken))
            {
                DirectoryInfo dInfo = new DirectoryInfo(rootDirSplitToken);

                // We do this in order to get trailing directory separator character
                rootDirSplitToken = Path.Combine(dInfo.Name, " ").Trim();
            }

            //TODO: guard against empty rootDirSplitToken
            string[] pathSplitToken = new string[] { rootDirSplitToken };

            Dictionary<string, SignBatch> signBatchDictionary = new Dictionary<string, SignBatch>();
            SignRequest signReq = null;

            foreach (string signFilePath in fileList)
            {
                string[] fileSplitPaths = signFilePath.Split(pathSplitToken, StringSplitOptions.RemoveEmptyEntries);

                if (fileSplitPaths != null)
                {
                    if (fileSplitPaths.Length >= 2)
                    {
                        fileSplitPaths[0] = Path.Combine(fileSplitPaths[0], rootDirSplitToken);
                        if (!signBatchDictionary.ContainsKey(fileSplitPaths[0]))
                        {
                            SignBatch signBatch = new SignBatch();
                            signBatch.SourceRootDirectory = fileSplitPaths[0];
                            signBatch.DestinationRootDirectory = fileSplitPaths[0];

                            SignRequestFile srf = new SignRequestFile();
                            srf.Name = Path.GetFileName(signFilePath);
                            srf.SourceLocation = fileSplitPaths[1];
                            srf.DestinationLocation = fileSplitPaths[1];

                            signBatch.SignRequestFiles.Add(srf);
                            signBatchDictionary.Add(fileSplitPaths[0], signBatch);

                            //TODO: Identify signingInfo from provided files, do not depend supplied property (InSigningOperation)
                            signBatch.SigningInfo = CreateSigningInfo(InSigningOperation);
                        }
                        else
                        {
                            if (signBatchDictionary.TryGetValue(fileSplitPaths[0], out SignBatch sb))
                            {
                                SignRequestFile srf = new SignRequestFile();
                                srf.Name = Path.GetFileName(signFilePath);
                                srf.SourceLocation = fileSplitPaths[1];
                                srf.DestinationLocation = fileSplitPaths[1];
                                sb.SignRequestFiles.Add(srf);

                                signBatchDictionary[fileSplitPaths[0]] = sb;
                            }
                        }
                    }
                }
            }

            foreach (KeyValuePair<string, SignBatch> sbKeyVal in signBatchDictionary)
            {
                if (signReq == null)
                {
                    signReq = new SignRequest(InSignBuildName);
                    signReq.SignBatches.Add(sbKeyVal.Value);
                }
                else
                {
                    signReq.SignBatches.Add(sbKeyVal.Value);
                }
            }

            return signReq;
        }


        private SigningInfo CreateSigningInfo(string signingOperationType)
        {
            SigningInfo signInfo = new SigningInfo();
            if (signingOperationType != null)
            {
                if (signingOperationType.Equals("nuget", StringComparison.OrdinalIgnoreCase))
                {
                    Operation signOp = new Operation();
                    signOp.KeyCode = "CP-401405";
                    signOp.OperationCode = "NuGetSign";
                    signOp.ToolName = "sign";
                    signOp.ToolVersion = "1.0";
                    signOp.Parameters = new Parameters();

                    Operation signVerifyOp = new Operation();
                    signVerifyOp.KeyCode = "CP-401405";
                    signVerifyOp.OperationCode = "NuGetVerify";
                    signVerifyOp.ToolName = "sign";
                    signVerifyOp.ToolVersion = "1.0";
                    signVerifyOp.Parameters = new Parameters();

                    signInfo.Operations.Add(signOp);
                    signInfo.Operations.Add(signVerifyOp);
                }
            }

            return signInfo;
        }
        #endregion

    }
}
