# Breaking Changes

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

## 1.7.0

### Changed Credential types supporting multi-tenant authentication to throw `AuthenticationFailedException` if the requested tenant id doesn't match the tenant id of the credential, and is not included in the `AdditionallyAllowedTenants` option.

Starting in Azure.Identity 1.7.0 the default behavior of credentials supporting multi-tenant authentication will be to throw a `AuthenticationFailedExcpetion` if the requested `TenantId` doesn't match the tenant id originally configured on the credential. Applications must now either explicitly add all expected tenant ids to the `AdditionallyAllowedTenants` list in the credential options, or add "*" to enable acquiring tokens from any tenant (the original behavior).

This is an example of explicitly adding tenants to allow acquiring tokens.

```C# Snippet:Identity_BreakingChanges_AddExplicitAdditionallyAllowedTenants
var credential = new DefaultAzureCredential(new DefaultAzureCredentialOptions
{
    AdditionallyAllowedTenants = { "0000-0000-0000-0000", "1111-1111-1111-1111" }
});
```

Here is an example of using the wildcard to enable acquiring tokens from any tenant, to be compatible with versions 1.5.0 through 1.6.1.

```C# Snippet:Identity_BreakingChanges_AddAllAdditionallyAllowedTenants
var credential = new DefaultAzureCredential(new DefaultAzureCredentialOptions
{
    AdditionallyAllowedTenants = { "*" }
});
```

Note: Credential types which do not require a `TenantId` on construction will only throw `AuthenticationFailedException` when the application has provided a value for `TenantId` either in the options or via a constructor overload. If no `TenantId` is specified when constructing the credential, the credential will acquire tokens for any requested `TenantId` regardless of the value of `AdditionallyAllowedTenants`.