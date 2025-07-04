// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text.Json;
using Azure.Core;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager;

namespace Azure.ResourceManager
{
    /// <summary>
    /// A class representing Azure resource manager client options.
    /// </summary>
#pragma warning disable AZC0008 // ClientOptions should have a nested enum called ServiceVersion
    public sealed class ArmClientOptions : ClientOptions
#pragma warning restore AZC0008 // ClientOptions should have a nested enum called ServiceVersion
    {
        internal IDictionary<ResourceType, string> ResourceApiVersionOverrides { get; } = new Dictionary<ResourceType, string>();

        /// <summary>
        /// Gets or sets Azure cloud environment.
        /// </summary>
        public ArmEnvironment? Environment { get; set; }

        /// <summary>
        /// Sets the api version to use for a given resource type.
        /// To find which API Versions are available in your environment you can use the <see cref="ResourceProviderResource.Get"/> method
        /// for the provider namespace you are interested in.
        /// </summary>
        /// <param name="resourceType"> The resource type to set the version for. To determine the appropriate value, you can refer to the corresponding documentation or XML documentation comments of the API. Then, get its resource type from the Resource's ResourceType field.</param>
        /// <param name="apiVersion"> The api version to use. </param>
        public void SetApiVersion(ResourceType resourceType, string apiVersion)
        {
            Argument.AssertNotNullOrEmpty(apiVersion, nameof(apiVersion));

            ResourceApiVersionOverrides[resourceType] = apiVersion;
        }

        /// <summary>
        /// Sets the api versions from an Azure Stack profile.
        /// </summary>
        public void SetApiVersionsFromProfile(AzureStackProfile profile)
        {
            var assembly = Assembly.GetExecutingAssembly();
            using (Stream stream = assembly.GetManifestResourceStream(profile.GetManifestName()))
            {
                var span = BinaryData.FromStream(stream).ToMemory().Span;
                var allProfile = JsonSerializer.Deserialize<Dictionary<string, Dictionary<string, JsonElement>>>(span, ArmClientOptionsJsonContext.Default.DictionaryStringDictionaryStringJsonElement);
                var armProfile = allProfile["resource-manager"];
                foreach (var keyValuePair in armProfile)
                {
                    var namespaceName = keyValuePair.Key;
                    var element = keyValuePair.Value;

                    foreach (var apiVersionProperty in element.EnumerateObject())
                    {
                        var apiVersion = apiVersionProperty.Name;
                        foreach (var resourceTypeItem in apiVersionProperty.Value.EnumerateArray())
                        {
                            string resourceTypeName = default;
                            foreach (var property in resourceTypeItem.EnumerateObject())
                            {
                                if (property.NameEquals("resourceType"))
                                {
                                    resourceTypeName = property.Value.GetString();
                                    break;
                                }
                            }
                            var resourceType = $"{namespaceName}/{resourceTypeName}";
                            ResourceApiVersionOverrides[resourceType] = apiVersion;
                        }
                    }
                }
            }
        }
    }
}
