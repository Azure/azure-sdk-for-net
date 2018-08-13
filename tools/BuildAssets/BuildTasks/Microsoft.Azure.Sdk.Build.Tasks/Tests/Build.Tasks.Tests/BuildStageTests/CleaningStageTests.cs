// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Microsoft.Azure.Sdk.Build.ExecProcess;
using Microsoft.Azure.Sdk.Build.Tasks.BuildStages;
using Microsoft.Build.Framework;
using Microsoft.WindowsAzure.Build.Tasks;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Build.Tasks.Tests.BuildStageTests
{
    public class CleanRestoredPackageTests: BuildTestBase
    {
        string IgnoreDirTokens = @"Microsoft.Azure.KeyVault.Samples";
        public CleanRestoredPackageTests()
        {

        }

        [Fact]
        public void CleanScopedPackages()
        {
            SDKCategorizeProjects catProj = CategorizeProjects(@"SDKs\Network");
            List<string> pkgRefList = catProj.AzSdkPackageList.Select<ITaskItem, string>((item) => item.ItemSpec.ToString())?.ToList<string>();

            List<string> projList = catProj.net452SdkProjectsToBuild.Select<ITaskItem, string>((item) => item.ItemSpec).ToList<string>();

            NugetExec nExec = new NugetExec();
            NugetProcStatus procStatus = nExec.RestoreProject(projList);
            //Assert.Equal(0, procStatus.ExitCode);

            List<string> cacheLocations = new List<string>() { RepoRestoreDir };

            foreach (string pkgName in pkgRefList)
            {
                string pkgNameDirPath = Path.Combine(RepoRestoreDir, pkgName);
                Assert.Equal(true, Directory.Exists(pkgNameDirPath));
            }

            CleanPackagesTask cleanTsk = new CleanPackagesTask();
            cleanTsk.PackageReferences = pkgRefList.ToArray<string>();
            cleanTsk.RestoreCacheLocations = cacheLocations.ToArray<string>();

            cleanTsk.Execute();

            foreach (string cacheLocation in cacheLocations)
            {
                foreach (string pkgName in pkgRefList)
                {
                    string pkgNameDirPath = Path.Combine(cacheLocation, pkgName);
                    Assert.Equal(false, Directory.Exists(pkgNameDirPath));
                }
            }
        }


        private SDKCategorizeProjects CategorizeProjects(string scope)
        {
            string scopeDir = scope;
            SDKCategorizeProjects cproj = new SDKCategorizeProjects();
            cproj.SourceRootDirPath = SourceRootDir;
            cproj.BuildScope = scopeDir;
            cproj.IgnorePathTokens = Path.Combine(IgnoreDirTokens);

            cproj.Execute();

            Assert.NotNull(cproj);

            return cproj;
        }

    }
}