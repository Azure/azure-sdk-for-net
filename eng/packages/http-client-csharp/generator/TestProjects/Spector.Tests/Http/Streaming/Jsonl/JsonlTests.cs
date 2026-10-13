// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Threading.Tasks;
using NUnit.Framework;
using Streaming.Jsonl;
using Streaming.Jsonl._Basic;

namespace TestProjects.Spector.Tests.Http.Streaming.Jsonl
{
    public class JsonlTests : SpectorTestBase
    {
        [SpectorTest]
        public Task Send() => Test(async (host) =>
        {
            var client = new JsonlClient(host, null).GetBasicClient();
            var response = await client.SendAsync(GetValues());
            Assert.AreEqual(204, response.Status);
        });

        [SpectorTest]
        public Task Receive() => Test(async (host) =>
        {
            var client = new JsonlClient(host, null).GetBasicClient();
            await using var response = await client.ReceiveAsync();
            var descriptions = new List<string>();
            await foreach (var value in response)
            {
                descriptions.Add(value.Desc);
            }

            CollectionAssert.AreEqual(new[] { "one", "two", "three" }, descriptions);
        });

        private static async IAsyncEnumerable<Info> GetValues()
        {
            await Task.Yield();
            yield return new Info("one");
            yield return new Info("two");
            yield return new Info("three");
        }
    }
}
