// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.ResourceManager.DatabaseFleetManager.Models;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.TestFramework;
using NUnit.Framework;

namespace Azure.ResourceManager.DatabaseFleetManager.Tests
{
    public class DatabaseFleetManagerManagementTestBase : ManagementRecordedTestBase<DatabaseFleetManagerManagementTestEnvironment>
    {
        protected DatabaseFleetManagerManagementTestBase(bool isAsync, RecordedTestMode mode)
            : base(isAsync, mode)
        {
        }

        protected DatabaseFleetManagerManagementTestBase(bool isAsync)
            : base(isAsync)
        {
        }

        protected ArmClient Client { get; private set; }
        protected SubscriptionResource DefaultSubscription { get; private set; }
        protected AzureLocation DefaultLocation { get; private set; }

        protected FleetTierProperties DefaultPooledTierProperties { get; } = new FleetTierProperties
        {
            Pooled = true,
            Family = "Gen5",
            ServiceTier = "GeneralPurpose",
            Capacity = 2,
            PoolNumOfDatabasesMax = 4,
            DatabaseCapacityMin = 0,
            DatabaseCapacityMax = 2
        };

        protected FleetspaceProperties DefaultFleetspaceProperties { get; } = new FleetspaceProperties
        {
            CapacityMax = 10,
            MainPrincipal = new MainPrincipal
            {
                ApplicationId = Guid.Parse("00000000-0000-0000-0000-000000000002"),
                ObjectId = Guid.Parse("00000000-0000-0000-0000-000000000002"),
                TenantId = Guid.Parse("00000000-0000-0000-0000-000000000003"),
                PrincipalType = PrincipalType.Application,
                Login = "MyMainPrincipal"
            }
        };

        protected FirewallRuleProperties DefaultFirewallRuleProperties { get; } = new FirewallRuleProperties
        {
            StartIPAddress = "10.0.0.0",
            EndIPAddress = "10.0.0.255"
        };

        protected FleetDatabaseProperties DefaultDatabaseProperties { get; } = new FleetDatabaseProperties
        {
            CreateMode = DatabaseCreateMode.Default
        };

        [SetUp]
        public async Task CreateCommonClient()
        {
            Client = GetArmClient();
            DefaultSubscription = await Client.GetDefaultSubscriptionAsync().ConfigureAwait(false);
            DefaultLocation = AzureLocation.UKSouth;
        }

        protected async Task<ResourceGroupResource> CreateResourceGroup(
            SubscriptionResource subscription,
            string rgNamePrefix,
            AzureLocation location)
        {
            string rgName = Recording.GenerateAssetName(rgNamePrefix);
            ResourceGroupData input = new ResourceGroupData(location);
            var lro = await subscription.GetResourceGroups().CreateOrUpdateAsync(WaitUntil.Completed, rgName, input);
            return lro.Value;
        }

        protected async Task<FleetResource> CreateFleetAsync(
            ResourceGroupResource resourceGroup,
            string fleetName)
        {
            var fleetData = new FleetData(DefaultLocation)
            {
                Properties = new FleetProperties
                {
                }
            };

            ArmOperation<FleetResource> response = await resourceGroup.GetFleets()
                .CreateOrUpdateAsync(WaitUntil.Completed, fleetName, fleetData);

            return response.Value;
        }

        protected async Task<FleetTierResource> CreateTierAsync(
            ResourceGroupResource resourceGroup,
            string fleetName,
            string tierName,
            FleetTierProperties tierProperties)
        {
            Response<FleetResource> fleet = await resourceGroup.GetFleetAsync(fleetName);

            var tierData = new FleetTierData
            {
                Properties = tierProperties
            };

            ArmOperation<FleetTierResource> response = await fleet.Value.GetFleetTiers()
                .CreateOrUpdateAsync(WaitUntil.Completed, tierName, tierData);

            return response.Value;
        }

        protected async Task<FleetspaceResource> CreateFleetspaceAsync(
            ResourceGroupResource resourceGroup,
            string fleetName,
            string fleetspaceName,
            FleetspaceProperties fleetspaceProperties)
        {
            Response<FleetResource> fleet = await resourceGroup.GetFleetAsync(fleetName);

            var fleetspaceData = new FleetspaceData
            {
                Properties = fleetspaceProperties
            };

            ArmOperation<FleetspaceResource> response = await fleet.Value.GetFleetspaces()
                .CreateOrUpdateAsync(WaitUntil.Completed, fleetspaceName, fleetspaceData);

            return response.Value;
        }

        protected async Task<FirewallRuleResource> CreateFirewallRuleAsync(
            ResourceGroupResource resourceGroup,
            string fleetName,
            string fleetspaceName,
            string firewallRuleName,
            FirewallRuleProperties firewallRuleProperties)
        {
            Response<FleetResource> fleet = await resourceGroup.GetFleetAsync(fleetName);
            Response<FleetspaceResource> fleetspace = await fleet.Value.GetFleetspaceAsync(fleetspaceName);

            var firewallRuleData = new FirewallRuleData
            {
                Properties = firewallRuleProperties
            };

            ArmOperation<FirewallRuleResource> response = await fleetspace.Value.GetFirewallRules()
                .CreateOrUpdateAsync(WaitUntil.Completed, firewallRuleName, firewallRuleData);

            return response.Value;
        }

        protected async Task<FleetDatabaseResource> CreateDatabaseAsync(
            ResourceGroupResource resourceGroup,
            string fleetName,
            string fleetspaceName,
            string databaseName,
            string tierName,
            FleetDatabaseProperties databaseProperties)
        {
            Response<FleetResource> fleet = await resourceGroup.GetFleetAsync(fleetName);
            Response<FleetspaceResource> fleetspace = await fleet.Value.GetFleetspaceAsync(fleetspaceName);

            databaseProperties.TierName = tierName;

            var databaseData = new FleetDatabaseData
            {
                Properties = databaseProperties,
            };

            ArmOperation<FleetDatabaseResource> response = await fleetspace.Value.GetFleetDatabases()
                .CreateOrUpdateAsync(WaitUntil.Completed, databaseName, databaseData);

            return response.Value;
        }
    }
}
