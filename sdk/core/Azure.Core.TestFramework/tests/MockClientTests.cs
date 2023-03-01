// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Text.Json.Serialization;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Azure.Core.TestFramework.Tests
{
    public class MockClientTests : ClientTestBase
    {
        public MockClientTests(bool isAsync) : base(isAsync)
        {
        }

        private MockClient CreateClient(params MockResponse[] responses)
        {
            MockClientOptions options = new()
            {
                Transport = new MockTransport(responses),
            };

            return InstrumentClient(new MockClient(options));
        }

        [Test]
        public async Task MockGetResource()
        {
            MockResponse[] responses = new[]
            {
                new MockResponse(200).WithJson(@"{""id"": ""1"", ""value"": ""resource1""}"),
            };

            MockClient client = CreateClient(responses);
            Response response = await client.GetResourceAsync("1");

            Assert.That(response.Status, Is.EqualTo(200));
            Assert.That(response.Content.ToObjectFromJson<MockResource>(), Has.Property("Id").EqualTo("1").And.Property("Value").EqualTo("resource1"));
        }

        private class MockResource
        {
            [JsonPropertyName("id")]
            public string Id { get; set; }

            [JsonPropertyName("value")]
            public string Value { get; set; }
        }
    }
}
