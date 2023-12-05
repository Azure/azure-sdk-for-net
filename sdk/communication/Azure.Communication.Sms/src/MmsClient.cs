// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Azure.Communication.Pipeline;
using Azure.Communication.Sms.Models;
using Azure.Core;
using Azure.Core.Pipeline;

namespace Azure.Communication.Sms
{
    /// <summary>
    /// The Azure Communication Services MMS client.
    /// </summary>
    public class MmsClient
    {
        private readonly ClientDiagnostics _clientDiagnostics;
        internal MmsRestClient RestClient { get; }

        #region public constructors - all arguments need null check

        /// <summary> Initializes a new instance of <see cref="MmsClient"/>.</summary>
        /// <param name="connectionString">Connection string acquired from the Azure Communication Services resource.</param>
        public MmsClient(string connectionString)
            : this(
                ConnectionString.Parse(Argument.CheckNotNullOrEmpty(connectionString, nameof(connectionString))),
                new MmsClientOptions())
        { }

        /// <summary> Initializes a new instance of <see cref="MmsClient"/>.</summary>
        /// <param name="connectionString">Connection string acquired from the Azure Communication Services resource.</param>
        /// <param name="options">Client option exposing <see cref="ClientOptions.Diagnostics"/>, <see cref="ClientOptions.Retry"/>, <see cref="ClientOptions.Transport"/>, etc.</param>
        public MmsClient(string connectionString, MmsClientOptions options)
            : this(
                ConnectionString.Parse(Argument.CheckNotNullOrEmpty(connectionString, nameof(connectionString))),
                options ?? new MmsClientOptions())
        { }

        /// <summary> Initializes a new instance of <see cref="MmsClient"/>.</summary>
        /// <param name="endpoint">The URI of the Azure Communication Services resource.</param>
        /// <param name="keyCredential">The <see cref="AzureKeyCredential"/> used to authenticate requests.</param>
        /// <param name="options">Client option exposing <see cref="ClientOptions.Diagnostics"/>, <see cref="ClientOptions.Retry"/>, <see cref="ClientOptions.Transport"/>, etc.</param>
        public MmsClient(Uri endpoint, AzureKeyCredential keyCredential, MmsClientOptions options = default)
            : this(
                Argument.CheckNotNull(endpoint, nameof(endpoint)).AbsoluteUri,
                Argument.CheckNotNull(keyCredential, nameof(keyCredential)),
                options ?? new MmsClientOptions())
        { }

        /// <summary> Initializes a new instance of <see cref="MmsClient"/>.</summary>
        /// <param name="endpoint">The URI of the Azure Communication Services resource.</param>
        /// <param name="tokenCredential">The TokenCredential used to authenticate requests, such as DefaultAzureCredential.</param>
        /// <param name="options">Client option exposing <see cref="ClientOptions.Diagnostics"/>, <see cref="ClientOptions.Retry"/>, <see cref="ClientOptions.Transport"/>, etc.</param>
        public MmsClient(Uri endpoint, TokenCredential tokenCredential, MmsClientOptions options = default)
            : this(
                Argument.CheckNotNull(endpoint, nameof(endpoint)).AbsoluteUri,
                Argument.CheckNotNull(tokenCredential, nameof(tokenCredential)),
                options ?? new MmsClientOptions())
        { }

        #endregion

        #region private constructors

        private MmsClient(ConnectionString connectionString, MmsClientOptions options)
            : this(connectionString.GetRequired("endpoint"), options.BuildHttpPipeline(connectionString), options)
        { }

        private MmsClient(string endpoint, TokenCredential tokenCredential, MmsClientOptions options)
            : this(endpoint, options.BuildHttpPipeline(tokenCredential), options)
        { }

        private MmsClient(string endpoint, AzureKeyCredential keyCredential, MmsClientOptions options)
            : this(endpoint, options.BuildHttpPipeline(keyCredential), options)
        { }

        private MmsClient(string endpoint, HttpPipeline httpPipeline, MmsClientOptions options)
        {
            _clientDiagnostics = new ClientDiagnostics(options);
            RestClient = new MmsRestClient(_clientDiagnostics, httpPipeline, new Uri(endpoint), options.ApiVersion);
        }

        #endregion

        /// <summary>Initializes a new instance of <see cref="MmsClient"/> for mocking.</summary>
        protected MmsClient()
        {
            _clientDiagnostics = null;
            RestClient = null;
        }

        /// <summary>
        /// Sends an MMS <paramref name="from"/> a phone number that is acquired by the authenticated account, <paramref name="to"/> another phone number.
        /// </summary>
        /// <param name="from"> The sender's identifier (typically phone number in E.164 format) that is owned by the authenticated account. </param>
        /// <param name="to">The recipient's phone number in E.164 format.</param>
        /// <param name="attachments"> A list of media attachments to include as part of the MMS. You can have maximum 10 attachments. </param>
        /// <param name="message">Optional message that will be sent to the recipient.</param>
        /// <param name="options">Optional configuration for sending MMS messages.</param>
        /// <param name="cancellationToken">The cancellation token for the task.</param>
        /// <exception cref="RequestFailedException">The server returned an error. See <see cref="Exception.Message"/> for details returned from the server.</exception>
        /// <exception cref="ArgumentNullException"><paramref name="from"/> is null.</exception>
        /// <exception cref="ArgumentNullException"><paramref name="to"/> is null.</exception>
        /// <exception cref="ArgumentNullException"><paramref name="message"/> is null.</exception>
        public virtual async Task<Response<MmsSendResult>> SendAsync(string from, string to, IEnumerable<MmsAttachment> attachments, string message = null, MmsSendOptions options = default, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(from, nameof(from));
            Argument.AssertNotNullOrEmpty(to, nameof(to));
            Response<IReadOnlyList<MmsSendResult>> response = await SendAsync(from, new[] { to }, attachments, message, options, cancellationToken).ConfigureAwait(false);
            return Response.FromValue(response.Value[0], response.GetRawResponse());
        }

        /// <summary>
        /// Sends an MMS <paramref name="from"/> a phone number that is acquired by the authenticated account, <paramref name="to"/> another phone number.
        /// </summary>
        /// <param name="from"> The sender's identifier (typically phone number in E.164 format) that is owned by the authenticated account. </param>
        /// <param name="to">The recipient's phone number in E.164 format.</param>
        /// <param name="attachments"> A list of media attachments to include as part of the MMS. You can have maximum 10 attachments. </param>
        /// <param name="message">Optional message that will be sent to the recipient.</param>
        /// <param name="options">Optional configuration for sending MMS messages.</param>
        /// <param name="cancellationToken">The cancellation token for the underlying request.</param>
        /// <exception cref="RequestFailedException">The server returned an error. See <see cref="Exception.Message"/> for details returned from the server.</exception>
        /// <exception cref="ArgumentNullException"><paramref name="from"/> is null.</exception>
        /// <exception cref="ArgumentNullException"><paramref name="to"/> is null.</exception>
        /// <exception cref="ArgumentNullException"><paramref name="message"/> is null.</exception>
        public virtual Response<MmsSendResult> Send(string from, string to, IEnumerable<MmsAttachment> attachments, string message = null, MmsSendOptions options = default, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(from, nameof(from));
            Argument.AssertNotNullOrEmpty(to, nameof(to));
            Response<IReadOnlyList<MmsSendResult>> response = Send(from, new[] { to }, attachments, message, options, cancellationToken);
            return Response.FromValue(response.Value[0], response.GetRawResponse());
        }

        /// <summary> Sends MMS message from a phone number that belongs to the authenticated account. </summary>
        /// <param name="from"> The sender's identifier (typically phone number in E.164 format) that is owned by the authenticated account. </param>
        /// <param name="to"> The recipient phone numbers in E.164 format. </param>
        /// <param name="attachments"> A list of media attachments to include as part of the MMS. You can have maximum 10 attachments. </param>
        /// <param name="message">Optional message that will be sent to the recipient. </param>
        /// <param name="options"> Optional configuration for sending MMS messages. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="RequestFailedException">The server returned an error. See <see cref="Exception.Message"/> for details returned from the server.</exception>
        /// <exception cref="ArgumentNullException"><paramref name="from"/> is null.</exception>
        /// <exception cref="ArgumentNullException"><paramref name="to"/> is null.</exception>
        /// <exception cref="ArgumentNullException"><paramref name="message"/> is null.</exception>
        public virtual async Task<Response<IReadOnlyList<MmsSendResult>>> SendAsync(string from, IEnumerable<string> to, IEnumerable<MmsAttachment> attachments, string message = null, MmsSendOptions options = default, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(MmsClient)}.{nameof(Send)}");
            scope.Start();
            try
            {
                Argument.AssertNotNullOrEmpty(from, nameof(from));
                Argument.AssertNotNullOrEmpty(to, nameof(to));
                IEnumerable<MmsRecipient> recipients = to.Select(x =>
                    new MmsRecipient(Argument.CheckNotNullOrEmpty(x, nameof(to)))
                    {
                        RepeatabilityRequestId = Guid.NewGuid().ToString(),
                        RepeatabilityFirstSent = DateTimeOffset.UtcNow.ToString("r", CultureInfo.InvariantCulture),
                    });

                Response<MmsSendResponse> response = await RestClient.SendAsync(from, recipients, attachments, message, options, cancellationToken).ConfigureAwait(false);
                return Response.FromValue(response.Value.Value, response.GetRawResponse());
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary> Sends an MMS message from a phone number that belongs to the authenticated account. </summary>
        /// <param name="from"> The sender's identifier (typically phone number in E.164 format) that is owned by the authenticated account. </param>
        /// <param name="to"> The recipient phone numbers in E.164 format. </param>
        /// <param name="attachments"> A list of media attachments to include as part of the MMS. You can have maximum 10 attachments. </param>
        /// <param name="message">Optional message that will be sent to the recipient. </param>
        /// <param name="options"> Optional configuration for sending MMS messages. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="RequestFailedException">The server returned an error. See <see cref="Exception.Message"/> for details returned from the server.</exception>
        /// <exception cref="ArgumentNullException"><paramref name="from"/> is null.</exception>
        /// <exception cref="ArgumentNullException"><paramref name="to"/> is null.</exception>
        /// <exception cref="ArgumentNullException"><paramref name="message"/> is null.</exception>
        public virtual Response<IReadOnlyList<MmsSendResult>> Send(string from, IEnumerable<string> to, IEnumerable<MmsAttachment> attachments, string message = null, MmsSendOptions options = default, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(MmsClient)}.{nameof(Send)}");
            scope.Start();
            try
            {
                Argument.AssertNotNullOrEmpty(from, nameof(from));
                Argument.AssertNotNullOrEmpty(to, nameof(to));

                IEnumerable<MmsRecipient> recipients = to.Select(x =>
                    new MmsRecipient(Argument.CheckNotNullOrEmpty(x, nameof(to)))
                    {
                        RepeatabilityRequestId = Guid.NewGuid().ToString(),
                        RepeatabilityFirstSent = DateTimeOffset.UtcNow.ToString("r", CultureInfo.InvariantCulture),
                    });

                Response<MmsSendResponse> response = RestClient.Send(from, recipients, attachments, message, options, cancellationToken);
                return Response.FromValue(response.Value.Value, response.GetRawResponse());
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }
    }
}
