// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.Search.Documents.Indexes;
using Azure.Search.Documents.Indexes.Models;
using Azure.Search.Documents.Tests.Utilities;
using NUnit.Framework;

namespace Azure.Search.Documents.Tests
{
    public class SearchIndexerClientTests : SearchTestBase
    {
        public SearchIndexerClientTests(bool async, SearchClientOptions.ServiceVersion serviceVersion)
            : base(async, serviceVersion, null /* RecordedTestMode.Record /* to re-record */)
        {
        }

        [Test]
        public void Constructor()
        {
            var serviceName = "my-svc-name";
            var endpoint = new Uri($"https://{serviceName}.search.windows.net");
            var service = new SearchIndexerClient(endpoint, new AzureKeyCredential("fake"));
            Assert.NotNull(service);
            Assert.AreEqual(endpoint, service.Endpoint);
            Assert.AreEqual(serviceName, service.ServiceName);

            Assert.Throws<ArgumentNullException>(() => new SearchIndexerClient(null, new AzureKeyCredential("fake")));
            Assert.Throws<ArgumentNullException>(() => new SearchIndexerClient(endpoint, null));
            Assert.Throws<ArgumentException>(() => new SearchIndexerClient(new Uri("http://bing.com"), null));
        }

        [Test]
        public void DiagnosticsAreUnique()
        {
            // Make sure we're not repeating Header/Query names already defined
            // in the base ClientOptions
            SearchClientOptions options = new SearchClientOptions();
            Assert.IsEmpty(GetDuplicates(options.Diagnostics.LoggedHeaderNames));
            Assert.IsEmpty(GetDuplicates(options.Diagnostics.LoggedQueryParameters));

            // CollectionAssert.Unique doesn't give you the duplicate values
            // which is less helpful than it could be
            static string GetDuplicates(IEnumerable<string> values)
            {
                List<string> duplicates = new List<string>();
                HashSet<string> unique = new HashSet<string>();
                foreach (string value in values)
                {
                    if (!unique.Add(value))
                    {
                        duplicates.Add(value);
                    }
                }
                return string.Join(", ", duplicates);
            }
        }

        [Test]
        public async Task CreateAzureBlobIndexer()
        {
            await using SearchResources resources = await SearchResources.CreateWithBlobStorageAndIndexAsync(this, populate: true);

            SearchIndexerClient serviceClient = resources.GetIndexerClient();

            // Create the Azure Blob data source and indexer.
            SearchIndexerDataSourceConnection dataSource = new SearchIndexerDataSourceConnection(
                Recording.Random.GetName(),
                SearchIndexerDataSourceType.AzureBlob,
                resources.StorageAccountConnectionString,
                new SearchIndexerDataContainer(resources.BlobContainerName));

            SearchIndexerDataSourceConnection actualSource = await serviceClient.CreateDataSourceConnectionAsync(
                dataSource);

            SearchIndexer indexer = new SearchIndexer(
                Recording.Random.GetName(),
                dataSource.Name,
                resources.IndexName);

            SearchIndexer actualIndexer = await serviceClient.CreateIndexerAsync(
                indexer);

            // Update the indexer.
            actualIndexer.Description = "Updated description";
            await serviceClient.CreateOrUpdateIndexerAsync(
                actualIndexer,
                onlyIfUnchanged: true);

            await WaitForIndexingAsync(serviceClient, actualIndexer.Name);

            // Run the indexer.
            await serviceClient.RunIndexerAsync(
                indexer.Name);

            await WaitForIndexingAsync(serviceClient, actualIndexer.Name);

            // Query the index.
            SearchClient client = resources.GetSearchClient();

            long count = await client.GetDocumentCountAsync();

            // This should be equal, but sometimes reports double despite logs showing no shared resources.
            Assert.That(count, Is.GreaterThanOrEqualTo(SearchResources.TestDocuments.Length));
        }

        [Test]
        [SyncOnly]
        public void CreateDataSourceConnectionParameterValidation()
        {
            var endpoint = new Uri($"https://my-svc-name.search.windows.net");
            var service = new SearchIndexerClient(endpoint, new AzureKeyCredential("fake"));

            ArgumentException ex = Assert.Throws<ArgumentNullException>(() => service.CreateDataSourceConnection(null));
            Assert.AreEqual("dataSourceConnection", ex.ParamName);

            ex = Assert.ThrowsAsync<ArgumentNullException>(() => service.CreateDataSourceConnectionAsync(null));
            Assert.AreEqual("dataSourceConnection", ex.ParamName);
        }

        [Test]
        [SyncOnly]
        public void CreateOrUpdateDataSourceConnectionParameterValidation()
        {
            var endpoint = new Uri($"https://my-svc-name.search.windows.net");
            var service = new SearchIndexerClient(endpoint, new AzureKeyCredential("fake"));

            ArgumentException ex = Assert.Throws<ArgumentNullException>(() => service.CreateOrUpdateDataSourceConnection(null));
            Assert.AreEqual("dataSourceConnection", ex.ParamName);

            ex = Assert.ThrowsAsync<ArgumentNullException>(() => service.CreateOrUpdateDataSourceConnectionAsync(null));
            Assert.AreEqual("dataSourceConnection", ex.ParamName);
        }

        [Test]
        [SyncOnly]
        public void GetDataSourceConnectionParameterValidation()
        {
            var endpoint = new Uri($"https://my-svc-name.search.windows.net");
            var service = new SearchIndexerClient(endpoint, new AzureKeyCredential("fake"));

            ArgumentException ex = Assert.Throws<ArgumentNullException>(() => service.GetDataSourceConnection(null));
            Assert.AreEqual("dataSourceConnectionName", ex.ParamName);

            ex = Assert.ThrowsAsync<ArgumentNullException>(() => service.GetDataSourceConnectionAsync(null));
            Assert.AreEqual("dataSourceConnectionName", ex.ParamName);
        }

        [Test]
        [SyncOnly]
        public void DeleteDataSourceConnectionParameterValidation()
        {
            var endpoint = new Uri($"https://my-svc-name.search.windows.net");
            var service = new SearchIndexerClient(endpoint, new AzureKeyCredential("fake"));

            ArgumentException ex = Assert.Throws<ArgumentNullException>(() => service.DeleteDataSourceConnection((string)null));
            Assert.AreEqual("dataSourceConnectionName", ex.ParamName);

            ex = Assert.Throws<ArgumentNullException>(() => service.DeleteDataSourceConnection((SearchIndexerDataSourceConnection)null));
            Assert.AreEqual("dataSourceConnection", ex.ParamName);

            ex = Assert.ThrowsAsync<ArgumentNullException>(() => service.DeleteDataSourceConnectionAsync((string)null));
            Assert.AreEqual("dataSourceConnectionName", ex.ParamName);

            ex = Assert.ThrowsAsync<ArgumentNullException>(() => service.DeleteDataSourceConnectionAsync((SearchIndexerDataSourceConnection)null));
            Assert.AreEqual("dataSourceConnection", ex.ParamName);
        }

        [Test]
        public async Task CrudDataSourceConnection()
        {
            await using SearchResources resources = await SearchResources.CreateWithBlobStorageAndIndexAsync(this);

            SearchIndexerClient client = resources.GetIndexerClient();
            string connectionName = Recording.Random.GetName();

            SearchIndexerDataSourceConnection connection = new SearchIndexerDataSourceConnection(
                connectionName,
                SearchIndexerDataSourceType.AzureBlob,
                resources.StorageAccountConnectionString,
                new SearchIndexerDataContainer(resources.BlobContainerName));

            // Create the connection.
            SearchIndexerDataSourceConnection createdConnection = await client.CreateDataSourceConnectionAsync(connection);

            try
            {
                Assert.That(createdConnection, Is.EqualTo(connection).Using(SearchIndexerDataSourceConnectionComparer.Shared));
                Assert.IsNull(createdConnection.ConnectionString); // Should not be returned since it contains sensitive information.

                // Update the connection.
                createdConnection.Description = "Updated description";
                SearchIndexerDataSourceConnection updatedConnection = await client.CreateOrUpdateDataSourceConnectionAsync(createdConnection, onlyIfUnchanged: true);

                Assert.That(updatedConnection, Is.EqualTo(createdConnection).Using(SearchIndexerDataSourceConnectionComparer.Shared));
                Assert.IsNull(updatedConnection.ConnectionString); // Should not be returned since it contains sensitive information.
                Assert.AreNotEqual(createdConnection.ETag, updatedConnection.ETag);

                // Get the connection.
                connection = await client.GetDataSourceConnectionAsync(connectionName);

                Assert.That(connection, Is.EqualTo(updatedConnection).Using(SearchIndexerDataSourceConnectionComparer.Shared));
                Assert.IsNull(connection.ConnectionString); // Should not be returned since it contains sensitive information.
                Assert.AreEqual(updatedConnection.ETag, connection.ETag);

                // Delete the connection.
                await client.DeleteDataSourceConnectionAsync(connection, onlyIfUnchanged: true);

                Response<IReadOnlyList<string>> names = await client.GetDataSourceConnectionNamesAsync();
                CollectionAssert.DoesNotContain(names.Value, connectionName);
            }
            catch
            {
                if (Recording.Mode != RecordedTestMode.Playback)
                {
                    await client.DeleteDataSourceConnectionAsync(connectionName);
                }
                throw;
            }
        }

        [Test]
        [SyncOnly]
        public void CreateIndexParameterValidation()
        {
            var endpoint = new Uri($"https://my-svc-name.search.windows.net");
            var service = new SearchIndexerClient(endpoint, new AzureKeyCredential("fake"));

            ArgumentException ex = Assert.Throws<ArgumentNullException>(() => service.CreateIndexer(null));
            Assert.AreEqual("indexer", ex.ParamName);

            ex = Assert.ThrowsAsync<ArgumentNullException>(() => service.CreateIndexerAsync(null));
            Assert.AreEqual("indexer", ex.ParamName);
        }

        [Test]
        [SyncOnly]
        public void CreateOrUpdateIndexerParameterValidation()
        {
            var endpoint = new Uri($"https://my-svc-name.search.windows.net");
            var service = new SearchIndexerClient(endpoint, new AzureKeyCredential("fake"));

            ArgumentException ex = Assert.Throws<ArgumentNullException>(() => service.CreateOrUpdateIndexer(null));
            Assert.AreEqual("indexer", ex.ParamName);

            ex = Assert.ThrowsAsync<ArgumentNullException>(() => service.CreateOrUpdateIndexerAsync(null));
            Assert.AreEqual("indexer", ex.ParamName);
        }

        [Test]
        [SyncOnly]
        public void GetIndexerParameterValidation()
        {
            var endpoint = new Uri($"https://my-svc-name.search.windows.net");
            var service = new SearchIndexerClient(endpoint, new AzureKeyCredential("fake"));

            ArgumentException ex = Assert.Throws<ArgumentNullException>(() => service.GetIndexer(null));
            Assert.AreEqual("indexerName", ex.ParamName);

            ex = Assert.ThrowsAsync<ArgumentNullException>(() => service.GetIndexerAsync(null));
            Assert.AreEqual("indexerName", ex.ParamName);
        }

        [Test]
        [SyncOnly]
        public void DeleteIndexerParameterValidation()
        {
            var endpoint = new Uri($"https://my-svc-name.search.windows.net");
            var service = new SearchIndexerClient(endpoint, new AzureKeyCredential("fake"));

            ArgumentException ex = Assert.Throws<ArgumentNullException>(() => service.DeleteIndexer((string)null));
            Assert.AreEqual("indexerName", ex.ParamName);

            ex = Assert.Throws<ArgumentNullException>(() => service.DeleteIndexer((SearchIndexer)null));
            Assert.AreEqual("indexer", ex.ParamName);

            ex = Assert.ThrowsAsync<ArgumentNullException>(() => service.DeleteIndexerAsync((string)null));
            Assert.AreEqual("indexerName", ex.ParamName);

            ex = Assert.ThrowsAsync<ArgumentNullException>(() => service.DeleteIndexerAsync((SearchIndexer)null));
            Assert.AreEqual("indexer", ex.ParamName);
        }

        [Test]
        [SyncOnly]
        public void ResetIndexerParameterValidation()
        {
            var endpoint = new Uri($"https://my-svc-name.search.windows.net");
            var service = new SearchIndexerClient(endpoint, new AzureKeyCredential("fake"));

            ArgumentException ex = Assert.Throws<ArgumentNullException>(() => service.ResetIndexer(null));
            Assert.AreEqual("indexerName", ex.ParamName);

            ex = Assert.ThrowsAsync<ArgumentNullException>(() => service.ResetIndexerAsync(null));
            Assert.AreEqual("indexerName", ex.ParamName);
        }

        [Test]
        [SyncOnly]
        public void RunIndexerParameterValidation()
        {
            var endpoint = new Uri($"https://my-svc-name.search.windows.net");
            var service = new SearchIndexerClient(endpoint, new AzureKeyCredential("fake"));

            ArgumentException ex = Assert.Throws<ArgumentNullException>(() => service.RunIndexer(null));
            Assert.AreEqual("indexerName", ex.ParamName);

            ex = Assert.ThrowsAsync<ArgumentNullException>(() => service.RunIndexerAsync(null));
            Assert.AreEqual("indexerName", ex.ParamName);
        }

        [Test]
        [SyncOnly]
        public void CreateSkillsetParameterValidation()
        {
            var endpoint = new Uri($"https://my-svc-name.search.windows.net");
            var service = new SearchIndexerClient(endpoint, new AzureKeyCredential("fake"));

            ArgumentException ex = Assert.Throws<ArgumentNullException>(() => service.CreateSkillset(null));
            Assert.AreEqual("skillset", ex.ParamName);

            ex = Assert.ThrowsAsync<ArgumentNullException>(() => service.CreateSkillsetAsync(null));
            Assert.AreEqual("skillset", ex.ParamName);
        }

        [Test]
        [SyncOnly]
        public void CreateOrUpdateSkillsetParameterValidation()
        {
            var endpoint = new Uri($"https://my-svc-name.search.windows.net");
            var service = new SearchIndexerClient(endpoint, new AzureKeyCredential("fake"));

            ArgumentException ex = Assert.Throws<ArgumentNullException>(() => service.CreateOrUpdateSkillset(null));
            Assert.AreEqual("skillset", ex.ParamName);

            ex = Assert.ThrowsAsync<ArgumentNullException>(() => service.CreateOrUpdateSkillsetAsync(null));
            Assert.AreEqual("skillset", ex.ParamName);
        }

        [Test]
        [SyncOnly]
        public void GetSkillsetParameterValidation()
        {
            var endpoint = new Uri($"https://my-svc-name.search.windows.net");
            var service = new SearchIndexerClient(endpoint, new AzureKeyCredential("fake"));

            ArgumentException ex = Assert.Throws<ArgumentNullException>(() => service.GetSkillset(null));
            Assert.AreEqual("skillsetName", ex.ParamName);

            ex = Assert.ThrowsAsync<ArgumentNullException>(() => service.GetSkillsetAsync(null));
            Assert.AreEqual("skillsetName", ex.ParamName);
        }

        [Test]
        [SyncOnly]
        public void DeleteSkillsetParameterValidation()
        {
            var endpoint = new Uri($"https://my-svc-name.search.windows.net");
            var service = new SearchIndexerClient(endpoint, new AzureKeyCredential("fake"));

            ArgumentException ex = Assert.Throws<ArgumentNullException>(() => service.DeleteSkillset((string)null));
            Assert.AreEqual("skillsetName", ex.ParamName);

            ex = Assert.Throws<ArgumentNullException>(() => service.DeleteSkillset((SearchIndexerSkillset)null));
            Assert.AreEqual("skillset", ex.ParamName);

            ex = Assert.ThrowsAsync<ArgumentNullException>(() => service.DeleteSkillsetAsync((string)null));
            Assert.AreEqual("skillsetName", ex.ParamName);

            ex = Assert.ThrowsAsync<ArgumentNullException>(() => service.DeleteSkillsetAsync((SearchIndexerSkillset)null));
            Assert.AreEqual("skillset", ex.ParamName);
        }

        [Test]
        public async Task CrudSkillset()
        {
            await using SearchResources resources = await SearchResources.CreateWithBlobStorageAndIndexAsync(this);

            SearchIndexerClient client = resources.GetIndexerClient();
            string skillsetName = Recording.Random.GetName();

            // Skills based on https://github.com/Azure-Samples/azure-search-sample-data/blob/master/hotelreviews/HotelReviews_skillset.json.
            SearchIndexerSkill skill1 = new SplitSkill(
                new[]
                {
                    new InputFieldMappingEntry("text") { Source = "/document/reviews_text" },
                    new InputFieldMappingEntry("languageCode") { Source = "/document/Language" },
                },
                new[]
                {
                    new OutputFieldMappingEntry("textItems") { TargetName = "pages" },
                })
            {
                Context = "/document/reviews_text",
                DefaultLanguageCode = SplitSkillLanguage.En,
                TextSplitMode = TextSplitMode.Pages,
                MaximumPageLength = 5000,
            };

            SearchIndexerSkill skill2 = new SentimentSkill(
                new[]
                {
                    new InputFieldMappingEntry("text") { Source = "/documents/reviews_text/pages/*" },
                    new InputFieldMappingEntry("languageCode") { Source = "/document/Language" },
                },
                new[]
                {
                    new OutputFieldMappingEntry("score") { TargetName = "Sentiment" },
                })
            {
                Context = "/document/reviews_text/pages/*",
                DefaultLanguageCode = SentimentSkillLanguage.En,
            };

            SearchIndexerSkill skill3 = new LanguageDetectionSkill(
                new[]
                {
                    new InputFieldMappingEntry("text") { Source = "/document/reviews_text" },
                },
                new[]
                {
                    new OutputFieldMappingEntry("languageCode") { TargetName = "Language" },
                })
            {
                Context = "/document",
            };

            SearchIndexerSkill skill4 = new KeyPhraseExtractionSkill(
                new[]
                {
                    new InputFieldMappingEntry("text") { Source = "/documents/reviews_Text/pages/*" },
                    new InputFieldMappingEntry("languageCode") { Source = "/document/Language" },
                },
                new[]
                {
                    new OutputFieldMappingEntry("keyPhrases") { TargetName = "Keyphrases" },
                })
            {
                Context = "/document/reviews_text/pages/*",
                DefaultLanguageCode = KeyPhraseExtractionSkillLanguage.En,
            };

            SearchIndexerSkill skill5 = new ShaperSkill(
                new[]
                {
                    new InputFieldMappingEntry("name") { Source = "/document/name" },
                    new InputFieldMappingEntry("reviews_date") { Source = "/document/reviews_date" },
                    new InputFieldMappingEntry("reviews_rating") { Source = "/documents/reviews_rating" },
                    new InputFieldMappingEntry("reviews_text") { Source = "/documents/reviews_text" },
                    new InputFieldMappingEntry("reviews_title") { Source = "/document/reviews_title" },
                    new InputFieldMappingEntry("AzureSearch_DocumentKey") { Source = "/document/AzureSearch_DocumentKey" },
                    new InputFieldMappingEntry("pages")
                    {
                        SourceContext = "/document/reviews_text/pages/*",
                        Inputs =
                        {
                            new InputFieldMappingEntry("SentimentScore") { Source = "/document/reviews_text/pages/*/Sentiment" },
                            new InputFieldMappingEntry("LanguageCode") { Source = "/document/Language" },
                            new InputFieldMappingEntry("Page") { Source = "/document/reviews_text/pages/*" },
                            new InputFieldMappingEntry("keyphrase")
                            {
                                SourceContext = "/document/reviews_text/pages/*/Keyphrases/*",
                                Inputs =
                                {
                                    new InputFieldMappingEntry("Keyphrases") { Source = "/document/reviews_text/pages/*/Keyphrases/*" },
                                },
                            },
                        },
                    },
                },
                new[]
                {
                    new OutputFieldMappingEntry("output") { TargetName = "tableprojection" },
                })
            {
                Context = "/document",
            };

            SearchIndexerSkillset skillset = new SearchIndexerSkillset(skillsetName, new[] { skill1, skill2, skill3, skill4, skill5 })
            {
                CognitiveServicesAccount = new DefaultCognitiveServicesAccount(),
            };

            // Create the skillset.
            SearchIndexerSkillset createdSkillset = await client.CreateSkillsetAsync(skillset);

            try
            {
                Assert.That(createdSkillset, Is.EqualTo(skillset).Using(SearchIndexerSkillsetComparer.Shared));

                // Update the skillset.
                createdSkillset.Description = "Update description";
                SearchIndexerSkillset updatedSkillset = await client.CreateOrUpdateSkillsetAsync(createdSkillset, onlyIfUnchanged: true);

                Assert.That(updatedSkillset, Is.EqualTo(createdSkillset).Using(SearchIndexerSkillsetComparer.Shared));
                Assert.AreNotEqual(createdSkillset.ETag, updatedSkillset.ETag);

                // Get the skillset
                skillset = await client.GetSkillsetAsync(skillsetName);

                Assert.That(skillset, Is.EqualTo(updatedSkillset).Using(SearchIndexerSkillsetComparer.Shared));
                Assert.AreEqual(updatedSkillset.ETag, skillset.ETag);

                // Delete the skillset.
                await client.DeleteSkillsetAsync(skillset, onlyIfUnchanged: true);

                Response<IReadOnlyList<string>> names = await client.GetSkillsetNamesAsync();
                CollectionAssert.DoesNotContain(names.Value, skillsetName);
            }
            catch
            {
                if (Recording.Mode != RecordedTestMode.Playback)
                {
                    await client.DeleteSkillsetAsync(skillsetName);
                }

                throw;
            }
        }
    }
}
