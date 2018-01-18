// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Microsoft.WindowsAzure.Build.Tasks.Utilities
{
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

        /// <summary>
        /// In Azure SDK For NET repo, this path will be until src e.g 'C:\Azure-SDK-FOR-NET\src'
        /// </summary>
        public string RootDirForSearch { get; private set; }
        #endregion

        #region Constructor
        public ProjectSearchUtility(string rootDirPath)
        {
            Check.DirectoryExists(rootDirPath);
            RootDirForSearch = rootDirPath;
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
        #endregion
        
        /// <summary>
        /// Finds all projects that can be found under RootDirForSearch using ProjectExtensionList.
        /// </summary>
        /// <param name="filterWithIgnoreProjects">true: will filter out all projects using IgnorePathTokenList. false: will not apply any filter</param>
        /// <returns></returns>
        public List<string> GetFilteredProjects()
        {
            IEnumerable<string> filteredProjects = AllProjectList.Except<string>(IgnoredProjectList, new ObjectComparer<string>((left, right) => left.Equals(right, StringComparison.OrdinalIgnoreCase)));
            return filteredProjects?.ToList<string>();
        }

        public List<string> GetFilteredTestProjects()
        {
            IEnumerable<string> filteredTestProjects = AllTestProjectList.Except<string>(IgnoredProjectList, new ObjectComparer<string>((left, right) => left.Equals(right, StringComparison.OrdinalIgnoreCase)));
            return filteredTestProjects?.ToList<string>();
        }

        public List<string> GetAllSDKProjects()
        {
            List<string> filteredSDKProjects = GetFilteredProjects().Except<string>(GetFilteredTestProjects(), new ObjectComparer<string>((left, right) => left.Equals(right, StringComparison.OrdinalIgnoreCase)))?.ToList<string>();
            return filteredSDKProjects;
        }

        public List<string> GetScopedSDKProjects(string scopePath)
        {
            List<string> scopedProjects = new List<string>();
            //string searchProjInDirPath = Path.Combine(RootDirForSearch, scopePath);
            string searchProjInDirPath = AdjustPathForScopedProjects(RootDirForSearch, scopePath);
            if (Directory.Exists(searchProjInDirPath))
            {
                scopedProjects = SearchProjects(searchProjInDirPath);
                List<string> testProjs = SearchTestProjects(searchProjInDirPath);

                var filteredProjs = scopedProjects.Except<string>(testProjs, new ObjectComparer<string>((left, right) => left.Equals(right, StringComparison.OrdinalIgnoreCase)));
                filteredProjs = filteredProjs.Except<string>(IgnoredProjectList, new ObjectComparer<string>((left, right) => left.Equals(right, StringComparison.OrdinalIgnoreCase)));

                scopedProjects = filteredProjs.ToList<string>();
            }

            return scopedProjects;
        }

        public List<string> GetScopedTestProjects(string scopePath)
        {
            List<string> testScopedProjects = new List<string>();

            //string searchDir = Path.Combine(RootDirForSearch, scopePath);
            string searchDir = AdjustPathForScopedProjects(RootDirForSearch, scopePath);
            if (Directory.Exists(searchDir))
            {
                testScopedProjects = SearchTestProjects(searchDir);
                var filteredProjs = testScopedProjects.Except<string>(IgnoredProjectList, new ObjectComparer<string>((left, right) => left.Equals(right, StringComparison.OrdinalIgnoreCase)));

                testScopedProjects = filteredProjs.ToList<string>();
            }

            return testScopedProjects;
        }
        
        #region Search
        private List<string> SearchProjects(string searchDirPath)
        {
            List<string> _allProjs = new List<string>();
            foreach (string ext in ProjectExtensionList)
            {
                var searchedProjects = Directory.EnumerateFiles(searchDirPath, ext, SearchOption.AllDirectories);
                if (searchedProjects.Any<string>())
                {
                    _allProjs.AddRange(searchedProjects);
                }
            }

            return _allProjs;
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
            }

            return searchProjInDirPath;
        }
        #endregion
    }
}