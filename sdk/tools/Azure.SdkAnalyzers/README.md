# Azure SDK Analyzers

Roslyn analyzers that enforce [Azure SDK Design Guidelines](https://azure.github.io/azure-sdk/dotnet_introduction.html) for .NET library authors.

This package is automatically included in all Azure SDK libraries in this repository to ensure consistent code quality and adherence to Azure SDK conventions.

## Key concepts

`Azure.SdkAnalyzers` provides Roslyn (compile-time) analyzers and code fixers that enforce patterns required by the [Azure SDK Design Guidelines for .NET](https://azure.github.io/azure-sdk/dotnet_introduction.html). Diagnostics fire as warnings during `dotnet build` and are visible in the IDE editor.

## Implemented Rules

| Rule | Description | Fix |
|------|-------------|-----|
| **AZC0012** | Avoid single word type names | — |
| **AZC0020** | Propagate CancellationToken to RequestContext | — |
| **AZC0101** | Do not use `ConfigureAwait(true)` | ✅ |

## For Library Authors

These analyzers run automatically during build and will produce warnings when your code doesn't follow Azure SDK conventions. Review the [Azure SDK Design Guidelines](https://azure.github.io/azure-sdk/dotnet_introduction.html) for detailed guidance on all rules.

For detailed information about each diagnostic rule, see the [list of diagnostics](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/tools/Azure.SdkAnalyzers/docs/list-of-diagnostics.md).

## Troubleshooting

### Suppressing a diagnostic

Most rules can be suppressed with the standard `#pragma warning disable` / `#pragma warning restore` syntax or via a `[SuppressMessage]` attribute:

```csharp
#pragma warning disable AZC0012 // Justified: intentionally generic name used here
public class Format { }
#pragma warning restore AZC0012
```

