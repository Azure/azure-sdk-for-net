// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable
#pragma warning disable OPENAI001 // Type is for evaluation purposes only

using System;
using System.ClientModel;
using System.IO;
using System.Threading.Tasks;
using Azure.AI.Projects.OpenAI;
using Azure.Core.TestFramework;
using Azure.Identity;
using NUnit.Framework;
using OpenAI.Files;

namespace Azure.AI.Projects.Tests;

public class Sample15_Files : FineTuningTestsBase
{
    public Sample15_Files(bool isAsync) : base(isAsync)
    {
    }

    [Test]
    public async Task FileOperationsAsync()
    {
        var dataDirectory = GetDataDirectory();

        #region Snippet:AI_Projects_Files_CreateClientsAsync
        var endpoint = Environment.GetEnvironmentVariable("PROJECT_ENDPOINT");
        AIProjectClient projectClient = new AIProjectClient(new Uri(endpoint), new DefaultAzureCredential());
        ProjectOpenAIClient oaiClient = projectClient.OpenAI;
        OpenAIFileClient fileClient = oaiClient.GetOpenAIFileClient();
        #endregion

        string fileId = null;

        try
        {
            #region Snippet:AI_Projects_Files_UploadFileAsync
            var testFilePath = Path.Combine(dataDirectory, "sft_training_set.jsonl");
            OpenAIFile uploadedFile = await fileClient.UploadFileAsync(
                BinaryData.FromBytes(File.ReadAllBytes(testFilePath)),
                "sft_training_set.jsonl",
                FileUploadPurpose.FineTune);
            Console.WriteLine($"Uploaded file with ID: {uploadedFile.Id}");
            fileId = uploadedFile.Id;
            #endregion

            #region Snippet:AI_Projects_Files_GetFileAsync
            OpenAIFile retrievedFile = await fileClient.GetFileAsync(fileId);
            Console.WriteLine($"Retrieved file: {retrievedFile.Filename} ({retrievedFile.SizeInBytes} bytes)");
            #endregion

            #region Snippet:AI_Projects_Files_DownloadFileAsync
            BinaryData fileContent = await fileClient.DownloadFileAsync(fileId);
            Console.WriteLine($"Downloaded file content: {fileContent.ToMemory().Length} bytes");
            #endregion

            #region Snippet:AI_Projects_Files_ListFilesAsync
            ClientResult<OpenAIFileCollection> filesResult = await fileClient.GetFilesAsync();
            Console.WriteLine($"Listed {filesResult.Value.Count} file(s)");
            #endregion
        }
        finally
        {
            if (fileId != null)
            {
                #region Snippet:AI_Projects_Files_DeleteFileAsync
                ClientResult<FileDeletionResult> deleteResult = await fileClient.DeleteFileAsync(fileId);
                Console.WriteLine($"Deleted file: {deleteResult.Value.FileId}");
                #endregion
            }
        }
    }

    [Test]
    public void FileOperations()
    {
        var dataDirectory = GetDataDirectory();

        #region Snippet:AI_Projects_Files_CreateClients
        var endpoint = Environment.GetEnvironmentVariable("PROJECT_ENDPOINT");
        AIProjectClient projectClient = new AIProjectClient(new Uri(endpoint), new DefaultAzureCredential());
        ProjectOpenAIClient oaiClient = projectClient.OpenAI;
        OpenAIFileClient fileClient = oaiClient.GetOpenAIFileClient();
        #endregion

        string fileId = null;

        try
        {
            #region Snippet:AI_Projects_Files_UploadFile
            var testFilePath = Path.Combine(dataDirectory, "sft_training_set.jsonl");
            OpenAIFile uploadedFile = fileClient.UploadFile(
                BinaryData.FromBytes(File.ReadAllBytes(testFilePath)),
                "sft_training_set.jsonl",
                FileUploadPurpose.FineTune);
            Console.WriteLine($"Uploaded file with ID: {uploadedFile.Id}");
            fileId = uploadedFile.Id;
            #endregion

            #region Snippet:AI_Projects_Files_GetFile
            OpenAIFile retrievedFile = fileClient.GetFile(fileId);
            Console.WriteLine($"Retrieved file: {retrievedFile.Filename} ({retrievedFile.SizeInBytes} bytes)");
            #endregion

            #region Snippet:AI_Projects_Files_DownloadFile
            BinaryData fileContent = fileClient.DownloadFile(fileId);
            Console.WriteLine($"Downloaded file content: {fileContent.ToMemory().Length} bytes");
            #endregion

            #region Snippet:AI_Projects_Files_ListFiles
            ClientResult<OpenAIFileCollection> filesResult = fileClient.GetFiles();
            Console.WriteLine($"Listed {filesResult.Value.Count} file(s)");
            #endregion
        }
        finally
        {
            if (fileId != null)
            {
                #region Snippet:AI_Projects_Files_DeleteFile
                ClientResult<FileDeletionResult> deleteResult = fileClient.DeleteFile(fileId);
                Console.WriteLine($"Deleted file: {deleteResult.Value.FileId}");
                #endregion
            }
        }
    }
}
