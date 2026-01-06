// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Azure.AI.Language.Text;
using Azure.AI.Language.Text.Tests;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.AI.Language.TextAnalytics.Tests
{
    public class TextAnalysisClientLiveTest : TextAnalysisTestBase
    {
        public TextAnalysisClientLiveTest(bool isAsync, TextAnalysisClientOptions.ServiceVersion serviceVersion)
            : base(isAsync, serviceVersion, null /* RecordedTestMode.Record /* to record */)
        {
        }

        [RecordedTest]
        public async Task AnalyzeText_LanguageDetection()
        {
            string textA =
                "Este documento está escrito en un lenguaje diferente al inglés. Su objectivo es demostrar cómo"
                + " invocar el método de detección de lenguaje del servicio de Text Analytics en Microsoft Azure."
                + " También muestra cómo acceder a la información retornada por el servicio. Esta funcionalidad es"
                + " útil para las aplicaciones que recopilan texto arbitrario donde el lenguaje no se conoce de"
                + " antemano. Puede usarse para detectar una amplia gama de lenguajes, variantes, dialectos y"
                + " algunos idiomas regionales o culturales.";

            AnalyzeTextInput body = new TextLanguageDetectionInput()
            {
                TextInput = new LanguageDetectionTextInput()
                {
                    LanguageInputs =
                    {
                        new LanguageInput("A", textA),
                    }
                }
            };

            Response<AnalyzeTextResult> response = await client.AnalyzeTextAsync(body);
            Assert.That(response, Is.Not.Null);
            Assert.That(response.Value, Is.Not.Null);
            AnalyzeTextLanguageDetectionResult AnalyzeTextLanguageDetectionResult = (AnalyzeTextLanguageDetectionResult)response.Value;

            Assert.That(AnalyzeTextLanguageDetectionResult, Is.Not.Null);
            Assert.That(AnalyzeTextLanguageDetectionResult.Results, Is.Not.Null);
            Assert.That(AnalyzeTextLanguageDetectionResult.Results.Documents, Is.Not.Null);
            foreach (LanguageDetectionDocumentResult document in AnalyzeTextLanguageDetectionResult.Results.Documents)
            {
                Assert.That(document, Is.Not.Null);
                Assert.That(document.DetectedLanguage, Is.Not.Null);
                Assert.Multiple(() =>
                {
                    Assert.That(document.DetectedLanguage.Name, Is.Not.Null);
                    Assert.That(document.DetectedLanguage.Iso6391Name, Is.Not.Null);
                    Assert.That(document.DetectedLanguage.ConfidenceScore, Is.Not.Null);
                    Assert.That(document.Id, Is.Not.Null);
                });
            }
        }

        [RecordedTest]
        public async Task AnalyzeText_Sentiment()
        {
            string textA =
                "The food and service were unacceptable, but the concierge were nice. After talking to them about the"
                + " quality of the food and the process to get room service they refunded the money we spent at the"
                + " restaurant and gave us a voucher for nearby restaurants.";

            AnalyzeTextInput body = new TextSentimentAnalysisInput()
            {
                TextInput = new MultiLanguageTextInput()
                {
                    MultiLanguageInputs =
                    {
                        new MultiLanguageInput("A", textA) { Language = "en" },
                    }
                }
            };

            Response<AnalyzeTextResult> response = await client.AnalyzeTextAsync(body);
            Assert.That(response, Is.Not.Null);
            Assert.That(response.Value, Is.Not.Null);
            AnalyzeTextSentimentResult AnalyzeTextSentimentResult = (AnalyzeTextSentimentResult)response.Value;

            Assert.That(AnalyzeTextSentimentResult, Is.Not.Null);
            Assert.That(AnalyzeTextSentimentResult.Results, Is.Not.Null);
            Assert.That(AnalyzeTextSentimentResult.Results.Documents, Is.Not.Null);
            foreach (SentimentActionResult sentimentResponseWithDocumentDetectedLanguage in AnalyzeTextSentimentResult.Results.Documents)
            {
                Assert.That(sentimentResponseWithDocumentDetectedLanguage, Is.Not.Null);
                Assert.Multiple(() =>
                {
                    Assert.That(sentimentResponseWithDocumentDetectedLanguage.Id, Is.Not.Null);
                    Assert.That(sentimentResponseWithDocumentDetectedLanguage.Sentiment, Is.Not.Null);
                    Assert.That(sentimentResponseWithDocumentDetectedLanguage.ConfidenceScores, Is.Not.Null);
                });
                Assert.Multiple(() =>
                {
                    Assert.That(sentimentResponseWithDocumentDetectedLanguage.ConfidenceScores.Positive, Is.Not.Null);
                    Assert.That(sentimentResponseWithDocumentDetectedLanguage.ConfidenceScores.Neutral, Is.Not.Null);
                    Assert.That(sentimentResponseWithDocumentDetectedLanguage.ConfidenceScores.Negative, Is.Not.Null);
                    Assert.That(sentimentResponseWithDocumentDetectedLanguage.Sentences, Is.Not.Null);
                });
                foreach (SentenceSentiment sentenceSentiment in sentimentResponseWithDocumentDetectedLanguage.Sentences)
                {
                    Assert.That(sentenceSentiment, Is.Not.Null);
                    Assert.Multiple(() =>
                    {
                        Assert.That(sentenceSentiment.Text, Is.Not.Null);
                        Assert.That(sentenceSentiment.Sentiment, Is.Not.Null);
                        Assert.That(sentenceSentiment.ConfidenceScores, Is.Not.Null);
                    });
                    Assert.Multiple(() =>
                    {
                        Assert.That(sentenceSentiment.ConfidenceScores.Positive, Is.Not.Null);
                        Assert.That(sentenceSentiment.ConfidenceScores.Neutral, Is.Not.Null);
                        Assert.That(sentenceSentiment.ConfidenceScores.Negative, Is.Not.Null);
                        Assert.That(sentenceSentiment.Offset, Is.Not.Null);
                        Assert.That(sentenceSentiment.Length, Is.Not.Null);
                    });
                }
            }
        }

        [RecordedTest]
        public async Task AnalyzeText_ExtractKeyPhrases()
        {
            string textA =
                "We love this trail and make the trip every year. The views are breathtaking and well worth the hike!"
                + " Yesterday was foggy though, so we missed the spectacular views. We tried again today and it was"
                + " amazing. Everyone in my family liked the trail although it was too challenging for the less"
                + " athletic among us. Not necessarily recommended for small children. A hotel close to the trail"
                + " offers services for childcare in case you want that.";

            AnalyzeTextInput body = new TextKeyPhraseExtractionInput()
            {
                TextInput = new MultiLanguageTextInput()
                {
                    MultiLanguageInputs =
                    {
                        new MultiLanguageInput("A", textA) { Language = "en" },
                    }
                },
                ActionContent = new KeyPhraseActionContent()
                {
                    ModelVersion = "latest",
                }
            };

            Response<AnalyzeTextResult> response = await client.AnalyzeTextAsync(body);
            Assert.That(response, Is.Not.Null);
            Assert.That(response.Value, Is.Not.Null);
            AnalyzeTextKeyPhraseResult keyPhraseTaskResult = (AnalyzeTextKeyPhraseResult)response.Value;

            Assert.That(keyPhraseTaskResult, Is.Not.Null);
            Assert.That(keyPhraseTaskResult.Results, Is.Not.Null);
            Assert.That(keyPhraseTaskResult.Results.Documents, Is.Not.Null);
            foreach (KeyPhrasesActionResult kpeResult in keyPhraseTaskResult.Results.Documents)
            {
                Assert.That(kpeResult, Is.Not.Null);
                Assert.Multiple(() =>
                {
                    Assert.That(kpeResult.Id, Is.Not.Null);
                    Assert.That(kpeResult.KeyPhrases, Is.Not.Null);
                });
                foreach (string keyPhrase in kpeResult.KeyPhrases)
                {
                    Assert.That(keyPhrase, Is.Not.Null);
                }
            }
        }

        [RecordedTest]
        public async Task AnalyzeText_RecognizeEntities()
        {
            string textA =
                "We love this trail and make the trip every year. The views are breathtaking and well worth the hike!"
                + " Yesterday was foggy though, so we missed the spectacular views. We tried again today and it was"
                + " amazing. Everyone in my family liked the trail although it was too challenging for the less"
                + " athletic among us. Not necessarily recommended for small children. A hotel close to the trail"
                + " offers services for childcare in case you want that.";

            AnalyzeTextInput body = new TextEntityRecognitionInput()
            {
                TextInput = new MultiLanguageTextInput()
                {
                    MultiLanguageInputs =
                    {
                        new MultiLanguageInput("A", textA) { Language = "en" },
                    }
                },
                ActionContent = new EntitiesActionContent()
                {
                    ModelVersion = "latest",
                }
            };

            Response<AnalyzeTextResult> response = await client.AnalyzeTextAsync(body);
            Assert.That(response, Is.Not.Null);
            Assert.That(response.Value, Is.Not.Null);
            AnalyzeTextEntitiesResult entitiesTaskResult = (AnalyzeTextEntitiesResult)response.Value;

            Assert.That(entitiesTaskResult, Is.Not.Null);
            Assert.That(entitiesTaskResult.Results, Is.Not.Null);
            Assert.That(entitiesTaskResult.Results.Documents, Is.Not.Null);
            foreach (EntityActionResult nerResult in entitiesTaskResult.Results.Documents)
            {
                Assert.That(nerResult, Is.Not.Null);
                Assert.Multiple(() =>
                {
                    Assert.That(nerResult.Id, Is.Not.Null);
                    Assert.That(nerResult.Entities, Is.Not.Null);
                });
                foreach (NamedEntityWithMetadata entity in nerResult.Entities)
                {
                    Assert.That(entity, Is.Not.Null);
                    Assert.Multiple(() =>
                    {
                        Assert.That(entity.Text, Is.Not.Null);
                        Assert.That(entity.Category, Is.Not.Null);
                        Assert.That(entity.Offset, Is.Not.Null);
                        Assert.That(entity.Length, Is.Not.Null);
                    });
                    Assert.That(entity.ConfidenceScore, Is.Not.Null);
                }
            }
        }

        [RecordedTest]
        public async Task AnalyzeText_RecognizePii()
        {
            string textA =
                "Parker Doe has repaid all of their loans as of 2020-04-25. Their SSN is 859-98-0987. To contact them,"
                + " use their phone number 800-102-1100. They are originally from Brazil and have document ID number"
                + " 998.214.865-68.";

            AnalyzeTextInput body = new TextPiiEntitiesRecognitionInput()
            {
                TextInput = new MultiLanguageTextInput()
                {
                    MultiLanguageInputs =
                    {
                        new MultiLanguageInput("A", textA) { Language = "en" },
                    }
                }
            };

            Response<AnalyzeTextResult> response = await client.AnalyzeTextAsync(body);
            Assert.That(response, Is.Not.Null);
            Assert.That(response.Value, Is.Not.Null);
            AnalyzeTextPiiResult piiTaskResult = (AnalyzeTextPiiResult)response.Value;

            Assert.That(piiTaskResult, Is.Not.Null);
            Assert.That(piiTaskResult.Results, Is.Not.Null);
            Assert.That(piiTaskResult.Results.Documents, Is.Not.Null);
            foreach (PiiActionResult piiResult in piiTaskResult.Results.Documents)
            {
                Assert.Multiple(() =>
                {
                    Assert.That(piiResult.Id, Is.Not.Null);
                    Assert.That(piiResult.Entities, Is.Not.Null);
                });
                foreach (PiiEntity entity in piiResult.Entities)
                {
                    Assert.That(entity, Is.Not.Null);
                    Assert.Multiple(() =>
                    {
                        Assert.That(entity.Text, Is.Not.Null);
                        Assert.That(entity.Category, Is.Not.Null);
                        Assert.That(entity.Offset, Is.Not.Null);
                        Assert.That(entity.Length, Is.Not.Null);
                    });
                    Assert.That(entity.ConfidenceScore, Is.Not.Null);
                }
            }
        }

        [RecordedTest]
        public async Task AnalyzeText_RecognizeLinkedEntities()
        {
            string textA =
                "Microsoft was founded by Bill Gates with some friends he met at Harvard. One of his friends, Steve"
                + " Ballmer, eventually became CEO after Bill Gates as well.Steve Ballmer eventually stepped down as"
                + " CEO of Microsoft, and was succeeded by Satya Nadella. Microsoft originally moved its headquarters"
                + " to Bellevue, Washington in Januaray 1979, but is now headquartered in Redmond";

            AnalyzeTextInput body = new TextEntityLinkingInput()
            {
                TextInput = new MultiLanguageTextInput()
                {
                    MultiLanguageInputs =
                    {
                        new MultiLanguageInput("A", textA) { Language = "en" },
                    }
                },
                ActionContent = new EntityLinkingActionContent()
                {
                    ModelVersion = "latest",
                }
            };

            Response<AnalyzeTextResult> response = await client.AnalyzeTextAsync(body);
            Assert.That(response, Is.Not.Null);
            Assert.That(response.Value, Is.Not.Null);
            AnalyzeTextEntityLinkingResult entityLinkingTaskResult = (AnalyzeTextEntityLinkingResult)response.Value;

            Assert.That(entityLinkingTaskResult, Is.Not.Null);
            Assert.That(entityLinkingTaskResult.Results, Is.Not.Null);
            Assert.That(entityLinkingTaskResult.Results.Documents, Is.Not.Null);
            foreach (EntityLinkingActionResult entityLinkingResult in entityLinkingTaskResult.Results.Documents)
            {
                Assert.Multiple(() =>
                {
                    Assert.That(entityLinkingResult.Id, Is.Not.Null);
                    Assert.That(entityLinkingResult.Entities, Is.Not.Null);
                });
                foreach (LinkedEntity linkedEntity in entityLinkingResult.Entities)
                {
                    Assert.Multiple(() =>
                    {
                        Assert.That(linkedEntity.Name, Is.Not.Null);
                        Assert.That(linkedEntity.Language, Is.Not.Null);
                        Assert.That(linkedEntity.DataSource, Is.Not.Null);
                        Assert.That(linkedEntity.Url, Is.Not.Null);
                        Assert.That(linkedEntity.Id, Is.Not.Null);
                        Assert.That(linkedEntity.Matches, Is.Not.Null);
                    });
                    foreach (EntityLinkingMatch match in linkedEntity.Matches)
                    {
                        Assert.Multiple(() =>
                        {
                            Assert.That(match.ConfidenceScore, Is.Not.Null);
                            Assert.That(match.Text, Is.Not.Null);
                            Assert.That(match.Offset, Is.Not.Null);
                            Assert.That(match.Length, Is.Not.Null);
                        });
                    }
                }
            }
        }

        [RecordedTest]
        public async Task AnalyzeText_HealthcareLROTask()
        {
            string textA = "Prescribed 100mg ibuprofen, taken twice daily.";

            MultiLanguageTextInput multiLanguageTextInput = new MultiLanguageTextInput()
            {
                MultiLanguageInputs =
                {
                    new MultiLanguageInput("A", textA) { Language = "en" },
                }
            };

            var analyzeTextOperationActions = new AnalyzeTextOperationAction[]
            {
                new HealthcareOperationAction
                {
                    Name = "HealthcareOperationActionSample",
                },
            };

            Response<AnalyzeTextOperationState> response = await client.AnalyzeTextOperationAsync(multiLanguageTextInput, analyzeTextOperationActions);
            AnalyzeTextOperationState analyzeTextOperationState = response.Value;

            Assert.Multiple(() =>
            {
                Assert.That(response, Is.Not.Null);
                Assert.That(analyzeTextOperationState, Is.Not.Null);
            });
            Assert.That(analyzeTextOperationState.Actions, Is.Not.Null);
            Assert.That(analyzeTextOperationState.Actions.Items, Is.Not.Null);

            foreach (AnalyzeTextOperationResult analyzeTextOperationResult in analyzeTextOperationState.Actions.Items)
            {
                if (analyzeTextOperationResult is HealthcareOperationResult)
                {
                    HealthcareOperationResult healthcareLROResult = (HealthcareOperationResult)analyzeTextOperationResult;
                    Assert.That(healthcareLROResult, Is.Not.Null);
                    Assert.That(healthcareLROResult.Results, Is.Not.Null);
                    Assert.That(healthcareLROResult.Results.Documents, Is.Not.Null);

                    foreach (HealthcareActionResult healthcareEntitiesDocument in healthcareLROResult.Results.Documents)
                    {
                        Assert.Multiple(() =>
                        {
                            Assert.That(healthcareEntitiesDocument.Id, Is.Not.Null);
                            Assert.That(healthcareEntitiesDocument.Entities, Is.Not.Null);
                            Assert.That(healthcareEntitiesDocument.Relations, Is.Not.Null);
                        });
                        foreach (HealthcareEntity healthcareEntity in healthcareEntitiesDocument.Entities)
                        {
                            Assert.That(healthcareEntity, Is.Not.Null);
                            Assert.Multiple(() =>
                            {
                                Assert.That(healthcareEntity.Text, Is.Not.Null);
                                Assert.That(healthcareEntity.Category, Is.Not.Null);
                                Assert.That(healthcareEntity.Offset, Is.Not.Null);
                                Assert.That(healthcareEntity.Length, Is.Not.Null);
                            });
                            Assert.That(healthcareEntity.ConfidenceScore, Is.Not.Null);

                            if (healthcareEntity.Links is not null)
                            {
                                foreach (HealthcareEntityLink healthcareEntityLink in healthcareEntity.Links)
                                {
                                    Assert.That(healthcareEntityLink, Is.Not.Null);
                                    Assert.Multiple(() =>
                                    {
                                        Assert.That(healthcareEntityLink.Id, Is.Not.Null);
                                        Assert.That(healthcareEntityLink.DataSource, Is.Not.Null);
                                    });
                                }
                            }
                        }
                        foreach (HealthcareRelation relation in healthcareEntitiesDocument.Relations)
                        {
                            Assert.That(relation, Is.Not.Null);
                            Assert.Multiple(() =>
                            {
                                Assert.That(relation.RelationType, Is.Not.Null);
                                Assert.That(relation.Entities, Is.Not.Null);
                            });
                            foreach (HealthcareRelationEntity healthcareRelationEntity in relation.Entities)
                            {
                                Assert.Multiple(() =>
                                {
                                    Assert.That(healthcareRelationEntity.Role, Is.Not.Null);
                                    Assert.That(healthcareRelationEntity.Ref, Is.Not.Null);
                                });
                            }
                        }
                    }
                }
            }
        }

        [RecordedTest]
        public async Task AnalyzeText_CustomEntitiesLROTask()
        {
            string textA =
                "We love this trail and make the trip every year. The views are breathtaking and well worth the hike!"
                + " Yesterday was foggy though, so we missed the spectacular views. We tried again today and it was"
                + " amazing. Everyone in my family liked the trail although it was too challenging for the less"
                + " athletic among us.";

            MultiLanguageTextInput multiLanguageTextInput = new MultiLanguageTextInput()
            {
                MultiLanguageInputs =
                {
                    new MultiLanguageInput("A", textA) { Language = "en" },
                }
            };

            string projectName = TestEnvironment.CTProjectName;
            string deploymentName = TestEnvironment.CTDeploymentName;

            CustomEntitiesActionContent customEntitiesActionContent = new CustomEntitiesActionContent(projectName, deploymentName);

            var analyzeTextOperationActions = new AnalyzeTextOperationAction[]
            {
                new CustomEntitiesOperationAction
                {
                    Name = "CustomEntitiesOperationActionSample",
                    ActionContent = customEntitiesActionContent
                },
            };

            Response<AnalyzeTextOperationState> response = await client.AnalyzeTextOperationAsync(multiLanguageTextInput, analyzeTextOperationActions);
            AnalyzeTextOperationState analyzeTextOperationState = response.Value;

            Assert.Multiple(() =>
            {
                Assert.That(response, Is.Not.Null);
                Assert.That(analyzeTextOperationState, Is.Not.Null);
            });
            Assert.That(analyzeTextOperationState.Actions, Is.Not.Null);
            Assert.That(analyzeTextOperationState.Actions.Items, Is.Not.Null);

            foreach (AnalyzeTextOperationResult analyzeTextOperationResult in analyzeTextOperationState.Actions.Items)
            {
                if (analyzeTextOperationResult is CustomEntityRecognitionOperationResult)
                {
                    CustomEntityRecognitionOperationResult customClassificationResult = (CustomEntityRecognitionOperationResult)analyzeTextOperationResult;
                    Assert.That(customClassificationResult, Is.Not.Null);
                    Assert.That(customClassificationResult.Results, Is.Not.Null);
                    Assert.That(customClassificationResult.Results.Documents, Is.Not.Null);

                    foreach (CustomEntityActionResult entitiesDocument in customClassificationResult.Results.Documents)
                    {
                        Assert.Multiple(() =>
                        {
                            Assert.That(entitiesDocument.Id, Is.Not.Null);
                            Assert.That(entitiesDocument.Entities, Is.Not.Null);
                        });

                        foreach (NamedEntity entity in entitiesDocument.Entities)
                        {
                            Assert.That(entity, Is.Not.Null);
                            Assert.Multiple(() =>
                            {
                                Assert.That(entity.Text, Is.Not.Null);
                                Assert.That(entity.Category, Is.Not.Null);
                                Assert.That(entity.Offset, Is.Not.Null);
                                Assert.That(entity.Length, Is.Not.Null);
                            });
                            Assert.That(entity.ConfidenceScore, Is.Not.Null);
                        }
                    }
                }
            }
        }

        [RecordedTest]
        public async Task AnalyzeText_CustomSingleLabelClassificationLROTask()
        {
            string textA =
                "I need a reservation for an indoor restaurant in China. Please don't stop the music. Play music and"
                + " add it to my playlist.";

            MultiLanguageTextInput multiLanguageTextInput = new MultiLanguageTextInput()
            {
                MultiLanguageInputs =
                {
                    new MultiLanguageInput("A", textA) { Language = "en" },
                }
            };

            string projectName = TestEnvironment.CSCProjectName;
            string deploymentName = TestEnvironment.CSCDeploymentName;

            CustomSingleLabelClassificationActionContent customSingleLabelClassificationActionContent = new CustomSingleLabelClassificationActionContent(projectName, deploymentName);

            var analyzeTextOperationActions = new AnalyzeTextOperationAction[]
            {
                new CustomSingleLabelClassificationOperationAction
                {
                    Name = "CSCOperationActionSample",
                    ActionContent = customSingleLabelClassificationActionContent
                },
            };

            Response<AnalyzeTextOperationState> response = await client.AnalyzeTextOperationAsync(multiLanguageTextInput, analyzeTextOperationActions);

            AnalyzeTextOperationState analyzeTextOperationState = response.Value;
            Assert.Multiple(() =>
            {
                Assert.That(response, Is.Not.Null);
                Assert.That(analyzeTextOperationState, Is.Not.Null);
            });
            Assert.That(analyzeTextOperationState.Actions, Is.Not.Null);
            Assert.That(analyzeTextOperationState.Actions.Items, Is.Not.Null);

            foreach (AnalyzeTextOperationResult analyzeTextOperationResult in analyzeTextOperationState.Actions.Items)
            {
                if (analyzeTextOperationResult is CustomSingleLabelClassificationOperationResult)
                {
                    CustomSingleLabelClassificationOperationResult customClassificationResult = (CustomSingleLabelClassificationOperationResult)analyzeTextOperationResult;
                    Assert.That(customClassificationResult, Is.Not.Null);
                    Assert.That(customClassificationResult.Results, Is.Not.Null);
                    Assert.That(customClassificationResult.Results.Documents, Is.Not.Null);

                    foreach (ClassificationActionResult customClassificationDocument in customClassificationResult.Results.Documents)
                    {
                        Assert.Multiple(() =>
                        {
                            Assert.That(customClassificationDocument.Id, Is.Not.Null);
                            Assert.That(customClassificationDocument.Class, Is.Not.Null);
                        });

                        foreach (ClassificationResult classification in customClassificationDocument.Class)
                        {
                            Assert.Multiple(() =>
                            {
                                Assert.That(classification.Category, Is.Not.Null);
                                Assert.That(classification.ConfidenceScore, Is.Not.Null);
                            });
                        }
                    }
                }
            }
        }

        [RecordedTest]
        public async Task AnalyzeText_CustomMultiLabelClassificationLROTask()
        {
            string textA =
                "I need a reservation for an indoor restaurant in China. Please don't stop the music. Play music and"
                + " add it to my playlist.";

            MultiLanguageTextInput multiLanguageTextInput = new MultiLanguageTextInput()
            {
                MultiLanguageInputs =
        {
            new MultiLanguageInput("A", textA) { Language = "en" },
        }
            };

            string projectName = TestEnvironment.CMCProjectName;
            string deploymentName = TestEnvironment.CMCDeploymentName;

            CustomMultiLabelClassificationActionContent customMultiLabelClassificationActionContent = new CustomMultiLabelClassificationActionContent(projectName, deploymentName);

            var analyzeTextOperationActions = new AnalyzeTextOperationAction[]
            {
                new CustomMultiLabelClassificationOperationAction
                {
                    Name = "CMCOperationActionSample",
                    ActionContent = customMultiLabelClassificationActionContent,
                },
            };

            Response<AnalyzeTextOperationState> response = await client.AnalyzeTextOperationAsync(multiLanguageTextInput, analyzeTextOperationActions);

            AnalyzeTextOperationState analyzeTextOperationState = response.Value;
            Assert.Multiple(() =>
            {
                Assert.That(response, Is.Not.Null);
                Assert.That(analyzeTextOperationState, Is.Not.Null);
            });
            Assert.That(analyzeTextOperationState.Actions, Is.Not.Null);
            Assert.That(analyzeTextOperationState.Actions.Items, Is.Not.Null);

            foreach (AnalyzeTextOperationResult analyzeTextOperationResult in analyzeTextOperationState.Actions.Items)
            {
                if (analyzeTextOperationResult is CustomMultiLabelClassificationOperationResult)
                {
                    CustomMultiLabelClassificationOperationResult customClassificationResult = (CustomMultiLabelClassificationOperationResult)analyzeTextOperationResult;
                    Assert.That(customClassificationResult, Is.Not.Null);
                    Assert.That(customClassificationResult.Results, Is.Not.Null);
                    Assert.That(customClassificationResult.Results.Documents, Is.Not.Null);

                    foreach (ClassificationActionResult customClassificationDocument in customClassificationResult.Results.Documents)
                    {
                        Assert.Multiple(() =>
                        {
                            Assert.That(customClassificationDocument.Id, Is.Not.Null);
                            Assert.That(customClassificationDocument.Class, Is.Not.Null);
                        });

                        foreach (ClassificationResult classification in customClassificationDocument.Class)
                        {
                            Assert.Multiple(() =>
                            {
                                Assert.That(classification.Category, Is.Not.Null);
                                Assert.That(classification.ConfidenceScore, Is.Not.Null);
                            });
                        }
                    }
                }
            }
        }

        [RecordedTest]
        [ServiceVersion(Min = TextAnalysisClientOptions.ServiceVersion.V2023_04_01)]
        public async Task AnalyzeText_ExtractiveSummarizationLROTaskAsync()
        {
            string textA =
                "Windows 365 was in the works before COVID-19 sent companies around the world on a scramble to secure"
                + " solutions to support employees suddenly forced to work from home, but “what really put the"
                + " firecracker behind it was the pandemic, it accelerated everything,” McKelvey said. She explained"
                + " that customers were asking, “How do we create an experience for people that makes them still feel"
                + " connected to the company without the physical presence of being there?” In this new world of"
                + " Windows 365, remote workers flip the lid on their laptop, boot up the family workstation or clip a"
                + " keyboard onto a tablet, launch a native app or modern web browser and login to their Windows 365"
                + " account. From there, their Cloud PC appears with their background, apps, settings and content just"
                + " as they left it when they last were last there – in the office, at home or a coffee shop. And"
                + " then, when you’re done, you’re done. You won’t have any issues around security because you’re not"
                + " saving anything on your device,” McKelvey said, noting that all the data is stored in the cloud."
                + " The ability to login to a Cloud PC from anywhere on any device is part of Microsoft’s larger"
                + " strategy around tailoring products such as Microsoft Teams and Microsoft 365 for the post-pandemic"
                + " hybrid workforce of the future, she added. It enables employees accustomed to working from home to"
                + " continue working from home; it enables companies to hire interns from halfway around the world; it"
                + " allows startups to scale without requiring IT expertise. “I think this will be interesting for"
                + " those organizations who, for whatever reason, have shied away from virtualization. This is giving"
                + " them an opportunity to try it in a way that their regular, everyday endpoint admin could manage,”"
                + " McKelvey said. The simplicity of Windows 365 won over Dean Wells, the corporate chief information"
                + " officer for the Government of Nunavut. His team previously attempted to deploy a traditional"
                + " virtual desktop infrastructure and found it inefficient and unsustainable given the limitations of"
                + " low-bandwidth satellite internet and the constant need for IT staff to manage the network and"
                + " infrastructure. We didn’t run it for very long,” he said. “It didn’t turn out the way we had"
                + " hoped. So, we actually had terminated the project and rolled back out to just regular PCs.” He"
                + " re-evaluated this decision after the Government of Nunavut was hit by a ransomware attack in"
                + " November 2019 that took down everything from the phone system to the government’s servers."
                + " Microsoft helped rebuild the system, moving the government to Teams, SharePoint, OneDrive and"
                + " Microsoft 365. Manchester’s team recruited the Government of Nunavut to pilot Windows 365. Wells"
                + " was intrigued, especially by the ability to manage the elastic workforce securely and seamlessly."
                + " “The impact that I believe we are finding, and the impact that we’re going to find going forward,"
                + " is being able to access specialists from outside the territory and organizations outside the"
                + " territory to come in and help us with our projects, being able to get people on staff with us to"
                + " help us deliver the day-to-day expertise that we need to run the government,” he said. “Being able"
                + " to improve healthcare, being able to improve education, economic development is going to improve"
                + " the quality of life in the communities.”";

            MultiLanguageTextInput multiLanguageTextInput = new MultiLanguageTextInput()
            {
                MultiLanguageInputs =
                {
                    new MultiLanguageInput("A", textA)
                    {
                        Language = "en"
                    },
                }
            };

            var analyzeTextOperationActions = new AnalyzeTextOperationAction[]
            {
                new ExtractiveSummarizationOperationAction
                {
                    Name = "ExtractiveSummarizationOperationActionSample",
                },
            };

            Response<AnalyzeTextOperationState> response = await client.AnalyzeTextOperationAsync(multiLanguageTextInput, analyzeTextOperationActions);

            AnalyzeTextOperationState analyzeTextOperationState = response.Value;
            Assert.Multiple(() =>
            {
                Assert.That(response, Is.Not.Null);
                Assert.That(analyzeTextOperationState, Is.Not.Null);
            });
            Assert.That(analyzeTextOperationState.Actions, Is.Not.Null);
            Assert.That(analyzeTextOperationState.Actions.Items, Is.Not.Null);

            foreach (AnalyzeTextOperationResult analyzeTextOperationResult in analyzeTextOperationState.Actions.Items)
            {
                if (analyzeTextOperationResult is ExtractiveSummarizationOperationResult)
                {
                    ExtractiveSummarizationOperationResult extractiveSummarizationLROResult = (ExtractiveSummarizationOperationResult)analyzeTextOperationResult;
                    Assert.That(extractiveSummarizationLROResult, Is.Not.Null);
                    Assert.That(extractiveSummarizationLROResult.Results, Is.Not.Null);
                    Assert.That(extractiveSummarizationLROResult.Results.Documents, Is.Not.Null);

                    foreach (ExtractedSummaryActionResult extractedSummaryDocument in extractiveSummarizationLROResult.Results.Documents)
                    {
                        Assert.Multiple(() =>
                        {
                            Assert.That(extractedSummaryDocument.Id, Is.Not.Null);
                            Assert.That(extractedSummaryDocument.Sentences, Is.Not.Null);
                        });
                        foreach (ExtractedSummarySentence sentence in extractedSummaryDocument.Sentences)
                        {
                            Assert.Multiple(() =>
                            {
                                Assert.That(sentence.Text, Is.Not.Null);
                                Assert.That(sentence.RankScore, Is.Not.Null);
                                Assert.That(sentence.Offset, Is.Not.Null);
                                Assert.That(sentence.Length, Is.Not.Null);
                            });
                        }
                    }
                }
            }
        }

        [RecordedTest]
        [ServiceVersion(Min = TextAnalysisClientOptions.ServiceVersion.V2023_04_01)]
        public async Task AnalyzeText_AbstractiveSummarizationLROTaskAsync()
        {
            string textA =
                "Windows 365 was in the works before COVID-19 sent companies around the world on a scramble to secure"
                + " solutions to support employees suddenly forced to work from home, but “what really put the"
                + " firecracker behind it was the pandemic, it accelerated everything,” McKelvey said. She explained"
                + " that customers were asking, “How do we create an experience for people that makes them still feel"
                + " connected to the company without the physical presence of being there?” In this new world of"
                + " Windows 365, remote workers flip the lid on their laptop, boot up the family workstation or clip a"
                + " keyboard onto a tablet, launch a native app or modern web browser and login to their Windows 365"
                + " account. From there, their Cloud PC appears with their background, apps, settings and content just"
                + " as they left it when they last were last there – in the office, at home or a coffee shop. And"
                + " then, when you’re done, you’re done. You won’t have any issues around security because you’re not"
                + " saving anything on your device,” McKelvey said, noting that all the data is stored in the cloud."
                + " The ability to login to a Cloud PC from anywhere on any device is part of Microsoft’s larger"
                + " strategy around tailoring products such as Microsoft Teams and Microsoft 365 for the post-pandemic"
                + " hybrid workforce of the future, she added. It enables employees accustomed to working from home to"
                + " continue working from home; it enables companies to hire interns from halfway around the world; it"
                + " allows startups to scale without requiring IT expertise. “I think this will be interesting for"
                + " those organizations who, for whatever reason, have shied away from virtualization. This is giving"
                + " them an opportunity to try it in a way that their regular, everyday endpoint admin could manage,”"
                + " McKelvey said. The simplicity of Windows 365 won over Dean Wells, the corporate chief information"
                + " officer for the Government of Nunavut. His team previously attempted to deploy a traditional"
                + " virtual desktop infrastructure and found it inefficient and unsustainable given the limitations of"
                + " low-bandwidth satellite internet and the constant need for IT staff to manage the network and"
                + " infrastructure. We didn’t run it for very long,” he said. “It didn’t turn out the way we had"
                + " hoped. So, we actually had terminated the project and rolled back out to just regular PCs.” He"
                + " re-evaluated this decision after the Government of Nunavut was hit by a ransomware attack in"
                + " November 2019 that took down everything from the phone system to the government’s servers."
                + " Microsoft helped rebuild the system, moving the government to Teams, SharePoint, OneDrive and"
                + " Microsoft 365. Manchester’s team recruited the Government of Nunavut to pilot Windows 365. Wells"
                + " was intrigued, especially by the ability to manage the elastic workforce securely and seamlessly."
                + " “The impact that I believe we are finding, and the impact that we’re going to find going forward,"
                + " is being able to access specialists from outside the territory and organizations outside the"
                + " territory to come in and help us with our projects, being able to get people on staff with us to"
                + " help us deliver the day-to-day expertise that we need to run the government,” he said. “Being able"
                + " to improve healthcare, being able to improve education, economic development is going to improve"
                + " the quality of life in the communities.”";

            MultiLanguageTextInput multiLanguageTextInput = new MultiLanguageTextInput()
            {
                MultiLanguageInputs =
                {
                    new MultiLanguageInput("A", textA)
                    {
                        Language = "en"
                    },
                }
            };

            var analyzeTextOperationActions = new AnalyzeTextOperationAction[]
            {
                new AbstractiveSummarizationOperationAction
                {
                    Name = "AbsractiveSummarizationOperationActionSample",
                },
            };

            Response<AnalyzeTextOperationState> response = await client.AnalyzeTextOperationAsync(multiLanguageTextInput, analyzeTextOperationActions);

            AnalyzeTextOperationState analyzeTextOperationState = response.Value;
            Assert.Multiple(() =>
            {
                Assert.That(response, Is.Not.Null);
                Assert.That(analyzeTextOperationState, Is.Not.Null);
            });
            Assert.That(analyzeTextOperationState.Actions, Is.Not.Null);
            Assert.That(analyzeTextOperationState.Actions.Items, Is.Not.Null);

            foreach (AnalyzeTextOperationResult analyzeTextOperationResult in analyzeTextOperationState.Actions.Items)
            {
                if (analyzeTextOperationResult is AbstractiveSummarizationOperationResult)
                {
                    AbstractiveSummarizationOperationResult abstractiveSummarizationLROResult = (AbstractiveSummarizationOperationResult)analyzeTextOperationResult;
                    Assert.That(abstractiveSummarizationLROResult, Is.Not.Null);
                    Assert.That(abstractiveSummarizationLROResult.Results, Is.Not.Null);
                    Assert.That(abstractiveSummarizationLROResult.Results.Documents, Is.Not.Null);

                    foreach (AbstractiveSummaryActionResult extractedSummaryDocument in abstractiveSummarizationLROResult.Results.Documents)
                    {
                        Assert.Multiple(() =>
                        {
                            Assert.That(extractedSummaryDocument.Id, Is.Not.Null);
                            Assert.That(extractedSummaryDocument.Summaries, Is.Not.Null);
                        });

                        foreach (AbstractiveSummary summary in extractedSummaryDocument.Summaries)
                        {
                            Assert.That(summary.Text, Is.Not.Null);
                            if (summary.Contexts is not null)
                            {
                                foreach (SummaryContext context in summary.Contexts)
                                {
                                    Assert.Multiple(() =>
                                    {
                                        Assert.That(context.Offset, Is.Not.Null);
                                        Assert.That(context.Length, Is.Not.Null);
                                    });
                                }
                            }

                            Console.WriteLine();
                        }
                    }
                }
            }
        }

        [RecordedTest]
        [ServiceVersion(Min = TextAnalysisClientOptions.ServiceVersion.V2025_05_15_Preview)]
        public async Task AnalyzeText_RecognizePii_WithValueExclusion()
        {
            string text = "My SSN is 859-98-0987.";

            AnalyzeTextInput body = new TextPiiEntitiesRecognitionInput()
            {
                TextInput = new MultiLanguageTextInput()
                {
                    MultiLanguageInputs =
                    {
                        new MultiLanguageInput("3", text) { Language = "en" },
                    }
                },
                ActionContent = new PiiActionContent()
                {
                    ModelVersion = "latest",
                    ValueExclusionPolicy = new ValueExclusionPolicy(
                        caseSensitive: false,
                        excludedValues: new[] { "859-98-0987" }
                    )
                }
            };

            Response<AnalyzeTextResult> response = await client.AnalyzeTextAsync(body);
            Assert.That(response?.Value, Is.Not.Null);

            AnalyzeTextPiiResult piiTaskResult = (AnalyzeTextPiiResult)response.Value;

            foreach (PiiActionResult result in piiTaskResult.Results.Documents)
            {
                Assert.Multiple(() =>
                {
                    Assert.That(result.Id, Is.EqualTo("3"));
                    Assert.That(result.Entities, Is.Not.Null);
                });
                Assert.Multiple(() =>
                {
                    Assert.That(result.Entities, Is.Empty, "Expected no PII entities due to exclusion.");
                    Assert.That(result.RedactedText, Is.EqualTo(text), "Expected redacted text to remain unchanged.");
                });
            }
        }

        [RecordedTest]
        [ServiceVersion(Min = TextAnalysisClientOptions.ServiceVersion.V2025_05_15_Preview)]
        public async Task AnalyzeText_RecognizePii_WithSynonyms()
        {
            PiiActionContent actionContent = new PiiActionContent();
            actionContent.ExcludePiiCategories.Add(PiiCategoriesExclude.PhoneNumber);
            actionContent.EntitySynonyms.Add(
                new EntitySynonyms(
                    new EntityCategory("USBankAccountNumber"),
                    new List<EntitySynonym>
                    {
                        new EntitySynonym("FAN") { Language = "en" },
                        new EntitySynonym("RAN") { Language = "en" }
                    }
                )
            );

            AnalyzeTextInput input = new TextPiiEntitiesRecognitionInput
            {
                TextInput = new MultiLanguageTextInput
                {
                    MultiLanguageInputs =
                    {
                        new MultiLanguageInput("1", "My FAN is 281314478878") { Language = "en" },
                        new MultiLanguageInput("2", "My bank account number is 281314478873.") { Language = "en" },
                        new MultiLanguageInput("3", "My FAN is 281314478878 and Tom's RAN is 281314478879.") { Language = "en" },
                    }
                },
                ActionContent = actionContent
            };

            Response<AnalyzeTextResult> response = await client.AnalyzeTextAsync(input);
            Assert.That(response, Is.Not.Null);
            Assert.That(response.Value, Is.Not.Null);

            AnalyzeTextPiiResult piiResult = (AnalyzeTextPiiResult)response.Value;
            // Assert — Document 1
            var doc1 = piiResult.Results.Documents.Single(d => d.Id == "1");
            Assert.That(doc1.Entities.Any(e =>
                e.Text == "281314478878" &&
                e.Category == "USBankAccountNumber"),
                Is.True,
                "Doc 1 should contain USBankAccountNumber entity for FAN.");

            // Assert — Document 2
            var doc2 = piiResult.Results.Documents.Single(d => d.Id == "2");
            Assert.That(doc2.Entities.Any(e =>
                e.Text == "281314478873" &&
                e.Category == "USBankAccountNumber"),
                Is.True,
                "Doc 2 should contain USBankAccountNumber entity for a normal bank acct number.");

            // Assert — Document 3
            var doc3 = piiResult.Results.Documents.Single(d => d.Id == "3");

            Assert.Multiple(() =>
            {
                Assert.That(doc3.Entities.Any(e =>
                            e.Text == "281314478878" &&
                            e.Category == "USBankAccountNumber"),
                            Is.True,
                            "Doc 3 should contain USBankAccountNumber entity for FAN.");

                Assert.That(doc3.Entities.Any(e =>
                    e.Text == "281314478879" &&
                    e.Category == "USBankAccountNumber"),
                    Is.True,
                    "Doc 3 should contain USBankAccountNumber entity for RAN.");
            });
        }

        [RecordedTest]
        [ServiceVersion(Min = TextAnalysisClientOptions.ServiceVersion.V2025_05_15_Preview)]
        public async Task AnalyzeText_RecognizePii_WithNewEntityTypes()
        {
            AnalyzeTextInput input = new TextPiiEntitiesRecognitionInput()
            {
                TextInput = new MultiLanguageTextInput()
                {
                    MultiLanguageInputs =
                    {
                        new MultiLanguageInput("1", "The date of birth is May 15th, 2015") { Language = "en" },
                        new MultiLanguageInput("2", "The phone number is 5551234567") { Language = "en" }
                    }
                },
                ActionContent = new PiiActionContent()
                {
                    ModelVersion = "latest"
                }
            };

            Response<AnalyzeTextResult> response = await client.AnalyzeTextAsync(input);
            Assert.That(response?.Value, Is.Not.Null);

            AnalyzeTextPiiResult piiResult = (AnalyzeTextPiiResult)response.Value;
            // Assert: document 1 (Date of birth)
            PiiActionResult doc1 = piiResult.Results.Documents.Single(d => d.Id == "1");

            // The raw date string should not appear in redacted text.
            const string dobText = "May 15th, 2015";
            Assert.That(
                doc1.RedactedText != null && !doc1.RedactedText.Contains(dobText),
                Is.True,
                "Document 1 redacted text should not contain the raw date of birth."
            );

            // Assert: document 2 (Phone number)
            PiiActionResult doc2 = piiResult.Results.Documents.Single(d => d.Id == "2");

            // There should be at least one PhoneNumber entity.
            Assert.That(
                doc2.Entities.Any(e => e.Category == PiiCategory.PhoneNumber),
                Is.True,
                "Document 2 should contain a PhoneNumber entity."
            );

            // The raw phone number should not appear in redacted text.
            const string phoneText = "(555) 123-4567";
            Assert.That(
                doc2.RedactedText != null && !doc2.RedactedText.Contains(phoneText),
                Is.True,
                "Document 2 redacted text should not contain the raw phone number."
            );
        }

        [RecordedTest]
        [ServiceVersion(Min = TextAnalysisClientOptions.ServiceVersion.V2025_11_15_Preview)]
        public async Task AnalyzeText_RecognizePii_RedactionPolicies()
        {
            string documentText = "My name is John Doe. My ssn is 123-45-6789. My email is john@example.com..";

            AnalyzeTextInput body = new TextPiiEntitiesRecognitionInput
            {
                TextInput = new MultiLanguageTextInput
                {
                    MultiLanguageInputs =
            {
                new MultiLanguageInput("A", documentText) { Language = "en" },
                new MultiLanguageInput("B", documentText) { Language = "en" },
            }
                },
                ActionContent = new PiiActionContent
                {
                    PiiCategories = { PiiCategory.All },

                    RedactionPolicies =
            {
                new EntityMaskPolicyType
                {
                    // defaultPolicy: use entity mask for everything unless overridden
                    PolicyName = "defaultPolicy",
                    IsDefault = true,
                },
                new CharacterMaskPolicyType
                {
                    // customMaskForSSN: keep part of SSN visible while masking the rest
                    PolicyName = "customMaskForSSN",
                    UnmaskLength = 4,
                    UnmaskFromEnd = true, // if you really want "****-***-6789"-style behavior
                    EntityTypes =
                    {
                        PiiCategoriesExclude.UsSocialSecurityNumber
                    },
                },
                new SyntheticReplacementPolicyType
                {
                    // syntheticMaskForPerson: generate synthetic values for Person and Email
                    PolicyName = "syntheticMaskForPerson",
                    EntityTypes =
                    {
                        PiiCategoriesExclude.Person,
                        PiiCategoriesExclude.Email
                    },
                }
            }
                }
            };

            // Act
            Response<AnalyzeTextResult> response = await client.AnalyzeTextAsync(body);
            AnalyzeTextPiiResult piiResult = (AnalyzeTextPiiResult)response.Value;

            Assert.Multiple(() =>
            {
                // Basic sanity checks
                Assert.That(piiResult.Results.Documents.Count, Is.EqualTo(2), "Expected 2 document results.");
                Assert.That(piiResult.Results.Errors, Is.Empty, "Did not expect any document errors.");
            });

            foreach (PiiActionResult doc in piiResult.Results.Documents)
            {
                Assert.Multiple(() =>
                {
                    // 1. We should have at least these three PII categories recognized:
                    Assert.That(
                        doc.Entities.Any(e => e.Category == PiiCategory.UsSocialSecurityNumber),
                        Is.True,
                        $"Document {doc.Id} should contain a US SSN entity.");

                    Assert.That(
                        doc.Entities.Any(e => e.Category == PiiCategory.Person),
                        Is.True,
                        $"Document {doc.Id} should contain a Person entity.");

                    Assert.That(
                        doc.Entities.Any(e => e.Category == PiiCategory.Email),
                        Is.True,
                        $"Document {doc.Id} should contain an Email entity.");

                    // 2. Check redaction behavior for Person and Email:
                    //    "John Doe" and "john@example.com" should not appear in the redacted text
                    Assert.That(doc.RedactedText, Is.Not.Null, "RedactedText should not be null.");
                });
                Assert.That(doc.RedactedText, Does.Not.Contain("John Doe"), $"Document {doc.Id} redacted text should not contain the original person name.");
                Assert.That(doc.RedactedText, Does.Not.Contain("john@example.com"), $"Document {doc.Id} redacted text should not contain the original email.");

                // 3. Check SSN redaction behavior:
                //    Full SSN should be masked, but the last 4 digits may remain visible due to CharacterMask policy.
                const string fullSsn = "123-45-6789";
                const string last4 = "6789";

                Assert.That(doc.RedactedText, Does.Not.Contain(fullSsn), $"Document {doc.Id} redacted text should not contain the full SSN.");
                Assert.That(doc.RedactedText, Does.Contain(last4), $"Document {doc.Id} redacted text should still contain the last 4 digits of the SSN due to the custom mask policy.");
            }
        }

        [RecordedTest]
        [ServiceVersion(Min = TextAnalysisClientOptions.ServiceVersion.V2025_11_15_Preview)]
        public async Task AnalyzeText_RecognizePii_ConfidenceScoreThreshold()
        {
            string text =
            "My name is John Doe. My ssn is 222-45-6789. My email is john@example.com. John Doe is my name.";

            // Input documents
            var textInput = new MultiLanguageTextInput
            {
                MultiLanguageInputs =
            {
                new MultiLanguageInput("1", text) { Language = "en" }
            }
                };

            // Confidence score overrides:
            //   default = 0.3
            //   SSN & Email overridden to 0.9 (so they get filtered out as entities)
            var confidenceThreshold = new ConfidenceScoreThreshold(0.3f);
            confidenceThreshold.Overrides.Add(
                new ConfidenceScoreThresholdOverride(
                    value: 0.9f,
                    entity: PiiCategory.UsSocialSecurityNumber.ToString()
                ));
            confidenceThreshold.Overrides.Add(
                new ConfidenceScoreThresholdOverride(
                    value: 0.9f,
                    entity: PiiCategory.Email.ToString()
                ));

            var actionContent = new PiiActionContent
            {
                PiiCategories = { PiiCategory.All },
                DisableEntityValidation = true,
                ConfidenceScoreThreshold = confidenceThreshold
            };

            var body = new TextPiiEntitiesRecognitionInput
            {
                TextInput = textInput,
                ActionContent = actionContent
            };

            // Act (non-LRO)
            Response<AnalyzeTextResult> response = await client.AnalyzeTextAsync(body);
            var piiResult = (AnalyzeTextPiiResult)response.Value;

            // Basic shape checks
            Assert.That(piiResult, Is.Not.Null);
            Assert.That(piiResult.Results, Is.Not.Null);
            Assert.That(piiResult.Results.Documents, Is.Not.Null);
            Assert.That(piiResult.Results.Documents.Count, Is.EqualTo(1));

            PiiActionResult doc = piiResult.Results.Documents[0];
            string redacted = doc.RedactedText;

            // Person should be masked out in text; SSN & Email should remain in the text
            // (but be filtered out as entities due to the 0.9 threshold overrides)
            Assert.That(redacted, Does.Not.Contain("John Doe"), "Person name should be masked in redacted text.");
            Assert.That(redacted, Does.Contain("222-45-6789"), "SSN should remain visible in redacted text.");
            Assert.That(redacted, Does.Contain("john@example.com"), "Email should remain visible in redacted text.");

            // Only Person entities should be returned (SSN & Email filtered by high thresholds)
            Assert.That(doc.Entities.Count, Is.EqualTo(2), "Expected exactly 2 entities to be returned.");

            var categories = new HashSet<string>(
            doc.Entities.Select(e => e.Category.ToString())
);

            Assert.That(
                categories,
                Is.EquivalentTo(new[] { PiiCategory.Person.ToString() }),
                "Only Person entities should be returned."
            );

            Assert.Multiple(() =>
            {
                // Ensure no SSN or Email entities are present
                Assert.That(
                    doc.Entities.Any(e => e.Category == PiiCategory.UsSocialSecurityNumber),
                    Is.False,
                    "USSocialSecurityNumber entities should be filtered out by the confidence threshold override."
                );
                Assert.That(
                    doc.Entities.Any(e => e.Category == PiiCategory.Email),
                    Is.False,
                    "Email entities should be filtered out by the confidence threshold override."
                );
            });

            // Quick sanity on confidence
            foreach (PiiEntity e in doc.Entities)
            {
                Assert.Multiple(() =>
                {
                    Assert.That(e.Category, Is.EqualTo(PiiCategory.Person.ToString()), "All returned entities should be Person.");
                    Assert.That(e.ConfidenceScore, Is.GreaterThanOrEqualTo(0.3), "Entities should respect the default confidence floor.");
                });
            }
        }
    }
}
