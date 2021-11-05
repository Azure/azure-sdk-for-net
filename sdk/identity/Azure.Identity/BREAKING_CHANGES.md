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