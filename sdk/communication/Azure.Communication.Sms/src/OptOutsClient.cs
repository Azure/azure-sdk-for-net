// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Azure.Communication.Sms.Models;
using Azure.Core.Pipeline;

namespace Azure.Communication.Sms
{
    /// <summary>
    /// The Azure Communication Services SMS Opt Out Management client.
    /// </summary>
    public class OptOutsClient
    {
        private readonly ClientDiagnostics _clientDiagnostics;

        internal OptOutsRestClient OptOutsRestClient;

        internal OptOutsClient(ClientDiagnostics clientDiagnostics, HttpPipeline pipeline, Uri endpoint, string apiVersion = "2024-12-10-preview")
        {
            Argument.CheckNotNull(clientDiagnostics, nameof(clientDiagnostics));
            Argument.CheckNotNull(pipeline, nameof(pipeline));
            Argument.CheckNotNull(endpoint, nameof(endpoint));
            Argument.CheckNotNull(apiVersion, nameof(apiVersion));

            OptOutsRestClient = new OptOutsRestClient(clientDiagnostics, pipeline, endpoint, apiVersion);
            _clientDiagnostics = clientDiagnostics;
        }

        /// <summary>Initializes a new instance of <see cref="SmsClient"/> for mocking.</summary>
        protected OptOutsClient()
        {
            _clientDiagnostics = null;
            OptOutsRestClient = null;
        }

        /// <summary>
        /// Checks if <paramref name="to"/> phone numbers are opted out from <paramref name="from"/> phone number.
        /// </summary>
        /// <param name="from">The sender's phone number that is owned by the authenticated account.</param>
        /// <param name="to">The recipient's phone number.</param>
        /// <param name="cancellationToken">The cancellation token for the task.</param>
        /// <exception cref="RequestFailedException">The server returned an error. See <see cref="Exception.Message"/> for details returned from the server.</exception>
        /// <exception cref="ArgumentNullException"><paramref name="from"/> is null.</exception>
        /// <exception cref="ArgumentNullException"><paramref name="to"/> is null.</exception>
        public virtual async Task<Response<OptOutResponse>> CheckAsync(string from, IEnumerable<string> to, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(SmsClient)}.{nameof(OptOutsClient)}.{nameof(CheckAsync)}");
            scope.Start();
            try
            {
                Argument.AssertNotNullOrEmpty(from, nameof(from));
                Argument.AssertNotNullOrEmpty(to, nameof(to));
                IEnumerable<OptOutRecipient> recipients = to.Select(x => new OptOutRecipient(Argument.CheckNotNullOrEmpty(x, nameof(to))));

                Response<OptOutResponse> response = await OptOutsRestClient.CheckAsync(from, recipients, cancellationToken).ConfigureAwait(false);
                return Response.FromValue(response.Value, response.GetRawResponse());
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary>
        /// Checks if <paramref name="to"/> phone numbers are opted out from <paramref name="from"/> phone number.
        /// </summary>
        /// <param name="from">The sender's phone number that is owned by the authenticated account.</param>
        /// <param name="to">The recipient's phone number.</param>
        /// <param name="cancellationToken">The cancellation token for the task.</param>
        /// <exception cref="RequestFailedException">The server returned an error. See <see cref="Exception.Message"/> for details returned from the server.</exception>
        /// <exception cref="ArgumentNullException"><paramref name="from"/> is null.</exception>
        /// <exception cref="ArgumentNullException"><paramref name="to"/> is null.</exception>
        public virtual Response<OptOutResponse> Check(string from, IEnumerable<string> to, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(SmsClient)}.{nameof(OptOutsClient)}.{nameof(Check)}");
            scope.Start();
            try
            {
                Argument.AssertNotNullOrEmpty(from, nameof(from));
                Argument.AssertNotNullOrEmpty(to, nameof(to));

                IEnumerable<OptOutRecipient> recipients = to.Select(x => new OptOutRecipient(Argument.CheckNotNullOrEmpty(x, nameof(to))));

                Response<OptOutResponse> response = OptOutsRestClient.Check(from, recipients, cancellationToken);
                return Response.FromValue(response.Value, response.GetRawResponse());
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary>
        /// Opts out <paramref name="to"/> phone numbers from receiving SMS from <paramref name="from"/> phone number.
        /// </summary>
        /// <param name="from">The sender's phone number that is owned by the authenticated account.</param>
        /// <param name="to">The recipient's phone number which should be opted out.</param>
        /// <param name="cancellationToken">The cancellation token for the task.</param>
        /// <exception cref="RequestFailedException">The server returned an error. See <see cref="Exception.Message"/> for details returned from the server.</exception>
        /// <exception cref="ArgumentNullException"><paramref name="from"/> is null.</exception>
        /// <exception cref="ArgumentNullException"><paramref name="to"/> is null.</exception>
        public virtual async Task<Response<OptOutChangeResponse>> AddAsync(string from, IEnumerable<string> to, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(SmsClient)}.{nameof(OptOutsClient)}.{nameof(AddAsync)}");
            scope.Start();
            try
            {
                Argument.AssertNotNullOrEmpty(from, nameof(from));
                Argument.AssertNotNullOrEmpty(to, nameof(to));
                IEnumerable<OptOutRecipient> recipients = to.Select(x => new OptOutRecipient(Argument.CheckNotNullOrEmpty(x, nameof(to))));

                Response<OptOutResponse> response = await OptOutsRestClient.AddAsync(from, recipients, cancellationToken).ConfigureAwait(false);
                OptOutChangeResponse result = new OptOutChangeResponse(response.Value.Value.Select(r => new OptOutChangeResponseItem(r.To, r.HttpStatusCode, r.ErrorMessage)));

                return Response.FromValue(result, response.GetRawResponse());
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary>
        /// Opts out <paramref name="to"/> phone numbers from receiving SMS from <paramref name="from"/> phone number.
        /// </summary>
        /// <param name="from">The sender's phone number that is owned by the authenticated account.</param>
        /// <param name="to">The recipient's phone number which should be opted out.</param>
        /// <param name="cancellationToken">The cancellation token for the task.</param>
        /// <exception cref="RequestFailedException">The server returned an error. See <see cref="Exception.Message"/> for details returned from the server.</exception>
        /// <exception cref="ArgumentNullException"><paramref name="from"/> is null.</exception>
        /// <exception cref="ArgumentNullException"><paramref name="to"/> is null.</exception>
        public virtual Response<OptOutChangeResponse> Add(string from, IEnumerable<string> to, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(SmsClient)}.{nameof(OptOutsClient)}.{nameof(Add)}");
            scope.Start();
            try
            {
                Argument.AssertNotNullOrEmpty(from, nameof(from));
                Argument.AssertNotNullOrEmpty(to, nameof(to));

                IEnumerable<OptOutRecipient> recipients = to.Select(x => new OptOutRecipient(Argument.CheckNotNullOrEmpty(x, nameof(to))));
                Response<OptOutResponse> response = OptOutsRestClient.Add(from, recipients, cancellationToken);
                OptOutChangeResponse result = new OptOutChangeResponse(response.Value.Value.Select(r => new OptOutChangeResponseItem(r.To, r.HttpStatusCode, r.ErrorMessage)));

                return Response.FromValue(result, response.GetRawResponse());
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary>
        /// Opts in <paramref name="to"/> phone numbers to receive SMS from <paramref name="from"/> phone number.
        /// </summary>
        /// <param name="from">The sender's phone number that is owned by the authenticated account.</param>
        /// <param name="to">The recipient's phone number which should be opted in.</param>
        /// <param name="cancellationToken">The cancellation token for the task.</param>
        /// <exception cref="RequestFailedException">The server returned an error. See <see cref="Exception.Message"/> for details returned from the server.</exception>
        /// <exception cref="ArgumentNullException"><paramref name="from"/> is null.</exception>
        /// <exception cref="ArgumentNullException"><paramref name="to"/> is null.</exception>
        public virtual async Task<Response<OptOutChangeResponse>> RemoveAsync(string from, IEnumerable<string> to, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(SmsClient)}.{nameof(OptOutsClient)}.{nameof(RemoveAsync)}");
            scope.Start();
            try
            {
                Argument.AssertNotNullOrEmpty(from, nameof(from));
                Argument.AssertNotNullOrEmpty(to, nameof(to));
                IEnumerable<OptOutRecipient> recipients = to.Select(x => new OptOutRecipient(Argument.CheckNotNullOrEmpty(x, nameof(to))));

                Response<OptOutResponse> response = await OptOutsRestClient.RemoveAsync(from, recipients, cancellationToken).ConfigureAwait(false);
                OptOutChangeResponse result = new OptOutChangeResponse(response.Value.Value.Select(r => new OptOutChangeResponseItem(r.To, r.HttpStatusCode, r.ErrorMessage)));

                return Response.FromValue(result, response.GetRawResponse());
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary>
        /// Opts in <paramref name="to"/> phone numbers to receive SMS from <paramref name="from"/> phone number.
        /// </summary>
        /// <param name="from">The sender's phone number that is owned by the authenticated account.</param>
        /// <param name="to">The recipient's phone number which should be opted in.</param>
        /// <param name="cancellationToken">The cancellation token for the task.</param>
        /// <exception cref="RequestFailedException">The server returned an error. See <see cref="Exception.Message"/> for details returned from the server.</exception>
        /// <exception cref="ArgumentNullException"><paramref name="from"/> is null.</exception>
        /// <exception cref="ArgumentNullException"><paramref name="to"/> is null.</exception>
        public virtual Response<OptOutChangeResponse> Remove(string from, IEnumerable<string> to, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(SmsClient)}.{nameof(OptOutsClient)}.{nameof(Remove)}");
            scope.Start();
            try
            {
                Argument.AssertNotNullOrEmpty(from, nameof(from));
                Argument.AssertNotNullOrEmpty(to, nameof(to));

                IEnumerable<OptOutRecipient> recipients = to.Select(x => new OptOutRecipient(Argument.CheckNotNullOrEmpty(x, nameof(to))));
                Response<OptOutResponse> response = OptOutsRestClient.Remove(from, recipients, cancellationToken);
                OptOutChangeResponse result = new OptOutChangeResponse(response.Value.Value.Select(r => new OptOutChangeResponseItem(r.To, r.HttpStatusCode, r.ErrorMessage)));

                return Response.FromValue(result, response.GetRawResponse());
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }
    }
}
