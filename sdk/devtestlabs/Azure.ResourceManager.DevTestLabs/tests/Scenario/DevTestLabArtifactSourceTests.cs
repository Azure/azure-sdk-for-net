// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.ResourceManager.DevTestLabs.Models;
using Azure.ResourceManager.Resources;
using NUnit.Framework;

namespace Azure.ResourceManager.DevTestLabs.Tests
{
    [NonParallelizable]
    internal class DevTestLabArtifactSourceTests : DevTestLabsManagementTestBase
    {
        private DevTestLabArtifactSourceCollection _artifactSourceCollection => TestDevTestLab.GetDevTestLabArtifactSources();
        public DevTestLabArtifactSourceTests(bool isAsync) : base(isAsync)
        {
        }

        [RecordedTest]
        public async Task ExistGetGetAll()
        {
            // GetAll
            var first = (await _artifactSourceCollection.GetAllAsync().ToEnumerableAsync()).FirstOrDefault();
            string artifactSourceName = first.Data.Name;
            ValidateDevTestLabArtifactSource(first.Data, artifactSourceName);

            // Exist
            bool flag = await _artifactSourceCollection.ExistsAsync(artifactSourceName);
            Assert.IsTrue(flag);

            // Get
            var artifactSource = await _artifactSourceCollection.GetAsync(artifactSourceName);
            ValidateDevTestLabArtifactSource(artifactSource.Value.Data, artifactSourceName);
        }

        private void ValidateDevTestLabArtifactSource(DevTestLabArtifactSourceData artifactSource, string artifactSourceName)
        {
            Assert.IsNotNull(artifactSource);
            Assert.IsNotEmpty(artifactSource.Id);
            Assert.AreEqual(artifactSourceName, artifactSource.Name);
            Assert.AreEqual(DevTestLabSourceControlType.GitHub, artifactSource.SourceType);
            Assert.AreEqual(DevTestLabEnableStatus.Enabled, artifactSource.Status);
        }
    }
}
