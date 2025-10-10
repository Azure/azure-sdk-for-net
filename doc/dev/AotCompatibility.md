# AOT Compatibility in Azure SDK for .NET

The majority of .NET Azure SDK libraries are committed to being compatible with native AOT. This should be a top priority when working on a new or existing library. For more information about native AOT deployment, see [this article](https://learn.microsoft.com/dotnet/core/deploying/native-aot/).

This document outlines the AOT compatibility process and guidance for Azure SDK library authors specifically.

## Built-in checks

All libraries in the Azure SDK for .NET are **automatically opted in** to AOT compatibility by marking libraries as trimmable and running checks to ensure AOT unsafe code is not used. There are two checks to validate that libraries are compatible with AOT:

### 1. AOT Compatibility Analyzers

Libraries are automatically marked with `<IsAotCompatible>true</IsAotCompatible>` in their project files. This enables the [AOT compatibility analyzers](https://learn.microsoft.com/dotnet/core/deploying/native-aot/?tabs=windows%2Cnet8#aot-compatibility-analyzers) which help library authors identify AOT-unsafe code during development by flagging it with compiler warnings.

### 2. CI Pipeline Checks

AOT compatibility checks are also automatically enabled in CI pipelines. These checks follow the process outlined in ["Prepare .NET libraries for trimming"](https://learn.microsoft.com/dotnet/core/deploying/trimming/prepare-libraries-for-trimming#show-all-warnings-with-test-app) to collect warnings from both the library **and it's dependencies** for AOT-unsafe code which provides additional validation beyond the compile-time analyzers.

## Guidance for Library Authors

### Making Libraries AOT Compatible

Library authors should prioritize AOT compatibility by following the comprehensive guidance in ["Prepare .NET libraries for trimming"](https://learn.microsoft.com/dotnet/core/deploying/trimming/prepare-libraries-for-trimming). This article details strategies for making code AOT-safe.

**For Azure SDK libraries specifically, it is critical to always provide AOT-safe alternatives for any AOT-unsafe code paths.** This means ensuring that all library features can be used safely in an AOT context, not just marking incompatible code with attributes. The goal is to make the entire library's functionality available to customers deploying with native AOT.

**For serialization scenarios**, follow the guidance in [ModelReaderWriterContext documentation](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/System.ClientModel/src/docs/ModelReaderWriterContext.md) to provide safe serialization paths using source generation.

### Handling AOT-Unsafe Code

When encountering code paths that are truly AOT-unsafe, library authors must:

1. **Mark unsafe paths appropriately** using `RequiresUnreferencedCode`, `RequiresDynamicCode`, and similar attributes to clearly document the AOT-unsafe behavior
2. **Always provide AOT-safe alternatives** - This is critical for Azure SDK libraries. Every AOT-unsafe code path should have a corresponding safe alternative that customers can use in AOT scenarios

### Important: Avoid Warning Suppression

**Suppressing AOT compatibility warnings should be avoided in Azure SDK libraries.** Instead of suppressing warnings:

- **Refactor code** to be AOT-safe using source generation, pre-computed data, or other safe patterns
- **Provide alternative APIs** that offer the same functionality through AOT-safe means
- **Use proper attributes** like `RequiresUnreferencedCode` to document why specific code paths are unsafe and guide users to safe alternatives

If you feel a suppression is needed, there are almost always alternative ways to refactor the code so that the analyzer can recognize whether it's safe or not. Warning suppression is very rarely the right approach and should be avoided.

Warning suppression masks real compatibility issues and prevents customers from making informed decisions about AOT deployment.

### Opt-Out Process (Last Resort Only)

Libraries that cannot be made AOT compatible must opt out entirely by adding `<AotCompatOptOut>true</AotCompatOptOut>` to their `.csproj` files. This completely disables:
- The `IsAotCompatible` property and AOT analyzers
- CI pipeline AOT compatibility checks

**There is no halfway option** - libraries are either fully AOT compatible or must opt out completely. The expectation is that libraries work toward full AOT compatibility rather than maintaining a permanent opt-out status.

**Important**: This opt-out is strongly discouraged and should only be used as a temporary measure while working toward full AOT compatibility. All Azure SDK libraries should ultimately be AOT compatible for wider ecosystem compatibility and to support customers deploying with native AOT.

## Resolving Trimming Warnings

The following resources provide comprehensive guidance for resolving trimming warnings and making libraries AOT compatible:

- ["How to make libraries compatible with native AOT"](https://devblogs.microsoft.com/dotnet/creating-aot-compatible-libraries/) by Eric Erhardt
- ["Prepare .NET libraries for trimming"](https://learn.microsoft.com/dotnet/core/deploying/trimming/prepare-libraries-for-trimming)  
- ["Introduction to trim warnings"](https://learn.microsoft.com/dotnet/core/deploying/trimming/fixing-warnings)

### Source Generation for Serialization

For AOT-safe serialization/deserialization:
- [Introduction of C# source generation in .NET 6](https://devblogs.microsoft.com/dotnet/try-the-new-system-text-json-source-generator/)
- [How to use source generation](https://learn.microsoft.com/dotnet/standard/serialization/system-text-json/source-generation)
- [ModelReaderWriterContext documentation](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/System.ClientModel/src/docs/ModelReaderWriterContext.md)