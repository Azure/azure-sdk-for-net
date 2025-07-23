// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure;
using Azure.AI.Language.Text.Authoring;
using Azure.AI.Language.Text.Authoring.Tests;
using Azure.Core;
using Azure.Core.TestFramework;
using NUnit.Framework;
using System.Threading.Tasks;

namespace Azure.AI.Language.Text.Authoring.Tests.Samples
{
    public partial class Sample9_TextAuthoring_GetModelEvaluationResults : SamplesBase<AuthoringClientTestEnvironment>
    {
        [Test]
        [SyncOnly]
        public void GetModelEvaluationResults()
        {
            Uri endpoint = TestEnvironment.Endpoint;
            AzureKeyCredential credential = new(TestEnvironment.ApiKey);
            TextAnalysisAuthoringClient client = new TextAnalysisAuthoringClient(endpoint, credential);

            #region Snippet:Sample9_TextAuthoring_GetModelEvaluationResults
            string projectName = "{projectName}";
            string trainedModelLabel = "{modelLabel}";
            StringIndexType stringIndexType = StringIndexType.Utf16CodeUnit;

            TextAuthoringTrainedModel trainedModelClient = client.GetTrainedModel(projectName, trainedModelLabel);

            Pageable<TextAuthoringDocumentEvalResult> results = trainedModelClient.GetModelEvaluationResults(
                stringIndexType: stringIndexType
            );

            foreach (TextAuthoringDocumentEvalResult result in results)
            {
                Console.WriteLine($"Document Location: {result.Location}");
                Console.WriteLine($"Language: {result.Language}");

                // Example: handle single-label classification results
                if (result is CustomSingleLabelClassificationDocumentEvalResult singleLabelResult)
                {
                    var classification = singleLabelResult.CustomSingleLabelClassificationResult;
                    Console.WriteLine($"Expected Class: {classification.ExpectedClass}");
                    Console.WriteLine($"Predicted Class: {classification.PredictedClass}");
                }
                // Add handling for other result types as needed
            }
            #endregion
        }

        [Test]
        [AsyncOnly]
        public async Task GetModelEvaluationResultsAsync()
        {
            Uri endpoint = TestEnvironment.Endpoint;
            AzureKeyCredential credential = new(TestEnvironment.ApiKey);
            TextAnalysisAuthoringClient client = new TextAnalysisAuthoringClient(endpoint, credential);

            #region Snippet:Sample9_TextAuthoring_GetModelEvaluationResultsAsync
            string projectName = "{projectName}";
            string trainedModelLabel = "{modelLabel}";
            StringIndexType stringIndexType = StringIndexType.Utf16CodeUnit;

            TextAuthoringTrainedModel trainedModelClient = client.GetTrainedModel(projectName, trainedModelLabel);

            AsyncPageable<TextAuthoringDocumentEvalResult> results = trainedModelClient.GetModelEvaluationResultsAsync(
                stringIndexType: stringIndexType
            );

            await foreach (TextAuthoringDocumentEvalResult result in results)
            {
                Console.WriteLine($"Document Location: {result.Location}");
                Console.WriteLine($"Language: {result.Language}");

                // Example: handle single-label classification results
                if (result is CustomSingleLabelClassificationDocumentEvalResult singleLabelResult)
                {
                    var classification = singleLabelResult.CustomSingleLabelClassificationResult;
                    Console.WriteLine($"Expected Class: {classification.ExpectedClass}");
                    Console.WriteLine($"Predicted Class: {classification.PredictedClass}");
                }
                // Add handling for other result types as needed
            }
            #endregion
        }
    }
}
