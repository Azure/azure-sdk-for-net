// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;

namespace Microsoft.Azure.WebJobs.Extensions.WebPubSub
{
    /// <summary>
    /// Validation options when using Web PubSub service.
    /// Used for Abuse Protection and Signature checks.
    /// </summary>
    internal class WebPubSubValidationOptions
    {
        private const string EndpointPropertyName = "Endpoint";
        private const string AccessKeyPropertyName = "AccessKey";
        private const string PortPropertyName = "Port";
        private static readonly char[] KeyValueSeparator = { '=' };
        private static readonly char[] PropertySeparator = { ';' };
        private readonly Dictionary<string, string> _hostKeyMappings = new(StringComparer.OrdinalIgnoreCase);

        public WebPubSubValidationOptions(params string[] connectionStrings)
        {
            foreach (var item in connectionStrings)
            {
                if (string.IsNullOrEmpty(item))
                {
                    continue;
                }
                (Uri host, string accessKey) = ParseConnectionString(item);
                _hostKeyMappings.Add(host.Host, accessKey);
            }
        }

        public WebPubSubValidationOptions(IEnumerable<string> connectionStrings)
            : this(connectionStrings.ToArray())
        {
        }

        internal bool ContainsHost()
        {
            return _hostKeyMappings.Count > 0;
        }

        internal bool ContainsHost(string host)
        {
            return _hostKeyMappings.ContainsKey(host);
        }

        internal bool TryGetKey(string host, out string accessKey)
        {
            return _hostKeyMappings.TryGetValue(host, out accessKey);
        }

        internal List<string> GetAllowedHosts()
        {
            return _hostKeyMappings.Select(x => x.Key).ToList();
        }

        /// <summary>
        /// Parse connection string to endpoint and credential.
        /// </summary>
        /// <returns></returns>
        internal static (Uri Endpoint, string AccessKey) ParseConnectionString(string connectionString)
        {
            if (string.IsNullOrEmpty(connectionString))
            {
                throw new ArgumentNullException(nameof(connectionString));
            }

            var properties = connectionString.Split(PropertySeparator, StringSplitOptions.RemoveEmptyEntries);

            var dict = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);
            foreach (var property in properties)
            {
                var kvp = property.Split(KeyValueSeparator, 2);
                if (kvp.Length != 2)
                    continue;

                var key = kvp[0].Trim();
                if (dict.ContainsKey(key))
                {
                    throw new ArgumentException($"Duplicate properties found in connection string: {key}.");
                }

                dict.Add(key, kvp[1].Trim());
            }

            if (!dict.TryGetValue(EndpointPropertyName, out var endpoint))
            {
                throw new ArgumentException($"Required property not found in connection string: {EndpointPropertyName}.");
            }
            endpoint = endpoint.TrimEnd('/');

            // AccessKey is optional when connection string is disabled.
            dict.TryGetValue(AccessKeyPropertyName, out var accessKey);

            int? port = null;
            if (dict.TryGetValue(PortPropertyName, out var rawPort))
            {
                if (int.TryParse(rawPort, out var portValue) && portValue > 0 && portValue <= 0xFFFF)
                {
                    port = portValue;
                }
                else
                {
                    throw new ArgumentException($"Invalid Port value: {rawPort}");
                }
            }

            var uriBuilder = new UriBuilder(endpoint);
            if (port.HasValue)
            {
                uriBuilder.Port = port.Value;
            }

            return (uriBuilder.Uri, accessKey);
        }
    }
}
