# Migrate from Microsoft.Azure.CognitiveServices.Knowledge.QnAMaker to Azure.AI.Language.QuestionAnswering Authoring

> [!NOTE]
> Scope: This guide covers **authoring (project / knowledge sources / QnA / export / delete)** migration from QnAMaker to the modern Authoring SDK.  
> For **runtime querying (inference)** migration, see the separate runtime migration guide and the inference package `Azure.AI.Language.QuestionAnswering.Inference`.  
> Service API version referenced by current previews: `2025-05-15-preview`.

This guide helps migrate from the old client library [`Microsoft.Azure.CognitiveServices.Knowledge.QnAMaker`](https://www.nuget.org/packages/Microsoft.Azure.CognitiveServices.Knowledge.QnAMaker) to the modern authoring client library [`Azure.AI.Language.QuestionAnswering`](https://www.nuget.org/packages/Azure.AI.Language.QuestionAnswering). It focuses on side‑by‑side comparisons for authoring operations (creating/updating/exporting/deleting) between the two.

For general usage and more samples, refer to the [`Azure.AI.Language.QuestionAnswering` README](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/cognitivelanguage/Azure.AI.Language.QuestionAnswering.Authoring/README.md) and [authoring samples](https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/cognitivelanguage/Azure.AI.Language.QuestionAnswering.Authoring/samples).

## Table of contents

- [Migration benefits](#migration-benefits)
- [General changes](#general-changes)
  - [Package and namespaces](#package-and-namespaces)
  - [Package split and choosing the right package](#package-split-and-choosing-the-right-package)
  - [Type forwarding & compatibility](#type-forwarding--compatibility)
  - [Authoring client](#authoring-client)
    - [Authenticating authoring client](#authenticating-authoring-client)
    - [Creating a project (was: knowledge base)](#creating-a-project-was-knowledge-base)
    - [Updating knowledge sources (was: update KB)](#updating-knowledge-sources-was-update-kb)
    - [Updating QnAs](#updating-qnas)
    - [Exporting a project](#exporting-a-project)
    - [Deleting a project (was: delete KB)](#deleting-a-project-was-delete-kb)

## Migration benefits

Azure’s modern client libraries adopt consistent design guidelines:
- Uniform naming, shapes, and async patterns across services.
- Better long‑running operation handling (`Operation<T>`).
- Clear separation of **authoring vs inference responsibilities** to slim dependency surfaces.

See the general [design guidelines](https://azure.github.io/azure-sdk/general_introduction.html) and [.NET‑specific guidelines](https://azure.github.io/azure-sdk/dotnet_introduction.html) for deeper details.

## General changes

### Package and namespaces

Legacy pattern: `Microsoft.Azure.CognitiveServices.Knowledge.QnAMaker`  
Modern pattern: `Azure.AI.Language.QuestionAnswering` (root) with authoring namespace: `Azure.AI.Language.QuestionAnswering.Authoring`.

Legacy “knowledge base” concepts map to modern “project” + “deployment” terminology.

### Package split and choosing the right package

Starting with the 2.0.0 preview split:

| Scenario | NuGet package | Notes |
|----------|---------------|-------|
| Authoring only (create/update/deploy/export/delete) | `Azure.AI.Language.QuestionAnswering` | Includes authoring APIs; forwards inference types. |
| Runtime querying only | `Azure.AI.Language.QuestionAnswering.Inference` | Smaller surface (no authoring operations). |
| Both authoring + runtime in same app | `Azure.AI.Language.QuestionAnswering` | Inference types available via type forwarding; optional to add inference package only if pinning versions. |

### Type forwarding & compatibility

- Inference types (`QuestionAnsweringClient`, `AnswersResult`, etc.) are **type‑forwarded** from the authoring package to the inference implementation, preserving source & binary compatibility.
- Existing code that queried and now upgrades to include authoring needs **no code changes** for inference usage.
- Pure query projects can remove the authoring package and add `Azure.AI.Language.QuestionAnswering.Inference` for a leaner dependency set.
- Future previews may reduce or hide forwarded inference APIs from the authoring package—track the CHANGELOG for status.

### Authoring client

#### Authenticating authoring client

Previously (QnAMaker) `QnAMakerClient` with `ApiKeyServiceClientCredentials`:

```C# Snippet:CognitiveServices_QnA_Maker_Snippets_MigrationGuide_CreateClient
QnAMakerClient client = new QnAMakerClient(new ApiKeyServiceClientCredentials("{QnAMakerSubscriptionKey}"), new HttpClient(), false)
{
    Endpoint = "{QnaMakerEndpoint}"
};
```

Now use `QuestionAnsweringAuthoringClient` with `AzureKeyCredential`:

```C# Snippet:Language_QnA_Maker_Snippets_MigrationGuide_CreateClient
Uri endpoint = new Uri("{LanguageQnaEndpoint}");
AzureKeyCredential credential = new AzureKeyCredential("{ApiKey}");

QuestionAnsweringAuthoringClient client = new QuestionAnsweringAuthoringClient(endpoint, credential);
```

#### Creating a project (was: knowledge base)

Previously creating a `Knowledgebase` with `CreateKbDTO`:

```C# Snippet:CognitiveServices_QnA_Maker_Snippets_MigrationGuide_CreateKnowledgeBase
Microsoft.Azure.CognitiveServices.Knowledge.QnAMaker.Models.Operation createOp = await client.Knowledgebase.CreateAsync(new CreateKbDTO
{
    Name = "{KnowledgeBaseName}", QnaList = new List<QnADTO>
    {
        new QnADTO
        {
            Questions = new List<string>
            {
                "{Question}"
            },
            Answer = "{Answer}"
        }
    }
});
```

Now create a **project** (`CreateProjectAsync`) with JSON properties:

```C# Snippet:Language_QnA_Maker_Snippets_MigrationGuide_CreateProject
string newProjectName = "{ProjectName}";
RequestContent creationRequestContent = RequestContent.Create(
    new {
            description = "This is the description for a test project",
            language = "en",
            multilingualResource = false,
            settings = new
            {
                defaultAnswer = "No answer found for your question."
            }
        }
    );

Response creationResponse = await client.CreateProjectAsync(newProjectName, creationRequestContent);
```

#### Updating knowledge sources (was: update KB)

Legacy “update” used `UpdateKbOperationDTO`:

```C# Snippet:CognitiveServices_QnA_Maker_Snippets_MigrationGuide_UpdateKnowledgeBase
Microsoft.Azure.CognitiveServices.Knowledge.QnAMaker.Models.Operation updateOp = await client.Knowledgebase.UpdateAsync("{KnowledgeBaseID}",
    new UpdateKbOperationDTO
    {
        Add = new UpdateKbOperationDTOAdd
        {
            QnaList = new List<QnADTO>
            {
                new QnADTO
                {
                    Questions = new List<string>
                    {
                        "{Question}"
                    },
                    Answer = "{Answer}"
                }
            }
        }
    });
```

Modern source ingestion uses `UpdateSourcesAsync`:

```C# Snippet:Language_QnA_Maker_Snippets_MigrationGuide_UpdateKnowledgeSource
string sourceUri = "{SourceURI}";
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

Operation<AsyncPageable<BinaryData>> updateSourcesOperation = await client.UpdateSourcesAsync(WaitUntil.Completed, "{ProjectName}", updateSourcesRequestContent);
```

#### Updating QnAs

Legacy added QnA pairs via KB update DTO; modern adds/updates QnA with `UpdateQnasAsync`:

```C# Snippet:Language_QnA_Maker_Snippets_MigrationGuide_UpdateQnas
RequestContent updateQnasRequestContent = RequestContent.Create(
    new[] {
        new {
                op = "add",
                value = new
                {
                    questions = new[]
                        {
                            "What is the easiest way to use Azure services in my .NET project?"
                        },
                    answer = "Refer to the Azure SDKs"
                }
            }
    });

Operation<AsyncPageable<BinaryData>> updateQnasOperation = await client.UpdateQnasAsync(WaitUntil.Completed, "{ProjectName}", updateQnasRequestContent);
```

#### Exporting a project

Previously downloaded KB with `DownloadAsync`:

```C# Snippet:CognitiveServices_QnA_Maker_Snippets_MigrationGuide_DownloadKnowledgeBase
QnADocumentsDTO kbdata = await client.Knowledgebase.DownloadAsync("{KnowledgeBaseID}", EnvironmentType.Test);
```

Modern export:

```C# Snippet:Language_QnA_Maker_Snippets_MigrationGuide_ExportProject
Operation<BinaryData> exportOperation = client.Export(WaitUntil.Completed, "{ProjectName}", "{ExportFormat}");
```

#### Deleting a project (was: delete KB)

Legacy delete:

```C# Snippet:CognitiveServices_QnA_Maker_Snippets_MigrationGuide_DeleteKnowledgeBase
await client.Knowledgebase.DeleteAsync("{KnowledgeBaseID}");
```

Modern delete project:

```C# Snippet:Language_QnA_Maker_Snippets_MigrationGuide_DeleteProject
Operation deletionOperation = await client.DeleteProjectAsync(WaitUntil.Completed, "{ProjectName}");
```

## Summary

- “Knowledge base” → “Project” + “Deployment”.
- Authoring operations moved to `QuestionAnsweringAuthoringClient`.
- Inference types remain accessible for compatibility but can be consumed from the dedicated inference package if authoring is not needed.
- Use service version `2025-05-15-preview` with the 2.0.0 preview authoring package.

> For pure runtime migration examples (querying / follow‑up / confidence tuning), see the runtime (Inference) migration guide.
