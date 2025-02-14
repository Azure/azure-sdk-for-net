// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Linq;
using System.Threading.Tasks;
using Azure.AI.FormRecognizer.Training;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.AI.FormRecognizer.Samples
{
    public partial class FormRecognizerSamples
    {
        [RecordedTest]
        [Ignore("https://github.com/Azure/azure-sdk-for-net/issues/47689")]
        public async Task ManageCustomModels()
        {
            string endpoint = TestEnvironment.Endpoint;
            string apiKey = TestEnvironment.ApiKey;

            #region Snippet:FormRecognizerSampleManageCustomModels

            FormTrainingClient client = new FormTrainingClient(new Uri(endpoint), new AzureKeyCredential(apiKey));

            // Check number of models in the FormRecognizer account, and the maximum number of models that can be stored.
            AccountProperties accountProperties = client.GetAccountProperties();
            Console.WriteLine($"Account has {accountProperties.CustomModelCount} models.");
            Console.WriteLine($"It can have at most {accountProperties.CustomModelLimit} models.");

            // List the first ten or fewer models currently stored in the account.
            Pageable<CustomFormModelInfo> models = client.GetCustomModels();

            foreach (CustomFormModelInfo modelInfo in models.Take(10))
            {
                Console.WriteLine($"Custom Model Info:");
                Console.WriteLine($"  Model Id: {modelInfo.ModelId}");
                Console.WriteLine($"  Model name: {modelInfo.ModelName}");
                Console.WriteLine($"  Is composed model: {modelInfo.Properties.IsComposedModel}");
                Console.WriteLine($"  Model Status: {modelInfo.Status}");
                Console.WriteLine($"  Training model started on: {modelInfo.TrainingStartedOn}");
                Console.WriteLine($"  Training model completed on: {modelInfo.TrainingCompletedOn}");
            }

            // Create a new model to store in the account

#if SNIPPET
            Uri trainingFileUri = new Uri("<trainingFileUri>");
#else
            Uri trainingFileUri = new Uri(TestEnvironment.BlobContainerSasUrl);
#endif
            TrainingOperation operation = client.StartTraining(trainingFileUri, useTrainingLabels: false, "My new model");
            Response<CustomFormModel> operationResponse = await operation.WaitForCompletionAsync();
            CustomFormModel model = operationResponse.Value;

            // Get the model that was just created
            CustomFormModel modelCopy = client.GetCustomModel(model.ModelId);

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
            client.DeleteModel(model.ModelId);

            #endregion
        }
    }
}
