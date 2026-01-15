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
            Assert.That((bool)await namespaceCollection.ExistsAsync(namespaceName), Is.True);
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
            Assert.That(applicationGroupName, Is.EqualTo(applicationgroup.Id.Name));
            Assert.That(applicationgroupData.IsEnabled, Is.EqualTo(applicationgroup.Data.IsEnabled));
            Assert.That(applicationgroupData.ClientAppGroupIdentifier, Is.EqualTo(applicationgroup.Data.ClientAppGroupIdentifier));
            Assert.That((bool)await _applicationGroupCollection.ExistsAsync(applicationGroupName), Is.True);
            List<EventHubsThrottlingPolicy> policy = new List<EventHubsThrottlingPolicy>();

            policy = applicationgroupData.Policies.Select(x => x as EventHubsThrottlingPolicy).ToList();
            // List<ThrottlingPolicy> lp = applicationgroupData.Policies.ConvertAll(new Converter<ApplicationGroupPolicy,ThrottlingPolicy>(ApplicationGroupPolicyToThrottling));
            Assert.That(policy[0].Name, Is.EqualTo("Throttlingpolicy1"));
            Assert.That(policy[0].RateLimitThreshold, Is.EqualTo(3452));
            Assert.That(policy[0].MetricId, Is.EqualTo(EventHubsMetricId.IncomingMessages));
            Assert.That(policy[1].Name, Is.EqualTo("Throttlingpolicy3"));
            Assert.That(policy[1].RateLimitThreshold, Is.EqualTo(3451));
            Assert.That(policy[1].MetricId, Is.EqualTo(EventHubsMetricId.IncomingBytes));
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
            Assert.That(count, Is.EqualTo(2));
        }
    }
}
