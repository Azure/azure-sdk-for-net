// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Azure.Core;
using System.Xml;
using Azure.Core.TestFramework;
using Azure.ResourceManager.LabServices.Models;
using NUnit.Framework;

namespace Azure.ResourceManager.LabServices.Tests
{
    public class LabVirtualMachineImageTests : LabServicesManagementTestBase
    {
        public LabVirtualMachineImageTests(bool isAsync)
                    : base(isAsync)//, RecordedTestMode.Record)
        {
        }

        [Test]
        [LiveOnly(Reason = "Test regularly fails due to timeout")]
        public async Task LabImageCRUDTest()
        {
            // Prepare lab resource.
            var rg = await CreateResourceGroupAsync();
            var labPlanCollection = rg.GetLabPlans();
            var labPlanData = GePlantData();
            var labPlanName = Recording.GenerateAssetName("sdklabplan-");
            var labPlan = (await labPlanCollection.CreateOrUpdateAsync(WaitUntil.Completed, labPlanName, labPlanData)).Value;

            // GetAll test
            var vmImageCollection = labPlan.GetLabVirtualMachineImages();
            var list = await vmImageCollection.GetAllAsync().ToEnumerableAsync();
            Assert.GreaterOrEqual(list.Count, 1);

            // Get test - 1
            var labImageName = list[0].Data.Name;
            var labImage = (await vmImageCollection.GetAsync(labImageName)).Value;
            Assert.AreEqual(labImageName, labImage.Data.Name);

            // Update with PUT test
            // No create available
            var vmImageData = new LabVirtualMachineImageData()
            {
                EnabledState = LabServicesEnableState.Disabled
            };
            labImage = (await vmImageCollection.CreateOrUpdateAsync(WaitUntil.Completed, labImageName, vmImageData)).Value;
            Assert.AreEqual(labImageName, labImage.Data.Name);
            Assert.AreEqual(vmImageData.EnabledState, labImage.Data.EnabledState);

            // Update with PATCH
            var patch = new LabVirtualMachineImagePatch() { EnabledState = LabServicesEnableState.Enabled };
            labImage = (await labImage.UpdateAsync(patch)).Value;
            Assert.AreEqual(labImageName, labImage.Data.Name);
            Assert.AreEqual(LabServicesEnableState.Enabled, labImage.Data.EnabledState);

            // Get test - 2
            labImage = (await labImage.GetAsync()).Value;
            Assert.AreEqual(labImageName, labImage.Data.Name);
            Assert.AreEqual(LabServicesEnableState.Enabled, labImage.Data.EnabledState);

            // Exists test
            bool boolResult = await vmImageCollection.ExistsAsync(labImageName);
            Assert.IsTrue(boolResult);
            boolResult = await vmImageCollection.ExistsAsync("foo");
            Assert.IsFalse(boolResult);
        }

        public LabPlanData GePlantData()
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
    }
}
