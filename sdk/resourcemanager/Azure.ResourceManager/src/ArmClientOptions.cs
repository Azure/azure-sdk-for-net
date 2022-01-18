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
        private IDictionary<ResourceType, string> ResourceApiVersionOverrides { get; } = new Dictionary<ResourceType, string>();

        internal ConcurrentDictionary<string, Dictionary<string, string>> ResourceApiVersions { get; } = new ConcurrentDictionary<string, Dictionary<string, string>>();
        internal ConcurrentDictionary<string, string> NamespaceVersions { get; } = new ConcurrentDictionary<string, string>();

        /// <summary>
        /// Gets the ApiVersions object
        /// </summary>
        public string Scope { get; set; } = "https://management.core.windows.net/.default";

        /// <summary>
        /// Sets the api version to use for a given resource type.
        /// </summary>
        /// <param name="resourceType"> The resource type to set the version for. </param>
        /// <param name="apiVersion"> The api version to use. </param>
        public void SetApiVersion(ResourceType resourceType, string apiVersion)
        {
            Argument.AssertNotNullOrEmpty(apiVersion, nameof(apiVersion));

            ResourceApiVersionOverrides[resourceType] = apiVersion;
        }

        /// <summary>
        /// Gets the api version override if it has been set for the current client options.
        /// </summary>
        /// <param name="resourceType"> The resource type to get the version for. </param>
        /// <param name="apiVersion"> The api version to variable to set. </param>
        public bool TryGetApiVersion(ResourceType resourceType, out string apiVersion)
        {
            return ResourceApiVersionOverrides.TryGetValue(resourceType, out apiVersion);
        }

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
