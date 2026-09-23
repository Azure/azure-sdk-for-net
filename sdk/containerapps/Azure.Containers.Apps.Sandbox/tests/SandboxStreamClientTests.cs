// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.Containers.Apps.Sandbox.Tests
{
    public class SandboxStreamClientTests
    {
        [Test]
        public async Task GetSandboxExecStreamBuildsExpectedRequest()
        {
            MockTransport transport = new MockTransport(new MockResponse(200));
            SandboxGroupSandboxStreams client = CreateClient(transport);

            Response response = await client.GetSandboxExecStreamAsync("worker", "sandbox-user");

            Assert.That(response.Status, Is.EqualTo(200));
            Assert.That(transport.Requests[0].Method, Is.EqualTo(RequestMethod.Get));
            Assert.That(transport.Requests[0].Uri.ToString(), Does.Contain("/sandboxes/sandbox-id/exec/stream?"));
            Assert.That(transport.Requests[0].Uri.Query, Does.Contain("containerName=worker"));
            Assert.That(transport.Requests[0].Uri.Query, Does.Contain("user=sandbox-user"));
        }

        [Test]
        public async Task GetSandboxProcessesStreamBuildsExpectedRequest()
        {
            MockTransport transport = new MockTransport(new MockResponse(200));
            SandboxGroupSandboxStreams client = CreateClient(transport);

            Response response = await client.GetSandboxProcessesStreamAsync("worker");

            Assert.That(response.Status, Is.EqualTo(200));
            Assert.That(transport.Requests[0].Uri.ToString(), Does.Contain("/sandboxes/sandbox-id/processes/stream?"));
            Assert.That(transport.Requests[0].Uri.Query, Does.Contain("containerName=worker"));
        }

        [Test]
        public async Task GetSandboxLogStreamSerializesOptionalParameters()
        {
            MockTransport transport = new MockTransport(new MockResponse(200));
            SandboxGroupSandboxStreams client = CreateClient(transport);

            Response response = await client.GetSandboxLogStreamAsync(
                tailLines: 100,
                logFormat: 1,
                follow: true,
                containerName: "worker");

            Assert.That(response.Status, Is.EqualTo(200));
            Assert.That(transport.Requests[0].Uri.ToString(), Does.Contain("/sandboxes/sandbox-id/logstream?"));
            Assert.That(transport.Requests[0].Uri.Query, Does.Contain("tailLines=100"));
            Assert.That(transport.Requests[0].Uri.Query, Does.Contain("logFormat=1"));
            Assert.That(transport.Requests[0].Uri.Query, Does.Contain("follow=true"));
            Assert.That(transport.Requests[0].Uri.Query, Does.Contain("containerName=worker"));
        }

        private static SandboxGroupSandboxStreams CreateClient(MockTransport transport) =>
            SandboxClientTestHelpers
                .CreateSandboxGroupClient(transport)
                .GetSandboxGroupSandboxClient("sandbox-id")
                .GetSandboxGroupSandboxStreamsClient();
    }
}
