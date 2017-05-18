using System;
using Microsoft.Build.Utilities;
using Microsoft.Build.Framework;
using System.IO;
using System.Linq;
using System.Collections.Generic;

using Microsoft.Build.Evaluation;
using Microsoft.Build.Execution;
using Microsoft.WindowsAzure.Build.Tasks.Utilities;

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
                if(string.IsNullOrEmpty(_ignoreDirNameForSearchingProjects))
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
        public ITaskItem[] SDKProjectsToBuild { get; private set; }

        /// <summary>
        /// List of Test Projects that needs to be build
        /// </summary>
        [Output]
        public ITaskItem[] SDKTestProjectsToBuild { get; private set; }

        /// <summary>
        /// List of .NET 452 projects that will be separated from the list of projects that 
        /// are multi targeting
        /// 
        /// </summary>
        [Output]
        public ITaskItem[] WellKnowSDKNet452Projects { get; private set; }

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

            UpdateWellKnowProjectList();

            foreach (string testProj in testProjects)
            {
                TaskItem ti = new TaskItem(testProj);
                testTaskItems.Add(ti);
            }

            foreach(string projPath in sdkProjects)
            {
                TaskItem ti = new TaskItem(projPath);

                //This will be enabled, once we find a good way to parse project files that are .NET SDK based.
                //Currently the build engine unable to execute property functions and gives error. Need to find if I am using 
                // the righ set of API's.
                //We want to avoid parsing xml project file as much as possible.

                //Dictionary<string, string> targetFxMetaData = GetMetaData(ti);
                //foreach (KeyValuePair<string, string> kv in targetFxMetaData)
                //{
                //    ti.SetMetadata(kv.Key, kv.Value);
                //}
                
                sdkTaskItems.Add(ti);
            }

            if(sdkTaskItems.Any<ITaskItem>())
            {
                SDKProjectsToBuild = sdkTaskItems.ToArray<ITaskItem>();
            }

            if(testTaskItems.Any<ITaskItem>())
            {
                SDKTestProjectsToBuild = testTaskItems.ToArray<ITaskItem>();
            }
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
            foreach(string token in _defaultTestProjTokens)
            {
                var intrimTP = Directory.EnumerateFiles(rootSearchDirPath, token, SearchOption.AllDirectories)?.ToList<string>();
               
                if(intrimTP.Any<string>())
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

        private Dictionary<string, string> GetMetaData(ITaskItem projSpec)
        {
            Dictionary<string, string> fxDict = new Dictionary<string, string>();
            int monikerCount = 0;
            string[] fxMonikers = new string[] { "TargetFx1", "TargetFx2" };

            var ver = ProjectCollection.GlobalProjectCollection.DefaultToolsVersion;
            Project loadedPoj = ProjectCollection.GlobalProjectCollection.LoadProject(projSpec.ItemSpec);



            string targetFxList = loadedPoj.GetPropertyValue("TargetFrameworks");
            var fxNames = targetFxList.Split(';').ToList<string>();

            KeyValuePair<string, string> kv = new KeyValuePair<string, string>();

            foreach(string fn in fxNames)
            {
                fxDict.Add(fxMonikers[monikerCount], fn);
                Log.LogMessage("Adding FxMoniker {0}={1}", fxMonikers[monikerCount], fn);
                monikerCount++;
            }

            return fxDict;
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
                WellKnowTestSDKNet452Projects = wkTTi.ToArray<ITaskItem>();
            }

            if (wkTi.Any<ITaskItem>())
            {
                WellKnowSDKNet452Projects = wkTi.ToArray<ITaskItem>();
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
        private void Init()
        {
            if (!Directory.Exists(SourceRootDirPath))
                throw new DirectoryNotFoundException("'{0}' does not exists. Please provide a valid directory to search for projects that needs to be build");

            if((string.IsNullOrWhiteSpace(BuildScope)) || (string.IsNullOrEmpty(BuildScope)))
            {
                Log.LogMessage("Empty Scope Detected, setting BuildScope to 'All'");
                BuildScope = _defaultBuildScope;
            }

            //Get All Projects
            SearchAllProjectFiles(SourceRootDirPath, SearchProjectFileExt);

            //Get overall ignore list
            _overAllIgnoreProjects.AddRange(SearchWellKnowProjects(wkProj45Paths));
            _overAllIgnoreProjects.AddRange(SearchWellKnowProjects(wkTest45Projects));
        }

        private List<string> GetAndUpdateIgnoredProjects(string sourceRootDir)
        {
            //ClientIntegrationTesting
            // FileConventions
            // FileStaging
            string[] ignoreTokens = null;
            
            if(!string.IsNullOrEmpty(IgnoreDirNameForSearchingProjects))
            {
                IgnoreDirNameForSearchingProjects = IgnoreDirNameForSearchingProjects.Trim();
                ignoreTokens = IgnoreDirNameForSearchingProjects.Split(' ');
            }

            var allProjFiles = Directory.EnumerateFiles(sourceRootDir, _defaultFileExt, SearchOption.AllDirectories);

            foreach(string tokenToIgnore in ignoreTokens)
            {
                var ignoredFiles = from s in allProjFiles where s.Contains(tokenToIgnore) select s;
                if(ignoredFiles.Any<string>())
                {
                    _overAllIgnoreProjects.AddRange(ignoredFiles);
                }
            }

            _overAllIgnoreProjects.AddRange(SearchWellKnowProjects(wkProj45Paths));
            _overAllIgnoreProjects.AddRange(SearchWellKnowProjects(wkTest45Projects));

            return _overAllIgnoreProjects;
        }
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
