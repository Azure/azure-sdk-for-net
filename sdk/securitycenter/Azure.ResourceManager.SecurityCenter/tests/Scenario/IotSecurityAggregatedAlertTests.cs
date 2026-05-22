// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.ResourceManager.IotHub;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.SecurityCenter.Models;
using NUnit.Framework;

namespace Azure.ResourceManager.SecurityCenter.Tests
{
    internal class IotSecurityAggregatedAlertTests : SecurityCenterManagementTestBase
    {
        private ResourceGroupResource _resourceGroup;
        private IotSecuritySolutionResource _iotSecuritySolutionModelResource;
        private IotSecurityAggregatedAlertCollection _iotSecurityAggregatedAlertCollection;

        public IotSecurityAggregatedAlertTests(bool isAsync) : base(isAsync)//, RecordedTestMode.Record)
        {
        }

        [SetUp]
        public async Task TestSetUp()
        {
            _resourceGroup = await CreateResourceGroup();
            var iotHub = await CreateIotHub(_resourceGroup, Recording.GenerateAssetName("iothub"));
            _iotSecuritySolutionModelResource = await CreateIotSecuritySolution(_resourceGroup, iotHub.Data.Id, Recording.GenerateAssetName("solution"));
            _iotSecurityAggregatedAlertCollection = _iotSecuritySolutionModelResource.GetIotSecuritySolutionAnalyticsModel().GetIotSecurityAggregatedAlerts();
        }

        [RecordedTest]
        [Ignore("The SDK doesn't support create a IotSecurityAggregatedAlertResource")]
        public async Task Get()
        {
            string aggregatedAlertName = "";
            var aggregatedAlert = await _iotSecurityAggregatedAlertCollection.GetAsync(aggregatedAlertName);
            Assert.NotNull(aggregatedAlert);
        }

        [RecordedTest]
        [Ignore("The SDK doesn't support create a IotSecurityAggregatedAlertResource")]
        public async Task Dismiss()
        {
            string aggregatedAlertName = "";
            var aggregatedAlert = await _iotSecurityAggregatedAlertCollection.GetAsync(aggregatedAlertName);
            var response = await aggregatedAlert.Value.DismissAsync();
        }

        [RecordedTest]
        public async Task GetAll()
        {
            var list = await _iotSecurityAggregatedAlertCollection.GetAllAsync().ToEnumerableAsync();
            Assert.IsEmpty(list);
        }
    }
}
