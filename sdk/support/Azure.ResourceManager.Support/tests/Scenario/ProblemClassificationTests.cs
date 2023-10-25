// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.ResourceManager.Support.Tests
{
    internal class ProblemClassificationTests : SupportManagementTestBase
    {
        private ProblemClassificationCollection _problemClassificationCollection;
        private const string _existProblemClassificationName = "c9805a0b-9410-1708-2989-0befc008e963";

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

        private void ValidateProblemClassification(ProblemClassificationData supportAzureService)
        {
            Assert.IsNotNull(supportAzureService);
            Assert.IsNotEmpty(supportAzureService.Id);
            Assert.IsNotEmpty(supportAzureService.DisplayName);
        }
    }
}
