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
                const string testPrefix = TestPrefix;
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

                    
                    string rpcName = ComputeManagementTestUtilities.GenerateName("rpc1ClientTest");
                    VerifyRPCCreation(createdVM.Id, rpcName, rgName, location);
                    VerifyRestorePointCreation(rgName, rpcName, location);
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

        private void VerifyRestorePointCreation(string rgName, string rpcName, string location)
        {
            var inputRPName = ComputeManagementTestUtilities.GenerateName("rpClientTest");
            ApiEntityReference diskToExclude = new ApiEntityReference() { Id = "" };
            var inputRP = new RestorePoint
            {
                Name = inputRPName,
                Location = location,
                Tags = new Dictionary<string, string>()
                {
                    {"RG", "rg"},
                    {"testTag", "1"},
                },
                // need to change model to be public setter
                //ExcludeDisks = new List<ApiEntityReference> { diskToExclude },
            };

            try
            {
                RestorePoint createOrUpdateResponse = m_CrpClient.RestorePoints.CreateOrUpdate(
                    rgName,
                    rpcName,
                    inputRPName,
                    inputRP);
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
