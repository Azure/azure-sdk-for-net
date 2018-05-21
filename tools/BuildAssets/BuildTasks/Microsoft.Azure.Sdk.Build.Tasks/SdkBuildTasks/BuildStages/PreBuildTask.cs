// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Microsoft.Azure.Sdk.Build.Tasks.BuildStages
{
    using Microsoft.Azure.Sdk.Build.Tasks.BaseTasks;
    using Microsoft.Azure.Sdk.Build.Tasks.Models;
    using Microsoft.Azure.Sdk.Build.Tasks.Utilities;
    using Microsoft.Build.Framework;
    using Microsoft.WindowsAzure.Build.Tasks.Utilities;
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using static Microsoft.WindowsAzure.Build.Tasks.Utilities.Constants;

    /// <summary>
    /// 
    /// </summary>
    public class PreBuildTask : NetSdkTask
    {

        #region Required Properties
        public bool EnableDebugTrace { get; set; }
        protected override INetSdkTask TaskInstance { get => this; }

        public override string NetSdkTaskName => "PreBuildTask";

        public bool CreatePropsFile { get; set; }

        public ITaskItem[] SdkProjects { get; set; }

        public bool IdeBuild { get; set; }

        [Output]
        public string ApiTagPropsFile { get; set; }
        #endregion

        public PreBuildTask()
        {
            DebugTraceEnabled = EnableDebugTrace;
        }
        public override bool Execute()
        {
            TaskLogger.LogDebugInfo("Executing PreBuildTask");
            if (CreatePropsFile == true)
            {
                List<SdkProjectMetaData> filteredProjects = TaskData.FilterCategorizedProjects(SdkProjects);

                SdkProjectMetaData metaProject = null;

                if (filteredProjects.Count <= 0)
                {
                    foreach (ITaskItem item in SdkProjects)
                    {
                        metaProject = new SdkProjectMetaData(item.ItemSpec);
                        if (metaProject != null) break;
                    }
                }
                else if (filteredProjects.Count > 0)
                {
                    TaskLogger.LogDebugInfo("Filtered project(s) count '{0}'", filteredProjects?.Count.ToString());
                    metaProject = filteredProjects.First<SdkProjectMetaData>();
                }

                if (metaProject.IsNonSdkProject == false)
                {
                    if (metaProject.ProjectType != SdkProjctType.Test)
                    {
                        TaskLogger.LogDebugInfo("Filtered project(s) is '{0}'", metaProject.FullProjectPath);

                        foreach (string importFileName in metaProject.ProjectImports)
                        {
                            if (GetApiTagsPropsPath(metaProject, importFileName, out string propFilePath, out string slnDirPath))
                            {
                                if (string.IsNullOrEmpty(propFilePath))
                                {
                                    propFilePath = Path.Combine(slnDirPath, importFileName);
                                    MsBuildProjectFile msBuildFile = new MsBuildProjectFile(propFilePath);
                                    ApiTagPropsFile = msBuildFile.CreateXmlDocWithProps();
                                }
                                else
                                {
                                    ApiTagPropsFile = propFilePath;
                                }
                                //ToDo: Schema verification
                            }
                        }
                    }
                }
            }

            return true;
        }

        private bool ValidateArgs()
        {
            bool isValid = false;
            bool isProjDataPlane = SdkProjects.Select<ITaskItem, string>((item) => item.ItemSpec).Contains<string>("dataPlane", new ObjectComparer<string>((l, r) => l.Equals(r, StringComparison.OrdinalIgnoreCase)));
            
            isValid = !isProjDataPlane;
            return isValid;
        }


        private string GetSlnFilePath(SdkProjectMetaData sdkProject)
        {
            string iteratingDirPath = Path.GetDirectoryName(sdkProject.FullProjectPath);
            string slnFilePath = string.Empty;
            int depthSearchIndex = 0;

            while (depthSearchIndex <= 7)
            {
                var slnFiles = Directory.EnumerateFiles(iteratingDirPath, "*.sln", SearchOption.TopDirectoryOnly);

                if (slnFiles.Any())
                {
                    slnFilePath = slnFiles.First<string>();
                }
                else
                {
                    iteratingDirPath = Path.GetDirectoryName(iteratingDirPath);
                    depthSearchIndex++;
                }
            }

            return slnFilePath;
        }


        private string GetApiTagsPropsPath(SdkProjectMetaData sdkProject, string apiTagsFileName)
        {
            string slnFilePath = GetSlnFilePath(sdkProject);
            string propsFilePath = string.Empty;

            if(File.Exists(slnFilePath))
            {
                propsFilePath = Path.Combine(Path.GetDirectoryName(slnFilePath), apiTagsFileName);

                if(!File.Exists(propsFilePath))
                {
                    propsFilePath = string.Empty;
                }
            }

            return propsFilePath;
        }

        private bool GetApiTagsPropsPath(SdkProjectMetaData sdkProject, string apiTagsFileName, out string propsFilePath, out string slnFileDirPath)
        {
            string apiTagsPropsPath = string.Empty;
            string slnDir = string.Empty;
            //string apiTagsFileName = BuildStageConstant.PROPS_FILE_NAME;

            string projDir = Path.GetDirectoryName(sdkProject.FullProjectPath);
            int depthSearchIndex = 0;

            while (depthSearchIndex <= 7)
            {
                string propsFile = Path.Combine(projDir, apiTagsFileName);
                var slnFiles = Directory.EnumerateFiles(projDir, "*.sln", SearchOption.TopDirectoryOnly);
                propsFilePath = string.Empty;
                slnFileDirPath = string.Empty;

                if (File.Exists(propsFile))
                {
                    apiTagsPropsPath = propsFile;
                    //depthSearchIndex = 4;
                    break;
                }
                else if(slnFiles.Any())
                {
                    slnDir = projDir;
                    //depthSearchIndex = 4;
                    break;
                }
                else
                {
                    projDir = Path.GetDirectoryName(projDir);
                    depthSearchIndex++;
                }
            }

            propsFilePath = apiTagsPropsPath;
            slnFileDirPath = slnDir;

            return true;
            //return ( !(!string.IsNullOrEmpty(propsFilePath)) || (!string.IsNullOrEmpty(slnFilePath)) );
        }
    }
}
