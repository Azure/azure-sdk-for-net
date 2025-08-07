// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
#region Snippet:TextAnalysisClient_Namespace
using Azure.AI.Language.Text;
#endregion
using Azure.AI.Language.Text.Tests;
using Azure.Core.TestFramework;
using NUnit.Framework;
#region Snippet:Text_Identity_Namespace
using Azure.Identity;
#endregion

namespace Azure.AI.Language.TextAnalytics.Tests.Samples
{
    public partial class CreateClient : SamplesBase<TextAnalysisClientTestEnvironment>
    {
        [Test]
        public void CreateTextAnalysisClientForSpecificApiVersion()
        {
            #region Snippet:CreateTextAnalysisClientForSpecificApiVersion
            Uri endpoint = new Uri("{endpoint}");
            AzureKeyCredential credential = new AzureKeyCredential("{api-key}");
#if !SNIPPET
            endpoint = TestEnvironment.Endpoint;
            credential = new(TestEnvironment.ApiKey);
#endif
            TextAnalysisClientOptions options = new TextAnalysisClientOptions(TextAnalysisClientOptions.ServiceVersion.V2023_04_01);
            var client = new TextAnalysisClient(endpoint, credential, options);
            #endregion
        }

        [Test]
        public void CreateTextClient()
        {
            #region Snippet:CreateTextClient
            Uri endpoint = new Uri("{endpoint}");
            AzureKeyCredential credential = new AzureKeyCredential("{api-key}");
#if !SNIPPET
            endpoint = TestEnvironment.Endpoint;
            credential = new(TestEnvironment.ApiKey);
#endif
            TextAnalysisClient client = new TextAnalysisClient(endpoint, credential);
            #endregion
        }

        [Test]
        public void TextAnalysisClient_CreateWithDefaultAzureCredential()
        {
            #region Snippet:TextAnalysisClient_CreateWithDefaultAzureCredential
            Uri endpoint = new Uri("{endpoint}");
#if !SNIPPET
            endpoint = TestEnvironment.Endpoint;
#endif
            DefaultAzureCredential credential = new DefaultAzureCredential();
            TextAnalysisClient client = new TextAnalysisClient(endpoint, credential);
            #endregion
        }

        [Test]
        public void BadArgument()
        {
            Uri endpoint = TestEnvironment.Endpoint;
            AzureKeyCredential credential = new(TestEnvironment.ApiKey);
            TextAnalysisClient client = new TextAnalysisClient(endpoint, credential);

            #region Snippet:TextAnalysisClient_BadRequest
            try
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
                            new MultiLanguageInput("D", textA),
                        }
                    },
                    ActionContent = new EntitiesActionContent()
                    {
                        ModelVersion = "NotValid", // Invalid model version will is a bad request.
                    }
                };

                Response<AnalyzeTextResult> response = client.AnalyzeText(body);
            }
            catch (RequestFailedException ex)
            {
                Console.WriteLine(ex.ToString());
            }
            #endregion
        }
    }
}
