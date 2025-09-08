---
description: "Guide the user to generate and build SDKs locally for TypeSpec changes"
---

# Goal
Help the user generate and build SDKs locally from TypeSpec API specifications using the `azure-sdk-mcp` tools.  

---

## Part A: Generate SDK Locally

### Step 1: Outline workflow
**Goal**: Ensure the user understands the overall SDK generation and build process before starting.  
**Actions**:
  - Present the high-level steps involved in generating and building SDK locally:
    1. Select target language
    2. Verify SDK repository
    3. Validate repository path
    4. Identify path to configuration file
    5. Generate SDK using `azure-sdk-mcp`
    6. Identify SDK project path
    7. Build/Compile SDK using `azure-sdk-mcp`
  - Ask the user to confirm readiness to proceed.

---

### Step 2: Select language
**Goal**: Confirm the target language for SDK generation.  
**Actions**:
  - Prompt user to choose one of the supported languages:
      - .NET
      - Java
      - JavaScript
      - Python
      - Go
  - Validate input against the allowed list.

---

### Step 3: Verify SDK repository
**Goal**: Ensure the correct Azure SDK language repository is available locally.
**Actions**:
  - Prompt user to provide the path to their **locally cloned repository** for the selected language.
  - Note: The **local folder name can be arbitrary**, but the repository must have originated from one of the official Azure SDK repositories:
      - `azure-sdk-for-net` (.NET)
      - `azure-sdk-for-java` (Java)
      - `azure-sdk-for-js` (JavaScript)
      - `azure-sdk-for-python` (Python)
      - `azure-sdk-for-go` (Go)
  - If the repository is not cloned → instruct user to clone the appropriate remote repository from GitHub.
  - MCP tool will automatically validate the remote origin and repository structure.

---

### Step 4: Validate repository path
**Actions**:
  - Check if the provided repository path exists and matches the selected SDK language repository.
  - If invalid → prompt user to re-enter a valid path.

---

### Step 5: Identify path to configuration file
**Goal**: Determine the correct path to the TypeSpec configuration file based on the working context.  
**Actions**:
  - **Scenario A: Working in a repository cloned from `azure-rest-api-specs`**
    - Identify the path to `tspconfig.yaml` (local path or HTTPS URL).
    - The local folder name can be arbitrary; the MCP tool will validate that the remote origin URL points to the official `azure-rest-api-specs` repository.
    - Example paths (pointing directly to tspconfig.yaml):
      - `/home/usr/azure-rest-api-specs/specification/azurefleet/AzureFleet.Management/tspconfig.yaml`
      - `https://github.com/Azure/azure-rest-api-specs/blob/cf275faeaa164687fe51176bf09a80692a841d38/specification/azurefleet/resource-manager/Microsoft.AzureFleet/AzureFleet/tspconfig.yaml`

  - **Scenario B: Working in one of the official Azure SDK language repositories**  
    (i.e., originally cloned from `azure-sdk-for-net`, `azure-sdk-for-java`, `azure-sdk-for-js`, `azure-sdk-for-python`, `azure-sdk-for-go`)
    - Identify the path to `tsp-location.yaml`.
    - The local folder name can be arbitrary; MCP tool will validate the remote origin URL.
    - Example path:
      `/home/usr/azure-sdk-for-java/sdk/computefleet/azure-resourcemanager-computefleet/tsp-location.yaml`

---

### Step 6: Generate SDK
**Actions**:
  - Use the tools provided by the `azure-sdk-mcp` server to generate the SDK locally.

---

## Part B: Build / Compile SDK Locally

### Step 1: Identify SDK project path
**Goal**: Locate the generated SDK project directory for building/compiling.
**Actions**:
  - Find the project directory inside the selected Azure SDK language repository.
  - Typical structure:  
    `sdk/{service-name}/{package-name}/`
  - Example:  
    `/path/to/azure-sdk-for-java/sdk/computefleet/azure-resourcemanager-computefleet/`

---

### Step 2: Build/Compile the SDK
**Actions**:
  - Use the tools provided by the `azure-sdk-mcp` server to compile the SDK in the identified project directory.
