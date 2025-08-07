# Token caching in the Azure Identity client library

*Token caching* is a feature provided by the Azure Identity library. The feature allows apps to:

- Improve their resilience and performance.
- Reduce the number of requests made to Microsoft Entra ID to obtain access tokens.
- Reduce the number of times the user is prompted to authenticate.

When an app needs to access a protected Azure resource, it typically needs to obtain an access token from Microsoft Entra ID. Obtaining that token involves sending a request to Microsoft Entra ID and may also involve prompting the user. Microsoft Entra ID then validates the credentials provided in the request and issues an access token.

Token caching, via the Azure Identity library, allows the app to store this access token [in memory](#in-memory-token-caching), where it's accessible to the current process, or [on disk](#persistent-token-caching) where it can be accessed across application or process invocations. The token can then be retrieved quickly and easily the next time the app needs to access the same resource. The app can avoid making another request to Microsoft Entra ID, which reduces network traffic and improves resilience. Additionally, in scenarios where the app is authenticating users, token caching also avoids prompting the user each time new tokens are requested.

### In-memory token caching

*In-memory token caching* is the default option provided by the Azure Identity library. This caching approach allows apps to store access tokens in memory. With in-memory token caching, the library first determines if a valid access token for the requested resource is already stored in memory. If a valid token is found, it's returned to the app without the need to make another request to Microsoft Entra ID. If a valid token isn't found, the library will automatically acquire a token by sending a request to Microsoft Entra ID.

The in-memory token cache provided by the Azure Identity library is thread-safe.

**Note:** When Azure Identity library credentials are used with Azure service libraries (for example, Azure Blob Storage), the in-memory token caching is active in the `HttpPipeline` layer as well. All `TokenCredential` implementations are supported there, including custom implementations external to the Azure Identity library.

#### Disable caching

As there are many levels of cache, it's not possible to disable in-memory caching. However, the in-memory cache may be cleared by creating a new credential instance. The exception is `ManagedIdentityCredential`, which uses a static instance of in-memory cache by default. This means that the cache can be reused by multiple instances of a credential within the same application instance.

## Persistent token caching

*Persistent disk token caching* is an opt-in feature in the Azure Identity library. The feature allows apps to cache access tokens in an encrypted, persistent storage mechanism. As indicated in the following table, the storage mechanism differs across operating systems.

| Operating system | Storage mechanism |
|------------------|-------------------|
| Linux            | Keyring           |
| macOS            | Keychain          |
| Windows          | DPAPI             |

With persistent disk token caching enabled, the library first determines if a valid access token for the requested resource is already stored in the persistent cache. If a valid token is found, it's returned to the app without the need to make another request to Microsoft Entra ID. Additionally, the tokens are preserved across app runs, which:

- Makes the app more resilient to failures.
- Ensures the app can continue to function during a Microsoft Entra ID outage or disruption.
- Avoids having to prompt users to authenticate each time the process is restarted.


>IMPORTANT! The token cache contains sensitive data and **MUST** be protected to prevent compromising accounts. All application decisions regarding the persistence of the token cache must consider that a breach of its content will fully compromise all the accounts it contains.

### Using the default token cache

The simplest way to persist the token data for a credential is to to use the default `TokenCachePersistenceOptions`.
This will persist and read token data from a shared persisted token cache protected to the current account.

```C# Snippet:Identity_TokenCache_PersistentDefault
var credential = new InteractiveBrowserCredential(
    new InteractiveBrowserCredentialOptions
    {
        TokenCachePersistenceOptions = new TokenCachePersistenceOptions()
    });
```

### Using a named token cache

Some applications may prefer to isolate the token cache they use rather than using the shared instance.
To accomplish this they can specify the `TokenCachePersistenceOptions` when creating the credential and provide a `Name` for the persisted cache instance.

```C# Snippet:Identity_TokenCache_PersistentNamed
var persistenceOptions = new TokenCachePersistenceOptions { Name = "my_application_name" };

var credential = new InteractiveBrowserCredential(
    new InteractiveBrowserCredentialOptions { TokenCachePersistenceOptions = persistenceOptions }
);
```

### Allowing unencrypted storage

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

### Silently authenticate a user with AuthenticationRecord and TokenCachePersistenceOptions

When authenticating a user via `InteractiveBrowserCredential`, or `DeviceCodeCredential`, an [AuthenticationRecord](https://learn.microsoft.com/dotnet/api/azure.identity.authenticationrecord?view=azure-dotnet) can be persisted as well. The authentication record is:

- Returned from the `Authenticate` API and contains data identifying an authenticated account.
- Needed to identify the appropriate entry in the persisted token cache to silently authenticate on subsequent executions.

There's no sensitive data in the `AuthenticationRecord`, so it can be persisted in a non-protected state.

Once an app has persisted an `AuthenticationRecord`, future authentications can be performed silently by setting `TokenCachePersistenceOptions` and `AuthenticationRecord` on the builder.

Here's an example of an app storing the `AuthenticationRecord` to the local file system after authenticating the user:

```C# Snippet:Identity_ClientSideUserAuthentication_Persist_TokenCache_AuthRecordPath
private const string AUTH_RECORD_PATH = "./tokencache.bin";
```

```C# Snippet:Identity_ClientSideUserAuthentication_Persist_AuthRecord
AuthenticationRecord authRecord = await credential.AuthenticateAsync();

using (var authRecordStream = new FileStream(AUTH_RECORD_PATH, FileMode.Create, FileAccess.Write))
{
    await authRecord.SerializeAsync(authRecordStream);
}
```

Now that the `AuthenticationRecord` is persisted, the app can silently authenticate the user:

```C# Snippet:Identity_ClientSideUserAuthentication_Persist_SilentAuth
AuthenticationRecord authRecord;

using (var authRecordStream = new FileStream(AUTH_RECORD_PATH, FileMode.Open, FileAccess.Read))
{
    authRecord = await AuthenticationRecord.DeserializeAsync(authRecordStream);
}

var credential = new InteractiveBrowserCredential(
    new InteractiveBrowserCredentialOptions
    {
        TokenCachePersistenceOptions = new TokenCachePersistenceOptions(),
        AuthenticationRecord = authRecord
    });
```

## Credentials supporting token caching

The following table indicates the state of in-memory and persistent caching in each credential type.

**Note:** In-memory caching is activated by default. Persistent token caching needs to be enabled as shown in the samples above.

| Credential                     | In-memory token caching                                                | Persistent disk token caching |
|--------------------------------|------------------------------------------------------------------------|-------------------------------|
| `AuthorizationCodeCredential`  | Supported                                                              | Supported                     |
| `AzureCliCredential`           | Not Supported                                                          | Not Supported                 |
| `AzureDeveloperCliCredential`  | Not Supported                                                          | Not Supported                 |
| `AzurePipelinesCredential`     | Supported                                                              | Supported                     |
| `AzurePowershellCredential`    | Not Supported                                                          | Not Supported                 |
| `ClientAssertionCredential`    | Supported                                                              | Supported                     |
| `ClientCertificateCredential`  | Supported                                                              | Supported                     |
| `ClientSecretCredential`       | Supported                                                              | Supported                     |
| `DefaultAzureCredential`       | Supported if the target credential in the credential chain supports it | Not Supported                 |
| `DeviceCodeCredential`         | Supported                                                              | Supported                     |
| `EnvironmentCredential`        | Supported                                                              | Supported                     |
| `InteractiveBrowserCredential` | Supported                                                              | Supported                     |
| `ManagedIdentityCredential`    | Supported                                                              | Not Supported                 |
| `OnBehalfOfCredential`         | Supported                                                              | Supported                     |
| `VisualStudioCredential`       | Supported                                                              | Not Supported                 |
| `WorkloadIdentityCredential`   | Supported                                                              | Supported                     |
