﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Azure.AI.Language.QuestionAnswering.Models;
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
        private async Task Language_QnA_MigrationGuide_Runtime()
        {
            #region Snippet:Language_QnA_Maker_Snippets_MigrationGuide_CreateRuntimeClient
            var endpoint = new Uri("{endpoint}");
            var credential = new AzureKeyCredential("{api-key}");

            var client = new QuestionAnsweringClient(endpoint, credential);
            #endregion

            #region Snippet:Language_QnA_Maker_Snippets_MigrationGuide_QueryKnowledgeBase
            var response = await client.QueryKnowledgeBaseAsync(
                "{project-name}",
                "{deployment-name}",
                "{question}");
            #endregion

            #region Snippet:Language_QnA_Maker_Snippets_MigrationGuide_Chat

            var options = new QueryKnowledgeBaseOptions(
                "{project-name}",
                "{deployment-name}",
                "{question}");
            options.Context = new KnowledgeBaseAnswerRequestContext(1);

            var responseFollowUp = await client.QueryKnowledgeBaseAsync(options);

            #endregion
        }
        private async Task CognitiveServices_QnA_MigrationGuide_Runtime()
        {
            #region Snippet:CognitiveServices_QnA_Maker_Snippets_MigrationGuide_CreateRuntimeClient
            var credential = new EndpointKeyServiceClientCredentials("{api-key}");

            var client = new QnAMakerRuntimeClient(credential)
            {
                RuntimeEndpoint = "{endpoint}"
            };
            #endregion Snippet:CognitiveServices_QnA_Maker_Snippets_MigrationGuide_CreateRuntimeClient

            #region Snippet:CognitiveServices_QnA_Maker_Snippets_MigrationGuide_QueryKnowledgeBase
            var queryDTO = new QueryDTO();
            queryDTO.Question = "{question}";

            var response = await client.Runtime.GenerateAnswerAsync("{knowladgebase-id}", queryDTO);
            #endregion Snippet:CognitiveServices_QnA_Maker_Snippets_MigrationGuide_QueryKnowledgeBase

            #region Snippet:CognitiveServices_QnA_Maker_Snippets_MigrationGuide_Chat
            var queryDTOFollowUp = new QueryDTO();
            queryDTOFollowUp.Context = new QueryDTOContext(previousQnaId: 1);

            var responseFollowUp = await client.Runtime.GenerateAnswerAsync("{knowladgebase-id}", queryDTO);
            #endregion Snippet:CognitiveServices_QnA_Maker_Snippets_MigrationGuide_Chat
        }
    }
}
