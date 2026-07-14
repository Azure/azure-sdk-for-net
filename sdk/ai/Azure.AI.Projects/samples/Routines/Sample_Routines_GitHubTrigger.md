# Sample for Routines GitHubTrigger in Azure.AI.Projects

This sample demonstrates how to use a `GitHubIssueRoutineTrigger`, which schedules a job based on GitHubEvents. In this scenario, run is being started, in response to the Issue creation and assignment.

## Hosted agent deployment
As a prerequisite to this sample, the hosted Agent needs to be deployed. Please follow the steps in the [Hosted agents sample](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/ai/Azure.AI.Extensions.OpenAI/samples/Sample28_HostedAgent.md) and make sure that the Agent is able to generate responses. In the Microsoft foundry choose the "Build" tab and select "Agents" get the created Agent and select "Details" section and copy the Entra Agent identity ID. Assign Agent a "Foundry User" RBAC role for Microsoft foundry, containing an Agent (one level above the project). In the Azure portal, select the Foundry and click on "Access control (IAM)" on the left panel and add the role for an Agent.

## Run a sample.

1. First, create the client and read the environment variables that will be used in the following steps.
  `GITHUB_CONNECTION_NAME` is the name of a GitHub connection how it is shown in the Microsoft Foundry portal.
  `GITHUB_USERNAME` the name of a repository owner. It may be a name of an organization, for example in case of .NET SDK repository https://github.com/Azure/azure-sdk-for-net.git, it will be "Azure".
  `GITHUB_REPOSITORY` is a name of a GitHub repository, in the example above it will be azure-sdk-for-net.


```C# Snippet:Sample_CreateClient_RoutinesGithub
var projectEndpoint = System.Environment.GetEnvironmentVariable("FOUNDRY_PROJECT_ENDPOINT");
string routineName = "sample-routine";
string agentName = System.Environment.GetEnvironmentVariable("HOSTED_AGENT_NAME");
string connectionName = System.Environment.GetEnvironmentVariable("GITHUB_CONNECTION_NAME");
string owner = System.Environment.GetEnvironmentVariable("GITHUB_USERNAME");
string repository = System.Environment.GetEnvironmentVariable("GITHUB_REPOSITORY");
AIProjectClient projectClient = new(endpoint: new Uri(projectEndpoint), tokenProvider: new DefaultAzureCredential());
AIProjectRoutines routinesClient = projectClient.Routines;
```

2. Get the Hosted Agent.

Synchronous sample:
```C# Snippet:Sample_GetHostedAgent_RoutinesGithub_Sync
ProjectsAgentVersion agentVersion = projectClient.AgentAdministrationClient.GetAgent(
    agentName: agentName).Value.GetLatestVersion();
```

Asynchronous sample:
```C# Snippet:Sample_GetHostedAgent_RoutinesGithub_Async
ProjectsAgentVersion agentVersion = (await projectClient.AgentAdministrationClient.GetAgentAsync(
    agentName: agentName)).Value.GetLatestVersion();
```

3. Create a routine with a `GitHubIssueRoutineTrigger` trigger and an agent invocation action.

Synchronous sample:
```C# Snippet:Sample_CreateRoutine_RoutinesGithub_Sync
RoutineAction action = new AgentResponsesApiRoutineAction
{
    AgentName = agentVersion.Name,
};
ProjectsRoutineOptions routineOptions = new(action: action, description: "Routine used by GitHub trigger sample.", enabled: true);
routineOptions.Triggers.Add("on-issue",
    new GitHubIssueRoutineTrigger(
        connectionId: connectionName,
        owner: owner,
        repository: repository,
        issueEvent: GitHubIssueEvent.Opened
    )
);
ProjectsRoutine created = routinesClient.CreateOrUpdate(
    name: routineName,
    options: routineOptions
);
Console.WriteLine($"Created routine: {created.Name} enabled={created.IsEnabled}.");
```

Asynchronous sample:
```C# Snippet:Sample_CreateRoutine_RoutinesGithub_Async
RoutineAction action = new AgentResponsesApiRoutineAction
{
    AgentName = agentVersion.Name,
};
ProjectsRoutineOptions routineOptions = new(action: action, description: "Routine used by GitHub trigger sample.", enabled: true);
routineOptions.Triggers.Add("on-issue",
    new GitHubIssueRoutineTrigger(
        connectionId: connectionName,
        owner: owner,
        repository: repository,
        issueEvent: GitHubIssueEvent.Opened
    )
);
ProjectsRoutine created = await routinesClient.CreateOrUpdateAsync(
    name: routineName,
    options: routineOptions
);
Console.WriteLine($"Created routine: {created.Name} enabled={created.IsEnabled}.");
```

4. For brevity we will create the method, checking the run status and will use it to check if the run has succeeded.

```C# Snippet:Sample_HandleRunError_Routines
protected static void CheckRunResult(RoutineRun completedRun, int minutesWait, bool runCreated)
{
    if (completedRun == null)
    {
        if (runCreated)
        {
            throw new InvalidOperationException($"The run did not complete within {minutesWait} minutes.");
        }
        else
        {
            throw new InvalidOperationException("The run was not created.");
        }
    }
    if (string.Equals(completedRun.Status, "killed", StringComparison.InvariantCultureIgnoreCase))
    {
        throw new InvalidOperationException("The run was forcefully stopped.");
    }
    if (string.Equals(completedRun.Status, "failed", StringComparison.InvariantCultureIgnoreCase))
    {
        throw new InvalidOperationException($"The run has failed with the error. Type: {completedRun.ErrorType} Message: {completedRun.ErrorMessage}.");
    }
}
```

5. Wait for ten minutes. During this time create an issue in the repository and assign it to the account, for which the consent was obtained while connection creation.

Synchronous sample:
```C# Snippet:Sample_WaitForGitHubEventTriggeredTask_RoutinesGithub_Sync
Console.WriteLine($"Please create an issue on {repository} GitHub repository.");
int minutesWait = 10;
Console.WriteLine($"Waiting for run for {minutesWait} minutes...");
DateTime deadline = DateTime.UtcNow + TimeSpan.FromMinutes(minutesWait);
RoutineRun completedRun = null;
bool runWasTriggered = false;
while (DateTime.UtcNow < deadline)
{
    Thread.Sleep(500);
    foreach (RoutineRun run in projectClient.Routines.GetRoutineRuns(name: created.Name))
    {
        runWasTriggered = true;
        Console.WriteLine($"    - run ID {run.Id}, status: {run.Status}, trigger type: {run.TriggerType}, triggered at: {run.TriggeredAt?.ToString() ?? "<Not triggered yet>"}, ended at: {run.EndedAt?.ToString() ?? "<Not ended yet>"}");
        if (string.Equals(run.Status, "finished", StringComparison.InvariantCultureIgnoreCase) ||
            string.Equals(run.Status, "failed", StringComparison.InvariantCultureIgnoreCase) ||
            string.Equals(run.Status, "killed", StringComparison.InvariantCultureIgnoreCase))
        {
            completedRun = run;
        }
    }
    if (completedRun is not null)
    {
        break;
    }
}
CheckRunResult(completedRun, minutesWait, runWasTriggered);
```

Asynchronous sample:
```C# Snippet:Sample_WaitForGitHubEventTriggeredTask_RoutinesGithub_Async
Console.WriteLine($"Please create an issue on {repository} GitHub repository.");
int minutesWait = 10;
Console.WriteLine($"Waiting for run for {minutesWait} minutes...");
DateTime deadline = DateTime.UtcNow + TimeSpan.FromMinutes(minutesWait);
RoutineRun completedRun = null;
bool runWasTriggered = false;
while (DateTime.UtcNow < deadline)
{
    await Task.Delay(500);
    await foreach (RoutineRun run in projectClient.Routines.GetRoutineRunsAsync(name: created.Name))
    {
        runWasTriggered = true;
        Console.WriteLine($"    - run ID {run.Id}, status: {run.Status}, trigger type: {run.TriggerType}, triggered at: {run.TriggeredAt?.ToString() ?? "<Not triggered yet>"}, ended at: {run.EndedAt?.ToString() ?? "<Not ended yet>"}");
        if (string.Equals(run.Status, "finished", StringComparison.InvariantCultureIgnoreCase) ||
            string.Equals(run.Status, "failed", StringComparison.InvariantCultureIgnoreCase) ||
            string.Equals(run.Status, "killed", StringComparison.InvariantCultureIgnoreCase))
        {
            completedRun = run;
        }
    }
    if (completedRun is not null)
    {
        break;
    }
}
CheckRunResult(completedRun, minutesWait, runWasTriggered);
```

6. Retrieve completed job ID.

Synchronous sample:
```C# Snippet:Sample_PrintOutput_RoutinesGithub_Sync
Console.WriteLine($"The response Id is {completedRun.ResponseId}");
//  Currently the response retrieval is not supported.
// ProjectResponsesClient oaiClient = projectClient.ProjectOpenAIClient.GetProjectResponsesClientForAgentEndpoint(agentVersion.Name);
// ResponseResult result = await oaiClient.GetResponseAsync(new GetResponseOptions(responseId: completedRun.ResponseId));
// if (result.Error is not null)
// {
//     throw new InvalidOperationException($"The response, triggered by routine resulted in error. Code: {result.Error.Code}, Message: {result.Error.Message}");
// }
// Console.WriteLine($"Response: {result.GetOutputText()}");
```

Asynchronous sample:
```C# Snippet:Sample_PrintOutput_RoutinesGithub_Async
Console.WriteLine($"The response Id is {completedRun.ResponseId}");
//  Currently the response retrieval is not supported.
// ProjectResponsesClient oaiClient = projectClient.ProjectOpenAIClient.GetProjectResponsesClientForAgentEndpoint(agentVersion.Name);
// ResponseResult result = await oaiClient.GetResponseAsync(new GetResponseOptions(responseId: completedRun.ResponseId));
// if (result.Error is not null)
// {
//     throw new InvalidOperationException($"The response, triggered by routine resulted in error. Code: {result.Error.Code}, Message: {result.Error.Message}");
// }
// Console.WriteLine($"Response: {result.GetOutputText()}");
```


7. Finally, delete the routine.

Synchronous sample:
```C# Snippet:Sample_DeleteRoutine_RoutinesGithub_Sync
routinesClient.Delete(routineName);
Console.WriteLine("Routine deleted");
```

Asynchronous sample:
```C# Snippet:Sample_DeleteRoutine_RoutinesGithub_Async
await routinesClient.DeleteAsync(routineName);
Console.WriteLine("Routine deleted");
```
