// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Provisioning.Generator.Model;
using Azure.ResourceManager.AppService;
using Azure.ResourceManager.AppService.Models;
using Generator.Model;
using System;
using System.Collections.Generic;
using System.Reflection;

namespace Azure.Provisioning.Generator.Specifications;

public class AppServiceSpecification() :
    Specification("AppService", typeof(AppServiceExtensions))
{
    protected override void Customize()
    {
        // Remove misfires
        RemoveProperty<AppCertificateResource>("Thumbprint");
        RemoveProperty<AppServiceSourceControlResource>("SourceControlType");
        RemoveProperty<SiteDeploymentResource>("Id");
        RemoveProperty<SiteHostNameBindingResource>("Thumbprint");
        RemoveProperty<SiteHybridConnectionNamespaceRelayResource>("RelayArmUri");
        RemoveProperty<SitePublicCertificateResource>("Thumbprint");
        RemoveProperty<SiteSlotDeploymentResource>("Id");
        RemoveProperty<SiteSlotHostNameBindingResource>("Thumbprint");
        RemoveProperty<SiteSlotHybridConnectionNamespaceRelayResource>("RelayArmUri");
        RemoveProperty<SiteSlotVirtualNetworkConnectionResource>("CertThumbprint");
        RemoveProperty<SiteVirtualNetworkConnectionResource>("CertThumbprint");
        RemoveProperty<StaticSiteBasicAuthPropertyResource>("BasicAuthName");
        RemoveProperty<StaticSiteBuildUserProvidedFunctionAppResource>("IsForced");
        RemoveProperty<StaticSiteUserProvidedFunctionAppResource>("IsForced");
        RemoveProperty<WebSiteExtensionResource>("SiteExtensionId");
        RemoveProperty<WebSiteSlotExtensionResource>("SiteExtensionId");
        RemoveProperty<WebSiteSlotPublicCertificateResource>("Thumbprint");
        RemoveProperty<WebSiteSlotResource>("Slot");
        RemoveProperty<AppServiceCertificateDetails>("Thumbprint");
        RemoveProperty<AppServiceTableStorageApplicationLogsConfig>("SasUri");
        RemoveProperty<AppServiceVirtualNetworkRoute>("ResourceType");
        RemoveProperty<ResponseMessageEnvelopeRemotePrivateEndpointConnection>("ResourceType");
        RemoveProperty<RemotePrivateEndpointConnection>("ResourceType");
        RemoveProperty<WebAppPushSettings>("ResourceType");
        RemoveProperty<HostNameSslState>("Thumbprint");

        CustomizeResource<SiteAuthSettingsV2>(r =>
        {
            r.ResourceType = "Microsoft.Web/sites/config";
        });
        CustomizeProperty<SiteAuthSettingsV2>("Name", p => { p.GenerateDefaultValue = true; p.HideAccessors = true; p.IsReadOnly = false; }); // must be `authsettingsV2`

        // Not generated today:
        // CustomizePropertyIsoDuration<MetricAvailability>("BlobDuration");
        // CustomizePropertyIsoDuration<LogSpecification>("BlobDuration");
        CustomizeProperty<FunctionAppAlwaysReadyConfig>("InstanceCount", p => { p.HideLevel = PropertyHideLevel.HideProperty; });
        CustomizeProperty<FunctionAppScaleAndConcurrency>("MaximumInstanceCount", p => { p.HideLevel = PropertyHideLevel.HideProperty; });
        CustomizeProperty<FunctionAppScaleAndConcurrency>("InstanceMemoryMB", p => { p.HideLevel = PropertyHideLevel.HideProperty; });
        CustomizeProperty<FunctionAppScaleAndConcurrency>("HttpPerInstanceConcurrency", p => { p.HideLevel = PropertyHideLevel.HideProperty; });
        CustomizeProperty<WebSiteSlotResource>("Name", p => { p.IsReadOnly = false; }); // make writable for slot name
        CustomizeProperty<AppServiceEnvironmentResource>("CustomDnsSuffixConfiguration", p => { p.Name = "CustomDnsSuffixConfig"; });
        CustomizeProperty<AppServiceEnvironmentResource>("NetworkingConfiguration", p => { p.Name = "NetworkingConfig"; });
        CustomizeResource<AppServiceEnvironmentResource>(r =>
        {
            r.GeneratePartialPropertyDefinition = true;
        });
        CustomizeProperty<StaticSiteResource>("UserProvidedFunctionApps", p => { p.Name = "UserFunctionApps"; });
        CustomizeResource<StaticSiteResource>(r =>
        {
            r.GeneratePartialPropertyDefinition = true;
        });

        // Naming requirements
        AddNameRequirements<AppCertificateResource>(min: 1, max: 260, lower: true, upper: true, digits: true, hyphen: true, underscore: true, period: true, parens: false);
        AddNameRequirements<AppServicePlanResource>(min: 1, max: 60, lower: true, upper: true, digits: true, hyphen: true);
        AddNameRequirements<WebSiteResource>(min: 2, max: 60, lower: true, upper: true, digits: true, hyphen: true);
        AddNameRequirements<WebSiteSlotResource>(min: 2, max: 59, lower: true, upper: true, digits: true, hyphen: true);
        AddNameRequirements<SitePrivateEndpointConnectionResource>(min: 2, max: 64, lower: true, upper: true, digits: true, hyphen: true, underscore: true, period: true);

        // Roles
        Roles.Add(new Role("WebPlanContributor", "2cc479cb-7b4d-49a8-b449-8c00fd0f0a4b", "Manage the web plans for websites. Does not allow you to assign roles in Azure RBAC."));
        Roles.Add(new Role("WebsiteContributor", "de139f84-1756-47ae-9be6-808fbbe84772", "Manage websites, but not web plans. Does not allow you to assign roles in Azure RBAC."));
    }

    private protected override Dictionary<Type, MethodInfo> FindConstructibleResources()
    {
        // Add missing resources
        var dict = base.FindConstructibleResources();
        dict.Add(typeof(SiteAuthSettingsV2), typeof(WebSiteResource).GetMethod("UpdateAuthSettingsV2")!);
        return dict;
    }
}
