// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.ResourceManager.HybridCompute;
using NUnit.Framework;
using Azure.Core;
using Azure.ResourceManager.HybridCompute.Models;
using System.Diagnostics;

namespace Azure.ResourceManager.HybridCompute.Tests.Scenario
{
    public class HybridComputeManagementEsuLicenseTest : HybridComputeManagementTestBase
    {
        public HybridComputeManagementEsuLicenseTest(bool isAsync) : base(isAsync)
        {
        }

        [SetUp]
        public async Task ClearAndInitialize()
        {
            if (Mode == RecordedTestMode.Record || Mode == RecordedTestMode.Playback)
            {
                await InitializeClients();
            }
        }

        [TestCase]
        [RecordedTest]
        public async Task CanCreateEsuLicense()
        {
            HybridComputeLicenseData resourceData = await createEsuLicense();
            Assert.That(resourceData.Name, Is.EqualTo(esuLicenseName));
        }

        [TestCase]
        [RecordedTest]
        public async Task CanUpdateEsuLicense()
        {
            HybridComputeLicenseData resourceData = await updateEsuLicense();
            Assert.That(resourceData.LicenseDetails.State, Is.Not.EqualTo("Activated"));
        }

        [TestCase]
        [RecordedTest]
        public async Task CanGetEsuLicense()
        {
            HybridComputeLicenseData resourceData = await getEsuLicense();
            Assert.That(resourceData.Name, Is.EqualTo(esuLicenseName));
        }

        [TestCase]
        [RecordedTest]
        public async Task CanGetEsuLicenseCollection()
        {
            HybridComputeLicenseCollection resourceCollection = await getEsuLicenseCollection();
            Assert.That(resourceCollection, Is.Not.Null);
        }

        [TestCase]
        [RecordedTest]
        public async Task CanCreateLicenseProfile()
        {
            HybridComputeLicenseProfileData resourceData = await createLicenseProfile();
            Assert.That(resourceData.Name, Is.EqualTo("default"));
        }

        [TestCase]
        [RecordedTest]
        public async Task CanGetLicenseProfile()
        {
            HybridComputeLicenseProfileData resourceData = await getLicenseProfile();
            Assert.That(resourceData.Name, Is.EqualTo("default"));
        }

        [TestCase]
        [RecordedTest]
        public async Task CanUpdateLicenseProfile()
        {
            HybridComputeLicenseProfileData resourceData = await updateLicenseProfile();
            Assert.That(resourceData.Name, Is.EqualTo("default"));
        }

        [TestCase]
        [RecordedTest]
        public async Task CanDeleteEsuLicense(){
            await deleteEsuLicense();
        }

        [TestCase]
        [RecordedTest]
        public async Task CanDeleteLicenseProfile(){
            await deleteLicenseProfile();
        }
    }
}
