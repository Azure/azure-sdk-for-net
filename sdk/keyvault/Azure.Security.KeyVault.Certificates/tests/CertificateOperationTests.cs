// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.Core.TestFramework;
using Azure.Security.KeyVault.Tests;
using NUnit.Framework;

namespace Azure.Security.KeyVault.Certificates.Tests
{
    [NonParallelizable]
    public class CertificateOperationTests : ClientTestBase
    {
        private const string VaultUri = "https://test.vault.azure.net";
        private const string CertificateId = "https://test.vault.azure.net/certificates/test-cert";
        private const string CertificateName = "test-cert";

        private static readonly string s_policyJson = $@"{{""id"":""{CertificateId}/policy"",""issuer"":{{""name"":""Self""}}}}";
        private static readonly CertificatePolicy s_policy;

        private TestEventListener _listener;

        public CertificateOperationTests(bool isAsync) : base(isAsync)
        {
        }

        static CertificateOperationTests()
        {
            var policy = new CertificatePolicy();
            ((IJsonDeserializable)policy).ReadProperties(JsonDocument.Parse(s_policyJson).RootElement);

            s_policy = policy;
        }

        [SetUp]
        public void Setup()
        {
            _listener = new TestEventListener();
            _listener.EnableEvents(CertificatesEventSource.Singleton, EventLevel.Verbose);
        }

        [TearDown]
        public void TearDown()
        {
            _listener.Dispose();
        }

        [Test]
        public async Task UpdateStatusCompleted()
        {
            var transport = new MockTransport(new[]
            {
                new MockResponse(202).WithContent($@"{{""id"":""{CertificateId}/pending"",""status"":""inProgress""}}"),
                new MockResponse(200).WithContent($@"{{""id"":""{CertificateId}/pending"",""status"":""completed""}}"),
                new MockResponse(200).WithContent($@"{{""id"":""{CertificateId}/1"",""policy"":{s_policyJson}}}"),
            });

            CertificateClient client = CreateClient(transport);
            CertificateOperation operation = await client.StartCreateCertificateAsync(CertificateName, s_policy);

            await WaitForOperationAsync(operation);

            // Begin
            IEnumerable<EventWrittenEventArgs> messages = _listener.EventsById(CertificatesEventSource.BeginUpdateStatusEvent);
            AssertMessageCount(1, messages);

            EventWrittenEventArgs message = messages.Last();
            Assert.That(message.Level, Is.EqualTo(EventLevel.Verbose));
            Assert.That(message.EventName, Is.EqualTo("BeginUpdateStatus"));
            Assert.That(message.GetProperty<string>("id"), Is.EqualTo($"{CertificateId}/pending"));
            Assert.That(message.GetProperty<string>("status"), Is.EqualTo("inProgress"));
            Assert.That(message.GetProperty<string>("error"), Is.EqualTo("(none)"));

            // End
            messages = _listener.EventsById(CertificatesEventSource.EndUpdateStatusEvent);
            AssertMessageCount(1, messages);

            message = messages.Last();
            Assert.That(message.Level, Is.EqualTo(EventLevel.Verbose));
            Assert.That(message.EventName, Is.EqualTo("EndUpdateStatus"));
            Assert.That(message.GetProperty<string>("id"), Is.EqualTo($"{CertificateId}/pending"));
            Assert.That(message.GetProperty<string>("status"), Is.EqualTo("completed"));
            Assert.That(message.GetProperty<string>("error"), Is.EqualTo("(none)"));
        }

        [Test]
        public async Task UpdateStatusEventuallyCompleted()
        {
            var transport = new MockTransport(new[]
            {
                new MockResponse(202).WithContent($@"{{""id"":""{CertificateId}/pending"",""status"":""inProgress""}}"),

                new MockResponse(200).WithContent($@"{{""id"":""{CertificateId}/pending"",""status"":""inProgress""}}"),
                new MockResponse(200).WithContent($@"{{""id"":""{CertificateId}/pending"",""status"":""inProgress""}}"),
                new MockResponse(200).WithContent($@"{{""id"":""{CertificateId}/pending"",""status"":""inProgress""}}"),
                new MockResponse(200).WithContent($@"{{""id"":""{CertificateId}/pending"",""status"":""inProgress""}}"),
                new MockResponse(200).WithContent($@"{{""id"":""{CertificateId}/pending"",""status"":""inProgress""}}"),
                new MockResponse(200).WithContent($@"{{""id"":""{CertificateId}/pending"",""status"":""inProgress""}}"),
                new MockResponse(200).WithContent($@"{{""id"":""{CertificateId}/pending"",""status"":""inProgress""}}"),
                new MockResponse(200).WithContent($@"{{""id"":""{CertificateId}/pending"",""status"":""inProgress""}}"),
                new MockResponse(200).WithContent($@"{{""id"":""{CertificateId}/pending"",""status"":""inProgress""}}"),

                new MockResponse(200).WithContent($@"{{""id"":""{CertificateId}/pending"",""status"":""completed""}}"),
                new MockResponse(200).WithContent($@"{{""id"":""{CertificateId}/1"",""policy"":{s_policyJson}}}"),
            });

            CertificateClient client = CreateClient(transport);
            CertificateOperation operation = await client.StartCreateCertificateAsync(CertificateName, s_policy);

            await WaitForOperationAsync(operation);

            // Begin
            IEnumerable<EventWrittenEventArgs> messages = _listener.EventsById(CertificatesEventSource.BeginUpdateStatusEvent);
            Assert.That(messages.Count(), Is.EqualTo(10));

            EventWrittenEventArgs message = messages.Last();
            Assert.That(message.Level, Is.EqualTo(EventLevel.Verbose));
            Assert.That(message.EventName, Is.EqualTo("BeginUpdateStatus"));
            Assert.That(message.GetProperty<string>("id"), Is.EqualTo($"{CertificateId}/pending"));
            Assert.That(message.GetProperty<string>("status"), Is.EqualTo("inProgress"));
            Assert.That(message.GetProperty<string>("error"), Is.EqualTo("(none)"));

            // End
            messages = _listener.EventsById(CertificatesEventSource.EndUpdateStatusEvent);
            AssertMessageCount(10, messages);

            message = messages.Last();
            Assert.That(message.Level, Is.EqualTo(EventLevel.Verbose));
            Assert.That(message.EventName, Is.EqualTo("EndUpdateStatus"));
            Assert.That(message.GetProperty<string>("id"), Is.EqualTo($"{CertificateId}/pending"));
            Assert.That(message.GetProperty<string>("status"), Is.EqualTo("completed"));
            Assert.That(message.GetProperty<string>("error"), Is.EqualTo("(none)"));
        }

        [Test]
        public async Task UpdateStatusCanceled()
        {
            var transport = new MockTransport(new[]
            {
                new MockResponse(202).WithContent($@"{{""id"":""{CertificateId}/pending"",""status"":""inProgress""}}"),

                new MockResponse(200).WithContent($@"{{""id"":""{CertificateId}/pending"",""status"":""inProgress""}}"),
                new MockResponse(200).WithContent($@"{{""id"":""{CertificateId}/pending"",""status"":""inProgress""}}"),
                new MockResponse(200).WithContent($@"{{""id"":""{CertificateId}/pending"",""status"":""inProgress""}}"),
                new MockResponse(200).WithContent($@"{{""id"":""{CertificateId}/pending"",""status"":""inProgress""}}"),

                new MockResponse(200).WithContent($@"{{""id"":""{CertificateId}/pending"",""status"":""cancelled""}}"),
            });

            CertificateClient client = CreateClient(transport);
            CertificateOperation operation = await client.StartCreateCertificateAsync(CertificateName, s_policy);

            Exception ex = Assert.ThrowsAsync<OperationCanceledException>(async () => await WaitForOperationAsync(operation));
            Assert.That(ex.Message, Is.EqualTo("The operation was canceled so no value is available."));

            // Begin
            IEnumerable<EventWrittenEventArgs> messages = _listener.EventsById(CertificatesEventSource.BeginUpdateStatusEvent);
            AssertMessageCount(5, messages);

            EventWrittenEventArgs message = messages.Last();
            Assert.That(message.Level, Is.EqualTo(EventLevel.Verbose));
            Assert.That(message.EventName, Is.EqualTo("BeginUpdateStatus"));
            Assert.That(message.GetProperty<string>("id"), Is.EqualTo($"{CertificateId}/pending"));
            Assert.That(message.GetProperty<string>("status"), Is.EqualTo("inProgress"));
            Assert.That(message.GetProperty<string>("error"), Is.EqualTo("(none)"));

            // End
            messages = _listener.EventsById(CertificatesEventSource.EndUpdateStatusEvent);
            AssertMessageCount(5, messages);

            message = messages.Last();
            Assert.That(message.Level, Is.EqualTo(EventLevel.Verbose));
            Assert.That(message.EventName, Is.EqualTo("EndUpdateStatus"));
            Assert.That(message.GetProperty<string>("id"), Is.EqualTo($"{CertificateId}/pending"));
            Assert.That(message.GetProperty<string>("status"), Is.EqualTo("cancelled"));
            Assert.That(message.GetProperty<string>("error"), Is.EqualTo("(none)"));
        }

        [Test]
        public async Task UpdateStatusDeleted()
        {
            var transport = new MockTransport(new[]
            {
                new MockResponse(202).WithContent($@"{{""id"":""{CertificateId}/pending"",""status"":""inProgress""}}"),

                new MockResponse(200).WithContent($@"{{""id"":""{CertificateId}/pending"",""status"":""inProgress""}}"),
                new MockResponse(200).WithContent($@"{{""id"":""{CertificateId}/pending"",""status"":""inProgress""}}"),
                new MockResponse(200).WithContent($@"{{""id"":""{CertificateId}/pending"",""status"":""inProgress""}}"),
                new MockResponse(200).WithContent($@"{{""id"":""{CertificateId}/pending"",""status"":""inProgress""}}"),

                new MockResponse(404),
            });

            CertificateClient client = CreateClient(transport);
            CertificateOperation operation = await client.StartCreateCertificateAsync(CertificateName, s_policy);

            Exception ex = Assert.ThrowsAsync<InvalidOperationException>(async () => await WaitForOperationAsync(operation));
            Assert.That(ex.Message, Is.EqualTo("The operation was deleted so no value is available."));

            // Begin
            IEnumerable<EventWrittenEventArgs> messages = _listener.EventsById(CertificatesEventSource.BeginUpdateStatusEvent);
            AssertMessageCount(5, messages);

            EventWrittenEventArgs message = messages.Last();
            Assert.That(message.Level, Is.EqualTo(EventLevel.Verbose));
            Assert.That(message.EventName, Is.EqualTo("BeginUpdateStatus"));
            Assert.That(message.GetProperty<string>("id"), Is.EqualTo($"{CertificateId}/pending"));
            Assert.That(message.GetProperty<string>("status"), Is.EqualTo("inProgress"));
            Assert.That(message.GetProperty<string>("error"), Is.EqualTo("(none)"));

            // End
            messages = _listener.EventsById(CertificatesEventSource.EndUpdateStatusEvent);
            AssertMessageCount(5, messages);

            message = messages.Last();
            Assert.That(message.Level, Is.EqualTo(EventLevel.Verbose));
            Assert.That(message.EventName, Is.EqualTo("EndUpdateStatus"));
            Assert.That(message.GetProperty<string>("id"), Is.EqualTo("(deleted)"));
            Assert.That(message.GetProperty<string>("status"), Is.Empty);
            Assert.That(message.GetProperty<string>("error"), Is.EqualTo("(none)"));
        }

        [Test]
        public async Task UpdateStatusErred()
        {
            var transport = new MockTransport(new[]
            {
                new MockResponse(202).WithContent($@"{{""id"":""{CertificateId}/pending"",""status"":""inProgress""}}"),

                new MockResponse(200).WithContent($@"{{""id"":""{CertificateId}/pending"",""status"":""inProgress""}}"),
                new MockResponse(200).WithContent($@"{{""id"":""{CertificateId}/pending"",""status"":""inProgress""}}"),
                new MockResponse(200).WithContent($@"{{""id"":""{CertificateId}/pending"",""status"":""inProgress""}}"),
                new MockResponse(200).WithContent($@"{{""id"":""{CertificateId}/pending"",""status"":""inProgress""}}"),

                new MockResponse(200).WithContent($@"{{""id"":""{CertificateId}/pending"",""status"":""failed"",""error"":{{""code"":""mock failure code"",""message"":""mock failure message""}}}}"),
            });

            CertificateClient client = CreateClient(transport);
            CertificateOperation operation = await client.StartCreateCertificateAsync(CertificateName, s_policy);

            Exception ex = Assert.ThrowsAsync<InvalidOperationException>(async () => await WaitForOperationAsync(operation));
            Assert.That(ex.Message, Is.EqualTo("The certificate operation failed: mock failure message"));

            // Begin
            IEnumerable<EventWrittenEventArgs> messages = _listener.EventsById(CertificatesEventSource.BeginUpdateStatusEvent);
            AssertMessageCount(5, messages);

            EventWrittenEventArgs message = messages.Last();
            Assert.That(message.Level, Is.EqualTo(EventLevel.Verbose));
            Assert.That(message.EventName, Is.EqualTo("BeginUpdateStatus"));
            Assert.That(message.GetProperty<string>("id"), Is.EqualTo($"{CertificateId}/pending"));
            Assert.That(message.GetProperty<string>("status"), Is.EqualTo("inProgress"));
            Assert.That(message.GetProperty<string>("error"), Is.EqualTo("(none)"));

            // End
            messages = _listener.EventsById(CertificatesEventSource.EndUpdateStatusEvent);
            AssertMessageCount(5, messages);

            message = messages.Last();
            Assert.That(message.Level, Is.EqualTo(EventLevel.Verbose));
            Assert.That(message.EventName, Is.EqualTo("EndUpdateStatus"));
            Assert.That(message.GetProperty<string>("id"), Is.EqualTo($"{CertificateId}/pending"));
            Assert.That(message.GetProperty<string>("status"), Is.EqualTo("failed"));
            Assert.That(message.GetProperty<string>("error"), Is.EqualTo("mock failure message"));
        }

        private static void AssertMessageCount(int expected, IEnumerable<EventWrittenEventArgs> messages)
        {
            int actual = messages.Count();
            if (actual != expected)
            {
                StringBuilder sb = new StringBuilder($"Expected {expected} messages; got {actual}\nMessages:\n");
                foreach (EventWrittenEventArgs message in messages)
                {
                    sb.AppendFormat("- {0} ({1}): {2}\n", message.EventName, message.EventId, message.Message);
                }

                Assert.Fail(sb.ToString());
            }
        }

        private CertificateClient CreateClient(HttpPipelineTransport transport)
        {
            CertificateClientOptions options = new CertificateClientOptions
            {
                Retry =
                {
                    Delay = TimeSpan.FromMilliseconds(10),
                    Mode = RetryMode.Fixed,
                },
                Transport = transport,
            };

            return InstrumentClient(
                new CertificateClient(
                    new Uri(VaultUri),
                    new MockCredential(),
                    options
                    ));
        }

        private async ValueTask<KeyVaultCertificateWithPolicy> WaitForOperationAsync(CertificateOperation operation) =>
            await operation.WaitForCompletionAsync();

        public class MockCredential : TokenCredential
        {
            private readonly AccessToken _token = new AccessToken("mockToken", DateTimeOffset.UtcNow.AddHours(1));

            public override AccessToken GetToken(TokenRequestContext requestContext, CancellationToken cancellationToken)
            {
                return _token;
            }

            public override ValueTask<AccessToken> GetTokenAsync(TokenRequestContext requestContext, CancellationToken cancellationToken)
            {
                return new ValueTask<AccessToken>(_token);
            }
        }
    }
}
