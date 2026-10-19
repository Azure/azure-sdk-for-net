# AKS identity binding live tests

`WorkloadIdentityBindingLiveTests` is an Azure.Core-owned NUnit fixture marked
`[LiveOnly]`. Its two tests exercise the guide's proxy-enabled scenarios and
proxy-disabled negative case against the local Azure.Core project. Neither the
tests nor their runner depend on the Azure.Identity integration application.
This directory is outside the legacy `tests\Identity` sources shared with
Azure.Identity.Tests.

The tests require .NET 8 or later. The deployment runner uses .NET 10 from the
repository's `global.json`, PowerShell 7.4 or later, Azure CLI, the `aks-preview`
extension providing `az aks identity-binding`, `kubectl`, and native `tar`.
Docker, ACR, application secrets, and Azure role assignments are not required.

## Resources and execution

Follow [Vinay's direct-upload testing guide](https://gist.github.com/g2vinay/147467b7515ef2137c0342e9a7646e26)
and the [official identity binding setup instructions](https://learn.microsoft.com/azure/aks/identity-bindings)
to create a dedicated Azure public-cloud resource group, AKS cluster, and
user-assigned managed identity. Enable workload identity and OIDC without API
server VNet integration. Use two Linux x64, non-B-series nodes with at least four
vCPUs and four GiB each, and allow quota for an upgrade node.

Tag only the dedicated group with `sample=workload-identity-proxy`. Do not grant
Azure roles to the test identity or add a conventional federated identity
credential.

Run from this checkout:

```powershell
.\sdk\core\Azure.Core\tests\IdentityBinding\Run-WorkloadIdentityBindingTests.ps1 `
    -SubscriptionId '<authorized-subscription-id>' `
    -ResourceGroup '<dedicated-test-group>' `
    -ClusterName '<test-cluster>' `
    -IdentityName '<test-identity>'
```

The runner verifies the binding, sole AKS-managed FIC, and absence of Azure roles.
It grants only the `wi-proxy` service account permission to use the identity,
publishes `Azure.Core.Tests.csproj`, and directly uploads the published tests into
two nonroot, read-only-root-filesystem .NET SDK containers.

Each Kubernetes Job executes one test from `Azure.Core.Tests.dll` using
`dotnet vstest`, `AZURE_TEST_MODE=Live`, and
`AZURE_CORE_IDENTITY_BINDING_TESTS=true`. The runner requires genuine TRX counters
showing exactly one passed test per Job, the expected NUnit test identity, and
matching locally published/running Azure.Core assembly hashes. A skipped or
undiscovered test cannot count as success.

The fixture is excluded from Record/Playback by `[LiveOnly]`. Other live-test
hosts skip it with an explicit reason unless the opt-in variable is set; when
opted in, missing or invalid AKS settings fail the test.

| Scenario | Passing result |
| --- | --- |
| Configuration | Webhook-projected identity/token and HTTPS proxy/TLS/CA settings are valid. |
| Async | Valid, unexpired token for the expected tenant/UAMI; actual proxy HTTP traffic observed. |
| Cache | Same token, with no additional HTTP request. |
| Sync | Fresh credential returns a valid token with additional proxy traffic. |
| Concurrent | Four calls on a fresh credential return valid tokens with additional proxy traffic. |
| ARM authentication | Exactly `403 / AuthorizationFailed`, confirming server acceptance without resource roles. |
| Disabled | Expected missing-FIC error from direct authentication; zero proxy requests. |

Traffic is measured from established `System.Net.Http` connections and request
headers, not the pre-rewrite `RequestStart` URL. Token claims are checked locally;
the ARM call verifies server acceptance. Exact request counts are not fixed.
Rotation, outages, denied subjects, and scale are outside this guide's matrix.

## Results and cleanup

The ignored `artifacts\aks-identity-binding-ga\live-*` directory holds redacted
`enabled.jsonl`, `disabled.jsonl`, and `summary.json`, NUnit console logs,
published binaries, and a separate **sensitive kubeconfig**. Share only the three
redacted JSON result files. Failures return a nonzero exit code without logging
tokens or assertions.

The runner leaves its dedicated resources available for investigation or another
run. Delete only the dedicated group after testing:

```powershell
az group delete --subscription '<authorized-subscription-id>' `
    --name '<dedicated-test-group>' --yes
```
