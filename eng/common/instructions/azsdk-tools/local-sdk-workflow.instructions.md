Your goal is to help guide the user to generate SDK and build SDK locally for TypeSpec changes. This is currently supported for five languages: .NET, Java, JavaScript, Python, and Go.

## Steps to generate SDK locally from a TypeSpec API specification
### Step 1: Tell user the steps to generate SDK locally
- Identify the language for SDK generation
- Validate the corresponding Azure SDK language repository is present in local environment. The supported repositories are:
    - azure-sdk-for-net
    - azure-sdk-for-java
    - azure-sdk-for-js
    - azure-sdk-for-python
    - azure-sdk-for-go
- Specify the path to the cloned Azure SDK language repository
- Specify the path to the 'tspconfig.yaml' file or the path to 'tsp-location.yaml' file.
- Use tools provided by 'azure-sdk-mcp' MCP server to generate SDK locally

### Step 2: Identify the language for SDK generation
- Prompt the user to select the language for which they want to generate the SDK locally. Supported languages are:
    - .NET
    - Java
    - JavaScript
    - Python
    - Go

### Step 3: Check for existing Azure SDK language repository
- Prompt the user to provide the path to their cloned Azure SDK language repository.
- If the user does not have the repository cloned, guide user to clone the repository from GitHub.

### Step 4: Validate repository path
- Check if the provided repository path is valid. If not, prompt the user to provide a valid path for the repository's location.

### Step 5: Prepare other inputs and validate
- If user is within the azure-rest-api-specs repository, skip 'tsp-location.yaml' input and use the path to 'tspconfig.yaml' file.
- If user is within the Azure SDK language repository, skip 'tspconfig.yaml' input and use the path to 'tsp-location.yaml' file.
- The path to 'tspconfig.yaml' can be a local path or a HTTPS URL.

### Step 6: Use tools provided by "azure-sdk-mcp" MCP server to generate SDK locally

## Steps to build/compile SDK locally
- Identify the SDK project path to build
- Use tools provided by "azure-sdk-mcp" MCP server to compile the SDK
