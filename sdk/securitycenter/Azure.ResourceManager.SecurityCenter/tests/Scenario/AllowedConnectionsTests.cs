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
    internal class AllowedConnectionsTests : SecurityCenterManagementTestBase
    {
        private ResourceGroupResource _resourceGroup => CreateResourceGroup().Result;
        private AllowedConnectionsResourceCollection _allowedConnectionsResourceCollection;

        public AllowedConnectionsTests(bool isAsync) : base(isAsync)
        {
        }

        [SetUp]
        public   void TestSetUp()
        {
            _allowedConnectionsResourceCollection = _resourceGroup.GetAllowedConnectionsResources();
        }

        [RecordedTest]
        public async Task GetAll()
        {
            var list = await DefaultSubscription.GetAllowedConnectionsResourcesAsync().ToEnumerableAsync();
        }
    }
}
