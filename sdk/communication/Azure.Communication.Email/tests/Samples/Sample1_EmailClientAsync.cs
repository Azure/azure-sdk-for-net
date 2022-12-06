// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Azure.Communication.Email.Models;
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
        public async Task SendEmailAsync()
        {
            EmailClient client = CreateEmailClient();

            #region Snippet:Azure_Communication_Email_SendAsync
            // Create the email content
            var emailContent = new EmailContent("This is the subject");
            emailContent.PlainText = "This is the body";

            // Create the recipient list
            var emailRecipients = new EmailRecipients(
                new List<EmailAddress>
                {
                    new EmailAddress(
                        //@@ email: "<recipient email address>"
                        //@@ displayName: "<recipient displayname>"
                        /*@@*/ email: TestEnvironment.RecipientAddress,
                        /*@@*/ displayName: "Customer Name")
                });

            // Create the EmailMessage
            var emailMessage = new EmailMessage(
                //@@ sender: "<Send email address>" // The email address of the domain registered with the Communication Services resource
                /*@@*/ sender: TestEnvironment.SenderAddress,
                emailContent,
                emailRecipients);

            SendEmailResult sendResult = await client.SendAsync(emailMessage);

            Console.WriteLine($"Email id: {sendResult.MessageId}");
            #endregion Snippet:Azure_Communication_Email_SendAsync

            Assert.False(string.IsNullOrEmpty(sendResult.MessageId));
        }

        [Test]
        [AsyncOnly]
        public async Task SendEmailToMultipleRecipientsAsync()
        {
            EmailClient client = CreateEmailClient();

            #region Snippet:Azure_Communication_Email_Send_Multiple_RecipientsAsync
            // Create the email content
            var emailContent = new EmailContent("This is the subject");
            emailContent.PlainText = "This is the body";

            // Create the To list
            var toRecipients = new List<EmailAddress>
            {
                new EmailAddress(
                    //@@ email: "<recipient email address>"
                    //@@ displayName: "<recipient displayname>"
                    /*@@*/ email: TestEnvironment.RecipientAddress,
                    /*@@*/ displayName: "Customer Name"),
                new EmailAddress(
                    //@@ email: "<recipient email address>"
                    //@@ displayName: "<recipient displayname>"
                    /*@@*/ email: TestEnvironment.RecipientAddress,
                    /*@@*/ displayName: "Customer Name")
            };

            // Create the CC list
            var ccRecipients = new List<EmailAddress>
            {
                new EmailAddress(
                    //@@ email: "<recipient email address>"
                    //@@ displayName: "<recipient displayname>"
                    /*@@*/ email: TestEnvironment.RecipientAddress,
                    /*@@*/ displayName: "Customer Name"),
                new EmailAddress(
                    //@@ email: "<recipient email address>"
                    //@@ displayName: "<recipient displayname>"
                    /*@@*/ email: TestEnvironment.RecipientAddress,
                    /*@@*/ displayName: "Customer Name")
            };

            // Create the BCC list
            var bccRecipients = new List<EmailAddress>
            {
                new EmailAddress(
                    //@@ email: "<recipient email address>"
                    //@@ displayName: "<recipient displayname>"
                    /*@@*/ email: TestEnvironment.RecipientAddress,
                    /*@@*/ displayName: "Customer Name"),
                new EmailAddress(
                    //@@ email: "<recipient email address>"
                    //@@ displayName: "<recipient displayname>"
                    /*@@*/ email: TestEnvironment.RecipientAddress,
                    /*@@*/ displayName: "Customer Name")
            };

            var emailRecipients = new EmailRecipients(toRecipients, ccRecipients, bccRecipients);

            // Create the EmailMessage
            var emailMessage = new EmailMessage(
                //@@ sender: "<Send email address>" // The email address of the domain registered with the Communication Services resource
                /*@@*/ sender: TestEnvironment.SenderAddress,
                emailContent,
                emailRecipients);

            SendEmailResult sendResult = await client.SendAsync(emailMessage);

            Console.WriteLine($"Email id: {sendResult.MessageId}");
            #endregion Snippet:Azure_Communication_Email_Send_Multiple_RecipientsAsync

            Console.WriteLine(sendResult.MessageId);
            Assert.False(string.IsNullOrEmpty(sendResult.MessageId));
        }

        [Test]
        [AsyncOnly]
        public async Task SendEmailWithAttachmentAsync()
        {
            EmailClient client = CreateEmailClient();

            var emailContent = new EmailContent("This is the subject");
            emailContent.PlainText = "This is the body";

            var emailRecipients = new EmailRecipients(
                  new List<EmailAddress>
                  {
                        new EmailAddress(
                            //@@ email: "<recipient email address>"
                            //@@ displayName: "<recipient displayname>"
                            /*@@*/ email: TestEnvironment.RecipientAddress,
                            /*@@*/ displayName: "Customer Name")
                  });

            #region Snippet:Azure_Communication_Email_Send_With_AttachmentsAsync
            // Create the EmailMessage
            var emailMessage = new EmailMessage(
                //@@ sender: "<Send email address>" // The email address of the domain registered with the Communication Services resource
                /*@@*/ sender: TestEnvironment.SenderAddress,
                emailContent,
                emailRecipients);

#if SNIPPET
            var filePath = "<path to your file>";
            var attachmentName = "<name of your attachment>";
            EmailAttachmentType attachmentType = EmailAttachmentType.Txt;
#endif

            // Convert the file content into a Base64 string
#if SNIPPET
            byte[] bytes = File.ReadAllBytes(filePath);
            string attachmentFileInBytes = Convert.ToBase64String(bytes);
#else
            string attachmentName = "Attachment.txt";
            EmailAttachmentType attachmentType = EmailAttachmentType.Txt;
            var attachmentFileInBytes = "VGhpcyBpcyBhIHRlc3Q=";
#endif
            var emailAttachment = new EmailAttachment(attachmentName, attachmentType, attachmentFileInBytes);

            emailMessage.Attachments.Add(emailAttachment);

            SendEmailResult sendResult = await client.SendAsync(emailMessage);
            #endregion Snippet:Azure_Communication_Email_Send_With_AttachmentsAsync
        }

        [Test]
        [AsyncOnly]
        public async Task GetSendEmailStatusAsync()
        {
            EmailClient client = CreateEmailClient();

            // Create the email content
            var emailContent = new EmailContent("This is the subject");
            emailContent.PlainText = "This is the body";

            // Create the recipient list
            var emailRecipients = new EmailRecipients(
                new List<EmailAddress>
                {
                    new EmailAddress(
                        //@@ email: "<recipient email address>"
                        //@@ displayName: "<recipient displayname>"
                        /*@@*/ email: TestEnvironment.RecipientAddress,
                        /*@@*/ displayName: "Customer Name")
                });

            // Create the EmailMessage
            var emailMessage = new EmailMessage(
                //@@ sender: "<Send email address>" // The email address of the domain registered with the Communication Services resource
                /*@@*/ sender: TestEnvironment.SenderAddress,
                emailContent,
                emailRecipients);

            #region Snippet:Azure_Communication_Email_GetSendStatusAsync
            SendEmailResult sendResult = await client.SendAsync(emailMessage);

            SendStatusResult status = await client.GetSendStatusAsync(sendResult.MessageId);
            #endregion Snippet:Azure_Communication_Email_GetSendStatusAsync

            Assert.False(string.IsNullOrEmpty(sendResult.MessageId));
        }
    }
}
