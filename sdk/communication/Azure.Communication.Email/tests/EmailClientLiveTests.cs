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
        [AsyncOnly]
        [TestCaseSource(nameof(SetRecipientAddressState))]
        public async Task SendEmailAndWaitForStatusAsync(
            bool setTo, bool setCc, bool setBcc)
        {
            EmailClient emailClient = CreateEmailClient();
            EmailRecipients emailRecipients = GetRecipients(setTo, setCc, setBcc);

            EmailSendResult statusMonitor = await SendEmailAndWaitForStatusAsync(emailClient, emailRecipients);

            Assert.IsFalse(string.IsNullOrWhiteSpace(statusMonitor.Id));
            Console.WriteLine($"OperationId={statusMonitor.Id}");
            Console.WriteLine(statusMonitor.Status);
        }

        [Test]
        [SyncOnly]
        [TestCaseSource(nameof(SetRecipientAddressState) )]
        public void SendEmailAndWaitForStatus(
            bool setTo, bool setCc, bool setBcc)
        {
            EmailClient emailClient = CreateEmailClient();
            EmailRecipients emailRecipients = GetRecipients(setTo, setCc, setBcc);

            EmailSendResult statusMonitor = SendEmailAndWaitForStatus(emailClient, emailRecipients);

            Assert.IsFalse(string.IsNullOrWhiteSpace(statusMonitor.Id));
            Console.WriteLine($"OperationId={statusMonitor.Id}");
            Console.WriteLine(statusMonitor.Status);
        }

        private EmailSendResult SendEmailAndWaitForStatus(EmailClient emailClient, EmailRecipients emailRecipients)
        {
            var emailContent = new EmailContent("subject");
            emailContent.PlainText = "Test";

            var emailMessage = new EmailMessage(
                TestEnvironment.SenderAddress,
                emailContent,
                emailRecipients);

            EmailSendOperation emailSendOperation = emailClient.Send(WaitUntil.Started, emailMessage);
            Response<EmailSendResult>? statusMonitor = emailSendOperation.WaitForCompletion();

            return statusMonitor;
        }

        private async Task<EmailSendResult> SendEmailAndWaitForStatusAsync(EmailClient emailClient, EmailRecipients emailRecipients)
        {
            var emailContent = new EmailContent("subject");
            emailContent.PlainText = "Test";

            var emailMessage = new EmailMessage(
                TestEnvironment.SenderAddress,
                emailContent,
                emailRecipients);

            EmailSendOperation emailSendOperation = await emailClient.SendAsync(WaitUntil.Started, emailMessage);
            Response<EmailSendResult>? statusMonitor = await emailSendOperation.WaitForCompletionAsync();

            return statusMonitor;
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
