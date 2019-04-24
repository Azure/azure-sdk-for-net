// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

using Azure.Core.Pipeline;
using Azure.Core.Pipeline.Policies;
using NUnit.Framework;
using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Moq;
using Azure.Core.Testing;

namespace Azure.ApplicationModel.Configuration.Samples
{
    [Category("Live")]
    public partial class ConfigurationSamples
    {
        [Test]
        public async Task MockClient()
        {
            // Create a mock response
            var mockResponse = new Mock<Response>();
            // Create a client mock
            var mock = new Mock<ConfigurationClient>();
            // Setup client method
            mock.Setup(c => c.GetAsync("Key", It.IsAny<string>(), It.IsAny<DateTimeOffset>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(new Response<ConfigurationSetting>(mockResponse.Object, ConfigurationClientModelFactory.ConfigurationSetting("Key", "Value")));

            // Use the client mock
            ConfigurationClient client = mock.Object;
            Response<ConfigurationSetting> setting = await client.GetAsync("Key");
            Assert.AreEqual("Value", setting.Value.Value);
        }
    }
}
