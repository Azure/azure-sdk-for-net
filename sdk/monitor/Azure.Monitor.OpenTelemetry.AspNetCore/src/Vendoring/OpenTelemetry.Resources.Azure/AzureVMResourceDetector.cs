// Copyright The OpenTelemetry Authors
// SPDX-License-Identifier: Apache-2.0

using System.Diagnostics;
using OpenTelemetry.Trace;

namespace OpenTelemetry.Resources.Azure;

/// <summary>
/// Resource detector for Azure VM environment.
/// </summary>
internal sealed class AzureVMResourceDetector : IResourceDetector
{
    internal static readonly IReadOnlyCollection<string> ExpectedAzureAmsFields =
    [
        ResourceAttributeConstants.AzureVmScaleSetName,
        ResourceSemanticConventions.AttributeCloudPlatform,
        ResourceSemanticConventions.AttributeCloudProvider,
        ResourceSemanticConventions.AttributeCloudRegion,
        ResourceSemanticConventions.AttributeCloudResourceId,
        ResourceSemanticConventions.AttributeHostId,
        ResourceSemanticConventions.AttributeHostName,
        ResourceSemanticConventions.AttributeHostType,
        ResourceSemanticConventions.AttributeOsType,
        ResourceSemanticConventions.AttributeOsVersion,
        ResourceSemanticConventions.AttributeServiceInstance
    ];

    private static readonly IReadOnlyCollection<string> OmitWhenEmptyAzureAmsFields =
    [
        ResourceSemanticConventions.AttributeHostImageId,
        ResourceSemanticConventions.AttributeHostImageName,
        ResourceSemanticConventions.AttributeHostImageVersion
    ];

    private static Resource? vmResource;
    private static long lastFailedDetectionTimestamp;

    /// <summary>
    /// Gets or sets how long a failed detection is remembered for.
    /// </summary>
    /// <remarks>
    /// Remembering a failure briefly stops the providers that are usually built together at startup from each waiting for
    /// an unreachable metadata endpoint, while a transient failure does not prevent a provider built later from
    /// detecting the resource.
    /// </remarks>
    internal static TimeSpan FailedDetectionCacheDuration { get; set; } = TimeSpan.FromMinutes(1);

    /// <inheritdoc/>
    public Resource Detect()
    {
        try
        {
            if (Environment.GetEnvironmentVariable(ResourceAttributeConstants.AppServiceSiteNameEnvVar) != null)
            {
                return Resource.Empty;
            }

            if (vmResource != null)
            {
                return vmResource;
            }

            var lastFailedDetection = Volatile.Read(ref lastFailedDetectionTimestamp);
            if (lastFailedDetection != 0 && Stopwatch.GetElapsedTime(lastFailedDetection) < FailedDetectionCacheDuration)
            {
                return Resource.Empty;
            }

            // Prevents the HTTP operations from being instrumented.
            using var scope = SuppressInstrumentationScope.Begin();

            var vmMetaDataResponse = AzureVmMetaDataRequestor.GetAzureVmMetaDataResponse();
            if (vmMetaDataResponse == null)
            {
                return RecordFailedDetection();
            }

            var attributeList = new List<KeyValuePair<string, object>>(
                ExpectedAzureAmsFields.Count + OmitWhenEmptyAzureAmsFields.Count);
            foreach (var field in ExpectedAzureAmsFields)
            {
                attributeList.Add(new(field, vmMetaDataResponse.GetValueForField(field)));
            }

            var resourceGroupName = vmMetaDataResponse.GetValueForField(ResourceAttributeConstants.AzureResourceGroupName);
            if (resourceGroupName is { Length: > 0 })
            {
                attributeList.Add(new(ResourceAttributeConstants.AzureResourceGroupName, resourceGroupName));
            }

            var subscriptionId = vmMetaDataResponse.GetValueForField(ResourceSemanticConventions.AttributeCloudAccount);
            if (subscriptionId is { Length: > 0 })
            {
                attributeList.Add(new(ResourceSemanticConventions.AttributeCloudAccount, subscriptionId));
            }

            foreach (var field in OmitWhenEmptyAzureAmsFields)
            {
                var value = vmMetaDataResponse.GetValueForField(field);
                if (value.Length > 0)
                {
                    attributeList.Add(new(field, value));
                }
            }

            if (attributeList.Count == 0)
            {
                vmResource = Resource.Empty;
                return vmResource;
            }

            vmResource = new Resource(
                attributeList,
                Internal.SchemaUrls.Get(AzureResourceBuilderExtensions.SemanticConventionsVersion));

            return vmResource;
        }
        catch (Exception ex)
        {
            AzureResourcesEventSource.Log.FailedToDetectAzureVMResources(ex);
            return RecordFailedDetection();
        }
    }

    internal static void ClearCachedResource()
    {
        vmResource = null;
        Volatile.Write(ref lastFailedDetectionTimestamp, 0);
    }

    private static Resource RecordFailedDetection()
    {
        Volatile.Write(ref lastFailedDetectionTimestamp, Stopwatch.GetTimestamp());
        return Resource.Empty;
    }
}
