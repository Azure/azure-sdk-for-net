---
name: sdkinternal-dotnet-workflow-review-sample-quality
description: Reviews Content Understanding SDK samples for code quality, correctness, and output accuracy. Enumerates sample files, runs samples to generate output, reviews code line-by-line for correctness and clarity, verifies output matches code behavior, checks comments for accuracy. Use when reviewing sample code quality, verifying sample correctness, or ensuring samples are well-documented.
---

# Review CU Sample Quality

This skill performs comprehensive quality review of Content Understanding SDK samples, ensuring code correctness, clarity, output accuracy, and documentation quality.

## When to Use

- Reviewing sample code quality and correctness
- Verifying sample outputs match code behavior
- Checking comment accuracy and clarity
- Validating sample documentation matches implementation

## Prerequisites

1. **Clean working directory**: The skill requires an empty git change list before starting
2. **SDK compiled**: Samples require the SDK to be compiled (`sdk-compile`)
3. **Test recordings**: For PLAYBACK mode, recordings must be available

## Workflow

### Step 1: Verify Clean Working Directory

**CRITICAL**: The skill must stop if there are uncommitted changes.

```powershell
git status --porcelain
```

If output is non-empty, **STOP** and inform the user that changes must be committed or stashed first.

### Step 2: Enumerate Samples

Discover all samples in `tests/samples/`:

**Sample naming pattern:**
- `Sample##_Description.cs`
- Example: `Sample01_AnalyzeBinary.cs`

**Output format:**
```
Found N samples:
  - Sample01_AnalyzeBinary.cs
  - Sample02_AnalyzeUris.cs
  - Sample03_ExtractFieldsWithAnalyzer.cs
  ...
```

### Step 3: Run Samples

Run samples in PLAYBACK mode to generate output:

```powershell
$env:AZURE_TEST_MODE = "Playback"
dotnet test tests/*.csproj -f net462 --filter "FullyQualifiedName~Samples" -v n
```

### Step 4: Review Each Sample

For each sample, perform line-by-line review:

#### 4.1 Understand Sample Purpose
- Read the method-level XML documentation
- Understand what the sample demonstrates
- Identify key operations and expected behavior

#### 4.2 Review Code Correctness
Check for:
- **Logic errors**: Incorrect API usage, wrong method calls, missing error handling
- **Type safety**: Correct types, proper casting, null handling
- **Resource management**: Proper cleanup, using statements where needed
- **Best practices**: Following C# and Azure SDK conventions

#### 4.3 Review Code Clarity
Check for:
- **Readability**: Clear variable names, logical flow, appropriate abstractions
- **Structure**: Well-organized code, appropriate method extraction
- **Comments**: Code is self-documenting or has helpful comments

#### 4.4 Verify Output Matches Code
Compare the sample code with test execution:

1. **Trace execution flow**: Follow the code path and identify what should be printed
2. **Check for missing output**: Verify all expected Console.WriteLine appear in output
3. **Check for incorrect output**: Verify output values match code logic
4. **Check for unexpected output**: Look for errors, exceptions, or warnings not explained in code

#### 4.5 Review Comments and Regions

##### XML Documentation
- Method has `<summary>` describing purpose
- Parameters are documented
- Any prerequisites are noted

##### Code Regions
- `#region Snippet:` markers for documentation
- `#region Assertion:` markers for test assertions
- `#if SNIPPET` / `#else` blocks for documentation vs test code

##### Inline Comments
- Comments explain non-obvious logic
- Comments match actual code behavior
- No outdated or incorrect comments

### Step 5: Generate Review Summary

For each sample that had changes, create a review summary:

**Summary format:**
```markdown
# Sample Review: Sample##_Description

**Date**: YYYY-MM-DD
**File**: `tests/samples/Sample##_Description.cs`

## Sample Purpose
[Brief description of what the sample demonstrates]

## Changes Made

### Code Correctness
- Issue: [Description]
  - Fix: [What was changed]
  
### Code Clarity
- Issue: [Description]
  - Fix: [What was changed]

### Documentation
- Issue: [Description]
  - Fix: [What was changed]

## Summary
[Overall summary of changes and improvements]
```

## Review Checklist

For each sample, verify:

- [ ] Code is correct and handles edge cases
- [ ] Code is clear and readable
- [ ] Output matches code behavior
- [ ] All expected output is present
- [ ] No unexpected errors or warnings
- [ ] `#region Snippet:` markers are correct
- [ ] `#if SNIPPET` blocks have user-friendly placeholders
- [ ] XML documentation is accurate
- [ ] Inline comments are accurate and helpful
- [ ] Assertions validate all important results

## .NET-Specific Patterns

### Snippet Pattern
```csharp
#region Snippet:ContentUnderstandingAnalyzeBinary
#if SNIPPET
            string filePath = "<localDocumentFilePath>";
#else
            string filePath = TestEnvironment.CreatePath("sample_invoice.pdf");
#endif
// ... sample code ...
#endregion
```

### Assertion Pattern
```csharp
#region Assertion:ContentUnderstandingAnalyzeBinary
            Assert.IsNotNull(result, "Result should not be null");
            Assert.IsTrue(result.Contents.Count > 0, "Should have contents");
            Console.WriteLine($"Analysis completed with {result.Contents.Count} contents");
#endregion
```

## Related Skills

- **`sdk-compile`**: Compiles SDK. Required before running samples.
- **`sdk-run-sample`**: Runs a single sample for testing.
- **`sdk-run-all-samples`**: Runs all samples for comprehensive testing.
- **`sdk-test-playback`**: Runs samples with recorded responses.

## Example Workflow

```
1. Check git status → Clean ✓
2. Enumerate samples → Found 12 samples
3. Run sdk-compile → Build successful
4. Run sdk-run-all-samples → All passed
5. Review Sample01_AnalyzeBinary.cs
   - Code review ✓
   - Output verification ✓
   - Made 2 documentation fixes
6. Review Sample02_AnalyzeUris.cs
   - Found logic error in error handling
   - Fixed and documented
7. Continue with remaining samples...
8. Summarize all changes
```

## Notes

- **Stop on errors**: If git status shows changes, stop immediately
- **Test in PLAYBACK mode**: Use recorded responses for consistent results
- **Follow conventions**: Use Azure SDK .NET conventions for samples
- **Document changes**: Create review summaries for all changes made
