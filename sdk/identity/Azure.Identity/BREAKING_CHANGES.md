# Breaking Changes

## 1.7.0

### Behavioral change to credential types supporting multi-tenant authentication

As of `Azure.Identity` 1.7.0, the default behavior of credentials supporting multi-tenant authentication has changed. Each of these credentials will throw an `AuthenticationFailedException` if the requested `TenantId` doesn't match the tenant ID originally configured on the credential. Apps must now do one of the following things:

- Add all IDs, of tenants from which tokens should be acquired, to the `AdditionallyAllowedTenants` list in the credential options. For example:

```C# Snippet:Identity_BreakingChanges_AddExplicitAdditionallyAllowedTenants
var credential = new DefaultAzureCredential(new DefaultAzureCredentialOptions
{
    AdditionallyAllowedTenants = { "<tenant_id_1>", "<tenant_id_2>" }
});
```

- Add `*` to enable token acquisition from any tenant. This is the original behavior and is compatible with previous versions supporting multi tenant authentication. For example:

```C# Snippet:Identity_BreakingChanges_AddAllAdditionallyAllowedTenants
var credential = new DefaultAzureCredential(new DefaultAzureCredentialOptions
{
    AdditionallyAllowedTenants = { "*" }
});
```

Note: Credential types which do not require a `TenantId` on construction will only throw `AuthenticationFailedException` when the application has provided a value for `TenantId` either in the options or via a constructor overload. If no `TenantId` is specified when constructing the credential, the credential will acquire tokens for any requested `TenantId` regardless of the value of `AdditionallyAllowedTenants`.

More information on this change and the consideration behind it can be found [here](https://aka.ms/azsdk/blog/multi-tenant-guidance).

## 1.4.0

### Changed `ExcludeSharedTokenCacheCredential` default value from __false__ to __true__ on `DefaultAzureCredentialsOptions`

Starting in Azure.Identity 1.4.0-beta.4 the default value of the `ExcludeSharedTokenCacheCredential` property on `DefaultAzureCredentialsOptions` has changed from __false__ to __true__, excluding the `SharedTokenCacheCredential` from the `DefaultAzureCredential` authentication flow by default. We expect that few users will be impacted by this change as the `VisualStudioCredential` has effectively replaced the `SharedTokenCacheCredential` in this authentication flow. However, users who find this change does negatively impact them can still invoke the old behavior by explicitly setting the value to false.

```C# Snippet:Identity_BreakingChanges_SetExcludeSharedTokenCacheCredentialToFalse
var credential = new DefaultAzureCredential(new DefaultAzureCredentialOptions
{
    ExcludeSharedTokenCacheCredential = false
});
```

More information on this change and the consideration behind it can be found [here](https://github.com/Azure/azure-sdk/issues/1970).