// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Azure.AI.Extensions.OpenAI;
using Azure.AI.Projects.Tests.Samples.Evaluation;
using Microsoft.ClientModel.TestFramework;
using Microsoft.ClientModel.TestFramework.Mocks;
using NUnit.Framework;

namespace Azure.AI.Projects.Tests;

public class VoiceEvaluationSampleTests
{
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
