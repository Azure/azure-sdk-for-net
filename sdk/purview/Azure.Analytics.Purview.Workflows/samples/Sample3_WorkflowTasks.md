# Workflow tasks

This sample shows how to approve s workflow task.

To get started, make sure you have satisfied all the [Prerequisites][prerequisites] and got all the resources required by [Authenticate the client][authenticate_the_client].

## Create a WorkflowClient

To create a new `WorkflowClient`, you need the endpoint, API version, and credentials from your resource. In the sample below you'll use `UsernamePasswordCredential` to authenticate.
You can set `endpoint`, `username`, `password` etc. based on an environment variable, a configuration setting, or any way that works for your application.

```C# Snippet:Azure_Analytics_Purview_Workflows_CreateClient
Uri endpoint = new Uri(Environment.GetEnvironmentVariable("WORKFLOW_ENDPOINT"));
string clientId = Environment.GetEnvironmentVariable("ClientId");
string tenantId = Environment.GetEnvironmentVariable("TenantId");
string username = Environment.GetEnvironmentVariable("Username");
string password = Environment.GetEnvironmentVariable("Password");

TokenCredential usernamePasswordCredential = new UsernamePasswordCredential(clientId,tenantId, username,password, null);
var client = new PurviewWorkflowServiceClient(endpoint, usernamePasswordCredential);
```

## Approve workflow task

```C# Snippet:Azure_Analytics_Purview_Workflows_ApproveWorkflowTask
// This taskId is an existing workflow task's id, user could get workflow tasks by calling GetWorkflowTasksAsync API.
Guid taskId = new Guid("b129fe16-72d3-4994-9135-b997b9be46e0");

string request = "{\"comment\":\"Thanks!\"}";

Response approveResult = await client.ApproveApprovalTaskAsync(taskId, RequestContent.Create(request));
```
[prerequisites]: https://github.com/Azure/azure-sdk-for-net/sdk/purview/Azure.Analytics.Purview.Workflows/README.md#Prerequisites
[authenticate_the_client]: https://github.com/Azure/azure-sdk-for-net/sdk/purview/Azure.Analytics.Purview.Workflows/README.md#authenticate-the-client
