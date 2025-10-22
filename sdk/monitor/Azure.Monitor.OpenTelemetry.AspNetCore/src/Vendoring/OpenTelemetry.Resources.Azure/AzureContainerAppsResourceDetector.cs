// Copyright The OpenTelemetry Authors
// SPDX-License-Identifier: Apache-2.0

using OpenTelemetry.Trace;

namespace OpenTelemetry.Resources.Azure;

/// <summary>
/// Resource detector for Azure Container Apps environment.
/// </summary>
internal sealed class AzureContainerAppsResourceDetector : IResourceDetector
{
    internal static readonly IReadOnlyDictionary<string, string> AzureContainerAppResourceAttributes = new Dictionary<string, string>
    {
        { ResourceSemanticConventions.AttributeServiceInstance, ResourceAttributeConstants.AzureContainerAppsReplicaNameEnvVar },
        { ResourceSemanticConventions.AttributeServiceVersion, ResourceAttributeConstants.AzureContainerAppsRevisionEnvVar },
    };

    internal static readonly IReadOnlyDictionary<string, string> AzureContainerAppJobResourceAttributes = new Dictionary<string, string>
    {
        { ResourceSemanticConventions.AttributeServiceInstance, ResourceAttributeConstants.AzureContainerAppsReplicaNameEnvVar },
        { ResourceSemanticConventions.AttributeServiceVersion, ResourceAttributeConstants.AzureContainerAppJobExecutionNameEnvVar },
    };

    /// <inheritdoc/>
    public Resource Detect()
    {
        List<KeyValuePair<string, object>> attributeList = [];
        try
        {
            var containerAppName = Environment.GetEnvironmentVariable(ResourceAttributeConstants.AzureContainerAppsNameEnvVar);
            var containerAppJobName = Environment.GetEnvironmentVariable(ResourceAttributeConstants.AzureContainerAppJobNameEnvVar);

            if (containerAppName != null)
            {
                AddBaseAttributes(attributeList, containerAppName);

                AddResourceAttributes(attributeList, AzureContainerAppResourceAttributes);
            }
            else if (containerAppJobName != null)
            {
                AddBaseAttributes(attributeList, containerAppJobName);

                AddResourceAttributes(attributeList, AzureContainerAppJobResourceAttributes);
            }
        }
        catch
        {
            // TODO: log exception.
            return Resource.Empty;
        }

        return new Resource(attributeList);
    }

    private static void AddResourceAttributes(List<KeyValuePair<string, object>> attributeList, IReadOnlyDictionary<string, string> resourceAttributes)
    {
        foreach (var kvp in resourceAttributes)
        {
            var attributeValue = Environment.GetEnvironmentVariable(kvp.Value);
            if (attributeValue != null)
            {
                attributeList.Add(new KeyValuePair<string, object>(kvp.Key, attributeValue));
            }
        }
    }

    private static void AddBaseAttributes(List<KeyValuePair<string, object>> attributeList, string serviceName)
    {
        attributeList.Add(new KeyValuePair<string, object>(ResourceSemanticConventions.AttributeServiceName, serviceName));
        attributeList.Add(new KeyValuePair<string, object>(ResourceSemanticConventions.AttributeCloudProvider, ResourceAttributeConstants.AzureCloudProviderValue));
        attributeList.Add(new KeyValuePair<string, object>(ResourceSemanticConventions.AttributeCloudPlatform, ResourceAttributeConstants.AzureContainerAppsPlatformValue));
    }
}
