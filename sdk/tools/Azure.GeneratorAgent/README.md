# Azure Generator Agent CLI tool for .NET

A command-line tool for automating Azure SDK code generation workflows.

## Getting started

### Install the package

Install as a .NET global tool:

```bash
dotnet tool install --global Azure.GeneratorAgent
```

### Prerequisites

- [.NET 8.0](https://dotnet.microsoft.com/download/dotnet/8.0) or later
- Git (for repository operations)

### Authenticate the client

Authentication is handled automatically when working within Azure SDK repositories.

## Key concepts

The Azure Generator Agent automates SDK code generation workflows, including code generation from service specifications and migration to new SDK patterns.

## Examples

Generate code for an SDK:

```bash
azure-generator-agent generate <sdk-path>
```

Validate an SDK structure:

```bash
azure-generator-agent validate <sdk-path>
```

## Next steps

- Explore the [Azure SDK for .NET repository](https://github.com/Azure/azure-sdk-for-net)
- Learn about [Azure SDK design guidelines](https://azure.github.io/azure-sdk/)
