// Copyright The OpenTelemetry Authors
// SPDX-License-Identifier: Apache-2.0

#nullable enable

using System.Collections.Generic;
using OpenTelemetry.Resources;
using OpenTelemetry.Trace;

namespace OpenTelemetry.ResourceDetectors.Azure;

/// <summary>
/// Resource detector for Azure VM environment.
/// </summary>
internal sealed class AzureVMResourceDetector : IResourceDetector
{
    internal static readonly IReadOnlyCollection<string> ExpectedAzureAmsFields = new string[]
    {
        ResourceAttributeConstants.AzureVmScaleSetName,
        ResourceAttributeConstants.AzureVmSku,
        ResourceSemanticConventions.AttributeCloudPlatform,
        ResourceSemanticConventions.AttributeCloudProvider,
        ResourceSemanticConventions.AttributeCloudRegion,
        ResourceSemanticConventions.AttributeCloudResourceId,
        ResourceSemanticConventions.AttributeHostId,
        ResourceSemanticConventions.AttributeHostName,
        ResourceSemanticConventions.AttributeHostType,
        ResourceSemanticConventions.AttributeOsType,
        ResourceSemanticConventions.AttributeOsVersion,
        ResourceSemanticConventions.AttributeServiceInstance,
    };

    private static Resource? vmResource;

    /// <inheritdoc/>
    public Resource Detect()
    {
        try
        {
            if (vmResource != null)
            {
                return vmResource;
            }

            // Prevents the http operations from being instrumented.
            using var scope = SuppressInstrumentationScope.Begin();

            var vmMetaDataResponse = AzureVmMetaDataRequestor.GetAzureVmMetaDataResponse();
            if (vmMetaDataResponse == null)
            {
                vmResource = Resource.Empty;

                return vmResource;
            }

            var attributeList = new List<KeyValuePair<string, object>>(ExpectedAzureAmsFields.Count);
            foreach (var field in ExpectedAzureAmsFields)
            {
                attributeList.Add(new KeyValuePair<string, object>(field, vmMetaDataResponse.GetValueForField(field)));
            }

            vmResource = new Resource(attributeList);
        }
        catch
        {
            // TODO: log exception.
            vmResource = Resource.Empty;
        }

        return vmResource;
    }
}
