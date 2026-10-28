// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using FoundryLikeA;
using FoundryLikeB;
using NUnit.Framework;
using OpenAILike;
using OpenAILike.Mocks;
using OpenAILike.Responses;
using static System.ClientModel.Tests.ModelReaderWriterTests.Proxies.ProxyTestPayloads;

namespace System.ClientModel.Tests.ModelReaderWriterTests.Proxies
{
    /// <summary>
    /// Drives the OpenAILike clients over a mocked transport. Each test registers proxies on the client options through
    /// the libraries' provisional registration helpers, mocks the service response, runs a client call, and checks the
    /// runtime type and owning assembly of the tools that come back. The assembly assertions prove the
    /// deserialization physically ran in the extension library, or, for fallbacks, in the base library.
    /// </summary>
    public class ClientProxyTests
    {
        private static readonly ApiKeyCredential s_credential = new("local-test-key");

        [Test]
        public async Task ResponsesClientRoutesRegisteredToolsAndFallsBack()
        {
            var transport = CannedResponseTransport.Sequence(
                ResponseJson("azure_search", "index_name", "docs"),
                ResponseJson("bing_grounding", "market", "en-US"),
                ResponseJson("totally_unknown"));
            var options = new ResponsesClientOptions { Transport = transport };
            options.AddAzureSerializationExtensions();
            options.AddBingSerializationExtensions();
            var client = new ResponsesClient(s_credential, options);

            ResponseTool azure = (await client.GetResponseAsync("azure")).Value.Tools.Single();
            ResponseTool bing = (await client.GetResponseAsync("bing")).Value.Tools.Single();
            ResponseTool unknown = (await client.GetResponseAsync("unknown")).Value.Tools.Single();

            Assert.That(azure, Is.InstanceOf<AzureSearchTool>());
            Assert.That(azure.GetType().Assembly, Is.EqualTo(typeof(AzureSearchTool).Assembly));
            Assert.That(((AzureSearchTool)azure).IndexName, Is.EqualTo("docs"));
            Assert.That(bing, Is.InstanceOf<BingGroundingTool>());
            Assert.That(bing.GetType().Assembly, Is.EqualTo(typeof(BingGroundingTool).Assembly));
            Assert.That(((BingGroundingTool)bing).Market, Is.EqualTo("en-US"));
            Assert.That(unknown, Is.InstanceOf<UnknownResponseTool>());
            Assert.That(unknown.GetType().Assembly, Is.EqualTo(typeof(ResponseTool).Assembly));
            Assert.That(transport.RequestMethods, Is.EqualTo(new[] { "GET", "GET", "GET" }));
            Assert.That(
                transport.RequestUris.Select(u => u.AbsolutePath),
                Is.EqualTo(new[] { "/v1/responses/azure", "/v1/responses/bing", "/v1/responses/unknown" }));
        }

        [Test]
        public async Task OpenAIClientPassesProxyRegistrationsToResponsesSubclient()
        {
            var transport = new CannedResponseTransport(ResponseJson("azure_search", "index_name", "root-docs"));
            var options = new OpenAIClientOptions { Transport = transport };
            options.AddAzureSerializationExtensions();
            options.AddBingSerializationExtensions();
            var client = new OpenAIClient(s_credential, options);

            ResponseTool tool = (await client.GetResponsesClient().GetResponseAsync("root")).Value.Tools.Single();

            Assert.That(tool, Is.InstanceOf<AzureSearchTool>());
            Assert.That(((AzureSearchTool)tool).IndexName, Is.EqualTo("root-docs"));
            Assert.That(transport.RequestMethods, Is.EqualTo(new[] { "GET" }));
            Assert.That(transport.RequestUris.Select(u => u.AbsolutePath), Is.EqualTo(new[] { "/v1/responses/root" }));
        }

        [Test]
        public async Task FirstPartyWrapperAddsAzureWithoutEndUserRegistration()
        {
            var transport = new CannedResponseTransport(ResponseJson("azure_search", "index_name", "first-party"));
            var options = new ResponsesClientOptions { Transport = transport };
            var client = new AzureResponsesClient(s_credential, options);

            ResponseTool tool = (await client.GetResponseAsync("first-party")).Value.Tools.Single();

            Assert.That(tool, Is.InstanceOf<AzureSearchTool>());
            Assert.That(((AzureSearchTool)tool).IndexName, Is.EqualTo("first-party"));
            Assert.That(transport.RequestUris.Select(u => u.AbsolutePath), Is.EqualTo(new[] { "/v1/responses/first-party" }));
        }

        [Test]
        public async Task ResponsesClientSerializesRequestAndReadsProxiedResponse()
        {
            var transport = new CannedResponseTransport(ResponseJson("azure_search", "index_name", "created"));
            var options = new ResponsesClientOptions { Transport = transport };
            options.AddAzureSerializationExtensions();
            var client = new ResponsesClient(s_credential, options);
            var request = new CreateResponseOptions("test-model", [ResponseItem.CreateUserMessageItem("hello")]);
            request.Tools.Add(new AzureSearchTool("request-docs"));

            ResponseResult response = (await client.CreateResponseAsync(request)).Value;

            Assert.That(response.Tools.Single(), Is.InstanceOf<AzureSearchTool>());
            Assert.That(((AzureSearchTool)response.Tools.Single()).IndexName, Is.EqualTo("created"));
            Assert.That(transport.RequestMethods, Is.EqualTo(new[] { "POST" }));
            Assert.That(transport.RequestUris.Select(u => u.AbsolutePath), Is.EqualTo(new[] { "/v1/responses" }));
            Assert.That(transport.RequestBodies.TryDequeue(out BinaryData? requestBody), Is.True);
            using JsonDocument body = JsonDocument.Parse(requestBody!);
            Assert.That(body.RootElement.GetProperty("model").GetString(), Is.EqualTo("test-model"));
            Assert.That(body.RootElement.GetProperty("input").GetArrayLength(), Is.EqualTo(1));
            Assert.That(
                body.RootElement.GetProperty("tools")[0].GetRawText(),
                Is.EqualTo("{\"type\":\"azure_search\",\"index_name\":\"request-docs\"}"));
        }

        [Test]
        public async Task SeparateResponsesClientsSnapshotDistinctProxySets()
        {
            var azureTransport = new CannedResponseTransport(ResponseJson("azure_search", "index_name", "azure"));
            var bingTransport = CannedResponseTransport.Sequence(
                ResponseJson("azure_search", "index_name", "unregistered"),
                ResponseJson("bing_grounding", "market", "en-GB"));
            var azureOptions = new ResponsesClientOptions { Transport = azureTransport };
            azureOptions.AddAzureSerializationExtensions();
            var bingOptions = new ResponsesClientOptions { Transport = bingTransport };
            bingOptions.AddBingSerializationExtensions();
            var azureClient = new ResponsesClient(s_credential, azureOptions);
            var bingClient = new ResponsesClient(s_credential, bingOptions);

            // Registrations added after a client was constructed do not reach that client.
            bingOptions.ModelReaderWriterOptions!.AddProxy<ResponseTool>(new AzureSearchToolProxy());

            ResponseTool azure = (await azureClient.GetResponseAsync("azure")).Value.Tools.Single();
            ResponseTool noAzure = (await bingClient.GetResponseAsync("other")).Value.Tools.Single();
            ResponseTool bing = (await bingClient.GetResponseAsync("bing")).Value.Tools.Single();

            Assert.That(azure, Is.InstanceOf<AzureSearchTool>());
            Assert.That(noAzure.GetType().Assembly, Is.EqualTo(typeof(ResponseTool).Assembly));
            Assert.That(bing, Is.InstanceOf<BingGroundingTool>());
            Assert.That(((BingGroundingTool)bing).Market, Is.EqualTo("en-GB"));
        }

        [Test]
        public async Task ResponsesClientReadsMixedToolsFromOneResponse()
        {
            string response = "{\"id\":\"response-id\",\"model\":\"test-model\",\"tools\":["
                + $"{AzureToolJson},{BingToolJson},"
                + "{\"type\":\"function\",\"function_name\":\"get_weather\"},{\"type\":\"unrecognized\"}]}";
            var options = new ResponsesClientOptions { Transport = new CannedResponseTransport(response) };
            options.AddAzureSerializationExtensions();
            options.AddBingSerializationExtensions();
            var client = new ResponsesClient(s_credential, options);

            ResponseResult result = (await client.GetResponseAsync("mixed")).Value;

            Assert.That(result.Tools, Has.Count.EqualTo(4));
            Assert.That(result.Tools[0], Is.InstanceOf<AzureSearchTool>());
            Assert.That(result.Tools[1], Is.InstanceOf<BingGroundingTool>());
            Assert.That(result.Tools[2], Is.InstanceOf<FunctionTool>());
            Assert.That(result.Tools[2].GetType().Assembly, Is.EqualTo(typeof(ResponseTool).Assembly));
            Assert.That(result.Tools[3], Is.InstanceOf<UnknownResponseTool>());
        }

        [Test]
        public async Task DisjointProxiesSelectByPayloadWhenRegisteredInReverseOrder()
        {
            var transport = CannedResponseTransport.Sequence(
                ResponseJson("azure_search", "index_name", "docs"),
                ResponseJson("bing_grounding", "market", "en-US"));
            var options = new ResponsesClientOptions { Transport = transport };
            options.AddBingSerializationExtensions();
            options.AddAzureSerializationExtensions();
            var client = new ResponsesClient(s_credential, options);

            ResponseTool azure = (await client.GetResponseAsync("azure")).Value.Tools.Single();
            ResponseTool bing = (await client.GetResponseAsync("bing")).Value.Tools.Single();

            Assert.That(azure, Is.InstanceOf<AzureSearchTool>());
            Assert.That(bing, Is.InstanceOf<BingGroundingTool>());
        }

        [Test]
        public async Task FirstPartyWrapperCoexistsWithRegistrationsOnSuppliedOptions()
        {
            var transport = CannedResponseTransport.Sequence(
                ResponseJson("bing_grounding", "market", "en-US"),
                ResponseJson("azure_search", "index_name", "docs"));
            var options = new ResponsesClientOptions { Transport = transport };
            options.AddBingSerializationExtensions();
            var client = new AzureResponsesClient(s_credential, options);

            ResponseTool bing = (await client.GetResponseAsync("bing")).Value.Tools.Single();
            ResponseTool azure = (await client.GetResponseAsync("azure")).Value.Tools.Single();

            Assert.That(bing, Is.InstanceOf<BingGroundingTool>());
            Assert.That(bing.GetType().Assembly, Is.EqualTo(typeof(BingGroundingTool).Assembly));
            Assert.That(azure, Is.InstanceOf<AzureSearchTool>());
        }
    }
}
