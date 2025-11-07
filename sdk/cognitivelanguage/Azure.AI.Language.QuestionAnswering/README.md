# Azure Cognitive Language Services Question Answering Authoring client library for .NET

The Question Answering Authoring client library lets you manage Question Answering projects: create and configure projects, add and update knowledge sources, add QnA pairs, deploy a project, and delete it. Use this library to automate lifecycle management while using the runtime (Inference) library to ask questions.

[Source code][authoring_src] | [Package (NuGet)][authoring_package] | [API reference][authoring_refdocs] | [Samples][authoring_samples] | [Product documentation][questionanswering_docs] | [REST API docs][authoring_rest_docs]

> If you only need to query deployed projects, use the runtime package (`Azure.AI.Language.QuestionAnswering.Inference`).  
> If you need to create/update/deploy projects, use this Authoring package.

## Getting started

### Install the package

```dotnetcli
dotnet add package Azure.AI.Language.QuestionAnswering.Authoring --prerelease
```

### Prerequisites

* An Azure subscription
* A Cognitive Services Language resource with Question Answering enabled
* Endpoint (e.g. `https://<resource>.cognitiveservices.azure.com/`)
* API key (or Azure AD role: "Cognitive Services Language Contributor" / appropriate permissions)

### Authenticate the client

You can use an API key or Azure Active Directory (AAD) credentials.

#### Namespaces

```C# Snippet:QuestionAnsweringClient_Namespaces
```

Add the authoring namespace:

```C# Snippet:QuestionAnsweringAuthoringClient_Namespace
```

#### Create a QuestionAnsweringAuthoringClient (API key)

```C# Snippet:QuestionAnsweringAuthoringClient_Create
```

#### Create a client using Azure Active Directory

```C# Snippet:QuestionAnswering_Identity_Namespace
```

```C# Snippet:QuestionAnsweringClient_CreateWithDefaultAzureCredential
```

> Regional endpoints require a custom domain to use AAD. See the official authentication docs for details.

## Key concepts

| Concept | Description |
|--------|-------------|
| Project | A container for language configuration, knowledge sources, QnA pairs, and deployments. |
| Deployment | A named, queryable snapshot of a project used by runtime clients. |
| Knowledge Source | A URL / file / structured or unstructured content ingested into the project. |
| QnA Pair | A question with one or more answers that can be updated incrementally. |
| Long‑running Operations | Creation of deployments, updating sources, updating QnAs, export operations return `Operation<T>`. |

### Thread safety

Client instances are thread-safe and intended to be reused.

### Additional concepts

<!-- CLIENT COMMON BAR -->
[Client options](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/README.md#configuring-service-clients-using-clientoptions) |
[Accessing the response](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/README.md#accessing-http-response-details-using-responset) |
[Long-running operations](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/README.md#consuming-long-running-operations-using-operationt) |
[Handling failures](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/README.md#reporting-errors-requestfailedexception) |
[Diagnostics](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/Diagnostics.md) |
[Mocking](https://learn.microsoft.com/dotnet/azure/sdk/unit-testing-mocking) |
[Client lifetime](https://devblogs.microsoft.com/azure-sdk/lifetime-management-and-thread-safety-guarantees-of-azure-sdk-net-clients/)
<!-- CLIENT COMMON BAR -->

## Examples

### Create a project

```C# Snippet:QuestionAnsweringAuthoringClient_CreateProject
```

### Deploy a project

```C# Snippet:QuestionAnsweringAuthoringClient_DeployProject
```

### Add (or update) knowledge sources

```C# Snippet:QuestionAnsweringAuthoringClient_UpdateSources
```

> Additional operations (update QnAs, export, delete) follow similar patterns using `Operation<T>` or direct `Response` objects.

### Error handling (example from runtime client, same pattern applies)

```C# Snippet:QuestionAnsweringClient_BadRequest
```

## Troubleshooting

| Issue | Possible Cause | Mitigation |
|-------|----------------|-----------|
| 401/403 | Invalid key or missing AAD role | Regenerate key or assign proper role |
| 404 | Project or deployment name incorrect | Verify spelling and casing |
| 409 | Concurrent modification conflict | Introduce retry / sequence operations |
| Operation timeout | Long-running network or service delay | Poll with backoff, check `Operation.HasCompleted` and diagnostics |

Enable diagnostics logging:

```csharp
using Azure.Core.Diagnostics;
using AzureEventSourceListener listener = AzureEventSourceListener.CreateConsoleLogger();
```

## Next steps

* Export a project and store the snapshot in version control.
* Automate deployment after source updates.
* Integrate with CI/CD for promoting projects between environments.

## Contributing

See the root repository contributing guide for how to build, test, and submit changes.

<!-- LINKS -->
[authoring_src]: https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/cognitivelanguage/Azure.AI.Language.QuestionAnswering.Authoring/src/
[authoring_package]: https://www.nuget.org/packages/Azure.AI.Language.QuestionAnswering.Authoring
[authoring_refdocs]: https://learn.microsoft.com/dotnet/api/Azure.AI.Language.QuestionAnswering.Authoring
[authoring_samples]: https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/cognitivelanguage/Azure.AI.Language.QuestionAnswering.Authoring/samples/
[questionanswering_docs]: https://learn.microsoft.com/azure/cognitive-services/
[authoring_rest_docs]: https://learn.microsoft.com/rest/api/language/question-answering-projects