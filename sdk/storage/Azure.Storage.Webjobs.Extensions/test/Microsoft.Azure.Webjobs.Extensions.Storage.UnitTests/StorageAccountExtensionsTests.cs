// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Xunit;

namespace Microsoft.Azure.WebJobs.Host.UnitTests.Storage
{
    public class StorageAccountExtensionsTests
    {
        //private IStorageAccount account;
        //private Mock<IStorageAccount> accountMock;

        //public StorageAccountExtensionsTests()
        //{
        //    accountMock = new Mock<IStorageAccount>();
        //    account = accountMock.Object;
        //    accountMock.SetupGet(acc => acc.Credentials)
        //        .Returns(new StorageCredentials("name", string.Empty, "key"));
        //}

        [Fact(Skip = "Missing StorageAccountType")]
        public void AssertTypeOneOf_Succeeds()
        {
            //account.AssertTypeOneOf(StorageAccountType.GeneralPurpose);
        }

        [Fact(Skip = "Missing StorageAccountType")]
        public void AssertTypeOneOf_Throws_Unsupported()
        {
            //accountMock.SetupGet(acc => acc.Type).Returns(StorageAccountType.BlobOnly);
            //var exception = Assert.Throws<InvalidOperationException>(() => account.AssertTypeOneOf(StorageAccountType.GeneralPurpose));
            //Assert.Equal("Storage account 'name' is of unsupported type 'Blob-Only/ZRS'. Supported types are 'General Purpose'", exception.Message);
        }

        [Fact(Skip = "Missing StorageAccountType")]
        public void AssertTypeOneOf_Throws_MultipleSuggestions()
        {
            //    var exception = Assert.Throws<InvalidOperationException>(() => account.AssertTypeOneOf(StorageAccountType.BlobOnly, StorageAccountType.Premium));
            //    Assert.Equal("Storage account 'name' is of unsupported type 'General Purpose'. Supported types are 'Blob-Only/ZRS', 'Premium'", exception.Message);
        }
    }
}
