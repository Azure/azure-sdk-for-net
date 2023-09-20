// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.Diagnostics;
using Azure.Core.Pipeline;
using Microsoft.Identity.Client;
using NUnit.Framework;
using Azure.Core.TestFramework;

namespace Azure.Identity.Tests
{
    public class MsalClientBaseTests
    {
        [Test]
        [NonParallelizable]
        public void LogPiiIsEnforcedPerInstance([Values(true, false)] bool logPii)
        {
            string client1Message = "client1";
            string client2Message = "client2";
            List<string> messages = new();

            using AzureEventSourceListener listener = new(
                (args, _) =>
                {
                    if (args.EventName.StartsWith(nameof(AzureIdentityEventSource.LogMsal)))
                    {
                        messages.Add(args.GetProperty<string>("message"));
                    }
                },
                EventLevel.Verbose);

            var client_1 = new MockMsalClient(
                new CredentialPipeline(new HttpPipeline(new MockTransport()), new ClientDiagnostics(Moq.Mock.Of<ClientOptions>())),
                "tenant",
                "client",
                new InteractiveBrowserCredentialOptions(){ IsUnsafeSupportLoggingEnabled = logPii });

            var client_2 = new MockMsalClient(
                new CredentialPipeline(new HttpPipeline(new MockTransport()), new ClientDiagnostics(Moq.Mock.Of<ClientOptions>())),
                "tenant",
                "client",
                new InteractiveBrowserCredentialOptions(){ IsUnsafeSupportLoggingEnabled = false }); // never log PII

            Assert.AreEqual(logPii, client_1.IsSupportLoggingEnabled);

            client_1.Log(client1Message, true);
            client_2.Log(client2Message, true);

            if (logPii)
            {
                Assert.Contains(client1Message, messages);
            }
            Assert.That(messages, Does.Not.Contain(client2Message));
            messages.Clear();

            client_1.Log(client1Message, false);
            client_2.Log(client2Message, false);

            Assert.That(messages, Contains.Item(client1Message));
            Assert.That(messages, Contains.Item(client2Message));
        }

        private class MockMsalClient : MsalClientBase<IClientApplicationBase>
        {
            public MockMsalClient(CredentialPipeline pipeline, string tenantId, string clientId, TokenCredentialOptions options)
                : base(pipeline, tenantId, clientId, options)
            { }

            public ManualResetEventSlim Evt { get; set; }

            protected override ValueTask<IClientApplicationBase> CreateClientAsync(bool enableCae, bool async, CancellationToken cancellationToken)
                => throw new NotImplementedException();

            public void Log(string message, bool isPii)
            {
                LogMsal(LogLevel.Error, message, isPii);
            }
        }
    }
}
