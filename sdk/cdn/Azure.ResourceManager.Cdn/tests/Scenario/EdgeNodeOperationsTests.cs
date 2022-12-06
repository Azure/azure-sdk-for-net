// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.Cdn.Models;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.ResourceManager.Cdn.Tests
{
    public class EdgeNodeOperationsTests : CdnManagementTestBase
    {
        public EdgeNodeOperationsTests(bool isAsync)
            : base(isAsync)//, RecordedTestMode.Record)
        {
        }

        [TestCase]
        [RecordedTest]
        public async Task List()
        {
            await foreach (var tenant in Client.GetTenants().GetAllAsync())
            {
                int count = 0;
                await foreach (var tempEdgeNode in tenant.GetEdgeNodesAsync())
                {
                    count++;
                }
                Assert.AreEqual(count, 3);
            }
        }
    }
}
