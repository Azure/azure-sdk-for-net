﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Azure.AI.FormRecognizer.Models;
using Azure.AI.FormRecognizer.Tests;
using Azure.Core.Testing;
using NUnit.Framework;

namespace Azure.AI.FormRecognizer.Samples
{
    public partial class FormRecognizerSamples : SamplesBase<FormRecognizerTestEnvironment>
    {
        [Test]
        public async Task RecognizeCustomForms()
        {
            string endpoint = TestEnvironment.Endpoint;
            string apiKey = TestEnvironment.ApiKey;

            FormRecognizerClient client = new FormRecognizerClient(new Uri(endpoint), new AzureKeyCredential(apiKey));

            string invoiceUri = FormRecognizerTestEnvironment.CreateUri("Invoice_1.pdf");
            string modelId = "<your model id>";

            #region Snippet:FormRecognizerSample4RecognizeCustomForms

            Response<IReadOnlyList<RecognizedForm>> forms = await client.StartRecognizeCustomFormsFromUri(modelId, new Uri(invoiceUri)).WaitForCompletionAsync();
            foreach (RecognizedForm form in forms.Value)
            {
                Console.WriteLine($"Form of type: {form.FormType}");
                foreach (FormField field in form.Fields.Values)
                {
                    Console.WriteLine($"Field '{field.Name}: ");

                    if (field.LabelText != null)
                    {
                        Console.WriteLine($"    Label: '{field.LabelText.Text}");
                    }

                    Console.WriteLine($"    Value: '{field.ValueText.Text}");
                    Console.WriteLine($"    Confidence: '{field.Confidence}");
                }
            }
            #endregion
        }
    }
}
