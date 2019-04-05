using Microsoft.Azure.Search;
using Microsoft.Azure.Search.Models;
using Microsoft.Azure.Search.Tests;
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
        public void CreateIndexWithCMKUsingAccessCredentials()
        {
            Run(() =>
            {
                SearchServiceClient searchClient = Data.GetSearchServiceClient();

                Index encryptedIndex = CreateEncryptedTestIndex(new EncryptionKey()
                {
                    KeyVaultUri = this.Data.KeyVaultUri,
                    KeyVaultKeyName = this.Data.KeyName,
                    KeyVaultKeyVersion = this.Data.KeyVersion,
                    AccessCredentials = new AzureActiveDirectoryApplicationCredentials()
                    {
                        ApplicationId = this.Data.TestAADApplicationId,
                        ApplicationSecret = this.Data.TestAADApplicationSecret
                    }
                });

                Index createdEncryptedIndex = searchClient.Indexes.Create(encryptedIndex);

                AssertIndexesEqual(encryptedIndex, createdEncryptedIndex);
            });
        }

        [Fact]
        public void CreateIndexWithCMKUsingWithoutAccessCredentials()
        {
            Run(() =>
            {
                SearchServiceClient searchClient = Data.GetSearchServiceClient();

                Index encryptedIndex = CreateEncryptedTestIndex(new EncryptionKey()
                {
                    KeyVaultUri = this.Data.KeyVaultUri,
                    KeyVaultKeyName = this.Data.KeyName,
                    KeyVaultKeyVersion = this.Data.KeyVersion
                });

                Index createdEncryptedIndex = searchClient.Indexes.Create(encryptedIndex);

                AssertIndexesEqual(encryptedIndex, createdEncryptedIndex);
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

        private static void AssertIndexesEqual(Index expected, Index actual)
        {
            Assert.Equal(expected, actual, new ModelComparer<Index>());
        }

        [Fact]
        public void CreateSynonymMapWithCMKUsingAccessCredentials()
        {
            Run(() =>
            {
                SearchServiceClient searchClient = Data.GetSearchServiceClient();

                Index encryptedIndex = CreateEncryptedTestIndex(new EncryptionKey()
                {
                    KeyVaultUri = this.Data.KeyVaultUri,
                    KeyVaultKeyName = this.Data.KeyName,
                    KeyVaultKeyVersion = this.Data.KeyVersion,
                    AccessCredentials = new AzureActiveDirectoryApplicationCredentials()
                    {
                        ApplicationId = this.Data.TestAADApplicationId,
                        ApplicationSecret = this.Data.TestAADApplicationSecret
                    }
                });

                Index createdEncryptedIndex = searchClient.Indexes.Create(encryptedIndex);

                AssertIndexesEqual(encryptedIndex, createdEncryptedIndex);
            });
        }

        [Fact]
        public void CreateSynonymMapWithCMKUsingWithoutAccessCredentials()
        {
            //Run(() =>
            //{
            //    SearchServiceClient searchClient = Data.GetSearchServiceClient();

            //    Index encryptedIndex = CreateEncryptedTestIndex(new EncryptionKey()
            //    {
            //        KeyVaultUri = this.Data.KeyVaultUri,
            //        KeyVaultKeyName = this.Data.KeyName,
            //        KeyVaultKeyVersion = this.Data.KeyVersion
            //    });

            //    Index createdEncryptedIndex = searchClient.Indexes.Create(encryptedIndex);

            //    AssertIndexesEqual(encryptedIndex, createdEncryptedIndex);
            //});
        }        
    }
}
