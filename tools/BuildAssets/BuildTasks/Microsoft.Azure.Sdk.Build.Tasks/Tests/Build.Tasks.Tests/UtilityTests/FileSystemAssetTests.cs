// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Microsoft.Azure.Sdk.Build.Tasks.Utilities;
using Microsoft.Build.Evaluation;
using Microsoft.Build.Execution;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Build.Tasks.Tests.UtilityTests
{

    public class FileSystemAssetTests : IClassFixture<FileSystemAssetFixture>
    {
        FileSystemAssetFixture fixture;

        public FileSystemAssetTests(FileSystemAssetFixture fix)
        {
            this.fixture = fix;
        }

        [Fact]
        public void CreatePropsFile()
        {
            string fullFilePath = Path.Combine(Environment.GetEnvironmentVariable("Temp"), "Sample.props");
            MsBuildProjectFile msProjFile = new MsBuildProjectFile(fullFilePath);
            msProjFile.CreateEmptyFile();

            Assert.True(File.Exists(fullFilePath));
            this.fixture.AssetList.Add(fullFilePath);
            Project proj = new Project(fullFilePath);            
            Assert.NotNull(proj);

            proj = null;
        }
    }

    public class FileSystemAssetFixture : IDisposable
    {
        List<string> _assetList;
        public List<string> AssetList { get => _assetList; }

        public FileSystemAssetFixture()
        {
            _assetList = new List<string>();
        }

        public void Dispose()
        {
            foreach(string fileSysAsset in AssetList)
            {
                if(File.Exists(fileSysAsset))
                {
                    File.Delete(fileSysAsset);
                }
            }
        }
    }
}
