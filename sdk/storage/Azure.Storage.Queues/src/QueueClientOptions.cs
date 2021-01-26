// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.Storage.Queues.Models;

namespace Azure.Storage.Queues
{
    /// <summary>
    /// Provides the client configuration options for connecting to Azure Queue
    /// Storage
    /// </summary>
    public class QueueClientOptions : ClientOptions
    {
        /// <summary>
        /// The Latest service version supported by this client library.
        /// </summary>
        internal const ServiceVersion LatestVersion = StorageVersionExtensions.LatestVersion;

        /// <summary>
        /// The versions of Azure Queue Storage supported by this client
        /// library.
        ///
        /// For more information, see
        /// <see href="https://docs.microsoft.com/en-us/rest/api/storageservices/versioning-for-the-azure-storage-services">
        /// Versioning for the Azure Storage services</see>.
        /// </summary>
        public enum ServiceVersion
        {
#pragma warning disable CA1707 // Identifiers should not contain underscores
            /// <summary>
            /// The 2019-02-02 service version described at
            /// <see href="https://docs.microsoft.com/en-us/rest/api/storageservices/version-2019-02-02">
            /// Version 2019-02-02</see>.
            /// </summary>
            V2019_02_02 = 1,

            /// <summary>
            /// The 2019-07-07 service version described at
            /// <see href="https://docs.microsoft.com/en-us/rest/api/storageservices/version-2019-07-07">
            /// Version 2019-07-07</see>.
            /// </summary>
            V2019_07_07 = 2,

            /// <summary>
            /// The 2019-12-12 service version.
            /// </summary>
            V2019_12_12 = 3,

            /// <summary>
            /// The 2020-02-10 service version.
            /// </summary>
            V2020_02_10 = 4,

            /// <summary>
            /// The 2020-04-08 service version.
            /// </summary>
            V2020_04_08 = 5
#pragma warning restore CA1707 // Identifiers should not contain underscores
        }

        /// <summary>
        /// Gets the <see cref="ServiceVersion"/> of the service API used when
        /// making requests.  For more, see
        /// For more information, see
        /// <see href="https://docs.microsoft.com/en-us/rest/api/storageservices/versioning-for-the-azure-storage-services">
        /// Versioning for the Azure Storage services</see>.
        /// </summary>
        public ServiceVersion Version { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="QueueClientOptions"/>
        /// class.
        /// </summary>
        /// <param name="version">
        /// The <see cref="ServiceVersion"/> of the service API used when
        /// making requests.
        /// </param>
        public QueueClientOptions(ServiceVersion version = LatestVersion)
        {
            if (ServiceVersion.V2019_02_02 <= version
                && version <= LatestVersion)
            {
                Version = version;
            }
            else
            {
                throw Errors.VersionNotSupported(nameof(version));
            }

            this.Initialize();
            AddHeadersAndQueryParameters();
        }

        /// <summary>
        /// Gets or sets the secondary storage <see cref="Uri"/> that can be read from for the storage account if the
        /// account is enabled for RA-GRS.
        ///
        /// If this property is set, the secondary Uri will be used for GET or HEAD requests during retries.
        /// If the status of the response from the secondary Uri is a 404, then subsequent retries for
        /// the request will not use the secondary Uri again, as this indicates that the resource
        /// may not have propagated there yet. Otherwise, subsequent retries will alternate back and forth
        /// between primary and secondary Uri.
        /// </summary>
        public Uri GeoRedundantSecondaryUri { get; set; }

        /// <summary>
        /// Gets or sets a message encoding that determines how <see cref="QueueMessage.Body"/> is represented in HTTP requests and responses.
        /// The default is <see cref="QueueMessageEncoding.None"/>.
        /// </summary>
        public QueueMessageEncoding MessageEncoding { get; set; } = QueueMessageEncoding.None;

        /// <summary>
        /// Optional. Performs the tasks needed when an invalid message is received or peaked from the queue.
        ///
        /// <para>Invalid message can be received or peaked when <see cref="QueueClient"/> is expecting certain <see cref="QueueMessageEncoding"/>
        /// but there's another producer that is not encoding messages in expected way. I.e. the queue contains messages with different encoding.</para>
        ///
        /// <para><see cref="InvalidMessageEventArgs"/> contains <see cref="QueueClient"/> that has received invalid message as well as the message
        /// which can be either <see cref="QueueMessage"/> or <see cref="PeekedMessage"/> with raw body, i.e. no decoding will be attempted so that
        /// body can be inspected as has been received from the queue.</para>
        ///
        /// <para>The <see cref="QueueClient"/> won't attempt to remove invalid message from the queue. Therefore such handling should be included into
        /// the event handler itself.</para>
        /// </summary>
        public event SyncAsyncEventHandler<InvalidMessageEventArgs> OnInvalidMessage;

        internal SyncAsyncEventHandler<InvalidMessageEventArgs> GetInvalidMessageHandlers() => OnInvalidMessage;

        #region Advanced Options
        internal ClientSideEncryptionOptions _clientSideEncryptionOptions;
        #endregion

        /// <summary>
        /// Add headers and query parameters in <see cref="DiagnosticsOptions.LoggedHeaderNames"/> and <see cref="DiagnosticsOptions.LoggedQueryParameters"/>
        /// </summary>
        private void AddHeadersAndQueryParameters()
        {
            Diagnostics.LoggedHeaderNames.Add("Access-Control-Allow-Origin");
            Diagnostics.LoggedHeaderNames.Add("x-ms-date");
            Diagnostics.LoggedHeaderNames.Add("x-ms-error-code");
            Diagnostics.LoggedHeaderNames.Add("x-ms-request-id");
            Diagnostics.LoggedHeaderNames.Add("x-ms-version");
            Diagnostics.LoggedHeaderNames.Add("x-ms-approximate-messages-count");
            Diagnostics.LoggedHeaderNames.Add("x-ms-popreceipt");
            Diagnostics.LoggedHeaderNames.Add("x-ms-time-next-visible");

            Diagnostics.LoggedQueryParameters.Add("comp");
            Diagnostics.LoggedQueryParameters.Add("maxresults");
            Diagnostics.LoggedQueryParameters.Add("rscc");
            Diagnostics.LoggedQueryParameters.Add("rscd");
            Diagnostics.LoggedQueryParameters.Add("rsce");
            Diagnostics.LoggedQueryParameters.Add("rscl");
            Diagnostics.LoggedQueryParameters.Add("rsct");
            Diagnostics.LoggedQueryParameters.Add("se");
            Diagnostics.LoggedQueryParameters.Add("si");
            Diagnostics.LoggedQueryParameters.Add("sip");
            Diagnostics.LoggedQueryParameters.Add("sp");
            Diagnostics.LoggedQueryParameters.Add("spr");
            Diagnostics.LoggedQueryParameters.Add("sr");
            Diagnostics.LoggedQueryParameters.Add("srt");
            Diagnostics.LoggedQueryParameters.Add("ss");
            Diagnostics.LoggedQueryParameters.Add("st");
            Diagnostics.LoggedQueryParameters.Add("sv");
            Diagnostics.LoggedQueryParameters.Add("include");
            Diagnostics.LoggedQueryParameters.Add("marker");
            Diagnostics.LoggedQueryParameters.Add("prefix");
            Diagnostics.LoggedQueryParameters.Add("messagettl");
            Diagnostics.LoggedQueryParameters.Add("numofmessages");
            Diagnostics.LoggedQueryParameters.Add("peekonly");
            Diagnostics.LoggedQueryParameters.Add("popreceipt");
            Diagnostics.LoggedQueryParameters.Add("visibilitytimeout");
        }

        /// <summary>
        /// Create an HttpPipeline from QueueClientOptions.
        /// </summary>
        /// <param name="authentication">Optional authentication policy.</param>
        /// <returns>An HttpPipeline to use for Storage requests.</returns>
        internal HttpPipeline Build(HttpPipelinePolicy authentication = null)
        {
            return this.Build(authentication, GeoRedundantSecondaryUri);
        }

        /// <summary>
        /// Create an HttpPipeline from QueueClientOptions.
        /// </summary>
        /// <param name="credentials">Optional authentication credentials.</param>
        /// <returns>An HttpPipeline to use for Storage requests.</returns>
        internal HttpPipeline Build(object credentials)
        {
            return this.Build(credentials, GeoRedundantSecondaryUri);
        }
    }
}
