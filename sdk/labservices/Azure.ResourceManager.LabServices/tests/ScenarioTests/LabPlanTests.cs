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
                    : base(isAsync)//, RecordedTestMode.Record)
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
            Assert.That(boolResult, Is.True);

            // GetAll test
            var list = await collection.GetAllAsync().ToEnumerableAsync();
            Assert.That(list.Count, Is.EqualTo(1));
            AssertLabPlanData(data, list[0].Data);

            // Delete test
            await resource.DeleteAsync(WaitUntil.Completed);
            boolResult = await collection.ExistsAsync(resourceName);
            Assert.That(boolResult, Is.False);
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
            Assert.That(actual.DefaultConnectionProfile.WebSshAccess, Is.EqualTo(expected.DefaultConnectionProfile.WebSshAccess));
            Assert.That(actual.DefaultConnectionProfile.WebRdpAccess, Is.EqualTo(expected.DefaultConnectionProfile.WebRdpAccess));
            Assert.That(actual.DefaultConnectionProfile.ClientSshAccess, Is.EqualTo(expected.DefaultConnectionProfile.ClientSshAccess));
            Assert.That(actual.DefaultConnectionProfile.ClientRdpAccess, Is.EqualTo(expected.DefaultConnectionProfile.ClientRdpAccess));
            Assert.That(actual.DefaultAutoShutdownProfile.ShutdownOnDisconnect, Is.EqualTo(expected.DefaultAutoShutdownProfile.ShutdownOnDisconnect));
            Assert.That(actual.DefaultAutoShutdownProfile.ShutdownWhenNotConnected, Is.EqualTo(expected.DefaultAutoShutdownProfile.ShutdownWhenNotConnected));
            Assert.That(actual.DefaultAutoShutdownProfile.ShutdownOnIdle, Is.EqualTo(expected.DefaultAutoShutdownProfile.ShutdownOnIdle));
            Assert.That(actual.DefaultAutoShutdownProfile.DisconnectDelay, Is.EqualTo(expected.DefaultAutoShutdownProfile.DisconnectDelay));
            Assert.That(actual.DefaultAutoShutdownProfile.NoConnectDelay, Is.EqualTo(expected.DefaultAutoShutdownProfile.NoConnectDelay));
            Assert.That(actual.DefaultAutoShutdownProfile.IdleDelay, Is.EqualTo(expected.DefaultAutoShutdownProfile.IdleDelay));
            Assert.That(actual.SupportInfo.Uri, Is.EqualTo(expected.SupportInfo.Uri));
            Assert.That(actual.SupportInfo.Email, Is.EqualTo(expected.SupportInfo.Email));
            Assert.That(actual.SupportInfo.Phone, Is.EqualTo(expected.SupportInfo.Phone));
            Assert.That(actual.SupportInfo.Instructions, Is.EqualTo(expected.SupportInfo.Instructions));
            Assert.That(expected.AllowedRegions.Count, Is.EqualTo(2));
        }
    }
}
