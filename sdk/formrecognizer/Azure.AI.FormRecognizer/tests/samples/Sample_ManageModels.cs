// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Linq;
using System.Threading.Tasks;
using Azure.AI.FormRecognizer.DocumentAnalysis.Tests;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.AI.FormRecognizer.DocumentAnalysis.Samples
{
    public partial class DocumentAnalysisSamples : SamplesBase<DocumentAnalysisTestEnvironment>
    {
        [Test]
        public async Task ManageModels()
        {
            string endpoint = TestEnvironment.Endpoint;
            string apiKey = TestEnvironment.ApiKey;

            #region Snippet:FormRecognizerSampleManageModels

            var client = new DocumentModelAdministrationClient(new Uri(endpoint), new AzureKeyCredential(apiKey));

            // Check number of custom models in the FormRecognizer account, and the maximum number of models that can be stored.
            AccountProperties accountProperties = client.GetAccountProperties();
            Console.WriteLine($"Account has {accountProperties.Count} models.");
            Console.WriteLine($"It can have at most {accountProperties.Limit} models.");

            // List the first ten or fewer models currently stored in the account.
            Pageable<DocumentModelInfo> models = client.GetModels();

            foreach (DocumentModelInfo modelInfo in models.Take(10))
            {
                Console.WriteLine($"Custom Model Info:");
                Console.WriteLine($"  Model Id: {modelInfo.ModelId}");
                if (string.IsNullOrEmpty(modelInfo.Description))
                    Console.WriteLine($"  Model description: {modelInfo.Description}");
                Console.WriteLine($"  Created on: {modelInfo.CreatedOn}");
            }

            // Create a new model to store in the account

#if SNIPPET
            Uri trainingFileUri = <trainingFileUri>;
#else
            Uri trainingFileUri = new Uri(TestEnvironment.BlobContainerSasUrl);
#endif
            BuildModelOperation operation = client.StartBuildModel(trainingFileUri, DocumentBuildMode.Template);
            Response<DocumentModel> operationResponse = await operation.WaitForCompletionAsync();
            DocumentModel model = operationResponse.Value;

            // Get the model that was just created
            DocumentModel newCreatedModel = client.GetModel(model.ModelId);

            Console.WriteLine($"Custom Model with Id {newCreatedModel.ModelId} has the following information:");

            Console.WriteLine($"  Model Id: {newCreatedModel.ModelId}");
            if (string.IsNullOrEmpty(newCreatedModel.Description))
                Console.WriteLine($"  Model description: {newCreatedModel.Description}");
            Console.WriteLine($"  Created on: {newCreatedModel.CreatedOn}");

            // Delete the created model from the account.
            client.DeleteModel(newCreatedModel.ModelId);

            #endregion
        }
    }
}
