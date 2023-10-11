// <copyright file="AppServiceResourceDetector.cs" company="OpenTelemetry Authors">
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

#nullable enable

using System;
using System.Collections.Generic;
using OpenTelemetry.Resources;
using OpenTelemetry.Trace;

namespace OpenTelemetry.ResourceDetectors.Azure;

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
        List<KeyValuePair<string, object>> attributeList = new();

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
        string websiteResourceGroup = Environment.GetEnvironmentVariable(ResourceAttributeConstants.AppServiceResourceGroupEnvVar);
        string websiteOwnerName = Environment.GetEnvironmentVariable(ResourceAttributeConstants.AppServiceOwnerNameEnvVar) ?? string.Empty;

        int idx = websiteOwnerName.IndexOf('+');
        string subscriptionId = idx > 0 ? websiteOwnerName.Substring(0, idx) : websiteOwnerName;

        if (string.IsNullOrEmpty(websiteResourceGroup) || string.IsNullOrEmpty(subscriptionId))
        {
            return null;
        }

        return $"/subscriptions/{subscriptionId}/resourceGroups/{websiteResourceGroup}/providers/Microsoft.Web/sites/{websiteSiteName}";
    }
}
