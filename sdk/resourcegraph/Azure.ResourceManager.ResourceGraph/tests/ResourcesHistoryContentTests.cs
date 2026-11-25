// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel.Primitives;
using System.Runtime.Versioning;
using System.Text.Json;
using Azure.ResourceManager.ResourceGraph.Models;
using NUnit.Framework;

namespace Azure.ResourceManager.ResourceGraph.Tests
{
    public class ResourcesHistoryContentTests
    {
        [Test]
        public void JsonRoundTripPreservesUnknownProperty()
        {
#if NETFRAMEWORK
            var targetFramework = (TargetFrameworkAttribute)Attribute.GetCustomAttribute(
                typeof(ResourcesHistoryContent).Assembly, typeof(TargetFrameworkAttribute));
            Assert.That(targetFramework.FrameworkName, Is.EqualTo(".NETStandard,Version=v2.0"));
            const int depth = 80;
#else
            // The modern writer uses WriteRawValue, which validates at depth 64.
            const int depth = 32;
#endif
            string nested = new string('[', depth) + "42" + new string(']', depth);
            var options = new ModelReaderWriterOptions("J");
            var input = BinaryData.FromString("{\"query\":\"Resources\",\"unknown\":" + nested + "}");
            var context = AzureResourceManagerResourceGraphContext.Default;
            var model = ModelReaderWriter.Read<ResourcesHistoryContent>(input, options, context);
            BinaryData output = ModelReaderWriter.Write(model, options, context);

            using JsonDocument document = JsonDocument.Parse(output, new JsonDocumentOptions { MaxDepth = 256 });
            Assert.That(document.RootElement.GetProperty("query").GetString(), Is.EqualTo("Resources"));
            Assert.That(document.RootElement.GetProperty("unknown").GetRawText(), Is.EqualTo(nested));
        }
    }
}
