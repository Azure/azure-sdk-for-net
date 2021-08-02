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

namespace Azure.ResourceManager.Network.Tests.Tests
{
    public class DdosProtectionPlanTests
        : NetworkServiceClientTestBase
    {
        private const string NamePrefix = "test_ddos_protection_plan_";
        private Resources.ResourceGroup resourceGroup;

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
            resourceGroup = (await CreateResourceGroup(Recording.GenerateAssetName(NamePrefix))).Value;
        }

        [TearDown]
        public async Task CleanupResourceGroup()
        {
            //await CleanupResourceGroupsAsync();

            // need to cleanup created plans, since only one plan is allowed per location
            var ddosProtectionPlans = await GetContainer().GetAllAsync().ToEnumerableAsync();
            foreach (var plan in ddosProtectionPlans)
            {
                await plan.DeleteAsync();
            }
        }

        public DdosProtectionPlanContainer GetContainer()
        {
            return resourceGroup.GetDdosProtectionPlans();
        }

        [Test]
        [RecordedTest]
        public async Task DdosProtectionPlanApiTest()
        {
            var container = GetContainer();
            var name = Recording.GenerateAssetName(NamePrefix);

            // create
            var ddosProtectionPlanResponse = await container.CreateOrUpdateAsync(name, new DdosProtectionPlanData{
                Location = TestEnvironment.Location
            });

            Assert.True(await container.CheckIfExistsAsync(name));

            var ddosProtectionPlanData = ddosProtectionPlanResponse.Value.Data;
            ValidateCommon(ddosProtectionPlanData, name);
            Assert.IsEmpty(ddosProtectionPlanData.Tags);

            // update
            ddosProtectionPlanResponse = await container.CreateOrUpdateAsync(name, new DdosProtectionPlanData{
                Location = TestEnvironment.Location,
                Tags = {
                {"tag1", "value1" },
                {"tag2", "value2" } }
            });
            ddosProtectionPlanData = ddosProtectionPlanResponse.Value.Data;

            ValidateCommon(ddosProtectionPlanData, name);
            Assert.That(ddosProtectionPlanData.Tags, Has.Count.EqualTo(2));
            Assert.That(ddosProtectionPlanData.Tags, Does.ContainKey("tag1").WithValue("value1"));
            Assert.That(ddosProtectionPlanData.Tags, Does.ContainKey("tag2").WithValue("value2"));

            // get
            ddosProtectionPlanResponse = await container.GetAsync(name);
            ddosProtectionPlanData = ddosProtectionPlanResponse.Value.Data;

            ValidateCommon(ddosProtectionPlanData, name);
            Assert.That(ddosProtectionPlanData.Tags, Has.Count.EqualTo(2));
            Assert.That(ddosProtectionPlanData.Tags, Does.ContainKey("tag1").WithValue("value1"));
            Assert.That(ddosProtectionPlanData.Tags, Does.ContainKey("tag2").WithValue("value2"));

            // patch
            ddosProtectionPlanResponse = await ddosProtectionPlanResponse.Value.UpdateTagsAsync(new Dictionary<string, string>{{ "tag2", "value2"}});
            ddosProtectionPlanData = ddosProtectionPlanResponse.Value.Data;

            ValidateCommon(ddosProtectionPlanData, name);
            Assert.That(ddosProtectionPlanData.Tags, Has.Count.EqualTo(1));
            Assert.That(ddosProtectionPlanData.Tags, Does.ContainKey("tag2").WithValue("value2"));

            // list
            var ddosProtectionPlans = await container.GetAllAsync().ToEnumerableAsync();
            Assert.That(ddosProtectionPlans, Has.Count.EqualTo(1));
            var ddosProtectionPlan = ddosProtectionPlans[0];
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
            // TODO: ADO 6080
            //ddosProtectionPlans = await ArmClient.DefaultSubscription.GetDdosProtectionPlanAsync();
            //Assert.IsEmpty(ddosProtectionPlans);
        }

        private void ValidateCommon(DdosProtectionPlanData data, string name)
        {
            Assert.AreEqual(name, data.Name);
            Assert.AreEqual(TestEnvironment.Location, data.Location);
        }
    }
}
