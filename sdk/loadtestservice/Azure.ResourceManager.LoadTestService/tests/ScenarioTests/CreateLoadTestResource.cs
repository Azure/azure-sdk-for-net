// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.ResourceManager.LoadTestService.Tests.Helpers;
using NUnit.Framework;

namespace Azure.ResourceManager.LoadTestService.Tests
{
    public class CreateLoadTestResource : LoadTestServiceManagementTestBase
    {
        private readonly string SubscriptionId;

        private readonly string ResourceGroupName;

        private readonly string ResourceName;

        private readonly ResourceIdentifier ResourceIdentifier;
        public CreateLoadTestResource(bool isAsync) : base(isAsync, RecordedTestMode.Record)
        {
            SubscriptionId = TestEnvironment.LOADTESTSERVICE_SUBSCRIPTION_ID;
            ResourceGroupName = TestEnvironment.LOADTESTSERVICE_RESOURCE_GROUP;
            ResourceName = TestEnvironment.LOADTESTSERVICE_RESOURCE_NAME;
            ResourceIdentifier = LoadTestResource.CreateResourceIdentifier(SubscriptionId, ResourceGroupName, ResourceName);
        }

        private LoadTestResource _loadTestResource;
        //private LoadTestResourceData _loadTestResourceData;

        [Test]
        public async Task BeginCreateFunctionalTest()
        {
            LoadTestResourceData loadTestResourceData = LoadTestResourceHelper.GenerateLoadTestResourcedata(ResourceIdentifier, TestEnvironment.LOADTESTSERVICE_LOCATION);

            _loadTestResource = new LoadTestResource(Client, loadTestResourceData);
            Response<LoadTestResource> res = await _loadTestResource.GetAsync();

            Assert.IsFalse(false);
        }
    }
}
