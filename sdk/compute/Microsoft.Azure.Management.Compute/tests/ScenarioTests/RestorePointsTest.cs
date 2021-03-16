using Compute.Tests;
using Microsoft.Azure.Management.Compute.Models;
using Microsoft.Azure.Management.Compute;
using Microsoft.Azure.Management.ResourceManager;
using Microsoft.Azure.Management.ResourceManager.Models;
using Microsoft.Azure.Management.Storage.Models;
using Microsoft.Azure.Test.HttpRecorder;
using Microsoft.Rest.Azure;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using Xunit;

namespace Microsoft.Azure.Management.Compute.Tests.ScenarioTests
{
    /// <summary>
    /// Covers following Operations:
    /// Create source VM
    /// Create two Restore Point Collections for the source VM
    /// Update rpc via PATCH
    /// Create restore point and exclude one data disk using ExcludeDisks property
    /// List all restore points in rpc (using $expand=restorePoints)
    /// List all rpcs in resource group
    /// List all rpcs in subscription
    /// Delete restore point
    /// Delete restore point collection
    /// </summary>
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
                var rgName = ComputeManagementTestUtilities.GenerateName(TestPrefix);
                ImageReference imageRef = GetPlatformVMImage(useWindowsImage: true);
                VirtualMachine inputVM;
                string storageAccountForDisksName = TestUtilities.GenerateName(TestPrefix);
                string availabilitySetName = TestUtilities.GenerateName(TestPrefix);

                try
                {
                    StorageAccount storageAccountForDisks = CreateStorageAccount(rgName, storageAccountForDisksName);
                    // create the VM
                    VirtualMachine createdVM = CreateVM(rgName, availabilitySetName, storageAccountForDisks, imageRef, out inputVM,
                        (vm) =>
                        {
                            vm.DiagnosticsProfile = GetManagedDiagnosticsProfile();
                        }, hasManagedDisks: true);
                    DataDisk dataDisk = createdVM.StorageProfile.DataDisks[0];
                    string dataDiskId = dataDisk.ManagedDisk.Id;
                    OSDisk osDisk = createdVM.StorageProfile.OsDisk;

                    string rpName = ComputeManagementTestUtilities.GenerateName("rpClientTest");
                    string rpcName = ComputeManagementTestUtilities.GenerateName("rpcClientTest");
                    string rpcName2 = ComputeManagementTestUtilities.GenerateName("rpcClientTest");
                    string vmId = createdVM.Id;
                    string vmSize = createdVM.HardwareProfile.VmSize;

                    // create two RPCs
                    Dictionary<string, string> tags = new Dictionary<string, string>()
                    {
                        {"RG", "rg"},
                        {"testTag", "1"},
                    };
                    RestorePointCollection createdRpc = CreateRpc(createdVM.Id, rpcName, rgName, location, tags);
                    VerifyRpc(createdRpc, rpcName, location, vmId);

                    RestorePointCollection createdRpc2 = CreateRpc(createdVM.Id, rpcName2, rgName, location, tags);
                    VerifyRpc(createdRpc2, rpcName2, location, vmId);

                    // for PATCH RPC, only tags are allowed to be updated
                    Dictionary<string, string> newTags = new Dictionary<string, string>()
                    {
                        {"newTag", "newValue"},
                        {"newtestTag", "newValue"},
                    };
                    UpdateRpc(rgName, rpcName, createdRpc, newTags);

                    // GET list of all rpc in the resource group.
                    IEnumerable<RestorePointCollection> rpcs = ListRpcInResourceGroup(rgName);
                    // two rpcs are returned because the RG has two rpcs
                    RestorePointCollection rpc1 = rpcs.First();
                    VerifyRpc(rpc1, rpcName, location, vmId);
                    RestorePointCollection rpc2 = rpcs.ElementAt(1);
                    VerifyRpc(rpc2, rpcName2, location, vmId);

                    // GET list of all rpc in subscription.
                    rpcs = ListRpcInSubscription();
                    // verify two rpcs exist in the sub as well
                    rpc1 = rpcs.First();
                    VerifyRpc(rpc1, rpcName, location, vmId);
                    rpc2 = rpcs.ElementAt(1);
                    VerifyRpc(rpc2, rpcName2, location, vmId);

                    // create RP in the RPC
                    RestorePoint createdRP = CreateRestorePoint(rgName, rpcName, rpName, osDisk, diskToExclude: dataDiskId);
                    VerifyRestorePointDetails(createdRP, rpName, osDisk, 1,
                        excludeDiskId: dataDiskId, vmId: vmId, vmSize: vmSize);
                    RestorePoint getRP = GetRP(rgName, rpcName, rpName);
                    VerifyRestorePointDetails(createdRP, rpName, osDisk, 1,
                        excludeDiskId: dataDiskId, vmId: vmId, vmSize: vmSize);

                    // get RPC without $expand=restorePoints
                    RestorePointCollection returnedRpc = GetRpc(rgName, rpcName);
                    VerifyRpc(returnedRpc, rpcName, location, vmId);

                    // get RPC with $expand=restorePoints
                    returnedRpc = GetRpc(rgName, rpcName,  
                        RestorePointCollectionExpandOptions.RestorePoints);
                    VerifyRpc(returnedRpc, rpcName, location, vmId,
                        shouldRpcContainRestorePoints: true);

                    // verify the restore point returned from GET RPC with $expand=restorePoints
                    RestorePoint rpInRpc = returnedRpc.RestorePoints[0];
                    VerifyRestorePointDetails(rpInRpc, rpName, osDisk, 1,
                        excludeDiskId: dataDiskId, vmId: vmId, vmSize: vmSize);

                    // delete the restore point
                    DeleteRP(rgName, rpcName, rpName);
                    // GET of deleted restore point should return 404 not found
                    try
                    {
                        GetRP(rgName, rpcName, rpName);
                        Assert.False(true);
                    }
                    catch (CloudException ex)
                    {
                        Assert.True(ex.Response.StatusCode == HttpStatusCode.NotFound);
                    }

                    // delete the restore point collection
                    DeleteRpc(rgName, rpcName);
                    // GET of deleted RPC should return 404 not found
                    try
                    {
                        GetRpc(rgName, rpcName);
                        Assert.False(true);
                    }
                    catch (CloudException ex)
                    {
                        Assert.True(ex.Response.StatusCode == HttpStatusCode.NotFound);
                    }
                }
                catch (Exception e)
                {
                    throw e;
                }
                finally
                {
                    m_ResourcesClient.ResourceGroups.Delete(rgName);
                }
            }
        }

        private void DeleteRP(string rgName, string rpcName, string rpName)
        {
            m_CrpClient.RestorePoints.Delete(rgName, rpcName, rpName);
        }

        private void DeleteRpc(string rgName, string rpcName)
        {
            m_CrpClient.RestorePointCollections.Delete(rgName, rpcName);
        }

        private IEnumerable<RestorePointCollection> ListRpcInResourceGroup(string rgName)
        {
            return m_CrpClient.RestorePointCollections.List(rgName);
        }

        private IEnumerable<RestorePointCollection> ListRpcInSubscription()
        {
            return m_CrpClient.RestorePointCollections.ListAll();
        }

        // for update of RPC, only update of tags is permitted
        private void UpdateRpc(string rgName, string rpcName, RestorePointCollection rpc,
            Dictionary<string,string> tags)
        {
            rpc.Tags = tags;
            RestorePointCollectionUpdate updateRpc = new RestorePointCollectionUpdate(
                tags, rpc.Source, new List<RestorePoint>());
            m_CrpClient.RestorePointCollections.Update(rgName, rpcName, updateRpc);
        }

        private RestorePoint GetRP(string rgName, string rpcName, 
            string rpName)
        {
            return m_CrpClient.RestorePoints.Get(rgName, rpcName, rpName);
        }

        // if verify result of GET RPC with $expand, verify that the returned rpc contains restore points
        private void VerifyRpc(RestorePointCollection rpc, string rpcName,
            string location, string source, bool shouldRpcContainRestorePoints = false)
        {
            Assert.Equal(rpcName, rpc.Name);
            Assert.Equal(location, rpc.Location, ignoreCase: true);
            Assert.NotNull(rpc.Id);
            Assert.Equal("Microsoft.Compute/restorePointCollections", rpc.Type);
            Assert.Equal(source, rpc.Source.Id, ignoreCase: true);
            Assert.NotNull(rpc.Id);
            IDictionary<string, string> tagsOnRestorePoint = rpc.Tags;

            // RPC contains restore points only if request contains $expand=restorePoints
            if (shouldRpcContainRestorePoints)
            {
                Assert.NotNull(rpc.RestorePoints);
                Assert.Equal(1, rpc.RestorePoints.Count);
            }
            else
            {
                Assert.Null(rpc.RestorePoints);
            }
        }

        private RestorePointCollection GetRpc(string rgName, string rpcName,
            string expandOptions = null)
        {
            return m_CrpClient.RestorePointCollections.Get(
                rgName,
                rpcName,
                expandOptions);
        }

        // Create restore point and exercise 'ExcludeDisk' functionality by excluding dataDisk.
        private RestorePoint CreateRestorePoint(string rgName, string rpcName, 
            string rpName, OSDisk osDisk, string diskToExclude)
        {
            string osDiskId = osDisk.ManagedDisk.Id;
            string osDiskName = osDisk.Name;
            ApiEntityReference diskToExcludeEntityRef = new ApiEntityReference() { Id = diskToExclude };
            List<ApiEntityReference> disksToExclude = new List<ApiEntityReference> { diskToExcludeEntityRef };
            return m_CrpClient.RestorePoints.Create(rgName, rpcName, rpName, disksToExclude);
        }

        // Verify restore point properties.
        // Verify disk exclusion by verifying the the returned restore point contains the id of the 
        // excluded disk in 'ExcludeDisks' propertyand did not create diskRestorePoint
        // of the excluded data disk.
        void VerifyRestorePointDetails(RestorePoint rp, string rpName, OSDisk osDisk,
            int excludeDisksCount, string excludeDiskId, string vmId, string vmSize)
        {
            Assert.Equal(rpName, rp.Name);
            //Assert.Equal(vmId, rp.SourceMetadata.VmId, ignoreCase: true);
            Assert.NotNull(rp.Id);
            Assert.NotNull(rp.ProvisioningDetails.CreationTime);
            Assert.NotNull(rp.ProvisioningDetails.StatusCode);
            Assert.NotNull(rp.ProvisioningDetails.StatusMessage);
            Assert.NotNull(rp.ProvisioningDetails.TotalUsedSizeInBytes);
            Assert.Equal(ProvisioningState.Succeeded.ToString(), rp.ProvisioningState);
            Assert.Equal(ConsistencyModeTypes.ApplicationConsistent, rp.ConsistencyMode);
            RestorePointSourceVMStorageProfile storageProfile = rp.SourceMetadata.StorageProfile;
            Assert.Equal(osDisk.Name, storageProfile.OsDisk.Name, ignoreCase: true);
            Assert.Equal(osDisk.ManagedDisk.Id, storageProfile.OsDisk.ManagedDisk.Id, ignoreCase: true);
            Assert.Equal(excludeDisksCount, rp.ExcludeDisks.Count);
            Assert.Equal(excludeDiskId, rp.ExcludeDisks[0].Id, ignoreCase: true);
            Assert.NotNull(rp.SourceMetadata.VmId);
            Assert.Equal(vmSize, rp.SourceMetadata.HardwareProfile.VmSize);
        }

        private RestorePointCollection CreateRpc(string sourceVMId, string rpcName,
            string rgName, string location, Dictionary<string, string> tags)
        {
            Models.SubResource sourceVM = new Models.SubResource(id: sourceVMId);
            var inputRpc = new RestorePointCollection(location, source: sourceVM, name: rpcName, tags: tags);
            RestorePointCollection restorePointCollection =
                m_CrpClient.RestorePointCollections.CreateOrUpdate(rgName, rpcName,
                inputRpc);
            return restorePointCollection;
        }
    }
}
