// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.IO;
using System.Threading.Tasks;
using Azure.AI.FormRecognizer.Models;
using Azure.AI.FormRecognizer.Tests;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.AI.FormRecognizer.Samples
{
    public partial class FormRecognizerSamples : SamplesBase<FormRecognizerTestEnvironment>
    {
        /// <summary>
        /// This sample illustrates how to consume a FieldBoundingBox type data that is available across the Form Recognizer library.
        /// A bounding box is a sequence of four <see cref="PointF"/> representing a quadrilateral that outlines
        /// an element such as a line or a word in a recognized form.
        /// Coordinates are specified relative to the top-left of the original image,
        /// and points are ordered clockwise from the top-left corner relative to the text orientation.
        /// Units type of a recognized page can be found at <see cref="FormPage.Unit"/>.
        /// For the purpose of the sample, we will use the StartRecognizeContent capability.
        /// </summary>
        [Test]
        public async Task FieldBoundingBoxSample()
        {
            string endpoint = TestEnvironment.Endpoint;
            string apiKey = TestEnvironment.ApiKey;

            FormRecognizerClient client = new FormRecognizerClient(new Uri(endpoint), new AzureKeyCredential(apiKey));

            string invoiceFilePath = FormRecognizerTestEnvironment.CreatePath("Invoice_1.pdf");

            using (FileStream stream = new FileStream(invoiceFilePath, FileMode.Open))
            {
                FormPageCollection formPages = await client.StartRecognizeContentAsync(stream).WaitForCompletionAsync();
                foreach (FormPage page in formPages)
                {
                    Console.WriteLine($"Form Page {page.PageNumber} has {page.Lines.Count} lines.");

                    for (int i = 0; i < page.Lines.Count; i++)
                    {
                        FormLine line = page.Lines[i];
                        Console.WriteLine($"    Line {i} with text: '{line.Text}'.");

                        Console.WriteLine("        Its bounding box is:");
                        Console.WriteLine($"        Upper left => X: {line.BoundingBox[0].X}, Y= {line.BoundingBox[0].Y}");
                        Console.WriteLine($"        Upper right => X: {line.BoundingBox[1].X}, Y= {line.BoundingBox[1].Y}");
                        Console.WriteLine($"        Lower right => X: {line.BoundingBox[2].X}, Y= {line.BoundingBox[2].Y}");
                        Console.WriteLine($"        Lower left => X: {line.BoundingBox[3].X}, Y= {line.BoundingBox[3].Y}");
                    }
                }
            }
        }
    }
}
