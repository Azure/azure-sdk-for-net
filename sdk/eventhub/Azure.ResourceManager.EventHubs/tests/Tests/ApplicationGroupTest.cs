// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NUnit.Framework;
using Azure.ResourceManager.Resources;
using Azure.Core.TestFramework;
using Azure.ResourceManager.EventHubs.Models;
using Azure.ResourceManager.EventHubs;
using Azure.ResourceManager.Network;
using Azure.ResourceManager.Network.Models;
using Azure.ResourceManager.Resources.Models;
using Azure.Core;
using System.Reflection.Metadata;
using System.Drawing;

namespace Azure.ResourceManager.EventHubs.Tests.Tests
{
    public class ApplicationGroupTest : EventHubTestBase
    {
        private ResourceGroupResource _resourceGroup;
        private EventHubsApplicationGroupCollection _applicationGroupCollection;
        public ApplicationGroupTest(bool isAsync) : base(isAsync)
        {
        }

        [SetUp]
        public async Task CreateNamespaceAndGetEventhubCollection()
        {
            _resourceGroup = await CreateResourceGroupAsync();
            string namespaceName = await CreateValidNamespaceName("testnamespacemgmt");
            EventHubsNamespaceCollection namespaceCollection = _resourceGroup.GetEventHubsNamespaces();
            EventHubsNamespaceResource eventHubNamespace = (await namespaceCollection.CreateOrUpdateAsync(WaitUntil.Completed, namespaceName, new EventHubsNamespaceData(DefaultLocation)
            {
                Sku = new EventHubsSku("Premium")
                {
                    Tier = "Premium",
                    Capacity = 1
                }
            })).Value;
            eventHubNamespace = await namespaceCollection.GetAsync(namespaceName);
            Assert.IsTrue(await namespaceCollection.ExistsAsync(namespaceName));
           // VerifyNamespaceProperties(eventHubNamespace, true);
            _applicationGroupCollection = eventHubNamespace.GetEventHubsApplicationGroups();
        }

        [Test]
        [RecordedTest]
        [Ignore("RequestFailedException:Cannot create or update an Application Group with non-existent SAS Key.")]
        public async Task CreateApplicationGroupWithParameter()
        {
            string SASKey = Recording.GenerateAssetName("SasKey_");
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
            EventHubsApplicationGroupResource applicationgroup = (await _applicationGroupCollection.CreateOrUpdateAsync(WaitUntil.Completed, applicationGroupName,applicationgroupData)).Value;
            Assert.IsNotNull(applicationgroup);
            Assert.AreEqual(applicationgroup.Id.Name, applicationGroupName);
            Assert.AreEqual(applicationgroup.Data.IsEnabled,applicationgroupData.IsEnabled);
            Assert.AreEqual(applicationgroup.Data.ClientAppGroupIdentifier, applicationgroupData.ClientAppGroupIdentifier);
            Assert.IsTrue(await _applicationGroupCollection.ExistsAsync(applicationGroupName));
            List<EventHubsThrottlingPolicy> policy = new List<EventHubsThrottlingPolicy>();

            policy = applicationgroupData.Policies.Select(x => x as EventHubsThrottlingPolicy).ToList();
            // List<ThrottlingPolicy> lp = applicationgroupData.Policies.ConvertAll(new Converter<ApplicationGroupPolicy,ThrottlingPolicy>(ApplicationGroupPolicyToThrottling));
            Assert.AreEqual("Throttlingpolicy1", policy[0].Name);
            Assert.AreEqual(3452, policy[0].RateLimitThreshold);
            Assert.AreEqual(EventHubsMetricId.IncomingMessages, policy[0].MetricId);
            Assert.AreEqual("Throttlingpolicy3", policy[1].Name);
            Assert.AreEqual(3451, policy[1].RateLimitThreshold);
            Assert.AreEqual(EventHubsMetricId.IncomingBytes, policy[1].MetricId);
            applicationgroup = await _applicationGroupCollection.GetAsync(applicationGroupName);

            //delete applicationGroup
            await applicationgroup.DeleteAsync(WaitUntil.Completed);
        }

        [Test]
        [RecordedTest]
        [Ignore("RequestFailedException:Cannot create or update an Application Group with non-existent SAS Key.")]
        public async Task GetAllApplicationGroups()
        {
            string SASKey = Recording.GenerateAssetName("SasKey_");
            string ClientAppGroupIdentifier1 = "SASKeyName=" + SASKey;
            string SASKey1 = Recording.GenerateAssetName("SasKey_");
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
            _ = (await _applicationGroupCollection.CreateOrUpdateAsync(WaitUntil.Completed, applicationGroupName1, applicationgroupData1)).Value;
            _ = (await _applicationGroupCollection.CreateOrUpdateAsync(WaitUntil.Completed, applicationGroupName2, applicationgroupData2)).Value;

            //validate
            int count = 0;
            await foreach (EventHubsApplicationGroupResource applicationgroup in _applicationGroupCollection.GetAllAsync())
            {
                if (applicationgroup.Id.Name == applicationGroupName1)
                    count++;
                if (applicationgroup.Id.Name == applicationGroupName2)
                    count++;
            }
            Assert.AreEqual(count, 2);
        }
    }
}
