// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

namespace Microsoft.Azure.Management.Search.Tests
{
    using Microsoft.Azure.Management.Search.Models;
    using Microsoft.Azure.Search.Tests.Utilities;
    using Xunit;

    public sealed class AdminKeyTests : SearchTestBase<SearchServiceFixture>
    {
        [Fact]
        public void CanListAdminKeys()
        {
            Run(() =>
            {
                SearchManagementClient searchMgmt = GetSearchManagementClient();

                // List admin keys
                AdminKeyResult adminKeyResult = 
                    searchMgmt.AdminKeys.List(Data.ResourceGroupName, Data.SearchServiceName);

                Assert.NotNull(adminKeyResult);
                Assert.NotNull(adminKeyResult.PrimaryKey);
                Assert.NotNull(adminKeyResult.SecondaryKey);
                Assert.NotEmpty(adminKeyResult.PrimaryKey);
                Assert.NotEmpty(adminKeyResult.SecondaryKey);
            });
        }
    }
}
