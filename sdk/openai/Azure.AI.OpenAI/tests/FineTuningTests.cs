// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using OpenAI.FineTuning;
using OpenAI.TestFramework;
using System;

using System.Threading.Tasks;
using System.ClientModel;
using System.ClientModel.Primitives;
using System.Linq;
using System.Text.Json;
using Azure.AI.OpenAI.Tests.Models;
using Azure.AI.OpenAI.Tests.Utils;
using OpenAI.Chat;
using OpenAI.Files;
using OpenAI.TestFramework.Utils;
using Azure.AI.OpenAI.Files;


#if !AZURE_OPENAI_GA
using Azure.AI.OpenAI.FineTuning;
#endif

namespace Azure.AI.OpenAI.Tests;

#pragma warning disable CS0618

[Category("FineTuning")]
public class FineTuningTests : AoaiTestBase<FineTuningClient>
{
    public FineTuningTests(bool isAsync) : base(isAsync)
    {
    }

    [Test]
    [Category("Smoke")]
    public void CanCreateClient() => Assert.That(GetTestClient(), Is.InstanceOf<FineTuningClient>());

    [RecordedTest]
#if !AZURE_OPENAI_GA
    [TestCase(AzureOpenAIClientOptions.ServiceVersion.V2024_10_01_Preview)]
    [TestCase(AzureOpenAIClientOptions.ServiceVersion.V2024_12_01_Preview)]
    [TestCase(AzureOpenAIClientOptions.ServiceVersion.V2025_01_01_Preview)]
#else
    [TestCase(AzureOpenAIClientOptions.ServiceVersion.V2024_10_21)]
#endif
    [TestCase(null)]
    public async Task CanUploadFileForFineTuning(AzureOpenAIClientOptions.ServiceVersion? version)
    {
        FineTuningClient ftClient = GetTestClient(GetTestClientOptions(version));
        OpenAIFileClient fileClient = GetTestClientFrom<OpenAIFileClient>(ftClient);

        OpenAIFile newFile = await fileClient.UploadFileAsync(
            BinaryData.FromString("this isn't valid input for fine tuning"),
            "intentionally-bad-ft-input.jsonl",
            FileUploadPurpose.FineTune);
        Validate(newFile);

        // In contrast to batch, files uploaded for fine tuning will initially appear in a 'pending' state,
        // transitioning into a terminal as input validation is handled. In this case, because malformed input is
        // uploaded, the terminal status should be 'error'.
        AzureOpenAIFileStatus azureStatus = newFile.GetAzureOpenAIFileStatus();
        Assert.That(azureStatus, Is.EqualTo(AzureOpenAIFileStatus.Pending));

        TimeSpan filePollingInterval = Recording!.Mode == RecordedTestMode.Playback ? TimeSpan.FromMilliseconds(1) : TimeSpan.FromSeconds(5);

        for (int i = 0; i < 60 && (azureStatus == AzureOpenAIFileStatus.Pending || azureStatus == AzureOpenAIFileStatus.Running); i++)
        {
            await Task.Delay(filePollingInterval);
            newFile = await fileClient.GetFileAsync(newFile.Id);
            azureStatus = newFile.GetAzureOpenAIFileStatus();
        }

        Assert.That(azureStatus, Is.EqualTo(AzureOpenAIFileStatus.Error), "Expected file id {0} to be in error state, but it was {1}", newFile.Id, azureStatus);
        Assert.That(newFile.StatusDetails.ToLower(), Does.Contain("validation of jsonl"));
    }

    [RecordedTest]
#if !AZURE_OPENAI_GA
    [TestCase(AzureOpenAIClientOptions.ServiceVersion.V2024_10_01_Preview)]
    [TestCase(AzureOpenAIClientOptions.ServiceVersion.V2024_12_01_Preview)]
    [TestCase(AzureOpenAIClientOptions.ServiceVersion.V2025_01_01_Preview)]
#else
    [TestCase(AzureOpenAIClientOptions.ServiceVersion.V2024_10_21)]
#endif
    //[TestCase(null)]
    public async Task JobsFineTuning(AzureOpenAIClientOptions.ServiceVersion? version)
    {
        FineTuningClient client = GetTestClient(GetTestClientOptions(version));

        int count = 25;

        await foreach (FineTuningJob job in client.GetJobsAsync(options: new() { PageSize = 10 }))
        {
            if (count-- <= 0)
            {
                break;
            }

            Assert.That(job, Is.Not.Null);
            Assert.That(job.Value, Is.Null.Or.Not.Empty); // this either null or set to some non-empty value
            Assert.That(job.Status, Is.Not.Null.Or.Empty);
        }
    }

    [RecordedTest]
#if !AZURE_OPENAI_GA
    [TestCase(AzureOpenAIClientOptions.ServiceVersion.V2024_10_01_Preview)]
    [TestCase(AzureOpenAIClientOptions.ServiceVersion.V2024_12_01_Preview)]
    [TestCase(AzureOpenAIClientOptions.ServiceVersion.V2025_01_01_Preview)]
#else
    [TestCase(AzureOpenAIClientOptions.ServiceVersion.V2024_10_21)]
#endif
    [TestCase(null)]
    public async Task CheckpointsFineTuning(AzureOpenAIClientOptions.ServiceVersion? version)
    {
        AzureFineTuningClient client = (AzureFineTuningClient)UnWrap(GetTestClient(GetTestClientOptions(version)));

        FineTuningJob job = await client.GetJobsAsync(options: new FineTuningJobCollectionOptions() { PageSize = 10 })
            .FirstOrDefaultAsync(j => j.Status == "succeeded");

        //FineTuningJob job = client.GetJob("ftjob-5ad97dff8fd246eeb0934f4fb37e8a76");
        Assert.That(job, Is.Not.Null);
        Assert.That(job.Status, Is.EqualTo("succeeded"));

        Console.WriteLine("Job id: " + job.JobId);
        if (job is AzureFineTuningJob azureJob)
        {
            azureJob.GetCheckpointsAsync();
        }
        var checkpoints = job.GetCheckpointsAsync();

        await checkpoints.ToListAsync();  // Fails

        //FineTuningJob job2 = await FineTuningJob.RehydrateAsync(UnWrap(client), job.JobId);

        //int count = 25;
        //await foreach (FineTuningCheckpoint checkpoint in job2.GetCheckpointsAsync())
        //{
        //    if (count-- <= 0)
        //    {
        //        break;
        //    }

        //    Assert.That(checkpoint, Is.Not.Null);
        //    Assert.That(checkpoint.JobId, !(Is.Null.Or.Empty));
        //    Assert.That(checkpoint.CreatedAt, Is.GreaterThan(START_2024));
        //    Assert.That(checkpoint.CheckpointId, !(Is.Null.Or.Empty));
        //    Assert.That(checkpoint.Metrics, Is.Not.Null);
        //    Assert.That(checkpoint.Metrics.StepNumber, Is.GreaterThan(0));
        //    Assert.That(checkpoint.Metrics.TrainLoss, Is.GreaterThan(0));
        //    Assert.That(checkpoint.Metrics.TrainMeanTokenAccuracy, Is.GreaterThan(0));
        //    //Assert.That(checkpoint.Metrics.ValidLoss, Is.GreaterThan(0));
        //    //Assert.That(checkpoint.Metrics.ValidMeanTokenAccuracy, Is.GreaterThan(0));
        //    //Assert.That(checkpoint.Metrics.FullValidLoss, Is.GreaterThan(0));
        //    //Assert.That(checkpoint.Metrics.FullValidMeanTokenAccuracy, Is.GreaterThan(0));
        //}
    }

    [RecordedTest]
    [AsyncOnly]
#if !AZURE_OPENAI_GA
    [TestCase(AzureOpenAIClientOptions.ServiceVersion.V2024_10_01_Preview)]
    [TestCase(AzureOpenAIClientOptions.ServiceVersion.V2024_12_01_Preview)]
    [TestCase(AzureOpenAIClientOptions.ServiceVersion.V2025_01_01_Preview)]
#else
    [TestCase(AzureOpenAIClientOptions.ServiceVersion.V2024_10_21)]
#endif
    [TestCase(null)]
    public async Task EventsFineTuning(AzureOpenAIClientOptions.ServiceVersion? version)
    {
        // TODO: FIXME: Some bug in Castle Proxy fails to call Azure-specific code when running Sync version
        //AzureFineTuningClient client = (AzureFineTuningClient)UnWrap(GetTestClient(GetTestClientOptions(version)));

        FineTuningClient client = GetTestClient(GetTestClientOptions(version));

        FineTuningJob job = await client.GetJobsAsync().FirstOrDefaultAsync(j => j.Status == FineTuningStatus.Succeeded)!;

        Assert.NotNull(job);
        Assert.AreEqual(job.Status, "succeeded");

        var evt = await job.GetEventsAsync(new() { PageSize = 1 }).FirstOrDefaultAsync();

        Assert.That(evt, Is.Not.Null);
        Assert.That(evt.Id, !(Is.Null.Or.Empty));
        Assert.That(evt.CreatedAt, Is.GreaterThan(START_2024));
        Assert.That(evt.Level, !(Is.Null.Or.Empty));
        Assert.That(evt.Message, !(Is.Null.Or.Empty));
    }

    [RecordedTest]
#if !AZURE_OPENAI_GA
    [TestCase(AzureOpenAIClientOptions.ServiceVersion.V2024_10_01_Preview)]
    [TestCase(AzureOpenAIClientOptions.ServiceVersion.V2024_12_01_Preview)]
    [TestCase(AzureOpenAIClientOptions.ServiceVersion.V2025_01_01_Preview)]
#else
    [TestCase(AzureOpenAIClientOptions.ServiceVersion.V2024_10_21)]
#endif
    [TestCase(null)]
    public async Task CreateCancelDelete(AzureOpenAIClientOptions.ServiceVersion? version)
    {

        FineTuningClient client = GetTestClient(GetTestClientOptions(version));

        OpenAIFileClient fileClient = GetTestClientFrom<OpenAIFileClient>(client);

        var uploadedFile = await UploadAndWaitForCompleteOrFail(fileClient, Assets.FineTuning.RelativePath);

        FineTuningJob job = await client.FineTuneAsync(
            "gpt-4o-mini",
            uploadedFile.Id,
            waitUntilCompleted: false, new() { TrainingMethod = FineTuningTrainingMethod.CreateSupervised() });

        Assert.That(job.JobId, Is.Not.Null.Or.Empty);
        Assert.That(job.Status, !(Is.Null.Or.EqualTo("failed").Or.EqualTo("cancelled")));

        await job.CancelAndUpdateAsync();

        await job.WaitForCompletionAsync();
        
        Assert.That(job.Status, Is.EqualTo("cancelled"), "Fine tuning did not cancel");

        bool deleted = await DeleteJobAndVerifyAsync((AzureFineTuningJob)job, job.JobId, client);
        Assert.True(deleted, "Failed to delete fine tuning model: {0}", job.Value);

        FileDeletionResult success = await fileClient.DeleteFileAsync(uploadedFile.Id);
        Assert.That(success.Deleted, Is.True);
    }

    [RecordedTest]
#if !AZURE_OPENAI_GA
    [TestCase(AzureOpenAIClientOptions.ServiceVersion.V2024_10_01_Preview)]
    [TestCase(AzureOpenAIClientOptions.ServiceVersion.V2024_12_01_Preview)]
    [TestCase(AzureOpenAIClientOptions.ServiceVersion.V2025_01_01_Preview)]
#else
    [TestCase(AzureOpenAIClientOptions.ServiceVersion.V2024_10_21)]
#endif
    [TestCase(null)]
    [Explicit("Each permutation of this test can take around 10 to 15 *minutes* in live mode to run")]
    public async Task DeployAndChatWithModel(AzureOpenAIClientOptions.ServiceVersion? version)
    {
        FineTuningClient client = GetTestClient(GetTestClientOptions(version));

        AzureDeploymentClient deploymentClient = GetTestClientFrom<AzureDeploymentClient>(client);
        string? deploymentName = null;
        await using RunOnScopeExit _ = new(async () =>
        {
            if (deploymentName != null)
            {
                await deploymentClient.DeleteDeploymentAsync(deploymentName);
            }
        });

        FineTuningJob job = await client.GetJobsAsync().FirstOrDefaultAsync(j => j.Status == FineTuningStatus.Succeeded)!;

        if (job.Value == null)
        {
            Assert.Inconclusive("No fine-tuning job found with status 'succeeded'.");
        }

        // Deploy the model and wait for the deployment to finish
        deploymentName = "azure-ai-openai-test-" + Recording?.Random.NewGuid().ToString();
        AzureDeployedModel deployment = await deploymentClient.CreateDeploymentAsync(deploymentName, job.Value!);
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

    private TestClientOptions GetTestClientOptions(AzureOpenAIClientOptions.ServiceVersion? version)
    {
        return version is null ? new TestClientOptions() : new TestClientOptions(version.Value);
    }
    
    private async Task<OpenAIFile> UploadAndWaitForCompleteOrFail(OpenAIFileClient fileClient, string path)
    {
        OpenAIFile uploadedFile = await fileClient.UploadFileAsync(path, FileUploadPurpose.FineTune);
        Validate(uploadedFile);

#pragma warning disable CS0618
        uploadedFile = await WaitUntilReturnLast(
            uploadedFile,
            () => fileClient.GetFileAsync(uploadedFile.Id),
            f => f.Status == FileStatus.Processed || f.Status == FileStatus.Error,
            TimeSpan.FromSeconds(5),
            TimeSpan.FromMinutes(5))
            .ConfigureAwait(false);
#pragma warning restore CS0618

        return uploadedFile;
    }

    private async Task<bool> DeleteJobAndVerifyAsync(AzureFineTuningJob operation, string jobId, FineTuningClient client, TimeSpan? timeBetween = null, TimeSpan? maxWaitTime = null)
    {
        var stopTime = DateTimeOffset.Now + (maxWaitTime ?? TimeSpan.FromMinutes(1));
        TimeSpan sleepTime = timeBetween ?? (Recording!.Mode == RecordedTestMode.Playback ? TimeSpan.FromMilliseconds(1): TimeSpan.FromSeconds(2));

        RequestOptions noThrow = new()
        {
            ErrorOptions = ClientErrorBehaviors.NoThrow
        };


        bool success = false;
        while (DateTimeOffset.Now < stopTime)
        {
            ClientResult result = IsAsync
                ? await operation.DeleteJobAsync(jobId, noThrow).ConfigureAwait(false)
                : operation.DeleteJob(jobId, noThrow);
            Assert.That(result, Is.Not.Null);

            try 
            { 
                await client.GetJobAsync(jobId, noThrow.CancellationToken).ConfigureAwait(false);
            }
            catch (ClientResultException ex) when (ex.Status == 404)
            {
                success = true;
            }

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
