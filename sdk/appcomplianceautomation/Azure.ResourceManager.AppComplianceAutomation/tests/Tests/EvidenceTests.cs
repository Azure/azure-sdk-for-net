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
    public class EvidenceTests: AppComplianceAutomationManagementTestBase
    {
        public EvidenceTests(bool isAsync) : base(isAsync)
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
        public async Task EvidenceCRUD()
        {
            // Create evidence
            // Create evidence: prepare data
            string reportName = "sdk-test-report";
            string evidenceName = "6affe3ce-66e9-40fb-b6d0-1ae03159f2b0";
            ResourceIdentifier appComplianceReportEvidenceResourceId = AppComplianceReportEvidenceResource.CreateResourceIdentifier(reportName, evidenceName);
            AppComplianceReportEvidenceResource appComplianceReportEvidence = Client.GetAppComplianceReportEvidenceResource(appComplianceReportEvidenceResourceId);
            AppComplianceReportEvidenceProperties properties = new AppComplianceReportEvidenceProperties();
            properties.ControlId = "Operational_Security_1";
            properties.ResponsibilityId = "Operational_Security_1_manual_cr";
            properties.FilePath = "acatevidence/sdk-test-report/Operational_Security_1/Operational_Security_1_manual_cr/6affe3ce-66e9-40fb-b6d0-1ae03159f2b0/feedback1.png";
            properties.EvidenceType = AppComplianceReportEvidenceType.File;
            AppComplianceReportEvidenceData data = new AppComplianceReportEvidenceData(properties);
            // Create evidence: send request
            ArmOperation<AppComplianceReportEvidenceResource> response = await appComplianceReportEvidence.UpdateAsync(WaitUntil.Completed, data);
            // Create evidence: verify result
            AppComplianceReportEvidenceResource evidenceResource = response.Value;
            Assert.AreEqual(evidenceName, evidenceResource.Data.Name);

            // Get evidence
            // Get evidence: send request
            AppComplianceReportEvidenceResource getResult = await appComplianceReportEvidence.GetAsync();
            // Get evidence: verify result
            Assert.AreEqual(evidenceName, getResult.Data.Name);

            // download evidence current ppe cannot download evidence
            EvidenceFileDownloadRequestContent content = new EvidenceFileDownloadRequestContent();
            EvidenceFileDownloadResult download = await appComplianceReportEvidence.DownloadAsync(content);
            Assert.IsNotNull(download);

            // Delete evidence
            // Delete evidence: send request
            var operation = await appComplianceReportEvidence.DeleteAsync(WaitUntil.Completed);
            // Delete evidence: verify result
            Assert.IsTrue(operation.HasCompleted);
        }
    }
}
