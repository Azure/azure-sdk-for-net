# Azure Purview Workflow client library for .NET

Workflows are automated, repeatable business processes that users can create within Microsoft Purview to validate and orchestrate CUD (create, update, delete) operations on their data entities. Enabling these processes allow organizations to track changes, enforce policy compliance, and ensure quality data across their data landscape.

Use the client library for Purview Workflow to:
- Managing workflows
- Submitting user requests and monitoring workflow runs
- Viewing and responding to workflow tasks

**For more details about how to use workflow, please refer to the [service documentation][product_documentation]**

### Prerequisites

You must have an [Azure subscription][azure_subscription] and a [Purview resource][purview_resource] to use this package.

### Authenticate the client

Since the Workflow service uses an Azure Active Directory (AAD) bearer token for authentication and identification, an email address should be encoded into the token to allow for notification when using Workflow. It is recommended that the [Azure Identity][azure_identity] library be used  with a the [UsernamePasswordCredential][username_password_credential]. Before using the [Azure Identity][azure_identity] library with Workflow, [an application][app_registration] should be registered and used for the clientId passed to the [UsernamePasswordCredential][username_password_credentail].

```C# Snippet:Azure_Analytics_Purview_Workflows_CreatePurviewWorkflowClient
```

## Examples

You can familiarize yourself with different APIs using [Samples](https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/purview/Azure.Analytics.Purview.Workflows/samples).

### <scenario>

You can create a client and call the client's `<operation>` method.

```C# Snippet:Azure_Analytics_Purview_Workflows_CrudWorkflow
Uri endpoint = new("https://<purview-account-name>.purview.azure.com");
var credential = new DefaultAzureCredential();
var client = new PurviewWorkflowServiceClient(endpoint, credential);

Guid workflowId = new Guid("ba25ed0e-3364-4e8e-8385-c60e12f3e342");
Response result = client.GetWorkflow(workflowId);
```

<!-- LINKS -->
[product_documentation]: https://learn.microsoft.com/azure/purview/concept-workflow
[azure_subscription]: https://azure.microsoft.com/free/dotnet/
[purview_resource]: https://docs.microsoft.com/azure/purview/create-catalog-portal
[azure_identity]: https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/identity/Azure.Identity
[app_registration]: https://learn.microsoft.com/azure/active-directory/develop/quickstart-register-app
[username_password_credentail]: https://learn.microsoft.com/dotnet/api/azure.identity.usernamepasswordcredential?view=azure-dotnet
