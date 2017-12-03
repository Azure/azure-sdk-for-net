namespace Microsoft.Azure.Sdk.Build.Tasks.BuildStages
{
    using System;
    using Microsoft.Build.Utilities;
    using Microsoft.Build.Framework;
    using Microsoft.Azure.Sdk.Build.Tasks.BaseTasks;
    using Microsoft.Azure.Sdk.Build.Tasks.Utilities;
    using Microsoft.Azure.Sdk.Build.Tasks.Models;
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
        protected override INetSdkTask TaskInstance { get => this; }

        public override string NetSdkTaskName => "PreBuildTask";

        public bool CreatePropsFile { get; set; }

        public ITaskItem[] SdkProjects { get; set; }

        [Output]
        public string ApiTagPropsFile { get; set; }
        #endregion
        
        public override bool Execute()
        {
            if(CreatePropsFile == true)
            {
                List<SdkProjectMetaData> filteredProjects = TaskData.FilterCategorizedProjects(SdkProjects);
                TaskLogger.LogInfo("Filtered project(s) count '{0}'", filteredProjects?.Count.ToString());

                if(filteredProjects.Count > 0 )
                {
                    if (GetApiTagsPropsPath(filteredProjects[0], out string propFilePath, out string slnDirPath))
                    {
                        if(string.IsNullOrEmpty(propFilePath))
                        {
                            propFilePath = Path.Combine(slnDirPath, BuildStageConstant.PROPS_FILE_NAME);
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

            return true;
        }

        private bool GetApiTagsPropsPath(SdkProjectMetaData sdkProject, out string propsFilePath, out string slnFilePath)
        {
            string apiTagsPropsPath = string.Empty;
            string sFile = string.Empty;
            string apiTagsFileName = BuildStageConstant.PROPS_FILE_NAME;

            string projDir = Path.GetDirectoryName(sdkProject.FullProjectPath);
            int depthSearchIndex = 0;

            while (depthSearchIndex <= 3)
            {
                string propsFile = Path.Combine(projDir, apiTagsFileName);
                var slnFiles = Directory.EnumerateFiles(projDir, "*.sln", SearchOption.TopDirectoryOnly);
                propsFilePath = string.Empty;
                slnFilePath = string.Empty;

                if (File.Exists(propsFile))
                {
                    apiTagsPropsPath = propsFile;
                    depthSearchIndex = 4;
                }
                else if(slnFiles.Any())
                {
                    sFile = projDir;
                    depthSearchIndex = 4;
                }
                else
                {
                    projDir = Path.GetDirectoryName(projDir);
                    depthSearchIndex++;
                }
            }

            propsFilePath = apiTagsPropsPath;
            slnFilePath = sFile;

            return true;
            //return ( !(!string.IsNullOrEmpty(propsFilePath)) || (!string.IsNullOrEmpty(slnFilePath)) );
        }
    }
}
