// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Azure.AI.Extensions.OpenAI;
using Azure.AI.Projects.Agents;
using Azure.AI.Projects.Tests.Samples.Evaluation;
using Microsoft.ClientModel.TestFramework;
using Microsoft.ClientModel.TestFramework.Mocks;
using Moq;
using NUnit.Framework;

#pragma warning disable AAIP001

namespace Azure.AI.Projects.Tests;

public class VoiceEvaluationSampleTests
{
    [TestCase("completed")]
    [TestCase("evaluation_failed")]
    [TestCase("upload_failed")]
    [TestCase("registration_failed")]
    [TestCase("delete_failed")]
    public async Task RecordedSampleUploadsAudioBeforeJsonlAndCleansUp(string outcome)
    {
        Mock<AIProjectDatasetsOperations> datasets = new(MockBehavior.Strict);
        List<string> deleted = [];
        string directory = null;
        string jsonlName = null;
        string audioName = null;
        bool evaluated = false;
        datasets.Setup(client => client.UploadFolderAsync(
            It.IsAny<string>(), "1", It.IsAny<string>(), null, null))
            .Returns((string name, string version, string path, string connection, System.Text.RegularExpressions.Regex pattern) =>
            {
                directory = Path.GetDirectoryName(path);
                audioName = name;
                Assert.That(File.Exists(Path.Combine(path, "conversation.wav")), Is.True);
                Assert.That(Directory.GetFiles(path, "*.jsonl"), Is.Empty);
                return Task.FromResult(ClientResult.FromValue(
                    AzureAIProjectsModelFactory.FolderDataset(
                        id: "azureai://sample/data/audio/versions/1",
                        dataUri: new Uri("https://example.blob.core.windows.net/audio/conversation.wav")),
                    new MockPipelineResponse(200)));
            });
        datasets.Setup(client => client.CreateOrUpdateAsync(
            It.IsAny<string>(), "1", It.IsAny<BinaryContent>(), null))
            .Returns((string name, string version, BinaryContent content, RequestOptions options) =>
            {
                using MemoryStream stream = new();
                content.WriteTo(stream, default);
                using JsonDocument folder = JsonDocument.Parse(stream.ToArray());
                Assert.That(name, Is.EqualTo(audioName));
                Assert.That(folder.RootElement.GetProperty("dataUri").GetString(),
                    Is.EqualTo("https://example.blob.core.windows.net/audio/"));
                if (outcome == "registration_failed")
                {
                    throw new InvalidOperationException("Folder registration failed.");
                }
                return Task.FromResult(ClientResult.FromResponse(new MockPipelineResponse(200)));
            });
        datasets.Setup(client => client.UploadFileAsync(It.IsAny<string>(), "1", It.IsAny<string>(), null))
            .Returns((string name, string version, string path, string connection) =>
            {
                jsonlName = name;
                Assert.That(name, Is.Not.EqualTo(audioName));
                using JsonDocument row = JsonDocument.Parse(File.ReadAllText(path));
                JsonElement audio = row.RootElement.GetProperty("conversation_artifacts").GetProperty("audio");
                Assert.That(audio.GetProperty("asset_id").GetString(), Is.EqualTo("azureai://sample/datasets/audio/versions/1"));
                Assert.That(audio.GetProperty("asset_file_path").GetString(), Is.EqualTo("conversation.wav"));
                if (outcome == "upload_failed")
                {
                    throw new InvalidOperationException("Upload failed.");
                }
                return Task.FromResult(ClientResult.FromValue(
                    AzureAIProjectsModelFactory.FileDataset(id: "jsonl-dataset"), new MockPipelineResponse(200)));
            });
        datasets.Setup(client => client.DeleteAsync(It.IsAny<string>(), "1", default(CancellationToken)))
            .Returns((string name, string version, CancellationToken token) =>
            {
                deleted.Add(name);
                if (name == jsonlName && outcome == "delete_failed")
                {
                    throw new InvalidOperationException("Delete failed.");
                }
                return Task.FromResult(ClientResult.FromResponse(new MockPipelineResponse(200)));
            });

        Task Invoke() => Sample_VoiceEvaluation.WithRecordedDatasetAsync(datasets.Object, id =>
        {
            evaluated = true;
            Assert.That(id, Is.EqualTo("jsonl-dataset"));
            Assert.That(deleted, Is.Empty, "Keep inputs until grading finishes.");
            return outcome == "evaluation_failed"
                ? Task.FromException(new InvalidOperationException("Evaluation failed."))
                : Task.CompletedTask;
        });
        if (outcome == "completed")
        {
            await Invoke();
        }
        else
        {
            Assert.ThrowsAsync<InvalidOperationException>(Invoke);
        }
        Assert.That(evaluated, Is.EqualTo(outcome is not ("upload_failed" or "registration_failed")));
        Assert.That(deleted, Is.EqualTo(outcome is "upload_failed" or "registration_failed" ? new[] { audioName } : new[] { jsonlName, audioName }));
        Assert.That(Directory.Exists(directory), Is.False);
    }

    [Test]
    public async Task ExistingRecordedDatasetIsNotUploadedOrDeleted()
    {
        Mock<AIProjectDatasetsOperations> datasets = new(MockBehavior.Strict);
        string used = null;
        await Sample_VoiceEvaluation.WithRecordedDatasetAsync(datasets.Object, id =>
        {
            used = id;
            return Task.CompletedTask;
        }, "existing-dataset");
        Assert.That(used, Is.EqualTo("existing-dataset"));
        datasets.VerifyNoOtherCalls();
    }

    [TestCase(false)]
    [TestCase(true)]
    public async Task SimulationCreatesConfiguredVoiceAgentAndDeletesReturnedVersion(bool fail)
    {
        Mock<AgentAdministrationClient> agents = new(MockBehavior.Strict);
        string createdName = null;
        agents.Setup(client => client.CreateAgentVersionAsync(
            It.IsAny<string>(), It.IsAny<ProjectsAgentVersionCreationOptions>(), null, default))
            .Returns((string name, ProjectsAgentVersionCreationOptions options, string features, CancellationToken token) =>
            {
                createdName = name;
                VoiceAgentDefinition definition = (VoiceAgentDefinition)options.Definition;
                Assert.That(definition.ModelType, Is.EqualTo(VoiceModelType.Managed));
                Assert.That(definition.Model, Is.EqualTo("gpt-realtime"));
                Assert.That(definition.OutputModalities, Does.Contain(VoiceOutputModality.Audio));
                Assert.That(definition.Instructions, Does.Contain("nine PM"));
                Assert.That(definition.Audio.Output.VoiceType, Is.EqualTo(VoiceType.AzureStandard));
                Assert.That(definition.Audio.Output.Voice, Is.EqualTo("en-US-AvaNeural"));
                Assert.That(definition.Store, Is.True);
                return Task.FromResult(ClientResult.FromValue(
                    ProjectsAgentsModelFactory.ProjectsAgentVersion(name: name, version: "7"),
                    new MockPipelineResponse(200)));
            });
        agents.Setup(client => client.DeleteAgentVersionAsync(It.IsAny<string>(), "7", default(CancellationToken)))
            .ReturnsAsync(ClientResult.FromResponse(new MockPipelineResponse(200)));
        Task Invoke() => Sample_VoiceEvaluation.WithVoiceAgentAsync(agents.Object, (name, version) =>
        {
            Assert.That(name, Is.EqualTo(createdName));
            Assert.That(version, Is.EqualTo("7"));
            return fail ? Task.FromException(new InvalidOperationException("Evaluation failed.")) : Task.CompletedTask;
        });
        if (fail)
        {
            Assert.ThrowsAsync<InvalidOperationException>(Invoke);
        }
        else
        {
            await Invoke();
        }
        agents.Verify(client => client.DeleteAgentVersionAsync(createdName, "7", default(CancellationToken)), Times.Once);
    }

    [Test]
    public async Task ExistingVoiceAgentIsNotCreatedOrDeleted()
    {
        Mock<AgentAdministrationClient> agents = new(MockBehavior.Strict);
        string used = null;
        await Sample_VoiceEvaluation.WithVoiceAgentAsync(agents.Object, (name, version) =>
        {
            used = $"{name}:{version}";
            return Task.CompletedTask;
        }, "existing-agent", "3");
        Assert.That(used, Is.EqualTo("existing-agent:3"));
        agents.VerifyNoOtherCalls();
    }

    [Test]
    public async Task ExistingVoiceAgentWithoutVersionUsesLatest()
    {
        Mock<AgentAdministrationClient> agents = new(MockBehavior.Strict);
        ProjectsAgentRecord record = ModelReaderWriter.Read<ProjectsAgentRecord>(BinaryData.FromString(
            """{"id":"agent-id","name":"existing-agent","versions":{"latest":{"id":"version-id","name":"existing-agent","version":"9","created_at":0,"definition":{"kind":"voice","model":"gpt-realtime"}}}}"""));
        agents.Setup(client => client.GetAgentAsync("existing-agent", default(CancellationToken)))
            .ReturnsAsync(ClientResult.FromValue(record, new MockPipelineResponse(200)));
        string used = null;
        await Sample_VoiceEvaluation.WithVoiceAgentAsync(agents.Object, (name, version) =>
        {
            used = $"{name}:{version}";
            return Task.CompletedTask;
        }, "existing-agent");
        Assert.That(used, Is.EqualTo("existing-agent:9"));
        agents.Verify(client => client.GetAgentAsync("existing-agent", default(CancellationToken)), Times.Once);
        agents.VerifyNoOtherCalls();
    }

    [TestCase(false, "completed")]
    [TestCase(true, "completed")]
    [TestCase(false, "polling")]
    [TestCase(false, "failed")]
    [TestCase(false, "errored")]
    [TestCase(false, "empty")]
    [TestCase(false, "timeout")]
    [TestCase(false, "cancel_error")]
    [TestCase(false, "output_cancel_between_pages")]
    [TestCase(false, "output_cancel_last_page")]
    public async Task SampleUsesAudioContractAndAlwaysCleansUp(bool simulation, string outcome)
    {
        List<(string Method, string Path, string Body)> requests = [];
        using CancellationTokenSource cancellation = new();
        int outputPages = 0;
        int pollingDelays = 0;
        MockPipelineTransport transport = new(message =>
        {
            string method = message.Request.Method;
            string path = message.Request.Uri.AbsolutePath;
            using MemoryStream stream = new();
            message.Request.Content?.WriteTo(stream, default);
            string body = System.Text.Encoding.UTF8.GetString(stream.ToArray());
            requests.Add((method, path, body));
            if (method == "DELETE")
            {
                return new MockPipelineResponse(200).WithContent("""{"deleted":true}""");
            }
            if (path.EndsWith("/cancel", StringComparison.Ordinal))
            {
                return outcome == "cancel_error"
                    ? new MockPipelineResponse(400).WithContent("""{"error":{"message":"Cannot cancel"}}""")
                    : new MockPipelineResponse(200).WithContent("""{"status":"canceled"}""");
            }
            if (method == "GET" && path.EndsWith("/runs/evalrun_audio", StringComparison.Ordinal))
            {
                return new MockPipelineResponse(200).WithContent(
                    """{"id":"evalrun_audio","status":"completed","result_counts":{"total":1,"passed":0,"failed":1,"errored":0}}""");
            }
            if (path.EndsWith("/runs", StringComparison.Ordinal))
            {
                return new MockPipelineResponse(201).WithContent(JsonSerializer.Serialize(new
                {
                    id = "evalrun_audio",
                    status = outcome switch
                    {
                        "failed" => "failed",
                        "timeout" or "cancel_error" or "polling" => "queued",
                        _ => "completed"
                    },
                    result_counts = new
                    {
                        total = outcome == "empty" ? 0 : 1,
                        passed = 0,
                        failed = 1,
                        errored = outcome == "errored" ? 1 : 0
                    },
                    error = outcome == "failed" ? new { code = "invalid_audio", message = "Recording unavailable" } : null
                }));
            }
            if (path.EndsWith("/output_items", StringComparison.Ordinal))
            {
                Assert.That(message.CancellationToken.CanBeCanceled, Is.True);
                outputPages++;
                if (outputPages == 2)
                {
                    Assert.That(message.Request.Uri.Query, Does.Contain("after=item_1"));
                }
                if ((outcome == "output_cancel_between_pages" && outputPages == 1) ||
                    (outcome == "output_cancel_last_page" && outputPages == 2))
                {
                    cancellation.Cancel();
                    Assert.That(message.CancellationToken.IsCancellationRequested, Is.True);
                }
                return new MockPipelineResponse(200).WithContent(JsonSerializer.Serialize(new
                {
                    data = new[]
                    {
                        new
                        {
                            id = $"item_{outputPages}",
                            results = new[] { new { name = "task_completion", score = 0, passed = false, reason = "Task not completed" } }
                        }
                    },
                    has_more = outputPages == 1,
                    last_id = $"item_{outputPages}"
                }));
            }
            Assert.That(path, Does.EndWith("/evals"));
            return new MockPipelineResponse(201).WithContent("""{"id":"eval_audio"}""");
        })
        {
            ExpectSyncPipeline = false
        };
        ProjectOpenAIClient openAI = new(
            new Uri("https://example.services.ai.azure.com/api/projects/example"),
            new MockCredential(),
            new ProjectOpenAIClientOptions
            {
                Transport = transport
            });
        BinaryData definition = Sample_VoiceEvaluation.CreateDefinition("audio-judge", simulation
            ? ["task_completion"]
            : ["task_completion", "groundedness", "customer_satisfaction", "coherence"]);
        BinaryData run = simulation
            ? Sample_VoiceEvaluation.CreateSimulationRun("store-assistant", "1", "user-simulator", "en-US-AvaNeural")
            : Sample_VoiceEvaluation.CreateRecordedRun("dataset-id");

        Task<IReadOnlyList<string>> Invoke()
        {
            Task<IReadOnlyList<string>> pending = Sample_VoiceEvaluation.RunEvaluationAsync(
                openAI.GetEvaluationClient(), definition, run, cancellation.Token,
                outcome == "polling" ? token =>
                {
                    token.ThrowIfCancellationRequested();
                    pollingDelays++;
                    return Task.CompletedTask;
                }
            : null);
            if (outcome is "timeout" or "cancel_error")
            {
                cancellation.Cancel();
            }
            return pending;
        }
        if (outcome is "completed" or "polling")
        {
            IReadOnlyList<string> results = await Invoke();
            Assert.That(results.Count, Is.EqualTo(2));
            Assert.That(results[0], Does.Contain("item_1"));
            Assert.That(results[1], Does.Contain("item_2"));
        }
        else if (outcome == "timeout")
        {
            Assert.ThrowsAsync<TaskCanceledException>(Invoke);
        }
        else if (outcome == "cancel_error")
        {
            Assert.ThrowsAsync<ClientResultException>(Invoke);
        }
        else if (outcome is "output_cancel_between_pages" or "output_cancel_last_page")
        {
            Assert.CatchAsync<OperationCanceledException>(Invoke);
        }
        else
        {
            Assert.ThrowsAsync<InvalidOperationException>(Invoke);
        }

        using JsonDocument definitionJson = JsonDocument.Parse(requests[0].Body);
        JsonElement criteria = definitionJson.RootElement.GetProperty("testing_criteria");
        Assert.That(criteria.GetArrayLength(), Is.EqualTo(simulation ? 1 : 4));
        foreach (JsonElement criterion in criteria.EnumerateArray())
        {
            Assert.That(criterion.GetProperty("evaluator_name").GetString(), Does.StartWith("builtin.").And.EndWith("_audio"));
            Assert.That(criterion.GetProperty("initialization_parameters").GetProperty("deployment_name").GetString(), Is.EqualTo("audio-judge"));
            Assert.That(criterion.TryGetProperty("data_mapping", out _), Is.False);
        }
        using JsonDocument runJson = JsonDocument.Parse(requests[1].Body);
        Assert.That(runJson.RootElement.GetProperty("name").GetString(), Is.Not.Empty);
        Assert.That(runJson.RootElement.GetProperty("evaluation_level").GetString(), Is.EqualTo("conversation"));
        Assert.That(runJson.RootElement.TryGetProperty("input_modality", out _), Is.False);
        JsonElement source = runJson.RootElement.GetProperty("data_source");
        if (simulation)
        {
            Assert.That(source.GetProperty("source").GetProperty("type").GetString(), Is.EqualTo("inline_user_conversation_simulation"));
            Assert.That(source.GetProperty("target").GetProperty("name").GetString(), Is.EqualTo("store-assistant"));
            Assert.That(source.GetProperty("model_configuration").GetProperty("model").GetString(), Is.EqualTo("user-simulator"));
            Assert.That(source.GetProperty("model_configuration").GetProperty("voice_model").GetProperty("type").GetString(), Is.EqualTo("azure-standard"));
        }
        else
        {
            Assert.That(source.GetProperty("source").GetProperty("id").GetString(), Is.EqualTo("dataset-id"));
        }
        Assert.That(requests.Last().Method, Is.EqualTo("DELETE"));
        Assert.That(requests.Last().Path, Does.EndWith("/evals/eval_audio"));
        Assert.That(requests.Any(request => request.Path.EndsWith("/cancel", StringComparison.Ordinal)),
            Is.EqualTo(outcome is "timeout" or "cancel_error"));
        Assert.That(outputPages, Is.EqualTo(outcome switch
        {
            "failed" or "timeout" or "cancel_error" => 0,
            "output_cancel_between_pages" => 1,
            _ => 2
        }));
        Assert.That(pollingDelays, Is.EqualTo(outcome == "polling" ? 1 : 0));
    }
}
