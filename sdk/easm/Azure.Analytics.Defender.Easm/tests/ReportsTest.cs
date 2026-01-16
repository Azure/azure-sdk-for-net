// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Azure.Analytics.Defender.Easm;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.Analytics.Defender.Easm.Tests
{
    internal class ReportsTest : EasmClientTest
    {
        private string metric;
        public ReportsTest(bool isAsync) : base(isAsync)
        {
            metric = "savedfilter_metric_51126";
        }
        [RecordedTest]
        public async System.Threading.Tasks.Task ReportsBillableTest()
        {
            ReportAssetSnapshotPayload ReportAssetSnapshotPayload = new ReportAssetSnapshotPayload();
            ReportAssetSnapshotPayload.Metric = metric;
            var response = await client.GetSnapshotAsync(ReportAssetSnapshotPayload);
            ReportAssetSnapshotResult reportAssetSnapshotResult = response.Value;
            Assert.That(reportAssetSnapshotResult, Is.Not.Null);
            Assert.That(reportAssetSnapshotResult.Metric, Is.EqualTo(metric));
            Assert.That(reportAssetSnapshotResult.Description, Is.Not.Null);
        }
        [RecordedTest]
        public async System.Threading.Tasks.Task ReportsSnapshotTest()
        {
            ReportAssetSnapshotPayload ReportAssetSnapshotPayload = new ReportAssetSnapshotPayload();
            ReportAssetSnapshotPayload.Metric = metric;
            var response = await client.GetSnapshotAsync(ReportAssetSnapshotPayload);
            ReportAssetSnapshotResult reportAssetSnapshotResult = response.Value;
            Assert.That(reportAssetSnapshotResult.DisplayName, Is.Not.Null);
            Assert.That(reportAssetSnapshotResult.Metric, Is.EqualTo(metric));
            Assert.That(reportAssetSnapshotResult.Description, Is.Not.Null);
            Assert.That(reportAssetSnapshotResult.Assets, Is.Not.Null);
        }
        [RecordedTest]
        public async System.Threading.Tasks.Task ReportsSummaryTest()
        {
            ReportAssetSummaryPayload reportAssetSummaryRequest = new ReportAssetSummaryPayload();
            reportAssetSummaryRequest.Metrics.Add(metric);
            var response = await client.GetSummaryAsync(reportAssetSummaryRequest);
            Assert.That(response.Value.AssetSummaries.Count > 0, Is.True);
        }
    }
}
