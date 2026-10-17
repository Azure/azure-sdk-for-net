# Container integration tests

Running the app without arguments retains the conventional workload identity smoke test.
The `enabled` and `disabled` modes test AKS identity binding against the **local Azure.Core
project**, referenced through the local Azure.Identity project.

## AKS identity binding live tests

These tests follow [Vinay's direct-upload testing guide](https://gist.github.com/g2vinay/147467b7515ef2137c0342e9a7646e26).
They require .NET from the repository's `global.json`, PowerShell 7.4 or later, Azure CLI,
the `aks-preview` extension providing `az aks identity-binding`, `kubectl`, and native `tar`.
Docker, ACR, application secrets, and Azure role assignments are not required.

First create a **dedicated** Azure public-cloud resource group, AKS cluster, and
user-assigned managed identity using the [official identity binding setup instructions](https://learn.microsoft.com/azure/aks/identity-bindings).
Enable workload identity and OIDC on the cluster, without API server VNet integration.
Use two Linux x64, non-B-series nodes with at least four vCPUs and four GiB each;
allow quota for an upgrade node. Tag only the dedicated test group with
`sample=workload-identity-proxy`. Do not grant Azure roles to the test identity or
create a conventional federated identity credential.

Run from this checkout:

```powershell
.\sdk\identity\Azure.Identity\integration\Integration.Identity.Container\Run-WorkloadIdentityBindingTests.ps1 `
    -SubscriptionId '<authorized-subscription-id>' `
    -ResourceGroup '<dedicated-test-group>' `
    -ClusterName '<test-cluster>' `
    -IdentityName '<test-identity>'
```

The runner creates the identity binding if needed, verifies that the identity has
only the AKS-managed FIC, and grants only the `wi-proxy` service account permission
to use that identity. It publishes this checkout, uploads it into two nonroot,
read-only-root-filesystem .NET containers, and requires both Kubernetes Jobs to
complete successfully. Each pod's Azure.Core assembly hash must match the local
published assembly.

| Scenario | Passing result |
| --- | --- |
| Configuration | Webhook-projected identity/token and HTTPS proxy/TLS/CA settings are valid. |
| Async | Valid, unexpired token for the expected tenant and UAMI; actual proxy HTTP traffic observed. |
| Cache | Same token, with no additional HTTP request. |
| Sync | Fresh credential returns a valid token with additional proxy traffic. |
| Concurrent | Four calls on a fresh credential return valid tokens with additional proxy traffic. |
| ARM authentication | The token is accepted by ARM, returning exactly `403 / AuthorizationFailed` because the identity has no resource roles. |
| Disabled | Direct authentication fails with an expected missing-FIC error; zero proxy requests. |

Traffic is measured from `System.Net.Http` established connections and request
headers, not the pre-rewrite `RequestStart` URL. Token claims are checked locally;
the ARM call provides server-side token acceptance. Exact request counts are not
fixed, and this suite does not cover rotation, outages, denied subjects, or scale.

The ignored `artifacts\aks-identity-binding-ga\live-*` directory holds redacted
`enabled.jsonl`, `disabled.jsonl`, and `summary.json`, as well as the separate
**sensitive kubeconfig** and published binaries. Share only the three result files.
Failures return a nonzero exit code and never log tokens or assertions.

The runner leaves the dedicated resources available for investigation or another run.
After testing, delete only the dedicated group to stop ongoing AKS costs:

```powershell
az group delete --subscription '<authorized-subscription-id>' `
    --name '<dedicated-test-group>' --yes
```
