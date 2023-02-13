// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.SecurityCenter.Models;
using NUnit.Framework;

namespace Azure.ResourceManager.SecurityCenter.Tests
{
    internal class CustomEntityStoreAssignmentTests : SecurityCenterManagementTestBase
    {
        private ResourceGroupResource _resourceGroup;
        private CustomEntityStoreAssignmentCollection _customEntityStoreAssignmentCollection;

        public CustomEntityStoreAssignmentTests(bool isAsync) : base(isAsync)//, RecordedTestMode.Record)
        {
        }

        [SetUp]
        public async Task TestSetUp()
        {
            _resourceGroup = await CreateResourceGroup();
            _customEntityStoreAssignmentCollection = _resourceGroup.GetCustomEntityStoreAssignments();
        }

        [RecordedTest]
        [Ignore(" Azure.RequestFailedException : The location property is required for this definition.")]
        public async Task CreateOrUpdate()
        {
            string customEntityStoreAssignmentName = Recording.GenerateAssetName("customEntityStoreAssignment");
            var data = new CustomEntityStoreAssignmentCreateOrUpdateContent()
            {
                Principal = "aaduser=f3923a3e-ad57-4752-b1a9-fbf3c8e5e082;72f988bf-86f1-41af-91ab-2d7cd011db47",
            };
            var customAssessmentAutomation = await _customEntityStoreAssignmentCollection.CreateOrUpdateAsync(WaitUntil.Completed, customEntityStoreAssignmentName, data);
            Assert.IsNotNull(customAssessmentAutomation);
        }

        [RecordedTest]
        public async Task GetAll()
        {
            var list = await _customEntityStoreAssignmentCollection.GetAllAsync().ToEnumerableAsync();
            Assert.IsEmpty(list);
        }
    }
}
