# Root Cause Analysis: Disconnect Method Not Generated on UserSessionResource

## Summary

The `Disconnect` and `SendMessage` methods are generated as extension methods on
`MockableDesktopVirtualizationResourceGroupResource` instead of as instance methods
on `UserSessionResource`. This is caused by a **custom override of `ArmResourceActionSync`
in the service TypeSpec** that hardcodes the `@armResourceAction` decorator argument to the
base `Azure.ResourceManager.Foundations.Resource` type instead of using the template's
`Resource` type parameter.

## Root Cause

### The Bug: `CustomOperations.tsp` line 104

The service spec defines a local override of `ArmResourceActionSync` in:

```
specification/desktopvirtualization/resource-manager/
  Microsoft.DesktopVirtualization/DesktopVirtualization/CustomOperations.tsp
```

The critical line is **line 104**:

```typespec
@armResourceAction(Azure.ResourceManager.Foundations.Resource)   // ← BUG: hardcoded base type
op ArmResourceActionSync<
  Resource extends Azure.ResourceManager.Foundations.Resource,
  ...
```

Compare with the standard ARM library definition (`@azure-tools/typespec-azure-resource-manager/lib/operations.tsp`):

```typespec
@armResourceAction(Resource)   // ← CORRECT: uses the template parameter
op ArmResourceActionSync<
  Resource extends Foundations.SimpleResource,
  ...
```

The standard ARM library passes the `Resource` **template parameter** to `@armResourceAction`,
so when instantiated as `ArmResourceActionSync<UserSession, ...>`, the decorator receives
`UserSession` as its argument.

The custom override passes the **hardcoded base type** `Azure.ResourceManager.Foundations.Resource`,
so regardless of what concrete resource type is passed to the template, the decorator always
receives the base `Resource` type.

### Why CustomOperations.tsp Affects UserSession.tsp

Both files declare `namespace Microsoft.DesktopVirtualization` and have
`using Azure.ResourceManager`. When `CustomOperations.tsp` defines a local
`op ArmResourceActionSync<...>` inside that namespace, it creates
`Microsoft.DesktopVirtualization.ArmResourceActionSync`, which **shadows**
the ARM library's `Azure.ResourceManager.ArmResourceActionSync`.

TypeSpec's name resolution checks the **current namespace first** before looking at
`using` imports. So when `UserSession.tsp` line 112 writes:

```typespec
disconnect is ArmResourceActionSync<UserSession, void, ...>;
```

…the unqualified `ArmResourceActionSync` resolves to the local override (with the
hardcoded base `Resource` decorator argument), not the ARM library version.

Compare with line 78 of the same file:

```typespec
listByHostPool is Azure.ResourceManager.ArmResourceActionSync<...>;
```

This uses the fully-qualified name, so it bypasses the shadow and uses the correct
ARM library template where `@armResourceAction(Resource)` references the template parameter.

### How This Causes the Bug

The emitter's resource detection logic (`resource-detection.ts`) uses `parseResourceOperation()`
to determine which ARM resource each operation belongs to. For action operations, it reads
the `@armResourceAction` decorator's first argument to get the resource model:

```typescript
case armResourceActionName:
  return {
    kind: ResourceOperationKind.Action,
    modelId: getResourceModelId(sdkContext, decorator),  // reads decorator arg[0]
    ...
  };
```

With the custom override, `getResourceModelId()` returns
`"Azure.ResourceManager.CommonTypes.Resource"` instead of
`"Microsoft.DesktopVirtualization.UserSession"`.

Since `"Azure.ResourceManager.CommonTypes.Resource"` is **not** in the set of known
service resource models, the operation falls through to the non-resource methods bucket
(line 299–306 of `resource-detection.ts`), and is placed on
`MockableDesktopVirtualizationResourceGroupResource` as an extension method rather than
on `UserSessionResource`.

### Why the Test Project Works

The test project (`Mgmt-TypeSpec/UserSession.tsp`) does **not** have a custom
`ArmResourceActionSync` override. It uses the standard ARM library template directly:

```typespec
disconnect is ArmResourceActionSync<UserSession, void, { @statusCode _: 200; }>;
```

This resolves through the standard ARM library where `@armResourceAction(Resource)` correctly
receives `UserSession`, so the emitter properly associates the `disconnect` operation with
the `UserSession` resource.

## Affected Operations

All operations in the service spec that use the **unqualified** `ArmResourceActionSync`
(resolving to the local override) are affected:

| Operation | Resource | File |
|-----------|----------|------|
| `UserSessions.disconnect` | UserSession | UserSession.tsp:112 |
| `UserSessions.sendMessage` | UserSession | UserSession.tsp:124 |
| `SessionHosts.retryProvisioning` | SessionHost | SessionHost.tsp:117 |
| `SessionHosts.listSingleSessionHostRegistrationTokens` | SessionHost | SessionHost.tsp:125 |
| `HostPools.listRegistrationTokens` | HostPool | HostPool.tsp:235 |
| `HostPools.retrieveRegistrationToken` | HostPool | HostPool.tsp:244 |
| `AppAttachPackageInfo.import` | HostPool | HostPool.tsp:39 |
| `MSIXImages.expand` | HostPool | HostPool.tsp:61 |
| `InitiateSessionHostUpdate.post` | SessionHostManagement | SessionHostManagement.tsp:40 |

Operations using the **fully qualified** `Azure.ResourceManager.ArmResourceActionSync` are
**not affected** because they bypass the custom override and use the correct ARM library
template. These include `listByHostPool`, `listByWorkspace`, and similar operations.

## Fix Options

### Option A: Fix the spec (in the spec repo)

Change line 104 of `CustomOperations.tsp` from:

```typespec
@armResourceAction(Azure.ResourceManager.Foundations.Resource)
```

to:

```typespec
@armResourceAction(Resource)
```

This makes the custom template behave identically to the standard ARM library template with
respect to resource model resolution.

### Option B: Remove the custom override entirely

If the custom `ArmResourceActionSync` template is no longer needed (i.e., the upstream ARM
library template now provides the same signature), delete the custom template from
`CustomOperations.tsp` and ensure all operations use
`Azure.ResourceManager.ArmResourceActionSync` (fully qualified) or that the `using`
statement imports the standard one.

### Option C: Make the emitter more resilient

Enhance the emitter's `parseResourceOperation()` to fall back to the operation's URL path
to determine the resource type when the decorator argument resolves to the base `Resource`
type. This would be a defense-in-depth measure but does not fix the underlying spec issue.

## Verification

After applying the fix, regenerate the SDK and verify:

1. `UserSessionResource.cs` contains `Disconnect()` and `DisconnectAsync()` methods
2. `UserSessionResource.cs` contains `SendMessage()` and `SendMessageAsync()` methods
3. `SessionHostResource.cs` contains `RetryProvisioning()` methods
4. These methods are **not** present on `MockableDesktopVirtualizationResourceGroupResource`
5. The `armProviderSchema` decorator in `tspCodeModel.json` shows these methods inside
   the respective resource's `methods` array (not in `nonResourceMethods`)
