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
            ReportResourceCollection reports = tenant.GetReportResources();

            // create report
            List<ResourceMetadata> resources = new List<ResourceMetadata>();
            Dictionary<string, string> tags = new Dictionary<string, string>();
            resources.Add(new ResourceMetadata(
                "/subscriptions/f744fbde-a95f-437e-8fcf-38f9324e3d9c/resourceGroups/sdk-test/providers/Microsoft.Storage/storageAccounts/sdkteststorageaccount",
                "microsoft.storage/storageaccounts",
                "StorageV2",
                "sdkteststorageaccount",
                tags ,null));
            DateTime univDateTime = new DateTime(2022, 01, 01, 0, 0, 0, DateTimeKind.Utc);
            ReportProperties properties = new ReportProperties("GMT Standard Time", new DateTimeOffset(univDateTime), resources);
            ArmOperation<ReportResource> response = await reports.CreateOrUpdateAsync(WaitUntil.Completed, reportName, new ReportResourceData(properties));

            // get report
            Response<ReportResource> getResponse = await reports.GetAsync(reportName);
            ReportResource report = getResponse.Value;
            Assert.AreEqual(report.Data.Name, reportName);

            // delete report
            var operation = await report.DeleteAsync(WaitUntil.Completed);
            Assert.IsTrue(operation.HasCompleted);
        }
    }
}
