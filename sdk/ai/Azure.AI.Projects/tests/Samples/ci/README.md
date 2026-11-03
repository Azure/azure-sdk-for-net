# On-demand sample tests in Azure DevOps

[../../../tests.yml](https://github.com/Azure/azure-sdk-for-python/blob/main/sdk/ai/azure-ai-projects/tests.yml) runs existing synchronous/asynchronous pytest sample cases in up to **four fresh public-network Standard Foundry environments**, sharing one permanent set of managed identities. Each test queue creates its own resource group (RG) and deletes only its owned temporary resources.

## Workflow

Every manually queued run generates plans, checks the selected shared identities and aggregate capacity, then provisions/tests/cleans up each nonempty queue in parallel. **Queueing this pipeline opts in to billable resources.** There is no preview/run-mode selector, automatic CI/PR trigger or YAML manual-approval stage.

The internal **Plan** stage collects samples without execution and publishes a fresh plan per queue before the live stage may start. It changes no Azure resources and is not ARM `what-if`, a permission/capacity check or a regression-test job. Pester installation and unit-test execution are not part of an on-demand sample run. Maintainer checks are described below.

Defaults: **up to four RG workers**, **gpt-5.2**, version **2025-12-11**, `GlobalStandard`, capacity **10 per active queue**. The **shared identity resource group** has no default and is entered on every run. `testQueueCount` accepts 1–4 as a maximum; fewer samples produce fewer workers, never empty RGs. Model settings remain configurable and `modelVersion=auto` resolves the regional catalog default. No separate region input is required: live admission obtains the identities' actual region from Azure metadata. West US 3 remains the live-validated configuration; other regions must pass all service, quota and model checks and are not guaranteed capacity.

Selected cases are sorted by pytest node ID and divided **round-robin, without repetition**. Five cases across four workers assign cases 1 and 5 to `q1`, case 2 to `q2`, case 3 to `q3` and case 4 to `q4`. Each worker runs its assigned cases sequentially, independently of the other workers.

## One-time setup

Configure a pipeline to use [../../../tests.yml](https://github.com/Azure/azure-sdk-for-python/blob/main/sdk/ai/azure-ai-projects/tests.yml), authorize the Azure SDK package feed and `azsdk-pool`, and save these variables:

| Variable | Setting |
| --- | --- |
| `AZURE_SUBSCRIPTION_ID` | Normal variable containing the target subscription GUID. |
| `AZURE_TENANT_ID` | Normal variable containing the target tenant GUID. |
| `LLM_VALIDATION_PROJECT_ENDPOINT` | Existing Foundry project endpoint. A normal variable is supported; secret storage is optional. |
| `MCP_GITHUB_PAT` | **Secret** containing the complete GitHub PAT, including `github_pat_` or `ghp_`. Required on every run: the MCP connection is always provisioned. |

The target IDs must be available to **both** Plan and RunSamples. Save runtime variables directly in the pipeline; there is no Library-group runtime parameter. Do not put secrets in YAML, chat, runtime parameters, command-line arguments, plans or artifacts.

The YAML variable `azureServiceConnection` is configured as **azure-sdk-tests**, an authorized Azure Resource Manager connection. It is not a Run pipeline field. Changing the connection requires updating that configuration and authorizing the pipeline; a subscription/MI name does not select or grant access to a service connection. Prefer workload identity federation. Its service principal must already have:

- Access to the explicit subscription and tenant; resource-group/deployment permissions, attachment of the existing UAMIs, and native Cosmos SQL role-assignment permissions. **Contributor** covers these management operations; workers do not need Azure IAM-administrator roles.
- The preconfigured subscription-scoped **Foundry User** grant. Workers assume Azure IAM grants exist; they never check, create or repair them.
- Access to the existing validation project and its **gpt-5.2** deployment, including the harness's file-upload and Code Interpreter operations. No validator resources or roles are provisioned by this pipeline.
- Registered providers: `Microsoft.CognitiveServices`, `Microsoft.Storage`, `Microsoft.DocumentDB`, `Microsoft.Search`, `Microsoft.ManagedIdentity`, and `Microsoft.Web`.

The scripts require **PowerShell 7.2+**. Azure subscription roles do not grant Azure DevOps pipeline-edit or service-connection authorization rights. Existing organization/service-connection approvals are not bypassed.

Enter the PAT directly in the pipeline secret field. Use minimum GitHub permissions and an appropriate expiration/SSO authorization; see [GitHub MCP authentication](https://github.com/github/github-mcp-server/blob/main/docs/remote-server.md).

### Select the shared identity resource group

The run form asks for **`identityResourceGroup`**: the existing resource group that holds the shared identities, for example `rg-azsdk-identities-westus3-102826_164519`. It must be a valid Azure resource group name (1–90 characters; letters, digits, `_`, `-`, `.`, parentheses; no trailing period). It is not a subscription, region or MI name.

The identities are created by [Deploy-Identities.ps1](https://github.com/Azure/azure-sdk-for-python/blob/main/sdk/ai/azure-ai-projects/tests/samples/shared-identities/infra/Deploy-Identities.ps1), which names them `mi-azsdk-sample-{project,account,search,function}-{region}-{timestamp}`. The pipeline needs only the `-project-`, `-account-`, `-search-` and `-function-` name segments; any prefix or suffix is accepted.

The subscription/tenant still come from saved variables, never an active-account default or search across subscriptions. Offline **Plan** publishes only the RG name with resolution `Pending`—it invents no identity IDs or region. Read-only admission lists the managed identities in that RG and requires exactly one whose name contains each `-{purpose}-` segment (unrelated identities in the group are ignored). It then requires the `purpose`, `sample-ci-owner`, `sample-ci-retention=permanent` and `sample-ci-identity` tags set by the deployment script, one owner and one region, and binds their actual resource IDs, region, owner and principal IDs. Duplicates, missing identities, unowned/mixed sets or incomplete metadata fail closed. It verifies capacity, then publishes **resolved-sample-plan** for the workers; workers never use unresolved plans. Provider registrations and preconfigured grants are assumed to exist and are not checked. Each worker GET-rechecks identity metadata before writes and passes the four resolved resource IDs and the project principal ID to Bicep. No identity is created, replaced or granted roles by test jobs.

### Permanent identities and service grants

[Deploy-Identities.ps1](https://github.com/Azure/azure-sdk-for-python/blob/main/sdk/ai/azure-ai-projects/tests/samples/shared-identities/infra/Deploy-Identities.ps1) is the single owner of the shared identities; an authorized administrator runs it, never a worker job. Without `-Apply` it only previews (`what-if`). With `-Apply` it prompts for a subscription and region (or takes `-SubscriptionId`/`-Location`) and, after confirmation, creates:

- A permanent RG `rg-azsdk-identities-{region}-{MMddyy_HHmmss}` and four UAMIs `mi-azsdk-sample-{project,account,search,function}-{region}-{MMddyy_HHmmss}`, tagged `purpose=azsdk-sample-identities`, `sample-ci-retention=permanent`, a shared `sample-ci-owner` token and `sample-ci-identity={purpose}`. Pass the RG name to the pipeline's `identityResourceGroup`.
- The seven **subscription-scoped** roles in [IdentityConfiguration.json](https://github.com/Azure/azure-sdk-for-python/blob/main/sdk/ai/azure-ai-projects/tests/samples/shared-identities/infra/IdentityConfiguration.json) for the project UAMI: Foundry User, Storage Blob Data Contributor, Storage Blob Data Owner (conditioned), Cosmos DB Operator, Search Service Contributor, Search Index Data Contributor and Storage Queue Data Contributor.
- Subscription-scoped **Storage Blob Data Owner** and **Storage Queue Data Contributor** for the Function UAMI.

The script does **not** grant the pipeline service principal Foundry User; that subscription-scoped grant must exist already and is not checked by admission. Every run creates a new RG and identity set; nothing is reused or deleted.

**A newly created set does not automatically run this pipeline.** Pass its RG name as `identityResourceGroup` after reviewing the target, broad role scope and regional eligibility. The [metadata resolver](https://github.com/Azure/azure-sdk-for-python/blob/main/sdk/ai/azure-ai-projects/tests/samples/ci/SampleCiHelpers.ps1) requires a single existing, owned identity set in that RG and never adopts unowned identities. Grants are assumed to be configured already. Do not infer workload compatibility from MI creation.

The account and Search identities have **no grants** until a separately reviewed integration needs them. The deployment script creates no test workloads. The CI cleanup never deletes these identities or grants.

**Scope warning:** the service grants reach matching existing and future resources throughout the subscription, not just temporary RGs. Shared identities reduce cross-run isolation. The approved Blob Owner condition restricts only blob tag read/write and filtering to container names ending `-azureml-agent`; it omits the original generated workspace-prefix restriction, and other Blob Owner permissions remain allowed. Do not silently broaden this pattern or use it without scope review.

### Single-operator execution; no Environment setup

No dedicated ADO Environment, Exclusive lock, ADO access-token mapping or Environment-administration permission is needed by this workflow. All jobs are ordinary pipeline jobs. Existing checks on service connections, pools and other protected resources remain in force.

**The sole operator must verify that the previous run and every RG cleanup have completed before starting another live run.** The four-worker limit applies per run, not across runs; an accidental overlapping run is not automatically serialized and can exceed four RGs overall.

Read-only admission still rejects leftover temporary sample RGs, repeated/empty queue selections and insufficient aggregate account/Search/model quota. This is a point-in-time check, not a race-free mutex or hardware reservation. The default two cases need two free account and Search slots and 20 model units; four active workers need four slots and 40 units. This workflow limit is not an Azure security boundary.

## Run a sample

1. Select the reviewed branch in **Run pipeline**.
2. Set `selectionKind`, `selection`, maximum worker count, **identityResourceGroup** and model options. No preview, connection, Library-group or region fields are shown.
3. Before queueing, verify the saved variables, configured connection, selected identity set and previous run's cleanup. **Run** authorizes provisioning billable resources after internal planning and live admission succeed.
4. Inspect offline selections/intents in **sample-plan** and actual admitted identity IDs/region in **resolved-sample-plan**, under each active queue. Each node appears exactly once; workers run automatically after admission. For plan-only inspection without a live run, maintainers can invoke the local selector/planner with fictional targets; this is not a separate pipeline mode.
5. Verify every queue's ADO **Tests** results and attachments and final deployment state `CleanedUp` in **sample-results-q1** through **sample-results-q4**, as applicable.

To verify repeatability, wait for all queues to pass and finish verified cleanup before queueing a second fresh batch. Each queue gets a new plan, owner token and RG; shared identities alone persist. Never reuse the first batch's workloads or overlap retries.

### Selection examples

| `selectionKind` | `selection` |
| --- | --- |
| `sample-path` | `samples/agents/tools/sample_agent_mcp_with_project_connection.py` |
| `sample-path` | `samples/agents/tools/sample_agent_mcp*project_connection*.py` (sync and async) |
| `test-id` | `sample_agent_mcp_with_project_connection` |
| `test-id` | `*test_samples_async.py::*[sample_agent_mcp_with_project_connection_async]` |
| `test-id` | `sample_agent_basic;sample_agent_mcp_with_project_connection` (OR) |

`*` and `?` are wildcards; brackets in pytest IDs are literal. Matching is case-insensitive, slash-normalized and deduplicated. Semicolons/newlines separate OR patterns. Zero matches fail; selection never falls back to all tests. Harness exclusions remain excluded. A selected sample that needs an environment variable nothing supplies is rejected during planning, before any resource is created: it is logged as an error and skipped, the other samples still run, and the run fails at the end in `ReportRejectedSamples`. Supported sample inputs come from the root `environment` output in [infra/main.bicep](infra/main.bicep), `AZURE_SUBSCRIPTION_ID`, `AZURE_TENANT_ID`, `AZURE_RESOURCE_GROUP`, and the pipeline-supplied `LLM_VALIDATION_PROJECT_ENDPOINT`. Every active queue's plan saves the complete provisioned input names as `environmentBindings`, which `run_samples.py` enforces. A queue whose samples were all rejected gets no worker.

## Shared provisioning and language adapters

The infrastructure entry points have no dependency on Python, pytest, sample paths, or
sample queries. They can prepare the same environment for .NET, Java, JavaScript/TypeScript,
Go, or Python tests. The Azure resources always deploy as one complete bundle.

| Layer | Entry points |
| --- | --- |
| Shared offline planning | [New-ResourceDeploymentPlan.ps1](New-ResourceDeploymentPlan.ps1) |
| Shared admission and deployment | [Invoke-ResourceProvisioning.ps1](Invoke-ResourceProvisioning.ps1), [SampleCiHelpers.ps1](SampleCiHelpers.ps1) |
| Shared cleanup | [Remove-SampleResources.ps1](Remove-SampleResources.ps1) |
| Python-only selection and admission adapter | [New-SampleDeploymentPlan.ps1](New-SampleDeploymentPlan.ps1), [Invoke-SampleProvisioning.ps1](Invoke-SampleProvisioning.ps1), [PythonSampleCiHelpers.ps1](PythonSampleCiHelpers.ps1) |
| Python-only execution | [select_samples.py](select_samples.py), [run_samples.py](run_samples.py), [sample_ci_attachments.py](sample_ci_attachments.py) |

### Adding resources without editing PowerShell

1. Add a Bicep resource or module to [infra/main.bicep](infra/main.bicep).
   Declare module dependencies using Bicep inputs/outputs, not script-side deployment steps.
   Do not add a sample-selection condition.
2. Expose its non-secret test inputs as explicit uppercase keys in the root
   `output environment object = { ... }` block. Offline planning discovers these keys
   without an Azure login or Bicep compiler. Keep one key per line, using the existing
   format; computed keys and an output built with `union(...)` are not supported.
   The compiled-template check verifies that discovered keys match actual ARM outputs.
3. If a new provider or extra subscription-scoped grant is required, have an
   administrator register the provider or approve and configure the bootstrap grant.
   Workers assume provider registrations and grants for the existing
   project/account/search/function identities already exist; they never check or create them.
   The existing baseline project grants and conditioned Blob Owner grant remain mandatory.
4. Run the offline regression suites and Bicep checker below, then validate live.

No PowerShell changes are needed for ordinary ARM resources and their environment
outputs. The Python runner also registers new output names as pytest options automatically:
it passes only the validated binding **names** through
`AZURE_AI_PROJECTS_TEST_ENVIRONMENT_NAMES`; values still use the existing CLI options.
There is no resource-specific option list or sanitized default for these bindings.
Outside that runner, manual pytest invocations using extra environment CLI options must
set the same metadata first, for example
`$env:AZURE_AI_PROJECTS_TEST_ENVIRONMENT_NAMES = '["NEW_RESOURCE_ENDPOINT"]'`
before passing `--new-resource-endpoint=...`. Only names belong in that JSON array,
not values. Existing preparer-derived options, live/recording flags and playback
defaults are unchanged; directly running a sample script still uses its usual environment.

This is not a generic imperative-task framework. Code publication, data-plane initialization,
specialized quota/readiness checks, new identity types, or secret delivery may still need
reviewed scripts. The shared Function publisher is such an explicit post-deployment step;
its Python handler is a test dependency, not a dependency on the Python SDK test harness.

### Calling from another SDK language

Distribute the shared scripts, the complete [infra](infra) directory, and
[function_app](function_app) together at a pinned revision; keep their relative layout.
The shared entry points require PowerShell 7.2+, Azure CLI with Bicep, and the existing
authorized service-principal context. They do not authenticate on behalf of the caller.
Function remote build uses the packaged handler requirements.

For example, after setting `AZURE_SUBSCRIPTION_ID` and `AZURE_TENANT_ID`:

```powershell
# Offline: no manifest or Python package is required.
.\New-ResourceDeploymentPlan.ps1 -OutputDirectory .\plans\q1 -QueueName q1 `
    -IdentityResourceGroup '<existing-identity-rg>' -DefinitionId 8392 -BuildId 12345 -JobAttempt 1

# Read-only admission; workers must use the resolved plan it writes.
.\Invoke-ResourceProvisioning.ps1 -BatchPlanDirectory .\plans -ResolvedPlanDirectory .\resolved

# Billable deployment; MCP_GITHUB_PAT must be supplied securely in this process's environment.
.\Invoke-ResourceProvisioning.ps1 -PlanPath .\resolved\q1\deployment-plan.json `
    -StatePath .\results\q1\deployment-state.json -QueueName q1 -ConfirmProvisioning
```

The schema-version-1 JSON plan contains numeric run identifiers, queue `q1` through `q4`,
fresh ownership metadata, model configuration, identity resolution, and `environmentBindings`.
The shared planner creates it; callers should not invent resource names or identity bindings.
If running under Azure DevOps, use the actual definition/build/attempt IDs; runtime ownership
checks reject identifiers from another run. Other CI systems must supply equivalent numeric IDs.

After deployment, require state `status=Ready`, then load the state's `environment`
object into the language-specific test process. All bindings are nonempty strings;
only declared non-secret names are accepted. Supply any external validation configuration
separately. Shared admission does not inspect language-specific test metadata; each adapter
must validate its own test partition before calling admission.

In the caller's `finally`/always-run cleanup step, invoke:

```powershell
.\Remove-SampleResources.ps1 -StatePath .\results\q1\deployment-state.json -QueueName q1 -ConfirmCleanup
```

A non-Python adapter and pipeline are not shipped here. The shared interface is prepared
for reuse; cross-language test execution still needs its own adapter and live validation.

## Function App integration

[infra/function-app.bicep](infra/function-app.bicep) translates the Function App infrastructure from the `foundry-project-pool` provisioning script. The pipeline always deploys it and publishes [function_app](function_app) for every active queue, even when no selected sample uses Function or queue bindings. There is no Function enable/disable parameter.

The sample query selects tests, not infrastructure. Every active queue receives the same resource bundle, environment bindings and prerequisite grant checks. Planning still validates each selected sample's required environment-variable names and rejects unsupported samples; that validation never adds or removes resources.

Provisioning values are internal inputs, not environment-variable configuration:

| Input | Source |
| --- | --- |
| Account and project names | Standard module outputs wired directly to dependent modules by the root Bicep template. |
| Agent name | Generated run plan. |
| Model settings | Run plan and validated regional model catalog. |
| `storageAccountName` | Standard setup's storage output. |
| `sharedFunctionIdentityResourceId` | Function UAMI in the admitted shared identity set. |

These values are passed directly to Bicep. [infra/sample-resources.bicepparam](infra/sample-resources.bicepparam) supplies only the existing `MCP_GITHUB_PAT` secret to the secure Bicep parameter; no names, identity IDs, model settings, or Function toggle are read from environment variables there.

The Function template creates a Linux **EP1** plan, a Python **3.11** Function App with Functions host **v4**, and the `weather-input-queue` and `weather-output-queue` queues. Host storage and the queue binding use the existing Function UAMI without storage keys or connection strings. Each run creates a fresh app and declares its complete settings directly; reading and merging that same appsettings resource during deployment would introduce an ARM circular dependency. Premium capacity is billable for every active queue, regardless of sample selection, and must be available in the selected region.

Before any queue can provision resources, admission and worker preflight require preconfigured subscription-scoped Storage Blob Data Owner and Storage Queue Data Contributor grants for the Function identity, and Storage Queue Data Contributor for the project identity. Worker jobs never create these grants. The shared-identity bootstrap includes them for new sets; existing sets require a separately approved grant update.

The pipeline publishes only the three handler package files and checks for `queue_trigger` indexing up to 30 times, ten seconds apart, before starting the sample. This allows for host startup after publication; missing indexing or an Azure query error still fails provisioning. The five non-secret Function outputs become sample inputs: `FUNCTION_APP_NAME`, `FUNCTION_APP_URL`, `STORAGE_INPUT_QUEUE_NAME`, `STORAGE_OUTPUT_QUEUE_NAME`, and `STORAGE_QUEUE_SERVICE_ENDPOINT`. These are sample environment variables, not provisioning configuration. No `FUNCTION_APP_KEY` is retrieved or output.

The package's [pytest environment hook](../../conftest.py) registers these Function inputs
from the runner's binding-name metadata, just like any other provisioned resource.
Both hyphenated and underscored CLI spellings are accepted. No Function-specific option
mapping or sanitized playback default is needed. Explicit CLI values are copied to the
sample environment; an omitted value leaves the existing environment unchanged.

## Safety and results

- **Explicit targets and identity:** task, plan and state subscription/tenant IDs must match the same authorized service-principal identity. No fallback to an active account, another tenant, or a developer's login.
- **Live preflight:** check Search S1 offerings/service quota, Cosmos subscription-region access, the pinned template's Storage SKU restrictions, model availability, and separate account/model quotas. Missing or invalid evidence fails closed. Provider registrations and IAM grants are assumed to exist; missing prerequisites surface as Azure deployment or runtime errors. These checks do not reserve capacity or change region, SKU, registration or policy.
- **Reviewed local Bicep:** [infra/standard-shared-identities.bicep](https://github.com/Azure/azure-sdk-for-python/blob/main/sdk/ai/azure-ai-projects/tests/samples/ci/infra/standard-shared-identities.bicep) is a local UAMI composition based on the unchanged official reference pinned by [infra/standard-setup.lock.json](https://github.com/Azure/azure-sdk-for-python/blob/main/sdk/ai/azure-ai-projects/tests/samples/ci/infra/standard-setup.lock.json), not an unchanged upstream deployment. The official 14 sources remain checksum-verified maintainer references; workers do not download them. State is saved before the first resource mutation.
- **Run-unique names:** the local template retains the full 13-character `uniqueString` hash of the resource group ID and saved deployment timestamp for account, project, Storage, Cosmos DB and Search names. It does not truncate the hash to four characters, which caused global storage-name collisions. The hash stays stable within a plan and changes for each fresh run.
- **Fresh workloads only:** every queue creates a Foundry account/project, Storage, Cosmos DB, Search, three AAD connections, two capability hosts, a native Cosmos data grant, one model deployment, an MCP connection, and its own Function App, hosting plan and queues with published handler code. Only the four selected UAMIs are reused. No worker Azure IAM assignments, Application Insights or ACR are created. `GlobalStandard` inference may run globally despite resource colocation.
- **Secrets:** only provisioning receives the PAT, through an environment-backed Bicep `@secure()` parameter. The connection stores the full Bearer token; the sample receives only its connection ID. No job explicitly maps an ADO access token; the sample subprocess strips any inherited token and the PAT. The external validator endpoint is passed only through the preflight/test environment and excluded from plans, state, Bicep outputs and pytest arguments.
- **Readiness:** bounded read-only retries precede sample execution. An already-started sample is never retried automatically.
- **Logs:** results attach the shared executor's sanitized API/print log and print-only output log through native JUnit markers. Captured console/JUnit reports are redacted; raw sample prints/live logging cannot bypass capture. Only verified run-owned attachment paths are published. Validator input remains the original in-memory output. Logs can still contain test data; use suitable access and retention settings.
- **Cleanup:** each queue's `always()` step attempts deletion after failure/cancellation, verifying its independently supplied queue, exact state/plan binding, full group ID and all four CI purpose/run/owner/queue tags. The group must be absent before recording `CleanedUp`; `-WhatIf` never marks completion. Sibling queues, shared identities/validation resources, permanent grants and separately retained projects are untouched.

Provisioning can incur standing charges. Agent loss, hard termination or Azure errors can prevent cleanup; expiry tags are metadata, **not automatic deletion**. Review state and inventory before manual cleanup. Soft-deleted Foundry records are not purged automatically. Use task errors, per-queue state/inventory and pytest output for troubleshooting; raw secure deployment bodies are suppressed. Compilation and bootstrap verification do not prove live UAMI Standard deployment or sample success.

## Files

| Runtime file | Responsibility |
| --- | --- |
| [New-SampleDeploymentPlan.ps1](https://github.com/Azure/azure-sdk-for-python/blob/main/sdk/ai/azure-ai-projects/tests/samples/ci/New-SampleDeploymentPlan.ps1) | Python compatibility checks and test metadata added to a shared infrastructure plan. |
| [Invoke-SampleProvisioning.ps1](https://github.com/Azure/azure-sdk-for-python/blob/main/sdk/ai/azure-ai-projects/tests/samples/ci/Invoke-SampleProvisioning.ps1) | Python partition validation and delegation to the shared provisioner; preserves existing pipeline calls. |
| [Remove-SampleResources.ps1](https://github.com/Azure/azure-sdk-for-python/blob/main/sdk/ai/azure-ai-projects/tests/samples/ci/Remove-SampleResources.ps1) | Exact queue/ownership-checked cleanup. |
| [SampleCiHelpers.ps1](https://github.com/Azure/azure-sdk-for-python/blob/main/sdk/ai/azure-ai-projects/tests/samples/ci/SampleCiHelpers.ps1) | Language-neutral identity metadata, ownership, output, quota and error-handling guards. |
| [select_samples.py](https://github.com/Azure/azure-sdk-for-python/blob/main/sdk/ai/azure-ai-projects/tests/samples/ci/select_samples.py), [run_samples.py](https://github.com/Azure/azure-sdk-for-python/blob/main/sdk/ai/azure-ai-projects/tests/samples/ci/run_samples.py) | Real sample collection/selection and live pytest invocation. |
| [sample_ci_attachments.py](https://github.com/Azure/azure-sdk-for-python/blob/main/sdk/ai/azure-ai-projects/tests/samples/ci/sample_ci_attachments.py) | Sanitized shared-log attachments and captured report publication. |

## Maintainer validation (separate from sample runs)

Retained Python unit tests live in this directory; mocked PowerShell tests and [the Bicep checker](https://github.com/Azure/azure-sdk-for-python/blob/main/sdk/ai/azure-ai-projects/tests/samples/ci/validation/Test-BicepTemplates.ps1) live under [validation](https://github.com/Azure/azure-sdk-for-python/tree/main/sdk/ai/azure-ai-projects/tests/samples/ci/validation). No new PR pipeline is introduced here.

- With dotenv/live execution disabled, run the Python tests using `--confcutdir=tests/samples/ci` to avoid parent service fixtures.
- Run all PowerShell `*.Tests.ps1` files under validation using **Pester 4.10.1**. The suites isolate Azure calls and cover identity resource-group resolution and metadata checks. On-demand pipeline agents do not need Pester.
- The Bicep checker compiles the root bundle, its three modules, the resource-group template, and the secret-only parameter file with an empty PAT. It checks unconditional modules, environment-contract parity, Function hosting defaults, identity-based settings and non-secret outputs, and rejects Azure IAM writes including nested deployments. Its optional `StandardTemplatePath` input also verifies and compiles the 14 unchanged cached official sources.
- Use the repository Black configuration, PowerShell syntax checks and `git diff --check`. Real harness collection must use `PYTHON_DOTENV_DISABLED=true` and fictional target IDs and must not execute samples.
