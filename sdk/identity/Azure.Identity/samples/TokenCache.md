# Persisting credentials by configuring TokenCachePersistenceOptions

Many credential implementations in the Azure.Identity library have an underlying token cache which persists sensitive authentication data such as account information, access tokens, and refresh tokens.
By default this data exists in an in memory cache which is specific to the credential instance.
However, there are scenarios where an application needs persist it across executions in order to share the token cache across credentials.
To accomplish this the Azure.Identity provides the `TokenCachePersistenceOptions`.

>IMPORTANT! The token cache contains sensitive data and **MUST** be protected to prevent compromising accounts. All application decisions regarding the persistence of the token cache must consider that a breach of its content will fully compromise all the accounts it contains.

## Using the default token cache

The simplest way to persist the token data for a credential is to to use the default `TokenCachePersistenceOptions`.
This will persist and read token data from a shared persisted token cache protected to the current account.

```C# Snippet:Identity_TokenCache_PersistentDefault
var credential = new InteractiveBrowserCredential(
    new InteractiveBrowserCredentialOptions
    {
        TokenCachePersistenceOptions = new TokenCachePersistenceOptions()
    });
```

## Using a named token cache

Some applications may prefer to isolate the token cache they use rather than using the shared instance.
To accomplish this they can specify the `TokenCachePersistenceOptions` when creating the credential and provide a `Name` for the persisted cache instance.

```C# Snippet:Identity_TokenCache_PersistentNamed
var persistenceOptions = new TokenCachePersistenceOptions { Name = "my_application_name" };

var credential = new InteractiveBrowserCredential(
    new InteractiveBrowserCredentialOptions { TokenCachePersistenceOptions = persistenceOptions }
);
```

## Allowing unencrypted storage

By default the token cache will protect any data which is persisted using the user data protection APIs available on the current platform.
However, there are cases where no data protection is available, and applications may choose to still persist the token cache in an unencrypted state.
This is accomplished with the `UnsafeAllowUnencryptedStorage` option.

```C# Snippet:Identity_TokenCache_PersistentUnencrypted
var persistenceOptions = new TokenCachePersistenceOptions { UnsafeAllowUnencryptedStorage = true };

var credential = new InteractiveBrowserCredential(
    new InteractiveBrowserCredentialOptions { TokenCachePersistenceOptions = persistenceOptions }
);
```

By setting `UnsafeAllowUnencryptedStorage` to `true`, the credential will encrypt the contents of the token cache before persisting it if data protection is available on the current platform.
If platform data protection is unavailable, it will write and read the persisted token data to an unencrypted local file ACL'd to the current account.
If `UnsafeAllowUnencryptedStorage` is `false` (the default), a `CredentialUnavailableException` will be raised in the case no data protection is available.
