// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable
#pragma warning disable OPENAI001 // Type is for evaluation purposes only

using System;
using System.ClientModel;
using System.IO;
using System.Threading.Tasks;
using Azure.AI.Agents;
using Azure.Core.TestFramework;
using NUnit.Framework;
using OpenAI;
using OpenAI.Files;

namespace Azure.AI.Projects.Tests;

internal class Sample_Files : SamplesBase<AIProjectsTestEnvironment>
{
    private string GetDataDirectory()
    {
        var testDirectory = Path.GetDirectoryName(typeof(Sample_Files).Assembly.Location);
        while (testDirectory != null && !Directory.Exists(Path.Combine(testDirectory, "sdk")))
        {
            testDirectory = Path.GetDirectoryName(testDirectory);
        }
        return Path.Combine(testDirectory!, "sdk", "ai", "Azure.AI.Projects", "tests", "Samples", "FineTuning", "data");
    }

    [Test]
    [AsyncOnly]
    public async Task FileOperationsAsync()
    {
        var endpoint = TestEnvironment.PROJECTENDPOINT;
        var dataDirectory = GetDataDirectory();
        var testFilePath = Path.Combine(dataDirectory, "training_set.jsonl");

        var projectClient = new AIProjectClient(new Uri(endpoint), new DefaultAzureCredential());
        OpenAIFileClient fileClient = projectClient.OpenAI.Files;

        // Step 1: Upload a file
        Console.WriteLine("\n=== Step 1: Uploading File ===");
        Console.WriteLine($"Uploading file from: {testFilePath}");

        // Verify file exists and is not empty
        if (!File.Exists(testFilePath))
        {
            throw new FileNotFoundException($"Test file not found: {testFilePath}");
        }

        FileInfo fileInfo = new FileInfo(testFilePath);
        Console.WriteLine($"File size on disk: {fileInfo.Length} bytes");

        if (fileInfo.Length == 0)
        {
            throw new InvalidOperationException($"Test file is empty: {testFilePath}");
        }

        OpenAIFile uploadedFile;
        using (FileStream fileStream = File.OpenRead(testFilePath))
        {
            Console.WriteLine($"FileStream length: {fileStream.Length} bytes");
            Console.WriteLine($"FileStream can read: {fileStream.CanRead}");

            uploadedFile = await fileClient.UploadFileAsync(
                fileStream,
                "training_set.jsonl",
                FileUploadPurpose.FineTune);
        }
        Console.WriteLine($"✅ File uploaded successfully!");
        Console.WriteLine($"   File ID: {uploadedFile.Id}");
        Console.WriteLine($"   Filename: {uploadedFile.Filename}");
        Console.WriteLine($"   Purpose: {uploadedFile.Purpose}");
        Console.WriteLine($"   Size: {uploadedFile.SizeInBytes} bytes");
        Console.WriteLine($"   Created At: {uploadedFile.CreatedAt}");

        // Use the uploaded file ID
        string fileId = uploadedFile.Id;

        // Step 2: Retrieve file metadata by ID
        Console.WriteLine("\n=== Step 2: Retrieving File Metadata ===");
        Console.WriteLine($"Retrieving metadata for file ID: {fileId}");
        OpenAIFile retrievedFile = await fileClient.GetFileAsync(fileId);
        Console.WriteLine($"✅ File metadata retrieved successfully!");
        Console.WriteLine($"   File ID: {retrievedFile.Id}");
        Console.WriteLine($"   Filename: {retrievedFile.Filename}");
        Console.WriteLine($"   Purpose: {retrievedFile.Purpose}");
        Console.WriteLine($"   Size: {retrievedFile.SizeInBytes} bytes");

        // Step 3: Retrieve file content
        Console.WriteLine("\n=== Step 3: Retrieving File Content ===");
        Console.WriteLine($"Downloading content for file ID: {fileId}");
        BinaryData fileContent = await fileClient.DownloadFileAsync(fileId);
        Console.WriteLine($"✅ File content retrieved successfully!");
        Console.WriteLine($"   Content size: {fileContent.ToMemory().Length} bytes");

        // Assert downloaded content matches expected size
        Assert.IsNotNull(fileContent, "Downloaded file content should not be null");
        Assert.IsTrue(fileContent.ToMemory().Length > 0, "Downloaded content should not be empty");

        // Display first few lines of content
        string contentStr = fileContent.ToString();
        string[] lines = contentStr.Split('\n');
        int linesToShow = Math.Min(3, lines.Length);
        Console.WriteLine($"   First {linesToShow} line(s) of content:");
        for (int i = 0; i < linesToShow; i++)
        {
            string line = lines[i].Length > 100 ? lines[i].Substring(0, 100) + "..." : lines[i];
            Console.WriteLine($"      {line}");
        }

        // Step 4: List all files
        Console.WriteLine("\n=== Step 4: Listing All Files ===");
        Console.WriteLine("Retrieving list of all files...");
        int fileCount = 0;
        bool foundUploadedFile = false;
        ClientResult<OpenAIFileCollection> filesResult = await fileClient.GetFilesAsync();
        foreach (OpenAIFile file in filesResult.Value)
        {
            fileCount++;
            Console.WriteLine($"- File {fileCount}:");
            Console.WriteLine($"    ID: {file.Id}");
            Console.WriteLine($"    Filename: {file.Filename}");
            Console.WriteLine($"    Purpose: {file.Purpose}");
            Console.WriteLine($"    Size: {file.SizeInBytes} bytes");

            if (file.Id == fileId)
            {
                foundUploadedFile = true;
                Console.WriteLine($"    ⭐ This is our uploaded file!");
            }

            if (fileCount >= 5)
            {
                Console.WriteLine("   ... (showing first 5 files)");
                break;
            }
        }
        Console.WriteLine($"✅ Listed {fileCount} file(s)");

        // Assert that we listed at least one file
        Assert.IsTrue(fileCount > 0, "Should have listed at least one file");

        if (foundUploadedFile)
        {
            Console.WriteLine($"✅ Confirmed our uploaded file is in the list");
        }

        // Assert that our uploaded file is in the list
        Assert.IsTrue(foundUploadedFile, "Uploaded file should appear in the list of files");

        // Step 5: Delete the file
        Console.WriteLine("\n=== Step 5: Deleting File ===");
        Console.WriteLine($"Deleting file with ID: {fileId}");
        ClientResult<FileDeletionResult> deleteResult = await fileClient.DeleteFileAsync(fileId);
        Console.WriteLine($"✅ File deleted successfully! Deleted: {deleteResult.Value.Deleted}");

        // Step 6: Verify file is deleted
        Console.WriteLine("\n=== Step 6: Verifying File Deletion ===");
        Console.WriteLine("Checking if file still exists in list...");
        bool fileStillExists = false;
        int verifyCount = 0;
        ClientResult<OpenAIFileCollection> verifyFilesResult = await fileClient.GetFilesAsync();
        foreach (OpenAIFile file in verifyFilesResult.Value)
        {
            verifyCount++;
            if (file.Id == fileId)
            {
                fileStillExists = true;
                break;
            }

            // Only check first 50 files to avoid long iteration
            if (verifyCount >= 50)
            {
                break;
            }
        }

        if (fileStillExists)
        {
            Console.WriteLine($"⚠️  Warning: File still appears in list after deletion");
        }
        else
        {
            Console.WriteLine($"✅ Confirmed: File no longer appears in the list");
        }

        // Assert file no longer exists in the list
        Assert.IsFalse(fileStillExists, "Deleted file should not appear in the list of files");

        Console.WriteLine("\n=== File Operations Completed Successfully! ===");
    }
}
