// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using System.Linq;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.Core.TestFramework;
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
            Assert.AreEqual(1, messages.Count());

            EventWrittenEventArgs message = messages.Last();
            Assert.AreEqual(EventLevel.Verbose, message.Level);
            Assert.AreEqual("BeginUpdateStatus", message.EventName);
            Assert.AreEqual($"{CertificateId}/pending", message.GetProperty<string>("id"));
            Assert.AreEqual("inProgress", message.GetProperty<string>("status"));
            Assert.AreEqual("(none)", message.GetProperty<string>("error"));

            // End
            messages = _listener.EventsById(CertificatesEventSource.EndUpdateStatusEvent);
            Assert.AreEqual(1, messages.Count());

            message = messages.Last();
            Assert.AreEqual(EventLevel.Verbose, message.Level);
            Assert.AreEqual("EndUpdateStatus", message.EventName);
            Assert.AreEqual($"{CertificateId}/pending", message.GetProperty<string>("id"));
            Assert.AreEqual("completed", message.GetProperty<string>("status"));
            Assert.AreEqual("(none)", message.GetProperty<string>("error"));
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
            Assert.AreEqual(10, messages.Count());

            EventWrittenEventArgs message = messages.Last();
            Assert.AreEqual(EventLevel.Verbose, message.Level);
            Assert.AreEqual("BeginUpdateStatus", message.EventName);
            Assert.AreEqual($"{CertificateId}/pending", message.GetProperty<string>("id"));
            Assert.AreEqual("inProgress", message.GetProperty<string>("status"));
            Assert.AreEqual("(none)", message.GetProperty<string>("error"));

            // End
            messages = _listener.EventsById(CertificatesEventSource.EndUpdateStatusEvent);
            Assert.AreEqual(10, messages.Count());

            message = messages.Last();
            Assert.AreEqual(EventLevel.Verbose, message.Level);
            Assert.AreEqual("EndUpdateStatus", message.EventName);
            Assert.AreEqual($"{CertificateId}/pending", message.GetProperty<string>("id"));
            Assert.AreEqual("completed", message.GetProperty<string>("status"));
            Assert.AreEqual("(none)", message.GetProperty<string>("error"));
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
            Assert.AreEqual("The operation was canceled so no value is available.", ex.Message);

            // Begin
            IEnumerable<EventWrittenEventArgs> messages = _listener.EventsById(CertificatesEventSource.BeginUpdateStatusEvent);
            Assert.AreEqual(5, messages.Count());

            EventWrittenEventArgs message = messages.Last();
            Assert.AreEqual(EventLevel.Verbose, message.Level);
            Assert.AreEqual("BeginUpdateStatus", message.EventName);
            Assert.AreEqual($"{CertificateId}/pending", message.GetProperty<string>("id"));
            Assert.AreEqual("inProgress", message.GetProperty<string>("status"));
            Assert.AreEqual("(none)", message.GetProperty<string>("error"));

            // End
            messages = _listener.EventsById(CertificatesEventSource.EndUpdateStatusEvent);
            Assert.AreEqual(5, messages.Count());

            message = messages.Last();
            Assert.AreEqual(EventLevel.Verbose, message.Level);
            Assert.AreEqual("EndUpdateStatus", message.EventName);
            Assert.AreEqual($"{CertificateId}/pending", message.GetProperty<string>("id"));
            Assert.AreEqual("cancelled", message.GetProperty<string>("status"));
            Assert.AreEqual("(none)", message.GetProperty<string>("error"));
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
            Assert.AreEqual("The operation was deleted so no value is available.", ex.Message);

            // Begin
            IEnumerable<EventWrittenEventArgs> messages = _listener.EventsById(CertificatesEventSource.BeginUpdateStatusEvent);
            Assert.AreEqual(5, messages.Count());

            EventWrittenEventArgs message = messages.Last();
            Assert.AreEqual(EventLevel.Verbose, message.Level);
            Assert.AreEqual("BeginUpdateStatus", message.EventName);
            Assert.AreEqual($"{CertificateId}/pending", message.GetProperty<string>("id"));
            Assert.AreEqual("inProgress", message.GetProperty<string>("status"));
            Assert.AreEqual("(none)", message.GetProperty<string>("error"));

            // End
            messages = _listener.EventsById(CertificatesEventSource.EndUpdateStatusEvent);
            Assert.AreEqual(5, messages.Count());

            message = messages.Last();
            Assert.AreEqual(EventLevel.Verbose, message.Level);
            Assert.AreEqual("EndUpdateStatus", message.EventName);
            Assert.AreEqual("(deleted)", message.GetProperty<string>("id"));
            Assert.AreEqual(string.Empty, message.GetProperty<string>("status"));
            Assert.AreEqual("(none)", message.GetProperty<string>("error"));
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
            Assert.AreEqual("The certificate operation failed: mock failure message", ex.Message);

            // Begin
            IEnumerable<EventWrittenEventArgs> messages = _listener.EventsById(CertificatesEventSource.BeginUpdateStatusEvent);
            Assert.AreEqual(5, messages.Count());

            EventWrittenEventArgs message = messages.Last();
            Assert.AreEqual(EventLevel.Verbose, message.Level);
            Assert.AreEqual("BeginUpdateStatus", message.EventName);
            Assert.AreEqual($"{CertificateId}/pending", message.GetProperty<string>("id"));
            Assert.AreEqual("inProgress", message.GetProperty<string>("status"));
            Assert.AreEqual("(none)", message.GetProperty<string>("error"));

            // End
            messages = _listener.EventsById(CertificatesEventSource.EndUpdateStatusEvent);
            Assert.AreEqual(5, messages.Count());

            message = messages.Last();
            Assert.AreEqual(EventLevel.Verbose, message.Level);
            Assert.AreEqual("EndUpdateStatus", message.EventName);
            Assert.AreEqual($"{CertificateId}/pending", message.GetProperty<string>("id"));
            Assert.AreEqual("failed", message.GetProperty<string>("status"));
            Assert.AreEqual("mock failure message", message.GetProperty<string>("error"));
        }

        private CertificateClient CreateClient(HttpPipelineTransport transport)
        {
            CertificateClientOptions options = new CertificateClientOptions
            {
                Transport = transport,
            };

            return InstrumentClient(
                new CertificateClient(
                    new Uri(VaultUri),
                    new MockCredential(),
                    options
                    ));
        }

        private async ValueTask<KeyVaultCertificateWithPolicy> WaitForOperationAsync(CertificateOperation operation)
        {
            var rand = new Random();
            TimeSpan PollingInterval() => TimeSpan.FromMilliseconds(rand.Next(1, 50));

            if (IsAsync)
            {
                return await operation.WaitForCompletionAsync(PollingInterval(), default);
            }
            else
            {
                while (!operation.HasCompleted)
                {
                    operation.UpdateStatus();
                    await Task.Delay(PollingInterval());
                }

                return operation.Value;
            }
        }

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
