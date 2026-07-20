// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel.Primitives;
using System.ClientModel.Tests.Proxy.FirstPartyA;
using System.ClientModel.Tests.Proxy.OpenAILike;
using System.ClientModel.Tests.Proxy.OpenAILike.Mocks;
using System.ClientModel.Tests.Proxy.ThirdPartyB;
using NUnit.Framework;

namespace System.ClientModel.Tests.ModelReaderWriterTests
{
    /// <summary>
    /// A <b>truly end-to-end</b> demonstration of the OpenAI -> Foundry conditional-deserialization
    /// scenario. Unlike a bare <see cref="ModelReaderWriter"/> call, each test drives a real
    /// <see cref="ResponseToolsClient"/> whose <see cref="ClientPipeline"/> uses a mock transport that
    /// returns a canned response body — i.e. we register the proxy, mock the response, run a client
    /// call, and verify the expected derived type comes back. Asserting the concrete runtime type AND
    /// the owning assembly proves the deserialization physically ran in the third-party DLL, not the base.
    /// </summary>
    public class ProxyEndToEndTests
    {
        // Builds a client whose transport returns the given canned response body, with optional proxies registered.
        private static ResponseToolsClient CreateClient(string cannedResponseJson, Action<ModelReaderWriterOptions>? registerProxies = null)
        {
            var mrwOptions = new ModelReaderWriterOptions("J");
            registerProxies?.Invoke(mrwOptions);

            var pipelineOptions = new ClientPipelineOptions
            {
                Transport = new CannedResponseTransport(cannedResponseJson)
            };

            return new ResponseToolsClient(pipelineOptions, mrwOptions);
        }

        private static void RegisterBothProxies(ModelReaderWriterOptions options)
            => options.AddAzureTools().AddBingTools();

        [Test]
        public void FunctionTool_HandledByBase()
        {
            ResponseToolsClient client = CreateClient("{\"type\":\"function\",\"function_name\":\"get_weather\"}", RegisterBothProxies);

            ResponseTool tool = client.GetTool("t1");

            Assert.IsInstanceOf<FunctionTool>(tool);
            Assert.AreEqual(typeof(ResponseTool).Assembly, tool.GetType().Assembly);
            Assert.AreEqual("get_weather", ((FunctionTool)tool).FunctionName);
        }

        [Test]
        public void AzureSearch_RoutedToFirstPartyA()
        {
            ResponseToolsClient client = CreateClient("{\"type\":\"azure_search\",\"index_name\":\"docs\"}", RegisterBothProxies);

            ResponseTool tool = client.GetTool("t2");

            Assert.IsInstanceOf<AzureSearchTool>(tool);
            Assert.AreEqual(typeof(AzureSearchTool).Assembly, tool.GetType().Assembly);
            Assert.AreEqual("docs", ((AzureSearchTool)tool).IndexName);
        }

        [Test]
        public void BingGrounding_RoutedToThirdPartyB()
        {
            ResponseToolsClient client = CreateClient("{\"type\":\"bing_grounding\",\"market\":\"en-US\"}", RegisterBothProxies);

            ResponseTool tool = client.GetTool("t3");

            Assert.IsInstanceOf<BingGroundingTool>(tool);
            Assert.AreEqual(typeof(BingGroundingTool).Assembly, tool.GetType().Assembly);
            Assert.AreEqual("en-US", ((BingGroundingTool)tool).Market);
        }

        [Test]
        public void UnknownDiscriminator_FallsBackToBase()
        {
            ResponseToolsClient client = CreateClient("{\"type\":\"web_search\"}", RegisterBothProxies);

            ResponseTool tool = client.GetTool("t4");

            Assert.IsInstanceOf<UnknownResponseTool>(tool);
            Assert.AreEqual(typeof(ResponseTool).Assembly, tool.GetType().Assembly);
        }

        [Test]
        public void WithoutProxies_AzureSearchFallsBackToBase()
        {
            // No proxies registered — proves the proxy is what changes behavior.
            ResponseToolsClient client = CreateClient("{\"type\":\"azure_search\",\"index_name\":\"docs\"}");

            ResponseTool tool = client.GetTool("t5");

            Assert.IsInstanceOf<UnknownResponseTool>(tool);
        }

        [Test]
        public void FirstPartyClient_HidesProxy_RoutesAzureSearch()
        {
            // The end user constructs the first-party client and registers NOTHING — the proxy is
            // hidden inside FirstPartyToolsClient. Routing to the first-party subtype still happens.
            var pipelineOptions = new ClientPipelineOptions
            {
                Transport = new CannedResponseTransport("{\"type\":\"azure_search\",\"index_name\":\"docs\"}")
            };
            var client = new FirstPartyToolsClient(pipelineOptions);

            ResponseTool tool = client.GetTool("t6");

            Assert.IsInstanceOf<AzureSearchTool>(tool);
            Assert.AreEqual(typeof(AzureSearchTool).Assembly, tool.GetType().Assembly);
            Assert.AreEqual("docs", ((AzureSearchTool)tool).IndexName);
        }

        [Test]
        public void FirstPartyClient_HiddenProxy_CoexistsWithExplicitThirdParty()
        {
            // First-party proxy stays hidden; the customer layers the third-party Bing proxy on top.
            // Each proxy only claims its own discriminator (note 18).
            var pipelineOptions = new ClientPipelineOptions
            {
                Transport = new CannedResponseTransport("{\"type\":\"bing_grounding\",\"market\":\"en-US\"}")
            };
            var client = new FirstPartyToolsClient(pipelineOptions, o => o.AddBingTools());

            ResponseTool tool = client.GetTool("t7");

            Assert.IsInstanceOf<BingGroundingTool>(tool);
            Assert.AreEqual(typeof(BingGroundingTool).Assembly, tool.GetType().Assembly);
            Assert.AreEqual("en-US", ((BingGroundingTool)tool).Market);
        }
    }
}
