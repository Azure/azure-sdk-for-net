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
            ReportAssetSnapshotRequest reportAssetSnapshotRequest = new ReportAssetSnapshotRequest();
            reportAssetSnapshotRequest.Metric = metric;
            var response = await client.GetSnapshotAsync(reportAssetSnapshotRequest);
            ReportAssetSnapshotResult reportAssetSnapshotResult = response.Value;
            Assert.IsNotNull(reportAssetSnapshotResult);
            Assert.AreEqual(metric, reportAssetSnapshotResult.Metric);
            Assert.IsNotNull(reportAssetSnapshotResult.Description);
        }
        [RecordedTest]
        public async System.Threading.Tasks.Task ReportsSnapshotTest()
        {
            ReportAssetSnapshotRequest reportAssetSnapshotRequest = new ReportAssetSnapshotRequest();
            reportAssetSnapshotRequest.Metric = metric;
            var response = await client.GetSnapshotAsync(reportAssetSnapshotRequest);
            ReportAssetSnapshotResult reportAssetSnapshotResult = response.Value;
            Assert.IsNotNull(reportAssetSnapshotResult.DisplayName);
            Assert.AreEqual(metric, reportAssetSnapshotResult.Metric);
            Assert.IsNotNull(reportAssetSnapshotResult.Description);
            Assert.IsNotNull(reportAssetSnapshotResult.Assets);
        }
        [RecordedTest]
        public async System.Threading.Tasks.Task ReportsSummaryTest()
        {
            ReportAssetSummaryRequest reportAssetSummaryRequest = new ReportAssetSummaryRequest();
            reportAssetSummaryRequest.Metrics.Add(metric);
            var response = await client.GetSummaryAsync(reportAssetSummaryRequest);
            Assert.IsTrue(response.Value.AssetSummaries.Count > 0);
        }
    }
}
