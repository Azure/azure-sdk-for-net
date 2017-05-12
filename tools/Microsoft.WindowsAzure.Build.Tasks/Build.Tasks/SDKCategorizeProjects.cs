using System;
using Microsoft.Build.Utilities;
using Microsoft.Build.Framework;
using System.IO;
using System.Linq;
using System.Collections.Generic;
//using Microsoft.Build.BuildEngine;
using Microsoft.Build.Evaluation;
using Microsoft.Build.Execution;
using Microsoft.WindowsAzure.Build.Tasks.Utilities;
using System.Collections.Concurrent;
using System.Diagnostics;
using ThreadingTsk = System.Threading.Tasks;
//using System.Threading.Tasks;

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
        private string _defaultFileExt = "*.csproj";
        private string _defaultBuildScope = "All";
        private string[] _defaultTestProjTokens;
        private string KV_IGNOREDIRNAME = "Microsoft.Azure.KeyVault.Samples";

        private string _ignoreDirNameForSearchingProjects;

        List<string> wkProj45Paths;
        List<string> wkTest45Projects;

        private List<string> _searchedAllProjects;
        private List<string> _finalDirListForSearchingProjects;
        private List<string> _overAllIgnoreProjects;

        ConcurrentBag<ITaskItem> net452Projs = new ConcurrentBag<ITaskItem>();
        ConcurrentBag<ITaskItem> netStd14Projs = new ConcurrentBag<ITaskItem>();
        ConcurrentBag<ITaskItem> testNetCore11Projs = new ConcurrentBag<ITaskItem>();
        ConcurrentBag<ITaskItem> testNet452Projs = new ConcurrentBag<ITaskItem>();
        ConcurrentBag<ITaskItem> unSupportedProjs = new ConcurrentBag<ITaskItem>();
        #endregion

        public SDKCategorizeProjects()
        {
            _searchedAllProjects = new List<string>();
            _finalDirListForSearchingProjects = new List<string>();
            _overAllIgnoreProjects = new List<string>();

            _defaultTestProjTokens = new string[] { "*tests.csproj", "*test.csproj", "*KeyVault.TestFramework.csproj" };
            wkProj45Paths = new List<string>() { "*Etw.csproj", "*Log4net.csproj", "*Azure.TestFramework.csproj", "*Test.HttpRecorder.csproj" };
            wkTest45Projects = new List<string>() { "*Net45Tests.csproj", "*Tracing.Tests.csproj" };
        }

        #region Task properties

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

        /// <summary>
        /// List of projects that needs to be built
        /// </summary>
        [Output]
        public ITaskItem[] net452SdkProjectsToBuild { get; private set; }
        //public ITaskItem[] SDKProjectsToBuild { get; private set; }

        /// <summary>
        /// List of Test Projects that needs to be build
        /// </summary>
        [Output]
        public ITaskItem[] netStd14SdkProjectsToBuild { get; private set; }
        //public ITaskItem[] SDKTestProjectsToBuild { get; private set; }

        /// <summary>
        /// List of .NET 452 projects that will be separated from the list of projects that 
        /// are multi targeting
        /// 
        /// </summary>
        [Output]
        public ITaskItem[] netCore11TestProjectsToBuild { get; private set; }
        //public ITaskItem[] WellKnowSDKNet452Projects { get; private set; }

        [Output]
        public ITaskItem[] net452TestProjectsToBuild { get; private set; }
        //public ITaskItem[] UnSupportedTargetFxProjects { get; private set; }

        [Output]
        public ITaskItem[] unSupportedProjectsToBuild { get; private set; }

        //[Output]
        //public ITaskItem[] Foo { get; private set; }

        /// <summary>
        /// List of .NET 452 test projects that will be separated from the list of projects that
        /// are multi-targeting
        /// </summary>
        [Output]
        public ITaskItem[] WellKnowTestSDKNet452Projects { get; private set; }
        #endregion

        public override bool Execute()
        {
            List<string> sdkProjects = new List<string>();
            List<string> testProjects = new List<string>();
            List<ITaskItem> sdkTaskItems = new List<ITaskItem>();
            List<ITaskItem> testTaskItems = new List<ITaskItem>();
            List<ITaskItem> unsupportedTargetFxTaskItems = new List<ITaskItem>();

            Init();

            if (BuildScope.Equals("All", StringComparison.OrdinalIgnoreCase))
            {
                sdkProjects = SearchOnlySdkProjects(SourceRootDirPath);
                testProjects = SearchOnlyTestProjects(SourceRootDirPath);
            }
            else //We set default scope to All if empty/null, so safe to evaluate to Else in this case
            {
                sdkProjects = ScopedSdkProjects(SourceRootDirPath, BuildScope);
                testProjects = ScopedTestProjects(SourceRootDirPath, BuildScope);
            }

            ConcurrentBag<SdkProjectMetaData> projWithMetaData = new ConcurrentBag<SdkProjectMetaData>();

            var sdkProjTimeBefore = DateTime.Now;
            projWithMetaData = GetMetaData(sdkProjects, projWithMetaData);
            var sdkProjTimeAfter = DateTime.Now;

            var testProjTimeBefore = DateTime.Now;
            projWithMetaData = GetMetaData(testProjects, projWithMetaData);
            var testProjTimeAfter = DateTime.Now;

            Debug.WriteLine("Parsing Sdk Projects took {0}", (sdkProjTimeAfter - sdkProjTimeBefore).TotalSeconds.ToString());
            Debug.WriteLine("Parsing Test Projects took {0}", (testProjTimeAfter - testProjTimeBefore).TotalSeconds.ToString());

            var net452SdkProjects = from s in projWithMetaData where (s.IsTargetFxSupported = true && s.FxMoniker == TargetFrameworkMoniker.net452 && s.ProjectType == SdkProjctType.Sdk) select s.ProjectTaskItem;
            var netStd14SdkProjects = from s in projWithMetaData where (s.IsTargetFxSupported = true && s.FxMoniker == TargetFrameworkMoniker.netstandard14 && s.ProjectType == SdkProjctType.Sdk) select s.ProjectTaskItem;
            var testNetCore11Projects = from s in projWithMetaData where (s.IsTargetFxSupported = true && s.FxMoniker == TargetFrameworkMoniker.netcoreapp11 && s.ProjectType == SdkProjctType.Test) select s.ProjectTaskItem;
            var testNet452Projects = from s in projWithMetaData where (s.IsTargetFxSupported = true && s.FxMoniker == TargetFrameworkMoniker.net452 && s.ProjectType == SdkProjctType.Test) select s.ProjectTaskItem;
            var unSupportedProjects = from s in projWithMetaData where (s.IsTargetFxSupported = false) select s.ProjectTaskItem;

            net452SdkProjectsToBuild = net452SdkProjects?.ToArray<ITaskItem>();
            netStd14SdkProjectsToBuild = netStd14SdkProjects?.ToArray<ITaskItem>();
            netCore11TestProjectsToBuild = testNetCore11Projects?.ToArray<ITaskItem>();
            net452TestProjectsToBuild = testNet452Projects?.ToArray<ITaskItem>();
            unSupportedProjectsToBuild = unSupportedProjects?.ToArray<ITaskItem>();

            return true;
        }

        public ConcurrentBag<SdkProjectMetaData> GetMetaData(List<string> projectList, ConcurrentBag<SdkProjectMetaData> supportedProjectBag)
        {
            SdkProjctType pType = SdkProjctType.Sdk;
            var projList = from p in projectList select new TaskItem(p);

            IBuildEngine be = this.BuildEngine;

            ThreadingTsk.Parallel.ForEach<ITaskItem>(projList, (proj) =>
            //foreach (ITaskItem proj in projList)
            {
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
                        TargetFrameworkMoniker tfxMoniker = IsTargetFxSupported(fx);

                        if (tfxMoniker == TargetFrameworkMoniker.net452)
                        {
                            SdkProjectMetaData sp = new SdkProjectMetaData(project: proj, fxMoniker: TargetFrameworkMoniker.net452, fullProjectPath: proj.ItemSpec, isTargetFxSupported: true, projectType: pType);
                            supportedProjectBag.Add(sp);
                        }
                        else if (tfxMoniker == TargetFrameworkMoniker.netstandard14)
                        {
                            SdkProjectMetaData sp = new SdkProjectMetaData(proj, TargetFrameworkMoniker.netstandard14, proj.ItemSpec, true, pType);
                            supportedProjectBag.Add(sp);
                        }
                        else if (tfxMoniker == TargetFrameworkMoniker.netcoreapp11)
                        {
                            SdkProjectMetaData sp = new SdkProjectMetaData(proj, TargetFrameworkMoniker.netcoreapp11, proj.ItemSpec, true, pType);
                            supportedProjectBag.Add(sp);
                        }
                        else
                        {
                            SdkProjectMetaData sp = new SdkProjectMetaData(proj, tfxMoniker, proj.ItemSpec, false, pType);
                            supportedProjectBag.Add(sp);
                        }
                    }
                }
                catch (Exception ex)
                {
                    if (be != null)
                    {
                        Log.LogMessage(ex.ToString());
                    }
                    else
                    {
                        Debug.WriteLine(ex.ToString());
                    }
                }

                //loadedProj = null;
            });

            return supportedProjectBag;
        }
        
        private TargetFrameworkMoniker IsTargetFxSupported(string fxMoniker)
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

            return validMoniker;
        }

        private void GetCategorization(List<string> testProjects, 
            List<string> sdkProjects, List<ITaskItem> testTaskItems, 
            List<ITaskItem> sdkTaskItems, List<ITaskItem> unsupportedTargetFxTaskItems)
        {
            //UpdateWellKnowProjectList();

            //foreach (string testProj in testProjects)
            //{
            //    TaskItem ti = new TaskItem(testProj);
            //    testTaskItems.Add(ti);
            //}

            //foreach (string projPath in sdkProjects)
            //{
            //    TaskItem supportedTi = new TaskItem(projPath);
            //    TaskItem unSupportedTi = new TaskItem(projPath);

            //    Dictionary<string, SdkProjectMetaData> targetFxMetaData = GetSupportedProjectStatus(supportedTi);

            //    var supportedProjs = from p in targetFxMetaData where p.Value.IsTargetFxSupported.Equals(true) select p;
            //    var unSupportedProjs = from p in targetFxMetaData where p.Value.IsTargetFxSupported.Equals(false) select p;

            //    foreach (KeyValuePair<string, SdkProjectMetaData> kv in supportedProjs)
            //    {
            //        supportedTi.SetMetadata(kv.Key, kv.Value.FxMoniker);
            //        sdkTaskItems.Add(supportedTi);
            //    }

            //    foreach (KeyValuePair<string, SdkProjectMetaData> kv in unSupportedProjs)
            //    {
            //        unSupportedTi.SetMetadata(kv.Key, kv.Value.FxMoniker);
            //        unsupportedTargetFxTaskItems.Add(unSupportedTi);
            //    }
            //}

            //if (sdkTaskItems.Any<ITaskItem>())
            //{
            //    SDKProjectsToBuild = sdkTaskItems.ToArray<ITaskItem>();
            //}

            //if (testTaskItems.Any<ITaskItem>())
            //{
            //    SDKTestProjectsToBuild = testTaskItems.ToArray<ITaskItem>();
            //}

            //return true;
        }

        private bool GetOldWay()
        {
            //UpdateWellKnowProjectList();

            //foreach (string testProj in testProjects)
            //{
            //    TaskItem ti = new TaskItem(testProj);
            //    testTaskItems.Add(ti);
            //}

            //foreach (string projPath in sdkProjects)
            //{
            //    TaskItem supportedTi = new TaskItem(projPath);
            //    TaskItem unSupportedTi = new TaskItem(projPath);

            //    Dictionary<string, FxProjectStatus> targetFxMetaData = GetSupportedProjectStatus(supportedTi);

            //    var supportedProjs = from p in targetFxMetaData where p.Value.IsTargetFxSupported.Equals(true) select p;
            //    var unSupportedProjs = from p in targetFxMetaData where p.Value.IsTargetFxSupported.Equals(false) select p;

            //    foreach (KeyValuePair<string, FxProjectStatus> kv in supportedProjs)
            //    {
            //        supportedTi.SetMetadata(kv.Key, kv.Value.FxMoniker);
            //        sdkTaskItems.Add(supportedTi);
            //    }

            //    foreach (KeyValuePair<string, FxProjectStatus> kv in unSupportedProjs)
            //    {
            //        unSupportedTi.SetMetadata(kv.Key, kv.Value.FxMoniker);
            //        unsupportedTargetFxTaskItems.Add(unSupportedTi);
            //    }

            //}

            //if (sdkTaskItems.Any<ITaskItem>())
            //{
            //    SDKProjectsToBuild = sdkTaskItems.ToArray<ITaskItem>();
            //}

            //if (testTaskItems.Any<ITaskItem>())
            //{
            //    SDKTestProjectsToBuild = testTaskItems.ToArray<ITaskItem>();
            //}

            return true;
        }

        #region Scoped
        private List<string> ScopedSdkProjects(string rootSearchDirPath, string scope)
        {
            List<string> finalSdkProj = new List<string>();
            string searchProjInDirPath = Path.Combine(rootSearchDirPath, scope);
            if (Directory.Exists(searchProjInDirPath))
            {
                var scopedSdkProjs = SearchOnlySdkProjects(searchProjInDirPath);
                //var stestProj = SearchOnlyTestProjects(searchProjInDirPath);

                //var scopedSdkProjs = ssdkProj.Except<string>(stestProj, new ObjectComparer<string>((left, right) => left.Equals(right, StringComparison.OrdinalIgnoreCase)));
                if (scopedSdkProjs.Any<string>())
                {
                    finalSdkProj.AddRange(scopedSdkProjs);
                }
            }
            return finalSdkProj;
        }

        private List<string> ScopedTestProjects(string rootSearchDirPath, string scope)
        {
            List<string> testProj = new List<string>();
            string searchProjInDirPath = Path.Combine(rootSearchDirPath, scope);
            if (Directory.Exists(searchProjInDirPath))
            {
                testProj = SearchOnlyTestProjects(searchProjInDirPath);
            }
            return testProj;
        }

        //private List<string> GetScopedDirs(string dirScope)
        //{
        //    List<string> finalScopeDirs = new List<string>();
        //    var allDirs = Directory.EnumerateDirectories(SourceRootDirPath, "*", SearchOption.AllDirectories);
        //    var ignoredDirs = Directory.EnumerateDirectories(SourceRootDirPath, IgnoreDirForSearchingProjects, SearchOption.AllDirectories);
        //    var scopeDirs = allDirs.Except<String>(ignoredDirs);

        //    if(scopeDirs.Any<String>())
        //    {
        //        finalScopeDirs = scopeDirs.ToList<string>();
        //    }

        //    return finalScopeDirs;
        //}
        #endregion

        #region All
        /// <summary>
        /// This searches all the projects from the root directory sepcified
        /// This also creates ignore list of projects
        /// </summary>
        /// <param name="rootSearchDirPath"></param>
        /// <param name="projectExts"></param>
        /// <returns></returns>
        private List<string> SearchAllProjectFiles(string rootSearchDirPath, string projectExts)
        {
            List<string> searchedProjects = new List<string>();
            if (string.IsNullOrWhiteSpace(projectExts) || string.IsNullOrEmpty(projectExts))
            {
                projectExts = _defaultFileExt;
            }
            List<string> projectExtList = projectExts.Split(';').ToList<string>();

            var allProjFiles = Directory.EnumerateFiles(SourceRootDirPath, _defaultFileExt, SearchOption.AllDirectories);
            var ignoredFiles = GetAndUpdateIgnoredProjects(SourceRootDirPath);

            var finalProjects = allProjFiles.Except<string>(ignoredFiles, new ObjectComparer<string>((left, right) => left.Equals(right, StringComparison.OrdinalIgnoreCase)));

            if (finalProjects.Any<string>())
                _searchedAllProjects.AddRange(finalProjects);

            return _searchedAllProjects;
        }

        private List<string> SearchOnlySdkProjects(string rootSearchDirPath)
        {
            List<string> sdkProjFiles = new List<string>();
            var sdkProj = Directory.EnumerateFiles(rootSearchDirPath, _defaultFileExt, SearchOption.AllDirectories)?.ToList<string>();
            var testProj = SearchOnlyTestProjects(rootSearchDirPath);

            var finalSdkProj = sdkProj.Except<string>(_overAllIgnoreProjects, new ObjectComparer<string>((left, right) => left.Equals(right, StringComparison.OrdinalIgnoreCase)));
            finalSdkProj = finalSdkProj.Except<string>(testProj, new ObjectComparer<string>((left, right) => left.Equals(right, StringComparison.OrdinalIgnoreCase)));

            if (finalSdkProj.Any<string>())
            {
                sdkProjFiles.AddRange(finalSdkProj);
            }
            //_sdkProjFiles = _searchedAllProjects.FindAll((pf) => ((!pf.EndsWith("test.csproj")) || (!pf.EndsWith("tests.csproj"))));
            //}

            return sdkProjFiles;
        }

        private List<string> SearchOnlyTestProjects(string rootSearchDirPath)
        {
            List<string> testProj = new List<string>();
            List<string> tp = new List<string>();
            foreach (string token in _defaultTestProjTokens)
            {
                var intrimTP = Directory.EnumerateFiles(rootSearchDirPath, token, SearchOption.AllDirectories)?.ToList<string>();

                if (intrimTP.Any<string>())
                {
                    tp.AddRange(intrimTP);
                }
            }

            var finalTp = tp.Except<string>(_overAllIgnoreProjects, new ObjectComparer<string>((left, right) => left.Equals(right, StringComparison.OrdinalIgnoreCase)))?.ToList<string>();
            if (finalTp.Any<string>())
            {
                testProj.AddRange(finalTp);
            }
            return testProj;
        }
        #endregion
        
        private void Init()
        {
            if (!Directory.Exists(SourceRootDirPath))
                throw new DirectoryNotFoundException("'{0}' does not exists. Please provide a valid directory to search for projects that needs to be build");

            if ((string.IsNullOrWhiteSpace(BuildScope)) || (string.IsNullOrEmpty(BuildScope)))
            {
                Log.LogMessage("Empty Scope Detected, setting BuildScope to 'All'");
                BuildScope = _defaultBuildScope;
            }

            //Get All Projects
            SearchAllProjectFiles(SourceRootDirPath, SearchProjectFileExt);

            //Get overall ignore list
            //_overAllIgnoreProjects.AddRange(SearchWellKnowProjects(wkProj45Paths));
            //_overAllIgnoreProjects.AddRange(SearchWellKnowProjects(wkTest45Projects));
        }
        
        private List<string> GetAllProjectFilesFromDirs(string projFileSearchPattern, SearchOption searchingOption, params string[] searchDirs)
        {
            List<string> results = new List<string>();
            foreach (string dir in searchDirs)
            {
                var projs = Directory.EnumerateFiles(dir, "*test*.csproj", SearchOption.AllDirectories);
                if (projs.Any<string>())
                {
                    results.AddRange(projs);
                }
            }

            return results;
        }
        
        public void GetSupportedProjectStatus(ITaskItem projSpec)
        {
            //Dictionary<string, SdkProjectMetaData> fxDict = new Dictionary<string, SdkProjectMetaData>();
            //int monikerCount = 0;
            //Project loadedProj = new Project(projSpec.ItemSpec);

            //string targetFxList = loadedProj.GetPropertyValue("TargetFrameworks");
            //if (string.IsNullOrEmpty(targetFxList))
            //{
            //    targetFxList = loadedProj.GetPropertyValue("TargetFramework");
            //}

            //if (!string.IsNullOrEmpty(targetFxList))
            //{
            //    var fxNames = targetFxList.Split(';').ToList<string>();
            //    foreach (string fn in fxNames)
            //    {
            //        TargetFrameworkMoniker fxMoniker = GetValidFxMoniker(fn, out bool isFxValid);
            //        SdkProjectMetaData projStatus = new SdkProjectMetaData(fxMoniker.ToString(), projSpec.ItemSpec, isFxValid);
            //        if (isFxValid)
            //        {
            //            fxDict.Add(fxMoniker.ToString(), projStatus);
            //        }
            //        else
            //        {
            //            //Log.LogMessage("Detected unsupported Target Framework {0}, in project {1}", fn, projSpec.ItemSpec);
            //        }

            //        monikerCount++;
            //    }

            //    loadedProj = null;
            //}

            //return fxDict;
        }

        /// <summary>
        /// Potential fragmentation logic
        /// </summary>
        private void UpdateWellKnowProjectList()
        {
            List<string> wkSdkProjs = SearchWellKnowProjects(wkProj45Paths);
            List<string> wkTestSdkProjs = SearchWellKnowProjects(wkTest45Projects);

            List<ITaskItem> wkTTi = new List<ITaskItem>();
            List<ITaskItem> wkTi = new List<ITaskItem>();

            foreach (string testProj in wkTestSdkProjs)
            {
                TaskItem ti = new TaskItem(testProj);
                wkTTi.Add(ti);
            }

            foreach (string projPath in wkSdkProjs)
            {
                TaskItem ti = new TaskItem(projPath);
                wkTi.Add(ti);
            }

            if (wkTTi.Any<ITaskItem>())
            {
                //WellKnowTestSDKNet452Projects = wkTTi.ToArray<ITaskItem>();
            }

            if (wkTi.Any<ITaskItem>())
            {
                //WellKnowSDKNet452Projects = wkTi.ToArray<ITaskItem>();
            }
        }

        private List<string> SearchWellKnowProjects(List<string> searchPatternList)
        {
            List<string> searchedProjects = new List<string>();
            foreach (string projSearchPattern in searchPatternList)
            {
                var sdk45Proj = Directory.EnumerateFiles(SourceRootDirPath, projSearchPattern, SearchOption.AllDirectories);
                if (sdk45Proj.Any<string>())
                {
                    searchedProjects.AddRange(sdk45Proj);
                }
            }

            return searchedProjects;
        }
        
        private List<string> GetAndUpdateIgnoredProjects(string sourceRootDir)
        {
            //ClientIntegrationTesting
            // FileConventions
            // FileStaging
            string[] ignoreTokens = null;

            if (!string.IsNullOrEmpty(IgnoreDirNameForSearchingProjects))
            {
                IgnoreDirNameForSearchingProjects = IgnoreDirNameForSearchingProjects.Trim();
                ignoreTokens = IgnoreDirNameForSearchingProjects.Split(' ');
            }

            var allProjFiles = Directory.EnumerateFiles(sourceRootDir, _defaultFileExt, SearchOption.AllDirectories);

            foreach (string tokenToIgnore in ignoreTokens)
            {
                var ignoredFiles = from s in allProjFiles where s.Contains(tokenToIgnore) select s;
                if (ignoredFiles.Any<string>())
                {
                    _overAllIgnoreProjects.AddRange(ignoredFiles);
                }
            }

            //_overAllIgnoreProjects.AddRange(SearchWellKnowProjects(wkProj45Paths));
            //_overAllIgnoreProjects.AddRange(SearchWellKnowProjects(wkTest45Projects));

            return _overAllIgnoreProjects;
        }

        private TargetFrameworkMoniker GetValidFxMoniker(string moniker, out bool isMonikerValid)
        {
            string lcMoniker = moniker.ToLower();
            bool fxSupported = false;
            TargetFrameworkMoniker fxMoniker = TargetFrameworkMoniker.UnSupported;
            switch (lcMoniker)
            {
                case "net452":
                    fxMoniker = TargetFrameworkMoniker.net452;
                    fxSupported = true;
                    break;

                case "netcoreapp1.1":
                    fxMoniker = TargetFrameworkMoniker.netcoreapp11;
                    fxSupported = true;
                    break;

                case "netstandard1.4":
                    fxMoniker = TargetFrameworkMoniker.netstandard14;
                    fxSupported = true;
                    break;

                case "net46":
                    fxMoniker = TargetFrameworkMoniker.net46;
                    fxSupported = false;
                    break;

                case "net461":
                    fxMoniker = TargetFrameworkMoniker.net461;
                    fxSupported = false;
                    break;
            }

            isMonikerValid = fxSupported;
            return fxMoniker;
        }
        
    }

    public class SdkProjectMetaData
    {
        public TargetFrameworkMoniker FxMoniker { get; set; }
        public string FullProjectPath { get; set; }
        public bool IsTargetFxSupported { get; set; }

        public SdkProjctType ProjectType { get; set; } 

        public ITaskItem ProjectTaskItem { get; set; }

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

/*
 * 
 * string[] dirArray = null;
                var dirs = GetScopedDirs(searchProjInDirPath);
                if(dirs.Any<string>())
                {
                    dirArray = dirs.ToArray<string>();
                }

                List<string> allScopedSdkProjs = GetAllProjectFilesFromDirs("*.csproj", SearchOption.AllDirectories, dirArray);
                List<string> scopedTestProjs = ScopedTestProjects(rootSearchDirPath, scope);

                var onlySdk = allScopedSdkProjs.Except<string>(scopedTestProjs);
                if(onlySdk.Any<string>())
                {
                    sdkProj = onlySdk.ToList<string>();
                }
            }

            return sdkProj;
//var allDirs = Directory.EnumerateDirectories(SourceRootDirPath, "*", SearchOption.TopDirectoryOnly);
            //var ignoredDirs = Directory.EnumerateDirectories(SourceRootDirPath, IgnoreDirForSearchingProjects, SearchOption.AllDirectories);

            //var projectsToSearchInDirs = allDirs.Except<string>(ignoredDirs);
            //if(projectsToSearchInDirs.Any<string>())
            //{
            //    _finalDirListForSearchingProjects = projectsToSearchInDirs.ToList<string>();
            //}

            //if(_finalDirListForSearchingProjects.Any<string>())
            //{
            //    foreach (string searchDir in _finalDirListForSearchingProjects)
            //    {
            //        foreach (string pExt in projectExtList)
            //        {
            //            string fileSearchPattern = string.Concat("*", pExt);
            //            var projectFiles = Directory.EnumerateFiles(SourceRootDirPath, fileSearchPattern, SearchOption.AllDirectories);
            //            _searchedAllProjects.AddRange(projectFiles);
            //        }
            //    }
            //}


    //foreach (string dir in _finalDirListForSearchingProjects)
            //{
            //    var tp = Directory.EnumerateFiles(dir, "*test*.csproj", SearchOption.AllDirectories);
            //    if(tp.Any<string>())
            //    {   
            //        testProj.AddRange(tp);
            //    }
            //}


    var dirs = GetScopedDirs(searchProjInDirPath);
                if (dirs.Any<string>())
                {
                    dirArray = dirs.ToArray<string>();
                }

                testProj = GetAllProjectFilesFromDirs("*test*.csproj", SearchOption.AllDirectories, dirArray);
                //List<string> sDirs = GetScopedDirs(searchProjInDirPath);
                //foreach(string dir in sDirs)
                //{
                //    var projs = SearchProjectFiles(dir, "*test*.csproj", SearchOption.AllDirectories);
                //    if(projs.Any<string>())
                //    {
                //        testProj.AddRange(projs);
                //    }
                //}

*/
