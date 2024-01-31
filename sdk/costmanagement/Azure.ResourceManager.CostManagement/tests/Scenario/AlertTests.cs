// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.ResourceManager.CostManagement.Tests
{
    internal class AlertTests : CostManagementManagementTestBase
    {
        private CostManagementAlertCollection _alertCollection;

        public AlertTests(bool isAsync) : base(isAsync)
        {
        }

        [SetUp]
        public void SetUp()
        {
            _alertCollection = Client.GetCostManagementAlerts(DefaultScope);
        }

        [RecordedTest]
        public async Task GetAll()
        {
            var list = await _alertCollection.GetAllAsync().ToEnumerableAsync();
            Assert.IsEmpty(list);
        }
    }
}
