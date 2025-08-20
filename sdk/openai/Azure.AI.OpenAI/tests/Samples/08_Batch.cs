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

    public void BatchBestPractices()
    {
        #region Snippet:BatchBestPractices
        // Best practices for batch processing with Azure OpenAI
        
        Console.WriteLine("Azure OpenAI Batch Processing Best Practices:");
        Console.WriteLine();
        
        Console.WriteLine("1. File Preparation:");
        Console.WriteLine("   - Use JSONL format (one JSON object per line)");
        Console.WriteLine("   - Include unique custom_id for each request");
        Console.WriteLine("   - Validate JSON structure before upload");
        Console.WriteLine("   - Keep file size under limits (typically 100MB)");
        Console.WriteLine();
        
        Console.WriteLine("2. Request Structure:");
        Console.WriteLine("   - Use consistent model names across requests");
        Console.WriteLine("   - Set appropriate max_tokens for responses");
        Console.WriteLine("   - Consider rate limits and quotas");
        Console.WriteLine();
        
        Console.WriteLine("3. Monitoring and Management:");
        Console.WriteLine("   - Poll batch status every 30-60 seconds");
        Console.WriteLine("   - Handle different completion states (success, error, cancelled)");
        Console.WriteLine("   - Download and process results promptly");
        Console.WriteLine("   - Clean up input and output files when done");
        Console.WriteLine();
        
        Console.WriteLine("4. Error Handling:");
        Console.WriteLine("   - Check for individual request failures in results");
        Console.WriteLine("   - Implement retry logic for transient errors");
        Console.WriteLine("   - Log batch IDs for troubleshooting");
        Console.WriteLine();
        
        Console.WriteLine("5. Cost Optimization:");
        Console.WriteLine("   - Batch similar requests together");
        Console.WriteLine("   - Use appropriate completion windows");
        Console.WriteLine("   - Monitor usage and costs regularly");
        
        // Example JSONL structure for reference
        string exampleJsonl = @"
{""custom_id"": ""req_001"", ""method"": ""POST"", ""url"": ""/v1/chat/completions"", ""body"": {""model"": ""gpt-35-turbo"", ""messages"": [{""role"": ""user"", ""content"": ""Hello""}]}}
{""custom_id"": ""req_002"", ""method"": ""POST"", ""url"": ""/v1/chat/completions"", ""body"": {""model"": ""gpt-35-turbo"", ""messages"": [{""role"": ""user"", ""content"": ""Goodbye""}]}}
        ".Trim();
        
        Console.WriteLine("\nExample JSONL format:");
        Console.WriteLine(exampleJsonl);
        #endregion
    }
}