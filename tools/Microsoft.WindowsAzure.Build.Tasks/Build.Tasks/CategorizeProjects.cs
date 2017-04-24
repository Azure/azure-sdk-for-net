using System;
using Microsoft.Build.Utilities;
using Microsoft.Build.Framework;
using System.IO;
using System.Linq;
using System.Collections.Generic;

using Microsoft.Build.Evaluation;
using Microsoft.Build.Execution;

namespace Microsoft.WindowsAzure.Build.Tasks
{
    public class CategorizeProjects : Task
    {
        private string _defaultFileExt = "*.csproj";
        private string _defaultBuildScope = "All";
        private string _defaultTestProj = "*tests.csproj";

        List<string> wkProj45Paths = new List<string>() { "*Etw.csproj", "*Log4net.csproj" };
        List<string> wkTest45Projects = new List<string>() { "*Net45Tests.csproj", "*Tracing.Tests.csproj" };

        private List<string> _searchedAllProjects;

        private List<string> _finalDirListForSearchingProjects;

        private List<string> _overAllIgnoreProjects;

        public CategorizeProjects()
        {
            _searchedAllProjects = new List<string>();
            _finalDirListForSearchingProjects = new List<string>();
            _overAllIgnoreProjects = new List<string>();
        }

        #region Task properties

        [Required]
        public string SourceRootDirPath { get; set; }

        [Required]
        public string BuildScope { get; set; }

        public string IgnoreDirForSearchingProjects { get; set; }
        
        public string SearchProjectFileExt { get; set; }

        [Output]
        public ITaskItem[] SDKProjectsToBuild { get; set; }

        [Output]
        public ITaskItem[] SDKTestProjectsToBuild { get; set; }

        [Output]
        public ITaskItem[] WellKnowSDKNet452Projects { get; set; }

        [Output]
        public ITaskItem[] WellKnowTestSDKNet452Projects { get; set; }
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
                SearchAllProjectFiles(SourceRootDirPath, SearchProjectFileExt);
                sdkProjects = SearchOnlySdkProjects(SourceRootDirPath);
                testProjects = SearchOnlyTestProjects(SourceRootDirPath);
            }
            else //We set default scope to All if empty/null, so safe to evaluate to Else in this case
            {
                SearchAllProjectFiles(SourceRootDirPath, SearchProjectFileExt);
                sdkProjects = ScopedSdkProjects(SourceRootDirPath, BuildScope);
                testProjects = ScopedTestProjects(SourceRootDirPath, BuildScope);
            }

            UpdateWellKnowProjectList();
            //sdkProjects = sdkProjects.Except<string>(SearchWellKnowProjects(wkProj45Paths))?.ToList<string>();
            //testProjects = testProjects.Except<string>(SearchWellKnowProjects(wkTest45Projects))?.ToList<string>();
            
            foreach (string testProj in testProjects)
            {
                TaskItem ti = new TaskItem(testProj);
                testTaskItems.Add(ti);
            }

            foreach(string projPath in sdkProjects)
            {
                TaskItem ti = new TaskItem(projPath);
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
                var ssdkProj = SearchOnlySdkProjects(searchProjInDirPath);
                var stestProj = SearchOnlyTestProjects(searchProjInDirPath);

                var scopedSdkProjs = ssdkProj.Except<string>(stestProj);
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
        private List<string> SearchAllProjectFiles(string rootSearchDirPath, string projectExts)
        {
            List<string> searchedProjects = new List<string>();
            if (string.IsNullOrWhiteSpace(projectExts) || string.IsNullOrEmpty(projectExts))
            {
                projectExts = _defaultFileExt;
            }
            List<string> projectExtList = projectExts.Split(';').ToList<string>();

            var allProjFiles = Directory.EnumerateFiles(SourceRootDirPath, _defaultFileExt, SearchOption.AllDirectories);
            var ignoredFiles = from s in allProjFiles where s.Contains(IgnoreDirForSearchingProjects) select s;

            if(ignoredFiles.Any<string>())
            {
                _overAllIgnoreProjects.AddRange(ignoredFiles);
            }

            var finalProjects = allProjFiles.Except<string>(ignoredFiles);

            if (finalProjects.Any<string>())
                _searchedAllProjects.AddRange(finalProjects);

            return _searchedAllProjects;
        }

        private List<string> SearchOnlySdkProjects(string rootSearchDirPath)
        {
            List<string> ignoreList = _overAllIgnoreProjects;
            ignoreList.AddRange(SearchOnlyTestProjects(rootSearchDirPath));
            ignoreList.AddRange(SearchWellKnowProjects(wkProj45Paths));

            List<string> sdkProjFiles = new List<string>();
            var sdkProj = Directory.EnumerateFiles(rootSearchDirPath, _defaultFileExt, SearchOption.AllDirectories);
            //sdkProj = sdkProj.Except<string>(_overAllIgnoreProjects);
            //List<string> testProjects = SearchOnlyTestProjects(rootSearchDirPath);
            //List<string> wkProj = SearchWellKnowProjects(wkProj45Paths);
            //sdkProj = sdkProj.Except<string>(wkProj);
            var finalSdkProj = sdkProj.Except<string>(ignoreList);

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
            List<string> ignoreList = new List<string>();
            //ignoreList.AddRange(_overAllIgnoreProjects);
            ignoreList.AddRange(SearchWellKnowProjects(wkTest45Projects));

            List<string> testProj = new List<string>();
            var tp = Directory.EnumerateFiles(rootSearchDirPath, _defaultTestProj, SearchOption.AllDirectories);
            //List<string> wkTestProj = SearchWellKnowProjects(wkTest45Projects);
            //tp = tp.Except<string>(wkTestProj);
            var finalTp = tp.Except<string>(ignoreList);
            if (finalTp.Any<string>())
            {
                testProj.AddRange(finalTp);
            }

            foreach(string lst in ignoreList)
            {
                testProj.Except<string>()
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
