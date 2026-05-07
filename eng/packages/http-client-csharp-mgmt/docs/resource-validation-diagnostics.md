# Resource Validation Diagnostics

## Overview

After the `resolveArmResources` step, the management-plane emitter runs a set of validation checks on the resolved resources. These checks catch misconfigured resource definitions early and emit error-level diagnostics. This document explains each diagnostic code and how to resolve it.

## Diagnostic Codes

### `invalid-resource-read-response`

**Severity:** Error

**Description:** A read (GET) operation for a resource returns a model type that does not match the resource's own model type.

**Cause:** The TypeSpec definition has a GET operation whose response type is different from the resource model. This usually happens when the operation is incorrectly associated with a resource, or when a custom GET operation returns a different model.

**How to fix:**

1. Ensure the GET operation for the resource returns the resource's own model type. For example:

   ```typespec
   @armResourceRead(MyResource)
   op get(...ResourceInstanceParameters<MyResource>): ArmResponse<MyResource> | ErrorResponse;
   ```

2. If this operation is not intended to be a read operation for the resource, consider restructuring it as a resource action instead.

3. If the operation is inherited from a base type and incorrectly resolved, check the base model's operations and ensure they return the correct type.

---

### `non-pageable-list-operation`

**Severity:** Error

**Description:** A list operation on a resource is not pageable. All list operations must be pageable to generate correct SDK code.

**Cause:** The operation is detected as a list operation but is missing the pageable annotation or the `@list` decorator.

**How to fix:**

1. **Add the `@list` decorator** if the operation is intended to be a list operation:

   ```typespec
   @list
   @armResourceList(MyResource)
   op listByResourceGroup(...ResourceListParameters<MyResource>): ArmResponse<ResourceListResult<MyResource>> | ErrorResponse;
   ```

2. **Add the `@markAsPageable` decorator** on the `csharp` scope if the operation cannot use `@list` directly (e.g., due to non-standard pagination patterns):

   ```typespec
   @@markAsPageable(MyService.myListOperation, "csharp");
   ```

3. Verify the operation returns a pageable response type (e.g., `ResourceListResult<T>` or a type annotated with `@pagedResult`).

---

### `duplicate-resource-id`

**Severity:** Error

**Description:** Two or more resources share the same `resourceIdPattern`. Each resolved resource must have a unique resource ID pattern to generate distinct resource types in the SDK.

**Cause:** Multiple resource models map to the same ARM resource path template. This can happen when:
- Two models are accidentally decorated with the same `@armResourcePath`
- A resource model is duplicated in different namespaces with the same path

**How to fix:**

1. Review the resource definitions and ensure each resource has a unique `@armResourcePath`:

   ```typespec
   // Each resource should have a unique path segment
   @armResourcePath("resourceA")
   model ResourceA is TrackedResource<ResourceAProperties> { ... }

   @armResourcePath("resourceB")
   model ResourceB is TrackedResource<ResourceBProperties> { ... }
   ```

2. If both resources are intentionally at the same path, consider merging them into a single resource model.

3. If one of the resources should not be a resource (e.g., it's a nested model), remove the `@armResource*` decorators from it.

---

### `duplicate-resource-name`

**Severity:** Error

**Description:** Two or more resources share the same `resourceName`. Each resolved resource must have a unique name to generate distinct SDK types.

**Cause:** Multiple resource models end up with the same resource name. This can happen when:
- Two resources have the same TypeSpec model name in different namespaces
- The `@clientName` decorator is used to give two resources the same name

**How to fix:**

1. Rename one of the resource models to have a unique name:

   ```typespec
   model UniqueResourceA is TrackedResource<ResourceAProperties> { ... }
   model UniqueResourceB is TrackedResource<ResourceBProperties> { ... }
   ```

2. If the resources are in different namespaces but have the same name, use `@clientName` to differentiate them in the generated SDK:

   ```typespec
   @@clientName(NamespaceA.MyResource, "MyResourceA", "csharp");
   @@clientName(NamespaceB.MyResource, "MyResourceB", "csharp");
   ```

3. If the duplication is unintentional, check if one of the models should not be a resource and remove its resource decorators.
