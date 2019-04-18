// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

namespace Microsoft.Azure.Search.Tests
{
    using Microsoft.Azure.Search.Models;
    using Microsoft.Azure.Search.Tests.Utilities;
    using Xunit;

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
                SynonymMap encryptedSynonymMap = CreatedEncryptedSynonymMap(new EncryptionKey()
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

                SynonymMap createdEncryptedSynonyMap = searchClient.SynonymMaps.Create(encryptedSynonymMap);
                AssertSynonymMapsEqual(encryptedSynonymMap, createdEncryptedSynonyMap);
            });
        }

        [Fact]
        public void CreateSynonymMapWithCMKUsingWithoutAccessCredentials()
        {
            Run(() =>
            {
                SearchServiceClient searchClient = Data.GetSearchServiceClient();
                SynonymMap encryptedSynonymMap = CreatedEncryptedSynonymMap(new EncryptionKey()
                {
                    KeyVaultUri = this.Data.KeyVaultUri,
                    KeyVaultKeyName = this.Data.KeyName,
                    KeyVaultKeyVersion = this.Data.KeyVersion
                });

                SynonymMap createdEncryptedSynonyMap = searchClient.SynonymMaps.Create(encryptedSynonymMap);
                AssertSynonymMapsEqual(encryptedSynonymMap, createdEncryptedSynonyMap);
            });
        }        

        private static SynonymMap CreatedEncryptedSynonymMap(EncryptionKey encryptionKey)
        {
            string synonymMapName = SearchTestUtilities.GenerateName();
            return new SynonymMap(synonymMapName, "word1,word2", encryptionKey);
        }

        private static void AssertSynonymMapsEqual(SynonymMap expected, SynonymMap actual)
        {
            Assert.Equal(expected, actual, new ModelComparer<SynonymMap>());
        }
    }
}
