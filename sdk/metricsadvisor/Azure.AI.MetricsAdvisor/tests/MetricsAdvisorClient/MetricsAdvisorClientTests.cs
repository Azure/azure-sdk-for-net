// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.Identity;
using NUnit.Framework;

namespace Azure.AI.MetricsAdvisor.Tests
{
    public class MetricsAdvisorClientTests : ClientTestBase
    {
        public MetricsAdvisorClientTests(bool isAsync) : base(isAsync)
        {
        }

        [Test]
        public void ConstructorValidatesArguments()
        {
            var endpoint = new Uri("http://notreal.azure.com");
            var keyCredential = new MetricsAdvisorKeyCredential("fakeSubscriptionKey", "fakeApiKey");
            var tokenCredential = new DefaultAzureCredential();
            var options = new MetricsAdvisorClientsOptions();

            Assert.That(() => new MetricsAdvisorClient(null, keyCredential), Throws.InstanceOf<ArgumentNullException>());
            Assert.That(() => new MetricsAdvisorClient(endpoint, default(MetricsAdvisorKeyCredential)), Throws.InstanceOf<ArgumentNullException>());
            Assert.That(() => new MetricsAdvisorClient(null, keyCredential, options), Throws.InstanceOf<ArgumentNullException>());
            Assert.That(() => new MetricsAdvisorClient(endpoint, default(MetricsAdvisorKeyCredential), options), Throws.InstanceOf<ArgumentNullException>());
            Assert.That(() => new MetricsAdvisorClient(null, tokenCredential), Throws.InstanceOf<ArgumentNullException>());
            Assert.That(() => new MetricsAdvisorClient(endpoint, default(TokenCredential)), Throws.InstanceOf<ArgumentNullException>());
            Assert.That(() => new MetricsAdvisorClient(null, tokenCredential, options), Throws.InstanceOf<ArgumentNullException>());
            Assert.That(() => new MetricsAdvisorClient(endpoint, default(TokenCredential), options), Throws.InstanceOf<ArgumentNullException>());
        }

        [Test]
        public void ConstructorAllowsNullOptions()
        {
            var endpoint = new Uri("http://notreal.azure.com");
            var keyCredential = new MetricsAdvisorKeyCredential("fakeSubscriptionKey", "fakeApiKey");
            var tokenCredential = new DefaultAzureCredential();

            Assert.That(() => new MetricsAdvisorClient(endpoint, keyCredential, null), Throws.Nothing);
            Assert.That(() => new MetricsAdvisorClient(endpoint, tokenCredential, null), Throws.Nothing);
        }
    }
}
