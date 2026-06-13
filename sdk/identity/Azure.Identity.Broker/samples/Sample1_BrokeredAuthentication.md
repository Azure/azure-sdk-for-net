# Brokered authentication

This sample demonstrates how to use the `Azure.Identity.Broker` library to authenticate with `InteractiveBrowserCredential` using the system authentication broker (WAM on Windows, Microsoft broker on macOS and Linux).

## Obtaining a parent window handle

The `InteractiveBrowserCredentialBrokerOptions` constructor requires a parent window handle so the broker dialog can be docked to the application window. How you obtain this handle depends on your platform and application framework:

| Platform / Framework | Window handle |
|---|---|
| **Win32 / Console** | `[DllImport("user32.dll")] static extern IntPtr GetForegroundWindow();` |
| **WPF** | `new System.Windows.Interop.WindowInteropHelper(this).Handle` |
| **WinForms** | `this.Handle` |
| **macOS / Linux** | `IntPtr.Zero` |

The samples below use `RuntimeInformation.IsOSPlatform` to select the correct handle at runtime so they compile and run on every platform.

## Authenticate with the system authentication broker

The `InteractiveBrowserCredentialBrokerOptions` class is used to configure an `InteractiveBrowserCredential` to authenticate through the system authentication broker.

```C#
using System;
using System.Runtime.InteropServices;
using Azure.Identity;
using Azure.Identity.Broker;
using Azure.Security.KeyVault.Secrets;

IntPtr parentWindowHandle = RuntimeInformation.IsOSPlatform(OSPlatform.Windows)
    ? GetForegroundWindow()
    : IntPtr.Zero;

var credential = new InteractiveBrowserCredential(
    new InteractiveBrowserCredentialBrokerOptions(parentWindowHandle));

var client = new SecretClient(new Uri("https://myvault.vault.azure.net/"), credential);

KeyVaultSecret secret = client.GetSecret("secret1");

[DllImport("user32.dll")]
static extern IntPtr GetForegroundWindow();
```

## Silently authenticate with the default broker account

Set `UseDefaultBrokerAccount` to `true` to authenticate with the currently signed-in operating system account without prompting the user:

```C#
using System;
using System.Runtime.InteropServices;
using Azure.Identity;
using Azure.Identity.Broker;
using Azure.Security.KeyVault.Secrets;

IntPtr parentWindowHandle = RuntimeInformation.IsOSPlatform(OSPlatform.Windows)
    ? GetForegroundWindow()
    : IntPtr.Zero;

var credential = new InteractiveBrowserCredential(
    new InteractiveBrowserCredentialBrokerOptions(parentWindowHandle)
    {
        UseDefaultBrokerAccount = true
    });

var client = new SecretClient(new Uri("https://myvault.vault.azure.net/"), credential);

[DllImport("user32.dll")]
static extern IntPtr GetForegroundWindow();
```

## Enable MSA passthrough

For first-party applications that need to list personal Microsoft accounts (MSA), enable legacy MSA passthrough:

```C#
using System;
using System.Runtime.InteropServices;
using Azure.Identity;
using Azure.Identity.Broker;
using Azure.Security.KeyVault.Secrets;

IntPtr parentWindowHandle = RuntimeInformation.IsOSPlatform(OSPlatform.Windows)
    ? GetForegroundWindow()
    : IntPtr.Zero;

var credential = new InteractiveBrowserCredential(
    new InteractiveBrowserCredentialBrokerOptions(parentWindowHandle)
    {
        IsLegacyMsaPassthroughEnabled = true
    });

var client = new SecretClient(new Uri("https://myvault.vault.azure.net/"), credential);

[DllImport("user32.dll")]
static extern IntPtr GetForegroundWindow();
```
