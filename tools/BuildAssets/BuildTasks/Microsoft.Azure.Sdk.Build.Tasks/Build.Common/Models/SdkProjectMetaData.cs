// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Microsoft.Azure.Sdk.Build.Common.Tasks.Models
{
    using Microsoft.Build.Construction;
    using Microsoft.Build.Evaluation;
    using Microsoft.Build.Framework;
    using Microsoft.Azure.Sdk.Build.Common.Utilities;
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;

    public class SdkProjectMetaData
    {
        public TargetFrameworkMoniker FxMoniker { get; set; }

        public string FxMonikerString { get; set; }
        public string FullProjectPath { get; set; }

        public string TargetOutputFullPath { get; set; }

        public bool IsTargetFxSupported { get; set; }

        public SdkProjctType ProjectType { get; set; }

        public ITaskItem ProjectTaskItem { get; set; }

        public SdkProjectMetaData() { }

        public Project MsBuildProject { get; set; }

        public bool IsProjectDataPlane { get; set; }

        public bool IsFxFullDesktopVersion { get; set; }

        public bool IsFxNetCore { get; set; }

        public bool IsNonSdkProject { get; set; }

        public List<string> ProjectImports { get; set; }

        public SdkProjectMetaData(ITaskItem project, Project msbuildProject, TargetFrameworkMoniker fxMoniker, string fxMonikerString, string fullProjectPath, string targetOutputPath, bool isTargetFxSupported, SdkProjctType projectType = SdkProjctType.Sdk)
        {
            ProjectTaskItem = project;
            FxMoniker = fxMoniker;
            FullProjectPath = fullProjectPath;
            IsTargetFxSupported = isTargetFxSupported;
            ProjectType = projectType;
            TargetOutputFullPath = targetOutputPath;
            FxMonikerString = fxMonikerString;
            MsBuildProject = msbuildProject;
        }

        public SdkProjectMetaData(ITaskItem project, 
                                    Project msbuildProject, TargetFrameworkMoniker fxMoniker, string fxMonikerString, 
                                    string fullProjectPath, string targetOutputPath, bool isTargetFxSupported, 
                                    SdkProjctType projectType,
                                    bool isProjectDataPlaneProject,
                                    bool isNonSdkProject = true)
        {
            ProjectTaskItem = project;
            FxMoniker = fxMoniker;
            FullProjectPath = fullProjectPath;
            IsTargetFxSupported = isTargetFxSupported;
            ProjectType = projectType;
            TargetOutputFullPath = targetOutputPath;
            FxMonikerString = fxMonikerString;
            MsBuildProject = msbuildProject;
            IsProjectDataPlane = isProjectDataPlaneProject;
            IsFxFullDesktopVersion = IsExpectedFxCategory(fxMoniker, TargetFxCategory.FullDesktop);
            IsFxNetCore = IsExpectedFxCategory(fxMoniker, TargetFxCategory.NetCore);
            IsNonSdkProject = isNonSdkProject;
        }

        public SdkProjectMetaData(string fullProjectPath, TargetFrameworkMoniker priorityFxVersion = TargetFrameworkMoniker.net452)
        {
            if(!string.IsNullOrEmpty(fullProjectPath))
            {
                try
                {
                    if (ProjectCollection.GlobalProjectCollection.GetLoadedProjects(fullProjectPath).Count != 0)
                    {
                        MsBuildProject = ProjectCollection.GlobalProjectCollection.GetLoadedProjects(fullProjectPath).FirstOrDefault<Project>();
                    }
                    else
                    {
                        MsBuildProject = new Project(fullProjectPath);
                    }
                }
                catch(Exception ex)
                {

                }

                if(MsBuildProject != null)
                {
                    FxMoniker = GetTargetFramework(MsBuildProject, priorityFxVersion);
                    FxMonikerString = GetFxMonikerString(priorityFxVersion);
                    ProjectTaskItem = new Microsoft.Build.Utilities.TaskItem(fullProjectPath);
                    FullProjectPath = fullProjectPath;
                    TargetOutputFullPath = GetTargetFullPath(MsBuildProject, FxMonikerString);                    
                    ProjectType = GetProjectType(MsBuildProject);
                    IsTargetFxSupported = IsFxSupported(FxMonikerString);
                    IsProjectDataPlane = IsDataPlaneProject(MsBuildProject);
                    IsFxFullDesktopVersion = IsExpectedFxCategory(FxMoniker, TargetFxCategory.FullDesktop);
                    IsFxNetCore = IsExpectedFxCategory(FxMoniker, TargetFxCategory.NetCore);
                    ProjectImports = GetProjectImports(MsBuildProject);
                }
            }
        }
        
        private List<string> GetProjectImports(Project msbuildProj)
        {
            string rpProps = Constants.BuildStageConstant.PROPS_APITAG_FILE_NAME;
            string multiApiProps = Constants.BuildStageConstant.PROPS_MULTIAPITAG_FILE_NAME;
            //$([MSBuild]::GetPathOfFileAbove('AzSdk.RP.props'))
            List<string> importList = new List<string>();
            ProjectRootElement rootElm = msbuildProj.Xml;
            ICollection<ProjectImportElement> importElms = rootElm.Imports;

            foreach (ProjectImportElement imp in importElms)
            {
                if (imp.Project.Contains(rpProps))
                {
                    importList.Add(rpProps);
                }

                if (imp.Project.Contains(multiApiProps))
                {
                    importList.Add(multiApiProps);
                }
            }

            return importList;
        }

        private TargetFrameworkMoniker GetTargetFramework(Project msBuildProj, TargetFrameworkMoniker priorityFxVersion)
        {
            TargetFrameworkMoniker moniker = TargetFrameworkMoniker.UnSupported;
            string targetFxList = msBuildProj.GetPropertyValue("TargetFrameworks");
            if (string.IsNullOrEmpty(targetFxList))
            {
                targetFxList = msBuildProj.GetPropertyValue("TargetFramework");
            }

            var fxNames = targetFxList?.Split(new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries)?.ToList<string>();
            foreach (string fx in fxNames)
            {
                moniker = GetFxMoniker(fx);
                if(moniker.Equals(priorityFxVersion))
                {
                    break;
                }
            }

            return moniker;
        }

        private bool IsDataPlaneProject(Project msBuildProject)
        {
            bool isDataPlane = false;
            if(msBuildProject.FullPath.ToLower().Contains("dataplane"))
            {
                isDataPlane = true;
                string packageId = msBuildProject.GetPropertyValue("PackageId");
                if (packageId.ToLower().Contains("management"))
                {
                    isDataPlane = false;
                }
            }

            return isDataPlane;
        }

        private string GetTargetFullPath(Project sdkProj, string targetFxMoniker)
        {
            string projOutputPath = sdkProj.GetPropertyValue("OutputPath");
            string outputType = sdkProj.GetPropertyValue("OutputType");
            string asmName = sdkProj.GetPropertyValue("AssemblyName");
            string projDirPath = Path.GetDirectoryName(sdkProj.FullPath);
            string fullTargetPath = string.Empty;

            if (outputType.Equals("Library", StringComparison.OrdinalIgnoreCase))
            {
                fullTargetPath = Path.Combine(projDirPath, projOutputPath, targetFxMoniker, String.Concat(asmName, ".dll"));
            }

            return fullTargetPath;
        }
        
        public string GetFxMonikerString(TargetFrameworkMoniker fxMoniker)
        {
            string monikerString = string.Empty;
            switch (fxMoniker)
            {
                case TargetFrameworkMoniker.net452:
                    monikerString = "net452";
                    break;

                case TargetFrameworkMoniker.netcoreapp11:
                    monikerString = "netcoreapp1.1";
                    break;

                case TargetFrameworkMoniker.netstandard14:
                    monikerString = "netstandard1.4";
                    break;

                case TargetFrameworkMoniker.net46:
                    monikerString = "net46";
                    break;

                case TargetFrameworkMoniker.net461:
                    monikerString = "net461";
                    break;
            }

            return monikerString;
        }

        public bool IsExpectedFxCategory(TargetFrameworkMoniker targetFxMoniker, TargetFxCategory expectedFxCategory)
        {
            bool expectedFxCat = false;
            switch (targetFxMoniker)
            {
                case TargetFrameworkMoniker.net452:
                case TargetFrameworkMoniker.net46:
                case TargetFrameworkMoniker.net461:
                    expectedFxCat = (expectedFxCategory == TargetFxCategory.FullDesktop);
                    break;

                case TargetFrameworkMoniker.netcoreapp11:
                case TargetFrameworkMoniker.netstandard14:
                    expectedFxCat = (expectedFxCategory == TargetFxCategory.NetCore);
                    break;
            }

            return expectedFxCat;
        }

        public SdkProjctType GetProjectType(Project msbuildProj)
        {
            SdkProjctType pType = SdkProjctType.Sdk;
            ICollection<ProjectItem> pkgs = msbuildProj.GetItemsIgnoringCondition("PackageReference");
            if (pkgs.Any<ProjectItem>())
            {
                var testReference = pkgs.Where<ProjectItem>((p) => p.EvaluatedInclude.Equals("xunit", StringComparison.OrdinalIgnoreCase));
                if (testReference.Any<ProjectItem>())
                {
                    pType = SdkProjctType.Test;
                }
                else
                {
                    pType = SdkProjctType.Sdk;
                }
            }

            return pType;
        }

        private bool IsFxSupported(string fxMoniker)
        {
            string lcMoniker = fxMoniker.ToLower();
            bool fxSupported = false;
            TargetFrameworkMoniker validMoniker = TargetFrameworkMoniker.UnSupported;
            switch (lcMoniker)
            {
                case "net452":
                    validMoniker = TargetFrameworkMoniker.net452;
                    fxSupported = true;
                    break;

                case "netcoreapp1.1":
                    validMoniker = TargetFrameworkMoniker.netcoreapp11;
                    fxSupported = true;
                    break;

                case "netstandard1.4":
                    validMoniker = TargetFrameworkMoniker.netstandard14;
                    fxSupported = true;
                    break;

                case "net46":
                    validMoniker = TargetFrameworkMoniker.net46;
                    fxSupported = false;
                    break;

                case "net461":
                    validMoniker = TargetFrameworkMoniker.net461;
                    fxSupported = true;
                    break;
                default:
                    validMoniker = TargetFrameworkMoniker.UnSupported;
                    fxSupported = false;
                    break;
            }

            //targetFx = validMoniker;
            return fxSupported;
        }

        private TargetFrameworkMoniker GetFxMoniker(string fx)
        {
            string lcMoniker = fx.ToLower();
            TargetFrameworkMoniker validMoniker = TargetFrameworkMoniker.UnSupported;
            switch (lcMoniker)
            {
                case "net452":
                    validMoniker = TargetFrameworkMoniker.net452;
                    break;

                case "netcoreapp1.1":
                    validMoniker = TargetFrameworkMoniker.netcoreapp11;
                    break;

                case "netstandard1.4":
                    validMoniker = TargetFrameworkMoniker.netstandard14;
                    break;

                case "net46":
                    validMoniker = TargetFrameworkMoniker.net46;
                    break;

                case "net461":
                    validMoniker = TargetFrameworkMoniker.net461;
                    break;
                default:
                    validMoniker = TargetFrameworkMoniker.UnSupported;
                    break;
            }

            return validMoniker;
        }

    }

    public enum TargetFrameworkMoniker
    {
        net45,
        net452,
        net46,
        net461,
        netcoreapp11,
        netstandard14,
        UnSupported
    }

    public enum TargetFxCategory
    {
        FullDesktop,
        NetCore
    }

    public enum SdkProjctType
    {
        Sdk,
        Test
    }
}
