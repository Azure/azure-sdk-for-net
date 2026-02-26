---
name: mgmt-type-rename
description: Rename generated types in Azure management-plane .NET SDKs by adding @@clientName decorators in TypeSpec client.tsp. Use when review comments ask to prefix, rename, or fix generic type names to avoid collisions.
---

# Skill: mgmt-type-rename

Rename generated C# types in Azure management-plane SDKs by updating TypeSpec `client.tsp` (and optionally `managedOps.tsp` or similar model files) in the spec repo, then regenerating the SDK.

## When Invoked

Trigger phrases: "rename types", "add prefix", "fix generic names", "type name collision", "needs RP prefix", "rename for review comments", "resolve naming comments".

## Overview

Management-plane SDK types are generated from TypeSpec definitions in `azure-rest-api-specs`. When generated C# type names are too generic (e.g., `ProvisioningState`, `ServiceInformation`), they can collide with types from other SDKs. The fix is to add `@@clientName` decorators in the spec's `client.tsp` to give them an RP-prefixed name for C#.

### Key Concepts

- **`@@clientName(TypeSpecName, "CSharpName", "csharp")`** — renames a TypeSpec model/union/enum to a different name in the generated C# SDK.
- **Named unions vs aliases** — `@@clientName` can only target named types (models, unions, enums, interfaces). If a type is defined as an `alias` (e.g., `alias foo = "A" | "B" | string;`), it must first be converted to a named `union` before `@@clientName` can be applied.
- **Swagger regeneration** — if you modify anything in the TypeSpec beyond `client.tsp` or `tspconfig.yaml` (e.g., converting an alias to a union in the model `.tsp` file), you must run `tsp compile .` to regenerate the swagger file, otherwise spec CI will fail.

## Workflow

### Step 1: Identify Types to Rename

Read PR review comments (or the API surface file `api/*.cs`) to identify which types need renaming. Common patterns:

| Generic Name | Prefixed Name |
|---|---|
| `ProvisioningState` | `<ServiceName>ProvisioningState` |
| `ServiceInformation` | `<ServiceName>ServiceInformation` |
| `DesiredConfiguration` | `<ServiceName>DesiredConfiguration` |

The prefix is typically the RP/service name (e.g., `ManagedOps`, `Compute`, `Network`).

### Step 2: Locate the Spec Files

1. Find `tsp-location.yaml` in the SDK package directory:
   ```
   sdk/<service>/Azure.ResourceManager.<Service>/tsp-location.yaml
   ```
2. This file contains:
   - `directory`: path to the TypeSpec spec (e.g., `specification/managedoperations/ManagedOps.Management`)
   - `commit`: the spec repo commit SHA
   - `repo`: the spec repo (e.g., `Azure/azure-rest-api-specs`)

3. Locate the corresponding spec files. The spec repo may be:
   - A local clone (typically at `../azure-rest-api-specs` relative to the SDK repo)
   - Or fetched from GitHub using the commit SHA

4. Key spec files:
   - `client.tsp` — where `@@clientName` decorators go
   - `main.tsp` / `<service>.tsp` — where models, unions, and aliases are defined

### Step 3: Apply Renames in the Spec Repo

#### For models, unions, and enums (named types)

Add `@@clientName` decorators to `client.tsp`:

```typespec
import "./main.tsp";
import "@azure-tools/typespec-client-generator-core";

using Azure.ClientGenerator.Core;
using Microsoft.<ServiceNamespace>;

@@clientName(ProvisioningState, "<ServiceName>ProvisioningState", "csharp");
@@clientName(ServiceInformation, "<ServiceName>ServiceInformation", "csharp");
```

Make sure to add `using Microsoft.<ServiceNamespace>;` if not already present, so that the type names resolve correctly.

#### For aliases (unnamed unions)

Aliases cannot be targeted by `@@clientName`. Convert them to named unions first:

**Before (alias — cannot rename):**
```typespec
#suppress "@azure-tools/typespec-azure-core/no-unnamed-union" "..."
alias enablementState =
  | "Enabled"
  | "Disabled"
  | string;
```

**After (named union — can rename):**
```typespec
@doc("The enablement state of a service.")
union EnablementState {
  string,

  @doc("Service is enabled.")
  Enabled: "Enabled",

  @doc("Service is disabled.")
  Disabled: "Disabled",
}
```

Then add `@@clientName` in `client.tsp`:
```typespec
@@clientName(EnablementState, "<ServiceName>EnablementStatus", "csharp");
```

**Important:** After converting aliases to unions, update all references in the model `.tsp` files from the old alias name to the new union name.

### Step 4: Regenerate Swagger (if model .tsp files changed)

If you modified any `.tsp` file other than `client.tsp` or `tspconfig.yaml`, you **must** regenerate the swagger:

```powershell
cd <spec-repo>/specification/<service>/<ServiceName>.Management
npx tsp compile .
```

This updates the swagger JSON file under `resource-manager/`. Commit the regenerated swagger along with your TypeSpec changes.

### Step 5: Commit and Push Spec Changes

Commit all spec changes (client.tsp, model .tsp, and regenerated swagger) and push to the spec PR branch.

### Step 6: Update SDK tsp-location.yaml

Update the `commit` field in `tsp-location.yaml` to point to the new spec commit SHA:

```yaml
directory: specification/<service>/<ServiceName>.Management
commit: <new-commit-sha>
repo: Azure/azure-rest-api-specs
```

### Step 7: Regenerate the SDK

```powershell
cd sdk/<service>/Azure.ResourceManager.<Service>/src
dotnet build /t:GenerateCode
```

### Step 8: Build and Export API

```powershell
# Build to verify compilation
cd sdk/<service>/Azure.ResourceManager.<Service>/src
dotnet build

# Export API listing
cd <repo-root>
pwsh eng/scripts/Export-API.ps1 <service-directory>
```

### Step 9: Verify the Renames

Check that the old type names are gone and new prefixed names exist:

```powershell
# Should find matches for new names
grep -c "<ServiceName>ProvisioningState" sdk/<service>/Azure.ResourceManager.<Service>/api/*.cs

# Should find NO matches for old names
grep -c "\bProvisioningState\b" sdk/<service>/Azure.ResourceManager.<Service>/api/*.cs
```

### Step 10: Commit, Push, and Resolve Comments

1. Commit and push the regenerated SDK to the SDK PR branch
2. Resolve the corresponding review comments on the SDK PR

## Checklist

- [ ] All generic type names have RP prefix in generated C# code
- [ ] `client.tsp` has `@@clientName` decorators for all renamed types
- [ ] Any aliases converted to named unions have all references updated
- [ ] Swagger regenerated if model `.tsp` files were modified (`tsp compile .`)
- [ ] SDK `tsp-location.yaml` commit SHA updated to spec commit
- [ ] SDK regenerated (`dotnet build /t:GenerateCode`)
- [ ] SDK builds with 0 errors
- [ ] API listing exported (`Export-API.ps1`)
- [ ] Changes pushed to both spec PR and SDK PR
- [ ] Review comments resolved

## Common Pitfalls

1. **Forgetting `using Microsoft.<Namespace>;`** in `client.tsp` — the type names won't resolve and `@@clientName` will silently fail.
2. **Not regenerating swagger** after modifying model `.tsp` files — spec CI will fail.
3. **Alias vs union confusion** — `@@clientName` only works on named types. Aliases must be converted to unions first.
4. **Stale commit SHA** — always update `tsp-location.yaml` to point to the pushed spec commit before regenerating.
