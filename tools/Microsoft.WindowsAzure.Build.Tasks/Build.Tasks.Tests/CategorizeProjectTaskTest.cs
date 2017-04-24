using Microsoft.WindowsAzure.Build.Tasks;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using System.Reflection;
using System.IO;
using System.Linq;
using Microsoft.Build.Framework;

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
            //ignoreDir = Path.Combine(sourceRootDir, @"SDKs\KeyVault\dataPlane\Microsoft.Azure.KeyVault.Samples");
            ignoreDir = @"Microsoft.Azure.KeyVault.Samples";
        }
        [Fact]
        public void CategorizeProjects()
        {
            CategorizeProjects cproj = new CategorizeProjects();
            cproj.SourceRootDirPath = sourceRootDir;
            cproj.BuildScope = "All";
            cproj.IgnoreDirForSearchingProjects = Path.Combine(ignoreDir);

            if(cproj.Execute())
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
        public void ScopedProject()
        {
            CategorizeProjects cproj = new CategorizeProjects();
            cproj.SourceRootDirPath = sourceRootDir;
            cproj.BuildScope = @"SDKs\Compute";
            cproj.IgnoreDirForSearchingProjects = Path.Combine(ignoreDir);

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
            CategorizeProjects cproj = new CategorizeProjects();
            cproj.SourceRootDirPath = sourceRootDir;
            cproj.BuildScope = @"SDKs\KeyVault\dataPlane";
            cproj.IgnoreDirForSearchingProjects = Path.Combine(ignoreDir);

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
            CategorizeProjects cproj = new CategorizeProjects();
            cproj.SourceRootDirPath = sourceRootDir;
            cproj.BuildScope = @"SDKCommon\ClientRuntime";
            cproj.IgnoreDirForSearchingProjects = Path.Combine(ignoreDir);

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
            CategorizeProjects cproj = new CategorizeProjects();
            cproj.SourceRootDirPath = sourceRootDir;
            cproj.BuildScope = @"SDKCommon";
            cproj.IgnoreDirForSearchingProjects = Path.Combine(ignoreDir);

            if (cproj.Execute())
            {
                Assert.True(cproj.SDKProjectsToBuild.Count<ITaskItem>() == 5);
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
            CategorizeProjects cproj = new CategorizeProjects();
            cproj.SourceRootDirPath = sourceRootDir;
            cproj.BuildScope = @"SDKCommon\TestFramework";
            cproj.IgnoreDirForSearchingProjects = Path.Combine(ignoreDir);

            if (cproj.Execute())
            {
                Assert.True(cproj.SDKProjectsToBuild.Count<ITaskItem>() == 2);
                Assert.True(cproj.SDKTestProjectsToBuild.Count<ITaskItem>() ==3);
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
