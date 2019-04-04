using Microsoft.Azure.Search.Models;
using Microsoft.Azure.Search.Tests.Utilities;
using Search.Tests.Utilities;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Search.Tests.Tests
{
    public sealed class EncryptionWithCMKTests : SearchTestBase<EncryptionFixture>
    {
        [Fact]
        public void CreateIndexWithCMK()
        {
            Run(() =>
            {
                Index encryptedIndex = CreateEncryptedTestIndex(new EncryptionKey()
                {
                    KeyVaultUri = this.Data.KeyVaultUri,
                    KeyVaultKeyName = this.Data.KeyName,
                    KeyVaultKeyVersion = this.Data.KeyVersion,
                    AccessCredentials = new AzureActiveDirectoryApplicationCredentials()
                    {
                        ApplicationId = this.Data.TestAADApplicationId,
                        ApplicationSecret = 
                    }
                })
            });
        }
        private static Index CreateEncryptedTestIndex(EncryptionKey encryptionKey)
        {
            string indexName = SearchTestUtilities.GenerateName();

            var index = new Index()
            {
                Name = indexName,
                Fields = new[]
                {
                        new Field("hotelId", DataType.String) { IsKey = true, IsSearchable = false, IsFilterable = true, IsSortable = true, IsFacetable = true },
                        new Field("description", DataType.String) { IsKey = false, IsSearchable = true, IsFilterable = false, IsSortable = false, IsFacetable = false },
                },
                EncryptionKey = encryptionKey
            };

            return index;
        }
}
}
