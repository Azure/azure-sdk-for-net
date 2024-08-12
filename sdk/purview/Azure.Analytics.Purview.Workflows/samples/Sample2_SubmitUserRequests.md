# Submit user requests

This sample shows how to submit a user request.

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
var client = new WorkflowsClient(endpoint, usernamePasswordCredential);
```

## Submit a user request

```C# Snippet:Azure_Analytics_Purview_Workflows_SubmitUserRequests
string request = "{\"operations\":[{\"type\":\"CreateTerm\",\"payload\":{\"glossaryTerm\":{\"name\":\"term\",\"anchor\":{\"glossaryGuid\":\"20031e20-b4df-4a66-a61d-1b0716f3fa48\"},\"status\":\"Approved\",\"nickName\":\"term\"}}}],\"comment\":\"Thanks!\"}";

Response submitResult = await client.SubmitAsync(RequestContent.Create(request));
```
