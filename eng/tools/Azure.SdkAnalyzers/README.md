# Azure SDK Analyzers

This project contains Roslyn analyzers for Azure SDK for .NET libraries.

## Analyzers

### AZC0012: Avoid single word type names

Single word type names are too generic and have a high chance of collision with BCL types or types from other libraries. This analyzer detects public types with single-word names and suggests more descriptive multi-word alternatives.

**Example:**
```csharp
// Bad - single word type name
public class Client { }

// Good - descriptive multi-word name
public class BlobClient { }
public class ServiceClient { }
```

## Building

To build the analyzer project:

```bash
cd eng/tools/Azure.SdkAnalyzers
dotnet build
```

## History

This analyzer was originally part of the [Azure SDK Tools](https://github.com/Azure/azure-sdk-tools/tree/main/src/dotnet/Azure.ClientSdk.Analyzers) repository and has been copied here to be included directly in the Azure SDK for .NET repository.
