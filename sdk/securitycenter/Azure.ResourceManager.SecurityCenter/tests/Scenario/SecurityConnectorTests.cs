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
    internal class SecurityConnectorTests : SecurityCenterManagementTestBase
    {
        private ResourceGroupResource _resourceGroup;
        private SecurityConnectorCollection _securityConnectorCollection;
        public SecurityConnectorTests(bool isAsync) : base(isAsync)//, RecordedTestMode.Record)
        {
        }

        [SetUp]
        public async Task TestSetUp()
        {
            _resourceGroup = await CreateResourceGroup();
            _securityConnectorCollection = _resourceGroup.GetSecurityConnectors();
        }

        [RecordedTest]
        public async Task GetAll()
        {
            var list = await _securityConnectorCollection.GetAllAsync().ToEnumerableAsync();
            Assert.IsEmpty(list);
        }
    }
}
