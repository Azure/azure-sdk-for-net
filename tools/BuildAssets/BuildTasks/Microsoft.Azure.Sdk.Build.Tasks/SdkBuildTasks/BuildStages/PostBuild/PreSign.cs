// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Microsoft.Azure.Sdk.Build.Tasks.BuildStages.PostBuild
{
    using Microsoft.Azure.Sdk.Build.Tasks.BaseTasks;
    using Microsoft.Azure.Sdk.Build.Tasks.Models;
    using Microsoft.Azure.Sdk.Build.Tasks.Models.Esrp.Sign;
    using Microsoft.Build.Framework;
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class PreSignTask : NetSdkTask
    {
        protected override INetSdkTask TaskInstance { get => this; }

        public override string NetSdkTaskName => "PreSignTask";

        public bool DebugTrace { get; set; }

        public ITaskItem[] SdkProjects { get; set; }
        
        /// <summary>
        /// space delimited extension include . char
        /// e.g. .nupkg .dll
        /// </summary>
        public string FileToSignSearchExtension { get; set; }

        public string[] FilesToSignWithFullPath { get; set; }

        public string SignedFilesRootDirPath { get; set; }


        #region private internal fields
        List<string> FinalFileListToBeSigned { get; set; }

        List<string> SignFilesFromProjects { get; set; }

        List<string> SignFileFromFullPath { get; set; }

        List<string> SignFileFromRootDir { get; set; }

        #endregion


        public PreSignTask()
        {
            DebugTraceEnabled = DebugTrace;
            FinalFileListToBeSigned = new List<string>();

            SignFilesFromProjects = new List<string>();
            SignFileFromFullPath = new List<string>();
            SignFileFromRootDir = new List<string>();
        }


        public override bool Execute()
        {
            InitFileList();
            return true;
        }


        private void InitFileList()
        {
            #region From Projects
            // Build File list from projects that got built
            if (SdkProjects.Any<ITaskItem>())
            {
                List<SdkProjectMetaData> filteredProjects = TaskData.GetSdkProjects(SdkProjects);

                foreach (SdkProjectMetaData sdkProj in filteredProjects)
                {
                    SignFilesFromProjects.Add(sdkProj.TargetOutputFullPath);
                }
            }
            #endregion

            #region FullPath File list
            // Build file list from provided file list

            if (FilesToSignWithFullPath != null)
            {
                if (FilesToSignWithFullPath.Any<string>())
                {
                    SignFileFromFullPath.AddRange(FilesToSignWithFullPath);
                }
            }
            #endregion

            #region from root directory and searching providing file extensions
            // Build file list from provided root directory and file extension
            // this will include search for list of files with expected file extensions in the root directory

            if(string.IsNullOrEmpty(SignedFilesRootDirPath))
            {
                this.TaskLogger.LogDebugInfo("'SignedFilesRootDirPath' Provided directory path is empty");
            }
            else
            {
                if(!Directory.Exists(SignedFilesRootDirPath))
                {
                    this.TaskLogger.LogDebugInfo("Provided directory root '{0}' does not exists, files from the provided will be skipped", SignedFilesRootDirPath);
                }
                else
                {
                    char[] extSplitToken = new char[] { ' ' };
                    string[] fileExt = FileToSignSearchExtension.Split(extSplitToken, StringSplitOptions.RemoveEmptyEntries);

                    IEnumerable<string> files = null;
                    foreach (string extToSearch in fileExt)
                    {
                        files.Concat(Directory.EnumerateFiles(SignedFilesRootDirPath, extToSearch));
                    }
                }
            }

            #endregion

        }


        private void CreateNugetSignManifest()
        {
            SignRequest nugetSignReq = CreateSignRequestModel("binaries");
        }


        private SignRequest CreateSignRequestModel(string rootDirSplitToken)
        {
            string[] pathSplitToken = new string[] { rootDirSplitToken };

            Dictionary<string, SignBatch> signBatchDictionary = new Dictionary<string, SignBatch>();
            SignRequest signReq = null;

            foreach (string signFilePath in FinalFileListToBeSigned)
            {
                string[] fileSplitPaths = signFilePath.Split(pathSplitToken, StringSplitOptions.RemoveEmptyEntries);

                if (fileSplitPaths != null)
                {
                    if (fileSplitPaths.Length >= 2)
                    {
                        if (!signBatchDictionary.ContainsKey(fileSplitPaths[0]))
                        {
                            SignBatch signBatch = new SignBatch();
                            signBatch.SourceRootDirectory = fileSplitPaths[0];
                            signBatch.DestinationRootDirectory = fileSplitPaths[0];
                            SigningInfo sInfo = new SigningInfo();

                            SignRequestFile srf = new SignRequestFile();
                            srf.Name = Path.GetFileName(signFilePath);
                            srf.SourceLocation = fileSplitPaths[1];
                            srf.DestinationLocation = fileSplitPaths[1];

                            signBatch.SignRequestFiles.Add(srf);
                            signBatchDictionary.Add(fileSplitPaths[0], signBatch);
                        }
                        else
                        {
                            if (signBatchDictionary.TryGetValue(fileSplitPaths[0], out SignBatch sb))
                            {
                                sb.SignRequestFiles[0].SourceLocation = fileSplitPaths[1];
                                sb.SignRequestFiles[0].DestinationLocation = fileSplitPaths[1];
                                sb.SignRequestFiles[0].Name = Path.GetFileName(signFilePath);

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
                    signReq = new SignRequest();
                }
                else
                {
                    signReq.SignBatches.Add(sbKeyVal.Value);
                }
            }

            return signReq;
        }


        private void CreateDllSignManifest()
        {
            //string[] pathSplitToken = new string[] { "bin" };
            //Dictionary<string, SignBatch> signBatchDictionary = new Dictionary<string, SignBatch>();
            //SignRequest signReq = null;

            //foreach(string signFilePath in FinalFileListToBeSigned)
            //{
            //    string[] fileSplitPaths = signFilePath.Split(pathSplitToken, StringSplitOptions.RemoveEmptyEntries);

            //    if(fileSplitPaths != null)
            //    {
            //        if (fileSplitPaths.Length >= 2)
            //        {
            //            if(!signBatchDictionary.ContainsKey(fileSplitPaths[0]))
            //            {
            //                SignBatch signBatch = new SignBatch();
            //                signBatch.SourceRootDirectory = fileSplitPaths[0];
            //                signBatch.DestinationRootDirectory = fileSplitPaths[0];
            //                SigningInfo sInfo = new SigningInfo();
                            
            //                SignRequestFile srf = new SignRequestFile();
            //                srf.Name = Path.GetFileName(signFilePath);
            //                srf.SourceLocation = fileSplitPaths[1];
            //                srf.DestinationLocation = fileSplitPaths[1];

            //                signBatch.SignRequestFiles.Add(srf);
            //                signBatchDictionary.Add(fileSplitPaths[0], signBatch);
            //            }
            //            else
            //            {
            //                if(signBatchDictionary.TryGetValue(fileSplitPaths[0], out SignBatch sb))
            //                {
            //                    sb.SignRequestFiles[0].SourceLocation = fileSplitPaths[1];
            //                    sb.SignRequestFiles[0].DestinationLocation = fileSplitPaths[1];
            //                    sb.SignRequestFiles[0].Name = Path.GetFileName(signFilePath);

            //                    signBatchDictionary[fileSplitPaths[0]] = sb;
            //                }
            //            }
            //        }
            //    }
            //}

            //foreach(KeyValuePair<string, SignBatch> sbKeyVal in signBatchDictionary)
            //{
            //    if(signReq == null)
            //    {
            //        signReq = new SignRequest();
            //    }
            //    else
            //    {
            //        signReq.SignBatches.Add(sbKeyVal.Value);
            //    }
            //}
        }

        /*
        {Microsoft.Azure.Sdk.Build.Tasks.Models.SdkProjectMetaData}
    FullProjectPath: "D:\\myFork\\netSdkBuild\\src\\SDKs\\Compute\\Management.Compute\\Microsoft.Azure.Management.Compute.csproj"
    FxMoniker: net452
    FxMonikerString: "net452"
    IsFxFullDesktopVersion: true
    IsFxNetCore: false
    IsNonSdkProject: false
    IsProjectDataPlane: false
    IsTargetFxSupported: true
    MsBuildProject: "D:\\myFork\\netSdkBuild\\src\\SDKs\\Compute\\Management.Compute\\Microsoft.Azure.Management.Compute.csproj" 
    EffectiveToolsVersion="15.0" #GlobalProperties=0 #Properties=288 #ItemTypes=4 #ItemDefinitions=0 #Items=64 #Targets=45
    ProjectImports: Count = 1
    ProjectTaskItem: {Microsoft.Build.Utilities.TaskItem}
    ProjectType: Sdk
    TargetOutputFullPath: "D:\\myFork\\netSdkBuild\\src\\SDKs\\Compute\\Management.Compute\\bin\\Debug\\net452\\Microsoft.Azure.Management.Compute.dll"
        */

    }



    internal class SignInternalRequest
    {

    }

}
