// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Text.Json.Nodes;
using System.Threading.Tasks;
using Azure.Core;
using AzureExampleBasicClient;
using NUnit.Framework;

namespace TestProjects.Spector.Tests.Http.Azure.Example.Basic
{
    public class AzureExampleBasicTests : SpectorTestBase
    {
        [SpectorTest]
        public Task Azure_Example_Basic_basicAction() => Test(async (host) =>
        {
            var value = new
            {
                stringProperty = "text",
                modelProperty = new
                {
                    int32Property = 1,
                    float32Property = 1.5f,
                    enumProperty = "EnumValue1"
                },
                arrayProperty = new[] { "item" },
                recordProperty = new
                {
                    record = "value"
                }
            };
            var response = await new AzureExampleClient(host, null).BasicActionAsync("query", "header", RequestContent.Create(value));
            Assert.AreEqual(200, response.Status);
            JsonNode responseBody = JsonNode.Parse(response.Content!)!;
            Assert.AreEqual("text", (string)responseBody["stringProperty"]!);
        });
    }
}