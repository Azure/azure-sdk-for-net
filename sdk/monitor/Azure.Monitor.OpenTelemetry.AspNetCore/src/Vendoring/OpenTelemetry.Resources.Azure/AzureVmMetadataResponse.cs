// Copyright The OpenTelemetry Authors
// SPDX-License-Identifier: Apache-2.0

using System.Text.Json.Serialization;
using OpenTelemetry.Trace;

namespace OpenTelemetry.Resources.Azure;

internal sealed class AzureVmMetadataResponse
{
    [JsonPropertyName("location")]
    public string? Location { get; set; }

    [JsonPropertyName("name")]
    public string? Name { get; set; }

    [JsonPropertyName("osType")]
    public string? OsType { get; set; }

    [JsonPropertyName("resourceGroupName")]
    public string? ResourceGroupName { get; set; }

    [JsonPropertyName("resourceId")]
    public string? ResourceId { get; set; }

    [JsonPropertyName("subscriptionId")]
    public string? SubscriptionId { get; set; }

    [JsonPropertyName("storageProfile")]
    public AzureVmStorageProfile? StorageProfile { get; set; }

    [JsonPropertyName("version")]
    public string? Version { get; set; }

    [JsonPropertyName("vmId")]
    public string? VmId { get; set; }

    [JsonPropertyName("vmScaleSetName")]
    public string? VmScaleSetName { get; set; }

    [JsonPropertyName("vmSize")]
    public string? VmSize { get; set; }

    internal string GetValueForField(string fieldName)
    {
        string? amsValue = null;
        switch (fieldName)
        {
            case ResourceSemanticConventions.AttributeCloudAccount:
                amsValue = this.SubscriptionId;
                break;
            case ResourceSemanticConventions.AttributeCloudPlatform:
                amsValue = ResourceAttributeConstants.AzureVmCloudPlatformValue;
                break;
            case ResourceSemanticConventions.AttributeCloudProvider:
                amsValue = ResourceAttributeConstants.AzureCloudProviderValue;
                break;
            case ResourceSemanticConventions.AttributeCloudRegion:
                amsValue = this.Location;
                break;
            case ResourceSemanticConventions.AttributeCloudResourceId:
                amsValue = this.ResourceId;
                break;
            case ResourceSemanticConventions.AttributeHostId:
            case ResourceSemanticConventions.AttributeServiceInstance:
                amsValue = this.VmId;
                break;
            case ResourceSemanticConventions.AttributeHostImageId:
                amsValue = this.StorageProfile?.ImageReference?.Id;
                break;
            case ResourceSemanticConventions.AttributeHostImageName:
                if (this.StorageProfile?.ImageReference is { } imageReference
                    && !string.IsNullOrEmpty(imageReference.Publisher)
                    && !string.IsNullOrEmpty(imageReference.Offer)
                    && !string.IsNullOrEmpty(imageReference.Sku))
                {
                    amsValue = $"{imageReference.Publisher}:{imageReference.Offer}:{imageReference.Sku}";
                }

                break;
            case ResourceSemanticConventions.AttributeHostImageVersion:
            case ResourceSemanticConventions.AttributeOsVersion:
                amsValue = this.Version;
                break;
            case ResourceSemanticConventions.AttributeHostName:
                amsValue = this.Name;
                break;
            case ResourceSemanticConventions.AttributeHostType:
                amsValue = this.VmSize;
                break;
            case ResourceSemanticConventions.AttributeOsType:
#pragma warning disable CA1308 // Normalize strings to uppercase
                // The os.type value must be lowercase per the semantic conventions.
                amsValue = this.OsType?.ToLowerInvariant();
#pragma warning restore CA1308 // Normalize strings to uppercase
                break;
            case ResourceAttributeConstants.AzureResourceGroupName:
                amsValue = this.ResourceGroupName;
                break;
            case ResourceAttributeConstants.AzureVmScaleSetName:
                amsValue = this.VmScaleSetName;
                break;
            default:
                break;
        }

        amsValue ??= string.Empty;

        return amsValue;
    }
}
