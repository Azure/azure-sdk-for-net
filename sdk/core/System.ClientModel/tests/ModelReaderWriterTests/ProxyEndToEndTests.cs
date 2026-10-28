// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel.Primitives;
using System.ClientModel.Tests.Proxy.FirstPartyA;
using System.ClientModel.Tests.Proxy.OpenAILike;
using System.ClientModel.Tests.Proxy.OpenAILike.Mocks;
using System.ClientModel.Tests.Proxy.ThirdPartyB;
using System.Collections.Generic;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
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
        private static ResponseToolsClient CreateClient(string cannedResponseJson, Action<ClientPipelineOptions>? registerProxies = null)
        {
            var pipelineOptions = new ClientPipelineOptions
            {
                Transport = new CannedResponseTransport(cannedResponseJson)
            };
            registerProxies?.Invoke(pipelineOptions);

            return new ResponseToolsClient(pipelineOptions);
        }

        private static void RegisterBothProxies(ClientPipelineOptions options)
        {
            options.AddProxy<ResponseTool>(new AzureSearchToolProxy());
            options.AddProxy<ResponseTool>(new BingGroundingToolProxy());
        }

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
        public void DirectClient_RegistersAzureProxyOnClientOptions()
        {
            ResponseToolsClient client = CreateClient(
                "{\"type\":\"azure_search\",\"index_name\":\"docs\"}",
                options => options.AddProxy<ResponseTool>(new AzureSearchToolProxy()));

            Assert.IsInstanceOf<AzureSearchTool>(client.GetTool("direct"));
        }

        [Test]
        public void DirectClient_SerializesRequestAndDeserializesProxiedResponse()
        {
            var transport = new CannedResponseTransport("{\"type\":\"azure_search\",\"index_name\":\"response-docs\"}");
            var options = new ClientPipelineOptions { Transport = transport };
            options.AddProxy<ResponseTool>(new AzureSearchToolProxy());
            var client = new ResponseToolsClient(options);

            ResponseTool response = client.SubmitTool(new AzureSearchTool("request-docs"));

            Assert.IsTrue(transport.RequestBodies.TryDequeue(out BinaryData? requestBody));
            Assert.AreEqual("{\"type\":\"azure_search\",\"index_name\":\"request-docs\"}", requestBody!.ToString());
            Assert.IsInstanceOf<AzureSearchTool>(response);
            Assert.AreEqual("response-docs", ((AzureSearchTool)response).IndexName);
            Assert.AreEqual(typeof(AzureSearchTool).Assembly, response.GetType().Assembly);
        }

        [Test]
        public void DirectClient_ConcurrentRequestsKeepSerializedToolsIndependent()
        {
            var transport = new CannedResponseTransport("{\"type\":\"azure_search\",\"index_name\":\"response\"}");
            var options = new ClientPipelineOptions { Transport = transport };
            options.AddProxy<ResponseTool>(new AzureSearchToolProxy());
            var client = new ResponseToolsClient(options);
            var calls = new List<Task<ResponseTool>>();

            for (int i = 0; i < 8; i++)
            {
                int index = i;
                calls.Add(Task.Run(() => client.SubmitTool(new AzureSearchTool($"index-{index}"))));
            }

            Task.WaitAll(calls.ToArray());

            var requestNames = new HashSet<string>();
            while (transport.RequestBodies.TryDequeue(out BinaryData? requestBody))
            {
                using JsonDocument document = JsonDocument.Parse(requestBody.ToString());
                requestNames.Add(document.RootElement.GetProperty("index_name").GetString()!);
            }

            Assert.AreEqual(8, requestNames.Count);
            for (int i = 0; i < 8; i++)
            {
                Assert.IsTrue(requestNames.Contains($"index-{i}"));
                Assert.IsInstanceOf<AzureSearchTool>(calls[i].Result);
            }
        }

        [Test]
        public void Subclient_InheritsProxyRegistrationsAndUsesItsOwnRequestPath()
        {
            var transport = new CannedResponseTransport("{\"type\":\"azure_search\",\"index_name\":\"docs\"}");
            var options = new ClientPipelineOptions { Transport = transport };
            options.AddProxy<ResponseTool>(new AzureSearchToolProxy());
            var subclient = new ResponseToolsClient(options).GetSubclient("group");

            ResponseTool result = subclient.GetTool("tool");

            Assert.IsInstanceOf<AzureSearchTool>(result);
            Assert.IsTrue(transport.RequestUris.TryDequeue(out Uri? requestUri));
            Assert.AreEqual("/subclients/group/tools/tool", requestUri!.AbsolutePath);
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
        public void ProxyForDeclaredToolType_RoutesSingleAndNestedCollectionItems()
        {
            const string payload = "{\"type\":\"azure_search\",\"index_name\":\"docs\"}";
            var options = new ModelReaderWriterOptions("J").AddAzureTools();

            ResponseTool? single = ModelReaderWriter.Read<ResponseTool>(BinaryData.FromString(payload), options);
            List<ResponseTool>? list = ModelReaderWriter.Read<List<ResponseTool>>(
                BinaryData.FromString($"[{payload}]"), options);
            List<List<ResponseTool>>? nested = ModelReaderWriter.Read<List<List<ResponseTool>>>(
                BinaryData.FromString($"[[{payload}]]"), options);

            Assert.IsInstanceOf<AzureSearchTool>(single);
            Assert.IsNotNull(list);
            Assert.AreEqual(1, list!.Count);
            Assert.IsInstanceOf<AzureSearchTool>(list[0]);
            Assert.AreEqual(typeof(AzureSearchTool).Assembly, list[0].GetType().Assembly);
            Assert.AreEqual("docs", ((AzureSearchTool)list[0]).IndexName);
            Assert.IsNotNull(nested);
            Assert.IsInstanceOf<AzureSearchTool>(nested![0][0]);
            Assert.AreEqual(typeof(AzureSearchTool).Assembly, nested[0][0].GetType().Assembly);
            Assert.AreEqual("docs", ((AzureSearchTool)nested[0][0]).IndexName);
        }

        [Test]
        public void ProxyForDeclaredToolType_RoutesMixedCollectionAndFallback()
        {
            const string payload = "[{\"type\":\"azure_search\",\"index_name\":\"docs\"}," +
                "{\"type\":\"bing_grounding\",\"market\":\"en-US\"}," +
                "{\"type\":\"function\",\"function_name\":\"get_weather\"}," +
                "{\"type\":\"unrecognized\"}]";
            var options = new ModelReaderWriterOptions("J").AddAzureTools().AddBingTools();

            List<ResponseTool>? tools = ModelReaderWriter.Read<List<ResponseTool>>(
                BinaryData.FromString(payload), options);
            List<List<ResponseTool>>? nested = ModelReaderWriter.Read<List<List<ResponseTool>>>(
                BinaryData.FromString($"[{payload}]"), options);

            Assert.IsNotNull(tools);
            Assert.IsNotNull(nested);
            Assert.AreEqual(1, nested!.Count);
            AssertMixedTools(tools!);
            AssertMixedTools(nested[0]);
        }

        private static void AssertMixedTools(IReadOnlyList<ResponseTool> tools)
        {
            Assert.AreEqual(4, tools.Count);
            Assert.IsInstanceOf<AzureSearchTool>(tools[0]);
            Assert.AreEqual(typeof(AzureSearchTool).Assembly, tools[0].GetType().Assembly);
            Assert.AreEqual("docs", ((AzureSearchTool)tools[0]).IndexName);
            Assert.IsInstanceOf<BingGroundingTool>(tools[1]);
            Assert.AreEqual(typeof(BingGroundingTool).Assembly, tools[1].GetType().Assembly);
            Assert.AreEqual("en-US", ((BingGroundingTool)tools[1]).Market);
            Assert.IsInstanceOf<FunctionTool>(tools[2]);
            Assert.AreEqual(typeof(ResponseTool).Assembly, tools[2].GetType().Assembly);
            Assert.IsInstanceOf<UnknownResponseTool>(tools[3]);
            Assert.AreEqual(typeof(ResponseTool).Assembly, tools[3].GetType().Assembly);
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
            var client = new FirstPartyToolsClient(
                pipelineOptions, o => o.AddProxy<ResponseTool>(new BingGroundingToolProxy()));

            ResponseTool tool = client.GetTool("t7");

            Assert.IsInstanceOf<BingGroundingTool>(tool);
            Assert.AreEqual(typeof(BingGroundingTool).Assembly, tool.GetType().Assembly);
            Assert.AreEqual("en-US", ((BingGroundingTool)tool).Market);
        }

        [Test]
        public void FirstPartyClient_PreservesProxiesConfiguredBeforeConstruction()
        {
            var pipelineOptions = new ClientPipelineOptions
            {
                Transport = new CannedResponseTransport("{\"type\":\"bing_grounding\",\"market\":\"en-US\"}")
            };
            pipelineOptions.AddProxy<ResponseTool>(new BingGroundingToolProxy());

            var client = new FirstPartyToolsClient(pipelineOptions);
            ResponseTool tool = client.GetTool("t8");

            Assert.IsInstanceOf<BingGroundingTool>(tool);
            Assert.AreEqual(typeof(BingGroundingTool).Assembly, tool.GetType().Assembly);
            Assert.AreEqual("en-US", ((BingGroundingTool)tool).Market);
        }

        [Test]
        public void SeparateClients_UseOnlyTheirRegisteredProxies()
        {
            const string azurePayload = "{\"type\":\"azure_search\",\"index_name\":\"docs\"}";
            var azureClient = CreateClient(azurePayload, options => options.AddProxy<ResponseTool>(new AzureSearchToolProxy()));
            var bingOnlyClient = CreateClient(azurePayload, options => options.AddProxy<ResponseTool>(new BingGroundingToolProxy()));
            var bingClient = CreateClient(
                "{\"type\":\"bing_grounding\",\"market\":\"en-US\"}",
                options => options.AddProxy<ResponseTool>(new BingGroundingToolProxy()));

            ResponseTool azure = azureClient.GetTool("a");
            ResponseTool noAzure = bingOnlyClient.GetTool("b");
            ResponseTool bing = bingClient.GetTool("c");

            Assert.IsInstanceOf<AzureSearchTool>(azure);
            Assert.AreEqual(typeof(AzureSearchTool).Assembly, azure.GetType().Assembly);
            Assert.IsInstanceOf<UnknownResponseTool>(noAzure);
            Assert.IsInstanceOf<BingGroundingTool>(bing);
            Assert.AreEqual(typeof(BingGroundingTool).Assembly, bing.GetType().Assembly);
        }

        [Test]
        public void SeparateClients_ConcurrentCallsDoNotShareProxyRegistrations()
        {
            const string azurePayload = "{\"type\":\"azure_search\",\"index_name\":\"docs\"}";
            using var barrier = new Barrier(2);
            var azureOptions = new ClientPipelineOptions
            {
                Transport = new CannedResponseTransport(azurePayload, processBarrier: barrier)
            };
            azureOptions.AddProxy<ResponseTool>(new AzureSearchToolProxy());
            var bingOnlyOptions = new ClientPipelineOptions
            {
                Transport = new CannedResponseTransport(azurePayload, processBarrier: barrier)
            };
            bingOnlyOptions.AddProxy<ResponseTool>(new BingGroundingToolProxy());
            var azureClient = new ResponseToolsClient(azureOptions);
            var bingOnlyClient = new ResponseToolsClient(bingOnlyOptions);

            Task<ResponseTool> azureCall = Task.Factory.StartNew(
                () => azureClient.GetTool("azure"),
                CancellationToken.None, TaskCreationOptions.LongRunning, TaskScheduler.Default);
            Task<ResponseTool> bingOnlyCall = Task.Factory.StartNew(
                () => bingOnlyClient.GetTool("bing"),
                CancellationToken.None, TaskCreationOptions.LongRunning, TaskScheduler.Default);
            Task.WaitAll(azureCall, bingOnlyCall);

            Assert.IsInstanceOf<AzureSearchTool>(azureCall.Result);
            Assert.IsInstanceOf<UnknownResponseTool>(bingOnlyCall.Result);
        }

        [Test]
        public void DisjointProxies_SelectByPayloadWhenRegisteredInReverseOrder()
        {
            var azureClient = CreateClient(
                "{\"type\":\"azure_search\",\"index_name\":\"docs\"}",
                options =>
                {
                    options.AddProxy<ResponseTool>(new BingGroundingToolProxy());
                    options.AddProxy<ResponseTool>(new AzureSearchToolProxy());
                });
            var bingClient = CreateClient(
                "{\"type\":\"bing_grounding\",\"market\":\"en-US\"}",
                options =>
                {
                    options.AddProxy<ResponseTool>(new BingGroundingToolProxy());
                    options.AddProxy<ResponseTool>(new AzureSearchToolProxy());
                });

            Assert.IsInstanceOf<AzureSearchTool>(azureClient.GetTool("a"));
            Assert.IsInstanceOf<BingGroundingTool>(bingClient.GetTool("b"));
        }

        [Test]
        public void ClientOptions_AddProxyRejectsNullAndFrozenOptions()
        {
            var options = new ClientPipelineOptions
            {
                Transport = new CannedResponseTransport("{\"type\":\"azure_search\"}")
            };

            Assert.Throws<ArgumentNullException>(
                () => options.AddProxy<ResponseTool>((IPersistableModel<ResponseTool>)null!));
            Assert.Throws<ArgumentNullException>(
                () => options.AddProxy<ResponseTool>((ConditionalModelProxy<ResponseTool>)null!));

            ClientPipeline.Create(options);

            Assert.Throws<InvalidOperationException>(
                () => options.AddProxy<ResponseTool>(new AzureSearchToolProxy()));
        }

        [Test]
        public void ClientOptions_DoNotExposeAModelReaderWriterOptionsSetter()
        {
            Assert.IsNull(typeof(ClientPipelineOptions)
                .GetProperty(nameof(ClientPipelineOptions.ModelReaderWriterOptions))!.GetSetMethod());
        }

        [Test]
        public void ClientConstruction_SnapshotsProxyRegistrations()
        {
            var options = new ClientPipelineOptions
            {
                Transport = new CannedResponseTransport("{\"type\":\"bing_grounding\",\"market\":\"en-US\"}")
            };
            options.AddProxy<ResponseTool>(new AzureSearchToolProxy());
            var client = new ResponseToolsClient(options);

            options.ModelReaderWriterOptions!.AddProxy<ResponseTool>(new BingGroundingToolProxy());

            Assert.IsInstanceOf<UnknownResponseTool>(client.GetTool("snapshot"));
        }

        [Test]
        public void ClientOptionsClone_SeparatesProxyRegistrations()
        {
            var options = new ClientPipelineOptions
            {
                Transport = new CannedResponseTransport("{\"type\":\"bing_grounding\",\"market\":\"en-US\"}")
            };
            options.AddProxy<ResponseTool>(new AzureSearchToolProxy());
            ClientPipelineOptions clone = options.Clone();
            options.ModelReaderWriterOptions!.AddProxy<ResponseTool>(new BingGroundingToolProxy());

            var client = new ResponseToolsClient(clone);

            Assert.IsInstanceOf<UnknownResponseTool>(client.GetTool("clone"));
        }

        [Test]
        public void Write_BaseTypeRegistrationDoesNotApplyToDerivedInstance()
        {
            var options = new ModelReaderWriterOptions("J");
            var baseProxy = new SentinelModel<ResponseTool>("base");
            options.AddProxy<ResponseTool>(baseProxy);
            var tool = new AzureSearchTool("docs");
            string original = ModelReaderWriter.Write(tool, new ModelReaderWriterOptions("J")).ToString();

            Assert.AreEqual(original, ModelReaderWriter.Write<ResponseTool>(tool, options).ToString());
            Assert.IsNull(baseProxy.ProxiedModelAtWrite);

            options.AddProxy<AzureSearchTool>(new SentinelModel<AzureSearchTool>("exact"));

            Assert.AreEqual("{\"sentinel\":\"exact\"}", ModelReaderWriter.Write<ResponseTool>(tool, options).ToString());
        }

        // Writes a distinct sentinel document so a test can tell the proxy, not the original model, wrote.
        private sealed class SentinelModel<T> : IJsonModel<T>
        {
            private readonly string _name;

            public SentinelModel(string name) => _name = name;

            public object? ProxiedModelAtWrite { get; private set; }

            T IJsonModel<T>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options) => throw new NotSupportedException();

            void IJsonModel<T>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
            {
                ProxiedModelAtWrite = options.ProxiedModel;
                writer.WriteStartObject();
                writer.WriteString("sentinel"u8, _name);
                writer.WriteEndObject();
            }

            T IPersistableModel<T>.Create(BinaryData data, ModelReaderWriterOptions options) => throw new NotSupportedException();

            BinaryData IPersistableModel<T>.Write(ModelReaderWriterOptions options) => BinaryData.FromString($"{{\"sentinel\":\"{_name}\"}}");

            string IPersistableModel<T>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";
        }
    }
}
