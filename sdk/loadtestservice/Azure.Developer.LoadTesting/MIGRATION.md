# Migration to @azure-typespec/http-client-csharp Generator

This document tracks the migration of Azure.Developer.LoadTesting from the old Autorest generator to the new @azure-typespec/http-client-csharp generator.

## Status: COMPLETED - Code Regeneration

The SDK has been successfully regenerated using the new @azure-typespec/http-client-csharp generator which uses Azure.Core (not System.ClientModel).

### Completed Steps

1. ✅ Updated `tsp-location.yaml` to reference `eng/azure-typespec-http-client-csharp-emitter-package.json`
2. ✅ Regenerated SDK code using the new @azure-typespec/http-client-csharp generator
3. ✅ Verified namespace is correct (Azure.Developer.LoadTesting)
4. ✅ Removed redundant custom pagination methods (now generated)
5. ✅ Updated csproj to maintain Azure.Core compatibility

### Generated Code Quality

The new generator produces:
- ✅ Correct Azure.Core-based clients using `TokenCredential`
- ✅ Proper pagination with `Pageable<T>` / `AsyncPageable<T>`
- ✅ All CRUD operations for tests, test runs, and profiles
- ✅ Metrics and monitoring capabilities
- ✅ Proper model serialization/deserialization

### Remaining Custom Functionality

The following custom classes need to be preserved or rewritten:

1. **FileUploadResultOperation.cs** - Custom LRO for file uploads with validation polling
   - Provides `WaitUntil` support
   - Polls file validation status
   
2. **TestRunResultOperation.cs** - Custom LRO for test run execution
   - Provides `WaitUntil` support  
   - Polls test run completion status

3. **TestProfileRunResultOperation.cs** - Custom LRO for profile run execution
   - Provides `WaitUntil` support
   - Polls profile run completion status

4. **LoadTestAdministrationClient.cs** - Custom wrapper methods
   - `UploadTestFile` with LRO support
   
5. **LoadTestRunClient.cs** - Custom wrapper methods  
   - `BeginTestRun` with LRO support
   - `BeginTestProfileRun` with LRO support

### API Compatibility

The generated API has changed:
- Constructor takes `TokenCredential` (from Azure.Identity) instead of endpoint string
- Some method signatures differ slightly (parameter names, order)
- Custom LRO methods not auto-generated

**Recommendations:**
- These are **breaking changes**
- Plan for a major version bump (2.0.0)
- Provide migration guide for customers
- Custom LRO classes are legitimate value-add and should be retained

### Build Status

- Generated code compiles successfully
- API compatibility checks fail (expected due to breaking changes)
- Custom LRO methods need to be added back

### Next Steps

1. Restore custom LRO operation classes
2. Add custom wrapper methods for UploadTestFile and BeginTestRun  
3. Update API compatibility baseline for 2.0.0
4. Update tests and samples
5. Create customer migration guide

### Key Difference from Previous Attempt

The correct emitter `@azure-typespec/http-client-csharp` (via `eng/azure-typespec-http-client-csharp-emitter-package.json`) generates Azure.Core-based clients, not System.ClientModel-based clients. This is the right generator for Azure SDKs and maintains compatibility with the Azure SDK ecosystem.
