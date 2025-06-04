# Workflow tasks

This sample shows how to approve s workflow task.

## Create a WorkflowClient

To create a new `WorkflowClient`, you need the endpoint, API version, and credentials from your resource. In the sample below you'll use `UsernamePasswordCredential` to authenticate.
You can set `endpoint`, `username`, `password` etc. based on an environment variable, a configuration setting, or any way that works for your application.

```C# Snippet:Azure_Analytics_Purview_Workflows_CreateClient
Uri endpoint = new Uri(Environment.GetEnvironmentVariable("WORKFLOW_ENDPOINT"));
TokenCredential credential = new DefaultAzureCredential();

var client = new WorkflowsClient(endpoint, credential);
```

## Approve workflow task

```C# Snippet:Azure_Analytics_Purview_Workflows_ApproveWorkflowTask
// This taskId represents an existing workflow task. The id can be obtained by calling GetWorkflowTasksAsync API.
Guid taskId = new Guid("b129fe16-72d3-4994-9135-b997b9be46e0");

string request = "{\"comment\":\"Thanks!\"}";

Response approveResult = await client.ApproveAsync(taskId, RequestContent.Create(request));
```
