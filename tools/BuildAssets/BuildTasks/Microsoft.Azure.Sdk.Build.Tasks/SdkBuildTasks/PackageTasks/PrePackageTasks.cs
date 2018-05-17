// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Microsoft.Azure.Sdk.Build.Tasks.PackageTasks
{
    using Microsoft.Azure.Sdk.Build.Tasks.BaseTasks;
    using Microsoft.Build.Framework;

    /// <summary>
    /// The idea is to execute series of tasks that are required to be executed tasks prior to Packaging the nuget package
    /// The individual tasks will be invoked from this tasks, but yet have them independent to be executed on it's own.
    /// 
    /// </summary>
    public class PrePackageTasks : NetSdkTask
    {
        #region Required Properties

        public ITaskItem[] SdkProjectInfo { get; set; }



        protected override INetSdkTask TaskInstance { get => this; }
        #endregion

        public PrePackageTasks()
        {

        }

        public override bool Execute()
        {
            Execute_AddTagInfoToPackage();

            return true;
        }


        internal void Execute_AddTagInfoToPackage()
        {
            AddTagInfoTask addTagsTask = new AddTagInfoTask();
            addTagsTask.SdkProjectInfo = SdkProjectInfo;
            addTagsTask.BuildEngine = this.BuildEngine;
            addTagsTask.BuildScope = this.BuildScope;
            addTagsTask.DebugTraceEnabled = this.DebugTraceEnabled;
            //addTagsTask.SdkMetaProjects = SdkMetaProjects;
            
            addTagsTask.Execute();
        }
    }
}
