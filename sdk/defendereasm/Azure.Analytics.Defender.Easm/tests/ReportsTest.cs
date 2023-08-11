// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Azure.Analytics.Defender.Easm.Models;
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
        public async Task ReportsBillableTest()
        {
            Response<ReportBillableAssetSummaryResult> response = await client.GetBillableAsync();
            Assert.IsTrue(response.Value.AssetSummaries.Count > 0);
        }

        [RecordedTest]
        public async Task ReportsSnapshotTest()
        {
            ReportAssetSnapshotRequest reportAssetSnapshotRequest = new ReportAssetSnapshotRequest();
            reportAssetSnapshotRequest.Metric = metric;
            //reportAssetSnapshotRequest.Page = 0;
            //reportAssetSnapshotRequest.Size = 25;
            Response<ReportAssetSnapshotResult> response = await client.GetSnapshotAsync(reportAssetSnapshotRequest);
            ReportAssetSnapshotResult reportAssetSnapshotResponse = response.Value;
            Assert.IsNotNull(reportAssetSnapshotResponse.DisplayName);
            Assert.AreEqual(metric, reportAssetSnapshotResponse.Metric);
            Assert.IsNotNull(reportAssetSnapshotResponse.Description);
            Assert.IsNotNull(reportAssetSnapshotResponse.Assets);
        }

        [RecordedTest]
        public async Task ReportsSummaryTest()
        {
            ReportAssetSummaryRequest reportAssetSummaryRequest = new ReportAssetSummaryRequest();
            reportAssetSummaryRequest.Metrics.Add(metric);
            Response<ReportAssetSummaryResult> response = await client.GetSummaryAsync(reportAssetSummaryRequest);
            Assert.IsTrue(response.Value.AssetSummaries.Count > 0);
        }
    }
}
