// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Azure.Containers.Apps.Sandbox.Models;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.Containers.Apps.Sandbox.Tests
{
    [AsyncOnly]
    [LiveOnly(Reason = "WebSocket frames cannot be recorded by the HTTP test transport.")]
    public class SandboxWebSocketLiveTests : SandboxClientTestBase
    {
        public SandboxWebSocketLiveTests(bool isAsync)
            : base(isAsync)
        {
        }

        [RecordedTest]
        public async Task ExecSessionReceivesOutputAndExitCode()
        {
            SandboxGroupClient sandboxGroup = CreateSandboxGroupClient();
            SandboxProperties sandbox = await CreateSandboxAsync(sandboxGroup);
            SandboxesClient client = sandboxGroup.GetSandboxesClient();
            using CancellationTokenSource timeout = new CancellationTokenSource(TimeSpan.FromMinutes(2));
            await WaitUntilRunningAsync(client, sandbox.Id, timeout.Token);

            SandboxExecStartRequest request = new SandboxExecStartRequest("/bin/sh")
            {
                AllocateTerminal = false,
                EnableStandardInput = false
            };
            request.Arguments.Add("-c");
            request.Arguments.Add("echo sdk-ws-ok");

            await using SandboxExecSession session = await client.StartSandboxExecSessionAsync(
                sandbox.Id, request, cancellationToken: timeout.Token);
            SandboxExecEvent started = await session.ReceiveAsync(timeout.Token);
            Assert.That(started.Type, Is.EqualTo(SandboxExecEventType.SessionId));

            StringBuilder stdout = new StringBuilder();
            StringBuilder events = new StringBuilder("SessionId, ");
            int? exitCode = null;
            while (true)
            {
                SandboxExecEvent next = await session.ReceiveAsync(timeout.Token);
                events.Append(next.Type).Append(", ");
                switch (next.Type)
                {
                    case SandboxExecEventType.StandardOutput:
                        stdout.Append(next.Data.ToString());
                        break;
                    case SandboxExecEventType.StandardError:
                    case SandboxExecEventType.Error:
                        Assert.Fail($"Exec failed: {next.Text ?? next.Data?.ToString()}");
                        break;
                    case SandboxExecEventType.ExitCode:
                        exitCode = next.ExitCode;
                        break;
                    case SandboxExecEventType.Closed:
                        Assert.Fail($"Exec WebSocket closed before output and exit code. Events: {events}. Close reason: {next.Text}");
                        break;
                }

                if (exitCode.HasValue && stdout.ToString().Contains("sdk-ws-ok"))
                {
                    Assert.That(exitCode.Value, Is.Zero);
                    return;
                }
            }
        }

        [RecordedTest]
        public async Task ExecSessionRoundTripsStdinAndStdout()
        {
            SandboxGroupClient sandboxGroup = CreateSandboxGroupClient();
            SandboxProperties sandbox = await CreateSandboxAsync(sandboxGroup);
            SandboxesClient client = sandboxGroup.GetSandboxesClient();
            using CancellationTokenSource timeout = new CancellationTokenSource(TimeSpan.FromMinutes(2));
            await WaitUntilRunningAsync(client, sandbox.Id, timeout.Token);

            string content = $"sdk-ws-stdin-{Guid.NewGuid():N}\n";
            string path = $"/tmp/sdk-ws-stdin-{Guid.NewGuid():N}.txt";
            // TTY forwards stdin; a fixed byte count lets the process exit without terminal EOF.
            SandboxExecStartRequest write = new SandboxExecStartRequest("/bin/sh") { AllocateTerminal = true, EnableStandardInput = true };
            write.Arguments.Add("-c");
            write.Arguments.Add($"head -c {Encoding.UTF8.GetByteCount(content)} > '{path}'");

            using CancellationTokenSource streamTimeout = CancellationTokenSource.CreateLinkedTokenSource(timeout.Token);
            streamTimeout.CancelAfter(TimeSpan.FromSeconds(75));
            await using (SandboxExecSession session = await client.StartSandboxExecSessionAsync(
                sandbox.Id, write, cancellationToken: streamTimeout.Token))
            {
                Assert.That((await session.ReceiveAsync(streamTimeout.Token)).Type, Is.EqualTo(SandboxExecEventType.SessionId));
                await session.SendInputAsync(BinaryData.FromString(content), streamTimeout.Token);
                Assert.That((await ReadUntilExitAsync(session, streamTimeout.Token)).ExitCode, Is.Zero);
            }

            SandboxExecStartRequest read = new SandboxExecStartRequest("/bin/cat") { AllocateTerminal = false, EnableStandardInput = false };
            read.Arguments.Add(path);
            await using (SandboxExecSession session = await client.StartSandboxExecSessionAsync(
                sandbox.Id, read, cancellationToken: streamTimeout.Token))
            {
                Assert.That((await session.ReceiveAsync(streamTimeout.Token)).Type, Is.EqualTo(SandboxExecEventType.SessionId));
                (string stdout, int exitCode) = await ReadUntilExitAsync(session, streamTimeout.Token);
                Assert.That(exitCode, Is.Zero);
                Assert.That(stdout, Is.EqualTo(content));
            }
        }

        [RecordedTest]
        public async Task ProcessStreamReceivesSnapshot()
        {
            SandboxGroupClient sandboxGroup = CreateSandboxGroupClient();
            SandboxProperties sandbox = await CreateSandboxAsync(sandboxGroup);
            SandboxesClient client = sandboxGroup.GetSandboxesClient();
            using CancellationTokenSource timeout = new CancellationTokenSource(TimeSpan.FromMinutes(2));
            await WaitUntilRunningAsync(client, sandbox.Id, timeout.Token);

            await using SandboxProcessStream stream = await client.OpenSandboxProcessStreamAsync(
                sandbox.Id, cancellationToken: timeout.Token);
            string snapshot = await stream.ReadSnapshotAsync(timeout.Token);

            Assert.That(snapshot, Is.Not.Null.And.Not.Empty);
        }

        private static async Task<(string StandardOutput, int ExitCode)> ReadUntilExitAsync(
            SandboxExecSession session, CancellationToken cancellationToken)
        {
            StringBuilder stdout = new StringBuilder();
            while (true)
            {
                SandboxExecEvent next = await session.ReceiveAsync(cancellationToken);
                switch (next.Type)
                {
                    case SandboxExecEventType.StandardOutput:
                        stdout.Append(next.Data.ToString());
                        break;
                    case SandboxExecEventType.StandardError:
                    case SandboxExecEventType.Error:
                        Assert.Fail($"Exec failed: {next.Text ?? next.Data?.ToString()}");
                        break;
                    case SandboxExecEventType.ExitCode:
                        Assert.That(next.ExitCode, Is.Not.Null);
                        return (stdout.ToString(), next.ExitCode.Value);
                    case SandboxExecEventType.Closed:
                        Assert.Fail($"Exec WebSocket closed before an exit code. Close reason: {next.Text}");
                        break;
                }
            }
        }

        private static async Task WaitUntilRunningAsync(SandboxesClient client, string sandboxId, CancellationToken cancellationToken)
        {
            while (true)
            {
                SandboxProperties sandbox = (await client.GetPropertiesAsync(sandboxId, cancellationToken)).Value;
                if (sandbox.State == SandboxState.Running)
                {
                    return;
                }

                Assert.That(sandbox.State, Is.Not.EqualTo(SandboxState.StopFailed), "Sandbox failed to start.");
                await Task.Delay(TimeSpan.FromSeconds(2), cancellationToken);
            }
        }
    }
}
