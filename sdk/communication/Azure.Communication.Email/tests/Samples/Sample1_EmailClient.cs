// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
#region Snippet:Azure_Communication_Email_UsingStatements
//@@ using Azure.Communication.Email;
#endregion Snippet:Azure_Communication_Email_UsingStatements
using Azure.Core.TestFramework;
using NUnit.Framework;
using System.Net.Mime;
using System.Threading;

namespace Azure.Communication.Email.Tests.Samples
{
    internal class Sample1_EmailClient : EmailClientLiveTestBase
    {
        public Sample1_EmailClient(bool isAsync) : base(isAsync)
        {
        }

        [Test]
        [SyncOnly]
        public void SendSimpleEmailWithAutomaticPollingForStatus()
        {
            EmailClient emailClient = CreateEmailClient();

            #region Snippet:Azure_Communication_Email_Send_Simple_AutoPolling
            //@@ try
            //@@ {
                var emailSendOperation = emailClient.Send(
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
            #endregion Snippet:Azure_Communication_Email_Send_Simple_AutoPolling

            Assert.False(string.IsNullOrEmpty(operationId));
        }

        [Test]
        [SyncOnly]
        public void SendEmailWithMoreOptions()
        {
            EmailClient emailClient = CreateEmailClient();

            #region Snippet:Azure_Communication_Email_Send_With_MoreOptions
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
                var emailSendOperation = emailClient.Send(
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
                #endregion Snippet:Azure_Communication_Email_Send_With_MoreOptions

                Assert.False(string.IsNullOrEmpty(operationId));
        }

        [Test]
        [SyncOnly]
        public void SendEmailToMultipleRecipients()
        {
            EmailClient emailClient = CreateEmailClient();

            #region Snippet:Azure_Communication_Email_Send_Multiple_Recipients
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
                EmailSendOperation emailSendOperation = emailClient.Send(WaitUntil.Completed, emailMessage);
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
            #endregion Snippet:Azure_Communication_Email_Send_Multiple_Recipients

            Assert.False(string.IsNullOrEmpty(operationId));
        }

        [Test]
        [SyncOnly]
        public void SendEmailWithAttachment()
        {
            EmailClient emailClient = CreateEmailClient();

            // Create the email content
            var emailContent = new EmailContent("This is the subject")
            {
                PlainText = "This is the body",
                Html = "<html><body>This is the html body</body></html>"
            };

            #region Snippet:Azure_Communication_Email_Send_With_Attachments
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
                EmailSendOperation emailSendOperation = emailClient.Send(WaitUntil.Completed, emailMessage);
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
            #endregion Snippet:Azure_Communication_Email_Send_With_Attachments
        }

        [RecordedTest]
        [SyncOnly]
        public void SendSimpleEmailWithManualPollingForStatus()
        {
            EmailClient emailClient = CreateEmailClient();

            #region Snippet:Azure_Communication_Email_Send_Simple_ManualPolling
            /// Send the email message with WaitUntil.Started
            var emailSendOperation = emailClient.Send(
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
                    emailSendOperation.UpdateStatus();
                    if (emailSendOperation.HasCompleted)
                    {
                        break;
                    }
                    Thread.Sleep(100);
                }

                if (emailSendOperation.HasValue)
                {
                    Console.WriteLine($"Email Sent. Status = {emailSendOperation.Value.Status}");
                }
            }
            catch (RequestFailedException ex)
            {
                Console.WriteLine($"Email send failed with Code = {ex.ErrorCode} and Message = {ex.Message}");
            }

            /// Get the OperationId so that it can be used for tracking the message for troubleshooting
            string operationId = emailSendOperation.Id;
            Console.WriteLine($"Email operation id = {operationId}");
            #endregion: Azure_Communication_Email_Send_Simple_ManualPolling
        }
    }
}
