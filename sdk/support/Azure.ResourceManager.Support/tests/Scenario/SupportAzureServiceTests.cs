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
    internal class SupportAzureServiceTests : SupportManagementTestBase
    {
        private SupportAzureServiceCollection _supportAzureServiceCollection => DefaultTenant.GetSupportAzureServices();
        private const string _existAzureSupportServiceName = "484e2236-bc6d-b1bb-76d2-7d09278cf9ea";

        public SupportAzureServiceTests(bool isAsync) : base(isAsync)//, RecordedTestMode.Record)
        {
        }

        [RecordedTest]
        public async Task Exist()
        {
            var flag = await _supportAzureServiceCollection.ExistsAsync(_existAzureSupportServiceName);
            Assert.IsTrue(flag);
        }

        [RecordedTest]
        public async Task Get()
        {
            var supportAzureService = await _supportAzureServiceCollection.GetAsync(_existAzureSupportServiceName);
            ValidateSupportAzureService(supportAzureService.Value.Data, _existAzureSupportServiceName);
        }

        [RecordedTest]
        public async Task GetAll()
        {
            var list = await _supportAzureServiceCollection.GetAllAsync().ToEnumerableAsync();
            Assert.IsNotEmpty(list);
            ValidateSupportAzureService(list.FirstOrDefault(item => item.Data.Name == _existAzureSupportServiceName).Data, _existAzureSupportServiceName);
        }

        private void ValidateSupportAzureService(SupportAzureServiceData supportAzureService, string supportAzureServiceName)
        {
            Assert.IsNotNull(supportAzureService);
            Assert.IsNotEmpty(supportAzureService.DisplayName);
            Assert.AreEqual(supportAzureService.Name, supportAzureServiceName);
        }
    }
}
