// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure;
using Azure.Core;
using Azure.Messaging.WebPubSub;

namespace Microsoft.Azure.WebPubSub.AspNetCore
{
    /// <summary>
    /// A Web PubSub service endpoint used to process incoming and outgoing requests.
    /// </summary>
    public class ServiceEndpoint
    {
        private static readonly ValidationOptions _validationOptions = new();

        internal CredentialKind CredentialKind { get; }

        internal ValidationOptions ValidationOptions = _validationOptions;

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
        public ServiceEndpoint(string connectionString, WebPubSubServiceClientOptions clientOptions = null)
        {
            CredentialKind = CredentialKind.ConnectionString;
            ConnectionString = connectionString ?? throw new ArgumentNullException(nameof(connectionString));
            ClientOptions = clientOptions ?? new WebPubSubServiceClientOptions();
            (Endpoint, AccessKey) = ValidationOptions.ParseConnectionString(connectionString);
            _validationOptions.Add(connectionString);
        }

        /// <summary>
        /// Create a service endpoint with endpoint and <see cref="TokenCredential"/>.
        /// </summary>
        /// <param name="endpoint">The uri of target service endpoint.</param>
        /// <param name="credential">The <see cref="TokenCredential"/>.</param>
        /// <param name="clientOptions">The <see cref="WebPubSubServiceClientOptions"/> to use when invoke service.</param>
        public ServiceEndpoint(Uri endpoint, TokenCredential credential, WebPubSubServiceClientOptions clientOptions = null)
        {
            CredentialKind = CredentialKind.TokenCredential;
            Endpoint = endpoint ?? throw new ArgumentNullException(nameof(endpoint));
            TokenCredential = credential ?? throw new ArgumentNullException(nameof(credential));
            ClientOptions = clientOptions ?? new WebPubSubServiceClientOptions();
            _validationOptions.Add(endpoint);
        }

        /// <summary>
        /// Create a service endpoint with endpoint and <see cref="AzureKeyCredential"/>.
        /// </summary>
        /// <param name="endpoint">The uri of target service endpoint.</param>
        /// <param name="credential">The <see cref="AzureKeyCredential"/>.</param>
        /// <param name="clientOptions">The <see cref="WebPubSubServiceClientOptions"/> to use when invoke service.</param>
        public ServiceEndpoint(Uri endpoint, AzureKeyCredential credential, WebPubSubServiceClientOptions clientOptions = null)
        {
            CredentialKind = CredentialKind.AzureKeyCredential;
            Endpoint = endpoint ?? throw new ArgumentNullException(nameof(endpoint));
            AzureKeyCredential = credential ?? throw new ArgumentNullException(nameof(credential));
            ClientOptions = clientOptions ?? new WebPubSubServiceClientOptions();
            _validationOptions.Add(endpoint);
        }
    }
}
