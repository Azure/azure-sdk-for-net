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
    internal class SecuritySolutionTests : SecurityCenterManagementTestBase
    {
        private ResourceGroupResource _resourceGroup;
        private IotSecuritySolutionCollection _securitySolutionCollection;
        public SecuritySolutionTests(bool isAsync) : base(isAsync)//, RecordedTestMode.Record)
        {
        }

        [SetUp]
        public async Task TestSetUp()
        {
            _resourceGroup = await CreateResourceGroup();
            _securitySolutionCollection = _resourceGroup.GetIotSecuritySolutions();
        }

        [RecordedTest]
        [Ignore("The SKD doesn't support create SecuritySolution")]
        public async Task Exist()
        {
            string securitySolutionName = "";
            bool flag = await _securitySolutionCollection.ExistsAsync(securitySolutionName);
            Assert.IsTrue(flag);
        }

        [RecordedTest]
        [Ignore("The SKD doesn't support create SecuritySolution")]
        public async Task Get()
        {
            string securitySolutionName = "";
            var securitySolution = await _securitySolutionCollection.GetAsync(securitySolutionName);
            Assert.IsNotNull(securitySolution);
        }

        [RecordedTest]
        public async Task GetAll()
        {
            var list = await DefaultSubscription.GetSecuritySolutionsAsync().ToEnumerableAsync();
            Assert.IsEmpty(list);
        }
    }
}
