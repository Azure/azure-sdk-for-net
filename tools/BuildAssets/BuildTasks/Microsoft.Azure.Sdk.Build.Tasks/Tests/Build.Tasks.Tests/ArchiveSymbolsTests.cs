// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Build.Tasks.Tests
{
    using Microsoft.Azure.Sdk.Build.Tasks;
    using Microsoft.Build.Framework;
    using Microsoft.Build.Utilities;
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Runtime.InteropServices;
    using System.Text;
    using System.Threading.Tasks;
    using Xunit;

    public class ArchiveSymbolsTests : BuildTestBase
    {
        /// <summary>
        /// This test will only create all the files that are required to submit request for symbol archive
        /// In order to send the request, provide a valid UNC path (cannot be a local file path)
        /// @"Valid UNC Path" (e.g. \\someshare\someDir)
        /// </summary>
        [Fact]
        public void CreateSymbolRequest()
        {
            string outputDir = this.TestBinaryOutputDir;
            IEnumerable<ITaskItem> files = Directory.EnumerateFiles(outputDir).Select<string, ITaskItem>((item) => new TaskItem(item));
            ArchiveSymbolsTask symTsk = new ArchiveSymbolsTask();

            symTsk.PublishSymbolStatusEmailTo = "sampleEmail@testDomain.com";
            symTsk.SymbolsArchiveRootDir = System.Environment.GetEnvironmentVariable("temp");
            symTsk.SkipExecuteSymbolRequest = true;
            symTsk.BuiltAssemblyFileCollection = files.ToArray<ITaskItem>();
            symTsk.Execute();

            Assert.True(symTsk.SymbolRequestFileList.Count > 0);
        }

        [Fact]
        public void CreateErrorSymbolRequest()
        {
            string outputDir = this.TestBinaryOutputDir;
            string localTempPath = System.Environment.GetEnvironmentVariable("temp");
            string localUNCPath = GetLocalUNCPath(localTempPath);

            IEnumerable<ITaskItem> files = Directory.EnumerateFiles(outputDir).Select<string, ITaskItem>((item) => new TaskItem(item));
            ArchiveSymbolsTask symTsk = new ArchiveSymbolsTask();
            symTsk.PublishSymbolStatusEmailTo = "sampleEmail@testDomain.com";
            symTsk.SymbolsArchiveRootDir = localUNCPath;
            symTsk.SymbolReqProjectName = "SomeRandomProjectName";
            symTsk.BuiltAssemblyFileCollection = files.ToArray<ITaskItem>();
            Assert.Throws<ApplicationException>(() => symTsk.Execute());
        }

        /// <summary>
        /// Quick and dirty way to get local UNC path
        /// WNetGetUniversalNameA(mpr.dll) is failing and unable to get UNC path successfully
        /// </summary>
        /// <param name="localPath"></param>
        /// <returns></returns>
        private string GetLocalUNCPath(string localPath)
        {
            string computerName = System.Environment.GetEnvironmentVariable("COMPUTERNAME");
            string systemDrive = System.Environment.GetEnvironmentVariable("SystemDrive");
            systemDrive = systemDrive.Replace(":", "");
            string newLocalPath = localPath.Remove(0, 2);
            string newUncPath = string.Format(@"\\{0}\{1}$\{2}", computerName, systemDrive, newLocalPath);
            return newUncPath;
        }
    }
}
