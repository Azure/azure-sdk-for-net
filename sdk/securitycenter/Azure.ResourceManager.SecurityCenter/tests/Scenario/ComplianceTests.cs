// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.SecurityCenter.Models;
using NUnit.Framework;

namespace Azure.ResourceManager.SecurityCenter.Tests
{
    internal class ComplianceTests : SecurityCenterManagementTestBase
    {
        private SecurityComplianceCollection _complianceCollection => Client.GetSecurityCompliances(DefaultSubscription.Id);
        private const string _existComplianceName = "2022-10-14Z";

        public ComplianceTests(bool isAsync) : base(isAsync)//, RecordedTestMode.Record)
        {
        }

        [SetUp]
        public void TestSetUp()
        {
        }

        [RecordedTest]
        public async Task Exist()
        {
            bool flag = await _complianceCollection.ExistsAsync(_existComplianceName);
            Assert.That(flag, Is.True);
        }

        [RecordedTest]
        public async Task Get()
        {
            var compliance = await _complianceCollection.GetAsync(_existComplianceName);
            ValidateCompliance(compliance, _existComplianceName);
        }

        [RecordedTest]
        public async Task GetAll()
        {
            var list = await _complianceCollection.GetAllAsync().ToEnumerableAsync();
            Assert.That(list, Is.Not.Empty);
            ValidateCompliance(list.First(item => item.Data.Name == _existComplianceName), _existComplianceName);
        }

        private void ValidateCompliance(SecurityComplianceResource compliance, string complianceName)
        {
            Assert.That(compliance, Is.Not.Null);
            Assert.That(compliance.Data.Id, Is.Not.Null);
            Assert.That(compliance.Data.Name, Is.EqualTo(_existComplianceName));
            Assert.That(compliance.Data.ResourceType.ToString(), Is.EqualTo("Microsoft.Security/compliances"));
        }
    }
}
