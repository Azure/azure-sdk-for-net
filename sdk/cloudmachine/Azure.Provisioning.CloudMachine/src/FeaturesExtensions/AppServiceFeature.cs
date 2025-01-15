// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Provisioning.Expressions;
using Azure.Provisioning.AppService;
using Azure.Provisioning.Primitives;
using Azure.Provisioning.Resources;
using Azure.CloudMachine.Core;

namespace Azure.CloudMachine.AppService;

public class AppServiceFeature : CloudMachineFeature
{
    public AppServiceSkuDescription Sku { get; set; }

    public AppServiceFeature()
    {
        Sku = new AppServiceSkuDescription { Tier = "Free", Name = "F1" };
    }

    protected override ProvisionableResource EmitResources(CloudMachineInfrastructure infrastructure)
    {
        //Add a App Service to the CloudMachine infrastructure.
        AppServicePlan hostingPlan = new("cm_hosting_plan")
        {
            Name = infrastructure.Id,
            Sku = Sku,
            Kind = "app"
        };
        infrastructure.AddResource(hostingPlan);

        WebSite appService = new("cm_website")
        {
            Name = infrastructure.Id,
            Kind = "app",
            Tags = { { "azd-service-name", infrastructure.Id } },
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
                    // This is used by the CloudMachineWorkspace to detect that it is running in a deployed App Service.
                    // The ClientId is used to create a ManagedIdentityCredential so that it wires up to our CloudMachine user-assigned identity.
                    new AppServiceNameValuePair
                    {
                        Name = "CLOUDMACHINE_MANAGED_IDENTITY_CLIENT_ID",
                        Value = infrastructure.Identity.ClientId
                    },
                ]
            }
        };
        infrastructure.AddResource(appService);

        return appService;
    }
}
