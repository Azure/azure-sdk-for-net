// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Threading;
using Azure.AI.MetricsAdvisor.Models;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.AI.MetricsAdvisor.Tests
{
    public class MetricFeedbackTests : ClientTestBase
    {
        public MetricFeedbackTests(bool isAsync) : base(isAsync)
        {
        }

        private string FakeGuid => "00000000-0000-0000-0000-000000000000";

        [Test]
        public void AddFeedbackValidatesArguments()
        {
            MetricsAdvisorClient client = GetMetricsAdvisorClient();

            Assert.That(() => client.AddFeedbackAsync(null), Throws.InstanceOf<ArgumentNullException>());

            Assert.That(() => client.AddFeedback(null), Throws.InstanceOf<ArgumentNullException>());
        }

        [Test]
        public void AddFeedbackRespectsTheCancellationToken()
        {
            MetricsAdvisorClient client = GetMetricsAdvisorClient();

            var filter = new FeedbackDimensionFilter(new DimensionKey());
            var feedback = new MetricCommentFeedback(FakeGuid, filter, "comment");

            using var cancellationSource = new CancellationTokenSource();
            cancellationSource.Cancel();

            Assert.That(() => client.AddFeedbackAsync(feedback, cancellationSource.Token), Throws.InstanceOf<OperationCanceledException>());
            Assert.That(() => client.AddFeedback(feedback, cancellationSource.Token), Throws.InstanceOf<OperationCanceledException>());
        }

        [Test]
        public void GetFeedbackValidatesArguments()
        {
            MetricsAdvisorClient client = GetMetricsAdvisorClient();

            Assert.That(() => client.GetFeedbackAsync(null), Throws.InstanceOf<ArgumentNullException>());
            Assert.That(() => client.GetFeedbackAsync(""), Throws.InstanceOf<ArgumentException>());
            Assert.That(() => client.GetFeedbackAsync("feedbackId"), Throws.InstanceOf<ArgumentException>().With.InnerException.TypeOf(typeof(FormatException)));

            Assert.That(() => client.GetFeedback(null), Throws.InstanceOf<ArgumentNullException>());
            Assert.That(() => client.GetFeedback(""), Throws.InstanceOf<ArgumentException>());
            Assert.That(() => client.GetFeedback("feedbackId"), Throws.InstanceOf<ArgumentException>().With.InnerException.TypeOf(typeof(FormatException)));
        }

        [Test]
        public void GetFeedbackRespectsTheCancellationToken()
        {
            MetricsAdvisorClient client = GetMetricsAdvisorClient();

            using var cancellationSource = new CancellationTokenSource();
            cancellationSource.Cancel();

            Assert.That(() => client.GetFeedbackAsync(FakeGuid, cancellationSource.Token), Throws.InstanceOf<OperationCanceledException>());
            Assert.That(() => client.GetFeedback(FakeGuid, cancellationSource.Token), Throws.InstanceOf<OperationCanceledException>());
        }

        [Test]
        public void GetAllFeedbackValidatesArguments()
        {
            MetricsAdvisorClient client = GetMetricsAdvisorClient();

            Assert.That(() => client.GetAllFeedbackAsync(null), Throws.InstanceOf<ArgumentNullException>());
            Assert.That(() => client.GetAllFeedbackAsync(""), Throws.InstanceOf<ArgumentException>());
            Assert.That(() => client.GetAllFeedbackAsync("metricId"), Throws.InstanceOf<ArgumentException>().With.InnerException.TypeOf(typeof(FormatException)));

            Assert.That(() => client.GetAllFeedback(null), Throws.InstanceOf<ArgumentNullException>());
            Assert.That(() => client.GetAllFeedback(""), Throws.InstanceOf<ArgumentException>());
            Assert.That(() => client.GetAllFeedback("metricId"), Throws.InstanceOf<ArgumentException>().With.InnerException.TypeOf(typeof(FormatException)));
        }

        [Test]
        public void GetAllFeedbackRespectsTheCancellationToken()
        {
            MetricsAdvisorClient client = GetMetricsAdvisorClient();

            using var cancellationSource = new CancellationTokenSource();
            cancellationSource.Cancel();

            IAsyncEnumerator<MetricFeedback> asyncEnumerator = client.GetAllFeedbackAsync(FakeGuid, cancellationToken: cancellationSource.Token).GetAsyncEnumerator();
            Assert.That(async () => await asyncEnumerator.MoveNextAsync(), Throws.InstanceOf<OperationCanceledException>());

            IEnumerator<MetricFeedback> enumerator = client.GetAllFeedback(FakeGuid, cancellationToken: cancellationSource.Token).GetEnumerator();
            Assert.That(() => enumerator.MoveNext(), Throws.InstanceOf<OperationCanceledException>());
        }

        private MetricsAdvisorClient GetMetricsAdvisorClient()
        {
            var fakeEndpoint = new Uri("http://notreal.azure.com");
            var fakeCredential = new MetricsAdvisorKeyCredential("fakeSubscriptionKey", "fakeApiKey");

            return new MetricsAdvisorClient(fakeEndpoint, fakeCredential);
        }
    }
}
