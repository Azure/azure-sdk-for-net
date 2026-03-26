---
description: "Guide the user to generate and build SDKs locally for a TypeSpec based API spec"
---

# Goal

Help the user generate and build SDKs locally from TypeSpec API specifications using the `azure-sdk-mcp` tools.
High level steps involved:
1. Generate SDK locally
2. Build / Compile SDK locally
3. Commit generated changes checkpoint
4. Run package checks
5. Run package tests
6. Update change log, metadata and version
7. Commit final changes checkpoint

---

## Generate SDK Locally

### Step 1: Outline workflow

**Goal**: Ensure the user understands the overall SDK generation and build process before starting.  
**Actions**:

- **MUST** present the high-level steps involved in generating and building SDK locally:
  1. Select target language
  2. Verify SDK repository
  3. Validate repository path
  4. Identify path to configuration file
  5. Verify setup for the selected language
  6. Generate SDK using `azsdk_package_generate_code` MCP tool
  7. Identify SDK project path
  8. Build/Compile SDK using `azsdk_package_build_code` MCP tool
  9. Commit generated changes checkpoint
  10. Run package checks
  11. Run package tests
  12. Update change log, metadata and version
  13. Commit final changes checkpoint

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
    - `/home/usr/azure-rest-api-specs/specification/contosowidgetmanager/Contoso.Management/tspconfig.yaml`
    - `https://github.com/Azure/azure-rest-api-specs/blob/4af373fc5826cf5a2365a20dde01c4b2efde48f0/specification/contosowidgetmanager/Contoso.Management/tspconfig.yaml`

- **Scenario B: Working in one of the official Azure SDK language repositories**  
  (i.e., originally cloned from `azure-sdk-for-net`, `azure-sdk-for-java`, `azure-sdk-for-js`, `azure-sdk-for-python`, `azure-sdk-for-go`)
  - Identify the path to `tsp-location.yaml`.
  - The local folder name can be arbitrary; MCP tool will validate the remote origin URL.
  - Example path:
    `/home/usr/azure-sdk-for-net/sdk/contoso/Azure.ResourceManager.Contoso/tsp-location.yaml`

---

### Step 6: Verify setup for selected language
**Actions**:
- Run `azsdk_verify_setup` MCP tool to ensure the local environment is correctly configured for the selected SDK language.

---

### Step 7: Generate SDK

**Actions**:
- Run `azsdk_package_generate_code` MCP tool to generate the SDK locally.

---

##  Build / Compile SDK Locally

### Step 1: Identify SDK project path

**Goal**: Locate the generated SDK project directory for building/compiling.
**Actions**:

- Find the project directory inside the selected Azure SDK language repository.
- Typical structure:  
  `sdk/{service-name}/{package-name}/`
- Example:  
  `/path/to/azure-sdk-for-net/contoso/Azure.ResourceManager.Contoso/`

---

### Step 2: Build/Compile the SDK

**Actions**:

- Run `azsdk_package_build_code` MCP tool to compile the SDK in the identified project directory.

---

### Step 3: Stage checkpoint — Commit generated changes

**Goal**: Prompt the user to commit the changes produced by the generation and build steps before proceeding to validation and testing.  
**Actions**:

- **MUST** inform the user that SDK generation and build have completed successfully.
- **MUST** prompt the user to decide if they want to commit the changes now. Do NOT skip this prompt.
- If the user chooses to commit:
  - Check if the user is on the `main` branch. If so, prompt: *"You are currently on the main branch. Please create a new branch using `git checkout -b <branch-name>` before proceeding."* Suggest a reasonable default branch name based on the generation context (e.g., `sdk/<service-name>/<package-name>`) and provide the exact `git checkout -b <branch-name>` command for the user to run. Allow the user to provide a preferred branch name instead. Wait for user confirmation before continuing.
  - Run `git add <modified-files>` to stage the changed files.
  - Prompt the user for a commit message.
  - Run `git commit -m "<user-provided-message>"`.
- If the user chooses to skip, acknowledge and proceed to the next step.

---

### Step 4: Run package validation

**Actions**:

- Run `azsdk_package_run_check` MCP tool to validate the generated SDK package in the identified project directory.

---

### Step 5: Run package tests

**Actions**:

- Run `azsdk_package_run_tests` MCP tool to run tests on the generated SDK package in the identified project directory.

---

### Step 6: Update change log, metadata and version

**Actions**:

- Run `azsdk_package_update_changelog_content` MCP tool to update change log in the identified project directory.
- Run `azsdk_package_update_metadata` MCP tool to update metadata in the identified project directory.
- Run `azsdk_package_update_version` MCP tool to update version in the identified project directory.

---

### Step 7: Stage checkpoint — Commit final changes

**Goal**: Prompt the user to commit the final set of changes after all updates are complete.  
**Actions**:

- **MUST** inform the user that changelog, metadata, and version updates are complete.
- **MUST** prompt the user to decide if they want to commit the changes now. Do NOT skip this prompt.
- If the user chooses to commit:
  - Check if the user is on the `main` branch. If so, prompt: *"You are currently on the main branch. Please create a new branch using `git checkout -b <branch-name>` before proceeding."* Suggest a reasonable default branch name based on the generation context (e.g., `sdk/<service-name>/<package-name>`) and provide the exact `git checkout -b <branch-name>` command for the user to run. Allow the user to provide a preferred branch name instead. Wait for user confirmation before continuing.
  - Run `git add <modified-files>` to stage the changed files.
  - Prompt the user for a commit message.
  - Run `git commit -m "<user-provided-message>"`.
- If the user chooses to skip, acknowledge and proceed.