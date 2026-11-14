# Sample of using a trace evaluation rule in Azure.AI.Projects.

This sample demonstrates how to create a scheduled trace evaluation rule. The rule runs every hour and evaluates traces from an existing agent. The project must have Application Insights connected, and the agent must already have traces. The project managed identity needs the "Foundry User" role on the project.

The `ParseClientResult` helper used below is defined in [Sample10_EvaluationsMonitor](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/ai/Azure.AI.Projects/samples/Evaluations/Sample10_EvaluationsMonitor.md); copy it into your sample.

## Run the sample

1. First, we need to create project client and read the environment variables which will be used in the next steps. `FOUNDRY_AGENT_NAME` is the name of an existing agent with traces. We will also create an `EvaluationClient` to create evaluation.

```C# Snippet:Sample_CreateClients_TraceEvaluationRule
var endpoint = System.Environment.GetEnvironmentVariable("FOUNDRY_PROJECT_ENDPOINT");
var modelDeploymentName = System.Environment.GetEnvironmentVariable("FOUNDRY_MODEL_NAME");
var agentName = System.Environment.GetEnvironmentVariable("FOUNDRY_AGENT_NAME");
AIProjectClient projectClient = new(new Uri(endpoint), new DefaultAzureCredential());
EvaluationClient evaluationClient = projectClient.ProjectOpenAIClient.GetEvaluationClient();
```

2. Define the evaluation. It uses the `traces` scenario and the coherence evaluator.

```C# Snippet:Sample_EvaluationConfig_TraceEvaluationRule
private static BinaryData GetTraceEvaluationConfig(string modelDeploymentName)
{
    return BinaryData.FromObjectAsJson(
        new
        {
            name = "Trace Evaluation",
            data_source_config = new
            {
                type = "azure_ai_source",
                scenario = "traces"
            },
            testing_criteria = new[]
            {
                new {
                    type = "azure_ai_evaluator",
                    name = "coherence",
                    evaluator_name = "builtin.coherence",
                    initialization_parameters = new { deployment_name = modelDeploymentName },
                    data_mapping = new { query = "{{item.query}}", response = "{{item.response}}" }
                },
            }
        }
    );
}
```

3. Create the evaluation.

Synchronous sample:
```C# Snippet:Sample_CreateEvaluation_TraceEvaluationRule_Sync
using BinaryContent evaluationDataContent = BinaryContent.Create(GetTraceEvaluationConfig(modelDeploymentName));
ClientResult evaluation = evaluationClient.CreateEvaluation(evaluationDataContent);
Dictionary<string, string> fields = ParseClientResult(evaluation, ["name", "id"]);
string evaluationId = fields["id"];
Console.WriteLine($"Evaluation created (id: {evaluationId}, name: {fields["name"]})");
```

Asynchronous sample:
```C# Snippet:Sample_CreateEvaluation_TraceEvaluationRule_Async
using BinaryContent evaluationDataContent = BinaryContent.Create(GetTraceEvaluationConfig(modelDeploymentName));
ClientResult evaluation = await evaluationClient.CreateEvaluationAsync(evaluationDataContent);
Dictionary<string, string> fields = ParseClientResult(evaluation, ["name", "id"]);
string evaluationId = fields["id"];
Console.WriteLine($"Evaluation created (id: {evaluationId}, name: {fields["name"]})");
```

4. Define the rule. `TraceEvaluationRuleAction` takes the evaluation ID and a trace data source that selects up to 10 traces of the agent. The rule is triggered by a timer, which is set to an hourly `RecurrenceTrigger`.

```C# Snippet:Sample_CreateRule_TraceEvaluationRule
TracesEvalRunDataSource traceSource = new()
{
    AgentName = agentName,
    MaxTraces = 10,
};
TraceEvaluationRuleAction traceAction = new(
    evalId: evaluationId,
    source: ModelReaderWriter.Write(traceSource, ModelReaderWriterOptions.Json));
EvaluationRule traceRule = new(
    action: traceAction, eventType: EvaluationRuleEventType.TimerTrigger, enabled: true)
{
    DisplayName = "My Trace Eval Rule",
    Description = "Hourly trace evaluation of agent traces.",
    Schedule = new RecurrenceTrigger(interval: 1, schedule: new HourlyRecurrenceSchedule()),
};
```

5. Schedule provisioning runs in the background, and the rule cannot be updated or deleted until it finishes. Use a helper that polls for up to five minutes and passes cancellation to each request. On timeout, it reports the rule ID and last status.

Synchronous sample:
```C# Snippet:Sample_WaitForProvisioning_TraceEvaluationRule_Sync
private static EvaluationRule WaitForProvisioning(
    AIProjectClient projectClient,
    string ruleId,
    CancellationToken cancellationToken = default)
{
    TimeSpan timeout = TimeSpan.FromMinutes(5);
    using CancellationTokenSource timeoutCts = CancellationTokenSource.CreateLinkedTokenSource(cancellationToken);
    timeoutCts.CancelAfter(timeout);
    string lastStatus = "unknown";
    try
    {
        EvaluationRule rule = projectClient.EvaluationRules.Get(ruleId, timeoutCts.Token);
        lastStatus = rule.ProvisioningStatus.ToString();
        while (rule.ProvisioningStatus == ScheduleProvisioningStatus.Creating
            || rule.ProvisioningStatus == ScheduleProvisioningStatus.Updating)
        {
            if (timeoutCts.Token.WaitHandle.WaitOne(TimeSpan.FromSeconds(5)))
            {
                timeoutCts.Token.ThrowIfCancellationRequested();
            }
            rule = projectClient.EvaluationRules.Get(ruleId, timeoutCts.Token);
            lastStatus = rule.ProvisioningStatus.ToString();
        }
        return rule;
    }
    catch (OperationCanceledException) when (!cancellationToken.IsCancellationRequested)
    {
        throw new TimeoutException(
            $"Evaluation rule '{ruleId}' provisioning timed out after {timeout}. "
            + $"Last provisioning status: {lastStatus}.");
    }
}
```

Asynchronous sample:
```C# Snippet:Sample_WaitForProvisioning_TraceEvaluationRule_Async
private static async Task<EvaluationRule> WaitForProvisioningAsync(
    AIProjectClient projectClient,
    string ruleId,
    CancellationToken cancellationToken = default)
{
    TimeSpan timeout = TimeSpan.FromMinutes(5);
    using CancellationTokenSource timeoutCts = CancellationTokenSource.CreateLinkedTokenSource(cancellationToken);
    timeoutCts.CancelAfter(timeout);
    string lastStatus = "unknown";
    try
    {
        EvaluationRule rule = await projectClient.EvaluationRules.GetAsync(ruleId, timeoutCts.Token);
        lastStatus = rule.ProvisioningStatus.ToString();
        while (rule.ProvisioningStatus == ScheduleProvisioningStatus.Creating
            || rule.ProvisioningStatus == ScheduleProvisioningStatus.Updating)
        {
            await Task.Delay(TimeSpan.FromSeconds(5), timeoutCts.Token);
            rule = await projectClient.EvaluationRules.GetAsync(ruleId, timeoutCts.Token);
            lastStatus = rule.ProvisioningStatus.ToString();
        }
        return rule;
    }
    catch (OperationCanceledException) when (!cancellationToken.IsCancellationRequested)
    {
        throw new TimeoutException(
            $"Evaluation rule '{ruleId}' provisioning timed out after {timeout}. "
            + $"Last provisioning status: {lastStatus}.");
    }
}
```

6. Create the rule and wait for provisioning to finish.

Synchronous sample:
```C# Snippet:Sample_CreateRuleOnAzure_TraceEvaluationRule_Sync
EvaluationRule createdRule = projectClient.EvaluationRules.CreateOrUpdate(
    id: "my-trace-eval-rule",
    evaluationRule: traceRule);
Console.WriteLine($"Trace evaluation rule created (id: {createdRule.Id}, name: {createdRule.DisplayName})");
// The rule cannot be updated or deleted until its schedule provisioning finishes.
createdRule = WaitForProvisioning(projectClient, createdRule.Id);
Console.WriteLine($"Provisioning status: {createdRule.ProvisioningStatus}");
```

Asynchronous sample:
```C# Snippet:Sample_CreateRuleOnAzure_TraceEvaluationRule_Async
EvaluationRule createdRule = await projectClient.EvaluationRules.CreateOrUpdateAsync(
    id: "my-trace-eval-rule",
    evaluationRule: traceRule);
Console.WriteLine($"Trace evaluation rule created (id: {createdRule.Id}, name: {createdRule.DisplayName})");
// The rule cannot be updated or deleted until its schedule provisioning finishes.
createdRule = await WaitForProvisioningAsync(projectClient, createdRule.Id);
Console.WriteLine($"Provisioning status: {createdRule.ProvisioningStatus}");
```

7. Delete the rule and the evaluation.

Synchronous sample:
```C# Snippet:Sample_Cleanup_TraceEvaluationRule_Sync
projectClient.EvaluationRules.Delete(id: createdRule.Id);
Console.WriteLine($"Trace evaluation rule deleted (id: {createdRule.Id})");
evaluationClient.DeleteEvaluation(evaluationId, new RequestOptions());
```

Asynchronous sample:
```C# Snippet:Sample_Cleanup_TraceEvaluationRule_Async
await projectClient.EvaluationRules.DeleteAsync(id: createdRule.Id);
Console.WriteLine($"Trace evaluation rule deleted (id: {createdRule.Id})");
await evaluationClient.DeleteEvaluationAsync(evaluationId, new RequestOptions());
```
