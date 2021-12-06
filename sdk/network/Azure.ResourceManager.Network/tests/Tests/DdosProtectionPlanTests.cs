// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Azure.Azure.Test;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Resources.Models;
using Azure.ResourceManager.Network.Models;
using Azure.ResourceManager.Network.Tests.Helpers;
using NUnit.Framework;

namespace Azure.ResourceManager.Network.Tests
{
    public class DdosProtectionPlanTests
        : NetworkServiceClientTestBase
    {
        private const string NamePrefix = "test_ddos_";
        private Resources.ResourceGroup resourceGroup;
        private Resources.Subscription _subscription;

        public DdosProtectionPlanTests(bool isAsync) : base(isAsync)
        {
        }

        [SetUp]
        public async Task ClearChallengeCacheforRecord()
        {
            if (Mode == RecordedTestMode.Record || Mode == RecordedTestMode.Playback)
            {
                Initialize();
            }
            _subscription = await ArmClient.GetDefaultSubscriptionAsync();
            resourceGroup = await CreateResourceGroup(Recording.GenerateAssetName(NamePrefix));
        }

        public DdosProtectionPlanCollection GetCollection()
        {
            return resourceGroup.GetDdosProtectionPlans();
        }

        [Test]
        [RecordedTest]
        public async Task DdosProtectionPlanApiTest()
        {
            var container = GetCollection();
            var name = Recording.GenerateAssetName(NamePrefix);

            // create
            DdosProtectionPlan ddosProtectionPlan = await container.CreateOrUpdate(name, new DdosProtectionPlanData(TestEnvironment.Location)).WaitForCompletionAsync();

            Assert.True(await container.CheckIfExistsAsync(name));

            var ddosProtectionPlanData = ddosProtectionPlan.Data;
            ValidateCommon(ddosProtectionPlanData, name);
            Assert.IsEmpty(ddosProtectionPlanData.Tags);

            // update
            var data = new DdosProtectionPlanData(TestEnvironment.Location);
            data.Tags.Add("tag1", "value1");
            data.Tags.Add("tag2", "value2");
            ddosProtectionPlan = await container.CreateOrUpdate(name, data).WaitForCompletionAsync();
            ddosProtectionPlanData = ddosProtectionPlan.Data;

            ValidateCommon(ddosProtectionPlanData, name);
            Assert.That(ddosProtectionPlanData.Tags, Has.Count.EqualTo(2));
            Assert.That(ddosProtectionPlanData.Tags, Does.ContainKey("tag1").WithValue("value1"));
            Assert.That(ddosProtectionPlanData.Tags, Does.ContainKey("tag2").WithValue("value2"));

            // get
            ddosProtectionPlan = await container.GetAsync(name);
            ddosProtectionPlanData = ddosProtectionPlan.Data;

            ValidateCommon(ddosProtectionPlanData, name);
            Assert.That(ddosProtectionPlanData.Tags, Has.Count.EqualTo(2));
            Assert.That(ddosProtectionPlanData.Tags, Does.ContainKey("tag1").WithValue("value1"));
            Assert.That(ddosProtectionPlanData.Tags, Does.ContainKey("tag2").WithValue("value2"));

            // patch
            var tags = new TagsObject();
            tags.Tags.Add("tag2", "value2");
            ddosProtectionPlan = await ddosProtectionPlan.UpdateAsync(tags);
            ddosProtectionPlanData = ddosProtectionPlan.Data;

            ValidateCommon(ddosProtectionPlanData, name);
            Assert.That(ddosProtectionPlanData.Tags, Has.Count.EqualTo(1));
            Assert.That(ddosProtectionPlanData.Tags, Does.ContainKey("tag2").WithValue("value2"));

            // list
            var ddosProtectionPlans = await container.GetAllAsync().ToEnumerableAsync();
            Assert.That(ddosProtectionPlans, Has.Count.EqualTo(1));
            ddosProtectionPlan = ddosProtectionPlans[0];
            ddosProtectionPlanData = ddosProtectionPlan.Data;

            ValidateCommon(ddosProtectionPlanData, name);
            Assert.That(ddosProtectionPlanData.Tags, Has.Count.EqualTo(1));
            Assert.That(ddosProtectionPlanData.Tags, Does.ContainKey("tag2").WithValue("value2"));

            // delete
            await ddosProtectionPlan.DeleteAsync();

            Assert.False(await container.CheckIfExistsAsync(name));

            ddosProtectionPlans = await container.GetAllAsync().ToEnumerableAsync();
            Assert.IsEmpty(ddosProtectionPlans);

            // list all
            ddosProtectionPlans = await _subscription.GetDdosProtectionPlansAsync().ToEnumerableAsync();
            Assert.IsEmpty(ddosProtectionPlans);
        }

        private void ValidateCommon(DdosProtectionPlanData data, string name)
        {
            Assert.AreEqual(name, data.Name);
            Assert.AreEqual(TestEnvironment.Location, data.Location.Name);
        }
    }
}
