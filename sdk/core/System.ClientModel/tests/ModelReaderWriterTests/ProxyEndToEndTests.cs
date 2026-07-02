// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel.Primitives;
using System.ClientModel.Tests.Proxy.OpenAILike;
using System.ClientModel.Tests.Proxy.ThirdPartyA;
using System.ClientModel.Tests.Proxy.ThirdPartyB;
using NUnit.Framework;

namespace System.ClientModel.Tests.ModelReaderWriterTests
{
    /// <summary>
    /// End-to-end demonstration of the OpenAI -> Foundry conditional-deserialization scenario:
    /// a base "OpenAI-like" library, two independent third-party libraries each adding a subtype via
    /// a conditional proxy, and a consumer that routes deserialization purely from the payload
    /// discriminator. Asserts the concrete runtime type AND the owning assembly so we prove the
    /// deserialization physically runs in the third-party DLL, not the base.
    /// </summary>
    public class ProxyEndToEndTests
    {
        private static ModelReaderWriterOptions CreateOptionsWithBothProxies()
            => new ModelReaderWriterOptions("J").AddAzureTools().AddBingTools();

        [Test]
        public void FunctionTool_HandledByBase()
        {
            var data = BinaryData.FromString("{\"type\":\"function\",\"function_name\":\"get_weather\"}");
            ResponseTool tool = ModelReaderWriter.Read<ResponseTool>(data, CreateOptionsWithBothProxies())!;

            Assert.IsInstanceOf<FunctionTool>(tool);
            Assert.AreEqual(typeof(ResponseTool).Assembly, tool.GetType().Assembly);
            Assert.AreEqual("get_weather", ((FunctionTool)tool).FunctionName);
        }

        [Test]
        public void AzureSearch_RoutedToThirdPartyA()
        {
            var data = BinaryData.FromString("{\"type\":\"azure_search\",\"index_name\":\"docs\"}");
            ResponseTool tool = ModelReaderWriter.Read<ResponseTool>(data, CreateOptionsWithBothProxies())!;

            Assert.IsInstanceOf<AzureSearchTool>(tool);
            Assert.AreEqual(typeof(AzureSearchTool).Assembly, tool.GetType().Assembly);
            Assert.AreEqual("docs", ((AzureSearchTool)tool).IndexName);
        }

        [Test]
        public void BingGrounding_RoutedToThirdPartyB()
        {
            var data = BinaryData.FromString("{\"type\":\"bing_grounding\",\"market\":\"en-US\"}");
            ResponseTool tool = ModelReaderWriter.Read<ResponseTool>(data, CreateOptionsWithBothProxies())!;

            Assert.IsInstanceOf<BingGroundingTool>(tool);
            Assert.AreEqual(typeof(BingGroundingTool).Assembly, tool.GetType().Assembly);
            Assert.AreEqual("en-US", ((BingGroundingTool)tool).Market);
        }

        [Test]
        public void UnknownDiscriminator_FallsBackToBase()
        {
            var data = BinaryData.FromString("{\"type\":\"web_search\"}");
            ResponseTool tool = ModelReaderWriter.Read<ResponseTool>(data, CreateOptionsWithBothProxies())!;

            Assert.IsInstanceOf<UnknownResponseTool>(tool);
            Assert.AreEqual(typeof(ResponseTool).Assembly, tool.GetType().Assembly);
        }

        [Test]
        public void WithoutProxies_AzureSearchFallsBackToBase()
        {
            var data = BinaryData.FromString("{\"type\":\"azure_search\",\"index_name\":\"docs\"}");
            ResponseTool tool = ModelReaderWriter.Read<ResponseTool>(data, new ModelReaderWriterOptions("J"))!;

            // Proves the proxy is what changes behavior: without it, the base cannot route azure_search.
            Assert.IsInstanceOf<UnknownResponseTool>(tool);
        }
    }
}
