// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Provisioning.AppService;
using Azure.Provisioning.KeyVaults;
using Azure.Provisioning.ResourceManager;

namespace Azure.Provisioning.Tests
{
    public static class TestExtensions
    {
        public static TestFrontEndWebSite AddFrontEndWebSite(this IConstruct construct, KeyVault? keyVault = null, AppServicePlan? appServicePlan = null, ResourceGroup? resourceGroup = null)
        {
            return new TestFrontEndWebSite(construct, keyVault, appServicePlan, resourceGroup);
        }

        public static TestCommonSqlDatabase AddCommonSqlDatabase(this IConstruct construct, KeyVault? keyVault = null)
        {
            return new TestCommonSqlDatabase(construct, keyVault);
        }

        public static TestBackEndWebSite AddBackEndWebSite(this IConstruct construct, AppServicePlan? appServicePlan = null)
        {
            return new TestBackEndWebSite(construct, appServicePlan);
        }

        public static TestWebSiteWithSqlBackEnd AddWebSiteWithSqlBackEnd(this IConstruct construct)
        {
            return new TestWebSiteWithSqlBackEnd(construct);
        }
    }
}
