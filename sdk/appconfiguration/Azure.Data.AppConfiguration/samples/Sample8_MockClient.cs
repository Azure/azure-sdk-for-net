// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading;
using Moq;
using NUnit.Framework;

namespace Azure.Data.AppConfiguration.Samples
{
    public partial class ConfigurationSamples
    {
        [Test]
        public void MockClient()
        {
            // Create a mock response
            var mockResponse = new Mock<Response>();
            // Create a client mock
            var mock = new Mock<ConfigurationClient>();
            // Setup client method
            mock.Setup(c => c.Get("Key", It.IsAny<string>(), It.IsAny<DateTimeOffset>(), It.IsAny<CancellationToken>()))
                .Returns(Response.FromValue(mockResponse.Object, ConfigurationModelFactory.ConfigurationSetting("Key", "Value")));

            // Use the client mock
            ConfigurationClient client = mock.Object;
            ConfigurationSetting setting = client.Get("Key");
            Assert.AreEqual("Value", setting.Value);
        }
    }
}
