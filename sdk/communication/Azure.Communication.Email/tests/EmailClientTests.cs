// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
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
                Assert.ThrowsAsync<ArgumentNullException>(async () => await emailClient.StartSendAsync(null, Guid.NewGuid()));
            }
            else
            {
                Assert.Throws<ArgumentNullException>(() => emailClient.StartSend(null, Guid.NewGuid()));
            }
        }

        [Test]
        [TestCaseSource(nameof(InvalidStringValues))]
        public void SendEmailOverload_InvalidSenderEmail_Throws(string invalidStringValue)
        {
            EmailClient emailClient = CreateEmailClient();
            EmailMessage emailMessage = DefaultEmailMessage();
            AsyncTestDelegate asyncCode = async () => await emailClient.StartSendAsync(
                    invalidStringValue,
                    emailMessage.Recipients.To.First().Email,
                    emailMessage.Content.Subject,
                    emailMessage.Content.Html,
                    emailMessage.Content.PlainText);
            TestDelegate code = () => emailClient.StartSend(
                    invalidStringValue,
                    emailMessage.Recipients.To.First().Email,
                    emailMessage.Content.Subject,
                    emailMessage.Content.Html,
                    emailMessage.Content.PlainText);

            SendEmailOverload_ExecuteTest(invalidStringValue, asyncCode, code);
        }

        private void SendEmailOverload_ExecuteTest(string invalidStringValue, AsyncTestDelegate asyncCode, TestDelegate code)
        {
            if (IsAsync)
            {
                if (invalidStringValue == null)
                {
                    Assert.ThrowsAsync<ArgumentNullException>(asyncCode);
                }
                else
                {
                    Assert.ThrowsAsync<ArgumentException>(asyncCode);
                }
            }
            else
            {
                if (invalidStringValue == null)
                {
                    Assert.Throws<ArgumentNullException>(code);
                }
                else
                {
                    Assert.Throws<ArgumentException>(code);
                }
            }
        }

        [Test]
        [TestCaseSource(nameof(InvalidStringValues))]
        public void SendEmailOverload_InvalidToRecipient_Throws(string invalidStringValue)
        {
            EmailClient emailClient = CreateEmailClient();
            EmailMessage emailMessage = DefaultEmailMessage();
            AsyncTestDelegate asyncCode = async () => await emailClient.StartSendAsync(
                        emailMessage.SenderEmail,
                        invalidStringValue,
                        emailMessage.Content.Subject,
                        emailMessage.Content.Html,
                        emailMessage.Content.PlainText);
            TestDelegate code = () => emailClient.StartSend(
                        emailMessage.SenderEmail,
                        invalidStringValue,
                        emailMessage.Content.Subject,
                        emailMessage.Content.Html,
                        emailMessage.Content.PlainText);

            SendEmailOverload_ExecuteTest(invalidStringValue, asyncCode, code);
        }

        [Test]
        [TestCaseSource(nameof(InvalidStringValues))]
        public void SendEmailOverload_InvalidSubject_Throws(string invalidStringValue)
        {
            EmailClient emailClient = CreateEmailClient();
            EmailMessage emailMessage = DefaultEmailMessage();
            AsyncTestDelegate asyncCode = async () => await emailClient.StartSendAsync(
                    emailMessage.SenderEmail,
                    emailMessage.Recipients.To.First().Email,
                    invalidStringValue,
                    emailMessage.Content.Html,
                    emailMessage.Content.PlainText);
            TestDelegate code = () => emailClient.StartSend(
                    emailMessage.SenderEmail,
                    emailMessage.Recipients.To.First().Email,
                    invalidStringValue,
                    emailMessage.Content.Html,
                    emailMessage.Content.PlainText);

            SendEmailOverload_ExecuteTest(invalidStringValue, asyncCode, code);
        }

        [Test]
        [TestCaseSource(nameof(InvalidStringValues))]
        public void SendEmailOverload_InvalidContent_Throws(string invalidStringValue)
        {
            EmailClient emailClient = CreateEmailClient();
            EmailMessage emailMessage = DefaultEmailMessage();

            if (IsAsync)
            {
                Assert.ThrowsAsync<ArgumentException>(async () => await emailClient.StartSendAsync(
                    emailMessage.SenderEmail,
                    emailMessage.Recipients.To.First().Email,
                    emailMessage.Content.Subject,
                    invalidStringValue,
                    invalidStringValue));
            }
            else
            {
                Assert.Throws<ArgumentException>(() => emailClient.StartSend(
                    emailMessage.SenderEmail,
                    emailMessage.Recipients.To.First().Email,
                    emailMessage.Content.Subject,
                    invalidStringValue,
                    invalidStringValue));
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
                exception = Assert.ThrowsAsync<RequestFailedException>(async () => await emailClient.StartSendAsync(emailMessage, Guid.NewGuid()));
            }
            else
            {
                exception = Assert.Throws<RequestFailedException>(() => emailClient.StartSend(emailMessage, Guid.NewGuid()));
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
                exception = Assert.ThrowsAsync<ArgumentException>(async () => await emailClient.StartSendAsync(emailMessage, Guid.NewGuid()));
            }
            else
            {
                exception = Assert.Throws<ArgumentException>(() => emailClient.StartSend(emailMessage, Guid.NewGuid()));
            }
            Assert.IsTrue(exception?.Message.Contains(errorMessage));
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

        private static IEnumerable<object[]> InvalidParamsForSendEmailOverload()
        {
            EmailMessage emailMessage = DefaultEmailMessage();

            yield return new object[]
            {
                new object?[] {
                    null,
                    emailMessage.Recipients.To.First(),
                    emailMessage.Content.Subject,
                    emailMessage.Content.Html,
                }
            };

            yield return new object[]
            {
                new object?[] {
                    string.Empty,
                    emailMessage.Recipients.To.First(),
                    emailMessage.Content.Subject,
                    emailMessage.Content.Html,
                }
            };

            yield return new object[]
            {
                new object?[] {
                    null,
                    emailMessage.Recipients.To.First(),
                    emailMessage.Content.Subject,
                    emailMessage.Content.Html,
                }
            };

            yield return new object[]
            {
                new object?[] {
                    null,
                    emailMessage.Recipients.To.First(),
                    emailMessage.Content.Subject,
                    emailMessage.Content.Html,
                }
            };
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
                    EmailMessageEmptyCustomHeaderValue(),
                    ErrorMessages.EmptyHeaderValue
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
                    EmailMessageInvalidAttachment(),
                    ErrorMessages.InvalidAttachmentContent
                }
            };
        }

        private static IEnumerable<string?> InvalidStringValues()
        {
            yield return null;
            yield return string.Empty;
            yield return "   ";
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

        private static EmailMessage EmailMessageEmptyCustomHeaderValue()
        {
            EmailMessage emailMessage = DefaultEmailMessage();

            emailMessage.Headers.Add("Key1", "Value1");
            emailMessage.Headers.Add("Key", string.Empty);

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

        private static EmailMessage EmailMessageInvalidAttachment()
        {
            var emailMessage = DefaultEmailMessage();

            emailMessage.Attachments.Add(new EmailAttachment(Guid.NewGuid().ToString(), "text/plain", new BinaryData("")));

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
