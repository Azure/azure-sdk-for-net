// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Microsoft.Azure.Management.LabServices;
using Microsoft.Azure.Management.LabServices.Models;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using System;
using System.Linq;
using Xunit;

namespace LabServices.Tests
{
    public class LabTests : LabServicesTestBase
    {

        private readonly string rg = "labservices-sdk-testing";
        private readonly string labName = "test-sdk-lab";

        [Fact]
        public void ListLabsTest()
        {
            using (MockContext context = MockContext.Start(this.GetType()))
            {
                LabServicesClient client = GetManagedLabsClient(context);

                var labs = client.Labs.ListBySubscription().ToList();
                Assert.NotEmpty(labs);
                var lab = labs.First();
                Assert.IsType<Lab>(lab);

            }
        }

        [Fact]
        public void ListLabPlansTest()
        {
            using (MockContext context = MockContext.Start(this.GetType()))
            {
                LabServicesClient client = GetManagedLabsClient(context);

                var labPlans = client.LabPlans.ListBySubscription().ToList();
                Assert.NotEmpty(labPlans);
                var labPlan = labPlans.First();
                Assert.IsType<LabPlan>(labPlan);
            }
        }

        [Fact]
        public void CreateLabTest()
        {
            using (MockContext context = MockContext.Start(this.GetType()))
            {
                LabServicesClient client = GetManagedLabsClient(context);

                var lab = new Lab
                {
                    Title = "test lab",
                    Location = "westus",
                    AutoShutdownProfile = new AutoShutdownProfile
                    {
                        ShutdownOnDisconnect = EnableState.Disabled,
                        ShutdownOnIdle = ShutdownOnIdleMode.UserAbsence,
                        ShutdownWhenNotConnected = EnableState.Disabled,
                        IdleDelay = TimeSpan.FromMinutes(15)
                    },
                    ConnectionProfile = new ConnectionProfile
                    {
                        ClientRdpAccess = ConnectionType.Public,
                        ClientSshAccess = ConnectionType.Public,
                        WebRdpAccess = ConnectionType.None,
                        WebSshAccess = ConnectionType.None
                    },
                    VirtualMachineProfile = new VirtualMachineProfile
                    {
                        CreateOption = CreateOption.TemplateVM,
                        AdminUser = new Credentials
                        {
                            Username = "student",
                            Password = "placeholder#Bakljfh$#$%^&!#@$",
                        },
                        ImageReference = new ImageReference
                        {
                            Sku = "20_04-lts",
                            Offer = "0001-com-ubuntu-server-focal",
                            Publisher = "canonical",
                            Version = "latest"
                        },
                        Sku = new Sku
                        {
                            Name = "Basic",
                            Capacity = 0
                        },
                        UsageQuota = TimeSpan.FromHours(2),
                        UseSharedPassword = EnableState.Enabled
                    },
                    SecurityProfile = new SecurityProfile(openAccess: EnableState.Disabled)
                };

                var labResponse = client.Labs.BeginCreateOrUpdate(body: lab, resourceGroupName: rg, labName: labName);
                Assert.NotNull(labResponse);
                Assert.IsType<Lab>(labResponse);
                Assert.Equal(ProvisioningState.Creating, labResponse.ProvisioningState);
            }
        }

        [Fact]
        public void UpdateLabTest()
        {
            using (MockContext context = MockContext.Start(this.GetType()))
            {
                var newTitle = "new title";
                LabServicesClient client = GetManagedLabsClient(context);

                var labUpdate = new LabUpdate
                {
                    Title = newTitle
                };

                var labResponse = client.Labs.Update(body: labUpdate, resourceGroupName: rg, labName: labName);
                Assert.NotNull(labResponse);
                Assert.IsType<Lab>(labResponse);
                Assert.Equal(newTitle, labResponse.Title);
            }
        }

        [Fact]
        public async void DeleteLabTest()
        {
            using (MockContext context = MockContext.Start(this.GetType()))
            {
                LabServicesClient client = GetManagedLabsClient(context);

                var deleteResponse = await client.Labs.BeginDeleteWithHttpMessagesAsync(resourceGroupName: rg, labName: labName);
                Assert.NotNull(deleteResponse);
                Assert.NotNull(deleteResponse.Response);
                Assert.True(deleteResponse.Response.IsSuccessStatusCode);
            }
        }
    }
}

