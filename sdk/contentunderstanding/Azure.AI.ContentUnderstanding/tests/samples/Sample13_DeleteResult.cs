// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable enable

using System;
using System.Linq;
using System.Threading.Tasks;
using Azure;
using Azure.AI.ContentUnderstanding;
using Azure.AI.ContentUnderstanding.Tests;
using Azure.Core;
using Azure.Core.TestFramework;

namespace Azure.AI.ContentUnderstanding.Samples
{
    public partial class ContentUnderstandingSamples
    {
        [RecordedTest]
        public async Task DeleteResultAsync()
        {
            string endpoint = TestEnvironment.Endpoint;
            var options = InstrumentClientOptions(new ContentUnderstandingClientOptions());
            var client = InstrumentClient(new ContentUnderstandingClient(new Uri(endpoint), TestEnvironment.Credential, options));

            #region Snippet:ContentUnderstandingAnalyzeAndDeleteResult
#if SNIPPET
            Uri documentUrl = new Uri("<documentUrl>");
#else
            Uri documentUrl = ContentUnderstandingClientTestEnvironment.CreateUri("invoice.pdf");
#endif

            // Step 1: Start the analysis operation
            var analyzeOperation = await client.AnalyzeAsync(
                WaitUntil.Started,
                "prebuilt-invoice",
                inputs: new[] { new AnalyzeInput { Url = documentUrl } });

            // Get the operation ID from the operation (available after Started)
            string operationId = analyzeOperation.GetOperationId() ?? throw new InvalidOperationException("Could not extract operation ID from operation");
            Console.WriteLine($"Operation ID: {operationId}");

            // Wait for completion
            await analyzeOperation.WaitForCompletionAsync();
            AnalyzeResult result = analyzeOperation.Value;
            Console.WriteLine("Analysis completed successfully!");

            // Display some sample results
            if (result.Contents?.FirstOrDefault() is DocumentContent docContent && docContent.Fields != null)
            {
                Console.WriteLine($"Total fields extracted: {docContent.Fields.Count}");
                if (docContent.Fields.TryGetValue("CustomerName", out var customerNameField) && customerNameField is StringField sf)
                {
                    Console.WriteLine($"Customer Name: {sf.ValueString ?? "(not found)"}");
                }
            }

            // Step 2: Delete the analysis result
            Console.WriteLine($"Deleting analysis result (Operation ID: {operationId})...");
            await client.DeleteResultAsync(operationId);
            Console.WriteLine("Analysis result deleted successfully!");
            #endregion
        }
    }
}
