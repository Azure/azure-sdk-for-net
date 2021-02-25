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
                    DataDisk disk = createdVM.StorageProfile.DataDisks[0];
                    string diskId = disk.ManagedDisk.Id;

                    
                    string rpName = ComputeManagementTestUtilities.GenerateName("rpClientTest");
                    string rpcName = ComputeManagementTestUtilities.GenerateName("rpc1ClientTest");
                    VerifyRPCCreation(createdVM.Id, rpcName, rgName, location);
                    VerifyRestorePointCreation(rgName, rpcName, rpName, diskToExclude: diskId);
                    GetRP(rgName, rpcName, rpName);
                    GetRpc(rgName, rpcName);
                    GetRpc(rgName, rpcName, RestorePointCollectionExpandOptions.RestorePoints);
                    //VerifyRestorePointCreation(rgName, rpcName, location);
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

        private void GetRP(string rgName, string rpcName, string rpName)
        {
            try
            {
                RestorePoint createdRP = m_CrpClient.RestorePoints.Get(
                    rgName,
                    rpcName,
                    rpName);
                Assert.Equal(rpName, createdRP.Name);
            }
            catch (CloudException ex)
            {
                Assert.True(ex.Response.StatusCode == HttpStatusCode.BadRequest);
            }
        }

        private void GetRpc(string rgName, string rpcName,
            RestorePointCollectionExpandOptions? expandOptions = null)
        {
            try
            {
                RestorePointCollection createdRP = m_CrpClient.RestorePointCollections.Get(
                    rgName,
                    rpcName,
                    expandOptions);
            }
            catch (CloudException ex)
            {
                Assert.True(ex.Response.StatusCode == HttpStatusCode.BadRequest);
            }
        }

        private void VerifyRestorePointCreation(string rgName, string rpcName, 
            string rpName, string diskToExclude = null)
        {
            ApiEntityReference diskToExcludeEntityRef = new ApiEntityReference() { Id = diskToExclude };
            var inputRP = new RestorePoint
            {
                Name = rpName,
                //ExcludeDisks = new List<ApiEntityReference> { diskToExclude },
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
                // returned rp id = "/subscriptions/0296790d-427c-48ca-b204-8b729bbd8670/resourceGroups/crptestar872/providers/Microsoft.Compute/restorePointCollections/rpc1ClientTest908/restorePoints/rpClientTest2613"
            }
            catch (CloudException ex)
            {
                Assert.True(ex.Response.StatusCode == HttpStatusCode.BadRequest);
            }
        }

        private void GetRestorePoint(string rgName, string rpcName, string location)
        {
            var rpName = ComputeManagementTestUtilities.GenerateName("rpClientTest");
            ApiEntityReference diskToExclude = new ApiEntityReference() { Id = "" };
            var inputRP = new RestorePoint
            {
                Name = rpName,
                // need to change model to be public setter
                //ExcludeDisks = new List<ApiEntityReference> { diskToExclude },
            };

            try
            {
                RestorePoint createdRP = m_CrpClient.RestorePoints.CreateOrUpdate(
                    rgName,
                    rpcName,
                    rpName,
                    inputRP);
                Assert.Equal(rpName, createdRP.Name);
                // returned rp id = "/subscriptions/0296790d-427c-48ca-b204-8b729bbd8670/resourceGroups/crptestar872/providers/Microsoft.Compute/restorePointCollections/rpc1ClientTest908/restorePoints/rpClientTest2613"
            }
            catch (CloudException ex)
            {
                Assert.True(ex.Response.StatusCode == HttpStatusCode.BadRequest);
            }
            // exclude an actual disk on the restore point
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
