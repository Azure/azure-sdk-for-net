// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
#region Snippet:QuestionAnsweringAuthoringClient_Namespace
using Azure.AI.Language.QuestionAnswering.Authoring;
#endregion
using Azure.Core.TestFramework;

namespace Azure.AI.Language.QuestionAnswering.Authoring.Tests.Samples
{
    public partial class QuestionAnsweringAuthoringClientSamples : QuestionAnsweringAuthoringTestBase<QuestionAnsweringAuthoringClient>
    {
        public void CreateQuestionAnsweringAuthoringClient()
        {
            #region Snippet:QuestionAnsweringAuthoringClient_Create
            Uri endpoint = new Uri("https://myaccount.cognitiveservices.azure.com/");
            AzureKeyCredential credential = new AzureKeyCredential("{api-key}");

            QuestionAnsweringAuthoringClient client = new QuestionAnsweringAuthoringClient(endpoint, credential);
            #endregion
        }
    }
}
