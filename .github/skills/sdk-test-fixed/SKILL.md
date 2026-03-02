---
name: sdk-test-fixed
description: Fix Azure SDK .NET test failures by analyzing errors, patching test code and session recording JSON files. Use when test failures occur after TypeSpec conversion or API version upgrades.
---

# SDK Test Fix Agent

## Purpose
This agent resolves Azure SDK .NET test failures after TypeSpec conversion or API version upgrades. It handles two categories of errors:
1. **Test code logic errors** — NullReferenceException, type mismatches, missing members, etc. caused by SDK source code changes. Fixes test code to align with the regenerated SDK while preserving test intent.
2. **Recording mismatch errors** — `TestRecordingMismatchException` caused by differences between actual HTTP requests and previously recorded requests. Patches session recording JSON files to match current SDK behavior.

## When to Use
- After TypeSpec conversion or API version upgrade causes SDK test failures
- When test code throws runtime exceptions (NullReferenceException, InvalidCastException, etc.)
- When `TestRecordingMismatchException` errors appear in test output
- When request headers or body content in recordings no longer match actual requests
- To batch-fix multiple test failures across a test suite

## Input Required
**User provides**: The SDK project path under the repository root

**Example input**:
```
sdk\appconfiguration\Azure.ResourceManager.AppConfiguration
```

## Fix Process

### Step 1: Run Tests and Collect Errors

Run the .NET 8 tests to collect all error messages. Only target .NET 8 since all framework versions share the same recordings.

**Command**:
```powershell
cd <repo-root>
dotnet test <sdk-project-path>\tests -f net8.0 --no-build -- RunConfiguration.TestSessionTimeout=600000
```

If tests need to be built first:
```powershell
dotnet build <sdk-project-path>\tests
dotnet test <sdk-project-path>\tests -f net8.0 --no-build
```

**Example**:
```powershell
dotnet test sdk\appconfiguration\Azure.ResourceManager.AppConfiguration\tests -f net8.0
```

**Note**: Collect the full test output. Each failed test may produce different types of errors that require different fix strategies.

### Step 2: Prepare Test Attributes for Error Classification

Before running tests to classify errors, **modify test method attributes** to separate logic errors from recording mismatch errors. This enables a clear two-phase diagnosis.

#### Why This Step Is Needed

Azure SDK tests use the `[RecordedTest]` attribute to enable HTTP session recording/playback. When `[RecordedTest]` is active, the test framework intercepts HTTP calls and replays recorded sessions. This means:
- **Logic errors** (NullRef, type mismatch, etc.) and **recording mismatch errors** (`TestRecordingMismatchException`) can appear simultaneously, making diagnosis confusing.
- By temporarily disabling recording playback, only **pure logic errors** surface, allowing you to fix them first without interference from recording issues.

#### 2.1: Comment Out `[RecordedTest]` and Add `[Test]`

For each test method in the test file:

1. **If the method has `[RecordedTest]`** — comment it out
2. **If the method does NOT have `[Test]`** — add `[Test]` attribute

**Example**:
```csharp
// Before
[RecordedTest]
public async Task DeleteTest()
{
    // ...
}

// After — Phase 1 (logic error diagnosis)
//[RecordedTest]
[Test]
public async Task DeleteTest()
{
    // ...
}
```

**Batch operation** — use search and replace across all test files:
```powershell
# Find all test files with [RecordedTest]
Get-ChildItem -Path "<sdk-project-path>\tests" -Filter "*.cs" -Recurse |
  Select-String -Pattern "\[RecordedTest\]" -List |
  Select-Object -ExpandProperty Path
```

#### 2.2: Build and Run Tests (Phase 1 — Logic Errors Only)

With `[RecordedTest]` disabled, tests run **without** the recording playback framework. Any failures at this stage are **pure logic errors** (Category A).

```powershell
dotnet build <sdk-project-path>\tests
dotnet test <sdk-project-path>\tests -f net8.0 --no-build -- RunConfiguration.TestSessionTimeout=600000
```

**At this stage**:
- `NullReferenceException`, `InvalidCastException`, `MissingMethodException`, etc. → **Fix test code** (Step 3A)
- Tests that pass → **No logic error**, will need recording check in Phase 2
- Compilation errors → **Fix test code** first

#### 2.3: After All Logic Errors Are Fixed — Restore Attributes

Once all logic errors from Phase 1 are resolved and tests pass (or only fail due to missing HTTP responses):

1. **Uncomment `[RecordedTest]`** on each test method
2. **删除 Phase 1 新添加的 `[Test]`** — 如果 `[Test]` 是 Phase 1 中新增的，必须删除；如果原来就有 `[Test]`，则保留不动

```csharp
// After — Phase 2 (recording mismatch diagnosis)
// 原来没有 [Test]，Phase 1 新增的 → 删除 [Test]
[RecordedTest]
public async Task DeleteTest()
{
    // ...
}

// 原来就有 [Test] → 保留
[RecordedTest]
[Test]
public async Task UpdateTest()
{
    // ...
}
```

> **说明**：恢复阶段需要将测试属性还原到修改前的状态。新增的 `[Test]` 如果不删除，会导致测试方法拥有多余的属性，不符合原始代码风格。

#### 2.4: Run Tests Again (Phase 2 — Recording Mismatches)

With `[RecordedTest]` restored, tests now use the recording playback framework. Any failures at this stage are **recording mismatch errors** (Category B).

```powershell
dotnet test <sdk-project-path>\tests -f net8.0 --no-build -- RunConfiguration.TestSessionTimeout=600000
```

**At this stage**:
- `TestRecordingMismatchException` → **Fix recording files** (Step 3B)
- All tests pass → **Done!**

---

### Step 3: Classify Error Type

Based on the phase you are in, classify each error into one of two categories. This determines which fix path to follow.

**Category A: Test Code Logic Errors**

These are runtime exceptions thrown by the test code itself, indicating the test code is incompatible with the regenerated SDK source.

**Identifying Patterns**:
```
Message:
  System.NullReferenceException : Object reference not set to an instance of an object.
  System.InvalidCastException : Unable to cast object of type 'X' to type 'Y'.
  CS1061: 'TypeName' does not contain a definition for 'MemberName'
  System.MissingMethodException : Method not found: 'ReturnType Namespace.Class.Method(...)'
  System.ArgumentException : ...
```

**Common Causes After SDK Regeneration**:

| Error Type | Typical Cause | Example |
|-----------|---------------|--------|
| `NullReferenceException` | Property/method return type changed, previously non-null value now null | `resource.Data.Properties.xxx` where `Properties` is now null |
| `InvalidCastException` | Type hierarchy changed, implicit cast no longer valid | Enum to string, or base/derived type changes |
| `MissingMethodException` | Method signature changed or method removed | `CreateOrUpdate` parameters changed |
| `CS1061` (missing member) | Property renamed or moved to nested object | `data.Sku` → `data.Properties.Sku` |
| `ArgumentException` | Constructor parameters changed | Required parameters added or removed |

→ **Go to [Step 3A: Fix Test Code Logic Errors](#step-3a-fix-test-code-logic-errors)**

---

**Category B: Recording Mismatch Errors**

These are `TestRecordingMismatchException` errors indicating the recorded HTTP traffic no longer matches what the SDK sends.

**Identifying Pattern**:
```
Message:
  Azure.Core.TestFramework.TestRecordingMismatchException : Unable to find a record for the request <METHOD> <URL>
  Header differences:
      <header-diff-details>
  Body differences:
      <body-diff-details>
```

**Fields to Extract**:

| Field | Description | Example |
|-------|-------------|--------|
| TestName | Failed test method name | `DeleteTest`, `AddTagTest(False)` |
| SourceFile | Test source file name | `ConfigurationStoreOperationTests.cs` |
| METHOD | HTTP method of the mismatched request | `DELETE`, `PATCH`, `PUT`, `GET` |
| URL | Full request URL | `https://management.azure.com/subscriptions/.../configurationStores/testapp-7027?api-version=2025-06-01-preview` |
| Header differences | Missing or extra headers | `<Accept> is absent in request, value <application/json>` |
| Body differences | Missing or extra body properties | `.properties: Missing in record JSON` |

→ **Go to [Step 3B: Locate Session Recording Files](#step-3b-locate-session-recording-files)**

### Step 3A: Fix Test Code Logic Errors

When the error is a test code logic error (Category A), the fix is in the test source code, NOT in the recording files.

> **⚠️ 严格禁止修改 SDK 源码 ⚠️**
>
> 只允许修改测试代码（`tests\` 目录下的 `.cs` 文件）。**严格禁止**修改 `src\Generated\` 下的任何生成代码或 `src\` 下的任何源码文件。
>
> 即使生成的 SDK 返回类型、参数类型、方法签名发生了变化，也必须**调整测试代码来适配新的 SDK API**，而不是反过来修改 SDK 源码。
>
> **原则**：SDK 生成代码是正确的参考基准，测试代码必须适配它。

#### 3A.1: Locate the Error Source

From the error stack trace, identify:
1. **Test file and line number** — where the exception is thrown
2. **The failing expression** — the specific code that fails
3. **The root cause** — what SDK change broke this code

**Example Error**:
```
DeleteTest
  Source: ConfigurationStoreOperationTests.cs line 62
  Message:
    System.NullReferenceException : Object reference not set to an instance of an object.
  Stack Trace:
    at Azure.ResourceManager.AppConfiguration.Tests.ConfigurationStoreOperationTests.DeleteTest() in ..\tests\ConfigurationStoreOperationTests.cs:line 62
```

#### 3A.2: Analyze the SDK Source Code Changes

Compare the test code expectations with the actual generated SDK source:

1. **Read the test file** at the error line to understand what the test is trying to do
2. **Read the SDK source code** (under `src\Generated\`) to understand how the API has changed
3. **Identify the mismatch** — what the test expects vs. what the SDK now provides

**Common Analysis Patterns**:

| Test Code Pattern | SDK Change | Analysis Approach |
|------------------|-----------|-------------------|
| `resource.Data.SomeProperty` throws NRE | Property moved or type changed | Check the generated `Data` model class for the property |
| `new ResourceData(...)` compilation error | Constructor signature changed | Check generated constructors and required parameters |
| `resource.GetSomething()` method not found | Method renamed or moved | Search generated code for similar method names |
| `(SomeType)value` throws InvalidCast | Type changed from class to struct or enum changed | Check the generated type definition |

**How to Find SDK Source**:
```
<sdk-project-path>\src\Generated\        ← Generated model and client code
<sdk-project-path>\src\Generated\Models\ ← Generated model types
<sdk-project-path>\src\Generated\Extensions\ ← Generated extension methods
```

#### 3A.3: Apply the Fix to Test Code

**Principle**: Fix the test code to work with the new SDK API surface while **preserving the original test intent and coverage**.

> **绝对禁止修改 `src\` 目录下的任何文件（包括 `src\Generated\` 下的自动生成代码）。所有修复必须且只能在 `tests\` 目录下的测试代码中进行。**

**Fix Strategies**:

##### Strategy 1: Property Access Path Changed
```csharp
// Before (NullReferenceException)
var value = resource.Data.Properties.Setting;

// After — property moved to Data directly
var value = resource.Data.Setting;
```

##### Strategy 2: Constructor Signature Changed
```csharp
// Before (MissingMethodException)
var data = new ConfigurationStoreData(location, sku);

// After — new required parameter added
var data = new ConfigurationStoreData(location, sku, createMode);
```

##### Strategy 3: Method Signature Changed
```csharp
// Before (method not found)
await store.UpdateAsync(patchData);

// After — method now returns different type or takes different params
await store.UpdateAsync(WaitUntil.Completed, patchData);
```

##### Strategy 4: Type Changed
```csharp
// Before (InvalidCastException)
string skuName = (string)data.Sku.Name;

// After — Sku.Name is now an enum/union type
string skuName = data.Sku.Name.ToString();
```

##### Strategy 5: Null Check Required
```csharp
// Before (NullReferenceException)
Assert.AreEqual("value", resource.Data.Properties.SomeField);

// After — Properties may be null in response, access safely
Assert.IsNotNull(resource.Data.Properties);
Assert.AreEqual("value", resource.Data.Properties.SomeField);
// OR if property moved:
Assert.AreEqual("value", resource.Data.SomeField);
```

#### 3A.4: Compile and Rerun

After fixing test code:

1. **Build** to ensure compilation succeeds:
```powershell
dotnet build <sdk-project-path>\tests
```

2. **Run the specific test** to verify（注意此时 `[RecordedTest]` 应处于注释状态，`[Test]` 应已添加）：
```powershell
dotnet test <sdk-project-path>\tests -f net8.0 --no-build --filter "FullyQualifiedName~<TestName>"
```

3. **If the test passes** (Phase 1, without recording), the logic error is fixed. Move to the next failing test.
4. **If a new code error appears**, repeat Step 3A for the new error.
5. **When all logic errors are fixed** — restore `[RecordedTest]` attributes (see Step 2.3), then rerun all tests. Any `TestRecordingMismatchException` errors now go to **[Step 3B](#step-3b-locate-session-recording-files)**.

---

### Step 3B: Locate Session Recording Files

Session recordings are stored in the `.assets` folder under a hash-based directory structure.

**Recording File Path Pattern**:
```
.assets\<hash>\net\<sdk-path>\tests\SessionRecords\<TestClassName>\<TestMethodName>.json
```

**Locating Steps**:
1. Find the `.assets` folder in the repo root
2. Navigate the hash directory (e.g., `XOK1tj8eU4`) — there is typically only one
3. Follow the path: `net\<sdk-path>\tests\SessionRecords\`
4. Find the folder matching the test class name (e.g., `ConfigurationStoreOperationTests`)
5. Find the JSON file matching the test method name

**Important**: Each test method has both sync and async variants:
- `<TestName>.json` — sync version
- `<TestName>Async.json` — async version

**Both files must be fixed** since they share the same recording structure.

**Example**:
```
Test: DeleteTest in ConfigurationStoreOperationTests.cs

Recording files:
.assets\XOK1tj8eU4\net\sdk\appconfiguration\Azure.ResourceManager.AppConfiguration\tests\SessionRecords\ConfigurationStoreOperationTests\DeleteTest.json
.assets\XOK1tj8eU4\net\sdk\appconfiguration\Azure.ResourceManager.AppConfiguration\tests\SessionRecords\ConfigurationStoreOperationTests\DeleteTestAsync.json
```

### Step 4B: Locate the Matching Request Entry in Recording

Each recording JSON file contains an array of `Entries`. Each entry represents one HTTP request/response pair.

**Recording JSON Structure**:
```json
{
  "Entries": [
    {
      "RequestUri": "https://management.azure.com/subscriptions/.../configurationStores/testapp-7027?api-version=2025-06-01-preview",
      "RequestMethod": "DELETE",
      "RequestHeaders": {
        "Accept": "application/json",
        "Authorization": "Sanitized",
        ...
      },
      "RequestBody": null,
      "StatusCode": 200,
      "ResponseHeaders": { ... },
      "ResponseBody": { ... }
    },
    ...
  ]
}
```

**Matching Rules**:
1. **Match by URL path**: Extract the URL path from the error message (strip the `api-version` query parameter for matching), find entries whose `RequestUri` contains the same resource path
2. **Match by HTTP method**: Filter entries where `RequestMethod` matches the method from the error (e.g., `DELETE`, `PATCH`)
3. If multiple entries match, use the one closest to the position implied by the test flow

### Step 5B: Apply Fixes Based on Recording Error Type

#### Fix Type 1: Header Differences — Extra Header in Recording

**Error Pattern**:
```
Header differences:
    <HeaderName> is absent in request, value <HeaderValue>
```

**Meaning**: The recording has a header that the actual request does NOT send. The SDK code no longer sends this header.

**Fix**: Remove the header from `RequestHeaders` in the matching entry.

**Example**:
```
Error: <Accept> is absent in request, value <application/json>
```

**Before**:
```json
"RequestHeaders": {
  "Accept": "application/json",
  "Authorization": "Sanitized",
  "x-ms-client-request-id": "..."
}
```

**After**:
```json
"RequestHeaders": {
  "Authorization": "Sanitized",
  "x-ms-client-request-id": "..."
}
```

#### Fix Type 2: Header Differences — Missing Header in Recording

**Error Pattern**:
```
Header differences:
    <HeaderName> is present in request, but not in record, value <HeaderValue>
```

**Meaning**: The actual request sends a header that the recording does NOT have.

**Fix**: Add the header to `RequestHeaders` in the matching entry.

**Example**:
```
Error: <Content-Type> is present in request, but not in record, value <application/json>
```

**Fix**: Add `"Content-Type": "application/json"` to `RequestHeaders`.

#### Fix Type 3: Body Differences — Extra Property in Request

**Error Pattern**:
```
Body differences:
There are differences between request and recordentry bodies:
.properties: Missing in record JSON
```

**Meaning**: The actual request body has a `.properties` field, but the recording's `RequestBody` does NOT. However, since we want the recording to match the **current** SDK behavior, this typically means the recording has an **extra** nested `"properties": {}` that should be removed, or the SDK now sends a different body structure.

**Interpretation Guide**:
- `.<field>: Missing in record JSON` — The field is in the actual request but not in the recording. This usually means the recording's `RequestBody` includes content that is now structured differently. Examine the context to determine the correct fix.
- `.<field>: Missing in request JSON` — The field is in the recording but not in the actual request. Remove it from the recording.

**Common Scenario — Remove empty `properties` object**:
When the SDK no longer wraps content in `"properties": {}`, remove the empty wrapper from the recording.

**Before**:
```json
"RequestBody": "{\"tags\":{\"tag1\":\"value1\"},\"properties\":{}}"
```

**After**:
```json
"RequestBody": "{\"tags\":{\"tag1\":\"value1\"}}"
```

**Note**: `RequestBody` is a **JSON string** (escaped JSON inside a string value). Edit it carefully, ensuring the resulting string is valid JSON when parsed.

#### Fix Type 4: Body Differences — Property Value Mismatch

**Error Pattern**:
```
Body differences:
There are differences between request and recordentry bodies:
.properties.field: Expected "oldValue", got "newValue"
```

**Fix**: Update the value in the recording's `RequestBody` to match the expected value.

#### Fix Type 5: API Version Mismatch

**Error Pattern**:
```
Unable to find a record for the request GET https://...?api-version=2025-06-01-preview
```
Where the recording has `api-version=2024-09-01` or a different version.

**Fix**: Update the `api-version` query parameter in `RequestUri` for ALL matching entries throughout the recording file.

**Search and replace**:
```
Old: api-version=2024-09-01
New: api-version=2025-06-01-preview
```

**Important**: Apply this change to **all entries** in the recording file, not just the one matching the error, as the entire file likely uses the old API version.

#### Fix Type 6: Response Schema Changes

Sometimes the `ResponseBody` also needs updating if the SDK expects a different response structure. This is less common but may occur when:
- New fields are added to response models
- Field names change
- Response envelope structure changes

**Fix**: Update the `ResponseBody` content to match what the new API version returns.

### Step 6B: Fix Both Sync and Async Recordings

**Critical**: Every fix must be applied to BOTH recording files:
- `<TestName>.json`
- `<TestName>Async.json`

The content structure is identical between sync and async recordings (only request IDs and timestamps differ), so the same logical fix applies to both files.

### Step 7: Rerun Tests and Iterate

After applying fixes (either test code or recording fixes):

1. **Rerun tests**:
```powershell
dotnet test <sdk-project-path>\tests -f net8.0 --no-build
```

2. **Reclassify remaining failures**: Each failure may be a different category
   - Code logic error → Go to Step 3A
   - Recording mismatch → Go to Step 3B
3. **Apply additional fixes**: Fixing one error often reveals previously hidden errors
4. **Iterate**: Repeat steps 2-7 until all tests pass

**Iteration Strategy**:
- **Phase 1 先行** — 注释 `[RecordedTest]`、添加 `[Test]`，先修复所有逻辑错误
- **Phase 2 后续** — 恢复 `[RecordedTest]`，删除 Phase 1 新增的 `[Test]`（原有的保留），再修复所有录制不匹配
- **严禁修改源码** — 所有修复只在 `tests\` 目录进行，绝不触碰 `src\` 目录
- Fix all errors of the same type together (e.g., all header fixes, then body fixes)
- After each batch of fixes, rerun to verify and discover new errors
- Keep a log of applied fixes for traceability

**Two-Phase Fix Pattern** (recommended workflow):
```
Phase 1: Comment out [RecordedTest], add [Test]
  → Run tests (no recording playback)
  → Test fails → NullReferenceException / InvalidCast / etc.
    → Fix test code ONLY (never modify src)
    → Rerun test
    → Test passes ✓ (logic is correct)
  → All logic errors fixed

Phase 2: Restore [RecordedTest], remove newly added [Test] (keep original [Test])
  → Run tests (with recording playback)
  → Test fails → TestRecordingMismatchException
    → Fix recording JSON in .assets folder
    → Fix BOTH sync and async recordings
    → Rerun test
    → Test passes ✓
```

## Workflow Summary

```
1. Build tests
       ↓
2. Prepare test attributes (Phase 1)
       │  Comment out [RecordedTest]
       │  Add [Test] if missing
       ↓
   Run tests (net8.0, no recording playback)
       ↓
3. Fix all logic errors (Category A)
       │  ⚠️ ONLY modify test code, NEVER modify src
       │  NullRef, InvalidCast, MissingMethod, etc.
       │  Adapt test code to new SDK API surface
       ↓
   All logic tests pass?
       ├── No → repeat Step 3A
       └── Yes ↓
4. Restore test attributes (Phase 2)
       │  Uncomment [RecordedTest]
       │  Remove [Test] if newly added; keep if original
       ↓
   Run tests (net8.0, with recording playback)
       ↓
5. Fix recording mismatches (Category B)
       │  TestRecordingMismatchException
       │  Fix Headers/Body/API version in recordings
       │  Fix BOTH sync and async JSON files
       ↓
   All tests pass?
       ├── No → repeat Step 5B
       └── Yes → Done ✓
```

## Common Error Types Quick Reference

### Category A: Code Logic Errors

| Error Pattern | Fix Action | Apply To |
|---------------|-----------|----------|
| `NullReferenceException` | Check property access chain, verify against generated models | Test `.cs` file |
| `InvalidCastException` | Update type cast to match new SDK types | Test `.cs` file |
| `MissingMethodException` | Update method call to match new signature | Test `.cs` file |
| `CS1061` (member not found) | Find renamed/relocated property in generated code | Test `.cs` file |
| `ArgumentException` | Update constructor/method arguments | Test `.cs` file |

### Category B: Recording Mismatch Errors

| Error Pattern | Fix Action | Apply To |
|---------------|-----------|----------|
| `<Header> is absent in request` | Remove header from `RequestHeaders` | Both sync/async recordings |
| `<Header> is present in request, but not in record` | Add header to `RequestHeaders` | Both sync/async recordings |
| `.<field>: Missing in record JSON` | Check if recording has extra properties to remove | Both sync/async recordings |
| `.<field>: Missing in request JSON` | Remove field from `RequestBody` | Both sync/async recordings |
| `api-version` mismatch in URL | Replace old api-version in all `RequestUri` fields | All entries in both files |
| `Expected "<old>", got "<new>"` | Update value in `RequestBody` | Both sync/async recordings |

## Best Practices

### DO:
- **先处理测试属性** — 注释 `[RecordedTest]`、添加 `[Test]`，将逻辑错误与录制错误分离
- **分两阶段诊断** — Phase 1 修复逻辑错误，Phase 2 修复录制文件
- **Fix code errors before recording errors** — code fixes may change request behavior
- **Preserve test intent** — when fixing test code, maintain the same test coverage and assertions
- **Read the generated SDK source** — always understand the actual API before modifying tests
- **Always fix both** sync and async recording files for each test
- **Run only net8.0** tests — recordings are shared across all target frameworks
- **Fix by category** — batch all header fixes, then body fixes, etc.
- **Validate JSON** after editing `RequestBody` strings (they are escaped JSON)
- **Check for cascading effects** — one fix may resolve multiple test failures
- **Use search-and-replace** for API version changes across entire files
- **修复完成后恢复 `[RecordedTest]`** — Phase 1 新增的 `[Test]` 需要删除，原有的保留

### DON'T:
- **❌ 绝对不要修改 `src\` 或 `src\Generated\` 下的 SDK 源码** — 即使返回类型、参数类型改变，也只修改测试代码
- Skip error classification — applying recording fixes to code errors wastes time
- Change test logic or remove assertions — only adapt to new API surface
- Add new test functionality while fixing — keep fixes minimal and focused
- Fix only one of sync/async recordings — both must match
- Manually re-record tests unless the recording is fundamentally broken
- Change `ResponseBody` content unless explicitly needed
- Ignore malformed JSON in `RequestBody` — this will cause runtime parse errors
- **忘记恢复 `[RecordedTest]` 属性** — Phase 2 必须恢复才能正确检测录制不匹配
- **不要忘记删除 Phase 1 新增的 `[Test]`** — 恢复阶段必须删除新增的 `[Test]`，但原有的 `[Test]` 不能删

## Troubleshooting

### Issue 1: Test Code Error — Cannot Determine Correct Fix
- **Cause**: The SDK source change is complex (e.g., entire model restructured)
- **Solution**:
  - Search the generated `src\Generated\Models\` folder for the relevant type
  - Compare old vs. new model structure by reading the generated `.cs` files
  - Look at other tests in the same class for patterns of how the new API is used
  - If a property was removed entirely, check if it was moved to a sub-object or renamed
  ```powershell
  # Find where a property/type is defined in generated code
  grep -r "PropertyName" <sdk-project-path>\src\Generated\ --include="*.cs"
  ```

### Issue 2: Code Fix Causes Compilation Error in Other Tests
- **Cause**: Multiple tests share helper methods or base class setup code
- **Solution**:
  - Check if the change affects shared helper methods in the test base class
  - Update the shared method signature and fix all callers
  - If the helper is used differently by different tests, consider creating an overload

### Issue 3: Cannot Find `.assets` Folder
- **Cause**: Assets not restored
- **Solution**: Run `dotnet build` first, or manually restore test assets:
  ```powershell
  # Check for assets.json in the test project
  cat <sdk-project-path>\tests\assets.json
  # The assets are auto-restored during build
  ```

### Issue 4: Recording File Has Many Entries with Same URL
- **Cause**: Test makes multiple requests to the same endpoint (e.g., polling LRO)
- **Solution**: 
  - Match by both URL **and** HTTP method
  - If still ambiguous, consider the request sequence order
  - Look at `RequestBody` content to distinguish between entries

### Issue 5: Fix Applied but Test Still Fails
- **Cause**: Multiple differences in the same request entry, or additional entries need fixing
- **Solution**:
  - Check the **new** error message — it may point to a different issue in the same entry
  - Verify the JSON string in `RequestBody` is valid after editing
  - Ensure changes were saved to the correct file

### Issue 6: Test Passes Individually but Fails in Batch
- **Cause**: Test ordering or shared state issues
- **Solution**:
  - Run the specific test in isolation to verify the recording fix
  - Check for recording entries shared across tests
  ```powershell
  dotnet test <path> -f net8.0 --filter "FullyQualifiedName~<TestName>"
  ```

### Issue 7: `RequestBody` String Editing Mistakes
- **Cause**: `RequestBody` is an escaped JSON string, not a JSON object
- **Solution**:
  - Parse the string value as JSON, make edits, then re-serialize
  - Watch for trailing commas after removing properties
  - Ensure proper escaping of quotes within the string value
  
**Example of proper editing**:
```json
// Original (escaped string)
"RequestBody": "{\"tags\":{\"tag1\":\"value1\"},\"properties\":{}}"

// Step 1: Parse the string → {"tags":{"tag1":"value1"},"properties":{}}
// Step 2: Remove "properties" → {"tags":{"tag1":"value1"}}
// Step 3: Re-serialize → "{\"tags\":{\"tag1\":\"value1\"}}"
```
