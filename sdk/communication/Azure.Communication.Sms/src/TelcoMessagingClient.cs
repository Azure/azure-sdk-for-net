// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Communication.Pipeline;
using Azure.Core;
using Azure.Core.Pipeline;

namespace Azure.Communication.Sms
{
    /// <summary>
    /// The Azure Communication Services Telco Messaging client.
    /// </summary>
    public class TelcoMessagingClient
    {
        private readonly ClientDiagnostics _clientDiagnostics;
        private readonly SmsRestClient _smsRestClient;

        #region public constructors - all arguments need null check

        /// <summary> Initializes a new instance of <see cref="TelcoMessagingClient"/>.</summary>
        /// <param name="connectionString">Connection string acquired from the Azure Communication Services resource.</param>
        public TelcoMessagingClient(string connectionString)
            : this(
                ConnectionString.Parse(Argument.CheckNotNullOrEmpty(connectionString, nameof(connectionString))),
                new TelcoMessagingClientOptions())
        { }

        /// <summary> Initializes a new instance of <see cref="TelcoMessagingClient"/>.</summary>
        /// <param name="connectionString">Connection string acquired from the Azure Communication Services resource.</param>
        /// <param name="options">Client option exposing <see cref="ClientOptions.Diagnostics"/>, <see cref="ClientOptions.Retry"/>, <see cref="ClientOptions.Transport"/>, etc.</param>
        public TelcoMessagingClient(string connectionString, TelcoMessagingClientOptions options)
            : this(
                ConnectionString.Parse(Argument.CheckNotNullOrEmpty(connectionString, nameof(connectionString))),
                options ?? new TelcoMessagingClientOptions())
        { }

        /// <summary> Initializes a new instance of <see cref="TelcoMessagingClient"/>.</summary>
        /// <param name="endpoint">The URI of the Azure Communication Services resource.</param>
        /// <param name="keyCredential">The <see cref="AzureKeyCredential"/> used to authenticate requests.</param>
        /// <param name="options">Client option exposing <see cref="ClientOptions.Diagnostics"/>, <see cref="ClientOptions.Retry"/>, <see cref="ClientOptions.Transport"/>, etc.</param>
        public TelcoMessagingClient(Uri endpoint, AzureKeyCredential keyCredential, TelcoMessagingClientOptions options = default)
            : this(
                Argument.CheckNotNull(endpoint, nameof(endpoint)).AbsoluteUri,
                Argument.CheckNotNull(keyCredential, nameof(keyCredential)),
                options ?? new TelcoMessagingClientOptions())
        { }

        /// <summary> Initializes a new instance of <see cref="TelcoMessagingClient"/>.</summary>
        /// <param name="endpoint">The URI of the Azure Communication Services resource.</param>
        /// <param name="tokenCredential">The TokenCredential used to authenticate requests, such as DefaultAzureCredential.</param>
        /// <param name="options">Client option exposing <see cref="ClientOptions.Diagnostics"/>, <see cref="ClientOptions.Retry"/>, <see cref="ClientOptions.Transport"/>, etc.</param>
        public TelcoMessagingClient(Uri endpoint, TokenCredential tokenCredential, TelcoMessagingClientOptions options = default)
            : this(
                Argument.CheckNotNull(endpoint, nameof(endpoint)).AbsoluteUri,
                Argument.CheckNotNull(tokenCredential, nameof(tokenCredential)),
                options ?? new TelcoMessagingClientOptions())
        { }

        #endregion

        #region private constructors

        private TelcoMessagingClient(ConnectionString connectionString, TelcoMessagingClientOptions options)
            : this(connectionString.GetRequired("endpoint"), options.BuildHttpPipeline(connectionString), options)
        { }

        private TelcoMessagingClient(string endpoint, TokenCredential tokenCredential, TelcoMessagingClientOptions options)
            : this(endpoint, options.BuildHttpPipeline(tokenCredential), options)
        { }

        private TelcoMessagingClient(string endpoint, AzureKeyCredential keyCredential, TelcoMessagingClientOptions options)
            : this(endpoint, options.BuildHttpPipeline(keyCredential), options)
        { }

        private TelcoMessagingClient(string endpoint, HttpPipeline httpPipeline, TelcoMessagingClientOptions options)
        {
            _clientDiagnostics = new ClientDiagnostics(options);
            _smsRestClient = new SmsRestClient(_clientDiagnostics, httpPipeline, new Uri(endpoint), options.ApiVersion);

            // Initialize sub-clients
            Sms = new SmsSubClient(_clientDiagnostics, _smsRestClient);
            OptOuts = new OptOutsClient(_clientDiagnostics, httpPipeline, new Uri(endpoint), options.ApiVersion);
            DeliveryReports = new DeliveryReportsClient(_clientDiagnostics, httpPipeline, new Uri(endpoint), options.ApiVersion);
        }

        #endregion

        /// <summary>Initializes a new instance of <see cref="TelcoMessagingClient"/> for mocking.</summary>
        protected TelcoMessagingClient()
        {
            _clientDiagnostics = null;
            _smsRestClient = null;
            Sms = null;
            OptOuts = null;
            DeliveryReports = null;
        }

        /// <summary>
        /// SMS messaging sub-client for sending messages.
        /// </summary>
        public virtual SmsSubClient Sms { get; private set; }

        /// <summary>
        /// Opt Out management client.
        /// </summary>
        public virtual OptOutsClient OptOuts { get; private set; }

        /// <summary>
        /// Delivery Reports client for retrieving message delivery status.
        /// </summary>
        public virtual DeliveryReportsClient DeliveryReports { get; private set; }
    }
}
