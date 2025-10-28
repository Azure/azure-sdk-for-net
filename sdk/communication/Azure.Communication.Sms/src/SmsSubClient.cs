// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Azure.Communication.Sms.Models;
using Azure.Core;
using Azure.Core.Pipeline;

namespace Azure.Communication.Sms
{
    /// <summary>
    /// The Azure Communication Services SMS messaging sub-client.
    /// </summary>
    public class SmsSubClient
    {
        private readonly ClientDiagnostics _clientDiagnostics;
        internal SmsRestClient RestClient { get; }

        internal SmsSubClient(ClientDiagnostics clientDiagnostics, SmsRestClient restClient)
        {
            _clientDiagnostics = clientDiagnostics;
            RestClient = restClient;
        }

        /// <summary>Initializes a new instance of <see cref="SmsSubClient"/> for mocking.</summary>
        protected SmsSubClient()
        {
            _clientDiagnostics = null;
            RestClient = null;
        }

        /// <summary>
        /// Sends a SMS <paramref name="from"/> a phone number that is acquired by the authenticated account, <paramref name="to"/> another phone number.
        /// </summary>
        /// <param name="from">The sender's phone number that is owned by the authenticated account.</param>
        /// <param name="to">The recipient's phone number.</param>
        /// <param name="message">The contents of the message that will be sent to the recipient. The allowable content is defined by RFC 5724. If the message has more than 160 characters, the server will split it into multiple SMSs automatically.</param>
        /// <param name="options">Optional configuration for sending SMS messages.</param>
        /// <param name="cancellationToken">The cancellation token for the task.</param>
        /// <exception cref="RequestFailedException">The server returned an error. See <see cref="Exception.Message"/> for details returned from the server.</exception>
        /// <exception cref="ArgumentNullException"><paramref name="from"/> is null.</exception>
        /// <exception cref="ArgumentNullException"><paramref name="to"/> is null.</exception>
        /// <exception cref="ArgumentNullException"><paramref name="message"/> is null.</exception>
        public virtual async Task<Response<SmsSendResult>> SendAsync(string from, string to, string message, SmsSendOptions options = default, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(from, nameof(from));
            Argument.AssertNotNullOrEmpty(to, nameof(to));
            Response<IReadOnlyList<SmsSendResult>> response = await SendAsync(from, new[] { to }, message, options, cancellationToken).ConfigureAwait(false);
            return Response.FromValue(response.Value[0], response.GetRawResponse());
        }

        /// <summary>
        /// Sends a SMS <paramref name="from"/> a phone number that is acquired by the authenticated account, <paramref name="to"/> another phone number.
        /// </summary>
        /// <param name="from">The sender's phone number that is owned by the authenticated account.</param>
        /// <param name="to">The recipient's phone number.</param>
        /// <param name="message">The contents of the message that will be sent to the recipient. The allowable content is defined by RFC 5724. If the message has more than 160 characters, the server will split it into multiple SMSs automatically.</param>
        /// <param name="options">Optional configuration for sending SMS messages.</param>
        /// <param name="cancellationToken">The cancellation token for the underlying request.</param>
        /// <exception cref="RequestFailedException">The server returned an error. See <see cref="Exception.Message"/> for details returned from the server.</exception>
        /// <exception cref="ArgumentNullException"><paramref name="from"/> is null.</exception>
        /// <exception cref="ArgumentNullException"><paramref name="to"/> is null.</exception>
        /// <exception cref="ArgumentNullException"><paramref name="message"/> is null.</exception>
        public virtual Response<SmsSendResult> Send(string from, string to, string message, SmsSendOptions options = default, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(from, nameof(from));
            Argument.AssertNotNullOrEmpty(to, nameof(to));
            Response<IReadOnlyList<SmsSendResult>> response = Send(from, new[] { to }, message, options, cancellationToken);
            return Response.FromValue(response.Value[0], response.GetRawResponse());
        }

        /// <summary> Sends an SMS message from a phone number that belongs to the authenticated account. </summary>
        /// <param name="from"> The sender&apos;s phone number in E.164 format that is owned by the authenticated account. </param>
        /// <param name="to"> The recipient&apos;s phone number in E.164 format. In this version, up to 100 recipients in the list is supported. </param>
        /// <param name="message"> The contents of the message that will be sent to the recipient. The allowable content is defined by RFC 5724. </param>
        /// <param name="options"> Optional configuration for sending SMS messages. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="RequestFailedException">The server returned an error. See <see cref="Exception.Message"/> for details returned from the server.</exception>
        /// <exception cref="ArgumentNullException"><paramref name="from"/> is null.</exception>
        /// <exception cref="ArgumentNullException"><paramref name="to"/> is null.</exception>
        /// <exception cref="ArgumentNullException"><paramref name="message"/> is null.</exception>
        public virtual async Task<Response<IReadOnlyList<SmsSendResult>>> SendAsync(string from, IEnumerable<string> to, string message, SmsSendOptions options = default, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(SmsSubClient)}.{nameof(Send)}");
            scope.Start();
            try
            {
                Argument.AssertNotNullOrEmpty(from, nameof(from));
                Argument.AssertNotNullOrEmpty(to, nameof(to));
                IEnumerable<SmsRecipient> recipients = to.Select(x =>
                    new SmsRecipient(Argument.CheckNotNullOrEmpty(x, nameof(to)))
                    {
                        RepeatabilityRequestId = Guid.NewGuid().ToString(),
                        RepeatabilityFirstSent = DateTimeOffset.UtcNow.ToString("r", CultureInfo.InvariantCulture),
                    });

                Response<object> response = await RestClient.SendAsync(from, recipients, message, options, cancellationToken).ConfigureAwait(false);

                if (response.GetRawResponse().Status >= 400)
                {
                    if (response.Value is BadRequestErrorResponse badRequestError)
                    {
                        throw new RequestFailedException(response.GetRawResponse());
                    }
                    if (response.Value is StandardErrorResponse standardError)
                    {
                        throw new RequestFailedException(response.GetRawResponse());
                    }
                }

                var smsSendResponse = (SmsSendResponse)response.Value;
                return Response.FromValue(smsSendResponse.Value, response.GetRawResponse());
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary> Sends an SMS message from a phone number that belongs to the authenticated account. </summary>
        /// <param name="from"> The sender&apos;s phone number in E.164 format that is owned by the authenticated account. </param>
        /// <param name="to"> The recipient&apos;s phone number in E.164 format. In this version, up to 100 recipients in the list is supported. </param>
        /// <param name="message"> The contents of the message that will be sent to the recipient. The allowable content is defined by RFC 5724. </param>
        /// <param name="options"> Optional configuration for sending SMS messages. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="RequestFailedException">The server returned an error. See <see cref="Exception.Message"/> for details returned from the server.</exception>
        /// <exception cref="ArgumentNullException"><paramref name="from"/> is null.</exception>
        /// <exception cref="ArgumentNullException"><paramref name="to"/> is null.</exception>
        /// <exception cref="ArgumentNullException"><paramref name="message"/> is null.</exception>
        public virtual Response<IReadOnlyList<SmsSendResult>> Send(string from, IEnumerable<string> to, string message, SmsSendOptions options = default, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(SmsSubClient)}.{nameof(Send)}");
            scope.Start();
            try
            {
                Argument.AssertNotNullOrEmpty(from, nameof(from));
                Argument.AssertNotNullOrEmpty(to, nameof(to));

                IEnumerable<SmsRecipient> recipients = to.Select(x =>
                    new SmsRecipient(Argument.CheckNotNullOrEmpty(x, nameof(to)))
                    {
                        RepeatabilityRequestId = Guid.NewGuid().ToString(),
                        RepeatabilityFirstSent = DateTimeOffset.UtcNow.ToString("r", CultureInfo.InvariantCulture),
                    });

                Response<object> response = RestClient.Send(from, recipients, message, options, cancellationToken);

                if (response.GetRawResponse().Status >= 400)
                {
                    if (response.Value is BadRequestErrorResponse badRequestError)
                    {
                        throw new RequestFailedException(response.GetRawResponse());
                    }
                    if (response.Value is StandardErrorResponse standardError)
                    {
                        throw new RequestFailedException(response.GetRawResponse());
                    }
                }

                var smsSendResponse = (SmsSendResponse)response.Value;
                return Response.FromValue(smsSendResponse.Value, response.GetRawResponse());
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }
    }
}
