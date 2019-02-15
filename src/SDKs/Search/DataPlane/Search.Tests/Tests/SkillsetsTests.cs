// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

namespace Microsoft.Azure.Search.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;
    using Microsoft.Azure.Search.Models;
    using Microsoft.Azure.Search.Tests.Utilities;
    using Microsoft.Rest.Azure;
    using Xunit;

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
        public void CreateSkillsetThrowsExceptionWithInvalidLanguageSelection()
        {
            Run(() =>
            {
                SearchServiceClient searchClient = Data.GetSearchServiceClient();
                Skillset skillset = CreateTestSkillsetOcrSentiment(OcrSkillLanguage.Fi, SentimentSkillLanguage.Fi, TextExtractionAlgorithm.Handwritten);
                CloudException exception = Assert.Throws<CloudException>(() => searchClient.Skillsets.Create(skillset));
                Assert.Contains("When 'textExtractionAlgorithm' parameter is set to 'handwritten' the only supported value for 'defaultLanguageCode' parameter is 'en'", exception.Message);
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
            List<Skill> skills = new List<Skill>();

            List<InputFieldMappingEntry> inputs = new List<InputFieldMappingEntry>()
            {
                new InputFieldMappingEntry { Name = "url", Source = "/document/url" },
                new InputFieldMappingEntry { Name = "queryString", Source = "/document/queryString" }
            };

            List<OutputFieldMappingEntry> outputs = new List<OutputFieldMappingEntry>()
            {
                new OutputFieldMappingEntry { Name = "text", TargetName = "mytext" }
            };

            skills.Add(new OcrSkill("Tested OCR skill", RootPathString, inputs, outputs)
            {
                TextExtractionAlgorithm = algorithm,
                DefaultLanguageCode = "en"
            });

            List<InputFieldMappingEntry> inputs1 = new List<InputFieldMappingEntry>()
            {
                new InputFieldMappingEntry
                {
                    Name = "text",
                    Source = "/document/mytext"
                }
            };

            List<OutputFieldMappingEntry> outputs1 = new List<OutputFieldMappingEntry>()
            {
                new OutputFieldMappingEntry
                {
                    Name = "entities",
                    TargetName = "myEntities"
                }
            };

            skills.Add(new EntityRecognitionSkill("Tested Entity Recognition skill", RootPathString, inputs1, outputs1)
            {
                Categories = categories,
                DefaultLanguageCode = "en"
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
            List<Skill> skills = new List<Skill>();

            List<InputFieldMappingEntry> inputs = new List<InputFieldMappingEntry>()
            {
                new InputFieldMappingEntry { Name = "url", Source = "/document/url" },
                new InputFieldMappingEntry { Name = "queryString", Source = "/document/queryString" }
            };

            List<OutputFieldMappingEntry> outputs = new List<OutputFieldMappingEntry>()
            {
                new OutputFieldMappingEntry { Name = "text", TargetName = "mytext" }
            };

            skills.Add(new OcrSkill("Tested OCR skill", RootPathString, inputs, outputs));

            return new Skillset(SearchTestUtilities.GenerateName(), description: "Skillset for testing default configuration", skills: skills);
        }

        private static Skillset CreateSkillsetWithImageAnalysisDefaultSettings()
        {
            List<Skill> skills = new List<Skill>();

            List<InputFieldMappingEntry> inputs = new List<InputFieldMappingEntry>()
            {
                new InputFieldMappingEntry { Name = "url", Source = "/document/url" },
                new InputFieldMappingEntry { Name = "queryString", Source = "/document/queryString" }
            };

            List<OutputFieldMappingEntry> outputs = new List<OutputFieldMappingEntry>()
            {
                new OutputFieldMappingEntry { Name = "description", TargetName = "mydescription" }
            };

            skills.Add(new ImageAnalysisSkill("Tested image analysis skill", RootPathString, inputs, outputs));

            return new Skillset(SearchTestUtilities.GenerateName(), description: "Skillset for testing default configuration", skills: skills);
        }

        private static Skillset CreateSkillsetWithKeyPhraseExtractionDefaultSettings()
        {
            List<Skill> skills = new List<Skill>();

            List<InputFieldMappingEntry> inputs = new List<InputFieldMappingEntry>()
            {
                new InputFieldMappingEntry
                {
                    Name = "text",
                    Source = "/document/myText"
                }
            };

            List<OutputFieldMappingEntry> outputs = new List<OutputFieldMappingEntry>()
            {
                new OutputFieldMappingEntry
                {
                    Name = "keyPhrases",
                    TargetName = "myKeyPhrases"
                }
            };

            skills.Add(new KeyPhraseExtractionSkill("Tested Key Phrase skill", RootPathString, inputs, outputs));

            return new Skillset(SearchTestUtilities.GenerateName(), description: "Skillset for testing default configuration", skills: skills);
        }

        private static Skillset CreateSkillsetWithMergeDefaultSettings()
        {
            List<Skill> skills = new List<Skill>();

            List<InputFieldMappingEntry> inputs = new List<InputFieldMappingEntry>()
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

            List<OutputFieldMappingEntry> outputs = new List<OutputFieldMappingEntry>()
            {
                new OutputFieldMappingEntry
                {
                    Name = "mergedText",
                    TargetName = "myMergedText"
                }
            };

            skills.Add(new MergeSkill("Tested Merged Text skill", RootPathString, inputs, outputs));

            return new Skillset(SearchTestUtilities.GenerateName(), description: "Skillset for testing default configuration", skills: skills);
        }

        private static Skillset CreateSkillsetWithEntityRecognitionDefaultSettings()
        {
            List<Skill> skills = new List<Skill>();

            List<InputFieldMappingEntry> inputs = new List<InputFieldMappingEntry>()
            {
                new InputFieldMappingEntry
                {
                    Name = "text",
                    Source = "/document/mytext"
                }
            };

            List<OutputFieldMappingEntry> outputs = new List<OutputFieldMappingEntry>()
            {
                new OutputFieldMappingEntry
                {
                    Name = "entities",
                    TargetName = "myEntities"
                }
            };

            skills.Add(new EntityRecognitionSkill("Tested Entity Recognition skill", RootPathString, inputs, outputs));

            return new Skillset(SearchTestUtilities.GenerateName(), description: "Skillset for testing default configuration", skills: skills);
        }

        private static Skillset CreateSkillsetWithSentimentDefaultSettings()
        {
            List<Skill> skills = new List<Skill>();

            List<InputFieldMappingEntry> inputs = new List<InputFieldMappingEntry>()
            {
                new InputFieldMappingEntry
                {
                    Name = "text",
                    Source = "/document/mytext"
                }
            };

            List<OutputFieldMappingEntry> outputs = new List<OutputFieldMappingEntry>()
            {
                new OutputFieldMappingEntry
                {
                    Name = "score",
                    TargetName = "mySentiment"
                }
            };

            skills.Add(new SentimentSkill("Tested Sentiment skill", RootPathString, inputs, outputs));

            return new Skillset(SearchTestUtilities.GenerateName(), description: "Skillset for testing default configuration", skills: skills);
        }

        private static Skillset CreateSkillsetWithSplitDefaultSettings()
        {
            List<Skill> skills = new List<Skill>();

            List<InputFieldMappingEntry> inputs = new List<InputFieldMappingEntry>()
            {
                new InputFieldMappingEntry
                {
                    Name = "text",
                    Source = "/document/mytext"
                }
            };

            List<OutputFieldMappingEntry> outputs = new List<OutputFieldMappingEntry>()
            {
                new OutputFieldMappingEntry
                {
                    Name = "textItems",
                    TargetName = "myTextItems"
                }
            };

            skills.Add(new SplitSkill("Tested Split skill", RootPathString, inputs, outputs)
            {
                TextSplitMode = TextSplitMode.Pages
            });

            return new Skillset(SearchTestUtilities.GenerateName(), description: "Skillset for testing default configuration", skills: skills);
        }

        private static Skillset CreateTestOcrSkillset(int repeat, TextExtractionAlgorithm algorithm, string name = null, bool shouldDetectOrientation = false)
        {
            List<Skill> skills = new List<Skill>();

            List<InputFieldMappingEntry> inputs = new List<InputFieldMappingEntry>()
            {
                new InputFieldMappingEntry { Name = "url", Source = "/document/url" },
                new InputFieldMappingEntry { Name = "queryString", Source = "/document/queryString" }
            };

            for (int i = 0; i < repeat; i++)
            {
                List<OutputFieldMappingEntry> outputs = new List<OutputFieldMappingEntry>()
                {
                    new OutputFieldMappingEntry { Name = "text", TargetName = "mytext" + i }
                };

                skills.Add(new OcrSkill("Tested OCR skill", RootPathString, inputs, outputs)
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
            Assert.Equal(expected, actual, new ModelComparer<Skillset>());
        }

        private static Skillset CreateTestSkillsetOcrKeyPhrase(OcrSkillLanguage ocrLanguageCode, KeyPhraseExtractionSkillLanguage keyPhraseLanguageCode)
        {
            List<Skill> skills = new List<Skill>();

            List<InputFieldMappingEntry> inputs = new List<InputFieldMappingEntry>()
            {
                new InputFieldMappingEntry { Name = "url", Source = "/document/url" },
                new InputFieldMappingEntry { Name = "queryString", Source = "/document/queryString" }
            };

            List<OutputFieldMappingEntry> outputs = new List<OutputFieldMappingEntry>()
            {
                new OutputFieldMappingEntry { Name = "text", TargetName = "mytext" }
            };

            skills.Add(new OcrSkill("Tested OCR skill", RootPathString, inputs, outputs)
            {
                TextExtractionAlgorithm = TextExtractionAlgorithm.Printed,
                DefaultLanguageCode = ocrLanguageCode,

            });

            List<InputFieldMappingEntry> inputs1 = new List<InputFieldMappingEntry>()
            {
                new InputFieldMappingEntry
                {
                    Name = "text",
                    Source = "/document/mytext"
                }
            };

            List<OutputFieldMappingEntry> outputs1 = new List<OutputFieldMappingEntry>()
            {
                new OutputFieldMappingEntry
                {
                    Name = "keyPhrases",
                    TargetName = "myKeyPhrases"
                }
            };

            skills.Add(new KeyPhraseExtractionSkill("Tested Key Phrase skill", RootPathString, inputs1, outputs1)
            {
                DefaultLanguageCode = keyPhraseLanguageCode,

            });

            return new Skillset("testskillset", "Skillset for testing", skills);
        }

        private static Skillset CreateTestSkillsetOcrSentiment(OcrSkillLanguage ocrLanguageCode, SentimentSkillLanguage sentimentLanguageCode, TextExtractionAlgorithm algorithm)
        {
            List<Skill> skills = new List<Skill>();

            List<InputFieldMappingEntry> inputs = new List<InputFieldMappingEntry>()
            {
                new InputFieldMappingEntry { Name = "url", Source = "/document/url" },
                new InputFieldMappingEntry { Name = "queryString", Source = "/document/queryString" }
            };

            List<OutputFieldMappingEntry> outputs = new List<OutputFieldMappingEntry>()
            {
                new OutputFieldMappingEntry { Name = "text", TargetName = "mytext" }
            };

            skills.Add(new OcrSkill("Tested OCR skill", RootPathString, inputs, outputs)
            {
                TextExtractionAlgorithm = algorithm,
                DefaultLanguageCode = ocrLanguageCode,

            });

            List<InputFieldMappingEntry> inputs1 = new List<InputFieldMappingEntry>()
            {
                new InputFieldMappingEntry
                {
                    Name = "text",
                    Source = "/document/mytext"
                }
            };

            List<OutputFieldMappingEntry> outputs1 = new List<OutputFieldMappingEntry>()
            {
                new OutputFieldMappingEntry
                {
                    Name = "score",
                    TargetName = "mySentiment"
                }
            };

            skills.Add(new SentimentSkill("Tested Sentiment skill", RootPathString, inputs1, outputs1)
            {
                DefaultLanguageCode = sentimentLanguageCode,

            });

            return new Skillset("testskillset1", "Skillset for testing", skills);
        }

        private static Skillset CreateTestSkillsetImageAnalysisKeyPhrase()
        {
            List<Skill> skills = new List<Skill>();

            List<InputFieldMappingEntry> inputs = new List<InputFieldMappingEntry>()
            {
                new InputFieldMappingEntry { Name = "url", Source = "/document/url" },
                new InputFieldMappingEntry { Name = "queryString", Source = "/document/queryString" }
            };

            List<OutputFieldMappingEntry> outputs = new List<OutputFieldMappingEntry>()
            {
                new OutputFieldMappingEntry { Name = "description", TargetName = "mydescription" }
            };

            skills.Add(new ImageAnalysisSkill("Tested image analysis skill", RootPathString, inputs, outputs)
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

            List<InputFieldMappingEntry> inputs1 = new List<InputFieldMappingEntry>()
            {
                new InputFieldMappingEntry
                {
                    Name = "text",
                    Source = "/document/mydescription/*/Tags/*"
                }
            };

            List<OutputFieldMappingEntry> outputs1 = new List<OutputFieldMappingEntry>()
            {
                new OutputFieldMappingEntry
                {
                    Name = "keyPhrases",
                    TargetName = "myKeyPhrases"
                }
            };

            skills.Add(new KeyPhraseExtractionSkill("Tested Key Phrase skill", RootPathString, inputs1, outputs1)
            {
                DefaultLanguageCode = "en"
            });

            return new Skillset("testskillset2", "Skillset for testing", skills);
        }

        private static Skillset CreateTestSkillsetLanguageDetection()
        {
            List<Skill> skills = new List<Skill>();

            List<InputFieldMappingEntry> inputs = new List<InputFieldMappingEntry>()
            {
                new InputFieldMappingEntry
                {
                    Name = "text",
                    Source = "/document/text"
                }
            };

            List<OutputFieldMappingEntry> outputs = new List<OutputFieldMappingEntry>()
            {
                new OutputFieldMappingEntry
                {
                    Name = "languageCode",
                    TargetName = "myLanguageCode"
                }
            };

            skills.Add(new LanguageDetectionSkill("Tested Language Detection skill", RootPathString, inputs, outputs));

            return new Skillset("testskillset3", "Skillset for testing", skills);
        }

        private static Skillset CreateTestSkillsetMergeText()
        {
            List<Skill> skills = new List<Skill>();

            List<InputFieldMappingEntry> inputs = new List<InputFieldMappingEntry>()
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

            List<OutputFieldMappingEntry> outputs = new List<OutputFieldMappingEntry>()
            {
                new OutputFieldMappingEntry
                {
                    Name = "mergedText",
                    TargetName = "myMergedText"
                }
            };

            skills.Add(new MergeSkill("Tested Merged Text skill", RootPathString, inputs, outputs)
            {
                InsertPreTag = "__",
                InsertPostTag = "__e"
            });

            return new Skillset("testskillset4", "Skillset for testing", skills);
        }

        private static Skillset CreateTestSkillsetOcrShaper()
        {
            List<Skill> skills = new List<Skill>();

            List<InputFieldMappingEntry> inputs = new List<InputFieldMappingEntry>()
            {
                new InputFieldMappingEntry { Name = "url", Source = "/document/url" },
                new InputFieldMappingEntry { Name = "queryString", Source = "/document/queryString" }
            };

            List<OutputFieldMappingEntry> outputs = new List<OutputFieldMappingEntry>()
            {
                new OutputFieldMappingEntry { Name = "text", TargetName = "mytext" }
            };

            skills.Add(new OcrSkill("Tested OCR skill", RootPathString, inputs, outputs)
            {
                TextExtractionAlgorithm = TextExtractionAlgorithm.Printed,
                DefaultLanguageCode = "en"
            });

            List<InputFieldMappingEntry> inputs1 = new List<InputFieldMappingEntry>()
            {
                new InputFieldMappingEntry
                {
                    Name = "text",
                    Source = "/document/mytext"
                }
            };

            List<OutputFieldMappingEntry> outputs1 = new List<OutputFieldMappingEntry>()
            {
                new OutputFieldMappingEntry
                {
                    Name = "output",
                    TargetName = "myOutput"
                }
            };

            skills.Add(new ShaperSkill("Tested Shaper skill", RootPathString, inputs1, outputs1));

            return new Skillset("testskillset", "Skillset for testing", skills);
        }

        private static Skillset CreateSkillsetWithCognitiveServicesKey()
        {
            List<Skill> skills = new List<Skill>();

            List<InputFieldMappingEntry> inputs = new List<InputFieldMappingEntry>()
            {
                new InputFieldMappingEntry { Name = "url", Source = "/document/url" },
                new InputFieldMappingEntry { Name = "queryString", Source = "/document/queryString" }
            };

            List<OutputFieldMappingEntry> outputs = new List<OutputFieldMappingEntry>()
            {
                new OutputFieldMappingEntry { Name = "text", TargetName = "mytext" }
            };

            skills.Add(new OcrSkill("Tested OCR skill", RootPathString, inputs, outputs)
            {
                TextExtractionAlgorithm = TextExtractionAlgorithm.Printed,
                DefaultLanguageCode = "en"
            });

            return new Skillset("testskillset", "Skillset for testing", skills, new DefaultCognitiveServices());
        }

        private static Skillset CreateTestSkillsetOcrSplitText(OcrSkillLanguage ocrLanguageCode, SplitSkillLanguage splitLanguageCode, TextSplitMode textSplitMode)
        {
            List<Skill> skills = new List<Skill>();

            List<InputFieldMappingEntry> inputs = new List<InputFieldMappingEntry>()
            {
                new InputFieldMappingEntry { Name = "url", Source = "/document/url" },
                new InputFieldMappingEntry { Name = "queryString", Source = "/document/queryString" }
            };

            List<OutputFieldMappingEntry> outputs = new List<OutputFieldMappingEntry>()
            {
                new OutputFieldMappingEntry { Name = "text", TargetName = "mytext" }
            };

            skills.Add(new OcrSkill("Tested OCR skill", RootPathString, inputs, outputs)
            {
                TextExtractionAlgorithm = TextExtractionAlgorithm.Printed,
                DefaultLanguageCode = ocrLanguageCode
            });

            List<InputFieldMappingEntry> inputs1 = new List<InputFieldMappingEntry>()
            {
                new InputFieldMappingEntry
                {
                    Name = "text",
                    Source = "/document/mytext"
                }
            };

            List<OutputFieldMappingEntry> outputs1 = new List<OutputFieldMappingEntry>()
            {
                new OutputFieldMappingEntry
                {
                    Name = "textItems",
                    TargetName = "myTextItems"
                }
            };

            skills.Add(new SplitSkill("Tested Split skill", RootPathString, inputs1, outputs1)
            {
                TextSplitMode = textSplitMode,
                DefaultLanguageCode = splitLanguageCode
            });

            return new Skillset("testskillset", "Skillset for testing", skills);
        }
    }
}
