// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.Storage.Queues.Models;
using Azure.Storage.Shared;

namespace Azure.Storage.Queues
{
    /// <summary>
    /// Provides the client configuration options for connecting to Azure Queue
    /// Storage
    /// </summary>
    public class QueueClientOptions : ClientOptions, ISupportsTenantIdChallenges
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
            V2020_04_08 = 5,

            /// <summary>
            /// The 2020-06-12 service version.
            /// </summary>
            V2020_06_12 = 6,

            /// <summary>
            /// The 2020-08-14 service version.
            /// </summary>
            V2020_08_04 = 7,

            /// <summary>
            /// The 2020-10-02 service version.
            /// </summary>
            V2020_10_02 = 8,

            /// <summary>
            /// The 2020-12-06 service version.
            /// </summary>
            V2020_12_06 = 9,

            /// <summary>
            /// The 2021-02-12 service version.
            /// </summary>
            V2021_02_12 = 10,

            /// <summary>
            /// The 2021-04-10 service version.
            /// </summary>
            V2021_04_10 = 11,

            /// <summary>
            /// The 2021-06-08 service version.
            /// </summary>
            V2021_06_08 = 12,

            /// <summary>
            /// The 2021-08-06 service version.
            /// </summary>
            V2021_08_06 = 13,

            /// <summary>
            /// The 2021-10-04 service version.
            /// </summary>
            V2021_10_04 = 14,

            /// <summary>
            /// The 2021-12-02 service version.
            /// </summary>
            V2021_12_02 = 15,

            /// <summary>
            /// The 2022-11-02 service version.
            /// </summary>
            V2022_11_02 = 16,

            /// <summary>
            /// The 2023-01-03 service version.
            /// </summary>
            V2023_01_03 = 17,

            /// <summary>
            /// The 2023-05-03 service version.
            /// </summary>
            V2023_05_03 = 18,

            /// <summary>
            /// The 2023-08-03 service version.
            /// </summary>
            V2023_08_03 = 19,

            /// <summary>
            /// The 2023-11-03 service version.
            /// </summary>
            V2023_11_03 = 20,

            /// <summary>
            /// The 2024-02-04 service version.
            /// </summary>
            V2024_02_04 = 21,

            /// <summary>
            /// The 2024-05-04 service version.
            /// </summary>
            V2024_05_04 = 22,

            /// <summary>
            /// The 2024-08-04 service version.
            /// </summary>
            V2024_08_04 = 23,

            /// <summary>
            /// The 2024-11-04 service version.
            /// </summary>
            V2024_11_04 = 24,

            /// <summary>
            /// The 2025-01-05 service version.
            /// </summary>
            V2025_01_05 = 25,

            /// <summary>
            /// The 2025-05-05 service version.
            /// </summary>
            V2025_05_05 = 26,

            /// <summary>
            /// The 2025-07-05 service version.
            /// </summary>
            V2025_07_05 = 27,

            /// <summary>
            /// 2025-11-05 service version.
            /// </summary>
            V2025_11_05 = 28
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
                && version <= StorageVersionExtensions.MaxVersion)
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

        /// <inheritdoc />
        public bool EnableTenantDiscovery { get; set; }

        /// <summary>
        /// Optional. Performs the tasks needed when a message is received or peaked from the queue but cannot be decoded.
        ///
        /// <para>Such message can be received or peaked when <see cref="QueueClient"/> is expecting certain <see cref="QueueMessageEncoding"/>
        /// but there's another producer that is not encoding messages in expected way. I.e. the queue contains messages with different encoding.</para>
        ///
        /// <para><see cref="QueueMessageDecodingFailedEventArgs"/> contains <see cref="QueueClient"/> that has received the message as well as
        /// <see cref="QueueMessageDecodingFailedEventArgs.ReceivedMessage"/> or <see cref="QueueMessageDecodingFailedEventArgs.PeekedMessage"/>
        /// with raw body, i.e. no decoding will be attempted so that
        /// body can be inspected as has been received from the queue.</para>
        ///
        /// <para>The <see cref="QueueClient"/> won't attempt to remove the message from the queue. Therefore such handling should be included into
        /// the event handler itself.</para>
        ///
        /// <para>The handler is potentially invoked by both synchronous and asynchronous receive and peek APIs. Therefore implementation of the handler should align with
        /// <see cref="QueueClient"/> APIs that are being used.
        /// See <see cref="SyncAsyncEventHandler{T}"/> about how to implement handler correctly. The example below shows a handler with all possible cases explored.
        /// <code snippet="Snippet:Azure_Storage_Queues_Samples_Sample03_MessageEncoding_MessageDecodingFailedHandlerAsync" language="csharp">
        /// QueueClientOptions queueClientOptions = new QueueClientOptions()
        /// {
        ///     MessageEncoding = QueueMessageEncoding.Base64
        /// };
        ///
        /// queueClientOptions.MessageDecodingFailed += async (QueueMessageDecodingFailedEventArgs args) =&gt;
        /// {
        ///     if (args.PeekedMessage != null)
        ///     {
        ///         Console.WriteLine($&quot;Invalid message has been peeked, message id={args.PeekedMessage.MessageId} body={args.PeekedMessage.Body}&quot;);
        ///     }
        ///     else if (args.ReceivedMessage != null)
        ///     {
        ///         Console.WriteLine($&quot;Invalid message has been received, message id={args.ReceivedMessage.MessageId} body={args.ReceivedMessage.Body}&quot;);
        ///
        ///         if (args.IsRunningSynchronously)
        ///         {
        ///             args.Queue.DeleteMessage(args.ReceivedMessage.MessageId, args.ReceivedMessage.PopReceipt);
        ///         }
        ///         else
        ///         {
        ///             await args.Queue.DeleteMessageAsync(args.ReceivedMessage.MessageId, args.ReceivedMessage.PopReceipt);
        ///         }
        ///     }
        /// };
        ///
        /// QueueClient queueClient = new QueueClient(connectionString, queueName, queueClientOptions);
        /// </code>
        /// </para>
        /// </summary>
        public event SyncAsyncEventHandler<QueueMessageDecodingFailedEventArgs> MessageDecodingFailed;

        internal SyncAsyncEventHandler<QueueMessageDecodingFailedEventArgs> GetMessageDecodingFailedHandlers() => MessageDecodingFailed;

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

        /// <summary>
        /// Gets or sets the Audience to use for authentication with Azure Active Directory (AAD). The audience is not considered when using a shared key.
        /// </summary>
        /// <value>If <c>null</c>, <see cref="QueueAudience.PublicAudience" /> will be assumed.</value>
        public QueueAudience? Audience { get; set; }
    }
}
