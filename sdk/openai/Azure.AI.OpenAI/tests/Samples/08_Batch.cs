// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ClientModel;
using System.ClientModel.Primitives;
using System.IO;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Azure.Identity;
using OpenAI.Batch;
using OpenAI.Files;

namespace Azure.AI.OpenAI.Samples;

public partial class AzureOpenAISamples
{
    public async Task BasicBatchProcessing()
    {
        #region Snippet:BasicBatchProcessing
        AzureOpenAIClient azureClient = new(
            new Uri("https://your-azure-openai-resource.com"),
            new DefaultAzureCredential());
        
        #pragma warning disable OPENAI001 // Type is for evaluation purposes only and is subject to change or removal in future updates.
        BatchClient batchClient = azureClient.GetBatchClient();
        #pragma warning restore OPENAI001
        
        #pragma warning disable AOAI001 // Type is for evaluation purposes only and is subject to change or removal in future updates.
        OpenAIFileClient fileClient = azureClient.GetOpenAIFileClient();
        #pragma warning restore AOAI001

        // Step 1: Create batch request file in JSONL format
        var batchRequests = new StringBuilder();
        batchRequests.AppendLine("{\"custom_id\": \"request-1\", \"method\": \"POST\", \"url\": \"/v1/chat/completions\", \"body\": {\"model\": \"gpt-35-turbo\", \"messages\": [{\"role\": \"user\", \"content\": \"Summarize the benefits of renewable energy.\"}], \"max_tokens\": 100}}");
        batchRequests.AppendLine("{\"custom_id\": \"request-2\", \"method\": \"POST\", \"url\": \"/v1/chat/completions\", \"body\": {\"model\": \"gpt-35-turbo\", \"messages\": [{\"role\": \"user\", \"content\": \"Explain the water cycle in simple terms.\"}], \"max_tokens\": 100}}");
        batchRequests.AppendLine("{\"custom_id\": \"request-3\", \"method\": \"POST\", \"url\": \"/v1/chat/completions\", \"body\": {\"model\": \"gpt-35-turbo\", \"messages\": [{\"role\": \"user\", \"content\": \"What are the main causes of climate change?\"}], \"max_tokens\": 100}}");

        // Step 2: Upload the batch file
        BinaryData batchFileData = BinaryData.FromString(batchRequests.ToString());
        OpenAIFile inputFile = await fileClient.UploadFileAsync(
            batchFileData, 
            "batch_requests.jsonl", 
            FileUploadPurpose.Batch);

        Console.WriteLine($"Uploaded batch file: {inputFile.Id}");

        // Step 3: Create batch request using the low-level protocol API
        var createBatchRequestContent = BinaryContent.Create(BinaryData.FromString($@"{{
            ""input_file_id"": ""{inputFile.Id}"",
            ""endpoint"": ""/v1/chat/completions"",
            ""completion_window"": ""24h""
        }}"));

        CreateBatchOperation batch = await batchClient.CreateBatchAsync(createBatchRequestContent, waitUntilCompleted: false);
        
        Console.WriteLine($"Created batch job: {batch.BatchId}");
        Console.WriteLine("Batch processing initiated. Use the batch ID to monitor progress.");
        #endregion
    }

    public async Task BatchMonitoringExample()
    {
        #region Snippet:BatchMonitoringExample
        AzureOpenAIClient azureClient = new(
            new Uri("https://your-azure-openai-resource.com"),
            new DefaultAzureCredential());
        
        #pragma warning disable OPENAI001
        BatchClient batchClient = azureClient.GetBatchClient();
        #pragma warning restore OPENAI001

        // Assume we have a batch ID from a previous operation
        string batchId = "batch_abc123"; // Replace with actual batch ID
        
        try
        {
            // Get batch information using the low-level API
            var getBatchResponse = await batchClient.GetBatchAsync(batchId, options: null);
            var batchContent = getBatchResponse.GetRawResponse().Content.ToString();
            
            Console.WriteLine("Batch Status Information:");
            Console.WriteLine(batchContent);
            
            // The response contains JSON with status, progress, and file IDs
            // Parse this to extract specific information as needed
            
            Console.WriteLine("\nBatch monitoring workflow:");
            Console.WriteLine("1. Check batch status periodically");
            Console.WriteLine("2. Download results when completed");
            Console.WriteLine("3. Handle any errors appropriately");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error retrieving batch information: {ex.Message}");
        }
        #endregion
    }
}