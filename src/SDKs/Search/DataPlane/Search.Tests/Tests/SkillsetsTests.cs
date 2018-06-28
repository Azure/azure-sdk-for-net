// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

namespace Microsoft.Azure.Search.Tests
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;
    using Microsoft.Azure.Search.Models;
    using Microsoft.Azure.Search.Tests.Utilities;
    using Microsoft.Rest.Azure;
    using Xunit;

    public sealed class SkillsetsTests : SearchTestBase<SearchServiceFixture>
    {
        public const char PathSeparator = '/';
        public const string RootName = "document";

        public const string InputImageFieldName = "image";
        public const string InputUrlFieldName = "url";
        // The query string is for SAS token and it is optional
        public const string InputQueryStringFieldName = "queryString";

        public const string OutputTextFieldName = "text";
        public const string OutputLayoutTextFieldName = "layoutText";

        public static string RootPathString { get; } = PathSeparator + RootName;

        [Fact]
        public void CreateSkillsetReturnsCorrectDefinitionOcrKeyPhrase()
        {
            Run(() =>
            {
                SearchServiceClient searchClient = Data.GetSearchServiceClient();
                CreateAndValidateSkillset(searchClient, CreateTestSkillsetOcrKeyPhrase(OcrSkillLanguage.en.ToString(), KeyPhraseExtractionSkillLanguage.en.ToString()));
                CreateAndValidateSkillset(searchClient, CreateTestSkillsetOcrKeyPhrase(OcrSkillLanguage.fr.ToString(), KeyPhraseExtractionSkillLanguage.fr.ToString()));
                CreateAndValidateSkillset(searchClient, CreateTestSkillsetOcrKeyPhrase(OcrSkillLanguage.es.ToString(), KeyPhraseExtractionSkillLanguage.es.ToString()));
            });
        }

        [Fact]
        public void CreateSkillsetReturnsCorrectDefinitionOcrHandwritingSentiment()
        {
            Run(() =>
            {
                SearchServiceClient searchClient = Data.GetSearchServiceClient();
                CreateAndValidateSkillset(searchClient, CreateTestSkillsetOcrSentiment(OcrSkillLanguage.pt.ToString(), SentimentSkillLanguage.pt_PT.ToString()));
                CreateAndValidateSkillset(searchClient, CreateTestSkillsetOcrSentiment(OcrSkillLanguage.fi.ToString(), SentimentSkillLanguage.fi.ToString()));
                CreateAndValidateSkillset(searchClient, CreateTestSkillsetOcrSentiment(OcrSkillLanguage.en.ToString(), SentimentSkillLanguage.en.ToString()));
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
        public void CreateSkillsetReturnsCorrectDefinitionOcrNamedEntity()
        {
            Run(() =>
            {
                SearchServiceClient searchClient = Data.GetSearchServiceClient();
                CreateAndValidateSkillset(searchClient, CreateTestSkillsetOcrNamedEntity());
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
                CreateAndValidateSkillset(searchClient, CreateTestSkillsetOcrSplitText(OcrSkillLanguage.en.ToString(), SplitSkillLanguage.en.ToString()));
                CreateAndValidateSkillset(searchClient, CreateTestSkillsetOcrSplitText(OcrSkillLanguage.fr.ToString(), SplitSkillLanguage.fr.ToString()));
                CreateAndValidateSkillset(searchClient, CreateTestSkillsetOcrSplitText(OcrSkillLanguage.fi.ToString(), SplitSkillLanguage.fi.ToString()));
            });
        }

        [Fact]
        public void CreateOrUpdateCreatesWhenSkillsetDoesNotExist()
        {
            Run(() =>
            {
                SearchServiceClient searchClient = Data.GetSearchServiceClient();

                Skillset skillset = CreateTestOcrSkillset(1);

                AzureOperationResponse<Skillset> response =
                    searchClient.Skillsets.CreateOrUpdateWithHttpMessagesAsync(skillset.Name, skillset).Result;
                Assert.Equal(HttpStatusCode.Created, response.Response.StatusCode);
            });
        }

        [Fact]
        public void CreateOrUpdateUpdatesWhenSkillsetExists()
        {
            Run(() =>
            {
                SearchServiceClient searchClient = Data.GetSearchServiceClient();

                Skillset skillset = CreateTestOcrSkillset(1);

                AzureOperationResponse<Skillset> response =
                    searchClient.Skillsets.CreateOrUpdateWithHttpMessagesAsync(skillset.Name, skillset).Result;
                Assert.Equal(HttpStatusCode.Created, response.Response.StatusCode);

                skillset = CreateTestOcrSkillset(2, skillset.Name);
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
                CreateAndGetSkillset(searchClient, CreateTestOcrSkillset(1));
            });
        }

        [Fact]
        public void GetOcrSkillsetWithShouldDetectOrientationReturnsCorrectDefinition()
        {
            Run(() =>
            {
                SearchServiceClient searchClient = Data.GetSearchServiceClient();
                CreateAndGetSkillset(searchClient, CreateTestOcrSkillset(repeat: 1, shouldDetectOrientation: true));
            });
        }

        [Fact]
        public void DeleteSkillsetIsIdempotent()
        {
            Run(() =>
            {
                SearchServiceClient searchClient = Data.GetSearchServiceClient();

                Skillset skillset = CreateTestOcrSkillset(1);

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

        private static Skillset CreateTestOcrSkillset(int repeat, string name = null, bool shouldDetectOrientation = false)
        {
            List<Skill> skills = new List<Skill>();

            List<InputFieldMappingEntry> _inputs = new List<InputFieldMappingEntry>()
            {
                new InputFieldMappingEntry { Name = "url", Source = "/document/url" },
                new InputFieldMappingEntry { Name = "queryString", Source = "/document/queryString" }
            };

            for (int i = 0; i < repeat; i++)
            {
                List<OutputFieldMappingEntry> _outputs = new List<OutputFieldMappingEntry>()
                {
                    new OutputFieldMappingEntry { Name = "text", TargetName = "mytext" + i }
                };


                skills.Add(new OcrSkill("Tested OCR skill", PathSeparator + RootName, _inputs, _outputs)
                {
                    TextExtractionAlgorithm = TextExtractionAlgorithm.Printed,
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

        private static Skillset CreateTestSkillsetOcrKeyPhrase(string ocrLanguageCode = "en", string keyPhraseLanguageCode = "en")
        {
            List<Skill> skills = new List<Skill>();

            List<InputFieldMappingEntry> _inputs = new List<InputFieldMappingEntry>()
            {
                new InputFieldMappingEntry { Name = "url", Source = "/document/url" },
                new InputFieldMappingEntry { Name = "queryString", Source = "/document/queryString" }
            };

            List<OutputFieldMappingEntry> _outputs = new List<OutputFieldMappingEntry>()
            {
                new OutputFieldMappingEntry { Name = "text", TargetName = "mytext" }
            };

            skills.Add(new OcrSkill("Tested OCR skill", PathSeparator + RootName, _inputs, _outputs)
            {
                TextExtractionAlgorithm = TextExtractionAlgorithm.Printed,
                DefaultLanguageCode = ocrLanguageCode,

            });

            List<InputFieldMappingEntry> _inputs1 = new List<InputFieldMappingEntry>()
            {
                new InputFieldMappingEntry
                {
                    Name = "text",
                    Source = "/document/mytext"
                }
            };

            List<OutputFieldMappingEntry> _outputs1 = new List<OutputFieldMappingEntry>()
            {
                new OutputFieldMappingEntry
                {
                    Name = "keyPhrases",
                    TargetName = "myKeyPhrases"
                }
            };

            skills.Add(new KeyPhraseExtractionSkill("Tested Key Phrase skill", PathSeparator + RootName, _inputs1, _outputs1)
            {
                DefaultLanguageCode = keyPhraseLanguageCode,

            });

            return new Skillset("testskillset", "Skillset for testing", skills);
        }

        private static Skillset CreateTestSkillsetOcrSentiment(string ocrLanguageCode = "en", string sentimentLanguageCode = "en")
        {
            List<Skill> skills = new List<Skill>();

            List<InputFieldMappingEntry> _inputs = new List<InputFieldMappingEntry>()
            {
                new InputFieldMappingEntry { Name = "url", Source = "/document/url" },
                new InputFieldMappingEntry { Name = "queryString", Source = "/document/queryString" }
            };

            List<OutputFieldMappingEntry> _outputs = new List<OutputFieldMappingEntry>()
            {
                new OutputFieldMappingEntry { Name = "text", TargetName = "mytext" }
            };

            skills.Add(new OcrSkill("Tested OCR skill", PathSeparator + RootName, _inputs, _outputs)
            {
                TextExtractionAlgorithm = TextExtractionAlgorithm.Handwritten,
                DefaultLanguageCode = ocrLanguageCode,

            });

            List<InputFieldMappingEntry> _inputs1 = new List<InputFieldMappingEntry>()
            {
                new InputFieldMappingEntry
                {
                    Name = "text",
                    Source = "/document/mytext"
                }
            };

            List<OutputFieldMappingEntry> _outputs1 = new List<OutputFieldMappingEntry>()
            {
                new OutputFieldMappingEntry
                {
                    Name = "score",
                    TargetName = "mySentiment"
                }
            };

            skills.Add(new SentimentSkill("Tested Sentiment skill", PathSeparator + RootName, _inputs1, _outputs1)
            {
                DefaultLanguageCode = sentimentLanguageCode,

            });

            return new Skillset("testskillset1", "Skillset for testing", skills);
        }

        private static Skillset CreateTestSkillsetImageAnalysisKeyPhrase()
        {
            List<Skill> skills = new List<Skill>();

            List<InputFieldMappingEntry> _inputs = new List<InputFieldMappingEntry>()
            {
                new InputFieldMappingEntry { Name = "url", Source = "/document/url" },
                new InputFieldMappingEntry { Name = "queryString", Source = "/document/queryString" }
            };

            List<OutputFieldMappingEntry> _outputs = new List<OutputFieldMappingEntry>()
            {
                new OutputFieldMappingEntry { Name = "description", TargetName = "mydescription" }
            };

            skills.Add(new ImageAnalysisSkill("Tested image analysis skill", PathSeparator + RootName, _inputs, _outputs)
            {
                VisualFeatures = new List<VisualFeatures?> { VisualFeatures.Description },
                DefaultLanguageCode = "en",

            });

            List<InputFieldMappingEntry> _inputs1 = new List<InputFieldMappingEntry>()
            {
                new InputFieldMappingEntry
                {
                    Name = "text",
                    Source = "/document/mydescription/*/Tags/*"
                }
            };

            List<OutputFieldMappingEntry> _outputs1 = new List<OutputFieldMappingEntry>()
            {
                new OutputFieldMappingEntry
                {
                    Name = "keyPhrases",
                    TargetName = "myKeyPhrases"
                }
            };

            skills.Add(new KeyPhraseExtractionSkill("Tested Key Phrase skill", PathSeparator + RootName, _inputs1, _outputs1)
            {
                DefaultLanguageCode = "en",

            });

            return new Skillset("testskillset2", "Skillset for testing", skills);
        }

        private static Skillset CreateTestSkillsetLanguageDetection()
        {
            List<Skill> skills = new List<Skill>();

            List<InputFieldMappingEntry> _inputs = new List<InputFieldMappingEntry>()
            {
                new InputFieldMappingEntry
                {
                    Name = "text",
                    Source = "/document/text"
                }
            };

            List<OutputFieldMappingEntry> _outputs = new List<OutputFieldMappingEntry>()
            {
                new OutputFieldMappingEntry
                {
                    Name = "languageCode",
                    TargetName = "myLanguageCode"
                }
            };

            skills.Add(new LanguageDetectionSkill("Tested Language Detection skill", PathSeparator + RootName, _inputs, _outputs));

            return new Skillset("testskillset3", "Skillset for testing", skills);
        }

        private static Skillset CreateTestSkillsetMergeText()
        {
            List<Skill> skills = new List<Skill>();

            List<InputFieldMappingEntry> _inputs = new List<InputFieldMappingEntry>()
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

            List<OutputFieldMappingEntry> _outputs = new List<OutputFieldMappingEntry>()
            {
                new OutputFieldMappingEntry
                {
                    Name = "mergedText",
                    TargetName = "myMergedText"
                }
            };

            skills.Add(new MergeSkill("Tested Merged Text skill", PathSeparator + RootName, _inputs, _outputs));

            return new Skillset("testskillset4", "Skillset for testing", skills);
        }

        private static Skillset CreateTestSkillsetOcrNamedEntity()
        {
            List<Skill> skills = new List<Skill>();

            List<InputFieldMappingEntry> _inputs = new List<InputFieldMappingEntry>()
            {
                new InputFieldMappingEntry { Name = "url", Source = "/document/url" },
                new InputFieldMappingEntry { Name = "queryString", Source = "/document/queryString" }
            };

            List<OutputFieldMappingEntry> _outputs = new List<OutputFieldMappingEntry>()
            {
                new OutputFieldMappingEntry { Name = "text", TargetName = "mytext" }
            };

            skills.Add(new OcrSkill("Tested OCR skill", PathSeparator + RootName, _inputs, _outputs)
            {
                TextExtractionAlgorithm = TextExtractionAlgorithm.Printed,
                DefaultLanguageCode = "en",

            });

            List<InputFieldMappingEntry> _inputs1 = new List<InputFieldMappingEntry>()
            {
                new InputFieldMappingEntry
                {
                    Name = "text",
                    Source = "/document/mytext"
                }
            };

            List<OutputFieldMappingEntry> _outputs1 = new List<OutputFieldMappingEntry>()
            {
                new OutputFieldMappingEntry
                {
                    Name = "entities",
                    TargetName = "myEntities"
                }
            };

            skills.Add(new NamedEntityRecognitionSkill("Tested Named Entity Recognition skill", PathSeparator + RootName, _inputs1, _outputs1)
            {
                DefaultLanguageCode = "en",

            });

            return new Skillset("testskillset", "Skillset for testing", skills);
        }

        private static Skillset CreateTestSkillsetOcrShaper()
        {
            List<Skill> skills = new List<Skill>();

            List<InputFieldMappingEntry> _inputs = new List<InputFieldMappingEntry>()
            {
                new InputFieldMappingEntry { Name = "url", Source = "/document/url" },
                new InputFieldMappingEntry { Name = "queryString", Source = "/document/queryString" }
            };

            List<OutputFieldMappingEntry> _outputs = new List<OutputFieldMappingEntry>()
            {
                new OutputFieldMappingEntry { Name = "text", TargetName = "mytext" }
            };

            skills.Add(new OcrSkill("Tested OCR skill", PathSeparator + RootName, _inputs, _outputs)
            {
                TextExtractionAlgorithm = TextExtractionAlgorithm.Printed,
                DefaultLanguageCode = "en",

            });

            List<InputFieldMappingEntry> _inputs1 = new List<InputFieldMappingEntry>()
            {
                new InputFieldMappingEntry
                {
                    Name = "text",
                    Source = "/document/mytext"
                }
            };

            List<OutputFieldMappingEntry> _outputs1 = new List<OutputFieldMappingEntry>()
            {
                new OutputFieldMappingEntry
                {
                    Name = "output",
                    TargetName = "myOutput"
                }
            };

            skills.Add(new ShaperSkill("Tested Shaper skill", PathSeparator + RootName, _inputs1, _outputs1));

            return new Skillset("testskillset", "Skillset for testing", skills);
        }

        private static Skillset CreateTestSkillsetOcrSplitText(string ocrLanguageCode = "en", string splitLanguageCode = "en")
        {
            List<Skill> skills = new List<Skill>();

            List<InputFieldMappingEntry> _inputs = new List<InputFieldMappingEntry>()
            {
                new InputFieldMappingEntry { Name = "url", Source = "/document/url" },
                new InputFieldMappingEntry { Name = "queryString", Source = "/document/queryString" }
            };

            List<OutputFieldMappingEntry> _outputs = new List<OutputFieldMappingEntry>()
            {
                new OutputFieldMappingEntry { Name = "text", TargetName = "mytext" }
            };

            skills.Add(new OcrSkill("Tested OCR skill", PathSeparator + RootName, _inputs, _outputs)
            {
                TextExtractionAlgorithm = TextExtractionAlgorithm.Printed,
                DefaultLanguageCode = ocrLanguageCode
            });

            List<InputFieldMappingEntry> _inputs1 = new List<InputFieldMappingEntry>()
            {
                new InputFieldMappingEntry
                {
                    Name = "text",
                    Source = "/document/mytext"
                }
            };

            List<OutputFieldMappingEntry> _outputs1 = new List<OutputFieldMappingEntry>()
            {
                new OutputFieldMappingEntry
                {
                    Name = "textItems",
                    TargetName = "myTextItems"
                }
            };

            skills.Add(new SplitSkill("Tested Split skill", PathSeparator + RootName, _inputs1, _outputs1)
            {
                TextSplitMode = TextSplitMode.Pages,
                DefaultLanguageCode = splitLanguageCode
            });

            return new Skillset("testskillset", "Skillset for testing", skills);
        }
    }
}