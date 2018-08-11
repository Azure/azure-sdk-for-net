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
using Microsoft.Azure.Sdk.Build.Tasks.Models;
using Microsoft.Build.Construction;
using System.Text.RegularExpressions;

namespace Build.Tasks.Tests
{
    public class CategorizeProjectTaskTest
    {
        internal string rootDir = string.Empty;
        internal string sourceRootDir = string.Empty;
        internal string ignoreDir = string.Empty;
        public CategorizeProjectTaskTest()
        {
            rootDir = GetSourceRootDir();
            sourceRootDir = Path.Combine(rootDir, "src");
            ignoreDir = @"Microsoft.Azure.KeyVault.Samples";
            //System.Environment.SetEnvironmentVariable("MSBuildSDKsPath", @"C:\Program Files (x86)\Microsoft Visual Studio\2017\Professional\MSBuild\Sdks");
        }
        
        [Fact]
        public void GetProjectsWithNonSupportedFxVersion()
        {
            string scopeDir = @"tools\BuildAssets\BuildTasks\Microsoft.Azure.Sdk.Build.Tasks\BootstrapTasks";
            SDKCategorizeProjects cproj = new SDKCategorizeProjects();
            cproj.SourceRootDirPath = sourceRootDir;
            cproj.BuildScope = scopeDir;
            cproj.IgnorePathTokens = Path.Combine(ignoreDir);


            if (cproj.Execute())
            {
                Assert.Equal(cproj.UnFilteredProjects.Count<string>(), 1);
                Assert.Contains(Path.Combine(rootDir, "tools"), cproj.ProjectRootDir);
            }
        }

        [Fact]
        public void GetNonSdkProjects()
        {
            string scopeDir = @"tools\BuildAssets\BuildTasks\Microsoft.Azure.Sdk.Build.Tasks\BootstrapTasks";
            SDKCategorizeProjects cproj = new SDKCategorizeProjects();
            cproj.SourceRootDirPath = sourceRootDir;
            cproj.BuildScope = scopeDir;
            cproj.IgnorePathTokens = Path.Combine(ignoreDir);


            if (cproj.Execute())
            {
                Assert.True(cproj.nonSdkProjectToBuild.ToList().Count >= 1);
                Assert.Contains(Path.Combine(rootDir, "tools"), cproj.ProjectRootDir);
            }
        }

        [Fact]
        public void EmptyProjectExtList()
        {
            SDKCategorizeProjects cproj = new SDKCategorizeProjects();
            cproj.SearchProjectFileExt = null;
            cproj.SourceRootDirPath = sourceRootDir;
            cproj.BuildScope = @"tools\ProjectTemplates\AzureDotNetSDK-TestProject";
            cproj.IgnorePathTokens = Path.Combine(ignoreDir);


            if (cproj.Execute())
            {
                Assert.Equal(cproj.UnFilteredProjects.Count<string>(), 0);
            }
        }

        [Fact]
        public void GetProjectOutsideSourceDir()
        {
            SDKCategorizeProjects cproj = new SDKCategorizeProjects();
            cproj.SearchProjectFileExt = "*.xproj";
            cproj.SourceRootDirPath = sourceRootDir;
            cproj.BuildScope = @"tools\ProjectTemplates\AzureDotNetSDK-TestProject";
            cproj.IgnorePathTokens = Path.Combine(ignoreDir);
            

            if (cproj.Execute())
            {
                Assert.Equal(cproj.UnFilteredProjects.Count<string>(), 0);
            }
        }


        [Fact]
        public void IgnoreDirTokens()
        {
            Microsoft.WindowsAzure.Build.Tasks.SDKCategorizeProjects cproj = new Microsoft.WindowsAzure.Build.Tasks.SDKCategorizeProjects();
            cproj.SourceRootDirPath = sourceRootDir;
            cproj.BuildScope = "All";
            cproj.IgnorePathTokens = string.Join(" ", ignoreDir, "ClientIntegrationTesting", "FileStaging");

            if (cproj.Execute())
            {
                //Using a random number, basically if the number of projects drop below a certain, should fail this test
                Assert.True(cproj.net452SdkProjectsToBuild.Count<ITaskItem>() > 10);
                Assert.True(cproj.netCore20TestProjectsToBuild.Count<ITaskItem>() > 10);
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
            cproj.IgnorePathTokens = Path.Combine(ignoreDir);

            if(cproj.Execute())
            {
                int totalSdkProjectCount = cproj.net452SdkProjectsToBuild.Count() + cproj.netStd14SdkProjectsToBuild.Count<ITaskItem>();
                Assert.True(totalSdkProjectCount > 112);
                Assert.True(cproj.netCore20TestProjectsToBuild.Count<ITaskItem>() > 54);
                Assert.True(cproj.net452TestProjectsToBuild.Count<ITaskItem>() > 7);

                Assert.Contains(sourceRootDir, cproj.ProjectRootDir);
            }
        }

        [Fact]
        public void ScopedProject()
        {
            string scopeDir = @"SDKs\Compute";
            SDKCategorizeProjects cproj = new SDKCategorizeProjects();
            cproj.SourceRootDirPath = sourceRootDir;
            cproj.BuildScope = scopeDir;
            cproj.IgnorePathTokens = Path.Combine(ignoreDir);

            if (cproj.Execute())
            {
                Assert.Equal(cproj.net452SdkProjectsToBuild.Count<ITaskItem>(), 1);
                Assert.Equal(cproj.netCore20TestProjectsToBuild.Count<ITaskItem>(), 1);
                Assert.Contains(sourceRootDir, cproj.ProjectRootDir);
            }
        }

        [Fact]
        public void GetReferencedPackagesForScope()
        {
            string scopeDir = @"SDKs\Compute";
            SDKCategorizeProjects cproj = new SDKCategorizeProjects();
            cproj.SourceRootDirPath = sourceRootDir;
            cproj.BuildScope = scopeDir;
            cproj.IgnorePathTokens = Path.Combine(ignoreDir);

            if (cproj.Execute())
            {
                Assert.Equal(cproj.net452SdkProjectsToBuild.Count<ITaskItem>(), 1);
                Assert.Equal(cproj.netCore20TestProjectsToBuild.Count<ITaskItem>(), 1);
                Assert.True(cproj.AzSdkPackageList.Count<string>() >= 1);
            }
        }

        [Fact]
        public void BuildOnlyIncludedTokenListProjects()
        {
            SDKCategorizeProjects cproj = new SDKCategorizeProjects();
            cproj.BuildScope = "All";
            cproj.SourceRootDirPath = sourceRootDir;
            cproj.IncludePathTokens = "Compute Network DataBox";
            cproj.IgnorePathTokens = Path.Combine(ignoreDir);

            if (cproj.Execute())
            {
                Assert.True(cproj.net452SdkProjectsToBuild.Count<ITaskItem>() >= 7);
                Assert.True(cproj.netCore20TestProjectsToBuild.Count<ITaskItem>() >= 7);
            }
        }

        [Fact]
        public void IgnoreIncludeOverlappingProjects()
        {
            SDKCategorizeProjects cproj = new SDKCategorizeProjects();
            cproj.BuildScope = "All";
            cproj.SourceRootDirPath = sourceRootDir;
            cproj.IncludePathTokens = "Compute Network DataBox";
            cproj.IgnorePathTokens = "Compute";

            if (cproj.Execute())
            {
                Assert.True(cproj.net452SdkProjectsToBuild.Count<ITaskItem>() >= 3);
                Assert.True(cproj.netCore20TestProjectsToBuild.Count<ITaskItem>() >= 3);
            }
        }

        [Fact]
        public void IgnoreExactScopedProjects()
        {
            SDKCategorizeProjects cproj = new SDKCategorizeProjects();
            cproj.BuildScope = @"SDKs\Compute";
            cproj.SourceRootDirPath = sourceRootDir;
            cproj.IgnorePathTokens = "Compute";

            if (cproj.Execute())
            {
                Assert.True(cproj.net452SdkProjectsToBuild.Count<ITaskItem>() == 0);
                Assert.True(cproj.netCore20TestProjectsToBuild.Count<ITaskItem>() == 0);
            }
        }

        [Fact]
        public void IncludeFewFromEntireScope()
        {
            SDKCategorizeProjects cproj = new SDKCategorizeProjects();
            cproj.BuildScope = @"SDKs";
            cproj.SourceRootDirPath = sourceRootDir;
            cproj.IncludePathTokens = "Search Billing DataBox";

            if (cproj.Execute())
            {
                Assert.True(cproj.net452SdkProjectsToBuild.Count<ITaskItem>() >= 8);
                Assert.True(cproj.netCore20TestProjectsToBuild.Count<ITaskItem>() >= 8);
            }
        }

        [Fact]
        public void IgnoreIncludeExactScopedProjects()
        {
            SDKCategorizeProjects cproj = new SDKCategorizeProjects();
            cproj.BuildScope = @"SDKs\Compute";
            cproj.SourceRootDirPath = sourceRootDir;
            cproj.IncludePathTokens = "Compute";
            cproj.IgnorePathTokens = "Compute";

            if (cproj.Execute())
            {
                Assert.Equal(1, cproj.net452SdkProjectsToBuild.Count<ITaskItem>());
                Assert.Equal(1, cproj.netCore20TestProjectsToBuild.Count<ITaskItem>());
            }
        }

        [Fact]
        public void IncludeOverrideScope()
        {
            SDKCategorizeProjects cproj = new SDKCategorizeProjects();
            cproj.BuildScope = @"SDKs\Network";
            cproj.SourceRootDirPath = sourceRootDir;
            cproj.IncludePathTokens = "Compute";

            if (cproj.Execute())
            {
                Assert.Empty(cproj.net452SdkProjectsToBuild);
                Assert.Empty(cproj.netCore11TestProjectsToBuild);
                //Assert.Equal(0, cproj.net452SdkProjectsToBuild.Count<ITaskItem>());
                //Assert.Equal(0, cproj.netCore11TestProjectsToBuild.Count<ITaskItem>());
            }
        }


        [Fact(Skip ="Enabled when repo is updated")]
        public void AdditionalFxProject()
        {
            string scopeDir = @"SdkCommon\Auth\Az.Auth\Az.Authentication";
            SDKCategorizeProjects cproj = new SDKCategorizeProjects();
            cproj.SourceRootDirPath = sourceRootDir;
            cproj.BuildScope = scopeDir;
            cproj.IgnorePathTokens = Path.Combine(ignoreDir);

            if (cproj.Execute())
            {
                Assert.Equal(cproj.net461SdkProjectsToBuild.Count<ITaskItem>(), 1);
                Assert.Contains(sourceRootDir, cproj.ProjectRootDir);
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
            cproj.IgnorePathTokens = Path.Combine(ignoreDir);

            if (cproj.Execute())
            {
                Assert.True(cproj.net452SdkProjectsToBuild.Count<ITaskItem>() > 0);
                Assert.True(cproj.netCore20TestProjectsToBuild.Count<ITaskItem>() > 0);
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
            cproj.IgnorePathTokens = Path.Combine(ignoreDir);

            if (cproj.Execute())
            {
                Assert.Equal(cproj.net452SdkProjectsToBuild.Count<ITaskItem>(), 1);
                Assert.Equal(cproj.netCore20TestProjectsToBuild.Count<ITaskItem>(), 1);
            }
        }

        [Fact]
        public void SDKCommonProjects()
        {
            SDKCategorizeProjects cproj = new SDKCategorizeProjects();
            cproj.SourceRootDirPath = sourceRootDir;
            cproj.BuildScope = @"SDKCommon";
            cproj.IgnorePathTokens = Path.Combine(ignoreDir);

            if (cproj.Execute())
            {
                //Since HttpRecorder and TestFramework are multi-targeting, they are no 
                //longer treated as regular nuget packages (targeting net452 and netStd1.4)
                //but rather projects that are built without any targetFx
                //
                Assert.True(cproj.net452SdkProjectsToBuild.Count<ITaskItem>() >= 7);
                Assert.True(cproj.netCore20TestProjectsToBuild.Count<ITaskItem>() >= 5);                
            }
        }

        [Fact]
        public void TestFrameworkDir()
        {
            SDKCategorizeProjects cproj = new SDKCategorizeProjects();
            cproj.SourceRootDirPath = sourceRootDir;
            cproj.BuildScope = @"SDKCommon\TestFramework";
            cproj.IgnorePathTokens = Path.Combine(ignoreDir);

            if (cproj.Execute())
            {
                //Since HttpRecorder and TestFramework are multi-targeting, they are no 
                //longer treated as regular nuget packages (targeting net452 and netStd1.4)
                //but rather projects that are build without any targetFx
                Assert.Equal(0, cproj.netStd14SdkProjectsToBuild.Count());
                Assert.Equal(2, cproj.net452SdkProjectsToBuild.Count());
                Assert.Equal(2, cproj.netCore20TestProjectsToBuild.Count<ITaskItem>());
            }
        }

        [Fact]
        public void FindTestProject()
        {
            //Operational Insights have named their projects as test.csproj rather than tests.csproj
            SDKCategorizeProjects cproj = new SDKCategorizeProjects();
            cproj.SourceRootDirPath = sourceRootDir;
            cproj.BuildScope = @"SDKs\OperationalInsights";
            cproj.IgnorePathTokens = Path.Combine(ignoreDir);

            if (cproj.Execute())
            {
                Assert.Equal(2, cproj.netStd14SdkProjectsToBuild.Count<ITaskItem>());
                Assert.Equal(2, cproj.netCore20TestProjectsToBuild.Count<ITaskItem>());
            }
        }

        [Fact]
        public void TestIgnoredTokesn()
        {
            //Gallery projects are being ignored
            SDKCategorizeProjects cproj = new SDKCategorizeProjects();
            cproj.SourceRootDirPath = sourceRootDir;
            cproj.BuildScope = @"SDKs\Gallery";
            cproj.IgnorePathTokens = @"Gallery";

            if (cproj.Execute())
            {
                Assert.Equal(0, cproj.net452SdkProjectsToBuild.Count());
                Assert.Equal(0, cproj.netCore11TestProjectsToBuild.Count());
            }
        }

        internal string GetSourceRootDir()
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
