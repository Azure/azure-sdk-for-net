// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Microsoft.Azure.Sdk.Build.Tasks.BaseTasks;
using Microsoft.Azure.Sdk.Build.Tasks.Models;
using Microsoft.Build.Construction;
using Microsoft.Build.Evaluation;
using Microsoft.Build.Framework;
using Microsoft.Build.Utilities;
using Microsoft.WindowsAzure.Build.Tasks.Utilities;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using ThreadingTsk = System.Threading.Tasks;

namespace Microsoft.WindowsAzure.Build.Tasks
{
    /// <summary>
    /// This task will enable getting projects that needs to be built.
    /// Currently this task makes the following assumption:
    /// 1) We have hard coded to search for only *.csproj files as the projects that needs to be built
    /// It has the capability and properties that will accomodate any number of project file extension (using ; separated list)
    /// 2) It has currently hard-coded to ignore KeyVault Sample projects (they do not need to be built anytime)
    /// 3) Due to a Msbuild capability of not able to provide outputs for multi-targeting projects, we need to separate out projects 
    /// that are only targeting one framework version.
    /// So in our entire build system, we assume that all our proejcts target only .NET 452 and .NET Standard 1.4
    /// Not sure if we want to accomodate random target frameworks (possibly not), but then there are always exceptions and we are not
    /// ready for those exceptions.
    /// Need to file an issue to investigate this and enable it.
    /// 
    /// </summary>
    public class SDKCategorizeProjects : Task
    {
        #region fields
        private string KV_IGNOREDIRNAME = "Microsoft.Azure.KeyVault.Samples";
        private string _ignoreDirNameForSearchingProjects;
        private string _searchProjectFileExt;
        #endregion

        public SDKCategorizeProjects()
        {
         
        }

        /// <summary>
        /// Source Root Dir Path to search projects
        /// </summary>
        [Required]
        public string SourceRootDirPath { get; set; }

        /// <summary>
        /// BuildScope
        /// </summary>
        [Required]
        public string BuildScope { get; set; }

        /// <summary>
        /// Directory name which needs to be ignore during searching of projects
        /// We ignore all directory paths that has the provided directory name
        /// for e.g. Microsoft.Azure.KeyVault.Samples, we will ignore any paths that has the given names
        /// </summary>
        public string IgnorePathTokens
        {
            get
            {
                if (string.IsNullOrEmpty(_ignoreDirNameForSearchingProjects))
                {
                    _ignoreDirNameForSearchingProjects = KV_IGNOREDIRNAME;
                }

                return _ignoreDirNameForSearchingProjects;
            }
            set
            {
                _ignoreDirNameForSearchingProjects = value;
            }
        }

        public string IncludePathTokens { get; set; }

        /// <summary>
        /// List of project file extension.
        /// </summary>
        public string SearchProjectFileExt
        {
            get
            {
                if(_searchProjectFileExt == null)
                {
                    _searchProjectFileExt = string.Empty;
                }

                return _searchProjectFileExt;
            }

            set
            {
                _searchProjectFileExt = value;
            }
        }

        #region OUTPUT
        /// <summary>
        /// List of projects that needs to be built
        /// </summary>
        [Output]
        public ITaskItem[] net452SdkProjectsToBuild { get; private set; }

        /// <summary>
        /// List of projects that needs to be built
        /// </summary>
        [Output]
        public ITaskItem[] net461SdkProjectsToBuild { get; private set; }

        /// <summary>
        /// List of Test Projects that needs to be build
        /// </summary>
        [Output]
        public ITaskItem[] netStd14SdkProjectsToBuild { get; private set; }

        /// <summary>
        /// List of Test Projects that needs to be build
        /// </summary>
        [Output]
        public ITaskItem[] netCore11SdkProjectsToBuild { get; private set; }

        /// <summary>
        /// List of .NET 452 projects that will be separated from the list of projects that 
        /// are multi targeting
        /// </summary>
        [Output]
        public ITaskItem[] netCore11TestProjectsToBuild { get; private set; }

        [Output]
        public ITaskItem[] net452TestProjectsToBuild { get; private set; }
        
        [Output]
        public ITaskItem[] net461TestProjectsToBuild { get; private set; }

        [Output]
        public ITaskItem[] unSupportedProjectsToBuild { get; private set; }

        [Output]
        public ITaskItem[] nonSdkProjectToBuild { get; private set; }

        [Output]
        public string ProjectRootDir { get; private set; }
        

        /// <summary>
        /// List of .NET 452 test projects that will be separated from the list of projects that
        /// are multi-targeting
        /// </summary>
        [Output]
        public ITaskItem[] WellKnowTestSDKNet452Projects { get; private set; }



        public string[] UnFilteredProjects { get; private set; }
        #endregion

        /// <summary>
        /// Executes the Categorization task
        /// The primary objective is to do the following:
        /// 1) Find supported/unsupported TargetFramework specified in the project file
        /// 2) Categorize if a project is a test project or not (currently we rely on references added to the project to decide if a project is Test or not)
        /// At the end of this task we get 6 outputs
        /// Each output array is a list of project categorized according to the TargetFramework the project is targeting.
        /// </summary>
        /// <returns></returns>
        public override bool Execute()
        {
            return Categorize();
        }

        private bool Categorize()
        {
            List<string> sdkProjects = new List<string>();
            List<string> testProjects = new List<string>();
            List<string> allProjects = new List<string>();
            List<string> ignorePathList = new List<string>();
            List<string> includePathList = new List<string>();

            // We try to guess if build tasks projects are being built, if yes we ignore tests being built
            if (BuildScope.Contains(@"BuildAssets\BuildTasks\Microsoft.Azure.Sdk.Build.Tasks"))
            {
                IgnorePathTokens = string.Join(" ", IgnorePathTokens, @"BuildAssets\BuildTasks\Microsoft.Azure.Sdk.Build.Tasks\Tests");
            }

            string[] ignoreTokens = IgnorePathTokens?.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            string[] includeTokens = IncludePathTokens?.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            if(ignoreTokens != null && ignoreTokens.Any<string>())
            {
                ignorePathList = ignoreTokens.ToList<string>();
            }
            
            if(includeTokens != null && includeTokens.Any<string>())
            {
                includePathList = includeTokens.ToList<string>();
            }
            

            if (!ignorePathList.Contains(KV_IGNOREDIRNAME))
            {
                ignorePathList.Add(KV_IGNOREDIRNAME);
            }

            string[] projExtList = SearchProjectFileExt?.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            ProjectSearchUtility ProjUtil = new ProjectSearchUtility(SourceRootDirPath, ignorePathList, includePathList);
            if (BuildScope.Equals("All", StringComparison.OrdinalIgnoreCase))
            {
                sdkProjects = ProjUtil.GetAllSDKProjects();
                testProjects = ProjUtil.GetFilteredTestProjects();
                ProjectRootDir = ProjUtil.RootDirForSearch;
            }
            else //We set default scope to All if empty/null, so safe to evaluate to Else in this case
            {
                sdkProjects = ProjUtil.GetScopedSDKProjects(BuildScope);
                testProjects = ProjUtil.GetScopedTestProjects(BuildScope);
                ProjectRootDir = ProjUtil.ProjectRootDir;
            }

            allProjects.AddRange(sdkProjects);
            allProjects.AddRange(testProjects);

            ConcurrentBag<SdkProjectMetaData> projWithMetaData = new ConcurrentBag<SdkProjectMetaData>();

            var projTimeBefore = DateTime.Now;
            projWithMetaData = GetProjectData(allProjects, projWithMetaData);
            var projTimeAfter = DateTime.Now;

            Debug.WriteLine("Parsing Projects took {0} seconds", (projTimeAfter - projTimeBefore).TotalSeconds.ToString());

            //This allows us to reuse the metadata later.
            TaskData.CategorizedProjects = projWithMetaData.ToList<SdkProjectMetaData>();

            var net452SdkProjects = from s in projWithMetaData where (s.IsTargetFxSupported == true && s.FxMoniker == TargetFrameworkMoniker.net452 && s.ProjectType == SdkProjctType.Sdk) select s.ProjectTaskItem;
            var net461SdkProjects = from s in projWithMetaData where (s.IsTargetFxSupported == true && s.FxMoniker == TargetFrameworkMoniker.net461 && s.ProjectType == SdkProjctType.Sdk) select s.ProjectTaskItem;
            var netStd14SdkProjects = from s in projWithMetaData where (s.IsTargetFxSupported == true && s.FxMoniker == TargetFrameworkMoniker.netstandard14 && s.ProjectType == SdkProjctType.Sdk) select s.ProjectTaskItem;
            var netCore11SdkProjects = from s in projWithMetaData where (s.IsTargetFxSupported == true && s.FxMoniker == TargetFrameworkMoniker.netcoreapp11 && s.ProjectType == SdkProjctType.Sdk) select s.ProjectTaskItem;
            var testNetCore11Projects = from s in projWithMetaData where (s.IsTargetFxSupported == true && s.FxMoniker == TargetFrameworkMoniker.netcoreapp11 && s.ProjectType == SdkProjctType.Test) select s.ProjectTaskItem;
            var testNet452Projects = from s in projWithMetaData where (s.IsTargetFxSupported == true && s.FxMoniker == TargetFrameworkMoniker.net452 && s.ProjectType == SdkProjctType.Test) select s.ProjectTaskItem;
            var testNet461Projects = from s in projWithMetaData where (s.IsTargetFxSupported == true && s.FxMoniker == TargetFrameworkMoniker.net461 && s.ProjectType == SdkProjctType.Test) select s.ProjectTaskItem;
            var unSupportedProjects = from s in projWithMetaData where (s.IsTargetFxSupported == false) select s.ProjectTaskItem;
            var nonSdkProjects = from s in projWithMetaData where (s.IsNonSdkProject == true) select s.ProjectTaskItem;

            net452SdkProjectsToBuild = net452SdkProjects?.ToArray<ITaskItem>();
            net461SdkProjectsToBuild = net461SdkProjects?.ToArray<ITaskItem>();
            netStd14SdkProjectsToBuild = netStd14SdkProjects?.ToArray<ITaskItem>();
            netCore11SdkProjectsToBuild = netCore11SdkProjects?.ToArray<ITaskItem>();
            netCore11TestProjectsToBuild = testNetCore11Projects?.ToArray<ITaskItem>();
            net452TestProjectsToBuild = testNet452Projects?.ToArray<ITaskItem>();
            net461TestProjectsToBuild = testNet461Projects?.ToArray<ITaskItem>();
            unSupportedProjectsToBuild = unSupportedProjects?.ToArray<ITaskItem>();
            UnFilteredProjects = allProjects.ToArray<string>();
            nonSdkProjectToBuild = nonSdkProjects?.ToArray<ITaskItem>();

            return true;
        }

        /// <summary>
        /// This function parses project file and gets meta data
        /// This is where we categorize if a project is a test project or not (second check based on the references added to the project)
        /// This is where we find if the project has any supported target framework.
        /// </summary>
        /// <param name="projectList">List of project file paths</param>
        /// <param name="supportedProjectBag">Collection where parsed data will be saved to get parsed project data</param>
        /// <returns></returns>
        internal ConcurrentBag<SdkProjectMetaData> GetProjectData(List<string> projectList, ConcurrentBag<SdkProjectMetaData> supportedProjectBag)
        {
            SdkProjctType pType = SdkProjctType.Sdk;
            var projList = from p in projectList select new TaskItem(p);
            IBuildEngine buildEng = this.BuildEngine;

            ConcurrentBag<SdkProjectMetaData> projCollection = new ConcurrentBag<SdkProjectMetaData>();

#if DebugInVS
            foreach (ITaskItem proj in projList)
            {
#else
            ThreadingTsk.Parallel.ForEach<ITaskItem>(projList, (proj) =>
            {
#endif
            try
            {
                    projCollection.Add(new SdkProjectMetaData() { MsBuildProject = new Project(proj.ItemSpec), ProjectTaskItem = proj });
                }
                catch (Exception ex)
                {
                    if (buildEng != null)
                    {
                        Log.LogWarningFromException(ex);
                    }
                    else
                    {
                        Debug.WriteLine(ex.Message);
                    }
                }
#if !DebugInVS
            });
#else
            }
#endif

                foreach(SdkProjectMetaData sdkProjMD in projCollection)
            {
                string targetFxList = sdkProjMD.MsBuildProject.GetPropertyValue("TargetFrameworks");
                if (string.IsNullOrEmpty(targetFxList))
                {
                    targetFxList = sdkProjMD.MsBuildProject.GetPropertyValue("TargetFramework");
                }

                ICollection<ProjectItem> pkgs = sdkProjMD.MsBuildProject.GetItemsIgnoringCondition("PackageReference");
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

                var fxNames = targetFxList?.Split(new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries)?.ToList<string>();
                foreach (string fx in fxNames)
                {
                    bool isFxSupported = IsTargetFxSupported(fx, out TargetFrameworkMoniker tfxMoniker);
                    string fullOutputPath = string.Empty;
                    bool isProjDataPlane = false;
                    bool isNonSdkProjectKind = false;
                    if (!tfxMoniker.Equals(TargetFrameworkMoniker.UnSupported))
                    {
                        fullOutputPath = GetTargetFullPath(sdkProjMD, fx);
                    }

                    if (sdkProjMD.ProjectTaskItem.ItemSpec.ToLower().Contains("dataplane"))
                    {
                        isProjDataPlane = true;
                    }

                    if (sdkProjMD.ProjectTaskItem.ItemSpec.ToLower().Contains(@"\tools\buildassets"))
                    {
                        isNonSdkProjectKind = true;
                    }

                    SdkProjectMetaData sp = new SdkProjectMetaData(project: sdkProjMD.ProjectTaskItem,
                        msbuildProject: sdkProjMD.MsBuildProject,
                        fxMoniker: tfxMoniker,
                        fxMonikerString: fx,
                        fullProjectPath: sdkProjMD.ProjectTaskItem.ItemSpec,
                        targetOutputPath: fullOutputPath,
                        isTargetFxSupported: isFxSupported,
                        projectType: pType, isProjectDataPlaneProject: isProjDataPlane,
                        isNonSdkProject: isNonSdkProjectKind);

                    sp.ProjectImports = GetProjectImports(sdkProjMD);

                    supportedProjectBag.Add(sp);
                }
            }

            return supportedProjectBag;
        }

        private List<string> GetProjectImports(SdkProjectMetaData sdkProjMD)
        {
            string rpProps = Constants.BuildStageConstant.PROPS_APITAG_FILE_NAME;
            string multiApiProps = Constants.BuildStageConstant.PROPS_MULTIAPITAG_FILE_NAME;
            //$([MSBuild]::GetPathOfFileAbove('AzSdk.RP.props'))
            List<string> importList = new List<string>();
            ProjectRootElement rootElm = sdkProjMD.MsBuildProject.Xml;
            ICollection<ProjectImportElement> importElms = rootElm.Imports;

            foreach(ProjectImportElement imp in importElms)
            {
                if(imp.Project.Contains(rpProps))
                {
                    importList.Add(rpProps);
                }

                if(imp.Project.Contains(multiApiProps))
                {
                    importList.Add(multiApiProps);
                }
            }

            return importList;
        }

        private string GetTargetFullPath(SdkProjectMetaData sdkProj, string targetFxMoniker)
        {
            string projOutputPath = sdkProj.MsBuildProject.GetPropertyValue("OutputPath");
            string outputType = sdkProj.MsBuildProject.GetPropertyValue("OutputType");
            string asmName = sdkProj.MsBuildProject.GetPropertyValue("AssemblyName");
            string projDirPath = Path.GetDirectoryName(sdkProj.ProjectTaskItem.ItemSpec);
            string fullTargetPath = string.Empty;

            if (outputType.Equals("Library", StringComparison.OrdinalIgnoreCase))
            {
                fullTargetPath = Path.Combine(projDirPath, projOutputPath, targetFxMoniker, String.Concat(asmName, ".dll"));
            }

            return fullTargetPath;
        }
        
        private bool IsTargetFxSupported(string fxMoniker, out TargetFrameworkMoniker targetFx)
        {
            string lcMoniker = fxMoniker.ToLower();
            bool fxSupported = false;
            TargetFrameworkMoniker validMoniker = TargetFrameworkMoniker.UnSupported;
            switch (lcMoniker)
            {
                case "netstandard1.4":
                    validMoniker = TargetFrameworkMoniker.netstandard14;
                    fxSupported = true;
                    break;

                case "netstandard1.6":
                    validMoniker = TargetFrameworkMoniker.netstandard14;
                    fxSupported = false;
                    break;

                case "net452":
                    validMoniker = TargetFrameworkMoniker.net452;
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

                case "netcoreapp1.1":
                    validMoniker = TargetFrameworkMoniker.netcoreapp11;
                    fxSupported = true;
                    break;

                case "netcoreapp2.0":
                    validMoniker = TargetFrameworkMoniker.net461;
                    fxSupported = false;
                    break;
            }

            targetFx = validMoniker;
            return fxSupported;
        }
    }
}