# Migration to @azure-typespec/http-client-csharp Generator

This document tracks the migration of Azure.Developer.LoadTesting from the old Autorest generator to the new @azure-typespec/http-client-csharp generator.

## Status: IN PROGRESS

### Completed Steps

1. ✅ Updated `tsp-location.yaml` to reference `eng/http-client-csharp-emitter-package.json`
2. ✅ Regenerated SDK code using the new TypeSpec generator
3. ✅ Fixed namespace issues (LoadTestService → Azure.Developer.LoadTesting)
4. ✅ Resolved OperationState naming conflict (renamed to LoadTestOperationState)
5. ✅ Updated csproj to include System.ClientModel package
6. ✅ Added error suppressions for AZC0007, AZC0012, AZC0015, IL2026, IL3050

### Remaining Work

#### Custom Code Migration

The custom code in the `src/Custom/` directory needs to be migrated from Azure.Core APIs to System.ClientModel APIs:

**API Surface Changes:**

| Old (Azure.Core) | New (System.ClientModel) |
|-----------------|-------------------------|
| `TokenCredential` | `AuthenticationTokenProvider` |
| `HttpPipeline` | `ClientPipeline` |
| `RequestContent` | `BinaryContent` |
| `RequestContext` | `RequestOptions` |
| `Response` / `Response<T>` | `ClientResult` / `ClientResult<T>` |
| `Pageable<T>` / `AsyncPageable<T>` | Collection results pattern |
| `ClientDiagnostics` | Not directly available |

**Files Requiring Migration:**

1. **LoadTestAdministrationClient.cs** - Custom methods for file upload operations
   - `UploadTestFile` methods need to use new operation patterns
   - Update to use `ClientResult` instead of `Response`
   - Update to use `RequestOptions` instead of `RequestContext`

2. **LoadTestRunClient.cs** - Custom methods for test run operations
   - `BeginTestRun` methods need updating
   - Pagination helpers need rewriting for new collection results
   - `GetMetrics` overloads need conversion

3. **FileUploadResultOperation.cs** - Long-running operation for file uploads
   - Needs to implement new LRO pattern from System.ClientModel
   - Update response types

4. **TestRunResultOperation.cs** - Long-running operation for test runs
   - Needs to implement new LRO pattern
   - Update response types

5. **TestProfileRunResultOperation.cs** - Long-running operation for profile runs
   - Needs to implement new LRO pattern
   - Update response types

#### API Compatibility

The new generator produces a different API surface that may not be backward compatible:

- Methods return `ClientResult<T>` instead of `Response<T>`
- Constructor signatures changed (different credential types)
- Pagination patterns different
- LRO patterns different

**Recommendations:**
- Consider this a **major version bump** (2.0.0)
- Document all breaking changes
- Provide migration guide for customers

#### Testing

Once custom code is migrated:
1. Update unit tests to work with new APIs
2. Update samples
3. Run integration tests
4. Verify all scenarios work end-to-end

### Build Status

Current build fails with ~232 errors due to:
- Custom code using old Azure.Core types
- API compatibility checks failing
- Response type mismatches

### Resources

- [System.ClientModel Documentation](https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/core/System.ClientModel)
- [New Generator Documentation](https://github.com/Azure/azure-sdk-for-net/tree/main/eng/packages/http-client-csharp)
- [Example Migrated SDK: Azure.AI.Projects](https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/ai/Azure.AI.Projects)

### Next Steps

1. Migrate custom operation classes to use System.ClientModel patterns
2. Update LoadTestAdministrationClient custom methods
3. Update LoadTestRunClient custom methods  
4. Update tests
5. Update samples
6. Document breaking changes
7. Complete testing and validation
