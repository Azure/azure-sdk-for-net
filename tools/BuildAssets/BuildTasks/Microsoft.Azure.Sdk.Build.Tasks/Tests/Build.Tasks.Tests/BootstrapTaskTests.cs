// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Build.Tasks.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using Xunit;
    using System.Reflection;
    using System.IO;
    using System.Linq;
    using Microsoft.Build.Framework;
    using Microsoft.Build.Evaluation;
    using Microsoft.Azure.Build.BootstrapTasks;

    public class BootstrapTaskTests
    {
        [Fact]
        public void CopyDefaultFiles()
        {
            string localBranchDir = GetSourceRootDir();
            Assert.False(string.IsNullOrEmpty(localBranchDir));
            string remoteDir = localBranchDir;
            GetBuildTools getBldTools = new Microsoft.Azure.Build.BootstrapTasks.GetBuildTools(localBranchDir, remoteDir);            
            getBldTools.Execute();

            Assert.False(getBldTools.unableToCopyFilePath.Count > 0);
        }

        [Fact]
        public void CopyFilesTwice()
        {
            string localBranchDir = GetSourceRootDir();
            Assert.False(string.IsNullOrEmpty(localBranchDir));
            GetBuildTools getBldTools = new Microsoft.Azure.Build.BootstrapTasks.GetBuildTools(localBranchDir, localBranchDir);
            getBldTools.Execute();
            Assert.False(getBldTools.unableToCopyFilePath.Count > 0);
            getBldTools.Execute();
            Assert.False(getBldTools.unableToCopyFilePath.Count > 0);
        }

        [Fact]
        public void CopyFilesFromGitHub()
        {
            string localBranchDir = GetSourceRootDir();
            string remoteRootDir = @"https://raw.githubusercontent.com/shahabhijeet/azure-sdk-for-net/addSep/";
            Assert.False(string.IsNullOrEmpty(localBranchDir));
            GetBuildTools getBldTools = new GetBuildTools(localBranchDir, remoteRootDir);
            getBldTools.Execute();
            Assert.False(getBldTools.unableToCopyFilePath.Count > 0);
        }

        [Fact]
        public void CopyFilesFromLocalDir()
        {
            string localBranchDir = GetSourceRootDir();
            Assert.False(string.IsNullOrEmpty(localBranchDir));

            string remoteRootDir = new Uri(Path.Combine(Directory.GetCurrentDirectory(), "BootStrapperTestResources")).LocalPath;
            GetBuildTools getBldTools = new GetBuildTools(localBranchDir, remoteRootDir);
            getBldTools.Execute();
            Assert.True(getBldTools.unableToCopyFilePath.Count > 0);
        }

        private string GetSourceRootDir()
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

            return srcRootDir;
        }
    }
}
