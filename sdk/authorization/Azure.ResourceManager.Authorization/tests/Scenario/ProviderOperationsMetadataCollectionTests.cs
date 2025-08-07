// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.ResourceManager.Authorization.Tests.Scenario
{
    public class ProviderOperationsMetadataCollectionTests : AuthorizationManagementTestBase
    {
        public ProviderOperationsMetadataCollectionTests(bool isAsync)
                    : base(isAsync)//, RecordedTestMode.Record)
        {
        }

        private async Task<AuthorizationProviderOperationsMetadataCollection> GetProviderOperationsCollectionAsync()
        {
            var tenants = await Client.GetTenants().GetAllAsync().ToEnumerableAsync();
            return tenants.FirstOrDefault().GetAllAuthorizationProviderOperationsMetadata();
        }

        [RecordedTest]
        public async Task GetAll()
        {
            var collection = await GetProviderOperationsCollectionAsync();
            var providerOperations = await collection.GetAllAsync().ToEnumerableAsync();
            Assert.GreaterOrEqual(providerOperations.Count, 0);
        }

        [RecordedTest]
        public async Task Get()
        {
            var collection = await GetProviderOperationsCollectionAsync();
            var providerOperations = await collection.GetAllAsync().ToEnumerableAsync();
            var providerOperation1 = providerOperations.FirstOrDefault();
            if (providerOperation1 != null)
            {
                var providerOperation2 = await collection.GetAsync(providerOperation1.Data.Name);
                Assert.AreEqual(providerOperation2.Value.Data.Name, providerOperation1.Data.Name);
            }
        }

        [RecordedTest]
        public async Task Exists()
        {
            var collection = await GetProviderOperationsCollectionAsync();
            var providerOperations = await collection.GetAllAsync().ToEnumerableAsync();
            var providerOperation1 = providerOperations.FirstOrDefault();
            if (providerOperation1 != null)
            {
                var providerOperation2 = await collection.ExistsAsync(providerOperation1.Data.Name);
                Assert.IsTrue(providerOperation2.Value);
            }
        }
    }
}
