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
                Identity = new ManagedServiceIdentity(ManagedServiceIdentityType.SystemAssigned),
            };
            var lro = await resourceGroup.GetContainerServiceManagedClusters().CreateOrUpdateAsync(WaitUntil.Completed, clusterName, clusterData);
            return lro.Value;
        }
    }
}
