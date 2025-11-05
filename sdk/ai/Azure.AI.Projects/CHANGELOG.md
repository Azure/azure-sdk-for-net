# Release History

## 2.0.0 (Unreleased)

### Features Added
* Added many new operations (to be filled)

## 1.1.0 (2025-11-03)

### Other Changes
* Added `files` samples for operations create, delete, list, retrieve and download.
- Remove `clientRequestId` parameter from `AIProjectConnectionsOperations` and `AIProjectDeploymentsOperations` methods as this value is controlled transparently by `System.ClientModel`.
- Remove `type` parameter from `AzureAIProjectsModelFactory.BlobReferenceSasCredential` as this is a hardcoded value.
- Remove `pendingUploadType` parameter from `AzureAIProjectsModelFactory.PendingUploadRequest` and `AzureAIProjectsModelFactory.PendingUploadConfiguration` as this is a hardcoded value.

## 1.0.0 (2025-10-01)

### Features Added
* Added convenience `CreateOrUpdate` methods for `AIProjectIndex` objects

### Breaking Changes
* Name changes:
  * `AssetDeployment` has been renamed to `AIProjectDeployment`
  * `BlobReference` has been renamed to `AIProjectBlobReference`
  * `ConnectionProperties` has been renamed to `AIProjectConnection`
  * `FileDatasetVersion` has been renamed to `FileDataset`
  * `FolderDatasetVersion` has been renamed to `FolderDataset`
  * `SasCredential` has been renamed to `BlobReferenceSasCredential`
  * `SearchIndex` has been renamed to `AIProjectIndex`
* Removed `GetOpenAIClient` method. Look at Inference samples for how to get the client now.
* All other `Get*Client` methods have been removed. Use the `AIProjectClient` properties `Connections`, `Datasets`, `Deployments`, and `Indexes` instead.

### Bugs Fixed
* Properly handle secret key population for `AIProjectConnectionCustomCredential`, [see GitHub issue 52355](https://github.com/Azure/azure-sdk-for-net/issues/52355).

## 1.0.0-beta.11 (2025-08-20)

### Features Added
* Added a constructor for `AIProjectClient` which takes a `System.ClientModel.AuthenticationTokenProvider` object for authentication. We will be switching away from `Azure.Core.TokenCredential` with the upcoming stable release.

### Breaking Changes
* Class changes:
  * `AIDeployment` has been renamed `AssetDeployment`
  * `AssetCredentialResponse` has been renamed `DatasetCredential`
  * `DatasetIndex` has been renamed `SearchIndex`
  * `PendingUploadRequest` has been renamed `PendingUploadConfiguration`
  * `PendingUploadResponse` has been renamed `PendingUploadResult`
* In `Datasets`, methods `PendingUpload` and `PendingUploadAsync`, argument `body` was replaced with `configuration`
* `GetAzureOpenAIChatClient` and `GetAzureOpenAIEmbeddingClient` methods have been removed and replaced with a single `GetOpenAIClient` method. This method returns an OpenAI client which has properties for accessing individual operation clients. More information is available in the `Inference` samples.
* All operations methods have been renamed to include the object the operation is for. For example, `Connections.GetDefault` has been renamed to `Connections.GetDefaultConnection`, and `Datasets.Get` has been renamed to `Datasets.GetDatasets`.
* `Deployments.GetModelDeployment` and `Deployments.GetModelDeploymentAsync` methods have been removed. Use `Deployments.GetDeployment` and `Deployments.GetDeploymentAsync` instead.`

## 1.0.0-beta.10 (2025-07-11)

### Features Added
* Support for generating embeddings through Azure OpenAI using `GetAzureOpenAIEmbeddingClient`.

### Breaking Changes
* Name changes:
  * In `Datasets` methods `PendingUpload` and `PendingUploadAsync`, argument `body` was replaced with `pendingUploadRequest`
  * `Connection` has been renamed `ConnectionProperties`
  * `Deployment` has been renamed `AIDeployment`
  * `Index` has been renamed `DatasetIndex`
  * `SasCredential` has been renamed `BlobReferenceSasCredential`
  * `Sku` has been renamed `ModelDeploymentSku`
* Removing `GetChatCompletionsClient`, `GetEmbeddingsClient`, and `GetImageEmbeddingsClient` methods from `AIProjectClient`. The Inference client should be used directly instead.
* Replacing `GetConnectionsClient`, `GetDatasetsClient`, `GetDeploymentsClient`, and`GetIndexesClient` with `Connections`, `Datasets`, `Deployments`, and `Indexes` properties.

### Bugs Fixed
* Fix getting model deployed on the Azure Open AI resource, if the resource is authenticated using Entra ID. [see GitHub issue 49064](https://github.com/Azure/azure-sdk-for-net/issues/49064)
* Fix dataset uploading datasets.

## 1.0.0-beta.9 (2025-05-16)

### Features Added
* `Deployments` methods to enumerate AI models deployed to your AI Foundry Project.
* `Datasets` methods to upload documents and reference them. To be used with Evaluations.
* `Indexes` methods to handle Search Indexes.

### Breaking Changes
* Azure AI Foundry Project endpoint is now required to construct the `AIProjectClient`. It has the form
`https://<your-ai-services-account-name>.services.ai.azure.com/api/projects/<your-project-name>`. Find it in your AI Foundry Project Overview page. Support for project connection string and hub-based projects has been discontinued. We recommend creating a new Azure AI Foundry resource utilizing project endpoint. If this is not possible, please pin the version of `Azure.AI.Projects` to version `1.0.0-beta.8` or earlier.
* Agents are now implemented in a separate package `Azure.AI.Agents.Persistent`. Use the `GetPersistentAgentsClient` method on the
`AIProjectsClient` to create, run and delete agents. However there have been some breaking changes in these operations. See [Agents package document and samples](https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/ai/Azure.AI.Agents.Persistent) for more details.
* Several changes to the `Connections` methods, including the response object (now it is simply called `Connection`). The class `ConnectionProperties` was renamed to `Connection`, and its properties have changed.
* `GetAzureOpenAIChatClient` now supports returning an authenticated `AzureOpenAI` ChatClient to be used with
AI models deployed to the Project's AI Services.
* The method `UploadFileRequest` on `AIProjectClient` had been removed, use `UploadFile` in `Datasets` instead.
* Property `scope` on `AIProjectClient` is removed.
* Evaluator Ids are available using the class `EvaluatorIDs` and no longer require `Azure.AI.Evaluation` package to be installed.
* Property `Id` on Evaluation is replaced with `name`.
* Please see the [agents migration guide](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/ai/Azure.AI.Projects/AGENTS_MIGRATION_GUIDE.md) on how to use the new `azure-ai-projects` with `azure-ai-agents` package.

### Sample Updates
* All samples have been updated. New ones have been added for Deployments, Datasets, and Indexes.

## 1.0.0-beta.8 (2025-04-23)

### Sample Updates
* New sample added for connected agent tool.

### Bugs Fixed
* Fix for filtering of messages by run ID [see GitHub issue 49513](https://github.com/Azure/azure-sdk-for-net/issues/49513).

## 1.0.0-beta.7 (2025-04-18)

### Features Added
* Added image input support for agents create message
* Added list threads support for agents

### Sample Updates
* New samples added for image input from url and file.
* New Fabric tool sample for agents

## 1.0.0-beta.6 (2025-03-28)

### Features Added
* Added `QueryType` parameter to `AISearchIndexResource` to allow different search types performed by an agent [issue](https://github.com/Azure/azure-sdk-for-net/issues/49069).
* Added sample for Azure AI Search in streaming scenarios [issue](https://github.com/Azure/azure-sdk-for-net/issues/49069).

### Breaking Changes
* `MicrosoftFabricToolDefinition` constructor parameter was renamed from `fabricAiskill` to `fabricDataagent`, the corresponding parameter was renamed from `FabricAiskill` to `FabricDataagent`.

### Bugs Fixed
* Fixed Azure AI Search in streaming scenarios.

### Sample updates
* Added documentation for each sample.
* The unnecessary code was removed from samples.

## 1.0.0-beta.5 (2025-03-17)

### Features Added

* Added `ConnectionProvider` abstraction in `AIProjectClient` to enable seamless connectivity with Azure OpenAI, Inference, and Search SDKs.
* Added `CognitiveService` connection type.
* Added support for URL citations with the `MessageTextUrlCitationAnnotation` class. `MessageTextContent` objects now can possibly have `Annotations` populated in order to provide information on URL citations.

## 1.0.0-beta.4 (2025-02-28)

### Bugs Fixed

* Fixed deserialization failure for AzureBlobStorage connection [issue](https://github.com/Azure/azure-sdk-for-net/issues/47874)
* Fixed a bug on deserialization of RunStepDeltaFileSearchToolCall [issue](https://github.com/Azure/azure-sdk-for-net/issues/48333)

## 1.0.0-beta.3 (2025-01-22)

### Bugs Fixed

* Fixed the bug preventing addition of a single Azure blob URI to the VectorStore.
* Fixed deserialization of Run Step when the file search is used [issue](https://github.com/Azure/azure-sdk-for-net/issues/47836).
* Fixed the issue preventing using streaming with function tools [issue](https://github.com/Azure/azure-sdk-for-net/issues/47797).

## 1.0.0-beta.2 (2024-12-13)

### Features Added

* Added `AzureFunctionToolDefinition` support to inform Agents about Azure Functions.
* Added `OpenApiTool` for Agents, which creates and executes a REST function defined by an OpenAPI spec.
* Add `parallelToolCalls` parameter to `CreateRunRequest`, `CreateRunAsync`, `CreateRunStreaming` and `CreateRunStreamingAsync`,  which allows parallel tool execution for Agents.

### Bugs Fixed

* Fix a bug preventing additional messages to be created when using `CreateRunStreamingAsync` and `CreateRunAsync` see [issue](https://github.com/Azure/azure-sdk-for-net/issues/47244).
* Fixed a bug where an exception would occur when run was not completed due to RAI check fail see [issue](https://github.com/Azure/azure-sdk-for-net/issues/47243).

## 1.0.0-beta.1 (2024-11-19)

### Features Added
- Initial release
