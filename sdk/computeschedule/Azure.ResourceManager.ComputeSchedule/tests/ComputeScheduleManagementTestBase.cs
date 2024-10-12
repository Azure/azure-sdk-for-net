// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.Identity;
using Azure.ResourceManager.Compute;
using Azure.ResourceManager.ComputeSchedule.Models;
using Azure.ResourceManager.ComputeSchedule.Tests.Helpers;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.TestFramework;
using NUnit.Framework;
using Polly;
using Polly.Contrib.WaitAndRetry;
using OperationState = Azure.ResourceManager.ComputeSchedule.Models.ScheduledActionOperationState;

namespace Azure.ResourceManager.ComputeSchedule.Tests
{
    public class ComputeScheduleManagementTestBase : ManagementRecordedTestBase<ComputeScheduleManagementTestEnvironment>
    {
        protected ArmClient Client { get; private set; }
        protected SubscriptionResource DefaultSubscription { get; private set; }
        protected AzureLocation Location { get; private set; }
        protected GenericResourceCollection _genericResourceCollection;
        protected ResourceGroupResource DefaultResourceGroupResource;

        protected ComputeScheduleManagementTestBase(bool isAsync)
            : base(isAsync)
        {
        }

        protected ComputeScheduleManagementTestBase(bool isAsync, RecordedTestMode mode)
        : base(isAsync, mode)
        {
        }

        [SetUp]
        public async Task CreateCommonClient()
        {
            if (Mode == RecordedTestMode.Record || Mode == RecordedTestMode.Playback)
            {
                Client = GetArmClient();
                SubscriptionResource subIdRes = await Client.GetDefaultSubscriptionAsync();
                DefaultSubscription = Client.GetSubscriptionResource(subIdRes.Id);
                DefaultResourceGroupResource = await DefaultSubscription.GetResourceGroupAsync(TestEnvironment.ResourceGroup);
                Location = DefaultResourceGroupResource.Data.Location;
                _genericResourceCollection = Client.GetGenericResources();
            }
        }

        protected async Task<ResourceGroupResource> CreateResourceGroupAsync(string rgName)
        {
            var rgOp = await DefaultSubscription.GetResourceGroups().CreateOrUpdateAsync(
                WaitUntil.Completed,
                rgName,
                new ResourceGroupData(Location)
                {
                    Tags =
                    {
                        { "computescheduletest", "test" }
                    }
                });
            return rgOp.Value;
        }

        protected ResourceIdentifier GetSubnetId(GenericResource vnet)
        {
            var properties = vnet.Data.Properties.ToObjectFromJson() as Dictionary<string, object>;
            var subnets = properties["subnets"] as IEnumerable<object>;
            var subnet = subnets.First() as IDictionary<string, object>;
            return new ResourceIdentifier(subnet["id"] as string);
        }

        private async Task<GenericResource> CreateNetworkInterface(ResourceIdentifier subnetId, ResourceGroupResource rg, string dependencyName)
        {
            var nicName = Recording.GenerateAssetName($"{dependencyName}-nic-");
            ResourceIdentifier nicId = new ResourceIdentifier($"{rg.Id}/providers/Microsoft.Network/networkInterfaces/{nicName}");
            var input = new GenericResourceData(Location)
            {
                Properties = BinaryData.FromObjectAsJson(new Dictionary<string, object>()
                {
                    { "ipConfigurations", new List<object>()
                        {
                            new Dictionary<string, object>()
                            {
                                { "name", "internal" },
                                { "properties", new Dictionary<string, object>()
                                    {
                                        { "subnet", new Dictionary<string, object>() { { "id", subnetId.ToString() } } }
                                    }
                                }
                            }
                        }
                    }
                })
            };
            var operation = await _genericResourceCollection.CreateOrUpdateAsync(WaitUntil.Completed, nicId, input);
            return operation.Value;
        }

        protected async Task<GenericResource> CreateVirtualNetwork(ResourceGroupResource rg, string dependencyName)
        {
            var vnetName = Recording.GenerateAssetName($"{dependencyName}-vnet-");
            var subnetName = Recording.GenerateAssetName($"{dependencyName}-subnet-");
            ResourceIdentifier vnetId = new ResourceIdentifier($"{rg.Id}/providers/Microsoft.Network/virtualNetworks/{vnetName}");
            var addressSpaces = new Dictionary<string, object>()
            {
                { "addressPrefixes", new List<string>() { "10.0.0.0/16" } }
            };
            var subnet = new Dictionary<string, object>()
            {
                { "name", subnetName },
                { "properties", new Dictionary<string, object>()
                {
                    { "addressPrefix", "10.0.2.0/24" }
                } }
            };
            var subnets = new List<object>() { subnet };
            var input = new GenericResourceData(Location)
            {
                Properties = BinaryData.FromObjectAsJson(new Dictionary<string, object>()
                {
                    { "addressSpace", addressSpaces },
                    { "subnets", subnets }
                })
            };
            var operation = await _genericResourceCollection.CreateOrUpdateAsync(WaitUntil.Completed, vnetId, input);
            return operation.Value;
        }

        /// <summary>
        /// Dependencies for creating a virtual machine
        /// </summary>
        /// <returns></returns>
        protected async Task<GenericResource> CreateBasicDependenciesOfVirtualMachineCreationAsync(ResourceGroupResource rg, string dependencyName)
        {
            GenericResource vnet = await CreateVirtualNetwork(rg, dependencyName);
            GenericResource nic = await CreateNetworkInterface(GetSubnetId(vnet), rg, dependencyName);
            return nic;
        }

        /// <summary>
        /// Create a virtual machine in a resource group
        /// </summary>
        /// <param name="vmName"></param>
        /// <param name="resourceGroup"></param>
        /// <returns></returns>
        protected async Task<VirtualMachineResource> CreateVirtualMachineAsync(string vmName, string vmnamesuffix, ResourceGroupResource resourceGroup)
        {
            var computerName = $"{vmName}{vmnamesuffix}";
            VirtualMachineCollection vmCollection = resourceGroup.GetVirtualMachines();
            GenericResource nic = await CreateBasicDependenciesOfVirtualMachineCreationAsync(resourceGroup, computerName);
            VirtualMachineData input = ResourceUtils.GetBasicWindowsVirtualMachineData(Location, computerName, nic.Id);
            ArmOperation<VirtualMachineResource> lro = await vmCollection.CreateOrUpdateAsync(WaitUntil.Completed, computerName, input);
            return lro.Value;
        }

        protected async Task<List<VirtualMachineResource>> GenerateMultipleVirtualMachines(string vmName, ResourceGroupResource resourceGroup, int vmCount)
        {
            var item = new List<VirtualMachineResource>();
            item.Clear();

            for (int i = 0; i < vmCount; i++)
            {
                VirtualMachineResource vm = await CreateVirtualMachineAsync(vmName, $"{i}", resourceGroup);
                item.Add(vm);
            }

            return item;
        }

        protected static SubscriptionResource GenerateSubscriptionResource(ArmClient client, string subid)
        {
            ResourceIdentifier subscriptionResourceId = SubscriptionResource.CreateResourceIdentifier(subid);
            return client.GetSubscriptionResource(subscriptionResourceId);
        }

        #region Polling operation to get status of operations
        protected Polly.Retry.AsyncRetryPolicy<GetOperationStatusResult> PollOperationStatus(int vmCount)
        {
            int retryCount = 7;
            var maxDelay = TimeSpan.FromSeconds(20);

            IEnumerable<TimeSpan> delay = Backoff.ExponentialBackoff(initialDelay: Recording.Mode != RecordedTestMode.Playback ? TimeSpan.FromSeconds(5) : TimeSpan.FromMilliseconds(10), retryCount: retryCount).Select(s => TimeSpan.FromTicks(Math.Min(s.Ticks, maxDelay.Ticks)));

            return Policy
                .HandleResult<GetOperationStatusResult>(r => ShouldRetryPolling(r, vmCount).GetAwaiter().GetResult())
                .WaitAndRetryAsync(delay);
        }

#pragma warning disable IDE0044 // Add readonly modifier
        private Dictionary<string, OperationState> _completedOperations = new();
#pragma warning restore IDE0044 // Add readonly modifier

        private Task<bool> ShouldRetryPolling(GetOperationStatusResult response, int totalVmsCount)
        {
            var shouldRetry = true;
            _completedOperations.Clear();

            IReadOnlyList<ResourceOperationResult> responseResults = response.Results;

            foreach (ResourceOperationResult item in responseResults)
            {
                if (item.ErrorCode != null)
                {
                    _completedOperations.Add(item.Operation.OperationId, item.Operation.State);
                }
                else
                {
                    if (item.Operation.State == OperationState.Succeeded || item.Operation.State == OperationState.Failed || item.Operation.State == OperationState.Cancelled)
                    {
                        _completedOperations.Add(item.Operation.OperationId, item.Operation.State);
                    }
                }
            }

            if (_completedOperations.Count == totalVmsCount)
            {
                shouldRetry = false;
            }
            return Task.FromResult(shouldRetry);
        }
        #endregion

        #region SA Operations

        protected static async Task<StartResourceOperationResult> TestSubmitStartAsync(string location, SubmitStartContent submitStartRequest, string subid, ArmClient client)
        {
            SubscriptionResource subscriptionResource = GenerateSubscriptionResource(client, subid);
            SubmitStartContent content = submitStartRequest;
            StartResourceOperationResult result;

            try
            {
                result = await subscriptionResource.SubmitVirtualMachineStartAsync(location, content);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.InnerException?.Message);
                throw;
            }
            return result;
        }

        protected static async Task<DeallocateResourceOperationResult> TestSubmitDeallocateAsync(string location, SubmitDeallocateContent submitStartRequest, string subid, ArmClient client)
        {
            SubscriptionResource subscriptionResource = GenerateSubscriptionResource(client, subid);
            SubmitDeallocateContent content = submitStartRequest;
            DeallocateResourceOperationResult result;

            try
            {
                result = await subscriptionResource.SubmitVirtualMachineDeallocateAsync(location, content);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.InnerException?.Message);
                throw;
            }
            return result;
        }

        protected static async Task<HibernateResourceOperationResult> TestSubmitHibernateAsync(string location, SubmitHibernateContent submitStartRequest, string subid, ArmClient client)
        {
            SubscriptionResource subscriptionResource = GenerateSubscriptionResource(client, subid);
            SubmitHibernateContent content = submitStartRequest;
            HibernateResourceOperationResult result;

            try
            {
                result = await subscriptionResource.SubmitVirtualMachineHibernateAsync(location, content);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.InnerException?.Message);
                throw;
            }
            return result;
        }

        protected static async Task<StartResourceOperationResult> TestExecuteStartAsync(string location, ExecuteStartContent executeStartRequest, string subid, ArmClient client)
        {
            SubscriptionResource subscriptionResource = GenerateSubscriptionResource(client, subid);
            ExecuteStartContent content = executeStartRequest;
            StartResourceOperationResult result;
            try
            {
                result = await subscriptionResource.ExecuteVirtualMachineStartAsync(location, content);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.InnerException?.Message);
                throw;
            }

            return result;
        }

        protected static async Task<DeallocateResourceOperationResult> TestExecuteDeallocateAsync(string location, ExecuteDeallocateContent executeDeallocateRequest, string subid, ArmClient client)
        {
            SubscriptionResource subscriptionResource = GenerateSubscriptionResource(client, subid);
            ExecuteDeallocateContent content = executeDeallocateRequest;

            DeallocateResourceOperationResult result;
            try
            {
                result = await subscriptionResource.ExecuteVirtualMachineDeallocateAsync(location, content);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.InnerException?.Message);
                throw;
            }

            return result;
        }

        protected static async Task<HibernateResourceOperationResult> TestExecuteHibernateAsync(string location, ExecuteHibernateContent executeHibernateRequest, string subid, ArmClient client)
        {
            SubscriptionResource subscriptionResource = GenerateSubscriptionResource(client, subid);
            ExecuteHibernateContent content = executeHibernateRequest;
            HibernateResourceOperationResult result;

            try
            {
                result = await subscriptionResource.ExecuteVirtualMachineHibernateAsync(location, content);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.InnerException?.Message);
                throw;
            }
            return result;
        }

        protected static async Task<GetOperationStatusResult> TestGetOpsStatusAsync(string location, GetOperationStatusContent getOpsStatusRequest, string subid, ArmClient client)
        {
            SubscriptionResource subscriptionResource = GenerateSubscriptionResource(client, subid);
            GetOperationStatusContent content = getOpsStatusRequest;
            GetOperationStatusResult result;

            try
            {
                result = await subscriptionResource.GetVirtualMachineOperationStatusAsync(location, content);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.InnerException?.Message);
                throw;
            }

            return result;
        }

        protected static async Task<CancelOperationsResult> TestCancelOpsAsync(string location, CancelOperationsContent cancelOpsRequest, string subid, ArmClient client)
        {
            SubscriptionResource subscriptionResource = GenerateSubscriptionResource(client, subid);
            CancelOperationsContent content = cancelOpsRequest;
            CancelOperationsResult result;

            try
            {
                result = await subscriptionResource.CancelVirtualMachineOperationsAsync(location, content);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.InnerException?.Message);
                throw;
            }
            return result;
        }

        protected static async Task<GetOperationErrorsResult> TestGetOperationErrorsAsync(string location, GetOperationErrorsContent getOperationErrorsRequest, string subid, ArmClient client)
        {
            SubscriptionResource subscriptionResource = GenerateSubscriptionResource(client, subid);
            GetOperationErrorsContent content = getOperationErrorsRequest;
            GetOperationErrorsResult result;

            try
            {
                result = await subscriptionResource.GetVirtualMachineOperationErrorsAsync(location, content);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.InnerException?.Message);
                throw;
            }
            return result;
        }

        #endregion
    }
}
