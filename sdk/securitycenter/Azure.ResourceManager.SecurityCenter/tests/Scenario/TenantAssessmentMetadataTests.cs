// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.SecurityCenter.Models;
using NUnit.Framework;

namespace Azure.ResourceManager.SecurityCenter.Tests
{
    internal class TenantAssessmentMetadataTests : SecurityCenterManagementTestBase
    {
        private TenantAssessmentMetadataCollection _tenantAssessmentMetadataCollection;
        private const string _existAssessmentMetadataName = "4fb67663-9ab9-475d-b026-8c544cced439";

        public TenantAssessmentMetadataTests(bool isAsync) : base(isAsync)//, RecordedTestMode.Record)
        {
            JsonPathSanitizers.Add("$..description");
            JsonPathSanitizers.Add("$..remediationDescription");
        }

        [SetUp]
        public async Task TestSetUp()
        {
            var tenants = await Client.GetTenants().GetAllAsync().ToEnumerableAsync();
            var tenant = tenants.FirstOrDefault();
            _tenantAssessmentMetadataCollection = tenant.GetAllTenantAssessmentMetadata();
        }

        [RecordedTest]
        public async Task Exist()
        {
            bool flag = await _tenantAssessmentMetadataCollection.ExistsAsync(_existAssessmentMetadataName);
            Assert.IsTrue(flag);
        }

        [RecordedTest]
        public async Task Get()
        {
            var tenantAssessmentMetadataResource = await _tenantAssessmentMetadataCollection.GetAsync(_existAssessmentMetadataName);
            ValidateTenantAssessmentMetadata(tenantAssessmentMetadataResource);
        }

        [RecordedTest]
        public async Task GetAll()
        {
            var list = await _tenantAssessmentMetadataCollection.GetAllAsync().ToEnumerableAsync();
            Assert.IsNotEmpty(list);
            ValidateTenantAssessmentMetadata(list.First(item => item.Data.Name == _existAssessmentMetadataName));
        }

        private void ValidateTenantAssessmentMetadata(TenantAssessmentMetadataResource tenantAssessmentMetadataResource, string assessmentMetadataName = _existAssessmentMetadataName)
        {
            Assert.IsNotNull(tenantAssessmentMetadataResource);
            Assert.IsNotNull(tenantAssessmentMetadataResource.Data.Id);
            Assert.AreEqual(assessmentMetadataName, tenantAssessmentMetadataResource.Data.Name);
            Assert.AreEqual("Microsoft.Security/assessmentMetadata", tenantAssessmentMetadataResource.Data.ResourceType.ToString());
            Assert.AreEqual("Endpoint protection should be installed on machines", tenantAssessmentMetadataResource.Data.DisplayName);
            Assert.AreEqual(SecurityAssessmentSeverity.High, tenantAssessmentMetadataResource.Data.Severity);
            Assert.AreEqual(SecurityAssessmentUserImpact.Low, tenantAssessmentMetadataResource.Data.UserImpact);
            Assert.AreEqual(ImplementationEffort.Low, tenantAssessmentMetadataResource.Data.ImplementationEffort);
        }
    }
}
