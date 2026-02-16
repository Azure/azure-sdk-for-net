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

public partial class Sample18_FineTuning_Reinforcement : SamplesBase
{
    [Test]
    public async Task ReinforcementFineTuningAsync()
    {
        #region Snippet:AI_Projects_FineTuning_Reinforcement_CreateClientsAsync
#if SNIPPET
        string trainingFilePath = Environment.GetEnvironmentVariable("TRAINING_FILE_PATH") ?? "data/rft_training_set.jsonl";
        string validationFilePath = Environment.GetEnvironmentVariable("VALIDATION_FILE_PATH") ?? "data/rft_validation_set.jsonl";
#else
        string trainingFilePath = Path.Combine(FineTuningHelpers.GetSamplesDataDirectory(), "rft_training_set.jsonl");
        string validationFilePath = Path.Combine(FineTuningHelpers.GetSamplesDataDirectory(), "rft_validation_set.jsonl");
#endif
        var endpoint = Environment.GetEnvironmentVariable("PROJECT_ENDPOINT");
        var modelDeploymentName = Environment.GetEnvironmentVariable("MODEL_DEPLOYMENT_NAME");
        var graderModelDeploymentName = Environment.GetEnvironmentVariable("GRADER_MODEL_DEPLOYMENT_NAME");
        AIProjectClient projectClient = new AIProjectClient(new Uri(endpoint), new DefaultAzureCredential());
        ProjectOpenAIClient oaiClient = projectClient.OpenAI;
        OpenAIFileClient fileClient = oaiClient.GetOpenAIFileClient();
        FineTuningClient fineTuningClient = oaiClient.GetFineTuningClient();
        #endregion

        #region Snippet:AI_Projects_FineTuning_Reinforcement_UploadFilesAsync
        // Upload training file
        Console.WriteLine("Uploading training file...");
        using FileStream trainStream = File.OpenRead(trainingFilePath);
        OpenAIFile trainFile = await fileClient.UploadFileAsync(
            trainStream,
            "rft_training_set.jsonl",
            FileUploadPurpose.FineTune);
        Console.WriteLine($"Uploaded training file with ID: {trainFile.Id}");

        // Upload validation file
        Console.WriteLine("Uploading validation file...");
        using FileStream validationStream = File.OpenRead(validationFilePath);
        OpenAIFile validationFile = await fileClient.UploadFileAsync(
            validationStream,
            "rft_validation_set.jsonl",
            FileUploadPurpose.FineTune);
        Console.WriteLine($"Uploaded validation file with ID: {validationFile.Id}");
        #endregion

        // Wait for files to complete processing
        Console.WriteLine("Waiting for files to complete processing...");
        await FineTuningHelpers.WaitForFileProcessingAsync(fileClient, trainFile.Id, pollIntervalSeconds: 2);
        await FineTuningHelpers.WaitForFileProcessingAsync(fileClient, validationFile.Id, pollIntervalSeconds: 2);

        #region Snippet:AI_Projects_FineTuning_Reinforcement_CreateJobAsync
        // Create reinforcement fine-tuning job with grader configuration
        Console.WriteLine("Creating reinforcement fine-tuning job...");

        var requestJson = new
        {
            model = modelDeploymentName,
            training_file = trainFile.Id,
            validation_file = validationFile.Id,
            trainingType = "Standard",
            method = new
            {
                type = "reinforcement",
                reinforcement = new
                {
                    grader = new
                    {
                        type = "score_model",
                        name = graderModelDeploymentName,
                        model = graderModelDeploymentName,
                        input = new[]
                        {
                            new
                            {
                                role = "user",
                                content = "Evaluate the model's response based on correctness and quality. Rate from 0 to 10."
                            }
                        },
                        range = new[] { 0.0, 10.0 }
                    },
                    hyperparameters = new
                    {
                        n_epochs = 1,
                        batch_size = 4,
                        learning_rate_multiplier = 2,
                        eval_interval = 5,
                        eval_samples = 2,
                        reasoning_effort = "medium"
                    }
                }
            }
        };

        string jsonBody = JsonSerializer.Serialize(requestJson);

        BinaryContent content = BinaryContent.Create(BinaryData.FromString(jsonBody));
        FineTuningJob fineTuningJob = await fineTuningClient.FineTuneAsync(content, waitUntilCompleted: false, options: null);

        Console.WriteLine($"Created reinforcement fine-tuning job: {fineTuningJob.JobId}");
        Console.WriteLine($"Status: {fineTuningJob.Status}");
        #endregion
    }

    [Test]
    public void ReinforcementFineTuningSync()
    {
        #region Snippet:AI_Projects_FineTuning_Reinforcement_CreateClients
#if SNIPPET
        string trainingFilePath = Environment.GetEnvironmentVariable("TRAINING_FILE_PATH") ?? "data/rft_training_set.jsonl";
        string validationFilePath = Environment.GetEnvironmentVariable("VALIDATION_FILE_PATH") ?? "data/rft_validation_set.jsonl";
#else
        string trainingFilePath = Path.Combine(FineTuningHelpers.GetSamplesDataDirectory(), "rft_training_set.jsonl");
        string validationFilePath = Path.Combine(FineTuningHelpers.GetSamplesDataDirectory(), "rft_validation_set.jsonl");
#endif
        var endpoint = Environment.GetEnvironmentVariable("PROJECT_ENDPOINT");
        var modelDeploymentName = Environment.GetEnvironmentVariable("MODEL_DEPLOYMENT_NAME");
        var graderModelDeploymentName = Environment.GetEnvironmentVariable("GRADER_MODEL_DEPLOYMENT_NAME");
        AIProjectClient projectClient = new AIProjectClient(new Uri(endpoint), new DefaultAzureCredential());
        ProjectOpenAIClient oaiClient = projectClient.OpenAI;
        OpenAIFileClient fileClient = oaiClient.GetOpenAIFileClient();
        FineTuningClient fineTuningClient = oaiClient.GetFineTuningClient();
        #endregion

        #region Snippet:AI_Projects_FineTuning_Reinforcement_UploadFiles
        // Upload training file
        Console.WriteLine("Uploading training file...");
        using FileStream trainStream = File.OpenRead(trainingFilePath);
        OpenAIFile trainFile = fileClient.UploadFile(
            trainStream,
            "rft_training_set.jsonl",
            FileUploadPurpose.FineTune);
        Console.WriteLine($"Uploaded training file with ID: {trainFile.Id}");

        // Upload validation file
        Console.WriteLine("Uploading validation file...");
        using FileStream validationStream = File.OpenRead(validationFilePath);
        OpenAIFile validationFile = fileClient.UploadFile(
            validationStream,
            "rft_validation_set.jsonl",
            FileUploadPurpose.FineTune);
        Console.WriteLine($"Uploaded validation file with ID: {validationFile.Id}");
        #endregion

        // Wait for files to complete processing
        Console.WriteLine("Waiting for files to complete processing...");
        FineTuningHelpers.WaitForFileProcessing(fileClient, trainFile.Id, pollIntervalSeconds: 2);
        FineTuningHelpers.WaitForFileProcessing(fileClient, validationFile.Id, pollIntervalSeconds: 2);

        #region Snippet:AI_Projects_FineTuning_Reinforcement_CreateJob
        // Create reinforcement fine-tuning job with grader configuration
        Console.WriteLine("Creating reinforcement fine-tuning job...");

        var requestJson = new
        {
            model = modelDeploymentName,
            training_file = trainFile.Id,
            validation_file = validationFile.Id,
            trainingType = "Standard",
            method = new
            {
                type = "reinforcement",
                reinforcement = new
                {
                    grader = new
                    {
                        type = "score_model",
                        name = graderModelDeploymentName,
                        model = graderModelDeploymentName,
                        input = new[]
                        {
                            new
                            {
                                role = "user",
                                content = "Evaluate the model's response based on correctness and quality. Rate from 0 to 10."
                            }
                        },
                        range = new[] { 0.0, 10.0 }
                    },
                    hyperparameters = new
                    {
                        n_epochs = 1,
                        batch_size = 4,
                        learning_rate_multiplier = 2,
                        eval_interval = 5,
                        eval_samples = 2,
                        reasoning_effort = "medium"
                    }
                }
            }
        };

        string jsonBody = JsonSerializer.Serialize(requestJson);

        BinaryContent content = BinaryContent.Create(BinaryData.FromString(jsonBody));
        FineTuningJob fineTuningJob = fineTuningClient.FineTune(content, waitUntilCompleted: false, options: null);

        Console.WriteLine($"Created reinforcement fine-tuning job: {fineTuningJob.JobId}");
        Console.WriteLine($"Status: {fineTuningJob.Status}");
        #endregion
    }

    public Sample18_FineTuning_Reinforcement(bool isAsync) : base(isAsync)
    { }
}
