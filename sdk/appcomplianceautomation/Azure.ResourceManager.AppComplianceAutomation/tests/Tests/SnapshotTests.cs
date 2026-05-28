// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.AppComplianceAutomation;
using NUnit.Framework;
using Azure.ResourceManager.AppComplianceAutomation.Models;
using System.Collections.Generic;
using Azure.Core;

namespace Azure.ResourceManager.AppComplianceAutomation.Tests.Tests
{
    public class SnapshotTests : AppComplianceAutomationManagementTestBase
    {
        public SnapshotTests(bool isAsync) : base(isAsync)
        {
        }

        private TestContext testContextInstance;

        public TestContext TestContext
        {
            get { return testContextInstance; }
            set { testContextInstance = value; }
        }

        [SetUp]
        public void Init()
        {
            InitializeUserTokenClients();
        }

        [OneTimeTearDown]
        public void Cleanup()
        {
        }

        [TestCase]
        public async Task GetSnapshot()
        {
            // List snapshots
            int count = 0;
            string latestSnapshotName = "";
            AppComplianceReportResource report = Client.GetAppComplianceReportResource(AppComplianceReportResource.CreateResourceIdentifier("sdk-test-report"));
            AppComplianceReportSnapshotCollection snapshots = report.GetAppComplianceReportSnapshots();
            await foreach (AppComplianceReportSnapshotResource resource in snapshots.GetAllAsync(null))
            {
                count++;
                if (latestSnapshotName == "")
                {
                    latestSnapshotName = resource.Data.Name;
                }
            }
            Assert.Greater(count, 0);

            // Get snapshot
            AppComplianceReportSnapshotResource snapshot = await snapshots.GetAsync(latestSnapshotName);
            Assert.IsNotNull(snapshot);

            // Download snapshot
            SnapshotDownloadRequestContent content = new SnapshotDownloadRequestContent(AppComplianceDownloadType.ComplianceDetailedPdfReport);
            content.OfferGuid = null;
            content.ReportCreatorTenantId = new Guid("72f988bf-86f1-41af-91ab-2d7cd011db47");

            ArmOperation<AppComplianceDownloadResult> response = await snapshot.DownloadAsync(WaitUntil.Completed, content);
            Assert.IsNotNull(response);
        }
    }
}
