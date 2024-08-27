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
using OperationState = Azure.ResourceManager.ComputeSchedule.Models.OperationState;

namespace Azure.ResourceManager.ComputeSchedule.Tests
{
    public class ComputeScheduleManagementTestBase : ManagementRecordedTestBase<ComputeScheduleManagementTestEnvironment>
    {
        protected ArmClient Client { get; private set; }
        protected SubscriptionResource DefaultSubscription { get; private set; }
        protected AzureLocation Location { get; private set; }
        protected GenericResourceCollection _genericResourceCollection;
        protected ResourceGroupResource DefaultResourceGroupResource;

        private const string DummySshKey = "ssh-rsa AAAAB3NzaC1yc2EAAAADAQABAAACAQD1kQeX2CReMtaQhQdZsGeo1pGSdrugd/FTLRA+5FOJ63RVEXkJP0OKGdUv5mP9+/aAyQXjc9bXLKeWJl3shYUVqLphjYnsFxgBCMidVOHi826F2BXyPCb/aft0L7CzP185iP6hMMZQHqSIkI+FD6EoVPY42ocGdjOE8GR2NEotFK980ldh/IkIIcqSPsX5aCx7awVdiMACov+Iy7nuf7qL9W7IZUOjEbcReWuI5l56cXWbIg3/N5AFYkjictTkl9+CqgqxxAYxsYLSLTkKFN/D+vGXWXGuWygMMqT3Go5lKo1m15WN/TWoU8ftFVrktw1nPKzZPLPUdAGU0Lxj73fLJRALVPlCSPRU905Ophu5lzIObnze9Hs/aqilbByt6hLuLAWhPk9I2yEppIhbJ08YH8r2iwjcsoCuMsM+LUkwKZwMvUx6sei26e+3Hrbto1G9vvvpX89B2B09JXrcJroaxUjnjoYS9ug3wLD/+TPoVF8Sn2DIIytQiXsANC88Kf9dm3x2qJ7c7duy6shEIYGBha4i9/Q9709xyp8TKI2O47KAesPPgbpCE2StCIMNIBp0yl6+7JzuEPk0lAQ3Q24ow2q1EIv1D6zse4zL1Q5qHcF+Q7g5+ZlHW9IPO2YFaco7F149ez5xOmZAmINR0mUYDNyctkT+rAOXrCY1SO5SmQ== user@myserver";

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
                SubscriptionResource subIdRes = GenerateSubscriptionResource(Client, TestEnvironment.SubId);
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
            var vnet = await CreateVirtualNetwork(rg, dependencyName);
            var nic = await CreateNetworkInterface(GetSubnetId(vnet), rg, dependencyName);
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
            var wholeVmName = $"{vmName}-{vmnamesuffix}";
            var vmCollection = resourceGroup.GetVirtualMachines();
            var nic = await CreateBasicDependenciesOfVirtualMachineCreationAsync(resourceGroup, wholeVmName);
            var input = ResourceUtils.GetBasicLinuxVirtualMachineData(Location, wholeVmName, nic.Id, DummySshKey);
            var lro = await vmCollection.CreateOrUpdateAsync(WaitUntil.Completed, wholeVmName, input);
            return lro.Value;
        }

        protected async Task<List<VirtualMachineResource>> GenerateMultipleVirtualMachines(string vmName, ResourceGroupResource resourceGroup, int vmCount)
        {
            var item = new List<VirtualMachineResource>();
            item.Clear();

            for (int i = 0; i < vmCount; i++)
            {
                var vm = await CreateVirtualMachineAsync(vmName, $"-{i}", resourceGroup);
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
        protected Polly.Retry.AsyncRetryPolicy<GetOperationStatusResponse> PollOperationStatus(int vmCount)
        {
            int retryCount = 7;
            var maxDelay = TimeSpan.FromSeconds(10);

            IEnumerable<TimeSpan> delay = Backoff.ExponentialBackoff(initialDelay: TimeSpan.FromSeconds(2), retryCount: retryCount)
                    .Select(s => TimeSpan.FromTicks(Math.Min(s.Ticks, maxDelay.Ticks)));

            return Policy
                .HandleResult<GetOperationStatusResponse>(r => ShouldRetryPolling(r, vmCount).GetAwaiter().GetResult())
                .Or<RequestFailedException>()
                .WaitAndRetryAsync(delay);
        }

#pragma warning disable IDE0044 // Add readonly modifier
        private Dictionary<string, OperationState> _completedOperations = new();
#pragma warning restore IDE0044 // Add readonly modifier

        private Task<bool> ShouldRetryPolling(GetOperationStatusResponse response, int totalVmsCount)
        {
            var shouldRetry = true;
            _completedOperations.Clear();

            IReadOnlyList<ResourceOperation> responseResults = response.Results;

            foreach (ResourceOperation item in responseResults)
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

        protected static async Task<StartResourceOperationResponse> TestSubmitStartAsync(string location, SubmitStartContent submitStartRequest, string subid)
        {
            TokenCredential cred = new DefaultAzureCredential();
            ArmClient client = new(cred);
            SubscriptionResource subscriptionResource = GenerateSubscriptionResource(client, subid);
            SubmitStartContent content = submitStartRequest;
            StartResourceOperationResponse result;

            try
            {
                result = await subscriptionResource.VirtualMachinesSubmitStartScheduledActionAsync(location, content);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.InnerException?.Message);
                throw;
            }
            return result;
        }

        protected static async Task<DeallocateResourceOperationResponse> TestSubmitDeallocateAsync(string location, SubmitDeallocateContent submitStartRequest, string subid)
        {
            TokenCredential cred = new DefaultAzureCredential();
            ArmClient client = new(cred);
            SubscriptionResource subscriptionResource = GenerateSubscriptionResource(client, subid);
            SubmitDeallocateContent content = submitStartRequest;
            DeallocateResourceOperationResponse result;

            try
            {
                result = await subscriptionResource.VirtualMachinesSubmitDeallocateScheduledActionAsync(location, content);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.InnerException?.Message);
                throw;
            }
            return result;
        }

        protected static async Task<HibernateResourceOperationResponse> TestSubmitHibernateAsync(string location, SubmitHibernateContent submitStartRequest, string subid)
        {
            TokenCredential cred = new DefaultAzureCredential();
            ArmClient client = new(cred);
            SubscriptionResource subscriptionResource = GenerateSubscriptionResource(client, subid);
            SubmitHibernateContent content = submitStartRequest;
            HibernateResourceOperationResponse result;

            try
            {
                result = await subscriptionResource.VirtualMachinesSubmitHibernateScheduledActionAsync(location, content);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.InnerException?.Message);
                throw;
            }
            return result;
        }

        protected static async Task<StartResourceOperationResponse> TestExecuteStartAsync(string location, ExecuteStartContent executeStartRequest, string subid)
        {
            TokenCredential cred = new DefaultAzureCredential();
            ArmClient client = new(cred);
            SubscriptionResource subscriptionResource = GenerateSubscriptionResource(client, subid);
            ExecuteStartContent content = executeStartRequest;
            StartResourceOperationResponse result;
            try
            {
                result = await subscriptionResource.VirtualMachinesExecuteStartScheduledActionAsync(location, content);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.InnerException?.Message);
                throw;
            }

            return result;
        }

        protected static async Task<DeallocateResourceOperationResponse> TestExecuteDeallocateAsync(string location, ExecuteDeallocateContent executeDeallocateRequest, string subid)
        {
            TokenCredential cred = new DefaultAzureCredential();
            ArmClient client = new(cred);
            SubscriptionResource subscriptionResource = GenerateSubscriptionResource(client, subid);
            ExecuteDeallocateContent content = executeDeallocateRequest;

            DeallocateResourceOperationResponse result;
            try
            {
                result = await subscriptionResource.VirtualMachinesExecuteDeallocateScheduledActionAsync(location, content);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.InnerException?.Message);
                throw;
            }

            return result;
        }

        protected static async Task<HibernateResourceOperationResponse> TestExecuteHibernateAsync(string location, ExecuteHibernateContent executeHibernateRequest, string subid)
        {
            TokenCredential cred = new DefaultAzureCredential();
            ArmClient client = new(cred);
            SubscriptionResource subscriptionResource = GenerateSubscriptionResource(client, subid);
            ExecuteHibernateContent content = executeHibernateRequest;
            HibernateResourceOperationResponse result;

            try
            {
                result = await subscriptionResource.VirtualMachinesExecuteHibernateScheduledActionAsync(location, content);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.InnerException?.Message);
                throw;
            }
            return result;
        }

        protected static async Task<GetOperationStatusResponse> TestGetOpsStatusAsync(string location, GetOperationStatusContent getOpsStatusRequest, string subid)
        {
            TokenCredential cred = new DefaultAzureCredential();

            ArmClient client = new(cred);
            SubscriptionResource subscriptionResource = GenerateSubscriptionResource(client, subid);
            GetOperationStatusContent content = getOpsStatusRequest;
            GetOperationStatusResponse result;

            try
            {
                result = await subscriptionResource.VirtualMachinesGetOperationStatusScheduledActionAsync(location, content);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.InnerException?.Message);
                throw;
            }

            return result;
        }

        protected static async Task<CancelOperationsResponse> TestCancelOpsAsync(string location, CancelOperationsContent cancelOpsRequest, string subid)
        {
            TokenCredential cred = new DefaultAzureCredential();

            ArmClient client = new(cred);
            SubscriptionResource subscriptionResource = GenerateSubscriptionResource(client, subid);
            CancelOperationsContent content = cancelOpsRequest;
            CancelOperationsResponse result;

            try
            {
                result = await subscriptionResource.VirtualMachinesCancelOperationsScheduledActionAsync(location, content);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.InnerException?.Message);
                throw;
            }
            return result;
        }

        protected static async Task<GetOperationErrorsResponse> TestGetOperationErrorsAsync(string location, GetOperationErrorsContent getOperationErrorsRequest, string subid)
        {
            TokenCredential cred = new DefaultAzureCredential();

            ArmClient client = new(cred);
            SubscriptionResource subscriptionResource = GenerateSubscriptionResource(client, subid);
            GetOperationErrorsContent content = getOperationErrorsRequest;
            GetOperationErrorsResponse result;

            try
            {
                result = await subscriptionResource.VirtualMachinesGetOperationErrorsScheduledActionAsync(location, content);
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
