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
    internal class ConnectorSettingTests : SecurityCenterManagementTestBase
    {
        private SecurityCloudConnectorCollection _connectorSettingCollection => DefaultSubscription.GetSecurityCloudConnectors();

        public ConnectorSettingTests(bool isAsync) : base(isAsync, RecordedTestMode.Record)
        {
        }

        [SetUp]
        public void TestSetUp()
        {
        }
        /// <summary>
        /// </summary>
        /// <returns></returns>
        [RecordedTest]
        [Ignore("linked issue: https://github.com/Azure/azure-rest-api-specs/issues/21260")]
        public async Task GetAll()
        {
            var list = await _connectorSettingCollection.GetAllAsync().ToEnumerableAsync();
            Assert.IsNotEmpty(list);
        }
    }
}
