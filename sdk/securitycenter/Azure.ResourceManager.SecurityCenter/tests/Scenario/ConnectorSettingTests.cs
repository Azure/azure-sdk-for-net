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
        private ConnectorSettingCollection _connectorSettingCollection => DefaultSubscription.GetConnectorSettings();

        public ConnectorSettingTests(bool isAsync) : base(isAsync, RecordedTestMode.Record)
        {
        }

        [SetUp]
        public void TestSetUp()
        {
        }

        [RecordedTest]
        [Ignore("System.InvalidOperationException : The requested operation requires an element of type 'Object', but the target element has type 'Array'.")]
        public async Task GetAll()
        {
            var list = await _connectorSettingCollection.GetAllAsync().ToEnumerableAsync();
            Assert.IsNotEmpty(list);
        }
    }
}
