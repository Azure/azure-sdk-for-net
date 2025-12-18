// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable
#pragma warning disable OPENAI001 // Type is for evaluation purposes only

using System;
using System.ClientModel;
using System.IO;
using System.Threading.Tasks;
using Microsoft.ClientModel.TestFramework;
using NUnit.Framework;
using OpenAI.Files;

namespace Azure.AI.Projects.Tests;

/// <summary>
/// Asynchronous recorded tests for OpenAI file operations using test-proxy.
/// </summary>
public class FilesTests : FineTuningTestsBase
{
    public FilesTests(bool isAsync) : base(isAsync)
    {
    }

    [RecordedTest]
    public async Task FileOperations_FullLifecycle()
    {
        Console.WriteLine($"Test Mode: {Mode}");
        Console.WriteLine($"Recording is null: {Recording == null}");
        Console.WriteLine($"Recording ID: {Recording?.RecordingId}");

        var dataDirectory = GetDataDirectory();
        var testFilePath = Path.Combine(dataDirectory, "sft_training_set.jsonl");

        var (fileClient, _) = GetClients();

        // Step 1: Upload a file
        Console.WriteLine("=== Step 1: Uploading File ===");
        Console.WriteLine($"Uploading file: sft_training_set.jsonl");

        OpenAIFile uploadedFile = await fileClient.UploadFileAsync(
            BinaryData.FromBytes(File.ReadAllBytes(testFilePath)),
            "sft_training_set.jsonl",
            FileUploadPurpose.FineTune);

        Assert.That(uploadedFile, Is.Not.Null);
        Assert.That(uploadedFile.Id, Is.Not.Null);
        Assert.That(uploadedFile.Filename, Is.EqualTo("sft_training_set.jsonl"));
        Assert.That(uploadedFile.SizeInBytes, Is.GreaterThan(0));
        Console.WriteLine($"File uploaded successfully!");
        Console.WriteLine($"   File ID: {uploadedFile.Id}");
        Console.WriteLine($"   Filename: {uploadedFile.Filename}");
        Console.WriteLine($"   Purpose: {uploadedFile.Purpose}");
        Console.WriteLine($"   Size: {uploadedFile.SizeInBytes} bytes");

        string fileId = uploadedFile.Id;

        try
        {
            // Step 2: Retrieve file metadata by ID
            Console.WriteLine("=== Step 2: Retrieving File Metadata ===");
            Console.WriteLine($"Retrieving metadata for file ID: {fileId}");
            OpenAIFile retrievedFile = await fileClient.GetFileAsync(fileId);

            Assert.That(retrievedFile, Is.Not.Null);
            Assert.That(fileId, Is.EqualTo(retrievedFile.Id));
            Assert.That(retrievedFile.Filename, Is.EqualTo("sft_training_set.jsonl"));
            Assert.That(retrievedFile.SizeInBytes, Is.GreaterThan(0));
            Console.WriteLine($"File metadata retrieved successfully!");
            Console.WriteLine($"   File ID: {retrievedFile.Id}");
            Console.WriteLine($"   Filename: {retrievedFile.Filename}");

            // Step 3: Retrieve file content
            Console.WriteLine("=== Step 3: Retrieving File Content ===");
            Console.WriteLine($"Downloading content for file ID: {fileId}");
            BinaryData fileContent = await fileClient.DownloadFileAsync(fileId);

            Assert.That(fileContent, Is.Not.Null);
            Assert.That(fileContent.ToMemory().Length, Is.GreaterThan(0));
            Console.WriteLine($"File content retrieved successfully!");
            Console.WriteLine($"   Content size: {fileContent.ToMemory().Length} bytes");

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
            Console.WriteLine("=== Step 4: Listing All Files ===");
            Console.WriteLine("Retrieving list of all files...");
            int fileCount = 0;
            bool foundUploadedFile = false;
            ClientResult<OpenAIFileCollection> filesResult = await fileClient.GetFilesAsync();

            Assert.That(filesResult, Is.Not.Null);
            Assert.That(filesResult.Value, Is.Not.Null);

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
            Console.WriteLine($"Listed {fileCount} file(s)");
            Assert.That(fileCount, Is.GreaterThan(0));
            Assert.That(foundUploadedFile, Is.True, "Uploaded file should appear in the list of files");
            Console.WriteLine($"Confirmed our uploaded file is in the list");
        }
        finally
        {
            // Step 5: Delete the file
            Console.WriteLine("=== Step 5: Deleting File ===");
            Console.WriteLine($"Deleting file with ID: {fileId}");
            try
            {
                ClientResult<FileDeletionResult> deleteResult = await fileClient.DeleteFileAsync(fileId);
                Assert.That(deleteResult, Is.Not.Null);
                Assert.That(deleteResult.Value, Is.Not.Null);
                Assert.That(deleteResult.Value.Deleted, Is.Not.Null);
                Console.WriteLine($"File deleted successfully! Deleted: {deleteResult.Value.Deleted}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Failed to delete file {fileId}: {ex.Message}");
            }
        }

        Console.WriteLine("=== File Operations Completed Successfully! ===");
    }
}
