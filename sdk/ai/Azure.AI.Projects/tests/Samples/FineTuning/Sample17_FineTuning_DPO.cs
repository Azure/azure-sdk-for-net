// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable
#pragma warning disable OPENAI001 // Type is for evaluation purposes only

using System;
using System.IO;
using System.Threading.Tasks;
using Azure.AI.Projects.OpenAI;
using Azure.Identity;
using NUnit.Framework;
using OpenAI.Files;
using OpenAI.FineTuning;

namespace Azure.AI.Projects.Tests.Samples;

public partial class Sample17_FineTuning_DPO : SamplesBase
{
    [Test]
    public async Task DpoFineTuningAsync()
    {
        #region Snippet:AI_Projects_FineTuning_DPO_CreateClientsAsync
#if SNIPPET
        string trainingFilePath = Environment.GetEnvironmentVariable("TRAINING_FILE_PATH") ?? "data/dpo_training_set.jsonl";
        string validationFilePath = Environment.GetEnvironmentVariable("VALIDATION_FILE_PATH") ?? "data/dpo_validation_set.jsonl";
#else
        string trainingFilePath = Path.Combine(FineTuningHelpers.GetSamplesDataDirectory(), "dpo_training_set.jsonl");
        string validationFilePath = Path.Combine(FineTuningHelpers.GetSamplesDataDirectory(), "dpo_validation_set.jsonl");
#endif
        var endpoint = Environment.GetEnvironmentVariable("PROJECT_ENDPOINT");
        var modelDeploymentName = Environment.GetEnvironmentVariable("MODEL_DEPLOYMENT_NAME");
        AIProjectClient projectClient = new AIProjectClient(new Uri(endpoint), new DefaultAzureCredential());
        ProjectOpenAIClient oaiClient = projectClient.OpenAI;
        OpenAIFileClient fileClient = oaiClient.GetOpenAIFileClient();
        FineTuningClient fineTuningClient = oaiClient.GetFineTuningClient();
        #endregion

        #region Snippet:AI_Projects_FineTuning_DPO_UploadFilesAsync
        // Upload training file
        Console.WriteLine("Uploading training file...");
        using FileStream trainStream = File.OpenRead(trainingFilePath);
        OpenAIFile trainFile = await fileClient.UploadFileAsync(
            trainStream,
            "dpo_training_set.jsonl",
            FileUploadPurpose.FineTune);
        Console.WriteLine($"Uploaded training file with ID: {trainFile.Id}");

        // Upload validation file
        Console.WriteLine("Uploading validation file...");
        using FileStream validationStream = File.OpenRead(validationFilePath);
        OpenAIFile validationFile = await fileClient.UploadFileAsync(
            validationStream,
            "dpo_validation_set.jsonl",
            FileUploadPurpose.FineTune);
        Console.WriteLine($"Uploaded validation file with ID: {validationFile.Id}");
        #endregion

        // Wait for files to complete processing
        Console.WriteLine("Waiting for files to complete processing...");
        await FineTuningHelpers.WaitForFileProcessingAsync(fileClient, trainFile.Id, pollIntervalSeconds: 2);
        await FineTuningHelpers.WaitForFileProcessingAsync(fileClient, validationFile.Id, pollIntervalSeconds: 2);

        #region Snippet:AI_Projects_FineTuning_DPO_CreateJobAsync
        // Create DPO fine-tuning job
        Console.WriteLine("Creating DPO fine-tuning job...");
        FineTuningJob fineTuningJob = fineTuningClient.FineTune(
            modelDeploymentName,
            trainFile.Id,
            waitUntilCompleted: false,
            new()
            {
                TrainingMethod = FineTuningTrainingMethod.CreateDirectPreferenceOptimization(
                    epochCount: 1,
                    batchSize: 4,
                    learningRate: 0.0001),
                ValidationFile = validationFile.Id
            });
        Console.WriteLine($"Created DPO fine-tuning job: {fineTuningJob.JobId}");
        Console.WriteLine($"Status: {fineTuningJob.Status}");
        #endregion
    }

    [Test]
    public void DpoFineTuningSync()
    {
        #region Snippet:AI_Projects_FineTuning_DPO_CreateClients
#if SNIPPET
        string trainingFilePath = Environment.GetEnvironmentVariable("TRAINING_FILE_PATH") ?? "data/dpo_training_set.jsonl";
        string validationFilePath = Environment.GetEnvironmentVariable("VALIDATION_FILE_PATH") ?? "data/dpo_validation_set.jsonl";
#else
        string trainingFilePath = Path.Combine(FineTuningHelpers.GetSamplesDataDirectory(), "dpo_training_set.jsonl");
        string validationFilePath = Path.Combine(FineTuningHelpers.GetSamplesDataDirectory(), "dpo_validation_set.jsonl");
#endif
        var endpoint = Environment.GetEnvironmentVariable("PROJECT_ENDPOINT");
        var modelDeploymentName = Environment.GetEnvironmentVariable("MODEL_DEPLOYMENT_NAME");
        AIProjectClient projectClient = new AIProjectClient(new Uri(endpoint), new DefaultAzureCredential());
        ProjectOpenAIClient oaiClient = projectClient.OpenAI;
        OpenAIFileClient fileClient = oaiClient.GetOpenAIFileClient();
        FineTuningClient fineTuningClient = oaiClient.GetFineTuningClient();
        #endregion

        #region Snippet:AI_Projects_FineTuning_DPO_UploadFiles
        // Upload training file
        Console.WriteLine("Uploading training file...");
        using FileStream trainStream = File.OpenRead(trainingFilePath);
        OpenAIFile trainFile = fileClient.UploadFile(
            trainStream,
            "dpo_training_set.jsonl",
            FileUploadPurpose.FineTune);
        Console.WriteLine($"Uploaded training file with ID: {trainFile.Id}");

        // Upload validation file
        Console.WriteLine("Uploading validation file...");
        using FileStream validationStream = File.OpenRead(validationFilePath);
        OpenAIFile validationFile = fileClient.UploadFile(
            validationStream,
            "dpo_validation_set.jsonl",
            FileUploadPurpose.FineTune);
        Console.WriteLine($"Uploaded validation file with ID: {validationFile.Id}");
        #endregion

        // Wait for files to complete processing
        Console.WriteLine("Waiting for files to complete processing...");
        FineTuningHelpers.WaitForFileProcessing(fileClient, trainFile.Id, pollIntervalSeconds: 2);
        FineTuningHelpers.WaitForFileProcessing(fileClient, validationFile.Id, pollIntervalSeconds: 2);

        #region Snippet:AI_Projects_FineTuning_DPO_CreateJob
        // Create DPO fine-tuning job
        Console.WriteLine("Creating DPO fine-tuning job...");
        FineTuningJob fineTuningJob = fineTuningClient.FineTune(
            modelDeploymentName,
            trainFile.Id,
            waitUntilCompleted: false,
            new()
            {
                TrainingMethod = FineTuningTrainingMethod.CreateDirectPreferenceOptimization(
                    epochCount: 1,
                    batchSize: 4,
                    learningRate: 0.0001),
                ValidationFile = validationFile.Id
            });
        Console.WriteLine($"Created DPO fine-tuning job: {fineTuningJob.JobId}");
        Console.WriteLine($"Status: {fineTuningJob.Status}");
        #endregion
    }

    public Sample17_FineTuning_DPO(bool isAsync) : base(isAsync)
    { }
}
