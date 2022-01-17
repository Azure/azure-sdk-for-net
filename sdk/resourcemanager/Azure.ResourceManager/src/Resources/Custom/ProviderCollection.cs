﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.ResourceManager.Core;

namespace Azure.ResourceManager.Resources
{
    /// <summary>
    /// A class representing collection of resources and their operations over their parent.
    /// </summary>
    public partial class ProviderCollection : ArmCollection
    {
        internal string TryGetApiVersion(ResourceType resourceType, CancellationToken cancellationToken = default)
        {
            string version;
            Dictionary<string, string> resourceVersions;
            if (!ClientOptions.ResourceApiVersions.TryGetValue(resourceType.Namespace, out resourceVersions))
            {
                resourceVersions = LoadResourceVersionsFromApi(resourceType.Namespace, cancellationToken);
                ClientOptions.ResourceApiVersions.TryAdd(resourceType.Namespace, resourceVersions);
            }
            if (!resourceVersions.TryGetValue(resourceType.Type, out version))
            {
                throw new InvalidOperationException($"Invalid resource type {resourceType}");
            }
            return version;
        }

        internal async ValueTask<string> TryGetApiVersionAsync(ResourceType resourceType, CancellationToken cancellationToken = default)
        {
            string version;
            Dictionary<string, string> resourceVersions;
            if (!ClientOptions.ResourceApiVersions.TryGetValue(resourceType.Namespace, out resourceVersions))
            {
                resourceVersions = await LoadResourceVersionsFromApiAsync(resourceType.Namespace, cancellationToken).ConfigureAwait(false);
                ClientOptions.ResourceApiVersions.TryAdd(resourceType.Namespace, resourceVersions);
            }
            if (!resourceVersions.TryGetValue(resourceType.Type, out version))
            {
                throw new InvalidOperationException($"Invalid resource type {resourceType}");
            }
            return version;
        }

        private Dictionary<string, string> LoadResourceVersionsFromApi(string resourceNamespace, CancellationToken cancellationToken = default)
        {
            Provider results = Get(resourceNamespace, cancellationToken: cancellationToken);
            return GetVersionsFromResult(results);
        }

        private async Task<Dictionary<string, string>> LoadResourceVersionsFromApiAsync(string resourceNamespace, CancellationToken cancellationToken = default)
        {
            Provider results = await GetAsync(resourceNamespace, cancellationToken: cancellationToken).ConfigureAwait(false);
            return GetVersionsFromResult(results);
        }

        private static Dictionary<string, string> GetVersionsFromResult(Provider results)
        {
            Dictionary<string, string> resourceVersions = new Dictionary<string, string>();
            foreach (var type in results.Data.ResourceTypes)
            {
                resourceVersions[type.ResourceType] = type.ApiVersions[0];
            }
            return resourceVersions;
        }

        internal string GetApiVersionForNamespace(string resourceNamespace, CancellationToken cancellationToken = default)
        {
            string version;
            if (!ClientOptions.NamespaceVersions.TryGetValue(resourceNamespace, out version))
            {
                Provider results = Get(resourceNamespace, cancellationToken: cancellationToken);
                version = GetMaxVersion(results);
                ClientOptions.NamespaceVersions.TryAdd(resourceNamespace, version);
            }
            return version;
        }

        internal async ValueTask<string> GetApiVersionForNamespaceAsync(string resourceNamespace, CancellationToken cancellationToken = default)
        {
            string version;
            if (!ClientOptions.NamespaceVersions.TryGetValue(resourceNamespace, out version))
            {
                Provider results = await GetAsync(resourceNamespace, cancellationToken: cancellationToken).ConfigureAwait(false);
                version = GetMaxVersion(results);
                ClientOptions.NamespaceVersions.TryAdd(resourceNamespace, version);
            }
            return version;
        }

        private static string GetMaxVersion(Provider results)
        {
            DateTime maxVersion = DateTime.MinValue;
            string maxVersionStr = null;
            foreach (var type in results.Data.ResourceTypes)
            {
                string strVersion = GetDateFromVersion(type.ApiVersions[0]);
                DateTime current = DateTime.Parse(strVersion, CultureInfo.InvariantCulture);
                if (current > maxVersion)
                {
                    maxVersion = current;
                    maxVersionStr = strVersion;
                }
            }
            return maxVersionStr.ToString();
        }

        private static string GetDateFromVersion(string version)
        {
            var span = version.AsSpan();
            int firstDash = span.IndexOf('-');
            var slice = span.Slice(0, firstDash + 1);
            int end = slice.IndexOf('-');
            return span.Slice(0, firstDash + end + 2).ToString();
        }
    }
}
