// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.SiteManager.Models;
using Azure.ResourceManager.TestFramework;
using NUnit.Framework;

namespace Azure.ResourceManager.SiteManager.Tests
{
    public class SiteManagerManagementTestBase : ManagementRecordedTestBase<SiteManagerManagementTestEnvironment>
    {
        protected ArmClient Client { get; private set; }
        protected SubscriptionResource DefaultSubscription { get; private set; }

        protected SiteManagerManagementTestBase(bool isAsync, RecordedTestMode mode)
        : base(isAsync, mode)
        {
        }

        protected SiteManagerManagementTestBase(bool isAsync)
            : base(isAsync)
        {
        }

        public static ResourceIdentifier CreateServiceGroupId(string serviceGroupName)
            => new ResourceIdentifier($"/providers/Microsoft.Management/serviceGroups/{serviceGroupName}");

        [SetUp]
        public async Task CreateCommonClient()
        {
            Client = GetArmClient();
            DefaultSubscription = await Client.GetDefaultSubscriptionAsync().ConfigureAwait(false);
        }

        protected async Task<ResourceGroupResource> CreateResourceGroup(SubscriptionResource subscription, string rgNamePrefix, AzureLocation location)
        {
            string rgName = Recording.GenerateAssetName(rgNamePrefix);
            ResourceGroupData input = new ResourceGroupData(location);
            var lro = await subscription.GetResourceGroups().CreateOrUpdateAsync(WaitUntil.Completed, rgName, input);
            return lro.Value;
        }

        protected async Task<ResourceGroupEdgeSiteResource> CreateSiteAsync(ResourceGroupResource resourceGroup, string siteName)
        {
            InitializeSiteDetails(out var displayName, out var description, out var labels, out var siteAddress);

            var siteProperties = ArmSiteManagerModelFactory.EdgeSiteProperties(displayName, description, siteAddress, labels);
            var siteData = ArmSiteManagerModelFactory.EdgeSiteData(resourceGroup.Id, siteName, default, null, siteProperties);

            var lro = await resourceGroup.GetResourceGroupEdgeSites().CreateOrUpdateAsync(WaitUntil.Completed, siteName, siteData);
            return lro.Value;
        }

        protected async Task<ServiceGroupEdgeSiteResource> CreateServiceGroupSiteAsync(ArmClient armClient, string siteName, string serviceGroupName)
        {
            InitializeSiteDetails(out var displayName, out var description, out var labels, out var siteAddress);

            var siteProperties = ArmSiteManagerModelFactory.EdgeSiteProperties(displayName, description, siteAddress, labels);
            var siteData = new EdgeSiteData()
            {
                Properties = siteProperties
            };

            var lro = await armClient.GetServiceGroupEdgeSites(CreateServiceGroupId(serviceGroupName)).CreateOrUpdateAsync(WaitUntil.Completed, siteName, siteData);
            return lro.Value;
        }

        private static void InitializeSiteDetails(out string displayName, out string description, out System.Collections.Generic.Dictionary<string, string> labels, out EdgeSiteAddressProperties siteAddress)
        {
            displayName = "Seattle Site";
            description = "Seattle Site Description";
            labels = new System.Collections.Generic.Dictionary<string, string>
            {
                { "city", "Seattle" },
                { "country", "USA" }
            };
            siteAddress = new EdgeSiteAddressProperties()
            {
                StreetAddress1 = "Apt 4B",
                StreetAddress2 = "123 Main St",
                City = "Seattle",
                StateOrProvince = "WA",
                Country = "USA",
                PostalCode = "98101"
            };
        }

        protected async Task<ResourceGroupEdgeSiteResource> UpdateSiteAsync(ResourceGroupResource resourceGroup, string siteName)
        {
            var displayName = "New York Site";
            var description = "New York Site Description";

            var labels = new System.Collections.Generic.Dictionary<string, string>
            {
                { "city", "New York" }
            };

            EdgeSiteAddressProperties siteAddress = new EdgeSiteAddressProperties()
            {
                City = "New York",
                Country = "USA",
            };

            var siteProperties = ArmSiteManagerModelFactory.EdgeSiteProperties(displayName, description, siteAddress, labels);
            var siteData = ArmSiteManagerModelFactory.EdgeSiteData(resourceGroup.Id, siteName, default, null, siteProperties);

            var lro = await resourceGroup.GetResourceGroupEdgeSites().CreateOrUpdateAsync(WaitUntil.Completed, siteName, siteData);
            return lro.Value;
        }

        protected async Task<ServiceGroupEdgeSiteResource> UpdateServiceGroupSiteAsync(ArmClient armClient, string siteName, string serviceGroupName)
        {
            var displayName = "New York Site";
            var description = "New York Site Description";

            var labels = new System.Collections.Generic.Dictionary<string, string>
            {
                { "city", "New York" }
            };

            EdgeSiteAddressProperties siteAddress = new EdgeSiteAddressProperties()
            {
                City = "New York",
                Country = "USA",
            };

            var siteProperties = ArmSiteManagerModelFactory.EdgeSiteProperties(displayName, description, siteAddress, labels);
            var siteData = new EdgeSiteData()
            {
                Properties = siteProperties
            };
            var lro = await armClient.GetServiceGroupEdgeSites(CreateServiceGroupId(serviceGroupName)).CreateOrUpdateAsync(WaitUntil.Completed, siteName, siteData);
            return lro.Value;
        }
    }
}
