// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Models;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.SiteManager.Models;
using Azure.ResourceManager.TestFramework;
using NUnit.Framework;
using System;
using System.Linq;
using System.Reflection.Emit;
using System.Reflection.Metadata;
using System.Security.AccessControl;
using System.Threading.Tasks;

namespace Azure.ResourceManager.SiteManager.Tests
{
    public class SiteManagerManagementTestBase : ManagementRecordedTestBase<SiteManagerManagementTestEnvironment>
    {
        protected ArmClient Client { get; private set; }
        protected SubscriptionResource DefaultSubscription { get; private set; }
        protected TenantResource DefaultTenant { get; private set; }

        protected SiteManagerManagementTestBase(bool isAsync, RecordedTestMode mode)
        : base(isAsync, mode)
        {
        }

        protected SiteManagerManagementTestBase(bool isAsync)
            : base(isAsync)
        {
        }

        [SetUp]
        public async Task CreateCommonClient()
        {
            Client = GetArmClient();
            DefaultSubscription = await Client.GetDefaultSubscriptionAsync().ConfigureAwait(false);
            DefaultTenant = (await Client.GetTenants().ToEnumerableAsync().ConfigureAwait(false)).FirstOrDefault();
        }

        protected async Task<ResourceGroupResource> CreateResourceGroup(SubscriptionResource subscription, string rgNamePrefix, AzureLocation location)
        {
            string rgName = Recording.GenerateAssetName(rgNamePrefix);
            ResourceGroupData input = new ResourceGroupData(location);
            var lro = await subscription.GetResourceGroups().CreateOrUpdateAsync(WaitUntil.Completed, rgName, input);
            return lro.Value;
        }

        protected async Task<EdgeSiteResource> CreateSiteAsync(ResourceGroupResource resourceGroup, string siteName)
        {
            string displayName, description;
            System.Collections.Generic.Dictionary<string, string> labels;
            SiteAddressProperties siteAddress;
            InitializeSiteDetails(out displayName, out description, out labels, out siteAddress);

            var siteProperties = ArmSiteManagerModelFactory.EdgeSiteProperties(displayName, description, siteAddress, labels);
            var siteData = ArmSiteManagerModelFactory.EdgeSiteData(resourceGroup.Id, siteName, default, null, siteProperties);

            var lro = await resourceGroup.GetEdgeSites().CreateOrUpdateAsync(WaitUntil.Completed, siteName, siteData);
            return lro.Value;
        }

        protected async Task<EdgeSiteResource> CreateServiceGroupSiteAsync(TenantResource tenantResource, string siteName, string serviceGroupName)
        {
            string displayName, description;
            System.Collections.Generic.Dictionary<string, string> labels;
            SiteAddressProperties siteAddress;
            InitializeSiteDetails(out displayName, out description, out labels, out siteAddress);

            var siteProperties = ArmSiteManagerModelFactory.EdgeSiteProperties(displayName, description, siteAddress, labels);
            var siteData = ArmSiteManagerModelFactory.EdgeSiteData(tenantResource.Id, siteName, default, null, siteProperties);

            var lro = await tenantResource.CreateOrUpdateSitesByServiceGroupAsync(WaitUntil.Completed, serviceGroupName, siteName, siteData);
            return lro.Value;
        }

        private static void InitializeSiteDetails(out string displayName, out string description, out System.Collections.Generic.Dictionary<string, string> labels, out SiteAddressProperties siteAddress)
        {
            displayName = "Seattle Site";
            description = "Seattle Site Description";
            labels = new System.Collections.Generic.Dictionary<string, string>
            {
                { "city", "Seattle" },
                { "country", "USA" }
            };
            siteAddress = new SiteAddressProperties()
            {
                StreetAddress1 = "Apt 4B",
                StreetAddress2 = "123 Main St",
                City = "Seattle",
                StateOrProvince = "WA",
                Country = "USA",
                PostalCode = "98101"
            };
        }

        protected async Task<EdgeSiteResource> UpdateSiteAsync(ResourceGroupResource resourceGroup, string siteName)
        {
            var displayName = "New York Site";
            var description = "New York Site Description";

            var labels = new System.Collections.Generic.Dictionary<string, string>
            {
                { "city", "New York" }
            };

            SiteAddressProperties siteAddress = new SiteAddressProperties()
            {
                City = "New York",
                Country = "USA",
            };

            var siteProperties = ArmSiteManagerModelFactory.EdgeSiteProperties(displayName, description, siteAddress, labels);
            var siteData = ArmSiteManagerModelFactory.EdgeSiteData(resourceGroup.Id, siteName, default, null, siteProperties);

            var lro = await resourceGroup.GetEdgeSites().CreateOrUpdateAsync(WaitUntil.Completed, siteName, siteData);
            return lro.Value;
        }

        protected async Task<EdgeSiteResource> UpdateServiceGroupSiteAsync(TenantResource tenantResource, string siteName, string serviceGroupName)
        {
            var displayName = "New York Site";
            var description = "New York Site Description";

            var labels = new System.Collections.Generic.Dictionary<string, string>
            {
                { "city", "New York" }
            };

            SiteAddressProperties siteAddress = new SiteAddressProperties()
            {
                City = "New York",
                Country = "USA",
            };

            var siteProperties = ArmSiteManagerModelFactory.EdgeSiteProperties(displayName, description, siteAddress, labels);
            var siteData = ArmSiteManagerModelFactory.EdgeSiteData(tenantResource.Id, siteName, default, null, siteProperties);

            var lro = await tenantResource.CreateOrUpdateSitesByServiceGroupAsync(WaitUntil.Completed, serviceGroupName, siteName, siteData);
            return lro.Value;
        }
    }
}
