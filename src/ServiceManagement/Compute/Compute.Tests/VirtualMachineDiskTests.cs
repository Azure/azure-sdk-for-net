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
    using Xunit;
    using Hyak.Common;

    public class VirtualMachineDiskTests : TestBase, IUseFixture<TestFixtureData>
    {
        private TestFixtureData fixture;

        public void SetFixture(TestFixtureData data)
        {
            data.Instantiate(TestUtilities.GetCallingClass());
            fixture = data;
        }

        [Fact]
        public void CanUpdateVMDisk()
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

                    var image = compute.VirtualMachineOSImages.List()
                                .FirstOrDefault(s => string.Equals(s.OperatingSystemType,
                                                                   "Windows",
                                                                   StringComparison.OrdinalIgnoreCase) &&
                                                                   s.LogicalSizeInGB < 100);

                    Assert.True(!string.IsNullOrEmpty(image.IOType));

                    var osDiskSourceUri = new Uri(string.Format(
                                                "http://{1}.blob.core.windows.net/myvhds/{0}.vhd",
                                                serviceName,
                                                storageAccountName));

                    var dataDiskSourceUri = new Uri(string.Format(
                                                "http://{1}.blob.core.windows.net/myvhds/{0}5.vhd",
                                                serviceName,
                                                storageAccountName));

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
                                            MediaLink = osDiskSourceUri,
                                        },
                                    DataVirtualHardDisks =
                                    new List<DataVirtualHardDisk>(
                                        Enumerable.Repeat(new DataVirtualHardDisk
                                        {
                                            Label = "testDataDiskLabel5",
                                            LogicalUnitNumber = 0,
                                            LogicalDiskSizeInGB = 1,
                                            HostCaching = "ReadOnly",
                                            MediaLink = dataDiskSourceUri,
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
                                                TimeZone = "Pacific Standard Time"
                                            },
                                        }
                                    }
                                },
                        });

                    // Create virtual disks
                    string dataDiskBlobName = "datadisk.vhd";
                    string osDiskBlobName = "osdisk.vhd";

                    var dataDiskBlobUri = ComputeManagementTestUtilities.CopyBlobInStorage(
                        storageAccountName,
                        dataDiskSourceUri,
                        "myvhds",
                        dataDiskBlobName);

                    var osDiskBlobUri = ComputeManagementTestUtilities.CopyBlobInStorage(
                        storageAccountName,
                        osDiskSourceUri,
                        "myvhds",
                        osDiskBlobName);

                    string dataDiskName = TestUtilities.GenerateName("datadisk");
                    string osDiskName = TestUtilities.GenerateName("osdisk");

                    string dataDiskLabel = "DataDiskLabelOld";
                    string osDiskLabel = "OSDiskLabelOld";

                    compute.VirtualMachineDisks.CreateDisk(new VirtualMachineDiskCreateParameters()
                        {
                            Name = dataDiskName,
                            Label = dataDiskLabel,
                            MediaLinkUri = dataDiskBlobUri,
                        });
                    compute.VirtualMachineDisks.CreateDisk(new VirtualMachineDiskCreateParameters()
                    {
                        Name = osDiskName,
                        Label = osDiskLabel,
                        MediaLinkUri = osDiskBlobUri,
                        OperatingSystemType = "Windows",
                    });

                    // Verify disks before update
                    var dataDiskReturned = compute.VirtualMachineDisks.GetDisk(dataDiskName);
                    var osDiskReturned = compute.VirtualMachineDisks.GetDisk(osDiskName);

                    Assert.Equal(dataDiskName, dataDiskReturned.Name);
                    Assert.Equal(dataDiskLabel, dataDiskReturned.Label);
                    Assert.Equal(1, dataDiskReturned.LogicalSizeInGB);

                    Assert.Equal(osDiskName, osDiskReturned.Name);
                    Assert.Equal(osDiskLabel, osDiskReturned.Label);
                    Assert.True(osDiskReturned.LogicalSizeInGB < 100);
                    Assert.Equal("Windows", osDiskReturned.OperatingSystemType);

                    // Updating disks
                    dataDiskLabel = "DataDiskLabelNew";
                    osDiskLabel = "OSDiskLabelNew";

                    compute.VirtualMachineDisks.UpdateDiskSize(dataDiskName,
                        new VirtualMachineDiskUpdateParameters()
                        {
                            Name = dataDiskName,
                            Label = dataDiskLabel,
                            ResizedSizeInGB = 500,
                        });

                    compute.VirtualMachineDisks.UpdateDiskSize(osDiskName,
                        new VirtualMachineDiskUpdateParameters()
                        {
                            Name = osDiskName,
                            Label = osDiskLabel,
                            ResizedSizeInGB = 128,
                        });

                    // Verify disks after update
                    dataDiskReturned = compute.VirtualMachineDisks.GetDisk(dataDiskName);
                    osDiskReturned = compute.VirtualMachineDisks.GetDisk(osDiskName);

                    Assert.Equal(dataDiskName, dataDiskReturned.Name);
                    Assert.Equal(dataDiskLabel, dataDiskReturned.Label);
                    Assert.Equal(500, dataDiskReturned.LogicalSizeInGB);

                    Assert.Equal(osDiskName, osDiskReturned.Name);
                    Assert.Equal(osDiskLabel, osDiskReturned.Label);
                    Assert.Equal(128, osDiskReturned.LogicalSizeInGB);
                    Assert.Equal("Windows", osDiskReturned.OperatingSystemType);

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
    }
}
