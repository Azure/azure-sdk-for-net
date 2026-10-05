// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable
#pragma warning disable OPENAI001 // Type is for evaluation purposes only

using System;
using System.ClientModel;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Azure.AI.Projects.Agents;
using Azure.AI.Projects.Evaluation;
using Microsoft.ClientModel.TestFramework;
using Microsoft.ClientModel.TestFramework.Mocks;
using NUnit.Framework;

namespace Azure.AI.Projects.Tests;
#pragma warning disable AAIP001

/// <summary>
/// Asynchronous recorded tests for evaluator generation job operations using test-proxy.
/// </summary>
public class EvaluatorGenerationJobTests : ProjectsClientTestBase
{
    public EvaluatorGenerationJobTests(bool isAsync) : base(isAsync)
    {
    }

    private static readonly string AGENT_NAME = "cs-agent-for-evaluation";
    private static readonly string INPUT_PREFIX = "cs-test-created-job";
    private static readonly int PAGE_SIZE = 3;

    [Test]
    public void EvaluatorGenerationInputsSerializeAsRequestBody()
    {
        EvaluatorGenerationInputs inputs = new(
            sources: [new PromptEvaluatorGenerationJobSource("Test evaluator generation source")],
            model: "test-model",
            evaluatorName: "test-evaluator")
        {
            EvaluatorDisplayName = "Test evaluator"
        };
        BinaryData body = ModelReaderWriter.Write(inputs, new ModelReaderWriterOptions("W"));
        using JsonDocument document = JsonDocument.Parse(body);
        JsonElement root = document.RootElement;

        Assert.Multiple(() =>
        {
            Assert.That(root.GetProperty("sources").GetArrayLength(), Is.EqualTo(1));
            Assert.That(root.GetProperty("model").GetString(), Is.EqualTo("test-model"));
            Assert.That(root.GetProperty("evaluator_name").GetString(), Is.EqualTo("test-evaluator"));
            Assert.That(root.GetProperty("evaluator_display_name").GetString(), Is.EqualTo("Test evaluator"));
            Assert.That(root.TryGetProperty("inputs", out _), Is.False);
            Assert.That(root.TryGetProperty("id", out _), Is.False);
        });
    }

    [TestCase(false)]
    [TestCase(true)]
    public async Task CreateEvaluatorGenerationJobSendsRequestInputs(bool isAsync)
    {
        MockPipelineTransport transport = new(_ =>
        {
            MockPipelineResponse response = new(201);
            response.SetIsError(false);
            return response.WithContent(
                """
                {"id":"job_test","status":"queued","sources":[],"model":"test-model","evaluator_name":"test-evaluator","created_at":1757700000}
                """);
        })
        {
            ExpectSyncPipeline = !isAsync
        };
        string requestBody = null;
        transport.OnSendingRequest = message =>
        {
            using MemoryStream buffer = new();
            message.Request.Content.WriteTo(buffer, default);
            requestBody = Encoding.UTF8.GetString(buffer.ToArray());
        };
        AIProjectClientOptions options = new() { Transport = transport };
        AIProjectClient client = new(new Uri("https://fake-account.services.ai.azure.com/api/projects/fake-project"), new MockCredential(), options);
        EvaluatorGenerationInputs inputs = new(
            sources: [new PromptEvaluatorGenerationJobSource("Test source")],
            model: "test-model",
            evaluatorName: "test-evaluator");

        ClientResult<EvaluatorGenerationJob> result = isAsync
            ? await client.EvaluatorGenerationJobs.CreateAsync(inputs)
            : client.EvaluatorGenerationJobs.Create(inputs);

        using JsonDocument document = JsonDocument.Parse(requestBody);
        JsonElement root = document.RootElement;
        Assert.Multiple(() =>
        {
            Assert.That(result.GetRawResponse().Status, Is.EqualTo(201));
            Assert.That(result.Value.Id, Is.EqualTo("job_test"));
            Assert.That(result.Value.EvaluatorName, Is.EqualTo("test-evaluator"));
            Assert.That(root.GetProperty("model").GetString(), Is.EqualTo("test-model"));
            Assert.That(root.GetProperty("sources").GetArrayLength(), Is.EqualTo(1));
            Assert.That(root.TryGetProperty("inputs", out _), Is.False);
            Assert.That(transport.Requests, Has.Count.EqualTo(1));
        });
    }

    [RecordedTest]
    public async Task TestEvaluatorGenerationJobCRUD()
    {
        AIProjectClient projectClient = GetTestProjectClient();
        DeclarativeAgentDefinition agentDefinition = new(model: TestEnvironment.FOUNDRY_MODEL_NAME)
        {
            Instructions = "You are a helpful assistant that answers general questions",
        };
        ProjectsAgentVersion agentVersion = await projectClient.AgentAdministrationClient.CreateAgentVersionAsync(
            agentName: AGENT_NAME,
            options: new(agentDefinition));
        // Create
        EvaluatorGenerationInputs job = new(
            sources: [new AgentEvaluatorGenerationJobSource(agentName: agentVersion.Name)],
            model: TestEnvironment.FOUNDRY_MODEL_NAME,
            evaluatorName: "coherence"
        )
        {
            EvaluatorDisplayName = INPUT_PREFIX
        };
        EvaluatorGenerationJob runningJob = await projectClient.EvaluatorGenerationJobs.CreateAsync(job);
        while (runningJob.Status != ProjectsJobStatus.Failed && runningJob.Status != ProjectsJobStatus.Succeeded)
        {
            await Delay(500);
            Console.WriteLine($"Waiting for job ID: {runningJob.Id}...");
            runningJob = await projectClient.EvaluatorGenerationJobs.GetAsync(jobId: runningJob.Id);
        }
        Assert.That(runningJob.Status, Is.EqualTo(ProjectsJobStatus.Succeeded));
        Assert.That(runningJob.Result.Name, Is.Not.Null.And.Not.Empty);
        Assert.That(runningJob.Result.Version, Is.Not.Null.And.Not.Empty);
        // Cancel
        job = new(
            sources: [new PromptEvaluatorGenerationJobSource("Please explain the Maxwell's equation")],
            model: TestEnvironment.FOUNDRY_MODEL_NAME,
            evaluatorName: "violence"
        )
        {
            EvaluatorDisplayName = INPUT_PREFIX
        };
        EvaluatorGenerationJob jobToCancel = await projectClient.EvaluatorGenerationJobs.CreateAsync(job);
        jobToCancel = await projectClient.EvaluatorGenerationJobs.CancelAsync(jobToCancel.Id);
        while (jobToCancel.Status != ProjectsJobStatus.Failed && jobToCancel.Status != ProjectsJobStatus.Succeeded && jobToCancel.Status != ProjectsJobStatus.Cancelled)
        {
            await Delay(500);
            jobToCancel = await projectClient.EvaluatorGenerationJobs.GetAsync(jobId: jobToCancel.Id);
        }
        Assert.That(jobToCancel.Status, Is.EqualTo(ProjectsJobStatus.Cancelled));
        Assert.That(jobToCancel.Result, Is.Null);
        // List
        await Delay(20000);
        HashSet<string> jobs = [.. await projectClient.EvaluatorGenerationJobs.GetAllAsync().Select(x => x.Id).ToArrayAsync()];
        Assert.That(jobs, Does.Contain(runningJob.Id));
        Assert.That(jobs, Does.Contain(jobToCancel.Id));
        // Delete
        await projectClient.EvaluatorGenerationJobs.DeleteAsync(jobToCancel.Id);
        await Delay(20000);
        jobs = [.. await projectClient.EvaluatorGenerationJobs.GetAllAsync().Select(x => x.Id).ToArrayAsync()];
        Assert.That(jobs, Does.Contain(runningJob.Id));
        Assert.That(jobs, Does.Not.Contain(jobToCancel.Id));
    }

    [RecordedTest]
    public async Task TestEvaluatorGenerationJobPagination()
    {
        AIProjectClient projectClient = GetTestProjectClient();
        DeclarativeAgentDefinition agentDefinition = new(model: TestEnvironment.FOUNDRY_MODEL_NAME)
        {
            Instructions = "You are a helpful assistant that answers general questions",
        };
        ProjectsAgentVersion agentVersion = await projectClient.AgentAdministrationClient.CreateAgentVersionAsync(
            agentName: AGENT_NAME,
            options: new(agentDefinition));
        for (int i = 0; i < PAGE_SIZE + 1; i++)
        {
            EvaluatorGenerationInputs job = new(
                sources: [new AgentEvaluatorGenerationJobSource(agentName: agentVersion.Name)],
                model: TestEnvironment.FOUNDRY_MODEL_NAME,
                evaluatorName: "coherence"
            )
            {
                EvaluatorDisplayName = $"{INPUT_PREFIX}-{i}"
            };
            EvaluatorGenerationJob runningJob = await projectClient.EvaluatorGenerationJobs.CreateAsync(job);
            await projectClient.EvaluatorGenerationJobs.CancelAsync(runningJob.Id);
        }
        await Delay(60000);
        List<EvaluatorGenerationJob> records = await projectClient.EvaluatorGenerationJobs.GetAllAsync(limit: PAGE_SIZE, order: "asc").Where(x => x.EvaluatorDisplayName?.StartsWith(INPUT_PREFIX) == true).ToListAsync();
        Assert.That(records.Count, Is.EqualTo(PAGE_SIZE + 1));
        // Go forward.
        List<EvaluatorGenerationJob> forward = await projectClient.EvaluatorGenerationJobs.GetAllAsync(order: "asc", after: records[0].Id, limit: PAGE_SIZE).Where(x => x.EvaluatorDisplayName?.StartsWith(INPUT_PREFIX) == true).ToListAsync();
        Assert.That(forward.Count, Is.EqualTo(records.Count - 1));
        Assert.That(forward[0].Id, Is.EqualTo(records[1].Id));
        Assert.That(forward[forward.Count - 1].Id, Is.EqualTo(records[records.Count - 1].Id));
        //// Two limits:
        // Pagination via before is not supported.
        //forward = await projectClient.EvaluatorGenerationJobs.GetAllAsync( order: "asc", after: records[0].Id, before: records[3].Id, limit: PAGE_SIZE).Where(x => x.EvaluatorDisplayName.StartsWith(INPUT_PREFIX)).ToListAsync();
        //Assert.That(forward.Count, Is.EqualTo(2));
        //Assert.That(forward[0].Id, Is.EqualTo(records[1].Id));
        //Assert.That(forward[1].Id, Is.EqualTo(records[2].Id));
        // Go backwards.
        List<EvaluatorGenerationJob> backwards = await projectClient.EvaluatorGenerationJobs.GetAllAsync(order: "desc", after: records[3].Id, limit: PAGE_SIZE).Where(x => x.EvaluatorDisplayName?.StartsWith(INPUT_PREFIX) == true).ToListAsync();
        Assert.That(backwards.Count, Is.EqualTo(records.Count - 1));
        Assert.That(backwards[0].Id, Is.EqualTo(records[records.Count - 2].Id));
        Assert.That(backwards[backwards.Count - 1].Id, Is.EqualTo(records[0].Id));
        //// Two limits.
        // Pagination via before is not supported.
        //backwards = await projectClient.EvaluatorGenerationJobs.GetAllAsync(order: "desc", after: records[records.Count - 1].Id, before: records[records.Count - 4].Id, limit: PAGE_SIZE).Where(x => x.EvaluatorDisplayName.StartsWith(INPUT_PREFIX)).ToListAsync();
        //Assert.That(backwards.Count, Is.EqualTo(2));
        //Assert.That(backwards[0].Id, Is.EqualTo(records[records.Count - 2].Id));
        //Assert.That(backwards[1].Id, Is.EqualTo(records[records.Count - 3].Id));
    }

    #region Helpers

    #endregion
    #region Cleanup
    [TearDown]
    public async virtual Task Cleanup()
    {
        if (Mode == RecordedTestMode.Playback)
            return;
        Uri connectionString = new(TestEnvironment.FOUNDRY_PROJECT_ENDPOINT);
        AIProjectClient projectClient = new(connectionString, GetTestTokenProvider());
        try
        {
            await projectClient.AgentAdministrationClient.DeleteAgentAsync(AGENT_NAME);
        }
        catch { }
        // Delete Jobs and generated evaluators.
        List<EvaluatorGenerationJob> evaluatorGenerations = await projectClient.EvaluatorGenerationJobs.GetAllAsync().Where(x => x.EvaluatorDisplayName?.StartsWith(INPUT_PREFIX) == true).ToListAsync();
        foreach (EvaluatorGenerationJob job in evaluatorGenerations)
        {
            await projectClient.EvaluatorGenerationJobs.DeleteAsync(job.Id);
            if (job.Result?.Name is not null && job.Result?.Version is not null)
            {
                await projectClient.Evaluators.DeleteVersionAsync(name: job.Result.Name, version: job.Result.Version);
            }
        }
    }
    #endregion
}
