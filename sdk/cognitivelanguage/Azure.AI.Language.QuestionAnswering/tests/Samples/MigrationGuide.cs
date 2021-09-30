// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.Azure.CognitiveServices.Knowledge.QnAMaker;
using Microsoft.Azure.CognitiveServices.Knowledge.QnAMaker.Models;
using NUnit.Framework;

namespace Azure.AI.Language.QuestionAnswering.Tests.Samples
{
    public partial class QuestionAnsweringClientSamples
    {
        /* uncomment when we have authoring
        [Ignore("Used only for the migration guide")]
        private async Task MigrationGuide_Authoring()
        {
            #region Snippet:CognitiveServices_QnA_Maker_Snippets_MigrationGuide_CreateClient
            IQnAMakerClient client = new QnAMakerClient(new ApiKeyServiceClientCredentials("<QnAMakerSubscriptionKey>"), new HttpClient(), false)
            {
                Endpoint = "https://westus.api.cognitive.microsoft.com"
            };
            #endregion Snippet:CognitiveServices_QnA_Maker_Snippets_MigrationGuide_CreateClient

            #region Snippet:CognitiveServices_QnA_Maker_Snippets_MigrationGuide_CreateKnowledgeBase
            var createOp = await client.Knowledgebase.CreateAsync(new CreateKbDTO
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

            #region Snippet:CognitiveServices_QnA_Maker_Snippets_MigrationGuide_UpdateKnowledeBase
            var updateOp = await client.Knowledgebase.UpdateAsync("<KnowledgeBaseID>",
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
            #endregion Snippet:CognitiveServices_QnA_Maker_Snippets_MigrationGuide_UpdateKnowledeBase

            #region Snippet:CognitiveServices_QnA_Maker_Snippets_MigrationGuide_DownloadKnowledeBase
            var kbdata = await client.Knowledgebase.DownloadAsync("<KnowledgeBaseID>", EnvironmentType.Test);
            #endregion Snippet:CognitiveServices_QnA_Maker_Snippets_MigrationGuide_UpdateKnowledeBase

            #region Snippet:CognitiveServices_QnA_Maker_Snippets_MigrationGuide_DeleteKnowledeBase
            await client.Knowledgebase.DeleteAsync("<KnowledgeBaseID>");
            #endregion Snippet:CognitiveServices_QnA_Maker_Snippets_MigrationGuide_DeleteKnowledeBase

        }*/

        private async Task MigrationGuide_Runtime()
        {
            #region Snippet:CognitiveServices_QnA_Maker_Snippets_MigrationGuide_CreateRuntimeClient
            IQnAMakerRuntimeClient client = new QnAMakerRuntimeClient(new EndpointKeyServiceClientCredentials("<QnAMakerEndpointKey>"), new HttpClient(), false)
            {
                RuntimeEndpoint = "https://sk4cs.azurewebsites.net"
            };
            #endregion Snippet:CognitiveServices_QnA_Maker_Snippets_MigrationGuide_CreateRuntimeClient

            #region Snippet:CognitiveServices_QnA_Maker_Snippets_MigrationGuide_QueryKnowledgeBase
            QueryDTO queryDTO = new QueryDTO();
            queryDTO.Question = "hello";
            var answer = await client.Runtime.GenerateAnswerAsync("<KnowledgeBaseID>", queryDTO);
            #endregion Snippet:CognitiveServices_QnA_Maker_Snippets_MigrationGuide_QueryKnowledgeBase

            #region Snippet:CognitiveServices_QnA_Maker_Snippets_MigrationGuide_Chat
            QueryDTO queryDTOFollowUp = new QueryDTO();
            queryDTOFollowUp.Context = new QueryDTOContext(previousQnaId: "<previousQnaId>");
            var answerFollowUp = await client.Runtime.GenerateAnswerAsync("<KnowledgeBaseID>", queryDTO);
            #endregion Snippet:CognitiveServices_QnA_Maker_Snippets_MigrationGuide_Chat

        }
    }
}
