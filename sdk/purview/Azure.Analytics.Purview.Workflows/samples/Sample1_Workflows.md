# Create, delete, get and list Workflows
This sample shows how to create and get a workflow.

To get started, make sure you have satisfied all the prerequisites and got all the resources required by [README][README].

## Create a WorkflowClient

To create a new `WorkflowClient` you need the endpoint, API version, and credentials from your resource. In the sample below you'll use `UsernamePasswordCredential` to authenticate.
You can set `endpoint`, `username`, `password` etc. based on an environment variable, a configuration setting, or any way that works for your application.

```C# Snippet:Azure_Analytics_Purview_Workflows_CreatePurviewWorkflowClient
    //<client-id>, <tenant-id> are the client ID and tenant ID of the AAD application.
    //<user-name>,<password> are the value of user name and password of an AAD user.
    TokenCredential usernamePasswordCredential = new UsernamePasswordCredential(<client-id>, <tenant-id>, <user-name>,<password>, null);
    var client = new PurviewWorkflowServiceClient(new Uri("https://<purview-account-name>.purview.azure.com"), usernamePasswordCredential)
```

## Create a Workflow

```C# Snippet:Azure_Analytics_Purview_Workflows_CreateWorkflow

    Guid workflowId = Guid.NewGuid();

    string workflow = "{\"name\":\"Create glossary term workflow\",\"description\":\"\",\"triggers\":[{\"type\":\"when_term_creation_is_requested\",\"underGlossaryHierarchy\":\"/glossaries/20031e20-b4df-4a66-a61d-1b0716f3fa48\"}],\"isEnabled\":true,\"actionDag\":{\"actions\":{\"Startandwaitforanapproval\":{\"type\":\"Approval\",\"inputs\":{\"parameters\":{\"approvalType\":\"PendingOnAll\",\"title\":\"ApprovalRequestforCreateGlossaryTerm\",\"assignedTo\":[\"eece94d9-0619-4669-bb8a-d6ecec5220bc\"]}},\"runAfter\":{}},\"Condition\":{\"type\":\"If\",\"expression\":{\"and\":[{\"equals\":[\"@outputs('Startandwaitforanapproval')['body/outcome']\",\"Approved\"]}]},\"actions\":{\"Createglossaryterm\":{\"type\":\"CreateTerm\",\"runAfter\":{}},\"Sendemailnotification\":{\"type\":\"EmailNotification\",\"inputs\":{\"parameters\":{\"emailSubject\":\"GlossaryTermCreate-APPROVED\",\"emailMessage\":\"YourrequestforGlossaryTerm@{triggerBody()['request']['term']['name']}isapproved.\",\"emailRecipients\":[\"@{triggerBody()['request']['requestor']}\"]}},\"runAfter\":{\"Createglossaryterm\":[\"Succeeded\"]}}},\"else\":{\"actions\":{\"Sendrejectemailnotification\":{\"type\":\"EmailNotification\",\"inputs\":{\"parameters\":{\"emailSubject\":\"GlossaryTermCreate-REJECTED\",\"emailMessage\":\"YourrequestforGlossaryTerm@{triggerBody()['request']['term']['name']}isrejected.\",\"emailRecipients\":[\"@{triggerBody()['request']['requestor']}\"]}},\"runAfter\":{}}}},\"runAfter\":{\"Startandwaitforanapproval\":[\"Succeeded\"]}}}}}";

    Response createResult = await client.CreateOrReplaceWorkflowAsync(workflowId, RequestContent.Create(workflow));

```

## Get a Workflow

```C# Snippet:Azure_Analytics_Purview_Workflows_GetWorkflow

    Guid workflowId = new Guid("8af1ecae-16ee-4b2d-8972-00d611dd2f99");

    Response getResult = await client.GetWorkflowAsync(workflowId);
```
[README]: https://github.com/Azure/azure-sdk-for-net/sdk/purview/Azure.Analytics.Purview.Workflows/README.md
