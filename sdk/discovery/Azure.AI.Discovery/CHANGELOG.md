# Release History

## 1.0.0-beta.1 (2026-05-19)

Initial beta release of the Azure AI Discovery client library for .NET.

### Features Added

- Added `WorkspaceClient` for managing Discovery workspace resources, with sub-clients for:
  - `DiscoveryInvestigationsClient` — create, list, get, and delete investigations, and start/stop/get/update the per-investigation Discovery Engine.
  - `DiscoveryConversationsClient` — create, list, get, update, and delete conversations that interact with the Discovery Engine.
  - `DiscoveryTasksClient` — create, list (with `$filter` support), get, update, comment on, start, and delete tasks; record execution history.
  - `DiscoveryToolsClient` — run tools on supercomputer node pools, monitor run status with log retrieval, cancel runs, and query compute usage.
- Added `BookshelfClient` for managing knowledge bases, with sub-clients for:
  - `KnowledgeBases` — list available knowledge bases.
  - `KnowledgeBaseVersions` — create or update, get, list, delete, and retrieve the latest version of a knowledge base; start, cancel, and monitor indexing.
- Added shared model types under the `Azure.AI.Discovery` namespace covering investigations, conversations, tasks, tools, knowledge bases, and the Discovery Engine.
- Targets `netstandard2.0`, `net8.0`, and `net10.0` against Microsoft Discovery API version `2026-02-01-preview`.
