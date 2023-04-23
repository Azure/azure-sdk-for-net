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
    internal class ExportTests : CostManagementManagementTestBase
    {
        private CostManagementExportCollection _exportCollection;

        public ExportTests(bool isAsync) : base(isAsync)
        {
        }

        [SetUp]
        public void SetUp()
        {
            _exportCollection = Client.GetCostManagementExports(DefaultScope);
        }

        [RecordedTest]
        public async Task List()
        {
            var list = await _exportCollection.GetAllAsync().ToEnumerableAsync();
            Assert.IsEmpty(list);
        }
    }
}
