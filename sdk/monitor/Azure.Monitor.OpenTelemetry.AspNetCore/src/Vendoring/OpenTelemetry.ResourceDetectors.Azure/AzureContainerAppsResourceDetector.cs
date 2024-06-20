// Copyright The OpenTelemetry Authors
// SPDX-License-Identifier: Apache-2.0

using System;
using System.Collections.Generic;
using OpenTelemetry.Resources;
using OpenTelemetry.Trace;

namespace OpenTelemetry.ResourceDetectors.Azure;

/// <summary>
/// Resource detector for Azure Container Apps environment.
/// </summary>
internal sealed class AzureContainerAppsResourceDetector : IResourceDetector
{
    internal static readonly IReadOnlyDictionary<string, string> AzureContainerResourceAttributes = new Dictionary<string, string>
    {
        { ResourceSemanticConventions.AttributeServiceInstance, ResourceAttributeConstants.AzureContainerAppsReplicaNameEnvVar },
        { ResourceSemanticConventions.AttributeServiceVersion, ResourceAttributeConstants.AzureContainerAppsRevisionEnvVar },
    };

    /// <inheritdoc/>
    public Resource Detect()
    {
        List<KeyValuePair<string, object>> attributeList = new();

        try
        {
            var containerAppName = Environment.GetEnvironmentVariable(ResourceAttributeConstants.AzureContainerAppsNameEnvVar);

            if (containerAppName != null)
            {
                attributeList.Add(new KeyValuePair<string, object>(ResourceSemanticConventions.AttributeServiceName, containerAppName));
                attributeList.Add(new KeyValuePair<string, object>(ResourceSemanticConventions.AttributeCloudProvider, ResourceAttributeConstants.AzureCloudProviderValue));
                attributeList.Add(new KeyValuePair<string, object>(ResourceSemanticConventions.AttributeCloudPlatform, ResourceAttributeConstants.AzureContainerAppsPlatformValue));

                foreach (var kvp in AzureContainerResourceAttributes)
                {
                    var attributeValue = Environment.GetEnvironmentVariable(kvp.Value);
                    if (attributeValue != null)
                    {
                        attributeList.Add(new KeyValuePair<string, object>(kvp.Key, attributeValue));
                    }
                }
            }
        }
        catch
        {
            // TODO: log exception.
            return Resource.Empty;
        }

        return new Resource(attributeList);
    }
}
