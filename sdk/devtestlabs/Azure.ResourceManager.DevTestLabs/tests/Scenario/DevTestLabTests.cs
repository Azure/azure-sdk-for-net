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
    internal class DevTestLabTests : DevTestLabsManagementTestBase
    {
        private DevTestLabCollection _devTestLabCollections = null;
        public DevTestLabTests(bool isAsync) : base(isAsync)
        {
        }

        [SetUp]
        public async Task SetUp()
        {
            TestResourceGroup = await CreateResourceGroup();
            _devTestLabCollections = TestResourceGroup.GetDevTestLabs();
        }

        [RecordedTest]
        public async Task CreateOrUpdateExistGetGetAllDelete()
        {
            // CreateOrUpdate
            string labName = Recording.GenerateAssetName("lab");
            var lab = await CreateDevTestLab(TestResourceGroup, labName);

            // Exist
            var flag = await _devTestLabCollections.ExistsAsync(labName);
            Assert.IsTrue(flag);

            // Get
            var getlab = await _devTestLabCollections.GetAsync(labName);
            ValidateDevTestLab(getlab.Value.Data, labName);

            // GetAll
            var list = await _devTestLabCollections.GetAllAsync().ToEnumerableAsync();
            Assert.IsNotEmpty(list);
            ValidateDevTestLab(list.FirstOrDefault().Data, labName);

            // Delete
            await DeleteAllLocks(TestResourceGroup);
            await lab.DeleteAsync(WaitUntil.Completed);
            flag = await _devTestLabCollections.ExistsAsync(labName);
            Assert.IsFalse(flag);
        }

        [TestCase(null)]
        [TestCase(false)]
        [TestCase(true)]
        public async Task AddRemoveTag(bool? useTagResource)
        {
            SetTagResourceUsage(Client, useTagResource);
            string labName = Recording.GenerateAssetName("lab");
            var lab = await CreateDevTestLab(TestResourceGroup, labName);

            // AddTag
            await lab.AddTagAsync("addtagkey", "addtagvalue");
            lab = await _devTestLabCollections.GetAsync(labName);
            Assert.AreEqual(1, lab.Data.Tags.Count);
            KeyValuePair<string, string> tag = lab.Data.Tags.Where(tag => tag.Key == "addtagkey").FirstOrDefault();
            Assert.AreEqual("addtagkey", tag.Key);
            Assert.AreEqual("addtagvalue", tag.Value);

            // RemoveTag
            await lab.RemoveTagAsync("addtagkey");
            lab = await _devTestLabCollections.GetAsync(labName);
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
