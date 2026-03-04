---
name: mgmt-review-comment-resolution
description: Resolve review comments on Azure management-plane .NET SDK PRs. Handles renaming types/properties, changing property types, and other API surface adjustments by updating TypeSpec client.tsp and regenerating.
---

# Skill: mgmt-review-comment-resolution

Resolve review comments on Azure management-plane SDK PRs by making changes in the TypeSpec spec repo (`client.tsp`) and regenerating the SDK.

## When Invoked

Trigger phrases: "resolve review comments", "fix review comments", "resolve PR comments", "rename types", "fix naming", "resolve naming comments", "fix API surface".

## Overview

Management-plane SDK code is generated from TypeSpec definitions in `azure-rest-api-specs`. Review comments on SDK PRs often request changes to the generated API surface — renaming types, renaming properties, or changing property types to be more user-friendly. These changes are made in the spec repo's `client.tsp` using TypeSpec decorators (primarily `@@clientName`), then the SDK is regenerated.

### Key Concepts

- **`@@clientName(TypeSpecName, "CSharpName", "csharp")`** — renames a TypeSpec model/union/enum/property to a different name in the generated C# SDK. This is the primary tool for resolving naming comments.
- **`@@clientName` only works on named types** — models, unions, enums, and interfaces. If a type is defined as an `alias`, `@@clientName` cannot target it. See "Handling Unsupported Cases" below.
- **Only `client.tsp` may be changed** — do not modify any other `.tsp` files or config files. If resolving a comment would require changes to other files, skip that change and inform the user with the reason after processing all other comments. Since only `client.tsp` is modified, swagger regeneration is never needed.

## Types of Review Comments

### 1. Type Names Too Generic

Review comments may flag type names that are too generic and could collide with types from other SDKs or lack sufficient context.

**Goal:** Make the name more descriptive by adding context — this could be the RP name, the resource name, or other domain-specific context. The right prefix depends on what makes the name unambiguous and meaningful.

**Examples:**
| Original | Renamed | Context Added |
|---|---|---|
| `ProvisioningState` | `ManagedOpsProvisioningState` | RP name |
| `ServiceInformation` | `ManagedOpsServiceInformation` | RP name |
| `EncryptionProperties` | `VaultEncryptionProperties` | Resource name |
| `ConnectionState` | `PrivateEndpointConnectionState` | Feature name |

**How to decide the prefix:** Read the review comment carefully — it may suggest a specific prefix. If not, choose the most natural context that makes the name unambiguous within the SDK's namespace. When uncertain, **ask the user** what prefix or name they prefer.

### 2. Property Renames

Properties can also be renamed using `@@clientName` on the model's property:

```typespec
@@clientName(MyModel.oldPropertyName, "NewPropertyName", "csharp");
```

### 3. Property Type Changes

Some review comments ask for property types to be changed (e.g., `string` → `ResourceIdentifier`, `string` → `TimeSpan`). Use the `@@alternateType` decorator in `client.tsp` to change the generated C# type:

```typespec
@@alternateType(MyModel.myProperty, armResourceIdentifier, "csharp");
@@alternateType(MyModel.durationProperty, duration, "csharp");
```

This changes the property's type in the generated C# SDK without modifying other `.tsp` files. If `@@alternateType` cannot handle the requested type change, skip the change and inform the user with the reason after processing all other comments.

## Workflow

### Step 1: Read and Understand Review Comments

Fetch the PR's review comments using GitHub MCP tools. For each unresolved comment:
1. Identify what change is requested (rename type, rename property, change type, etc.)
2. Find the corresponding TypeSpec type/property in the spec
3. Determine the appropriate new name or change

If a comment is ambiguous about what the new name should be, **ask the user** before proceeding.

### Step 2: Locate the Spec Files

1. Find `tsp-location.yaml` in the SDK package directory:
   ```
   sdk/<service>/Azure.ResourceManager.<Service>/tsp-location.yaml
   ```
2. This file contains:
   - `directory`: path to the TypeSpec spec (e.g., `specification/managedoperations/ManagedOps.Management`)
   - `commit`: the spec repo commit SHA
   - `repo`: the spec repo (e.g., `Azure/azure-rest-api-specs`)

3. Key spec files:
   - `client.tsp` — where `@@clientName` and `@@alternateType` decorators go (this is the only `.tsp` file you should modify)
   - Other `.tsp` files — read-only reference for understanding models, unions, and aliases

### Step 3: Apply Changes in the Spec Repo

Locate the spec repo. It may be:
- A local clone (typically at `../azure-rest-api-specs` relative to the SDK repo)
- If not available locally, clone it or ask the user for the path

If there is an existing spec PR branch, check it out. If there is no spec PR or branch yet, create a new branch from the commit referenced in `tsp-location.yaml`.

Add `@@clientName` decorators to `client.tsp`. Read the existing `client.tsp` to find the correct `using` statement for the service namespace (e.g., `using Microsoft.ManagedOps;`, `using Azure.ResourceManager.Compute;`, etc.), then add decorators targeting the types to rename:

```typespec
@@clientName(GenericTypeName, "MoreDescriptiveTypeName", "csharp");
@@clientName(MyModel.genericProperty, "moreDescriptiveProperty", "csharp");
```

Make sure the `using` statement for the service namespace is present so that type names resolve correctly. Check the `namespace` declaration in `main.tsp` or other `.tsp` files to find the correct namespace.

### Step 4: Commit and Push Spec Changes

Commit `client.tsp` changes and push to the spec PR branch.

### Step 5: Update SDK tsp-location.yaml

Update the `commit` field in `tsp-location.yaml` to point to the new spec commit SHA:

```yaml
directory: specification/<service>/<ServiceName>.Management
commit: <new-commit-sha>
repo: Azure/azure-rest-api-specs
```

### Step 6: Regenerate the SDK

```powershell
cd sdk/<service>/Azure.ResourceManager.<Service>/src
dotnet build /t:GenerateCode
```

### Step 7: Build and Verify

```powershell
# Build the library and tests (mgmt libraries always have a solution file)
cd sdk/<service>/Azure.ResourceManager.<Service>
dotnet build

# Export API listing
cd <repo-root>
pwsh eng/scripts/Export-API.ps1 <service-directory>
```

If tests fail to build due to old type/property names, update the test files to use the new names.

### Step 8: Verify the Changes

Check the API surface file (`api/*.cs`) to confirm the review comments have been addressed — old names are gone and new names are present.

### Step 9: Commit, Push, and Resolve Comments

1. Commit and push the regenerated SDK to the SDK PR branch
2. Resolve the corresponding review comments on the SDK PR using GitHub GraphQL API

## Handling Unsupported Cases

Some changes cannot be done purely through `@@clientName` or `@@alternateType` in `client.tsp`. When you encounter any of the following, **skip the change** and continue processing other comments. After all processable changes are done, inform the user about the skipped changes with the reason, and let them choose how to proceed:

- **Aliases** — `@@clientName` cannot target TypeSpec aliases (e.g., `alias foo = "A" | "B" | string;`). Explain to the user that the alias needs to be converted to a named type (e.g., `union`) in the spec `.tsp` file first.
- **Changes requiring other file modifications** — any change that cannot be expressed via `client.tsp` decorators alone (e.g., structural changes, flattening/unflattening models, adding/removing properties, or changing inheritance). Only `client.tsp` may be modified.
- **Ambiguous naming** — if a review comment says "rename this" but doesn't specify the new name, ask the user what name they prefer.

## Common Pitfalls

1. **Missing `using` statement** in `client.tsp` — the type names won't resolve and `@@clientName` will silently fail. Check the `namespace` declaration in the spec's `.tsp` files to find the correct namespace.
2. **Modifying files other than `client.tsp`** — only `client.tsp` should be modified in the spec repo. If other file changes are needed, skip and inform the user.
3. **Stale commit SHA** — always update `tsp-location.yaml` to point to the pushed spec commit before regenerating.
4. **Test files** — after renaming types, test and sample files may still reference old names and need manual updates.
5. **Not building tests** — always build the solution (which includes tests), not just the library, to catch stale references.
