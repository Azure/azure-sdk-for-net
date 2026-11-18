// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Reflection.Metadata;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.ResourceManager.EventHubs;
using Azure.ResourceManager.EventHubs.Models;
using Azure.ResourceManager.Network;
using Azure.ResourceManager.Network.Models;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.Resources.Models;
using NUnit.Framework;

namespace Azure.ResourceManager.EventHubs.Tests.Tests
{
    public class ApplicationGroupTest : EventHubTestBase
    {
        private ResourceGroupResource _resourceGroup;
        private EventHubsApplicationGroupCollection _applicationGroupCollection;
        private EventHubsNamespaceResource _namespace;
        public ApplicationGroupTest(bool isAsync) : base(isAsync)
        {
        }

        [SetUp]
        public async Task CreateNamespaceAndGetEventhubCollection()
        {
            _resourceGroup = await CreateResourceGroupAsync();
            string namespaceName = await CreateValidNamespaceName("testnamespacemgmt");
            EventHubsNamespaceCollection namespaceCollection = _resourceGroup.GetEventHubsNamespaces();
            EventHubsNamespaceResource eventHubNamespace = await CreateNamespaceAsync(_resourceGroup, namespaceName, EventHubsSkuName.Premium, AzureLocation.EastUS);
            _namespace = eventHubNamespace;
            eventHubNamespace = await namespaceCollection.GetAsync(namespaceName);
            Assert.IsTrue(await namespaceCollection.ExistsAsync(namespaceName));
            // VerifyNamespaceProperties(eventHubNamespace, true);
            _applicationGroupCollection = eventHubNamespace.GetEventHubsApplicationGroups();
        }

        [Test]
        [RecordedTest]
        [Ignore("Premium namespace creation is restricted in the recording subscription; re-record when Premium capacity is available.")]
        public async Task CreateApplicationGroupWithParameter()
        {
            string SASKey = await CreateApplicationKeyAsync();
            string ClientAppGroupIdentifier = "SASKeyName=" + SASKey;
            string applicationGroupName = Recording.GenerateAssetName("applicationgroup");
            EventHubsApplicationGroupData applicationgroupData = new EventHubsApplicationGroupData()
            {
                IsEnabled = true,
                ClientAppGroupIdentifier = ClientAppGroupIdentifier,
                Policies =
                {
                    new EventHubsThrottlingPolicy("Throttlingpolicy1", 3452, "IncomingMessages")
                }
            };
            applicationgroupData.Policies.Add(new EventHubsThrottlingPolicy("Throttlingpolicy3", 3451, "IncomingBytes"));
            EventHubsApplicationGroupResource applicationgroup = await CompleteAsync(await _applicationGroupCollection.CreateOrUpdateAsync(WaitUntil.Started, applicationGroupName, applicationgroupData));
            Assert.IsNotNull(applicationgroup);
            Assert.AreEqual(applicationgroup.Id.Name, applicationGroupName);
            Assert.AreEqual(applicationgroup.Data.IsEnabled, applicationgroupData.IsEnabled);
            Assert.AreEqual(applicationgroup.Data.ClientAppGroupIdentifier, applicationgroupData.ClientAppGroupIdentifier);
            Assert.IsTrue(await _applicationGroupCollection.ExistsAsync(applicationGroupName));
            applicationgroup = await applicationgroup.GetAsync();
            List<EventHubsThrottlingPolicy> policy = applicationgroup.Data.Policies.OfType<EventHubsThrottlingPolicy>().ToList();
            Assert.AreEqual(2, policy.Count);
            Assert.AreEqual("Throttlingpolicy1", policy[0].Name);
            Assert.AreEqual(3452, policy[0].RateLimitThreshold);
            Assert.AreEqual(EventHubsMetricId.IncomingMessages, policy[0].MetricId);
            Assert.AreEqual("Throttlingpolicy3", policy[1].Name);
            Assert.AreEqual(3451, policy[1].RateLimitThreshold);
            Assert.AreEqual(EventHubsMetricId.IncomingBytes, policy[1].MetricId);

            //delete applicationGroup
            await CompleteAsync(await applicationgroup.DeleteAsync(WaitUntil.Started));
            Assert.IsFalse(await _applicationGroupCollection.ExistsAsync(applicationGroupName));
        }

        [Test]
        [RecordedTest]
        [Ignore("Premium namespace creation is restricted in the recording subscription; re-record when Premium capacity is available.")]
        public async Task GetAllApplicationGroups()
        {
            string SASKey = await CreateApplicationKeyAsync();
            string ClientAppGroupIdentifier1 = "SASKeyName=" + SASKey;
            string SASKey1 = await CreateApplicationKeyAsync();
            string ClientAppGroupIdentifier2 = "SASKeyName=" + SASKey1;
            //create two Application Groups
            string applicationGroupName1 = Recording.GenerateAssetName("applicationgroup1");
            string applicationGroupName2 = Recording.GenerateAssetName("applicationgroup2");
            EventHubsApplicationGroupData applicationgroupData1 = new EventHubsApplicationGroupData()
            {
                IsEnabled = true,
                ClientAppGroupIdentifier = ClientAppGroupIdentifier1,
                Policies =
                {
                    new EventHubsThrottlingPolicy("Throttlingpolicy1", 3452, "IncomingMessages")
                }
            };
            EventHubsApplicationGroupData applicationgroupData2 = new EventHubsApplicationGroupData()
            {
                IsEnabled = true,
                ClientAppGroupIdentifier = ClientAppGroupIdentifier2,
                Policies =
                {
                    new EventHubsThrottlingPolicy("Throttlingpolicy4", 3455, "IncomingMessages")
                }
            };
            await CompleteAsync(await _applicationGroupCollection.CreateOrUpdateAsync(WaitUntil.Started, applicationGroupName1, applicationgroupData1));
            await CompleteAsync(await _applicationGroupCollection.CreateOrUpdateAsync(WaitUntil.Started, applicationGroupName2, applicationgroupData2));

            //validate
            int count = 0;
            foreach (EventHubsApplicationGroupResource applicationgroup in await ReadAllAsync(_applicationGroupCollection.GetAllAsync()))
            {
                if (applicationgroup.Id.Name == applicationGroupName1)
                    count++;
                if (applicationgroup.Id.Name == applicationGroupName2)
                    count++;
            }
            Assert.AreEqual(count, 2);
        }

        [RecordedTest]
        [Ignore("Premium namespace creation is restricted in the recording subscription; re-record when Premium capacity is available.")]
        public async Task UpdateApplicationGroup()
        {
            string name = Recording.GenerateAssetName("applicationgroup");
            var data = new EventHubsApplicationGroupData
            {
                IsEnabled = true,
                ClientAppGroupIdentifier = "SASKeyName=" + await CreateApplicationKeyAsync(),
                Policies = { new EventHubsThrottlingPolicy("incoming", 100, EventHubsMetricId.IncomingMessages) }
            };
            EventHubsApplicationGroupResource resource = await CompleteAsync(
                await _applicationGroupCollection.CreateOrUpdateAsync(WaitUntil.Started, name, data));
            data.IsEnabled = false;
            await CompleteAsync(await resource.UpdateAsync(WaitUntil.Started, data));
            Response<EventHubsApplicationGroupResource> readBack = await resource.GetAsync();
            AssertStatus(readBack.GetRawResponse(), 200);
            Assert.IsFalse(readBack.Value.Data.IsEnabled);
            Assert.AreEqual(data.ClientAppGroupIdentifier, readBack.Value.Data.ClientAppGroupIdentifier);
        }

        private async Task<string> CreateApplicationKeyAsync()
        {
            string name = Recording.GenerateAssetName("appkey");
            await CompleteAsync(await _namespace.GetEventHubsNamespaceAuthorizationRules().CreateOrUpdateAsync(
                WaitUntil.Started, name, new EventHubsAuthorizationRuleData
                {
                    Rights = { EventHubsAccessRight.Listen, EventHubsAccessRight.Send }
                }));
            return name;
        }
    }
}
