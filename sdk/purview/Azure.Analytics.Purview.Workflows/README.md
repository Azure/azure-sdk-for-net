# Azure Purview Workflow client library for .NET

Workflows are automated, repeatable business processes that users can create within Microsoft Purview to validate and orchestrate CUD (create, update, delete) operations on their data entities. Enabling these processes allow organizations to track changes, enforce policy compliance, and ensure quality data across their data landscape.

Use the client library for Purview Workflow to:

- Manage workflows
- Submit user requests and monitor workflow runs
- View and respond to workflow tasks

**For more details about how to use workflow, please refer to the [service documentation][product_documentation]**

## Getting started

### Install the package

```dotnetcli
dotnet add package Azure.Analytics.Purview.Workflows --prerelease
```

### Prerequisites

You must have an [Azure subscription][azure_subscription] and a [Purview resource][purview_resource] to use this package.

### Authenticate the client

Since the Workflow service uses an Azure Active Directory (AAD) bearer token for authentication and identification, an email address should be encoded into the token to allow for notification when using Workflow. It is recommended that the [Azure Identity][azure_identity] library be used  with a the [DefaultAzureCredential][default_azure_credential]. Before using the [Azure Identity][azure_identity] library with Workflow, [an application][app_registration] should be registered and set the information obtained from the application, such as AZURE_CLIENT_ID, AZURE_TENANT_ID, and AZURE_CLIENT_SECRET, as environment variables. Then use [DefaultAzureCredential][default_azure_credential] for authentication. For more authentication details, refer to [MFA][multifactor_authentication].

```C# Snippet:Azure_Analytics_Purview_Workflows_CreateClient
Uri endpoint = new Uri(Environment.GetEnvironmentVariable("WORKFLOW_ENDPOINT"));
TokenCredential credential = new DefaultAzureCredential();

var client = new WorkflowsClient(endpoint, credential);
```

## Examples

The following section provides several code snippets covering some of the most common scenarios, including:

- [Azure Purview Workflow client library for .NET](#azure-purview-workflow-client-library-for-net)
  - [Getting started](#getting-started)
    - [Install the package](#install-the-package)
    - [Prerequisites](#prerequisites)
    - [Authenticate the client](#authenticate-the-client)
  - [Examples](#examples)
    - [Create workflow](#create-workflow)
    - [Submit user requests](#submit-user-requests)
    - [Approve workflow task](#approve-workflow-task)
  - [Key concepts](#key-concepts)
  - [Troubleshooting](#troubleshooting)
  - [Next steps](#next-steps)
  - [Contributing](#contributing)

### Create workflow

```C# Snippet:Azure_Analytics_Purview_Workflows_CreateWorkflow
Guid workflowId = Guid.NewGuid();

string workflow = "{\"name\":\"Create glossary term workflow\",\"description\":\"\",\"triggers\":[{\"type\":\"when_term_creation_is_requested\",\"underGlossaryHierarchy\":\"/glossaries/20031e20-b4df-4a66-a61d-1b0716f3fa48\"}],\"isEnabled\":true,\"actionDag\":{\"actions\":{\"Startandwaitforanapproval\":{\"type\":\"Approval\",\"inputs\":{\"parameters\":{\"approvalType\":\"PendingOnAll\",\"title\":\"ApprovalRequestforCreateGlossaryTerm\",\"assignedTo\":[\"eece94d9-0619-4669-bb8a-d6ecec5220bc\"]}},\"runAfter\":{}},\"Condition\":{\"type\":\"If\",\"expression\":{\"and\":[{\"equals\":[\"@outputs('Startandwaitforanapproval')['body/outcome']\",\"Approved\"]}]},\"actions\":{\"Createglossaryterm\":{\"type\":\"CreateTerm\",\"runAfter\":{}},\"Sendemailnotification\":{\"type\":\"EmailNotification\",\"inputs\":{\"parameters\":{\"emailSubject\":\"GlossaryTermCreate-APPROVED\",\"emailMessage\":\"YourrequestforGlossaryTerm@{triggerBody()['request']['term']['name']}isapproved.\",\"emailRecipients\":[\"@{triggerBody()['request']['requestor']}\"]}},\"runAfter\":{\"Createglossaryterm\":[\"Succeeded\"]}}},\"else\":{\"actions\":{\"Sendrejectemailnotification\":{\"type\":\"EmailNotification\",\"inputs\":{\"parameters\":{\"emailSubject\":\"GlossaryTermCreate-REJECTED\",\"emailMessage\":\"YourrequestforGlossaryTerm@{triggerBody()['request']['term']['name']}isrejected.\",\"emailRecipients\":[\"@{triggerBody()['request']['requestor']}\"]}},\"runAfter\":{}}}},\"runAfter\":{\"Startandwaitforanapproval\":[\"Succeeded\"]}}}}}";

Response createResult = await client.CreateOrReplaceAsync(workflowId, RequestContent.Create(workflow));
```

### Submit user requests

```C# Snippet:Azure_Analytics_Purview_Workflows_SubmitUserRequests
string request = "{\"operations\":[{\"type\":\"CreateTerm\",\"payload\":{\"glossaryTerm\":{\"name\":\"term\",\"anchor\":{\"glossaryGuid\":\"20031e20-b4df-4a66-a61d-1b0716f3fa48\"},\"status\":\"Approved\",\"nickName\":\"term\"}}}],\"comment\":\"Thanks!\"}";

Response submitResult = await client.SubmitAsync(RequestContent.Create(request));
```

### Approve workflow task

```C# Snippet:Azure_Analytics_Purview_Workflows_ApproveWorkflowTask
// This taskId represents an existing workflow task. The id can be obtained by calling GetWorkflowTasksAsync API.
Guid taskId = new Guid("b129fe16-72d3-4994-9135-b997b9be46e0");

string request = "{\"comment\":\"Thanks!\"}";

Response approveResult = await client.ApproveAsync(taskId, RequestContent.Create(request));
```

## Key concepts

## Troubleshooting

## Next steps

This client SDK exposes operations using *protocol methods*, you can learn more about how to use SDK Clients which use protocol methods in our [documentation][protocol_client_quickstart].

## Contributing

See the [CONTRIBUTING.md][contributing] for details on building, testing, and contributing to this library.

This project welcomes contributions and suggestions. Most contributions require you to agree to a Contributor License Agreement (CLA) declaring that you have the right to, and actually do, grant us the rights to use your contribution. For details, visit [cla.microsoft.com][cla].

When you submit a pull request, a CLA-bot will automatically determine whether you need to provide a CLA and decorate the PR appropriately (e.g., label, comment). Simply follow the instructions provided by the bot. You will only need to do this once across all repos using our CLA.

This project has adopted the [Microsoft Open Source Code of Conduct][code_of_conduct]. For more information see the [Code of Conduct FAQ][coc_faq] or contact [opencode@microsoft.com][coc_contact] with any additional questions or comments.

<!-- LINKS -->
[product_documentation]: https://learn.microsoft.com/azure/purview/concept-workflow
[azure_subscription]: https://azure.microsoft.com/free/dotnet/
[purview_resource]: https://learn.microsoft.com/azure/purview/create-catalog-portal
[azure_identity]: https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/identity/Azure.Identity/README.md
[app_registration]: https://learn.microsoft.com/azure/active-directory/develop/quickstart-register-app
[default_azure_credential]: https://learn.microsoft.com/dotnet/api/azure.identity.defaultazurecredential?view=azure-dotnet
[multifactor_authentication]:https://learn.microsoft.com/entra/identity/authentication/concept-mandatory-multifactor-authentication?tabs=dotnet#client-libraries
[protocol_client_quickstart]: https://aka.ms/azsdk/net/protocol/quickstart
[cla]: https://cla.microsoft.com
[code_of_conduct]: https://opensource.microsoft.com/codeofconduct/
[coc_faq]: https://opensource.microsoft.com/codeofconduct/faq/
[coc_contact]: mailto:opencode@microsoft.com
[contributing]: https://github.com/Azure/azure-sdk-for-net/blob/main/CONTRIBUTING.md
