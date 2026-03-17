// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
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
            Assert.Throws<ArgumentNullException>(() => new SearchIndexerClient(endpoint, credential: null));
            Assert.Throws<ArgumentNullException>(() => new SearchIndexerClient(endpoint, tokenCredential: null));
            Assert.Throws<ArgumentException>(() => new SearchIndexerClient(new Uri("http://bing.com"), credential: null));
        }

        [Test]
        public void DiagnosticsAreUnique()
        {
            // Make sure we're not repeating Header/Query names already defined
            // in the base ClientOptions
            SearchClientOptions options = new SearchClientOptions(ServiceVersion);
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

            SearchIndexerClient serviceClient = resources.GetIndexerClient(new SearchClientOptions(ServiceVersion));

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

            await serviceClient.CreateIndexerAsync(indexer);

            // Wait till the indexer is done.
            await WaitForIndexingAsync(serviceClient, indexer.Name);

            // Remove this workaround once the service issue is fixed: https://github.com/Azure/azure-sdk-for-net/issues/39104#issuecomment-1749469582
            // Tracking issue: https://msdata.visualstudio.com/Azure%20Search/_workitems/edit/2737454
            SearchIndexer actualIndexer = await serviceClient.GetIndexerAsync(indexer.Name);

            // Update the indexer.
            actualIndexer.Description = "Updated description";
            await serviceClient.CreateOrUpdateIndexerAsync(
                actualIndexer,
                onlyIfUnchanged: true);

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

            SearchIndexerClient client = resources.GetIndexerClient(new SearchClientOptions(ServiceVersion));
            string skillsetName = Recording.Random.GetName();

            SearchIndexerSkillset skillset = CreateSkillsetModel(skillsetName, resources);

            // Create the skillset.
            SearchIndexerSkillset createdSkillset = await client.CreateSkillsetAsync(skillset);

            await TestSkillsetAsync(client, skillset, createdSkillset, skillsetName);
        }

        private SearchIndexerSkillset CreateSkillsetModel(string skillsetName, SearchResources resources)
        {
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
                    new OutputFieldMappingEntry("confidenceScores") { TargetName = "Sentiment" },
                },
                 SentimentSkill.SkillVersion.V3)
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

            KnowledgeStoreTableProjectionSelector table1 = new("hotelReviewsDocument")
            {
                GeneratedKeyName = "Documentid",
                Source = "/document/tableprojection",
                SourceContext = null,
            };

            KnowledgeStoreTableProjectionSelector table2 = new("hotelReviewsPages")
            {
                GeneratedKeyName = "Pagesid",
                Source = "/document/tableprojection/pages/*",
                SourceContext = null,
            };

            KnowledgeStoreTableProjectionSelector table3 = new("hotelReviewsKeyPhrases")
            {
                GeneratedKeyName = "KeyPhrasesid",
                Source = "/document/tableprojection/pages/*/keyphrase/*",
                SourceContext = null,
            };

            KnowledgeStoreProjection projection1 = new()
            { Tables = { table1, table2, table3 } };

            KnowledgeStoreTableProjectionSelector table4 = new("hotelReviewsInlineDocument")
            {
                GeneratedKeyName = "Documentid",
                Source = null,
                SourceContext = "/document",
            };
            table4.Inputs.Add(new("name") { Source = "/document/name", SourceContext = null });
            table4.Inputs.Add(new("reviews_date") { Source = "/document/reviews_date", SourceContext = null });
            table4.Inputs.Add(new("reviews_rating") { Source = "/document/reviews_rating", SourceContext = null });
            table4.Inputs.Add(new("reviews_text") { Source = "/document/reviews_text", SourceContext = null });
            table4.Inputs.Add(new("reviews_title") { Source = "/document/reviews_title", SourceContext = null });
            table4.Inputs.Add(new("AzureSearch_DocumentKey") { Source = "/document/AzureSearch_DocumentKey", SourceContext = null });

            KnowledgeStoreTableProjectionSelector table5 = new("hotelReviewsInlinePages")
            {
                GeneratedKeyName = "Pagesid",
                Source = null,
                SourceContext = "/document/reviews_text/pages/*",
            };
            table5.Inputs.Add(new("SentimentScore") { Source = "/document/reviews_text/pages/*/Sentiment", SourceContext = null });
            table5.Inputs.Add(new("LanguageCode") { Source = "/document/Language", SourceContext = null });
            table5.Inputs.Add(new("Page") { Source = "/document/reviews_text/pages/*", SourceContext = null });

            KnowledgeStoreTableProjectionSelector table6 = new("hotelReviewsInlineKeyPhrases")
            {
                GeneratedKeyName = "kpidv2",
                Source = null,
                SourceContext = "/document/reviews_text/pages/*/Keyphrases/*",
            };
            table6.Inputs.Add(new("Keyphrases") { Source = "/document/reviews_text/pages/*/Keyphrases/*", SourceContext = null });

            KnowledgeStoreProjection projection2 = new()
            { Tables = { table4, table5, table6 } };

            List<KnowledgeStoreProjection> projections = new() { projection1, projection2 };

            SearchIndexerSkillset skillset = new SearchIndexerSkillset(skillsetName, new[] { skill1, skill2, skill3, skill4, skill5 })
            {
                CognitiveServicesAccount = new DefaultCognitiveServicesAccount(),
                KnowledgeStore = new KnowledgeStore(resources.StorageAccountConnectionString, projections),
            };

            return skillset;
        }

        private async Task TestSkillsetAsync(SearchIndexerClient client, SearchIndexerSkillset skillset, SearchIndexerSkillset createdSkillset, string skillsetName)
        {
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

                // Check the projections in the knowledge store of the skillset.
                Assert.AreEqual(2, skillset.KnowledgeStore.Projections.Count);

                KnowledgeStoreProjection p1 = skillset.KnowledgeStore.Projections[0];
                Assert.AreEqual(3, p1.Tables.Count);
                Assert.AreEqual("hotelReviewsDocument", p1.Tables[0].TableName);
                Assert.AreEqual(0, p1.Tables[0].Inputs.Count);
                Assert.AreEqual("hotelReviewsPages", p1.Tables[1].TableName);
                Assert.AreEqual(0, p1.Tables[1].Inputs.Count);
                Assert.AreEqual("hotelReviewsKeyPhrases", p1.Tables[2].TableName);
                Assert.AreEqual(0, p1.Tables[2].Inputs.Count);
                Assert.AreEqual(0, p1.Objects.Count);
                Assert.AreEqual(0, p1.Files.Count);

                KnowledgeStoreProjection p2 = skillset.KnowledgeStore.Projections[1];
                Assert.AreEqual(3, p2.Tables.Count);
                Assert.AreEqual("hotelReviewsInlineDocument", p2.Tables[0].TableName);
                Assert.AreEqual(6, p2.Tables[0].Inputs.Count);
                Assert.AreEqual("hotelReviewsInlinePages", p2.Tables[1].TableName);
                Assert.AreEqual(3, p2.Tables[1].Inputs.Count);
                Assert.AreEqual("hotelReviewsInlineKeyPhrases", p2.Tables[2].TableName);
                Assert.AreEqual(1, p2.Tables[2].Inputs.Count);
                Assert.AreEqual(0, p2.Objects.Count);
                Assert.AreEqual(0, p2.Files.Count);

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

        [Test]
        public async Task RoundtripAllSkills()
        {
            await using SearchResources resources = SearchResources.CreateWithNoIndexes(this);

            SearchIndexerClient client = resources.GetIndexerClient(new SearchClientOptions(ServiceVersion));
            string skillsetName = Recording.Random.GetName();

            // Enumerate all skills and create them with consistently fake input to test for nullability during deserialization.
            SearchIndexerSkill CreateSkill(Type t, string[] inputNames, string[] outputNames)
            {
                var inputs = inputNames.Select(input => new InputFieldMappingEntry(input) { Source = "/document/content" }).ToList();
                var outputs = outputNames.Select(output => new OutputFieldMappingEntry(output, targetName: Recording.Random.GetName(), serializedAdditionalRawData: null)).ToList();

                return t switch
                {
                    Type _ when t == typeof(CustomEntityLookupSkill) => new CustomEntityLookupSkill(inputs, outputs) { EntitiesDefinitionUri = new Uri("https://microsoft.com") },

                    // TODO: Should TextSplitMode be added to constructor (required input)?
                    Type _ when t == typeof(SplitSkill) => new SplitSkill(inputs, outputs) { TextSplitMode = TextSplitMode.Pages },

                    Type _ when t == typeof(TextTranslationSkill) => new TextTranslationSkill(inputs, outputs, TextTranslationSkillLanguage.En),
                    Type _ when t == typeof(WebApiSkill) => new WebApiSkill(inputs, outputs, "https://microsoft.com"),
                    Type _ when t == typeof(AzureOpenAIEmbeddingSkill) => new AzureOpenAIEmbeddingSkill(inputs, outputs) { ResourceUri = new Uri("https://test-sample.openai.azure.com"), ApiKey = "api-key", DeploymentName = "model", ModelName = "text-embedding-3-large" },
                    _ => (SearchIndexerSkill)Activator.CreateInstance(t, new object[] { inputs, outputs }),
                };
            }

            EntityRecognitionSkill CreateEntityRecognitionSkill(EntityRecognitionSkill.SkillVersion skillVersion)
            {
                var inputs = new[] { "languageCode", "text" }.Select(input => new InputFieldMappingEntry(input) { Source = "/document/content" }).ToList();
                var outputs = new[] { "persons" }.Select(output => new OutputFieldMappingEntry(output, targetName: Recording.Random.GetName(), serializedAdditionalRawData: null)).ToList();

                if (skillVersion == EntityRecognitionSkill.SkillVersion.V1)
                {
                    return new EntityRecognitionSkill(inputs, outputs);
                }
                if (skillVersion == EntityRecognitionSkill.SkillVersion.V3)
                {
                    return new EntityRecognitionSkill(inputs, outputs, skillVersion);
                }

                throw new NotSupportedException($"Unknown version {skillVersion}");
            }

            SentimentSkill CreateSentimentSkill(SentimentSkill.SkillVersion skillVersion)
            {
                var inputs = new[] { "languageCode", "text" }.Select(input => new InputFieldMappingEntry(input) { Source = "/document/content" }).ToList();

                if (skillVersion == SentimentSkill.SkillVersion.V1)
                {
                    var outputs = new[] { "score" }.
                                Select(output => new OutputFieldMappingEntry(output, targetName: Recording.Random.GetName(), serializedAdditionalRawData: null)).ToList();
                    return new SentimentSkill(inputs, outputs);
                }
                if (skillVersion == SentimentSkill.SkillVersion.V3)
                {
                    var outputs = new[] { "sentiment", "confidenceScores", "sentences" }.
                                Select(output => new OutputFieldMappingEntry(output, targetName: Recording.Random.GetName(), serializedAdditionalRawData: null)).ToList();
                    return new SentimentSkill(inputs, outputs, skillVersion);
                }

                throw new NotSupportedException($"Unknown version {skillVersion}");
            }

            List<SearchIndexerSkill> skills = typeof(SearchIndexerSkill).Assembly.GetExportedTypes()
                .Where(t => t != typeof(SearchIndexerSkill) && typeof(SearchIndexerSkill).IsAssignableFrom(t))
                .Select(t => t switch
                {
                    Type _ when t == typeof(ConditionalSkill) => CreateSkill(t, new[] { "condition", "whenTrue", "whenFalse" }, new[] { "output" }),
                    Type _ when t == typeof(CustomEntityLookupSkill) => CreateSkill(t, new[] { "text", "languageCode" }, new[] { "entities" }),
                    Type _ when t == typeof(DocumentExtractionSkill) => CreateSkill(t, new[] { "file_data" }, new[] { "content", "normalized_images" }),
                    Type _ when t == typeof(EntityLinkingSkill) => CreateSkill(t, new[] { "languageCode", "text" }, new[] { "entities" }),
                    Type _ when t == typeof(EntityRecognitionSkill) => CreateEntityRecognitionSkill(EntityRecognitionSkill.SkillVersion.V3),
                    Type _ when t == typeof(ImageAnalysisSkill) => CreateSkill(t, new[] { "image" }, new[] { "categories" }),
                    Type _ when t == typeof(KeyPhraseExtractionSkill) => CreateSkill(t, new[] { "text", "languageCode" }, new[] { "keyPhrases" }),
                    Type _ when t == typeof(LanguageDetectionSkill) => CreateSkill(t, new[] { "text" }, new[] { "languageCode", "languageName", "score" }),
                    Type _ when t == typeof(MergeSkill) => CreateSkill(t, new[] { "text", "itemsToInsert", "offsets" }, new[] { "mergedText" }),
                    Type _ when t == typeof(OcrSkill) => CreateSkill(t, new[] { "image" }, new[] { "text", "layoutText" }),
                    Type _ when t == typeof(PiiDetectionSkill) => CreateSkill(t, new[] { "languageCode", "text" }, new[] { "piiEntities", "maskedText" }),
                    Type _ when t == typeof(SentimentSkill) => CreateSentimentSkill(SentimentSkill.SkillVersion.V3),
                    Type _ when t == typeof(ShaperSkill) => CreateSkill(t, new[] { "text" }, new[] { "output" }),
                    Type _ when t == typeof(SplitSkill) => CreateSkill(t, new[] { "text", "languageCode" }, new[] { "textItems" }),
                    Type _ when t == typeof(TextTranslationSkill) => CreateSkill(t, new[] { "text", "toLanguageCode", "fromLanguageCode" }, new[] { "translatedText", "translatedToLanguageCode", "translatedFromLanguageCode" }),
                    Type _ when t == typeof(WebApiSkill) => CreateSkill(t, new[] { "input" }, new[] { "output" }),
                    Type _ when t == typeof(AzureOpenAIEmbeddingSkill) => CreateSkill(t, new[] { "text" }, new[] { "embedding" }),
                    Type _ when t == typeof(DocumentIntelligenceLayoutSkill) => CreateSkill(t, new[] { "file_data" }, new[] { "content", "normalized_images" }),
                    _ => throw new NotSupportedException($"{t.FullName}"),
                })
                .Where(skill => skill != null)
                .ToList();

            skills.Add(CreateEntityRecognitionSkill(EntityRecognitionSkill.SkillVersion.V3));
            skills.Add(CreateSentimentSkill(SentimentSkill.SkillVersion.V3));

            SearchIndexerSkillset specifiedSkillset = new SearchIndexerSkillset(skillsetName, skills)
            {
                CognitiveServicesAccount = new DefaultCognitiveServicesAccount(),
                KnowledgeStore = new KnowledgeStore(resources.StorageAccountConnectionString, new List<KnowledgeStoreProjection>()),
            };

            try
            {
                SearchIndexerSkillset createdSkillset = await client.CreateSkillsetAsync(specifiedSkillset);

                Assert.AreEqual(skillsetName, createdSkillset.Name);
                Assert.AreEqual(skills.Count, createdSkillset.Skills.Count);
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
