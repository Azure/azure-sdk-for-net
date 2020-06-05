// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Linq;
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
            string trainingFileUrl = TestEnvironment.BlobContainerSasUrl;

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
                Console.WriteLine($"    Model Id: {modelInfo.ModelId}");
                Console.WriteLine($"    Model Status: {modelInfo.Status}");
                Console.WriteLine($"    Requested on: {modelInfo.RequestedOn}");
                Console.WriteLine($"    Completed on: : {modelInfo.CompletedOn}");
            }

            // Create a new model to store in the account
            CustomFormModel model = await client.StartTrainingAsync(new Uri(trainingFileUrl), useTrainingLabels: false).WaitForCompletionAsync();

            // Get the model that was just created
            CustomFormModel modelCopy = await client.GetCustomModelAsync(model.ModelId);

            Console.WriteLine($"Custom Model {modelCopy.ModelId} recognizes the following form types:");

            foreach (CustomFormSubmodel submodel in modelCopy.Submodels)
            {
                Console.WriteLine($"Submodel Form Type: {submodel.FormType}");
                foreach (CustomFormModelField field in submodel.Fields.Values)
                {
                    Console.Write($"    FieldName: {field.Name}");
                    if (field.Label != null)
                    {
                        Console.Write($", FieldLabel: {field.Label}");
                    }
                    Console.WriteLine("");
                }
            }

            // Delete the model from the account.
            await client.DeleteModelAsync(model.ModelId);
        }
    }
}
