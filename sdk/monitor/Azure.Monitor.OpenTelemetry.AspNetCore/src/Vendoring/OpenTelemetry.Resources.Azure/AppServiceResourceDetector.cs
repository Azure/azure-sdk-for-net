// Copyright The OpenTelemetry Authors
// SPDX-License-Identifier: Apache-2.0

using OpenTelemetry.Trace;

namespace OpenTelemetry.Resources.Azure;

/// <summary>
/// Resource detector for Azure AppService environment.
/// </summary>
internal sealed class AppServiceResourceDetector : IResourceDetector
{
    internal static readonly IReadOnlyDictionary<string, string> AppServiceResourceAttributes = new Dictionary<string, string>
    {
        { ResourceSemanticConventions.AttributeCloudRegion, ResourceAttributeConstants.AppServiceRegionNameEnvVar },
        { ResourceSemanticConventions.AttributeDeploymentEnvironment, ResourceAttributeConstants.AppServiceSlotNameEnvVar },
        { ResourceSemanticConventions.AttributeHostId, ResourceAttributeConstants.AppServiceHostNameEnvVar },
        { ResourceSemanticConventions.AttributeServiceInstance, ResourceAttributeConstants.AppServiceInstanceIdEnvVar },
        { ResourceAttributeConstants.AzureAppServiceStamp, ResourceAttributeConstants.AppServiceStampNameEnvVar },
    };

    /// <inheritdoc/>
    public Resource Detect()
    {
        List<KeyValuePair<string, object>> attributeList = [];

        try
        {
            var websiteSiteName = Environment.GetEnvironmentVariable(ResourceAttributeConstants.AppServiceSiteNameEnvVar);

            if (websiteSiteName != null)
            {
                attributeList.Add(new KeyValuePair<string, object>(ResourceSemanticConventions.AttributeServiceName, websiteSiteName));
                attributeList.Add(new KeyValuePair<string, object>(ResourceSemanticConventions.AttributeCloudProvider, ResourceAttributeConstants.AzureCloudProviderValue));
                attributeList.Add(new KeyValuePair<string, object>(ResourceSemanticConventions.AttributeCloudPlatform, ResourceAttributeConstants.AzureAppServicePlatformValue));

                var azureResourceUri = GetAzureResourceURI(websiteSiteName);
                if (azureResourceUri != null)
                {
                    attributeList.Add(new KeyValuePair<string, object>(ResourceSemanticConventions.AttributeCloudResourceId, azureResourceUri));
                }

                foreach (var kvp in AppServiceResourceAttributes)
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

    private static string? GetAzureResourceURI(string websiteSiteName)
    {
        var websiteResourceGroup = Environment.GetEnvironmentVariable(ResourceAttributeConstants.AppServiceResourceGroupEnvVar);
        var websiteOwnerName = Environment.GetEnvironmentVariable(ResourceAttributeConstants.AppServiceOwnerNameEnvVar) ?? string.Empty;

#if NET
        var idx = websiteOwnerName.IndexOf('+', StringComparison.Ordinal);
#else
        var idx = websiteOwnerName.IndexOf("+", StringComparison.Ordinal);
#endif
        var subscriptionId = idx > 0 ? websiteOwnerName.Substring(0, idx) : websiteOwnerName;

        return string.IsNullOrEmpty(websiteResourceGroup) || string.IsNullOrEmpty(subscriptionId)
            ? null
            : $"/subscriptions/{subscriptionId}/resourceGroups/{websiteResourceGroup}/providers/Microsoft.Web/sites/{websiteSiteName}";
    }
}
