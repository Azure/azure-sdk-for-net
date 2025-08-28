Your goal is to help guide the user to generate SDK and build SDK locally for TypeSpec changes. This is currently supported for five languages: .NET, Java, JavaScript(TypeScript), Python, and Go.

## Steps to generate SDK locally from TypeSpec
### Step 1: Tell user the steps to generate SDK locally
- specify the language for SDK generation
- have the corresponding azure-sdk-for-{language} repository cloned locally
- specify the path to the cloned azure-sdk-for-{language} repository
- specify the path to the 'tspconfig.yaml' file or the path to 'tsp-location.yaml' file.
- use tools provided by 'azure-sdk-mcp' MCP server to generate SDK locally

### Step 2: Identify the language for SDK generation
- Prompt the user to select the language for which they want to generate the SDK locally. Supported languages are:
    - .NET
    - Java
    - JavaScript (TypeScript)
    - Python
    - Go

### Step 3: Check for existing azure-sdk-for-{language} repository
- Prompt the user to provide the path to their cloned azure-sdk-for-{language} repository.
- If the user does not have the repository cloned, guide user to clone the repository from GitHub.

### Step 4: Validate repository path
- Check if the provided path is valid. If not, prompt the user to provide a valid path.

### Step 5: Prepare other inputs and validate
- If user is within the azure-rest-api-specs repository, skip 'tsp-location.yaml' input and use the path to 'tspconfig.yaml' file.
- If user is within the azure-sdk-for-{language} repository, skip 'tspconfig.yaml' input and use the path to 'tsp-location.yaml' file.
- The path to 'tspconfig.yaml' can be a local path or a HTTPS URL.
- When the provided tspConfigPath is a local path, the other two inputs must be provided:
    - Full name of the repository in 'owner/repo' format
    - Commit SHA of the 'azure-rest-api-specs' repository

### Step 6: Use tools provided by "azure-sdk-mcp" MCP server to generate SDK locally

## Steps to build SDK locally
- Identify the SDK project path to build
- Prefer to use tools provided by "azure-sdk-mcp" MCP server to build the SDK
