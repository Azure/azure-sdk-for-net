// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using Azure.Core;
using Microsoft.Extensions.Azure;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Moq;
using NUnit.Framework;

namespace Microsoft.Azure.WebJobs.Extensions.WebPubSub.Tests
{
    public class WebPubSubServiceAccessOptionsSetupTests
    {
        private const string TestConnectionString = "Endpoint=https://test.webpubsub.azure.com;AccessKey=test-key;";
        private const string TestServiceUri = "https://test.webpubsub.azure.com";
        private const string TestHub = "TestHub";

        [Test]
        public void Configure_WithConnectionStringInPublicOptions_SetsWebPubSubAccess()
        {
            // Arrange
            var configuration = CreateConfiguration();
            var publicOptions = CreatePublicOptions(connectionString: TestConnectionString);
            var azureComponentFactory = Mock.Of<AzureComponentFactory>();
            var nameResolver = new Mock<INameResolver>().Object;

            var setup = new WebPubSubServiceAccessOptionsSetup(
                configuration,
                azureComponentFactory,
                nameResolver,
                publicOptions);

            var options = new WebPubSubServiceAccessOptions();

            // Act
            setup.Configure(options);

            // Assert
            Assert.IsNotNull(options.WebPubSubAccess);
            Assert.AreEqual(new System.Uri(TestServiceUri), options.WebPubSubAccess.ServiceEndpoint);
        }

        [Test]
        public void Configure_WithConnectionStringInConfiguration_SetsWebPubSubAccess()
        {
            // Arrange
            var configuration = CreateConfiguration(new Dictionary<string, string>
            {
                { Constants.WebPubSubConnectionStringName, TestConnectionString }
            });
            var publicOptions = CreatePublicOptions();
            var azureComponentFactory = Mock.Of<AzureComponentFactory>();
            var nameResolver = new Mock<INameResolver>().Object;

            var setup = new WebPubSubServiceAccessOptionsSetup(
                configuration,
                azureComponentFactory,
                nameResolver,
                publicOptions);

            var options = new WebPubSubServiceAccessOptions();

            // Act
            setup.Configure(options);

            // Assert
            Assert.IsNotNull(options.WebPubSubAccess);
            Assert.AreEqual(new System.Uri(TestServiceUri), options.WebPubSubAccess.ServiceEndpoint);
        }

        [Test]
        public void Configure_WithServiceUriInConfiguration_SetsWebPubSubAccess()
        {
            // Arrange
            var mockCredential = Mock.Of<TokenCredential>();
            var configuration = CreateConfiguration(new Dictionary<string, string>
            {
                { $"{Constants.WebPubSubConnectionStringName}:{Constants.ServiceUriKey}", TestServiceUri }
            });
            var publicOptions = CreatePublicOptions();
            var azureComponentFactory = Mock.Of<AzureComponentFactory>(f =>
                f.CreateTokenCredential(It.IsAny<IConfiguration>()) == mockCredential);
            var nameResolver = new Mock<INameResolver>().Object;

            var setup = new WebPubSubServiceAccessOptionsSetup(
                configuration,
                azureComponentFactory,
                nameResolver,
                publicOptions);

            var options = new WebPubSubServiceAccessOptions();

            // Act
            setup.Configure(options);

            // Assert
            Assert.IsNotNull(options.WebPubSubAccess);
            Assert.AreEqual(new System.Uri(TestServiceUri), options.WebPubSubAccess.ServiceEndpoint);
            Assert.IsInstanceOf<IdentityCredential>(options.WebPubSubAccess.Credential);
            Assert.AreEqual(mockCredential, ((IdentityCredential)options.WebPubSubAccess.Credential).TokenCredential);
        }

        [Test]
        public void Configure_ConnectionStringTakesPrecedenceOverConfiguration()
        {
            // Arrange
            var mockCredential = Mock.Of<TokenCredential>();
            var configuration = CreateConfiguration(new Dictionary<string, string>
            {
                { $"{Constants.WebPubSubConnectionStringName}:{Constants.ServiceUriKey}", "https://other.webpubsub.azure.com" }
            });
            var publicOptions = CreatePublicOptions(connectionString: TestConnectionString);
            var azureComponentFactory = Mock.Of<AzureComponentFactory>(f =>
                f.CreateTokenCredential(It.IsAny<IConfiguration>()) == mockCredential);
            var nameResolver = new Mock<INameResolver>().Object;

            var setup = new WebPubSubServiceAccessOptionsSetup(
                configuration,
                azureComponentFactory,
                nameResolver,
                publicOptions);

            var options = new WebPubSubServiceAccessOptions();

            // Act
            setup.Configure(options);

            // Assert
            Assert.IsNotNull(options.WebPubSubAccess);
            Assert.AreEqual(new System.Uri(TestServiceUri), options.WebPubSubAccess.ServiceEndpoint);
            Assert.IsInstanceOf<KeyCredential>(options.WebPubSubAccess.Credential);
        }

        [Test]
        public void Configure_WithNoConnectionInfo_DoesNotSetWebPubSubAccess()
        {
            // Arrange
            var configuration = CreateConfiguration();
            var publicOptions = CreatePublicOptions();
            var azureComponentFactory = Mock.Of<AzureComponentFactory>();
            var nameResolver = new Mock<INameResolver>().Object;

            var setup = new WebPubSubServiceAccessOptionsSetup(
                configuration,
                azureComponentFactory,
                nameResolver,
                publicOptions);

            var options = new WebPubSubServiceAccessOptions();

            // Act
            setup.Configure(options);

            // Assert
            Assert.IsNull(options.WebPubSubAccess);
        }

        [Test]
        public void Configure_WithHubInPublicOptions_SetsHub()
        {
            // Arrange
            var configuration = CreateConfiguration();
            var publicOptions = CreatePublicOptions(hub: TestHub);
            var azureComponentFactory = Mock.Of<AzureComponentFactory>();
            var nameResolver = new Mock<INameResolver>().Object;

            var setup = new WebPubSubServiceAccessOptionsSetup(
                configuration,
                azureComponentFactory,
                nameResolver,
                publicOptions);

            var options = new WebPubSubServiceAccessOptions();

            // Act
            setup.Configure(options);

            // Assert
            Assert.AreEqual(TestHub, options.Hub);
        }

        [Test]
        public void Configure_WithHubInNameResolver_SetsHub()
        {
            // Arrange
            var configuration = CreateConfiguration();
            var publicOptions = CreatePublicOptions();
            var azureComponentFactory = Mock.Of<AzureComponentFactory>();
            var mockNameResolver = new Mock<INameResolver>();
            mockNameResolver.Setup(x => x.Resolve(Constants.HubNameStringName)).Returns(TestHub);

            var setup = new WebPubSubServiceAccessOptionsSetup(
                configuration,
                azureComponentFactory,
                mockNameResolver.Object,
                publicOptions);

            var options = new WebPubSubServiceAccessOptions();

            // Act
            setup.Configure(options);

            // Assert
            Assert.AreEqual(TestHub, options.Hub);
        }

        [Test]
        public void Configure_HubInPublicOptionsTakesPrecedenceOverNameResolver()
        {
            // Arrange
            var configuration = CreateConfiguration();
            var publicOptions = CreatePublicOptions(hub: TestHub);
            var azureComponentFactory = Mock.Of<AzureComponentFactory>();
            var mockNameResolver = new Mock<INameResolver>();
            mockNameResolver.Setup(x => x.Resolve(Constants.HubNameStringName)).Returns("OtherHub");

            var setup = new WebPubSubServiceAccessOptionsSetup(
                configuration,
                azureComponentFactory,
                mockNameResolver.Object,
                publicOptions);

            var options = new WebPubSubServiceAccessOptions();

            // Act
            setup.Configure(options);

            // Assert
            Assert.AreEqual(TestHub, options.Hub);
        }

        private static IConfiguration CreateConfiguration(Dictionary<string, string> values = null)
        {
            var builder = new ConfigurationBuilder();
            if (values != null)
            {
                builder.AddInMemoryCollection(values);
            }
            return builder.Build();
        }

        private static IOptionsMonitor<WebPubSubFunctionsOptions> CreatePublicOptions(
            string connectionString = null,
            string hub = null)
        {
            var options = new WebPubSubFunctionsOptions
            {
                ConnectionString = connectionString,
                Hub = hub
            };

            var mockOptionsMonitor = new Mock<IOptionsMonitor<WebPubSubFunctionsOptions>>();
            mockOptionsMonitor.Setup(x => x.CurrentValue).Returns(options);
            return mockOptionsMonitor.Object;
        }
    }
}
