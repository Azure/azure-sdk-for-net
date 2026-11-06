# .NET Foundry live sample pipeline

[tests.yml](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/ai/Azure.AI.Projects/tests.yml)
provisions a fresh Standard Foundry environment and model for each active sample
worker, runs the .NET live samples, and cleans up the worker's temporary resource
group even when provisioning or tests fail. Queueing it authorizes billable
resources. There is no automatic CI or PR trigger.

## Resources

[standard-with-model.bicep](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/ai/Azure.AI.Projects/tests/Samples/ci/infra/standard-with-model.bicep)
uses the copied Standard shared-identity template to create:

- A Foundry account and project.
- Storage, Cosmos DB, Search, their project connections, and account/project
  capability hosts required by Standard agents.
- The project identity's native Cosmos data role and one configurable model
  deployment.

It does **not** create an MCP connection, Function App, hosting plan, queues,
Application Insights, new managed identities, or Azure IAM role assignments.
The copied full-bundle provisioner and Python sample adapters are not invoked.
An existing validation project is not used as the sample target.

## Prerequisites

Authorize the pipeline to use the **azure-sdk-tests** Azure Resource Manager
service connection and the configured agent pool. Save these normal pipeline
variables:

| Variable | Value |
| --- | --- |
| `AZURE_SUBSCRIPTION_ID` | Explicit target subscription GUID. |
| `AZURE_TENANT_ID` | Explicit target tenant GUID. |

Supply `identityResourceGroup` when queueing: the same permanent identity RG
used by the Python sample pipeline. The existing resolver verifies the four
bootstrap-owned project/account/search/function identities, their tags, owner,
tenant, principal IDs, and common region. The Function identity is validated as
part of that existing shared set but is not attached to any new resource.
The region comes from these identities, not from an arbitrary fallback.

The service connection must already be authorized for the target subscription,
resource-group/deployment operations, attachment of the existing identities,
and native Cosmos SQL role assignments. It also needs the preconfigured
subscription-scoped Foundry User grant so it can access each fresh project.
The project identity must already have the Standard setup's service grants.
Copying Bicep files or selecting a service connection does not transfer grants.
See the
[Python shared-identity setup](https://github.com/Azure/azure-sdk-for-python/blob/main/sdk/ai/azure-ai-projects/tests/samples/ci/README.md)
for the bootstrap requirements and role-scope warnings.

Workers never create or repair Azure IAM grants. Missing permissions fail
provisioning or live tests explicitly; an authorized administrator must resolve
them. Providers must be registered and regional account, model, Search, Cosmos,
and Storage eligibility/quota must be available. Preflight checks do not reserve
capacity across parallel workers.

## Execution and results

- The existing matrix has three disjoint sample slices, one framework
  (`net10.0`), Debug, and one package-reference configuration. The maximum
  parallel worker count defaults to four; it does not repeat the samples.
  The selected samples use `SyncOnly`: NUnit discovers both sync and async
  fixtures, but only the sync fixture executes; the async variant is skipped.
- `selectionKind`/`selection` restrict the existing slices; they do not add
  tests outside that matrix. A `test-id` selection is a .NET test-filter
  expression; semicolon-separated expressions are ORed. Semicolon-separated
  sample paths select their package's sample namespace.
- Matrix values are read-only. Each worker reads its `SampleSliceFilter` and
  combines it with the requested selection into the separate runtime variable
  `AdditionalTestFilters`; it never overwrites a matrix variable.
- Each worker uses PowerShell 7.2+ and Azure CLI under the service connection
  to resolve identities, check eligibility, provision Standard Foundry and the
  selected model, and publish its new endpoint/model/agent bindings to tests.
- Model name, version, SKU, and capacity remain run parameters. The default is
  `gpt-4.1` (`2025-04-14`) for both classic Agents and Responses samples.
  Overrides must support the selected APIs: reasoning models can reject
  sampling defaults used internally by the classic Agents service even when
  the sample does not set sampling parameters.
- Build and live tests use the same service connection through the existing
  federated-auth .NET template. In Azure Pipelines, all three test environments
  explicitly use `AzurePipelinesCredential` with the task's service-connection
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
  Combined console output is also published as a separate pipeline artifact.
  Plans and provisioning/cleanup state are published in each
  worker's `standard-foundry` artifact, including on failure.

No GitHub PAT or validation endpoint is required for these slices. Samples
requiring MCP, Function, or other additional resources are outside this first
pass.

## Cleanup safety

State is written before the first deployment mutation, including on partial
failure. Cleanup verifies the exact subscription, pipeline run, queue, RG ID,
and ownership tags before deletion. Hard cancellation, agent loss, or Azure
errors can still prevent cleanup. Expiry tags do not automatically delete
resources; inspect the saved state before manual cleanup and wait for cleanup
to finish before queueing another run.

## Maintainer validation

The focused offline tests are in
[StandardProvisioning.Tests.ps1](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/ai/Azure.AI.Projects/tests/Samples/ci/validation/StandardProvisioning.Tests.ps1)
and use the existing Pester 4.10.1 conventions. Compile the Standard-with-model
Bicep entry point as well. Offline checks do not establish that the service
connection has live RBAC grants or that live samples pass.
