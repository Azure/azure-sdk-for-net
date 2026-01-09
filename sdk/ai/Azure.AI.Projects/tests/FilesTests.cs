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
public class FilesTests : ProjectsClientTestBase
{
    public FilesTests(bool isAsync) : base(isAsync)
    {
    }

    private static string GetTestFineTuningFile(string name) => GetTestFile(Path.Combine("FineTuning", name));

    [RecordedTest]
    public async Task FileOperations_FullLifecycle()
    {
        var testFilePath = GetTestFineTuningFile("sft_training_set.jsonl");

        AIProjectClient projectClient = GetTestProjectClient();
        OpenAIFileClient fileClient = projectClient.OpenAI.GetOpenAIFileClient();

        // Step 1: Upload a file
        OpenAIFile uploadedFile = await fileClient.UploadFileAsync(
            BinaryData.FromBytes(File.ReadAllBytes(testFilePath)),
            "sft_training_set.jsonl",
            FileUploadPurpose.FineTune);

        Assert.That(uploadedFile, Is.Not.Null);
        Assert.That(uploadedFile.Id, Is.Not.Null);
        Assert.That(uploadedFile.Filename, Is.EqualTo("sft_training_set.jsonl"));
        Assert.That(uploadedFile.SizeInBytes, Is.GreaterThan(0));

        string fileId = uploadedFile.Id;

        try
        {
            // Step 2: Retrieve file metadata by ID
            OpenAIFile retrievedFile = await fileClient.GetFileAsync(fileId);

            Assert.That(retrievedFile, Is.Not.Null);
            Assert.That(fileId, Is.EqualTo(retrievedFile.Id));
            Assert.That(retrievedFile.Filename, Is.EqualTo("sft_training_set.jsonl"));
            Assert.That(retrievedFile.SizeInBytes, Is.GreaterThan(0));

            // Step 3: Retrieve file content
            BinaryData fileContent = await fileClient.DownloadFileAsync(fileId);

            Assert.That(fileContent, Is.Not.Null);
            Assert.That(fileContent.ToMemory().Length, Is.GreaterThan(0));

            // Step 4: List all files
            int fileCount = 0;
            bool foundUploadedFile = false;
            OpenAIFileCollection filesResult = await fileClient.GetFilesAsync();
            Assert.That(filesResult, Is.Not.Null);

            foreach (OpenAIFile file in filesResult)
            {
                fileCount++;
                if (file.Id == fileId)
                {
                    foundUploadedFile = true;
                }
                if (fileCount >= 5)
                {
                    break;
                }
            }
            Assert.That(fileCount, Is.GreaterThan(0));
            Assert.That(foundUploadedFile, Is.True, "Uploaded file should appear in the list of files");
        }
        finally
        {
            // Step 5: Delete the file
            try
            {
                ClientResult<FileDeletionResult> deleteResult = await fileClient.DeleteFileAsync(fileId);
                Assert.That(deleteResult, Is.Not.Null);
                Assert.That(deleteResult.Value, Is.Not.Null);
                Assert.That(deleteResult.Value.Deleted, Is.Not.Null);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Failed to delete file {fileId}: {ex.Message}");
            }
        }
    }
}
