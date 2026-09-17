// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.IO;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Azure.Core;
using NUnit.Framework;
using Streaming.Jsonl;

namespace TestProjects.Spector.Tests.Http.Streaming.Jsonl
{
    public class JsonlTests : SpectorTestBase
    {
        private const string JsonlContent = "{\"desc\": \"one\"}\n{\"desc\": \"two\"}\n{\"desc\": \"three\"}";

        [SpectorTest]
        [TestCase(true)]
        [TestCase(false)]
        public Task Send(bool isAsync) => Test(async (host) =>
        {
            var client = new JsonlClient(host, null).GetBasicClient();
            using var content = RequestContent.Create(BinaryData.FromString(JsonlContent));
            using var response = isAsync ? await client.SendAsync(content) : client.Send(content);

            Assert.AreEqual(204, response.Status);
        });

        [SpectorTest]
        [TestCase(true)]
        [TestCase(false)]
        public Task SendFromStream(bool isAsync) => Test(async (host) =>
        {
            var client = new JsonlClient(host, null).GetBasicClient();
            using var stream = new MemoryStream(Encoding.UTF8.GetBytes(JsonlContent));
            using var content = RequestContent.Create(stream);
            using var response = isAsync ? await client.SendAsync(content) : client.Send(content);

            Assert.AreEqual(204, response.Status);
        });

        [SpectorTest]
        [TestCase(true)]
        [TestCase(false)]
        public Task SendConvenience(bool isAsync) => Test(async (host) =>
        {
            var client = new JsonlClient(host, null).GetBasicClient();
            var stream = StreamingJsonlModelFactory.JsonlStreamInfo(BinaryData.FromString(JsonlContent));
            using var response = isAsync ? await client.SendAsync(stream) : client.Send(stream);

            Assert.AreEqual(204, response.Status);
        });

        [SpectorTest]
        [TestCase(true)]
        [TestCase(false)]
        public Task Receive(bool isAsync) => Test(async (host) =>
        {
            var client = new JsonlClient(host, null).GetBasicClient();
            var response = isAsync ? await client.ReceiveAsync() : client.Receive();
            using var rawResponse = response.GetRawResponse();

            Assert.AreEqual(200, rawResponse.Status);
            Assert.AreEqual("application/jsonl", rawResponse.Headers.ContentType);
            Assert.AreEqual(JsonlContent, response.Value.ToString());
        });

        [SpectorTest]
        [TestCase(true)]
        [TestCase(false)]
        public Task ReceiveProtocol(bool isAsync) => Test(async (host) =>
        {
            var client = new JsonlClient(host, null).GetBasicClient();
            using var response = isAsync ? await client.ReceiveAsync(context: null) : client.Receive(context: null);

            Assert.AreEqual(200, response.Status);
            Assert.AreEqual("application/jsonl", response.Headers.ContentType);
            Assert.IsNotNull(response.ContentStream);

            using var reader = new StreamReader(response.ContentStream!);
            foreach (var expected in new[] { "one", "two", "three" })
            {
                var line = isAsync ? await reader.ReadLineAsync() : reader.ReadLine();
                Assert.IsNotNull(line);
                using var document = JsonDocument.Parse(line!);
                Assert.AreEqual(expected, document.RootElement.GetProperty("desc").GetString());
            }

            Assert.IsNull(isAsync ? await reader.ReadLineAsync() : reader.ReadLine());
        });
    }
}
