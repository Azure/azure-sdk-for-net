# Pipeline Failure Patterns and Resolution

## Build Failures

- Check for TypeSpec customization needs (missing client.tsp changes)
- Verify tspconfig.yaml emitter configuration is correct
- Check for breaking changes in the generated API surface

## Test Failures

- Check if tests need playback recording updates
- Verify test fixtures are present and valid

## Validation Failures

- Run `azsdk_package_run_check` locally to reproduce
- Check changelog format and content
- Verify API compatibility (no unintended breaking changes)

## Common Failure Patterns

| Pattern                       | Likely Cause                   | Fix                                |
| ----------------------------- | ------------------------------ | ---------------------------------- |
| Missing types/models          | TypeSpec compilation issue     | Fix TypeSpec, regenerate           |
| Breaking change detected      | API surface changed            | Add `@clientName` or revert change |
| Test playback failure         | Recorded responses outdated    | Re-record test sessions            |
| Changelog validation error    | Missing or malformed changelog | Update changelog content           |
| Dependency resolution failure | Package version conflict       | Check dependency versions          |

## Fix Application

**If TypeSpec change is needed:**

- Use TypeSpec customization to apply changes
- Regenerate SDK after TypeSpec fixes

**If code fix is needed:**

- Apply fix directly in SDK repo
- Re-run build and validation locally

**If pipeline/infrastructure issue:**

- Suggest re-running the pipeline
- Report infrastructure issues to engineering systems team
