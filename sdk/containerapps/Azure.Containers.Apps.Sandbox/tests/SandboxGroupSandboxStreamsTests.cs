// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Net.WebSockets;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.Containers.Apps.Sandbox.Tests
{
    public class SandboxGroupSandboxStreamsTests
    {
        private const string ExpectedToken = "TEST TOKEN https://management.azuredevcompute.io/.default";

        [Test]
        public async Task ConnectToSandboxExecStreamBuildsAuthenticatedUri()
        {
            SandboxGroupSandboxStreams client = CreateClient();
            using var expectedSocket = new ClientWebSocket();
            Uri actualUri = null;
            string actualToken = null;
            CancellationToken actualCancellationToken = default;
            using var cancellationTokenSource = new CancellationTokenSource();
            client.WebSocketConnector = (uri, token, cancellationToken) =>
            {
                actualUri = uri;
                actualToken = token;
                actualCancellationToken = cancellationToken;
                return Task.FromResult<WebSocket>(expectedSocket);
            };

            SandboxStream stream = await client.ConnectToSandboxExecStreamAsync(
                new MockCredential(),
                "main/container",
                "sandbox user",
                cancellationTokenSource.Token);

            Assert.That(stream.WebSocket, Is.SameAs(expectedSocket));
            Assert.That(
                actualUri.AbsoluteUri,
                Is.EqualTo("wss://example.test/base/subscriptions/subscription/resourceGroups/resource%20group/sandboxGroups/group/sandboxes/sandbox/exec/stream?api-version=2026-09-01-preview&containerName=main%2Fcontainer&user=sandbox%20user"));
            Assert.That(actualToken, Is.EqualTo(ExpectedToken));
            Assert.That(actualCancellationToken, Is.EqualTo(cancellationTokenSource.Token));
        }

        [Test]
        public async Task ConnectToSandboxLogStreamIncludesOptionalParameters()
        {
            SandboxGroupSandboxStreams client = CreateClient();
            using var expectedSocket = new ClientWebSocket();
            Uri actualUri = null;
            client.WebSocketConnector = (uri, _, _) =>
            {
                actualUri = uri;
                return Task.FromResult<WebSocket>(expectedSocket);
            };

            SandboxStream stream = await client.ConnectToSandboxLogStreamAsync(
                new MockCredential(),
                tailLines: 25,
                logFormat: 1,
                follow: true,
                containerName: "main");

            Assert.That(stream.WebSocket, Is.SameAs(expectedSocket));
            Assert.That(
                actualUri.AbsoluteUri,
                Is.EqualTo("wss://example.test/base/subscriptions/subscription/resourceGroups/resource%20group/sandboxGroups/group/sandboxes/sandbox/logstream?api-version=2026-09-01-preview&tailLines=25&logFormat=1&follow=true&containerName=main"));
        }

        [Test]
        public async Task ConnectToSandboxProcessesStreamOmitsNullContainerName()
        {
            SandboxGroupSandboxStreams client = CreateClient(new Uri("http://localhost:8080"));
            using var expectedSocket = new ClientWebSocket();
            Uri actualUri = null;
            client.WebSocketConnector = (uri, _, _) =>
            {
                actualUri = uri;
                return Task.FromResult<WebSocket>(expectedSocket);
            };

            SandboxStream stream = await client.ConnectToSandboxProcessesStreamAsync(new MockCredential());

            Assert.That(stream.WebSocket, Is.SameAs(expectedSocket));
            Assert.That(
                actualUri.AbsoluteUri,
                Is.EqualTo("ws://localhost:8080/subscriptions/subscription/resourceGroups/resource%20group/sandboxGroups/group/sandboxes/sandbox/processes/stream?api-version=2026-09-01-preview"));
        }

        [Test]
        public void ConnectRequiresCredential()
        {
            SandboxGroupSandboxStreams client = CreateClient();

            Assert.ThrowsAsync<ArgumentNullException>(
                async () => await client.ConnectToSandboxProcessesStreamAsync(null));
        }

        [Test]
        public void CreatesBearerAuthorizationHeader()
        {
            Assert.That(
                SandboxGroupSandboxStreams.CreateAuthorizationHeaderValue("access-token"),
                Is.EqualTo(string.Concat("Bearer ", "access-token")));
        }

        private static SandboxGroupSandboxStreams CreateClient(Uri endpoint = null)
        {
            return new SandboxGroupSandboxStreams(
                clientDiagnostics: null,
                pipeline: null,
                endpoint ?? new Uri("https://example.test/base"),
                "2026-09-01-preview",
                "subscription",
                "resource group",
                "group",
                "sandbox");
        }
    }
}
