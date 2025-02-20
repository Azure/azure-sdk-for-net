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
            Assert.IsTrue(boolResult);

            // GetAll test
            var list = await collection.GetAllAsync().ToEnumerableAsync();
            Assert.AreEqual(1, list.Count);
            AssertLabData(data, list[0].Data);

            // Delete test
            await resource.DeleteAsync(WaitUntil.Completed);
            boolResult = await collection.ExistsAsync(resourceName);
            Assert.IsFalse(boolResult);
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
            Assert.AreEqual(expected.Title, actual.Title);
            Assert.AreEqual(expected.Location, actual.Location);
            Assert.AreEqual(expected.AutoShutdownProfile.ShutdownOnDisconnect, actual.AutoShutdownProfile.ShutdownOnDisconnect);
            Assert.AreEqual(expected.AutoShutdownProfile.ShutdownOnIdle, actual.AutoShutdownProfile.ShutdownOnIdle);
            Assert.AreEqual(expected.AutoShutdownProfile.ShutdownWhenNotConnected, actual.AutoShutdownProfile.ShutdownWhenNotConnected);
            Assert.AreEqual(expected.AutoShutdownProfile.IdleDelay, actual.AutoShutdownProfile.IdleDelay);
            Assert.AreEqual(expected.ConnectionProfile.ClientRdpAccess, actual.ConnectionProfile.ClientRdpAccess);
            Assert.AreEqual(expected.ConnectionProfile.ClientSshAccess, actual.ConnectionProfile.ClientSshAccess);
            Assert.AreEqual(expected.ConnectionProfile.WebRdpAccess, actual.ConnectionProfile.WebRdpAccess);
            Assert.AreEqual(expected.ConnectionProfile.WebSshAccess, actual.ConnectionProfile.WebSshAccess);
            Assert.AreEqual(expected.VirtualMachineProfile.CreateOption, actual.VirtualMachineProfile.CreateOption);
            Assert.AreEqual(expected.VirtualMachineProfile.AdminUser.Username, actual.VirtualMachineProfile.AdminUser.Username);
            Assert.AreEqual(expected.VirtualMachineProfile.ImageReference.Sku, actual.VirtualMachineProfile.ImageReference.Sku);
            Assert.AreEqual(expected.VirtualMachineProfile.ImageReference.Offer, actual.VirtualMachineProfile.ImageReference.Offer);
            Assert.AreEqual(expected.VirtualMachineProfile.ImageReference.Publisher, actual.VirtualMachineProfile.ImageReference.Publisher);
            Assert.AreEqual(expected.VirtualMachineProfile.ImageReference.Version, actual.VirtualMachineProfile.ImageReference.Version);
            Assert.AreEqual(expected.VirtualMachineProfile.Sku.Name, actual.VirtualMachineProfile.Sku.Name);
            Assert.AreEqual(expected.VirtualMachineProfile.Sku.Capacity, actual.VirtualMachineProfile.Sku.Capacity);
            Assert.AreEqual(expected.VirtualMachineProfile.UsageQuota, actual.VirtualMachineProfile.UsageQuota);
            Assert.AreEqual(expected.VirtualMachineProfile.UseSharedPassword, actual.VirtualMachineProfile.UseSharedPassword);
            Assert.AreEqual(expected.SecurityProfile.OpenAccess, actual.SecurityProfile.OpenAccess);
        }
    }
}
