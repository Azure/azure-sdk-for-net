// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable enable

using System;
using System.ClientModel;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Azure.AI.OpenAI.FineTuning;
using Azure.AI.OpenAI.Tests.Models;
using Azure.AI.OpenAI.Tests.Utils;
using Azure.AI.OpenAI.Tests.Utils.Config;
using Azure.Core.TestFramework;
using OpenAI.Chat;
using OpenAI.Files;
using OpenAI.FineTuning;

namespace Azure.AI.OpenAI.Tests;

public class FineTuningTests : AoaiTestBase<FineTuningClient>
{
    public FineTuningTests(bool isAsync) : base(isAsync)
    { }

    [Test]
    [Category("Smoke")]
    public void CanCreateClient() => Assert.That(GetTestClient(), Is.InstanceOf<FineTuningClient>());

    [RecordedTest]
    public async Task JobsFineTuning()
    {
        FineTuningClient client = GetTestClient();

        int count = 25;

        await foreach (FineTuningJob job in EnumerateJobsAsync(client))
        {
            if (count-- <= 0)
            {
                break;
            }

            Assert.That(job, Is.Not.Null);
            Assert.That(job.ID, !(Is.Null.Or.Empty));
            Assert.That(job.FineTunedModel, Is.Null.Or.Not.Empty); // this either null or set to some non-empty value
            Assert.That(job.Status, !(Is.Null.Or.Empty));
            Assert.That(job.Object, Is.EqualTo("fine_tuning.job"));
        }
    }

    [RecordedTest]
    public async Task CheckpointsFineTuning()
    {
        string fineTunedModel = GetFineTunedModel();
        FineTuningClient client = GetTestClient();

        // Check if the model exists by searching all jobs
        FineTuningJob job = await EnumerateJobsAsync(client)
            .FirstOrDefaultAsync(j => j.FineTunedModel == fineTunedModel)!;
        Assert.That(job, Is.Not.Null);
        Assert.That(job!.Status, Is.EqualTo("succeeded"));

        int count = 25;
        await foreach (FineTuningCheckpoint checkpoint in EnumerateCheckpoints(client, job.ID))
        {
            if (count-- <= 0)
            {
                break;
            }

            Assert.That(checkpoint, Is.Not.Null);
            Assert.That(checkpoint.ID, !(Is.Null.Or.Empty));
            Assert.That(checkpoint.CreatedAt, Is.GreaterThan(START_2024));
            Assert.That(checkpoint.FineTunedModelCheckpoint, !(Is.Null.Or.Empty));
            Assert.That(checkpoint.Metrics, Is.Not.Null);
            Assert.That(checkpoint.Metrics.Step, Is.GreaterThan(0));
            Assert.That(checkpoint.Metrics.TrainLoss, Is.GreaterThan(0));
            Assert.That(checkpoint.Metrics.TrainMeanTokenAccuracy, Is.GreaterThan(0));
            //Assert.That(checkpoint.Metrics.ValidLoss, Is.GreaterThan(0));
            //Assert.That(checkpoint.Metrics.ValidMeanTokenAccuracy, Is.GreaterThan(0));
            //Assert.That(checkpoint.Metrics.FullValidLoss, Is.GreaterThan(0));
            //Assert.That(checkpoint.Metrics.FullValidMeanTokenAccuracy, Is.GreaterThan(0));
        }
    }

    [RecordedTest]
    public async Task EventsFineTuning()
    {
        string fineTunedModel = GetFineTunedModel();
        FineTuningClient client = GetTestClient();

        // Check if the model exists by searching all jobs
        FineTuningJob job = await EnumerateJobsAsync(client)
            .FirstOrDefaultAsync(j => j.FineTunedModel == fineTunedModel)!;
        Assert.That(job, Is.Not.Null);
        Assert.That(job!.Status, Is.EqualTo("succeeded"));

        HashSet<string> ids = new();

        int count = 25;
        var asyncEnum = EnumerateAsync<FineTuningJobEvent>((after, limit, opt) => client.GetJobEventsAsync(job.ID, after, limit, opt));
        await foreach (FineTuningJobEvent evt in asyncEnum)
        {
            if (count-- <= 0)
            {
                break;
            }

            Assert.That(evt, Is.Not.Null);
            Assert.That(evt.ID, !(Is.Null.Or.Empty));
            Assert.That(evt.Object, Is.EqualTo("fine_tuning.job.event"));
            Assert.That(evt.CreatedAt, Is.GreaterThan(START_2024));
            Assert.That(evt.Level, !(Is.Null.Or.Empty));
            Assert.That(evt.Message, !(Is.Null.Or.Empty));

            bool added = ids.Add(evt.ID);
            Assert.That(added, Is.True, "Duplicate event ID detected {0}", evt.ID);
        }
    }

    [RecordedTest]
    public async Task DeleteFineTuningModel()
    {
        FineTuningClient client = GetTestClient();
        Assert.That(client, Is.Not.Null);
        Assert.That(client, Is.InstanceOf<FineTuningClient>());

        // The service always happily returns HTTP 204 regardless of whether or not the model exists
        bool deleted = await DeleteJobAndVerifyAsync(client, "does-not-exist");
        Assert.That(deleted, Is.True);
    }

    [RecordedTest]
    public async Task CreateAndCancelFineTuning()
    {
        var fineTuningFile = Assets.FineTuning;

        FineTuningClient client = GetTestClient();
        FileClient fileClient = GetTestClientFrom<FileClient>(client);

        // upload training data
        OpenAIFileInfo uploadedFile = await UploadAndWaitForCompleteOrFail(fileClient, fineTuningFile.RelativePath);

        // Create the fine tuning job
        using var requestContent = new FineTuningOptions()
        {
            Model = client.DeploymentOrThrow(),
            TrainingFile = uploadedFile.Id
        }.ToBinaryContent();

        ClientResult result = await client.CreateJobAsync(requestContent);
        FineTuningJob job = ValidateAndParse<FineTuningJob>(result);
        Assert.That(job.ID, !(Is.Null.Or.Empty));

        await using RunOnScopeExit _ = new(async () =>
        {
            bool deleted = await DeleteJobAndVerifyAsync(client, job.ID);
            Assert.True(deleted, "Failed to delete fine tuning job: {0}", job.ID);
        });

        // Wait for some events to become available
        ListResponse<FineTuningJobEvent> events;
        int maxLoops = 10;
        do
        {
            result = await client.GetJobEventsAsync(job.ID, null, 10, new());
            events = ValidateAndParse<ListResponse<FineTuningJobEvent>>(result);

            if (events.Data?.Count > 0)
            {
                Assert.That(events.Data[0], Is.Not.Null);
                Assert.That(events.Data[0].ID, !(Is.Null.Or.Empty));
                Assert.That(events.Data[0].Level, !(Is.Null.Or.Empty));
                Assert.That(events.Data[0].Message, !(Is.Null.Or.Empty));
                Assert.That(events.Data[0].CreatedAt, Is.GreaterThan(START_2024));

                break;
            }

            await Task.Delay(TimeSpan.FromSeconds(2));

        } while (maxLoops-- > 0);

        // Cancel the fine tuning job
        result = await client.CancelJobAsync(job.ID, new());
        job = ValidateAndParse<FineTuningJob>(result);

        // Make sure the job status shows as cancelled
        job = await WaitForJobToEnd(client, job);
        Assert.That(job.Status, Is.EqualTo("cancelled"));
    }

    [RecordedTest]
    [Category("LongRunning")] // CAUTION: This test can take up 30 *minutes* to run in live mode
    public async Task CreateAndDeleteFineTuning()
    {
        var fineTuningFile = Assets.FineTuning;

        FineTuningClient client = GetTestClient();
        FileClient fileClient = GetTestClientFrom<FileClient>(client);

        // upload training data
        OpenAIFileInfo uploadedFile = await UploadAndWaitForCompleteOrFail(fileClient, fineTuningFile.RelativePath);
        Assert.That(uploadedFile.Status, Is.EqualTo(OpenAIFileStatus.Processed));

        // Create the fine tuning job
        using var requestContent = new FineTuningOptions()
        {
            Model = client.DeploymentOrThrow(),
            TrainingFile = uploadedFile.Id
        }.ToBinaryContent();

        ClientResult result = await client.CreateJobAsync(requestContent);
        FineTuningJob job = ValidateAndParse<FineTuningJob>(result);
        Assert.That(job.ID, Is.Not.Null.Or.Empty);
        Assert.That(job.Error, Is.Null);
        Assert.That(job.Status, !(Is.Null.Or.EqualTo("failed").Or.EqualTo("cancelled")));

        // Wait for the fine tuning to complete
        job = await WaitForJobToEnd(client, job);
        Assert.That(job.Status, Is.EqualTo("succeeded"), "Fine tuning did not succeed");
        Assert.That(job.FineTunedModel, Is.Not.Null.Or.Empty);

        // Delete the fine tuned model
        bool deleted = await DeleteJobAndVerifyAsync(client, job.ID);
        Assert.True(deleted, "Failed to delete fine tuning model: {0}", job.FineTunedModel);
    }

    [RecordedTest]
    [Category("LongRunning")] // CAUTION: This test can take around 10 to 15 *minutes* in live mode to run
    public async Task DeployAndChatWithModel()
    {
        string fineTunedModel = GetFineTunedModel();
        FineTuningClient client = GetTestClient();

        AzureDeploymentClient deploymentClient = GetTestClientFrom<AzureDeploymentClient>(client);
        string? deploymentName = null;
        await using RunOnScopeExit _ = new(async () =>
        {
            if (deploymentName != null)
            {
                await deploymentClient.DeleteDeploymentAsync(deploymentName);
            }
        });

        // Check if the model exists by searching all jobs
        FineTuningJob? job = await EnumerateJobsAsync(client)
            .FirstOrDefaultAsync(j => j.FineTunedModel == fineTunedModel);
        Assert.That(job, Is.Not.Null);
        Assert.That(job!.Status, Is.EqualTo("succeeded"));

        // Deploy the model and wait for the deployment to finish
        deploymentName = "azure-ai-openai-test-" + Recording.Random.NewGuid().ToString();
        AzureDeployedModel deployment = await deploymentClient.CreateDeploymentAsync(deploymentName, fineTunedModel);
        Assert.That(deployment, Is.Not.Null);
        Assert.That(deployment.ID, !(Is.Null.Or.Empty));
        Assert.That(deployment.Properties, Is.Not.Null);

        deployment = await WaitUntilReturnLast(
            deployment,
            () => deploymentClient.GetDeploymentAsync(deploymentName),
            (d) =>
            {
                Assert.That(deployment?.Properties?.ProvisioningState, !(Is.Null.Or.Empty));

                return d.Properties.ProvisioningState == "Succeeded"
                    || d.Properties.ProvisioningState == "Failed"
                    || d.Properties.ProvisioningState == "Canceled";
            },
            TimeSpan.FromMinutes(1),
            TimeSpan.FromMinutes(30));

        Assert.That(deployment.Properties.ProvisioningState, Is.EqualTo("Succeeded"));

        // Run a chat completion test
        ChatClient chatClient = GetTestClientFrom<ChatClient>(client, deploymentName);

        ChatCompletion completion = await chatClient.CompleteChatAsync(
        [
            new SystemChatMessage("Convert sports headline to JSON: \"player\" (full name), \"team\", \"sport\", and \"gender\". If more than one return an array. No markdown"),
            new UserChatMessage("Pavleski will not play in 2024-2025 season")
        ]);
        Assert.That(completion, Is.Not.Null);
        Assert.That(completion.FinishReason, Is.EqualTo(ChatFinishReason.Stop));
        Assert.That(completion.Content, Has.Count.GreaterThan(0));
        Assert.That(completion.Content[0].Kind, Is.EqualTo(ChatMessageContentPartKind.Text));
        Assert.That(completion.Content[0].Text, !Is.Null.Or.Empty);

        // we expect a JSON payload as the response so let's try to deserialize it
        using var jsonDoc = JsonDocument.Parse(completion.Content[0].Text, new()
        {
            AllowTrailingCommas = true,
            CommentHandling = JsonCommentHandling.Skip,
            MaxDepth = 2
        });
        JsonElement json = jsonDoc.RootElement;
        if (json.ValueKind == JsonValueKind.Array)
        {
            json = json.EnumerateArray().FirstOrDefault();
        }

        Assert.That(json.ValueKind, Is.EqualTo(JsonValueKind.Object));
        Assert.That(json.EnumerateObject().Select(p => p.Name), Has.Some.Match("(player)|(team)|(sport)|(gender)"));
    }

    #region helper methods

    private string GetFineTunedModel()
    {
        string? model = TestConfig.GetConfig<FineTuningClient>()
            ?.GetValue<string>("fine_tuned_model");
        Assert.That(model, !(Is.Null.Or.Empty), "Failed to find the already fine tuned model to use");
        return model!;
    }

    private async Task<OpenAIFileInfo> UploadAndWaitForCompleteOrFail(FileClient fileClient, string path)
    {
        OpenAIFileInfo uploadedFile = await fileClient.UploadFileAsync(path, FileUploadPurpose.FineTune);
        Validate(uploadedFile);

        uploadedFile = await WaitUntilReturnLast(
            uploadedFile,
            () => fileClient.GetFileAsync(uploadedFile.Id),
            f => f.Status == OpenAIFileStatus.Processed || f.Status == OpenAIFileStatus.Error,
            TimeSpan.FromSeconds(5),
            TimeSpan.FromMinutes(5))
            .ConfigureAwait(false);

        return uploadedFile;
    }

    private Task<FineTuningJob> WaitForJobToEnd(FineTuningClient client, FineTuningJob job)
    {
        RequestOptions options = new();
        string jobId = job.ID;

        // NOTE: Fine tuning jobs can take up 30 minutes to complete so the timeouts here are longer to account for that
        return WaitUntilReturnLast(
            job,
            async () =>
            {
                ClientResult result = await client.GetJobAsync(jobId, options).ConfigureAwait(false);
                return ValidateAndParse<FineTuningJob>(result);
            },
            j => j.Status == "cancelled" || j.Status == "failed" || j.Status == "succeeded",
            TimeSpan.FromMinutes(1),
            TimeSpan.FromMinutes(40));
    }

    private IAsyncEnumerable<FineTuningJob> EnumerateJobsAsync(FineTuningClient client)
        => EnumerateAsync<FineTuningJob>((after, limit, opt) => client.GetJobsAsync(after, limit, opt));

    private IAsyncEnumerable<FineTuningCheckpoint> EnumerateCheckpoints(FineTuningClient client, string jobId)
        => EnumerateAsync<FineTuningCheckpoint>((after, limit, opt) => client.GetJobCheckpointsAsync(jobId, after, limit, opt));

    private async IAsyncEnumerable<T> EnumerateAsync<T>(Func<string?, int?, RequestOptions, Task<ClientResult>> getNextAsync)
        where T : FineTuningModelBase
    {
        int numPerFetch = 10;
        RequestOptions reqOptions = new();

        ClientResult result;
        ListResponse<T> items;
        string? lastId = null;

        do
        {
            result = await getNextAsync(lastId, numPerFetch, reqOptions);
            items = ValidateAndParse<ListResponse<T>>(result);

            if (items.Data?.Count > 0)
            {
                foreach (T item in items.Data)
                {
                    lastId = item.ID;
                    yield return item;
                }
            }
        } while (items.HasMore);
    }

    private async Task<bool> DeleteJobAndVerifyAsync(FineTuningClient client, string jobId, TimeSpan? timeBetween = null, TimeSpan? maxWaitTime = null)
    {
        var stopTime = DateTimeOffset.Now + (maxWaitTime ?? TimeSpan.FromMinutes(1));
        var sleepTime = timeBetween ?? TimeSpan.FromSeconds(2);

        RequestOptions noThrow = new()
        {
            ErrorOptions = ClientErrorBehaviors.NoThrow
        };

        var rawClient = GetOriginal(client);

        bool success = false;
        while (DateTimeOffset.Now < stopTime)
        {
            ClientResult result = IsAsync
                ? await rawClient.DeleteJobAsync(jobId, noThrow).ConfigureAwait(false)
                : rawClient.DeleteJob(jobId, noThrow);
            Assert.That(result, Is.Not.Null);

            // verify the deletion actually succeeded
            result = await client.GetJobAsync(jobId, noThrow).ConfigureAwait(false);
            var rawResponse = result.GetRawResponse();
            success = rawResponse.Status == 404;
            if (success)
            {
                break;
            }

            await Task.Delay(sleepTime).ConfigureAwait(false);
        }

        return success;
    }

    #endregion
}
