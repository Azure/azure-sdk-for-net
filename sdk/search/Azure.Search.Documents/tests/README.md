# Recording against existing resources

Copy [`.env.example`](../.env.example) to `.env` in the package root
(`sdk/search/Azure.Search.Documents/.env`), fill in the resource values, and
follow its prerequisite comments. `.env` is git-ignored. No resources, keys,
or role assignments are created by the loader.

From the repository root, in PowerShell 7.5+:

```powershell
az login --tenant <tenant-id>
. .\sdk\search\Azure.Search.Documents\tests\Set-RecordingEnvironment.ps1
dotnet test .\sdk\search\Azure.Search.Documents\tests\Azure.Search.Documents.Tests.csproj --framework net10.0 --filter $env:SEARCH_RECORDING_TEST_FILTER
```

Alternatively, pass `-EnvFile <path>` to load a different `.env` file.
Set `AZURE_TEST_MODE=Record`, `Live`, or `Playback` in `.env`.
Changes apply only to the current process and its children; an already-running
IDE does not inherit them. The framework starts the recording proxy automatically.
The test fixtures currently target API version `2026-10-01`.
The example separates common settings, GA dependencies, and preview-only
Fabric/Work IQ settings. Leave the preview-only values empty for GA recordings.
Filling them in does not enable preview APIs in this GA SDK/test fixture.

The loader supports `NAME=value`, empty values, full-line `#` comments, and
optional matching single/double quotes around values. Values are literal: no
interpolation, command execution, multiline values, or inline comments.
Keep real configuration and authorization tokens out of source control.

All live/recorded tests, samples, and batching clients use token credentials.
The runner uses its Azure CLI login; Search uses its system-assigned identity
for outbound Storage, AI Services, OpenAI, and Key Vault access.
Grant the Search identity Cognitive Services User on AI Services and Key Vault
Crypto Service Encryption User on the Key Vault for the relevant scenarios.
The runner needs Key Vault Crypto Officer to create keys in the encryption sample.
Fake-key unit tests still exercise key-based SDK constructors without live calls.
Update the filter in an existing `.env` from the example to include all tests.
Other `PlaybackOnly`, `LiveOnly`,
and ignored tests retain their restrictions. The encryption test has an explicit
opt-in described below. Keyless query tests use the runner
identity rather than a separate read-only query key. Missing resources or model
deployments can cause relevant tests to fail or skip.

Most old key-based recordings must be regenerated to match bearer authentication;
the encryption fixture retains the scoped offline compatibility path described
below. Review sanitized recordings before sharing and follow the repository's
test-proxy asset workflow to persist them.

## Customer-managed encryption test

`EncryptedIndex.CreateDoubleEncryptedIndex` supports offline Playback and
explicitly opted-in Record/Live runs against **existing, dedicated resources**.
Loading `.env` does not provision anything. The fixture remains pinned to
`V2024_07_01` for compatibility with its existing recording, unlike the main
`V2026_10_01` fixtures.

### Resources and configuration

Provision these resources before recording; do not use production resources:

| Resource | Required configuration |
| --- | --- |
| Azure AI Search | Basic or higher; enable RBAC authentication and the **system-assigned managed identity**. Leave capacity for an index, data source, and indexer. |
| Storage account | Blob storage available. The account name and full ARM resource ID in `.env` must refer to the same account. |
| Azure Key Vault | Use a vault, not Managed HSM, with **Azure RBAC**, **soft delete**, and **purge protection** enabled. This test creates its own RSA-2048 key with wrap/unwrap operations; no pre-created key is needed. |

Use the same Microsoft Entra tenant for the runner, Search managed identity,
and vault for this setup. OpenAI, AI Services, semantic ranking, Fabric,
application secrets, and storage account keys are **not** needed by this test.
It sets a CMK on the data source and indexer; the shared helper creates the
temporary Hotels index without an explicit CMK. Do not enable a service-wide
CMK enforcement policy just for this test: it can reject that index creation.

The runner and Search service are **different identities**. Assign the following
roles at the listed resources, not indiscriminately across the subscription:

| Principal | Role | Assignment scope | Purpose |
| --- | --- | --- | --- |
| Runner's `az login` identity | Search Service Contributor | Search service | Create/delete index, data source, and indexer; run/check indexer. |
| Runner's `az login` identity | Search Index Data Reader | Search service | Query the indexed documents. Existing Search Index Data Contributor also covers this. |
| Runner's `az login` identity | Storage Blob Data Contributor | Storage account | Create/delete the random container and upload sample blobs. |
| Runner's `az login` identity | Key Vault Crypto Officer | Key vault | Create and soft-delete the randomly named key, including reading deletion status. |
| Search service's system-assigned managed identity | Storage Blob Data Reader | Storage account | Let the indexer read the sample blobs using `ResourceId=...;`. |
| Search service's system-assigned managed identity | Key Vault Crypto Service Encryption User | Key vault | Read key metadata and wrap/unwrap encryption keys for the encrypted objects. |

Vault/account scope is intentional because the test creates randomly named keys
and containers. A resource-group Contributor/Owner role alone does not supply
these data-plane permissions. The person doing the setup separately needs
permission to create resources and assign roles (for example, Contributor plus
Role Based Access Control Administrator at the appropriate scope). The test
does not assign roles. Allow time for assignments to propagate.

Network rules must allow **both** paths:

* Runner -> Search endpoint, Storage blob endpoint, Key Vault endpoint, and
  Microsoft Entra ID.
* Search managed identity -> Storage and Key Vault. If firewalls are enabled,
  configure the documented trusted-service/resource-instance exceptions or
  private connectivity; RBAC does not bypass firewalls. Enabling trusted services
  for Search does not automatically give your developer machine access.

See [Search customer-managed keys](https://learn.microsoft.com/azure/search/search-security-manage-encryption-keys)
and [managed-identity storage connections](https://learn.microsoft.com/azure/search/search-howto-managed-identities-storage)
for supported network configurations.

### Configure and record just this test

In the package's git-ignored `.env`, fill in these values (the doubled
`SEARCH_SEARCH_` prefix is intentional):

```dotenv
SEARCH_SEARCH_SERVICE_NAME=your-search-service
SEARCH_TENANT_ID=your-tenant-id
SEARCH_SEARCH_STORAGE_NAME=yourstorageaccount
SEARCH_SEARCH_STORAGE_RESOURCE_ID=/subscriptions/your-subscription-id/resourceGroups/your-resource-group/providers/Microsoft.Storage/storageAccounts/yourstorageaccount
SEARCH_SEARCH_KEYVAULT_URL=https://your-vault.vault.azure.net/
```

Keep `SEARCH_CLIENT_SECRET=` and `SEARCH_SYSTEM_ACCESSTOKEN=` empty to mask stale
service-principal settings. Local runs use the runner's Azure CLI identity.
Storage resource IDs are not connection strings or blob URLs.

Run the following **only when you approve creating/deleting the test objects**,
from the repository root in the same PowerShell process:

```powershell
.\Set-RecordingEnvironment.ps1
$env:AZURE_DISABLE_BOOTSTRAPPING = 'true'
$env:AZURE_DISABLE_AUTO_RECORDING = 'true'
$env:AZURE_TEST_MODE = 'Record'
$env:AZURE_LIVE_TEST_SERVICE_VERSIONS = 'V2024_07_01'
$env:SEARCH_RUN_DOUBLE_ENCRYPTED_INDEX = 'true'
try {
    dotnet test Azure.Search.Documents.Tests.csproj --framework net10.0 --filter 'FullyQualifiedName~CreateDoubleEncryptedIndex'
}
finally {
    $env:SEARCH_RUN_DOUBLE_ENCRYPTED_INDEX = 'false'
    $env:AZURE_TEST_MODE = 'Playback'
    Remove-Item Env:\AZURE_LIVE_TEST_SERVICE_VERSIONS -ErrorAction SilentlyContinue
}
```

The test validates missing/malformed configuration before its first Azure call.
It does not remotely verify role assignments or firewall rules. An already-open
IDE/test host does not inherit variables from this PowerShell process; use the
command above or configure the same variables explicitly for that test host.

### Playback and cleanup

Playback does **not** need `.env`, Azure CLI login, an opt-in, or Azure resources.
It uses only recorded variables. The old recording uses its recorded storage key
and Search API key because it predates the keyless test setup; this compatibility
path is restricted to Playback. Live/Record always uses the storage resource ID,
the runner's token credential, and the Search managed identity. Do not rename
your `.env` setting to try to repair an old recording, and do not change the
shared test framework to read live settings
during Playback.

To verify the recording offline:

```powershell
$env:AZURE_TEST_MODE = 'Playback'
$env:AZURE_DISABLE_BOOTSTRAPPING = 'true'
$env:AZURE_DISABLE_AUTO_RECORDING = 'true'
dotnet test .\sdk\search\Azure.Search.Documents\tests\Azure.Search.Documents.Tests.csproj --framework net10.0 --filter 'FullyQualifiedName~CreateDoubleEncryptedIndex'
```

For new recordings/live runs, cleanup deletes the indexer and data source,
disposes the temporary index/container, then **soft-deletes** the generated vault
key. It never purges the key or changes your vault's purge protection. The
soft-deleted key remains for the configured retention period. Older recordings
contain no key-deletion request and are replayed unchanged.

If setup or cleanup fails, inspect the dedicated resources for leftovers before
retrying. In particular, do not delete a key still referenced by an encrypted
Search object: restore access and delete those objects first. A failed cleanup
is reported as a test failure, not silently ignored.
