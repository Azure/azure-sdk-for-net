// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Azure.AI.Language.QuestionAnswering.Projects;
using Azure.Core;
using Microsoft.Azure.CognitiveServices.Knowledge.QnAMaker;
using Microsoft.Azure.CognitiveServices.Knowledge.QnAMaker.Models;
using NUnit.Framework;

namespace Azure.AI.Language.QuestionAnswering.Tests.Samples
{
    public partial class QuestionAnsweringClientSamples
    {
        private async Task CognitiveServices_QnA_MigrationGuide_Authoring()
        {
            #region Snippet:CognitiveServices_QnA_Maker_Snippets_MigrationGuide_CreateClient
            QnAMakerClient client = new QnAMakerClient(new ApiKeyServiceClientCredentials("{QnAMakerSubscriptionKey}"), new HttpClient(), false)
            {
                Endpoint = "https://westus.api.cognitive.microsoft.com"
            };
            #endregion Snippet:CognitiveServices_QnA_Maker_Snippets_MigrationGuide_CreateClient

            #region Snippet:CognitiveServices_QnA_Maker_Snippets_MigrationGuide_CreateKnowledgeBase
            Microsoft.Azure.CognitiveServices.Knowledge.QnAMaker.Models.Operation createOp = await client.Knowledgebase.CreateAsync(new CreateKbDTO
            {
                Name = "testqna", QnaList = new List<QnADTO>
                {
                    new QnADTO
                    {
                        Questions = new List<string>
                        {
                            "hi"
                        },
                        Answer = "hello"
                    }
                }
            });
            #endregion Snippet:CognitiveServices_QnA_Maker_Snippets_MigrationGuide_CreateKnowledgeBase

            #region Snippet:CognitiveServices_QnA_Maker_Snippets_MigrationGuide_UpdateKnowledgeBase
            Microsoft.Azure.CognitiveServices.Knowledge.QnAMaker.Models.Operation updateOp = await client.Knowledgebase.UpdateAsync("{KnowledgeBaseID}",
                new UpdateKbOperationDTO
                {
                    Add = new UpdateKbOperationDTOAdd
                    {
                        QnaList = new List<QnADTO>
                        {
                            new QnADTO
                            {
                                Questions = new List<string>
                                {
                                    "bye"
                                },
                                Answer = "goodbye"
                            }
                        }
                    }
                });
            #endregion Snippet:CognitiveServices_QnA_Maker_Snippets_MigrationGuide_UpdateKnowledgeBase

            #region Snippet:CognitiveServices_QnA_Maker_Snippets_MigrationGuide_DownloadKnowledgeBase
            QnADocumentsDTO kbdata = await client.Knowledgebase.DownloadAsync("{KnowledgeBaseID}", EnvironmentType.Test);
            #endregion Snippet:CognitiveServices_QnA_Maker_Snippets_MigrationGuide_UpdateKnowledgeBase

            #region Snippet:CognitiveServices_QnA_Maker_Snippets_MigrationGuide_DeleteKnowledgeBase
            await client.Knowledgebase.DeleteAsync("{KnowledgeBaseID}");
            #endregion Snippet:CognitiveServices_QnA_Maker_Snippets_MigrationGuide_DeleteKnowledgeBase

        }

        private async Task Language_QnA_MigrationGuide_Authoring()
        {
            #region Snippet:Language_QnA_Maker_Snippets_MigrationGuide_CreateClient
            Uri endpoint = new Uri("https://myaccount.api.cognitive.microsoft.com");
            AzureKeyCredential credential = new AzureKeyCredential("{api-key}");

            QuestionAnsweringProjectsClient client = new QuestionAnsweringProjectsClient(endpoint, credential);
            #endregion Snippet:Language_QnA_Maker_Snippets_MigrationGuide_CreateClient

            #region Snippet:Language_QnA_Maker_Snippets_MigrationGuide_CreateProject
            string newProjectName = "testqna";
            RequestContent creationRequestContent = RequestContent.Create(
                new {
                        description = "This is the description for a test project",
                        language = "en",
                        multilingualResource = false,
                        settings = new
                        {
                            defaultAnswer = "No answer found for your question."
                        }
                    }
                );

            Response creationResponse = await client.CreateProjectAsync(newProjectName, creationRequestContent);
            #endregion Snippet:Language_QnA_Maker_Snippets_MigrationGuide_CreateProject

            #region Snippet:Language_QnA_Maker_Snippets_MigrationGuide_UpdateKnowledgeSource
            string sourceUri = "{SourceURI}";
            RequestContent updateSourcesRequestContent = RequestContent.Create(
                new[] {
                    new {
                            op = "add",
                            value = new
                            {
                                displayName = "MicrosoftFAQ",
                                source = sourceUri,
                                sourceUri = sourceUri,
                                sourceKind = "url",
                                contentStructureKind = "unstructured",
                                refresh = false
                            }
                        }
                });

            Operation<BinaryData> updateSourcesOperation = await client.UpdateSourcesAsync("{ProjectName}", updateSourcesRequestContent);
            Response<BinaryData> updateSourcesOperationResult = await updateSourcesOperation.WaitForCompletionAsync();
            #endregion Snippet:Language_QnA_Maker_Snippets_MigrationGuide_UpdateKnowledgeSource

            #region Snippet:Language_QnA_Maker_Snippets_MigrationGuide_UpdateQnas
            RequestContent updateQnasRequestContent = RequestContent.Create(
                new[] {
                    new {
                            op = "add",
                            value = new
                            {
                                questions = new[]
                                    {
                                        "What is the easiest way to use Azure services in my .NET project?"
                                    },
                                answer = "Refer to the Azure SDKs"
                            }
                        }
                });

            Operation<BinaryData> updateQnasOperation = await client.UpdateQnasAsync("{ProjectName}", updateQnasRequestContent);
            Response<BinaryData> updateQnasResult = await updateQnasOperation.WaitForCompletionAsync();
            #endregion Snippet:Language_QnA_Maker_Snippets_MigrationGuide_UpdateQnas

            #region Snippet:Language_QnA_Maker_Snippets_MigrationGuide_ExportProject
            Operation<BinaryData> exportOperation = client.Export("{ProjectName}", "{ExportFormat}");
            Response<BinaryData> exportResult = await exportOperation.WaitForCompletionAsync();
            #endregion Snippet:Language_QnA_Maker_Snippets_MigrationGuide_ExportProject

            #region Snippet:Language_QnA_Maker_Snippets_MigrationGuide_DeleteProject
            Operation<BinaryData> deletionOperation = await client.DeleteProjectAsync("{ProjectName}");
            Response<BinaryData> deleteResult = await deletionOperation.WaitForCompletionAsync();
            #endregion Snippet:Language_QnA_Maker_Snippets_MigrationGuide_DeleteProject
        }

        private async Task Language_QnA_MigrationGuide_Runtime()
        {
            #region Snippet:Language_QnA_Maker_Snippets_MigrationGuide_CreateRuntimeClient
            Uri endpoint = new Uri("{endpoint}");
            AzureKeyCredential credential = new AzureKeyCredential("{api-key}");

            QuestionAnsweringClient client = new QuestionAnsweringClient(endpoint, credential);
            #endregion

#pragma warning disable SA1509 // Opening braces should not be preceded by blank line
            {
                #region Snippet:Language_QnA_Maker_Snippets_MigrationGuide_QueryKnowledgeBase
                QuestionAnsweringProject project = new QuestionAnsweringProject("{project-name}", "{deployment-name}");
                Response<AnswersResult> response = await client.GetAnswersAsync("{question}", project);
                #endregion
            }

            {
                #region Snippet:Language_QnA_Maker_Snippets_MigrationGuide_Chat
                QuestionAnsweringProject project = new QuestionAnsweringProject("{project-name}", "{deployment-name}");
                AnswersOptions options = new AnswersOptions
                {
                    AnswerContext = new KnowledgeBaseAnswerContext(1)
                };

                Response<AnswersResult> responseFollowUp = await client.GetAnswersAsync("{question}", project, options);
                #endregion
            }
#pragma warning restore SA1509 // Opening braces should not be preceded by blank line
        }
        private async Task CognitiveServices_QnA_MigrationGuide_Runtime()
        {
            #region Snippet:CognitiveServices_QnA_Maker_Snippets_MigrationGuide_CreateRuntimeClient
            EndpointKeyServiceClientCredentials credential = new EndpointKeyServiceClientCredentials("{api-key}");

            QnAMakerRuntimeClient client = new QnAMakerRuntimeClient(credential)
            {
                RuntimeEndpoint = "{endpoint}"
            };
            #endregion Snippet:CognitiveServices_QnA_Maker_Snippets_MigrationGuide_CreateRuntimeClient

            #region Snippet:CognitiveServices_QnA_Maker_Snippets_MigrationGuide_QueryKnowledgeBase
            QueryDTO queryDTO = new QueryDTO();
            queryDTO.Question = "{question}";

            QnASearchResultList response = await client.Runtime.GenerateAnswerAsync("{knowledgebase-id}", queryDTO);
            #endregion Snippet:CognitiveServices_QnA_Maker_Snippets_MigrationGuide_QueryKnowledgeBase

            #region Snippet:CognitiveServices_QnA_Maker_Snippets_MigrationGuide_Chat
            QueryDTO queryDTOFollowUp = new QueryDTO();
            queryDTOFollowUp.Context = new QueryDTOContext(previousQnaId: 1);

            QnASearchResultList responseFollowUp = await client.Runtime.GenerateAnswerAsync("{knowledgebase-id}", queryDTO);
            #endregion Snippet:CognitiveServices_QnA_Maker_Snippets_MigrationGuide_Chat
        }
    }
}
