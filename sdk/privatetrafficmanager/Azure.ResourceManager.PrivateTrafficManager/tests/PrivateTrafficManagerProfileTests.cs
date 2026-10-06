// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Linq;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.ResourceManager.PrivateTrafficManager.Models;
using Azure.ResourceManager.Resources;
using NUnit.Framework;

namespace Azure.ResourceManager.PrivateTrafficManager.Tests
{
    public class PrivateTrafficManagerProfileTests : PrivateTrafficManagerManagementTestBase
    {
        private ResourceGroupResource _resourceGroup;

        public PrivateTrafficManagerProfileTests(bool isAsync)
            : base(isAsync)
        {
        }

        [SetUp]
        public async Task CreateTestResourceGroup()
        {
            _resourceGroup = await CreateResourceGroup(DefaultSubscription, "ptmrg", AzureLocation.WestUS2);
        }

        [TearDown]
        public async Task DeleteTestResourceGroup()
        {
            if (_resourceGroup != null && Mode != RecordedTestMode.Playback)
            {
                await _resourceGroup.DeleteAsync(WaitUntil.Started);
            }
        }

        private static PrivateTrafficManagerProfileData CreateProfileData() =>
            new PrivateTrafficManagerProfileData(new AzureLocation("global"))
            {
                Properties = new PrivateTrafficManagerProfileProperties
                {
                    CustomTopologyMapMode = CustomTopologyMapMode.Disabled,
                    TrafficRoutingMethod = TrafficRoutingMethod.Priority,
                    ProfileStatus = PrivateTrafficManagerProfileStatus.Enabled,
                    DnsConfig = new PrivateTrafficManagerDnsConfig
                    {
                        RecordType = DnsRecordType.A,
                        TimeToLiveInSeconds = 30,
                    },
                },
                Tags = { ["environment"] = "test" },
            };

        [TestCase]
        [RecordedTest]
        public async Task CreateGetListUpdateDelete()
        {
            string profileName = Recording.GenerateAssetName("ptmprofile");
            var profiles = _resourceGroup.GetPrivateTrafficManagerProfiles();

            var created = (await profiles.CreateOrUpdateAsync(WaitUntil.Completed, profileName, CreateProfileData())).Value;
            Assert.That(created.Data.Name, Is.EqualTo(profileName));
            Assert.That(created.Data.Properties.TrafficRoutingMethod, Is.EqualTo(TrafficRoutingMethod.Priority));
            Assert.That(created.Data.Properties.DnsConfig.RecordType, Is.EqualTo(DnsRecordType.A));
            Assert.That(created.Data.Properties.DnsConfig.TimeToLiveInSeconds, Is.EqualTo(30));

            var fetched = (await profiles.GetAsync(profileName)).Value;
            Assert.That(fetched.Id, Is.EqualTo(created.Id));
            Assert.That((await profiles.ExistsAsync(profileName)).Value, Is.True);

            var listed = await profiles.GetAllAsync().ToEnumerableAsync();
            Assert.That(listed.Any(p => p.Data.Name == profileName), Is.True);

            var patch = new PrivateTrafficManagerProfilePatch
            {
                Properties = new PrivateTrafficManagerProfilePatchProperties
                {
                    DnsConfig = new PrivateTrafficManagerDnsConfig { TimeToLiveInSeconds = 60 },
                },
            };
            patch.Tags["environment"] = "updated";
            var updated = (await fetched.UpdateAsync(WaitUntil.Completed, patch)).Value;
            Assert.That(updated.Data.Properties.DnsConfig.TimeToLiveInSeconds, Is.EqualTo(60));
            Assert.That(updated.Data.Tags["environment"], Is.EqualTo("updated"));

            await updated.DeleteAsync(WaitUntil.Completed);
            Assert.That((await profiles.ExistsAsync(profileName)).Value, Is.False);
        }

        [TestCase]
        [RecordedTest]
        public async Task HealthPolicyCreateGetListDelete()
        {
            string profileName = Recording.GenerateAssetName("ptmprofile");
            var profile = (await _resourceGroup.GetPrivateTrafficManagerProfiles()
                .CreateOrUpdateAsync(WaitUntil.Completed, profileName, CreateProfileData())).Value;

            string policyName = Recording.GenerateAssetName("ptmpolicy");
            var policyData = new ProbeHealthPolicy
            {
                Properties = new HealthPolicyProperties
                {
                    ProbeConfig = new ProbeConfig
                    {
                        Protocol = ProbeProtocol.Http,
                        Port = 80,
                        Path = "/health",
                        IntervalInSeconds = 30,
                        TimeoutInSeconds = 10,
                        ToleratedNumberOfFailures = 3,
                    },
                },
            };

            var policies = profile.GetHealthPolicies();
            var created = (await policies.CreateOrUpdateAsync(WaitUntil.Completed, policyName, policyData)).Value;
            Assert.That(created.Data.Name, Is.EqualTo(policyName));
            Assert.That(created.Data.Properties.ProbeConfig.Protocol, Is.EqualTo(ProbeProtocol.Http));
            Assert.That(created.Data.Properties.ProbeConfig.Path, Is.EqualTo("/health"));

            var fetched = (await policies.GetAsync(policyName)).Value;
            Assert.That(fetched.Id, Is.EqualTo(created.Id));

            var listed = await policies.GetAllAsync().ToEnumerableAsync();
            Assert.That(listed.Any(p => p.Data.Name == policyName), Is.True);

            await fetched.DeleteAsync(WaitUntil.Completed);
            Assert.That((await policies.ExistsAsync(policyName)).Value, Is.False);
        }
    }
}
