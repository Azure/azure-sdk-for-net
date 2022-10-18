// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.ResourceManager.IotHub;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.SecurityCenter.Models;
using NUnit.Framework;

namespace Azure.ResourceManager.SecurityCenter.Tests
{
    internal class IotSecuritySolutionModelTests : SecurityCenterManagementTestBase
    {
        private ResourceGroupResource _resourceGroup;
        private IotSecuritySolutionModelCollection _iotSecuritySolutionModelCollection;
        private IotHubDescriptionResource _iotHub;

        public IotSecuritySolutionModelTests(bool isAsync) : base(isAsync)//, RecordedTestMode.Record)
        {
        }

        [SetUp]
        public async Task TestSetUp()
        {
            _resourceGroup = await CreateResourceGroup();
            _iotSecuritySolutionModelCollection = _resourceGroup.GetIotSecuritySolutionModels();
            _iotHub = await CreateIotHub(_resourceGroup, Recording.GenerateAssetName("iothub"));
        }

        [RecordedTest]
        public async Task CreateOrUpdate()
        {
            string solutionModelName = Recording.GenerateAssetName("solution");
            var solutionModel = await CreateIotSecuritySolutionModel(_resourceGroup, _iotHub.Data.Id, solutionModelName);
            ValidateIotSecuritySolutionModelResource(solutionModel, solutionModelName);
        }

        [RecordedTest]
        public async Task Exist()
        {
            string solutionModelName = Recording.GenerateAssetName("solution");
            var solutionModel = await CreateIotSecuritySolutionModel(_resourceGroup, _iotHub.Data.Id, solutionModelName);
            bool flag = await _iotSecuritySolutionModelCollection.ExistsAsync(solutionModelName);
            Assert.IsTrue(flag);
        }

        [RecordedTest]
        public async Task Get()
        {
            string solutionModelName = Recording.GenerateAssetName("solution");
            await CreateIotSecuritySolutionModel(_resourceGroup, _iotHub.Data.Id, solutionModelName);
            var solutionModel = await _iotSecuritySolutionModelCollection.GetAsync(solutionModelName);
            ValidateIotSecuritySolutionModelResource(solutionModel, solutionModelName);
        }

        [RecordedTest]
        public async Task GetAll()
        {
            string solutionModelName = Recording.GenerateAssetName("solution");
            var solutionModel = await CreateIotSecuritySolutionModel(_resourceGroup, _iotHub.Data.Id, solutionModelName);
            var list = await _iotSecuritySolutionModelCollection.GetAllAsync().ToEnumerableAsync();
            Assert.IsNotEmpty(list);
            ValidateIotSecuritySolutionModelResource(list.First(item => item.Data.Name == solutionModelName), solutionModelName);
        }

        [RecordedTest]
        public async Task Delete()
        {
            string solutionModelName = Recording.GenerateAssetName("solution");
            var solutionModel = await CreateIotSecuritySolutionModel(_resourceGroup, _iotHub.Data.Id, solutionModelName);
            bool flag = await _iotSecuritySolutionModelCollection.ExistsAsync(solutionModelName);
            Assert.IsTrue(flag);

            await solutionModel.DeleteAsync(WaitUntil.Completed);
            flag = await _iotSecuritySolutionModelCollection.ExistsAsync(solutionModelName);
            Assert.IsFalse(flag);
        }

        private void ValidateIotSecuritySolutionModelResource(IotSecuritySolutionModelResource solutionModel, string solutionModelName)
        {
            Assert.IsNotNull(solutionModel);
            Assert.IsNotNull(solutionModel.Data.Id);
            Assert.AreEqual(solutionModelName, solutionModel.Data.Name);
            Assert.AreEqual(solutionModelName, solutionModel.Data.DisplayName);
            Assert.AreEqual(1, solutionModel.Data.IotHubs.Count);
            Assert.AreEqual(_resourceGroup.Data.Location, solutionModel.Data.Location);
            Assert.AreEqual("Microsoft.Security/iotSecuritySolutions", solutionModel.Data.ResourceType.ToString());
            Assert.AreEqual("Enabled", solutionModel.Data.Status.ToString());
        }
    }
}
