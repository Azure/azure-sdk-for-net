// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Microsoft.Build.Evaluation;
using Microsoft.Build.Framework;
using Microsoft.Build.Utilities;
using Microsoft.WindowsAzure.Build.Tasks.Utilities;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using ThreadingTsk = System.Threading.Tasks;

namespace Microsoft.WindowsAzure.Build.Tasks
{
    /// <summary>
    /// This task will enable getting projects that needs to be built.
    /// Currently this task makes the following assumption:
    /// 1) We have hard coded to search for only *.csproj files as the projects that needs to be built
    /// It has the capability and properties that will accommodate any number of project file extension (using ; separated list)
    /// 2) It has currently hard-coded to ignore KeyVault Sample projects (they do not need to be built anytime)
    /// 3) Due to a Msbuild capability of not able to provide outputs for multi-targeting projects, we need to separate out projects 
    /// that are only targeting one framework version.
    /// So in our entire build system, we assume that all our proejcts target only .NET 452 and .NET Standard 1.4
    /// Not sure if we want to accommodate random target frameworks (possibly not), but then there are always exceptions and we are not
    /// ready for those exceptions.
    /// Need to file an issue to investigate this and enable it.
    /// 
    /// </summary>
    public class SDKCategorizeProjects : Task
    {
        #region fields
        private string KV_IGNOREDIRNAME = "Microsoft.Azure.KeyVault.Samples";
        private string _ignoreDirNameForSearchingProjects;
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
        public string IgnoreDirNameForSearchingProjects
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

        /// <summary>
        /// List of project file extension.
        /// Currently only hard coded to .csproj files
        /// </summary>
        private string SearchProjectFileExt { get; set; }

        #region OUTPUT
        /// <summary>
        /// List of projects that needs to be built
        /// </summary>
        [Output]
        public ITaskItem[] net452SdkProjectsToBuild { get; private set; }

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
        /// 
        /// </summary>
        [Output]
        public ITaskItem[] netCore11TestProjectsToBuild { get; private set; }

        [Output]
        public ITaskItem[] net452TestProjectsToBuild { get; private set; }

        [Output]
        public ITaskItem[] unSupportedProjectsToBuild { get; private set; }
        

        /// <summary>
        /// List of .NET 452 test projects that will be separated from the list of projects that
        /// are multi-targeting
        /// </summary>
        [Output]
        public ITaskItem[] WellKnowTestSDKNet452Projects { get; private set; }
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
            List<string> sdkProjects = new List<string>();
            List<string> testProjects = new List<string>();
            List<string> allProjects = new List<string>();
            List<string> ignorePathList = new List<string>();

            string[] ignoreTokens = IgnoreDirNameForSearchingProjects.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            foreach (string igTkn in ignoreTokens)
            {
                ignorePathList.Add(igTkn);
            }

            if(!ignorePathList.Contains(KV_IGNOREDIRNAME))
            {
                ignorePathList.Add(KV_IGNOREDIRNAME);
            }
            ProjectSearchUtility ProjUtil = new ProjectSearchUtility(SourceRootDirPath, ignorePathList);
            if (BuildScope.Equals("All", StringComparison.OrdinalIgnoreCase))
            {
                sdkProjects = ProjUtil.GetAllSDKProjects();
                testProjects = ProjUtil.GetFilteredTestProjects();
            }
            else //We set default scope to All if empty/null, so safe to evaluate to Else in this case
            {
                sdkProjects = ProjUtil.GetScopedSDKProjects(BuildScope);
                testProjects = ProjUtil.GetScopedTestProjects(BuildScope);
            }

            allProjects.AddRange(sdkProjects);
            allProjects.AddRange(testProjects);

            ConcurrentBag<SdkProjectMetaData> projWithMetaData = new ConcurrentBag<SdkProjectMetaData>();

            var projTimeBefore = DateTime.Now;
            projWithMetaData = GetProjectData(allProjects, projWithMetaData);
            var projTimeAfter = DateTime.Now;

            Debug.WriteLine("Parsing Projects took {0}", (projTimeAfter - projTimeBefore).TotalSeconds.ToString());

            var net452SdkProjects = from s in projWithMetaData where (s.IsTargetFxSupported == true && s.FxMoniker == TargetFrameworkMoniker.net452 && s.ProjectType == SdkProjctType.Sdk) select s.ProjectTaskItem;
            var netStd14SdkProjects = from s in projWithMetaData where (s.IsTargetFxSupported == true && s.FxMoniker == TargetFrameworkMoniker.netstandard14 && s.ProjectType == SdkProjctType.Sdk) select s.ProjectTaskItem;
            var netCore11SdkProjects = from s in projWithMetaData where (s.IsTargetFxSupported == true && s.FxMoniker == TargetFrameworkMoniker.netcoreapp11 && s.ProjectType == SdkProjctType.Sdk) select s.ProjectTaskItem;
            var testNetCore11Projects = from s in projWithMetaData where (s.IsTargetFxSupported == true && s.FxMoniker == TargetFrameworkMoniker.netcoreapp11 && s.ProjectType == SdkProjctType.Test) select s.ProjectTaskItem;
            var testNet452Projects = from s in projWithMetaData where (s.IsTargetFxSupported == true && s.FxMoniker == TargetFrameworkMoniker.net452 && s.ProjectType == SdkProjctType.Test) select s.ProjectTaskItem;
            var unSupportedProjects = from s in projWithMetaData where (s.IsTargetFxSupported == false) select s.ProjectTaskItem;

            net452SdkProjectsToBuild = net452SdkProjects?.ToArray<ITaskItem>();
            netStd14SdkProjectsToBuild = netStd14SdkProjects?.ToArray<ITaskItem>();
            netCore11SdkProjectsToBuild = netCore11SdkProjects?.ToArray<ITaskItem>();
            netCore11TestProjectsToBuild = testNetCore11Projects?.ToArray<ITaskItem>();
            net452TestProjectsToBuild = testNet452Projects?.ToArray<ITaskItem>();
            unSupportedProjectsToBuild = unSupportedProjects?.ToArray<ITaskItem>();

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

            ThreadingTsk.Parallel.ForEach<ITaskItem>(projList, (proj) =>
            {
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
            });
            

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
                    SdkProjectMetaData sp = new SdkProjectMetaData(project: sdkProjMD.ProjectTaskItem, fxMoniker: tfxMoniker, fullProjectPath: sdkProjMD.ProjectTaskItem.ItemSpec, isTargetFxSupported: isFxSupported, projectType: pType);
                    supportedProjectBag.Add(sp);
                }
            }

            return supportedProjectBag;
        }


        internal ConcurrentBag<SdkProjectMetaData> GetMetaData(List<string> projectList, ConcurrentBag<SdkProjectMetaData> supportedProjectBag)
        {
            SdkProjctType pType = SdkProjctType.Sdk;
            var projList = from p in projectList select new TaskItem(p);
            IBuildEngine buildEng = this.BuildEngine;
            //Object obj = new object();

            //ThreadingTsk.Parallel.ForEach<ITaskItem>(projList, (proj) =>
            foreach (ITaskItem proj in projList)
            {
                //lock (obj)
                //{
                try
                {
                    Project loadedProj = new Project(proj.ItemSpec);

                    string targetFxList = loadedProj.GetPropertyValue("TargetFrameworks");
                    if (string.IsNullOrEmpty(targetFxList))
                    {
                        targetFxList = loadedProj.GetPropertyValue("TargetFramework");
                    }
                    ICollection<ProjectItem> pkgs = loadedProj.GetItemsIgnoringCondition("PackageReference");
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
                        SdkProjectMetaData sp = new SdkProjectMetaData(project: proj, fxMoniker: tfxMoniker, fullProjectPath: proj.ItemSpec, isTargetFxSupported: isFxSupported, projectType: pType);
                        supportedProjectBag.Add(sp);
                    }
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
                //}
                //loadedProj = null;
            }
            //);

            return supportedProjectBag;
        }
        
        private bool IsTargetFxSupported(string fxMoniker, out TargetFrameworkMoniker targetFx)
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
                    fxSupported = false;
                    break;
            }

            targetFx = validMoniker;
            return fxSupported;
        }
    }

    public class SdkProjectMetaData
    {
        public TargetFrameworkMoniker FxMoniker { get; set; }
        public string FullProjectPath { get; set; }
        public bool IsTargetFxSupported { get; set; }

        public SdkProjctType ProjectType { get; set; } 

        public ITaskItem ProjectTaskItem { get; set; }

        public SdkProjectMetaData() { }

        public Project MsBuildProject { get; set; }

        public SdkProjectMetaData(ITaskItem project, TargetFrameworkMoniker fxMoniker, string fullProjectPath, bool isTargetFxSupported, SdkProjctType projectType = SdkProjctType.Sdk)
        {
            ProjectTaskItem = project;
            FxMoniker = fxMoniker;
            FullProjectPath = fullProjectPath;
            IsTargetFxSupported = isTargetFxSupported;
            ProjectType = projectType;
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

    public enum SdkProjctType
    {
        Sdk,
        Test
    }
}
