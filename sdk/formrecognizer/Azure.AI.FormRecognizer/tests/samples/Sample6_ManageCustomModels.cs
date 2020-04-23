// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Linq;
using System.Threading.Tasks;
using Azure.AI.FormRecognizer.Tests;
using Azure.AI.FormRecognizer.Training;
using Azure.Core.Testing;
using NUnit.Framework;

namespace Azure.AI.FormRecognizer.Samples
{
    public partial class FormRecognizerSamples : SamplesBase<FormRecognizerTestEnvironment>
    {
        [Test]
        public async Task ManageCustomModels()
        {
            string endpoint = TestEnvironment.Endpoint;
            string apiKey = TestEnvironment.ApiKey;
            string trainingFileUrl = TestEnvironment.BlobContainerSasUrl;

            #region Snippet:FormRecognizerSample6ManageCustomModels

            FormTrainingClient client = new FormTrainingClient(new Uri(endpoint), new AzureKeyCredential(apiKey));

            // Check number of models in the FormRecognizer account, and the maximum number of models that can be stored.
            AccountProperties accountProperties = client.GetAccountProperties();
            Console.WriteLine($"Account has {accountProperties.CustomModelCount} models.");
            Console.WriteLine($"It can have at most {accountProperties.CustomModelLimit} models.");

            // List the first ten or fewer models currently stored in the account.
            Pageable<CustomFormModelInfo> models = client.GetModelInfos();

            foreach (CustomFormModelInfo modelInfo in models.Take(10))
            {
                Console.WriteLine($"Custom Model Info:");
                Console.WriteLine($"    Model Id: {modelInfo.ModelId}");
                Console.WriteLine($"    Model Status: {modelInfo.Status}");
                Console.WriteLine($"    Created On: {modelInfo.CreatedOn}");
                Console.WriteLine($"    Last Modified: {modelInfo.LastModified}");
            }

            // Create a new model to store in the account
            CustomFormModel model = await client.StartTrainingAsync(new Uri(trainingFileUrl)).WaitForCompletionAsync();

            // Get the model that was just created
            CustomFormModel modelCopy = client.GetCustomModel(model.ModelId);

            Console.WriteLine($"Custom Model {modelCopy.ModelId} recognizes the following form types:");

            foreach (CustomFormSubModel subModel in modelCopy.Models)
            {
                Console.WriteLine($"SubModel Form Type: {subModel.FormType}");
                foreach (CustomFormModelField field in subModel.Fields.Values)
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
            client.DeleteModel(model.ModelId);

            #endregion
        }
    }
}
