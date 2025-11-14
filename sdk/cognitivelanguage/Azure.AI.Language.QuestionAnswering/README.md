# Azure Cognitive Language Services Question Answering Authoring client library for .NET

The Question Answering Authoring client library lets you manage Question Answering projects: create and configure projects, add and update knowledge sources, add QnA pairs, deploy a project, and delete it. Use this library to automate lifecycle management while using the runtime (Inference) library to ask questions.

[Source code][authoring_src] | [Package (NuGet)][authoring_package] | [API reference][authoring_refdocs] | [Samples][authoring_samples] | [Product documentation][questionanswering_docs] | [REST API docs][authoring_rest_docs]

> If you only need to query deployed projects, install the runtime package (`Azure.AI.Language.QuestionAnswering.Inference`).
>
> If you need to create/update/deploy projects (authoring), install `Azure.AI.Language.QuestionAnswering` (it already brings inference transitively via type forwarding).

## Getting started

Service API version targeted: `2025-05-15-preview`.

### Install the package

Authoring (includes inference through type forwarding/dependency):
```dotnetcli
dotnet add package Azure.AI.Language.QuestionAnswering --prerelease
```

Inference only (slimmer surface if you do not perform authoring operations):
```dotnetcli
dotnet add package Azure.AI.Language.QuestionAnswering.Inference --prerelease
```

### Prerequisites

* An Azure subscription
* A Cognitive Services Language resource with Question Answering enabled
* Endpoint (e.g. `https://<resource>.cognitiveservices.azure.com/`)
* API key OR an Azure AD identity (role: “Cognitive Services Language Contributor” or appropriate RBAC)

### Authenticate the client

You can use an API key or Azure Active Directory (AAD) credentials (including Managed Identity).

#### Namespaces

Add the authoring namespace:

```C# Snippet:QuestionAnsweringAuthoringClient_Namespace
using Azure.AI.Language.QuestionAnswering.Authoring;
```

#### Create a QuestionAnsweringAuthoringClient (API key)

```C# Snippet:QuestionAnsweringAuthoringClient_Create
Uri endpoint = new Uri("https://myaccount.cognitiveservices.azure.com/");
AzureKeyCredential credential = new AzureKeyCredential("{api-key}");

QuestionAnsweringAuthoringClient client = new QuestionAnsweringAuthoringClient(endpoint, credential);
```

#### Create a QuestionAnsweringAuthoringClient (Managed Identity / DefaultAzureCredential)

```C# Snippet:QuestionAnsweringAuthoringClient_CreateWithDefaultCredential
Uri endpoint = new Uri("https://myaccount.cognitiveservices.azure.com/");
TokenCredential credential = new DefaultAzureCredential();

QuestionAnsweringAuthoringClient client = new QuestionAnsweringAuthoringClient(endpoint, credential, new QuestionAnsweringAuthoringClientOptions());
```

> Regional endpoints may require a custom domain configuration to use AAD / Managed Identity. See official authentication docs for details.

## Key concepts

| Concept | Description |
|--------|-------------|
| Project | A container for language configuration, knowledge sources, QnA pairs, and deployments. |
| Deployment | A named, queryable snapshot of a project used by runtime clients. |
| Knowledge Source | A URL / file / structured or unstructured content ingested into the project. |
| QnA Pair | A question with one or more answers that can be updated incrementally. |
| Long‑running Operations | Creating deployments, updating sources, updating QnAs, and export operations return `Operation<T>`. |

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
// Set project name and request content parameters
string newProjectName = "{ProjectName}";
RequestContent creationRequestContent = RequestContent.Create(
    new {
        description = "This is the description for a test project",
        language = "en",
        multilingualResource = false,
        settings = new {
            defaultAnswer = "No answer found for your question."
            }
        }
    );

Response creationResponse = client.CreateProject(newProjectName, creationRequestContent);

// Projects can be retrieved as follows
Pageable<QuestionAnsweringProject> projects = client.GetProjects();

Console.WriteLine("Projects: ");
foreach (QuestionAnsweringProject project in projects)
{
    Console.WriteLine(project);
}
```

### Deploy a project

```C# Snippet:QuestionAnsweringAuthoringClient_DeployProject
// Set deployment name and start operation
string newDeploymentName = "{DeploymentName}";

Operation deploymentOperation = client.DeployProject(WaitUntil.Completed, newProjectName, newDeploymentName);

// Deployments can be retrieved as follows
Pageable<ProjectDeployment> deployments = client.GetDeployments(newProjectName);
Console.WriteLine("Deployments: ");
foreach (ProjectDeployment deployment in deployments)
{
    Console.WriteLine(deployment);
}
```

### Add (or update) knowledge sources

```C# Snippet:QuestionAnsweringAuthoringClient_UpdateSources
// Set request content parameters for updating our new project's sources
string sourceUri = "{KnowledgeSourceUri}";
RequestContent updateSourcesRequestContent = RequestContent.Create(
    new[] {
        new {
                op = "add",
                value = new
                {
                    displayName = "MicrosoftFAQ",
                    source = sourceUri,
                    sourceUri = sourceUri,
                    sourceKind = "url",
                    contentStructureKind = "unstructured",
                    refresh = false
                }
            }
    });

Operation updateSourcesOperation = client.UpdateSources(WaitUntil.Completed, newProjectName, updateSourcesRequestContent);

// Knowledge Sources can be retrieved as follows
BinaryData sources = updateSourcesOperation.GetRawResponse().Content;

Console.WriteLine($"Sources: {sources}");
```

> Additional operations (update QnAs, export, delete) follow similar patterns using `Operation<T>` or direct `Response` objects.

## Type forwarding & migration

As of the 2.0.0 preview split:
- The main package (`Azure.AI.Language.QuestionAnswering`) focuses on authoring but continues to expose inference types via type forwarding.
- The runtime implementation is provided by `Azure.AI.Language.QuestionAnswering.Inference`.
- Existing source code using inference or authoring APIs should compile without change after upgrading, because public inference types remain in the reference surface (source + binary compatibility).
- If you only need runtime querying, you can depend solely on the inference package for a reduced dependency surface.
- Future previews may de-emphasize inference APIs in the main package—follow the CHANGELOG for updates.

No code changes are required for upgrading typical projects; standard `dotnet add package ... --prerelease` is sufficient.

## Troubleshooting

| Issue | Possible Cause | Mitigation |
|-------|----------------|-----------|
| 401/403 | Invalid key or missing AAD role | Regenerate key or assign proper role |
| 404 | Project or deployment name incorrect | Verify spelling and casing |
| 409 | Concurrent modification conflict | Introduce retry / sequence operations |
| Operation timeout | Long-running network or service delay | Poll with backoff; inspect diagnostics / activity IDs |

Enable diagnostics logging:

```csharp
using Azure.Core.Diagnostics;
using AzureEventSourceListener listener = AzureEventSourceListener.CreateConsoleLogger();
```

## Next steps

* Export a project and store the snapshot in version control.
* Automate deployment after source updates.
* Integrate with CI/CD to promote projects across environments.

## Contributing

See the root repository contributing guide for how to build, test, and submit changes.

<!-- LINKS -->
[authoring_src]: https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/cognitivelanguage/Azure.AI.Language.QuestionAnswering.Authoring/src/
[authoring_package]: https://www.nuget.org/packages/Azure.AI.Language.QuestionAnswering
[authoring_refdocs]: https://learn.microsoft.com/dotnet/api/Azure.AI.Language.QuestionAnswering.Authoring
[authoring_samples]: https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/cognitivelanguage/Azure.AI.Language.QuestionAnswering.Authoring/samples/
[questionanswering_docs]: https://learn.microsoft.com/azure/cognitive-services/
[authoring_rest_docs]: https://learn.microsoft.com/rest/api/language/question-answering-projects
