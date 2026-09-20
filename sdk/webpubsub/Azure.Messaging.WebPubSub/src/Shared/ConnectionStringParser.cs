// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using Azure.Core;

namespace Azure.Messaging.WebPubSub
{
    internal static class ConnectionStringParser
    {
        private static readonly char[] PropertySeparator = { ';' };
        private static readonly char[] KeyValueSeparator = { '=' };

        private const string EndpointPropertyName = "Endpoint";
        private const string AccessKeyPropertyName = "AccessKey";
        private const string PortPropertyName = "Port";

        internal static (Uri Endpoint, AzureKeyCredential Credential) Parse(string connectionString)
        {
            if (connectionString == null)
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

            if (!dict.TryGetValue(AccessKeyPropertyName, out var accessKey))
            {
                throw new ArgumentException($"Required property not found in connection string: {AccessKeyPropertyName}.");
            }

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

            return (uriBuilder.Uri, new AzureKeyCredential(accessKey));
        }
    }
}
