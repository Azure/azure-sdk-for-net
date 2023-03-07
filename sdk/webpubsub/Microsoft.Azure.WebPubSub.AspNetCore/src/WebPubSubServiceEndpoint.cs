// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using Azure;
using Azure.Core;
using Azure.Messaging.WebPubSub;

namespace Microsoft.Azure.WebPubSub.AspNetCore
{
    /// <summary>
    /// A Web PubSub service endpoint used to process incoming and outgoing requests.
    /// </summary>
    public class WebPubSubServiceEndpoint
    {
        private const string EndpointPropertyName = "Endpoint";
        private const string AccessKeyPropertyName = "AccessKey";
        private const string PortPropertyName = "Port";
        private static readonly char[] KeyValueSeparator = { '=' };
        private static readonly char[] PropertySeparator = { ';' };

        internal CredentialKind CredentialKind { get; }

        internal string ConnectionString { get; }

        internal string AccessKey { get; }

        internal TokenCredential TokenCredential { get; }

        internal AzureKeyCredential AzureKeyCredential { get; }

        /// <summary>
        /// The uri of service endpoint.
        /// </summary>

        public Uri Endpoint { get; }

        /// <summary>
        /// The <see cref="WebPubSubServiceClientOptions"/> used to invoke service.
        /// </summary>
        public WebPubSubServiceClientOptions ClientOptions { get; }

        /// <summary>
        /// Create a service endpoint with connection string.
        /// </summary>
        /// <param name="connectionString">The service endpoint connection string.</param>
        /// <param name="clientOptions">The <see cref="WebPubSubServiceClientOptions"/> to use when invoke service.</param>
        public WebPubSubServiceEndpoint(string connectionString, WebPubSubServiceClientOptions clientOptions = null)
        {
            CredentialKind = CredentialKind.ConnectionString;
            ConnectionString = connectionString ?? throw new ArgumentNullException(nameof(connectionString));
            ClientOptions = clientOptions ?? new WebPubSubServiceClientOptions();
            (Endpoint, AccessKey) = ParseConnectionString(connectionString);
        }

        /// <summary>
        /// Create a service endpoint with endpoint and <see cref="TokenCredential"/>.
        /// </summary>
        /// <param name="endpoint">The uri of target service endpoint.</param>
        /// <param name="credential">The <see cref="TokenCredential"/>.</param>
        /// <param name="clientOptions">The <see cref="WebPubSubServiceClientOptions"/> to use when invoke service.</param>
        public WebPubSubServiceEndpoint(Uri endpoint, TokenCredential credential, WebPubSubServiceClientOptions clientOptions = null)
        {
            CredentialKind = CredentialKind.TokenCredential;
            Endpoint = endpoint ?? throw new ArgumentNullException(nameof(endpoint));
            TokenCredential = credential ?? throw new ArgumentNullException(nameof(credential));
            ClientOptions = clientOptions ?? new WebPubSubServiceClientOptions();
        }

        /// <summary>
        /// Create a service endpoint with endpoint and <see cref="AzureKeyCredential"/>.
        /// </summary>
        /// <param name="endpoint">The uri of target service endpoint.</param>
        /// <param name="credential">The <see cref="AzureKeyCredential"/>.</param>
        /// <param name="clientOptions">The <see cref="WebPubSubServiceClientOptions"/> to use when invoke service.</param>
        public WebPubSubServiceEndpoint(Uri endpoint, AzureKeyCredential credential, WebPubSubServiceClientOptions clientOptions = null)
        {
            CredentialKind = CredentialKind.AzureKeyCredential;
            Endpoint = endpoint ?? throw new ArgumentNullException(nameof(endpoint));
            AzureKeyCredential = credential ?? throw new ArgumentNullException(nameof(credential));
            ClientOptions = clientOptions ?? new WebPubSubServiceClientOptions();
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
