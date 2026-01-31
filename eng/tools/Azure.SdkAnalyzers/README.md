# Azure SDK Analyzers

Roslyn analyzers that enforce [Azure SDK Design Guidelines](https://azure.github.io/azure-sdk/dotnet_introduction.html) for .NET library authors.

This package is automatically included in all Azure SDK libraries in this repository to ensure consistent code quality and adherence to Azure SDK conventions.

## Implemented Rules

- [**AZC0012**](https://github.com/Azure/azure-sdk-for-net/blob/move-azure-analyzers/eng/tools/Azure.SdkAnalyzers/docs/list-of-diagnostics.md#azc0012): Avoid single word type names

## For Library Authors

These analyzers run automatically during build and will produce warnings when your code doesn't follow Azure SDK conventions. Review the [Azure SDK Design Guidelines](https://azure.github.io/azure-sdk/dotnet_introduction.html) for detailed guidance on all rules.

For detailed information about each diagnostic rule, see the [list of diagnostics](https://github.com/Azure/azure-sdk-for-net/blob/move-azure-analyzers/eng/tools/Azure.SdkAnalyzers/docs/list-of-diagnostics.md).
