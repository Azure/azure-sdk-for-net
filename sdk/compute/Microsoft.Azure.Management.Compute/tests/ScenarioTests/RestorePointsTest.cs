using Compute.Tests;
using Microsoft.Azure.Management.Compute.Models;
using Microsoft.Azure.Management.ResourceManager;
using Microsoft.Azure.Management.ResourceManager.Models;
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
        ResourceManagementClient resourcesClient;

        ResourceGroup resourceGroup;

        string subId;
        string location;
        const string testPrefix = TestPrefix;
        string resourceGroupName;

        [Fact]
        public void TestOperations()
        {
            using (MockContext context = MockContext.Start(this.GetType().FullName))
            {
                EnsureClientsInitialized(context);
                //Initialize(context);
                // create the VM
                var rgName = ComputeManagementTestUtilities.GenerateName(TestPrefix);
                string storageAccountName = ComputeManagementTestUtilities.GenerateName(TestPrefix);
                string asName = ComputeManagementTestUtilities.GenerateName("as");
                VirtualMachine inputVM;

                try
                {
                    // Create Storage Account
                    var storageAccountOutput = CreateStorageAccount( rgName, storageAccountName );

                    Action<VirtualMachine> addDataDiskToVM = vm =>
                    {
                        string containerName = HttpMockServer.GetAssetName("TestVMDataDiskScenario", TestPrefix);
                        var vhdContainer = "https://" + storageAccountName + ".blob.core.windows.net/" + containerName;
                        var vhduri = vhdContainer + string.Format("/{0}.vhd", HttpMockServer.GetAssetName("TestVMDataDiskScenario", TestPrefix));

                        vm.HardwareProfile.VmSize = VirtualMachineSizeTypes.StandardA4;
                        vm.StorageProfile.DataDisks = new List<DataDisk>();
                        foreach (int index in new int[] {1, 2})
                        {
                            var diskName = "dataDisk" + index;
                            var ddUri = vhdContainer + string.Format("/{0}{1}.vhd", diskName, HttpMockServer.GetAssetName("TestVMDataDiskScenario", TestPrefix));
                            var dd = new DataDisk
                            {
                                Caching = CachingTypes.None,
                                Image = null,
                                DiskSizeGB = 10,
                                CreateOption = DiskCreateOptionTypes.Empty,
                                Lun = 1 + index,
                                Name = diskName,
                                Vhd = new VirtualHardDisk
                                {
                                    Uri = ddUri
                                }
                            };
                            vm.StorageProfile.DataDisks.Add(dd);
                        }

                        var testStatus = new InstanceViewStatus
                        {
                            Code = "test",
                            Message = "test"
                        };

                        var testStatusList = new List<InstanceViewStatus> { testStatus };

                    };

                    ImageReference imgageRef = GetPlatformVMImage(useWindowsImage: true);
                    var vm1 = CreateVM(rgName, asName, storageAccountOutput, imgageRef, out inputVM, addDataDiskToVM);

                    // Attempt to Create Availability Set with out of bounds FD and UD values
                    VerifyRPCCreation(vm1.Id);
                    VerifyRestorePointCreation();
                }
                catch (CloudException ex)
                {
                    Console.WriteLine("Here");
                }
                finally
                {
                    resourcesClient.ResourceGroups.Delete(resourceGroupName);
                }
            }
        }

        /*
        private void Initialize(MockContext context)
        {
            handler = new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK };
            resourcesClient = ComputeManagementTestUtilities.GetResourceManagementClient(context, handler);
            computeClient = ComputeManagementTestUtilities.GetComputeManagementClient(context, handler);

            subId = computeClient.SubscriptionId;
            location = ComputeManagementTestUtilities.DefaultLocation;

            resourceGroupName = ComputeManagementTestUtilities.GenerateName(testPrefix);

            resourceGroup = resourcesClient.ResourceGroups.CreateOrUpdate(
                resourceGroupName,
                new ResourceGroup
                {
                    Location = location,
                    Tags = new Dictionary<string, string>() { { resourceGroupName, "RB" + DateTime.UtcNow.ToString("u") } } });
        }
        */

        private void VerifyRestorePointCreation()
        {
            var inputRPName = ComputeManagementTestUtilities.GenerateName("rpClientTest");
            var inputRPCName = ComputeManagementTestUtilities.GenerateName("rpcClientTest");
            ApiEntityReference diskToExclude = new ApiEntityReference() { Id = "" };
            var inputRP = new RestorePoint
            {
                Location = location,
                Tags = new Dictionary<string, string>()
                {
                    {"RG", "rg"},
                    {"testTag", "1"},
                },
                // need to change model to be public setter
                ExcludeDisks = new List<ApiEntityReference> { diskToExclude },
            };

            RestorePoint createOrUpdateResponse = null;
            try
            {
                createOrUpdateResponse = m_CrpClient.RestorePoints.CreateOrUpdate(
                    resourceGroupName,
                    inputRPCName,
                    inputRPName,
                    inputRP);
            }
            catch (CloudException ex)
            {
                Assert.True(ex.Response.StatusCode == HttpStatusCode.BadRequest);
            }
        }
        private void VerifyRPCCreation(string sourceVMId)
        {
            var inputRPCName = ComputeManagementTestUtilities.GenerateName("rpc1ClientTest");
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
                    resourceGroupName,
                    inputRPCName,
                    inputRPC);
            }
            catch (CloudException ex)
            {
                Assert.True(ex.Response.StatusCode == HttpStatusCode.BadRequest,
                    "Expect failure when source id is not valid");
            }

            // now successfully create RPC id by passing in source VM id
            inputRPC.Source.Id = sourceVMId;
            createOrUpdateResponse = m_CrpClient.RestorePointCollections.CreateOrUpdate(
                    resourceGroupName,
                    inputRPCName,
                    inputRPC);
        }
    }
}
