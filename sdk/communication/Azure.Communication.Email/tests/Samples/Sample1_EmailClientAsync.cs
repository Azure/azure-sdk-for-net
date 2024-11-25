// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Net.Mime;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.Communication.Email.Tests.Samples
{
    internal class Sample1_EmailClientAsync : EmailClientLiveTestBase
    {
        public Sample1_EmailClientAsync(bool isAsync) : base(isAsync)
        {
        }

        [Test]
        [AsyncOnly]
        public async Task SendSimpleEmailWithAutomaticPollingForStatusAsync()
        {
            EmailClient emailClient = CreateEmailClient();

            #region Snippet:Azure_Communication_Email_Send_Simple_AutoPolling_Async
            //@@ try
            //@@ {
                var emailSendOperation = await emailClient.SendAsync(
                    wait: WaitUntil.Completed,
                    //@@ senderAddress: "<Send email address>" // The email address of the domain registered with the Communication Services resource
                    //@@ recipientAddress: "<recipient email address>"
                    /*@@*/ senderAddress: TestEnvironment.SenderAddress,
                    /*@@*/ recipientAddress: TestEnvironment.RecipientAddress,
                    subject: "This is the subject",
                    htmlContent: "<html><body>This is the html body</body></html>");
                Console.WriteLine($"Email Sent. Status = {emailSendOperation.Value.Status}");

                /// Get the OperationId so that it can be used for tracking the message for troubleshooting
                string operationId = emailSendOperation.Id;
                Console.WriteLine($"Email operation id = {operationId}");
            //@@ }
            //@@ catch ( RequestFailedException ex )
            //@@ {
                //@@ /// OperationID is contained in the exception message and can be used for troubleshooting purposes
                //@@ Console.WriteLine($"Email send operation failed with error code: {ex.ErrorCode}, message: {ex.Message}");
            //@@ }
            #endregion Snippet:Azure_Communication_Email_Send_Simple_AutoPolling_Async

            Assert.False(string.IsNullOrEmpty(operationId));
        }

        [RecordedTest]
        [AsyncOnly]
        public async Task SendSimpleEmailWithManualPollingForStatusAsync()
        {
            EmailClient emailClient = CreateEmailClient();

            #region Snippet:Azure_Communication_Email_Send_Simple_ManualPolling_Async
            /// Send the email message with WaitUntil.Started
            var emailSendOperation = await emailClient.SendAsync(
                wait: WaitUntil.Started,
                //@@ senderAddress: "<Send email address>" // The email address of the domain registered with the Communication Services resource
                //@@ recipientAddress: "<recipient email address>"
                /*@@*/ senderAddress: TestEnvironment.SenderAddress,
                /*@@*/ recipientAddress: TestEnvironment.RecipientAddress,
                subject: "This is the subject",
                htmlContent: "<html><body>This is the html body</body></html>");

            /// Call UpdateStatus on the email send operation to poll for the status
            /// manually.
            try
            {
                while (true)
                {
                    await emailSendOperation.UpdateStatusAsync();
                    if (emailSendOperation.HasCompleted)
                    {
                        break;
                    }
                    await Task.Delay(100);
                }

                if (emailSendOperation.HasValue)
                {
                    Console.WriteLine($"Email queued for delivery. Status = {emailSendOperation.Value.Status}");
                }
            }
            catch (RequestFailedException ex)
            {
                Console.WriteLine($"Email send failed with Code = {ex.ErrorCode} and Message = {ex.Message}");
            }

            /// Get the OperationId so that it can be used for tracking the message for troubleshooting
            string operationId = emailSendOperation.Id;
            Console.WriteLine($"Email operation id = {operationId}");
            #endregion: Azure_Communication_Email_Send_Simple_ManualPolling_Async
        }

        [Test]
        [AsyncOnly]
        public async Task SendEmailWithMoreOptionsAsync()
        {
            EmailClient emailClient = CreateEmailClient();

            #region Snippet:Azure_Communication_Email_Send_With_MoreOptions_Async
            // Create the email content
            var emailContent = new EmailContent("This is the subject")
            {
                PlainText = "This is the body",
                Html = "<html><body>This is the html body</body></html>"
            };

            // Create the EmailMessage
            var emailMessage = new EmailMessage(
                //@@ senderAddress: "<Send email address>" // The email address of the domain registered with the Communication Services resource
                //@@ recipientAddress: "<recipient email address>"
                /*@@*/ senderAddress: TestEnvironment.SenderAddress,
                /*@@*/ recipientAddress: TestEnvironment.RecipientAddress,
                content: emailContent);

            //@@ try
            //@@ {
                var emailSendOperation = await emailClient.SendAsync(
                    wait: WaitUntil.Completed,
                    message: emailMessage);
                Console.WriteLine($"Email Sent. Status = {emailSendOperation.Value.Status}");

                /// Get the OperationId so that it can be used for tracking the message for troubleshooting
                string operationId = emailSendOperation.Id;
                Console.WriteLine($"Email operation id = {operationId}");
            //@@ }
            //@@ catch ( RequestFailedException ex )
            //@@ {
                //@@ /// OperationID is contained in the exception message and can be used for troubleshooting purposes
                //@@ Console.WriteLine($"Email send operation failed with error code: {ex.ErrorCode}, message: {ex.Message}");
            //@@ }
            #endregion Snippet:Azure_Communication_Email_Send_With_MoreOptions_Async

            Assert.False(string.IsNullOrEmpty(operationId));
        }

        [Test]
        [AsyncOnly]
        public async Task SendEmailToMultipleRecipientsAsync()
        {
            EmailClient emailClient = CreateEmailClient();

            #region Snippet:Azure_Communication_Email_Send_Multiple_Recipients_Async
            // Create the email content
            var emailContent = new EmailContent("This is the subject")
            {
                PlainText = "This is the body",
                Html = "<html><body>This is the html body</body></html>"
            };

            // Create the To list
            var toRecipients = new List<EmailAddress>
            {
                new EmailAddress(
                    //@@ address: "<recipient email address>"
                    //@@ displayName: "<recipient displayname>"
                    /*@@*/ address: TestEnvironment.RecipientAddress,
                    /*@@*/ displayName: "Customer Name"),
                new EmailAddress(
                    //@@ address: "<recipient email address>"
                    //@@ displayName: "<recipient displayname>"
                    /*@@*/ address: TestEnvironment.RecipientAddress,
                    /*@@*/ displayName: "Customer Name")
            };

            // Create the CC list
            var ccRecipients = new List<EmailAddress>
            {
                new EmailAddress(
                    //@@ address: "<recipient email address>"
                    //@@ displayName: "<recipient displayname>"
                    /*@@*/ address: TestEnvironment.RecipientAddress,
                    /*@@*/ displayName: "Customer Name"),
                new EmailAddress(
                    //@@ address: "<recipient email address>"
                    //@@ displayName: "<recipient displayname>"
                    /*@@*/ address: TestEnvironment.RecipientAddress,
                    /*@@*/ displayName: "Customer Name")
            };

            // Create the BCC list
            var bccRecipients = new List<EmailAddress>
            {
                new EmailAddress(
                    //@@ address: "<recipient email address>"
                    //@@ displayName: "<recipient displayname>"
                    /*@@*/ address: TestEnvironment.RecipientAddress,
                    /*@@*/ displayName: "Customer Name"),
                new EmailAddress(
                    //@@ address: "<recipient email address>"
                    //@@ displayName: "<recipient displayname>"
                    /*@@*/ address: TestEnvironment.RecipientAddress,
                    /*@@*/ displayName: "Customer Name")
            };

            var emailRecipients = new EmailRecipients(toRecipients, ccRecipients, bccRecipients);

            // Create the EmailMessage
            var emailMessage = new EmailMessage(
                //@@ senderAddress: "<Send email address>" // The email address of the domain registered with the Communication Services resource
                /*@@*/ senderAddress: TestEnvironment.SenderAddress,
                emailRecipients,
                emailContent);

            //@@ try
            //@@ {
                EmailSendOperation emailSendOperation = await emailClient.SendAsync(WaitUntil.Completed, emailMessage);
                Console.WriteLine($"Email Sent. Status = {emailSendOperation.Value.Status}");

                /// Get the OperationId so that it can be used for tracking the message for troubleshooting
                string operationId = emailSendOperation.Id;
                Console.WriteLine($"Email operation id = {operationId}");
            //@@ }
            //@@ catch ( RequestFailedException ex )
            //@@ {
                //@@ /// OperationID is contained in the exception message and can be used for troubleshooting purposes
                //@@ Console.WriteLine($"Email send operation failed with error code: {ex.ErrorCode}, message: {ex.Message}");
            //@@ }
            #endregion Snippet:Azure_Communication_Email_Send_Multiple_Recipients_Async

            Assert.False(string.IsNullOrEmpty(operationId));
        }

        [Test]
        [AsyncOnly]
        public async Task SendEmailWithAttachmentAsync()
        {
            EmailClient emailClient = CreateEmailClient();

            // Create the email content
            var emailContent = new EmailContent("This is the subject")
            {
                PlainText = "This is the body",
                Html = "<html><body>This is the html body</body></html>"
            };

            #region Snippet:Azure_Communication_Email_Send_With_Attachments_Async
            // Create the EmailMessage
            var emailMessage = new EmailMessage(
                //@@ senderAddress: "<Send email address>" // The email address of the domain registered with the Communication Services resource
                //@@ recipientAddress: "<recipient email address>"
                /*@@*/ senderAddress: TestEnvironment.SenderAddress,
                /*@@*/ recipientAddress: TestEnvironment.RecipientAddress,
                content: emailContent);

#if SNIPPET
            var filePath = "<path to your file>";
            var attachmentName = "<name of your attachment>";
            var contentType = MediaTypeNames.Text.Plain;
#endif

#if SNIPPET
            var content = new BinaryData(System.IO.File.ReadAllBytes(filePath));
#else
            string attachmentName = "Attachment.txt";
            string contentType = MediaTypeNames.Text.Plain;
            var content = new BinaryData("This is attachment file content.");
#endif
            var emailAttachment = new EmailAttachment(attachmentName, contentType, content);

            emailMessage.Attachments.Add(emailAttachment);

            //@@ try
            //@@ {
                EmailSendOperation emailSendOperation = await emailClient.SendAsync(WaitUntil.Completed, emailMessage);
                Console.WriteLine($"Email Sent. Status = {emailSendOperation.Value.Status}");

                /// Get the OperationId so that it can be used for tracking the message for troubleshooting
                string operationId = emailSendOperation.Id;
                Console.WriteLine($"Email operation id = {operationId}");
            //@@ }
            //@@ catch ( RequestFailedException ex )
            //@@ {
                //@@ /// OperationID is contained in the exception message and can be used for troubleshooting purposes
                //@@ Console.WriteLine($"Email send operation failed with error code: {ex.ErrorCode}, message: {ex.Message}");
            //@@ }
            #endregion Snippet:Azure_Communication_Email_Send_With_Attachments_Async
        }

        [RecordedTest]
        [AsyncOnly]
        public async Task SendEmailWithInlineAttachmentAsync()
        {
            EmailClient emailClient = CreateEmailClient();

            #region Snippet:Azure_Communication_Email_Send_With_Inline_Attachments_Async
            // Create the email content and reference any inline attachments.
            var emailContent = new EmailContent("This is the subject")
            {
                PlainText = "This is the body",
                Html = "<html><body>This is the html body<img src=\"cid:myInlineAttachmentContentId\"></body></html>"
            };

            // Create the EmailMessage
            var emailMessage = new EmailMessage(
                //@@ senderAddress: "<Send email address>" // The email address of the domain registered with the Communication Services resource
                //@@ recipientAddress: "<recipient email address>"
                /*@@*/ senderAddress: TestEnvironment.SenderAddress,
                /*@@*/ recipientAddress: TestEnvironment.RecipientAddress,
                content: emailContent);

#if SNIPPET
            var filePath = "<path to your file>";
            var attachmentName = "<name of your attachment>";
            var contentType = MediaTypeNames.Text.Plain;
            var contentId = "myInlineAttachmentContentId";
#endif

#if SNIPPET
            var content = new BinaryData(System.IO.File.ReadAllBytes(filePath));
#else
            string attachmentName = "InlineImage.jpg";
            string contentType = MediaTypeNames.Image.Jpeg;
            var content = new BinaryData("This is image file content.");
            var contentId = "myInlineAttachmentContentId";
#endif
            var emailAttachment = new EmailAttachment(attachmentName, contentType, content);
            emailAttachment.ContentId = contentId;

            emailMessage.Attachments.Add(emailAttachment);

            //@@ try
            //@@ {
                EmailSendOperation emailSendOperation = await emailClient.SendAsync(WaitUntil.Completed, emailMessage);
                Console.WriteLine($"Email Sent. Status = {emailSendOperation.Value.Status}");

                /// Get the OperationId so that it can be used for tracking the message for troubleshooting
                string operationId = emailSendOperation.Id;
                Console.WriteLine($"Email operation id = {operationId}");
            //@@ }
            //@@ catch ( RequestFailedException ex )
            //@@ {
                //@@ /// OperationID is contained in the exception message and can be used for troubleshooting purposes
                //@@ Console.WriteLine($"Email send operation failed with error code: {ex.ErrorCode}, message: {ex.Message}");
            //@@ }
            #endregion Snippet:Azure_Communication_Email_Send_With_Inline_Attachments_Async
        }
    }
}
