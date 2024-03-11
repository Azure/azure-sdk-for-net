// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Resources;
using NUnit.Framework;

namespace Azure.ResourceManager.DevTestLabs.Tests
{
    [NonParallelizable]
    internal class DevTestLabArtifactTests : DevTestLabsManagementTestBase
    {
        private DevTestLabArtifactCollection _artifactCollection;
        public DevTestLabArtifactTests(bool isAsync) : base(isAsync)
        {
        }

        [SetUp]
        public async Task SetUp()
        {
            var artifactSources = await TestDevTestLab.GetDevTestLabArtifactSources().GetAllAsync().ToEnumerableAsync();
            _artifactCollection = artifactSources[0].GetDevTestLabArtifacts();
        }

        [RecordedTest]
        public async Task ExistGetGetAll()
        {
            // GetAll
            var list = await _artifactCollection.GetAllAsync().ToEnumerableAsync();
            string artifactName = list.FirstOrDefault().Id.Name;
            ValidateDevTestLabArtifact(list.FirstOrDefault().Data, artifactName);

            // Exist
            bool flag = await _artifactCollection.ExistsAsync(artifactName);
            Assert.IsTrue(flag);

            // Get
            var artifactSource = await _artifactCollection.GetAsync(artifactName);
            ValidateDevTestLabArtifact(artifactSource.Value.Data, artifactName);
        }

        private void ValidateDevTestLabArtifact(DevTestLabArtifactData artifact, string artifactName)
        {
            Assert.IsNotNull(artifact);
            Assert.IsNotEmpty(artifact.Id);
            Assert.IsNotEmpty(artifact.FilePath);
            Assert.IsNotEmpty(artifact.Icon);
            Assert.IsNotEmpty(artifact.Publisher);
            Assert.AreEqual(artifactName, artifact.Name);
        }
    }
}
