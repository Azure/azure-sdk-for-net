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
                CreateAndValidateSkillset(searchClient, CreateTestSkillsetOcrSentiment(OcrSkillLanguage.Pt, SentimentSkillLanguage.PtPt, TextExtractionAlgorithm.Printed));
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

            skills.Add(new OcrSkill(inputs, outputs, "Tested OCR skill", RootPathString)
            {
                TextExtractionAlgorithm = algorithm,
                DefaultLanguageCode = "en"
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

            skills.Add(new EntityRecognitionSkill(inputs1, outputs1, "Tested Entity Recognition skill", RootPathString)
            {
                Categories = categories,
                DefaultLanguageCode = "en",
                MinimumPrecision = 0.5
            });

            return new Skillset("testskillset", "Skillset for testing", skills);
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

            skills.Add(new OcrSkill(inputs, outputs, "Tested OCR skill", RootPathString));

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

            skills.Add(new ImageAnalysisSkill(inputs, outputs, "Tested image analysis skill", RootPathString));

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

            skills.Add(new KeyPhraseExtractionSkill(inputs, outputs, "Tested Key Phrase skill", RootPathString));

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

            skills.Add(new MergeSkill(inputs, outputs, "Tested Merged Text skill", RootPathString));

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

            skills.Add(new EntityRecognitionSkill(inputs, outputs, "Tested Entity Recognition skill", RootPathString));

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

            skills.Add(new SentimentSkill(inputs, outputs, "Tested Sentiment skill", RootPathString));

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

            skills.Add(new SplitSkill(inputs, outputs, "Tested Split skill", RootPathString)
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

                skills.Add(new OcrSkill(inputs, outputs, "Tested OCR skill", RootPathString)
                {
                    TextExtractionAlgorithm = algorithm,
                    ShouldDetectOrientation = shouldDetectOrientation,
                    DefaultLanguageCode = "en"
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

            skills.Add(new OcrSkill(inputs, outputs, "Tested OCR skill", RootPathString)
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

            skills.Add(new KeyPhraseExtractionSkill(inputs1, outputs1, "Tested Key Phrase skill", RootPathString)
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

            skills.Add(new OcrSkill(inputs, outputs, "Tested OCR skill", RootPathString)
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

            skills.Add(new SentimentSkill(inputs1, outputs1, "Tested Sentiment skill", RootPathString)
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

            skills.Add(new ImageAnalysisSkill(inputs, outputs, "Tested image analysis skill", RootPathString)
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
                DefaultLanguageCode = "en"
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

            skills.Add(new KeyPhraseExtractionSkill(inputs1, outputs1, "Tested Key Phrase skill", RootPathString)
            {
                DefaultLanguageCode = "en"
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

            skills.Add(new LanguageDetectionSkill(inputs, outputs, "Tested Language Detection skill", RootPathString));

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

            skills.Add(new MergeSkill(inputs, outputs, "Tested Merged Text skill", RootPathString)
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

            skills.Add(new OcrSkill(inputs, outputs, "Tested OCR skill", RootPathString)
            {
                TextExtractionAlgorithm = TextExtractionAlgorithm.Printed,
                DefaultLanguageCode = "en"
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

            skills.Add(new ShaperSkill(inputs1, outputs1, "Tested Shaper skill", RootPathString));

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

            skills.Add(new OcrSkill(inputs, outputs, "Tested OCR skill", RootPathString)
            {
                TextExtractionAlgorithm = TextExtractionAlgorithm.Printed,
                DefaultLanguageCode = "en"
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

            skills.Add(new OcrSkill(inputs, outputs, "Tested OCR skill", RootPathString)
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

            skills.Add(new SplitSkill(inputs1, outputs1, "Tested Split skill", RootPathString)
            {
                TextSplitMode = textSplitMode,
                DefaultLanguageCode = splitLanguageCode
            });

            return new Skillset("testskillset", "Skillset for testing", skills);
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
                    description: "A simple web api skill",
                    context: RootPathString)
            {
                HttpMethod = "POST"
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
    }
}
