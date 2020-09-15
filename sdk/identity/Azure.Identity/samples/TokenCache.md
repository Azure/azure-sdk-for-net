# Persisting the credential TokenCache
Many credential implementations in the Azure.Identity library have an underlying `TokenCache` which caches sensitive authentication data such as account information, access tokens, and refresh tokens. By default this `TokenCache` instance is an in memory cache which is specific to the credential instance. However, there are scenarios where an application needs to share the token cache across credentials, and persist it across executions. To accomplish this the Azure.Identity provides the `TokenCache` and `PeristantTokenCache` classes.

>IMPORTANT! The `TokenCache` contains sensitive data and **MUST** be protected to prevent compromising accounts. All application decisions regarding the storage of the `TokenCache` must consider that a breach of its content will fully compromise all the accounts it contains.

## Using the default PersistentTokenCache

The simplest way to persist the `TokenCache` of a credential is to to use the default `PersistentTokenCache`. This will persist and read the `TokenCache` from a shared persisted token cache protected to the current account.

```C# Snippet:Identity_TokenCache_PersistentDefault
var credential = new InteractiveBrowserCredential(new InteractiveBrowserCredentialOptions { TokenCache = new PersistentTokenCache() });
```

## Using a named PersistentTokenCache

Some applications may prefer to isolate the `PersistentTokenCache` they user rather than using the shared instance. To accomplish this they can specify a `PersistentTokenCacheOptions` when creating the `PersistentTokenCache` and provide a `Name` for the persisted cache instance.

```C# Snippet:Identity_TokenCache_PersistentNamed
var tokenCache = new PersistentTokenCache(new PersistentTokenCacheOptions { Name = "my_application_name" });

var credential = new InteractiveBrowserCredential(new InteractiveBrowserCredentialOptions { TokenCache = tokenCache });
```

## Allowing unencrypted storage
By default the `PersistentTokenCache` will protect any data which is persisted using the user data protection APIs available on the current platform. However, there are cases where no data protection is available, and applications may choose to still persist the token cache in an unencrypted state. This is accomplished with the `AllowUnencryptedStorage` option.

```C# Snippet:Identity_TokenCache_PersistentUnencrypted
var tokenCache = new PersistentTokenCache(new PersistentTokenCacheOptions { AllowUnencryptedStorage = true });

var credential = new InteractiveBrowserCredential(new InteractiveBrowserCredentialOptions { TokenCache =  tokenCache});
```
By setting `AllowUnencryptedStorage` to `true`, the `PersistentTokenCache` will encrypt the contents of the `TokenCache` before persisting it if data protection is available on the current platform, otherwise it will write and read the `TokenCache` data to an unencrypted local file ACL'd to the current account. If `AllowUnencryptedStorage` is `false` (the default) a `CredentialUnavailableException` will be raised in the case no data protection is available.

## Implementing custom TokenCache persistence 
Some applications may require complete control of how the `TokenCache` is persisted. To enable this the `TokenCache` provides the methods `Serialize`, `SerializeAsync`, `Deserialize` and `DeserializeAsync` methods so applications can write the `TokenCache` to any stream. The following samples illustrate how to use these serialization methods to write and read the cache from a stream. 

> IMPORTANT! This sample assumes the location of the file it is using for storage is secure. The `Serialize` and `SerializeAsync` methods will write the unencrypted content of the `TokenCache` to the provide stream. It is the responsibility the implementer to properly protect the `TokenCache` data.

The `Serialize` or `SerializeAsync` methods can be used to write out content of a `TokenCache` to any writeable stream.

```C# Snippet:Identity_TokenCache_CustomPersistence_Write
using var cacheStream = new FileStream(TokenCachePath, FileMode.Create, FileAccess.Write);

await tokenCache.SerializeAsync(cacheStream);
```

The `Deserialize` or `DeserializeAsync` methods can be used to read the content of a `TokenCache` from any readable stream.

```C# Snippet:Identity_TokenCache_CustomPersistence_Read
using var cacheStream = new FileStream(TokenCachePath, FileMode.OpenOrCreate, FileAccess.Read);

var tokenCache = await TokenCache.DeserializeAsync(cacheStream);
```

Applications can combine these methods along with the `Updated` event to automatically persist and read the token from a storage solution of their choice.
```C# Snippet:Identity_TokenCache_CustomPersistence_Usage
public static async Task<TokenCache> ReadTokenCacheAsync()
{
    using var cacheStream = new FileStream(TokenCachePath, FileMode.OpenOrCreate, FileAccess.Read);

    var tokenCache = await TokenCache.DeserializeAsync(cacheStream);

    tokenCache.Updated += WriteCacheOnUpdateAsync;

    return tokenCache;
}

public static async Task WriteCacheOnUpdateAsync(TokenCacheUpdatedArgs args)
{
    using var cacheStream = new FileStream(TokenCachePath, FileMode.Create, FileAccess.Write);

    await args.Cache.SerializeAsync(cacheStream);
}

public static async Task Main()
{
    var tokenCache = await ReadTokenCacheAsync();

    var credential = new InteractiveBrowserCredential(new InteractiveBrowserCredentialOptions { TokenCache = tokenCache });
}
```