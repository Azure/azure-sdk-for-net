// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Microsoft.Extensions.Configuration;
using NUnit.Framework;

namespace Azure.Containers.Apps.Sandbox.Tests
{
    public class SandboxStreamClientTests
    {
        [Test]
        public async Task ExecConnectionUsesGeneratedUriAndCredential()
        {
            SandboxesClient client = CreateClient(out MockCredential credential);
            Uri uri = null;
            string authorization = null;
            string[] scopes = null;
            credential.GetTokenCallback = (context, _) => scopes = context.Scopes;
            client.WebSocketConnector = (address, header, _) =>
            {
                uri = address;
                authorization = header;
                return Task.FromResult<ISandboxWebSocketClient>(new TestSocket());
            };

            await using SandboxStream stream = await client.ConnectToSandboxExecStreamAsync("sandbox/id", "worker 1", "sandbox-user");

            Assert.That(uri.Scheme, Is.EqualTo("wss"));
            Assert.That(uri.AbsolutePath, Does.EndWith("/sandboxGroups/test-group/sandboxes/sandbox%2Fid/exec/stream"));
            Assert.That(uri.Query, Does.Contain("api-version=2026-09-01-preview"));
            Assert.That(uri.Query, Does.Contain("containerName=worker%201"));
            Assert.That(uri.Query, Does.Contain("user=sandbox-user"));
            Assert.That(scopes, Is.EqualTo(new[] { "https://management.azuredevcompute.io/.default" }));
            Assert.That(authorization, Does.StartWith("Bearer TEST TOKEN "));
        }

        [Test]
        public async Task LogStreamUsesUnbufferedHttpAndStringFormat()
        {
            MockResponse expected = new MockResponse(200).SetContent("{\"timestamp\":\"now\",\"stream\":\"stdout\",\"message\":\"hello\"}\n");
            MockTransport transport = MockTransport.FromMessageCallback(message =>
            {
                Assert.That(message.BufferResponse, Is.False);
                return expected;
            });
            SandboxesClient client = CreateClient(out _, transport);
            client.WebSocketConnector = (_, _, _) => throw new AssertionException("Logstream must not connect via WebSocket.");

            Response<Stream> response = await client.OpenSandboxLogStreamAsync(
                "sandbox-id", tailLines: 25, logFormat: SandboxLogFormat.Json, follow: true, containerName: "worker");

            Uri uri = transport.SingleRequest.Uri.ToUri();
            Assert.That(uri.AbsolutePath, Does.EndWith("/sandboxes/sandbox-id/logstream"));
            Assert.That(uri.Query, Does.Contain("tailLines=25"));
            Assert.That(uri.Query, Does.Contain("logFormat=json"));
            Assert.That(uri.Query, Does.Contain("follow=true"));
            Assert.That(uri.Query, Does.Contain("containerName=worker"));
            using StreamReader reader = new StreamReader(response.Value);
            Assert.That(await reader.ReadLineAsync(), Does.Contain("\"message\":\"hello\""));
        }

        [Test]
        public void LogStreamRejectsInvalidTailLines()
        {
            SandboxesClient client = CreateClient(out _);
            Assert.ThrowsAsync<ArgumentOutOfRangeException>(async () =>
                await client.OpenSandboxLogStreamAsync("sandbox-id", tailLines: 301));
        }

        [Test]
        public void LogStreamSurfacesHttpErrors()
        {
            SandboxesClient client = CreateClient(out _, new MockTransport(new MockResponse(409)));
            Assert.ThrowsAsync<RequestFailedException>(async () =>
                await client.OpenSandboxLogStreamAsync("sandbox-id"));
        }

        [Test]
        public async Task ExecSessionSendsStartAndDecodesFrames()
        {
            SandboxesClient client = CreateClient(out _);
            TestSocket socket = new TestSocket();
            Uri uri = null;
            client.WebSocketConnector = (address, _, _) =>
            {
                uri = address;
                return Task.FromResult<ISandboxWebSocketClient>(socket);
            };
            var request = new Models.SandboxExecStartRequest("/bin/sh") { User = "sandbox-user", WorkingDirectory = "/work" };
            request.Arguments.Add("-i");
            request.Environment["TERM"] = "xterm";
            await using SandboxExecSession session = await client.StartSandboxExecSessionAsync("sandbox-id", request);
            using (JsonDocument json = JsonDocument.Parse(socket.Sent[0]))
            {
                Assert.That(json.RootElement.GetProperty("type").GetString(), Is.EqualTo("start"));
                JsonElement start = json.RootElement.GetProperty("start");
                Assert.That(start.GetProperty("command").GetString(), Is.EqualTo("/bin/sh"));
                Assert.That(start.GetProperty("args")[0].GetString(), Is.EqualTo("-i"));
                Assert.That(start.GetProperty("environment").GetProperty("TERM").GetString(), Is.EqualTo("xterm"));
                Assert.That(start.GetProperty("workingDirectory").GetString(), Is.EqualTo("/work"));
                Assert.That(start.GetProperty("user").GetString(), Is.EqualTo("sandbox-user"));
                Assert.That(start.GetProperty("tty").GetBoolean(), Is.True);
                Assert.That(start.GetProperty("stdin").GetBoolean(), Is.True);
                Assert.That(start.GetProperty("height").GetUInt32(), Is.EqualTo(24));
                Assert.That(start.GetProperty("width").GetUInt32(), Is.EqualTo(80));
                Assert.That(start.GetProperty("detach").GetBoolean(), Is.False);
            }
            Assert.That(uri.Query, Does.Not.Contain("user="));

            await session.SendInputAsync(BinaryData.FromBytes(new byte[] { 0, 255 }));
            await session.ResizeAsync(40, 80);
            await session.CloseInputAsync();
            Assert.That(socket.Sent[1], Does.Contain("\"data\":\"AP8=\""));
            Assert.That(socket.Sent[2], Does.Contain("\"height\":40"));
            Assert.That(socket.Sent[3], Does.Contain("\"close_stdin\""));

            socket.Enqueue("{\"type\":\"session_id\",\"data\":\"abc\"}");
            socket.Enqueue("{\"type\":\"stdout\",\"data\":\"AP8=\"}");
            socket.Enqueue("{\"type\":\"stderr\",\"data\":\"aGk=\"}");
            socket.Enqueue("{\"type\":\"exit_code\",\"exitCode\":0}");
            socket.Enqueue("{\"type\":\"error\",\"data\":\"failed\"}");
            Assert.That((await session.ReceiveAsync()).Text, Is.EqualTo("abc"));
            Assert.That((await session.ReceiveAsync()).Data.ToArray(), Is.EqualTo(new byte[] { 0, 255 }));
            Assert.That((await session.ReceiveAsync()).Type, Is.EqualTo(SandboxExecEventType.Stderr));
            Assert.That((await session.ReceiveAsync()).ExitCode, Is.EqualTo(0));
            Assert.That((await session.ReceiveAsync()).Text, Is.EqualTo("failed"));
            Assert.That((await session.ReceiveAsync()).Type, Is.EqualTo(SandboxExecEventType.Closed));
        }

        [Test]
        public async Task ExecSessionSerializesNonDefaultStartRequest()
        {
            SandboxesClient client = CreateClient(out _);
            TestSocket socket = new TestSocket();
            client.WebSocketConnector = (_, _, _) => Task.FromResult<ISandboxWebSocketClient>(socket);
            var request = new Models.SandboxExecStartRequest("sh")
            {
                Tty = false,
                Stdin = false,
                Height = 40,
                Width = 120,
                Detach = true
            };
            await using SandboxExecSession session = await client.StartSandboxExecSessionAsync("sandbox-id", request);

            using JsonDocument json = JsonDocument.Parse(socket.Sent[0]);
            JsonElement start = json.RootElement.GetProperty("start");
            Assert.That(start.GetProperty("args").GetArrayLength(), Is.Zero);
            Assert.That(start.GetProperty("environment").EnumerateObject().MoveNext(), Is.False);
            Assert.That(start.TryGetProperty("workingDirectory", out _), Is.False);
            Assert.That(start.TryGetProperty("user", out _), Is.False);
            Assert.That(start.GetProperty("tty").GetBoolean(), Is.False);
            Assert.That(start.GetProperty("stdin").GetBoolean(), Is.False);
            Assert.That(start.GetProperty("height").GetUInt32(), Is.EqualTo(40));
            Assert.That(start.GetProperty("width").GetUInt32(), Is.EqualTo(120));
            Assert.That(start.GetProperty("detach").GetBoolean(), Is.True);
        }

        [Test]
        public void ExecSessionRejectsInvalidStartRequest()
        {
            Assert.Throws<ArgumentNullException>(() => new Models.SandboxExecStartRequest(null));
            Assert.Throws<ArgumentException>(() => new Models.SandboxExecStartRequest(""));
            SandboxesClient client = CreateClient(out _);
            Assert.ThrowsAsync<ArgumentNullException>(async () =>
                await client.StartSandboxExecSessionAsync("sandbox-id", null));
        }

        [Test]
        public void OversizedExecStartDoesNotSendAndReleasesConnection()
        {
            SandboxesClient client = CreateClient(out _);
            TestSocket socket = new TestSocket();
            client.WebSocketConnector = (_, _, _) => Task.FromResult<ISandboxWebSocketClient>(socket);
            var request = new Models.SandboxExecStartRequest("sh");
            request.Environment["BIG"] = new string('x', 1_048_576);

            Assert.ThrowsAsync<ArgumentException>(async () =>
                await client.StartSandboxExecSessionAsync("sandbox-id", request));
            Assert.That(socket.Sent, Is.Empty);
            Assert.That(socket.WasDisposed, Is.True);
        }

        [Test]
        public void FailedExecStartReleasesConnection()
        {
            SandboxesClient client = CreateClient(out _);
            TestSocket socket = new TestSocket { FailSend = true };
            client.WebSocketConnector = (_, _, _) => Task.FromResult<ISandboxWebSocketClient>(socket);
            Assert.ThrowsAsync<IOException>(async () =>
                await client.StartSandboxExecSessionAsync("sandbox-id", new Models.SandboxExecStartRequest("sh")));
            Assert.That(socket.WasDisposed, Is.True);
        }

        [Test]
        public async Task InvalidExecFrameFailsExplicitly()
        {
            TestSocket socket = new TestSocket();
            socket.Enqueue("{\"type\":\"stdout\",\"data\":\"!\"}");
            await using SandboxExecSession session = new SandboxExecSession(new SandboxStream(socket));
            Assert.ThrowsAsync<InvalidDataException>(async () => await session.ReceiveAsync());
        }

        [Test]
        public async Task LargeExecInputIsSplitIntoServiceSizedFrames()
        {
            TestSocket socket = new TestSocket();
            await using SandboxExecSession session = new SandboxExecSession(new SandboxStream(socket));
            byte[] input = new byte[20_000];
            await session.SendInputAsync(BinaryData.FromBytes(input));
            Assert.That(socket.Sent.Count, Is.EqualTo(3));
            foreach (string frame in socket.Sent)
            {
                Assert.That(frame.Length, Is.LessThan(16_384));
                using JsonDocument json = JsonDocument.Parse(frame);
                Assert.That(json.RootElement.GetProperty("type").GetString(), Is.EqualTo("stdin"));
            }
        }

        [Test]
        public async Task ProcessStreamReturnsTextSnapshots()
        {
            SandboxesClient client = CreateClient(out _);
            TestSocket socket = new TestSocket();
            socket.Enqueue("top - 15:00\n PID USER");
            client.WebSocketConnector = (_, _, _) => Task.FromResult<ISandboxWebSocketClient>(socket);
            await using SandboxProcessStream stream = await client.OpenSandboxProcessStreamAsync("sandbox-id");
            Assert.That(await stream.ReadSnapshotAsync(), Does.StartWith("top - "));
            Assert.That(await stream.ReadSnapshotAsync(), Is.Null);
        }

        [Test]
        public async Task ProcessConnectionOmitsOptionalQuery()
        {
            SandboxesClient client = CreateClient(out _);
            Uri uri = null;
            client.WebSocketConnector = (address, _, _) =>
            {
                uri = address;
                return Task.FromResult<ISandboxWebSocketClient>(new TestSocket());
            };

            await using SandboxStream stream = await client.ConnectToSandboxProcessesStreamAsync("sandbox-id");

            Assert.That(uri.AbsolutePath, Does.EndWith("/sandboxes/sandbox-id/processes/stream"));
            Assert.That(uri.Query, Is.EqualTo("?api-version=2026-09-01-preview"));
        }

        [Test]
        public void TokenFailureDoesNotOpenConnection()
        {
            SandboxesClient client = CreateClient(out _);
            Assert.ThrowsAsync<ArgumentException>(async () =>
                await client.ConnectToSandboxExecStreamAsync(""));
        }

#pragma warning disable SCME0002 // Verify the settings constructor retains WebSocket credentials.
        [Test]
        public async Task SettingsConstructorRetainsWebSocketCredential()
        {
            MockCredential credential = new MockCredential();
            SandboxGroupClientSettings settings = new SandboxGroupClientSettings
            {
                Endpoint = new Uri(SandboxClientTestHelpers.Endpoint),
                SubscriptionId = SandboxClientTestHelpers.SubscriptionId,
                ResourceGroupName = SandboxClientTestHelpers.ResourceGroupName,
                SandboxGroupName = SandboxClientTestHelpers.SandboxGroupName,
                Options = new SandboxGroupClientOptions { Transport = new MockTransport(new MockResponse(200)) }
            };
            settings.Bind(new ConfigurationBuilder().Build().GetSection("SandboxGroupClient"));
            settings.CredentialProvider = credential;
            SandboxGroupClient group = new SandboxGroupClient(settings);
            SandboxesClient client = group.GetSandboxesClient();
            string authorization = null;
            client.WebSocketConnector = (_, header, _) =>
            {
                authorization = header;
                return Task.FromResult<ISandboxWebSocketClient>(new TestSocket());
            };

            await using SandboxStream stream = await client.ConnectToSandboxProcessesStreamAsync("sandbox-id");
            Assert.That(authorization, Does.Contain("https://management.azuredevcompute.io/.default"));
        }
#pragma warning restore SCME0002

        private static SandboxesClient CreateClient(out MockCredential credential, MockTransport transport = null)
        {
            credential = new MockCredential();
            SandboxGroupClient group = new SandboxGroupClient(
                new Uri(SandboxClientTestHelpers.Endpoint),
                SandboxClientTestHelpers.SubscriptionId,
                SandboxClientTestHelpers.ResourceGroupName,
                SandboxClientTestHelpers.SandboxGroupName,
                credential,
                new SandboxGroupClientOptions { Transport = transport ?? new MockTransport(new MockResponse(200)) });
            return group.GetSandboxesClient();
        }

        private sealed class TestSocket : ISandboxWebSocketClient
        {
            private readonly Queue<SandboxStreamMessage> _received = new Queue<SandboxStreamMessage>();
            public List<string> Sent { get; } = new List<string>();
            public bool FailSend { get; set; }
            public bool WasDisposed { get; private set; }
            public void Enqueue(string text) => _received.Enqueue(new SandboxStreamMessage(SandboxStreamMessageType.Text, BinaryData.FromString(text)));
            public Task SendAsync(BinaryData data, SandboxStreamMessageType type, CancellationToken cancellationToken)
            {
                if (FailSend) throw new IOException("Simulated start send failure.");
                Sent.Add(data.ToString());
                return Task.CompletedTask;
            }
            public Task<SandboxStreamMessage> ReceiveAsync(CancellationToken cancellationToken) =>
                Task.FromResult(_received.Count > 0 ? _received.Dequeue() : new SandboxStreamMessage(SandboxStreamMessageType.Close, null));
            public void Dispose() => WasDisposed = true;
            public ValueTask DisposeAsync()
            {
                WasDisposed = true;
                return default;
            }
        }
    }
}
