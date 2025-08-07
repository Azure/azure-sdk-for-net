# Client side user authentication

Client side applications often need to authenticate users to interact with resources in Azure. Some examples of this might be a command line tool which fetches secrets a user has access to from a key vault to setup a local test environment, or a GUI based application which allows a user to browse storage blobs they have access to. This sample demonstrates authenticating users with the `Azure.Identity` library.

## Interactive user authentication

Most often authenticating users requires some user interaction. Properly handling this user interaction for OAuth2 authorization code or device code authentication can be challenging. To simplify this for client side applications the `Azure.Identity` library provides the `InteractiveBrowserCredential` and the `DeviceCodeCredential`. These credentials are designed to handle the user interactions needed to authenticate via these two client side authentication flows, so the application developer can simply create the credential and authenticate clients with it.

## Authenticating users with the InteractiveBrowserCredential

For clients which have a default browser available, the `InteractiveBrowserCredential` provides the most simple user authentication experience. In the sample below an application authenticates a `SecretClient` using the `InteractiveBrowserCredential`.

```C# Snippet:Identity_ClientSideUserAuthentication_SimpleInteractiveBrowser
var client = new SecretClient(
    new Uri("https://myvault.vault.azure.net/"),
    new InteractiveBrowserCredential()
);
```

As code uses the `SecretClient` in the above sample, the `InteractiveBrowserCredential` will automatically authenticate the user by launching the default system browser prompting the user to login. In this case the user interaction happens on demand as is necessary to authenticate calls from the client.

## Authenticating users with the DeviceCodeCredential

For terminal clients without an available web browser, or clients with limited UI capabilities the `DeviceCodeCredential` provides the ability to authenticate any client using a device code. The next sample shows authenticating a `BlobClient` using the `DeviceCodeCredential`.

```C# Snippet:Identity_ClientSideUserAuthentication_SimpleDeviceCode
var credential = new DeviceCodeCredential();

var client = new BlobClient(
    new Uri("https://myaccount.blob.core.windows.net/mycontainer/myblob"),
    credential
);
```

Similarly to the `InteractiveBrowserCredential` the `DeviceCodeCredential` will also initiate the user interaction automatically as needed. To instantiate the `DeviceCodeCredential` the application must provide a callback which is called to display the device code along with details on how to authenticate to the user. In the above sample a lambda is provided which prints the full device code message to the console.

## Controlling user interaction

In many cases applications require tight control over user interaction. In these applications automatically blocking on required user interaction is often undesired or impractical. For this reason, credentials in the `Azure.Identity` library which interact with the user offer mechanisms to fully control user interaction.

```C# Snippet:Identity_ClientSideUserAuthentication_DisableAutomaticAuthentication
var credential = new InteractiveBrowserCredential(
    new InteractiveBrowserCredentialOptions { DisableAutomaticAuthentication = true });

await credential.AuthenticateAsync();

var client = new SecretClient(new Uri("https://myvault.vault.azure.net/"), credential);
```

In this sample the application is again using the `InteractiveBrowserCredential` to authenticate a `SecretClient`, but with two major differences from our first example. First, in this example the application is explicitly forcing any user interaction to happen before the credential is given to the client by calling `AuthenticateAsync`.

The second difference is here the application is preventing the credential from automatically initiating user interaction. Even though the application authenticates the user before the credential is used, further interaction might still be needed, for instance in the case that the user's refresh token expires, or a specific method require additional consent or authentication.

By setting the option `DisableAutomaticAuthentication` to `true` the credential will fail to automatically authenticate calls where user interaction is necessary. Instead, the credential will throw an `AuthenticationRequiredException`. The following example demonstrates an application handling such an exception to prompt the user to authenticate only after some application logic has completed.

```C# Snippet:Identity_ClientSideUserAuthentication_DisableAutomaticAuthentication_ExHandling
try
{
    client.GetSecret("secret");
}
catch (AuthenticationRequiredException e)
{
    await EnsureAnimationCompleteAsync();

    await credential.AuthenticateAsync(e.TokenRequestContext);

    client.GetSecret("secret");
}
```

## Persisting user authentication data

Quite often applications desire the ability to be run multiple times without having to re-authenticate the user on each execution.
This requires that data from credentials be persisted outside of the application memory so that it can authenticate silently on subsequent executions.
Applications can persist this data using `TokenPersistenceOptions` when constructing the credential, and persisting the `AuthenticationRecord` returned from `Authenticate`.

### Persisting the token cache

The credential handles persisting all the data needed to silently authenticate one or many accounts.
It manages sensitive data such as refresh tokens and access tokens which must be protected to prevent compromising the accounts related to them.
By default, the `Azure.Identity` library will protect and cache sensitive token data using available platform data protection.

To configure a credential, such as the `InteractiveBrowserCredential`, to persist token data, simply set the `TokenCachePersistenceOptions` option.

```C# Snippet:Identity_ClientSideUserAuthentication_Persist_TokenCache
var credential = new InteractiveBrowserCredential(
    new InteractiveBrowserCredentialOptions { TokenCachePersistenceOptions = new TokenCachePersistenceOptions() });
```

### Persisting the AuthenticationRecord

The `AuthenticationRecord` which is returned from the `Authenticate` and `AuthenticateAsync`, contains data identifying an authenticated account.
It is needed to identify the appropriate entry in the persisted token cache to silently authenticate on subsequent executions.
There is no sensitive data in the `AuthenticationRecord` so it can be persisted in a non-protected state.

Here is an example of an application storing the `AuthenticationRecord` to the local file system after authenticating the user.

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

### Silent authentication with AuthenticationRecord and TokenCachePersistenceOptions

Once an application has configured a credential to persist token data and an `AuthenticationRecord`, it is possible to silently authenticate.
This example demonstrates an application setting the `TokenCachePersistenceOptions` and retrieving an `AuthenticationRecord` from the local file system to create an `InteractiveBrowserCredential` capable of silent authentication.

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

The credential created in this example will silently authenticate given that a valid token for corresponding to the `AuthenticationRecord` still exists in the persisted token data.
There are some cases where interaction will still be required such as on token expiry, or when additional authentication is required for a particular resource.
