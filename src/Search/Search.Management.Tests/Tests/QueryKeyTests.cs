// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

namespace Microsoft.Azure.Management.Search.Tests
{
    using System.Linq;
    using Microsoft.Azure.Management.Search.Models;
    using Microsoft.Azure.Search.Tests.Utilities;
    using Xunit;

    public sealed class QueryKeyTests : SearchTestBase<SearchServiceFixture>
    {
        [Fact]
        public void CanListQueryKeys()
        {
            Run(() =>
            {
                SearchManagementClient searchMgmt = GetSearchManagementClient();

                var queryKeys =
                    searchMgmt.QueryKeys.ListBySearchService(Data.ResourceGroupName, Data.SearchServiceName);

                Assert.NotNull(queryKeys);

                QueryKey onlyKey = queryKeys.Single();

                AssertIsValidKey(onlyKey);
                AssertIsDefaultKey(onlyKey);
            });
        }

        [Fact]
        public void CanCreateAndDeleteQueryKeys()
        {
            Run(() =>
            {
                SearchManagementClient searchMgmt = GetSearchManagementClient();

                var queryKeys = searchMgmt.QueryKeys.ListBySearchService(Data.ResourceGroupName, Data.SearchServiceName);

                AssertIsDefaultKey(queryKeys.Single());

                QueryKey newKey = searchMgmt.QueryKeys.Create(Data.ResourceGroupName, Data.SearchServiceName, "my key");

                AssertIsValidKey(newKey, "my key");

                queryKeys = searchMgmt.QueryKeys.ListBySearchService(Data.ResourceGroupName, Data.SearchServiceName);

                Assert.Equal(2, queryKeys.Count());
                AssertIsDefaultKey(queryKeys.First());

                Assert.Equal(newKey.Name, queryKeys.ElementAt(1).Name);
                Assert.Equal(newKey.Key, queryKeys.ElementAt(1).Key);

                searchMgmt.QueryKeys.Delete(Data.ResourceGroupName, Data.SearchServiceName, newKey.Key);

                queryKeys = searchMgmt.QueryKeys.ListBySearchService(Data.ResourceGroupName, Data.SearchServiceName);

                AssertIsDefaultKey(queryKeys.Single());
            });
        }

        [Fact]
        public void DeleteQueryKeyIsIdempotent()
        {
            Run(() =>
            {
                SearchManagementClient searchMgmt = GetSearchManagementClient();
                QueryKey newKey = searchMgmt.QueryKeys.Create(Data.ResourceGroupName, Data.SearchServiceName, "my key");
                searchMgmt.QueryKeys.Delete(Data.ResourceGroupName, Data.SearchServiceName, newKey.Key);
                searchMgmt.QueryKeys.Delete(Data.ResourceGroupName, Data.SearchServiceName, newKey.Key);
            });
        }

        private static void AssertIsDefaultKey(QueryKey key)
        {
            Assert.Null(key.Name);   // Default key has no name.
        }

        private static void AssertIsValidKey(QueryKey key, string expectedName = null)
        {
            Assert.NotNull(key);
            Assert.NotNull(key.Key);
            Assert.NotEmpty(key.Key);

            if (expectedName != null)
            {
                Assert.Equal(expectedName, key.Name);
            }
        }
    }
}
