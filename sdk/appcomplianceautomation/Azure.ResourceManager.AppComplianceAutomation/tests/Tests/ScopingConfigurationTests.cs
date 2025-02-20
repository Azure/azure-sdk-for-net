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
    public class ScopingConfigurationTests : AppComplianceAutomationManagementTestBase
    {
        public ScopingConfigurationTests(bool isAsync) : base(isAsync)
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
        public async Task ScopingConfigurationCRUD()
        {
            string reportName = "sdk-test-report";
            string scopingConfigurationName = "default";
            ResourceIdentifier appComplianceReportScopingConfigurationResourceId = AppComplianceReportScopingConfigurationResource.CreateResourceIdentifier(reportName, scopingConfigurationName);
            AppComplianceReportScopingConfigurationResource appComplianceReportScopingConfiguration = Client.GetAppComplianceReportScopingConfigurationResource(appComplianceReportScopingConfigurationResourceId);

            // Get scoping configuration
            // Get scoping configuration: send request
            AppComplianceReportScopingConfigurationResource result = await appComplianceReportScopingConfiguration.GetAsync();
            // Get scoping configuration: verify result
            AppComplianceReportScopingConfigurationData resourceData = result.Data;
            Assert.IsNotNull(resourceData.Id);

            // Update scoping configuration
            // Update scoping configuration: prepare data
            ScopingAnswer answer = new ScopingAnswer("GEN20_hostingEnvironment", new List<string> { "Saas" });
            AppComplianceReportScopingConfigurationProperties properties = new AppComplianceReportScopingConfigurationProperties();
            properties.Answers.Add(answer);
            AppComplianceReportScopingConfigurationData data = new AppComplianceReportScopingConfigurationData();
            data.Properties = properties;
            // Update scoping configuration: send request
            ArmOperation<AppComplianceReportScopingConfigurationResource> updateResponse = await appComplianceReportScopingConfiguration.UpdateAsync(WaitUntil.Completed, data);
            // Update scoping configuration: verify result
            AppComplianceReportScopingConfigurationResource scopingconfiguration = updateResponse.Value;
            Assert.IsNotNull(scopingconfiguration.Data.Properties.Answers);

            // Delete scoping configuration
            // Delete scoping configuration: send request
            var operation = await appComplianceReportScopingConfiguration.DeleteAsync(WaitUntil.Completed);
            // Delete scoping configuration: verify result
            Assert.IsTrue(operation.HasCompleted);
        }
    }
}
