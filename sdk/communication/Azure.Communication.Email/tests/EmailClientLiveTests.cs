// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Azure.Communication.Email.Models;
using Azure.Core.TestFramework;
using NUnit.Framework;

#nullable enable

namespace Azure.Communication.Email.Tests
{
    internal class EmailClientLiveTests : EmailClientLiveTestBase
    {
        public EmailClientLiveTests(bool isAsync) : base(isAsync)
        {
        }

        [Test]
        [SyncOnly]
        public void SendEmail()
        {
            EmailClient emailClient = CreateEmailClient();

            SendEmailResult response = SendEmail(emailClient);

            Assert.IsNotNull(response);
            Assert.IsFalse(string.IsNullOrWhiteSpace(response.MessageId));
            Console.WriteLine($"MessageId={response.MessageId}");
        }

        [Test]
        [AsyncOnly]
        public async Task SendEmailAsync()
        {
            EmailClient emailClient = CreateEmailClient();

            SendEmailResult response = await SendEmailAsync(emailClient);

            Assert.IsNotNull(response);
            Assert.IsFalse(string.IsNullOrWhiteSpace(response.MessageId));
            Console.WriteLine($"MessageId={response.MessageId}");
        }

        [Test]
        [SyncOnly]
        public void GetSendStatus()
        {
            EmailClient emailClient = CreateEmailClient();

            SendEmailResult response = SendEmail(emailClient);

            Assert.IsNotNull(response);
            Assert.IsFalse(string.IsNullOrWhiteSpace(response.MessageId));
            Console.WriteLine($"MessageId={response.MessageId}");

            SendStatusResult messageStatusResponse = emailClient.GetSendStatus(response.MessageId);

            Assert.IsNotNull(messageStatusResponse);
            Console.WriteLine(messageStatusResponse.Status);
        }

        [Test]
        [AsyncOnly]
        public async Task GetSendStatusAsync()
        {
            EmailClient emailClient = CreateEmailClient();

            SendEmailResult response = await SendEmailAsync(emailClient);

            Assert.IsNotNull(response);
            Assert.IsFalse(string.IsNullOrWhiteSpace(response.MessageId));
            Console.WriteLine($"MessageId={response.MessageId}");

            SendStatusResult messageStatusResponse = await emailClient.GetSendStatusAsync(response.MessageId);

            Assert.IsNotNull(messageStatusResponse);
            Console.WriteLine(messageStatusResponse.Status);
        }

        private Response<SendEmailResult> SendEmail(EmailClient emailClient)
        {
            var emailContent = new EmailContent("subject");
            emailContent.PlainText = "Test";

            var emailMessage = new EmailMessage(
                TestEnvironment.SenderAddress,
                emailContent,
                new EmailRecipients(new List<EmailAddress> { new EmailAddress(TestEnvironment.RecipientAddress) { DisplayName = "ToAddress" } }));

            Response<SendEmailResult>? response = emailClient.Send(emailMessage);
            return response;
        }

        private async Task<Response<SendEmailResult>> SendEmailAsync(EmailClient emailClient)
        {
            var emailContent = new EmailContent("subject");
            emailContent.PlainText = "Test";

            var emailMessage = new EmailMessage(
                TestEnvironment.SenderAddress,
                emailContent,
                new EmailRecipients(new List<EmailAddress> { new EmailAddress(TestEnvironment.RecipientAddress) { DisplayName = "ToAddress" } }));

            Response<SendEmailResult>? response = await emailClient.SendAsync(emailMessage);
            return response;
        }
    }
}
