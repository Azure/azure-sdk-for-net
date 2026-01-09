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
    internal class DevTestLabTests : DevTestLabsManagementTestBase
    {
        private DevTestLabCollection _devTestLabCollections;
        private string _labName;

        public DevTestLabTests(bool isAsync) : base(isAsync)//, RecordedTestMode.Record)
        {
        }

        [SetUp]
        public void SetUp()
        {
            _devTestLabCollections = TestResourceGroup.GetDevTestLabs();
            _labName = TestDevTestLab.Data.Name;
        }

        [RecordedTest]
        public void CreateOrUpdate()
        {
            ValidateDevTestLab(TestDevTestLab.Data, _labName);
        }

        [RecordedTest]
        public async Task Exist()
        {
            var flag = await _devTestLabCollections.ExistsAsync(_labName);
            Assert.That((bool)flag, Is.True);
        }

        [RecordedTest]
        public async Task Get()
        {
            var getlab = await _devTestLabCollections.GetAsync(_labName);
            ValidateDevTestLab(getlab.Value.Data, _labName);
        }

        [RecordedTest]
        public async Task GetAll()
        {
            var first = (await _devTestLabCollections.GetAllAsync().ToEnumerableAsync()).FirstOrDefault();
            ValidateDevTestLab(first.Data, _labName);
        }

        [RecordedTest]
        public async Task Delete()
        {
            await DeleteAllLocks(TestResourceGroup);
            await TestDevTestLab.DeleteAsync(WaitUntil.Completed);
            bool flag = await _devTestLabCollections.ExistsAsync(_labName);
            Assert.That(flag, Is.False);
        }

        [TestCase(null)]
        [TestCase(false)]
        [TestCase(true)]
        public async Task AddRemoveTag(bool? useTagResource)
        {
            SetTagResourceUsage(Client, useTagResource);
            string _labName = Recording.GenerateAssetName("lab");
            var lab = await CreateDevTestLab(TestResourceGroup, _labName);

            // AddTag
            await lab.AddTagAsync("addtagkey", "addtagvalue");
            lab = await _devTestLabCollections.GetAsync(_labName);
            Assert.That(lab.Data.Tags, Has.Count.EqualTo(1));
            KeyValuePair<string, string> tag = lab.Data.Tags.Where(tag => tag.Key == "addtagkey").FirstOrDefault();
            Assert.Multiple(() =>
            {
                Assert.That(tag.Key, Is.EqualTo("addtagkey"));
                Assert.That(tag.Value, Is.EqualTo("addtagvalue"));
            });

            // RemoveTag
            await lab.RemoveTagAsync("addtagkey");
            lab = await _devTestLabCollections.GetAsync(_labName);
            Assert.That(lab.Data.Tags.Count, Is.EqualTo(0));
        }

        private void ValidateDevTestLab(DevTestLabData lab, string labName)
        {
            Assert.That(lab, Is.Not.Null);
            Assert.Multiple(() =>
            {
                Assert.That(lab.CreatedOn, Is.Not.Null);
                Assert.That((string)lab.Id, Is.Not.Empty);
                Assert.That(lab.Name, Is.EqualTo(labName));
                Assert.That(lab.PremiumDataDisks, Is.EqualTo(DevTestLabPremiumDataDisk.Disabled));
                Assert.That(lab.ProvisioningState, Is.EqualTo("Succeeded"));
            });
        }
    }
}
