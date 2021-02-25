using Compute.Tests;
using Microsoft.Azure.Management.Compute.Models;
using Microsoft.Azure.Management.ResourceManager;
using Microsoft.Azure.Management.ResourceManager.Models;
using Microsoft.Azure.Management.Storage.Models;
using Microsoft.Azure.Test.HttpRecorder;
using Microsoft.Rest.Azure;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using Xunit;

namespace Microsoft.Azure.Management.Compute.Tests.ScenarioTests
{
    public class RestorePointsTest: VMTestBase
    {
        RecordedDelegatingHandler handler;
        [Fact]
        public void CreateRpcAndRestorePoints()
        {
            using (MockContext context = MockContext.Start(this.GetType().FullName))
            {
                EnsureClientsInitialized(context);
                string subId = m_CrpClient.SubscriptionId;
                string location = ComputeManagementTestUtilities.DefaultLocation;
                //Initialize(context);
                // create the VM
                var rgName = ComputeManagementTestUtilities.GenerateName(TestPrefix);
                string storageAccountName = ComputeManagementTestUtilities.GenerateName(TestPrefix);
                string asName = ComputeManagementTestUtilities.GenerateName("as");
                ImageReference imageRef = GetPlatformVMImage(useWindowsImage: true);
                VirtualMachine inputVM;
                string storageAccountForDisksName = TestUtilities.GenerateName(TestPrefix);
                string availabilitySetName = TestUtilities.GenerateName(TestPrefix);

                try
                {
                    StorageAccount storageAccountForDisks = CreateStorageAccount(rgName, storageAccountForDisksName);
                    
                    VirtualMachine createdVM = CreateVM(rgName, availabilitySetName, storageAccountForDisks, imageRef, out inputVM,
                        (vm) =>
                        {
                            vm.DiagnosticsProfile = GetManagedDiagnosticsProfile();
                        }, hasManagedDisks: true);
                    DataDisk dataDisk = createdVM.StorageProfile.DataDisks[0];
                    string dataDiskId = dataDisk.ManagedDisk.Id;
                    OSDisk osDisk = createdVM.StorageProfile.OsDisk;
                    
                    string rpName = ComputeManagementTestUtilities.GenerateName("rpClientTest");
                    string rpcName = ComputeManagementTestUtilities.GenerateName("rpc1ClientTest");
                    string vmId = createdVM.Id;
                    string vmSize = createdVM.HardwareProfile.VmSize;
                    VerifyRPCCreation(createdVM.Id, rpcName, rgName, location);
                    VerifyRestorePointCreation(rgName, rpcName, rpName, osDisk, vmId,
                        diskToExclude: dataDiskId);
                    GetRP(rgName, rpcName, rpName, osDisk, vmId, vmSize, dataDiskId.ToString());
                    GetRpc(rgName, rpcName, location, vmId, rpName);
                    GetRpc(rgName, rpcName, location, vmId, rpName, RestorePointCollectionExpandOptions.RestorePoints);
                }
                catch (CloudException ex)
                {
                    Console.WriteLine("Here");
                }
                finally
                {
                    m_ResourcesClient.ResourceGroups.Delete(rgName);
                }
            }
        }

        private void DeleteRP(string rgName, string rpcName, string rpName)
        {
            try
            {
                m_CrpClient.RestorePoints.Delete(
                    rgName,
                    rpcName,
                    rpName);
            }
            catch (CloudException ex)
            {
                Assert.True(ex.Response.StatusCode == HttpStatusCode.BadRequest);
            }
        }

        private void GetRP(string rgName, string rpcName, 
            string rpName, OSDisk osDisk, string vmId, string vmSize, string diskToExclude = null)
        {
            try
            {
                RestorePoint getRestorePointResults = m_CrpClient.RestorePoints.Get(rgName, rpcName, rpName);
                VerifyRestorePointDetails(getRestorePointResults, rpName, osDisk.Name, osDisk.ManagedDisk.Id,
                    excludeDisksCount: 1, excludeDiskId:diskToExclude, vmId: vmId, vmSize: vmSize);
            }
            catch (CloudException ex)
            {
                Assert.True(ex.Response.StatusCode == HttpStatusCode.BadRequest);
            }
        }

        private void GetRpc(string rgName, string rpcName, string location, string source, string rpName,
            RestorePointCollectionExpandOptions? expandOptions = null)
        {
            try
            {
                RestorePointCollection getRpcResult = m_CrpClient.RestorePointCollections.Get(
                    rgName,
                    rpcName,
                    expandOptions);
                Assert.Equal(rpcName, getRpcResult.Name);
                Assert.Equal(location, getRpcResult.Location);
                Assert.NotNull(getRpcResult.Id);
                Assert.NotNull(getRpcResult.Type);
                Assert.Equal(source, getRpcResult.Source.Id, ignoreCase: true);

                if (expandOptions == RestorePointCollectionExpandOptions.RestorePoints)
                {
                    Assert.Equal(1, getRpcResult.RestorePoints.Count);
                    RestorePoint rp = getRpcResult.RestorePoints[0];
                    Assert.Equal(rpName, rp.Name);
                    Assert.NotNull(rp.Id);
                }
            }
            catch (CloudException ex)
            {
                Assert.True(ex.Response.StatusCode == HttpStatusCode.BadRequest);
            }
        }

        // Create restore point and exercise 'ExcludeDisk' functionality.
        // Verify returned restore point contains the id of the excluded disk and did not create diskRestorePoint
        // of the excluded data disk.
        private void VerifyRestorePointCreation(string rgName, string rpcName, 
            string rpName, OSDisk osDisk, string vmId, string diskToExclude = null)
        {
            string osDiskId = osDisk.ManagedDisk.Id;
            string osDiskName = osDisk.Name;
            ApiEntityReference diskToExcludeEntityRef = new ApiEntityReference() { Id = diskToExclude };
            var inputRP = new RestorePoint
            {
                Name = rpName,
            };
            if (diskToExclude != null)
            {
                inputRP.ExcludeDisks = new List<ApiEntityReference> { diskToExcludeEntityRef };
            }

            try
            {
                RestorePoint createdRP = m_CrpClient.RestorePoints.CreateOrUpdate(
                    rgName,
                    rpcName,
                    rpName,
                    inputRP);
                Assert.Equal(rpName, createdRP.Name);
                Assert.NotNull(createdRP.Id);
                Assert.NotNull(createdRP.ProvisioningDetails.CreationTime);
                Assert.Equal(ProvisioningState.Succeeded.ToString(), createdRP.ProvisioningState);
                Assert.Equal(ConsistencyModeTypes.ApplicationConsistent, createdRP.ConsistencyMode);
                RestorePointSourceVMStorageProfile storageProfile = createdRP.SourceMetadata.StorageProfile;
                Assert.Equal(osDiskName, storageProfile.OsDisk.Name, ignoreCase: true);
                Assert.Equal(osDiskId, storageProfile.OsDisk.DiskRestorePoint.Id, ignoreCase: true);
                Assert.Equal(1, createdRP.ExcludeDisks.Count);
                Assert.Equal(diskToExcludeEntityRef.ToString(), createdRP.ExcludeDisks[0].Id, ignoreCase: true);
                Assert.Equal(vmId, createdRP.SourceMetadata.VmId, ignoreCase: true);
                Assert.NotNull(createdRP.SourceMetadata.HardwareProfile.VmSize);
                Assert.Equal(diskToExcludeEntityRef.ToString(), createdRP.ExcludeDisks[0].Id, ignoreCase: true);
            }
            catch (CloudException ex)
            {
                Assert.True(ex.Response.StatusCode == HttpStatusCode.BadRequest);
            }
        }

        void VerifyRestorePointDetails(RestorePoint rp, string rpName, string osDiskName, string osDiskId,
            int excludeDisksCount, string excludeDiskId, string vmId, string vmSize)
        {
            Assert.Equal(rpName, rp.Name);
            Assert.NotNull(rp.Id);
            Assert.NotNull(rp.ProvisioningDetails.CreationTime);
            Assert.Equal(ProvisioningState.Succeeded.ToString(), rp.ProvisioningState);
            Assert.Equal(ConsistencyModeTypes.ApplicationConsistent, rp.ConsistencyMode);
            RestorePointSourceVMStorageProfile storageProfile = rp.SourceMetadata.StorageProfile;
            Assert.Equal(osDiskName, storageProfile.OsDisk.Name, ignoreCase: true);
            Assert.Equal(osDiskId, storageProfile.OsDisk.DiskRestorePoint.Id, ignoreCase: true);
            Assert.Equal(1, rp.ExcludeDisks.Count);
            Assert.Equal(excludeDiskId, rp.ExcludeDisks[0].Id, ignoreCase: true);
            Assert.Equal(vmId, rp.SourceMetadata.VmId, ignoreCase: true);
            Assert.Equal(vmSize, rp.SourceMetadata.HardwareProfile.VmSize);
        }

        private void VerifyRPCCreation(string sourceVMId, string rpcName, string rgName, string location)
        {
            var inputRPC = new RestorePointCollection
            {
                Location = location,
                Tags = new Dictionary<string, string>()
                {
                    {"RG", "rg"},
                    {"testTag", "1"},
                },

                Source = new Microsoft.Azure.Management.Compute.Models.SubResource()
                {
                    Id = ""
                },
            };

            RestorePointCollection createOrUpdateResponse = null;
            try
            {
                createOrUpdateResponse = m_CrpClient.RestorePointCollections.CreateOrUpdate(
                    rgName,
                    rpcName,
                    inputRPC);
            }
            catch (CloudException ex)
            {
                Assert.True(ex.Response.StatusCode == HttpStatusCode.BadRequest,
                    "Expect failure when source id is not valid");
            }

            try
            {
                // now successfully create RPC id by passing in source VM id
                inputRPC.Source.Id = sourceVMId;
                inputRPC.Name = rpcName;
                createOrUpdateResponse = m_CrpClient.RestorePointCollections.CreateOrUpdate(
                    rgName,
                    rpcName,
                    inputRPC);
                Assert.Equal(sourceVMId, createOrUpdateResponse.Source.Id);
                //Assert.Equal(sourceVMId, createOrUpdateResponse.Id);
                Assert.Null(createOrUpdateResponse.RestorePoints);
                Assert.Equal(rpcName, createOrUpdateResponse.Name);
                Assert.Equal(location, createOrUpdateResponse.Location, ignoreCase: true);
            }
            catch (CloudException ex)
            {
                Console.WriteLine("here"); 
            }
        }
    }
}
