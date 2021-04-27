using Compute.Tests;
using Microsoft.Azure.Management.Compute.Models;
using Microsoft.Azure.Management.Compute;
using Microsoft.Azure.Management.ResourceManager;
using Microsoft.Azure.Management.Storage.Models;
using Microsoft.Rest.Azure;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using Xunit;

namespace Microsoft.Azure.Management.Compute.Tests.ScenarioTests
{
    public class RestorePointsTest : VMTestBase
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
        [Fact]
        public void CreateRpcAndRestorePoints()
        {
            using (MockContext context = MockContext.Start(this.GetType().FullName))
            {
                EnsureClientsInitialized(context);
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
                    Dictionary<string, string> originalTags = new Dictionary<string, string>()
                    {
                        {"OriginalTag1", "originalTagValue1"},
                        {"OriginalTag2", "originalTagValue2"}
                    };
                    RestorePointCollection createdRpc = CreateRpc(createdVM.Id, rpcName, rgName, location, originalTags);
                    VerifyRestorePointCollection(createdRpc, rpcName, location, vmId, originalTags);

                    RestorePointCollection createdRpc2 = CreateRpc(createdVM.Id, rpcName2, rgName, location, originalTags);
                    VerifyRestorePointCollection(createdRpc2, rpcName2, location, vmId, originalTags);

                    // for PATCH RPC, only tags are allowed to be updated
                    Dictionary<string, string> newTags = new Dictionary<string, string>()
                    {
                        {"newTag1", "newValue1"},
                        {"newTag2", "newValue2"},
                    };

                    // Update tags on the first rpc. Do not update tags on the second rpc.
                    UpdateRestorePointCollection(rgName, rpcName, createdRpc, newTags);

                    // GET list of all rpc in the resource group.
                    IEnumerable<RestorePointCollection> rpcs = ListRpcInResourceGroup(rgName);
                    VerifyReturnedRpcs(rpcs, rpcName, rpcName2, location, vmId, newTags, originalTags);

                    // GET list of all rpc in subscription.
                    rpcs = ListRestorePointCollectionsInSubscription();
                    VerifyReturnedRpcs(rpcs, rpcName, rpcName2, location, vmId, newTags, originalTags);

                    // create RP in the RPC
                    RestorePoint createdRP = CreateRestorePoint(rgName, rpcName, rpName, osDisk, diskToExclude: dataDiskId);
                    VerifyRestorePointDetails(createdRP, rpName, osDisk, 1,
                        expectedExcludeDiskId: dataDiskId, expectedVmSize: vmSize);
                    RestorePoint getRP = GetRestorePoint(rgName, rpcName, rpName);
                    VerifyRestorePointDetails(createdRP, rpName, osDisk, 1,
                        expectedExcludeDiskId: dataDiskId, expectedVmSize: vmSize);

                    // get RPC without $expand=restorePoints
                    RestorePointCollection returnedRpc = GetRpc(rgName, rpcName);
                    VerifyRestorePointCollection(returnedRpc, rpcName, location, vmId, originalTags);

                    // get RPC with $expand=restorePoints
                    returnedRpc = GetRpc(rgName, rpcName, RestorePointCollectionExpandOptions.RestorePoints);
                    VerifyRestorePointCollection(returnedRpc, rpcName, location, vmId, originalTags, expectedCountOfContainedRestorePoints: 1);

                    // verify the restore point returned from GET RPC with $expand=restorePoints
                    VerifyRestorePointDetails(returnedRpc.RestorePoints[0], rpName, osDisk, 1,
                        expectedExcludeDiskId: dataDiskId, expectedVmSize: vmSize);

                    // delete the restore point
                    DeleteRP(rgName, rpcName, rpName);
                    // GET of deleted restore point should return 404 not found
                    try
                    {
                        GetRestorePoint(rgName, rpcName, rpName);
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

        // Verify that the two rpcs created by this test are in the GET restorePointCollections response.
        private void VerifyReturnedRpcs(IEnumerable<RestorePointCollection> rpcs, string rpcName1, string rpcName2, string location, string vmId,
            Dictionary<string, string> tagsForRpc1, Dictionary<string, string> tagsForRpc2)
        {
            // two rpcs are returned because the RG has two rpcs
            RestorePointCollection rpc1 = rpcs.Where(rpc => rpc.Name == rpcName1).First();
            VerifyRestorePointCollection(rpc1, rpcName1, location, vmId, tagsForRpc1);
            RestorePointCollection rpc2 = rpcs.Where(rpc => rpc.Name == rpcName2).First();
            VerifyRestorePointCollection(rpc2, rpcName2, location, vmId, tagsForRpc2);
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

        private IEnumerable<RestorePointCollection> ListRestorePointCollectionsInSubscription()
        {
            return m_CrpClient.RestorePointCollections.ListAll();
        }

        // for update of RPC, only update of tags is permitted
        private void UpdateRestorePointCollection(string rgName, string rpcName, RestorePointCollection rpc,
            Dictionary<string, string> tags)
        {
            rpc.Tags = tags;
            RestorePointCollectionUpdate updateRpc = new RestorePointCollectionUpdate(
                tags, rpc.Source, provisioningState: null, restorePointCollectionId: null, restorePoints: new List<RestorePoint>());
            m_CrpClient.RestorePointCollections.Update(rgName, rpcName, updateRpc);
        }

        // GET Restore Point
        private RestorePoint GetRestorePoint(string rgName, string rpcName,
            string rpName)
        {
            return m_CrpClient.RestorePoints.Get(rgName, rpcName, rpName);
        }

        // Verify the properties of the restorePointCollection.
        // If verifying result of GET RPC with $expand=restorePoints, verify that the returned rpc contains the expected number of restore points
        private void VerifyRestorePointCollection(RestorePointCollection rpc, string expctedRpcName,
            string expectedLocation, string expectdSourceVmId, Dictionary<string, string> expectedTags,
            int expectedCountOfContainedRestorePoints = 0)
        {
            Assert.NotNull(rpc);
            Assert.NotNull(rpc.Id);
            Assert.Equal(expctedRpcName, rpc.Name);
            Assert.Equal(expectedLocation, rpc.Location, ignoreCase: true);
            Assert.Equal("Microsoft.Compute/restorePointCollections", rpc.Type);
            Assert.Equal(expectdSourceVmId, rpc.Source.Id, ignoreCase: true);
            Assert.Equal(expectedLocation, rpc.Source.Location, ignoreCase: true);
            // Verify the tags on the rpc
            foreach ((string expectedTag, string value) in expectedTags)
            {
                Assert.True(rpc.Tags.Contains(KeyValuePair.Create(expectedTag, value)));
            }

            // TODO: verify rpc provisoningState after rollout
            //Assert.Equal("Successful", rpc.ProvisioningState, ignoreCase: true);

            // If GET rpc request uses $expand=restorePoints, then restore points should be returned
            if (expectedCountOfContainedRestorePoints == 0)
            {
                Assert.Null(rpc.RestorePoints);
            }
            else
            {
                Assert.NotNull(rpc.RestorePoints);
                Assert.Equal(expectedCountOfContainedRestorePoints, rpc.RestorePoints.Count);
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
        // Verify disk exclusion by verifying that the returned restore point contains the id of the 
        // excluded disk in 'ExcludeDisks' property and did not create diskRestorePoint
        // of the excluded data disk.
        void VerifyRestorePointDetails(RestorePoint restorePoint, string expectedRestorePointName, OSDisk expectedOsDisk,
            int expectedExcludeDisksCount, string expectedExcludeDiskId, string expectedVmSize)
        {
            Assert.Equal(expectedRestorePointName, restorePoint.Name);
            Assert.NotNull(restorePoint.Id);
            Assert.NotNull(restorePoint.ProvisioningDetails.CreationTime);
            Assert.NotNull(restorePoint.ProvisioningDetails.StatusCode);
            Assert.NotNull(restorePoint.ProvisioningDetails.StatusMessage);
            Assert.NotNull(restorePoint.ProvisioningDetails.TotalUsedSizeInBytes);
            Assert.Equal(ProvisioningState.Succeeded.ToString(), restorePoint.ProvisioningState);
            Assert.Equal(ConsistencyModeTypes.ApplicationConsistent, restorePoint.ConsistencyMode);
            RestorePointSourceVMStorageProfile storageProfile = restorePoint.SourceMetadata.StorageProfile;
            Assert.Equal(expectedOsDisk.Name, storageProfile.OsDisk.Name, ignoreCase: true);
            Assert.Equal(expectedOsDisk.ManagedDisk.Id, storageProfile.OsDisk.ManagedDisk.Id, ignoreCase: true);
            Assert.Equal(expectedExcludeDisksCount, restorePoint.ExcludeDisks.Count);
            Assert.Equal(expectedExcludeDiskId, restorePoint.ExcludeDisks[0].Id, ignoreCase: true);
            Assert.NotNull(restorePoint.SourceMetadata.VmId);
            Assert.Equal(expectedVmSize, restorePoint.SourceMetadata.HardwareProfile.VmSize);
        }

        private RestorePointCollection CreateRpc(string sourceVMId, string rpcName,
            string rgName, string location, Dictionary<string, string> tags)
        {
            RestorePointCollectionSourceProperties rpcSourceProperties = new RestorePointCollectionSourceProperties(id: sourceVMId);
            var inputRpc = new RestorePointCollection(location, source: rpcSourceProperties, name: rpcName, tags: tags);
            RestorePointCollection restorePointCollection =
                m_CrpClient.RestorePointCollections.CreateOrUpdate(rgName, rpcName,
                inputRpc);
            return restorePointCollection;
        }
    }
}