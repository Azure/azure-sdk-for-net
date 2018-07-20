// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Microsoft.WindowsAzure.Build.Tasks.Utilities
{
    using Microsoft.Azure.Sdk.Build.Tasks.Utilities;
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;

    public class ProjectSearchUtility
    {
        #region Fields
        const string DEFAULT_PROJECT_EXTENSION = "*.csproj";

        private List<string> _projExtList;
        private List<string> _ignorePathTokenList;
        private List<string> _testProjectTokenList;

        private List<string> _allProjs;
        private List<string> _testProjs;
        private List<string> _ignoreProjs;
        private List<string> _includeProjs;

        #endregion

        #region Properties
        public List<string> ProjectExtensionList
        {
            get
            {
                if (_projExtList == null)
                {
                    _projExtList = new List<string>() { DEFAULT_PROJECT_EXTENSION };
                }
                return _projExtList;
            }
        }

        public List<string> IgnorePathTokenList
        {
            get
            {
                if (_ignorePathTokenList == null)
                {
                    _ignorePathTokenList = new List<string>();
                }
                return _ignorePathTokenList;
            }

            private set
            {
                _ignorePathTokenList = value;
            }

        }

        public List<string> IncludePathTokenList { get; set; }

        public List<string> TestProjectTokenList
        {
            get
            {
                if (_testProjectTokenList == null)
                {
                    _testProjectTokenList = new List<string>() { "*tests.csproj", "*test.csproj", "*KeyVault.TestFramework.csproj" };
                }
                return _testProjectTokenList;
            }
        }

        public IReadOnlyList<string> AllProjectList
        {
            get
            {
                if (_allProjs == null)
                {
                    _allProjs = new List<string>();
                }

                if(_allProjs?.Count <= 0)
                { 
                    _allProjs = SearchProjects(RootDirForSearch);
                }

                return _allProjs.AsReadOnly();
            }
        }

        public IReadOnlyList<string> AllTestProjectList
        {
            get
            {
                if (_testProjs == null)
                {
                    _testProjs = new List<string>();
                }

                if(_testProjs?.Count <= 0)
                { 
                    _testProjs = SearchTestProjects(RootDirForSearch);
                }

                return _testProjs.AsReadOnly();
            }
        }

        
        public IReadOnlyList<string> IgnoredProjectList
        {
            get
            {
                if (_ignoreProjs == null)
                {
                    _ignoreProjs = new List<string>();
                }

                if (_ignoreProjs?.Count <= 0)
                {
                    foreach (string iP in IgnorePathTokenList)
                    {
                        var ignorePaths = from proj in AllProjectList where proj.Contains(iP) select proj;
                        if (ignorePaths.Any<string>())
                        {
                            _ignoreProjs.AddRange(ignorePaths);
                        }
                    }
                }

                return _ignoreProjs.AsReadOnly();
            }
        }

        public IReadOnlyList<string> IncludeProjectList
        {
            get
            {
                if (_includeProjs == null)
                {
                    _includeProjs = new List<string>();
                }

                if (_includeProjs?.Count <= 0)
                {
                    foreach (string iP in IncludePathTokenList)
                    {
                        var includePaths = from proj in AllProjectList where proj.Contains(iP) select proj;
                        if (includePaths.Any<string>())
                        {
                            _includeProjs.AddRange(includePaths);
                        }
                    }
                }

                return _includeProjs.AsReadOnly();
            }
        }

        /// <summary>
        /// This will be path especially when we run a CI run and search all possible projects
        /// </summary>
        public string RootDirForSearch { get; private set; }

        /// <summary>
        /// This will be the root directory where projects are being discovered
        /// </summary>
        public string ProjectRootDir { get; private set; }
        #endregion

        #region Constructor
        public ProjectSearchUtility(string rootDirPath)
        {
            Check.DirectoryExists(rootDirPath);
            RootDirForSearch = rootDirPath;

            _projExtList = null;
            _ignorePathTokenList = null;
            _testProjectTokenList = null;
            _allProjs = null;
            _testProjs = null;
            _ignoreProjs = null;
        }

        public ProjectSearchUtility(string rootDirPath, List<string> ignorePathTokens) : this(rootDirPath)
        {
            //Check.NotNull(projectExtensions, "Project Extensions param array");
            IgnorePathTokenList = ignorePathTokens;
        }

        public ProjectSearchUtility(string rootDirPath, List<string> ignorePathTokens, params string[] projectExtensionsToSearch) : this(rootDirPath, ignorePathTokens)
        {
            //Check.NotNull(ignorePathTokens, "Ignore Token Path List");
            foreach (string ext in projectExtensionsToSearch)
            {
                if (!ProjectExtensionList.Contains(ext))
                    ProjectExtensionList.Add(ext);
            }
        }

        public ProjectSearchUtility(string rootDirPath, List<string> ignorePathTokens, List<string> includePathTokens) : this(rootDirPath, ignorePathTokens, DEFAULT_PROJECT_EXTENSION)
        {
            IncludePathTokenList = includePathTokens;
        }
        #endregion
        
        /// <summary>
        /// Finds all projects that can be found under RootDirForSearch using ProjectExtensionList.
        /// </summary>
        /// <param name="filterWithIgnoreProjects">true: will filter out all projects using IgnorePathTokenList. false: will not apply any filter</param>
        /// <returns></returns>
        public List<string> GetFilteredProjects()
        {
            return FilterList(AllProjectList, true, true);
        }

        public List<string> GetFilteredTestProjects()
        {
            return FilterList(AllTestProjectList, true, true);
        }

        public List<string> GetAllSDKProjects()
        {
            List<string> filteredSDKProjects = GetFilteredProjects().Except<string>(GetFilteredTestProjects(), new ObjectComparer<string>((left, right) => left.Equals(right, StringComparison.OrdinalIgnoreCase)))?.ToList<string>();
            return filteredSDKProjects;
        }

        public List<string> GetScopedSDKProjects(string scopePath)
        {
            List<string> scopedProjects = new List<string>();
            string searchProjInDirPath = AdjustPathForScopedProjects(RootDirForSearch, scopePath);
            if (Directory.Exists(searchProjInDirPath))
            {
                ProjectRootDir = searchProjInDirPath;
                List<string> searchedScopedProjects = SearchProjects(searchProjInDirPath);
                List<string> testProjs = SearchTestProjects(searchProjInDirPath);

                var filteredProjs = searchedScopedProjects.Except<string>(testProjs, new ObjectComparer<string>((left, right) => left.Equals(right, StringComparison.OrdinalIgnoreCase)));
                scopedProjects = FilterList(filteredProjs, true, true);
            }

            return scopedProjects;
        }

        public List<string> GetScopedTestProjects(string scopePath)
        {
            List<string> returnTestScopedProjects = new List<string>();
            
            string searchDir = AdjustPathForScopedProjects(RootDirForSearch, scopePath);
            if (Directory.Exists(searchDir))
            {
                List<string> testScopedProjects = SearchTestProjects(searchDir);
                returnTestScopedProjects = FilterList(testScopedProjects, true, true);
            }

            return returnTestScopedProjects;
        }

        private List<string> FilterList(IEnumerable<string> listToBeFiltered, bool filterOnIgnoreList = true, bool filterOnIncludeList = true)
        {
            List<string> returnList = new List<string>();
            IEnumerable<string> filteredList = listToBeFiltered;

            if (listToBeFiltered != null && listToBeFiltered.Any<string>())
            {
                // Filter on IgnoreProject list
                if (filterOnIgnoreList && IgnoredProjectList.Any<string>())
                {
                    filteredList = listToBeFiltered.Except<string>(IgnoredProjectList, new ObjectComparer<string>((left, right) => left.Equals(right, StringComparison.OrdinalIgnoreCase)));
                }

                // Filter on IncludeProject List
                if (filteredList != null && filteredList.Any<string>())
                {
                    if (filterOnIncludeList && IncludeProjectList.Any<string>())
                    {
                        filteredList = filteredList.Intersect<string>(IncludeProjectList, new ObjectComparer<string>((left, right) => left.Equals(right, StringComparison.OrdinalIgnoreCase)));
                    }
                }
                else // this means IgnoreProjectList was either empty or the master list was empty due to filter on ignore list
                     // e.g. Scope was SDKs\Compute and IgnoreList had Compute
                     // in any case, we will now apply IncludeList on the master list
                {
                    if (filterOnIncludeList && IncludeProjectList.Any<string>())
                    {
                        filteredList = listToBeFiltered.Intersect<string>(IncludeProjectList, new ObjectComparer<string>((left, right) => left.Equals(right, StringComparison.OrdinalIgnoreCase)));
                    }
                }
            }
            
            if(filteredList != null && filteredList.Any<string>())
            {
                returnList = filteredList.ToList<string>();
            }

            return returnList;
        }

        #region Search
        private List<string> SearchProjects(string searchDirPath)
        {
            List<string> searchProjs = new List<string>();
            foreach (string ext in ProjectExtensionList)
            {
                var searchedProjects = Directory.EnumerateFiles(searchDirPath, ext, SearchOption.AllDirectories);
                if (searchedProjects.Any<string>())
                {
                    searchProjs.AddRange(searchedProjects);
                }
            }

            return searchProjs;
        }
        
        private List<string> SearchTestProjects(string searchDirPath)
        {
            List<string> _testProjs = new List<string>();

            foreach (string testToken in TestProjectTokenList)
            {
                var searchedTestProjects = Directory.EnumerateFiles(searchDirPath, testToken, SearchOption.AllDirectories);
                if (searchedTestProjects.Any<string>())
                {
                    _testProjs.AddRange(searchedTestProjects);
                }
            }

            return _testProjs;
        }
        #endregion

        #region Private functions
        /// <summary>
        /// This function checks if the scope path (which is a relative path) is found under src directory
        /// If not found, it will adjust the root directory from the actul root of repo (one level up)
        /// Earlier: RootDirForSearch use to be <root>\src
        /// But we adjust and move one level up and then search again (if prior attempt resulted in no matching directories)
        /// </summary>
        /// <param name="rootDir"></param>
        /// <param name="scopePath"></param>
        /// <returns></returns>
        private string AdjustPathForScopedProjects(string rootDir, string scopePath)
        {
            string rootParentDir = Directory.GetParent(rootDir).FullName;
            string searchProjInDirPath = Path.Combine(RootDirForSearch, scopePath);
            if (!Directory.Exists(searchProjInDirPath))
            {
                searchProjInDirPath = Path.Combine(rootParentDir, scopePath);
                if (!Directory.Exists(searchProjInDirPath))
                {
                    searchProjInDirPath = string.Empty;
                }
                else
                {
                    // update root dir where search will be preformed
                    RootDirForSearch = searchProjInDirPath;
                }
            }

            return searchProjInDirPath;
        }
        #endregion
    }
}