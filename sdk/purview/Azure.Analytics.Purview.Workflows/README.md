# Azure Purview Workflow client library for .NET

Workflows are automated, repeatable business processes that users can create within Microsoft Purview to validate and orchestrate CUD (create, update, delete) operations on their data entities. Enabling these processes allow organizations to track changes, enforce policy compliance, and ensure quality data across their data landscape.

Use the client library for Purview Workflow to:
- Manage workflows
- Submit user requests and monitor workflow runs
- View and respond to workflow tasks

**For more details about how to use workflow, please refer to the [service documentation][product_documentation]**

### Prerequisites

You must have an [Azure subscription][azure_subscription] and a [Purview resource][purview_resource] to use this package.

### Authenticate the client

Since the Workflow service uses an Azure Active Directory (AAD) bearer token for authentication and identification, an email address should be encoded into the token to allow for notification when using Workflow. It is recommended that the [Azure Identity][azure_identity] library be used  with a the [UsernamePasswordCredential][username_password_credential]. Before using the [Azure Identity][azure_identity] library with Workflow, [an application][app_registration] should be registered and used for the clientId passed to the [UsernamePasswordCredential][username_password_credential].

```C# Snippet:Azure_Analytics_Purview_Workflows_CreateClient
Uri endpoint = new Uri(Environment.GetEnvironmentVariable("WORKFLOW_ENDPOINT"));
string clientId = Environment.GetEnvironmentVariable("ClientId");
string tenantId = Environment.GetEnvironmentVariable("TenantId");
string username = Environment.GetEnvironmentVariable("Username");
string password = Environment.GetEnvironmentVariable("Password");

TokenCredential usernamePasswordCredential = new UsernamePasswordCredential(clientId,tenantId, username,password, null);
var client = new PurviewWorkflowServiceClient(endpoint, usernamePasswordCredential);
```

## Examples

The following section provides several code snippets covering some of the most common scenarios, including:
- [Create Workflow](#create-workflow)
- [Submit User Requests](#submit-user-requests)
- [Approve Workflow Task](#approve-workflow-task)
-
### Create workflow

```C# Snippet:Azure_Analytics_Purview_Workflows_CreateWorkflow
Guid workflowId = Guid.NewGuid();

string workflow = "{\"name\":\"Create glossary term workflow\",\"description\":\"\",\"triggers\":[{\"type\":\"when_term_creation_is_requested\",\"underGlossaryHierarchy\":\"/glossaries/20031e20-b4df-4a66-a61d-1b0716f3fa48\"}],\"isEnabled\":true,\"actionDag\":{\"actions\":{\"Startandwaitforanapproval\":{\"type\":\"Approval\",\"inputs\":{\"parameters\":{\"approvalType\":\"PendingOnAll\",\"title\":\"ApprovalRequestforCreateGlossaryTerm\",\"assignedTo\":[\"eece94d9-0619-4669-bb8a-d6ecec5220bc\"]}},\"runAfter\":{}},\"Condition\":{\"type\":\"If\",\"expression\":{\"and\":[{\"equals\":[\"@outputs('Startandwaitforanapproval')['body/outcome']\",\"Approved\"]}]},\"actions\":{\"Createglossaryterm\":{\"type\":\"CreateTerm\",\"runAfter\":{}},\"Sendemailnotification\":{\"type\":\"EmailNotification\",\"inputs\":{\"parameters\":{\"emailSubject\":\"GlossaryTermCreate-APPROVED\",\"emailMessage\":\"YourrequestforGlossaryTerm@{triggerBody()['request']['term']['name']}isapproved.\",\"emailRecipients\":[\"@{triggerBody()['request']['requestor']}\"]}},\"runAfter\":{\"Createglossaryterm\":[\"Succeeded\"]}}},\"else\":{\"actions\":{\"Sendrejectemailnotification\":{\"type\":\"EmailNotification\",\"inputs\":{\"parameters\":{\"emailSubject\":\"GlossaryTermCreate-REJECTED\",\"emailMessage\":\"YourrequestforGlossaryTerm@{triggerBody()['request']['term']['name']}isrejected.\",\"emailRecipients\":[\"@{triggerBody()['request']['requestor']}\"]}},\"runAfter\":{}}}},\"runAfter\":{\"Startandwaitforanapproval\":[\"Succeeded\"]}}}}}";

Response createResult = await client.CreateOrReplaceWorkflowAsync(workflowId, RequestContent.Create(workflow));
```

### Submit user requests

```C# Snippet:Azure_Analytics_Purview_Workflows_SubmitUserRequests
string request = "{\"operations\":[{\"type\":\"CreateTerm\",\"payload\":{\"glossaryTerm\":{\"name\":\"term\",\"anchor\":{\"glossaryGuid\":\"20031e20-b4df-4a66-a61d-1b0716f3fa48\"},\"status\":\"Approved\",\"nickName\":\"term\"}}}],\"comment\":\"Thanks!\"}";

Response submitResult = await client.SubmitUserRequestsAsync(RequestContent.Create(request));
```

### Approve workflow task

```C# Snippet:Azure_Analytics_Purview_Workflows_ApproveWorkflowTask
// This taskId represents an existing workflow task. The id can be obtained by calling GetWorkflowTasksAsync API.
Guid taskId = new Guid("b129fe16-72d3-4994-9135-b997b9be46e0");

string request = "{\"comment\":\"Thanks!\"}";

Response approveResult = await client.ApproveApprovalTaskAsync(taskId, RequestContent.Create(request));
```

<!-- LINKS -->
[product_documentation]: https://learn.microsoft.com/azure/purview/concept-workflow
[azure_subscription]: https://azure.microsoft.com/free/dotnet/
[purview_resource]: https://docs.microsoft.com/azure/purview/create-catalog-portal
[azure_identity]: https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/identity/Azure.Identity/README.md
[app_registration]: https://learn.microsoft.com/azure/active-directory/develop/quickstart-register-app
[username_password_credential]: https://learn.microsoft.com/dotnet/api/azure.identity.usernamepasswordcredential?view=azure-dotnet
