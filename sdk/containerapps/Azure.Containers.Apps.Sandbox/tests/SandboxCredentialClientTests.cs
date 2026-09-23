// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.Containers.Apps.Sandbox.Tests
{
    public class SandboxCredentialClientTests
    {
        private const string CredentialJson =
            """{"name":"copilot","displayName":"Copilot","provider":"GitHubCopilot","state":"Ready","source":{"kind":"Pat","parameterValues":{"token":"secret"}},"origin":"User"}""";

        [Test]
        public async Task SetCredentialSendsExpectedRequest()
        {
            MockTransport transport = new MockTransport(
                SandboxClientTestHelpers.CreateJsonResponse(200, CredentialJson));
            SandboxGroupCredentials client = CreateClient(transport);
            SandboxGroupCredentialSource source = new SandboxGroupCredentialSource(SandboxGroupCredentialSourceKind.Pat);
            source.ParameterValues.Add("token", "secret");
            CreateSandboxGroupCredentialContent content = new CreateSandboxGroupCredentialContent(
                SandboxGroupCredentialProvider.GitHubCopilot,
                source)
            {
                DisplayName = "Copilot"
            };

            Response<SandboxGroupCredential> response = await client.SetCredentialAsync("copilot", content);

            Assert.That(response.Value.Name, Is.EqualTo("copilot"));
            Assert.That(transport.Requests[0].Method, Is.EqualTo(RequestMethod.Put));
            Assert.That(transport.Requests[0].Uri.ToString(), Does.Contain("/credentials/copilot?"));
            string requestContent = SandboxClientTestHelpers.ReadContent(transport.Requests[0]);
            Assert.That(requestContent, Does.Contain("\"provider\":\"GitHubCopilot\""));
            Assert.That(requestContent, Does.Contain("\"kind\":\"Pat\""));
            Assert.That(requestContent, Does.Contain("\"token\":\"secret\""));
        }

        [Test]
        public async Task GetCredentialDeserializesCredential()
        {
            MockTransport transport = new MockTransport(
                SandboxClientTestHelpers.CreateJsonResponse(200, CredentialJson));
            SandboxGroupCredentials client = CreateClient(transport);

            Response<SandboxGroupCredential> response = await client.GetCredentialAsync("copilot");

            Assert.That(response.Value.Provider, Is.EqualTo(SandboxGroupCredentialProvider.GitHubCopilot));
            Assert.That(response.Value.Source.Kind, Is.EqualTo(SandboxGroupCredentialSourceKind.Pat));
            Assert.That(transport.Requests[0].Method, Is.EqualTo(RequestMethod.Get));
        }

        [Test]
        public async Task ListCredentialsHandlesContinuation()
        {
            string nextLink =
                $"{SandboxClientTestHelpers.Endpoint}/subscriptions/{SandboxClientTestHelpers.SubscriptionId}" +
                $"/resourceGroups/{SandboxClientTestHelpers.ResourceGroupName}/sandboxGroups/{SandboxClientTestHelpers.SandboxGroupName}" +
                "/credentials?skipToken=page-2";
            MockTransport transport = new MockTransport(
                SandboxClientTestHelpers.CreateJsonResponse(200,
                    $$"""{"value":[{{CredentialJson}}],"nextLink":"{{nextLink}}"}"""),
                SandboxClientTestHelpers.CreateJsonResponse(200,
                    """{"value":[{"name":"claude","provider":"Claude","state":"Ready","source":{"kind":"Pat"},"origin":"User"}]}"""));
            SandboxGroupCredentials client = CreateClient(transport);
            List<string> names = new List<string>();

            await foreach (Page<SandboxGroupCredential> page in client.GetCredentialsAsync("page-1").AsPages())
            {
                foreach (SandboxGroupCredential credential in page.Values)
                {
                    names.Add(credential.Name);
                }
            }

            Assert.That(names, Is.EqualTo(new[] { "copilot", "claude" }));
            Assert.That(transport.Requests, Has.Count.EqualTo(2));
            Assert.That(transport.Requests[0].Uri.Query, Does.Contain("skipToken=page-1"));
            Assert.That(transport.Requests[1].Uri.Query, Does.Contain("skipToken=page-2"));
        }

        [Test]
        public async Task DeleteCredentialSendsExpectedRequest()
        {
            MockTransport transport = new MockTransport(new MockResponse(204));
            SandboxGroupCredentials client = CreateClient(transport);

            Response response = await client.DeleteCredentialAsync("copilot");

            Assert.That(response.Status, Is.EqualTo(204));
            Assert.That(transport.Requests[0].Method, Is.EqualTo(RequestMethod.Delete));
            Assert.That(transport.Requests[0].Uri.ToString(), Does.Contain("/credentials/copilot?"));
        }

        private static SandboxGroupCredentials CreateClient(MockTransport transport) =>
            SandboxClientTestHelpers.CreateSandboxGroupClient(transport).GetSandboxGroupCredentialsClient();
    }
}
