// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.AI.MetricsAdvisor.Tests
{
    public class MetricFeedbackTests : ClientTestBase
    {
        public MetricFeedbackTests(bool isAsync) : base(isAsync)
        {
        }

        [Test]
        public void AddFeedbackValidatesArguments()
        {
            MetricsAdvisorClient client = GetMetricsAdvisorClient();

            Assert.That(() => client.AddFeedbackAsync(null), Throws.InstanceOf<ArgumentNullException>());

            Assert.That(() => client.AddFeedback(null), Throws.InstanceOf<ArgumentNullException>());
        }

        [Test]
        public void GetFeedbackValidatesArguments()
        {
            MetricsAdvisorClient client = GetMetricsAdvisorClient();

            Assert.That(() => client.GetFeedbackAsync(null), Throws.InstanceOf<ArgumentNullException>());
            Assert.That(() => client.GetFeedbackAsync(""), Throws.InstanceOf<ArgumentException>());

            Assert.That(() => client.GetFeedback(null), Throws.InstanceOf<ArgumentNullException>());
            Assert.That(() => client.GetFeedback(""), Throws.InstanceOf<ArgumentException>());
        }

        [Test]
        public void GetAllFeedbackValidatesArguments()
        {
            MetricsAdvisorClient client = GetMetricsAdvisorClient();

            Assert.That(() => client.GetAllFeedbackAsync(null), Throws.InstanceOf<ArgumentNullException>());
            Assert.That(() => client.GetAllFeedbackAsync(""), Throws.InstanceOf<ArgumentException>());

            Assert.That(() => client.GetAllFeedback(null), Throws.InstanceOf<ArgumentNullException>());
            Assert.That(() => client.GetAllFeedback(""), Throws.InstanceOf<ArgumentException>());
        }

        private MetricsAdvisorClient GetMetricsAdvisorClient()
        {
            var fakeEndpoint = new Uri("http://notreal.azure.com");
            var fakeCredential = new MetricsAdvisorKeyCredential("fakeSubscriptionKey", "fakeApiKey");

            return new MetricsAdvisorClient(fakeEndpoint, fakeCredential);
        }
    }
}
