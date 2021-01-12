// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.Communication.Pipeline;

namespace Azure.Communication.Sms
{
    /// <summary>
    /// The Azure Communication Services SMS client.
    /// </summary>
    public class SmsClient
    {
        private readonly ClientDiagnostics _clientDiagnostics;
        internal SmsRestClient RestClient { get; }

        /// <summary> Initializes a new instance of <see cref="SmsClient"/>.</summary>
        /// <param name="connectionString">Connection string acquired from the Azure Communication Services resource.</param>
        /// <param name="options">Client option exposing <see cref="ClientOptions.Diagnostics"/>, <see cref="ClientOptions.Retry"/>, <see cref="ClientOptions.Transport"/>, etc.</param>
        public SmsClient(string connectionString, SmsClientOptions? options = default)
            : this(
                  options ?? new SmsClientOptions(),
                  ConnectionString.Parse(AssertNotNullOrEmpty(connectionString, nameof(connectionString))))
        { }

        /// <summary>Initializes a new instance of <see cref="SmsClient"/> for mocking.</summary>
        protected SmsClient()
        {
            _clientDiagnostics = null!;
            RestClient = null!;
        }

        private SmsClient(ClientDiagnostics clientDiagnostics, HttpPipeline pipeline, string endpointUrl, string apiVersion = "2020-07-20-preview1")
        {
            RestClient = new SmsRestClient(clientDiagnostics, pipeline, endpointUrl, apiVersion);
            _clientDiagnostics = clientDiagnostics;
        }

        private SmsClient(SmsClientOptions options, ConnectionString connectionString)
            : this(
                  clientDiagnostics: new ClientDiagnostics(options),
                  pipeline: options.BuildHttpPipeline(connectionString),
                  endpointUrl: connectionString.GetRequired("endpoint"),
                  apiVersion: options.ApiVersion)
        { }

        /// <summary>
        /// Sends a SMS <paramref name="from"/> a phone number that is acquired by the authenticated account, <paramref name="to"/> another phone number.
        /// </summary>
        /// <param name="from">The sender's phone number that is owned by the authenticated account.</param>
        /// <param name="to">The recipient's phone number.</param>
        /// <param name="message">The contents of the message that will be sent to the recipient. The allowable content is defined by RFC 5724. If the message has more than 160 characters, the server will split it into multiple SMSs automatically.</param>
        /// <param name="sendSmsOptions">Optional configuration for sending SMS messages.</param>
        /// <param name="cancellationToken">The cancellation token for the task.</param>
        /// <exception cref="RequestFailedException">The server returned an error. See <see cref="Exception.Message"/> for details returned from the server.</exception>
        /// <exception cref="ArgumentNullException"><paramref name="from"/> is null.</exception>
        /// <exception cref="ArgumentNullException"><paramref name="to"/> is null.</exception>
        /// <exception cref="ArgumentNullException"><paramref name="message"/> is null.</exception>
        public virtual async Task<Response<SendSmsResponse>> SendAsync(PhoneNumberIdentifier from, PhoneNumberIdentifier to, string message, SendSmsOptions? sendSmsOptions = null, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(from.Value, nameof(from));
            Argument.AssertNotNullOrEmpty(to.Value, nameof(to));
            return await SendAsync(from, new[] { to }, message, sendSmsOptions, cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Sends a SMS <paramref name="from"/> a phone number that is acquired by the authenticated account, <paramref name="to"/> another phone number.
        /// </summary>
        /// <param name="from">The sender's phone number that is owned by the authenticated account.</param>
        /// <param name="to">The recipient's phone number.</param>
        /// <param name="message">The contents of the message that will be sent to the recipient. The allowable content is defined by RFC 5724. If the message has more than 160 characters, the server will split it into multiple SMSs automatically.</param>
        /// <param name="sendSmsOptions">Optional configuration for sending SMS messages.</param>
        /// <param name="cancellationToken">The cancellation token for the underlying request.</param>
        /// <exception cref="RequestFailedException">The server returned an error. See <see cref="Exception.Message"/> for details returned from the server.</exception>
        /// <exception cref="ArgumentNullException"><paramref name="from"/> is null.</exception>
        /// <exception cref="ArgumentNullException"><paramref name="to"/> is null.</exception>
        /// <exception cref="ArgumentNullException"><paramref name="message"/> is null.</exception>
        public virtual Response<SendSmsResponse> Send(PhoneNumberIdentifier from, PhoneNumberIdentifier to, string message, SendSmsOptions? sendSmsOptions = null, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(from.Value, nameof(from));
            Argument.AssertNotNullOrEmpty(to.Value, nameof(to));
            return Send(from, new[] { to }, message, sendSmsOptions, cancellationToken);
        }

        /// <summary> Sends an SMS message from a phone number that belongs to the authenticated account. </summary>
        /// <param name="from"> The sender&apos;s phone number in E.164 format that is owned by the authenticated account. </param>
        /// <param name="to"> The recipient&apos;s phone number in E.164 format. In this version, only one recipient in the list is supported. </param>
        /// <param name="message"> The contents of the message that will be sent to the recipient. The allowable content is defined by RFC 5724. </param>
        /// <param name="sendSmsOptions"> Optional configuration for sending SMS messages. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="RequestFailedException">The server returned an error. See <see cref="Exception.Message"/> for details returned from the server.</exception>
        /// <exception cref="ArgumentNullException"><paramref name="from"/> is null.</exception>
        /// <exception cref="ArgumentNullException"><paramref name="to"/> is null.</exception>
        /// <exception cref="ArgumentNullException"><paramref name="message"/> is null.</exception>
        public virtual async Task<Response<SendSmsResponse>> SendAsync(PhoneNumberIdentifier from, IEnumerable<PhoneNumberIdentifier> to, string message, SendSmsOptions? sendSmsOptions = null, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(SmsClient)}.{nameof(Send)}");
            scope.Start();
            try
            {
                Argument.AssertNotNullOrEmpty(from.Value, nameof(from));
                return await RestClient.SendAsync(from.Value, to.Select(x => AssertNotNullOrEmpty(x.Value, nameof(to))), message, sendSmsOptions, cancellationToken).ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary> Sends an SMS message from a phone number that belongs to the authenticated account. </summary>
        /// <param name="from"> The sender&apos;s phone number in E.164 format that is owned by the authenticated account. </param>
        /// <param name="to"> The recipient&apos;s phone number in E.164 format. In this version, only one recipient in the list is supported. </param>
        /// <param name="message"> The contents of the message that will be sent to the recipient. The allowable content is defined by RFC 5724. </param>
        /// <param name="sendSmsOptions"> Optional configuration for sending SMS messages. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="RequestFailedException">The server returned an error. See <see cref="Exception.Message"/> for details returned from the server.</exception>
        /// <exception cref="ArgumentNullException"><paramref name="from"/> is null.</exception>
        /// <exception cref="ArgumentNullException"><paramref name="to"/> is null.</exception>
        /// <exception cref="ArgumentNullException"><paramref name="message"/> is null.</exception>
        public virtual Response<SendSmsResponse> Send(PhoneNumberIdentifier from, IEnumerable<PhoneNumberIdentifier> to, string message, SendSmsOptions? sendSmsOptions = null, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(SmsClient)}.{nameof(Send)}");
            scope.Start();
            try
            {
                Argument.AssertNotNullOrEmpty(from.Value, nameof(from));
                return RestClient.Send(from.Value, to.Select(x => AssertNotNullOrEmpty(x.Value, nameof(to))), message, sendSmsOptions, cancellationToken);
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        private static string AssertNotNullOrEmpty(string argument, string argumentName)
        {
            Argument.AssertNotNullOrEmpty(argument, argumentName);
            return argument;
        }
    }
}
