// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Microsoft.Azure.Sdk.Build.Tasks.BaseTasks;
using Microsoft.Azure.Sdk.Build.Tasks.Models;
using Microsoft.Build.Evaluation;
using Microsoft.Build.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Microsoft.Azure.Sdk.Build.Tasks.PackageTasks
{
    public class AddTagInfoTask: NetSdkTask
    {
        public ITaskItem[] SdkProjectInfo { get; set; }
        protected override INetSdkTask TaskInstance { get => this; }

        public AddTagInfoTask()
        {
            
        }

        public override bool Execute()
        {
            List<SdkProjectMetaData> filteredProjects = TaskData.FilterCategorizedProjects(SdkProjectInfo);
            TaskLogger.LogInfo(filteredProjects.Count.ToString());

            foreach(SdkProjectMetaData proj in filteredProjects)
            {
                string ApiTag = GetApiMap(proj);
                UpdateProject(ApiTag, proj);
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

            Type someType = sdkAsm.GetType("ComputeSdkInfo");
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
            Project proj = sdkProject.MsBuildProject;
            string existingApiTags = sdkProject.MsBuildProject.GetPropertyValue("ApiTags");
            sdkProject.MsBuildProject.SetProperty("ApiTags", apiTag);
            sdkProject.MsBuildProject.Save();
        }
    }
}
