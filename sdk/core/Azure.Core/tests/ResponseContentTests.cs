// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using Azure.Core.Pipeline;
using Azure.Core.Serialization;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.Core.Tests
{
    public class ResponseContentTests
    {
        [Test]
        public async Task CanSetDynamicOptionsFromClientOptions()
        {
            MockClientOptions options = new MockClientOptions();
            MockClient client = new MockClient(options);
            Response response = await client.GetValueAsync();
            ResponseContent content = response.Content as ResponseContent;

            Assert.IsNotNull(content);
            Assert.AreEqual(content.DynamicOptions.PropertyNamingConvention, PropertyNamingConvention.None);
        }

        [Test]
        public async Task DefaultRawContentOptionsUseStrictCasing()
        {
            MockClientOptions options = new MockClientOptions();
            MockClient client = new MockClient(options);
            Response response = await client.GetValueAsync();
            dynamic value = response.Content.ToDynamicFromJson();
            Assert.IsNull(value.Foo);
            Assert.AreEqual(1, (int)value.foo);
        }

        [Test]
        public async Task UseCamelCaseOptionEnablesPropertyNameConversion()
        {
            MockClientOptions options = new MockClientOptions();
            options.RawContent.PropertyNamingConvention = PropertyNamingConvention.CamelCase;

            MockClient client = new MockClient(options);
            Response response = await client.GetValueAsync();
            dynamic value = response.Content.ToDynamicFromJson();

            Assert.AreEqual(1, (int)value.Foo);
            Assert.AreEqual(1, (int)value.foo);
        }

        #region Helpers
        private class MockClient
        {
            private HttpPipeline _pipeline;

            public MockClient(MockClientOptions options)
            {
                options.Transport = new MockTransport(
                    new MockResponse(200).SetContent("""{"foo": 1}""")
                 );

                _pipeline = HttpPipelineBuilder.Build(options);
            }

            public async Task<Response> GetValueAsync()
            {
                using HttpMessage message = _pipeline.CreateMessage();
                return await _pipeline.ProcessMessageAsync(message, new RequestContext()).ConfigureAwait(false);
            }
        }

        private class MockClientOptions : ClientOptions
        {
        }
        #endregion
    }
}
