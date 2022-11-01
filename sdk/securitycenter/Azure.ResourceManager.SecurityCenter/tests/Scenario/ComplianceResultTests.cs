// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Logic.Models;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.SecurityCenter.Models;
using NUnit.Framework;

namespace Azure.ResourceManager.SecurityCenter.Tests
{
    internal class ComplianceResultTests : SecurityCenterManagementTestBase
    {
        private ComplianceResultCollection _complianceResultCollection => Client.GetComplianceResults(DefaultSubscription.Id);
        private const string _existComplianceResultName = "DesignateMoreThanOneOwner";

        public ComplianceResultTests(bool isAsync) : base(isAsync)//, RecordedTestMode.Record)
        {
        }

        [SetUp]
        public void TestSetUp()
        {
        }

        [RecordedTest]
        public async Task Exist()
        {
            var flag = await _complianceResultCollection.ExistsAsync(_existComplianceResultName);
            Assert.IsTrue(flag);
        }

        [RecordedTest]
        public async Task Get()
        {
            var complianceResult = await _complianceResultCollection.GetAsync(_existComplianceResultName);
            ValidateComplianceResult(complianceResult);
        }

        [RecordedTest]
        [Ignore("Linked issue: https://github.com/Azure/azure-rest-api-specs/issues/21144")]
        public async Task GetAll()
        {
            var list = await _complianceResultCollection.GetAllAsync().ToEnumerableAsync();
            Assert.IsNotEmpty(list);
            ValidateComplianceResult(list.First(item => item.Data.Name == _existComplianceResultName));
        }

        private void ValidateComplianceResult(ComplianceResultResource complianceResult)
        {
            Assert.IsNotNull(complianceResult);
            Assert.IsNotNull(complianceResult.Data.Id);
            Assert.AreEqual(_existComplianceResultName, complianceResult.Data.Name);
            Assert.AreEqual("Microsoft.Security/complianceResults", complianceResult.Data.ResourceType.ToString());
        }
    }
}
