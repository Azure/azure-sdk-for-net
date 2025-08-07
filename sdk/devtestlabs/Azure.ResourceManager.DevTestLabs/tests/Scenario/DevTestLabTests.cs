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
            Assert.IsTrue(flag);
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
            Assert.IsFalse(flag);
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
            Assert.AreEqual(1, lab.Data.Tags.Count);
            KeyValuePair<string, string> tag = lab.Data.Tags.Where(tag => tag.Key == "addtagkey").FirstOrDefault();
            Assert.AreEqual("addtagkey", tag.Key);
            Assert.AreEqual("addtagvalue", tag.Value);

            // RemoveTag
            await lab.RemoveTagAsync("addtagkey");
            lab = await _devTestLabCollections.GetAsync(_labName);
            Assert.AreEqual(0, lab.Data.Tags.Count);
        }

        private void ValidateDevTestLab(DevTestLabData lab, string labName)
        {
            Assert.IsNotNull(lab);
            Assert.IsNotNull(lab.CreatedOn);
            Assert.IsNotEmpty(lab.Id);
            Assert.AreEqual(labName, lab.Name);
            Assert.AreEqual(DevTestLabPremiumDataDisk.Disabled, lab.PremiumDataDisks);
            Assert.AreEqual("Succeeded", lab.ProvisioningState);
        }
    }
}
