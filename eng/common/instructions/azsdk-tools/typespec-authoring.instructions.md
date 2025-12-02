---
description: "Guide the user to define and update TypeSpec based API spec for an azure service"
---

# Goal

Help the user define or update TypeSpec API specifications using the `azure-sdk-mcp` tools.

## 🧩 Context
This instruction applies to all tasks involving **TypeSpec**, including:
- Writing new TypeSpec definitions: service, api version, resource, models, operations
- Editing or refactoring existing TypeSpec files, editing api version, service, resource, models, or operations
- versioning evolution: 
    Making a preview api stable, 
    Replacing a preview API with a new preview API
    Replacing a preview API with a stable API
    Replacing a preview API with a stable API and a new preview API
    Adding a preview API
    Adding a stable API version
    and so on

- Resolving TypeSpec-related issues

## ⚙️ Workflow Guidance

When encountering a TypeSpec-related task, follow this process:

### Step 1: Collect Required Information

Collect required information for the TypeSpec-related task. If the task does not need the extra information, skip this step.

And this step just collecting information, NO code change action taken.

Following tasks need collect required information:

**Task 1: add a new api version**
Prompt user to answer following question one by one:
- prompt user to provide the api version name
- prompt user to idenfity if it is a stable version or preview version.
- verify if the api version name match the azure version rule: preview version suffix '-preview'. If not, prompt user to suggest an api version name
- identify current api versions which are stable version, which are preview version ( the version with suffix '-preview', For preview versions, the format should be YYYY-MM-DD-preview; For stable versions, the format should be YYYY-MM-DD (e.g., 2025-12-01))
- **when add a new preview api version**, and the current latest api version is preview version, prompt user to ask if it want to replace the previous preview api version or add a new preview api version
- **when add a new stable api version**, and the current latest api version is preview version, first identify which typespec items are added in this preview version, then prompt user to choose which items are GAed or all items are GAed

### Step 2: Call the `azure-sdk-mcp/azsdk_typespec_authoring` tool

Use this tool to retrieve validated solutions, suggestions, or fixes for TypeSpec issues. Combine the user’s question with all provided information collected in step 1 to construct a comprehensive query. Ensure the query is precise.

### Step 3: Extract the solution from the tool result

Parse the response from `azure-sdk-mcp/azsdk_typespec_authoring` to identify the recommended fix or implementation solution.
show the solution flow, list all the steps to execute.

### Step 4: Execute the solution

Apply the extracted solution from step 3 to update the TypeSpec file accordingly.


### Step 5: Summary the solution

Summary the solution taken, and display the reference doc url from the response from `azure-sdk-mcp/azsdk_typespec_authoring` tool

**When the task is to add a new api version, add following extra step:**

### Step 6: Suggestion follow up action

ask user whether he want to perform following actions:
- Add new operations (create, update, delete, list, etc.)
- Add new resource types or models
- Modify existing operations
- Add new properties to existing models

