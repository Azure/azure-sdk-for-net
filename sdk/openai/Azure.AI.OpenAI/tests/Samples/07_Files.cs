// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Azure.Identity;
using OpenAI.Files;

namespace Azure.AI.OpenAI.Samples;

public partial class AzureOpenAISamples
{
    public void BasicFileUpload()
    {
        #region Snippet:BasicFileUpload
        AzureOpenAIClient azureClient = new(
            new Uri("https://your-azure-openai-resource.com"),
            new DefaultAzureCredential());
        
        #pragma warning disable AOAI001 // Type is for evaluation purposes only and is subject to change or removal in future updates.
        OpenAIFileClient fileClient = azureClient.GetOpenAIFileClient();
        #pragma warning restore AOAI001

        // Create sample data for upload
        string fileContent = "Sample data for processing:\n" +
                           "Question: What is machine learning?\n" +
                           "Answer: Machine learning is a method of data analysis that automates analytical model building.\n" +
                           "Question: What is AI?\n" +
                           "Answer: AI is intelligence demonstrated by machines.";
        
        BinaryData data = BinaryData.FromString(fileContent);
        
        // Upload file for use with assistants
        OpenAIFile uploadedFile = fileClient.UploadFile(
            data, 
            "sample_qa_data.txt", 
            FileUploadPurpose.Assistants);
        
        Console.WriteLine($"File uploaded successfully:");
        Console.WriteLine($"  ID: {uploadedFile.Id}");
        Console.WriteLine($"  Filename: {uploadedFile.Filename}");
        Console.WriteLine($"  Size: {uploadedFile.SizeInBytes} bytes");
        Console.WriteLine($"  Purpose: {uploadedFile.Purpose}");
        #endregion
    }

    public void FileUploadForBatch()
    {
        AzureOpenAIClient azureClient = new(
            new Uri("https://your-azure-openai-resource.com"),
            new DefaultAzureCredential());
        
        #pragma warning disable AOAI001
        OpenAIFileClient fileClient = azureClient.GetOpenAIFileClient();
        #pragma warning restore AOAI001

        #region Snippet:FileUploadForBatch
        // Create JSONL content for batch processing
        var batchRequests = new StringBuilder();
        batchRequests.AppendLine("{\"custom_id\": \"request-1\", \"method\": \"POST\", \"url\": \"/v1/chat/completions\", \"body\": {\"model\": \"gpt-35-turbo\", \"messages\": [{\"role\": \"user\", \"content\": \"What is the capital of France?\"}]}}");
        batchRequests.AppendLine("{\"custom_id\": \"request-2\", \"method\": \"POST\", \"url\": \"/v1/chat/completions\", \"body\": {\"model\": \"gpt-35-turbo\", \"messages\": [{\"role\": \"user\", \"content\": \"What is the largest planet in our solar system?\"}]}}");
        batchRequests.AppendLine("{\"custom_id\": \"request-3\", \"method\": \"POST\", \"url\": \"/v1/chat/completions\", \"body\": {\"model\": \"gpt-35-turbo\", \"messages\": [{\"role\": \"user\", \"content\": \"Explain photosynthesis in one sentence.\"}]}}");

        BinaryData batchData = BinaryData.FromString(batchRequests.ToString());
        
        // Upload file for batch processing
        OpenAIFile batchFile = fileClient.UploadFile(
            batchData, 
            "batch_requests.jsonl", 
            FileUploadPurpose.Batch);
        
        Console.WriteLine($"Batch file uploaded:");
        Console.WriteLine($"  ID: {batchFile.Id}");
        Console.WriteLine($"  Filename: {batchFile.Filename}");
        Console.WriteLine($"  Purpose: {batchFile.Purpose}");
        #endregion
    }

    public void FileManagement()
    {
        AzureOpenAIClient azureClient = new(
            new Uri("https://your-azure-openai-resource.com"),
            new DefaultAzureCredential());
        
        #pragma warning disable AOAI001
        OpenAIFileClient fileClient = azureClient.GetOpenAIFileClient();
        #pragma warning restore AOAI001

        #region Snippet:FileManagement
        // List all uploaded files
        Console.WriteLine("Listing all uploaded files:");
        OpenAIFileCollection files = fileClient.GetFiles();
        
        foreach (OpenAIFile file in files)
        {
            Console.WriteLine($"  {file.Id}: {file.Filename} ({file.SizeInBytes} bytes, {file.Purpose})");
        }

        // Upload a sample file for demonstration
        string sampleContent = "This is a sample file for management demonstration.";
        BinaryData sampleData = BinaryData.FromString(sampleContent);
        
        OpenAIFile newFile = fileClient.UploadFile(
            sampleData, 
            "management_demo.txt", 
            FileUploadPurpose.Assistants);
        
        Console.WriteLine($"\nUploaded new file: {newFile.Id}");

        // Retrieve specific file information
        OpenAIFile retrievedFile = fileClient.GetFile(newFile.Id);
        Console.WriteLine($"\nRetrieved file details:");
        Console.WriteLine($"  ID: {retrievedFile.Id}");
        Console.WriteLine($"  Filename: {retrievedFile.Filename}");

        // Download file content
        BinaryData downloadedContent = fileClient.DownloadFile(newFile.Id);
        string contentText = downloadedContent.ToString();
        Console.WriteLine($"\nDownloaded content: \"{contentText}\"");

        // Clean up: delete the file
        FileDeletionResult deletionResult = fileClient.DeleteFile(newFile.Id);
        Console.WriteLine($"\nFile deletion result:");
        Console.WriteLine($"  Deleted: {deletionResult.Deleted}");
        Console.WriteLine($"  File ID: {deletionResult.FileId}");
        #endregion
    }

    public void DocumentProcessingWorkflow()
    {
        AzureOpenAIClient azureClient = new(
            new Uri("https://your-azure-openai-resource.com"),
            new DefaultAzureCredential());
        
        #pragma warning disable AOAI001
        OpenAIFileClient fileClient = azureClient.GetOpenAIFileClient();
        #pragma warning restore AOAI001

        #region Snippet:DocumentProcessingWorkflow
        // Scenario: Process multiple documents for an AI assistant
        
        // Sample documents with different types of content
        var documents = new Dictionary<string, string>
        {
            ["company_policies.txt"] = 
                "Employee Handbook\n" +
                "1. Work Hours: 9 AM to 5 PM\n" +
                "2. Remote Work: Available 2 days per week\n" +
                "3. Vacation Policy: 20 days annually\n" +
                "4. Dress Code: Business casual",
                
            ["product_specs.txt"] = 
                "Product Specifications\n" +
                "Model: CloudWidget Pro\n" +
                "CPU: 8-core processor\n" +
                "Memory: 16GB RAM\n" +
                "Storage: 512GB SSD\n" +
                "Operating System: Windows 11",
                
            ["faq_responses.txt"] = 
                "Frequently Asked Questions\n" +
                "Q: How do I reset my password?\n" +
                "A: Use the 'Forgot Password' link on the login page.\n" +
                "Q: What are the system requirements?\n" +
                "A: See the product specifications document.\n" +
                "Q: How do I contact support?\n" +
                "A: Email support@company.com or call 1-800-SUPPORT"
        };

        Console.WriteLine("Starting document processing workflow...");
        var uploadedFiles = new List<OpenAIFile>();

        // Step 1: Upload all documents
        foreach (var doc in documents)
        {
            Console.WriteLine($"Uploading {doc.Key}...");
            BinaryData docData = BinaryData.FromString(doc.Value);
            
            OpenAIFile uploadedFile = fileClient.UploadFile(
                docData, 
                doc.Key, 
                FileUploadPurpose.Assistants);
            
            uploadedFiles.Add(uploadedFile);
            Console.WriteLine($"  Uploaded: {uploadedFile.Id}");
        }

        // Step 2: Verify all files are processed
        Console.WriteLine("\nVerifying file processing status...");
        foreach (var file in uploadedFiles)
        {
            // Note: GetFile may fail immediately after upload. In production code,
            // consider adding retries with small delays (e.g., 1-2 seconds) if needed.
            OpenAIFile currentFile = fileClient.GetFile(file.Id);
            Console.WriteLine($"  {currentFile.Filename}: File uploaded successfully");
        }

        // Step 3: Create a summary of uploaded content
        Console.WriteLine("\nDocument processing summary:");
        Console.WriteLine($"Total files uploaded: {uploadedFiles.Count}");
        
        long totalSize = 0;
        foreach (var file in uploadedFiles)
        {
            totalSize += file.SizeInBytes ?? 0; // Handle nullable SizeInBytes
        }
        
        Console.WriteLine($"Total storage used: {totalSize} bytes");
        Console.WriteLine("\nFiles are now ready for use with:");
        Console.WriteLine("- AI Assistants for Q&A");
        Console.WriteLine("- Retrieval-augmented generation (RAG)");
        Console.WriteLine("- Document analysis and summarization");

        // Note: In a real scenario, you might not delete these files immediately
        // as they would be used by assistants or other AI services
        
        Console.WriteLine("\nWorkflow complete! Files available for AI processing.");
        #endregion
    }

    public void FileContentPreparation()
    {
        AzureOpenAIClient azureClient = new(
            new Uri("https://your-azure-openai-resource.com"),
            new DefaultAzureCredential());
        
        #pragma warning disable AOAI001
        OpenAIFileClient fileClient = azureClient.GetOpenAIFileClient();
        #pragma warning restore AOAI001

        #region Snippet:FileContentPreparation
        // Best practices for preparing file content for AI processing
        
        Console.WriteLine("Demonstrating file content preparation best practices...");

        // 1. Structured text data for better AI comprehension
        var structuredContent = new StringBuilder();
        structuredContent.AppendLine("# Customer Service Knowledge Base");
        structuredContent.AppendLine();
        structuredContent.AppendLine("## Billing Questions");
        structuredContent.AppendLine("**Question**: How do I view my bill?");
        structuredContent.AppendLine("**Answer**: Log into your account and click on 'Billing' in the navigation menu.");
        structuredContent.AppendLine();
        structuredContent.AppendLine("**Question**: When is my payment due?");
        structuredContent.AppendLine("**Answer**: Payments are due on the 15th of each month.");
        structuredContent.AppendLine();
        structuredContent.AppendLine("## Technical Support");
        structuredContent.AppendLine("**Question**: How do I troubleshoot connection issues?");
        structuredContent.AppendLine("**Answer**: First, check your internet connection, then restart the application.");

        BinaryData structuredData = BinaryData.FromString(structuredContent.ToString());
        OpenAIFile structuredFile = fileClient.UploadFile(
            structuredData, 
            "structured_kb.md", 
            FileUploadPurpose.Assistants);

        Console.WriteLine($"Uploaded structured content: {structuredFile.Id}");

        // 2. CSV data for tabular information
        var csvContent = new StringBuilder();
        csvContent.AppendLine("Product,Category,Price,InStock");
        csvContent.AppendLine("Laptop Pro,Electronics,1299.99,true");
        csvContent.AppendLine("Wireless Mouse,Electronics,29.99,true");
        csvContent.AppendLine("Office Chair,Furniture,199.99,false");
        csvContent.AppendLine("Standing Desk,Furniture,399.99,true");

        BinaryData csvData = BinaryData.FromString(csvContent.ToString());
        OpenAIFile csvFile = fileClient.UploadFile(
            csvData, 
            "product_catalog.csv", 
            FileUploadPurpose.Assistants);

        Console.WriteLine($"Uploaded CSV data: {csvFile.Id}");

        // 3. JSON data for complex structured information
        string jsonContent = @"{
  ""configurations"": [
    {
      ""environment"": ""production"",
      ""settings"": {
        ""timeout"": 30,
        ""retries"": 3,
        ""logging"": ""info""
      }
    },
    {
      ""environment"": ""development"",
      ""settings"": {
        ""timeout"": 10,
        ""retries"": 1,
        ""logging"": ""debug""
      }
    }
  ],
  ""features"": {
    ""authentication"": true,
    ""analytics"": true,
    ""notifications"": false
  }
}";

        BinaryData jsonData = BinaryData.FromString(jsonContent);
        OpenAIFile jsonFile = fileClient.UploadFile(
            jsonData, 
            "app_config.json", 
            FileUploadPurpose.Assistants);

        Console.WriteLine($"Uploaded JSON configuration: {jsonFile.Id}");

        Console.WriteLine("\nFile preparation best practices:");
        Console.WriteLine("✓ Use clear structure with headers and sections");
        Console.WriteLine("✓ Include context and descriptions");
        Console.WriteLine("✓ Format tabular data as CSV for easy parsing");
        Console.WriteLine("✓ Use JSON for complex nested data");
        Console.WriteLine("✓ Keep file sizes reasonable (< 512MB)");
        Console.WriteLine("✓ Use descriptive filenames");
        #endregion
    }
}