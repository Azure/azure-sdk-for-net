# Key Vault issue investigation context

This file provides service-level context for the agentic issue investigation workflow. It is advisory context only; the workflow should also inspect the package README, CHANGELOG, and `sdk/keyvault/TROUBLESHOOTING.md`.

## Known service behaviors

### Soft-delete recovery window conflict

Azure Key Vault uses soft-delete by default. When a vault or object is deleted, it enters a recovery window. During this period, creating a new resource with the same name can return HTTP 409 Conflict. This is intended behavior to protect against accidental data loss.

Resolution: purge the soft-deleted resource first, recover it, or wait for the retention period to expire.

Docs:
- https://learn.microsoft.com/azure/key-vault/general/soft-delete-overview
- https://learn.microsoft.com/azure/key-vault/general/key-vault-recovery

### Throttling at vault operation limits

Azure Key Vault enforces service limits. Exceeding those limits can return HTTP 429 Too Many Requests. This is intended service protection behavior.

Resolution: use retry with exponential backoff, cache frequently-read secrets or keys, and distribute high-volume workloads when needed.

Docs:
- https://learn.microsoft.com/azure/key-vault/general/service-limits
- https://learn.microsoft.com/azure/key-vault/general/overview-throttling

### Certificate import key-certificate mismatch

When importing a certificate into Key Vault, the private key must match the certificate. A mismatch returns HTTP 400 Bad Request as expected validation behavior.

Resolution: verify the PFX or PEM contains the correct matching private key and certificate chain.

Docs:
- https://learn.microsoft.com/azure/key-vault/certificates/tutorial-import-certificate
- https://learn.microsoft.com/azure/key-vault/certificates/about-certificates

### Access policies replaced on ARM deployment

When deploying a Key Vault via ARM templates, Bicep, or Terraform, the access policies property is treated as a full replacement, not a merge. If the template does not include all existing access policies, unlisted policies are removed.

Resolution: migrate to Azure RBAC for Key Vault data-plane access, include all existing access policies in the template, or use the accessPolicies sub-resource for incremental updates.

Docs:
- https://learn.microsoft.com/azure/key-vault/general/assign-access-policy
- https://learn.microsoft.com/azure/key-vault/general/rbac-migration

### Firewall blocks access from unexpected IP

When Key Vault firewall rules are enabled, requests from IPs or VNets not in the allow list can return HTTP 403 Forbidden. This is intended security behavior.

Resolution: add the client IP or VNet to the firewall allow list, use Private Endpoint, or configure trusted service access when appropriate.

Docs:
- https://learn.microsoft.com/azure/key-vault/general/network-security
- https://learn.microsoft.com/azure/key-vault/general/overview-vnet-service-endpoints

### RBAC role assignment propagation delay

Azure RBAC changes can take time to propagate. A user or managed identity may receive HTTP 403 shortly after a role assignment even when the assignment is correct.

Resolution: wait for RBAC propagation, verify the identity and scope, and retry after propagation completes.

Docs:
- https://learn.microsoft.com/azure/role-based-access-control/troubleshooting

### Wrong token audience for Key Vault

Key Vault data-plane requests require a token for the Key Vault audience. A token for the wrong resource or scope can result in HTTP 401.

Resolution: request a token for the Key Vault data-plane audience and verify the credential is configured for the correct cloud.

Docs:
- https://learn.microsoft.com/azure/key-vault/general/authentication

### Wrong tenant or identity used for authorization

Authentication can succeed with an unexpected tenant or identity, but Key Vault authorization can still fail because permissions were granted to a different principal.

Resolution: verify the tenant, client ID, managed identity, and object ID used by the application.

Docs:
- https://learn.microsoft.com/azure/key-vault/general/authentication
- https://learn.microsoft.com/dotnet/azure/sdk/authentication

### Purge protection prevents immediate permanent deletion

When purge protection is enabled, Key Vault prevents immediate permanent deletion during the retention period. This is intended data-protection behavior.

Resolution: plan for the retention period and avoid relying on immediate name reuse or permanent deletion when purge protection is enabled.

Docs:
- https://learn.microsoft.com/azure/key-vault/general/soft-delete-overview

### Private endpoint DNS misconfiguration

Key Vault private endpoint access depends on correct DNS resolution. Misconfigured DNS can send traffic to the wrong endpoint or fail access checks.

Resolution: verify private DNS zone configuration and confirm the vault hostname resolves to the expected private endpoint IP from the client network.

Docs:
- https://learn.microsoft.com/azure/key-vault/general/private-link-service

### Managed identity is not enabled or not granted access

A managed identity must be enabled on the hosting resource and granted Key Vault data-plane access before it can read secrets, keys, or certificates.

Resolution: verify the managed identity is enabled, confirm the runtime identity, and grant the required Key Vault role or access policy.

Docs:
- https://learn.microsoft.com/azure/key-vault/general/authentication
- https://learn.microsoft.com/azure/app-service/overview-managed-identity

### RBAC and access policy authorization model mismatch

Key Vault can use either Azure RBAC or vault access policies for data-plane authorization. Configuring permissions in the inactive model can result in access failures.

Resolution: check the vault permission model and configure either Azure RBAC roles or access policies according to the active model.

Docs:
- https://learn.microsoft.com/azure/key-vault/general/rbac-guide
- https://learn.microsoft.com/azure/key-vault/general/rbac-migration

### Disabled or expired secret, key, or certificate

Key Vault objects can be disabled or expired. Operations against disabled or expired objects can fail even when the caller has permissions.

Resolution: check object attributes, enable the object if appropriate, or update expiration settings.

Docs:
- https://learn.microsoft.com/azure/key-vault/secrets/about-secrets
- https://learn.microsoft.com/azure/key-vault/keys/about-keys

### Managed HSM endpoint used with vault client or vault endpoint used with HSM client

Managed HSM and standard Key Vault use different endpoint types and supported APIs. Using the wrong client or endpoint can produce expected configuration failures.

Resolution: use the client and endpoint type that match the resource: standard vault clients for vault endpoints, and supported key/crypto clients for Managed HSM endpoints.

Docs:
- https://learn.microsoft.com/azure/key-vault/managed-hsm/overview
- https://learn.microsoft.com/azure/key-vault/general/about-keys-secrets-certificates
