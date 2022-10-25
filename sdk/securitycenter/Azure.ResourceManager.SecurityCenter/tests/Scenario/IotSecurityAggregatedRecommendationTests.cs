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
    internal class IotSecurityAggregatedRecommendationTests : SecurityCenterManagementTestBase
    {
        private ResourceGroupResource _resourceGroup;
        private IotSecuritySolutionResource _iotSecuritySolutionResource;
        private IotSecurityAggregatedRecommendationCollection _iotSecurityAggregatedRecommendationCollection;

        public IotSecurityAggregatedRecommendationTests(bool isAsync) : base(isAsync)//, RecordedTestMode.Record)
        {
        }

        [SetUp]
        public async Task TestSetUp()
        {
            _resourceGroup = await CreateResourceGroup();
            var iotHub = await CreateIotHub(_resourceGroup, Recording.GenerateAssetName("iothub"));
            _iotSecuritySolutionResource = await CreateIotSecuritySolution(_resourceGroup, iotHub.Data.Id, Recording.GenerateAssetName("solution"));
            _iotSecurityAggregatedRecommendationCollection = _iotSecuritySolutionResource.GetIotSecuritySolutionAnalyticsModel().GetIotSecurityAggregatedRecommendations();
        }

        [RecordedTest]
        [Ignore("The SDK doesn't support create a IotSecurityAggregatedRecommendationResource")]
        public async Task Get()
        {
            string aggregatedRecommendationName = "";
            var aggregatedRecommendation = await _iotSecurityAggregatedRecommendationCollection.GetAsync(aggregatedRecommendationName);
            Assert.NotNull(aggregatedRecommendation);
        }

        [RecordedTest]
        public async Task GetAll()
        {
            var list = await _iotSecurityAggregatedRecommendationCollection.GetAllAsync().ToEnumerableAsync();
            Assert.IsEmpty(list);
        }
    }
}
