// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
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
        public async Task SendEmailAndWaitForExistingOperationAsync()
        {
            var emailClient = new EmailClient(
                TestEnvironment.CommunicationConnectionStringEmail,
                CreateEmailClientOptionsWithCorrelationVectorLogs());
            EmailRecipients emailRecipients = GetRecipients(setTo: true, setCc: true, setBcc: true);

            EmailSendOperation emailSendOperation = await SendEmailAndWaitForExistingOperationAsync(emailClient, emailRecipients);
            EmailSendResult statusMonitor = emailSendOperation.Value;

            Assert.IsFalse(string.IsNullOrWhiteSpace(emailSendOperation.Id));
            Console.WriteLine($"OperationId={emailSendOperation.Id}");
            Console.WriteLine($"Email send status = {statusMonitor.Status}");
        }

        [Test]
        [SyncOnly]
        public void SendEmailAndWaitForExistingOperation()
        {
            var emailClient = new EmailClient(
                TestEnvironment.CommunicationConnectionStringEmail,
                CreateEmailClientOptionsWithCorrelationVectorLogs());
            EmailRecipients emailRecipients = GetRecipients(setTo: true, setCc: true, setBcc: true);

            EmailSendOperation emailSendOperation = SendEmailAndWaitForExistingOperation(emailClient, emailRecipients);
            EmailSendResult statusMonitor = emailSendOperation.Value;

            Assert.IsFalse(string.IsNullOrWhiteSpace(emailSendOperation.Id));
            Console.WriteLine($"OperationId={emailSendOperation.Id}");
            Console.WriteLine($"Email send status = {statusMonitor.Status}");
        }

        [RecordedTest]
        [AsyncOnly]
        public async Task SendEmailAndWaitForStatusWithManualPollingAsync()
        {
            EmailClient emailClient = CreateEmailClient();
            EmailRecipients emailRecipients = GetRecipients(setTo: true, setCc: true, setBcc: true);

            EmailSendOperation emailSendOperation = await SendEmailAndWaitForStatusWithManualPollingAsync(emailClient, emailRecipients);
            EmailSendResult statusMonitor = emailSendOperation.Value;

            Assert.IsFalse(string.IsNullOrWhiteSpace(emailSendOperation.Id));
            Console.WriteLine($"OperationId={emailSendOperation.Id}");
            Console.WriteLine($"Email send status = {statusMonitor.Status}");
        }

        [Test]
        [AsyncOnly]
        [TestCaseSource(nameof(SetRecipientAddressState))]
        public async Task SendEmailAndWaitForStatusWithAutomaticPollingAsync(
            bool setTo, bool setCc, bool setBcc)
        {
            EmailClient emailClient = CreateEmailClient();
            EmailRecipients emailRecipients = GetRecipients(setTo, setCc, setBcc);

            EmailSendOperation emailSendOperation = await SendEmailAndWaitForStatusWithAutomaticPollingAsync(emailClient, emailRecipients);
            EmailSendResult statusMonitor = emailSendOperation.Value;

            Assert.IsFalse(string.IsNullOrWhiteSpace(emailSendOperation.Id));
            Console.WriteLine($"OperationId={emailSendOperation.Id}");
            Console.WriteLine($"Email send status = {statusMonitor.Status}");
        }

        [RecordedTest]
        [SyncOnly]
        [TestCaseSource(nameof(SetRecipientAddressState))]
        public void SendEmailAndWaitForStatusWithAutomaticPolling(
            bool setTo, bool setCc, bool setBcc)
        {
            EmailClient emailClient = CreateEmailClient();
            EmailRecipients emailRecipients = GetRecipients(setTo, setCc, setBcc);

            EmailSendOperation emailSendOperation = SendEmailAndWaitForStatusWithAutomaticPolling(emailClient, emailRecipients);
            EmailSendResult statusMonitor = emailSendOperation.Value;

            Assert.IsFalse(string.IsNullOrWhiteSpace(emailSendOperation.Id));
            Console.WriteLine($"OperationId={emailSendOperation.Id}");
            Console.WriteLine($"Email send status = {statusMonitor.Status}");
        }

        private async Task<EmailSendOperation> SendEmailAndWaitForStatusWithManualPollingAsync(EmailClient emailClient, EmailRecipients emailRecipients)
        {
            var emailContent = new EmailContent("subject");
            emailContent.PlainText = "Test";

            var emailMessage = new EmailMessage(
                TestEnvironment.SenderAddress,
                emailRecipients,
                emailContent);

            EmailSendOperation emailSendOperation = await emailClient.SendAsync(WaitUntil.Started, emailMessage);

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
                Console.WriteLine($"Email Sent. Status = {emailSendOperation.Value.Status}");
            }

            return emailSendOperation;
        }

        private EmailSendOperation SendEmailAndWaitForStatusWithAutomaticPolling(EmailClient emailClient, EmailRecipients emailRecipients)
        {
            var emailContent = new EmailContent("subject");
            emailContent.PlainText = "Test";

            var emailMessage = new EmailMessage(
                TestEnvironment.SenderAddress,
                emailRecipients,
                emailContent);

            EmailSendOperation emailSendOperation = emailClient.Send(WaitUntil.Completed, emailMessage);
            return emailSendOperation;
        }

        private async Task<EmailSendOperation> SendEmailAndWaitForStatusWithAutomaticPollingAsync(EmailClient emailClient, EmailRecipients emailRecipients)
        {
            var emailContent = new EmailContent("subject");
            emailContent.PlainText = "Test";

            var emailMessage = new EmailMessage(
                TestEnvironment.SenderAddress,
                emailRecipients,
                emailContent);

            EmailSendOperation emailSendOperation = await emailClient.SendAsync(WaitUntil.Completed, emailMessage);
            return emailSendOperation;
        }

        private async Task<EmailSendOperation> SendEmailAndWaitForExistingOperationAsync(EmailClient emailClient, EmailRecipients emailRecipients)
        {
            var emailContent = new EmailContent("subject");
            emailContent.PlainText = "Test";

            var emailMessage = new EmailMessage(
                TestEnvironment.SenderAddress,
                emailRecipients,
                emailContent);

            EmailSendOperation emailSendOperation = await emailClient.SendAsync(WaitUntil.Started, emailMessage);
            string operationId = emailSendOperation.Id;

            // Rehydrate operation with above existing operation id
            var existingOperation = new EmailSendOperation(operationId, emailClient);
            _ = await existingOperation.WaitForCompletionAsync().ConfigureAwait(false);

            return existingOperation;
        }

        private EmailSendOperation SendEmailAndWaitForExistingOperation(EmailClient emailClient, EmailRecipients emailRecipients)
        {
            var emailContent = new EmailContent("subject");
            emailContent.PlainText = "Test";

            var emailMessage = new EmailMessage(
                TestEnvironment.SenderAddress,
                emailRecipients,
                emailContent);

            EmailSendOperation emailSendOperation = emailClient.Send(WaitUntil.Started, emailMessage);
            string operationId = emailSendOperation.Id;

            // Rehydrate operation with above existing operation id
            var existingOperation = new EmailSendOperation(operationId, emailClient);
            _ = existingOperation.WaitForCompletion();

            return existingOperation;
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
                toEmailAddressList = new List<EmailAddress> { new EmailAddress(TestEnvironment.RecipientAddress, "ToAddress") };
            }

            if (setCc)
            {
                ccEmailAddressList = new List<EmailAddress> { new EmailAddress(TestEnvironment.RecipientAddress, "CcAddress") };
            }

            if (setBcc)
            {
                bccEmailAddressList = new List<EmailAddress> { new EmailAddress(TestEnvironment.RecipientAddress, "BccAddress") };
            }

            return new EmailRecipients(toEmailAddressList, ccEmailAddressList, bccEmailAddressList);
        }
    }
}
