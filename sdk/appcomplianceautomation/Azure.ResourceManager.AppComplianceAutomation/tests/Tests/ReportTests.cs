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
using System.Linq;

namespace Azure.ResourceManager.AppComplianceAutomation.Tests.Tests
{
    public class ReportTests : AppComplianceAutomationManagementTestBase
    {
        public ReportTests(bool isAsync) : base(isAsync)
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
        public async Task ReportCRUD()
        {
            string reportName = Recording.GenerateAssetName("sdk-report");
            TenantCollection tenantCollection = Client.GetTenants();
            var tenants = await tenantCollection.GetAllAsync().ToEnumerableAsync();
            var tenant = tenants.FirstOrDefault();
            AppComplianceReportCollection reports = tenant.GetAppComplianceReports();

            // Create report
            // Create report: prepare data
            List<ReportResourceMetadata> resources = new List<ReportResourceMetadata>();
            Dictionary<string, string> tags = new Dictionary<string, string>();
            resources.Add(new ReportResourceMetadata(
                new ResourceIdentifier("/subscriptions/120b982f-6bd3-4b60-98d2-a7b7ecd6c78e/resourcegroups/sdk-test/providers/Microsoft.Storage/storageAccounts/appcompliancetestsa"),
                "microsoft.storage/storageaccounts",
                "StorageV2",
                ReportResourceOrigin.Azure,
                "appcompliancetestsa",
                null));
            DateTime univDateTime = new DateTime(2022, 01, 01, 0, 0, 0, DateTimeKind.Utc);
            // Create report: send request
            ArmOperation<AppComplianceReportResource> response = await reports.CreateOrUpdateAsync(WaitUntil.Completed, reportName,
                new AppComplianceReportData(new AppComplianceReportProperties(new DateTimeOffset(univDateTime), "GMT Standard Time", resources)));
            // Create report: verify result
            AppComplianceReportResource reportResource = response.Value;
            Assert.AreEqual(reportResource.Data.Name, reportName);

            // Get report
            // Get report: send request
            Response<AppComplianceReportResource> getResponse = await reports.GetAsync(reportName);
            // Get report: verify result
            AppComplianceReportResource report = getResponse.Value;
            Assert.AreEqual(report.Data.Name, reportName);

            // Delete report
            // Delete report: send request
            var operation = await report.DeleteAsync(WaitUntil.Completed);
            // Delete report: verify result
            Assert.IsTrue(operation.HasCompleted);
        }
    }
}
