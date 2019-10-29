﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

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
            mock.Setup(c => c.GetConfigurationSetting("Key", It.IsAny<string>(), It.IsAny<CancellationToken>()))
                .Returns(Response.FromValue(ConfigurationModelFactory.ConfigurationSetting("Key", "Value"), mockResponse.Object));

            // Use the client mock
            ConfigurationClient client = mock.Object;
            ConfigurationSetting setting = client.GetConfigurationSetting("Key");
            Assert.AreEqual("Value", setting.Value);
        }
    }
}
