# AOT Compatibility in Azure SDK for .NET

The majority of .NET Azure SDK libraries are committed to being compatible with native AOT. Being AOT compatible should be prioritized when working on a new or existing library. For more information about native AOT deployment, see [this article](https://learn.microsoft.com/dotnet/core/deploying/native-aot/).

This document outlines the AOT compatibility process and guidance for Azure SDK library authors specifically.

## Built-in checks

All libraries in the Azure SDK for .NET are **automatically opted in** to AOT compatibility by marking libraries as trimmable, turning on AOT analyzers, and running checks to ensure AOT unsafe code is not used. There are two checks to validate that libraries are compatible with AOT:

### 1. AOT Compatibility Analyzers

Libraries are automatically marked with `<IsAotCompatible>true</IsAotCompatible>` in their project files. This enables the [AOT compatibility analyzers](https://learn.microsoft.com/dotnet/core/deploying/native-aot/?tabs=windows%2Cnet8#aot-compatibility-analyzers) which help library authors identify AOT-unsafe code during development by flagging it with compiler warnings.

### 2. CI Pipeline Checks

AOT compatibility checks are also automatically enabled in CI pipelines. These checks follow the process outlined in ["Prepare .NET libraries for trimming"](https://learn.microsoft.com/dotnet/core/deploying/trimming/prepare-libraries-for-trimming#show-all-warnings-with-test-app) to collect warnings from both the library **and it's dependencies** for AOT-unsafe code which provides additional validation beyond the compile-time analyzers.

## Guidance for Library Authors

### Making Libraries AOT Compatible

Library authors should prioritize AOT compatibility by following the comprehensive guidance in ["Prepare .NET libraries for trimming"](https://learn.microsoft.com/dotnet/core/deploying/trimming/prepare-libraries-for-trimming). This article details strategies for making code AOT-safe.

**For Azure SDK libraries specifically, it is critical to always provide AOT-safe alternatives for any AOT-unsafe code paths.** This goes beyond just marking unsafe code. The goal is to make the entire library's functionality available to customers deploying with native AOT.

**For serialization scenarios**, follow the guidance in [ModelReaderWriterContext documentation](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/System.ClientModel/src/docs/ModelReaderWriterContext.md) to provide safe serialization paths using source generation.

### Handling AOT-Unsafe Code

When encountering code paths that are truly AOT-unsafe, library authors must:

1. **Mark unsafe paths appropriately** using `RequiresUnreferencedCode`, `RequiresDynamicCode`, and similar attributes to clearly document the AOT-unsafe behavior
2. **Always provide AOT-safe alternatives** - This is critical for Azure SDK libraries. Every AOT-unsafe code path should have a corresponding safe alternative that customers can use in AOT scenarios

### Important: Avoid Warning Suppression

Warning suppression masks real compatibility issues and prevents customers from making informed decisions about AOT deployment. It should be avoided in Azure SDK libraries. Instead of suppressing warnings:

- **Refactor code** to be AOT-safe using source generation, pre-computed data, or other safe patterns
- **Provide alternative APIs** that offer the same functionality through AOT-safe means
- **Use proper attributes** like `RequiresUnreferencedCode` to document why specific code paths are unsafe and guide users to safe alternatives

If you feel a suppression is needed, there are almost always alternative ways to refactor the code so that the trimmer can recognize whether it's safe or not, and it can then be annotated accordingly. Warning suppression is rarely the right approach.

### Opt-Out Process

For libraries that cannot be made AOT compatible, authors can opt out of AOT compatibility checks entirely by adding `<AotCompatOptOut>true</AotCompatOptOut>` to their `.csproj` files. Setting this will:
- Set `IsAotCompatible` to false and turns off AOT analyzers
- Disables CI pipeline AOT compatibility checks

Ideally, this opt-out should be used as a temporary measure while working towards full AOT compatibility.

## Resolving Trimming Warnings

The following resources provide comprehensive guidance for resolving trimming warnings and making libraries AOT compatible:

- ["How to make libraries compatible with native AOT"](https://devblogs.microsoft.com/dotnet/creating-aot-compatible-libraries/) by Eric Erhardt
- ["Prepare .NET libraries for trimming"](https://learn.microsoft.com/dotnet/core/deploying/trimming/prepare-libraries-for-trimming)  
- ["Introduction to trim warnings"](https://learn.microsoft.com/dotnet/core/deploying/trimming/fixing-warnings)
- If using ModelReaderWriter in System.ClientModel, see the [ModelReaderWriterContext documentation](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/System.ClientModel/src/docs/ModelReaderWriterContext.md)