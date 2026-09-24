// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.Containers.Apps.Sandbox.Tests
{
    public class SandboxClientTests
    {
        [Test]
        public async Task CreateAndDeleteSandboxSendsExpectedRequests()
        {
            MockResponse createResponse = new MockResponse(201);
            createResponse.SetContent(
                """
                {
                  "id": "sandbox-id",
                  "sourcesRef": {
                    "diskImage": {
                      "name": "ubuntu",
                      "isPublic": true
                    }
                  },
                  "resources": {
                    "cpu": "1",
                    "memory": "2Gi",
                    "disk": "20Gi"
                  },
                  "state": "Running"
                }
                """);
            MockResponse deleteResponse = new MockResponse(204);
            MockTransport transport = new MockTransport(createResponse, deleteResponse);
            ContainerAppsSandboxClientOptions options = new ContainerAppsSandboxClientOptions
            {
                Transport = transport
            };
            ContainerAppsSandboxClient client = new ContainerAppsSandboxClient(
                new Uri("https://management.eastus2.azuredevcompute.io"),
                new MockCredential(),
                options);
            SandboxGroup sandboxGroup = client.GetSandboxGroupClient(
                "00000000-0000-0000-0000-000000000000",
                "test-rg",
                "test-group");

            Response<ContainerAppsSandbox> created = await sandboxGroup.CreateSandboxAsync(
                SandboxClientTestBase.CreateSandboxContent("unit-test"));
            Response deleted = await sandboxGroup
                .GetSandboxGroupSandboxClient(created.Value.Id)
                .DeleteAsync();

            Assert.That(created.Value.Id, Is.EqualTo("sandbox-id"));
            Assert.That(deleted.Status, Is.EqualTo(204));
            Assert.That(transport.Requests, Has.Count.EqualTo(2));

            MockRequest createRequest = transport.Requests[0];
            Assert.That(createRequest.Method, Is.EqualTo(RequestMethod.Post));
            Assert.That(
                createRequest.Uri.ToString(),
                Is.EqualTo("https://management.eastus2.azuredevcompute.io/subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/test-rg/sandboxGroups/test-group/sandboxes?api-version=2026-09-01-preview"));
            Assert.That(ReadContent(createRequest), Does.Contain("\"name\":\"ubuntu\""));
            Assert.That(ReadContent(createRequest), Does.Contain("\"test-id\":\"unit-test\""));

            MockRequest deleteRequest = transport.Requests[1];
            Assert.That(deleteRequest.Method, Is.EqualTo(RequestMethod.Delete));
            Assert.That(
                deleteRequest.Uri.ToString(),
                Is.EqualTo("https://management.eastus2.azuredevcompute.io/subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/test-rg/sandboxGroups/test-group/sandboxes/sandbox-id?api-version=2026-09-01-preview"));
        }

        [Test]
        public async Task CreateSandboxSerializesMaximumSelfContainedSettings()
        {
            MockResponse response = new MockResponse(201);
            response.SetContent(
                """
                {
                  "id": "sandbox-id",
                  "labels": {
                    "test-id": "maximum-set"
                  },
                  "entrypoint": ["/bin/sh"],
                  "cmd": ["-c", "echo sandbox"],
                  "environment": {
                    "SANDBOX_TEST": "true"
                  },
                  "sourcesRef": {
                    "diskImage": {
                      "name": "ubuntu",
                      "isPublic": true
                    }
                  },
                  "resources": {
                    "cpu": "1000m",
                    "memory": "2048Mi"
                  },
                  "state": "Running"
                }
                """);
            MockTransport transport = new MockTransport(response);
            ContainerAppsSandboxClientOptions options = new ContainerAppsSandboxClientOptions
            {
                Transport = transport
            };
            ContainerAppsSandboxClient client = new ContainerAppsSandboxClient(
                new Uri("https://management.eastus2.azuredevcompute.io"),
                new MockCredential(),
                options);
            SandboxGroup sandboxGroup = client.GetSandboxGroupClient(
                "00000000-0000-0000-0000-000000000000",
                "test-rg",
                "test-group");
            CreateSandboxContent content = SandboxClientTestBase.CreateSandboxContent("maximum-set");
            content.Entrypoint.Add("/bin/sh");
            content.Command.Add("-c");
            content.Command.Add("echo sandbox");
            content.Environment.Add("SANDBOX_TEST", "true");
            content.Ports.Add(new CreateSandboxPortContent(8080) { Name = "http" });
            content.EgressPolicy = new SandboxEgressPolicy
            {
                DefaultAction = EgressPolicyAction.Allow
            };
            content.Lifecycle = new SandboxLifecyclePolicy(
                new SandboxAutoSuspendPolicy(false),
                new SandboxAutoDeletePolicy(false));

            Response<ContainerAppsSandbox> result = await sandboxGroup.CreateSandboxAsync(content);
            string requestContent = ReadContent(transport.Requests[0]);

            Assert.That(result.Value.Id, Is.EqualTo("sandbox-id"));
            Assert.That(requestContent, Does.Contain("\"entrypoint\":[\"/bin/sh\"]"));
            Assert.That(requestContent, Does.Contain("\"cmd\":[\"-c\",\"echo sandbox\"]"));
            Assert.That(requestContent, Does.Contain("\"SANDBOX_TEST\":\"true\""));
            Assert.That(requestContent, Does.Contain("\"port\":8080"));
            Assert.That(requestContent, Does.Contain("\"defaultAction\":\"Allow\""));
            Assert.That(requestContent, Does.Contain("\"autoSuspendPolicy\""));
        }

        private static string ReadContent(MockRequest request)
        {
            using MemoryStream stream = new MemoryStream();
            request.Content.WriteTo(stream, CancellationToken.None);
            return BinaryData.FromBytes(stream.ToArray()).ToString();
        }
    }
}
