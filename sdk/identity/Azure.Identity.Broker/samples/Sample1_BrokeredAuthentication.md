# Brokered authentication

This sample demonstrates how to use the `Azure.Identity.Broker` library to authenticate with `InteractiveBrowserCredential` using the system authentication broker (WAM on Windows, Microsoft broker on macOS and Linux).

## Authenticate with the system authentication broker

The `InteractiveBrowserCredentialBrokerOptions` class is used to configure an `InteractiveBrowserCredential` to authenticate through the system authentication broker. The constructor requires a parent window handle (HWND) so the broker UI can be docked to the application window.

```C#
using System;
using System.Runtime.InteropServices;
using Azure.Identity;
using Azure.Identity.Broker;
using Azure.Security.KeyVault.Secrets;

// On Windows, obtain the parent window handle. On other platforms, IntPtr.Zero is typically used.
IntPtr parentWindowHandle = GetParentWindowHandle();

var credential = new InteractiveBrowserCredential(
    new InteractiveBrowserCredentialBrokerOptions(parentWindowHandle));

var client = new SecretClient(new Uri("https://myvault.vault.azure.net/"), credential);

KeyVaultSecret secret = client.GetSecret("secret1");
```

## Silently authenticate with the default broker account

Set `UseDefaultBrokerAccount` to `true` to authenticate with the currently signed-in operating system account without prompting the user:

```C#
using System;
using Azure.Identity;
using Azure.Identity.Broker;
using Azure.Security.KeyVault.Secrets;

IntPtr parentWindowHandle = GetParentWindowHandle();

var credential = new InteractiveBrowserCredential(
    new InteractiveBrowserCredentialBrokerOptions(parentWindowHandle)
    {
        UseDefaultBrokerAccount = true
    });

var client = new SecretClient(new Uri("https://myvault.vault.azure.net/"), credential);
```

## Enable MSA passthrough

For first-party applications that need to list personal Microsoft accounts (MSA), enable legacy MSA passthrough:

```C#
using System;
using Azure.Identity;
using Azure.Identity.Broker;
using Azure.Security.KeyVault.Secrets;

IntPtr parentWindowHandle = GetParentWindowHandle();

var credential = new InteractiveBrowserCredential(
    new InteractiveBrowserCredentialBrokerOptions(parentWindowHandle)
    {
        IsLegacyMsaPassthroughEnabled = true
    });

var client = new SecretClient(new Uri("https://myvault.vault.azure.net/"), credential);
```
