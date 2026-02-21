# Contributing to @azure-typespec/http-client-csharp

Welcome! This guide will help you set up your development environment and contribute to the Azure TypeSpec HTTP Client C# package.

## Table of Contents

- [Prerequisites](#prerequisites)
- [Getting Started](#getting-started)
- [Development Workflow](#development-workflow)
- [Testing](#testing)
- [Code Generation](#code-generation)
- [Creating Pull Requests](#creating-pull-requests)
- [Getting Help](#getting-help)
- [Code of Conduct](#code-of-conduct)

## Prerequisites

Before you begin, ensure you have the following installed:

- [Node.js](https://nodejs.org/) (version 20 or higher)
- [.NET 9.0 SDK](https://dotnet.microsoft.com/download/dotnet/9.0) (required - see global.json for exact version)
- [npm](https://docs.npmjs.com/downloading-and-installing-node-js-and-npm)
- [Git](https://git-scm.com/)
- [PowerShell](https://docs.microsoft.com/powershell/scripting/install/installing-powershell) (version 7.0 or higher, for advanced testing and code generation scenarios)
- [Long Path Support](https://learn.microsoft.com/en-us/windows/win32/fileio/maximum-file-path-limitation?tabs=powershell#registry-setting-to-enable-long-paths) (Windows only required to avoid path length limitations during development)

## Getting Started

### 1. Clone the Repository

```bash
git clone https://github.com/Azure/azure-sdk-for-net.git
cd azure-sdk-for-net/eng/packages/http-client-csharp
```

### 2. Install Dependencies

From the repository root:

```bash
npm ci
```

### 3. Build the C# Package

```bash
npm run build
```

This command runs:

- `npm run build:emitter` - Builds the TypeScript emitter
- `npm run build:generator` - Builds the .NET generator

### 4. Verify Installation

After building, you can verify everything is working correctly by running:

```bash
npm run test
```

## Development Workflow

### Package Structure

The C# HTTP client package consists of two main components:

- **Emitter** (`/emitter`): TypeScript code that processes TypeSpec definitions and produces input for the generator
- **Generator** (`/generator`): .NET code that generates C# client libraries from the emitter output

### Making Changes

1. **Create a fork** of the repository and clone it:

   ```bash
   git clone https://github.com/YOUR_USERNAME/azure-sdk-for-net.git
   cd azure-sdk-for-net
   git checkout -b feature/your-feature-name
   ```

2. **Make your changes** to the codebase

3. **Build your changes**:

   ```bash
   # Build emitter only
   npm run build:emitter
   
   # Build generator only
   npm run build:generator
   
   # Build everything
   npm run build
   ```

4. **Test your changes**:

   ```bash
   # Test emitter only
   npm run test:emitter
   
   # Test generator only
   npm run test:generator
   
   # Test everything
   npm run test
   ```

### Code Style and Linting

- **Format code**: `npm run prettier:fix`
- **Run linting**: `npm run lint`
- **Fix lint issues**: `npm run lint:fix`

## Testing

### Unit Tests

The package includes both TypeScript (emitter) and C# (generator) tests:

```bash
# Run all tests
npm run test

# Run emitter tests only (TypeScript/Vitest)
npm run test:emitter

# Run generator tests only (.NET)
npm run test:generator
```

> **Note**: Some tests may require a full workspace build to resolve all dependencies before running successfully.

### Integration Testing with Spector

The package uses the Spector test framework for end-to-end testing of generated code:

```bash
# Run Spector tests (requires PowerShell)
./eng/scripts/Test-Spector.ps1

# Run Spector tests with filter (filters by directory path)
./eng/scripts/Test-Spector.ps1 "http/type/array"

# Get Spector test coverage (outputs to ./generator/artifacts/coverage, not checked in)
./eng/scripts/Get-Spector-Coverage.ps1
```

### Test Project Generation

Generate test projects to validate the emitter and generator:

```bash
# Generate all test projects (requires PowerShell)
./eng/scripts/Generate.ps1

# Generate specific test project
./eng/scripts/Generate.ps1 -filter "project-name"

# Generate with stubbed mode disabled
./eng/scripts/Generate.ps1 -Stubbed $false
```

## Code Generation

### Regenerating Test Projects

To regenerate test projects after making changes:

**Generate projects**:

```bash
./eng/scripts/Generate.ps1
```

### Regenerating Azure Libraries

To regenerate Azure libraries using your local changes, run:

```bash
./eng/scripts/RegenPreview.ps1
```

This will regenerate all the Azure libraries and allow you to view any potential diffs your changes may cause. For more information on the script's usage, see [RegenPreview](./eng/scripts/docs/RegenPreview.md).

## Creating Pull Requests

### 1. Prepare Your PR

Before creating a pull request:

- [ ] Ensure all tests pass: `npm run test`
- [ ] Ensure code is properly formatted: `npm run prettier:fix`
- [ ] Ensure code is properly linted: `npm run lint:fix`
- [ ] Generate and test projects: `./eng/scripts/Generate.ps1` (if applicable)
- [ ] Update documentation if needed

### 2. Create the PR

1. Push your branch to your fork or the main repository
2. Create a pull request to the [Azure/azure-sdk-for-net](https://github.com/Azure/azure-sdk-for-net) repository
3. Provide a clear description of your changes
4. Link any related issues

## Getting Help

- **Issues**: Report bugs or request features in the [Azure SDK for .NET repository issues](https://github.com/Azure/azure-sdk-for-net/issues)
- **Documentation**: Check the [TypeSpec documentation](https://typespec.io/) for more information
- **C# Customization**: See the [Customization Guide](https://github.com/microsoft/typespec/blob/main/packages/http-client-csharp/.tspd/docs/customization.md)

## Code of Conduct

This project follows the [Microsoft Open Source Code of Conduct](https://opensource.microsoft.com/codeofconduct/). Please be respectful and inclusive in all interactions.

Thank you for contributing! 🎉
