// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using Azure.AI.FormRecognizer.Tests;
using Azure.AI.FormRecognizer.Training;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.AI.FormRecognizer.Samples
{
    public partial class FormRecognizerSamples : SamplesBase<FormRecognizerTestEnvironment>
    {
        [Test]
        public async Task ManageCustomModelsAsync()
        {
            string endpoint = TestEnvironment.Endpoint;
            string apiKey = TestEnvironment.ApiKey;
            Uri trainingFileUri = new Uri(TestEnvironment.BlobContainerSasUrl);

            #region Snippet:FormRecognizerSampleManageCustomModelsAsync

            FormTrainingClient client = new FormTrainingClient(new Uri(endpoint), new AzureKeyCredential(apiKey));

            // Check number of models in the FormRecognizer account, and the maximum number of models that can be stored.
            AccountProperties accountProperties = await client.GetAccountPropertiesAsync();
            Console.WriteLine($"Account has {accountProperties.CustomModelCount} models.");
            Console.WriteLine($"It can have at most {accountProperties.CustomModelLimit} models.");

            // List the models currently stored in the account.
            AsyncPageable<CustomFormModelInfo> models = client.GetCustomModelsAsync();

            await foreach (CustomFormModelInfo modelInfo in models)
            {
                Console.WriteLine($"Custom Model Info:");
                Console.WriteLine($"  Model Id: {modelInfo.ModelId}");
                Console.WriteLine($"  Model name: {modelInfo.ModelName}");
                Console.WriteLine($"  Is composed model: {modelInfo.Properties.IsComposedModel}");
                Console.WriteLine($"  Model Status: {modelInfo.Status}");
                Console.WriteLine($"  Training model started on: {modelInfo.TrainingStartedOn}");
                Console.WriteLine($"  Training model completed on: : {modelInfo.TrainingCompletedOn}");
            }

            // Create a new model to store in the account
            //@@ Uri trainingFileUri = <trainingFileUri>;
            TrainingOperation operation = await client.StartTrainingAsync(trainingFileUri, useTrainingLabels: false, "My new model");
            Response<CustomFormModel> operationResponse = await operation.WaitForCompletionAsync();
            CustomFormModel model = operationResponse.Value;

            // Get the model that was just created
            CustomFormModel modelCopy = await client.GetCustomModelAsync(model.ModelId);

            Console.WriteLine($"Custom Model with Id {modelCopy.ModelId}  and name {modelCopy.ModelName} recognizes the following form types:");

            foreach (CustomFormSubmodel submodel in modelCopy.Submodels)
            {
                Console.WriteLine($"Submodel Form Type: {submodel.FormType}");
                foreach (CustomFormModelField field in submodel.Fields.Values)
                {
                    Console.Write($"  FieldName: {field.Name}");
                    if (field.Label != null)
                    {
                        Console.Write($", FieldLabel: {field.Label}");
                    }
                    Console.WriteLine("");
                }
            }

            // Delete the model from the account.
            await client.DeleteModelAsync(model.ModelId);

            #endregion
        }
    }
}
