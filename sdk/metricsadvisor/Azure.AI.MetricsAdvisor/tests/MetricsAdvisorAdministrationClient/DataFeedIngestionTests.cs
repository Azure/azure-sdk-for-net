// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Threading;
using Azure.AI.MetricsAdvisor.Administration;
using Azure.AI.MetricsAdvisor.Models;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.AI.MetricsAdvisor.Tests
{
    public class DataFeedIngestionTests : ClientTestBase
    {
        public DataFeedIngestionTests(bool isAsync) : base(isAsync)
        {
        }

        private string FakeGuid => "00000000-0000-0000-0000-000000000000";

        [Test]
        public void GetDataFeedIngestionProgressValidatesArguments()
        {
            MetricsAdvisorAdministrationClient adminClient = GetMetricsAdvisorAdministrationClient();

            Assert.That(() => adminClient.GetDataFeedIngestionProgressAsync(null), Throws.InstanceOf<ArgumentNullException>());
            Assert.That(() => adminClient.GetDataFeedIngestionProgressAsync(""), Throws.InstanceOf<ArgumentException>());
            Assert.That(() => adminClient.GetDataFeedIngestionProgressAsync("dataFeedId"), Throws.InstanceOf<ArgumentException>().With.InnerException.TypeOf(typeof(FormatException)));

            Assert.That(() => adminClient.GetDataFeedIngestionProgress(null), Throws.InstanceOf<ArgumentNullException>());
            Assert.That(() => adminClient.GetDataFeedIngestionProgress(""), Throws.InstanceOf<ArgumentException>());
            Assert.That(() => adminClient.GetDataFeedIngestionProgress("dataFeedId"), Throws.InstanceOf<ArgumentException>().With.InnerException.TypeOf(typeof(FormatException)));
        }

        [Test]
        public void GetDataFeedIngestionProgressRespectsTheCancellationToken()
        {
            MetricsAdvisorAdministrationClient adminClient = GetMetricsAdvisorAdministrationClient();

            using var cancellationSource = new CancellationTokenSource();
            cancellationSource.Cancel();

            Assert.That(() => adminClient.GetDataFeedIngestionProgressAsync(FakeGuid, cancellationSource.Token), Throws.InstanceOf<OperationCanceledException>());
            Assert.That(() => adminClient.GetDataFeedIngestionProgress(FakeGuid, cancellationSource.Token), Throws.InstanceOf<OperationCanceledException>());
        }

        [Test]
        public void RefreshDataIngestionValidatesArguments()
        {
            MetricsAdvisorAdministrationClient adminClient = GetMetricsAdvisorAdministrationClient();

            Assert.That(() => adminClient.RefreshDataFeedIngestionAsync(null, default, default), Throws.InstanceOf<ArgumentNullException>());
            Assert.That(() => adminClient.RefreshDataFeedIngestionAsync("", default, default), Throws.InstanceOf<ArgumentException>());
            Assert.That(() => adminClient.RefreshDataFeedIngestionAsync("dataFeedId", default, default), Throws.InstanceOf<ArgumentException>().With.InnerException.TypeOf(typeof(FormatException)));

            Assert.That(() => adminClient.RefreshDataFeedIngestion(null, default, default), Throws.InstanceOf<ArgumentNullException>());
            Assert.That(() => adminClient.RefreshDataFeedIngestion("", default, default), Throws.InstanceOf<ArgumentException>());
            Assert.That(() => adminClient.RefreshDataFeedIngestion("dataFeedId", default, default), Throws.InstanceOf<ArgumentException>().With.InnerException.TypeOf(typeof(FormatException)));
        }

        [Test]
        public void RefreshDataIngestionRespectsTheCancellationToken()
        {
            MetricsAdvisorAdministrationClient adminClient = GetMetricsAdvisorAdministrationClient();

            using var cancellationSource = new CancellationTokenSource();
            cancellationSource.Cancel();

            Assert.That(() => adminClient.RefreshDataFeedIngestionAsync(FakeGuid, default, default, cancellationSource.Token), Throws.InstanceOf<OperationCanceledException>());
            Assert.That(() => adminClient.RefreshDataFeedIngestion(FakeGuid, default, default, cancellationSource.Token), Throws.InstanceOf<OperationCanceledException>());
        }

        [Test]
        public void GetDataFeedIngestionStatusesValidatesArguments()
        {
            MetricsAdvisorAdministrationClient adminClient = GetMetricsAdvisorAdministrationClient();

            var options = new GetDataFeedIngestionStatusesOptions(default, default);

            Assert.That(() => adminClient.GetDataFeedIngestionStatusesAsync(null, options), Throws.InstanceOf<ArgumentNullException>());
            Assert.That(() => adminClient.GetDataFeedIngestionStatusesAsync("", options), Throws.InstanceOf<ArgumentException>());
            Assert.That(() => adminClient.GetDataFeedIngestionStatusesAsync("dataFeedId", options), Throws.InstanceOf<ArgumentException>().With.InnerException.TypeOf(typeof(FormatException)));
            Assert.That(() => adminClient.GetDataFeedIngestionStatusesAsync(FakeGuid, null), Throws.InstanceOf<ArgumentNullException>());

            Assert.That(() => adminClient.GetDataFeedIngestionStatuses(null, options), Throws.InstanceOf<ArgumentNullException>());
            Assert.That(() => adminClient.GetDataFeedIngestionStatuses("", options), Throws.InstanceOf<ArgumentException>());
            Assert.That(() => adminClient.GetDataFeedIngestionStatuses("dataFeedId", options), Throws.InstanceOf<ArgumentException>().With.InnerException.TypeOf(typeof(FormatException)));
            Assert.That(() => adminClient.GetDataFeedIngestionStatuses(FakeGuid, null), Throws.InstanceOf<ArgumentNullException>());
        }

        [Test]
        public void GetDataFeedIngestionStatusesRespectsTheCancellationToken()
        {
            MetricsAdvisorAdministrationClient adminClient = GetMetricsAdvisorAdministrationClient();

            var options = new GetDataFeedIngestionStatusesOptions(default, default);

            using var cancellationSource = new CancellationTokenSource();
            cancellationSource.Cancel();

            IAsyncEnumerator<DataFeedIngestionStatus> asyncEnumerator = adminClient.GetDataFeedIngestionStatusesAsync(FakeGuid, options, cancellationSource.Token).GetAsyncEnumerator();
            Assert.That(async () => await asyncEnumerator.MoveNextAsync(), Throws.InstanceOf<OperationCanceledException>());

            IEnumerator<DataFeedIngestionStatus> enumerator = adminClient.GetDataFeedIngestionStatuses(FakeGuid, options, cancellationSource.Token).GetEnumerator();
            Assert.That(() => enumerator.MoveNext(), Throws.InstanceOf<OperationCanceledException>());
        }

        private MetricsAdvisorAdministrationClient GetMetricsAdvisorAdministrationClient()
        {
            var fakeEndpoint = new Uri("http://notreal.azure.com");
            var fakeCredential = new MetricsAdvisorKeyCredential("fakeSubscriptionKey", "fakeApiKey");

            return new MetricsAdvisorAdministrationClient(fakeEndpoint, fakeCredential);
        }
    }
}
