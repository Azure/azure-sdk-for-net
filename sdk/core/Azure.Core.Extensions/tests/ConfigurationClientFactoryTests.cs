// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using Microsoft.Extensions.Configuration;
using NUnit.Framework;

namespace Azure.Core.Extensions.Tests
{
    public class ConfigurationClientFactoryTests
    {
        [Test]
        public void SelectsConstructorBaseOnConfiguration()
        {
            IConfiguration configuration = GetConfiguration(new KeyValuePair<string, string>("connectionstring", "CS"));

            var factory = new ConfigurationClientFactory();
            var clientOptions = new TestClientOptions();
            var client = (TestClient)factory.CreateClient(typeof(TestClient), typeof(TestClientOptions), clientOptions, configuration);

            Assert.AreEqual("CS", client.ConnectionString);
            Assert.AreSame(clientOptions, client.Options);
        }

        [Test]
        public void ConvertsUriConstructorParameters()
        {
            IConfiguration configuration = GetConfiguration(new KeyValuePair<string, string>("uri", "http://localhost"));

            var factory = new ConfigurationClientFactory();
            var clientOptions = new TestClientOptions();
            var client = (TestClient)factory.CreateClient(typeof(TestClient), typeof(TestClientOptions), clientOptions, configuration);

            Assert.AreEqual("http://localhost/", client.Uri.ToString());
            Assert.AreSame(clientOptions, client.Options);
        }

        [Test]
        public void ThrowsExceptionWithInformationAboutArguments()
        {
            IConfiguration configuration = GetConfiguration();

            var factory = new ConfigurationClientFactory();
            var clientOptions = new TestClientOptions();
            var exception = Assert.Throws<InvalidOperationException>(() => factory.CreateClient(typeof(TestClient), typeof(TestClientOptions), clientOptions, configuration));
            Assert.AreEqual("Unable to find matching constructor. Define one of the follow sets of configuration parameters:" + Environment.NewLine +
                "1. connectionString" + Environment.NewLine +
                "2. uri" + Environment.NewLine,
                exception.Message);
        }

        private IConfiguration GetConfiguration(params KeyValuePair<string, string>[] items)
        {
            return new ConfigurationBuilder().AddInMemoryCollection(items).Build();
        }
    }
}
