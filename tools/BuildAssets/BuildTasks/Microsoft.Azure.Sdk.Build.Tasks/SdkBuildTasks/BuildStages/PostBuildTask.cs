using Microsoft.Azure.Sdk.Build.Tasks.BaseTasks;
using Microsoft.Azure.Sdk.Build.Tasks.Models;
using Microsoft.Build.Evaluation;
using Microsoft.Build.Framework;
using Microsoft.Build.Utilities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Microsoft.Azure.Sdk.Build.Tasks.BuildStages
{
    public class PostBuildTask : NetSdkTask
    {

        const string API_TAG_PROPERTYNAME = "AzureApiTags";
        const string PROPS_FILE_NAME = "AzSdk.RP.props";
        protected override INetSdkTask TaskInstance { get => this; }

        public override string NetSdkTaskName => "PostBuildTask";

        #region Required Properties
        public bool EnableDebugTrace { get; set; }
        public ITaskItem[] SdkProjects { get; set; }

        //public ITaskItem SdkProject { get; set; }

        public string BuildScope { get; set; }

        public bool InvokePostBuildTask { get; set; }

        [Output]
        public string ApiTag { get; set; }

        [Output]
        public string ApiTagPropsFile { get; set; }
        #endregion

        public PostBuildTask()
        {
            DebugTrace = EnableDebugTrace;
        }

        
        public override bool Execute()
        {
            if (ValidateArgs())
            {
                List<SdkProjectMetaData> filteredProjects = TaskData.FilterCategorizedProjects(SdkProjects);
                TaskLogger.LogInfo(filteredProjects?.Count.ToString());

                foreach (SdkProjectMetaData proj in filteredProjects)
                {
                    ApiTag = GetApiMap(proj);
                    UpdateProject(ApiTag, proj);
                }
            }

            return true;
        }

        internal string GetApiMap(SdkProjectMetaData sdkProjList)
        {
            return GetApiMapUsingReflection(sdkProjList);
        }

        private string GetApiMapUsingReflection(SdkProjectMetaData sdkProjList)
        {
            string sdkAsmPath = sdkProjList.TargetOutputFullPath;
            string apiMapPropertyName = string.Empty;
            Assembly sdkAsm = Assembly.LoadFrom(sdkAsmPath);

            Type someType = sdkAsm.GetType("SdkInfo");
            StringBuilder sb = new StringBuilder();

            var sdkInfoProp = someType.GetProperties().Where<PropertyInfo>((p) => p.Name.StartsWith("SdkInfo_"));

            if (sdkInfoProp.Any())
            {
                apiMapPropertyName = sdkInfoProp.FirstOrDefault()?.Name;

                IEnumerable<Tuple<string, string, string>> apiMap = (IEnumerable<Tuple<string, string, string>>)someType.GetProperty(apiMapPropertyName).GetValue(null, null);
                string apiTagFormat = "{0}_{1}_{2};";

                foreach (Tuple<string, string, string> apiSet in apiMap)
                {
                    sb.Append(string.Format(apiTagFormat, apiSet.Item1, apiSet.Item2, apiSet.Item3));
                }
            }

            sdkAsm = null;

            return sb.ToString();
        }

        internal void UpdateProject(string apiTag, SdkProjectMetaData sdkProject)
        {
            string azApiPropertyName = API_TAG_PROPERTYNAME;
            string propsFile = GetApiTagsPropsPath(sdkProject);
            Project propsProject = new Project(propsFile);
            string existingApiTags = propsProject.GetPropertyValue(azApiPropertyName);
            ApiTagPropsFile = propsFile;
            if (!existingApiTags.Trim().Equals(apiTag.Trim(), StringComparison.OrdinalIgnoreCase))
            {   
                propsProject.SetProperty(azApiPropertyName, apiTag);
                propsProject.Save();                
            }
        }

        internal string GetApiTagsPropsPath(SdkProjectMetaData sdkProject)
        {
            string apiTagsPropsPath = string.Empty;
            string apiTagsFileName = PROPS_FILE_NAME;

            string projDir = Path.GetDirectoryName(sdkProject.FullProjectPath);
            int depthSearchIndex = 0;

            while (depthSearchIndex <= 3)
            {
                string propsFile = Path.Combine(projDir, apiTagsFileName);

                if (File.Exists(propsFile))
                {
                    apiTagsPropsPath = propsFile;
                    depthSearchIndex = 4;
                }
                else
                {
                    projDir = Path.GetDirectoryName(projDir);
                    depthSearchIndex++;
                }
            }

            return apiTagsPropsPath;
        }

        private bool ValidateArgs()
        {
            bool isValidated = false;

            //TaskLogger.LogInfo("EnableDebugTrace: {0}", EnableDebugTrace.ToString());
            //TaskLogger.LogInfo("BuildScope: {0}", BuildScope.ToString());
            //TaskLogger.LogInfo("InvokePostBuildTask: {0}", InvokePostBuildTask.ToString());
            //TaskLogger.LogInfo("ProjectBeingBuilt: {0}", SdkProject.ItemSpec.ToString());

            if (InvokePostBuildTask == false)
            {
                TaskLogger.LogInfo("InvokePostBuildTask: {0}", InvokePostBuildTask.ToString());
                isValidated = false;
            }
            //else if(!String.IsNullOrEmpty(SdkProject.ItemSpec))
            //{
            //    isValidated = true;
            //    TaskLogger.LogInfo(SdkProject.ItemSpec);
            //}
            else if (SdkProjects.Any<ITaskItem>())
            {
                isValidated = true;
                TaskLogger.LogInfo<ITaskItem>(SdkProjects, (proj) => proj.ItemSpec.ToString());
            }
            else
            {
                //TaskLogger.LogException(new Microsoft.Build.Exceptions.InvalidProjectFileException("Unable to detect projects being build"));
            }

            return isValidated;
        }
    }
}
