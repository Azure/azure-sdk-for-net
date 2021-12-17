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

        /// <summary>
        /// Dictionary of ResourceType to version overrides.
        /// </summary>
        public Dictionary<ResourceType, string> ResourceApiVersionOverrides { get; } = new Dictionary<ResourceType, string>();

        internal ConcurrentDictionary<string, Dictionary<string, string>> ResourceApiVersions { get; } = new ConcurrentDictionary<string, Dictionary<string, string>>();
        internal ConcurrentDictionary<string,string> NamespaceVersions { get; } = new ConcurrentDictionary<string, string>();

        internal ArmClientOptions Clone()
        {
            ArmClientOptions copy = new ArmClientOptions();

            copy.Transport = Transport;

            //copy overrrides
            CopyApiVersions(copy, ResourceApiVersionOverrides);

            return copy;
        }

        private static void CopyApiVersions(ArmClientOptions copy, Dictionary<ResourceType, string> source)
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
