// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.Containers.Apps.Sandbox.Tests
{
    public class SandboxConnectionClientTests
    {
        private const string ConnectionJson =
            """{"id":"connection-id","name":"github","type":"GitHub","state":"Ready"}""";

        [Test]
        public async Task CreateConnectionSendsExpectedRequest()
        {
            MockTransport transport = new MockTransport(
                SandboxClientTestHelpers.CreateJsonResponse(201, ConnectionJson));
            SandboxGroupConnections client = CreateClient(transport);
            CreateConnectionContent content = new CreateConnectionContent("github", "GitHub")
            {
                ParameterValueSetName = "oauth"
            };
            content.Labels.Add("environment", "test");
            content.ParameterValueSetValues.Add("organization", "azure");

            Response<SandboxConnection> response = await client.CreateConnectionAsync(content);

            Assert.That(response.Value.Id, Is.EqualTo("connection-id"));
            Assert.That(transport.Requests[0].Method, Is.EqualTo(RequestMethod.Post));
            Assert.That(transport.Requests[0].Uri.ToString(), Does.EndWith(
                "/subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/test-rg/sandboxGroups/test-group/connections?api-version=2026-09-01-preview"));
            string requestContent = SandboxClientTestHelpers.ReadContent(transport.Requests[0]);
            Assert.That(requestContent, Does.Contain("\"name\":\"github\""));
            Assert.That(requestContent, Does.Contain("\"parameterValueSetName\":\"oauth\""));
            Assert.That(requestContent, Does.Contain("\"organization\":\"azure\""));
        }

        [Test]
        public async Task GetConnectionIncludesSandboxIdsWhenRequested()
        {
            MockTransport transport = new MockTransport(
                SandboxClientTestHelpers.CreateJsonResponse(200,
                    """{"id":"connection-id","name":"github","type":"GitHub","state":"Ready","usedBySandboxIds":["sandbox-id"]}"""));
            SandboxGroupConnections client = CreateClient(transport);

            Response<SandboxConnection> response = await client.GetConnectionAsync("connection-id", includeSandboxIds: true);

            Assert.That(response.Value.UsedBySandboxIds, Does.Contain("sandbox-id"));
            Assert.That(transport.Requests[0].Uri.Query, Does.Contain("includeSandboxIds=true"));
        }

        [Test]
        public async Task ListConnectionsHandlesFiltersAndContinuation()
        {
            string nextLink =
                $"{SandboxClientTestHelpers.Endpoint}/subscriptions/{SandboxClientTestHelpers.SubscriptionId}" +
                $"/resourceGroups/{SandboxClientTestHelpers.ResourceGroupName}/sandboxGroups/{SandboxClientTestHelpers.SandboxGroupName}" +
                "/connections?skipToken=page-2";
            MockTransport transport = new MockTransport(
                SandboxClientTestHelpers.CreateJsonResponse(200,
                    $$"""{"value":[{{ConnectionJson}}],"nextLink":"{{nextLink}}"}"""),
                SandboxClientTestHelpers.CreateJsonResponse(200,
                    """{"value":[{"id":"connection-2","name":"ado","type":"AzureDevOps","state":"Ready"}]}"""));
            SandboxGroupConnections client = CreateClient(transport);
            List<string> ids = new List<string>();

            await foreach (Page<SandboxConnection> page in client
                .GetConnectionsAsync(includeSandboxIds: true, labels: "environment=test", skipToken: "page-1")
                .AsPages())
            {
                foreach (SandboxConnection connection in page.Values)
                {
                    ids.Add(connection.Id);
                }
            }

            Assert.That(ids, Is.EqualTo(new[] { "connection-id", "connection-2" }));
            Assert.That(transport.Requests, Has.Count.EqualTo(2));
            Assert.That(transport.Requests[0].Uri.Query, Does.Contain("includeSandboxIds=true"));
            Assert.That(transport.Requests[0].Uri.Query, Does.Contain("labels=environment%3Dtest"));
            Assert.That(transport.Requests[0].Uri.Query, Does.Contain("skipToken=page-1"));
            Assert.That(transport.Requests[1].Uri.Query, Does.Contain("skipToken=page-2"));
            Assert.That(transport.Requests[1].Uri.Query, Does.Contain("api-version=2026-09-01-preview"));
        }

        [Test]
        public async Task DeleteConnectionSendsForceQueryParameter()
        {
            MockTransport transport = new MockTransport(new MockResponse(204));
            SandboxGroupConnections client = CreateClient(transport);

            Response response = await client.DeleteConnectionAsync("connection-id", force: true);

            Assert.That(response.Status, Is.EqualTo(204));
            Assert.That(transport.Requests[0].Method, Is.EqualTo(RequestMethod.Delete));
            Assert.That(transport.Requests[0].Uri.Query, Does.Contain("force=true"));
        }

        [Test]
        public async Task AuthorizeConnectionSerializesContent()
        {
            MockTransport transport = new MockTransport(
                SandboxClientTestHelpers.CreateJsonResponse(200, ConnectionJson));
            SandboxGroupConnections client = CreateClient(transport);
            AuthorizeConnectionContent content = new AuthorizeConnectionContent(
                new Dictionary<string, string> { ["authorizationCode"] = "code" });

            Response<SandboxConnection> response = await client.AuthorizeConnectionAsync("connection-id", content);

            Assert.That(response.Value.State.ToString(), Is.EqualTo("Ready"));
            Assert.That(transport.Requests[0].Uri.ToString(), Does.Contain("/connections/connection-id/authorize?"));
            Assert.That(SandboxClientTestHelpers.ReadContent(transport.Requests[0]),
                Does.Contain("\"authorizationCode\":\"code\""));
        }

        [Test]
        public async Task GenerateConnectionConsentLinkDeserializesResult()
        {
            MockTransport transport = new MockTransport(
                SandboxClientTestHelpers.CreateJsonResponse(200,
                    """{"consentLink":"https://login.example.com/consent"}"""));
            SandboxGroupConnections client = CreateClient(transport);
            GenerateConsentLinkContent content = new GenerateConsentLinkContent
            {
                RedirectUri = new Uri("https://localhost/callback")
            };

            Response<GenerateConsentLinkResult> response =
                await client.GenerateConnectionConsentLinkAsync("connection-id", content);

            Assert.That(response.Value.ConsentLink.AbsoluteUri, Is.EqualTo("https://login.example.com/consent"));
            Assert.That(transport.Requests[0].Uri.ToString(), Does.Contain("/connections/connection-id/consentLink?"));
            Assert.That(SandboxClientTestHelpers.ReadContent(transport.Requests[0]),
                Does.Contain("\"redirectUrl\":\"https://localhost/callback\""));
        }

        [Test]
        public async Task RefreshConnectionIncludesSandboxIdsWhenRequested()
        {
            MockTransport transport = new MockTransport(
                SandboxClientTestHelpers.CreateJsonResponse(200, ConnectionJson));
            SandboxGroupConnections client = CreateClient(transport);

            Response<SandboxConnection> response =
                await client.RefreshConnectionAsync("connection-id", includeSandboxIds: true);

            Assert.That(response.Value.Id, Is.EqualTo("connection-id"));
            Assert.That(transport.Requests[0].Method, Is.EqualTo(RequestMethod.Post));
            Assert.That(transport.Requests[0].Uri.ToString(), Does.Contain("/connections/connection-id/refresh?"));
            Assert.That(transport.Requests[0].Uri.Query, Does.Contain("includeSandboxIds=true"));
        }

        [Test]
        public async Task UpdateConnectionPolicyRulesSerializesRules()
        {
            MockTransport transport = new MockTransport(
                SandboxClientTestHelpers.CreateJsonResponse(200, ConnectionJson));
            SandboxGroupConnections client = CreateClient(transport);
            UpdatePolicyRulesContent content = new UpdatePolicyRulesContent(
                new[] { new McpPolicyRule("block-mail", new[] { "*@example.com" }) });
            content.EnabledToolGroups.Add("mail");

            Response<SandboxConnection> response =
                await client.UpdateConnectionPolicyRulesAsync("connection-id", content);

            Assert.That(response.Value.Id, Is.EqualTo("connection-id"));
            Assert.That(transport.Requests[0].Method, Is.EqualTo(RequestMethod.Put));
            string requestContent = SandboxClientTestHelpers.ReadContent(transport.Requests[0]);
            Assert.That(requestContent, Does.Contain("\"hookId\":\"block-mail\""));
            Assert.That(requestContent, Does.Contain("\"enabledToolGroups\":[\"mail\"]"));
        }

        [Test]
        public async Task AddConnectionToSandboxSerializesConnectionId()
        {
            MockTransport transport = new MockTransport(
                SandboxClientTestHelpers.CreateJsonResponse(200,
                    """{"connectionIds":["connection-id"]}"""));
            SandboxGroupSandboxNetworking client = SandboxClientTestHelpers
                .CreateSandboxGroupClient(transport)
                .GetSandboxGroupSandboxClient("sandbox-id")
                .GetSandboxGroupSandboxNetworkingClient();

            Response<ConnectionsListResult> response =
                await client.AddConnectionAsync(new AddConnectionContent("connection-id"));

            Assert.That(response.Value.ConnectionIds, Does.Contain("connection-id"));
            Assert.That(transport.Requests[0].Uri.ToString(), Does.Contain("/sandboxes/sandbox-id/connections/add?"));
            Assert.That(SandboxClientTestHelpers.ReadContent(transport.Requests[0]),
                Does.Contain("\"connectionId\":\"connection-id\""));
        }

        private static SandboxGroupConnections CreateClient(MockTransport transport) =>
            SandboxClientTestHelpers.CreateSandboxGroupClient(transport).GetSandboxGroupConnectionsClient();
    }
}
