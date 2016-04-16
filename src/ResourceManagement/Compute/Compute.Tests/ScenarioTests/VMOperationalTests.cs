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

using Microsoft.Azure.Management.Compute;
using Microsoft.Azure.Management.Compute.Models;
using Microsoft.Azure.Management.Resources;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net;
using Xunit;

namespace Compute.Tests
{
    public class VMOperationalTests : VMTestBase
    {
        class Image
        {
            [JsonProperty("uri")]
            public string Uri { get; set; }
        }

        class OSDisk
        {
            [JsonProperty("image")]
            public Image Image { get; set; }
        }

        class StorageProfile
        {
            [JsonProperty("osDisk")]
            public OSDisk OSDisk { get; set; }
        }

        class Properties
        {
            [JsonProperty("storageProfile")]
            public StorageProfile StorageProfile { get; set; }
        }

        class Resource
        {
            [JsonProperty("properties")]
            public Properties Properties { get; set; }
        }

        class Template
        {
            [JsonProperty("resources")]
            public List<Resource> Resources { get; set; }
        }

        /// <summary>
        /// Covers following Operations:
        /// Create RG
        /// Create Storage Account
        /// Create Network Resources
        /// Create VM
        /// GET VM Model View
        /// Start VM
        /// Stop VM
        /// Restart VM
        /// Deallocate VM
        /// Generalize VM
        /// Capture VM
        /// Delete RG
        /// </summary>
        [Fact]
        public void TestVMOperations()
        {
            using (MockContext context = MockContext.Start(this.GetType().FullName))
            {
                EnsureClientsInitialized(context);

                ImageReference imageRef = GetPlatformVMImage(useWindowsImage: true);

                // Create resource group
                string rg1Name = ComputeManagementTestUtilities.GenerateName(TestPrefix) + 1;
                string as1Name = ComputeManagementTestUtilities.GenerateName("as");
                string storageAccountName = ComputeManagementTestUtilities.GenerateName(TestPrefix);
                VirtualMachine inputVM1;

                try
                {
                    // Create Storage Account, so that both the VMs can share it
                    var storageAccountOutput = CreateStorageAccount(rg1Name, storageAccountName);

                    VirtualMachine vm1 = CreateVM_NoAsyncTracking(rg1Name, as1Name, storageAccountOutput, imageRef, out inputVM1);

                    m_CrpClient.VirtualMachines.Start(rg1Name, vm1.Name);
                    m_CrpClient.VirtualMachines.Redeploy(rg1Name, vm1.Name);
                    m_CrpClient.VirtualMachines.Restart(rg1Name, vm1.Name);
                    m_CrpClient.VirtualMachines.PowerOff(rg1Name, vm1.Name);
                    m_CrpClient.VirtualMachines.Deallocate(rg1Name, vm1.Name);
                    m_CrpClient.VirtualMachines.Generalize(rg1Name, vm1.Name);

                    var captureParams = new VirtualMachineCaptureParameters
                    {
                        DestinationContainerName = ComputeManagementTestUtilities.GenerateName(TestPrefix),
                        VhdPrefix = ComputeManagementTestUtilities.GenerateName(TestPrefix),
                        OverwriteVhds = true
                    };

                    var captureResponse = m_CrpClient.VirtualMachines.Capture(rg1Name, vm1.Name, captureParams);

                    Assert.NotNull(captureResponse.Output);
                    string outputAsString = captureResponse.Output.ToString();
                    Assert.Equal('{', outputAsString[0]);
                    Assert.True(outputAsString.Contains(captureParams.DestinationContainerName.ToLowerInvariant()));
                    Assert.True(outputAsString.ToLowerInvariant().Contains(captureParams.VhdPrefix.ToLowerInvariant()));

                    Template template = JsonConvert.DeserializeObject<Template>(outputAsString);
                    Assert.True(template.Resources.Count > 0);
                    string imageUri = template.Resources[0].Properties.StorageProfile.OSDisk.Image.Uri;
                    Assert.False(string.IsNullOrEmpty(imageUri));

                    // Create 2nd VM from the captured image
                    // TODO : Provisioning Time-out Issues
                    VirtualMachine inputVM2;
                    string as2Name = as1Name + "b";
                    VirtualMachine vm2 = CreateVM_NoAsyncTracking(rg1Name, as2Name, storageAccountOutput, imageRef, out inputVM2,
                        vm =>
                        {
                            vm.StorageProfile.ImageReference = null;
                            vm.StorageProfile.OsDisk.Image = new VirtualHardDisk { Uri = imageUri };
                            vm.StorageProfile.OsDisk.Vhd.Uri = vm.StorageProfile.OsDisk.Vhd.Uri.Replace(".vhd", "copy.vhd");
                            vm.StorageProfile.OsDisk.OsType = OperatingSystemTypes.Windows;
                        }, false, false);
                    Assert.True(vm2.StorageProfile.OsDisk.Image.Uri == imageUri);
                }
                finally
                {
                    // Cleanup the created resources. But don't wait since it takes too long, and it's not the purpose
                    // of the test to cover deletion. CSM does persistent retrying over all RG resources.
                    m_ResourcesClient.ResourceGroups.Delete(rg1Name);
                }
            }
        }

        /// <summary>
        /// Covers following Operations:
        /// Create RG
        /// Create Storage Account
        /// Create Network Resources
        /// Create VM
        /// GET VM Model View
        /// Redeploy VM
        /// Delete RG
        /// </summary>
        [Fact]
        public void TestVMOperations_Redeploy()
        {
            using (MockContext context = MockContext.Start(this.GetType().FullName))
            {
                EnsureClientsInitialized(context);

                ImageReference imageRef = GetPlatformVMImage(useWindowsImage: true);

                // Create resource group
                string rg1Name = TestUtilities.GenerateName(TestPrefix) + 1;
                string asName = TestUtilities.GenerateName("as");
                string storageAccountName = TestUtilities.GenerateName(TestPrefix);
                VirtualMachine inputVM1;

                bool passed = false;
                try
                {
                    // Create Storage Account, so that both the VMs can share it
                    var storageAccountOutput = CreateStorageAccount(rg1Name, storageAccountName);

                    VirtualMachine vm1 = CreateVM_NoAsyncTracking(rg1Name, asName, storageAccountOutput, imageRef,
                        out inputVM1);

                    var redeployOperationResponse = m_CrpClient.VirtualMachines.BeginRedeployWithHttpMessagesAsync(rg1Name, vm1.Name);
                    //Assert.Equal(HttpStatusCode.Accepted, redeployOperationResponse.Result.Response.StatusCode);
                    var lroResponse = m_CrpClient.VirtualMachines.RedeployWithHttpMessagesAsync(rg1Name,
                        vm1.Name).GetAwaiter().GetResult();
                    //Assert.Equal(ComputeOperationStatus.Succeeded, lroResponse.Status);

                    passed = true;
                }
                finally
                {
                    // Cleanup the created resources. But don't wait since it takes too long, and it's not the purpose
                    // of the test to cover deletion. CSM does persistent retrying over all RG resources.
                    var deleteRg1Response = m_ResourcesClient.ResourceGroups.BeginDeleteWithHttpMessagesAsync(rg1Name);
                    //Assert.True(deleteRg1Response.StatusCode == HttpStatusCode.Accepted,
                    //    "BeginDeleting status was not Accepted.");
                }

                Assert.True(passed);
            }
        }
    }
}