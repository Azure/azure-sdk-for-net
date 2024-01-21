// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Resources;
using NUnit.Framework;

namespace Azure.ResourceManager.OperationalInsights.Tests.Scenario
{
    internal class OperationalInsightsTableTests : OperationalInsightsManagementTestBase
    {
        private ResourceGroupResource _resourceGroup;
        private OperationalInsightsWorkspaceResource _workspace;

        public OperationalInsightsTableTests(bool isAsync) : base(isAsync)
        {
        }

        [SetUp]
        public async Task Setup()
        {
            _resourceGroup = await CreateResourceGroup();
            _workspace = await CreateAOIWorkspace(_resourceGroup, Recording.GenerateAssetName("AopTestWorkspace"));
        }

        [Test]
        public async Task Get()
        {
            string tableName = "Alert";
            var table = await _workspace.GetOperationalInsightsTables().GetAsync(tableName);
            Assert.AreEqual(tableName, table.Value.Data.Name);
            Assert.IsTrue(table.Value.Data.IsRetentionInDaysAsDefault);
            Assert.IsTrue(table.Value.Data.IsTotalRetentionInDaysAsDefault);
        }

        [Test]
        public async Task GetAll()
        {
            var tables = await _workspace.GetOperationalInsightsTables().GetAllAsync().ToEnumerableAsync();
            foreach (var table in tables)
            {
                Assert.IsTrue(table.Data.IsRetentionInDaysAsDefault);
                Assert.IsTrue(table.Data.IsTotalRetentionInDaysAsDefault);
            }
        }
    }
}
