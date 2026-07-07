// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable
#pragma warning disable OPENAI001 // Type is for evaluation purposes only

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.ClientModel.TestFramework;
using NUnit.Framework;

namespace Azure.AI.Projects.Tests;
#pragma warning disable AAIP001

/// <summary>
/// Asynchronous recorded tests for data generation job operations using test-proxy.
/// </summary>
public class DataGenerationJobTests : ProjectsClientTestBase
{
    public DataGenerationJobTests(bool isAsync) : base(isAsync)
    {
    }

    private static readonly string DATASET_NAME = "cs-test-dataset-gen";
    private static readonly string INPUT_PREFIX = "csDatagenInput";
    private static readonly int PAGE_SIZE = 3;

    [RecordedTest]
    public async Task TestDataSetGenerationJobCRUD()
    {
        AIProjectClient projectClient = GetTestProjectClient();

        DataGenerationJob job = new()
        {
            Inputs = GetInputs($"{INPUT_PREFIX}00")
        };
        // Create and get
        DataGenerationJob runningJob = await projectClient.DataGenerationJobs.CreateAsync(job);
        while (runningJob.Status != ProjectsJobStatus.Failed && runningJob.Status != ProjectsJobStatus.Succeeded)
        {
            await Delay();
            runningJob = await projectClient.DataGenerationJobs.GetAsync(jobId: runningJob.Id);
        }
        Assert.That(runningJob.Status, Is.EqualTo(ProjectsJobStatus.Succeeded), $"The job {runningJob.Id} has failed.");
        Assert.That(runningJob.Result.Outputs, Has.Count.EqualTo(1));
        Assert.That(runningJob.Result.Outputs[0], Is.InstanceOf<DatasetDataGenerationJobOutput>());
        DatasetDataGenerationJobOutput dataOutput = runningJob.Result.Outputs[0] as DatasetDataGenerationJobOutput;
        Assert.That(dataOutput.Name, Is.EqualTo(DATASET_NAME));
        // Cancel
        job = new()
        {
            Inputs = GetInputs($"{INPUT_PREFIX}01", 1000)
        };
        DataGenerationJob jobToCancel = await projectClient.DataGenerationJobs.CreateAsync(job);
        jobToCancel = await projectClient.DataGenerationJobs.CancelAsync(jobToCancel.Id);
        while (jobToCancel.Status != ProjectsJobStatus.Failed && jobToCancel.Status != ProjectsJobStatus.Succeeded && jobToCancel.Status != ProjectsJobStatus.Cancelled)
        {
            await Delay(500);
            jobToCancel = await projectClient.DataGenerationJobs.GetAsync(jobId: jobToCancel.Id);
        }
        Assert.That(jobToCancel.Status, Is.EqualTo(ProjectsJobStatus.Cancelled), $"The job {jobToCancel.Id} has failed.");
        // List
        HashSet<string> jobIDs = [.. await projectClient.DataGenerationJobs.GetAllAsync().Select(x => x.Id).ToListAsync()];
        Assert.That(jobIDs, Does.Contain(runningJob.Id));
        Assert.That(jobIDs, Does.Contain(jobToCancel.Id));
        // Delete
        await projectClient.DataGenerationJobs.DeleteAsync(jobId: runningJob.Id);
        await projectClient.DataGenerationJobs.DeleteAsync(jobId: jobToCancel.Id);
        jobIDs = [.. await projectClient.DataGenerationJobs.GetAllAsync().Select(x => x.Id).ToListAsync()];
        Assert.That(jobIDs, Does.Not.Contain(runningJob.Id));
        Assert.That(jobIDs, Does.Not.Contain(jobToCancel.Id));
    }

    [RecordedTest]
    public async Task TestDataGenerationJobPagination()
    {
        AIProjectClient projectClient = GetTestProjectClient();
        for (int i = 0; i < PAGE_SIZE + 1; i++)
        {
            DataGenerationJob job = new()
            {
                Inputs = GetInputs($"{INPUT_PREFIX}0{i}")
            };
            await projectClient.DataGenerationJobs.CreateAsync(job);
        }
        List<DataGenerationJob> records = await projectClient.DataGenerationJobs.GetAllAsync(limit: PAGE_SIZE, order: "asc").Where(x => x.Inputs.Name.StartsWith(INPUT_PREFIX)).ToListAsync();
        Assert.That(records.Count, Is.EqualTo(PAGE_SIZE + 1));
        // Go forward.
        List<DataGenerationJob> forward = await projectClient.DataGenerationJobs.GetAllAsync(order: "asc", after: records[0].Id, limit: PAGE_SIZE).Where(x => x.Inputs.Name.StartsWith(INPUT_PREFIX)).ToListAsync();
        Assert.That(forward.Count, Is.EqualTo(records.Count - 1));
        Assert.That(forward[0].Id, Is.EqualTo(records[1].Id));
        Assert.That(forward[forward.Count - 1].Id, Is.EqualTo(records[records.Count - 1].Id));
        //// Two limits:
        forward = await projectClient.DataGenerationJobs.GetAllAsync( order: "asc", after: records[0].Id, before: records[3].Id, limit: PAGE_SIZE).Where(x => x.Inputs.Name.StartsWith(INPUT_PREFIX)).ToListAsync();
        Assert.That(forward.Count, Is.EqualTo(2));
        Assert.That(forward[0].Id, Is.EqualTo(records[1].Id));
        Assert.That(forward[1].Id, Is.EqualTo(records[2].Id));
        // Go backwards.
        List<DataGenerationJob> backwards = await projectClient.DataGenerationJobs.GetAllAsync(order: "desc", before: records[0].Id, limit: PAGE_SIZE).Where(x => x.Inputs.Name.StartsWith(INPUT_PREFIX)).ToListAsync();
        Assert.That(backwards.Count, Is.EqualTo(records.Count - 1));
        Assert.That(backwards[0].Id, Is.EqualTo(records[records.Count - 1].Id));
        Assert.That(backwards[backwards.Count - 1].Id, Is.EqualTo(records[1].Id));
        // Two limits.
        backwards = await projectClient.DataGenerationJobs.GetAllAsync(order: "desc", after: records[records.Count - 1].Id, before: records[records.Count - 4].Id, limit: PAGE_SIZE).Where(x => x.Inputs.Name.StartsWith(INPUT_PREFIX)).ToListAsync();
        Assert.That(backwards.Count, Is.EqualTo(2));
        Assert.That(backwards[0].Id, Is.EqualTo(records[records.Count - 2].Id));
        Assert.That(backwards[1].Id, Is.EqualTo(records[records.Count - 3].Id));
    }

    #region Helpers
    private DataGenerationJobInputs GetInputs(string name, int samples = 16)
    {
        DataGenerationJobOutputOptions outputOptions = new()
        {
            Name = DATASET_NAME,
            Description = "QnA pairs generated from the Contoso refund policy prompt.",
        };
        outputOptions.Tags["sample"] = DATASET_NAME;
        DataGenerationJobInputs inputs = new(
                name:  name,
                sources: [new PromptDataGenerationJobSource(prompt: "Contoso offers a full refund within 30 days of purchase for any product " +
                        "returned in its original condition. After 30 days, store credit may be " +
                        "issued at the discretion of customer support. Digital goods are " +
                        "non-refundable once downloaded."){
                    Description = "Contoso refund policy"
                }],
                options: new SimpleQnADataGenerationJobOptions(maxSamples: samples)
                {
                    ModelOptions = new(TestEnvironment.FOUNDRY_MODEL_NAME)
                },
                scenario: DataGenerationJobScenario.Evaluation
            )
        {
            OutputOptions = outputOptions
        };
        return inputs;
    }
    #endregion
    #region Cleanup
    [TearDown]
    public async virtual Task Cleanup()
    {
        if (Mode == RecordedTestMode.Playback)
            return;
        Uri connectionString = new(TestEnvironment.FOUNDRY_PROJECT_ENDPOINT);
        AIProjectClient projectClient = new(connectionString, TestEnvironment.Credential);
        // Delete Jobs
        List<DataGenerationJob> dataGenerations = await projectClient.DataGenerationJobs.GetAllAsync().ToListAsync();
        foreach (DataGenerationJob job in dataGenerations)
        {
            if (job.Inputs.Name.StartsWith(INPUT_PREFIX))
            {
                await projectClient.DataGenerationJobs.DeleteAsync(job.Id);
            }
        }
        // Delete generated data sets.
        // Deletion data sets result in 500 error.
        //List<string> versions = await projectClient.Datasets.GetDatasetVersionsAsync(DATASET_NAME).Select(x => x.Version).ToListAsync();
        //foreach (string datasetVersion in versions)
        //{
        //    await projectClient.Datasets.DeleteAsync(name: DATASET_NAME, version: datasetVersion);
        //}
    }
    #endregion
}
