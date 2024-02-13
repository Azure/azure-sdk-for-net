// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Provisioning.AppService;
using Azure.Provisioning.ResourceManager;

namespace Azure.Provisioning.Tests
{
    public class TestBackEndWebSite : Construct
    {
        public TestBackEndWebSite(IConstruct scope, AppServicePlan? appServicePlan = null)
            : base(scope, nameof(TestBackEndWebSite))
        {
            if (ResourceGroup is null)
            {
                ResourceGroup = new ResourceGroup(scope, "rg");
            }

            appServicePlan = UseExistingResource(appServicePlan, () => scope.AddAppServicePlan(ResourceGroup));

            WebSite backEnd = new WebSite(this, "backEnd", appServicePlan, WebSiteRuntime.Dotnetcore, "6.0");
        }
    }
}
