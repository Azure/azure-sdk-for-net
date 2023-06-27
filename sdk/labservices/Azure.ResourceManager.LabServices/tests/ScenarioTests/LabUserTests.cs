// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using Azure.Core.TestFramework;
using Azure.ResourceManager.LabServices.Models;
using NUnit.Framework;

namespace Azure.ResourceManager.LabServices.Tests
{
    public class LabUserTests : LabServicesManagementTestBase
    {
        public LabUserTests(bool isAsync)
                    : base(isAsync)//, RecordedTestMode.Record)
        {
        }

        [Test]
        public async Task LabUserCRUD()
        {
            // Prepare lab resource
            var rg = await CreateResourceGroupAsync();
            var labCollection = rg.GetLabs();
            var labData = GetLabData();
            var labName = Recording.GenerateAssetName("sdklab-");
            var lab = (await labCollection.CreateOrUpdateAsync(WaitUntil.Completed, labName, labData)).Value;

            // Create test
            var userCollection = lab.GetLabUsers();
            var userData = GetUserData();
            string userName = Recording.GenerateAssetName("testuser-");
            var user = (await userCollection.CreateOrUpdateAsync(WaitUntil.Completed, userName, userData)).Value;
            AssertUserData(userData, user.Data);

            // Get test - 1
            user = await userCollection.GetAsync(userName);
            AssertUserData(userData, user.Data);

            // Update test with PUT
            userData.AdditionalUsageQuota = XmlConvert.ToTimeSpan("PT8H");
            user = (await userCollection.CreateOrUpdateAsync(WaitUntil.Completed, userName, userData)).Value;
            AssertUserData(userData, user.Data);

            // Get test - 2
            user = await user.GetAsync();
            AssertUserData(userData, user.Data);

            // Update with PATCH
            userData.AdditionalUsageQuota = XmlConvert.ToTimeSpan("PT6H");
            var patch = new LabUserPatch()
            {
                AdditionalUsageQuota = XmlConvert.ToTimeSpan("PT6H")
            };
            user = (await user.UpdateAsync(WaitUntil.Completed, patch)).Value;
            AssertUserData(userData, user.Data);

            // Exists test
            bool boolResult = await userCollection.ExistsAsync(userName);
            Assert.IsTrue(boolResult);

            // GetAll test
            var list = await userCollection.GetAllAsync().ToEnumerableAsync();
            Assert.AreEqual(1, list.Count);
            AssertUserData(userData, list[0].Data);

            // Delete test
            await user.DeleteAsync(WaitUntil.Completed);
            boolResult = await userCollection.ExistsAsync(userName);
            Assert.IsFalse(boolResult);
        }

        public LabData GetLabData()
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

        public LabUserData GetUserData()
        {
            return new LabUserData("testuser@contoso.com")
            {
                AdditionalUsageQuota = XmlConvert.ToTimeSpan("PT10H"),
            };
        }

        public void AssertUserData(LabUserData expected, LabUserData actual)
        {
            Assert.AreEqual(expected.Email, actual.Email);
            Assert.AreEqual(expected.AdditionalUsageQuota, actual.AdditionalUsageQuota);
        }
    }
}
