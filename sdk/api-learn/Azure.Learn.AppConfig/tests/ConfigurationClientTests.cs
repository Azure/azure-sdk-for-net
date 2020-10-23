// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.Learn.AppConfig;
using NUnit.Framework;
namespace Azure.LearnAppConfig.Tests
{
    [TestFixture(true)]
    [TestFixture(false)]
    public class ConfigurationClientTests : ClientTestBase
    {
        public ConfigurationClientTests(bool isAsync) :
              base(isAsync)
        {
        }

        [Test]
        public async Task AuthorizationHeadersAddedOnceWithRetries()
        {
            // arrange
            var finalResponse = new MockResponse(200);
            var setting = new ConfigurationSetting
            {
                Key = "test-key",
                Value = "test-value"
            };
            finalResponse.SetContent(JsonSerializer.Serialize(setting));
            var mockTransport = new MockTransport(new MockResponse(503), finalResponse);
            var options = new ConfigurationClientOptions
            {
                Transport = mockTransport
            };
            var credential = new MockCredential();
            var uri = new Uri("https://localHost");
            var client = InstrumentClient(new ConfigurationClient(uri, credential, options));

            // act
            await client.GetConfigurationSettingAsync(setting.Key, setting.Label);
            var retriedRequest = mockTransport.Requests[1];

            // assert
            Assert.True(retriedRequest.Headers.TryGetValues("Authorization", out var authorizationHeaders));
            Assert.AreEqual(1, authorizationHeaders.Count());
        }
    }
}
