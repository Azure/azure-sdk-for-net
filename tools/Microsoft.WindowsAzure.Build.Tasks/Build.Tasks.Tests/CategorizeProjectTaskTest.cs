// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Microsoft.WindowsAzure.Build.Tasks;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using System.Reflection;
using System.IO;
using System.Linq;
using Microsoft.Build.Framework;
using Microsoft.Build.Evaluation;

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
            Microsoft.WindowsAzure.Build.Tasks.SDKCategorizeProjects cproj = new Microsoft.WindowsAzure.Build.Tasks.SDKCategorizeProjects();
            cproj.SourceRootDirPath = sourceRootDir;
            cproj.BuildScope = "All";
            cproj.IgnoreDirNameForSearchingProjects = string.Join(" ", ignoreDir, "ClientIntegrationTesting", "FileStaging");

            if (cproj.Execute())
            {
                //Using a random number, basically if the number of projects drop below a certain, should fail this test
                Assert.True(cproj.net452SdkProjectsToBuild.Count<ITaskItem>() > 10);
                Assert.True(cproj.netCore11TestProjectsToBuild.Count<ITaskItem>() > 10);
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
                int totalSdkProjectCount = cproj.net452SdkProjectsToBuild.Count() + cproj.netStd14SdkProjectsToBuild.Count<ITaskItem>();
                Assert.Equal(112, totalSdkProjectCount);
                Assert.Equal(54, cproj.netCore11TestProjectsToBuild.Count<ITaskItem>());
                Assert.Equal(7, cproj.net452TestProjectsToBuild.Count<ITaskItem>());
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
                Assert.Equal(cproj.net452SdkProjectsToBuild.Count<ITaskItem>(), 1);
                Assert.Equal(cproj.netCore11TestProjectsToBuild.Count<ITaskItem>(), 1);
            }
        }

        [Fact]
        public void UnSupportedProjects()
        {
            SDKCategorizeProjects cproj = new SDKCategorizeProjects();
            cproj.SourceRootDirPath = sourceRootDir;
            cproj.BuildScope = @"SDKs\Batch\DataPlane";

            if (cproj.Execute())
            {
                Assert.Equal(3, cproj.unSupportedProjectsToBuild.Count<ITaskItem>());
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
                Assert.True(cproj.net452SdkProjectsToBuild.Count<ITaskItem>() > 0);
                Assert.True(cproj.netCore11TestProjectsToBuild.Count<ITaskItem>() > 0);
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
                Assert.Equal(cproj.net452SdkProjectsToBuild.Count<ITaskItem>(), 1);
                Assert.Equal(cproj.netCore11TestProjectsToBuild.Count<ITaskItem>(), 1);
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
                Assert.Equal(7, cproj.net452SdkProjectsToBuild.Count<ITaskItem>());
                Assert.Equal(5, cproj.netCore11TestProjectsToBuild.Count<ITaskItem>());                
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
                Assert.Equal(0, cproj.netStd14SdkProjectsToBuild.Count());
                Assert.Equal(2, cproj.net452SdkProjectsToBuild.Count());
                Assert.Equal(2, cproj.netCore11TestProjectsToBuild.Count<ITaskItem>());
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
                Assert.Equal(1, cproj.netStd14SdkProjectsToBuild.Count<ITaskItem>());
                Assert.Equal(1, cproj.netCore11TestProjectsToBuild.Count<ITaskItem>());
            }
        }

        [Fact]
        public void TestIgnoredTokesn()
        {
            //Gallery projects are being ignored
            SDKCategorizeProjects cproj = new SDKCategorizeProjects();
            cproj.SourceRootDirPath = sourceRootDir;
            cproj.BuildScope = @"SDKs\Gallery";
            cproj.IgnoreDirNameForSearchingProjects = @"Gallery";

            if (cproj.Execute())
            {
                Assert.Equal(0, cproj.net452SdkProjectsToBuild.Count());
                Assert.Equal(0, cproj.netCore11TestProjectsToBuild.Count());
            }
        }

        private string GetSourceRootDir()
        {
            string srcRootDir = string.Empty;
            string currDir = Directory.GetCurrentDirectory();

            if(!Directory.Exists(currDir))
            {
                currDir = Path.GetDirectoryName(this.GetType().GetTypeInfo().Assembly.Location);
            }

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
