// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.ComponentModel;
using Azure.Core;

namespace Azure.ResourceManager
{
    /// <summary>
    /// A class representing Azure resource manager client options.
    /// </summary>
#pragma warning disable AZC0008 // ClientOptions should have a nested enum called ServiceVersion
    public sealed class ArmClientOptions : ClientOptions
#pragma warning restore AZC0008 // ClientOptions should have a nested enum called ServiceVersion
    {
        /// <summary>
        /// Gets the ApiVersions object
        /// </summary>
        public string Scope { get; set; } = "https://management.core.windows.net/.default";

        internal IDictionary<ResourceType, string> ResourceApiVersionOverrides { get; } = new Dictionary<ResourceType, string>();

        /// <summary>
        /// Sets the api version to use for a given resource type.
        /// </summary>
        /// <param name="resourceType"> The resource type to set the version for. </param>
        /// <param name="apiVersion"> The api version to use. </param>
        public void SetApiVersion(ResourceType resourceType, string apiVersion)
        {
            ResourceApiVersionOverrides[resourceType] = apiVersion;
        }

        internal ConcurrentDictionary<string, Dictionary<string, string>> ResourceApiVersions { get; } = new ConcurrentDictionary<string, Dictionary<string, string>>();
        internal ConcurrentDictionary<string,string> NamespaceVersions { get; } = new ConcurrentDictionary<string, string>();

        internal ArmClientOptions Clone()
        {
            ArmClientOptions copy = new ArmClientOptions();

            copy.Transport = Transport;

            //copy overrrides
            CopyApiVersions(copy, ResourceApiVersionOverrides);

            foreach (var keyValuePair in ResourceApiVersionOverrides)
            {
                copy.ResourceApiVersionOverrides.Add(keyValuePair.Key, keyValuePair.Value);
            }

            return copy;
        }

        private static void CopyApiVersions(ArmClientOptions copy, IDictionary<ResourceType, string> source)
        {
            foreach (var resourceType in source)
            {
                if (!copy.ResourceApiVersions.TryGetValue(resourceType.Key.Namespace, out var versionOverrides))
                {
                    versionOverrides = new Dictionary<string, string>();
                    copy.ResourceApiVersions.TryAdd(resourceType.Key.Namespace, versionOverrides);
                }
                versionOverrides[resourceType.Key.Type] = resourceType.Value;
            }
        }
    }
}
