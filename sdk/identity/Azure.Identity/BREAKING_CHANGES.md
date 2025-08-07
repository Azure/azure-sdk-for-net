# Breaking Changes

## 1.11.0

### Behavioral change to `DefaultAzureCredential` in IMDS managed identity scenarios

As of `Azure.Identity` 1.11.0, the `DefaultAzureCredential` makes a couple minor behavioral changes to request timeout and retry behavior in environments where IMDS managed identity is used. The changes are as follows:
- The first request made to IMDS managed identity will be made with a 1-second timeout, as it did previously, but without the "Metadata" header to expedite validating whether the endpoint is available. This is guaranteed to fail with a 400 error.
    - If the request times out, indicating that the IMDS endpoint isn't available, no retries will be made. This is a change from the previous behavior, where the request was retried up to 3 times, with exponential backoff.
    - If the request returns a 400 error, indicating that the IMDS endpoint is available, the request will be retried up to 4 times, with exponential backoff, to allow for transient failures.

If more retries are needed for IMDS managed identity scenarios, a custom `RetryPolicy` can be specified in the `DefaultAzureCredentialOptions`. More information on how to customize the retry policy can be found [here](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/Configuration.md#setting-a-custom-retry-policy).

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
