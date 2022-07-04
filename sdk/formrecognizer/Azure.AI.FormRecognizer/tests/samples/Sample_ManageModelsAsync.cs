// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using Azure.AI.FormRecognizer.DocumentAnalysis.Tests;
using Azure.Core.TestFramework;

namespace Azure.AI.FormRecognizer.DocumentAnalysis.Samples
{
    public partial class DocumentAnalysisSamples : SamplesBase<DocumentAnalysisTestEnvironment>
    {
        [RecordedTest]
        public async Task ManageModelsAsync()
        {
            string endpoint = TestEnvironment.Endpoint;
            string apiKey = TestEnvironment.ApiKey;

            #region Snippet:FormRecognizerSampleManageModelsAsync

            var client = new DocumentModelAdministrationClient(new Uri(endpoint), new AzureKeyCredential(apiKey));

            // Check number of custom models in the FormRecognizer account, and the maximum number of models that can be stored.
            AccountProperties accountProperties = await client.GetAccountPropertiesAsync();
            Console.WriteLine($"Account has {accountProperties.DocumentModelCount} models.");
            Console.WriteLine($"It can have at most {accountProperties.DocumentModelLimit} models.");

            // List the first ten or fewer models currently stored in the account.
            AsyncPageable<DocumentModelSummary> models = client.GetModelsAsync();

            int count = 0;
            await foreach (DocumentModelSummary modelSummary in models)
            {
                Console.WriteLine($"Custom Model Summary:");
                Console.WriteLine($"  Model Id: {modelSummary.ModelId}");
                if (string.IsNullOrEmpty(modelSummary.Description))
                    Console.WriteLine($"  Model description: {modelSummary.Description}");
                Console.WriteLine($"  Created on: {modelSummary.CreatedOn}");
                if (++count == 10)
                    break;
            }

            // Create a new model to store in the account
#if SNIPPET
            Uri trainingFileUri = new Uri("<trainingFileUri>");
#else
            Uri trainingFileUri = new Uri(TestEnvironment.BlobContainerSasUrl);
#endif
            BuildModelOperation operation = await client.StartBuildModelAsync(trainingFileUri, DocumentBuildMode.Template);
            Response<DocumentModel> operationResponse = await operation.WaitForCompletionAsync();
            DocumentModel model = operationResponse.Value;

            // Get the model that was just created
            DocumentModel newCreatedModel = await client.GetModelAsync(model.ModelId);

            Console.WriteLine($"Custom Model with Id {newCreatedModel.ModelId} has the following information:");

            Console.WriteLine($"  Model Id: {newCreatedModel.ModelId}");
            if (string.IsNullOrEmpty(newCreatedModel.Description))
                Console.WriteLine($"  Model description: {newCreatedModel.Description}");
            Console.WriteLine($"  Created on: {newCreatedModel.CreatedOn}");

            // Delete the model from the account.
            await client.DeleteModelAsync(newCreatedModel.ModelId);

            #endregion
        }
    }
}
