// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.ResourceManager.LabServices.Models;
using NUnit.Framework;

namespace Azure.ResourceManager.LabServices.Tests
{
    public class LabTests : LabServicesManagementTestBase
    {
        public LabTests(bool isAsync)
                    : base(isAsync)//, RecordedTestMode.Record)
        {
        }

        [Test]
        public async Task LabCRUDTest()
        {
            var rg = await CreateResourceGroupAsync();
            var collection = rg.GetLabs();

            // Create test
            var data = GetData();
            var resourceName = Recording.GenerateAssetName("sdklab-");
            var resource = (await collection.CreateOrUpdateAsync(WaitUntil.Completed, resourceName, data)).Value;
            AssertLabData(data, resource.Data);

            // Get test - 1
            resource = await collection.GetAsync(resourceName);
            AssertLabData(data, resource.Data);

            // Update with Put test
            data.Title = "new title";
            // FYI: 'password' must be empty.
            data.VirtualMachineProfile.AdminUser.Password = null;
            resource = (await collection.CreateOrUpdateAsync(WaitUntil.Completed, resourceName, data)).Value;
            AssertLabData(data, resource.Data);

            // Get test - 2
            resource = await resource.GetAsync();
            AssertLabData(data, resource.Data);

            // Update with Patch test
            data.Title = "new title-2";
            var patch = new LabPatch()
            {
                Title = "new title-2"
            };
            resource = (await resource.UpdateAsync(WaitUntil.Completed, patch)).Value;
            AssertLabData(data, resource.Data);

            // Exists test
            bool boolResult = await collection.ExistsAsync(resourceName);
            Assert.That(boolResult, Is.True);

            // GetAll test
            var list = await collection.GetAllAsync().ToEnumerableAsync();
            Assert.That(list.Count, Is.EqualTo(1));
            AssertLabData(data, list[0].Data);

            // Delete test
            await resource.DeleteAsync(WaitUntil.Completed);
            boolResult = await collection.ExistsAsync(resourceName);
            Assert.That(boolResult, Is.False);
        }

        public LabData GetData()
        {
            return new LabData(DefaultLocation)
            {
                Title = "test lab",
                AutoShutdownProfile = new LabAutoShutdownProfile()
                {
                    ShutdownOnDisconnect = LabServicesEnableState.Disabled,
                    ShutdownOnIdle = LabVirtualMachineShutdownOnIdleMode.UserAbsence,
                    ShutdownWhenNotConnected = LabServicesEnableState.Disabled,
                    IdleDelay = TimeSpan.FromMinutes(15)
                },
                ConnectionProfile = new LabConnectionProfile()
                {
                    ClientRdpAccess = LabVirtualMachineConnectionType.Public,
                    ClientSshAccess = LabVirtualMachineConnectionType.Public,
                    WebRdpAccess = LabVirtualMachineConnectionType.None,
                    WebSshAccess = LabVirtualMachineConnectionType.None
                },
                VirtualMachineProfile = new LabVirtualMachineProfile(
                    createOption: LabVirtualMachineCreateOption.TemplateVm,
                    imageReference: new LabVirtualMachineImageReference()
                    {
                        Sku = "20_04-lts",
                        Offer = "0001-com-ubuntu-server-focal",
                        Publisher = "canonical",
                        Version = "latest"
                    },
                    sku: new LabServicesSku("Standard_Fsv2_2_4GB_64_S_SSD")
                    {
                        Capacity = 0
                    },
                    usageQuota: TimeSpan.FromHours(2),
                    adminUser: new LabVirtualMachineCredential("tester")
                    {
                        // Set the password if not in playback mode
                        Password = Mode == RecordedTestMode.Playback ? "Sanitized" : Environment.GetEnvironmentVariable("USER_PWD"),
                    }
                    )
                {
                    UseSharedPassword = LabServicesEnableState.Enabled
                },
                SecurityProfile = new LabSecurityProfile()
                {
                    OpenAccess = LabServicesEnableState.Disabled
                }
            };
        }

        public void AssertLabData(LabData expected, LabData actual)
        {
            Assert.That(actual.Title, Is.EqualTo(expected.Title));
            Assert.That(actual.Location, Is.EqualTo(expected.Location));
            Assert.That(actual.AutoShutdownProfile.ShutdownOnDisconnect, Is.EqualTo(expected.AutoShutdownProfile.ShutdownOnDisconnect));
            Assert.That(actual.AutoShutdownProfile.ShutdownOnIdle, Is.EqualTo(expected.AutoShutdownProfile.ShutdownOnIdle));
            Assert.That(actual.AutoShutdownProfile.ShutdownWhenNotConnected, Is.EqualTo(expected.AutoShutdownProfile.ShutdownWhenNotConnected));
            Assert.That(actual.AutoShutdownProfile.IdleDelay, Is.EqualTo(expected.AutoShutdownProfile.IdleDelay));
            Assert.That(actual.ConnectionProfile.ClientRdpAccess, Is.EqualTo(expected.ConnectionProfile.ClientRdpAccess));
            Assert.That(actual.ConnectionProfile.ClientSshAccess, Is.EqualTo(expected.ConnectionProfile.ClientSshAccess));
            Assert.That(actual.ConnectionProfile.WebRdpAccess, Is.EqualTo(expected.ConnectionProfile.WebRdpAccess));
            Assert.That(actual.ConnectionProfile.WebSshAccess, Is.EqualTo(expected.ConnectionProfile.WebSshAccess));
            Assert.That(actual.VirtualMachineProfile.CreateOption, Is.EqualTo(expected.VirtualMachineProfile.CreateOption));
            Assert.That(actual.VirtualMachineProfile.AdminUser.Username, Is.EqualTo(expected.VirtualMachineProfile.AdminUser.Username));
            Assert.That(actual.VirtualMachineProfile.ImageReference.Sku, Is.EqualTo(expected.VirtualMachineProfile.ImageReference.Sku));
            Assert.That(actual.VirtualMachineProfile.ImageReference.Offer, Is.EqualTo(expected.VirtualMachineProfile.ImageReference.Offer));
            Assert.That(actual.VirtualMachineProfile.ImageReference.Publisher, Is.EqualTo(expected.VirtualMachineProfile.ImageReference.Publisher));
            Assert.That(actual.VirtualMachineProfile.ImageReference.Version, Is.EqualTo(expected.VirtualMachineProfile.ImageReference.Version));
            Assert.That(actual.VirtualMachineProfile.Sku.Name, Is.EqualTo(expected.VirtualMachineProfile.Sku.Name));
            Assert.That(actual.VirtualMachineProfile.Sku.Capacity, Is.EqualTo(expected.VirtualMachineProfile.Sku.Capacity));
            Assert.That(actual.VirtualMachineProfile.UsageQuota, Is.EqualTo(expected.VirtualMachineProfile.UsageQuota));
            Assert.That(actual.VirtualMachineProfile.UseSharedPassword, Is.EqualTo(expected.VirtualMachineProfile.UseSharedPassword));
            Assert.That(actual.SecurityProfile.OpenAccess, Is.EqualTo(expected.SecurityProfile.OpenAccess));
        }
    }
}
