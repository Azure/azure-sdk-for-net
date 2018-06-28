// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Microsoft.Azure.Sdk.Build.Tasks.Models;
using Microsoft.WindowsAzure.Build.Tasks;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Build.Tasks.Tests
{
    public class SdkMetaDataTests
    {
        internal string sourceRootDir = string.Empty;
        internal string ignoreDir = string.Empty;

        public SdkMetaDataTests()
        {
            sourceRootDir = GetSourceRootDir();
            sourceRootDir = Path.Combine(sourceRootDir, "src");
            ignoreDir = @"Microsoft.Azure.KeyVault.Samples";
        }


        [Fact]
        public void SdkProject()
        {
            SDKCategorizeProjects catProj = GetProject(@"SDKs\Compute");

            string projFullPath = catProj.net452SdkProjectsToBuild.First().ItemSpec;
            SdkProjectMetaData metaProj = new SdkProjectMetaData(projFullPath, TargetFrameworkMoniker.net452);

            Assert.Equal(TargetFrameworkMoniker.net452, metaProj.FxMoniker);
            Assert.NotNull(metaProj.MsBuildProject);
            Assert.Equal(true, metaProj.IsFxFullDesktopVersion);
            Assert.Equal(false, metaProj.IsFxNetCore);
            Assert.Equal(false, metaProj.IsProjectDataPlane);
        }


        [Fact]
        public void DataPlaneSdkProject()
        {
            SDKCategorizeProjects catProj = GetProject(@"SDKs\Keyvault\dataPlane");

            string projFullPath = catProj.net452SdkProjectsToBuild.First().ItemSpec;
            SdkProjectMetaData metaProj = new SdkProjectMetaData(projFullPath, TargetFrameworkMoniker.net452);

            Assert.Equal(TargetFrameworkMoniker.net452, metaProj.FxMoniker);
            Assert.NotNull(metaProj.MsBuildProject);
            Assert.Equal(true, metaProj.IsFxFullDesktopVersion);
            Assert.Equal(false, metaProj.IsFxNetCore);
            Assert.Equal(true, metaProj.IsProjectDataPlane);
        }

        public SDKCategorizeProjects GetProject(string scope)
        {
            SDKCategorizeProjects cproj = new SDKCategorizeProjects();
            cproj.SourceRootDirPath = sourceRootDir;
            cproj.BuildScope = scope;
            cproj.IgnorePathTokens = Path.Combine(ignoreDir);
            cproj.Execute();
            return cproj;
        }

        internal string GetSourceRootDir()
        {
            string srcRootDir = string.Empty;
            string currDir = Directory.GetCurrentDirectory();

            if (!Directory.Exists(currDir))
            {
                currDir = Path.GetDirectoryName(this.GetType().GetTypeInfo().Assembly.Location);
            }

            string dirRoot = Directory.GetDirectoryRoot(currDir);

            var buildProjFile = Directory.EnumerateFiles(currDir, "build.proj", SearchOption.TopDirectoryOnly);

            while (currDir != dirRoot)
            {
                if (buildProjFile.Any<string>())
                {
                    srcRootDir = Path.GetDirectoryName(buildProjFile.First<string>());
                    break;
                }

                currDir = Directory.GetParent(currDir).FullName;
                buildProjFile = Directory.EnumerateFiles(currDir, "build.proj", SearchOption.TopDirectoryOnly);
            }

            if (string.IsNullOrEmpty(srcRootDir))
            {
                srcRootDir = @"C:\MyFork\vs17Dev";
            }

            return srcRootDir;
        }
    }
}
