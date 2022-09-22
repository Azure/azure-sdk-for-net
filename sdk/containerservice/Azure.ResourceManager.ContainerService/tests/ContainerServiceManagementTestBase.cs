// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Concurrent;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.Core.TestFramework;
using Azure.ResourceManager.ContainerService.Models;
using Azure.ResourceManager.Models;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.TestFramework;
using NUnit.Framework;

namespace Azure.ResourceManager.ContainerService.Tests
{
    public class ContainerServiceManagementTestBase : ManagementRecordedTestBase<ContainerServiceManagementTestEnvironment>
    {
        // TODO: Remove the policy once this issue is fixed: https://github.com/Azure/autorest.csharp/issues/2571.
        // internal class OperationQueryApiVersionPolicy : HttpPipelineSynchronousPolicy
        // {
        //     //"https://management.azure.com/subscriptions/8ecadfc9-d1a3-4ea4-b844-0d9f87e4d7c8/providers/Microsoft.ContainerService/locations/westus2/operations/6112cdd3-47cb-4b46-9d7c-7531b9fe64b5?api-version=2022-04-01"
        //     private Regex _operationQueryPattern = new Regex(@"/subscriptions/[^/]+/providers/Microsoft.ContainerService/locations/([^?/]+)/operations/[^?/]+\?api-version=2022-04-01");

        //     public override void OnSendingRequest(HttpMessage message)
        //     {
        //         if (message.Request.Method == RequestMethod.Get)
        //         {
        //             var match = _operationQueryPattern.Match(message.Request.Uri.ToString());
        //             if (match.Success)
        //             {
        //                 message.Request.Uri.Query = message.Request.Uri.Query.Replace("api-version=2022-04-01", "api-version=2017-08-31");
        //             }
        //         }
        //     }
        // }

        internal const string DnsPrefix = "aksdotnetsdk";
        internal const string AgentPoolProfileName = "aksagent";
        internal const string VmSize = "Standard_D2s_v3";
        protected ArmClient Client { get; private set; }

        protected SubscriptionResource Subscription { get; private set; }

        protected ContainerServiceManagementTestBase(bool isAsync, RecordedTestMode mode)
        : base(isAsync, mode)
        {
        }

        protected ContainerServiceManagementTestBase(bool isAsync)
            : base(isAsync)
        {
        }

        [SetUp]
        public async Task CreateCommonClient()
        {
            // OperationQueryApiVersionPolicy policy = new OperationQueryApiVersionPolicy();
            // ArmClientOptions options = new ArmClientOptions();
            // options.AddPolicy(policy, HttpPipelinePosition.PerCall);
            // Client = GetArmClient(options);
            Client = GetArmClient();
            Subscription = await Client.GetDefaultSubscriptionAsync();
        }

        protected async Task<ResourceGroupResource> CreateResourceGroupAsync(SubscriptionResource subscription, string rgNamePrefix, AzureLocation location)
        {
            string rgName = Recording.GenerateAssetName(rgNamePrefix);
            ResourceGroupData input = new ResourceGroupData(location);
            var lro = await subscription.GetResourceGroups().CreateOrUpdateAsync(WaitUntil.Completed, rgName, input);
            return lro.Value;
        }

        protected async Task<ContainerServiceManagedClusterResource> CreateContainerServiceAsync(ResourceGroupResource resourceGroup, string clusterName, AzureLocation? location = null)
        {
            var clusterData = new ContainerServiceManagedClusterData(location == null ? resourceGroup.Data.Location : location.Value)
            {
                AgentPoolProfiles =
                {
                    new ManagedClusterAgentPoolProfile(AgentPoolProfileName)
                    {
                        VmSize = VmSize,
                        Count = 1,
                        Mode = AgentPoolMode.System
                    }
                },
                DnsPrefix = DnsPrefix,
                Identity = new ManagedServiceIdentity(ManagedServiceIdentityType.SystemAssigned)
                //ServicePrincipalProfile = new ManagedClusterServicePrincipalProfile(new System.Guid("ac107706-47a2-4cc4-a80f-17a56933e1ff"))
                //{
                //    Secret = "fOL34CJYT6hJhyPeJra04iMpDzj8~.Imu9"
                //}
            };
            var lro = await resourceGroup.GetContainerServiceManagedClusters().CreateOrUpdateAsync(WaitUntil.Completed, clusterName, clusterData);
            return lro.Value;
        }
    }
}
