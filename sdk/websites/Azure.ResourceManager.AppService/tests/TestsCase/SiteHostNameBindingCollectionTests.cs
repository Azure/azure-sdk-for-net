// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.ResourceManager.AppService.Models;
using Azure.ResourceManager.AppService.Tests.Helpers;
using Azure.ResourceManager.Resources;
using Azure.Security.KeyVault.Certificates;
using NUnit.Framework;

namespace Azure.ResourceManager.AppService.Tests.TestsCase
{
    public class SiteHostNameBindingCollectionTests : AppServiceTestBase
    {
        private const string VaultUri = "https://yao725keyvault.vault.azure.net/";

        public SiteHostNameBindingCollectionTests(bool isAsync)
           : base(isAsync)
        {
        }

        [TestCase]
        [RecordedTest]
        public async Task CreateSiteHostNameBinding()
        {
            // Create a resource group
            ResourceGroupCollection rgs = DefaultSubscription.GetResourceGroups();
            string rgName = Recording.GenerateAssetName("testAppServiceRG-");
            var rgLro = await rgs.CreateOrUpdateAsync(WaitUntil.Completed, rgName, new ResourceGroupData(DefaultLocation));
            ResourceGroupResource rg = rgLro.Value;

            // Create an app service plan
            AppServicePlanCollection appServicePlans = rg.GetAppServicePlans();
            string planName = Recording.GenerateAssetName("testAppServicePlan");
            AppServicePlanData planData = ResourceDataHelper.GetBasicAppServicePlanData(DefaultLocation);
            var planLro = await appServicePlans.CreateOrUpdateAsync(WaitUntil.Completed, planName, planData);
            AppServicePlanResource appServicePlan = planLro.Value;

            // Create the web site
            WebSiteCollection webSites = rg.GetWebSites();
            string webSitename = Recording.GenerateAssetName("testSite");
            WebSiteData webSiteData = new WebSiteData(DefaultLocation)
            {
                AppServicePlanId = appServicePlan.Id,
            };
            var webSiteLro = await webSites.CreateOrUpdateAsync(WaitUntil.Completed, webSitename, webSiteData);
            WebSiteResource webSite = webSiteLro.Value;

            // Construct the vault client to get the X509ThumbPrint
            var vaultClient = GetCertificateClient();
            var certificate = await vaultClient.GetCertificateAsync("188544910");
            var x509ThumbPrint = certificate.Value.Properties.X509Thumbprint;
#if NET5_0_OR_GREATER
            string thumbprint = Convert.ToHexString(x509ThumbPrint);
#else
            string thumbprint = BitConverter.ToString(x509ThumbPrint).Replace("-", string.Empty);
#endif

            // Create the sith host name binding
            SiteHostNameBindingCollection siteHostNameBindings = webSite.GetSiteHostNameBindings();
            string siteHostNameBindingsName = Recording.GenerateAssetName("testSiteHostNameBinding");
            HostNameBindingData hostNameBindingData = new HostNameBindingData()
            {
                SiteName = webSite.Data.Name,
                CustomHostNameDnsRecordType = CustomHostNameDnsRecordType.CName,
                HostNameType = AppServiceHostNameType.Verified,
                SslState = HostNameBindingSslState.SniEnabled,
                Thumbprint = BinaryData.FromString($"\"{thumbprint}\""),
            };
            var hostNameBindingLro = await siteHostNameBindings.CreateOrUpdateAsync(WaitUntil.Completed, siteHostNameBindingsName, hostNameBindingData);
            SiteHostNameBindingResource siteHostNameBinding = hostNameBindingLro.Value;
        }

        private CertificateClient GetCertificateClient()
        {
            return InstrumentClient(new CertificateClient(new Uri(VaultUri), TestEnvironment.Credential));
        }
    }
}
