// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.ResourceManager.CostManagement.Tests
{
    internal class ScheduledActionTests : CostManagementManagementTestBase
    {
        private ScheduledActionCollection _scheduledActionCollection;
        public ScheduledActionTests(bool isAsync) : base(isAsync)
        {
        }

        [SetUp]
        public void SetUp()
        {
            _scheduledActionCollection = Client.GetScheduledActions(DefaultScope);
        }

        [RecordedTest]
        public async Task GetAll()
        {
            var list = await _scheduledActionCollection.GetAllAsync().ToEnumerableAsync();
            Assert.IsEmpty(list);
        }
    }
}
