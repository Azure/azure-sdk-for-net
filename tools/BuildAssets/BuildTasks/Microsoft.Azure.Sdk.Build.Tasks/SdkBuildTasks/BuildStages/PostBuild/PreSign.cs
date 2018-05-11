// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Microsoft.Azure.Sdk.Build.Tasks.BuildStages.PostBuild
{
    using Microsoft.Azure.Sdk.Build.Tasks.BaseTasks;
    using Microsoft.Azure.Sdk.Build.Tasks.Models;
    using Microsoft.Build.Framework;
    using System;
    using System.Collections.Generic;
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
                List<SdkProjectMetaData> filteredProjects = TaskData.FilterCategorizedProjects(SdkProjects);
                
                foreach (SdkProjectMetaData sdkProj in filteredProjects)
                {
                    FinalFileListToBeSigned.Add(sdkProj.TargetOutputFullPath);
                }
            }

            if (FilesToSignWithFullPath.Any<string>())
            {
                FinalFileListToBeSigned.AddRange(FilesToSignWithFullPath);
            }





            return true;
        }
    }
}
