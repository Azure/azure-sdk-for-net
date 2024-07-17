// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Azure.Communication.Pipeline;
using Azure.Core;
using Azure.Core.Pipeline;

namespace Azure.Communication.Email
{
    /// <summary> The Email service client. </summary>
    public partial class EmailClient
    {
        internal readonly ClientDiagnostics _clientDiagnostics;

        internal readonly EmailRestClient _restClient;

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
        /// <param name="credential">The <see cref="AzureKeyCredential"/> used to authenticate requests.</param>
        /// <param name="options">Client option exposing <see cref="ClientOptions.Diagnostics"/>, <see cref="ClientOptions.Retry"/>, <see cref="ClientOptions.Transport"/>, etc.</param>
        public EmailClient(Uri endpoint, AzureKeyCredential credential, EmailClientOptions options = default)
            : this(
                Argument.CheckNotNull(endpoint, nameof(endpoint)).AbsoluteUri,
                Argument.CheckNotNull(credential, nameof(credential)),
                options ?? new EmailClientOptions())
        {
        }

        /// <summary> Initializes a new instance of <see cref="EmailClient"/>.</summary>
        /// <param name="endpoint">The URI of the Azure Communication Services resource.</param>
        /// <param name="credential">The TokenCredential used to authenticate requests, such as DefaultAzureCredential.</param>
        /// <param name="options">Client option exposing <see cref="ClientOptions.Diagnostics"/>, <see cref="ClientOptions.Retry"/>, <see cref="ClientOptions.Transport"/>, etc.</param>
        public EmailClient(Uri endpoint, TokenCredential credential, EmailClientOptions options = default)
            : this(
                Argument.CheckNotNull(endpoint, nameof(endpoint)).AbsoluteUri,
                Argument.CheckNotNull(credential, nameof(credential)),
                options ?? new EmailClientOptions())
        { }

        private EmailClient(ConnectionString connectionString, EmailClientOptions options)
            : this(new Uri(connectionString.GetRequired("endpoint")), options.BuildHttpPipeline(connectionString), options)
        {
        }

        private EmailClient(Uri endpoint, HttpPipeline httpPipeline, EmailClientOptions options)
        {
            _clientDiagnostics = new ClientDiagnostics(options);
            _restClient = new EmailRestClient(_clientDiagnostics, httpPipeline, endpoint, options.ApiVersion);
        }

        private EmailClient(string endpoint, AzureKeyCredential credential, EmailClientOptions options)
            : this(new Uri(endpoint), options.BuildHttpPipeline(credential), options)
        {
        }

        private EmailClient(string endpoint, TokenCredential credential, EmailClientOptions options)
            : this(new Uri(endpoint), options.BuildHttpPipeline(credential), options)
        { }

        /// <summary> Queues an email message to be sent to one or more recipients. </summary>
        /// <param name="wait"> <see cref="WaitUntil.Completed"/>
        /// if the method should wait to return until the long-running operation has completed on the service;
        /// <see cref="WaitUntil.Started"/> if it should return after starting the operation.
        /// For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="message"> Message payload for sending an email. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<EmailSendOperation> SendAsync(
            WaitUntil wait,
            EmailMessage message,
            CancellationToken cancellationToken = default)
        {
            var operationId = Guid.NewGuid();
            return await SendAsync(wait, message, operationId, cancellationToken).ConfigureAwait(false);
        }

        /// <summary> Queues an email message to be sent to one or more recipients. </summary>
        /// <param name="wait"> <see cref="WaitUntil.Completed"/>
        /// if the method should wait to return until the long-running operation has completed on the service;
        /// <see cref="WaitUntil.Started"/> if it should return after starting the operation.
        /// For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="message"> Message payload for sending an email. </param>
        /// <param name="operationId"> The ID to identify the long running operation. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<EmailSendOperation> SendAsync(
            WaitUntil wait,
            EmailMessage message,
            Guid operationId,
            CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope("EmailClient.Send");
            scope.Start();
            try
            {
                return await SendEmailInternalAsync(wait, message, operationId, cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Queues an email message to be sent to a single recipient. </summary>
        /// <param name="wait"> <see cref="WaitUntil.Completed"/>
        /// if the method should wait to return until the long-running operation has completed on the service;
        /// <see cref="WaitUntil.Started"/> if it should return after starting the operation.
        /// For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="senderAddress"> From address of the email. </param>
        /// <param name="recipientAddress"> Email address of the TO recipient. </param>
        /// <param name="subject"> Subject for the email. </param>
        /// <param name="htmlContent"> Email body in HTML format. </param>
        /// <param name="plainTextContent"> Email body in plain text format. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<EmailSendOperation> SendAsync(
            WaitUntil wait,
            string senderAddress,
            string recipientAddress,
            string subject,
            string htmlContent,
            string plainTextContent = default,
            CancellationToken cancellationToken = default)
        {
            var operationId = Guid.NewGuid();
            return await SendAsync(wait, senderAddress, recipientAddress, subject,
                htmlContent, operationId, plainTextContent, cancellationToken).ConfigureAwait(false);
        }

        /// <summary> Queues an email message to be sent to a single recipient. </summary>
        /// <param name="wait"> <see cref="WaitUntil.Completed"/>
        /// if the method should wait to return until the long-running operation has completed on the service;
        /// <see cref="WaitUntil.Started"/> if it should return after starting the operation.
        /// For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="senderAddress"> From address of the email. </param>
        /// <param name="recipientAddress"> Email address of the TO recipient. </param>
        /// <param name="subject"> Subject for the email. </param>
        /// <param name="htmlContent"> Email body in HTML format. </param>
        /// <param name="plainTextContent"> Email body in plain text format. </param>
        /// <param name="operationId"> The ID to identify the long running operation. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<EmailSendOperation> SendAsync(
            WaitUntil wait,
            string senderAddress,
            string recipientAddress,
            string subject,
            string htmlContent,
            Guid operationId,
            string plainTextContent = default,
            CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope("EmailClient.Send");
            scope.Start();
            try
            {
                EmailMessage message = new EmailMessage(
                    senderAddress,
                    new EmailRecipients(new List<EmailAddress>()
                    {
                        new EmailAddress(recipientAddress)
                    }),
                    new EmailContent(subject)
                    {
                        PlainText = plainTextContent,
                        Html = htmlContent
                    });
                return await SendEmailInternalAsync(wait, message, operationId, cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Queues an email message to be sent to one or more recipients. </summary>
        /// <param name="wait"> <see cref="WaitUntil.Completed"/>
        /// if the method should wait to return until the long-running operation has completed on the service;
        /// <see cref="WaitUntil.Started"/> if it should return after starting the operation.
        /// For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="message"> Message payload for sending an email. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual EmailSendOperation Send(
            WaitUntil wait,
            EmailMessage message,
            CancellationToken cancellationToken = default)
        {
            var operationId = Guid.NewGuid();
            return Send(wait, message, operationId, cancellationToken);
        }

        /// <summary> Queues an email message to be sent to one or more recipients. </summary>
        /// <param name="wait"> <see cref="WaitUntil.Completed"/>
        /// if the method should wait to return until the long-running operation has completed on the service;
        /// <see cref="WaitUntil.Started"/> if it should return after starting the operation.
        /// For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="message"> Message payload for sending an email. </param>
        /// <param name="operationId"> The ID to identify the long running operation. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual EmailSendOperation Send(
            WaitUntil wait,
            EmailMessage message,
            Guid operationId,
            CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(EmailClient)}.{nameof(Send)}");
            scope.Start();
            try
            {
                return SendEmailInternal(wait, message, operationId, cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Queues an email message to be sent to a single recipient. </summary>
        /// <param name="wait"> <see cref="WaitUntil.Completed"/>
        /// if the method should wait to return until the long-running operation has completed on the service;
        /// <see cref="WaitUntil.Started"/> if it should return after starting the operation.
        /// For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="senderAddress"> From address of the email. </param>
        /// <param name="recipientAddress"> Email address of the TO recipient. </param>
        /// <param name="subject"> Subject for the email. </param>
        /// <param name="htmlContent"> Email body in HTML format. </param>
        /// <param name="plainTextContent"> Email body in plain text format. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual EmailSendOperation Send(
            WaitUntil wait,
            string senderAddress,
            string recipientAddress,
            string subject,
            string htmlContent,
            string plainTextContent = default,
            CancellationToken cancellationToken = default)
        {
            var operationId = Guid.NewGuid();
            return Send(wait, senderAddress, recipientAddress, subject,
                htmlContent, operationId, plainTextContent, cancellationToken);
        }

        /// <summary> Queues an email message to be sent to a single recipient. </summary>
        /// <param name="wait"> <see cref="WaitUntil.Completed"/>
        /// if the method should wait to return until the long-running operation has completed on the service;
        /// <see cref="WaitUntil.Started"/> if it should return after starting the operation.
        /// For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="senderAddress"> From address of the email. </param>
        /// <param name="recipientAddress"> Email address of the TO recipient. </param>
        /// <param name="subject"> Subject for the email. </param>
        /// <param name="htmlContent"> Email body in HTML format. </param>
        /// <param name="operationId"> The ID to identify the long running operation. </param>
        /// <param name="plainTextContent"> Email body in plain text format. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual EmailSendOperation Send(
            WaitUntil wait,
            string senderAddress,
            string recipientAddress,
            string subject,
            string htmlContent,
            Guid operationId,
            string plainTextContent = default,
            CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(EmailClient)}.{nameof(Send)}");
            scope.Start();
            try
            {
                EmailMessage message = new EmailMessage(
                    senderAddress,
                    new EmailRecipients(new List<EmailAddress>()
                    {
                        new EmailAddress(recipientAddress)
                    }),
                    new EmailContent(subject)
                    {
                        PlainText = plainTextContent,
                        Html = htmlContent
                    });
                return SendEmailInternal(wait, message, operationId, cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Gets the status result of an existing email send operation.
        /// </summary>
        /// <param name="id">ID of the existing email send operation.</param>
        /// <param name="cancellationToken">Optional <see cref="CancellationToken"/> to propagate
        /// notification that the operation should be cancelled.</param>
        /// <returns></returns>
        internal virtual async Task<Response<EmailSendResult>> GetSendResultAsync(
            string id,
            CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(EmailClient)}.{nameof(GetSendResult)}");
            scope.Start();
            try
            {
                var originalResponse = await _restClient.GetSendResultAsync(id, cancellationToken).ConfigureAwait(false);
                return Response.FromValue(originalResponse.Value, originalResponse.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Gets the status result of an existing email send operation.
        /// </summary>
        /// <param name="id">ID of the existing email send operation.</param>
        /// <param name="cancellationToken">Optional <see cref="CancellationToken"/> to propagate
        /// notification that the operation should be cancelled.</param>
        /// <returns></returns>
        internal virtual Response<EmailSendResult> GetSendResult(
            string id,
            CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(EmailClient)}.{nameof(GetSendResult)}");
            scope.Start();
            try
            {
                var originalResponse = _restClient.GetSendResult(id, cancellationToken);
                return Response.FromValue(originalResponse.Value, originalResponse.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        private async Task<EmailSendOperation> SendEmailInternalAsync(
            WaitUntil wait,
            EmailMessage message,
            Guid operationId,
            CancellationToken cancellationToken)
        {
            ValidateEmailMessage(message);

            ResponseWithHeaders<EmailSendHeaders> originalResponse = await _restClient.SendAsync(message, operationId, cancellationToken).ConfigureAwait(false);

            Response rawResponse = originalResponse.GetRawResponse();
            using JsonDocument document = await JsonDocument.ParseAsync(rawResponse.ContentStream, default, cancellationToken).ConfigureAwait(false);
            var emailSendResult = EmailSendResult.DeserializeEmailSendResult(document.RootElement);

            var operation = new EmailSendOperation(this, emailSendResult.Id, originalResponse.GetRawResponse());
            if (wait == WaitUntil.Completed)
            {
                await operation.WaitForCompletionAsync(cancellationToken).ConfigureAwait(false);
            }

            return operation;
        }

        private EmailSendOperation SendEmailInternal(
            WaitUntil wait,
            EmailMessage message,
            Guid operationId,
            CancellationToken cancellationToken)
        {
            ValidateEmailMessage(message);

            var originalResponse = _restClient.Send(message, operationId, cancellationToken);

            Response rawResponse = originalResponse.GetRawResponse();
            using JsonDocument document = JsonDocument.Parse(rawResponse.ContentStream, default);
            var emailSendResult = EmailSendResult.DeserializeEmailSendResult(document.RootElement);

            var operation = new EmailSendOperation(this, emailSendResult.Id, originalResponse.GetRawResponse());
            if (wait == WaitUntil.Completed)
            {
                operation.WaitForCompletion(cancellationToken);
            }

            return operation;
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
            if (string.IsNullOrWhiteSpace(emailMessage.SenderAddress))
            {
                throw new ArgumentException(ErrorMessages.InvalidSenderEmail);
            }
        }

        private static void ValidateRecipients(EmailMessage emailMessage)
        {
            emailMessage.Recipients.Validate();
        }

        private static void ValidateAttachmentContent(EmailMessage emailMessage)
        {
            foreach (EmailAttachment attachment in emailMessage.Attachments ?? Enumerable.Empty<EmailAttachment>())
            {
                attachment.ValidateAttachmentContent();
            }
        }
    }
}
