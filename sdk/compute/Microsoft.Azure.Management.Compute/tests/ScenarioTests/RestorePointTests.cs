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

namespace Compute.Tests
{
    public class RestorePointTests : VMTestBase
    {
        /// <summary>
        /// This test covers both local Restore Points and Cross-region copy scenarios
        /// Covers following Operations:
        /// Create source VM
        /// Create two Restore Point Collections for the source VM
        /// Create rpc in a different region referencing to rpc in source region (cross-region copy scenario)      
        /// Update rpc via PATCH
        /// Create restore point and exclude one data disk using ExcludeDisks property
        /// Copy restore point to different region (cross-region copy scenario)
        /// Get restore point with instance view (applicable only for restorePoint created via cross-region copy scenario)
        /// List all restore points in rpc (using $expand=restorePoints)
        /// List all rpcs in resource group
        /// List all rpcs in subscription
        /// Delete restore point
        /// Delete restore point collection
        /// </summary>
        [Fact(Skip = "Restore Points are created in a different sub")]
        [Trait("Name", "CreateRpcAndRestorePoints")]
        public void CreateRpcAndRestorePoints()
        {
            string originalTestLocation = Environment.GetEnvironmentVariable("AZURE_VM_TEST_LOCATION");
            using (MockContext context = MockContext.Start(this.GetType().FullName))
            {
                string location = "southcentralus";
                Environment.SetEnvironmentVariable("AZURE_VM_TEST_LOCATION", location);                
                EnsureClientsInitialized(context);
                var rgName = ComputeManagementTestUtilities.GenerateName(TestPrefix);
                ImageReference imageRef = GetPlatformVMImage(useWindowsImage: true);
                VirtualMachine inputVM;
                string storageAccountForDisksName = TestUtilities.GenerateName(TestPrefix);
                string availabilitySetName = TestUtilities.GenerateName(TestPrefix);

                try
                {
                    StorageAccount storageAccountForDisks = CreateStorageAccount(rgName, storageAccountForDisksName);
                    // create the VM
                    VirtualMachine createdVM = CreateVM(rgName, availabilitySetName, storageAccountForDisks.Name, imageRef, out inputVM,
                        (vm) =>
                        {
                            vm.DiagnosticsProfile = GetManagedDiagnosticsProfile();
                        }, hasManagedDisks: true,
                        vmSize: "Standard_M16ms",
                        osDiskStorageAccountType: "Premium_LRS",
                        dataDiskStorageAccountType: "Premium_LRS",
                        writeAcceleratorEnabled: true);
                    DataDisk dataDisk = createdVM.StorageProfile.DataDisks[0];
                    string dataDiskId = dataDisk.ManagedDisk.Id;
                    OSDisk osDisk = createdVM.StorageProfile.OsDisk;

                    string rpName = ComputeManagementTestUtilities.GenerateName("rpClientTest");
                    string rpcName = ComputeManagementTestUtilities.GenerateName("rpc1ClientTest");
                    string rpcName2 = ComputeManagementTestUtilities.GenerateName("rpc2ClientTest");
                    string remoteRpcName = ComputeManagementTestUtilities.GenerateName("rpcRemoteClientTest");
                    string remoteRpName = ComputeManagementTestUtilities.GenerateName("rpRemoteClientTest");
                    string vmId = createdVM.Id;
                    string vmSize = createdVM.HardwareProfile.VmSize;

                    // create two RPCs
                    Dictionary<string, string> tags = new Dictionary<string, string>()
                    {
                        {"RG", "rg"},
                        {"testTag", "testTagValue"},
                    };
                    RestorePointCollection createdRpc = CreateRpc(vmId, rpcName, rgName, location, tags);
                    VerifyRpc(createdRpc, rpcName, location, vmId);

                    RestorePointCollection createdRpc2 = CreateRpc(vmId, rpcName2, rgName, location, tags);
                    VerifyRpc(createdRpc2, rpcName2, location, vmId);

                    // create RPC in a different region referencing to 'createdRpc'. This is for cross-region restore point scenario.
                    string remoteRpcLocation = "eastus2euap", sourceRpcId = createdRpc.Id;
                    RestorePointCollection remoteRpc = CreateRpc(sourceRpcId, remoteRpcName, rgName, remoteRpcLocation, tags);
                    VerifyRpc(remoteRpc, remoteRpcName, remoteRpcLocation, sourceRpcId);

                    // for PATCH RPC, only tags are allowed to be updated
                    Dictionary<string, string> newTags = new Dictionary<string, string>()
                    {
                        {"newTag", "newValue1"},
                        {"newtestTag", "newValue2"},
                    };
                    UpdateRpc(rgName, rpcName, createdRpc, newTags);

                    // GET list of all rpc in the resource group.
                    IEnumerable<RestorePointCollection> rpcs = ListRpcInResourceGroup(rgName);
                    VerifyReturnedRpcs(rpcs, rpcName, rpcName2, remoteRpcName, location, remoteRpcLocation, vmId, sourceRpcId);

                    // GET list of all rpc in subscription.
                    rpcs = ListRpcInSubscription();
                    VerifyReturnedRpcs(rpcs, rpcName, rpcName2, remoteRpcName, location, remoteRpcLocation, vmId, sourceRpcId);

                    // create RP in the RPC
                    RestorePoint createdRP = CreateRestorePoint(rgName, rpcName, rpName, diskToExclude: dataDiskId, sourceRestorePointId: null);
                    VerifyRestorePointDetails(createdRP, rpName, osDisk, 1,
                        excludeDiskId: dataDiskId, vmSize: vmSize);
                    RestorePoint getRP = GetRP(rgName, rpcName, rpName);
                    VerifyRestorePointDetails(getRP, rpName, osDisk, 1,
                        excludeDiskId: dataDiskId, vmSize: vmSize);
                    VerifyDiskRestorePoint(rgName, rpcName, rpName);

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
                        excludeDiskId: dataDiskId, vmSize: vmSize);
                    VerifyDiskRestorePoint(rgName, rpcName, rpName);

                    // Copy above created RestorePoint to a different region.
                    RestorePoint createdRemoteRP = CreateRestorePoint(rgName, remoteRpcName, remoteRpName, diskToExclude: null, sourceRestorePointId: createdRP.Id);
                    VerifyRestorePointDetails(createdRemoteRP, remoteRpName, osDisk, 1, excludeDiskId: dataDiskId, vmSize: vmSize, isRemoteCopy: true, sourceRestorePointId: createdRP.Id);

                    RestorePoint getRemoteRP = GetRP(rgName, remoteRpcName, remoteRpName, expand: RestorePointExpandOptions.InstanceView);
                    VerifyRestorePointDetails(getRemoteRP, remoteRpName, osDisk, 1, excludeDiskId: dataDiskId, vmSize: vmSize, isRemoteCopy: true, 
                        sourceRestorePointId: createdRP.Id, isRemoteCopyInstanceView: true);

                    // delete the restore point
                    DeleteRP(rgName, rpcName, rpName);

                    //delete restore point created via cross-region copy scenario
                    DeleteRP(rgName, remoteRpcName, remoteRpName);

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
                    Environment.SetEnvironmentVariable("AZURE_VM_TEST_LOCATION", originalTestLocation);
                }
            }
        }

        /// <summary>
        /// Create restore point for VM with SecurityType as TrustedLaunch
        /// Verify SecurityType of DiskRestorePoint
        /// </summary>
        [Fact(Skip = "Restore Points are created in a different sub")]
        [Trait("Name", "CreateLocalRestorePointWithSecurityProfile")]
        public void CreateLocalRestorePointWithSecurityProfile()
        {
            string originalTestLocation = Environment.GetEnvironmentVariable("AZURE_VM_TEST_LOCATION");
            using (MockContext context = MockContext.Start(this.GetType().FullName))
            {
                string location = "southcentralus";
                Environment.SetEnvironmentVariable("AZURE_VM_TEST_LOCATION", location);
                EnsureClientsInitialized(context);
                var rgName = ComputeManagementTestUtilities.GenerateName(TestPrefix);
                ImageReference imageRef = new ImageReference(publisher: "MICROSOFTWINDOWSDESKTOP", offer: "WINDOWS-10", version: "latest", sku: "20H2-ENT-G2");
                VirtualMachine inputVM;
                string storageAccountForDisks = TestUtilities.GenerateName(TestPrefix);
                string availabilitySetName = TestUtilities.GenerateName(TestPrefix);

                try
                {
                    // PUT VM with SecurityType = TrustedLaunch
                    VirtualMachine createdVM = CreateVM(rgName, availabilitySetName, storageAccountForDisks, imageRef, out inputVM, hasManagedDisks: true,
                        vmSize: VirtualMachineSizeTypes.StandardD2sV3, securityType: "TrustedLaunch");

                    string rpcName = ComputeManagementTestUtilities.GenerateName("rpcClientTest");
                    string rpName = ComputeManagementTestUtilities.GenerateName("rpClientTest");

                    // Create Restore Point Collection
                    string vmId = createdVM.Id;
                    string vmSize = createdVM.HardwareProfile.VmSize;
                    Dictionary<string, string> tags = new Dictionary<string, string>() { { "testTag", "testTagValue" } };
                    RestorePointCollection createdRpc = CreateRpc(vmId, rpcName, rgName, location, tags);

                    // Create Restore Point
                    RestorePoint createdRP = CreateRestorePoint(rgName, rpcName, rpName, diskToExclude: null, sourceRestorePointId: null);

                    // GET Disk Restore Point
                    IPage<DiskRestorePoint> listDiskRestorePoint = m_CrpClient.DiskRestorePoint.ListByRestorePoint(rgName, rpcName, rpName);
                    var getDrp = m_CrpClient.DiskRestorePoint.Get(rgName, rpcName, rpName, listDiskRestorePoint.First().Name);

                    Assert.Equal("TrustedLaunch",getDrp.SecurityProfile.SecurityType);
                }
                catch (Exception e)
                {
                    throw e;
                }
                finally
                {
                    m_ResourcesClient.ResourceGroups.Delete(rgName);
                    Environment.SetEnvironmentVariable("AZURE_VM_TEST_LOCATION", originalTestLocation);
                }
            }
        }

        // Verify that the two rpcs created by this test are in the GET restorePointCollections response.
        private void VerifyReturnedRpcs(IEnumerable<RestorePointCollection> rpcs, string rpcName1, string rpcName2, string remoteRcpName, string location, 
            string remoteLocation, string sourceVMId, string sourceRpcId)
        {
            // two rpcs are returned because the RG has two rpcs
            RestorePointCollection rpc1 = rpcs.Where(rpc => rpc.Name == rpcName1).First();
            VerifyRpc(rpc1, rpcName1, location, sourceVMId);
            RestorePointCollection rpc2 = rpcs.Where(rpc => rpc.Name == rpcName2).First();
            VerifyRpc(rpc2, rpcName2, location, sourceVMId);
            RestorePointCollection rpc3 = rpcs.Where(rpc => rpc.Name == remoteRcpName).First();
            VerifyRpc(rpc3, remoteRcpName, remoteLocation, sourceRpcId);
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
            Dictionary<string, string> tags)
        {
            rpc.Tags = tags;
            RestorePointCollectionUpdate updateRpc = new RestorePointCollectionUpdate(
                tags, rpc.Source);
            m_CrpClient.RestorePointCollections.Update(rgName, rpcName, updateRpc);
        }

        private RestorePoint GetRP(string rgName, string rpcName,
            string rpName, string expand = null)
        {
            return m_CrpClient.RestorePoints.Get(rgName, rpcName, rpName, expand);
        }

        // if verifying result of GET RPC with $expand=restorePoints, verify that the returned rpc contains the expected restore point
        private void VerifyRpc(RestorePointCollection rpc, string rpcName,
            string location, string sourceResourceId, bool shouldRpcContainRestorePoints = false)
        {
            Assert.NotNull(rpc);
            Assert.Equal(rpcName, rpc.Name);
            Assert.Equal(location, rpc.Location, ignoreCase: true);
            Assert.NotNull(rpc.Id);
            Assert.Equal("Microsoft.Compute/restorePointCollections", rpc.Type);
            Assert.Equal(sourceResourceId, rpc.Source.Id, ignoreCase: true);
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
            string rpName, string diskToExclude, string sourceRestorePointId)
        {
            RestorePoint inputRestorePoint = new RestorePoint();
            if (diskToExclude != null)
            {
                ApiEntityReference diskToExcludeEntityRef = new ApiEntityReference() { Id = diskToExclude };
                List<ApiEntityReference> disksToExclude = new List<ApiEntityReference> { diskToExcludeEntityRef };
                inputRestorePoint.ExcludeDisks = disksToExclude;
            }

            if (sourceRestorePointId != null)
            {
                inputRestorePoint.SourceRestorePoint = new ApiEntityReference() { Id = sourceRestorePointId };
            }

            return m_CrpClient.RestorePoints.Create(rgName, rpcName, rpName, inputRestorePoint);
        }

        // Verify restore point properties.
        // Verify disk exclusion by verifying that the returned restore point contains the id of the 
        // excluded disk in 'ExcludeDisks' property and did not create diskRestorePoint
        // of the excluded data disk.
        // For RestorePoint created via cross-region copy scenario, sourceRestorePoint.Id is verified.
        // For GET instance view of RestorePoint created via cross-region copy scenario, instanceView is verified.
        void VerifyRestorePointDetails(RestorePoint restorePoint, string restorePointName, OSDisk osDisk,
            int excludeDisksCount, string excludeDiskId, string vmSize, bool isRemoteCopy = false, string sourceRestorePointId = null, 
            bool isRemoteCopyInstanceView = false)
        {
            Assert.Equal(restorePointName, restorePoint.Name);
            Assert.NotNull(restorePoint.Id);
            Assert.Equal(ProvisioningState.Succeeded.ToString(), restorePoint.ProvisioningState);
            Assert.Equal(ConsistencyModeTypes.ApplicationConsistent, restorePoint.ConsistencyMode);
            Assert.Equal(HyperVGenerationType.V1, restorePoint.SourceMetadata.HyperVGeneration);
            RestorePointSourceVMStorageProfile storageProfile = restorePoint.SourceMetadata.StorageProfile;
            Assert.Equal(osDisk.Name, storageProfile.OsDisk.Name, ignoreCase: true);
            Assert.True(osDisk.WriteAcceleratorEnabled ?? false);
            Assert.Equal(osDisk.ManagedDisk.Id, storageProfile.OsDisk.ManagedDisk.Id, ignoreCase: true);
            Assert.NotNull(restorePoint.SourceMetadata.VmId);
            Assert.Equal(vmSize, restorePoint.SourceMetadata.HardwareProfile.VmSize);
            Assert.Equal(EncryptionType.EncryptionAtRestWithPlatformKey, storageProfile.OsDisk.DiskRestorePoint.Encryption.Type);

            if (isRemoteCopy)
            {
                Assert.Equal(sourceRestorePointId, restorePoint.SourceRestorePoint.Id);
                if (isRemoteCopyInstanceView)
                {
                    RestorePointInstanceView restorePointInstanceView = restorePoint.InstanceView;
                    Assert.NotNull(restorePointInstanceView);
                    Assert.Equal(storageProfile.DataDisks.Count + 1, restorePointInstanceView.DiskRestorePoints.Count);
                    Assert.NotNull(restorePointInstanceView.DiskRestorePoints[0].ReplicationStatus.CompletionPercent);
                }
            }
            else
            {
                Assert.Equal(excludeDisksCount, restorePoint.ExcludeDisks.Count);
                Assert.Equal(excludeDiskId, restorePoint.ExcludeDisks[0].Id, ignoreCase: true);
            }
        }

        private RestorePointCollection CreateRpc(string sourceResourceId, string rpcName,
            string rgName, string location, Dictionary<string, string> tags)
        {
            //Models.SubResource sourceVM = new Models.SubResource(id: sourceVMId);
            RestorePointCollectionSourceProperties rpcSourceProperties = new RestorePointCollectionSourceProperties(location: location, id: sourceResourceId);
            var inputRpc = new RestorePointCollection(location, source: rpcSourceProperties, name: rpcName, tags: tags);
            RestorePointCollection restorePointCollection =
                m_CrpClient.RestorePointCollections.CreateOrUpdate(rgName, rpcName,
                inputRpc);
            return restorePointCollection;
        }

        // Verify disk restore points.
        private void VerifyDiskRestorePoint(string rgName, string rpcName, string rpName)
        {
            IPage<DiskRestorePoint> listDiskRestorePoint = m_CrpClient.DiskRestorePoint.ListByRestorePoint(rgName, rpcName, rpName);
            GrantAccessData accessData = new GrantAccessData { Access = AccessLevel.Read, DurationInSeconds = 1000 };
            foreach (DiskRestorePoint drp in listDiskRestorePoint)
            {
                var getDrp = m_CrpClient.DiskRestorePoint.Get(rgName, rpcName, rpName, drp.Name);
                ValidateDiskRestorePoint(getDrp, drp.Name);

                AccessUri accessUri = m_CrpClient.DiskRestorePoint.GrantAccess(rgName, rpcName, rpName, getDrp.Name, accessData);
                Assert.NotNull(accessUri.AccessSAS);

                getDrp = m_CrpClient.DiskRestorePoint.Get(rgName, rpcName, rpName, drp.Name);
                ValidateDiskRestorePoint(getDrp, drp.Name);

                m_CrpClient.DiskRestorePoint.RevokeAccess(rgName, rpcName, rpName, drp.Name);
            }
        }

        private void ValidateDiskRestorePoint(DiskRestorePoint drp, string rpName)
        {
            Assert.NotNull(drp);
            Assert.NotNull(drp.Id);
            Assert.Equal(rpName, drp.Name);
        }
    }
}