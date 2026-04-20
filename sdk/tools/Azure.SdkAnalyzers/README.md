# Azure SDK Analyzers

Roslyn analyzers that enforce [Azure SDK Design Guidelines](https://azure.github.io/azure-sdk/dotnet_introduction.html) for .NET library authors.

This package is automatically included in all Azure SDK libraries in this repository to ensure consistent code quality and adherence to Azure SDK conventions.

## Getting started

### Install the package

Install the `Azure.SdkAnalyzers` NuGet package via the .NET CLI:

```dotnetcli
dotnet add package Azure.SdkAnalyzers
```

Or via the NuGet Package Manager:

```powershell
Install-Package Azure.SdkAnalyzers
```

### Prerequisites

- .NET SDK 6.0 or later
- A project that targets any of the supported Azure SDK target frameworks

### Authenticate the client

This package contains build-time analyzers only. No authentication is required.

## Key concepts

`Azure.SdkAnalyzers` provides Roslyn (compile-time) analyzers and code fixers that enforce patterns required by the [Azure SDK Design Guidelines for .NET](https://azure.github.io/azure-sdk/dotnet_introduction.html). Diagnostics fire as warnings during `dotnet build` and are visible in the IDE editor.

For the full list of rules, see [docs/list-of-diagnostics.md](docs/list-of-diagnostics.md).

## Implemented Rules

| Rule | Description | Fix |
|------|-------------|-----|
| **AZC0012** | Avoid single word type names | — |
| **AZC0020** | Propagate CancellationToken to RequestContext | — |
| **AZC0101** | Do not use `ConfigureAwait(true)` | ✅ |

## Examples

### AZC0101 — ConfigureAwait(false)

The analyzer flags any `await` that passes `true` to `ConfigureAwait`:

```csharp
// ❌ AZC0101 warning — ConfigureAwait(true) is almost always wrong in library code
await task.ConfigureAwait(true);

// ✅ Correct — use false to avoid capturing the caller's SynchronizationContext
await task.ConfigureAwait(false);
```

A lightbulb code fix **"Use ConfigureAwait(false)"** is available in Visual Studio and VS Code to perform the replacement automatically.

### AZC0012 — Avoid single-word type names

```csharp
// ❌ AZC0012 warning
public class Manager { }

// ✅ Use a descriptive multi-word name
public class TableManager { }
```

### AZC0020 — Propagate CancellationToken to RequestContext

```csharp
// ❌ AZC0020 warning — token is dropped
await client.UpdateAsync(content, new RequestContext());

// ✅ Propagate the token
await client.UpdateAsync(content, new RequestContext { CancellationToken = cancellationToken });
```

## Troubleshooting

### Suppressing a diagnostic

Most rules can be suppressed with the standard `#pragma warning disable` / `#pragma warning restore` syntax or via a `[SuppressMessage]` attribute:

```csharp
#pragma warning disable AZC0012 // Justified: intentionally generic name used here
public class Format { }
#pragma warning restore AZC0012
```

> **Note:** AZC0101 is a **Warning** and can be suppressed. In the rare case where `ConfigureAwait(true)` is intentional, prefer omitting the `ConfigureAwait` call entirely.

### Build output shows no diagnostics

Ensure the package is referenced in your `.csproj` and that the project targets a framework compatible with Roslyn analyzers (net6.0 or later is recommended).

## Next steps

- Review the [Azure SDK Design Guidelines for .NET](https://azure.github.io/azure-sdk/dotnet_introduction.html)
- See [docs/list-of-diagnostics.md](docs/list-of-diagnostics.md) for detailed per-rule documentation
- Browse [AZC0101.md](docs/AZC0101.md) for detailed information on the ConfigureAwait rule

## Contributing

See [CONTRIBUTING.md](https://github.com/Azure/azure-sdk-for-net/blob/main/CONTRIBUTING.md) for contribution guidelines.
