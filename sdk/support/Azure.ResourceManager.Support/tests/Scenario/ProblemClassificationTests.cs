// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Support.Models;
using NUnit.Framework;

namespace Azure.ResourceManager.Support.Tests
{
    internal class ProblemClassificationTests : SupportManagementTestBase
    {
        private ProblemClassificationCollection _problemClassificationCollection;
        private const string _existProblemClassificationName = "c9805a0b-9410-1708-2989-0befc008e963";
        private const string _resourceId = "/subscriptions/cca0326c-4c31-46d8-8fcb-c67023a46f4b/resourceGroups/rg_vm/providers/Microsoft.Compute/virtualMachines/vmtest";
        private const string _serviceId = "6f16735c-b0ae-b275-ad3a-03479cfa1396";

        public ProblemClassificationTests(bool isAsync) : base(isAsync)//, RecordedTestMode.Record)
        {
        }

        [SetUp]
        public async Task SetUp()
        {
            string existAzureSupportServiceName = "484e2236-bc6d-b1bb-76d2-7d09278cf9ea";
            var supportAzureService = await DefaultTenant.GetSupportAzureServices().GetAsync(existAzureSupportServiceName);
            _problemClassificationCollection = supportAzureService.Value.GetProblemClassifications();
        }

        [RecordedTest]
        public async Task Exist()
        {
            var flag = await _problemClassificationCollection.ExistsAsync(_existProblemClassificationName);
            Assert.IsTrue(flag);
        }

        [RecordedTest]
        public async Task Get()
        {
            var supportAzureService = await _problemClassificationCollection.GetAsync(_existProblemClassificationName);
            ValidateProblemClassification(supportAzureService.Value.Data);
        }

        [RecordedTest]
        public async Task GetAll()
        {
            var list = await _problemClassificationCollection.GetAllAsync().ToEnumerableAsync();
            Assert.IsNotEmpty(list);
            ValidateProblemClassification(list.FirstOrDefault(item => item.Data.Name == _existProblemClassificationName).Data);
        }

/*        [RecordedTest]
        public async Task ClassifyProblems()
        {
            var problemClassificationContent = new ServiceProblemClassificationContent(issueSummary: "database", new Core.ResourceIdentifier(_resourceId), null);
            var problemClassificationOutput = await DefaultSubscription.ClassifyServiceProblemAsync(_serviceId, problemClassificationContent);
            this.ValidateProblemClassification(problemClassificationOutput.Value.ProblemClassificationResults.FirstOrDefault());
        }

        private void ValidateProblemClassification(ServiceProblemClassificationResult problemClassification)
        {
            Assert.IsNotNull(problemClassification);
            Assert.IsNotEmpty(problemClassification.ServiceId);
            Assert.IsNotEmpty(problemClassification.DisplayName);
            Assert.IsNotEmpty(problemClassification.ProblemClassificationId);
        }*/

        private void ValidateProblemClassification(ProblemClassificationData supportAzureService)
        {
            Assert.IsNotNull(supportAzureService);
            Assert.IsNotEmpty(supportAzureService.Id);
            Assert.IsNotEmpty(supportAzureService.DisplayName);
        }
    }
}
