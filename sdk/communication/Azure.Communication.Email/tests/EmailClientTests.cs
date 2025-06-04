// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Newtonsoft.Json;
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
                Assert.ThrowsAsync<ArgumentNullException>(async () => await emailClient.SendAsync(WaitUntil.Started, null));
            }
            else
            {
                Assert.Throws<ArgumentNullException>(() => emailClient.Send(WaitUntil.Started, null));
            }
        }

        [Test]
        [TestCaseSource(nameof(InvalidStringValues))]
        public void SendEmailOverload_InvalidSenderEmail_Throws(string invalidStringValue)
        {
            EmailClient emailClient = CreateEmailClient();
            EmailMessage emailMessage = DefaultEmailMessage();
            AsyncTestDelegate asyncCode = async () => await emailClient.SendAsync(
                    WaitUntil.Started,
                    invalidStringValue,
                    emailMessage.Recipients.To.First().Address,
                    emailMessage.Content.Subject,
                    emailMessage.Content.Html,
                    emailMessage.Content.PlainText);
            TestDelegate code = () => emailClient.Send(
                    WaitUntil.Started,
                    invalidStringValue,
                    emailMessage.Recipients.To.First().Address,
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
            AsyncTestDelegate asyncCode = async () => await emailClient.SendAsync(
                        WaitUntil.Started,
                        emailMessage.SenderAddress,
                        invalidStringValue,
                        emailMessage.Content.Subject,
                        emailMessage.Content.Html,
                        emailMessage.Content.PlainText);
            TestDelegate code = () => emailClient.Send(
                        WaitUntil.Started,
                        emailMessage.SenderAddress,
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
            AsyncTestDelegate asyncCode = async () => await emailClient.SendAsync(
                    WaitUntil.Started,
                    emailMessage.SenderAddress,
                    emailMessage.Recipients.To.First().Address,
                    invalidStringValue,
                    emailMessage.Content.Html,
                    emailMessage.Content.PlainText);
            TestDelegate code = () => emailClient.Send(
                    WaitUntil.Started,
                    emailMessage.SenderAddress,
                    emailMessage.Recipients.To.First().Address,
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
                Assert.ThrowsAsync<ArgumentException>(async () => await emailClient.SendAsync(
                    WaitUntil.Started,
                    emailMessage.SenderAddress,
                    emailMessage.Recipients.To.First().Address,
                    emailMessage.Content.Subject,
                    invalidStringValue,
                    invalidStringValue));
            }
            else
            {
                Assert.Throws<ArgumentException>(() => emailClient.Send(
                    WaitUntil.Started,
                    emailMessage.SenderAddress,
                    emailMessage.Recipients.To.First().Address,
                    emailMessage.Content.Subject,
                    invalidStringValue,
                    invalidStringValue));
            }
        }

        [Test]
        [TestCaseSource(nameof(InvalidStringValues))]
        public void SendEmailWithOperationIdOverload_InvalidToRecipient_Throws(string invalidStringValue)
        {
            EmailClient emailClient = CreateEmailClient();
            EmailMessage emailMessage = DefaultEmailMessage();
            Guid operationId = DefaultOperationId();
            AsyncTestDelegate asyncCode = async () => await emailClient.SendAsync(
                        WaitUntil.Started,
                        emailMessage.SenderAddress,
                        invalidStringValue,
                        emailMessage.Content.Subject,
                        emailMessage.Content.Html,
                        operationId,
                        emailMessage.Content.PlainText);
            TestDelegate code = () => emailClient.Send(
                        WaitUntil.Started,
                        emailMessage.SenderAddress,
                        invalidStringValue,
                        emailMessage.Content.Subject,
                        emailMessage.Content.Html,
                        operationId,
                        emailMessage.Content.PlainText);

            SendEmailOverload_ExecuteTest(invalidStringValue, asyncCode, code);
        }

        [Test]
        [TestCaseSource(nameof(InvalidStringValues))]
        public void SendEmailWithOperationIdOverload_InvalidSubject_Throws(string invalidStringValue)
        {
            EmailClient emailClient = CreateEmailClient();
            EmailMessage emailMessage = DefaultEmailMessage();
            Guid operationId = DefaultOperationId();
            AsyncTestDelegate asyncCode = async () => await emailClient.SendAsync(
                    WaitUntil.Started,
                    emailMessage.SenderAddress,
                    emailMessage.Recipients.To.First().Address,
                    invalidStringValue,
                    emailMessage.Content.Html,
                    operationId,
                    emailMessage.Content.PlainText);
            TestDelegate code = () => emailClient.Send(
                    WaitUntil.Started,
                    emailMessage.SenderAddress,
                    emailMessage.Recipients.To.First().Address,
                    invalidStringValue,
                    emailMessage.Content.Html,
                    operationId,
                    emailMessage.Content.PlainText);

            SendEmailOverload_ExecuteTest(invalidStringValue, asyncCode, code);
        }

        [Test]
        [TestCaseSource(nameof(InvalidStringValues))]
        public void SendEmailWithOperationIdOverload_InvalidContent_Throws(string invalidStringValue)
        {
            EmailClient emailClient = CreateEmailClient();
            EmailMessage emailMessage = DefaultEmailMessage();
            Guid operationId = DefaultOperationId();

            if (IsAsync)
            {
                Assert.ThrowsAsync<ArgumentException>(async () => await emailClient.SendAsync(
                    WaitUntil.Started,
                    emailMessage.SenderAddress,
                    emailMessage.Recipients.To.First().Address,
                    emailMessage.Content.Subject,
                    invalidStringValue,
                    operationId,
                    invalidStringValue));
            }
            else
            {
                Assert.Throws<ArgumentException>(() => emailClient.Send(
                    WaitUntil.Started,
                    emailMessage.SenderAddress,
                    emailMessage.Recipients.To.First().Address,
                    emailMessage.Content.Subject,
                    invalidStringValue,
                    operationId,
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
                exception = Assert.ThrowsAsync<RequestFailedException>(async () => await emailClient.SendAsync(WaitUntil.Started, emailMessage));
            }
            else
            {
                exception = Assert.Throws<RequestFailedException>(() => emailClient.Send(WaitUntil.Started, emailMessage));
            }
            Assert.AreEqual((int)HttpStatusCode.BadRequest, exception?.Status);
        }

        [Test]
        [TestCaseSource(nameof(InvalidEmailMessagesForArgumentException))]
        public void InvalidEmailMessage_Throws_ArgumentException(EmailMessage emailMessage, string errorMessage)
        {
            EmailClient emailClient = CreateEmailClient(HttpStatusCode.BadRequest);

            ArgumentException? exception = null;
            if (IsAsync)
            {
                exception = Assert.ThrowsAsync<ArgumentException>(async () => await emailClient.SendAsync(WaitUntil.Started, emailMessage));
            }
            else
            {
                exception = Assert.Throws<ArgumentException>(() => emailClient.Send(WaitUntil.Started, emailMessage));
            }
            Assert.IsTrue(exception?.Message.Contains(errorMessage));
        }

        [Test]
        [TestCaseSource(nameof(InvalidEmailMessagesForRequestFailedException))]
        public void InvalidEmailMessage_Throws_RequestFailedException(EmailMessage emailMessage, string errorMessage)
        {
            EmailClient emailClient = CreateEmailClient(HttpStatusCode.BadRequest);

            RequestFailedException? exception = null;
            if (IsAsync)
            {
                exception = Assert.ThrowsAsync<RequestFailedException>(async () => await emailClient.SendAsync(WaitUntil.Started, emailMessage));
            }
            else
            {
                exception = Assert.Throws<RequestFailedException>(() => emailClient.Send(WaitUntil.Started, emailMessage));
            }
            Assert.AreEqual((int)HttpStatusCode.BadRequest, exception?.Status);
        }

        [Test]
        [SyncOnly]
        public void EmailSend_RestClientReturnsSucceeded_NoException()
        {
            EmailClient emailClient = CreateEmailClientWithMockedFinalStatus(HttpStatusCode.OK, EmailSendStatus.Succeeded);
            var emailMessage = DefaultEmailMessage();

            EmailSendOperation emailSendOperation = emailClient.Send(WaitUntil.Started, emailMessage);

            while (true)
            {
                emailSendOperation.UpdateStatus();
                if (emailSendOperation.HasCompleted)
                {
                    break;
                }
                Thread.Sleep(1000);
            }

            Assert.IsTrue(emailSendOperation.HasCompleted);
            Assert.IsTrue(emailSendOperation.HasValue);
            Assert.IsNotNull(emailSendOperation.Id);
            Assert.AreEqual(EmailSendStatus.Succeeded, emailSendOperation.Value.Status);
        }

        [Test]
        [AsyncOnly]
        public async Task EmailSend_RestClientReturnsSucceeded_NoExceptionAsync()
        {
            EmailClient emailClient = CreateEmailClientWithMockedFinalStatus(HttpStatusCode.OK, EmailSendStatus.Succeeded);
            var emailMessage = DefaultEmailMessage();

            EmailSendOperation emailSendOperation = await emailClient.SendAsync(WaitUntil.Started, emailMessage);

            while (true)
            {
                await emailSendOperation.UpdateStatusAsync();
                if (emailSendOperation.HasCompleted)
                {
                    break;
                }
                Thread.Sleep(1000);
            }

            Assert.IsTrue(emailSendOperation.HasCompleted);
            Assert.IsTrue(emailSendOperation.HasValue);
            Assert.IsNotNull(emailSendOperation.Id);
            Assert.AreEqual(EmailSendStatus.Succeeded, emailSendOperation.Value.Status);
        }

        [Test]
        [SyncOnly]
        public void EmailSend_RestClientReturnsFailed_ThrowsException()
        {
            EmailClient emailClient = CreateEmailClientWithMockedFinalStatus(HttpStatusCode.OK, EmailSendStatus.Failed);
            var emailMessage = DefaultEmailMessage();

            EmailSendOperation emailSendOperation = emailClient.Send(WaitUntil.Started, emailMessage);

            RequestFailedException? exception = Assert.Throws<RequestFailedException>(() =>
            {
                while (true)
                {
                    emailSendOperation.UpdateStatus();
                    if (emailSendOperation.HasCompleted)
                    {
                        break;
                    }
                    Thread.Sleep(1000);
                }
            });

            Assert.AreEqual((int)HttpStatusCode.OK, exception?.Status);
            Assert.IsTrue(emailSendOperation.HasCompleted);
            Assert.IsFalse(emailSendOperation.HasValue);
            Assert.IsNotNull(emailSendOperation.Id);
        }

        [Test]
        [AsyncOnly]
        public async Task EmailSend_RestClientReturnsFailed_ThrowsExceptionAsync()
        {
            EmailClient emailClient = CreateEmailClientWithMockedFinalStatus(HttpStatusCode.OK, EmailSendStatus.Failed);
            var emailMessage = DefaultEmailMessage();

            EmailSendOperation emailSendOperation = await emailClient.SendAsync(WaitUntil.Started, emailMessage);

            RequestFailedException? exception = Assert.ThrowsAsync<RequestFailedException>(async () =>
            {
                while (true)
                {
                    await emailSendOperation.UpdateStatusAsync();
                    if (emailSendOperation.HasCompleted)
                    {
                        break;
                    }
                    Thread.Sleep(1000);
                }
            });

            Assert.AreEqual((int)HttpStatusCode.OK, exception?.Status);
            Assert.IsTrue(emailSendOperation.HasCompleted);
            Assert.IsFalse(emailSendOperation.HasValue);
            Assert.IsNotNull(emailSendOperation.Id);
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

        private EmailClient CreateEmailClientWithMockedFinalStatus(HttpStatusCode finalStatusCode, EmailSendStatus finalEmailSendStatus)
        {
            var mockEmailSendResult = new
            {
                id = Guid.NewGuid().ToString(),
                status = EmailSendStatus.Running.ToString(),
            };
            var mockSendMailResponse = new MockResponse((int)HttpStatusCode.Accepted);
            mockSendMailResponse.SetContent(JsonConvert.SerializeObject(mockEmailSendResult))
                .WithHeader("Content-Type", "application/json; charset=utf-8");

            var mockIntermediateGetStatusResult = new
            {
                id = Guid.NewGuid().ToString(),
                status = EmailSendStatus.Running.ToString(),
            };
            var mockIntermediateGetStatusResponse = new MockResponse((int)HttpStatusCode.OK);
            mockIntermediateGetStatusResponse.SetContent(JsonConvert.SerializeObject(mockIntermediateGetStatusResult))
                .WithHeader("Content-Type", "application/json; charset=utf-8");

            string mockFinalGetStatusResult;
            if (finalEmailSendStatus == EmailSendStatus.Succeeded)
            {
                var mockGetStatusResultObj = new
                {
                    id = Guid.NewGuid().ToString(),
                    status = finalEmailSendStatus.ToString()
                };
                mockFinalGetStatusResult = JsonConvert.SerializeObject(mockGetStatusResultObj);
            }
            else
            {
                var mockGetStatusResultObj = new
                {
                    id = Guid.NewGuid().ToString(),
                    status = finalEmailSendStatus.ToString(),
                    error = new
                    {
                        code = "EmailFailed",
                        message = "Invalid sender domain",
                        target = "SenderAddress"
                    }
                };
                mockFinalGetStatusResult = JsonConvert.SerializeObject(mockGetStatusResultObj);
            }
            var mockFinalGetStatusResponse = new MockResponse((int)finalStatusCode);
            mockFinalGetStatusResponse.SetContent(mockFinalGetStatusResult)
                .WithHeader("Content-Type", "application/json; charset=utf-8");

            var emailClientOptions = new EmailClientOptions
            {
                Transport = new MockTransport(mockSendMailResponse, mockIntermediateGetStatusResponse, mockFinalGetStatusResponse, mockFinalGetStatusResponse)
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

        private static IEnumerable<object?[]> InvalidEmailMessagesForArgumentException()
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
                    EmailMessageInvalidAttachment(),
                    ErrorMessages.InvalidAttachmentContent
                }
            };
        }

        private static IEnumerable<object?[]> InvalidEmailMessagesForRequestFailedException()
        {
            return new[]
            {
                new object[]
                {
                    EmailMessageInvalidSender(),
                    ErrorMessages.InvalidSenderEmail
                },
                new object[]
                {
                    EmailMessageInvalidToRecipients(),
                    ErrorMessages.InvalidEmailAddress
                },
                new object[]
                {
                    EmailMessageInvalidCcEmailAddress(),
                    ErrorMessages.InvalidEmailAddress
                },
                new object[]
                {
                    EmailMessageInvalidBccEmailAddress(),
                    ErrorMessages.InvalidEmailAddress
                },
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
                new EmailRecipients(DefaultRecipients()),
                GetDefaultContent(DefaultSubject()));
        }

        private static EmailMessage EmailMessageInvalidSender()
        {
            return new EmailMessage(
                "this is an invalid email address",
                new EmailRecipients(DefaultRecipients()),
                GetDefaultContent(DefaultSubject()));
        }

        private static EmailMessage EmailMessageEmptyToRecipients()
        {
            return new EmailMessage(
                DefaultSenderEmail(),
                new EmailRecipients(new List<EmailAddress>()),
                GetDefaultContent(DefaultSubject()));
        }

        private static object EmailMessageInvalidToRecipients()
        {
            return new EmailMessage(
                DefaultSenderEmail(),
                new EmailRecipients(new List<EmailAddress> { new EmailAddress("this is an invalid email address") }),
                GetDefaultContent(DefaultSubject()));
        }

        private static EmailMessage EmailMessageEmptyContent()
        {
            return new EmailMessage(
                DefaultSenderEmail(),
                new EmailRecipients(DefaultRecipients()),
                new EmailContent(DefaultSubject()));
        }

        private static EmailMessage EmailMessageEmptySubject()
        {
            return new EmailMessage(
                DefaultSenderEmail(),
                new EmailRecipients(DefaultRecipients()),
                GetDefaultContent(string.Empty));
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
                new EmailRecipients(DefaultRecipients()),
                GetDefaultContent(DefaultSubject()));
        }

        private static Guid DefaultOperationId()
        {
            return new("5de3fab9-f45f-4114-aa7c-b7f550909af8");
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
