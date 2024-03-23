// Copyright The OpenTelemetry Authors
// SPDX-License-Identifier: Apache-2.0

#nullable enable

using System.Text.Json.Serialization;
using OpenTelemetry.Trace;

namespace OpenTelemetry.ResourceDetectors.Azure;

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

    [JsonPropertyName("sku")]
    public string? Sku { get; set; }

    [JsonPropertyName("subscriptionId")]
    public string? SubscriptionId { get; set; }

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
            case ResourceSemanticConventions.AttributeHostName:
                amsValue = this.Name;
                break;
            case ResourceSemanticConventions.AttributeHostType:
                amsValue = this.VmSize;
                break;
            case ResourceSemanticConventions.AttributeOsType:
                amsValue = this.OsType;
                break;
            case ResourceSemanticConventions.AttributeOsVersion:
                amsValue = this.Version;
                break;
            case ResourceAttributeConstants.AzureVmScaleSetName:
                amsValue = this.VmScaleSetName;
                break;
            case ResourceAttributeConstants.AzureVmSku:
                amsValue = this.Sku;
                break;
        }

        amsValue ??= string.Empty;

        return amsValue;
    }
}
