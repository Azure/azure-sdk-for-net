// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.IO;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Azure.Containers.Apps.Sandbox.Models;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.Containers.Apps.Sandbox.Tests
{
    [AsyncOnly]
    [LiveOnly(Reason = "The unbuffered HTTP log response must be read against the live service.")]
    public class SandboxLogStreamLiveTests : SandboxClientTestBase
    {
        public SandboxLogStreamLiveTests(bool isAsync)
            : base(isAsync)
        {
        }

        [RecordedTest]
        public async Task LogStreamReadsHistoricalLogs()
        {
            SandboxGroupClient sandboxGroup = CreateSandboxGroupClient();
            SandboxProperties sandbox = await CreateSandboxAsync(sandboxGroup);
            SandboxesClient client = sandboxGroup.GetSandboxesClient();
            using CancellationTokenSource timeout = new CancellationTokenSource(TimeSpan.FromMinutes(2));
            while (true)
            {
                SandboxProperties current = (await client.GetPropertiesAsync(sandbox.Id, timeout.Token)).Value;
                if (current.State == SandboxState.Running)
                {
                    break;
                }

                Assert.That(current.State, Is.Not.EqualTo(SandboxState.StopFailed), "Sandbox failed to start.");
                await Task.Delay(TimeSpan.FromSeconds(2), timeout.Token);
            }

            Response<Stream> response = await client.OpenSandboxLogStreamAsync(
                sandbox.Id, tailLines: 100, logFormat: SandboxLogFormat.Json, follow: false,
                cancellationToken: timeout.Token);
            using Stream stream = response.Value;
            Assert.That(response.GetRawResponse().Status, Is.EqualTo(200));
            Assert.That(stream, Is.Not.Null);
            Assert.That(stream.CanRead, Is.True);

            using (MemoryStream content = new MemoryStream())
            {
                await stream.CopyToAsync(content, 81920, timeout.Token);
                Assert.That(content.Length, Is.GreaterThan(0), "No historical logs were available for this sandbox.");
                string logs = Encoding.UTF8.GetString(content.ToArray());
                int entries = 0;
                foreach (string line in logs.Split('\n'))
                {
                    if (string.IsNullOrWhiteSpace(line))
                    {
                        continue;
                    }

                    using JsonDocument entry = JsonDocument.Parse(line);
                    Assert.That(entry.RootElement.ValueKind, Is.EqualTo(JsonValueKind.Object));
                    Assert.That(entry.RootElement.TryGetProperty("message", out _), Is.True);
                    entries++;
                }

                Assert.That(entries, Is.GreaterThan(0));
            }
        }
    }
}
