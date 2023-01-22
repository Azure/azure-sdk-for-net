# Azure Purview Workflow client library for .NET

Workflows are automated, repeatable business processes that users can create within Microsoft Purview to validate and orchestrate CUD (create, update, delete) operations on their data entities. Enabling these processes allow organizations to track changes, enforce policy compliance, and ensure quality data across their data landscape.

Use the client library for Purview Workflow to:
- CRUD of workflow.
- Submit user request and monitor workflow run.
- View and respond to workflow tasks.


**Please rely heavily on the [service's documentation][product_documentation]**

## Getting started

This section should include everything a developer needs to do to install and create their first client connection *very quickly*.


### Prerequisites

You must have an [Azure subscription][azure_subscription] and a [Purview resource][purview_resource] to use this package.

### Authenticate the client


Since Workflow service use Azure Active Directory bearer token for authentication and username(usually it is an email address) should be encoded into the token so that user could received email notification when using workflow. A recommended solution is using the [Azure Identity][azure_identity] library to provide the [UsernamePasswordCredential][username_password_credentail]. Before get started using the [Azure Identity][azure_identity] library, [an application][app_registration] should be registered and then provide the client id into the [UsernamePasswordCredential][username_password_credentail].

```C#
    //<client-id>, <tenant-id> are the client ID and tenant ID of the AAD application.
    //<user-name>,<password> are the value of user name and password of an AAD user.
    TokenCredential usernamePasswordCredential = new UsernamePasswordCredential(<client-id>, <tenant-id>, <user-name>,<password>, null);
    var client = new PurviewWorkflowServiceClient(new Uri("https://<purview-account-name>.purview.azure.com"), usernamePasswordCredential)
```


## Key concepts

The *Key concepts* section should describe the functionality of the main classes. Point out the most important and useful classes in the package (with links to their reference pages) and explain how those classes work together. Feel free to use bulleted lists, tables, code blocks, or even diagrams for clarity.

Include the *Thread safety* and *Additional concepts* sections below at the end of your *Key concepts* section. You may remove or add links depending on what your library makes use of:

### Thread safety

We guarantee that all client instance methods are thread-safe and independent of each other ([guideline](https://azure.github.io/azure-sdk/dotnet_introduction.html#dotnet-service-methods-thread-safety)). This ensures that the recommendation of reusing client instances is always safe, even across threads.

### Additional concepts
<!-- CLIENT COMMON BAR -->
[Client options](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/README.md#configuring-service-clients-using-clientoptions) |
[Accessing the response](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/README.md#accessing-http-response-details-using-responset) |
[Long-running operations](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/README.md#consuming-long-running-operations-using-operationt) |
[Handling failures](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/README.md#reporting-errors-requestfailedexception) |
[Diagnostics](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/Diagnostics.md) |
[Mocking](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/README.md#mocking) |
[Client lifetime](https://devblogs.microsoft.com/azure-sdk/lifetime-management-and-thread-safety-guarantees-of-azure-sdk-net-clients/)
<!-- CLIENT COMMON BAR -->

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

## Troubleshooting

Describe common errors and exceptions, how to "unpack" them if necessary, and include guidance for graceful handling and recovery.

Provide information to help developers avoid throttling or other service-enforced errors they might encounter. For example, provide guidance and examples for using retry or connection policies in the API.

If the package or a related package supports it, include tips for logging or enabling instrumentation to help them debug their code.

## Next steps

* Provide a link to additional code examples, ideally to those sitting alongside the README in the package's `/samples` directory.
* If appropriate, point users to other packages that might be useful.
* If you think there's a good chance that developers might stumble across your package in error (because they're searching for specific functionality and mistakenly think the package provides that functionality), point them to the packages they might be looking for.

## Contributing

This is a template, but your SDK readme should include details on how to contribute code to the repo/package.

<!-- LINKS -->
[product_documentation]: https://learn.microsoft.com/en-us/azure/purview/concept-workflow
[client_nuget_package]: https://www.nuget.org/packages?q=Azure.Analytics.Purview.Workflows
[protocol_client_quickstart]: https://learn.microsoft.com/en-us/azure/purview/concept-workflow
[azure_subscription]: https://azure.microsoft.com/free/dotnet/
[purview_resource]: https://docs.microsoft.com/azure/purview/create-catalog-portal
[azure_identity]: https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/identity/Azure.Identity
[app_registration]: https://learn.microsoft.com/en-us/azure/active-directory/develop/quickstart-register-app
[username_password_credentail]: https://learn.microsoft.com/en-us/dotnet/api/azure.identity.usernamepasswordcredential?view=azure-dotnet
[style-guide-msft]: https://docs.microsoft.com/style-guide/capitalization
[style-guide-cloud]: https://aka.ms/azsdk/cloud-style-guide

![Impressions](https://azure-sdk-impressions.azurewebsites.net/api/impressions/azure-sdk-for-net/sdk/purview/Azure.Analytics.Purview.Workflows/README.png)
