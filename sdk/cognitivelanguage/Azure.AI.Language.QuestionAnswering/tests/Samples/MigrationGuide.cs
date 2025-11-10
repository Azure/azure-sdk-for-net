// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Net.Http;
using System.Threading.Tasks;
using Azure.Core;
using Microsoft.Azure.CognitiveServices.Knowledge.QnAMaker;
using Microsoft.Azure.CognitiveServices.Knowledge.QnAMaker.Models;

#pragma warning disable IDE0051 // Remove unused private members

namespace Azure.AI.Language.QuestionAnswering.Tests.Samples
{
    public partial class QuestionAnsweringClientSamples
    {
        // Authoring migration snippets removed intentionally:
        // (Create/Update/Download/Delete KB and Project operations)

        private async Task Language_QnA_MigrationGuide_Runtime()
        {
            #region Snippet:Language_QnA_Maker_Snippets_MigrationGuide_CreateRuntimeClient
            Uri endpoint = new Uri("{LanguageQnaEndpoint}");
            AzureKeyCredential credential = new AzureKeyCredential("{ApiKey}");

            Azure.AI.Language.QuestionAnswering.QuestionAnsweringClient client =
                new Azure.AI.Language.QuestionAnswering.QuestionAnsweringClient(endpoint, credential);
            #endregion

#pragma warning disable SA1509
            {
                #region Snippet:Language_QnA_Maker_Snippets_MigrationGuide_QueryKnowledgeBase
                var project = new Azure.AI.Language.QuestionAnswering.QuestionAnsweringProject("{ProjectName}", "{DeploymentName}");
                Azure.Response<Azure.AI.Language.QuestionAnswering.AnswersResult> response =
                    await client.GetAnswersAsync("{Question}", project);
                #endregion
            }

            {
                #region Snippet:Language_QnA_Maker_Snippets_MigrationGuide_Chat
                var project = new Azure.AI.Language.QuestionAnswering.QuestionAnsweringProject("{ProjectName}", "{DeploymentName}");
                var options = new Azure.AI.Language.QuestionAnswering.AnswersOptions
                {
                    AnswerContext = new Azure.AI.Language.QuestionAnswering.KnowledgeBaseAnswerContext(1)
                };

                Azure.Response<Azure.AI.Language.QuestionAnswering.AnswersResult> responseFollowUp =
                    await client.GetAnswersAsync("{Question}", project, options);
                #endregion
            }
#pragma warning restore SA1509
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
            QueryDTO queryDTO = new QueryDTO
            {
                Question = "{Question}"
            };

            QnASearchResultList response = await client.Runtime.GenerateAnswerAsync("{knowledgebase-id}", queryDTO);
            #endregion Snippet:CognitiveServices_QnA_Maker_Snippets_MigrationGuide_QueryKnowledgeBase

            #region Snippet:CognitiveServices_QnA_Maker_Snippets_MigrationGuide_Chat
            QueryDTO queryDTOFollowUp = new QueryDTO
            {
                Context = new QueryDTOContext(previousQnaId: 1),
                Question = "{Question}"
            };

            QnASearchResultList responseFollowUp = await client.Runtime.GenerateAnswerAsync("{knowledgebase-id}", queryDTOFollowUp);
            #endregion Snippet:CognitiveServices_QnA_Maker_Snippets_MigrationGuide_Chat
        }
    }
}
