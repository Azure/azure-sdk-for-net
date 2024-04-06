// Copyright The OpenTelemetry Authors
// SPDX-License-Identifier: Apache-2.0

namespace OpenTelemetry.ResourceDetectors.Azure;

internal sealed class ResourceAttributeConstants
{
    // AppService resource attributes
    internal const string AzureAppServiceStamp = "azure.app.service.stamp";

    // Azure VM resource attributes
    internal const string AzureVmScaleSetName = "azure.vm.scaleset.name";
    internal const string AzureVmSku = "azure.vm.sku";

    // AppService environment variables
    internal const string AppServiceHostNameEnvVar = "WEBSITE_HOSTNAME";
    internal const string AppServiceInstanceIdEnvVar = "WEBSITE_INSTANCE_ID";
    internal const string AppServiceOwnerNameEnvVar = "WEBSITE_OWNER_NAME";
    internal const string AppServiceRegionNameEnvVar = "REGION_NAME";
    internal const string AppServiceResourceGroupEnvVar = "WEBSITE_RESOURCE_GROUP";
    internal const string AppServiceSiteNameEnvVar = "WEBSITE_SITE_NAME";
    internal const string AppServiceSlotNameEnvVar = "WEBSITE_SLOT_NAME";
    internal const string AppServiceStampNameEnvVar = "WEBSITE_HOME_STAMPNAME";

    // Azure Container Apps environment variables
    internal const string AzureContainerAppsNameEnvVar = "CONTAINER_APP_NAME";
    internal const string AzureContainerAppsReplicaNameEnvVar = "CONTAINER_APP_REPLICA_NAME";
    internal const string AzureContainerAppsRevisionEnvVar = "CONTAINER_APP_REVISION";

    // Azure resource attributes constant values
    internal const string AzureAppServicePlatformValue = "azure_app_service";
    internal const string AzureCloudProviderValue = "azure";
    internal const string AzureVmCloudPlatformValue = "azure_vm";
    internal const string AzureContainerAppsPlatformValue = "azure_container_apps";
}
