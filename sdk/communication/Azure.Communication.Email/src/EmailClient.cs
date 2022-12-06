// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Azure.Communication.Email.Extensions;
using Azure.Communication.Email.Models;
using Azure.Communication.Pipeline;
using Azure.Core;
using Azure.Core.Pipeline;

namespace Azure.Communication.Email
{
    /// <summary> The Email service client. </summary>
    public partial class EmailClient
    {
        private readonly ClientDiagnostics _clientDiagnostics;

        internal EmailRestClient RestClient { get; }

        /// <summary> Initializes a new instance of EmailClient for mocking. </summary>
        protected EmailClient()
        {
        }

        /// <summary>
        /// Initializes a new instance of <see cref="EmailClient"/>
        /// </summary>
        /// <param name="connectionString">Connection string acquired from the Azure Communication Services resource.</param>
        public EmailClient(string connectionString)
            : this(ConnectionString.Parse(Argument.CheckNotNullOrEmpty(connectionString, nameof(connectionString))),
                 new EmailClientOptions())
        {
        }

        /// <summary> Initializes a new instance of <see cref="EmailClient"/>.</summary>
        /// <param name="connectionString">Connection string acquired from the Azure Communication Services resource.</param>
        /// <param name="options">Client option exposing <see cref="ClientOptions.Diagnostics"/>, <see cref="ClientOptions.Retry"/>, <see cref="ClientOptions.Transport"/>, etc.</param>
        public EmailClient(string connectionString, EmailClientOptions options)
            : this(
                ConnectionString.Parse(Argument.CheckNotNullOrEmpty(connectionString, nameof(connectionString))),
                options ?? new EmailClientOptions())
        {
        }

        /// <summary> Initializes a new instance of <see cref="EmailClient"/>.</summary>
        /// <param name="endpoint">The URI of the Azure Communication Services resource.</param>
        /// <param name="keyCredential">The <see cref="AzureKeyCredential"/> used to authenticate requests.</param>
        /// <param name="options">Client option exposing <see cref="ClientOptions.Diagnostics"/>, <see cref="ClientOptions.Retry"/>, <see cref="ClientOptions.Transport"/>, etc.</param>
        public EmailClient(Uri endpoint, AzureKeyCredential keyCredential, EmailClientOptions options = default)
            : this(
                Argument.CheckNotNull(endpoint, nameof(endpoint)).AbsoluteUri,
                Argument.CheckNotNull(keyCredential, nameof(keyCredential)),
                options ?? new EmailClientOptions())
        {
        }

        /// <summary> Initializes a new instance of <see cref="EmailClient"/>.</summary>
        /// <param name="endpoint">The URI of the Azure Communication Services resource.</param>
        /// <param name="tokenCredential">The TokenCredential used to authenticate requests, such as DefaultAzureCredential.</param>
        /// <param name="options">Client option exposing <see cref="ClientOptions.Diagnostics"/>, <see cref="ClientOptions.Retry"/>, <see cref="ClientOptions.Transport"/>, etc.</param>
        public EmailClient(Uri endpoint, TokenCredential tokenCredential, EmailClientOptions options = default)
            : this(
                Argument.CheckNotNull(endpoint, nameof(endpoint)).AbsoluteUri,
                Argument.CheckNotNull(tokenCredential, nameof(tokenCredential)),
                options ?? new EmailClientOptions())
        { }

        private EmailClient(ConnectionString connectionString, EmailClientOptions options)
            : this(connectionString.GetRequired("endpoint"), options.BuildHttpPipeline(connectionString), options)
        {
        }

        private EmailClient(string endpoint, HttpPipeline httpPipeline, EmailClientOptions options)
        {
            _clientDiagnostics = new ClientDiagnostics(options);
            RestClient = new EmailRestClient(_clientDiagnostics, httpPipeline, endpoint, options.ApiVersion);
        }

        private EmailClient(string endpoint, AzureKeyCredential keyCredential, EmailClientOptions options)
            : this(endpoint, options.BuildHttpPipeline(keyCredential), options)
        {
        }

        private EmailClient(string endpoint, TokenCredential tokenCredential, EmailClientOptions options)
            : this(endpoint, options.BuildHttpPipeline(tokenCredential), options)
        { }

        /// <summary> Gets the status of a message sent previously. </summary>
        /// <param name="messageId"> System generated message id (GUID) returned from a previous call to send email. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response<SendStatusResult>> GetSendStatusAsync(string messageId, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope("EmailClient.GetSendStatus");
            scope.Start();
            try
            {
                if (string.IsNullOrWhiteSpace(messageId))
                {
                    throw new ArgumentException("MessageId cannot be null or empty");
                }

                return await RestClient.GetSendStatusAsync(messageId, cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Gets the status of a message sent previously. </summary>
        /// <param name="messageId"> System generated message id (GUID) returned from a previous call to send email. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<SendStatusResult> GetSendStatus(string messageId, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope("EmailClient.GetSendStatus");
            scope.Start();
            try
            {
                if (string.IsNullOrWhiteSpace(messageId))
                {
                    throw new ArgumentException("MessageId cannot be null or empty");
                }

                return RestClient.GetSendStatus(messageId, cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Queues an email message to be sent to one or more recipients. </summary>
        /// <param name="emailMessage"> Message payload for sending an email. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response<SendEmailResult>> SendAsync(
            EmailMessage emailMessage,
            CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope("EmailClient.Send");
            scope.Start();
            try
            {
                ValidateEmailMessage(emailMessage);
                ResponseWithHeaders<EmailSendHeaders> response = (await RestClient.SendAsync(
                    Guid.NewGuid().ToString(),
                    DateTimeOffset.UtcNow.ToString("r", CultureInfo.InvariantCulture),
                    emailMessage,
                    cancellationToken).ConfigureAwait(false));

                Response rawResponse = response.GetRawResponse();
                if (!rawResponse.Headers.TryGetValue("x-ms-request-id", out var messageId))
                {
                    messageId = null;
                }

                return Response.FromValue(new SendEmailResult(messageId), response);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Queues an email message to be sent to one or more recipients. </summary>
        /// <param name="emailMessage"> Message payload for sending an email. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<SendEmailResult> Send(
            EmailMessage emailMessage,
            CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope("EmailClient.Send");
            scope.Start();
            try
            {
                ValidateEmailMessage(emailMessage);
                ResponseWithHeaders<EmailSendHeaders> response = RestClient.Send(
                    Guid.NewGuid().ToString(),
                    DateTimeOffset.UtcNow.ToString("r", CultureInfo.InvariantCulture),
                    emailMessage,
                    cancellationToken);

                Response rawResponse = response.GetRawResponse();
                if (!rawResponse.Headers.TryGetValue("x-ms-request-id", out var messageId))
                {
                    messageId = null;
                }

                return Response.FromValue(new SendEmailResult(messageId), response);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        private static void ValidateEmailMessage(EmailMessage emailMessage)
        {
            if (emailMessage == null)
            {
                throw new ArgumentNullException(nameof(emailMessage));
            }

            ValidateEmailCustomHeaders(emailMessage);
            ValidateEmailContent(emailMessage);
            ValidateSenderEmailAddress(emailMessage);
            ValidateRecipients(emailMessage);
            ValidateReplyToEmailAddresses(emailMessage);
            ValidateAttachmentContent(emailMessage);
        }

        private static void ValidateEmailCustomHeaders(EmailMessage emailMessage)
        {
            // Do not allow empty/null header names and values (for custom headers only)
            emailMessage.CustomHeaders?.ToList().ForEach(header => header.Validate());

            // Validate header names are all unique
            var messageHeaders = new HashSet<string>(StringComparer.InvariantCultureIgnoreCase);
            foreach (EmailCustomHeader header in emailMessage.CustomHeaders ?? Enumerable.Empty<EmailCustomHeader>())
            {
                if (!messageHeaders.Add(header.Name))
                {
                    throw new ArgumentException($"{header.Name}" + ErrorMessages.DuplicateHeaderName);
                }
            }
        }

        private static void ValidateEmailContent(EmailMessage emailMessage)
        {
            // Atleast one type of content (plaintext or html) should be present and be non-empty
            if (string.IsNullOrWhiteSpace(emailMessage.Content.Html) &&
                string.IsNullOrWhiteSpace(emailMessage.Content.PlainText))
            {
                throw new ArgumentException(ErrorMessages.EmptyContent);
            }

            if (string.IsNullOrWhiteSpace(emailMessage.Content.Subject))
            {
                throw new ArgumentException(ErrorMessages.EmptySubject);
            }
        }

        private static void ValidateSenderEmailAddress(EmailMessage emailMessage)
        {
            if (string.IsNullOrEmpty(emailMessage.Sender) || !ValidEmailAddress(emailMessage.Sender))
            {
                throw new ArgumentException(ErrorMessages.InvalidSenderEmail);
            }
        }

        private static void ValidateRecipients(EmailMessage emailMessage)
        {
            emailMessage.Recipients.Validate();
        }

        private static void ValidateReplyToEmailAddresses(EmailMessage emailMessage)
        {
            emailMessage.ReplyTo?.Validate();
        }

        private static void ValidateAttachmentContent(EmailMessage emailMessage)
        {
            foreach (EmailAttachment attachment in emailMessage.Attachments ?? Enumerable.Empty<EmailAttachment>())
            {
                attachment.ValidateAttachmentContent();
            }
        }

        private static bool ValidEmailAddress(string sender)
        {
            try
            {
                var emailAddress = new EmailAddress(sender);
                emailAddress.ValidateEmailAddress();
            }
            catch
            {
                return false;
            }

            return true;
        }
    }
}
