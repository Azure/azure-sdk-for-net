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
        [TestCaseSource(nameof(SetRecipientAddressState))]
        public void SendEmail(
            bool setTo, bool setCc, bool setBcc)
        {
            EmailClient emailClient = CreateEmailClient();
            EmailRecipients emailRecipients = GetRecipients(setTo, setCc, setBcc);

            SendEmailResult response = SendEmail(emailClient, emailRecipients);

            Assert.IsNotNull(response);
            Assert.IsFalse(string.IsNullOrWhiteSpace(response.MessageId));
            Console.WriteLine($"MessageId={response.MessageId}");
        }

        [Test]
        [AsyncOnly]
        [TestCaseSource(nameof(SetRecipientAddressState))]
        public async Task SendEmailAsync(
            bool setTo, bool setCc, bool setBcc)
        {
            EmailClient emailClient = CreateEmailClient();
            EmailRecipients emailRecipients = GetRecipients(setTo, setCc, setBcc);

            SendEmailResult response = await SendEmailAsync(emailClient, emailRecipients);

            Assert.IsNotNull(response);
            Assert.IsFalse(string.IsNullOrWhiteSpace(response.MessageId));
            Console.WriteLine($"MessageId={response.MessageId}");
        }

        [Test]
        [SyncOnly]
        [TestCaseSource(nameof(SetRecipientAddressState) )]
        public void GetSendStatus(
            bool setTo, bool setCc, bool setBcc)
        {
            EmailClient emailClient = CreateEmailClient();
            EmailRecipients emailRecipients = GetRecipients(setTo, setCc, setBcc);

            SendEmailResult response = SendEmail(emailClient, emailRecipients);

            Assert.IsNotNull(response);
            Assert.IsFalse(string.IsNullOrWhiteSpace(response.MessageId));
            Console.WriteLine($"MessageId={response.MessageId}");

            SendStatusResult messageStatusResponse = emailClient.GetSendStatus(response.MessageId);

            Assert.IsNotNull(messageStatusResponse);
            Console.WriteLine(messageStatusResponse.Status);
        }

        [Test]
        [AsyncOnly]
        [TestCaseSource(nameof(SetRecipientAddressState))]
        public async Task GetSendStatusAsync(
            bool setTo, bool setCc, bool setBcc)
        {
            EmailClient emailClient = CreateEmailClient();
            EmailRecipients emailRecipients = GetRecipients(setTo, setCc, setBcc);

            SendEmailResult response = await SendEmailAsync(emailClient, emailRecipients);

            Assert.IsNotNull(response);
            Assert.IsFalse(string.IsNullOrWhiteSpace(response.MessageId));
            Console.WriteLine($"MessageId={response.MessageId}");

            SendStatusResult messageStatusResponse = await emailClient.GetSendStatusAsync(response.MessageId);

            Assert.IsNotNull(messageStatusResponse);
            Console.WriteLine(messageStatusResponse.Status);
        }

        private Response<SendEmailResult> SendEmail(EmailClient emailClient, EmailRecipients emailRecipients)
        {
            var emailContent = new EmailContent("subject");
            emailContent.PlainText = "Test";

            var emailMessage = new EmailMessage(
                TestEnvironment.SenderAddress,
                emailContent,
                emailRecipients);

            Response<SendEmailResult>? response = emailClient.Send(emailMessage);
            return response;
        }

        private async Task<Response<SendEmailResult>> SendEmailAsync(EmailClient emailClient, EmailRecipients emailRecipients)
        {
            var emailContent = new EmailContent("subject");
            emailContent.PlainText = "Test";

            var emailMessage = new EmailMessage(
                TestEnvironment.SenderAddress,
                emailContent,
                emailRecipients);

            Response<SendEmailResult>? response = await emailClient.SendAsync(emailMessage);
            return response;
        }

        private static IEnumerable<TestCaseData> SetRecipientAddressState()
        {
            yield return new TestCaseData(true, false, false);
            yield return new TestCaseData(false, true, false);
            yield return new TestCaseData(false, false, true);
            yield return new TestCaseData(false, true, true);
            yield return new TestCaseData(true, false, true);
            yield return new TestCaseData(true, true, false);
            yield return new TestCaseData(true, true, true);
        }

        private EmailRecipients GetRecipients(bool setTo, bool setCc, bool setBcc)
        {
            List<EmailAddress>? toEmailAddressList = null;
            List<EmailAddress>? ccEmailAddressList = null;
            List<EmailAddress>? bccEmailAddressList = null;

            if (setTo)
            {
                toEmailAddressList = new List<EmailAddress> { new EmailAddress(TestEnvironment.RecipientAddress) { DisplayName = "ToAddress" } };
            }

            if (setCc)
            {
                ccEmailAddressList = new List<EmailAddress> { new EmailAddress(TestEnvironment.RecipientAddress) { DisplayName = "CcAddress" } };
            }

            if (setBcc)
            {
                bccEmailAddressList = new List<EmailAddress> { new EmailAddress(TestEnvironment.RecipientAddress) { DisplayName = "BccAddress" } };
            }

            return new EmailRecipients(toEmailAddressList, ccEmailAddressList, bccEmailAddressList);
        }
    }
}
