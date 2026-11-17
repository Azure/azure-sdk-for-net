# .NET Foundry live sample pipeline

[tests.yml](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/ai/Azure.AI.Projects/tests.yml)
provisions the full Python-equivalent resource bundle for each active sample
worker, runs the .NET live samples, and cleans up the worker's temporary resource
group even when provisioning or tests fail. Queueing it authorizes billable
resources. There is no automatic CI or PR trigger.

## Resources

[main.bicep](./infra/main.bicep) uses the copied Standard shared-identity template
and unconditional feature modules to create:

- A Foundry account and project.
- Storage, Cosmos DB, Search, their project connections, and account/project
  capability hosts required by Standard agents.
- The project identity's native Cosmos data role and one configurable model
  deployment.
- An authenticated GitHub MCP project connection.
- A Linux Elastic Premium Function App, its hosting plan and queues, with a
  separately published Python queue handler.
- An embedding deployment, document container, populated Search index,
  skillset and indexers.
- A keyless Playwright workspace and browser-automation project connection.
- Bing Grounding and Bing Custom Search accounts and project connections,
  including the custom search configuration.
- An OpenAPI project connection using the supplied external service key.

All modules run regardless of sample selection. This increases cost and
prerequisites even for the three original samples. There are no new managed
identities or Azure IAM role assignments, and no existing validation project
is used as the sample target. The Python pytest adapters are not invoked.
The former Standard-only entry point remains available for explicit local use,
but is no longer called by this pipeline.

## Prerequisites

Authorize the pipeline to use the **azure-sdk-tests** Azure Resource Manager
service connection and the configured agent pool. Save these normal pipeline
variables:

| Variable | Value |
| --- | --- |
| `AZURE_SUBSCRIPTION_ID` | Explicit target subscription GUID. |
| `AZURE_TENANT_ID` | Explicit target tenant GUID. |

Also save **secret** pipeline variables `MCP_GITHUB_PAT` (the complete GitHub
PAT, including its prefix) and `PROJ_CONN_OPEN_API_KEY` (the TripAdvisor/OpenAPI
service key). Both are required for every run. They are passed only into the
provisioning task and read by the secret-only Bicep parameter file, never
published as test bindings or written into plans, state or artifacts.
Do not pass them as run parameters or command-line arguments.

Supply `identityResourceGroup` when queueing: the same permanent identity RG
used by the Python sample pipeline. The existing resolver verifies the four
bootstrap-owned project/account/search/function identities, their tags, owner,
tenant, principal IDs, and common region. The Function identity is attached to
the new Function App, and the Search identity runs the indexing deployment script.
The region comes from these identities, not from an arbitrary fallback.

The service connection must already be authorized for the target subscription,
resource-group/deployment operations, attachment of the existing identities,
and native Cosmos SQL role assignments. It also needs the preconfigured
subscription-scoped Foundry User grant so it can access each fresh project.
The project identity must already have the Standard setup's service grants,
Storage Queue Data Contributor and Playwright Workspace Contributor.
The Function identity needs Storage Blob Data Owner and Storage Queue Data
Contributor. The Search identity needs Search Service Contributor, Search Index
Data Contributor, Storage Blob Data Contributor and Cognitive Services OpenAI User.
Copying Bicep files or selecting a service connection does not transfer grants.
See the
[Python shared-identity setup](https://github.com/Azure/azure-sdk-for-python/blob/main/sdk/ai/azure-ai-projects/tests/samples/ci/README.md)
for the bootstrap requirements and role-scope warnings.

Workers never create or repair Azure IAM grants. The account identity remains
without grants. Missing permissions fail
provisioning or live tests explicitly; an authorized administrator must resolve
them. Providers must be registered and regional account, model, Search, Cosmos,
and Storage eligibility/quota must be available, together with the embedding
model (`text-embedding-3-small`, version `1`, GlobalStandard capacity `10`),
Elastic Premium Functions, Playwright and Bing availability.
Registered providers must include Microsoft.CognitiveServices, Microsoft.Storage,
Microsoft.DocumentDB, Microsoft.Search, Microsoft.ManagedIdentity, Microsoft.Web,
Microsoft.LoadTestService, Microsoft.Bing and Microsoft.ContainerInstance
(used by the Search deployment script).
Preflight checks do not reserve capacity across parallel workers or prove every
feature's quota; a later module failure still triggers ownership-checked cleanup.

## Execution and results

- The existing matrix has three disjoint sample slices, one framework
  (`net10.0`), Debug, and one package-reference configuration. The maximum
  parallel worker count defaults to four; it does not repeat the samples.
  The slice filters select the `False` (sync) NUnit fixture, so each sample
  executes once without editing the samples or adding skipped async variants.
- `selectionKind`/`selection` restrict the existing slices; they do not add
  tests outside that matrix. A `test-id` selection is a .NET test-filter
  expression; semicolon-separated expressions are ORed. Semicolon-separated
  sample paths select their package's sample namespace.
- Matrix values are read-only. Each worker reads its `SampleSliceFilter` and
  combines it with the requested selection into the separate runtime variable
  `AdditionalTestFilters`; it never overwrites a matrix variable.
- Each worker uses PowerShell 7.2+ and Azure CLI under the service connection.
  [Invoke-BundleProvisioning.ps1](./Invoke-BundleProvisioning.ps1) creates an
  offline plan, resolves identities, calls the language-neutral provisioner,
  and publishes bindings only after the bundle is Ready and the Function
  queue trigger has been indexed. Partial failures retain cleanup state.
- Model name, version, SKU, and capacity remain run parameters. The default is
  `gpt-4.1` (`2025-04-14`) for both classic Agents and Responses samples.
  Overrides must support the selected APIs: reasoning models can reject
  sampling defaults used internally by the classic Agents service even when
  the sample does not set sampling parameters.
- Build and live tests opt into the shared template's Azure CLI task through
  `CloudConfig.Public.UseAzureCliForTests`. The task authenticates the same
  service connection and sets `AZURE_TOKEN_CREDENTIALS=AzureCliCredential`,
  restricting the samples' unmodified `DefaultAzureCredential` to that scoped
  CLI session rather than the agent's managed identity. This selector requires
  Azure.Identity 1.15.0 or later. Other pipelines keep their existing test task
  unless they opt in.
  The three test environments still use `AzurePipelinesCredential` with the task's service-connection
  tenant/client/connection IDs and the runtime `SYSTEM_ACCESSTOKEN`. Missing
  metadata or a mismatched target tenant fails without falling back to the
  agent's managed identity. Tokens are not written to state or artifacts.
  Local developer runs still use `DefaultAzureCredential`. Failed tests fail
  the job.
- An always-run step calls the existing ownership-checked cleanup script.
  It deletes only the fresh run-owned RG and its subscription deployment record,
  never the permanent identities or another worker's RG.
- Each executed sample attaches its captured console output as `console-output.txt`
  to its individual test result, including on failure. Download it from the
  pipeline's Tests tab, under the test result's Attachments. An empty file is
  attached when a sample writes no output. Normal console logging is unchanged.
  The output hook lives in the already-linked shared test bootstrap source;
  no sample-source or test-project file changes are required.
  Combined console output is also published as a separate pipeline artifact.
  Plans and provisioning/cleanup state are published in each
  worker's `standard-foundry` artifact, including on failure.

The three disjoint matrix slices are unchanged: deploying more resources does
not automatically select every sample or make samples requiring other services
(for example SharePoint, Fabric or hosted agents) runnable.

## .NET environment compatibility

The canonical Bicep outputs are retained. The wrapper also publishes these
aliases, consumed by the existing .NET test environments:

| .NET variable | Bundle binding |
| --- | --- |
| `MCP_PROJECT_CONNECTION_NAME` | `MCP_PROJECT_CONNECTION_ID` (passed directly to `ProjectConnectionId`) |
| `AI_SEARCH_CONNECTION_NAME` | `AI_SEARCH_PROJECT_CONNECTION_ID` (the .NET tools expect an ARM ID despite the variable name) |
| `BING_CONNECTION_ID` / `BING_CONNECTION_NAME` | `BING_PROJECT_CONNECTION_ID` / `BING_PROJECT_CONNECTION_NAME` |
| `CUSTOM_BING_CONNECTION_ID` / `CUSTOM_BING_CONNECTION_NAME` | `BING_CUSTOM_SEARCH_PROJECT_CONNECTION_ID` / `BING_CUSTOM_SEARCH_PROJECT_CONNECTION_NAME` |
| `PLAYWRIGHT_CONNECTION_ID` / `PLAYWRIGHT_CONNECTION_NAME` | `BROWSER_AUTOMATION_PROJECT_CONNECTION_ID` / `BROWSER_AUTOMATION_PROJECT_CONNECTION_NAME` |
| `BROWSER_AUTOMATION_NAME` | `BROWSER_AUTOMATION_PROJECT_CONNECTION_NAME` |
| `STORAGE_QUEUE_URI` | `STORAGE_QUEUE_SERVICE_ENDPOINT`, without a trailing slash |

OpenAPI connection ID/name and the custom Bing instance name already match.
The copied Search module uses the .NET `sample_index` name, a filterable
`category` field and synthetic sleeping-bag documents to match the .NET sample
query. The Function host is still Python (as in the shared bundle), but uses
the .NET `foo` request's `query` argument and the `azure-function-foo-input` /
`azure-function-tool-output` queues. Its only remote dependency is
`azure-functions`; no dependency is added to the .NET SDK.
Data-source, skillset and indexer names replace index-name underscores with
hyphens because Azure Search permits underscores only in the index name.
The permanent identities remain administered by the linked Python bootstrap;
this repository does not duplicate that bootstrap or grant roles.

## Cleanup safety

State is written before the first deployment mutation, including on partial
failure. Cleanup verifies the exact subscription, pipeline run, queue, RG ID,
and ownership tags before deletion. Hard cancellation, agent loss, or Azure
errors can still prevent cleanup. Expiry tags do not automatically delete
resources; inspect the saved state before manual cleanup and wait for cleanup
to finish before queueing another run.

## Maintainer validation

Use PowerShell 7.2+ with Pester 4.10.1 from this directory:

```powershell
Invoke-Pester -Script @(
  './validation/BundleProvisioning.Tests.ps1',
  './validation/StandardProvisioning.Tests.ps1',
  './validation/SharedProvisioning.Tests.ps1',
  './validation/SampleCiHelpers.Tests.ps1',
  './validation/Invoke-SampleProvisioning.Tests.ps1',
  './validation/Remove-SampleResources.Tests.ps1',
  './validation/IdentityResolution.Tests.ps1',
  './validation/SamplePreflight.Tests.ps1'
) -EnableExit
./validation/Test-BicepTemplates.ps1
python -m unittest discover -s ./validation -p test_bundle_assets.py
```

The Bicep checker compiles the complete bundle and inspects nested resources,
secret parameters, module dependencies and non-secret outputs. No deployment
is performed. Offline checks do not establish live RBAC, regional feature
availability or that live samples pass. Queue the existing pipeline only after
reviewing its new billable footprint and setting both secret variables.
