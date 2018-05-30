namespace Microsoft.Azure.Sdk.Build.Tasks.BuildStages.PostBuild
{
    /*
        using Microsoft.Azure.Sdk.Build.Tasks.BaseTasks;
    using Microsoft.Azure.Sdk.Build.Tasks.Models;
    using Microsoft.Build.Framework;
    using Microsoft.WindowsAzure.Build.Tasks.Utilities;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using System.Text;
    using System.Threading.Tasks;
    
    public class GetApiTag : NetSdkTask
    {
        #region Properties/Inputs
        protected override INetSdkTask TaskInstance => this;

        public override string NetSdkTaskName => "GetApiTag";

        public ITaskItem[] SdkProjects { get; set; }
        #endregion

        #region OUTPUT
        [Output]
        public string ApiTag { get; set; }
        #endregion

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
            IEnumerable<Tuple<string, string, string>> apiMap = GetApiMapUsingReflection(sdkProjList);
            Dictionary<string, string> normalizedMap = NormalizeTuple(apiMap);
            return GetTagValue(normalizedMap);
        }

        private IEnumerable<Tuple<string, string, string>> GetApiMapUsingReflection(SdkProjectMetaData sdkProjList)
        {
            string TYPENAMETOSEACH = "SdkInfo";
            string PROPERTYNAMEPREFIX = "ApiInfo_";

            string sdkAsmPath = sdkProjList.TargetOutputFullPath;
            string apiMapPropertyName = string.Empty;
            IEnumerable<Tuple<string, string, string>> combinedApiMap = new List<Tuple<string, string, string>>();

            Assembly sdkAsm = Assembly.LoadFrom(sdkAsmPath);

            Type someType = sdkAsm.GetType(TYPENAMETOSEACH, true, true);
            //StringBuilder sb = new StringBuilder();

            var props = someType.GetProperties(BindingFlags.Static | BindingFlags.NonPublic);
            var sdkInfoProp = props.Where<PropertyInfo>((p) => p.Name.StartsWith(PROPERTYNAMEPREFIX));

            if (sdkInfoProp.Any())
            {
                foreach (PropertyInfo pInfo in sdkInfoProp)
                {
                    IEnumerable<Tuple<string, string, string>> apiMap = (IEnumerable<Tuple<string, string, string>>)pInfo.GetValue(null, null);

                    if (apiMap.Any())
                    {
                        combinedApiMap.Union(apiMap);
                    }

                    //string apiTagFormat = "{0}_{1}_{2};";
                    //foreach (Tuple<string, string, string> apiSet in apiMap)
                    //{
                    //    sb.Append(string.Format(apiTagFormat, apiSet.Item1, apiSet.Item2, apiSet.Item3));
                    //}
                }
            }

            sdkAsm = null;
            return combinedApiMap;
        }

        private Dictionary<string, string> NormalizeTuple(IEnumerable<Tuple<string, string, string>> apiMap)
        {
            Dictionary<string, string> na = new Dictionary<string, string>(new ObjectComparer<string>((l, r) => l.Equals(r, StringComparison.OrdinalIgnoreCase)));
            Dictionary<string, string> normalized = new Dictionary<string, string>(new ObjectComparer<string>((l, r) => l.Equals(r, StringComparison.OrdinalIgnoreCase)));

            foreach (var api in apiMap)
            {
                string nsApi = string.Concat(api.Item1, api.Item3);
                if (!na.ContainsKey(nsApi))
                {
                    na.Add(nsApi, nsApi);
                    normalized.Add(api.Item1, api.Item3);
                }
            }

            return normalized;
        }

        private string GetTagValue(Dictionary<string, string> apiMap)
        {
            StringBuilder sb = new StringBuilder();
            string apiTagFormat = "{0}_{1};";
            foreach (KeyValuePair<String, string> kvp in apiMap)
            {
                sb.Append(string.Format(apiTagFormat, kvp.Key, kvp.Value));
            }

            return sb.ToString();
        }

        private void UpdateProject(string apiTag, SdkProjectMetaData sdkProject)
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

        private string GetApiTagsPropsPath(SdkProjectMetaData sdkProject)
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

    public class UpdateApiTag : NetSdkTask
    {
        #region Properties/Inputs
        protected override INetSdkTask TaskInstance => this;

        public override string NetSdkTaskName => "UpdateApiTag";
        
        public bool CreatePropsFile { get; set; }
        #endregion

        #region OUTPUT
        [Output]
        public string ApiTagPropsFile { get; set; }

        #endregion


    }
    */
}
