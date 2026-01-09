// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable
#pragma warning disable OPENAI001 // Type is for evaluation purposes only

using System;
using System.ClientModel;
using System.IO;
using System.Threading.Tasks;
using Azure.AI.Projects.OpenAI;
using Azure.Identity;
using NUnit.Framework;
using OpenAI.Files;

namespace Azure.AI.Projects.Tests.Samples;

public class Sample15_Files : SamplesBase
{
    [Test]
    public async Task FileOperationsAsync()
    {
        #region Snippet:AI_Projects_Files_CreateClientsAsync
#if SNIPPET
        string trainFilePath = Environment.GetEnvironmentVariable("TRAINING_FILE_PATH") ?? "data/sft_training_set.jsonl";
#else
        string trainFilePath = Path.Combine(FineTuningHelpers.GetSamplesDataDirectory(), "sft_training_set.jsonl");
#endif
        var endpoint = Environment.GetEnvironmentVariable("PROJECT_ENDPOINT");
        AIProjectClient projectClient = new AIProjectClient(new Uri(endpoint), new DefaultAzureCredential());
        ProjectOpenAIClient oaiClient = projectClient.OpenAI;
        OpenAIFileClient fileClient = oaiClient.GetOpenAIFileClient();
        #endregion

        string fileId = null;

        try
        {
            #region Snippet:AI_Projects_Files_UploadFileAsync
            using FileStream fileStream = File.OpenRead(trainFilePath);
            OpenAIFile uploadedFile = await fileClient.UploadFileAsync(
                fileStream,
                "sft_training_set.jsonl",
                FileUploadPurpose.FineTune);
            Console.WriteLine($"Uploaded file with ID: {uploadedFile.Id}");
            #endregion
            fileId = uploadedFile.Id;

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
        #region Snippet:AI_Projects_Files_CreateClients
#if SNIPPET
        string trainFilePath = Environment.GetEnvironmentVariable("TRAINING_FILE_PATH") ?? "data/sft_training_set.jsonl";
#else
        string trainFilePath = Path.Combine(FineTuningHelpers.GetSamplesDataDirectory(), "sft_training_set.jsonl");
#endif
        var endpoint = Environment.GetEnvironmentVariable("PROJECT_ENDPOINT");
        AIProjectClient projectClient = new AIProjectClient(new Uri(endpoint), new DefaultAzureCredential());
        ProjectOpenAIClient oaiClient = projectClient.OpenAI;
        OpenAIFileClient fileClient = oaiClient.GetOpenAIFileClient();
        #endregion

        string fileId = null;

        try
        {
            #region Snippet:AI_Projects_Files_UploadFile
            using FileStream fileStream = File.OpenRead(trainFilePath);
            OpenAIFile uploadedFile = fileClient.UploadFile(
                fileStream,
                "sft_training_set.jsonl",
                FileUploadPurpose.FineTune);
            Console.WriteLine($"Uploaded file with ID: {uploadedFile.Id}");
            #endregion
            fileId = uploadedFile.Id;

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
    public Sample15_Files(bool isAsync) : base(isAsync)
    { }
}
