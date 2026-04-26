// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Compute;
using Azure.ResourceManager.ComputeSchedule.Models;
using Azure.ResourceManager.Resources;
using NUnit.Framework;

namespace Azure.ResourceManager.ComputeSchedule.Tests.Scenario
{
    public class ComputescheduleOperationsTests : ComputeScheduleManagementTestBase
    {
        private static readonly int s_cancelOperationsDelayedDays = 5;
        public ComputescheduleOperationsTests(bool isAsync)
            : base(isAsync)//, RecordedTestMode.Record)
        {
        }

        private static readonly int s_submitOperationsDelayedSeconds = 1;
        private static readonly List<ScheduledActionOperationState> s_terminalList = [ScheduledActionOperationState.Succeeded, ScheduledActionOperationState.Failed, ScheduledActionOperationState.Cancelled];

        [TestCase, Order(1)]
        [RecordedTest]
        public async Task TestSubmitStartOperations()
        {
            int vmCount = 1;
            string vmName = Recording.GenerateAssetName("substart");
            List<VirtualMachineResource> allVms = await GenerateMultipleVirtualMachines(vmName, DefaultResourceGroupResource, vmCount);

            var allResourceids = allVms.Select(vm => vm.Id).ToList();
            Console.WriteLine($"Submitting start operations for {vmCount} VMs");
            DateTimeOffset dateTimeOffset = Recording.Now.AddSeconds(s_submitOperationsDelayedSeconds);

            UserRequestSchedule schedule = new(ScheduledActionDeadlineType.InitiateAt)
            {
                Timezone = "UTC",
                Deadline = dateTimeOffset
            };
            UserRequestResources resources = new(allResourceids);
            ScheduledActionExecutionParameterDetail executionParameters = new() { RetryPolicy = new UserRequestRetryPolicy() { RetryCount = 3, RetryWindowInMinutes = 30 } };

            var submitStartRequest = new SubmitStartContent(schedule, executionParameters, resources, Recording.Random.NewGuid().ToString());

            // Act
            // SubmitStart
            var subId = DefaultSubscription.Id.Name;
            var regionalClient = GetRegionalArmClient("https://eastus2euap.management.azure.com");
            StartResourceOperationResult submitStartResult = await TestSubmitStartAsync(Location, submitStartRequest, subId, regionalClient);

            HashSet<string> validOperationIds = ExcludeResourcesNotProcessed(submitStartResult.Results);

            if (validOperationIds.Count > 0)
            {
                GetOperationStatusResult getOperationStatus = PollOperationStatus(vmCount).ExecuteAsync(async () =>
                {
                    var getOpsStatusReq = new GetOperationStatusContent(validOperationIds, Recording.Random.NewGuid().ToString());
                    return await TestGetOpsStatusAsync(Location, getOpsStatusReq, subId, regionalClient);
                }).GetAwaiter().GetResult();

                Assert.NotNull(submitStartResult);
                Assert.NotNull(getOperationStatus);

                foreach (ResourceOperationResult result in getOperationStatus.Results)
                {
                    Assert.Contains(result.Operation.State, s_terminalList);
                    Assert.AreEqual(result.Operation.SubscriptionId, subId);
                }
            }
            else
            {
                Assert.Pass("No operations to process.");
            }
        }

        [TestCase, Order(2)]
        [RecordedTest]
        public async Task TestSubmitDeallocateOperations()
        {
            int vmCount = 1;
            string vmName = Recording.GenerateAssetName("subdeall");
            List<VirtualMachineResource> allVms = GenerateMultipleVirtualMachines(vmName, DefaultResourceGroupResource, vmCount).Result;

            var allResourceids = allVms.Select(vm => vm.Id).ToList();

            UserRequestSchedule schedule = new(ScheduledActionDeadlineType.InitiateAt)
            {
                Timezone = "UTC",
                Deadline = Recording.Now.AddSeconds(s_submitOperationsDelayedSeconds)
            };

            UserRequestResources resources = new(allResourceids);
            ScheduledActionExecutionParameterDetail executionParameters = new() { RetryPolicy = new UserRequestRetryPolicy() { RetryCount = 3, RetryWindowInMinutes = 30 } };

            var submitDeallocateRequest = new SubmitDeallocateContent(schedule, executionParameters, resources, Recording.Random.NewGuid().ToString());

            // Act
            // SubmitDeallocate
            var subId = DefaultSubscription.Id.Name;
            var regionalClient = GetRegionalArmClient("https://eastus2euap.management.azure.com");
            DeallocateResourceOperationResult submitDeallocateResult = await TestSubmitDeallocateAsync(Location, submitDeallocateRequest, subId, regionalClient);

            HashSet<string> validOperationIds = ExcludeResourcesNotProcessed(submitDeallocateResult.Results);

            if (validOperationIds.Count > 0)
            {
                // Put polling logic here: GetOperationsStatus
                GetOperationStatusResult getOperationStatus = PollOperationStatus(vmCount).ExecuteAsync(async () =>
                {
                    // GetOps status
                    var allOperationIds = submitDeallocateResult.Results.Select(result => result.Operation?.OperationId).Where(operationId => !string.IsNullOrEmpty(operationId)).ToList();
                    var getOpsStatusReq = new GetOperationStatusContent(allOperationIds, Recording.Random.NewGuid().ToString());
                    return await TestGetOpsStatusAsync(Location, getOpsStatusReq, subId, regionalClient);
                }).GetAwaiter().GetResult();

                // Assert results are returned
                Assert.NotNull(submitDeallocateResult);
                Assert.NotNull(getOperationStatus);

                foreach (ResourceOperationResult result in getOperationStatus.Results)
                {
                    Assert.Contains(result.Operation.State, s_terminalList);
                    Assert.AreEqual(result.Operation.SubscriptionId, subId);
                }
            }
            else
            {
                Assert.Pass("No operations to process.");
            }
        }

        [TestCase, Order(3)]
        [RecordedTest]
        public async Task TestSubmitHibernateOperations()
        {
            int vmCount = 1;
            string vmName = Recording.GenerateAssetName("subhib");
            List<VirtualMachineResource> allVms = GenerateMultipleVirtualMachines(vmName, DefaultResourceGroupResource, vmCount).Result;

            var allResourceids = allVms.Select(vm => vm.Id).ToList();

            UserRequestSchedule schedule = new(ScheduledActionDeadlineType.InitiateAt)
            {
                Timezone = "UTC",
                Deadline = Recording.Now.AddSeconds(s_submitOperationsDelayedSeconds)
            };
            UserRequestResources resources = new(allResourceids);
            ScheduledActionExecutionParameterDetail executionParameters = new() { RetryPolicy = new UserRequestRetryPolicy() { RetryCount = 3, RetryWindowInMinutes = 30 } };

            var submitHibernateRequest = new SubmitHibernateContent(schedule, executionParameters, resources, Recording.Random.NewGuid().ToString());

            // Act
            // Submit Hibernate
            var subId = DefaultSubscription.Id.Name;
            var regionalClient = GetRegionalArmClient("https://eastus2euap.management.azure.com");
            HibernateResourceOperationResult submitHibernateResult = await TestSubmitHibernateAsync(Location, submitHibernateRequest, subId, regionalClient);

            HashSet<string> validOperationIds = ExcludeResourcesNotProcessed(submitHibernateResult.Results);

            if (validOperationIds.Count > 0)
            {
                // Put polling logic here: GetOperationsStatus
                GetOperationStatusResult getOperationStatus = PollOperationStatus(vmCount).ExecuteAsync(async () =>
                {
                    // GetOps status
                    var allOperationIds = submitHibernateResult.Results.Select(result => result.Operation?.OperationId).Where(operationId => !string.IsNullOrEmpty(operationId)).ToList();
                    var getOpsStatusReq = new GetOperationStatusContent(allOperationIds, Recording.Random.NewGuid().ToString());
                    return await TestGetOpsStatusAsync(Location, getOpsStatusReq, subId, regionalClient);
                }).GetAwaiter().GetResult();

                // Assert results are returned
                Assert.NotNull(submitHibernateResult);
                Assert.NotNull(getOperationStatus);

                foreach (ResourceOperationResult result in getOperationStatus.Results)
                {
                    Assert.Contains(result.Operation.State, s_terminalList);
                    Assert.AreEqual(result.Operation.SubscriptionId, subId);
                }
            }
            else
            {
                Assert.Pass("No operations to process.");
            }
        }

        [TestCase, Order(4)]
        [RecordedTest]
        public async Task TestExecuteHibernateOperations()
        {
            int vmCount = 1;
            string vmName = Recording.GenerateAssetName("exeHib");
            List<VirtualMachineResource> allVms = GenerateMultipleVirtualMachines(vmName, DefaultResourceGroupResource, vmCount).Result;

            var allResourceids = allVms.Select(vm => vm.Id).ToList();

            Models.UserRequestResources resources = new(allResourceids);
            ScheduledActionExecutionParameterDetail executionParameters = new() { RetryPolicy = new UserRequestRetryPolicy() { RetryCount = 3, RetryWindowInMinutes = 30 } };

            var executeHibernateRequest = new ExecuteHibernateContent(executionParameters, resources, Recording.Random.NewGuid().ToString());

            // Act
            // Execute Hibernate
            var subId = DefaultSubscription.Id.Name;
            var regionalClient = GetRegionalArmClient("https://eastus2euap.management.azure.com");
            HibernateResourceOperationResult executeHibernateResult = await TestExecuteHibernateAsync(Location, executeHibernateRequest, subId, regionalClient);
            HashSet<string> validOperationIds = ExcludeResourcesNotProcessed(executeHibernateResult.Results);

            if (validOperationIds.Count > 0)
            {
                // Put polling logic here: GetOperationsStatus
                GetOperationStatusResult getOperationStatus = PollOperationStatus(vmCount).ExecuteAsync(async () =>
                {
                    // GetOps status
                    var allOperationIds = executeHibernateResult.Results.Select(result => result.Operation?.OperationId).Where(operationId => !string.IsNullOrEmpty(operationId)).ToList();
                    var getOpsStatusReq = new GetOperationStatusContent(allOperationIds, Recording.Random.NewGuid().ToString());
                    return await TestGetOpsStatusAsync(Location, getOpsStatusReq, subId, regionalClient);
                }).GetAwaiter().GetResult();

                // Assert results are returned
                Assert.NotNull(executeHibernateResult);
                Assert.NotNull(getOperationStatus);

                foreach (ResourceOperationResult result in getOperationStatus.Results)
                {
                    Assert.Contains(result.Operation.State, s_terminalList);
                    Assert.AreEqual(result.Operation.SubscriptionId, subId);
                }
            }
            else
            {
                Assert.Pass("No operations to process.");
            }
        }

        [TestCase, Order(5)]
        [RecordedTest]
        public async Task TestExecuteDeallocateOperations()
        {
            int vmCount = 1;
            string vmName = Recording.GenerateAssetName("exeDeall");
            List<VirtualMachineResource> allVms = GenerateMultipleVirtualMachines(vmName, DefaultResourceGroupResource, vmCount).Result;

            var allResourceids = allVms.Select(vm => vm.Id).ToList();

            Models.UserRequestResources resources = new(allResourceids);
            ScheduledActionExecutionParameterDetail executionParameters = new() { RetryPolicy = new UserRequestRetryPolicy() { RetryCount = 3, RetryWindowInMinutes = 30 } };

            var executeDeallocateRequest = new ExecuteDeallocateContent(executionParameters, resources, Recording.Random.NewGuid().ToString());

            // Act
            // Execute Deallocate
            var subId = DefaultSubscription.Id.Name;
            var regionalClient = GetRegionalArmClient("https://eastus2euap.management.azure.com");
            DeallocateResourceOperationResult executeDeallocateResult = await TestExecuteDeallocateAsync(Location, executeDeallocateRequest, subId, regionalClient);
            HashSet<string> validOperationIds = ExcludeResourcesNotProcessed(executeDeallocateResult.Results);

            if (validOperationIds.Count > 0)
            {
                // Put polling logic here: GetOperationsStatus
                GetOperationStatusResult getOperationStatus = PollOperationStatus(vmCount).ExecuteAsync(async () =>
                {
                    // GetOps status
                    var allOperationIds = executeDeallocateResult.Results.Select(result => result.Operation?.OperationId).Where(operationId => !string.IsNullOrEmpty(operationId)).ToList();
                    var getOpsStatusReq = new GetOperationStatusContent(allOperationIds, Recording.Random.NewGuid().ToString());
                    return await TestGetOpsStatusAsync(Location, getOpsStatusReq, subId, regionalClient);
                }).GetAwaiter().GetResult();

                // Assert results are returned
                Assert.NotNull(executeDeallocateResult);
                Assert.NotNull(getOperationStatus);

                foreach (ResourceOperationResult result in getOperationStatus.Results)
                {
                    Assert.Contains(result.Operation.State, s_terminalList);
                    Assert.AreEqual(result.Operation.SubscriptionId, subId);
                }
            }
            else
            {
                Assert.Pass("No operations to process.");
            }
        }

        [TestCase, Order(6)]
        [RecordedTest]
        public async Task TestExecuteStartOperations()
        {
            int vmCount = 1;
            string vmName = Recording.GenerateAssetName("exesta");
            List<VirtualMachineResource> allVms = GenerateMultipleVirtualMachines(vmName, DefaultResourceGroupResource, vmCount).Result;

            var allResourceids = allVms.Select(vm => vm.Id).ToList();

            Models.UserRequestResources resources = new(allResourceids);
            ScheduledActionExecutionParameterDetail executionParameters = new() { RetryPolicy = new UserRequestRetryPolicy() { RetryCount = 3, RetryWindowInMinutes = 30 } };

            var executeStartRequest = new ExecuteStartContent(executionParameters, resources, Recording.Random.NewGuid().ToString());

            // Act
            // Execute Start
            var subId = DefaultSubscription.Id.Name;
            var regionalClient = GetRegionalArmClient("https://eastus2euap.management.azure.com");
            StartResourceOperationResult executeStartResult = await TestExecuteStartAsync(Location, executeStartRequest, subId, regionalClient);
            HashSet<string> validOperationIds = ExcludeResourcesNotProcessed(executeStartResult.Results);

            if (validOperationIds.Count > 0)
            {
                // Put polling logic here: GetOperationsStatus
                GetOperationStatusResult getOperationStatus = PollOperationStatus(vmCount).ExecuteAsync(async () =>
                {
                    // GetOps status
                    var allOperationIds = executeStartResult.Results.Select(result => result.Operation?.OperationId).Where(operationId => !string.IsNullOrEmpty(operationId)).ToList();
                    var getOpsStatusReq = new GetOperationStatusContent(allOperationIds, Recording.Random.NewGuid().ToString());
                    return await TestGetOpsStatusAsync(Location, getOpsStatusReq, subId, regionalClient);
                }).GetAwaiter().GetResult();

                // Assert results are returned
                Assert.NotNull(executeStartResult);
                Assert.NotNull(getOperationStatus);

                foreach (ResourceOperationResult result in getOperationStatus.Results)
                {
                    Assert.Contains(result.Operation.State, s_terminalList);
                    Assert.AreEqual(result.Operation.SubscriptionId, subId);
                }
            }
            else
            {
                Assert.Pass("No operations to process.");
            }
        }

        [TestCase, Order(7)]
        [RecordedTest]
        public async Task TestCancelScheduledOperations()
        {
            int vmCount = 1;
            string vmName = Recording.GenerateAssetName("cancops");

            List<VirtualMachineResource> allVms = GenerateMultipleVirtualMachines(vmName, DefaultResourceGroupResource, vmCount).Result;

            var allResourceids = allVms.Select(vm => vm.Id).ToList();

            UserRequestSchedule schedule = new(ScheduledActionDeadlineType.InitiateAt)
            {
                Timezone = "UTC",
                Deadline = Recording.Now.AddDays(s_cancelOperationsDelayedDays)
            };
            Models.UserRequestResources resources = new(allResourceids);
            ScheduledActionExecutionParameterDetail executionParameters = new() { RetryPolicy = new UserRequestRetryPolicy() { RetryCount = 3, RetryWindowInMinutes = 30 } };

            var submitDeallocateRequest = new SubmitDeallocateContent(schedule, executionParameters, resources, Recording.Random.NewGuid().ToString());

            // Act
            // SubmitDeallocate: UserRequestSchedule a deallocate op in the future
            var subId = DefaultSubscription.Id.Name;
            var regionalClient = GetRegionalArmClient("https://eastus2euap.management.azure.com");
            DeallocateResourceOperationResult submitDeallocateResult = await TestSubmitDeallocateAsync(Location, submitDeallocateRequest, subId, regionalClient);

            HashSet<string> validOperationIds = ExcludeResourcesNotProcessed(submitDeallocateResult.Results);

            if (validOperationIds.Count > 0)
            {
                // Cancel the scheduled operation
                CancelOperationsContent cancelOperationsContent = new(validOperationIds, Recording.Random.NewGuid().ToString());
                CancelOperationsResult canceloperationsResponse = await TestCancelOpsAsync(Location, cancelOperationsContent, subId, regionalClient);

                // Put polling logic here: GetOperationsStatus
                GetOperationStatusResult getOperationStatus = PollOperationStatus(vmCount).ExecuteAsync(async () =>
                {
                    // GetOps status
                    var getOpsStatusReq = new GetOperationStatusContent(validOperationIds, Recording.Random.NewGuid().ToString());
                    return await TestGetOpsStatusAsync(Location, getOpsStatusReq, subId, regionalClient);
                }).GetAwaiter().GetResult();

                // Assert results are returned
                Assert.NotNull(submitDeallocateResult);
                Assert.NotNull(canceloperationsResponse);
                Assert.NotNull(getOperationStatus);

                foreach (ResourceOperationResult result in getOperationStatus.Results)
                {
                    Assert.AreEqual(result.Operation.State, ScheduledActionOperationState.Cancelled);
                    Assert.NotNull(result.Operation.ResourceOperationError);
                    Assert.AreEqual(result.Operation.ResourceOperationError.ErrorCode, "OperationCancelledByUser");
                }
            }
            else
            {
                Assert.Pass("No operations to process.");
            }
        }

        [TestCase, Order(8)]
        [RecordedTest]
        public async Task TestGetOperationsErrors()
        {
            int vmCount = 1;
            string vmName = Recording.GenerateAssetName("opserr");
            List<VirtualMachineResource> allVms = GenerateMultipleVirtualMachines(vmName, DefaultResourceGroupResource, vmCount).Result;

            var allResourceids = allVms.Select(vm => vm.Id).ToList();

            Models.UserRequestResources resources = new(allResourceids);
            ScheduledActionExecutionParameterDetail executionParameters = new() { RetryPolicy = new UserRequestRetryPolicy() { RetryCount = 3, RetryWindowInMinutes = 30 } };

            var executeDeallocateRequest = new ExecuteDeallocateContent(executionParameters, resources, Recording.Random.NewGuid().ToString());

            // Act
            // ExecuteDeallocate
            var subId = DefaultSubscription.Id.Name;
            var regionalClient = GetRegionalArmClient("https://eastus2euap.management.azure.com");
            DeallocateResourceOperationResult executeDeallocateResult = await TestExecuteDeallocateAsync(Location, executeDeallocateRequest, subId, regionalClient);

            HashSet<string> validOperationIds = ExcludeResourcesNotProcessed(executeDeallocateResult.Results);

            if (validOperationIds.Count > 0)
            {
                // Polling
                GetOperationStatusResult getOperationStatus = PollOperationStatus(vmCount).ExecuteAsync(async () =>
                {
                    // GetOps status
                    var getOpsStatusReq = new GetOperationStatusContent(validOperationIds, Recording.Random.NewGuid().ToString());
                    return await TestGetOpsStatusAsync(Location, getOpsStatusReq, subId, regionalClient);
                }).GetAwaiter().GetResult();

                // Get operation errors if any
                GetOperationErrorsContent getOperationsErrorsRequest = new(validOperationIds);
                GetOperationErrorsResult getOperationsErrorsResponse = await TestGetOperationErrorsAsync(Location, getOperationsErrorsRequest, subId, regionalClient);

                // Assert results are returned
                Assert.NotNull(executeDeallocateResult);
                Assert.NotNull(getOperationStatus);
                Assert.NotNull(getOperationsErrorsResponse);

                foreach (ResourceOperationResult result in getOperationStatus.Results)
                {
                    Assert.Contains(result.Operation.State, s_terminalList);
                    Assert.AreEqual(result.Operation.SubscriptionId, subId);
                }
            }
            else
            {
                Assert.Pass("No operations to process.");
            }
        }

        [TestCase, Order(9)]
        [RecordedTest]
        public async Task TestVirtualMachinesExecuteCreateOperations()
        {
            var subId = DefaultSubscription.Id.Name;
            var rgName = DefaultResourceGroupResource.Id.Name;
            AzureLocation testLocation = TestEnvironment.Location;

            ScheduledActionExecutionParameterDetail executionParameters = new()
            {
                RetryPolicy = new UserRequestRetryPolicy() { RetryCount = 1 }
            };

            var resourceConfigParameters = new ResourceProvisionPayload(1)
            {
                ResourcePrefix = "testcreate",
                VirtualMachineBaseProfile = new BulkVMConfiguration
                {
                    ResourceGroupName = rgName,
                    ComputeApiVersion = "2023-09-01",
                    Zones = { "1", "2", "3" },
                    Properties = new BulkActionVMProperties
                    {
                        HardwareProfile = new HardwareProfile { VmSize = "Standard_D2ads_v5" },
                        StorageProfile = new StorageProfile
                        {
                            ImageReference = new ImageReference
                            {
                                Publisher = "MicrosoftWindowsServer",
                                Offer = "WindowsServer",
                                Sku = "2022-datacenter-azure-edition",
                                Version = "latest",
                            },
                            OSDisk = new OSDisk(DiskCreateOptionTypes.FromImage)
                            {
                                OSType = OperatingSystemTypes.Windows,
                                Caching = CachingTypes.ReadWrite,
                                ManagedDisk = new ComputeScheduleManagedDiskConfig { StorageAccountType = StorageAccountTypes.StandardLRS },
                                DeleteOption = DiskDeleteOptionTypes.Detach,
                                DiskSizeGB = 127,
                            },
                            DiskControllerType = DiskControllerTypes.SCSI,
                        },
                        OsProfile = new OSProfile
                        {
                            ComputerName = "testcreatevm",
                            AdminUsername = "testadmin",
                            AdminPassword = "TestPassword123!",
                            WindowsConfiguration = new WindowsConfiguration
                            {
                                ProvisionVmAgent = true,
                                IsAutomaticUpdatesEnabled = true,
                            },
                        },
                    },
                },
                VirtualMachineOverrides =
                {
                    new BulkVMConfiguration
                    {
                        Name = "testcreatevm0",
                        Properties = new BulkActionVMProperties
                        {
                            HardwareProfile = new HardwareProfile { VmSize = "Standard_D2ads_v5" },
                        },
                    },
                },
            };

            var executeCreateRequest = new ExecuteCreateContent(resourceConfigParameters, executionParameters)
            {
                CorrelationId = Recording.Random.NewGuid().ToString(),
            };

            // Act - Use regional ARM client to target the EUAP endpoint where the API version is deployed
            var regionalClient = GetRegionalArmClient("https://eastus2euap.management.azure.com");
            CreateResourceOperationResult executeCreateResult = await TestExecuteCreateAsync(testLocation, executeCreateRequest, subId, regionalClient);

            // Assert - ExecuteCreate is an immediate operation; results are returned directly
            Assert.NotNull(executeCreateResult);
            Assert.NotNull(executeCreateResult.Results);
            Assert.IsNotEmpty(executeCreateResult.Results);
        }

        [TestCase, Order(10)]
        [RecordedTest]
        public async Task TestVirtualMachinesExecuteCreateFlexOperations()
        {
            var subId = DefaultSubscription.Id.Name;
            var rgName = DefaultResourceGroupResource.Id.Name;
            AzureLocation testLocation = TestEnvironment.Location;

            // Create VNet to get a subnet ID for inline NIC configuration
            string dependencyName = Recording.GenerateAssetName("testflex");
            GenericResource vnet = await CreateVirtualNetwork(DefaultResourceGroupResource, dependencyName);
            ResourceIdentifier subnetId = GetSubnetId(vnet);

            ScheduledActionExecutionParameterDetail executionParameters = new()
            {
                RetryPolicy = new UserRequestRetryPolicy() { RetryCount = 1 }
            };

            var flexProperties = new ComputeScheduleFlexProperties(
                new[]
                {
                    new ComputeScheduleVmSizeProfile("Standard_D2ads_v5", 0),
                    new ComputeScheduleVmSizeProfile("Standard_E2ads_v5", 1),
                    new ComputeScheduleVmSizeProfile("Standard_D2ds_v5", 2),
                },
                ComputeScheduleOSType.Windows,
                new ComputeSchedulePriorityProfile
                {
                    Type = ComputeSchedulePriorityType.Regular,
                    AllocationStrategy = ComputeScheduleAllocationStrategy.Prioritized,
                });

            var resourceConfigParameters = new ResourceProvisionFlexPayload(1, flexProperties)
            {
                ResourcePrefix = "testflex",
                VirtualMachineBaseProfile = new BulkVMConfiguration
                {
                    ResourceGroupName = rgName,
                    ComputeApiVersion = "2023-09-01",
                    Zones = { "1", "2", "3" },
                    Properties = new BulkActionVMProperties
                    {
                        HardwareProfile = new HardwareProfile { VmSize = "Standard_D2ads_v5" },
                        StorageProfile = new StorageProfile
                        {
                            ImageReference = new ImageReference
                            {
                                Publisher = "MicrosoftWindowsServer",
                                Offer = "WindowsServer",
                                Sku = "2022-datacenter-azure-edition",
                                Version = "latest",
                            },
                            OSDisk = new OSDisk(DiskCreateOptionTypes.FromImage)
                            {
                                OSType = OperatingSystemTypes.Windows,
                                Caching = CachingTypes.ReadWrite,
                                ManagedDisk = new ComputeScheduleManagedDiskConfig { StorageAccountType = StorageAccountTypes.StandardLRS },
                                DeleteOption = DiskDeleteOptionTypes.Detach,
                                DiskSizeGB = 127,
                            },
                            DiskControllerType = DiskControllerTypes.SCSI,
                        },
                        NetworkProfile = new NetworkProfile
                        {
                            NetworkApiVersion = new NetworkApiVersion("2022-07-01"),
                            NetworkInterfaceConfigurations =
                            {
                                new VirtualMachineNetworkInterfaceConfiguration("testflexnic")
                                {
                                    Properties = new VirtualMachineNetworkInterfaceConfigurationProperties(
                                        new[]
                                        {
                                            new VirtualMachineNetworkInterfaceIPConfiguration("testflexnic")
                                            {
                                                Properties = new VirtualMachineNetworkInterfaceIPConfigurationProperties
                                                {
                                                    SubnetId = subnetId,
                                                    Primary = true,
                                                },
                                            },
                                        })
                                    {
                                        Primary = true,
                                        EnableIPForwarding = true,
                                    },
                                },
                            },
                        },
                    },
                },
                VirtualMachineOverrides =
                {
                    new BulkVMConfiguration
                    {
                        Name = "testflexvm0",
                        Properties = new BulkActionVMProperties
                        {
                            HardwareProfile = new HardwareProfile { VmSize = "Standard_D2ads_v5" },
                            OsProfile = new OSProfile
                            {
                                ComputerName = "testflexvm",
                                AdminUsername = "testadmin",
                                AdminPassword = "TestPassword123!",
                                WindowsConfiguration = new WindowsConfiguration
                                {
                                    ProvisionVmAgent = true,
                                    IsAutomaticUpdatesEnabled = true,
                                },
                            },
                        },
                    },
                },
            };

            var executeCreateFlexRequest = new ExecuteCreateFlexContent(resourceConfigParameters, executionParameters)
            {
                CorrelationId = Recording.Random.NewGuid().ToString(),
            };

            // Act - Use regional ARM client to target the EUAP endpoint where the API version is deployed
            var regionalClient = GetRegionalArmClient("https://eastus2euap.management.azure.com");
            CreateFlexResourceOperationResult executeCreateFlexResult = await TestExecuteCreateFlexAsync(testLocation, executeCreateFlexRequest, subId, regionalClient);

            // Assert - ExecuteCreateFlex is an immediate operation; results are returned directly
            Assert.NotNull(executeCreateFlexResult);
            Assert.NotNull(executeCreateFlexResult.Results);
            Assert.IsNotEmpty(executeCreateFlexResult.Results);
        }
    }
}
