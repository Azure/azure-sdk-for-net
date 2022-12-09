// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.IO;
using System.Threading.Tasks;
using Azure.AI.FormRecognizer.Models;
using Azure.AI.FormRecognizer.Tests;
using Azure.AI.FormRecognizer.Training;
using Azure.Core.TestFramework;

namespace Azure.AI.FormRecognizer.Samples
{
    public partial class FormRecognizerSamples
    {
        /// This sample demonstrates the differences in output that arise when BeginRecognizeCustomForms
        /// is called with custom models trained with fixed vs. dynamic table tags.
        /// For this sample, you can use the training forms found in the `trainingFiles\labeledTables\{fixed|variable}` folder.
        /// Upload the forms to your storage container and then generate a container SAS URL.

        /// For more information see https://docs.microsoft.com/azure/cognitive-services/form-recognizer/overview#custom-models

        /// Note that Form Recognizer automatically finds and extracts all tables in your documents whether the tables
        /// are tagged/labeled or not. Tables extracted automatically by Form Recognizer will be included in the
        /// `Tables` property under `RecognizedForm.Pages`.

        /// A conceptual explanation of using table tags to train your custom form model can be found in the
        /// service documentation: https://docs.microsoft.com/azure/cognitive-services/form-recognizer/supervised-table-tags

        [RecordedTest]
        public async Task OutputModelsTrainedWithFixedRowsTables()
        {
            string endpoint = TestEnvironment.Endpoint;
            string apiKey = TestEnvironment.ApiKey;
            string trainingFileUrl = TestEnvironment.TableFixedRowsContainerSasUrlV2;
            string formFilePath = FormRecognizerTestEnvironment.CreatePath("label_table_fixed_rows1.pdf");

            FormRecognizerClient client = new FormRecognizerClient(new Uri(endpoint), new AzureKeyCredential(apiKey));
            FormTrainingClient trainingClient = new FormTrainingClient(new Uri(endpoint), new AzureKeyCredential(apiKey));

            // Model trained with labeled table with fixed rows.
            CustomFormModel modelTrainedWithLabels = await trainingClient.StartTrainingAsync(new Uri(trainingFileUrl), useTrainingLabels: true).WaitForCompletionAsync();

            using (FileStream stream = new FileStream(formFilePath, FileMode.Open))
            {
                RecognizedFormCollection forms = await client.StartRecognizeCustomFormsAsync(modelTrainedWithLabels.ModelId, stream).WaitForCompletionAsync();

                Console.WriteLine("---------Recognized labeled table with fixed rows---------");
                foreach (RecognizedForm form in forms)
                {
                    foreach (FormField field in form.Fields.Values)
                    {
                        /// Substitute "table" for the label given to the table tag during training
                        /// (if different than sample training docs).
                        if (field.Name == "table")
                        {
                            if (field.Value.ValueType == FieldValueType.Dictionary)
                            {
                                var table = field.Value.AsDictionary();
                                //columns
                                foreach (var row in table.Values)
                                {
                                    Console.WriteLine($"Row {row.Name} has columns:");
                                    if (row.Value.ValueType == FieldValueType.Dictionary)
                                    {
                                        var col = row.Value.AsDictionary();
                                        foreach (var colValues in col)
                                        {
                                            Console.Write($"  Col {colValues.Key}. Value: ");
                                            if (colValues.Value != null)
                                            {
                                                var rowContent = colValues.Value;
                                                if (rowContent.Value.ValueType == FieldValueType.String)
                                                {
                                                    Console.WriteLine($"'{rowContent.Value.AsString()}'");
                                                }
                                            }
                                            else
                                            {
                                                Console.WriteLine("Empty cell");
                                            }
                                        }
                                    }
                                }
                            }
                        }
                        else
                        {
                            Console.WriteLine($"Field {field.Name}: ");
                            Console.WriteLine($"    Value: '{field.ValueData.Text}");
                            Console.WriteLine($"    Confidence: '{field.Confidence}");
                        }
                    }
                }
            }
        }

        [RecordedTest]
        public async Task OutputModelsTrainedWithDynamicRowsTables()
        {
            string endpoint = TestEnvironment.Endpoint;
            string apiKey = TestEnvironment.ApiKey;
            string trainingFileUrl = TestEnvironment.TableDynamicRowsContainerSasUrlV2;
            string formFilePath = FormRecognizerTestEnvironment.CreatePath("label_table_dynamic_rows1.pdf");

            FormRecognizerClient client = new FormRecognizerClient(new Uri(endpoint), new AzureKeyCredential(apiKey));
            FormTrainingClient trainingClient = new FormTrainingClient(new Uri(endpoint), new AzureKeyCredential(apiKey));

            // Model trained with labeled table with dynamic rows.
            CustomFormModel modelTrainedWithLabels = await trainingClient.StartTrainingAsync(new Uri(trainingFileUrl), useTrainingLabels: true).WaitForCompletionAsync();

            using (FileStream stream = new FileStream(formFilePath, FileMode.Open))
            {
                RecognizedFormCollection forms = await client.StartRecognizeCustomFormsAsync(modelTrainedWithLabels.ModelId, stream).WaitForCompletionAsync();

                Console.WriteLine("---------Recognized labeled table with dynamic rows---------");
                foreach (RecognizedForm form in forms)
                {
                    foreach (FormField field in form.Fields.Values)
                    {
                        /// Substitute "table" for the label given to the table tag during training
                        /// (if different than sample training docs).
                        if (field.Name == "table")
                        {
                            if (field.Value.ValueType == FieldValueType.List)
                            {
                                var table = field.Value.AsList();
                                //columns
                                for (int i=0; i< table.Count; i++)
                                {
                                    Console.WriteLine($"Row {i+1}:");
                                    var row = table[i].Value.AsDictionary();
                                    foreach (var colValues in row)
                                    {
                                        Console.Write($"  Col {colValues.Key}. Value: ");
                                        if (colValues.Value != null)
                                        {
                                            var rowContent = colValues.Value;
                                            if (rowContent.Value.ValueType == FieldValueType.String)
                                            {
                                                Console.WriteLine($"'{rowContent.Value.AsString()}'");
                                            }
                                        }
                                        else
                                        {
                                            Console.WriteLine("Empty cell.");
                                        }
                                    }
                                }
                            }
                        }
                        else
                        {
                            Console.WriteLine($"Field {field.Name}: ");
                            Console.WriteLine($"    Value: '{field.ValueData.Text}");
                            Console.WriteLine($"    Confidence: '{field.Confidence}");
                        }
                    }
                }
            }
        }
    }
}
