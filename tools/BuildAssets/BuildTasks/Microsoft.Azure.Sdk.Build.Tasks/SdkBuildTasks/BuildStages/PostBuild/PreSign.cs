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

        public string[] FilesToSignWithFullPath { get; set; }

        public string SignedFilesRootDirPath { get; set; }

        /// <summary>
        /// Supported values are:
        /// nupkg, dll
        /// 
        /// </summary>
        public string FileType { get; set; }



        #region private internal fields
        List<string> FinalFileListToBeSigned { get; set; }
        #endregion


        public PreSignTask()
        {
            DebugTraceEnabled = DebugTrace;
            FinalFileListToBeSigned = new List<string>();
        }


        public override bool Execute()
        {
            if(SdkProjects.Any<ITaskItem>())
            {
                List<SdkProjectMetaData> filteredProjects = TaskData.GetSdkProjects(SdkProjects);
                
                foreach (SdkProjectMetaData sdkProj in filteredProjects)
                {
                    FinalFileListToBeSigned.Add(sdkProj.TargetOutputFullPath);
                }
            }

            if(FilesToSignWithFullPath != null)
            {
                if (FilesToSignWithFullPath.Any<string>())
                {
                    FinalFileListToBeSigned.AddRange(FilesToSignWithFullPath);
                }
            }




            return true;
        }


        private void CreateScanManifest()
        {
            string[] pathSplitToken = new string[] { "bin" };

            SignRequest signReq = new SignRequest();
            SignBatch signBatch = new SignBatch();
            //SignRequestFile signReqFile = new SignRequestFile();
            

            foreach(string fp in FinalFileListToBeSigned)
            {
                string[] fileSplitPaths = fp.Split(pathSplitToken, StringSplitOptions.RemoveEmptyEntries);

                SignRequestFile srf = new SignRequestFile();

                srf.Name = Path.GetFileName(fp);
                srf.SourceLocation = Path.GetDirectoryName(fp);
            }
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
}
