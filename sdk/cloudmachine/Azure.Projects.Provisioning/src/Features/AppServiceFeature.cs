// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Projects.Core;
using Azure.Provisioning.AppService;
using Azure.Provisioning.Expressions;
using Azure.Provisioning.Resources;

namespace Azure.Projects;

public class AppServiceFeature : AzureProjectFeature
{
    public AppServiceSkuDescription Sku { get; set; }

    public AppServiceFeature()
    {
        Sku = new AppServiceSkuDescription { Tier = "Free", Name = "F1" };
    }

    protected internal override void EmitConstructs(ProjectInfrastructure infrastructure)
    {
        //Add a App Service to the infrastructure.
        AppServicePlan hostingPlan = new("appServicePlan", AppServicePlan.ResourceVersions.V2024_04_01)
        {
            Name = infrastructure.ProjectId,
            Sku = Sku,
            Kind = "app"
        };
        infrastructure.AddConstruct(Id + "_plan", hostingPlan);

        WebSite appService = new("appServiceWebsite", WebSite.ResourceVersions.V2024_04_01)
        {
            Name = infrastructure.ProjectId,
            Kind = "app",
            Tags = { { "azd-service-name", infrastructure.ProjectId } },
            Identity = new()
            {
                ManagedServiceIdentityType = ManagedServiceIdentityType.UserAssigned,
                UserAssignedIdentities = { { BicepFunction.Interpolate($"{infrastructure.Identity.Id}").Compile().ToString(), new UserAssignedIdentityDetails() } }
            },
            AppServicePlanId = hostingPlan.Id,
            IsHttpsOnly = true,
            IsEnabled = true,
            SiteConfig = new()
            {
                IsHttp20Enabled = true,
                MinTlsVersion = AppServiceSupportedTlsVersion.Tls1_2,
                IsWebSocketsEnabled = true,
                AppSettings =
                [
                    // This is used by the ClientWorkspace to detect that it is running in a deployed App Service.
                    // The ClientId is used to create a ManagedIdentityCredential so that it wires up to our project user-assigned identity.
                    new AppServiceNameValuePair
                    {
                        Name = "CLOUDMACHINE_MANAGED_IDENTITY_CLIENT_ID",
                        Value = infrastructure.Identity.ClientId
                    },
                ]
            }
        };
        infrastructure.AddConstruct(Id, appService);
    }
}
