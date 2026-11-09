# Evaluate voice conversations

These two examples use the existing `EvaluationClient` protocol APIs. They require
service support for the built-in audio evaluators and an eligible audio-input judge
deployment.

The [runnable sample](../../tests/Samples/Evaluation/Sample_VoiceEvaluation.cs) contains
both workflows and their shared helpers. Authenticate with `DefaultAzureCredential`
as in the other project samples. Result parsing and pagination reuse
[EvaluationSampleBase](../../tests/Samples/Evaluation/EvaluationSampleBase.cs).

## Grade existing recordings

Set `FOUNDRY_PROJECT_ENDPOINT`, `FOUNDRY_MODEL_NAME` (the audio judge), and
`FOUNDRY_DATASET_ID` (an existing registered JSONL dataset). No target agent is invoked.
Each JSONL row contains a recording reference; the transcript is optional:

```json
{
  "messages": [
    {"role": "user", "content": "When does the Springfield store close?"},
    {"role": "assistant", "content": "Which Springfield location do you mean?"}
  ],
  "conversation_artifacts": {
    "audio": {
      "asset_id": "azureai://accounts/<account>/projects/<project>/datasets/<dataset>/versions/1",
      "asset_file_path": "recordings/conversation.wav"
    }
  }
}
```

Use one compact object per line in the actual JSONL file. The recording must already
be registered in the same project. Its reference uses `/datasets/` and a relative
member path, not a local file or SAS URL. `FOUNDRY_DATASET_ID` identifies the JSONL
dataset, not the WAV asset. These samples do not upload or delete either input;
see [datasets](../Sample1_Datasets.md) for dataset operations.

The recorded workflow uses task completion, groundedness, customer satisfaction,
and coherence audio evaluators:

```C# Snippet:Sample_VoiceEvaluation_Recorded
string endpoint = GetRequiredVariable("FOUNDRY_PROJECT_ENDPOINT");
string judge = GetRequiredVariable("FOUNDRY_MODEL_NAME");
string datasetId = GetRequiredVariable("FOUNDRY_DATASET_ID");
AIProjectClient project = new(new Uri(endpoint), new DefaultAzureCredential());
EvaluationClient client = project.ProjectOpenAIClient.GetEvaluationClient();

BinaryData definition = CreateDefinition(judge,
    ["task_completion", "groundedness", "customer_satisfaction", "coherence"]);
await RunEvaluationAsync(client, definition, CreateRecordedRun(datasetId));
```

Its run uses conversation scope and the existing JSONL source:

```C# Snippet:Sample_VoiceEvaluation_RecordedRun
internal static BinaryData CreateRecordedRun(string datasetId)
{
    return BinaryData.FromObjectAsJson(new
    {
        name = "Recorded audio conversation evaluation run",
        evaluation_level = "conversation",
        data_source = new
        {
            type = "jsonl",
            source = new { type = "file_id", id = datasetId }
        }
    });
}
```

## Simulate and grade a voice-agent call

Set the endpoint and judge variables above, plus `FOUNDRY_AGENT_NAME`,
`FOUNDRY_AGENT_VERSION`, `FOUNDRY_SIMULATOR_MODEL_NAME`, and `FOUNDRY_SIMULATOR_VOICE`
(for example, `en-US-AvaNeural`). An existing voice agent must be configured for
the store-hours scenario below; replace the seed if your agent serves a different task.

The **target agent** handles the call, the **simulator model** generates user turns,
the **voice** renders simulated-user speech, and the **audio judge** scores the result.

```C# Snippet:Sample_VoiceEvaluation_Simulation
string endpoint = GetRequiredVariable("FOUNDRY_PROJECT_ENDPOINT");
string judge = GetRequiredVariable("FOUNDRY_MODEL_NAME");
string agentName = GetRequiredVariable("FOUNDRY_AGENT_NAME");
string agentVersion = GetRequiredVariable("FOUNDRY_AGENT_VERSION");
string simulatorModel = GetRequiredVariable("FOUNDRY_SIMULATOR_MODEL_NAME");
string simulatorVoice = GetRequiredVariable("FOUNDRY_SIMULATOR_VOICE");
AIProjectClient project = new(new Uri(endpoint), new DefaultAzureCredential());
EvaluationClient client = project.ProjectOpenAIClient.GetEvaluationClient();

BinaryData definition = CreateDefinition(judge, ["task_completion"]);
BinaryData run = CreateSimulationRun(agentName, agentVersion, simulatorModel, simulatorVoice);
await RunEvaluationAsync(client, definition, run);
```

The single inline seed needs no dataset upload. This generates billable
model/agent calls and conversation dataset artifacts:

```C# Snippet:Sample_VoiceEvaluation_SimulationRun
internal static BinaryData CreateSimulationRun(
    string agentName, string agentVersion, string simulatorModel, string simulatorVoice)
{
    return BinaryData.FromObjectAsJson(new
    {
        name = "Voice agent simulation evaluation run",
        evaluation_level = "conversation",
        data_source = new
        {
            type = "azure_ai_user_conversation_simulation",
            source = new
            {
                type = "inline_user_conversation_simulation",
                test_cases = new[]
                {
                    new
                    {
                        test_case_id = "store_hours",
                        test_case_description = "Ask when the store closes today. If asked for a location, say Springfield, Illinois. Do not invent a closing time."
                    }
                }
            },
            target = new { type = "azure_ai_agent", name = agentName, version = agentVersion },
            model_configuration = new
            {
                model = simulatorModel,
                voice_model = new { type = "azure-standard", name = simulatorVoice }
            },
            default_simulation_configuration = new
            {
                max_num_turns = 3,
                conversation_repetitions = 1,
                enable_conversation_dataset_generation = true
            }
        }
    });
}
```

## Configure audio graders

The canonical `builtin.*_audio` evaluator identity selects audio scoring.
Do not send a run-level modality flag, grader `data_mapping`, or client-supplied
`audio_path`; the service obtains the recording from `conversation_artifacts.audio`.

```C# Snippet:Sample_VoiceEvaluation_Definition
internal static BinaryData CreateDefinition(string judge, string[] metrics)
{
    return BinaryData.FromObjectAsJson(new
    {
        name = "Voice conversation evaluation",
        data_source_config = new
        {
            type = "custom",
            item_schema = new
            {
                type = "object",
                properties = new
                {
                    messages = new { type = "array" },
                    conversation_artifacts = new { type = "object" }
                },
                required = new[] { "conversation_artifacts" }
            },
            include_sample_schema = false
        },
        testing_criteria = metrics.Select(metric => new
        {
            type = "azure_ai_evaluator",
            name = metric,
            evaluator_name = $"builtin.{metric}_audio",
            evaluator_version = "1",
            initialization_parameters = new { deployment_name = judge }
        }).ToArray()
    });
}
```

## Read results and clean up

The shared runner polls for up to 10 minutes, prints paginated output items
(numeric scores, reasons and pass/fail) and result counts, then deletes the evaluation.
A low score or failed grading threshold is not an execution error.
On timeout it attempts cancellation, and deletion is still attempted if cancellation fails.
The cleanup uses the client's authenticated pipeline for Foundry's `/cancel` route,
which differs from the cancellation route in the current OpenAI .NET client.
Existing agents and input assets are never deleted. Generated conversation datasets
are not removed by evaluation cleanup.

```C# Snippet:Sample_VoiceEvaluation_Run
internal static async Task RunEvaluationAsync(
    EvaluationClient client, BinaryData definition, BinaryData runData,
    CancellationToken cancellationToken = default)
{
    using CancellationTokenSource timeout = CancellationTokenSource.CreateLinkedTokenSource(cancellationToken);
    timeout.CancelAfter(TimeSpan.FromMinutes(10));
    RequestOptions options = new() { CancellationToken = timeout.Token };
    using BinaryContent definitionContent = BinaryContent.Create(definition);
    ClientResult evaluation = await client.CreateEvaluationAsync(definitionContent, options);
    string evaluationId = ParseClientResult(evaluation, ["id"])["id"];
    string runId = null;
    string status = null;
    try
    {
        using BinaryContent runContent = BinaryContent.Create(runData);
        ClientResult run = await client.CreateEvaluationRunAsync(evaluationId, runContent, options);
        runId = ParseClientResult(run, ["id"])["id"];
        status = ParseClientResult(run, ["status"])["status"];
        Console.WriteLine($"Evaluation: {evaluationId}, run: {runId}");
        while (status is not ("completed" or "failed" or "canceled" or "cancelled"))
        {
            await Task.Delay(TimeSpan.FromSeconds(5), timeout.Token);
            run = await client.GetEvaluationRunAsync(evaluationId, runId, options);
            status = ParseClientResult(run, ["status"])["status"];
        }
        if (status != "completed")
        {
            throw new InvalidOperationException($"Evaluation run {status}: {GetErrorMessageOrEmpty(run)}");
        }
        foreach (string item in await GetResultsListAsync(client, evaluationId, runId))
        {
            Console.WriteLine(item);
        }
        Console.WriteLine(GetResultsCounts(run));
        using JsonDocument document = JsonDocument.Parse(run.GetRawResponse().Content);
        JsonElement counts = document.RootElement.GetProperty("result_counts");
        if (counts.GetProperty("errored").GetInt32() > 0 || counts.GetProperty("total").GetInt32() == 0)
        {
            throw new InvalidOperationException("The evaluation has execution errors or produced no items.");
        }
    }
    finally
    {
        try
        {
            if (runId != null && status is not ("completed" or "failed" or "canceled" or "cancelled"))
            {
                // Foundry's cancellation route differs from the OpenAI SDK's route.
                using PipelineMessage cancel = client.Pipeline.CreateMessage();
                cancel.Request.Method = "POST";
                cancel.Request.Uri = new Uri(
                    $"{client.Endpoint.AbsoluteUri.TrimEnd('/')}/evals/{Uri.EscapeDataString(evaluationId)}/runs/{Uri.EscapeDataString(runId)}/cancel");
                await client.Pipeline.SendAsync(cancel);
                if (cancel.Response.IsError)
                {
                    throw new ClientResultException(cancel.Response);
                }
            }
        }
        finally
        {
            await client.DeleteEvaluationAsync(evaluationId, new RequestOptions());
        }
    }
}
```

Environment variables are required explicitly:

```C# Snippet:Sample_VoiceEvaluation_Environment
private static string GetRequiredVariable(string name) =>
    Environment.GetEnvironmentVariable(name) is string value && !string.IsNullOrWhiteSpace(value)
        ? value
        : throw new InvalidOperationException($"Set {name} before running this sample.");
```
