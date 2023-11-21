// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;
using Azure.Core.TestFramework;
using Azure.ResourceManager.ContainerService;
using Azure.ResourceManager.ContainerService.Models;
using Azure.ResourceManager.Models;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.TestFramework;
using NUnit.Framework;
using System.Drawing;
using System.Threading.Tasks;

namespace Azure.ResourceManager.ContainerServiceFleet.Tests
{
    public class ContainerServiceFleetManagementTestBase : ManagementRecordedTestBase<ContainerServiceFleetManagementTestEnvironment>
    {
        //protected ArmClient DefaultArmClient { get; private set; }
        //protected SubscriptionResource DefaultSubscription { get; private set; }
        //protected ResourceGroupResource DefaultResourceGroup { get; private set; }
        protected const string DefaultFleetResourceGroupName = "fleet-dotnet-testing"; // this must match the value set from ./New-TestResources.ps1
        protected AzureLocation DefaultLocation = new AzureLocation("eastus");

        protected ContainerServiceFleetManagementTestBase(bool isAsync, RecordedTestMode mode)
        : base(isAsync, mode)
        {
        }

        protected ContainerServiceFleetManagementTestBase(bool isAsync)
            : base(isAsync)
        {
        }

        protected async Task<ResourceGroupResource> CreateResourceGroup(SubscriptionResource subscription, string resourceGroup, AzureLocation location)
        {
            ResourceGroupData input = new ResourceGroupData(location);
            var lro = await subscription.GetResourceGroups().CreateOrUpdateAsync(WaitUntil.Completed, resourceGroup, input);
            return lro.Value;
        }

        protected async Task<ContainerServiceManagedClusterResource> CreateContainerServiceAsync(ResourceGroupResource resourceGroup, string clusterName, AzureLocation? location = null)
        {
            var clusterData = new ContainerServiceManagedClusterData(location == null ? resourceGroup.Data.Location : location.Value)
            {
                AgentPoolProfiles =
                {
                    new ManagedClusterAgentPoolProfile("aksagent")
                    {
                        VmSize = "Standard_D2s_v3",
                        Count = 1,
                        Mode = AgentPoolMode.System
                    }
                },
                DnsPrefix = "aksdotnetsdk",
                Identity = new ManagedServiceIdentity(ManagedServiceIdentityType.SystemAssigned)
            };
            var lro = await resourceGroup.GetContainerServiceManagedClusters().CreateOrUpdateAsync(WaitUntil.Completed, clusterName, clusterData);
            return lro.Value;
        }
    }
}
