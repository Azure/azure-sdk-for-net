# Workflow runs

This sample shows how to cancel a workflow run.

## Create a WorkflowClient

To create a new `WorkflowClient`, you need the endpoint, API version, and credentials from your resource. In the sample below you'll use `UsernamePasswordCredential` to authenticate.
You can set `endpoint`, `username`, `password` etc. based on an environment variable, a configuration setting, or any way that works for your application.

```C# Snippet:Azure_Analytics_Purview_Workflows_CreateClient
Uri endpoint = new Uri(Environment.GetEnvironmentVariable("WORKFLOW_ENDPOINT"));
TokenCredential credential = new DefaultAzureCredential();

var client = new WorkflowsClient(endpoint, credential);
```

## Cancel a workflow run

```C# Snippet:Azure_Analytics_Purview_Workflows_CancelWorkflowRun
// This workflowRunId represents an existing workflow run. The id can be obtained by calling GetWorkflowRunsAsync API.
Guid workflowRunId = new Guid("4f8d70c3-c09b-4e56-bfd1-8b86c79bd4d9");

string request = "{\"comment\":\"Thanks!\"}";

Response cancelResult = await client.CancelAsync(workflowRunId, RequestContent.Create(request));
```
