# Submit user requests
This sample shows how to submit user request.

To get started, make sure you have satisfied all the prerequisites and got all the resources required by [README][README].

## Create a WorkflowClient

To create a new `WorkflowClient` you need the endpoint, apiVersion, and credentials from your resource. In the sample below you'll use UsernamePasswordCredential to authenticate.
You can set `endpoint`, `username`, `password` etc. based on an environment variable, a configuration setting, or any way that works for your application.

```C# Snippet:Azure_Analytics_Purview_Workflows_CreatePurviewWorkflowClient
    //<client-id>, <tenant-id> are the client ID and tenant ID of the AAD application.
    //<user-name>,<password> are the value of user name and password of an AAD user.
    TokenCredential usernamePasswordCredential = new UsernamePasswordCredential(<client-id>, <tenant-id>, <user-name>,<password>, null);
    var client = new PurviewWorkflowServiceClient(new Uri("https://<purview-account-name>.purview.azure.com"), usernamePasswordCredential)
```

## Submit a user request

```C# Snippet:Azure_Analytics_Purview_Workflows_SubmitUserRequests

    string request = "{\"operations\":[{\"type\":\"CreateTerm\",\"payload\":{\"glossaryTerm\":{\"name\":\"term\",\"anchor\":{\"glossaryGuid\":\"20031e20-b4df-4a66-a61d-1b0716f3fa48\"},\"status\":\"Approved\",\"nickName\":\"term\"}}}],\"comment\":\"Thanks!\"}";

    Response submitResult = await client.SubmitUserRequestsAsync(RequestContent.Create(request));

```

[README]: https://github.com/Azure/azure-sdk-for-net/sdk/purview/Azure.Analytics.Purview.Workflows/README.md
