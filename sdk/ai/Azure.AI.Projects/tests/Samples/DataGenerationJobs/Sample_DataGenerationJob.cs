// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using Azure.Identity;
using Microsoft.ClientModel.TestFramework;
using NUnit.Framework;
using OpenAI.Files;

namespace Azure.AI.Projects.Tests.Samples;

public class Sample_DataGenerationJob: SamplesBase
{
    [Test]
    [AsyncOnly]
    public async Task DataGenerationJobAsync()
    {
        #region Snippet:Sample_CreateClients_DataGenerationJob
#if SNIPPET
        var endpoint = System.Environment.GetEnvironmentVariable("FOUNDRY_PROJECT_ENDPOINT");
#else
        var endpoint = TestEnvironment.FOUNDRY_PROJECT_ENDPOINT;
#endif
        // Create client with debugging enabled
        AIProjectClient projectClient = new(new Uri(endpoint), new DefaultAzureCredential());
        OpenAIFileClient fileClient = projectClient.ProjectOpenAIClient.GetOpenAIFileClient();
        #endregion
        #region Snippet:Sample_UploadFile_DataGenerationJob_Async
        string filePath = "sample_file_for_upload.txt";
        File.WriteAllText(
            path: filePath,
            contents: "The word 'apple' uses the code 442345, while the word 'banana' uses the code 673457.");
        OpenAIFile uploadedFile = await fileClient.UploadFileAsync(filePath: filePath, purpose: FileUploadPurpose.Assistants);
        File.Delete(filePath);
        DataGenerationJob job = new()
        {
            Inputs = new DataGenerationJobInputs(
                name: "sampleGeneration",
                sources: [new FileDataGenerationJobSource(uploadedFile.Id)],
                options: new SimpleQnADataGenerationJobOptions(maxSamples: 10),
                scenario: new DataGenerationJobScenario()
            ),
        };
        #endregion
        #region Snippet:Sample_CreateJob_DataGenerationJob_Async
        DataGenerationJob runningJob = await projectClient.DataGenerationJobs.CreateGenerationJobAsync(job);
        Console.WriteLine($"Created job ID: {runningJob.Id}");
        #endregion
        #region Snippet:Sample_GetJob_DataGenerationJob_Async
        while (runningJob.Status != JobStatus.Failed && runningJob.Status != JobStatus.Succeeded)
        {
            await Task.Delay(500);
            Console.WriteLine($"Waiting for job ID: {runningJob.Id}...");
            runningJob = await projectClient.DataGenerationJobs.GetGenerationJobAsync(jobId: runningJob.Id);
        }
        if (runningJob.Status == JobStatus.Failed)
        {
            throw new InvalidOperationException($"The job {runningJob.Id} has failed.");
        }
        Console.WriteLine($"The job ID: {runningJob.Id} completed");
        #endregion
        #region Snippet:Sample_GetJobOutputs_DataGenerationJob_Async
        if (runningJob.Result.Outputs is FileDataGenerationJobOutput fileOutput)
        {
            Console.WriteLine($"Downloading results file {fileOutput.Filename}.");
            BinaryData outData = await fileClient.DownloadFileAsync(fileOutput.Id);
            Console.WriteLine("=========File Contents=========");
            Console.WriteLine(outData.ToString());
            Console.WriteLine("===============================");
        }
        #endregion
        #region Snippet:Sample_CancelingJob_DataGenerationJob_Async
        job = new()
        {
            Inputs = new DataGenerationJobInputs(
                name: "sampleGeneration",
                sources: [new FileDataGenerationJobSource(uploadedFile.Id)],
                options: new SimpleQnADataGenerationJobOptions(maxSamples: 1000),
                scenario: new DataGenerationJobScenario()
            ),
        };
        DataGenerationJob jobToCancel = await projectClient.DataGenerationJobs.CreateGenerationJobAsync(job);
        jobToCancel = await projectClient.DataGenerationJobs.CancelGenerationJobAsync(jobToCancel.Id);
        while (jobToCancel.Status != JobStatus.Failed && jobToCancel.Status != JobStatus.Succeeded && jobToCancel.Status != JobStatus.Cancelled)
        {
            await Task.Delay(500);
            Console.WriteLine($"Waiting for job {jobToCancel.Id} to cancel...");
            jobToCancel = await projectClient.DataGenerationJobs.GetGenerationJobAsync(jobId: jobToCancel.Id);
        }
        if (jobToCancel.Status != JobStatus.Cancelled)
        {
            throw new InvalidOperationException($"The job {jobToCancel.Id} has failed.");
        }
        Console.WriteLine($"The job {jobToCancel.Id} was canceled.");
        #endregion
        #region Snippet:Sample_ListJob_DataGenerationJob_Async
        await foreach (DataGenerationJob oneJob in projectClient.DataGenerationJobs.GetGenerationJobsAsync(kind: [DataGenerationJobKind.SimpleQna]))
        {
            Console.WriteLine($"Job ID: {oneJob.Id}, Status: {oneJob.Status}.");
        }
        #endregion
        #region Snippet:Sample_DeleteJob_DataGenerationJob_Async
        await projectClient.DataGenerationJobs.DeleteGenerationJobAsync(jobId: runningJob.Id);
        await projectClient.DataGenerationJobs.DeleteGenerationJobAsync(jobId: jobToCancel.Id);
        #endregion
    }

    [Test]
    [SyncOnly]
    public void DataGenerationJobSync()
    {
#if SNIPPET
        var endpoint = System.Environment.GetEnvironmentVariable("FOUNDRY_PROJECT_ENDPOINT");
#else
        var endpoint = TestEnvironment.FOUNDRY_PROJECT_ENDPOINT;
#endif
        // Create client with debugging enabled
        AIProjectClient projectClient = new(new Uri(endpoint), new DefaultAzureCredential());
        OpenAIFileClient fileClient = projectClient.ProjectOpenAIClient.GetOpenAIFileClient();
        #region Snippet:Sample_UploadFile_DataGenerationJob_Sync
        string filePath = "sample_file_for_upload.txt";
        File.WriteAllText(
            path: filePath,
            contents: "The word 'apple' uses the code 442345, while the word 'banana' uses the code 673457.");
        OpenAIFile uploadedFile = fileClient.UploadFile(filePath: filePath, purpose: FileUploadPurpose.Assistants);
        File.Delete(filePath);
        DataGenerationJob job = new()
        {
            Inputs = new DataGenerationJobInputs(
                name: "sampleGeneration",
                sources: [new FileDataGenerationJobSource(uploadedFile.Id)],
                options: new SimpleQnADataGenerationJobOptions(maxSamples: 10),
                scenario: new DataGenerationJobScenario()
            ),
        };
        #endregion
        #region Snippet:Sample_CreateJob_DataGenerationJob_Sync
        DataGenerationJob runningJob = projectClient.DataGenerationJobs.CreateGenerationJob(job);
        Console.WriteLine($"Created job ID: {runningJob.Id}");
        #endregion
        #region Snippet:Sample_GetJob_DataGenerationJob_Sync
        while (runningJob.Status != JobStatus.Failed && runningJob.Status != JobStatus.Succeeded)
        {
            Thread.Sleep(500);
            Console.WriteLine($"Waiting for job ID: {runningJob.Id}...");
            runningJob = projectClient.DataGenerationJobs.GetGenerationJob(jobId: runningJob.Id);
        }
        if (runningJob.Status == JobStatus.Failed)
        {
            throw new InvalidOperationException($"The job {runningJob.Id} has failed.");
        }
        Console.WriteLine($"The job ID: {runningJob.Id} completed");
        #endregion
        #region Snippet:Sample_GetJobOutputs_DataGenerationJob_Sync
        if (runningJob.Result.Outputs is FileDataGenerationJobOutput fileOutput)
        {
            Console.WriteLine($"Downloading results file {fileOutput.Filename}.");
            BinaryData outData = fileClient.DownloadFile(fileOutput.Id);
            Console.WriteLine("=========File Contents=========");
            Console.WriteLine(outData.ToString());
            Console.WriteLine("===============================");
        }
        #endregion
        #region Snippet:Sample_CancelingJob_DataGenerationJob_Sync
        job = new()
        {
            Inputs = new DataGenerationJobInputs(
                name: "sampleGeneration",
                sources: [new FileDataGenerationJobSource(uploadedFile.Id)],
                options: new SimpleQnADataGenerationJobOptions(maxSamples: 1000),
                scenario: new DataGenerationJobScenario()
            ),
        };
        DataGenerationJob jobToCancel = projectClient.DataGenerationJobs.CreateGenerationJob(job);
        jobToCancel = projectClient.DataGenerationJobs.CancelGenerationJob(jobToCancel.Id);
        while (jobToCancel.Status != JobStatus.Failed && jobToCancel.Status != JobStatus.Succeeded && jobToCancel.Status != JobStatus.Cancelled)
        {
            Thread.Sleep(500);
            Console.WriteLine($"Waiting for job {jobToCancel.Id} to cancel...");
            jobToCancel = projectClient.DataGenerationJobs.GetGenerationJob(jobId: jobToCancel.Id);
        }
        if (jobToCancel.Status != JobStatus.Cancelled)
        {
            throw new InvalidOperationException($"The job {jobToCancel.Id} has failed.");
        }
        Console.WriteLine($"The job {jobToCancel.Id} was canceled.");
        #endregion
        #region Snippet:Sample_ListJob_DataGenerationJob_Sync
        foreach (DataGenerationJob oneJob in projectClient.DataGenerationJobs.GetGenerationJobs(kind: [DataGenerationJobKind.SimpleQna]))
        {
            Console.WriteLine($"Job ID: {oneJob.Id}, Status: {oneJob.Status}.");
        }
        #endregion
        #region Snippet:Sample_DeleteJob_DataGenerationJob_Sync
        projectClient.DataGenerationJobs.DeleteGenerationJob(jobId: runningJob.Id);
        projectClient.DataGenerationJobs.DeleteGenerationJob(jobId: jobToCancel.Id);
        #endregion
    }
    public Sample_DataGenerationJob(bool isAsync) : base(isAsync)
    { }
}
