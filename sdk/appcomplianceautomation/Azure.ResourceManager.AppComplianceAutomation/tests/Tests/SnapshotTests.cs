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
            ReportResource report = Client.GetReportResource(ReportResource.CreateResourceIdentifier("sdk-report9634"));
            SnapshotResourceCollection snapshots = report.GetSnapshotResources();
            await foreach (SnapshotResource resource in snapshots.GetAllAsync())
            {
                count++;
                if (latestSnapshotName == "")
                {
                    latestSnapshotName = resource.Data.Name;
                }
            }
            Assert.Greater(count, 0);

            // Get snapshot
            SnapshotResource snapshot = await snapshots.GetAsync(latestSnapshotName);
            Assert.IsNotNull(snapshot);
        }
    }
}
