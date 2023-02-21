// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.LabServices.Models;
using NUnit.Framework;
using Azure.Core.TestFramework;
using System.Xml;
using Azure.Core;

namespace Azure.ResourceManager.LabServices.Tests
{
    public class LabPlanTests : LabServicesManagementTestBase
    {
        public LabPlanTests(bool isAsync)
                    : base(isAsync, RecordedTestMode.Record)
        {
        }

        [Test]
        public async Task LabPlanCRUDTest()
        {
            var rg = await CreateResourceGroupAsync();
            var collection = rg.GetLabPlans();

            // Create test
            var data = GetData();
            var resourceName = Recording.GenerateAssetName("sdklabplan-");
            var resource = (await collection.CreateOrUpdateAsync(WaitUntil.Completed, resourceName, data)).Value;
            AssertLabPlanData(data, resource.Data);

            // Get test - 1
            resource = await collection.GetAsync(resourceName);
            AssertLabPlanData(data, resource.Data);

            // Update with Put test
            data.DefaultConnectionProfile.WebSshAccess = LabVirtualMachineConnectionType.Private;
            resource = (await collection.CreateOrUpdateAsync(WaitUntil.Completed, resourceName, data)).Value;
            AssertLabPlanData(data, resource.Data);

            // Get test - 2
            resource = await resource.GetAsync();
            AssertLabPlanData(data, resource.Data);

            // Update with Patch test
            data.DefaultConnectionProfile.WebSshAccess = LabVirtualMachineConnectionType.Public;
            var patch = new LabPlanPatch()
            {
                DefaultConnectionProfile = new LabConnectionProfile()
                {
                    WebSshAccess = LabVirtualMachineConnectionType.Public,
                    WebRdpAccess = LabVirtualMachineConnectionType.None,
                    ClientSshAccess = LabVirtualMachineConnectionType.Public,
                    ClientRdpAccess = LabVirtualMachineConnectionType.Public,
                },
            };
            resource = (await resource.UpdateAsync(WaitUntil.Completed, patch)).Value;
            AssertLabPlanData(data, resource.Data);

            // Exists test
            bool boolResult = await collection.ExistsAsync(resourceName);
            Assert.IsTrue(boolResult);

            // GetAll test
            var list = await collection.GetAllAsync().ToEnumerableAsync();
            Assert.AreEqual(1, list.Count);
            AssertLabPlanData(data, list[0].Data);

            // Delete test
            await resource.DeleteAsync(WaitUntil.Completed);
            boolResult = await collection.ExistsAsync(resourceName);
            Assert.IsFalse(boolResult);
        }

        public LabPlanData GetData()
        {
            return new LabPlanData(DefaultLocation)
            {
                DefaultConnectionProfile = new LabConnectionProfile()
                {
                    WebSshAccess = LabVirtualMachineConnectionType.None,
                    WebRdpAccess = LabVirtualMachineConnectionType.None,
                    ClientSshAccess = LabVirtualMachineConnectionType.Public,
                    ClientRdpAccess = LabVirtualMachineConnectionType.Public,
                },
                DefaultAutoShutdownProfile = new LabAutoShutdownProfile()
                {
                    ShutdownOnDisconnect = LabServicesEnableState.Enabled,
                    ShutdownWhenNotConnected = LabServicesEnableState.Enabled,
                    ShutdownOnIdle = LabVirtualMachineShutdownOnIdleMode.UserAbsence,
                    DisconnectDelay = XmlConvert.ToTimeSpan("PT15M"),
                    NoConnectDelay = XmlConvert.ToTimeSpan("PT15M"),
                    IdleDelay = XmlConvert.ToTimeSpan("PT15M"),
                },
                SupportInfo = new LabPlanSupportInfo()
                {
                    Uri = new Uri("http://help.contoso.com"),
                    Email = "help@contoso.com",
                    Phone = "+1-202-555-0123",
                    Instructions = "Contact support for help.",
                },
                AllowedRegions = { AzureLocation.EastUS, AzureLocation.EastUS2 }
            };
        }

        public void AssertLabPlanData(LabPlanData expected, LabPlanData actual)
        {
            Assert.AreEqual(expected.DefaultConnectionProfile.WebSshAccess, actual.DefaultConnectionProfile.WebSshAccess);
            Assert.AreEqual(expected.DefaultConnectionProfile.WebRdpAccess, actual.DefaultConnectionProfile.WebRdpAccess);
            Assert.AreEqual(expected.DefaultConnectionProfile.ClientSshAccess, actual.DefaultConnectionProfile.ClientSshAccess);
            Assert.AreEqual(expected.DefaultConnectionProfile.ClientRdpAccess, actual.DefaultConnectionProfile.ClientRdpAccess);
            Assert.AreEqual(expected.DefaultAutoShutdownProfile.ShutdownOnDisconnect, actual.DefaultAutoShutdownProfile.ShutdownOnDisconnect);
            Assert.AreEqual(expected.DefaultAutoShutdownProfile.ShutdownWhenNotConnected, actual.DefaultAutoShutdownProfile.ShutdownWhenNotConnected);
            Assert.AreEqual(expected.DefaultAutoShutdownProfile.ShutdownOnIdle, actual.DefaultAutoShutdownProfile.ShutdownOnIdle);
            Assert.AreEqual(expected.DefaultAutoShutdownProfile.DisconnectDelay, actual.DefaultAutoShutdownProfile.DisconnectDelay);
            Assert.AreEqual(expected.DefaultAutoShutdownProfile.NoConnectDelay, actual.DefaultAutoShutdownProfile.NoConnectDelay);
            Assert.AreEqual(expected.DefaultAutoShutdownProfile.IdleDelay, actual.DefaultAutoShutdownProfile.IdleDelay);
            Assert.AreEqual(expected.SupportInfo.Uri, actual.SupportInfo.Uri);
            Assert.AreEqual(expected.SupportInfo.Email, actual.SupportInfo.Email);
            Assert.AreEqual(expected.SupportInfo.Phone, actual.SupportInfo.Phone);
            Assert.AreEqual(expected.SupportInfo.Instructions, actual.SupportInfo.Instructions);
            Assert.AreEqual(expected.AllowedRegions.Count, 2);
        }
    }
}
