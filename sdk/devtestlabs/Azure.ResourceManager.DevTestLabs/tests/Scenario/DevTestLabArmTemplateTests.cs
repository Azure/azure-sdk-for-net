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
    internal class DevTestLabArmTemplateTests : DevTestLabsManagementTestBase
    {
        private DevTestLabArmTemplateCollection _armTemplateCollection;
        public DevTestLabArmTemplateTests(bool isAsync) : base(isAsync)
        {
        }

        [SetUp]
        public async Task SetUp()
        {
            var artifactSources = await TestDevTestLab.GetDevTestLabArtifactSources().GetAllAsync().ToEnumerableAsync();
            _armTemplateCollection = artifactSources[1].GetDevTestLabArmTemplates();
        }

        [RecordedTest]
        public async Task ExistGetGetAll()
        {
            // GetAll
            var first = (await _armTemplateCollection.GetAllAsync().ToEnumerableAsync()).FirstOrDefault();
            string templateName = first.Id.Name;
            ValidateDevTestLabArmTemplate(first.Data, templateName);

            // Exist
            bool flag = await _armTemplateCollection.ExistsAsync(templateName);
            Assert.IsTrue(flag);

            // Get
            var template = await _armTemplateCollection.GetAsync(templateName);
            ValidateDevTestLabArmTemplate(template.Value.Data, templateName);
        }

        private void ValidateDevTestLabArmTemplate(DevTestLabArmTemplateData template, string templateName)
        {
            Assert.IsNotNull(template);
            Assert.IsNotEmpty(template.Id);
            Assert.IsNotEmpty(template.Publisher);
            Assert.AreEqual(templateName, template.Name);
            Assert.AreEqual(true, template.IsEnabled);
        }
    }
}
