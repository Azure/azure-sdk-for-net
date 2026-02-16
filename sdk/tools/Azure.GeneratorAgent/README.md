# Azure Generator Agent client library for .NET

A command-line tool for automating Azure SDK code generation workflows.

<!-- Test comment: Testing new CI separation - only .NET 10.0 should be tested -->

## Getting started

### Install the package

Install as a .NET global tool:

```bash
dotnet tool install --global Azure.GeneratorAgent
```

### Prerequisites

- [.NET 10.0](https://dotnet.microsoft.com/download/dotnet/10.0) or later
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

## Troubleshooting

### Common issues

- **Generation failures**: Check that all prerequisites are installed and the target directory has proper permissions
- **Authentication errors**: Ensure you're running within a properly configured Azure SDK repository
- **Missing dependencies**: Verify .NET 10.0 runtime is installed

## Contributing

This project welcomes contributions and suggestions. Most contributions require you to agree to a Contributor License Agreement (CLA) declaring that you have the right to, and actually do, grant us the rights to use your contribution.

## Next steps

- Explore the [Azure SDK for .NET repository](https://github.com/Azure/azure-sdk-for-net)
- Learn about [Azure SDK design guidelines](https://azure.github.io/azure-sdk/)
