// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Globalization;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using Azure.Core;

namespace Azure.Messaging.EventGrid
{
    /// <summary>
    /// This <see cref="EventGridSasBuilder"/> is used to generate a Shared Access Signature (SAS) for an Azure Event Grid topic.
    /// </summary>
    public class EventGridSasBuilder
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="EventGridSasBuilder"/> class.
        /// </summary>
        /// <param name="endpoint">The endpoint to generate a shared access signature for.
        /// For example, "https://TOPIC-NAME.REGION-NAME.eventgrid.azure.net/eventGrid/api/events".</param>
        /// <param name="expiresOn">The time at which the shared access signature should expire.</param>
        public EventGridSasBuilder(Uri endpoint, DateTimeOffset expiresOn)
        {
            Argument.AssertNotNull(endpoint, nameof(endpoint));
            Endpoint = endpoint;
            ExpiresOn = expiresOn;
        }

        /// <summary>
        /// Gets or sets the endpoint to generate a shared access signature for.
        /// </summary>
        public Uri Endpoint
        {
            get
            {
                return _endpoint;
            }
            set
            {
                Argument.AssertNotNull(value, nameof(value));
                _endpoint = value;
            }
        }

        private Uri _endpoint;

        /// <summary>
        /// Gets or sets the time at which the shared access signature should expire.
        /// </summary>
        public DateTimeOffset ExpiresOn { get; set; }

        /// <summary>
        /// Gets or sets the service version to use when generating the shared access signature.
        /// </summary>
        public EventGridPublisherClientOptions.ServiceVersion ApiVersion { get; set; } = EventGridPublisherClientOptions.LatestVersion;

        /// <summary>
        /// Generates a shared access signature that can be used to authenticate with a topic.
        /// The signature can be used as the input to the <see cref="AzureSasCredential(string)"/> constructor.
        /// This credential can then be passed to the <see cref="EventGridPublisherClient(Uri, AzureSasCredential, EventGridPublisherClientOptions)"/> constructor.
        /// </summary>
        /// <param name="key">The <see cref="AzureKeyCredential"/> to use to authenticate with the service
        /// when generating the shared access signature.</param>
        /// <returns>A shared access signature that can be used to authenticate with an Event Grid topic.</returns>
        public string GenerateSas(AzureKeyCredential key)
        {
            Argument.AssertNotNull(key, nameof(key));
            const char Resource = 'r';
            const char Expiration = 'e';
            const char Signature = 's';

            var uriBuilder = new RequestUriBuilder();
            uriBuilder.Reset(Endpoint);
            uriBuilder.AppendQuery("api-version", ApiVersion.GetVersionString(), true);
            string encodedResource = HttpUtility.UrlEncode(uriBuilder.ToString());
            var encodedExpirationUtc = HttpUtility.UrlEncode(ExpiresOn.ToString(CultureInfo.CreateSpecificCulture("en-US")));

            string unsignedSas = $"{Resource}={encodedResource}&{Expiration}={encodedExpirationUtc}";
            using (var hmac = new HMACSHA256(Convert.FromBase64String(key.Key)))
            {
                string signature = Convert.ToBase64String(hmac.ComputeHash(Encoding.UTF8.GetBytes(unsignedSas)));
                string encodedSignature = HttpUtility.UrlEncode(signature);
                string signedSas = $"{unsignedSas}&{Signature}={encodedSignature}";

                return signedSas;
            }
        }
    }
}
