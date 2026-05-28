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
            Assert.IsNotNull(response);
            Assert.IsNotNull(response.Value);
            AnalyzeTextLanguageDetectionResult AnalyzeTextLanguageDetectionResult = (AnalyzeTextLanguageDetectionResult)response.Value;

            Assert.IsNotNull(AnalyzeTextLanguageDetectionResult);
            Assert.IsNotNull(AnalyzeTextLanguageDetectionResult.Results);
            Assert.IsNotNull(AnalyzeTextLanguageDetectionResult.Results.Documents);
            foreach (LanguageDetectionDocumentResult document in AnalyzeTextLanguageDetectionResult.Results.Documents)
            {
                Assert.IsNotNull(document);
                Assert.IsNotNull(document.DetectedLanguage);
                Assert.IsNotNull(document.DetectedLanguage.Name);
                Assert.IsNotNull(document.DetectedLanguage.Iso6391Name);
                Assert.IsNotNull(document.DetectedLanguage.ConfidenceScore);
                Assert.IsNotNull(document.Id);
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
            Assert.IsNotNull(response);
            Assert.IsNotNull(response.Value);
            AnalyzeTextSentimentResult AnalyzeTextSentimentResult = (AnalyzeTextSentimentResult)response.Value;

            Assert.IsNotNull(AnalyzeTextSentimentResult);
            Assert.IsNotNull(AnalyzeTextSentimentResult.Results);
            Assert.IsNotNull(AnalyzeTextSentimentResult.Results.Documents);
            foreach (SentimentActionResult sentimentResponseWithDocumentDetectedLanguage in AnalyzeTextSentimentResult.Results.Documents)
            {
                Assert.IsNotNull(sentimentResponseWithDocumentDetectedLanguage);
                Assert.IsNotNull(sentimentResponseWithDocumentDetectedLanguage.Id);
                Assert.IsNotNull(sentimentResponseWithDocumentDetectedLanguage.Sentiment);
                Assert.IsNotNull(sentimentResponseWithDocumentDetectedLanguage.ConfidenceScores);
                Assert.IsNotNull(sentimentResponseWithDocumentDetectedLanguage.ConfidenceScores.Positive);
                Assert.IsNotNull(sentimentResponseWithDocumentDetectedLanguage.ConfidenceScores.Neutral);
                Assert.IsNotNull(sentimentResponseWithDocumentDetectedLanguage.ConfidenceScores.Negative);
                Assert.IsNotNull(sentimentResponseWithDocumentDetectedLanguage.Sentences);
                foreach (SentenceSentiment sentenceSentiment in sentimentResponseWithDocumentDetectedLanguage.Sentences)
                {
                    Assert.IsNotNull(sentenceSentiment);
                    Assert.IsNotNull(sentenceSentiment.Text);
                    Assert.IsNotNull(sentenceSentiment.Sentiment);
                    Assert.IsNotNull(sentenceSentiment.ConfidenceScores);
                    Assert.IsNotNull(sentenceSentiment.ConfidenceScores.Positive);
                    Assert.IsNotNull(sentenceSentiment.ConfidenceScores.Neutral);
                    Assert.IsNotNull(sentenceSentiment.ConfidenceScores.Negative);
                    Assert.IsNotNull(sentenceSentiment.Offset);
                    Assert.IsNotNull(sentenceSentiment.Length);
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
            Assert.IsNotNull(response);
            Assert.IsNotNull(response.Value);
            AnalyzeTextKeyPhraseResult keyPhraseTaskResult = (AnalyzeTextKeyPhraseResult)response.Value;

            Assert.IsNotNull(keyPhraseTaskResult);
            Assert.IsNotNull(keyPhraseTaskResult.Results);
            Assert.IsNotNull(keyPhraseTaskResult.Results.Documents);
            foreach (KeyPhrasesActionResult kpeResult in keyPhraseTaskResult.Results.Documents)
            {
                Assert.IsNotNull(kpeResult);
                Assert.IsNotNull(kpeResult.Id);
                Assert.IsNotNull(kpeResult.KeyPhrases);
                foreach (string keyPhrase in kpeResult.KeyPhrases)
                {
                    Assert.IsNotNull(keyPhrase);
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
            Assert.IsNotNull(response);
            Assert.IsNotNull(response.Value);
            AnalyzeTextEntitiesResult entitiesTaskResult = (AnalyzeTextEntitiesResult)response.Value;

            Assert.IsNotNull(entitiesTaskResult);
            Assert.IsNotNull(entitiesTaskResult.Results);
            Assert.IsNotNull(entitiesTaskResult.Results.Documents);
            foreach (EntityActionResult nerResult in entitiesTaskResult.Results.Documents)
            {
                Assert.IsNotNull(nerResult);
                Assert.IsNotNull(nerResult.Id);
                Assert.IsNotNull(nerResult.Entities);
                foreach (NamedEntityWithMetadata entity in nerResult.Entities)
                {
                    Assert.IsNotNull(entity);
                    Assert.IsNotNull(entity.Text);
                    Assert.IsNotNull(entity.Category);
                    Assert.IsNotNull(entity.Offset);
                    Assert.IsNotNull(entity.Length);
                    Assert.IsNotNull(entity.ConfidenceScore);
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
            Assert.IsNotNull(response);
            Assert.IsNotNull(response.Value);
            AnalyzeTextPiiResult piiTaskResult = (AnalyzeTextPiiResult)response.Value;

            Assert.IsNotNull(piiTaskResult);
            Assert.IsNotNull(piiTaskResult.Results);
            Assert.IsNotNull(piiTaskResult.Results.Documents);
            foreach (PiiActionResult piiResult in piiTaskResult.Results.Documents)
            {
                Assert.IsNotNull(piiResult.Id);
                Assert.IsNotNull(piiResult.Entities);
                foreach (PiiEntity entity in piiResult.Entities)
                {
                    Assert.IsNotNull(entity);
                    Assert.IsNotNull(entity.Text);
                    Assert.IsNotNull(entity.Category);
                    Assert.IsNotNull(entity.Offset);
                    Assert.IsNotNull(entity.Length);
                    Assert.IsNotNull(entity.ConfidenceScore);
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
            Assert.IsNotNull(response);
            Assert.IsNotNull(response.Value);
            AnalyzeTextEntityLinkingResult entityLinkingTaskResult = (AnalyzeTextEntityLinkingResult)response.Value;

            Assert.IsNotNull(entityLinkingTaskResult);
            Assert.IsNotNull(entityLinkingTaskResult.Results);
            Assert.IsNotNull(entityLinkingTaskResult.Results.Documents);
            foreach (EntityLinkingActionResult entityLinkingResult in entityLinkingTaskResult.Results.Documents)
            {
                Assert.IsNotNull(entityLinkingResult.Id);
                Assert.IsNotNull(entityLinkingResult.Entities);
                foreach (LinkedEntity linkedEntity in entityLinkingResult.Entities)
                {
                    Assert.IsNotNull(linkedEntity.Name);
                    Assert.IsNotNull(linkedEntity.Language);
                    Assert.IsNotNull(linkedEntity.DataSource);
                    Assert.IsNotNull(linkedEntity.Url);
                    Assert.IsNotNull(linkedEntity.Id);
                    Assert.IsNotNull(linkedEntity.Matches);
                    foreach (EntityLinkingMatch match in linkedEntity.Matches)
                    {
                        Assert.NotNull(match.ConfidenceScore);
                        Assert.NotNull(match.Text);
                        Assert.NotNull(match.Offset);
                        Assert.NotNull(match.Length);
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

            Assert.IsNotNull(response);
            Assert.IsNotNull(analyzeTextOperationState);
            Assert.IsNotNull(analyzeTextOperationState.Actions);
            Assert.IsNotNull(analyzeTextOperationState.Actions.Items);

            foreach (AnalyzeTextOperationResult analyzeTextOperationResult in analyzeTextOperationState.Actions.Items)
            {
                if (analyzeTextOperationResult is HealthcareOperationResult)
                {
                    HealthcareOperationResult healthcareLROResult = (HealthcareOperationResult)analyzeTextOperationResult;
                    Assert.IsNotNull(healthcareLROResult);
                    Assert.IsNotNull(healthcareLROResult.Results);
                    Assert.IsNotNull(healthcareLROResult.Results.Documents);

                    foreach (HealthcareActionResult healthcareEntitiesDocument in healthcareLROResult.Results.Documents)
                    {
                        Assert.IsNotNull(healthcareEntitiesDocument.Id);
                        Assert.IsNotNull(healthcareEntitiesDocument.Entities);
                        Assert.IsNotNull(healthcareEntitiesDocument.Relations);
                        foreach (HealthcareEntity healthcareEntity in healthcareEntitiesDocument.Entities)
                        {
                            Assert.IsNotNull(healthcareEntity);
                            Assert.IsNotNull(healthcareEntity.Text);
                            Assert.IsNotNull(healthcareEntity.Category);
                            Assert.IsNotNull(healthcareEntity.Offset);
                            Assert.IsNotNull(healthcareEntity.Length);
                            Assert.IsNotNull(healthcareEntity.ConfidenceScore);

                            if (healthcareEntity.Links is not null)
                            {
                                foreach (HealthcareEntityLink healthcareEntityLink in healthcareEntity.Links)
                                {
                                    Assert.IsNotNull(healthcareEntityLink);
                                    Assert.IsNotNull(healthcareEntityLink.Id);
                                    Assert.IsNotNull(healthcareEntityLink.DataSource);
                                }
                            }
                        }
                        foreach (HealthcareRelation relation in healthcareEntitiesDocument.Relations)
                        {
                            Assert.IsNotNull(relation);
                            Assert.IsNotNull(relation.RelationType);
                            Assert.IsNotNull(relation.Entities);
                            foreach (HealthcareRelationEntity healthcareRelationEntity in relation.Entities)
                            {
                                Assert.IsNotNull(healthcareRelationEntity.Role);
                                Assert.IsNotNull(healthcareRelationEntity.Ref);
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

            Assert.IsNotNull(response);
            Assert.IsNotNull(analyzeTextOperationState);
            Assert.IsNotNull(analyzeTextOperationState.Actions);
            Assert.IsNotNull(analyzeTextOperationState.Actions.Items);

            foreach (AnalyzeTextOperationResult analyzeTextOperationResult in analyzeTextOperationState.Actions.Items)
            {
                if (analyzeTextOperationResult is CustomEntityRecognitionOperationResult)
                {
                    CustomEntityRecognitionOperationResult customClassificationResult = (CustomEntityRecognitionOperationResult)analyzeTextOperationResult;
                    Assert.IsNotNull(customClassificationResult);
                    Assert.IsNotNull(customClassificationResult.Results);
                    Assert.IsNotNull(customClassificationResult.Results.Documents);

                    foreach (CustomEntityActionResult entitiesDocument in customClassificationResult.Results.Documents)
                    {
                        Assert.IsNotNull(entitiesDocument.Id);
                        Assert.IsNotNull(entitiesDocument.Entities);

                        foreach (NamedEntity entity in entitiesDocument.Entities)
                        {
                            Assert.IsNotNull(entity);
                            Assert.IsNotNull(entity.Text);
                            Assert.IsNotNull(entity.Category);
                            Assert.IsNotNull(entity.Offset);
                            Assert.IsNotNull(entity.Length);
                            Assert.IsNotNull(entity.ConfidenceScore);
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
            Assert.IsNotNull(response);
            Assert.IsNotNull(analyzeTextOperationState);
            Assert.IsNotNull(analyzeTextOperationState.Actions);
            Assert.IsNotNull(analyzeTextOperationState.Actions.Items);

            foreach (AnalyzeTextOperationResult analyzeTextOperationResult in analyzeTextOperationState.Actions.Items)
            {
                if (analyzeTextOperationResult is CustomSingleLabelClassificationOperationResult)
                {
                    CustomSingleLabelClassificationOperationResult customClassificationResult = (CustomSingleLabelClassificationOperationResult)analyzeTextOperationResult;
                    Assert.IsNotNull(customClassificationResult);
                    Assert.IsNotNull(customClassificationResult.Results);
                    Assert.IsNotNull(customClassificationResult.Results.Documents);

                    foreach (ClassificationActionResult customClassificationDocument in customClassificationResult.Results.Documents)
                    {
                        Assert.IsNotNull(customClassificationDocument.Id);
                        Assert.IsNotNull(customClassificationDocument.Class);

                        foreach (ClassificationResult classification in customClassificationDocument.Class)
                        {
                            Assert.IsNotNull(classification.Category);
                            Assert.IsNotNull(classification.ConfidenceScore);
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
            Assert.IsNotNull(response);
            Assert.IsNotNull(analyzeTextOperationState);
            Assert.IsNotNull(analyzeTextOperationState.Actions);
            Assert.IsNotNull(analyzeTextOperationState.Actions.Items);

            foreach (AnalyzeTextOperationResult analyzeTextOperationResult in analyzeTextOperationState.Actions.Items)
            {
                if (analyzeTextOperationResult is CustomMultiLabelClassificationOperationResult)
                {
                    CustomMultiLabelClassificationOperationResult customClassificationResult = (CustomMultiLabelClassificationOperationResult)analyzeTextOperationResult;
                    Assert.IsNotNull(customClassificationResult);
                    Assert.IsNotNull(customClassificationResult.Results);
                    Assert.IsNotNull(customClassificationResult.Results.Documents);

                    foreach (ClassificationActionResult customClassificationDocument in customClassificationResult.Results.Documents)
                    {
                        Assert.IsNotNull(customClassificationDocument.Id);
                        Assert.IsNotNull(customClassificationDocument.Class);

                        foreach (ClassificationResult classification in customClassificationDocument.Class)
                        {
                            Assert.IsNotNull(classification.Category);
                            Assert.IsNotNull(classification.ConfidenceScore);
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
            Assert.IsNotNull(response);
            Assert.IsNotNull(analyzeTextOperationState);
            Assert.IsNotNull(analyzeTextOperationState.Actions);
            Assert.IsNotNull(analyzeTextOperationState.Actions.Items);

            foreach (AnalyzeTextOperationResult analyzeTextOperationResult in analyzeTextOperationState.Actions.Items)
            {
                if (analyzeTextOperationResult is ExtractiveSummarizationOperationResult)
                {
                    ExtractiveSummarizationOperationResult extractiveSummarizationLROResult = (ExtractiveSummarizationOperationResult)analyzeTextOperationResult;
                    Assert.IsNotNull(extractiveSummarizationLROResult);
                    Assert.IsNotNull(extractiveSummarizationLROResult.Results);
                    Assert.IsNotNull(extractiveSummarizationLROResult.Results.Documents);

                    foreach (ExtractedSummaryActionResult extractedSummaryDocument in extractiveSummarizationLROResult.Results.Documents)
                    {
                        Assert.IsNotNull(extractedSummaryDocument.Id);
                        Assert.IsNotNull(extractedSummaryDocument.Sentences);
                        foreach (ExtractedSummarySentence sentence in extractedSummaryDocument.Sentences)
                        {
                            Assert.IsNotNull(sentence.Text);
                            Assert.IsNotNull(sentence.RankScore);
                            Assert.IsNotNull(sentence.Offset);
                            Assert.IsNotNull(sentence.Length);
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
            Assert.IsNotNull(response);
            Assert.IsNotNull(analyzeTextOperationState);
            Assert.IsNotNull(analyzeTextOperationState.Actions);
            Assert.IsNotNull(analyzeTextOperationState.Actions.Items);

            foreach (AnalyzeTextOperationResult analyzeTextOperationResult in analyzeTextOperationState.Actions.Items)
            {
                if (analyzeTextOperationResult is AbstractiveSummarizationOperationResult)
                {
                    AbstractiveSummarizationOperationResult abstractiveSummarizationLROResult = (AbstractiveSummarizationOperationResult)analyzeTextOperationResult;
                    Assert.IsNotNull(abstractiveSummarizationLROResult);
                    Assert.IsNotNull(abstractiveSummarizationLROResult.Results);
                    Assert.IsNotNull(abstractiveSummarizationLROResult.Results.Documents);

                    foreach (AbstractiveSummaryActionResult extractedSummaryDocument in abstractiveSummarizationLROResult.Results.Documents)
                    {
                        Assert.IsNotNull(extractedSummaryDocument.Id);
                        Assert.IsNotNull(extractedSummaryDocument.Summaries);

                        foreach (AbstractiveSummary summary in extractedSummaryDocument.Summaries)
                        {
                            Assert.IsNotNull(summary.Text);
                            if (summary.Contexts is not null)
                            {
                                foreach (SummaryContext context in summary.Contexts)
                                {
                                    Assert.IsNotNull(context.Offset);
                                    Assert.IsNotNull(context.Length);
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
            Assert.IsNotNull(response?.Value);

            AnalyzeTextPiiResult piiTaskResult = (AnalyzeTextPiiResult)response.Value;

            foreach (PiiActionResult result in piiTaskResult.Results.Documents)
            {
                Assert.AreEqual("3", result.Id);
                Assert.IsNotNull(result.Entities);
                Assert.AreEqual(0, result.Entities.Count, "Expected no PII entities due to exclusion.");
                Assert.AreEqual(text, result.RedactedText, "Expected redacted text to remain unchanged.");
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
            Assert.IsNotNull(response);
            Assert.IsNotNull(response.Value);

            AnalyzeTextPiiResult piiResult = (AnalyzeTextPiiResult)response.Value;
            Assert.AreEqual(3, piiResult.Results.Documents.Count);

            PiiActionResult doc1 = piiResult.Results.Documents.First(d => d.Id == "1");
            Assert.AreEqual("My FAN is ************", doc1.RedactedText);
            // Print all entity details
            Console.WriteLine("Entities for document 1:");
            foreach (PiiEntity entity in doc1.Entities)
            {
                Console.WriteLine($"Text: {entity.Text}");
                Console.WriteLine($"Category: {entity.Category}");
                Console.WriteLine($"Type: {entity.Type}");
                Console.WriteLine($"Offset: {entity.Offset}");
                Console.WriteLine($"Length: {entity.Length}");
                Console.WriteLine($"ConfidenceScore: {entity.ConfidenceScore}");

                if (entity.Tags != null)
                {
                    Console.WriteLine("Tags:");
                    foreach (EntityTag tag in entity.Tags)
                    {
                        Console.WriteLine($"  - Name: {tag.Name}, ConfidenceScore: {tag.ConfidenceScore}");
                    }
                }

                Console.WriteLine();
            }
            Assert.IsTrue(doc1.Entities.Any(e => e.Text == "281314478878" && e.Category == "USBankAccountNumber"));

            PiiActionResult doc2 = piiResult.Results.Documents.First(d => d.Id == "2");
            Assert.AreEqual("My bank account number is ************.", doc2.RedactedText);
            Assert.IsTrue(doc2.Entities.Any(e => e.Text == "281314478873" && e.Category == "USBankAccountNumber"));

            PiiActionResult doc3 = piiResult.Results.Documents.First(d => d.Id == "3");
            Assert.AreEqual("My FAN is ************ and ***'s RAN is ************.", doc3.RedactedText);
            Assert.IsTrue(doc3.Entities.Any(e => e.Text == "281314478878" && e.Category == "USBankAccountNumber"));
            Assert.IsTrue(doc3.Entities.Any(e => e.Text == "281314478879" && e.Category == "USBankAccountNumber"));
            Assert.IsTrue(doc3.Entities.Any(e => e.Text == "Tom" && e.Category == "Person"));
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
                        new MultiLanguageInput("2", "The phone number is (555) 123-4567") { Language = "en" }
                    }
                },
                ActionContent = new PiiActionContent()
                {
                    ModelVersion = "2025-05-15-preview"
                }
            };

            Response<AnalyzeTextResult> response = await client.AnalyzeTextAsync(input);
            Assert.IsNotNull(response?.Value);

            AnalyzeTextPiiResult result = (AnalyzeTextPiiResult)response.Value;
            Assert.AreEqual("2025-05-15-preview", result.Results.ModelVersion);
            Assert.AreEqual(2, result.Results.Documents.Count);

            PiiActionResult doc1 = result.Results.Documents.First(d => d.Id == "1");
            Assert.AreEqual("The date of birth is **************", doc1.RedactedText);
            Assert.IsTrue(doc1.Entities.Any(e =>
                e.Text == "May 15th, 2015" &&
                e.Category == "DateTime" &&
                e.Type == "DateOfBirth"));

            PiiActionResult doc2 = result.Results.Documents.First(d => d.Id == "2");
            Assert.AreEqual("The phone number is **************", doc2.RedactedText);
            Assert.IsTrue(doc2.Entities.Any(e =>
                e.Text == "(555) 123-4567" &&
                e.Category == "PhoneNumber" &&
                e.Type == "PhoneNumber"));
        }
    }
}
