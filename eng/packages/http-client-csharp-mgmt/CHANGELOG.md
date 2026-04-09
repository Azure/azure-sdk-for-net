# Release History

## 1.0.0 (Unreleased)

### Features Added

### Breaking Changes

### Bugs Fixed

- Fixed LIFO stack push order in `BuildContextualParameterHierarchy` for scope-based extension resources. For resources such as `ChaosTarget` and `KubernetesClusterExtension`, the variable-key/variable-value pair was pushed in the wrong order, causing `Id.Name` and `Id.ResourceType.Type` to be swapped in the generated REST call arguments.
- Fixed `getExpectedParentResourceType` in the emitter to handle parent paths with more than 3 segments. For resources scoped under nested multi-provider paths (e.g., `managementGroups/{mgId}/subscriptions/{subId}/providers/Microsoft.Quota/...`), the function now falls back to computing the parent scope resource type from the last `/providers/` segment, enabling correct `ValidateResourceId` generation for those collections.

### Other Changes
