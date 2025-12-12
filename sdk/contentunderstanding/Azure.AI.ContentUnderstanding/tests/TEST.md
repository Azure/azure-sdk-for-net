# Running Tests

This guide explains how to set up and run tests for the Azure AI Content Understanding SDK for .NET.

> **Note:** These tests are primarily intended for SDK contributors and maintainers. If you're an SDK user looking to learn how to use the SDK, please refer to the [samples directory][samples-directory] instead, which contains working examples and documentation for common scenarios.

## Prerequisites

- [.NET SDK](https://dotnet.microsoft.com/download) (version 8.0 or higher)
- An Azure subscription with a [Microsoft Foundry resource](https://learn.microsoft.com/azure/ai-services/content-understanding/)
- Required model deployments in Microsoft Foundry (see [Model Deployment Configuration](#model-deployment-configuration))

## Environment Setup

Tests require environment variables to be set before running. The environment variable names align with the [Python SDK](https://github.com/Azure/azure-sdk-for-python/tree/main/sdk/contentunderstanding/azure-ai-content-understanding) for consistency.

### Required Environment Variables

| Variable Name | Description | Example |
|--------------|-------------|---------|
| `AZURE_CONTENT_UNDERSTANDING_ENDPOINT` | The endpoint URL of your Microsoft Foundry resource | `https://your-resource.services.ai.azure.com/` |
| `AZURE_CONTENT_UNDERSTANDING_KEY` | API key for authentication (optional - uses DefaultAzureCredential if not set) | `your-api-key-here` |

### Optional Environment Variables

| Variable Name | Description | Used By |
|--------------|-------------|---------|
| `GPT_4_1_DEPLOYMENT` | gpt-4.1 model deployment name | Prebuilt analyzers (invoice, receipt, etc.) |
| `GPT_4_1_MINI_DEPLOYMENT` | gpt-4.1-mini model deployment name | Prebuilt analyzers (documentSearch, audioSearch, videoSearch) |
| `TEXT_EMBEDDING_3_LARGE_DEPLOYMENT` | Text-embedding-3-large model deployment name | Prebuilt analyzers |
| `AZURE_CONTENT_UNDERSTANDING_SOURCE_RESOURCE_ID` | Source resource ID for cross-resource copying | Copy analyzer tests |
| `AZURE_CONTENT_UNDERSTANDING_SOURCE_REGION` | Source region for cross-resource copying | Copy analyzer tests |
| `AZURE_CONTENT_UNDERSTANDING_TARGET_ENDPOINT` | Target endpoint for cross-resource copying | Copy analyzer tests |
| `AZURE_CONTENT_UNDERSTANDING_TARGET_RESOURCE_ID` | Target resource ID for cross-resource copying | Copy analyzer tests |
| `AZURE_CONTENT_UNDERSTANDING_TARGET_REGION` | Target region for cross-resource copying | Copy analyzer tests |
| `AZURE_CONTENT_UNDERSTANDING_TARGET_KEY` | Target API key for cross-resource copying | Copy analyzer tests |

### Setting Environment Variables

You can set environment variables using any of the following methods:

#### Option 1: Using .env File (Recommended)

1. Copy `env.sample` to `.env` in the tests directory:
   ```bash
   cd sdk/contentunderstanding/Azure.AI.ContentUnderstanding/tests
   cp env.sample .env
   ```
2. Edit `.env` and fill in your actual values:

```bash
AZURE_CONTENT_UNDERSTANDING_ENDPOINT=https://your-resource.services.ai.azure.com/
AZURE_CONTENT_UNDERSTANDING_KEY=your-api-key-here
GPT_4_1_DEPLOYMENT=your-gpt-4.1-deployment
GPT_4_1_MINI_DEPLOYMENT=your-gpt-4.1-mini-deployment
TEXT_EMBEDDING_3_LARGE_DEPLOYMENT=your-text-embedding-3-large-deployment
```

3. Source the file before running tests (from the tests directory):

```bash
# Using set -a to auto-export variables (recommended)
set -a
source .env
set +a
```

**Note:** The `set -a` command automatically exports all variables, which is required for `dotnet test` to access them. Simply using `source .env` without `set -a` will set variables in the current shell but won't export them to child processes.

**Note:** Make sure `.env` is in your `.gitignore` to avoid committing secrets.

#### Option 2: Using setup script (Windows)

For Windows users, use the provided setup script:

1. Copy `env.sample` to `.env` (from the tests directory):
   ```cmd
   cd sdk\contentunderstanding\Azure.AI.ContentUnderstanding\tests
   copy env.sample .env
   ```
2. Edit `.env` and fill in your actual values
3. Run the setup script:
   ```cmd
   setup_test_env.cmd
   ```

This script will load environment variables from `.env` into your current command prompt session.

## Model Deployment Configuration

Before running tests that use prebuilt analyzers or custom analyzers, you must deploy the required models in Microsoft Foundry:

- **For `prebuilt-documentSearch`, `prebuilt-audioSearch`, `prebuilt-videoSearch`**: Deploy `gpt-4.1-mini` and `text-embedding-3-large`
- **For `prebuilt-invoice`, `prebuilt-receipt`, and others**: Deploy `gpt-4.1` and `text-embedding-3-large`
- **For custom analyzers**: Deploy the models required by your custom analyzer (typically `gpt-4.1` or `gpt-4.1-mini` and `text-embedding-3-large`)

Set the deployment names in your environment variables (see [Optional Environment Variables](#optional-environment-variables) above).

For more information on deploying models, see [Create model deployments in Microsoft Foundry portal](https://learn.microsoft.com/azure/ai-studio/how-to/deploy-models-openai).

## Running Tests

### Test Modes

The Azure SDK test framework supports different test modes:

- **Live Mode**: Runs tests against real Azure services (makes actual API calls). This is the default mode.
- **Record Mode**: Records HTTP interactions for later playback (creates test recordings).
- **Playback Mode**: Plays back recorded interactions (no real API calls, fastest). Requires existing test recordings.

### Setting Test Mode

Set the `AZURE_TEST_MODE` environment variable:

```bash
# Live mode (default - makes real API calls)
export AZURE_TEST_MODE=Live

# Record mode (creates recordings for later playback)
export AZURE_TEST_MODE=Record

# Playback mode (uses existing recordings, no API calls)
export AZURE_TEST_MODE=Playback
```

**Note:** Most users will run tests in Live mode. Record mode is used to create test recordings, and Playback mode is primarily used in CI/CD pipelines where recordings are already available.

### Running All Tests

```bash
cd sdk/contentunderstanding/Azure.AI.ContentUnderstanding
dotnet test
```

### Running Specific Tests

```bash
# Run a specific test by name
dotnet test --filter "FullyQualifiedName~AnalyzeBinaryAsync"

# Run all tests in a specific class
dotnet test --filter "FullyQualifiedName~ContentUnderstandingClientTest"

# Run all sample tests
dotnet test --filter "FullyQualifiedName~ContentUnderstandingSamples"
```

### Show console output

Use the console logger with higher verbosity to print `Console.WriteLine` output while tests run:

```bash
dotnet test --logger "console;verbosity=detailed"
```

You can combine this with filters, for example:

```bash
dotnet test --filter "FullyQualifiedName~Sample02_AnalyzeUrlAsync" --logger "console;verbosity=detailed"
```

### Running Tests in a Specific Framework

```bash
# Run tests for .NET 8.0
dotnet test -f net8.0

# Run tests for .NET 9.0
dotnet test -f net9.0
```

## Test Recordings

Test recordings are stored in `tests/SessionRecords/` and allow tests to run in Playback mode without making real API calls. This is primarily used in CI/CD pipelines where recordings are already committed to the repository.

**For most users:** Run tests in Playback mode (no real calls, fastest) using the committed recordings. Use Live mode only when adding new scenarios or updating recordings (SDK contributors).

**For CI/CD:** Tests run in Playback mode using pre-recorded interactions, avoiding the need for live Azure resources during automated testing.

## Troubleshooting

### Authentication Errors

If you see authentication errors:

1. **Using API Key**: Ensure `AZURE_CONTENT_UNDERSTANDING_KEY` is set correctly
2. **Using DefaultAzureCredential**: Ensure you're authenticated. Most users authenticate using:
   - **Azure CLI**: Run `az login` before running tests
   - **Azure Developer CLI**: Run `azd auth login` before running tests

   Other authentication methods (Azure PowerShell, Visual Studio, environment variables) are also supported but less commonly used.

### Missing Model Deployments

If tests fail with model deployment errors:

1. Ensure required models are deployed in Microsoft Foundry
2. Set the deployment name environment variables (e.g., `GPT_4_1_DEPLOYMENT`)
3. Verify deployment names match what you configured in Microsoft Foundry

## Additional Resources

- [Azure SDK Test Framework Documentation](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core.TestFramework/README.md)
- [Content Understanding Service Documentation](https://learn.microsoft.com/azure/ai-services/content-understanding/)

[samples-directory]: https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/contentunderstanding/Azure.AI.ContentUnderstanding/samples
