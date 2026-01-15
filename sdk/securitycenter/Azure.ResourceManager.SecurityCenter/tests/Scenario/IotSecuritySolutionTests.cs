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
using Azure.ResourceManager.SecurityCenter;
using NUnit.Framework;

namespace Azure.ResourceManager.SecurityCenter.Tests
{
    internal class IotSecuritySolutionTests : SecurityCenterManagementTestBase
    {
        private ResourceGroupResource _resourceGroup;
        private IotSecuritySolutionCollection _iotSecuritySolutionCollection;
        private IotHubDescriptionResource _iotHub;

        public IotSecuritySolutionTests(bool isAsync) : base(isAsync)//, RecordedTestMode.Record)
        {
        }

        [SetUp]
        public async Task TestSetUp()
        {
            _resourceGroup = await CreateResourceGroup();
            _iotSecuritySolutionCollection = _resourceGroup.GetIotSecuritySolutions();
            _iotHub = await CreateIotHub(_resourceGroup, Recording.GenerateAssetName("iothub"));
        }

        [RecordedTest]
        public async Task CreateOrUpdate()
        {
            string solutionName = Recording.GenerateAssetName("solution");
            var solution = await CreateIotSecuritySolution(_resourceGroup, _iotHub.Data.Id, solutionName);
            ValidateIotSecuritySolutionResource(solution, solutionName);
        }

        [RecordedTest]
        public async Task Exist()
        {
            string solutionName = Recording.GenerateAssetName("solution");
            var solution = await CreateIotSecuritySolution(_resourceGroup, _iotHub.Data.Id, solutionName);
            bool flag = await _iotSecuritySolutionCollection.ExistsAsync(solutionName);
            Assert.That(flag, Is.True);
        }

        [RecordedTest]
        public async Task Get()
        {
            string solutionName = Recording.GenerateAssetName("solution");
            await CreateIotSecuritySolution(_resourceGroup, _iotHub.Data.Id, solutionName);
            var solution = await _iotSecuritySolutionCollection.GetAsync(solutionName);
            ValidateIotSecuritySolutionResource(solution, solutionName);
        }

        [RecordedTest]
        public async Task GetAll()
        {
            string solutionName = Recording.GenerateAssetName("solution");
            var solution = await CreateIotSecuritySolution(_resourceGroup, _iotHub.Data.Id, solutionName);
            var list = await _iotSecuritySolutionCollection.GetAllAsync().ToEnumerableAsync();
            Assert.IsNotEmpty(list);
            ValidateIotSecuritySolutionResource(list.First(item => item.Data.Name == solutionName), solutionName);
        }

        [RecordedTest]
        public async Task Delete()
        {
            string solutionName = Recording.GenerateAssetName("solution");
            var solution = await CreateIotSecuritySolution(_resourceGroup, _iotHub.Data.Id, solutionName);
            bool flag = await _iotSecuritySolutionCollection.ExistsAsync(solutionName);
            Assert.That(flag, Is.True);

            await solution.DeleteAsync(WaitUntil.Completed);
            flag = await _iotSecuritySolutionCollection.ExistsAsync(solutionName);
            Assert.That(flag, Is.False);
        }

        [TestCase(null)]
        [TestCase(false)]
        [TestCase(true)]
        public async Task AddRemoveTag(bool? useTagResource)
        {
            SetTagResourceUsage(Client, useTagResource);
            string solutionName = Recording.GenerateAssetName("solution");
            var solution = await CreateIotSecuritySolution(_resourceGroup, _iotHub.Data.Id, solutionName);

            if (useTagResource == true || useTagResource == null)
            {
                // REST api doesn't support [/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Security/iotSecuritySolutions/{solutionName}] to add tags.
                Assert.ThrowsAsync<RequestFailedException>(() => solution.AddTagAsync("addtagkey", "addtagvalue"));
                return;
            }

            // AddTag
            await solution.AddTagAsync("addtagkey", "addtagvalue");
            solution = await _iotSecuritySolutionCollection.GetAsync(solutionName);
            Assert.That(solution.Data.Tags.Count, Is.EqualTo(1));
            KeyValuePair<string, string> tag = solution.Data.Tags.Where(tag => tag.Key == "addtagkey").FirstOrDefault();
            Assert.That(tag.Key, Is.EqualTo("addtagkey"));
            Assert.That(tag.Value, Is.EqualTo("addtagvalue"));

            // RemoveTag
            await solution.RemoveTagAsync("addtagkey");
            solution = await _iotSecuritySolutionCollection.GetAsync(solutionName);
            Assert.That(solution.Data.Tags.Count, Is.EqualTo(0));
        }

        private void ValidateIotSecuritySolutionResource(IotSecuritySolutionResource solution, string solutionName)
        {
            Assert.IsNotNull(solution);
            Assert.IsNotNull(solution.Data.Id);
            Assert.That(solution.Data.Name, Is.EqualTo(solutionName));
            Assert.That(solution.Data.DisplayName, Is.EqualTo(solutionName));
            Assert.That(solution.Data.IotHubs.Count, Is.EqualTo(1));
            Assert.That(solution.Data.Location, Is.EqualTo(_resourceGroup.Data.Location));
            Assert.That(solution.Data.ResourceType.ToString(), Is.EqualTo("Microsoft.Security/iotSecuritySolutions"));
            Assert.That(solution.Data.Status.ToString(), Is.EqualTo("Enabled"));
        }
    }
}
