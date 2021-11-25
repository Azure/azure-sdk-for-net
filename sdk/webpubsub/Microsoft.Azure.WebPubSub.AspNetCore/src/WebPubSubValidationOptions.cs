// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;

namespace Microsoft.Azure.WebPubSub.AspNetCore
{
    /// <summary>
    /// Validation options when using Web PubSub service.
    /// </summary>
    public class WebPubSubValidationOptions
    {
        private const string EndpointPropertyName = "Endpoint";
        private const string AccessKeyPropertyName = "AccessKey";
        private const string PortPropertyName = "Port";
        private static readonly char[] KeyValueSeparator = { '=' };
        private static readonly char[] PropertySeparator = { ';' };
        private readonly Dictionary<string, string> _hostKeyMappings = new(StringComparer.OrdinalIgnoreCase);

        /// <summary>
        /// Init the ValidationOptions based on a set of allowed connection strings.
        /// </summary>
        /// <param name="connectionStrings">The upstream connection strings for validation.</param>
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

        /// <summary>
        /// Init the ValidationOptions based on a set of allowed connection strings.
        /// </summary>
        /// <param name="connectionStrings">The upstream connection strings for validation.</param>
        public WebPubSubValidationOptions(IEnumerable<string> connectionStrings)
            : this(connectionStrings.ToArray())
        {
        }

        /// <summary>
        /// Method to add a upstream connection string to current validation options.
        /// </summary>
        /// <param name="connectionString">The upstream connection strings for validation.</param>
        public void Add(string connectionString)
        {
            if (string.IsNullOrEmpty(connectionString))
            {
                throw new ArgumentNullException(nameof(connectionString));
            }

            (Uri host, string accessKey) = ParseConnectionString(connectionString);
            _hostKeyMappings.Add(host.Host, accessKey);
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
