// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Azure.AI.Extensions.OpenAI;
using Azure.AI.Projects.Tests.Samples.Evaluation;
using Azure.AI.Projects.Tests.Utils;
using Microsoft.ClientModel.TestFramework;
using Microsoft.ClientModel.TestFramework.TestProxy.Admin;
using NUnit.Framework;
using OpenAI.Evals;

namespace Azure.AI.Projects.Tests;

public class VoiceEvaluationRecordedTests : ProjectsClientTestBase
{
    public VoiceEvaluationRecordedTests(bool isAsync) : base(isAsync)
    {
        TestTimeoutInSeconds = 900;

        BodyKeySanitizers.Add(new BodyKeySanitizer(new("$..deployment_name") { Value = "audio-judge" }));
        BodyKeySanitizers.Add(new BodyKeySanitizer(new("$..data_source.source.id") { Value = "sanitized-dataset-id" }));
        BodyKeySanitizers.Add(new BodyKeySanitizer(new("$..target.name") { Value = "voice-agent" }));
        BodyKeySanitizers.Add(new BodyKeySanitizer(new("$..target.version") { Value = "1" }));
        BodyKeySanitizers.Add(new BodyKeySanitizer(new("$..model_configuration.model") { Value = "simulator-model" }));

        BodyRegexSanitizers.Add(new BodyRegexSanitizer(new()
        {
            Regex = @"(?<=https://)[^.\/""\\\s]+(?=\.services\.ai\.azure\.com)",
            Value = "sanitized-host"
        }));
        foreach ((string segment, string replacement) in new[]
        {
            ("subscriptions", ProjectsTestSanitizers.SANITIZED_SUBSCRIPTION),
            ("resourceGroups", ProjectsTestSanitizers.SANITIZED_RESOURCE_GROUP),
            ("accounts", ProjectsTestSanitizers.SANITIZED_ACCOUNT),
            ("projects", ProjectsTestSanitizers.SANITIZED_PROJECT),
            ("datasets", "sanitized-dataset")
        })
        {
            BodyRegexSanitizers.Add(new BodyRegexSanitizer(new()
            {
                Regex = $@"(?<=/{segment}/)[^/""?\\\s]+",
                Value = replacement
            }));
        }
        CustomSanitizers.Add(new GeneralRegexSanitizer(new()
        {
            Regex = @"(?i)(?:[?&]|\\u0026|&amp;)(?:sig|sv|st|se|sp|sr|skoid|sktid|skt|ske|sks|skv)=(?<secret>[^&""\\\s]+)",
            GroupForReplace = "secret",
            Value = "Sanitized"
        }));
    }

    [RecordedTest]
    [AsyncOnly]
    public async Task RecordedConversationAsync()
    {
        string[] metrics = ["task_completion", "groundedness", "customer_satisfaction", "coherence"];
        EvaluationClient client = CreateEvaluationClient(TestEnvironment.FOUNDRY_VOICE_EVALUATION_PROJECT_ENDPOINT);
        IReadOnlyList<string> results = await Sample_VoiceEvaluation.RunEvaluationAsync(
            client,
            Sample_VoiceEvaluation.CreateDefinition(TestEnvironment.FOUNDRY_VOICE_EVALUATION_MODEL_NAME, metrics),
            Sample_VoiceEvaluation.CreateRecordedRun(TestEnvironment.FOUNDRY_DATASET_ID),
            pollingDelay: WaitForNextPollAsync);

        AssertCompletedGraders(results, metrics);
    }

    [RecordedTest]
    [AsyncOnly]
    public async Task VoiceAgentSimulationAsync()
    {
        string[] metrics = ["task_completion"];
        EvaluationClient client = CreateEvaluationClient(TestEnvironment.FOUNDRY_VOICE_SIMULATION_PROJECT_ENDPOINT);
        IReadOnlyList<string> results = await Sample_VoiceEvaluation.RunEvaluationAsync(
            client,
            Sample_VoiceEvaluation.CreateDefinition(TestEnvironment.FOUNDRY_VOICE_SIMULATION_MODEL_NAME, metrics),
            Sample_VoiceEvaluation.CreateSimulationRun(
                TestEnvironment.FOUNDRY_AGENT_NAME,
                TestEnvironment.FOUNDRY_AGENT_VERSION,
                TestEnvironment.FOUNDRY_SIMULATOR_MODEL_NAME,
                TestEnvironment.FOUNDRY_SIMULATOR_VOICE),
            pollingDelay: WaitForNextPollAsync);

        AssertCompletedGraders(results, metrics);
    }

    private EvaluationClient CreateEvaluationClient(string endpoint)
    {
        AIProjectClient project = CreateProxyFromClient(new AIProjectClient(
            new Uri(endpoint), GetTestTokenProvider(), CreateTestProjectClientOptions()));
        // Instrument both layers instead of relying on the unconfigured convenience client.
        ProjectOpenAIClient openAI = project.GetProjectOpenAIClient(CreateTestProjectOpenAIClientOptions());
        return CreateProxyFromClient(openAI.GetEvaluationClient());
    }

    private async Task WaitForNextPollAsync(CancellationToken cancellationToken)
    {
        cancellationToken.ThrowIfCancellationRequested();
        await Delay(5000);
        cancellationToken.ThrowIfCancellationRequested();
    }

    private static void AssertCompletedGraders(IReadOnlyList<string> outputItems, string[] metrics)
    {
        Assert.That(outputItems, Is.Not.Empty);
        foreach (string outputItem in outputItems)
        {
            using JsonDocument document = JsonDocument.Parse(outputItem);
            JsonElement item = document.RootElement;
            AssertNoError(item);
            JsonElement[] results = item.GetProperty("results").EnumerateArray().ToArray();
            Assert.That(results.Select(result => result.GetProperty("name").GetString()), Is.EquivalentTo(metrics));
            foreach (JsonElement result in results)
            {
                Assert.That(result.GetProperty("status").GetString(), Is.EqualTo("completed"));
                Assert.That(result.GetProperty("score").ValueKind, Is.EqualTo(JsonValueKind.Number));
                double score = result.GetProperty("score").GetDouble();
                Assert.That(double.IsNaN(score) || double.IsInfinity(score), Is.False);
                AssertNoError(result);
                if (result.TryGetProperty("sample", out JsonElement sample) && sample.ValueKind == JsonValueKind.Object)
                {
                    AssertNoError(sample);
                }
            }
        }
    }

    private static void AssertNoError(JsonElement value)
    {
        Assert.That(!value.TryGetProperty("error", out JsonElement error) || error.ValueKind == JsonValueKind.Null,
            Is.True, "Evaluation output must not contain an execution error.");
    }
}
