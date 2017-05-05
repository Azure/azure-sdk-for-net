﻿using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using System.Reflection;
using System.IO;
using System.Linq;
using Microsoft.Build.Framework;
using BuildTasks.Core;

namespace Build.Tasks.Tests
{
    public class CategorizeProjectTaskTest
    {
        string sourceRootDir = string.Empty;
        string ignoreDir = string.Empty;
        public CategorizeProjectTaskTest()
        {
            sourceRootDir = GetSourceRootDir();
            sourceRootDir = Path.Combine(sourceRootDir, "src");
            ignoreDir = @"Microsoft.Azure.KeyVault.Samples";
        }


        [Fact]
        public void IgnoreDirTokens()
        {
            SDKCategorizeProjects cproj = new SDKCategorizeProjects();
            cproj.SourceRootDirPath = sourceRootDir;
            cproj.BuildScope = "All";
            cproj.IgnoreDirNameForSearchingProjects = string.Join(" ", ignoreDir, "ClientIntegrationTesting", "FileStaging");

            if (cproj.Execute())
            {
                //Using a random number, basically if the number of projects drop below a certain, should fail this test
                Assert.True(cproj.SDKProjectsToBuild.Count<ITaskItem>() > 10);
                Assert.True(cproj.SDKTestProjectsToBuild.Count<ITaskItem>() > 10);
            }
            else
            {
                Assert.True(false);
            }
        }

        [Fact]
        public void CategorizeProjects()
        {
            SDKCategorizeProjects cproj = new SDKCategorizeProjects();
            cproj.SourceRootDirPath = sourceRootDir;
            cproj.BuildScope = "All";
            cproj.IgnoreDirNameForSearchingProjects = Path.Combine(ignoreDir);

            if(cproj.Execute())
            {
                //Using a random number, basically if the number of projects drop below a certain, should fail this test
                Assert.True(cproj.SDKProjectsToBuild.Count<ITaskItem>() > 20);
                Assert.True(cproj.SDKTestProjectsToBuild.Count<ITaskItem>() > 20);
            }
            else
            {
                Assert.True(false);
            }
        }

        [Fact]
        public void ScopedProject()
        {
            SDKCategorizeProjects cproj = new SDKCategorizeProjects();
            cproj.SourceRootDirPath = sourceRootDir;
            cproj.BuildScope = @"SDKs\Compute";
            cproj.IgnoreDirNameForSearchingProjects = Path.Combine(ignoreDir);

            if (cproj.Execute())
            {
                Assert.True(cproj.SDKProjectsToBuild.Count<ITaskItem>() == 1);
                Assert.True(cproj.SDKTestProjectsToBuild.Count<ITaskItem>() == 1);
            }
            else
            {
                Assert.True(false);
            }

        }

        [Fact]
        public void IgnoredProjects()
        {
            SDKCategorizeProjects cproj = new SDKCategorizeProjects();
            cproj.SourceRootDirPath = sourceRootDir;
            cproj.BuildScope = @"SDKs\KeyVault\dataPlane";
            cproj.IgnoreDirNameForSearchingProjects = Path.Combine(ignoreDir);

            if (cproj.Execute())
            {
                Assert.True(cproj.SDKProjectsToBuild.Count<ITaskItem>() > 0);
                Assert.True(cproj.SDKTestProjectsToBuild.Count<ITaskItem>() > 0);
            }
            else
            {
                Assert.True(false);
            }
        }

        [Fact]
        public void ClientRuntimeProjects()
        {
            SDKCategorizeProjects cproj = new SDKCategorizeProjects();
            cproj.SourceRootDirPath = sourceRootDir;
            cproj.BuildScope = @"SDKCommon\ClientRuntime";
            cproj.IgnoreDirNameForSearchingProjects = Path.Combine(ignoreDir);

            if (cproj.Execute())
            {
                Assert.True(cproj.SDKProjectsToBuild.Count<ITaskItem>() == 1);
                Assert.True(cproj.SDKTestProjectsToBuild.Count<ITaskItem>() == 1);
            }
            else
            {
                Assert.True(false);
            }
        }

        [Fact]
        public void SDKCommonProjects()
        {
            SDKCategorizeProjects cproj = new SDKCategorizeProjects();
            cproj.SourceRootDirPath = sourceRootDir;
            cproj.BuildScope = @"SDKCommon";
            cproj.IgnoreDirNameForSearchingProjects = Path.Combine(ignoreDir);

            if (cproj.Execute())
            {
                //Since HttpRecorder and TestFramework are multi-targeting, they are no 
                //longer treated as regular nuget packages (targeting net452 and netStd1.4)
                //but rather projects that are built without any targetFx
                //
                Assert.True(cproj.SDKProjectsToBuild.Count<ITaskItem>() == 3);
                Assert.True(cproj.SDKTestProjectsToBuild.Count<ITaskItem>() == 5);

                Assert.True(cproj.WellKnowSDKNet452Projects.Count() > 0);
                Assert.True(cproj.WellKnowTestSDKNet452Projects.Count() > 0);
            }
            else
            {
                Assert.True(false);
            }
        }

        [Fact]
        public void TestFrameworkDir()
        {
            SDKCategorizeProjects cproj = new SDKCategorizeProjects();
            cproj.SourceRootDirPath = sourceRootDir;
            cproj.BuildScope = @"SDKCommon\TestFramework";
            cproj.IgnoreDirNameForSearchingProjects = Path.Combine(ignoreDir);

            if (cproj.Execute())
            {
                //Since HttpRecorder and TestFramework are multi-targeting, they are no 
                //longer treated as regular nuget packages (targeting net452 and netStd1.4)
                //but rather projects that are build without any targetFx
                Assert.Null(cproj.SDKProjectsToBuild);
                Assert.True(cproj.SDKTestProjectsToBuild.Count<ITaskItem>() == 2);
            }
            else
            {
                Assert.True(false);
            }
        }

        [Fact]
        public void FindTestProject()
        {
            //Operational Insights have named their projects as test.csproj rather than tests.csproj
            SDKCategorizeProjects cproj = new SDKCategorizeProjects();
            cproj.SourceRootDirPath = sourceRootDir;
            cproj.BuildScope = @"SDKs\OperationalInsights";
            cproj.IgnoreDirNameForSearchingProjects = Path.Combine(ignoreDir);

            if (cproj.Execute())
            {
                Assert.True(cproj.SDKProjectsToBuild.Count<ITaskItem>() == 1);
                Assert.True(cproj.SDKTestProjectsToBuild.Count<ITaskItem>() == 1);
            }
            else
            {
                
                Assert.True(false);
            }
        }

        [Fact]
        public void TestIgnoredTokesn()
        {
            //Operational Insights have named their projects as test.csproj rather than tests.csproj
            SDKCategorizeProjects cproj = new SDKCategorizeProjects();
            cproj.SourceRootDirPath = sourceRootDir;
            cproj.BuildScope = @"SDKs\Gallery";
            cproj.IgnoreDirNameForSearchingProjects = @"Gallery";

            if (cproj.Execute())
            {
                Assert.Null(cproj.SDKProjectsToBuild);
                Assert.Null(cproj.SDKTestProjectsToBuild);
            }
            else
            {
                Assert.True(false);
            }
        }

        private string GetSourceRootDir()
        {
            string srcRootDir = string.Empty;
            string currDir = Path.GetDirectoryName(this.GetType().GetTypeInfo().Assembly.Location);
            string dirRoot = Directory.GetDirectoryRoot(currDir);

            var buildProjFile = Directory.EnumerateFiles(currDir, "build.proj", SearchOption.TopDirectoryOnly);
            
            while(currDir != dirRoot)
            {
                if(buildProjFile.Any<string>())
                {
                    srcRootDir = Path.GetDirectoryName(buildProjFile.First<string>());
                    break;
                }

                currDir = Directory.GetParent(currDir).FullName;
                buildProjFile = Directory.EnumerateFiles(currDir, "build.proj", SearchOption.TopDirectoryOnly);
            }

            if(string.IsNullOrEmpty(srcRootDir))
            {
                srcRootDir = @"C:\MyFork\vs17Dev";
            }

            return srcRootDir;
        }
    }
}
