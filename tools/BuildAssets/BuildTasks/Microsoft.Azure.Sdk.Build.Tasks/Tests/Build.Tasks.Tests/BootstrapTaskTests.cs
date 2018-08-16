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

        // Ensure we do not change case of the URL while accessing git. 
        // Since "azuRe" doesn't exist, build tools will not be installed
        [Fact]
        public void CopyFilesFromGitHubCaseInsensitive()
        {
            string localBranchDir = new Uri(Path.GetDirectoryName(Assembly.GetExecutingAssembly().CodeBase)).AbsolutePath;
            string remoteRootDir = @"https://raw.githubusercontent.com/azuRe/azure-sdk-for-net/psSdkJson6/";
            Assert.False(string.IsNullOrEmpty(localBranchDir) && Directory.Exists(localBranchDir));
            GetBuildTools getBldTools = new GetBuildTools(localBranchDir, remoteRootDir);
            getBldTools.Execute();
            var sdkBuildToolsDir = Path.Combine(localBranchDir, @"tools\SdkBuildTools");
            Assert.Empty(Directory.GetFiles(sdkBuildToolsDir));
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

        [Fact]
        public void GetRemoteUri()
        {
            string localBranchRootDir = GetSourceRootDir();
            Assert.False(string.IsNullOrEmpty(localBranchRootDir));
            
            GetBuildTools getBldTools = new GetBuildTools();
            getBldTools.LocalBranchRootDir = localBranchRootDir;
            getBldTools.WhatIf = true;
            getBldTools.OverrideLocal = true;

            getBldTools.Execute();
            Assert.NotNull(getBldTools.RemoteCopyFromRootDir);
            Assert.StartsWith("http", getBldTools.RemoteCopyFromRootDir, StringComparison.OrdinalIgnoreCase);

            Assert.False(getBldTools.RemoteCopyFromRootDir.EndsWith("readme.md", StringComparison.OrdinalIgnoreCase));

            Assert.NotNull(getBldTools.LocalBranchCopyToRootDir);
        }

        [Fact]
        public void OverrideLocal()
        {
            string localBranchRootDir = GetSourceRootDir();
            Assert.False(string.IsNullOrEmpty(localBranchRootDir));

            GetBuildTools getBldTools = new GetBuildTools();
            getBldTools.LocalBranchRootDir = localBranchRootDir;
            getBldTools.WhatIf = true;
            getBldTools.OverrideLocal = false;

            getBldTools.Execute();
            Assert.NotNull(getBldTools.RemoteCopyFromRootDir);
            Assert.False(getBldTools.RemoteCopyFromRootDir.StartsWith("http"));

            Assert.NotNull(getBldTools.LocalBranchCopyToRootDir);
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
