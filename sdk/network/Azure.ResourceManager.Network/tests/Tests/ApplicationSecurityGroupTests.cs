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
    [Ignore("https://github.com/Azure/azure-sdk-for-net/issues/24577")]
    public class ApplicationSecurityGroupTests
        : NetworkServiceClientTestBase
    {
        public ApplicationSecurityGroupTests(bool isAsync) : base(isAsync)
        {
        }

        [SetUp]
        public void ClearChallengeCacheforRecord()
        {
            if (Mode == RecordedTestMode.Record || Mode == RecordedTestMode.Playback)
            {
                Initialize();
            }
        }

        public async Task<ApplicationSecurityGroupContainer> GetContainer()
        {
            var resourceGroup = await CreateResourceGroup(Recording.GenerateAssetName("test_application_security_group_"));
            return resourceGroup.GetApplicationSecurityGroups();
        }

        [Test]
        [RecordedTest]
        public async Task ApplicationSecurityGroupApiTest()
        {
            var container = await GetContainer();
            var name = Recording.GenerateAssetName("test_application_security_group_");

            // create
            var applicationSecurityGroupResponse = await container.CreateOrUpdate(name, new ApplicationSecurityGroupData()
            {
                Location = TestEnvironment.Location,
            }).WaitForCompletionAsync();

            Assert.True(await container.CheckIfExistsAsync(name));

            var applicationSecurityGroupData = applicationSecurityGroupResponse.Value.Data;
            ValidateCommon(applicationSecurityGroupData, name);
            Assert.IsEmpty(applicationSecurityGroupData.Tags);

            applicationSecurityGroupData.Tags.Add("tag1", "value1");
            applicationSecurityGroupData.Tags.Add("tag2", "value2");

            // update
            applicationSecurityGroupResponse = await container.CreateOrUpdate(name, applicationSecurityGroupData).WaitForCompletionAsync();
            applicationSecurityGroupData = applicationSecurityGroupResponse.Value.Data;

            ValidateCommon(applicationSecurityGroupData, name);
            Assert.That(applicationSecurityGroupData.Tags, Has.Count.EqualTo(2));
            Assert.That(applicationSecurityGroupData.Tags, Does.ContainKey("tag1").WithValue("value1"));
            Assert.That(applicationSecurityGroupData.Tags, Does.ContainKey("tag2").WithValue("value2"));

            // get
            applicationSecurityGroupResponse = await container.GetAsync(name);
            applicationSecurityGroupData = applicationSecurityGroupResponse.Value.Data;

            ValidateCommon(applicationSecurityGroupData, name);
            Assert.That(applicationSecurityGroupData.Tags, Has.Count.EqualTo(2));
            Assert.That(applicationSecurityGroupData.Tags, Does.ContainKey("tag1").WithValue("value1"));
            Assert.That(applicationSecurityGroupData.Tags, Does.ContainKey("tag2").WithValue("value2"));

            // patch
            var tags = new TagsObject();
            tags.Tags.Add("tag2", "value2");
            applicationSecurityGroupData = (await applicationSecurityGroupResponse.Value.UpdateTagsAsync(tags)).Value.Data;

            ValidateCommon(applicationSecurityGroupData, name);
            Assert.That(applicationSecurityGroupData.Tags, Has.Count.EqualTo(1));
            Assert.That(applicationSecurityGroupData.Tags, Does.ContainKey("tag2").WithValue("value2"));

            // list
            var applicationSecurityGroups = await container.GetAllAsync().ToEnumerableAsync();
            Assert.That(applicationSecurityGroups, Has.Count.EqualTo(1));
            var applicationSecurityGroup = applicationSecurityGroups[0];
            applicationSecurityGroupData = applicationSecurityGroup.Data;

            ValidateCommon(applicationSecurityGroupData, name);
            Assert.That(applicationSecurityGroupData.Tags, Has.Count.EqualTo(1));
            Assert.That(applicationSecurityGroupData.Tags, Does.ContainKey("tag2").WithValue("value2"));

            // delete
            await applicationSecurityGroup.DeleteAsync();

            Assert.False(await container.CheckIfExistsAsync(name));

            applicationSecurityGroups = await container.GetAllAsync().ToEnumerableAsync();
            Assert.IsEmpty(applicationSecurityGroups);

            // list all
            applicationSecurityGroups = await ArmClient.DefaultSubscription.GetApplicationSecurityGroupsAsync().ToEnumerableAsync();
            Assert.IsEmpty(applicationSecurityGroups);
        }

        private void ValidateCommon(ApplicationSecurityGroupData data, string name)
        {
            Assert.AreEqual(name, data.Name);
            Assert.AreEqual(TestEnvironment.Location, data.Location);
        }
    }
}
