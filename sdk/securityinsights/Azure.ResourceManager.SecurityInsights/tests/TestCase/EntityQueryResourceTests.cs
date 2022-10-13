// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.Resources.Models;
using Azure.ResourceManager.SecurityInsights.Models;
using Azure.ResourceManager.SecurityInsights.Tests.Helpers;
using NUnit.Framework;

namespace Azure.ResourceManager.SecurityInsights.Tests.TestCase
{
    public class EntityQueryResourceTests : SecurityInsightsManagementTestBase
    {
        public EntityQueryResourceTests(bool isAsync)
            : base(isAsync, RecordedTestMode.Record)
        {
        }

        private async Task<EntityQueryResource> CreateEntityQueryAsync(string name)
        {
            var collection = (await CreateResourceGroupAsync()).GetEntityQueries(workspaceName);
            var input = ResourceDataHelpers.GetEntityQueryData();
            var lro = await collection.CreateOrUpdateAsync(WaitUntil.Completed, name, input);
            return lro.Value;
        }

        [TestCase]
        public async Task EntityQueryApiTests()
        {
            //1.Get
            var queryName = Recording.GenerateAssetName("testEntityQuery-");
            var query1 = await CreateEntityQueryAsync(queryName);
            EntityQueryResource query2 = await query1.GetAsync();

            ResourceDataHelpers.AssertEntityQueryData(query1.Data, query2.Data);
            //2.Delete
            await query1.DeleteAsync(WaitUntil.Completed);
        }
    }
}
