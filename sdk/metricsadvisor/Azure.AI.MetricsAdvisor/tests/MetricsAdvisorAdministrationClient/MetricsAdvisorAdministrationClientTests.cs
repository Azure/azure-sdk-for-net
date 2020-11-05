// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.AI.MetricsAdvisor.Administration;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.AI.MetricsAdvisor.Tests
{
    public class MetricsAdvisorAdministrationClientTests : ClientTestBase
    {
        public MetricsAdvisorAdministrationClientTests(bool isAsync) : base(isAsync)
        {
        }

        [Test]
        public void ConstructorValidatesArguments()
        {
            var endpoint = new Uri("http://notreal.azure.com");
            var credential = new MetricsAdvisorKeyCredential("fakeSubscriptionKey", "fakeApiKey");
            var options = new MetricsAdvisorClientsOptions();

            Assert.That(() => new MetricsAdvisorAdministrationClient(null, credential), Throws.InstanceOf<ArgumentNullException>());
            Assert.That(() => new MetricsAdvisorAdministrationClient(endpoint, null), Throws.InstanceOf<ArgumentNullException>());
            Assert.That(() => new MetricsAdvisorAdministrationClient(null, credential, options), Throws.InstanceOf<ArgumentNullException>());
            Assert.That(() => new MetricsAdvisorAdministrationClient(endpoint, null, options), Throws.InstanceOf<ArgumentNullException>());
        }

        [Test]
        public void ConstructorAllowsNullOptions()
        {
            var endpoint = new Uri("http://notreal.azure.com");
            var credential = new MetricsAdvisorKeyCredential("fakeSubscriptionKey", "fakeApiKey");

            Assert.That(() => new MetricsAdvisorAdministrationClient(endpoint, credential, null), Throws.Nothing);
        }
    }
}
