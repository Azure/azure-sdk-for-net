// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Azure.AI.Language.QuestionAnswering.Authoring;
using Azure.Core;
using Microsoft.Azure.CognitiveServices.Knowledge.QnAMaker;
using Microsoft.Azure.CognitiveServices.Knowledge.QnAMaker.Models;

#pragma warning disable IDE0051 // Remove unused private members

namespace Azure.AI.Language.QuestionAnswering.Tests.Samples
{
    public partial class QuestionAnsweringClientSamples
    {
        private async Task CognitiveServices_QnA_MigrationGuide_Authoring()
        {
            #region Snippet:CognitiveServices_QnA_Maker_Snippets_MigrationGuide_CreateClient
            QnAMakerClient client = new QnAMakerClient(new ApiKeyServiceClientCredentials("{QnAMakerSubscriptionKey}"), new HttpClient(), false)
            {
                Endpoint = "{QnaMakerEndpoint}"
            };
            #endregion Snippet:CognitiveServices_QnA_Maker_Snippets_MigrationGuide_CreateClient

            #region Snippet:CognitiveServices_QnA_Maker_Snippets_MigrationGuide_CreateKnowledgeBase
            Microsoft.Azure.CognitiveServices.Knowledge.QnAMaker.Models.Operation createOp = await client.Knowledgebase.CreateAsync(new CreateKbDTO
            {
                Name = "{KnowledgeBaseName}", QnaList = new List<QnADTO>
                {
                    new QnADTO
                    {
                        Questions = new List<string>
                        {
                            "{Question}"
                        },
                        Answer = "{Answer}"
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
                                    "{Question}"
                                },
                                Answer = "{Answer}"
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
            Uri endpoint = new Uri("{LanguageQnaEndpoint}");
            AzureKeyCredential credential = new AzureKeyCredential("{ApiKey}");

            QuestionAnsweringAuthoringClient client = new QuestionAnsweringAuthoringClient(endpoint, credential);
            #endregion Snippet:Language_QnA_Maker_Snippets_MigrationGuide_CreateClient

            #region Snippet:Language_QnA_Maker_Snippets_MigrationGuide_CreateProject
            string newProjectName = "{ProjectName}";
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

            Operation<AsyncPageable<BinaryData>> updateSourcesOperation = await client.UpdateSourcesAsync(WaitUntil.Completed, "{ProjectName}", updateSourcesRequestContent);
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

            Operation<AsyncPageable<BinaryData>> updateQnasOperation = await client.UpdateQnasAsync(WaitUntil.Completed, "{ProjectName}", updateQnasRequestContent);
            #endregion Snippet:Language_QnA_Maker_Snippets_MigrationGuide_UpdateQnas

            #region Snippet:Language_QnA_Maker_Snippets_MigrationGuide_ExportProject
            Operation<BinaryData> exportOperation = client.Export(WaitUntil.Completed, "{ProjectName}", "{ExportFormat}");
            #endregion Snippet:Language_QnA_Maker_Snippets_MigrationGuide_ExportProject

            #region Snippet:Language_QnA_Maker_Snippets_MigrationGuide_DeleteProject
            Operation deletionOperation = await client.DeleteProjectAsync(WaitUntil.Completed, "{ProjectName}");
            #endregion Snippet:Language_QnA_Maker_Snippets_MigrationGuide_DeleteProject
        }

        private async Task Language_QnA_MigrationGuide_Runtime()
        {
            #region Snippet:Language_QnA_Maker_Snippets_MigrationGuide_CreateRuntimeClient
            Uri endpoint = new Uri("{LanguageQnaEndpoint}");
            AzureKeyCredential credential = new AzureKeyCredential("{ApiKey}");

            QuestionAnsweringClient client = new QuestionAnsweringClient(endpoint, credential);
            #endregion

#pragma warning disable SA1509 // Opening braces should not be preceded by blank line
            {
                #region Snippet:Language_QnA_Maker_Snippets_MigrationGuide_QueryKnowledgeBase
                QuestionAnsweringProject project = new QuestionAnsweringProject("{ProjectName}", "{DeploymentName}");
                Response<AnswersResult> response = await client.GetAnswersAsync("{Question}", project);
                #endregion
            }

            {
                #region Snippet:Language_QnA_Maker_Snippets_MigrationGuide_Chat
                QuestionAnsweringProject project = new QuestionAnsweringProject("{ProjectName}", "{DeploymentName}");
                AnswersOptions options = new AnswersOptions
                {
                    AnswerContext = new KnowledgeBaseAnswerContext(1)
                };

                Response<AnswersResult> responseFollowUp = await client.GetAnswersAsync("{Question}", project, options);
                #endregion
            }
#pragma warning restore SA1509 // Opening braces should not be preceded by blank line
        }

        private async Task CognitiveServices_QnA_MigrationGuide_Runtime()
        {
            #region Snippet:CognitiveServices_QnA_Maker_Snippets_MigrationGuide_CreateRuntimeClient
            EndpointKeyServiceClientCredentials credential = new EndpointKeyServiceClientCredentials("{ApiKey}");

            QnAMakerRuntimeClient client = new QnAMakerRuntimeClient(credential)
            {
                RuntimeEndpoint = "{QnaMakerEndpoint}"
            };
            #endregion Snippet:CognitiveServices_QnA_Maker_Snippets_MigrationGuide_CreateRuntimeClient

            #region Snippet:CognitiveServices_QnA_Maker_Snippets_MigrationGuide_QueryKnowledgeBase
            QueryDTO queryDTO = new QueryDTO();
            queryDTO.Question = "{Question}";

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
