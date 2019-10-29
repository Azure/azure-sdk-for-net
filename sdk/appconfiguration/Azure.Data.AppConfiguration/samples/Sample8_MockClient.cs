// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading;
using Moq;
using NUnit.Framework;

namespace Azure.Data.AppConfiguration.Samples
{
    public partial class ConfigurationSamples
    {
        [Test]
        /*
         * This sample illustrates how to use Moq to create a unit test that
         * mocks the reponse from a ConfigurationClient method.  For more
         * examples of mocking, see the Azure.Data.AppConfiguration.Tests project.
         */
        public void MockClient()
        {
            // Create a mock response.
            var mockResponse = new Mock<Response>();

            // Create a mock client.
            var mockClient = new Mock<ConfigurationClient>();

            // Set up a client method that will be called when GetConfigurationSetting is called on the mock client.
            mockClient.Setup(c => c.GetConfigurationSetting("Key", It.IsAny<string>(), It.IsAny<CancellationToken>()))
                .Returns(Response.FromValue(ConfigurationModelFactory.ConfigurationSetting("Key", "Value"), mockResponse.Object));

            // Use the mock client to validate client functionality without making a network call.
            ConfigurationClient client = mockClient.Object;
            ConfigurationSetting setting = client.GetConfigurationSetting("Key");
            Assert.AreEqual("Value", setting.Value);
        }
    }
}
