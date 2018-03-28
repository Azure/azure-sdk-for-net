using Microsoft.Azure.Sdk.Build.Tasks.BaseTasks;
using Microsoft.Azure.Sdk.Build.Tasks.Models;
using Microsoft.Build.Evaluation;
using Microsoft.Build.Framework;
using Microsoft.Build.Utilities;
using Microsoft.WindowsAzure.Build.Tasks.Utilities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using Microsoft.Azure.Sdk.Build.Tasks.BuildStages;
using static Microsoft.WindowsAzure.Build.Tasks.Utilities.Constants;

namespace Microsoft.Azure.Sdk.Build.Tasks.BuildStages
{
    public class PostBuildTask : NetSdkTask
    {
        protected override INetSdkTask TaskInstance { get => this; }

        public override string NetSdkTaskName => "PostBuildTask";

        #region Required Properties
        public bool EnableDebugTrace { get; set; }
        public ITaskItem[] SdkProjects { get; set; }

        public bool IdeBuild { get; set; }

        public string ProjectTargetFramework { get; set; }

        #region Properties for test purpose
        /// <summary>
        /// This property is test purpose only
        /// </summary>
        public string AssemblyFullPath { get; set; }

        /// <summary>
        /// This property is test purpose only
        /// </summary>
        public string FQTypeName { get; set; }

        #endregion

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
            TaskLogger.LogDebugInfo("Executing PostBuildTask");
            if (!string.IsNullOrEmpty(AssemblyFullPath))
            {
                ApiTag = GetApiMap(AssemblyFullPath);
            }
            else
            {
                GetApiMapFromProject();
            }

            return true;
        }

        private void GetApiMapFromProject()
        {
            if (ValidateArgs())
            {
                SdkProjectMetaData proj = GetProject(SdkProjects);

                //List<SdkProjectMetaData> filteredProjects = TaskData.FilterCategorizedProjects(SdkProjects);
                //TaskLogger.LogInfo("Filtered project(s) count '{0}'", filteredProjects?.Count.ToString());

                //foreach (SdkProjectMetaData proj in filteredProjects)
                //{
                if (proj.IsProjectDataPlane == false)
                {
                    if (proj.ProjectType != SdkProjctType.Test)
                    {
                        ApiTag = GetApiMap(proj.TargetOutputFullPath);
                        if (!string.IsNullOrEmpty(ApiTag))
                        {
                            ApiTagPropsFile = UpdateProject(ApiTag, proj);
                            VerifyPropsFile(ApiTag, proj);
                        }
                        else
                        {
                            TaskLogger.LogDebugInfo("SdkInfo Not Found in '{0}'", proj.FullProjectPath);
                        }
                    }
                }
            }
        }

        private void VerifyPropsFile(string apiTag, SdkProjectMetaData sdkProject)
        {
            if(!string.IsNullOrEmpty(apiTag))
            {
                string propsFile = GetApiTagsPropsPath(sdkProject);
                if(!File.ReadAllText(propsFile).Contains(apiTag))
                {
                    TaskLogger.LogException(new Exception(string.Format("Could not find tags "+apiTag+" in the props file "+propsFile)));
                }
            }
        }

        private SdkProjectMetaData GetProject(ITaskItem[] sdkProjects)
        {
            SdkProjectMetaData metaProject = null;
            List<SdkProjectMetaData> filteredProjects = TaskData.FilterCategorizedProjects(SdkProjects);
            if(filteredProjects.Count <= 0)
            {
                foreach(ITaskItem item in sdkProjects)
                {
                    metaProject = new SdkProjectMetaData(item.ItemSpec);
                    if (metaProject != null) break;
                }
            }
            else if(filteredProjects.Count > 0)
            {
                metaProject = filteredProjects.First<SdkProjectMetaData>();
            }

            return metaProject;
        }

        internal string GetApiMap(string assemblyPath)
        {
            string apiTag = string.Empty;
            IEnumerable<Tuple<string, string, string>> apiMap = GetApiMapUsingReflection(assemblyPath);
            if (apiMap.Any())
            {
                IEnumerable<Tuple<string, string>> normalizedMap = NormalizeTuple(apiMap);
                apiTag = GetApiTag(normalizedMap);
            }

            return apiTag;
        }

        private IEnumerable<Tuple<string, string, string>> GetApiMapUsingReflection(string assemblyFullPath)
        {   
            string sdkAsmPath = assemblyFullPath;
            string apiMapPropertyName = string.Empty;
            List<Tuple<string, string, string>> combinedApiMap = new List<Tuple<string, string, string>>();

            try
            {
                TaskLogger.LogDebugInfo("Trying to load assembly: '{0}'", sdkAsmPath);
                Assembly sdkAsm = Assembly.LoadFrom(sdkAsmPath);
                Type sdkInfoType = null;
                if(string.IsNullOrEmpty(FQTypeName))
                {
                    sdkInfoType = sdkAsm.GetType(BuildStageConstant.TYPENAMETOSEACH, true, true);
                }
                else
                {
                    sdkInfoType = sdkAsm.GetType(FQTypeName, true, true);
                }

                var props = sdkInfoType.GetProperties(BindingFlags.Static | BindingFlags.NonPublic | BindingFlags.Public);
                var sdkInfoProp = props.Where<PropertyInfo>((p) => p.Name.StartsWith(BuildStageConstant.PROPERTYNAMEPREFIX, StringComparison.OrdinalIgnoreCase));

                if (sdkInfoProp.Any())
                {
                    foreach (PropertyInfo pInfo in sdkInfoProp)
                    {
                        IEnumerable<Tuple<string, string, string>> apiMap = (IEnumerable<Tuple<string, string, string>>)pInfo.GetValue(null, null);

                        if (apiMap.Any())
                        {
                            combinedApiMap.AddRange(apiMap);
                        }
                    }
                }
                sdkAsm = null;
            }
            catch(Exception ex)
            {
                TaskLogger.LogDebugInfo(ex.Message);
            }

            return combinedApiMap;
        }

        private IEnumerable<Tuple<string, string>> NormalizeTuple(IEnumerable<Tuple<string, string, string>> apiMap)
        {
            //TODO: get rid of second dictionary (optimize)
            Dictionary<string, string> na = new Dictionary<string, string>(new ObjectComparer<string>((l, r) => l.Equals(r, StringComparison.OrdinalIgnoreCase)));
            List<Tuple<string, string>> normalized = new List<Tuple<string, string>>();

            foreach (var api in apiMap)
            {
                string nsApi = string.Concat(api.Item1, api.Item3);
                if (!na.ContainsKey(nsApi))
                {
                    na.Add(nsApi, nsApi);
                    normalized.Add(new Tuple<string, string>(api.Item1, api.Item3));
                }
            }

            TaskLogger.LogDebugInfo(apiMap);
            TaskLogger.LogDebugInfo(normalized);

            return normalized;
        }
        
        private string GetApiTag(Dictionary<string, string> apiMap)
        {
            StringBuilder sb = new StringBuilder();
            string apiTagFormat = "{0}_{1};";
            foreach(KeyValuePair<String, string> kvp in apiMap)
            {
                sb.Append(string.Format(apiTagFormat, kvp.Key, kvp.Value));
            }

            return sb.ToString();
        }

        private string GetApiTag(IEnumerable<Tuple<string, string>> apiMap)
        {
            StringBuilder sb = new StringBuilder();
            string apiTagFormat = "{0}_{1};";
            foreach (Tuple<string, string> kvp in apiMap)
            {
                sb.Append(string.Format(apiTagFormat, kvp.Item1, kvp.Item2));
            }

            return sb.ToString();
        }


        private string UpdateProject(string apiTag, SdkProjectMetaData sdkProject)
        {
            string azApiPropertyName = BuildStageConstant.API_TAG_PROPERTYNAME;
            string propsFile = GetApiTagsPropsPath(sdkProject);
            Project propsProject;

            if (!string.IsNullOrEmpty(propsFile))
            {
                if (ProjectCollection.GlobalProjectCollection.GetLoadedProjects(propsFile).Count != 0)
                {
                    propsProject = ProjectCollection.GlobalProjectCollection.GetLoadedProjects(propsFile).FirstOrDefault<Project>();
                }
                else
                {
                    propsProject = new Project(propsFile);
                }


                string existingApiTags = propsProject.GetPropertyValue(azApiPropertyName);
                if (!existingApiTags.Trim().Equals(apiTag.Trim(), StringComparison.OrdinalIgnoreCase))
                {
                    propsProject.SetProperty(azApiPropertyName, apiTag);
                    propsProject.Save();
                }
            }
            return propsFile;
        }

        private string GetApiTagsPropsPath(SdkProjectMetaData sdkProject)
        {
            string apiTagsPropsPath = string.Empty;
            string apiTagsFileName = BuildStageConstant.PROPS_FILE_NAME;

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
            if (SdkProjects.Any<ITaskItem>())
            {
                isValidated = true;
                TaskLogger.LogDebugInfo<ITaskItem>(SdkProjects, (proj) => proj.ItemSpec.ToString());
            }
            else
            {
                TaskLogger.LogException(new Microsoft.Build.Exceptions.InvalidProjectFileException("Unable to detect projects being build"));
            }

            return isValidated;
        }
    }
}
