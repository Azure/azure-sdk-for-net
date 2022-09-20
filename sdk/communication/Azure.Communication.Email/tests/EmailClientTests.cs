// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Net;
using Azure.Communication.Email.Models;
using Azure.Core.TestFramework;
using NUnit.Framework;

#nullable enable

namespace Azure.Communication.Email.Tests
{
    public class EmailClientTests : ClientTestBase
    {
        protected const string ConnectionString = "endpoint=https://contoso.azure.com/;accesskey=ZHVtbXlhY2Nlc3NrZXk=";

        public EmailClientTests(bool isAsync) : base(isAsync)
        {
        }

        [Test]
        public void Constructor_InvalidParamsThrows()
        {
            Assert.Throws<ArgumentNullException>(() => new EmailClient(null));
            Assert.Throws<ArgumentException>(() => new EmailClient(string.Empty));
            Assert.Throws<InvalidOperationException>(() => new EmailClient(" "));
            Assert.Throws<InvalidOperationException>(() => new EmailClient("mumbojumbo"));
        }

        [Test]
        public void SendEmail_InvalidParams_Throws()
        {
            EmailClient emailClient = CreateEmailClient();

            if (IsAsync)
            {
                Assert.ThrowsAsync<ArgumentNullException>(async () => await emailClient.SendAsync(null));
            }
            else
            {
                Assert.Throws<ArgumentNullException>(() => emailClient.Send(null));
            }
        }

        [Test]
        public void BadRequest_ThrowsException()
        {
            EmailClient emailClient = CreateEmailClient(HttpStatusCode.BadRequest);

            EmailMessage emailMessage = DefaultEmailMessage();

            RequestFailedException? exception = null;
            if (IsAsync)
            {
                exception = Assert.ThrowsAsync<RequestFailedException>(async () => await emailClient.SendAsync(emailMessage));
            }
            else
            {
                exception = Assert.Throws<RequestFailedException>(() => emailClient.Send(emailMessage));
            }
            Assert.AreEqual((int)HttpStatusCode.BadRequest, exception?.Status);
        }

        [Test]
        [TestCaseSource(nameof(InvalidEmailMessages))]
        public void InvalidEmailMessage_Throws_ArgumentException(EmailMessage emailMessage, string errorMessage)
        {
            EmailClient emailClient = CreateEmailClient(HttpStatusCode.BadRequest);

            ArgumentException? exception = null;
            if (IsAsync)
            {
                exception = Assert.ThrowsAsync<ArgumentException>(async () => await emailClient.SendAsync(emailMessage));
            }
            else
            {
                exception = Assert.Throws<ArgumentException>(() => emailClient.Send(emailMessage));
            }
            Assert.IsTrue(exception?.Message.Contains(errorMessage));
        }

        [Test]
        public void GetMessageStatus_InvalidMessageId()
        {
            EmailClient emailClient = CreateEmailClient();

            if (IsAsync)
            {
                Assert.ThrowsAsync<ArgumentException>(async () => await emailClient.GetSendStatusAsync(string.Empty));
                Assert.ThrowsAsync<ArgumentException>(async () => await emailClient.GetSendStatusAsync(null));
            }
            else
            {
                Assert.Throws<ArgumentException>(() => emailClient.GetSendStatus(string.Empty));
                Assert.Throws<ArgumentException>(() => emailClient.GetSendStatus(null));
            }
        }

        private EmailClient CreateEmailClient(HttpStatusCode statusCode = HttpStatusCode.OK)
        {
            var mockResponse = new MockResponse((int)statusCode);
            var emailClientOptions = new EmailClientOptions
            {
                Transport = new MockTransport(mockResponse, mockResponse, mockResponse, mockResponse)
            };

            return new EmailClient(ConnectionString, emailClientOptions);
        }

        private static IEnumerable<object?[]> InvalidEmailMessages()
        {
            return new[]
            {
                new object[]
                {
                    EmailMessageEmptySender(),
                    ErrorMessages.InvalidSenderEmail
                },
                new object[]
                {
                    EmailMessageInvalidSender(),
                    ErrorMessages.InvalidSenderEmail
                },
                new object[]
                {
                    EmailMessageEmptyContent(),
                    ErrorMessages.EmptyContent
                },
                new object[]
                {
                    EmailMessageEmptyToRecipients(),
                    ErrorMessages.EmptyToRecipients
                },
                new object[]
                {
                    EmailMessageInvalidToRecipients(),
                    ErrorMessages.InvalidEmailAddress
                },
                new object[]
                {
                    EmailMessageEmptySubject(),
                    ErrorMessages.EmptySubject
                },
                new object[]
                {
                    EmailMessageDuplicateCustomHeader(),
                    ErrorMessages.DuplicateHeaderName
                },
                new object[]
                {
                    EmailMessageEmptyCustomHeaderName(),
                    ErrorMessages.EmptyHeaderNameOrValue
                },
                new object[]
                {
                    EmailMessageEmptyCustomHeaderValue(),
                    ErrorMessages.EmptyHeaderNameOrValue
                },
                new object[]
                {
                    EmailMessageEmptyCcEmailAddress(),
                    ErrorMessages.InvalidEmailAddress
                },
                new object[]
                {
                    EmailMessageInvalidCcEmailAddress(),
                    ErrorMessages.InvalidEmailAddress
                },
                new object[]
                {
                    EmailMessageEmptyBccEmailAddress(),
                    ErrorMessages.InvalidEmailAddress
                },
                new object[]
                {
                    EmailMessageInvalidBccEmailAddress(),
                    ErrorMessages.InvalidEmailAddress
                },
                new object[]
                {
                    EmailMessageEmptyAttachment(),
                    ErrorMessages.InvalidAttachmentContent
                },
                new object[]
                {
                    EmailMessageInvalidAttachment(),
                    ErrorMessages.InvalidAttachmentContent
                }
            };
        }

        private static EmailMessage EmailMessageEmptySender()
        {
            return new EmailMessage(
                string.Empty,
                GetDefaultContent(DefaultSubject()),
                new EmailRecipients(DefaultRecipients()));
        }

        private static EmailMessage EmailMessageInvalidSender()
        {
            return new EmailMessage(
                "this is an invalid email address",
                GetDefaultContent(DefaultSubject()),
                new EmailRecipients(DefaultRecipients()));
        }

        private static EmailMessage EmailMessageEmptyToRecipients()
        {
            return new EmailMessage(
                DefaultSenderEmail(),
                GetDefaultContent(DefaultSubject()),
                new EmailRecipients(new List<EmailAddress>()));
        }

        private static object EmailMessageInvalidToRecipients()
        {
            return new EmailMessage(
                DefaultSenderEmail(),
                GetDefaultContent(DefaultSubject()),
                new EmailRecipients(new List<EmailAddress> { new EmailAddress("this is an invalid email address") }));
        }

        private static EmailMessage EmailMessageEmptyContent()
        {
            return new EmailMessage(
                DefaultSenderEmail(),
                new EmailContent(DefaultSubject()),
                new EmailRecipients(DefaultRecipients()));
        }

        private static EmailMessage EmailMessageEmptySubject()
        {
            return new EmailMessage(
                DefaultSenderEmail(),
                GetDefaultContent(string.Empty),
                new EmailRecipients(DefaultRecipients()));
        }

        private static EmailMessage EmailMessageDuplicateCustomHeader()
        {
            var emailMessage = DefaultEmailMessage();

            emailMessage.CustomHeaders.Add(new EmailCustomHeader("Key1", "Value1"));
            emailMessage.CustomHeaders.Add(new EmailCustomHeader("Key2", "Value2"));
            emailMessage.CustomHeaders.Add(new EmailCustomHeader("Key1", "Value3"));

            return emailMessage;
        }

        private static EmailMessage EmailMessageEmptyCustomHeaderName()
        {
            EmailMessage emailMessage = EmailMessageDuplicateCustomHeader();
            emailMessage.CustomHeaders.Add(new EmailCustomHeader(string.Empty, "Value"));

            return emailMessage;
        }

        private static EmailMessage EmailMessageEmptyCustomHeaderValue()
        {
            EmailMessage emailMessage = EmailMessageDuplicateCustomHeader();
            emailMessage.CustomHeaders.Add(new EmailCustomHeader("Key", string.Empty));

            return emailMessage;
        }

        private static EmailMessage EmailMessageEmptyCcEmailAddress()
        {
            var emailMessage = DefaultEmailMessage();
            emailMessage.Recipients.CC.Add(new EmailAddress(string.Empty));

            return emailMessage;
        }

        private static EmailMessage EmailMessageInvalidCcEmailAddress()
        {
            var emailMessage = DefaultEmailMessage();

            emailMessage.Recipients.CC.Add(new EmailAddress("Invalid Email Address"));

            return emailMessage;
        }

        private static EmailMessage EmailMessageEmptyBccEmailAddress()
        {
            var emailMessage = DefaultEmailMessage();
            emailMessage.Recipients.BCC.Add(new EmailAddress(string.Empty));

            return emailMessage;
        }

        private static EmailMessage EmailMessageInvalidBccEmailAddress()
        {
            var emailMessage = DefaultEmailMessage();
            emailMessage.Recipients.BCC.Add(new EmailAddress("Invalid Email Address"));

            return emailMessage;
        }

        private static EmailMessage EmailMessageEmptyAttachment()
        {
            var emailMessage = DefaultEmailMessage();

            emailMessage.Attachments.Add(new EmailAttachment(Guid.NewGuid().ToString(), EmailAttachmentType.Txt, string.Empty));

            return emailMessage;
        }

        private static EmailMessage EmailMessageInvalidAttachment()
        {
            var emailMessage = DefaultEmailMessage();
            emailMessage.Attachments.Add(new EmailAttachment(Guid.NewGuid().ToString(), EmailAttachmentType.Txt, "This is invalid attachment content")); //"gobbledygook"));

            return emailMessage;
        }

        private static EmailMessage DefaultEmailMessage()
        {
            return new EmailMessage(
                DefaultSenderEmail(),
                GetDefaultContent(DefaultSubject()),
                new EmailRecipients(DefaultRecipients()));
        }

        private static string DefaultSenderEmail()
        {
            return "alerts@contoso.com";
        }

        private static string DefaultSubject()
        {
            return "Email Subject";
        }

        private static EmailContent GetDefaultContent(string subject)
        {
            var content = new EmailContent(subject);
            content.PlainText = "Test";

            return content;
        }

        private static List<EmailAddress> DefaultRecipients()
        {
            return new List<EmailAddress> { new EmailAddress("customer@Contoso.com", "Customer Name") };
        }
    }
}
