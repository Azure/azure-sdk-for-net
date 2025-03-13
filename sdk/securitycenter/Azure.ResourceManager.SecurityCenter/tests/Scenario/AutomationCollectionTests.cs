// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.SecurityCenter.Models;
using NUnit.Framework;

namespace Azure.ResourceManager.SecurityCenter.Tests
{
    internal class AutomationCollectionTests : SecurityCenterManagementTestBase
    {
        private SecurityAutomationCollection _automationCollection => _resourceGroup.GetSecurityAutomations();
        private ResourceGroupResource _resourceGroup;
        private ResourceIdentifier _workflowId;

        public AutomationCollectionTests(bool isAsync) : base(isAsync)//, RecordedTestMode.Record)
        {
        }

        [SetUp]
        public async Task TestSetUp()
        {
            _resourceGroup = await CreateResourceGroup();
        }

        private async Task<SecurityAutomationResource> CreateSecurityAutomation(string automationName)
        {
            // prerequisites
            var workflow = await CreateLogicWorkFlow(_resourceGroup);
            _workflowId = workflow.Data.Id;

            SecurityAutomationData data = new SecurityAutomationData(_resourceGroup.Data.Location)
            {
                Scopes =
                {
                    new SecurityAutomationScope()
                    {
                        Description = "A description that helps to identify this scope",
                        ScopePath = $"{_resourceGroup.Data.Id}"
                    }
                },
                Sources =
                {
                    new SecurityAutomationSource()
                    {
                        EventSource = "Assessments",
                    }
                },
                Actions =
                {
                    new SecurityAutomationActionLogicApp()
                    {
                        LogicAppResourceId = _workflowId,
                        Uri = new Uri("https://justtestsample.azurewebsites.net"),
                    }
                }
            };
            var automation = await _automationCollection.CreateOrUpdateAsync(WaitUntil.Completed, automationName, data);
            return automation.Value;
        }

        [RecordedTest]
        public async Task CreateOrUpdate()
        {
            string automationName = Recording.GenerateAssetName("automation");
            var automation = await CreateSecurityAutomation(automationName);
            ValidateAutomation(automation, automationName);
        }

        [RecordedTest]
        public async Task Exist()
        {
            string automationName = Recording.GenerateAssetName("automation");
            var automation = await CreateSecurityAutomation(automationName);
            bool flag = await _automationCollection.ExistsAsync(automationName);
            Assert.IsTrue(flag);
        }

        [RecordedTest]
        public async Task Get()
        {
            string automationName = Recording.GenerateAssetName("automation");
            await CreateSecurityAutomation(automationName);
            var automation = await _automationCollection.GetAsync(automationName);
            ValidateAutomation(automation, automationName);
        }

        [RecordedTest]

        public async Task GetAll()
        {
            string automationName = Recording.GenerateAssetName("automation");
            await CreateSecurityAutomation(automationName);
            var list = await _automationCollection.GetAllAsync().ToEnumerableAsync();
            Assert.IsNotEmpty(list);
            ValidateAutomation(list.First(item => item.Data.Name == automationName), automationName);
        }

        [RecordedTest]
        public async Task Delete()
        {
            string automationName = Recording.GenerateAssetName("automation");
            var automation = await CreateSecurityAutomation(automationName);
            bool flag = await _automationCollection.ExistsAsync(automationName);
            Assert.IsTrue(flag);

            await automation.DeleteAsync(WaitUntil.Completed);
            flag = await _automationCollection.ExistsAsync(automationName);
            Assert.IsFalse(flag);
        }

        [TestCase(null)]
        [TestCase(false)]
        [TestCase(true)]
        public async Task AddRemoveTag(bool? useTagResource)
        {
            SetTagResourceUsage(Client, useTagResource);
            string automationName = Recording.GenerateAssetName("automation");
            var automation = await CreateSecurityAutomation(automationName);

            if (useTagResource == false)
            {
                // if useTagResource == false, it will call automation's update method and then the uri of Automation.Data.Action is null, will throw 400 bad request
                Assert.ThrowsAsync<RequestFailedException>(() => automation.AddTagAsync("addtagkey", "addtagvalue"));
                return;
            }

            // AddTag
            await automation.AddTagAsync("addtagkey", "addtagvalue");
            automation = await _automationCollection.GetAsync(automationName);
            Assert.AreEqual(1, automation.Data.Tags.Count);
            KeyValuePair<string, string> tag = automation.Data.Tags.Where(tag => tag.Key == "addtagkey").FirstOrDefault();
            Assert.AreEqual("addtagkey", tag.Key);
            Assert.AreEqual("addtagvalue", tag.Value);

            // RemoveTag
            await automation.RemoveTagAsync("addtagkey");
            automation = await _automationCollection.GetAsync(automationName);
            Assert.AreEqual(0, automation.Data.Tags.Count);
        }

        private void ValidateAutomation(SecurityAutomationResource automation, string automationName)
        {
            Assert.IsNotNull(automation);
            Assert.IsNotNull(automation.Data.Id);
            Assert.AreEqual(automationName, automation.Data.Name);
            Assert.AreEqual(DefaultLocation, automation.Data.Location);
            Assert.AreEqual("Assessments", automation.Data.Sources.First().EventSource.ToString());
            Assert.AreEqual("Microsoft.Security/automations", automation.Data.ResourceType.ToString());
        }
    }
}
