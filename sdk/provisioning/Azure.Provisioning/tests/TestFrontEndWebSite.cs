// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Provisioning.AppService;
using Azure.Provisioning.KeyVaults;
using Azure.Provisioning.ResourceManager;

namespace Azure.Provisioning.Tests
{
    public class TestFrontEndWebSite : Construct
    {
        public TestFrontEndWebSite(IConstruct scope, KeyVault? keyVault = null, AppServicePlan? appServicePlan = null, ResourceGroup? parent = null)
            : base(scope, nameof(TestFrontEndWebSite), resourceGroup: parent ?? new ResourceGroup(scope, "rg"))
        {
            appServicePlan = UseExistingResource(appServicePlan, () => scope.AddAppServicePlan(ResourceGroup));
            keyVault = UseExistingResource(keyVault, () => scope.AddKeyVault(ResourceGroup));

            WebSite frontEnd = new WebSite(this, "frontEnd", appServicePlan, WebSiteRuntime.Node, "18-lts");
            var frontEndPrincipalId = frontEnd.AddOutput(
                website => website.Identity.PrincipalId,
                "SERVICE_API_IDENTITY_PRINCIPAL_ID",
                isSecure: true);

            keyVault.AddAccessPolicy(frontEndPrincipalId);

            WebSiteConfigLogs logs = new WebSiteConfigLogs(this, "logs", frontEnd);
        }
    }
}
