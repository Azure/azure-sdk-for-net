// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

namespace Microsoft.Azure.Management.Search.Tests
{
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

                ListQueryKeysResult queryKeyResult =
                    searchMgmt.QueryKeys.List(Data.ResourceGroupName, Data.SearchServiceName);

                Assert.NotNull(queryKeyResult);
                Assert.Equal(1, queryKeyResult.Value.Count);
                Assert.Null(queryKeyResult.Value[0].Name);   // Default key has no name.
                Assert.NotNull(queryKeyResult.Value[0].Key);
                Assert.NotEmpty(queryKeyResult.Value[0].Key);
            });
        }
    }
}
