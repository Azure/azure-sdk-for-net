// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable
#pragma warning disable OPENAI001 // Type is for evaluation purposes only

using System;
using System.IO;
using System.Threading.Tasks;
using Azure.AI.Projects.OpenAI;
using Azure.Core.TestFramework;
using Azure.Identity;
using NUnit.Framework;
using OpenAI.Files;
using OpenAI.FineTuning;

namespace Azure.AI.Projects.Tests.Samples.FineTuning;

public partial class Sample17_FineTuning_DPO : SamplesBase<AIProjectsTestEnvironment>
{
    [Test]
    public async Task DpoFineTuningAsync()
    {
        #region Snippet:AI_Projects_FineTuning_DPO_CreateClientsAsync
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
        using FileStream trainStream = File.OpenRead("sdk/ai/Azure.AI.Projects/tests/Samples/FineTuning/data/dpo_training_set.jsonl");
        OpenAIFile trainFile = await fileClient.UploadFileAsync(
            trainStream,
            "dpo_training_set.jsonl",
            FileUploadPurpose.FineTune);
        Console.WriteLine($"Uploaded training file with ID: {trainFile.Id}");

        // Upload validation file
        Console.WriteLine("Uploading validation file...");
        using FileStream validationStream = File.OpenRead("sdk/ai/Azure.AI.Projects/tests/Samples/FineTuning/data/dpo_validation_set.jsonl");
        OpenAIFile validationFile = await fileClient.UploadFileAsync(
            validationStream,
            "dpo_validation_set.jsonl",
            FileUploadPurpose.FineTune);
        Console.WriteLine($"Uploaded validation file with ID: {validationFile.Id}");

        // Note: In production, you should wait for files to complete processing before creating a fine-tuning job.
        // See Sample16_FineTuning_Supervised.md for a WaitForFileProcessingAsync helper method.
        #endregion

        #region Snippet:AI_Projects_FineTuning_DPO_CreateJobAsync
        // Create DPO fine-tuning job
        // Note: The default training type passed here is "Standard".
        // If you need to pass training type explicitly (e.g., "GlobalStandard"),
        // see Sample19_FineTuning_OSS.md for the manual JSON construction approach.
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
        using FileStream trainStream = File.OpenRead("sdk/ai/Azure.AI.Projects/tests/Samples/FineTuning/data/dpo_training_set.jsonl");
        OpenAIFile trainFile = fileClient.UploadFile(
            trainStream,
            "dpo_training_set.jsonl",
            FileUploadPurpose.FineTune);
        Console.WriteLine($"Uploaded training file with ID: {trainFile.Id}");

        // Upload validation file
        Console.WriteLine("Uploading validation file...");
        using FileStream validationStream = File.OpenRead("sdk/ai/Azure.AI.Projects/tests/Samples/FineTuning/data/dpo_validation_set.jsonl");
        OpenAIFile validationFile = fileClient.UploadFile(
            validationStream,
            "dpo_validation_set.jsonl",
            FileUploadPurpose.FineTune);
        Console.WriteLine($"Uploaded validation file with ID: {validationFile.Id}");

        // Note: In production, you should wait for files to complete processing before creating a fine-tuning job.
        // See Sample16_FineTuning_Supervised.md for a WaitForFileProcessing helper method.
        #endregion

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
}
