// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core.TestFramework;
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
            var credential = new MetricsAdvisorKeyCredential("fakeSubscriptionKey", "fakeApiKey");
            var options = new MetricsAdvisorClientsOptions();

            Assert.That(() => new MetricsAdvisorClient(null, credential), Throws.InstanceOf<ArgumentNullException>());
            Assert.That(() => new MetricsAdvisorClient(endpoint, null), Throws.InstanceOf<ArgumentNullException>());
            Assert.That(() => new MetricsAdvisorClient(null, credential, options), Throws.InstanceOf<ArgumentNullException>());
            Assert.That(() => new MetricsAdvisorClient(endpoint, null, options), Throws.InstanceOf<ArgumentNullException>());
        }

        [Test]
        public void ConstructorAllowsNullOptions()
        {
            var endpoint = new Uri("http://notreal.azure.com");
            var credential = new MetricsAdvisorKeyCredential("fakeSubscriptionKey", "fakeApiKey");

            Assert.That(() => new MetricsAdvisorClient(endpoint, credential, null), Throws.Nothing);
        }
    }
}
