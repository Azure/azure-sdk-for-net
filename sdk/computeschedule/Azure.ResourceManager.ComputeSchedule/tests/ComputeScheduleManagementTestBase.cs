// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
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
            ArmOperation<ResourceGroupResource> rgOp = await DefaultSubscription.GetResourceGroups().CreateOrUpdateAsync(
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
            ResourceIdentifier nicId = new($"{rg.Id}/providers/Microsoft.Network/networkInterfaces/{nicName}");
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
            ArmOperation<GenericResource> operation = await _genericResourceCollection.CreateOrUpdateAsync(WaitUntil.Completed, nicId, input);
            return operation.Value;
        }

        protected async Task<GenericResource> CreateVirtualNetwork(ResourceGroupResource rg, string dependencyName)
        {
            var vnetName = Recording.GenerateAssetName($"{dependencyName}-vnet-");
            var subnetName = Recording.GenerateAssetName($"{dependencyName}-subnet-");
            ResourceIdentifier vnetId = new($"{rg.Id}/providers/Microsoft.Network/virtualNetworks/{vnetName}");
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
            ArmOperation<GenericResource> operation = await _genericResourceCollection.CreateOrUpdateAsync(WaitUntil.Completed, vnetId, input);
            return operation.Value;
        }

        /// <summary>
        /// Dependencies for creating a virtual machine.
        /// </summary>
        /// <returns></returns>
        protected async Task<GenericResource> CreateBasicDependenciesOfVirtualMachineCreationAsync(ResourceGroupResource rg, string dependencyName)
        {
            GenericResource vnet = await CreateVirtualNetwork(rg, dependencyName);
            GenericResource nic = await CreateNetworkInterface(GetSubnetId(vnet), rg, dependencyName);
            return nic;
        }

        /// <summary>
        /// Create a virtual machine in a resource group.
        /// </summary>
        /// <param name="vmName"></param>
        /// <param name="vmnamesuffix"></param>
        /// <param name="resourceGroup"></param>
        /// <returns></returns>
        protected async Task<VirtualMachineResource> CreateVirtualMachineAsync(string vmName, string vmnamesuffix, ResourceGroupResource resourceGroup)
        {
            using CancellationTokenSource cts = new(TimeSpan.FromMinutes(10));
            while (!cts.Token.IsCancellationRequested)
            {
                try
                {
                    var computerName = $"{vmName}{vmnamesuffix}";
                    VirtualMachineCollection vmCollection = resourceGroup.GetVirtualMachines();
                    GenericResource nic = await CreateBasicDependenciesOfVirtualMachineCreationAsync(resourceGroup, computerName);
                    VirtualMachineData input = ResourceUtils.GetBasicWindowsVirtualMachineData(Location, computerName, nic.Id);
                    ArmOperation<VirtualMachineResource> lro = await vmCollection.CreateOrUpdateAsync(WaitUntil.Completed, computerName, input);
                    return lro.Value;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    await Task.Delay(1000);
                    throw;
                }
            }
            throw new OperationCanceledException("The operation was canceled before the virtual machine could be created.");
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

        protected async Task DeleteVirtualMachineAsync(List<VirtualMachineResource> vms)
        {
            foreach (VirtualMachineResource vm in vms)
            {
                await vm.DeleteAsync(WaitUntil.Completed, forceDeletion: true);
            }
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
        private Dictionary<string, OperationState?> _completedOperations = [];
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

#nullable enable

        /// <summary>
        /// This method excludes resources not processed in Scheduledactions due to a number of reasons like operation conflicts etc.
        /// </summary>
        /// <param name="results"></param>
        /// <returns></returns>
        public static HashSet<string?> ExcludeResourcesNotProcessed(IEnumerable<ResourceOperationResult> results)
        {
            var validOperationIds = new HashSet<string?>();
            foreach (ResourceOperationResult result in results)
            {
                if (result.ErrorCode != null)
                {
                    Console.WriteLine($"VM with resourceId: {result.ResourceId} encountered the following error: errorCode {result.ErrorCode}, errorDetails: {result.ErrorDetails}");
                }
                else
                {
                    validOperationIds.Add(result.Operation.OperationId);
                }
            }
            return validOperationIds;
        }
#nullable disable
        #endregion

        #region SA Operations

        protected static async Task<StartResourceOperationResult> TestSubmitStartAsync(AzureLocation location, SubmitStartContent submitStartRequest, string subid, ArmClient client)
        {
            SubscriptionResource subscriptionResource = GenerateSubscriptionResource(client, subid);
            SubmitStartContent content = submitStartRequest;
            StartResourceOperationResult result;

            try
            {
                result = await subscriptionResource.SubmitVirtualMachineStartAsync(location, content);
            }
            catch (RequestFailedException ex)
            {
                Console.WriteLine($"Request failed with ErrorCode:{ex.ErrorCode} and ErrorMessage: {ex.Message}");
                throw;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.InnerException?.Message);
                throw;
            }
            return result;
        }

        protected static async Task<DeallocateResourceOperationResult> TestSubmitDeallocateAsync(AzureLocation location, SubmitDeallocateContent submitStartRequest, string subid, ArmClient client)
        {
            SubscriptionResource subscriptionResource = GenerateSubscriptionResource(client, subid);
            SubmitDeallocateContent content = submitStartRequest;
            DeallocateResourceOperationResult result;

            try
            {
                result = await subscriptionResource.SubmitVirtualMachineDeallocateAsync(location, content);
            }
            catch (RequestFailedException ex)
            {
                Console.WriteLine($"Request failed with ErrorCode:{ex.ErrorCode} and ErrorMessage: {ex.Message}");
                throw;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.InnerException?.Message);
                throw;
            }
            return result;
        }

        protected static async Task<HibernateResourceOperationResult> TestSubmitHibernateAsync(AzureLocation location, SubmitHibernateContent submitStartRequest, string subid, ArmClient client)
        {
            SubscriptionResource subscriptionResource = GenerateSubscriptionResource(client, subid);
            SubmitHibernateContent content = submitStartRequest;
            HibernateResourceOperationResult result;

            try
            {
                result = await subscriptionResource.SubmitVirtualMachineHibernateAsync(location, content);
            }
            catch (RequestFailedException ex)
            {
                Console.WriteLine($"Request failed with ErrorCode:{ex.ErrorCode} and ErrorMessage: {ex.Message}");
                throw;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.InnerException?.Message);
                throw;
            }
            return result;
        }

        protected static async Task<StartResourceOperationResult> TestExecuteStartAsync(AzureLocation location, ExecuteStartContent executeStartRequest, string subid, ArmClient client)
        {
            SubscriptionResource subscriptionResource = GenerateSubscriptionResource(client, subid);
            ExecuteStartContent content = executeStartRequest;
            StartResourceOperationResult result;
            try
            {
                result = await subscriptionResource.ExecuteVirtualMachineStartAsync(location, content);
            }
            catch (RequestFailedException ex)
            {
                Console.WriteLine($"Request failed with ErrorCode:{ex.ErrorCode} and ErrorMessage: {ex.Message}");
                throw;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.InnerException?.Message);
                throw;
            }

            return result;
        }

        protected static async Task<DeallocateResourceOperationResult> TestExecuteDeallocateAsync(AzureLocation location, ExecuteDeallocateContent executeDeallocateRequest, string subid, ArmClient client)
        {
            SubscriptionResource subscriptionResource = GenerateSubscriptionResource(client, subid);
            ExecuteDeallocateContent content = executeDeallocateRequest;

            DeallocateResourceOperationResult result;
            try
            {
                result = await subscriptionResource.ExecuteVirtualMachineDeallocateAsync(location, content);
            }
            catch (RequestFailedException ex)
            {
                Console.WriteLine($"Request failed with ErrorCode:{ex.ErrorCode} and ErrorMessage: {ex.Message}");
                throw;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.InnerException?.Message);
                throw;
            }

            return result;
        }

        protected static async Task<HibernateResourceOperationResult> TestExecuteHibernateAsync(AzureLocation location, ExecuteHibernateContent executeHibernateRequest, string subid, ArmClient client)
        {
            SubscriptionResource subscriptionResource = GenerateSubscriptionResource(client, subid);
            ExecuteHibernateContent content = executeHibernateRequest;
            HibernateResourceOperationResult result;

            try
            {
                result = await subscriptionResource.ExecuteVirtualMachineHibernateAsync(location, content);
            }
            catch (RequestFailedException ex)
            {
                Console.WriteLine($"Request failed with ErrorCode:{ex.ErrorCode} and ErrorMessage: {ex.Message}");
                throw;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.InnerException?.Message);
                throw;
            }
            return result;
        }

        protected static async Task<GetOperationStatusResult> TestGetOpsStatusAsync(AzureLocation location, GetOperationStatusContent getOpsStatusRequest, string subid, ArmClient client)
        {
            SubscriptionResource subscriptionResource = GenerateSubscriptionResource(client, subid);
            GetOperationStatusContent content = getOpsStatusRequest;
            GetOperationStatusResult result;

            try
            {
                result = await subscriptionResource.GetVirtualMachineOperationStatusAsync(location, content);
            }
            catch (RequestFailedException ex)
            {
                Console.WriteLine($"Request failed with ErrorCode:{ex.ErrorCode} and ErrorMessage: {ex.Message}");
                throw;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.InnerException?.Message);
                throw;
            }

            return result;
        }

        protected static async Task<CancelOperationsResult> TestCancelOpsAsync(AzureLocation location, CancelOperationsContent cancelOpsRequest, string subid, ArmClient client)
        {
            SubscriptionResource subscriptionResource = GenerateSubscriptionResource(client, subid);
            CancelOperationsContent content = cancelOpsRequest;
            CancelOperationsResult result;

            try
            {
                result = await subscriptionResource.CancelVirtualMachineOperationsAsync(location, content);
            }
            catch (RequestFailedException ex)
            {
                Console.WriteLine($"Request failed with ErrorCode:{ex.ErrorCode} and ErrorMessage: {ex.Message}");
                throw;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.InnerException?.Message);
                throw;
            }
            return result;
        }

        protected static async Task<GetOperationErrorsResult> TestGetOperationErrorsAsync(AzureLocation location, GetOperationErrorsContent getOperationErrorsRequest, string subid, ArmClient client)
        {
            SubscriptionResource subscriptionResource = GenerateSubscriptionResource(client, subid);
            GetOperationErrorsContent content = getOperationErrorsRequest;
            GetOperationErrorsResult result;

            try
            {
                result = await subscriptionResource.GetVirtualMachineOperationErrorsAsync(location, content);
            }
            catch (RequestFailedException ex)
            {
                Console.WriteLine($"Request failed with ErrorCode:{ex.ErrorCode} and ErrorMessage: {ex.Message}");
                throw;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.InnerException?.Message);
                throw;
            }
            return result;
        }

        protected static async Task<DeleteResourceOperationResult> TestExecuteDeleteAsync(AzureLocation location, ExecuteDeleteContent executeDeleteRequest, string subid, ArmClient client)
        {
            SubscriptionResource subscriptionResource = GenerateSubscriptionResource(client, subid);
            ExecuteDeleteContent content = executeDeleteRequest;
            DeleteResourceOperationResult result;

            try
            {
                result = await subscriptionResource.VirtualMachinesExecuteDeleteScheduledActionAsync(location, content);
            }
            catch (RequestFailedException ex)
            {
                Console.WriteLine($"Request failed with ErrorCode:{ex.ErrorCode} and ErrorMessage: {ex.Message}");
                throw;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.InnerException?.Message);
                throw;
            }
            return result;
        }

        protected static async Task<CreateResourceOperationResult> TestExecuteCreateAsync(AzureLocation location, ExecuteCreateContent executeCreateRequest, string subid, ArmClient client)
        {
            SubscriptionResource subscriptionResource = GenerateSubscriptionResource(client, subid);
            ExecuteCreateContent content = executeCreateRequest;
            CreateResourceOperationResult result;

            try
            {
                result = await subscriptionResource.VirtualMachinesExecuteCreateScheduledActionAsync(location, content);
            }
            catch (RequestFailedException ex)
            {
                Console.WriteLine($"Request failed with ErrorCode:{ex.ErrorCode} and ErrorMessage: {ex.Message}");
                throw;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.InnerException?.Message);
                throw;
            }
            return result;
        }

        #endregion

        #region Recurring scheduledactions operations

        public static async Task<Response<ScheduledActionResource>> GetScheduledActions(string subid, ArmClient client, string scheduledActionName, ResourceGroupResource rgResource, bool shouldThrow = false)
        {
            Response<ScheduledActionResource> saResource = null;

            try
            {
                saResource = await rgResource.GetScheduledActionAsync(scheduledActionName);
            }
            catch (RequestFailedException ex) when (ex.ErrorCode == "ResourceNotFound")
            {
                Console.WriteLine($" {scheduledActionName} scheduledaction deleted");

                if (shouldThrow)
                {
                    throw;
                }
            }

            return saResource;
        }

        public static async Task DeleteScheduledAction(string subid, ArmClient client, string scheduledActionName, ResourceGroupResource rgResource, bool shouldThrow = false)
        {
            ResourceIdentifier scheduledActionResourceId = ScheduledActionResource.CreateResourceIdentifier(subid, rgResource.Id.Name, scheduledActionName);
            ScheduledActionResource scheduledAction = client.GetScheduledActionResource(scheduledActionResourceId);

            await scheduledAction.DeleteAsync(WaitUntil.Completed);

            await GetScheduledActions(subid, client, scheduledActionName, rgResource, shouldThrow);
        }
        #endregion
    }
}
