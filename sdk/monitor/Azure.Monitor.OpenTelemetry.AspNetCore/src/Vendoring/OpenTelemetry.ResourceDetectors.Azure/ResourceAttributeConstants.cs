// <copyright file="ResourceAttributeConstants.cs" company="OpenTelemetry Authors">
// Copyright The OpenTelemetry Authors
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
//     http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
// </copyright>

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

    // Azure resource attributes constant values
    internal const string AzureAppServicePlatformValue = "azure_app_service";
    internal const string AzureCloudProviderValue = "azure";
    internal const string AzureVmCloudPlatformValue = "azure_vm";
}
