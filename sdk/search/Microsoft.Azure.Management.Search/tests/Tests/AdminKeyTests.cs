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
        public void CanGetAdminKeys()
        {
            Run(() =>
            {
                SearchManagementClient searchMgmt = GetSearchManagementClient();

                // List admin keys
                AdminKeyResult adminKeyResult =
                    searchMgmt.AdminKeys.Get(Data.ResourceGroupName, Data.SearchServiceName);

                Assert.NotNull(adminKeyResult);
                Assert.NotNull(adminKeyResult.PrimaryKey);
                Assert.NotNull(adminKeyResult.SecondaryKey);
                Assert.NotEmpty(adminKeyResult.PrimaryKey);
                Assert.NotEmpty(adminKeyResult.SecondaryKey);
            });
        }

        [Fact]
        public void CanRegenerateAdminKeys()
        {
            Run(() =>
            {
                SearchManagementClient searchMgmt = GetSearchManagementClient();

                AdminKeyResult originalAdminKeys =
                    searchMgmt.AdminKeys.Get(Data.ResourceGroupName, Data.SearchServiceName);

                AdminKeyResult keysWithNewPrimary =
                    searchMgmt.AdminKeys.Regenerate(Data.ResourceGroupName, Data.SearchServiceName, AdminKeyKind.Primary);

                Assert.False(string.IsNullOrEmpty(keysWithNewPrimary.PrimaryKey));
                Assert.NotEqual(originalAdminKeys.PrimaryKey, keysWithNewPrimary.PrimaryKey);
                Assert.Equal(originalAdminKeys.SecondaryKey, keysWithNewPrimary.SecondaryKey);

                AdminKeyResult keysWithNewSecondary =
                    searchMgmt.AdminKeys.Regenerate(Data.ResourceGroupName, Data.SearchServiceName, AdminKeyKind.Secondary);

                Assert.False(string.IsNullOrEmpty(keysWithNewSecondary.SecondaryKey));
                Assert.Equal(keysWithNewPrimary.PrimaryKey, keysWithNewSecondary.PrimaryKey);
                Assert.NotEqual(keysWithNewPrimary.SecondaryKey, keysWithNewSecondary.SecondaryKey);
            });
        }
    }
}
