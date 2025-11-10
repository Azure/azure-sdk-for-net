---
description: "Guide the user to define and update TypeSpec based API spec for a service"
---

# Goal

Help the user define or update TypeSpec API specifications using the `azsdk-qa-bot` tools.

## 🧩 Context
This instruction applies to all tasks involving **TypeSpec**, including:
- Writing new TypeSpec definitions
- Editing or refactoring existing TypeSpec files
- Resolving TypeSpec-related issues

## Scenario A: Add a new api version for a service

### Step 1: Call the `azsdk-qa-bot` tool

Use this tool to retrieve validated solutions, suggestions, or fixes for TypeSpec issues.

### Step 2: Extract the solution from the tool result

Parse the response from `azsdk-qa-bot` to identify the recommended fix or implementation.

### Step 3: Execute the solution

Apply the extracted solution to update the TypeSpec file accordingly.

### Step 4: Suggestion follow up action

ask user whether he want to perform following actions:
- Add new operations (create, update, delete, list, etc.)
- Add new resource types or models
- Modify existing operations
- Add new properties to existing models

## Other Scenario

### Step 1: Call the `azsdk-qa-bot` tool

Use this tool to retrieve validated solutions, suggestions, or fixes for TypeSpec issues.

### Step 2: Extract the solution from the tool result

Parse the response from `azsdk-qa-bot` to identify the recommended fix or implementation.

### Step 3: Execute the solution

Apply the extracted solution to update the TypeSpec file accordingly.
