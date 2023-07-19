// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Azure.Azure.Test;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.Resources.Models;
using Azure.ResourceManager.Network.Models;
using Azure.ResourceManager.Network.Tests.Helpers;
using NUnit.Framework;

namespace Azure.ResourceManager.Network.Tests
{
    public class ApplicationSecurityGroupTests
        : NetworkServiceClientTestBase
    {
        private SubscriptionResource _subscription;

        public ApplicationSecurityGroupTests(bool isAsync)
            : base(isAsync)//, RecordedTestMode.Record)
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
        }

        public async Task<ApplicationSecurityGroupCollection> GetCollection()
        {
            var resourceGroup = await CreateResourceGroup(Recording.GenerateAssetName("test_application_security_group_"));
            return resourceGroup.GetApplicationSecurityGroups();
        }

        [TestCase(null)]
        [TestCase(false)]
        [TestCase(true)]
        public async Task ApplicationSecurityGroupApiTest(bool? useTagResource)
        {
            SetTagResourceUsage(ArmClient, useTagResource);
            var collection = await GetCollection();
            var name = Recording.GenerateAssetName("test_application_security_group_");

            // create
            var applicationSecurityGroupResponse = (await collection.CreateOrUpdateAsync(WaitUntil.Completed, name, new ApplicationSecurityGroupData()
            {
                Location = TestEnvironment.Location,
            })).Value;

            Assert.True(await collection.ExistsAsync(name));

            var applicationSecurityGroupData = applicationSecurityGroupResponse.Data;
            ValidateCommon(applicationSecurityGroupData, name);
            Assert.IsEmpty(applicationSecurityGroupData.Tags);

            applicationSecurityGroupData.Tags.Add("tag1", "value1");
            applicationSecurityGroupData.Tags.Add("tag2", "value2");

            // update
            applicationSecurityGroupResponse = await (await collection.CreateOrUpdateAsync(WaitUntil.Completed, name, applicationSecurityGroupData)).WaitForCompletionAsync();
            applicationSecurityGroupData = applicationSecurityGroupResponse.Data;

            ValidateCommon(applicationSecurityGroupData, name);
            Assert.That(applicationSecurityGroupData.Tags, Has.Count.EqualTo(2));
            Assert.That(applicationSecurityGroupData.Tags, Does.ContainKey("tag1").WithValue("value1"));
            Assert.That(applicationSecurityGroupData.Tags, Does.ContainKey("tag2").WithValue("value2"));

            // get
            applicationSecurityGroupResponse = await collection.GetAsync(name);
            applicationSecurityGroupData = applicationSecurityGroupResponse.Data;

            ValidateCommon(applicationSecurityGroupData, name);
            Assert.That(applicationSecurityGroupData.Tags, Has.Count.EqualTo(2));
            Assert.That(applicationSecurityGroupData.Tags, Does.ContainKey("tag1").WithValue("value1"));
            Assert.That(applicationSecurityGroupData.Tags, Does.ContainKey("tag2").WithValue("value2"));

            // patch
            var tags = new Dictionary<string, string>();
            tags.Add("tag2", "value2");
            applicationSecurityGroupData = (await applicationSecurityGroupResponse.SetTagsAsync(tags)).Value.Data;

            ValidateCommon(applicationSecurityGroupData, name);
            Assert.That(applicationSecurityGroupData.Tags, Has.Count.EqualTo(1));
            Assert.That(applicationSecurityGroupData.Tags, Does.ContainKey("tag2").WithValue("value2"));

            // list
            var applicationSecurityGroups = await collection.GetAllAsync().ToEnumerableAsync();
            Assert.That(applicationSecurityGroups, Has.Count.EqualTo(1));
            var applicationSecurityGroup = applicationSecurityGroups[0];
            applicationSecurityGroupData = applicationSecurityGroup.Data;

            ValidateCommon(applicationSecurityGroupData, name);
            Assert.That(applicationSecurityGroupData.Tags, Has.Count.EqualTo(1));
            Assert.That(applicationSecurityGroupData.Tags, Does.ContainKey("tag2").WithValue("value2"));

            // delete
            await applicationSecurityGroup.DeleteAsync(WaitUntil.Completed);

            Assert.False(await collection.ExistsAsync(name));

            applicationSecurityGroups = await collection.GetAllAsync().ToEnumerableAsync();
            Assert.IsEmpty(applicationSecurityGroups);

            // list all
            applicationSecurityGroups = await _subscription.GetApplicationSecurityGroupsAsync().ToEnumerableAsync();
            Assert.IsEmpty(applicationSecurityGroups);
        }

        private void ValidateCommon(ApplicationSecurityGroupData data, string name)
        {
            Assert.AreEqual(name, data.Name);
            Assert.AreEqual(TestEnvironment.Location, data.Location.ToString());
        }
    }
}
