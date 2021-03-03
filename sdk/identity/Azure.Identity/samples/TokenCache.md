# Persisting the credential TokenCache

Many credential implementations in the Azure.Identity library have an underlying `TokenCache` which caches sensitive authentication data such as account information, access tokens, and refresh tokens. By default this `TokenCache` instance is an in memory cache which is specific to the credential instance. However, there are scenarios where an application needs to share the token cache across credentials, and persist it across executions. To accomplish this the Azure.Identity provides the `TokenCache` and `TokenCache` classes.

>IMPORTANT! The `TokenCache` contains sensitive data and **MUST** be protected to prevent compromising accounts. All application decisions regarding the storage of the `TokenCache` must consider that a breach of its content will fully compromise all the accounts it contains.

## Using the default TokenCache

The simplest way to persist the `TokenCache` of a credential is to to use the default `TokenCache`. This will persist and read the `TokenCache` from a shared persisted token cache protected to the current account.

```C# Snippet:Identity_TokenCache_PersistentDefault
var credential = new InteractiveBrowserCredential(
    new InteractiveBrowserCredentialOptions
    {
        TokenCachePersistenceOptions = new TokenCachePersistenceOptions()
    });
```

## Using a named TokenCache

Some applications may prefer to isolate the `TokenCache` they user rather than using the shared instance. To accomplish this they can specify a `TokenCacheOptions` when creating the `TokenCache` and provide a `Name` for the persisted cache instance.

```C# Snippet:Identity_TokenCache_PersistentNamed
var persistenceOptions = new TokenCachePersistenceOptions { Name = "my_application_name" };

var credential = new InteractiveBrowserCredential(
    new InteractiveBrowserCredentialOptions { TokenCachePersistenceOptions = persistenceOptions }
);
```

## Allowing unencrypted storage

By default the `TokenCache` will protect any data which is persisted using the user data protection APIs available on the current platform. However, there are cases where no data protection is available, and applications may choose to still persist the token cache in an unencrypted state. This is accomplished with the `AllowUnencryptedStorage` option.

```C# Snippet:Identity_TokenCache_PersistentUnencrypted
var persistenceOptions = new TokenCachePersistenceOptions { AllowUnencryptedStorage = true };

var credential = new InteractiveBrowserCredential(
    new InteractiveBrowserCredentialOptions { TokenCachePersistenceOptions = persistenceOptions }
);
```

By setting `AllowUnencryptedStorage` to `true`, the `TokenCache` will encrypt the contents of the `TokenCache` before persisting it if data protection is available on the current platform, otherwise it will write and read the `TokenCache` data to an unencrypted local file ACL'd to the current account. If `AllowUnencryptedStorage` is `false` (the default) a `CredentialUnavailableException` will be raised in the case no data protection is available.
