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
    [CodeGenClient("EmailClient")]
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
            : this(new Uri(connectionString.GetRequired("endpoint")), options.BuildHttpPipeline(connectionString), options)
        {
        }

        private EmailClient(Uri endpoint, HttpPipeline httpPipeline, EmailClientOptions options)
        {
            _clientDiagnostics = new ClientDiagnostics(options);
            _pipeline = httpPipeline;
            RestClient = new EmailRestClient(_clientDiagnostics, httpPipeline, endpoint, options.ApiVersion);
        }

        private EmailClient(string endpoint, AzureKeyCredential keyCredential, EmailClientOptions options)
            : this(new Uri(endpoint), options.BuildHttpPipeline(keyCredential), options)
        {
        }

        private EmailClient(string endpoint, TokenCredential tokenCredential, EmailClientOptions options)
            : this(new Uri(endpoint), options.BuildHttpPipeline(tokenCredential), options)
        { }

        /// <summary> Queues an email message to be sent to one or more recipients. </summary>
        /// <param name="message"> Message payload for sending an email. </param>
        /// <param name="operationId"> ID of the send email operation. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<EmailSendOperation> StartSendAsync(
            EmailMessage message,
            Guid? operationId = null,
            CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope("EmailClient.StartSend");
            scope.Start();
            try
            {
                return await SendEmailInternalAsync(message, operationId, cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Queues an email message to be sent to a single recipient. </summary>
        /// <param name="senderEmail"> From address of the email. </param>
        /// <param name="toRecipient"> Email address of the TO recipient. </param>
        /// <param name="subject"> Subject for the email. </param>
        /// <param name="html"> Email body in HTML format. </param>
        /// <param name="plainText"> Email body in plain text format. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<EmailSendOperation> StartSendAsync(
            string senderEmail,
            string toRecipient,
            string subject,
            string html,
            string plainText = "",
            CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope("EmailClient.StartSend");
            scope.Start();
            try
            {
                EmailMessage message = new EmailMessage(
                    senderEmail,
                    new EmailContent(subject)
                    {
                        PlainText = plainText,
                        Html = html
                    },
                    new EmailRecipients(new List<EmailAddress>()
                    {
                        new EmailAddress(toRecipient)
                    }));
                return await SendEmailInternalAsync(message, null, cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Queues an email message to be sent to one or more recipients. </summary>
        /// <param name="message"> Message payload for sending an email. </param>
        /// <param name="operationId"> ID of the send email operation. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual EmailSendOperation StartSend(
            EmailMessage message,
            Guid? operationId = null,
            CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope("EmailClient.Send");
            scope.Start();
            try
            {
                return SendEmailInternal(message, operationId, cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Queues an email message to be sent to a single recipient. </summary>
        /// <param name="senderEmail"> From address of the email. </param>
        /// <param name="toRecipient"> Email address of the TO recipient. </param>
        /// <param name="subject"> Subject for the email. </param>
        /// <param name="html"> Email body in HTML format. </param>
        /// <param name="plainText"> Email body in plain text format. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual EmailSendOperation StartSend(
            string senderEmail,
            string toRecipient,
            string subject,
            string html,
            string plainText = "",
            CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope("EmailClient.Send");
            scope.Start();
            try
            {
                EmailMessage message = new EmailMessage(
                    senderEmail,
                    new EmailContent(subject)
                    {
                        PlainText = plainText,
                        Html = html
                    },
                    new EmailRecipients(new List<EmailAddress>()
                    {
                        new EmailAddress(toRecipient)
                    }));
                return SendEmailInternal(message, null, cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        private async Task<EmailSendOperation> SendEmailInternalAsync(
            EmailMessage message,
            Guid? operationId,
            CancellationToken cancellationToken)
        {
            ValidateEmailMessage(message);

            operationId ??= Guid.NewGuid();
            var originalResponse = await RestClient.SendAsync(message, operationId, cancellationToken).ConfigureAwait(false);
            return new EmailSendOperation(_clientDiagnostics, _pipeline, RestClient.CreateSendRequest(message, operationId).Request, originalResponse);
        }

        private EmailSendOperation SendEmailInternal(
            EmailMessage message,
            Guid? operationId,
            CancellationToken cancellationToken)
        {
            ValidateEmailMessage(message);

            operationId ??= Guid.NewGuid();
            var originalResponse = RestClient.Send(message, operationId, cancellationToken);
            return new EmailSendOperation(_clientDiagnostics, _pipeline, RestClient.CreateSendRequest(message, operationId).Request, originalResponse);
        }

        private static void ValidateEmailMessage(EmailMessage emailMessage)
        {
            if (emailMessage == null)
            {
                throw new ArgumentNullException(nameof(emailMessage));
            }

            ValidateEmailHeaders(emailMessage);
            ValidateEmailContent(emailMessage);
            ValidateSenderEmailAddress(emailMessage);
            ValidateRecipients(emailMessage);
            ValidateReplyToEmailAddresses(emailMessage);
            ValidateAttachmentContent(emailMessage);
        }

        private static void ValidateEmailHeaders(EmailMessage emailMessage)
        {
            // Do not allow empty/null header names and values (for custom headers only)
            emailMessage.Headers?.ToList().ForEach(header =>
            {
                if (string.IsNullOrWhiteSpace(header.Value))
                {
                    throw new ArgumentException(ErrorMessages.EmptyHeaderValue);
                }
            });
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
            if (string.IsNullOrEmpty(emailMessage.SenderEmail) || !ValidEmailAddress(emailMessage.SenderEmail))
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
