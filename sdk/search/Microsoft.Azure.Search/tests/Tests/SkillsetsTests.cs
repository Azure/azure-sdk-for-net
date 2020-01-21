// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

using System.Collections.Generic;
using System.Net;
using System.Net.Http.Headers;
using Microsoft.Azure.Search.Models;
using Microsoft.Azure.Search.Tests.Utilities;
using Microsoft.Rest.Azure;
using Xunit;

namespace Microsoft.Azure.Search.Tests
{
    public sealed class SkillsetsTests : SearchTestBase<SearchServiceFixture>
    {
        public const string InputImageFieldName = "image";
        public const string InputUrlFieldName = "url";
        // The query string is for SAS token and it is optional
        public const string InputQueryStringFieldName = "queryString";

        public const string OutputTextFieldName = "text";
        public const string OutputLayoutTextFieldName = "layoutText";

        public const string RootPathString = "/document";

        [Fact]
        public void CreateSkillsetReturnsCorrectDefinitionWebApiSkillWithHeaders()
        {
            Run(() =>
            {
                SearchServiceClient searchClient = Data.GetSearchServiceClient();
                CreateAndValidateSkillset(searchClient, CreateTestSkillsetWebApiSkill());
            });
        }

        [Fact]
        public void CreateSkillsetReturnsCorrectDefinitionWebApiSkillWithoutHeaders()
        {
            Run(() =>
            {
                SearchServiceClient searchClient = Data.GetSearchServiceClient();
                CreateAndValidateSkillset(searchClient, CreateTestSkillsetWebApiSkill(includeHeader: false));
            });
        }

        [Fact]
        public void CreateSkillsetReturnsCorrectDefinitionCustomEntityLookup()
        {
            Run(() =>
            {
                SearchServiceClient searchClient = Data.GetSearchServiceClient();
                CreateAndValidateSkillset(searchClient, CreateSkillsetWithCustomEntityLookup());
            });
        }

        [Fact]
        public void CreateSkillsetReturnsCorrectDefinitionInlineCustomEntityLookup()
        {
            Run(() =>
            {
                SearchServiceClient searchClient = Data.GetSearchServiceClient();
                CreateAndValidateSkillset(searchClient, CreateSkillsetWithInlineCustomEntityLookup());
            });
        }

        [Fact]
        public void CreateSkillsetReturnsCorrectDefinitionDocumentExtraction()
        {
            Run(() =>
            {
                SearchServiceClient searchClient = Data.GetSearchServiceClient();
                CreateAndValidateSkillset(searchClient, CreateSkillsetWithDocumentExtraction());
            });
        }

        [Fact]
        public void CreateSkillsetReturnsCorrectDefinitionKnowledgeStore()
        {
            Run(() =>
            {
                SearchServiceClient searchClient = Data.GetSearchServiceClient();
                CreateAndValidateSkillset(searchClient, CreateSkillsetWithKnowledgeStore());
            });
        }

        [Fact]
        public void CreateSkillsetReturnsCorrectDefinitionOcrKeyPhrase()
        {
            Run(() =>
            {
                SearchServiceClient searchClient = Data.GetSearchServiceClient();
                CreateAndValidateSkillset(searchClient, CreateTestSkillsetOcrKeyPhrase(OcrSkillLanguage.En, KeyPhraseExtractionSkillLanguage.En));
                CreateAndValidateSkillset(searchClient, CreateTestSkillsetOcrKeyPhrase(OcrSkillLanguage.Fr, KeyPhraseExtractionSkillLanguage.Fr));
                CreateAndValidateSkillset(searchClient, CreateTestSkillsetOcrKeyPhrase(OcrSkillLanguage.Es, KeyPhraseExtractionSkillLanguage.Es));
            });
        }

        [Fact]
        public void CreateSkillsetReturnsCorrectDefinitionWithDefaultSettings()
        {
            Run(() =>
            {
                SearchServiceClient searchClient = Data.GetSearchServiceClient();
                CreateAndValidateSkillset(searchClient, CreateSkillsetWithOcrDefaultSettings());
                CreateAndValidateSkillset(searchClient, CreateSkillsetWithImageAnalysisDefaultSettings());
                CreateAndValidateSkillset(searchClient, CreateSkillsetWithKeyPhraseExtractionDefaultSettings());
                CreateAndValidateSkillset(searchClient, CreateSkillsetWithMergeDefaultSettings());
                CreateAndValidateSkillset(searchClient, CreateSkillsetWithEntityRecognitionDefaultSettings());
                CreateAndValidateSkillset(searchClient, CreateSkillsetWithSentimentDefaultSettings());
                CreateAndValidateSkillset(searchClient, CreateSkillsetWithSplitDefaultSettings());
            });
        }

        [Fact]
        public void CreateSkillsetReturnsCorrectDefinitionOcrHandwritingSentiment()
        {
            Run(() =>
            {
                SearchServiceClient searchClient = Data.GetSearchServiceClient();
                CreateAndValidateSkillset(searchClient, CreateTestSkillsetOcrSentiment(OcrSkillLanguage.Pt, SentimentSkillLanguage.PtPT, TextExtractionAlgorithm.Printed));
                CreateAndValidateSkillset(searchClient, CreateTestSkillsetOcrSentiment(OcrSkillLanguage.Fi, SentimentSkillLanguage.Fi, TextExtractionAlgorithm.Printed));
                CreateAndValidateSkillset(searchClient, CreateTestSkillsetOcrSentiment(OcrSkillLanguage.En, SentimentSkillLanguage.En, TextExtractionAlgorithm.Handwritten));
            });
        }

        [Fact]
        public void CreateSkillsetReturnsCorrectDefinitionImageAnalysisKeyPhrase()
        {
            Run(() =>
            {
                SearchServiceClient searchClient = Data.GetSearchServiceClient();
                CreateAndValidateSkillset(searchClient, CreateTestSkillsetImageAnalysisKeyPhrase());
            });
        }

        [Fact]
        public void CreateSkillsetReturnsCorrectDefinitionLanguageDetection()
        {
            Run(() =>
            {
                SearchServiceClient searchClient = Data.GetSearchServiceClient();
                CreateAndValidateSkillset(searchClient, CreateTestSkillsetLanguageDetection());
            });
        }

        [Fact]
        public void CreateSkillsetReturnsCorrectDefinitionMergeText()
        {
            Run(() =>
            {
                SearchServiceClient searchClient = Data.GetSearchServiceClient();
                CreateAndValidateSkillset(searchClient, CreateTestSkillsetMergeText());
            });
        }

        [Fact]
        public void CreateSkillsetReturnsCorrectDefinitionOcrEntity()
        {
            Run(() =>
            {
                SearchServiceClient searchClient = Data.GetSearchServiceClient();
                CreateAndValidateSkillset(searchClient, CreateTestSkillsetOcrEntity(null, null));
                CreateAndValidateSkillset(searchClient, CreateTestSkillsetOcrEntity(TextExtractionAlgorithm.Printed, new List<EntityCategory> { EntityCategory.Location, EntityCategory.Organization, EntityCategory.Person }));
            });
        }

        [Fact]
        public void CreateSkillsetReturnsCorrectDefinitionOcrShaper()
        {
            Run(() =>
            {
                SearchServiceClient searchClient = Data.GetSearchServiceClient();
                CreateAndValidateSkillset(searchClient, CreateTestSkillsetOcrShaper());
            });
        }

        [Fact]
        public void CreateSkillsetReturnsCorrectDefinitionShaperWithNestedInputs()
        {
            Run(() =>
            {
                SearchServiceClient searchClient = Data.GetSearchServiceClient();
                CreateAndValidateSkillset(searchClient, CreateTestSkillsetWithNestedInputs());
            });
        }

        [Fact]
        public void CreateSkillsetThrowsExceptionWithNonShaperSkillWithNestedInputs()
        {
            Run(() =>
            {
                SearchServiceClient searchClient = Data.GetSearchServiceClient();
                Skillset skillset = CreateTestSkillsetWithNestedInputs(isShaper: false);
                CloudException exception = Assert.Throws<CloudException>(() => searchClient.Skillsets.Create(skillset));
                Assert.Contains("Skill '#1' is not allowed to have recursively defined inputs", exception.Message);
            });
        }

        [Fact]
        public void CreateSkillsetReturnsCorrectDefinitionOcrSplitText()
        {
            Run(() =>
            {
                SearchServiceClient searchClient = Data.GetSearchServiceClient();
                CreateAndValidateSkillset(searchClient, CreateTestSkillsetOcrSplitText(OcrSkillLanguage.En, SplitSkillLanguage.En, TextSplitMode.Pages));
                CreateAndValidateSkillset(searchClient, CreateTestSkillsetOcrSplitText(OcrSkillLanguage.Fr, SplitSkillLanguage.Fr, TextSplitMode.Pages));
                CreateAndValidateSkillset(searchClient, CreateTestSkillsetOcrSplitText(OcrSkillLanguage.Fi, SplitSkillLanguage.Fi, TextSplitMode.Sentences));
                CreateAndValidateSkillset(searchClient, CreateTestSkillsetOcrSplitText(OcrSkillLanguage.Da, SplitSkillLanguage.Da, TextSplitMode.Sentences));
            });
        }

        [Fact]
        public void CreateSkillsetReturnsCorrectDefinitionTextTranslation()
        {
            Run(() =>
            {
                SearchServiceClient searchClient = Data.GetSearchServiceClient();
                CreateAndValidateSkillset(searchClient, CreateTestSkillsetTextTranslation(TextTranslationSkillLanguage.Es));
                CreateAndValidateSkillset(searchClient, CreateTestSkillsetTextTranslation(TextTranslationSkillLanguage.Es, defaultFromLanguageCode: TextTranslationSkillLanguage.En));
                CreateAndValidateSkillset(searchClient, CreateTestSkillsetTextTranslation(TextTranslationSkillLanguage.Es, suggestedFrom: TextTranslationSkillLanguage.En));
                CreateAndValidateSkillset(searchClient, CreateTestSkillsetTextTranslation(TextTranslationSkillLanguage.Es, TextTranslationSkillLanguage.En, TextTranslationSkillLanguage.En));
            });
        }

        [Fact]
        public void CreateSkillsetReturnsCorrectDefinitionConditional()
        {
            Run(() =>
            {
                SearchServiceClient searchClient = Data.GetSearchServiceClient();
                CreateAndValidateSkillset(searchClient, CreateTestSkillsetConditional());
            });
        }

        [Fact]
        public void CreateOrUpdateCreatesWhenSkillsetDoesNotExist()
        {
            Run(() =>
            {
                SearchServiceClient searchClient = Data.GetSearchServiceClient();

                Skillset skillset = CreateTestOcrSkillset(1, TextExtractionAlgorithm.Printed);

                AzureOperationResponse<Skillset> response =
                    searchClient.Skillsets.CreateOrUpdateWithHttpMessagesAsync(skillset.Name, skillset).Result;
                Assert.Equal(HttpStatusCode.Created, response.Response.StatusCode);
            });
        }

        [Fact]
        public void CreateSkillsetReturnsCorrectDefinitionWithCognitiveServicesDefault()
        {
            Run(() =>
            {
                SearchServiceClient searchClient = Data.GetSearchServiceClient();
                CreateAndValidateSkillset(searchClient, CreateSkillsetWithCognitiveServicesKey());
            });
        }

        [Fact]
        public void CreateOrUpdateUpdatesWhenSkillsetExists()
        {
            Run(() =>
            {
                SearchServiceClient searchClient = Data.GetSearchServiceClient();

                Skillset skillset = CreateTestOcrSkillset(1, TextExtractionAlgorithm.Handwritten);

                AzureOperationResponse<Skillset> response =
                    searchClient.Skillsets.CreateOrUpdateWithHttpMessagesAsync(skillset.Name, skillset).Result;
                Assert.Equal(HttpStatusCode.Created, response.Response.StatusCode);

                skillset = CreateTestOcrSkillset(2, TextExtractionAlgorithm.Printed, skillset.Name);
                response =
                    searchClient.Skillsets.CreateOrUpdateWithHttpMessagesAsync(skillset.Name, skillset).Result;
                Assert.Equal(HttpStatusCode.OK, response.Response.StatusCode);
            });
        }

        [Fact]
        public void GetOcrSkillsetReturnsCorrectDefinition()
        {
            Run(() =>
            {
                SearchServiceClient searchClient = Data.GetSearchServiceClient();
                CreateAndGetSkillset(searchClient, CreateTestOcrSkillset(1, TextExtractionAlgorithm.Printed));
            });
        }

        [Fact]
        public void GetOcrSkillsetWithShouldDetectOrientationReturnsCorrectDefinition()
        {
            Run(() =>
            {
                SearchServiceClient searchClient = Data.GetSearchServiceClient();
                CreateAndGetSkillset(searchClient, CreateTestOcrSkillset(repeat: 1, algorithm: TextExtractionAlgorithm.Printed, shouldDetectOrientation: true));
            });
        }

        [Fact]
        public void GetSkillsetThrowsOnNotFound()
        {
            Run(() =>
            {
                SearchServiceClient searchClient = Data.GetSearchServiceClient();

                SearchAssert.ThrowsCloudException(
                    () => searchClient.Skillsets.Get("thisSkillsetdoesnotexist"),
                    HttpStatusCode.NotFound);
            });
        }

        [Fact]
        public void DeleteSkillsetIsIdempotent()
        {
            Run(() =>
            {
                SearchServiceClient searchClient = Data.GetSearchServiceClient();

                Skillset skillset = CreateTestOcrSkillset(1, TextExtractionAlgorithm.Printed);

                // Try delete before the Skillset even exists.
                AzureOperationResponse deleteResponse =
                    searchClient.Skillsets.DeleteWithHttpMessagesAsync(skillset.Name).Result;
                Assert.Equal(HttpStatusCode.NotFound, deleteResponse.Response.StatusCode);

                searchClient.Skillsets.Create(skillset);

                // Now delete twice.
                deleteResponse = searchClient.Skillsets.DeleteWithHttpMessagesAsync(skillset.Name).Result;
                Assert.Equal(HttpStatusCode.NoContent, deleteResponse.Response.StatusCode);

                deleteResponse = searchClient.Skillsets.DeleteWithHttpMessagesAsync(skillset.Name).Result;
                Assert.Equal(HttpStatusCode.NotFound, deleteResponse.Response.StatusCode);
            });
        }

        [Fact]
        public void ExistsReturnsFalseForNonExistingSkillset()
        {
            Run(() =>
            {
                SearchServiceClient client = Data.GetSearchServiceClient();
                Assert.False(client.Skillsets.Exists("nonexistent"));
            });
        }

        [Fact]
        public void ExistsReturnsTrueForExistingSkillset()
        {
            Run(() =>
            {
                SearchServiceClient client = Data.GetSearchServiceClient();
                Skillset skillset = CreateTestOcrSkillset(1, TextExtractionAlgorithm.Handwritten);

                try
                {
                    client.Skillsets.Create(skillset);
                    Assert.True(client.Skillsets.Exists(skillset.Name));
                }
                finally
                {
                    client.Skillsets.Delete(skillset.Name);
                }
            });
        }

        [Fact]
        public void CreateOrUpdateSkillsetIfNotExistsFailsOnExistingResource()
        {
            Run(() =>
            {
                AccessConditionTests.CreateOrUpdateIfNotExistsFailsOnExistingResource(
                    Data.GetSearchServiceClient().Skillsets.CreateOrUpdate,
                    () => CreateTestSkillsetOcrEntity(
                        TextExtractionAlgorithm.Printed,
                        new List<EntityCategory>
                        {
                            EntityCategory.Person,
                            EntityCategory.Location
                        }),
                    MutateSkillset);
            });
        }

        [Fact]
        public void CreateOrUpdateSkillsetIfNotExistsSucceedsOnNoResource()
        {
            Run(() =>
            {
                AccessConditionTests.CreateOrUpdateIfNotExistsSucceedsOnNoResource(
                    Data.GetSearchServiceClient().Skillsets.CreateOrUpdate,
                    () => CreateTestSkillsetOcrEntity(
                        TextExtractionAlgorithm.Printed,
                        new List<EntityCategory>
                        {
                            EntityCategory.Person,
                            EntityCategory.Location
                        }));
            });
        }

        [Fact]
        public void UpdateSkillsetIfExistsSucceedsOnExistingResource()
        {
            Run(() =>
            {
                AccessConditionTests.UpdateIfExistsSucceedsOnExistingResource(
                    Data.GetSearchServiceClient().Skillsets.CreateOrUpdate,
                    () => CreateTestSkillsetOcrEntity(
                        TextExtractionAlgorithm.Printed,
                        new List<EntityCategory>
                        {
                            EntityCategory.Person,
                            EntityCategory.Location
                        }),
                    MutateSkillset);
            });
        }

        [Fact]
        public void UpdateSkillsetIfExistsFailsOnNoResource()
        {
            Run(() =>
            {
                AccessConditionTests.UpdateIfExistsFailsOnNoResource(
                    Data.GetSearchServiceClient().Skillsets.CreateOrUpdate,
                    () => CreateTestSkillsetOcrEntity(
                        TextExtractionAlgorithm.Printed,
                        new List<EntityCategory>
                        {
                            EntityCategory.Person,
                            EntityCategory.Location
                        }));
            });
        }

        [Fact]
        public void UpdateSkillsetIfNotChangedSucceedsWhenResourceUnchanged()
        {
            Run(() =>
            {
                AccessConditionTests.UpdateIfNotChangedSucceedsWhenResourceUnchanged(
                    Data.GetSearchServiceClient().Skillsets.CreateOrUpdate,
                    () => CreateTestSkillsetOcrEntity(
                        TextExtractionAlgorithm.Printed,
                        new List<EntityCategory>
                        {
                            EntityCategory.Person,
                            EntityCategory.Location
                        }),
                    MutateSkillset);
            });
        }

        [Fact]
        public void UpdateSkillsetIfNotChangedFailsWhenResourceChanged()
        {
            Run(() =>
            {
                AccessConditionTests.UpdateIfNotChangedFailsWhenResourceChanged(
                    Data.GetSearchServiceClient().Skillsets.CreateOrUpdate,
                    () => CreateTestSkillsetOcrEntity(
                        TextExtractionAlgorithm.Printed,
                        new List<EntityCategory>
                        {
                            EntityCategory.Person,
                            EntityCategory.Location
                        }),
                    MutateSkillset);
            });
        }

        [Fact]
        public void DeleteSkillsetIfNotChangedWorksOnlyOnCurrentResource()
        {
            Run(() =>
            {
                SearchServiceClient searchClient = Data.GetSearchServiceClient();

                Skillset Skillset = CreateTestSkillsetOcrEntity(
                    TextExtractionAlgorithm.Printed,
                    new List<EntityCategory>
                    {
                        EntityCategory.Person,
                        EntityCategory.Location
                    });

                AccessConditionTests.DeleteIfNotChangedWorksOnlyOnCurrentResource(
                    searchClient.Skillsets.Delete,
                    () => searchClient.Skillsets.CreateOrUpdate(Skillset),
                    x => searchClient.Skillsets.CreateOrUpdate(MutateSkillset(x)),
                    Skillset.Name);
            });
        }

        [Fact]
        public void DeleteSkillsetIfExistsWorksOnlyWhenResourceExists()
        {
            Run(() =>
            {
                SearchServiceClient searchClient = Data.GetSearchServiceClient();

                Skillset Skillset = CreateTestSkillsetOcrEntity(
                    TextExtractionAlgorithm.Printed, 
                    new List<EntityCategory>
                    {
                        EntityCategory.Person,
                        EntityCategory.Location
                    });

                AccessConditionTests.DeleteIfExistsWorksOnlyWhenResourceExists(
                    searchClient.Skillsets.Delete,
                    () => searchClient.Skillsets.CreateOrUpdate(Skillset),
                    Skillset.Name);
            });
        }

        public static Skillset CreateTestSkillsetOcrEntity(TextExtractionAlgorithm? algorithm, List<EntityCategory> categories)
        {
            var skills = new List<Skill>();

            var inputs = new List<InputFieldMappingEntry>()
            {
                new InputFieldMappingEntry { Name = "url", Source = "/document/url" },
                new InputFieldMappingEntry { Name = "queryString", Source = "/document/queryString" }
            };

            var outputs = new List<OutputFieldMappingEntry>()
            {
                new OutputFieldMappingEntry { Name = "text", TargetName = "mytext" }
            };

            skills.Add(new OcrSkill(inputs, outputs, "myocr", "Tested OCR skill", RootPathString)
            {
                TextExtractionAlgorithm = algorithm,
                DefaultLanguageCode = OcrSkillLanguage.En
            });

            var inputs1 = new List<InputFieldMappingEntry>()
            {
                new InputFieldMappingEntry
                {
                    Name = "text",
                    Source = "/document/mytext"
                }
            };

            var outputs1 = new List<OutputFieldMappingEntry>()
            {
                new OutputFieldMappingEntry
                {
                    Name = "entities",
                    TargetName = "myEntities"
                }
            };

            skills.Add(new EntityRecognitionSkill(
                inputs1, 
                outputs1, 
                name: "myentity", 
                description: "Tested Entity Recognition skill", 
                context: RootPathString)
            {
                Categories = categories,
                DefaultLanguageCode = EntityRecognitionSkillLanguage.En,
                MinimumPrecision = 0.5
            });

            return new Skillset("testskillset", "Skillset for testing", skills);
        }

        private static Skillset MutateSkillset(Skillset skillset)
        {
            skillset.Description = "Mutated Skillset";
            return skillset;
        }

        private void CreateAndGetSkillset(SearchServiceClient searchClient, Skillset expectedSkillset)
        {
            try
            {
                searchClient.Skillsets.Create(expectedSkillset);
                Skillset actualSkillset = searchClient.Skillsets.Get(expectedSkillset.Name);
                AssertSkillsetEqual(expectedSkillset, actualSkillset);
            }
            finally
            {
                searchClient.Skillsets.Delete(expectedSkillset.Name);
            }
        }

        private static Skillset CreateSkillsetWithOcrDefaultSettings()
        {
            var skills = new List<Skill>();

            var inputs = new List<InputFieldMappingEntry>()
            {
                new InputFieldMappingEntry { Name = "url", Source = "/document/url" },
                new InputFieldMappingEntry { Name = "queryString", Source = "/document/queryString" }
            };

            var outputs = new List<OutputFieldMappingEntry>()
            {
                new OutputFieldMappingEntry { Name = "text", TargetName = "mytext" }
            };

            skills.Add(new OcrSkill(
                inputs, 
                outputs, 
                name: "myocr",
                description: "Tested OCR skill", 
                context: RootPathString));

            return new Skillset(SearchTestUtilities.GenerateName(), description: "Skillset for testing default configuration", skills: skills);
        }

        private static Skillset CreateSkillsetWithImageAnalysisDefaultSettings()
        {
            var skills = new List<Skill>();

            var inputs = new List<InputFieldMappingEntry>()
            {
                new InputFieldMappingEntry { Name = "url", Source = "/document/url" },
                new InputFieldMappingEntry { Name = "queryString", Source = "/document/queryString" }
            };

            var outputs = new List<OutputFieldMappingEntry>()
            {
                new OutputFieldMappingEntry { Name = "description", TargetName = "mydescription" }
            };

            skills.Add(new ImageAnalysisSkill(
                inputs, 
                outputs, 
                name: "myimage",
                description: "Tested image analysis skill", 
                context: RootPathString));

            return new Skillset(SearchTestUtilities.GenerateName(), description: "Skillset for testing default configuration", skills: skills);
        }

        private static Skillset CreateSkillsetWithKeyPhraseExtractionDefaultSettings()
        {
            var skills = new List<Skill>();

            var inputs = new List<InputFieldMappingEntry>()
            {
                new InputFieldMappingEntry
                {
                    Name = "text",
                    Source = "/document/myText"
                }
            };

            var outputs = new List<OutputFieldMappingEntry>()
            {
                new OutputFieldMappingEntry
                {
                    Name = "keyPhrases",
                    TargetName = "myKeyPhrases"
                }
            };

            skills.Add(new KeyPhraseExtractionSkill(
                inputs, 
                outputs,
                name: "mykeyphrases", 
                description: "Tested Key Phrase skill", 
                context: RootPathString));

            return new Skillset(SearchTestUtilities.GenerateName(), description: "Skillset for testing default configuration", skills: skills);
        }

        private static Skillset CreateSkillsetWithMergeDefaultSettings()
        {
            var skills = new List<Skill>();

            var inputs = new List<InputFieldMappingEntry>()
            {
                new InputFieldMappingEntry
                {
                    Name = "text",
                    Source = "/document/text"
                },
                new InputFieldMappingEntry
                {
                    Name = "itemsToInsert",
                    Source = "/document/textitems"
                },
                new InputFieldMappingEntry
                {
                    Name = "offsets",
                    Source = "/document/offsets"
                }
            };

            var outputs = new List<OutputFieldMappingEntry>()
            {
                new OutputFieldMappingEntry
                {
                    Name = "mergedText",
                    TargetName = "myMergedText"
                }
            };

            skills.Add(new MergeSkill(
                inputs, 
                outputs,
                name: "mymerge", 
                description: "Tested Merged Text skill", 
                context: RootPathString));

            return new Skillset(SearchTestUtilities.GenerateName(), description: "Skillset for testing default configuration", skills: skills);
        }

        private static Skillset CreateSkillsetWithEntityRecognitionDefaultSettings()
        {
            var skills = new List<Skill>();

            var inputs = new List<InputFieldMappingEntry>()
            {
                new InputFieldMappingEntry
                {
                    Name = "text",
                    Source = "/document/mytext"
                }
            };

            var outputs = new List<OutputFieldMappingEntry>()
            {
                new OutputFieldMappingEntry
                {
                    Name = "entities",
                    TargetName = "myEntities"
                }
            };

            skills.Add(new EntityRecognitionSkill(
                inputs, 
                outputs,
                name: "myentity", 
                description: "Tested Entity Recognition skill", 
                context: RootPathString));

            return new Skillset(SearchTestUtilities.GenerateName(), description: "Skillset for testing default configuration", skills: skills);
        }

        private static Skillset CreateSkillsetWithSentimentDefaultSettings()
        {
            var skills = new List<Skill>();

            var inputs = new List<InputFieldMappingEntry>()
            {
                new InputFieldMappingEntry
                {
                    Name = "text",
                    Source = "/document/mytext"
                }
            };

            var outputs = new List<OutputFieldMappingEntry>()
            {
                new OutputFieldMappingEntry
                {
                    Name = "score",
                    TargetName = "mySentiment"
                }
            };

            skills.Add(new SentimentSkill(
                inputs, 
                outputs, 
                name: "mysentiment",
                description: "Tested Sentiment skill", 
                context: RootPathString));

            return new Skillset(SearchTestUtilities.GenerateName(), description: "Skillset for testing default configuration", skills: skills);
        }

        private static Skillset CreateSkillsetWithSplitDefaultSettings()
        {
            var skills = new List<Skill>();

            var inputs = new List<InputFieldMappingEntry>()
            {
                new InputFieldMappingEntry
                {
                    Name = "text",
                    Source = "/document/mytext"
                }
            };

            var outputs = new List<OutputFieldMappingEntry>()
            {
                new OutputFieldMappingEntry
                {
                    Name = "textItems",
                    TargetName = "myTextItems"
                }
            };

            skills.Add(new SplitSkill(
                inputs, 
                outputs,
                name: "mysplit", 
                description: "Tested Split skill", 
                context: RootPathString)
            {
                TextSplitMode = TextSplitMode.Pages
            });

            return new Skillset(SearchTestUtilities.GenerateName(), description: "Skillset for testing default configuration", skills: skills);
        }

        private static Skillset CreateTestOcrSkillset(int repeat, TextExtractionAlgorithm algorithm, string name = null, bool shouldDetectOrientation = false)
        {
            var skills = new List<Skill>();

            var inputs = new List<InputFieldMappingEntry>()
            {
                new InputFieldMappingEntry { Name = "url", Source = "/document/url" },
                new InputFieldMappingEntry { Name = "queryString", Source = "/document/queryString" }
            };

            for (int i = 0; i < repeat; i++)
            {
                var outputs = new List<OutputFieldMappingEntry>()
                {
                    new OutputFieldMappingEntry { Name = "text", TargetName = "mytext" + i }
                };

                skills.Add(new OcrSkill(
                    inputs, 
                    outputs,
                    name: "myocr-" + i, 
                    description: "Tested OCR skill", 
                    context: RootPathString)
                {
                    TextExtractionAlgorithm = algorithm,
                    ShouldDetectOrientation = shouldDetectOrientation,
                    DefaultLanguageCode = OcrSkillLanguage.En
                });
            }

            return new Skillset(name: name ?? SearchTestUtilities.GenerateName(), description: "Skillset for testing OCR", skills: skills);
        }

        private void CreateAndValidateSkillset(SearchServiceClient searchClient, Skillset expectedSkillset)
        {
            try
            {
                Skillset actualSkillset = searchClient.Skillsets.Create(expectedSkillset);
                AssertSkillsetEqual(expectedSkillset, actualSkillset);
            }
            finally
            {
                searchClient.Skillsets.Delete(expectedSkillset.Name);
            }
        }

        private static void AssertSkillsetEqual(Skillset expected, Skillset actual)
        {
            Assert.Equal(expected, actual, new DataPlaneModelComparer<Skillset>());
        }

        private static Skillset CreateTestSkillsetOcrKeyPhrase(OcrSkillLanguage ocrLanguageCode, KeyPhraseExtractionSkillLanguage keyPhraseLanguageCode)
        {
            var skills = new List<Skill>();

            var inputs = new List<InputFieldMappingEntry>()
            {
                new InputFieldMappingEntry { Name = "url", Source = "/document/url" },
                new InputFieldMappingEntry { Name = "queryString", Source = "/document/queryString" }
            };

            var outputs = new List<OutputFieldMappingEntry>()
            {
                new OutputFieldMappingEntry { Name = "text", TargetName = "mytext" }
            };

            skills.Add(new OcrSkill(
                inputs, 
                outputs,
                name: "myocr", 
                description: "Tested OCR skill", 
                context: RootPathString)
            {
                TextExtractionAlgorithm = TextExtractionAlgorithm.Printed,
                DefaultLanguageCode = ocrLanguageCode
            });

            var inputs1 = new List<InputFieldMappingEntry>()
            {
                new InputFieldMappingEntry
                {
                    Name = "text",
                    Source = "/document/mytext"
                }
            };

            var outputs1 = new List<OutputFieldMappingEntry>()
            {
                new OutputFieldMappingEntry
                {
                    Name = "keyPhrases",
                    TargetName = "myKeyPhrases"
                }
            };

            skills.Add(new KeyPhraseExtractionSkill(
                inputs1, 
                outputs1,
                name: "mykeyphrases", 
                description: "Tested Key Phrase skill", 
                context: RootPathString)
            {
                DefaultLanguageCode = keyPhraseLanguageCode
            });

            return new Skillset("testskillset", "Skillset for testing", skills);
        }

        private static Skillset CreateTestSkillsetOcrSentiment(OcrSkillLanguage ocrLanguageCode, SentimentSkillLanguage sentimentLanguageCode, TextExtractionAlgorithm algorithm)
        {
            var skills = new List<Skill>();

            var inputs = new List<InputFieldMappingEntry>()
            {
                new InputFieldMappingEntry { Name = "url", Source = "/document/url" },
                new InputFieldMappingEntry { Name = "queryString", Source = "/document/queryString" }
            };

            var outputs = new List<OutputFieldMappingEntry>()
            {
                new OutputFieldMappingEntry { Name = "text", TargetName = "mytext" }
            };

            skills.Add(
                new OcrSkill(
                    inputs, 
                    outputs,
                    name: "myocr",
                    description: "Tested OCR skill", 
                    context: RootPathString)
            {
                TextExtractionAlgorithm = algorithm,
                DefaultLanguageCode = ocrLanguageCode
            });

            var inputs1 = new List<InputFieldMappingEntry>()
            {
                new InputFieldMappingEntry
                {
                    Name = "text",
                    Source = "/document/mytext"
                }
            };

            var outputs1 = new List<OutputFieldMappingEntry>()
            {
                new OutputFieldMappingEntry
                {
                    Name = "score",
                    TargetName = "mySentiment"
                }
            };

            skills.Add(new SentimentSkill(
                inputs1, 
                outputs1,
                name: "mysentiment", 
                description: "Tested Sentiment skill", 
                context: RootPathString)
            {
                DefaultLanguageCode = sentimentLanguageCode
            });

            return new Skillset("testskillset1", "Skillset for testing", skills);
        }

        private static Skillset CreateTestSkillsetImageAnalysisKeyPhrase()
        {
            var skills = new List<Skill>();

            var inputs = new List<InputFieldMappingEntry>()
            {
                new InputFieldMappingEntry { Name = "url", Source = "/document/url" },
                new InputFieldMappingEntry { Name = "queryString", Source = "/document/queryString" }
            };

            var outputs = new List<OutputFieldMappingEntry>()
            {
                new OutputFieldMappingEntry { Name = "description", TargetName = "mydescription" }
            };

            skills.Add(new ImageAnalysisSkill(
                inputs, 
                outputs,
                name: "myimage", 
                description: "Tested image analysis skill", 
                context: RootPathString)
            {
                VisualFeatures = new List<VisualFeature>
                {
                    VisualFeature.Categories,
                    VisualFeature.Color,
                    VisualFeature.Description,
                    VisualFeature.Faces,
                    VisualFeature.ImageType,
                    VisualFeature.Tags
                },
                Details = new List<ImageDetail>
                {
                    ImageDetail.Celebrities,
                    ImageDetail.Landmarks
                },
                DefaultLanguageCode = ImageAnalysisSkillLanguage.En
            });

            var inputs1 = new List<InputFieldMappingEntry>()
            {
                new InputFieldMappingEntry
                {
                    Name = "text",
                    Source = "/document/mydescription/*/Tags/*"
                }
            };

            var outputs1 = new List<OutputFieldMappingEntry>()
            {
                new OutputFieldMappingEntry
                {
                    Name = "keyPhrases",
                    TargetName = "myKeyPhrases"
                }
            };

            skills.Add(new KeyPhraseExtractionSkill(
                inputs1, 
                outputs1, 
                name: "mykeyphrases",
                description: "Tested Key Phrase skill", 
                context: RootPathString)
            {
                DefaultLanguageCode = KeyPhraseExtractionSkillLanguage.En
            });

            return new Skillset("testskillset2", "Skillset for testing", skills);
        }

        private static Skillset CreateTestSkillsetLanguageDetection()
        {
            var skills = new List<Skill>();

            var inputs = new List<InputFieldMappingEntry>()
            {
                new InputFieldMappingEntry
                {
                    Name = "text",
                    Source = "/document/text"
                }
            };

            var outputs = new List<OutputFieldMappingEntry>()
            {
                new OutputFieldMappingEntry
                {
                    Name = "languageCode",
                    TargetName = "myLanguageCode"
                }
            };

            skills.Add(new LanguageDetectionSkill(
                inputs, 
                outputs,
                name: "mylanguage", 
                description: "Tested Language Detection skill", 
                context: RootPathString));

            return new Skillset("testskillset3", "Skillset for testing", skills);
        }

        private static Skillset CreateTestSkillsetMergeText()
        {
            var skills = new List<Skill>();

            var inputs = new List<InputFieldMappingEntry>()
            {
                new InputFieldMappingEntry
                {
                    Name = "text",
                    Source = "/document/text"
                },
                new InputFieldMappingEntry
                {
                    Name = "itemsToInsert",
                    Source = "/document/textitems"
                },
                new InputFieldMappingEntry
                {
                    Name = "offsets",
                    Source = "/document/offsets"
                }
            };

            var outputs = new List<OutputFieldMappingEntry>()
            {
                new OutputFieldMappingEntry
                {
                    Name = "mergedText",
                    TargetName = "myMergedText"
                }
            };

            skills.Add(new MergeSkill(
                inputs, 
                outputs, 
                name: "mymerge",
                description: "Tested Merged Text skill", 
                context: RootPathString)
            {
                InsertPreTag = "__",
                InsertPostTag = "__e"
            });

            return new Skillset("testskillset4", "Skillset for testing", skills);
        }

        private static Skillset CreateTestSkillsetOcrShaper()
        {
            var skills = new List<Skill>();

            var inputs = new List<InputFieldMappingEntry>()
            {
                new InputFieldMappingEntry { Name = "url", Source = "/document/url" },
                new InputFieldMappingEntry { Name = "queryString", Source = "/document/queryString" }
            };

            var outputs = new List<OutputFieldMappingEntry>()
            {
                new OutputFieldMappingEntry { Name = "text", TargetName = "mytext" }
            };

            skills.Add(new OcrSkill(
                inputs, 
                outputs,
                name: "myocr", 
                description: "Tested OCR skill", 
                context: RootPathString)
            {
                TextExtractionAlgorithm = TextExtractionAlgorithm.Printed,
                DefaultLanguageCode = OcrSkillLanguage.En
            });

            var inputs1 = new List<InputFieldMappingEntry>()
            {
                new InputFieldMappingEntry
                {
                    Name = "text",
                    Source = "/document/mytext"
                }
            };

            var outputs1 = new List<OutputFieldMappingEntry>()
            {
                new OutputFieldMappingEntry
                {
                    Name = "output",
                    TargetName = "myOutput"
                }
            };

            skills.Add(new ShaperSkill(
                inputs1, 
                outputs1,
                name: "myshaper", 
                description: "Tested Shaper skill", 
                context: RootPathString));

            return new Skillset("testskillset", "Skillset for testing", skills);
        }

        private static Skillset CreateSkillsetWithCognitiveServicesKey()
        {
            var skills = new List<Skill>();

            var inputs = new List<InputFieldMappingEntry>()
            {
                new InputFieldMappingEntry { Name = "url", Source = "/document/url" },
                new InputFieldMappingEntry { Name = "queryString", Source = "/document/queryString" }
            };

            var outputs = new List<OutputFieldMappingEntry>()
            {
                new OutputFieldMappingEntry { Name = "text", TargetName = "mytext" }
            };

            skills.Add(new OcrSkill(
                inputs, 
                outputs,
                name: "myocr", 
                description: "Tested OCR skill", 
                context: RootPathString)
            {
                TextExtractionAlgorithm = TextExtractionAlgorithm.Printed,
                DefaultLanguageCode = OcrSkillLanguage.En
            });

            return new Skillset("testskillset", "Skillset for testing", skills, new DefaultCognitiveServices());
        }

        private static Skillset CreateTestSkillsetOcrSplitText(OcrSkillLanguage ocrLanguageCode, SplitSkillLanguage splitLanguageCode, TextSplitMode textSplitMode)
        {
            var skills = new List<Skill>();

            var inputs = new List<InputFieldMappingEntry>()
            {
                new InputFieldMappingEntry { Name = "url", Source = "/document/url" },
                new InputFieldMappingEntry { Name = "queryString", Source = "/document/queryString" }
            };

            var outputs = new List<OutputFieldMappingEntry>()
            {
                new OutputFieldMappingEntry { Name = "text", TargetName = "mytext" }
            };

            skills.Add(new OcrSkill(
                inputs, 
                outputs,
                name: "myocr", 
                description: "Tested OCR skill", 
                context: RootPathString)
            {
                TextExtractionAlgorithm = TextExtractionAlgorithm.Printed,
                DefaultLanguageCode = ocrLanguageCode
            });

            var inputs1 = new List<InputFieldMappingEntry>()
            {
                new InputFieldMappingEntry
                {
                    Name = "text",
                    Source = "/document/mytext"
                }
            };

            var outputs1 = new List<OutputFieldMappingEntry>()
            {
                new OutputFieldMappingEntry
                {
                    Name = "textItems",
                    TargetName = "myTextItems"
                }
            };

            skills.Add(new SplitSkill(
                inputs1, 
                outputs1, 
                name: "mysplit",
                description: "Tested Split skill", 
                context: RootPathString)
            {
                TextSplitMode = textSplitMode,
                DefaultLanguageCode = splitLanguageCode
            });

            return new Skillset("testskillset", "Skillset for testing", skills);
        }

        private static Skillset CreateTestSkillsetWithNestedInputs(bool isShaper = true)
        {
            var skills = new List<Skill>();

            var inputs = new List<InputFieldMappingEntry>()
            {
                new InputFieldMappingEntry
                {
                    Name = "doc",
                    SourceContext = "/document",
                    Inputs = new List<InputFieldMappingEntry>
                    {
                        new InputFieldMappingEntry
                        {
                            Name = "text",
                            Source = "/document/content"
                        },
                        new InputFieldMappingEntry
                        {
                            Name = "images",
                            Source = "/document/normalized_images/*"
                        }
                    }
                }
            };

            var outputs = new List<OutputFieldMappingEntry>()
            {
                new OutputFieldMappingEntry
                {
                    Name = "output",
                    TargetName = "myOutput"
                }
            };

            if (isShaper)
            {
                skills.Add(new ShaperSkill(
                    inputs, 
                    outputs, 
                    name: "myshaper",
                    description: "Tested Shaper skill", 
                    context: RootPathString));
            }
            else
            {
                // Used for testing skill that shouldn't allow nested inputs
                skills.Add(new WebApiSkill(
                    inputs, 
                    outputs,
                    uri: "https://contoso.example.org",
                    description: "Invalid skill with nested inputed", 
                    context: RootPathString));
            }

            return new Skillset("testskillset", "Skillset for testing", skills);
        }

        private static Skillset CreateTestSkillsetTextTranslation(TextTranslationSkillLanguage defaultToLanguageCode, TextTranslationSkillLanguage? defaultFromLanguageCode = null, TextTranslationSkillLanguage? suggestedFrom = null)
        {
            var skills = new List<Skill>();

            var inputs = new List<InputFieldMappingEntry>()
            {
                new InputFieldMappingEntry
                {
                    Name = "text",
                    Source = "/document/text"
                }
            };

            var outputs = new List<OutputFieldMappingEntry>()
            {
                new OutputFieldMappingEntry
                {
                    Name = "translatedText",
                    TargetName = "translatedText"
                },
                new OutputFieldMappingEntry
                {
                    Name = "translatedFromLanguageCode",
                    TargetName = "translatedFromLanguageCode"
                },
                new OutputFieldMappingEntry
                {
                    Name = "translatedToLanguageCode",
                    TargetName = "translatedToLanguageCode"
                }
            };

            skills.Add(new TextTranslationSkill(
                inputs, 
                outputs, 
                defaultToLanguageCode, 
                name: "mytranslate",
                defaultFromLanguageCode: defaultFromLanguageCode, 
                suggestedFrom: suggestedFrom));

            return new Skillset("testskillset", "Skillset for testing", skills);
        }

        private static Skillset CreateTestSkillsetConditional()
        {
            var skills = new List<Skill>();

            var inputs = new List<InputFieldMappingEntry>()
            {
                new InputFieldMappingEntry
                {
                    Name = "condition",
                    Source = "= $(/document/language) == null"
                },
                new InputFieldMappingEntry
                {
                    Name = "whenTrue",
                    Source = "= 'es'"
                },
                new InputFieldMappingEntry
                {
                    Name = "whenFalse",
                    Source = "= $(/document/language)"
                }
            };

            var outputs = new List<OutputFieldMappingEntry>()
            {
                new OutputFieldMappingEntry
                {
                    Name = "output",
                    TargetName = "myLanguageCode"
                }
            };

            skills.Add(new ConditionalSkill(
                inputs, 
                outputs,
                name: "myconditional", 
                description: "Tested Conditional skill", 
                context: RootPathString));

            return new Skillset("testskillset3", "Skillset for testing", skills);
        }

        private static Skillset CreateTestSkillsetWebApiSkill(bool includeHeader = true)
        {
            var skills = new List<Skill>();

            var inputs = new List<InputFieldMappingEntry>()
            {
                new InputFieldMappingEntry
                {
                    Name = "text",
                    Source = "/document/text"
                }
            };

            var outputs = new List<OutputFieldMappingEntry>()
            {
                new OutputFieldMappingEntry
                {
                    Name = "coolResult",
                    TargetName = "myCoolResult"
                }
            };

            var skill = new WebApiSkill(
                    inputs,
                    outputs,
                    uri: "https://contoso.example.org",
                    name: "mywebapi",
                    description: "A simple web api skill",
                    context: RootPathString)
            {
                HttpMethod = "POST",
                DegreeOfParallelism = 7
            };

            if (includeHeader)
            {
                skill.HttpHeaders = new Dictionary<string, string>
                {
                    ["x-ms-example"] = "example"
                };
            }

            skills.Add(skill);

            return new Skillset("webapiskillset", "Skillset for testing", skills);
        }


        private static Skillset CreateSkillsetWithCustomEntityLookup()
        {
            var skills = new List<Skill>();

            var inputs = new List<InputFieldMappingEntry>()
            {
                new InputFieldMappingEntry
                {
                    Name = "text",
                    Source = "/document/mytext"
                }
            };

            var outputs = new List<OutputFieldMappingEntry>()
            {
                new OutputFieldMappingEntry
                {
                    Name = "entities",
                    TargetName = "myCustomEntities"
                }
            };

            skills.Add(new CustomEntityLookupSkill(
                inputs,
                outputs,
                name: "myCustomEntities",
                description: "Tested Custom Entity Lookup skill",
                entitiesDefinitionUri: "https://www.myblobstorage.net/myEntityDefinition.json",
                context: RootPathString));

            return new Skillset("customentitylookupskillset", description: "Skillset with custom entity lookup skill", skills: skills);
        }

        private static Skillset CreateSkillsetWithInlineCustomEntityLookup()
        {
            var skills = new List<Skill>();

            var inputs = new List<InputFieldMappingEntry>()
            {
                new InputFieldMappingEntry
                {
                    Name = "text",
                    Source = "/document/mytext"
                }
            };

            var outputs = new List<OutputFieldMappingEntry>()
            {
                new OutputFieldMappingEntry
                {
                    Name = "entities",
                    TargetName = "myCustomEntities"
                }
            };

            var entity1 = new CustomEntityLookupSkillEntity(
                                name: "entity1",
                                description: "description passthrough",
                                type: "type passthrough",
                                subtype: "subtype passthrough",
                                id: "123",
                                caseSensitive: null,
                                accentSensitive: null,
                                fuzzyEditDistance: null,
                                defaultCaseSensitive: null,
                                defaultAccentSensitive: null,
                                defaultFuzzyEditDistance: null,
                                aliases: null);

            var entity2Aliases = new List<CustomEntityLookupSkillAlias>();
            var entity2 = new CustomEntityLookupSkillEntity(
                                name: "entity2",
                                description: "description passthrough",
                                type: "type passthrough",
                                subtype: "subtype passthrough",
                                id: "456",
                                caseSensitive: true,
                                accentSensitive: false,
                                fuzzyEditDistance: 1,
                                defaultCaseSensitive: false,
                                defaultAccentSensitive: true,
                                defaultFuzzyEditDistance: 3,
                                aliases: entity2Aliases);


            var entity3Aliases = new List<CustomEntityLookupSkillAlias>();
            var entity3Alias1 = new CustomEntityLookupSkillAlias(
                                text: "e3a1",
                                caseSensitive: null,
                                accentSensitive: null,
                                fuzzyEditDistance: null);
            entity3Aliases.Add(entity3Alias1);
            var entity3Alias2 = new CustomEntityLookupSkillAlias(
                                text: "e3a2",
                                caseSensitive: true,
                                accentSensitive: false,
                                fuzzyEditDistance: 2);
            entity3Aliases.Add(entity3Alias2);
            entity3Aliases.Add(entity3Alias2); // intentional dupe entry

            var entity3 = new CustomEntityLookupSkillEntity(
                                name: "entity2",
                                description: "description passthrough",
                                type: "type passthrough",
                                subtype: "subtype passthrough",
                                id: "456",
                                caseSensitive: null,
                                accentSensitive: null,
                                fuzzyEditDistance: null,
                                defaultCaseSensitive: true,
                                defaultAccentSensitive: true,
                                defaultFuzzyEditDistance: 3,
                                aliases: entity3Aliases);

            var entityArray = new List<CustomEntityLookupSkillEntity>();
            entityArray.Add(entity1);
            entityArray.Add(entity2);
            entityArray.Add(entity3);
            entityArray.Add(entity3); // intentional dupe entry
            var entitiesDefintion = entityArray;

            skills.Add(new CustomEntityLookupSkill(
                inputs,
                outputs,
                name: "myCustomEntities",
                description: "Tested Custom Entity Lookup skill",
                inlineEntitiesDefinition: entitiesDefintion,
                context: RootPathString));

            return new Skillset("customentitylookupskillset", description: "Skillset with inline custom entity lookup skill", skills: skills);
        }

        private static Skillset CreateSkillsetWithDocumentExtraction()
        {
            var skills = new List<Skill>();

            var inputs = new List<InputFieldMappingEntry>()
            {
                new InputFieldMappingEntry
                {
                    Name = "file_data",
                    Source = "/document/file_data"
                }
            };

            var outputs = new List<OutputFieldMappingEntry>()
            {
                new OutputFieldMappingEntry
                {
                    Name = "content",
                    TargetName = "myContent"
                },
                new OutputFieldMappingEntry
                {
                    Name = "normalized_images",
                    TargetName = "normalized_images"
                }
            };

            skills.Add(new DocumentExtractionSkill(
                inputs,
                outputs,
                name: "myDocumentExtraction",
                description: "Tested DocumentExtraction skill",
                parsingMode: "default",
                dataToExtract: "contentAndMetadata",
                configuration: new Dictionary<string, object>()
                {
                    {
                        "imageAction", "generateNormalizedImages"
                    },
                    {
                        "normalizedImageMaxWidth", 2000
                    },
                    {
                        "normalizedImageMaxHeight", 2000
                    }
                },
                context: RootPathString));

            return new Skillset("documentextractionskillset", description: "Skillset with document extraction skill", skills: skills);
        }

        private static Skillset CreateSkillsetWithKnowledgeStore()
        {
            var skills = new List<Skill>();

            var inputs = new List<InputFieldMappingEntry>()
            {
                new InputFieldMappingEntry
                {
                    Name = "file_data",
                    Source = "/document/file_data"
                }
            };

            var outputs = new List<OutputFieldMappingEntry>()
            {
                new OutputFieldMappingEntry
                {
                    Name = "content",
                    TargetName = "myContent"
                },
                new OutputFieldMappingEntry
                {
                    Name = "normalized_images",
                    TargetName = "normalized_images"
                }
            };

            skills.Add(new DocumentExtractionSkill(
                inputs,
                outputs,
                name: "myDocumentExtraction",
                description: "Tested DocumentExtraction skill",
                parsingMode: "default",
                dataToExtract: "contentAndMetadata",
                configuration: new Dictionary<string, object>()
                {
                    {
                        "imageAction", "generateNormalizedImages"
                    },
                    {
                        "normalizedImageMaxWidth", 2000
                    },
                    {
                        "normalizedImageMaxHeight", 2000
                    }
                },
                context: RootPathString));

            var projection1BlobSelector = new KnowledgeStoreObjectProjectionSelector(
                                            storageContainer: "container1",
                                            generatedKeyName: "docKey",
                                            source: "/document/content");

            var projection2BlobSelector = new KnowledgeStoreObjectProjectionSelector(
                                storageContainer: "container2",
                                generatedKeyName: "docKey",
                                sourceContext: "/document",
                                inputs: new List<InputFieldMappingEntry>()
                                {
                                    new InputFieldMappingEntry(
                                        name: "keyPhrases",
                                        source: "/document/keyPhrases")
                                });

            var projection1TableSelector = new KnowledgeStoreTableProjectionSelector(
                                tableName: "container11",
                                generatedKeyName: "docKey",
                                source: "/document/tableContent");

            var projection2TableSelector = new KnowledgeStoreTableProjectionSelector(
                                tableName: "container12",
                                generatedKeyName: "docKey",
                                sourceContext: "/document/tableData",
                                inputs: new List<InputFieldMappingEntry>()
                                {
                                    new InputFieldMappingEntry(
                                        name: "keyPhrases",
                                        source: "/document/tableData/keyPhrases")
                                });

            var projection1FileSelector = new KnowledgeStoreFileProjectionSelector(
                                storageContainer: "container111",
                                generatedKeyName: "docKey",
                                source: "/document/fileContent");

            var knowledgeStore = new KnowledgeStore(
                storageConnectionString: "DefaultEndpointsProtocol=https;AccountName=NotaRealAccount;AccountKey=fake;", // [SuppressMessage("Microsoft.Security", "CS001:SecretInline", Justification = "This is not a real secret")]
                projections: new List<KnowledgeStoreProjection>());

            knowledgeStore.Projections.Add(new KnowledgeStoreProjection(
                objects: new List<KnowledgeStoreObjectProjectionSelector>() { projection1BlobSelector },
                tables: new List<KnowledgeStoreTableProjectionSelector>() { projection1TableSelector },
                files: new List<KnowledgeStoreFileProjectionSelector>() { projection1FileSelector }));

            knowledgeStore.Projections.Add(new KnowledgeStoreProjection(
                objects: new List<KnowledgeStoreObjectProjectionSelector>() { projection2BlobSelector },
                tables: new List<KnowledgeStoreTableProjectionSelector>() { projection2TableSelector }));


            var skillset = new Skillset("knowledgestoreskillset", description: "Skillset with knowledgestore", skills: skills);
            skillset.KnowledgeStore = knowledgeStore;

            return skillset;
        }
    }
}
