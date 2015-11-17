//
// Copyright (c) Microsoft.  All rights reserved.
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//   http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
//

using Microsoft.WindowsAzure.Testing;

namespace Microsoft.WindowsAzure.Management.Compute.Testing
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;
    using Microsoft.WindowsAzure.Management.Compute.Models;
    using Microsoft.WindowsAzure.Management.Storage;
    using Microsoft.WindowsAzure.Management.Storage.Models;
    using Microsoft.Azure.Test;
    using Microsoft.Azure.Test.HttpRecorder;
    using Xunit;
    using Hyak.Common;

    public class VirtualMachineReproTests : TestBase, IUseFixture<TestFixtureData>
    {
        private TestFixtureData fixture;

        public void SetFixture(TestFixtureData data)
        {
            data.Instantiate(TestUtilities.GetCallingClass());
            fixture = data;
        }

        [Fact]
        public void CanUpdateHostedServiceExtendedProperties()
        {
            TestLogTracingInterceptor.Current.Start();
            using (var undoContext = UndoContext.Current)
            {
                undoContext.Start();
                var mgmt = fixture.GetManagementClient();
                var compute = fixture.GetComputeManagementClient();
                var storage = fixture.GetStorageManagementClient();

                try
                {
                    string storageAccountName = TestUtilities.GenerateName("psteststo").ToLower();
                    string serviceName = TestUtilities.GenerateName("pstestsvc");
                    string serviceLabel = serviceName + "1";
                    string serviceDescription = serviceName + "2";
                    string deploymentName = string.Format("{0}Prod", serviceName);
                    string deploymentLabel = deploymentName;

                    string location = mgmt.GetDefaultLocation("Storage", "Compute");
                    const string usWestLocStr = "West US";
                    if (mgmt.Locations.List().Any(
                        c => string.Equals(c.Name, usWestLocStr, StringComparison.OrdinalIgnoreCase)))
                    {
                        location = usWestLocStr;
                    }

                    storage.StorageAccounts.Create(
                        new StorageAccountCreateParameters
                        {
                            Location = location,
                            Label = storageAccountName,
                            Name = storageAccountName,
                            AccountType = StorageAccountTypes.StandardGRS
                        });

                    compute.HostedServices.Create(
                        new HostedServiceCreateParameters
                        {
                            Location = location,
                            Label = serviceDescription,
                            Description = serviceLabel,
                            ServiceName = serviceName,
                            ExtendedProperties = new Dictionary<string, string>
                            {
                                { "foo1", "bar" },
                                { "foo2", "baz" }
                            }
                        });

                    var hostedService = compute.HostedServices.Get(serviceName);
                    Assert.True(hostedService.Properties.Label == serviceDescription);
                    Assert.True(hostedService.Properties.Description == serviceLabel);
                    Assert.True(hostedService.Properties.ExtendedProperties["foo1"] == "bar");
                    Assert.True(hostedService.Properties.ExtendedProperties["foo2"] == "baz");

                    compute.HostedServices.Update(
                        serviceName,
                        new HostedServiceUpdateParameters
                        {
                            Label = serviceDescription,
                            Description = serviceLabel,
                            ExtendedProperties = new Dictionary<string, string>
                            {
                                { "bar", "foo3" },
                                { "baz", "foo4" }
                            }
                        });

                    hostedService = compute.HostedServices.Get(serviceName);
                    Assert.True(hostedService.Properties.Label == serviceDescription);
                    Assert.True(hostedService.Properties.Description == serviceLabel);
                    Assert.True(hostedService.Properties.ExtendedProperties["bar"] == "foo3");
                    Assert.True(hostedService.Properties.ExtendedProperties["baz"] == "foo4");

                    compute.HostedServices.Update(
                        serviceName,
                        new HostedServiceUpdateParameters
                        {
                            Label = serviceDescription,
                            ExtendedProperties = new Dictionary<string, string>
                            {
                                { "bar", "foo5" },
                                { "baz", "foo6" }
                            }
                        });

                    hostedService = compute.HostedServices.Get(serviceName);
                    Assert.True(hostedService.Properties.Label == serviceDescription);
                    Assert.True(hostedService.Properties.Description == serviceLabel);
                    Assert.True(hostedService.Properties.ExtendedProperties["bar"] == "foo5");
                    Assert.True(hostedService.Properties.ExtendedProperties["baz"] == "foo6");

                    compute.HostedServices.Update(
                        serviceName,
                        new HostedServiceUpdateParameters
                        {
                            Description = serviceLabel,
                            ExtendedProperties = new Dictionary<string, string>
                            {
                                { "bar", "foo7" },
                                { "baz", "foo8" }
                            }
                        });

                    hostedService = compute.HostedServices.Get(serviceName);
                    Assert.True(hostedService.Properties.Label == serviceDescription);
                    Assert.True(hostedService.Properties.Description == serviceLabel);
                    Assert.True(hostedService.Properties.ExtendedProperties["bar"] == "foo7");
                    Assert.True(hostedService.Properties.ExtendedProperties["baz"] == "foo8");

                    compute.HostedServices.Update(
                        serviceName,
                        new HostedServiceUpdateParameters
                        {
                            ExtendedProperties = new Dictionary<string, string>
                            {
                                { "bar", "foo9" },
                                { "baz", "foo10" }
                            }
                        });

                    hostedService = compute.HostedServices.Get(serviceName);
                    Assert.True(hostedService.Properties.Label == serviceDescription);
                    Assert.True(hostedService.Properties.Description == serviceLabel);
                    Assert.True(hostedService.Properties.ExtendedProperties["bar"] == "foo9");
                    Assert.True(hostedService.Properties.ExtendedProperties["baz"] == "foo10");

                    compute.HostedServices.Update(
                        serviceName,
                        new HostedServiceUpdateParameters
                        {
                            Label = serviceLabel,
                            Description = serviceDescription,
                            ExtendedProperties = new Dictionary<string, string>
                            {
                                { "bar", "foo1" },
                                { "baz", "foo2" }
                            }
                        });

                    hostedService = compute.HostedServices.Get(serviceName);
                    Assert.True(hostedService.Properties.Label == serviceLabel);
                    Assert.True(hostedService.Properties.Description == serviceDescription);
                    Assert.True(hostedService.Properties.ExtendedProperties["bar"] == "foo1");
                    Assert.True(hostedService.Properties.ExtendedProperties["baz"] == "foo2");

                    var result = compute.HostedServices.DeleteAll(serviceName);
                }
                finally
                {
                    undoContext.Dispose();
                    mgmt.Dispose();
                    compute.Dispose();
                    storage.Dispose();
                    TestLogTracingInterceptor.Current.Stop();
                }
            }
        }

        [Fact]
        public void CanUpdateVMInputEndpoints()
        {
            TestLogTracingInterceptor.Current.Start();
            using (var undoContext = UndoContext.Current)
            {
                undoContext.Start();
                var mgmt = fixture.GetManagementClient();
                var compute = fixture.GetComputeManagementClient();
                var storage = fixture.GetStorageManagementClient();

                try
                {
                    string storageAccountName = TestUtilities.GenerateName("psteststo").ToLower();
                    string serviceName = TestUtilities.GenerateName("pstestsvc");
                    string serviceLabel = serviceName + "1";
                    string serviceDescription = serviceName + "2";
                    string deploymentName = string.Format("{0}Prod", serviceName);
                    string deploymentLabel = deploymentName;

                    string location = mgmt.GetDefaultLocation("Storage", "Compute");
                    const string usWestLocStr = "West US";
                    if (mgmt.Locations.List().Any(
                        c => string.Equals(c.Name, usWestLocStr, StringComparison.OrdinalIgnoreCase)))
                    {
                        location = usWestLocStr;
                    }

                    storage.StorageAccounts.Create(
                        new StorageAccountCreateParameters
                        {
                            Location = location,
                            Label = storageAccountName,
                            Name = storageAccountName,
                            AccountType = StorageAccountTypes.StandardGRS
                        });

                    compute.HostedServices.Create(
                        new HostedServiceCreateParameters
                        {
                            Location = location,
                            Label = serviceDescription,
                            Description = serviceLabel,
                            ServiceName = serviceName
                        });

                    var image = compute.VirtualMachineOSImages.List()
                                .FirstOrDefault(s => string.Equals(s.OperatingSystemType,
                                                                   "Windows",
                                                                   StringComparison.OrdinalIgnoreCase) &&
                                                     s.LogicalSizeInGB < 100);
                    Assert.True(!string.IsNullOrEmpty(image.IOType));
                    compute.VirtualMachines.CreateDeployment(
                        serviceName,
                        new VirtualMachineCreateDeploymentParameters
                        {
                            Name = deploymentName,
                            DeploymentSlot = DeploymentSlot.Production,
                            Label = deploymentLabel,
                            Roles = new List<Role>()
                            {
                                new Role()
                                {
                                    ProvisionGuestAgent = false,
                                    ResourceExtensionReferences = null,
                                    RoleName = serviceName,
                                    RoleType = VirtualMachineRoleType.PersistentVMRole.ToString(),
                                    RoleSize = VirtualMachineRoleSize.Large.ToString(),
                                    OSVirtualHardDisk =
                                        new OSVirtualHardDisk
                                        {
                                            HostCaching = VirtualHardDiskHostCaching.ReadWrite,
                                            SourceImageName = image.Name,
                                            MediaLink = new Uri(string.Format(
                                                "http://{1}.blob.core.windows.net/myvhds/{0}.vhd",
                                                serviceName,
                                                storageAccountName)),
                                            ResizedSizeInGB = 128,
                                        },
                                    DataVirtualHardDisks =
                                    new List<DataVirtualHardDisk>(
                                        Enumerable.Repeat(new DataVirtualHardDisk
                                        {
                                            Label = "testDataDiskLabel5",
                                            LogicalUnitNumber = 0,
                                            LogicalDiskSizeInGB = 1,
                                            HostCaching = "ReadOnly",
                                            MediaLink = new Uri(string.Format(
                                                "http://{1}.blob.core.windows.net/myvhds/{0}5.vhd",
                                                serviceName,
                                                storageAccountName)),
                                        }, 1)),
                                    ConfigurationSets =
                                        new List<ConfigurationSet>()
                                        {
                                            new ConfigurationSet
                                            {
                                                AdminUserName = "FooBar12",
                                                AdminPassword = "foobarB@z21!",
                                                ConfigurationSetType = ConfigurationSetTypes
                                                                      .WindowsProvisioningConfiguration,
                                                ComputerName = serviceName,
                                                HostName = string.Format("{0}.cloudapp.net", serviceName),
                                                EnableAutomaticUpdates = false,
                                                TimeZone = "Pacific Standard Time",
                                                AdditionalUnattendContent = new AdditionalUnattendContentSettings
                                                {
                                                    UnattendPasses = new List<UnattendPassSettings>
                                                    {
                                                        new UnattendPassSettings
                                                        {
                                                            PassName = "oobeSystem",
                                                            UnattendComponents = new List<UnattendComponent>
                                                            {
                                                                new UnattendComponent
                                                                {
                                                                    ComponentName = "Microsoft-Windows-Shell-Setup",
                                                                    UnattendComponentSettings = new List<ComponentSetting>
                                                                    {
                                                                        new ComponentSetting
                                                                        {
                                                                            SettingName = "AutoLogon",
                                                                            Content = "<AutoLogon><Enabled>true</Enabled><LogonCount>5</LogonCount><Username>Foo12</Username><Password><Value>BaR@123pslibtest1269</Value><PlainText>true</PlainText></Password></AutoLogon>",
                                                                        }
                                                                    }
                                                                }
                                                            }
                                                        }
                                                    }
                                                }
                                            },
                                            new ConfigurationSet
                                            {
                                                ConfigurationSetType = "NetworkConfiguration",
                                                InputEndpoints =
                                                    new List<InputEndpoint>
                                                    {
                                                        new InputEndpoint
                                                        {
                                                            LocalPort = 3389,
                                                            Name = "RDP",
                                                            Port = 52777,
                                                            Protocol = InputEndpointTransportProtocol.Tcp,
                                                            VirtualIPAddress = "157.56.161.177",
                                                            EnableDirectServerReturn = false
                                                        },
                                                        new InputEndpoint
                                                        {
                                                            LocalPort = 1111,
                                                            Name = "Test",
                                                            Port = 2222,
                                                            Protocol = InputEndpointTransportProtocol.Tcp,
                                                            LoadBalancedEndpointSetName = serviceName,
                                                            LoadBalancerName = serviceName
                                                        }
                                                    }
                                            }
                                        }
                                    }
                                },
                                LoadBalancers = new List<LoadBalancer>()
                                {
                                    new LoadBalancer
                                    {
                                        Name = serviceName,
                                        FrontendIPConfiguration = new FrontendIPConfiguration
                                        {
                                            Type = "Private"
                                        }
                                    }
                                }
                        });

                    // Verify service return
                    var getSvcResult = compute.HostedServices.Get(serviceName);
                    Assert.True(getSvcResult.ComputeCapabilities == null
                             || getSvcResult.ComputeCapabilities.VirtualMachinesRoleSizes.Count() > 0);
                    Assert.True(getSvcResult.ComputeCapabilities == null
                             || getSvcResult.ComputeCapabilities.WebWorkerRoleSizes.Count() > 0);

                    var listSvcResult = compute.HostedServices.List()
                                               .FirstOrDefault(s => s.ServiceName.Equals(serviceName));
                    Assert.True(listSvcResult.ComputeCapabilities == null
                             || listSvcResult.ComputeCapabilities.VirtualMachinesRoleSizes.Count() > 0);
                    Assert.True(listSvcResult.ComputeCapabilities == null
                             || listSvcResult.ComputeCapabilities.WebWorkerRoleSizes.Count() > 0);

                    // Test deployment events, which are managed by the service side, not users.
                    // Therefore, not all subscription's recorded data will have these parts.
                    // Here are some sample responses injected into the recorded data:
                    /* <DeploymentEventCollection xmlns="http://schemas.microsoft.com/windowsazure" xmlns:i="http://www.w3.org/2001/XMLSchema-instance">
                         <RebootEvents>
                           <RebootEvent>
                             <RoleName>KenazDemo-A4</RoleName>
                             <InstanceName>KenazDemo-A4</InstanceName>
                             <RebootReason>Virtual machine rebooted due to planned maintenance event.</RebootReason>
                             <RebootStartTime>2014-09-14T03:50:09.4299879Z</RebootStartTime>
                           </RebootEvent>
                           <RebootEvent>
                             <RoleName>KenazDemo-D4</RoleName>
                             <InstanceName>KenazDemo-D4</InstanceName>
                             <RebootReason>Virtual machine rebooted due to planned maintenance event.</RebootReason>
                             <RebootStartTime>2014-09-14T05:22:03.5531204Z</RebootStartTime>
                           </RebootEvent>
                         </RebootEvents>
                       </DeploymentEventCollection> */
                    //
                    // Request Uri needs to be modified accordingly as well:
                    // ".../events?starttime=2015-01-10T08:00:00.0000000Z&endtime=2015-01-20T08:00:00.0000000Z"
                    var startTime = ComputeManagementTestUtilities.GetDeploymentEventStartDate();
                    var endTime = ComputeManagementTestUtilities.GetDeploymentEventEndDate();
                    var events = compute.Deployments.ListEvents(serviceName, deploymentName, startTime, endTime);
                    var slot = DeploymentSlot.Production;
                    Func<RebootEvent, bool> func = e => !string.IsNullOrEmpty(e.RoleName)
                        && !string.IsNullOrEmpty(e.InstanceName)
                        && !string.IsNullOrEmpty(e.RebootReason)
                        && e.RebootStartTime.Value >= DateTime.MinValue.AddDays(1) && e.RebootStartTime.Value <= DateTime.MaxValue.AddDays(-1);
                    Assert.True(!events.DeploymentEvents.Any() || events.DeploymentEvents.All(e => func(e)));
                    events = compute.Deployments.ListEventsBySlot(serviceName, slot, startTime, endTime);
                    Assert.True(!events.DeploymentEvents.Any() || events.DeploymentEvents.All(e => func(e)));

                    // Add a VM to the deployment
                    compute.VirtualMachines.Create(
                        serviceName,
                        deploymentName,
                        new VirtualMachineCreateParameters()
                        {
                            RoleName = serviceName + "2",
                            RoleSize = VirtualMachineRoleSize.ExtraSmall.ToString(),
                            OSVirtualHardDisk =
                                 new OSVirtualHardDisk
                                 {
                                     HostCaching = VirtualHardDiskHostCaching.ReadWrite,
                                     SourceImageName = image.Name,
                                     MediaLink = new Uri(string.Format(
                                         "http://{1}.blob.core.windows.net/myvhds/{0}3.vhd",
                                         serviceName,
                                         storageAccountName)),
                                 },
                            DataVirtualHardDisks =
                                new List<DataVirtualHardDisk>(
                                    Enumerable.Repeat(new DataVirtualHardDisk
                                    {
                                        Label = "testDataDiskLabel",
                                        LogicalUnitNumber = 0,
                                        LogicalDiskSizeInGB = 1,
                                        HostCaching = "ReadOnly",
                                        MediaLink = new Uri(string.Format(
                                            "http://{1}.blob.core.windows.net/myvhds/{0}4.vhd",
                                            serviceName,
                                            storageAccountName)),
                                    }, 1)),
                            ConfigurationSets =
                                new List<ConfigurationSet>()
                                {
                                    new ConfigurationSet
                                    {
                                        AdminUserName = "FooBar12",
                                        AdminPassword = "foobarB@z21!",
                                        ConfigurationSetType = ConfigurationSetTypes
                                                              .WindowsProvisioningConfiguration,
                                        ComputerName = serviceName,
                                        HostName = string.Format("{0}.cloudapp.net", serviceName),
                                        EnableAutomaticUpdates = false,
                                        TimeZone = "Pacific Standard Time",
                                        AdditionalUnattendContent = new AdditionalUnattendContentSettings
                                        {
                                            UnattendPasses = new List<UnattendPassSettings>
                                            {
                                                new UnattendPassSettings
                                                {
                                                    PassName = "oobeSystem",
                                                    UnattendComponents = new List<UnattendComponent>
                                                    {
                                                        new UnattendComponent
                                                        {
                                                            ComponentName = "Microsoft-Windows-Shell-Setup",
                                                            UnattendComponentSettings = new List<ComponentSetting>
                                                            {
                                                                new ComponentSetting
                                                                {
                                                                    SettingName = "AutoLogon",
                                                                    Content = "<AutoLogon><Enabled>true</Enabled><LogonCount>5</LogonCount><Username>Foo12</Username><Password><Value>BaR@123pslibtest1269</Value><PlainText>true</PlainText></Password></AutoLogon>",
                                                                }
                                                            }
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                    },
                                    new ConfigurationSet
                                    {
                                        ConfigurationSetType = "NetworkConfiguration",
                                        InputEndpoints =
                                            new List<InputEndpoint>
                                            {
                                                new InputEndpoint()
                                                {
                                                    LocalPort = 3389,
                                                    Name = "RDP",
                                                    Port = 52778,
                                                    Protocol = InputEndpointTransportProtocol.Tcp,
                                                    VirtualIPAddress = "157.56.161.177",
                                                    EnableDirectServerReturn = false
                                                }
                                            }
                                    }
                                },
                            ProvisionGuestAgent = true,
                            ResourceExtensionReferences = new List<ResourceExtensionReference>
                            {
                                new ResourceExtensionReference
                                {
                                    Name = "BGInfo",
                                    Publisher = "Microsoft.Compute",
                                    Version = "1.*",
                                    ReferenceName = "BGInfo",
                                    State = "Enable",
                                    ResourceExtensionParameterValues = null,
                                    ForceUpdate = true
                                }
                            }
                        });

                    // Test ILB & VM Update
                    var endpoint = compute.VirtualMachines
                                          .Get(serviceName, deploymentName, serviceName)
                                          .ConfigurationSets.First(
                        c => c.InputEndpoints.Any()).InputEndpoints.First();

                    compute.VirtualMachines.UpdateLoadBalancedEndpointSet(
                        serviceName,
                        deploymentName,
                        new VirtualMachineUpdateLoadBalancedSetParameters
                        {
                            LoadBalancedEndpoints = 
                            new List<VirtualMachineUpdateLoadBalancedSetParameters.InputEndpoint>
                            {
                                new VirtualMachineUpdateLoadBalancedSetParameters.InputEndpoint
                                {
                                    LoadBalancedEndpointSetName = serviceName,
                                    LoadBalancerName = serviceName,
                                    LocalPort = 11111,
                                    Port = 22222,
                                    Name = endpoint.Name,
                                    Protocol = endpoint.Protocol,
                                    Rules = new List<AccessControlListRule>
                                    {
                                        new AccessControlListRule
                                        {
                                            Action = "PERMIT",
                                            Description = "TestILBACL",
                                            Order = 0,
                                            RemoteSubnet = "192.168.50.8/32"
                                        }
                                    },
                                    EnableDirectServerReturn = endpoint.EnableDirectServerReturn,
                                    LoadBalancerProbe = endpoint.LoadBalancerProbe,
                                    VirtualIPAddress = endpoint.VirtualIPAddress,
                                    IdleTimeoutInMinutes = 10,
                                    LoadBalancerDistribution = "sourceIP"
                                }
                            }
                        });

                    var endpoint1 = compute.VirtualMachines
                                           .Get(serviceName, deploymentName, serviceName)
                                           .ConfigurationSets.First(c => c.InputEndpoints.Any())
                                           .InputEndpoints.First(e => e.Name.Equals("Test"));

                    Assert.True(endpoint1.EndpointAcl.Rules.Any(
                        r => r.Action.Equals("permit") && r.Description.Equals("TestILBACL")));

                    Assert.True(endpoint1.LoadBalancerDistribution == "sourceIP");
                    
                    // Test Update operation for AvailabilitySetName + BGInfo Extension
                    compute.VirtualMachines.Update(
                        serviceName,
                        deploymentName,
                        serviceName,
                        new VirtualMachineUpdateParameters()
                        {
                            Label = "test",
                            RoleName = serviceName,
                            RoleSize = VirtualMachineRoleSize.ExtraSmall.ToString(),
                            ProvisionGuestAgent = true,
                            ConfigurationSets = new List<ConfigurationSet>(),
                            OSVirtualHardDisk = new OSVirtualHardDisk(),
                            DataVirtualHardDisks = null,
                            ResourceExtensionReferences = new List<ResourceExtensionReference>()
                        });

                    var updatedRole = compute.Deployments.GetByName(serviceName, deploymentName)
                                             .Roles.First(r => r.RoleName == serviceName);

                    Assert.True(updatedRole.DataVirtualHardDisks.Count(d => d.Label == "testDataDiskLabel5") == 1);
                    Assert.True(updatedRole.DataVirtualHardDisks.All(a => !string.IsNullOrEmpty(a.IOType)));
                    Assert.True(!string.IsNullOrEmpty(updatedRole.OSVirtualHardDisk.IOType));

                    Assert.True(!string.IsNullOrEmpty(
                        compute.VirtualMachineDisks.GetDataDisk(serviceName, deploymentName, serviceName, 0).IOType));

                    Assert.True(!compute.VirtualMachineDisks.ListDisks().Any()
                        || compute.VirtualMachineDisks.ListDisks().All(a => !string.IsNullOrEmpty(a.IOType)));


                    compute.VirtualMachines.Update(
                        serviceName,
                        deploymentName,
                        serviceName,
                        new VirtualMachineUpdateParameters()
                        {
                            Label = "test",
                            RoleName = serviceName,
                            RoleSize = VirtualMachineRoleSize.ExtraSmall.ToString(),
                            ProvisionGuestAgent = true,
                            ConfigurationSets = new List<ConfigurationSet>(),
                            OSVirtualHardDisk = new OSVirtualHardDisk(),
                            DataVirtualHardDisks = new List<DataVirtualHardDisk>(),
                            AvailabilitySetName = "test",
                            ResourceExtensionReferences = new List<ResourceExtensionReference>
                            {
                                new ResourceExtensionReference
                                {
                                    Name = "BGInfo",
                                    Publisher = "Microsoft.Compute",
                                    Version = "1.*",
                                    ReferenceName = "BGInfo",
                                    State = "Enable",
                                    ResourceExtensionParameterValues = null,
                                    ForceUpdate = true
                                }
                            }
                        });

                    updatedRole = compute.Deployments.GetByName(serviceName, deploymentName)
                                         .Roles.First(r => r.RoleName == serviceName);

                    Assert.True(updatedRole.ResourceExtensionReferences.Any(
                        e => e.Name == "BGInfo" && e.Publisher == "Microsoft.Compute"));

                    Assert.True(!updatedRole.DataVirtualHardDisks.Any());

                    compute.VirtualMachines.Update(
                        serviceName,
                        deploymentName,
                        serviceName + "2",
                        new VirtualMachineUpdateParameters()
                        {
                            Label = "test",
                            RoleName = serviceName + "2",
                            RoleSize = VirtualMachineRoleSize.ExtraSmall.ToString(),
                            ProvisionGuestAgent = true,
                            ResourceExtensionReferences = new List<ResourceExtensionReference>(),
                            ConfigurationSets = new List<ConfigurationSet>(),
                            OSVirtualHardDisk = new OSVirtualHardDisk(),
                            DataVirtualHardDisks = compute.VirtualMachines
                                                          .Get(serviceName, deploymentName, serviceName + "2")
                                                          .DataVirtualHardDisks
                        });

                    bool vmIsReady = false;
                    string roleName = serviceName + "2";
                    var deployment = compute.Deployments.GetByName(
                            serviceName,
                            deploymentName);

                    Assert.True(deployment.Label == deploymentLabel);

                    while (!vmIsReady)
                    {
                        TestUtilities.Wait(TimeSpan.FromSeconds(30));

                        deployment = compute.Deployments.GetByName(
                            serviceName,
                            deploymentName);

                        var vm = deployment.RoleInstances.FirstOrDefault(
                            r => string.Equals(r.RoleName, roleName, StringComparison.OrdinalIgnoreCase));

                        vmIsReady = string.Equals(
                            vm.InstanceStatus, RoleInstanceStatus.ReadyRole, StringComparison.OrdinalIgnoreCase);
                    };

                    compute.VirtualMachines.Shutdown(
                        serviceName,
                        deploymentName,
                        roleName,
                        new VirtualMachineShutdownParameters
                        {
                            PostShutdownAction = PostShutdownAction.Stopped
                        });


                    compute.VirtualMachines.Shutdown(
                        serviceName,
                        deploymentName,
                        serviceName,
                        new VirtualMachineShutdownParameters
                        {
                            PostShutdownAction = PostShutdownAction.Stopped
                        });

                    bool vmIsStopped = false;
                    while (!vmIsStopped)
                    {
                        TestUtilities.Wait(TimeSpan.FromSeconds(30));

                        deployment = compute.Deployments.GetByName(
                            serviceName,
                            deploymentName);

                        var vm1 = deployment.RoleInstances.FirstOrDefault(
                            r => string.Equals(r.RoleName, roleName, StringComparison.OrdinalIgnoreCase));

                        var vm2 = deployment.RoleInstances.FirstOrDefault(
                            r => string.Equals(r.RoleName, serviceName, StringComparison.OrdinalIgnoreCase));

                        vmIsStopped = string.Equals(vm1.InstanceStatus, RoleInstanceStatus.StoppedVM, StringComparison.OrdinalIgnoreCase)
                                   && string.Equals(vm2.InstanceStatus, RoleInstanceStatus.StoppedVM, StringComparison.OrdinalIgnoreCase);
                    };

                    string vmImageName = "img" + serviceName;
                    compute.VirtualMachines.CaptureVMImage(
                        serviceName,
                        deploymentName,
                        roleName,
                        new VirtualMachineCaptureVMImageParameters
                        {
                            OSState = "Specialized",
                            VMImageLabel = serviceName,
                            VMImageName = vmImageName
                        });

                    compute.VirtualMachines.CaptureVMImage(
                        serviceName,
                        deploymentName,
                        roleName,
                        new VirtualMachineCaptureVMImageParameters
                        {
                            OSState = "Generalized",
                            VMImageLabel = serviceName,
                            VMImageName = vmImageName + "2"
                        });

                    var vmImageList = compute.VirtualMachineVMImages.List();
                    Assert.True(vmImageList.Count() >= 2);
                    Assert.True(vmImageList.All(a => !string.IsNullOrEmpty(a.OSDiskConfiguration.IOType)));
                    Assert.True(vmImageList.All(a => !a.DataDiskConfigurations.Any()
                     || a.DataDiskConfigurations.All(d => !string.IsNullOrEmpty(d.IOType))));

                    var dataDiskName = vmImageList.First(t => string.Equals(t.Name, vmImageName + "2"))
                                                  .DataDiskConfigurations.First().Name;

                    compute.VirtualMachineVMImages.Update(
                        vmImageName + "2",
                        new VirtualMachineVMImageUpdateParameters
                        {
                            Label = "testLabel",
                            OSDiskConfiguration = new OSDiskConfigurationUpdateParameters
                            {
                                HostCaching = "ReadOnly"
                            },
                            DataDiskConfigurations = new List<DataDiskConfigurationUpdateParameters>(
                                Enumerable.Repeat(new DataDiskConfigurationUpdateParameters
                                {
                                    Name = dataDiskName,
                                    LogicalUnitNumber = 0,
                                    HostCaching = "ReadWrite"
                                }, 1)),
                            Description = "testDescription"
                        });

                    // Test VM Image Create API
                    var updatedVMImageResult = compute.VirtualMachineVMImages.List()
                                                      .First(t => t.Name == vmImageName + "2");

                    var storageAccount = storage.StorageAccounts.Get(storageAccountName);
                    var storageAccountKey = storage.StorageAccounts.GetKeys(storageAccountName).PrimaryKey;
                    var storageEndpoint = storageAccount.StorageAccount.Properties.Endpoints[0];

                    var vmImageDestOSBlobName = "destVMImage" + serviceName + "OS.vhd";
                    var destOSBlobUri = ComputeManagementTestUtilities.CopyBlobInStorage(
                        storageAccountName,
                        updatedVMImageResult.OSDiskConfiguration.MediaLink,
                        "myvhds",
                        vmImageDestOSBlobName);

                    var vmImageDestDataBlobName1 = "destVMImage" + serviceName + "Data1.vhd";
                    var destDataBlobUri1 = ComputeManagementTestUtilities.CopyBlobInStorage(
                        storageAccountName,
                        updatedVMImageResult.OSDiskConfiguration.MediaLink,
                        "myvhds",
                        vmImageDestDataBlobName1);

                    var vmImageDestDataBlobName2 = "destVMImage" + serviceName + "Data2.vhd";
                    var destDataBlobUri2 = ComputeManagementTestUtilities.CopyBlobInStorage(
                        storageAccountName,
                        updatedVMImageResult.OSDiskConfiguration.MediaLink,
                        "myvhds",
                        vmImageDestDataBlobName2);

                    var createdVMImageResult = compute.VirtualMachineVMImages.Create(
                        new VirtualMachineVMImageCreateParameters
                        {
                            Name = updatedVMImageResult.Name + "dest",
                            Label = "test",
                            Description = "test",
                            Eula = "http://test.com",
                            SmallIconUri = "test",
                            IconUri = "test",
                            PrivacyUri = new Uri("http://test.com/"),
                            ShowInGui = false,
                            ImageFamily = "test",
                            Language = "test",
                            PublishedDate = DateTime.Now,
                            RecommendedVMSize = VirtualMachineRoleSize.Small,
                            OSDiskConfiguration = new OSDiskConfigurationCreateParameters
                            {
                                HostCaching = VirtualHardDiskHostCaching.ReadWrite,
                                OS = VirtualMachineVMImageOperatingSystemType.Windows,
                                OSState = VirtualMachineVMImageOperatingSystemState.Generalized,
                                MediaLink = destOSBlobUri
                            },
                            DataDiskConfigurations = new List<DataDiskConfigurationCreateParameters>(){
                                new DataDiskConfigurationCreateParameters
                                {
                                    HostCaching = VirtualHardDiskHostCaching.ReadOnly,
                                    LogicalUnitNumber = 0,
                                    MediaLink = destDataBlobUri1
                                },
                                new DataDiskConfigurationCreateParameters
                                {
                                    HostCaching = VirtualHardDiskHostCaching.ReadOnly,
                                    LogicalUnitNumber = 1,
                                    MediaLink = destDataBlobUri2
                                }}
                        });

                    var createdVMImage = compute.VirtualMachineVMImages.List()
                                                .First(t => t.Name == updatedVMImageResult.Name + "dest");

                    Assert.True(createdVMImage.Label == "test");
                    Assert.True(createdVMImage.Description == "test");
                    Assert.True(createdVMImage.Eula == "http://test.com");
                    Assert.True(createdVMImage.SmallIconUri == "test");
                    Assert.True(createdVMImage.IconUri == "test");
                    Assert.True(createdVMImage.PrivacyUri.AbsoluteUri == "http://test.com/");
                    Assert.True(createdVMImage.ShowInGui == false);
                    Assert.True(createdVMImage.ImageFamily == "test");
                    Assert.True(createdVMImage.Language == "test");
                    Assert.True(createdVMImage.PublishedDate != null);
                    Assert.True(createdVMImage.RecommendedVMSize == VirtualMachineRoleSize.Small);
                    Assert.True(createdVMImage.OSDiskConfiguration.HostCaching == VirtualHardDiskHostCaching.ReadWrite);
                    Assert.True(createdVMImage.OSDiskConfiguration.OperatingSystem == VirtualMachineVMImageOperatingSystemType.Windows);
                    Assert.True(createdVMImage.OSDiskConfiguration.OSState == VirtualMachineVMImageOperatingSystemState.Generalized);
                    Assert.True(createdVMImage.OSDiskConfiguration.MediaLink == destOSBlobUri);
                    Assert.True(createdVMImage.DataDiskConfigurations[0].HostCaching == VirtualHardDiskHostCaching.ReadOnly);
                    Assert.True(createdVMImage.DataDiskConfigurations[0].LogicalUnitNumber == 0);
                    Assert.True(createdVMImage.DataDiskConfigurations[0].MediaLink == destDataBlobUri1);
                    Assert.True(createdVMImage.DataDiskConfigurations[1].HostCaching == VirtualHardDiskHostCaching.ReadOnly);
                    Assert.True(createdVMImage.DataDiskConfigurations[1].LogicalUnitNumber == 1);
                    Assert.True(createdVMImage.DataDiskConfigurations[1].MediaLink == destDataBlobUri2);

                    compute.VirtualMachineVMImages.Delete(createdVMImage.Name, true);

                    // Test Add Role with VMImageName and AvailabilitySetName
                    compute.VirtualMachines.Create(
                        serviceName,
                        deploymentName,
                        new VirtualMachineCreateParameters()
                        {
                            RoleName = serviceName + "3",
                            RoleSize = VirtualMachineRoleSize.ExtraSmall.ToString(),
                            VMImageName = vmImageName,
                            AvailabilitySetName = "test",
                            ConfigurationSets =
                                new List<ConfigurationSet>()
                                {
                                    new ConfigurationSet
                                    {
                                        ConfigurationSetType = "NetworkConfiguration",
                                        InputEndpoints =
                                            new List<InputEndpoint>
                                            {
                                                new InputEndpoint()
                                                {
                                                    LocalPort = 3389,
                                                    Name = "RDP",
                                                    Port = 52778,
                                                    Protocol = InputEndpointTransportProtocol.Tcp,
                                                    VirtualIPAddress = "157.56.161.177",
                                                    EnableDirectServerReturn = false
                                                }
                                            }
                                    }
                                },
                            ProvisionGuestAgent = true,
                            ResourceExtensionReferences = new List<ResourceExtensionReference>
                            {
                                new ResourceExtensionReference
                                {
                                    Name = "BGInfo",
                                    Publisher = "Microsoft.Compute",
                                    Version = "1.*",
                                    ReferenceName = "BGInfo",
                                    State = "Enable",
                                    ResourceExtensionParameterValues = null,
                                    ForceUpdate = true
                                }
                            },
                            VMImageInput = new VMImageInput
                            {
                                OSDiskConfiguration = new OSDiskConfiguration
                                {
                                    ResizedSizeInGB = 128,
                                },
                                DataDiskConfigurations = new List<DataDiskConfiguration>
                                {
                                    new DataDiskConfiguration
                                    {
                                        DiskName = "DateDisk1",
                                        ResizedSizeInGB = 200,
                                    }
                                },
                            },
                        });

                    // Test VM Image Publisher APIs
                    string pirImageName = vmImageName;
                    string imageShareType = "Private";
                    string errorCodeStr = "ForbiddenError";
                    bool isPublisher = true;
                    try
                    {
                        compute.VirtualMachineVMImages.GetDetails(pirImageName);
                    }
                    catch (CloudException e)
                    {
                        if (e != null && e.Error.Code.Equals(errorCodeStr))
                        {
                            isPublisher = false;
                        }
                    }

                    try
                    {
                        compute.VirtualMachineVMImages.Replicate(
                            pirImageName,
                            new VirtualMachineVMImageReplicateParameters
                            {
                                TargetLocations = new string[] { mgmt.GetDefaultLocation() },
                                ComputeImageAttributes = new ComputeImageAttributes
                                {
                                    Offer = "test",
                                    Sku = "test",
                                    Version = "test"
                                },
                                MarketplaceImageAttributes = null
                            });
                    }
                    catch (CloudException e)
                    {
                        Assert.True(!isPublisher && e != null && e.Error.Code.Equals(errorCodeStr));
                    }

                    try
                    {
                        compute.VirtualMachineVMImages.Share(pirImageName, imageShareType);
                    }
                    catch (CloudException e)
                    {
                        Assert.True(!isPublisher && e != null && e.Error.Code.Equals(errorCodeStr));
                    }

                    try
                    {
                        compute.VirtualMachineVMImages.Unreplicate(pirImageName);
                    }
                    catch (CloudException e)
                    {
                        Assert.True(!isPublisher && e != null && e.Error.Code.Equals(errorCodeStr));
                    }

                    // Delete VM images
                    compute.VirtualMachineVMImages.Delete(vmImageName, true);
                    compute.VirtualMachineVMImages.Delete(vmImageName + "2", true);

                    // Test OS Image Capture API
                    string osImageName = "osImg" + serviceName;
                    compute.VirtualMachines.CaptureOSImage(
                        serviceName,
                        deploymentName,
                        serviceName,
                        new VirtualMachineCaptureOSImageParameters
                        {
                            TargetImageName = osImageName,
                            TargetImageLabel = osImageName,
                            PostCaptureAction = PostCaptureAction.Delete
                        });

                    var osImageList = compute.VirtualMachineOSImages.List();
                    Assert.True(osImageList.Count() >= 1);
                    Assert.True(osImageList.Count(g => g.Name.Equals(osImageName)) >= 1);
                    Assert.True(compute.VirtualMachineOSImages.Get(osImageName) != null);

                    // Test OS Image Update and Add API
                    var updateResult = compute.VirtualMachineOSImages.Update(
                        osImageName,
                        new VirtualMachineOSImageUpdateParameters
                        {
                            Description = "update",
                            Label = "update"
                        });
                    Assert.True(updateResult.Description == "update" && updateResult.Label == "update");
                    Assert.True(!string.IsNullOrEmpty(updateResult.IOType));

                    var destBlobName = "dest" + serviceName + ".vhd";
                    var destBlobUri = ComputeManagementTestUtilities.CopyBlobInStorage(
                        storageAccountName,
                        updateResult.MediaLinkUri,
                        "myvhds",
                        destBlobName);

                    var createResult = compute.VirtualMachineOSImages.Create(
                        new VirtualMachineOSImageCreateParameters
                        {
                            Name = updateResult.Name + "dest",
                            Label = "create",
                            Description = "create",
                            MediaLinkUri = destBlobUri,
                            OperatingSystemType = "Windows"
                        });
                    Assert.True(createResult.Description == "create" && createResult.Label == "create");
                    Assert.True(!string.IsNullOrEmpty(createResult.IOType));

                    compute.VirtualMachineOSImages.Delete(createResult.Name, true);

                    // Test OS Image Publisher APIs
                    pirImageName = osImageName;
                    isPublisher = true;
                    try
                    {
                        compute.VirtualMachineOSImages.GetDetails(pirImageName);
                    }
                    catch (CloudException e)
                    {
                        if (e != null && e.Error.Code.Equals(errorCodeStr))
                        {
                            isPublisher = false;
                        }
                    }

                    try
                    {
                        compute.VirtualMachineOSImages.Replicate(
                            pirImageName,
                            new VirtualMachineOSImageReplicateParameters
                            {
                                TargetLocations = new string[] { mgmt.GetDefaultLocation() },
                                ComputeImageAttributes = new ComputeImageAttributes
                                {
                                    Offer = "test",
                                    Sku = "test",
                                    Version = "test"
                                }
                            });
                    }
                    catch (CloudException e)
                    {
                        Assert.True(!isPublisher && e != null && e.Error.Code.Equals(errorCodeStr));
                    }

                    try
                    {
                        compute.VirtualMachineOSImages.Share(pirImageName, imageShareType);
                    }
                    catch (CloudException e)
                    {
                        Assert.True(!isPublisher && e != null && e.Error.Code.Equals(errorCodeStr));
                    }

                    try
                    {
                        compute.VirtualMachineOSImages.Unreplicate(pirImageName);
                    }
                    catch (CloudException e)
                    {
                        Assert.True(!isPublisher && e != null && e.Error.Code.Equals(errorCodeStr));
                    }

                    // Delete OS images
                    compute.VirtualMachineOSImages.Delete(osImageName, true);

                    // Delete all virtual machines
                    var vmList = compute.Deployments.GetByName(serviceName, deploymentName).Roles;
                    for (int i = 0; i < vmList.Count; i++)
                    {
                        var vm = vmList[i];
                        var pa = i < vmList.Count - 1
                               ? PostShutdownAction.StoppedDeallocated : PostShutdownAction.Stopped;
                        compute.VirtualMachines.Shutdown(
                            serviceName,
                            deploymentName,
                            vm.RoleName,
                            new VirtualMachineShutdownParameters
                            {
                                PostShutdownAction = pa
                            });

                        if (i < vmList.Count - 1)
                        {
                            compute.VirtualMachines.Delete(serviceName, deploymentName, vm.RoleName, true);
                        }
                        else
                        {
                            compute.Deployments.DeleteByName(serviceName, deploymentName, true);
                        }
                    }

                    // Delete the service
                    compute.HostedServices.DeleteAll(serviceName);
                }
                finally
                {
                    undoContext.Dispose();
                    mgmt.Dispose();
                    compute.Dispose();
                    storage.Dispose();
                    TestLogTracingInterceptor.Current.Stop();
                }
            }
        }

        [Fact]
        public void CanCreateVMWithVMImage()
        {
            TestLogTracingInterceptor.Current.Start();
            using (var undoContext = UndoContext.Current)
            {
                undoContext.Start();
                var mgmt = fixture.GetManagementClient();
                var compute = fixture.GetComputeManagementClient();
                var storage = fixture.GetStorageManagementClient();

                try
                {
                    string storageAccountName = TestUtilities.GenerateName("psteststo").ToLower();
                    string serviceName = TestUtilities.GenerateName("pstestsvc");
                    string serviceLabel = serviceName + "1";
                    string serviceDescription = serviceName + "2";
                    string deploymentName = string.Format("{0}Prod", serviceName);
                    string deploymentLabel = deploymentName;

                    string location = mgmt.GetDefaultLocation("Storage", "Compute");
                    const string usWestLocStr = "West US";
                    if (mgmt.Locations.List().Any(
                        c => string.Equals(c.Name, usWestLocStr, StringComparison.OrdinalIgnoreCase)))
                    {
                        location = usWestLocStr;
                    }

                    storage.StorageAccounts.Create(
                        new StorageAccountCreateParameters
                        {
                            Location = location,
                            Label = storageAccountName,
                            Name = storageAccountName,
                            AccountType = StorageAccountTypes.StandardGRS
                        });

                    compute.HostedServices.Create(
                        new HostedServiceCreateParameters
                        {
                            Location = location,
                            Label = serviceDescription,
                            Description = serviceLabel,
                            ServiceName = serviceName
                        });

                    var hostedService = compute.HostedServices.Get(serviceName);
                    Assert.True(hostedService.Properties.Label == serviceDescription);
                    Assert.True(hostedService.Properties.Description == serviceLabel);

                    var image = compute.VirtualMachineOSImages.List()
                                .FirstOrDefault(s => string.Equals(s.OperatingSystemType,
                                                                   "Windows",
                                                                   StringComparison.OrdinalIgnoreCase) &&
                                                     s.LogicalSizeInGB < 100);
                    Assert.True(!string.IsNullOrEmpty(image.IOType));

                    compute.VirtualMachines.CreateDeployment(
                        serviceName,
                        new VirtualMachineCreateDeploymentParameters
                        {
                            Name = deploymentName,
                            DeploymentSlot = DeploymentSlot.Production,
                            Label = deploymentLabel,
                            Roles = new List<Role>()
                            {
                                new Role()
                                {
                                    ProvisionGuestAgent = false,
                                    ResourceExtensionReferences = null,
                                    RoleName = serviceName,
                                    RoleType = VirtualMachineRoleType.PersistentVMRole.ToString(),
                                    RoleSize = VirtualMachineRoleSize.Large.ToString(),
                                    OSVirtualHardDisk =
                                        new OSVirtualHardDisk
                                        {
                                            HostCaching = VirtualHardDiskHostCaching.ReadWrite,
                                            SourceImageName = image.Name,
                                            MediaLink = new Uri(string.Format(
                                                "http://{1}.blob.core.windows.net/myvhds/{0}.vhd",
                                                serviceName,
                                                storageAccountName)),
                                        },
                                    DataVirtualHardDisks =
                                    new List<DataVirtualHardDisk>(
                                        Enumerable.Repeat(new DataVirtualHardDisk
                                        {
                                            Label = "testDataDiskLabel5",
                                            LogicalUnitNumber = 0,
                                            LogicalDiskSizeInGB = 1,
                                            HostCaching = "ReadOnly",
                                            MediaLink = new Uri(string.Format(
                                                "http://{1}.blob.core.windows.net/myvhds/{0}5.vhd",
                                                serviceName,
                                                storageAccountName)),
                                        }, 1)),
                                    ConfigurationSets =
                                        new List<ConfigurationSet>()
                                        {
                                            new ConfigurationSet
                                            {
                                                AdminUserName = "FooBar12",
                                                AdminPassword = "foobarB@z21!",
                                                ConfigurationSetType = ConfigurationSetTypes
                                                                      .WindowsProvisioningConfiguration,
                                                ComputerName = serviceName,
                                                HostName = string.Format("{0}.cloudapp.net", serviceName),
                                                EnableAutomaticUpdates = false,
                                                TimeZone = "Pacific Standard Time",
                                                AdditionalUnattendContent = new AdditionalUnattendContentSettings
                                                {
                                                    UnattendPasses = new List<UnattendPassSettings>
                                                    {
                                                        new UnattendPassSettings
                                                        {
                                                            PassName = "oobeSystem",
                                                            UnattendComponents = new List<UnattendComponent>
                                                            {
                                                                new UnattendComponent
                                                                {
                                                                    ComponentName = "Microsoft-Windows-Shell-Setup",
                                                                    UnattendComponentSettings = new List<ComponentSetting>
                                                                    {
                                                                        new ComponentSetting
                                                                        {
                                                                            SettingName = "AutoLogon",
                                                                            Content = "<AutoLogon><Enabled>true</Enabled><LogonCount>5</LogonCount><Username>Foo12</Username><Password><Value>BaR@123pslibtest1269</Value><PlainText>true</PlainText></Password></AutoLogon>",
                                                                        }
                                                                    }
                                                                }
                                                            }
                                                        }
                                                    }
                                                }
                                            },
                                            new ConfigurationSet
                                            {
                                                ConfigurationSetType = "NetworkConfiguration",
                                                InputEndpoints =
                                                    new List<InputEndpoint>
                                                    {
                                                        new InputEndpoint
                                                        {
                                                            LocalPort = 3389,
                                                            Name = "RDP",
                                                            Port = 52777,
                                                            Protocol = InputEndpointTransportProtocol.Tcp,
                                                            VirtualIPAddress = "157.56.161.177",
                                                            EnableDirectServerReturn = false
                                                        },
                                                        new InputEndpoint
                                                        {
                                                            LocalPort = 1111,
                                                            Name = "Test",
                                                            Port = 2222,
                                                            Protocol = InputEndpointTransportProtocol.Tcp,
                                                            LoadBalancedEndpointSetName = serviceName,
                                                            LoadBalancerName = serviceName
                                                        }
                                                    }
                                            }
                                        }
                                    }
                                },
                            LoadBalancers = new List<LoadBalancer>()
                                {
                                    new LoadBalancer
                                    {
                                        Name = serviceName,
                                        FrontendIPConfiguration = new FrontendIPConfiguration
                                        {
                                            Type = "Private"
                                        }
                                    }
                                }
                        });

                    // Verify service return
                    var getSvcResult = compute.HostedServices.Get(serviceName);
                    Assert.True(getSvcResult.ComputeCapabilities == null
                             || getSvcResult.ComputeCapabilities.VirtualMachinesRoleSizes.Count() > 0);
                    Assert.True(getSvcResult.ComputeCapabilities == null
                             || getSvcResult.ComputeCapabilities.WebWorkerRoleSizes.Count() > 0);

                    var listSvcResult = compute.HostedServices.List()
                                               .FirstOrDefault(s => s.ServiceName.Equals(serviceName));
                    Assert.True(listSvcResult.ComputeCapabilities == null
                             || listSvcResult.ComputeCapabilities.VirtualMachinesRoleSizes.Count() > 0);
                    Assert.True(listSvcResult.ComputeCapabilities == null
                             || listSvcResult.ComputeCapabilities.WebWorkerRoleSizes.Count() > 0);

                    compute.VirtualMachines.Shutdown(
                        serviceName,
                        deploymentName,
                        serviceName,
                        new VirtualMachineShutdownParameters
                        {
                            PostShutdownAction = PostShutdownAction.Stopped
                        });

                    var deployment = compute.Deployments.GetByName(
                            serviceName,
                            deploymentName);

                    bool vmIsStopped = false;
                    while (!vmIsStopped)
                    {
                        TestUtilities.Wait(TimeSpan.FromSeconds(30));

                        deployment = compute.Deployments.GetByName(
                            serviceName,
                            deploymentName);

                        var vm = deployment.RoleInstances.FirstOrDefault(
                            r => string.Equals(r.RoleName, serviceName, StringComparison.OrdinalIgnoreCase));

                        vmIsStopped = string.Equals(vm.InstanceStatus, RoleInstanceStatus.StoppedVM, StringComparison.OrdinalIgnoreCase);                                   
                    };

                    string vmImageName = "img" + serviceName;
                    compute.VirtualMachines.CaptureVMImage(
                        serviceName,
                        deploymentName,
                        serviceName,
                        new VirtualMachineCaptureVMImageParameters
                        {
                            OSState = "Specialized",
                            VMImageLabel = serviceName,
                            VMImageName = vmImageName
                        });

                    compute.VirtualMachines.CaptureVMImage(
                        serviceName,
                        deploymentName,
                        serviceName,
                        new VirtualMachineCaptureVMImageParameters
                        {
                            OSState = "Generalized",
                            VMImageLabel = serviceName,
                            VMImageName = vmImageName + "2"
                        });

                    var vmImageList = compute.VirtualMachineVMImages.List();
                    Assert.True(vmImageList.Count() >= 2);
                    Assert.True(vmImageList.All(a => !string.IsNullOrEmpty(a.OSDiskConfiguration.IOType)));
                    Assert.True(vmImageList.All(a => !a.DataDiskConfigurations.Any()
                     || a.DataDiskConfigurations.All(d => !string.IsNullOrEmpty(d.IOType))));

                    var dataDiskName = vmImageList.First(t => string.Equals(t.Name, vmImageName + "2"))
                                                  .DataDiskConfigurations.First().Name;

                    // Test Add Role with VMImageName and AvailabilitySetName
                    compute.VirtualMachines.CreateDeployment(
                        serviceName,
                        new VirtualMachineCreateDeploymentParameters()
                        {
                            Name = deploymentName,
                            DeploymentSlot = DeploymentSlot.Production,
                            Label = deploymentLabel,

                            Roles = new List<Role>()
                            {
                                new Role()
                                {
                                    ProvisionGuestAgent = true,
                                    RoleName = serviceName + "3",
                                    RoleType = VirtualMachineRoleType.PersistentVMRole.ToString(),
                                    RoleSize = VirtualMachineRoleSize.Large.ToString(),
                                    VMImageName = vmImageName + "2",
                                    AvailabilitySetName = "test",
                                    ConfigurationSets =
                                        new List<ConfigurationSet>()
                                        {
                                            new ConfigurationSet
                                            {
                                                AdminUserName = "FooBar12",
                                                AdminPassword = "foobarB@z21!",
                                                ConfigurationSetType = ConfigurationSetTypes
                                                                      .WindowsProvisioningConfiguration,
                                                ComputerName = serviceName,
                                                HostName = string.Format("{0}.cloudapp.net", serviceName),
                                                EnableAutomaticUpdates = false,
                                                TimeZone = "Pacific Standard Time",
                                                AdditionalUnattendContent = new AdditionalUnattendContentSettings
                                                {
                                                    UnattendPasses = new List<UnattendPassSettings>
                                                    {
                                                        new UnattendPassSettings
                                                        {
                                                            PassName = "oobeSystem",
                                                            UnattendComponents = new List<UnattendComponent>
                                                            {
                                                                new UnattendComponent
                                                                {
                                                                    ComponentName = "Microsoft-Windows-Shell-Setup",
                                                                    UnattendComponentSettings = new List<ComponentSetting>
                                                                    {
                                                                        new ComponentSetting
                                                                        {
                                                                            SettingName = "AutoLogon",
                                                                            Content = "<AutoLogon><Enabled>true</Enabled><LogonCount>5</LogonCount><Username>Foo12</Username><Password><Value>BaR@123pslibtest1269</Value><PlainText>true</PlainText></Password></AutoLogon>",
                                                                        }
                                                                    }
                                                                }
                                                            }
                                                        }
                                                    }
                                                }
                                            },
                                            new ConfigurationSet
                                            {
                                                ConfigurationSetType = "NetworkConfiguration",
                                                InputEndpoints =
                                                    new List<InputEndpoint>
                                                    {
                                                        new InputEndpoint()
                                                        {
                                                            LocalPort = 3389,
                                                            Name = "RDP",
                                                            Port = 52778,
                                                            Protocol = InputEndpointTransportProtocol.Tcp,
                                                            VirtualIPAddress = "157.56.161.177",
                                                            EnableDirectServerReturn = false
                                                        }
                                                    }
                                            }
                                        },
                                    ResourceExtensionReferences = new List<ResourceExtensionReference>()
                                    {
                                        new ResourceExtensionReference()
                                        {
                                            Name = "BGInfo",
                                            Publisher = "Microsoft.Compute",
                                            Version = "1.*",
                                            ReferenceName = "BGInfo",
                                            State = "Enable",
                                            ResourceExtensionParameterValues = null,
                                            ForceUpdate = true
                                        }
                                    },
                                    VMImageInput = new VMImageInput()
                                    {
                                        OSDiskConfiguration = new OSDiskConfiguration()
                                        {
                                            ResizedSizeInGB = 128,
                                        },
                                        DataDiskConfigurations = new List<DataDiskConfiguration>()
                                        {
                                            new DataDiskConfiguration()
                                            {
                                                DiskName = dataDiskName,
                                                ResizedSizeInGB = 200,
                                            }
                                        },
                                    },
                                },
                            },
                        });

                    // Delete all virtual machines
                    var vmList = compute.Deployments.GetByName(serviceName, deploymentName).Roles;
                    for (int i = 0; i < vmList.Count; i++)
                    {
                        var vm = vmList[i];
                        var pa = i < vmList.Count - 1
                               ? PostShutdownAction.StoppedDeallocated : PostShutdownAction.Stopped;
                        compute.VirtualMachines.Shutdown(
                            serviceName,
                            deploymentName,
                            vm.RoleName,
                            new VirtualMachineShutdownParameters
                            {
                                PostShutdownAction = pa
                            });

                        if (i < vmList.Count - 1)
                        {
                            compute.VirtualMachines.Delete(serviceName, deploymentName, vm.RoleName, true);
                        }
                        else
                        {
                            compute.Deployments.DeleteByName(serviceName, deploymentName, true);
                        }
                    }

                    // Delete the service
                    compute.HostedServices.DeleteAll(serviceName);
                }
                finally
                {
                    undoContext.Dispose();
                    mgmt.Dispose();
                    compute.Dispose();
                    storage.Dispose();
                    TestLogTracingInterceptor.Current.Stop();
                }
            }
        }

        [Fact]
        public void CanCreateVMAndGetDeploymentWithMaxDate()
        {
            TestLogTracingInterceptor.Current.Start();
            using (var undoContext = UndoContext.Current)
            {
                undoContext.Start();
                var mgmt = fixture.GetManagementClient();
                var compute = fixture.GetComputeManagementClient();
                var storage = fixture.GetStorageManagementClient();

                try
                {
                    string storageAccountName = TestUtilities.GenerateName("psteststo").ToLower();
                    string serviceName = TestUtilities.GenerateName("pstestsvc");
                    string serviceLabel = serviceName + "1";
                    string serviceDescription = serviceName + "2";
                    string deploymentName = string.Format("{0}Prod", serviceName);
                    string deploymentLabel = deploymentName;

                    string location = mgmt.GetDefaultLocation("Storage", "Compute");
                    const string usWestLocStr = "West US";
                    if (mgmt.Locations.List().Any(
                        c => string.Equals(c.Name, usWestLocStr, StringComparison.OrdinalIgnoreCase)))
                    {
                        location = usWestLocStr;
                    }

                    storage.StorageAccounts.Create(
                        new StorageAccountCreateParameters
                        {
                            Location = location,
                            Label = storageAccountName,
                            Name = storageAccountName,
                            AccountType = StorageAccountTypes.StandardGRS
                        });

                    compute.HostedServices.Create(
                        new HostedServiceCreateParameters
                        {
                            Location = location,
                            Label = serviceDescription,
                            Description = serviceLabel,
                            ServiceName = serviceName
                        });

                    var image = compute.VirtualMachineOSImages.List()
                                .FirstOrDefault(s => string.Equals(s.OperatingSystemType,
                                                                   "Windows",
                                                                   StringComparison.OrdinalIgnoreCase) &&
                                                     s.LogicalSizeInGB < 100);

                    compute.VirtualMachines.CreateDeployment(
                        serviceName,
                        new VirtualMachineCreateDeploymentParameters
                        {
                            Name = deploymentName,
                            DeploymentSlot = DeploymentSlot.Production,
                            Label = deploymentLabel,
                            Roles = new List<Role>()
                            {
                                new Role()
                                {
                                    ProvisionGuestAgent = false,
                                    ResourceExtensionReferences = null,
                                    RoleName = serviceName,
                                    RoleType = VirtualMachineRoleType.PersistentVMRole.ToString(),
                                    RoleSize = VirtualMachineRoleSize.Large.ToString(),
                                    OSVirtualHardDisk =
                                        new OSVirtualHardDisk
                                        {
                                            HostCaching = VirtualHardDiskHostCaching.ReadWrite,
                                            SourceImageName = image.Name,
                                            MediaLink = new Uri(string.Format(
                                                "http://{1}.blob.core.windows.net/myvhds/{0}.vhd",
                                                serviceName,
                                                storageAccountName)),
                                            ResizedSizeInGB = 128,
                                        },
                                    ConfigurationSets =
                                        new List<ConfigurationSet>()
                                        {
                                            new ConfigurationSet
                                            {
                                                AdminUserName = "FooBar12",
                                                AdminPassword = "foobarB@z21!",
                                                ConfigurationSetType = ConfigurationSetTypes
                                                                      .WindowsProvisioningConfiguration,
                                                ComputerName = serviceName,
                                                HostName = string.Format("{0}.cloudapp.net", serviceName),
                                                EnableAutomaticUpdates = false,
                                                TimeZone = "Pacific Standard Time"
                                            }
                                        }
                                    }
                                }
                        });

                    // Verify Date Times

                    // NOTE: the response of Get Deployment is manually modified such that
                    //       CreatedTime = "0001-01-01T00:00:00+12:00" (DateTime.MinValue in UTC+12 zone)
                    //       LastModifiedTime: "9999-12-31T23:59:59-12:00" (DateTime.MaxValue in UTC-12 zone)
                    //
                    // If this test is re-recorded, 'CreatedTime' and 'LastModifiedTime' of the response body
                    // should be modified again.
                    //
                    // Sample:
                    // <CreatedTime>0001-01-01T00:00:00Z</CreatedTime>
                    // <LastModifiedTime>9999-12-31T23:59:59Z</LastModifiedTime>
                    var getDepResult = compute.Deployments.GetByName(serviceName, deploymentName);
                    Assert.True(getDepResult.CreatedTime < DateTime.MinValue.AddDays(1));
                    Assert.True(getDepResult.LastModifiedTime > DateTime.MaxValue.AddDays(-1));

                    // Delete the service
                    compute.HostedServices.DeleteAll(serviceName);
                }
                finally
                {
                    mgmt.Dispose();
                    compute.Dispose();
                    storage.Dispose();
                    TestLogTracingInterceptor.Current.Stop();
                }
            }
        }
    }
}
