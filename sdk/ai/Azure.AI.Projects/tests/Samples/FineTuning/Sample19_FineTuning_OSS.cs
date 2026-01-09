// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable
#pragma warning disable OPENAI001 // Type is for evaluation purposes only

using System;
using System.ClientModel;
using System.IO;
using System.Text.Json;
using System.Threading.Tasks;
using Azure.AI.Projects.OpenAI;
using Azure.Identity;
using NUnit.Framework;
using OpenAI.Files;
using OpenAI.FineTuning;

namespace Azure.AI.Projects.Tests.Samples;

public partial class Sample19_FineTuning_OSS : SamplesBase
{
    [Test]
    public async Task OssFineTuningAsync()
    {
        #region Snippet:AI_Projects_FineTuning_OSS_CreateClientsAsync
#if SNIPPET
        string trainingFilePath = Environment.GetEnvironmentVariable("TRAINING_FILE_PATH") ?? "data/sft_training_set.jsonl";
        string validationFilePath = Environment.GetEnvironmentVariable("VALIDATION_FILE_PATH") ?? "data/sft_validation_set.jsonl";
#else
        string trainingFilePath = Path.Combine(FineTuningHelpers.GetSamplesDataDirectory(), "sft_training_set.jsonl");
        string validationFilePath = Path.Combine(FineTuningHelpers.GetSamplesDataDirectory(), "sft_validation_set.jsonl");
#endif
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
        using FileStream trainStream = File.OpenRead(trainingFilePath);
        OpenAIFile trainFile = await fileClient.UploadFileAsync(
            trainStream,
            "sft_training_set.jsonl",
            FileUploadPurpose.FineTune);
        Console.WriteLine($"Uploaded training file with ID: {trainFile.Id}");

        // Upload validation file
        Console.WriteLine("Uploading validation file...");
        using FileStream validationStream = File.OpenRead(validationFilePath);
        OpenAIFile validationFile = await fileClient.UploadFileAsync(
            validationStream,
            "sft_validation_set.jsonl",
            FileUploadPurpose.FineTune);
        Console.WriteLine($"Uploaded validation file with ID: {validationFile.Id}");
        #endregion

        // Wait for files to complete processing
        Console.WriteLine("Waiting for files to complete processing...");
        await FineTuningHelpers.WaitForFileProcessingAsync(fileClient, trainFile.Id, pollIntervalSeconds: 2);
        await FineTuningHelpers.WaitForFileProcessingAsync(fileClient, validationFile.Id, pollIntervalSeconds: 2);

        #region Snippet:AI_Projects_FineTuning_OSS_CreateJobAsync
        // Create OSS fine-tuning job with GlobalStandard training type
        Console.WriteLine("Creating OSS fine-tuning job...");

        var requestJson = new
        {
            model = modelDeploymentName,
            training_file = trainFile.Id,
            validation_file = validationFile.Id,
            trainingType = "GlobalStandard",
            method = new
            {
                type = "supervised",
                hyperparameters = new
                {
                    n_epochs = 1,
                    batch_size = 4,
                    learning_rate_multiplier = 0.0001
                }
            }
        };

        string jsonBody = JsonSerializer.Serialize(requestJson);

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
#if SNIPPET
        string trainingFilePath = Environment.GetEnvironmentVariable("TRAINING_FILE_PATH") ?? "data/sft_training_set.jsonl";
        string validationFilePath = Environment.GetEnvironmentVariable("VALIDATION_FILE_PATH") ?? "data/sft_validation_set.jsonl";
#else
        string trainingFilePath = Path.Combine(FineTuningHelpers.GetSamplesDataDirectory(), "sft_training_set.jsonl");
        string validationFilePath = Path.Combine(FineTuningHelpers.GetSamplesDataDirectory(), "sft_validation_set.jsonl");
#endif
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
        using FileStream trainStream = File.OpenRead(trainingFilePath);
        OpenAIFile trainFile = fileClient.UploadFile(
            trainStream,
            "sft_training_set.jsonl",
            FileUploadPurpose.FineTune);
        Console.WriteLine($"Uploaded training file with ID: {trainFile.Id}");

        // Upload validation file
        Console.WriteLine("Uploading validation file...");
        using FileStream validationStream = File.OpenRead(validationFilePath);
        OpenAIFile validationFile = fileClient.UploadFile(
            validationStream,
            "sft_validation_set.jsonl",
            FileUploadPurpose.FineTune);
        Console.WriteLine($"Uploaded validation file with ID: {validationFile.Id}");
        #endregion

        // Wait for files to complete processing
        Console.WriteLine("Waiting for files to complete processing...");
        FineTuningHelpers.WaitForFileProcessing(fileClient, trainFile.Id, pollIntervalSeconds: 2);
        FineTuningHelpers.WaitForFileProcessing(fileClient, validationFile.Id, pollIntervalSeconds: 2);

        #region Snippet:AI_Projects_FineTuning_OSS_CreateJob
        // Create OSS fine-tuning job with GlobalStandard training type
        Console.WriteLine("Creating OSS fine-tuning job...");

        var requestJson = new
        {
            model = modelDeploymentName,
            training_file = trainFile.Id,
            validation_file = validationFile.Id,
            trainingType = "GlobalStandard",
            method = new
            {
                type = "supervised",
                hyperparameters = new
                {
                    n_epochs = 1,
                    batch_size = 4,
                    learning_rate_multiplier = 0.0001
                }
            }
        };

        string jsonBody = JsonSerializer.Serialize(requestJson);

        BinaryContent content = BinaryContent.Create(BinaryData.FromString(jsonBody));
        FineTuningJob fineTuningJob = fineTuningClient.FineTune(content, waitUntilCompleted: false, options: null);

        Console.WriteLine($"Created OSS fine-tuning job: {fineTuningJob.JobId}");
        Console.WriteLine($"Status: {fineTuningJob.Status}");
        #endregion
    }

    public Sample19_FineTuning_OSS(bool isAsync) : base(isAsync)
    { }
}
