// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable
#pragma warning disable OPENAI001 // Type is for evaluation purposes only

using System;
using System.ClientModel;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Threading.Tasks;
using Azure.AI.Projects.OpenAI;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.Identity;
using NUnit.Framework;
using OpenAI.Files;
using OpenAI.FineTuning;

namespace Azure.AI.Projects.Tests.Samples.FineTuning;

public partial class Sample19_FineTuning_OSS : SamplesBase<AIProjectsTestEnvironment>
{
    [Test]
    public async Task OssFineTuningAsync()
    {
        #region Snippet:AI_Projects_FineTuning_OSS_CreateClientsAsync
        var endpoint = Environment.GetEnvironmentVariable("PROJECT_ENDPOINT");
        var modelDeploymentName = Environment.GetEnvironmentVariable("MODEL_DEPLOYMENT_NAME");
        AIProjectClient projectClient = new AIProjectClient(new Uri(endpoint), new DefaultAzureCredential());
        ProjectOpenAIClient oaiClient = projectClient.OpenAI;
        OpenAIFileClient fileClient = oaiClient.GetOpenAIFileClient();
        FineTuningClient fineTuningClient = oaiClient.GetFineTuningClient();
        #endregion

        #region Snippet:AI_Projects_FineTuning_OSS_UploadFilesAsync
        // Upload training file
        Console.WriteLine("Uploading training file...");
        using FileStream trainStream = File.OpenRead("sdk/ai/Azure.AI.Projects/tests/Samples/FineTuning/data/sft_training_set.jsonl");
        OpenAIFile trainFile = await fileClient.UploadFileAsync(
            trainStream,
            "sft_training_set.jsonl",
            FileUploadPurpose.FineTune);
        Console.WriteLine($"Uploaded training file with ID: {trainFile.Id}");

        // Upload validation file
        Console.WriteLine("Uploading validation file...");
        using FileStream validationStream = File.OpenRead("sdk/ai/Azure.AI.Projects/tests/Samples/FineTuning/data/sft_validation_set.jsonl");
        OpenAIFile validationFile = await fileClient.UploadFileAsync(
            validationStream,
            "sft_validation_set.jsonl",
            FileUploadPurpose.FineTune);
        Console.WriteLine($"Uploaded validation file with ID: {validationFile.Id}");

        // Note: In production, you should wait for files to complete processing before creating a fine-tuning job.
        // See Sample16_FineTuning_Supervised.md for a WaitForFileProcessingAsync helper method.
        #endregion

        #region Snippet:AI_Projects_FineTuning_OSS_CreateJobAsync
        // Create OSS fine-tuning job with GlobalStandard training type
        // Note: OSS models like Ministral-3B require explicit trainingType="GlobalStandard" parameter
        // which is not supported by the standard FineTuningClient API, so we use manual JSON construction
        Console.WriteLine("Creating OSS fine-tuning job...");

        string jsonBody = JsonSerializer.Serialize(new Dictionary<string, object>
        {
            ["model"] = modelDeploymentName,
            ["training_file"] = trainFile.Id,
            ["validation_file"] = validationFile.Id,
            ["trainingType"] = "GlobalStandard",
            ["method"] = new Dictionary<string, object>
            {
                ["type"] = "supervised",
                ["hyperparameters"] = new Dictionary<string, object>
                {
                    ["n_epochs"] = 1,
                    ["batch_size"] = 4,
                    ["learning_rate_multiplier"] = 0.0001
                }
            }
        });

        BinaryContent content = BinaryContent.Create(BinaryData.FromString(jsonBody));
        FineTuningJob fineTuningJob = await fineTuningClient.FineTuneAsync(content, waitUntilCompleted: false, options: null);

        Console.WriteLine($"Created OSS fine-tuning job: {fineTuningJob.JobId}");
        Console.WriteLine($"Status: {fineTuningJob.Status}");
        #endregion
    }

    [Test]
    public void OssFineTuningSync()
    {
        #region Snippet:AI_Projects_FineTuning_OSS_CreateClients
        var endpoint = Environment.GetEnvironmentVariable("PROJECT_ENDPOINT");
        var modelDeploymentName = Environment.GetEnvironmentVariable("MODEL_DEPLOYMENT_NAME");
        AIProjectClient projectClient = new AIProjectClient(new Uri(endpoint), new DefaultAzureCredential());
        ProjectOpenAIClient oaiClient = projectClient.OpenAI;
        OpenAIFileClient fileClient = oaiClient.GetOpenAIFileClient();
        FineTuningClient fineTuningClient = oaiClient.GetFineTuningClient();
        #endregion

        #region Snippet:AI_Projects_FineTuning_OSS_UploadFiles
        // Upload training file
        Console.WriteLine("Uploading training file...");
        using FileStream trainStream = File.OpenRead("sdk/ai/Azure.AI.Projects/tests/Samples/FineTuning/data/sft_training_set.jsonl");
        OpenAIFile trainFile = fileClient.UploadFile(
            trainStream,
            "sft_training_set.jsonl",
            FileUploadPurpose.FineTune);
        Console.WriteLine($"Uploaded training file with ID: {trainFile.Id}");

        // Upload validation file
        Console.WriteLine("Uploading validation file...");
        using FileStream validationStream = File.OpenRead("sdk/ai/Azure.AI.Projects/tests/Samples/FineTuning/data/sft_validation_set.jsonl");
        OpenAIFile validationFile = fileClient.UploadFile(
            validationStream,
            "sft_validation_set.jsonl",
            FileUploadPurpose.FineTune);
        Console.WriteLine($"Uploaded validation file with ID: {validationFile.Id}");

        // Note: In production, you should wait for files to complete processing before creating a fine-tuning job.
        // See Sample16_FineTuning_Supervised.md for a WaitForFileProcessing helper method.
        #endregion

        #region Snippet:AI_Projects_FineTuning_OSS_CreateJob
        // Create OSS fine-tuning job with GlobalStandard training type
        Console.WriteLine("Creating OSS fine-tuning job...");

        string jsonBody = JsonSerializer.Serialize(new Dictionary<string, object>
        {
            ["model"] = modelDeploymentName,
            ["training_file"] = trainFile.Id,
            ["validation_file"] = validationFile.Id,
            ["trainingType"] = "GlobalStandard",
            ["method"] = new Dictionary<string, object>
            {
                ["type"] = "supervised",
                ["hyperparameters"] = new Dictionary<string, object>
                {
                    ["n_epochs"] = 1,
                    ["batch_size"] = 4,
                    ["learning_rate_multiplier"] = 0.0001
                }
            }
        });

        BinaryContent content = BinaryContent.Create(BinaryData.FromString(jsonBody));
        FineTuningJob fineTuningJob = fineTuningClient.FineTune(content, waitUntilCompleted: false, options: null);

        Console.WriteLine($"Created OSS fine-tuning job: {fineTuningJob.JobId}");
        Console.WriteLine($"Status: {fineTuningJob.Status}");
        #endregion
    }
}
