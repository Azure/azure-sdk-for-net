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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.WindowsAzure.Management;
using Microsoft.WindowsAzure.Management.Models;
using Microsoft.WindowsAzure.Management.Compute;
using Microsoft.WindowsAzure.Management.Compute.Models;
using Microsoft.WindowsAzure.Management.Storage;
using Microsoft.WindowsAzure.Management.Storage.Models;

namespace Microsoft.WindowsAzure.Testing
{
    [TestClass]
    public class VirtualMachineReproTests : ComputeTestBase
    {
        [TestMethod]
        public void Bug187()
        {
            string serviceName = Randomize("testsvc");
            string storageAccountName = Randomize("teststorage").ToLower();
            string deploymentName = string.Format("{0}Prod", serviceName);
            
            using (var mgmt = GetManagementClient())
            using (var compute = GetComputeMangementClient())
            using (var storage = GetStorageMangementClient())
            {
                try
                {
                    compute.HostedServices.Create(
                        new HostedServiceCreateParameters
                        {
                            Location = LocationNames.WestUS,
                            Label = serviceName,
                            ServiceName = serviceName
                        });
                    storage.StorageAccounts.Create(
                        new StorageAccountCreateParameters
                        {
                            Location = LocationNames.WestUS,
                            Label = storageAccountName,
                            ServiceName = storageAccountName
                        });

                    var image = compute.VirtualMachineImages.List().FirstOrDefault();
                    compute.VirtualMachines.CreateDeployment(
                        serviceName,
                        new VirtualMachineCreateDeploymentParameters
                        {
                            Name = deploymentName,
                            DeploymentSlot = DeploymentSlot.Production,
                            Label = deploymentName,
                            Roles =
                                new List<Role>()
                                {
                                    new Role()
                                    {
                                        RoleName = serviceName,
                                        RoleType = VirtualMachineRoleType.PersistentVMRole.ToString(),
                                        RoleSize = VirtualMachineRoleSize.Large,
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
                                        ConfigurationSets =
                                            new List<ConfigurationSet>()
                                            {
                                                new ConfigurationSet
                                                {
                                                    AdminUserName = "FooBar12",
                                                    AdminPassword = "foobarB@z21!",
                                                    ConfigurationSetType = ConfigurationSetTypes.WindowsProvisioningConfiguration,
                                                    ComputerName = serviceName,
                                                    HostName = string.Format("{0}.cloudapp.net", serviceName),
                                                    EnableAutomaticUpdates = false,
                                                    TimeZone = "Pacific Standard Time"
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
                                                                Port = 52777,
                                                                Protocol = InputEndpointTransportProtocol.Tcp,
                                                                VirtualIPAddress = "157.56.161.177",
                                                                EnableDirectServerReturn = false
                                                            }
                                                        }
                                                }
                                            }
                                        }
                                }
                        });

                    // Add a VM to the deployment
                    compute.VirtualMachines.Create(
                        serviceName,
                        deploymentName,
                        new VirtualMachineCreateParameters()
                        {
                            RoleName = serviceName + "2",
                            RoleSize = VirtualMachineRoleSize.ExtraSmall,
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
                            ConfigurationSets =
                                new List<ConfigurationSet>()
                                {
                                    new ConfigurationSet
                                    {
                                        AdminUserName = "FooBar12",
                                        AdminPassword = "foobarB@z21!",
                                        ConfigurationSetType = ConfigurationSetTypes.WindowsProvisioningConfiguration,
                                        ComputerName = serviceName,
                                        HostName = string.Format("{0}.cloudapp.net", serviceName),
                                        EnableAutomaticUpdates = false,
                                        TimeZone = "Pacific Standard Time"
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
                                                    Port = 52777,
                                                    Protocol = InputEndpointTransportProtocol.Tcp,
                                                    VirtualIPAddress = "157.56.161.177",
                                                    EnableDirectServerReturn = false
                                                }
                                            }
                                    }
                                }
                        });
                }
                finally
                {
                    IgnoreExceptions(() => compute.VirtualMachines.Delete(serviceName, deploymentName, serviceName));
                    IgnoreExceptions(() => compute.HostedServices.Delete(serviceName));
                    IgnoreExceptions(() => storage.StorageAccounts.Delete(storageAccountName));
                }
            }
        }
    }
}
