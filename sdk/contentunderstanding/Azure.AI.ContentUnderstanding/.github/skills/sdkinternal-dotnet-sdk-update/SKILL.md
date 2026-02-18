---
name: sdkinternal-dotnet-sdk-update
description: "Update the Azure.AI.ContentUnderstanding .NET SDK from a new TypeSpec commit. Use when the TypeSpec spec has been updated and the SDK needs regeneration."
---

# Update .NET SDK from TypeSpec Commit

This skill guides updating the `Azure.AI.ContentUnderstanding` .NET SDK when a new TypeSpec commit is available.

## Prerequisites

- .NET 8.0 SDK (or higher)
- Node.js LTS (>= 18) for tsp-client / TypeSpec
- PowerShell 7+ (for `Export-API.ps1` script)
- Git
- Visual Studio 2022 (optional, for IDE experience; requires .NET Framework 4.6.1+ development tools)

## Folder Structure

```
sdk/contentunderstanding/
├── Azure.AI.ContentUnderstanding/
│   ├── tsp-location.yaml              # TypeSpec commit reference
│   ├── src/
│   │   ├── Generated/                 # Auto-generated code (DO NOT edit)
│   │   ├── ContentUnderstandingClient.Customizations.cs  # Custom client methods
│   │   ├── AudioVisualContent.Customizations.cs          # Custom deserialization
│   │   ├── ContentField.Extensions.cs                    # .Value property
│   │   ├── ArrayField.Extensions.cs                      # Indexer + Count
│   │   ├── ObjectField.Extensions.cs                     # Indexer by name
│   │   ├── ContentFieldDictionaryExtensions.cs           # GetFieldOrDefault
│   │   ├── OperationWithId.cs                            # Operation ID wrapper
│   │   ├── Suppression.cs                                # AZC0034 suppressions
│   │   └── Properties/AssemblyInfo.cs
│   └── tests/
└── Azure.AI.ContentUnderstanding.Tests/
```

## Workflow Steps

### Step 1: Update TypeSpec Commit Reference

Update the `commit` field in `tsp-location.yaml`:

```yaml
# File: sdk/contentunderstanding/Azure.AI.ContentUnderstanding/tsp-location.yaml
directory: specification/ai/ContentUnderstanding
commit: <NEW_COMMIT_SHA>  # Update this to the new spec commit
repo: Azure/azure-rest-api-specs
additionalDirectories:
emitterPackageJsonPath: eng/azure-typespec-http-client-csharp-emitter-package.json
```

### Step 2: Regenerate SDK

The simplest way to regenerate is via MSBuild from the package's `src` directory:

```bash
cd sdk/contentunderstanding/Azure.AI.ContentUnderstanding/src
dotnet build /t:GenerateCode
```

This single command (defined in `eng/CodeGeneration.targets`):
1. Installs tsp-client (`npm ci --prefix eng/common/tsp-client`)
2. Builds the C# generator plugin (`eng/packages/plugins/client/Client.Plugin/`)
3. Runs `tsp-client update --no-prompt` to sync the spec and regenerate code under `src/Generated/`

**Alternative** — run tsp-client directly from the repo root:

```bash
# Install tsp-client (if not already)
cd eng/common/tsp-client
npm ci

# Run update from the repo root
npm exec --prefix eng/common/tsp-client --no -- tsp-client update --no-prompt --output-dir sdk/contentunderstanding/Azure.AI.ContentUnderstanding/
```

**Useful MSBuild options:**

```bash
# Verbose / trace output
dotnet build /t:GenerateCode /p:Trace=true -v d

# Use a local spec repo instead of downloading from GitHub
dotnet build /t:GenerateCode /p:LocalSpecRepo=/path/to/azure-rest-api-specs

# Save TypeSpec inputs for later offline regeneration
dotnet build /t:GenerateCode /p:SaveInputs=true

# Skip spec sync (use previously downloaded spec files — requires prior SaveInputs run)
dotnet build /t:GenerateCode /p:SkipSync=true

# Generate test project scaffold
dotnet build /t:GenerateCode /p:GenerateTestProject=true

# Skip building the generator plugin (if already built)
dotnet build /t:GenerateCode /p:SkipBuildPlugin=true
```

### Step 3: Verify Customizations Are Preserved

.NET SDK customizations live in **partial classes and extension files** alongside the `Generated/` folder. These files are NOT overwritten during regeneration because they are hand-authored (not inside `Generated/`). However, regeneration can change the generated code that customizations depend on.

#### Step 3a: Build and Check for Compilation Errors

```bash
cd sdk/contentunderstanding
dotnet build
```

If there are compilation errors, check:

1. **Signature changes**: If generated methods change signatures (new/removed/renamed parameters), the `[CodeGenSuppress]` attributes and custom method overrides in `ContentUnderstandingClient.Customizations.cs` may need updating.
2. **Type changes**: If generated model classes are renamed or restructured, extension files (`ContentField.Extensions.cs`, etc.) may need updating.
3. **Internal API changes**: `OperationWithId.cs` depends on internal protocol operation APIs. If these change, the wrapper may need adjustment.

#### Step 3b: Verify All Customization Files Exist

Ensure these files still exist and are NOT inside `Generated/`:

- `ContentUnderstandingClient.Customizations.cs`
- `AudioVisualContent.Customizations.cs`
- `ContentField.Extensions.cs`
- `ArrayField.Extensions.cs`
- `ObjectField.Extensions.cs`
- `ContentFieldDictionaryExtensions.cs`
- `OperationWithId.cs`
- `Suppression.cs`

### Step 4: Export Updated Public API Surface

If the regeneration changed public APIs, update the API listing:

```powershell
eng/scripts/Export-API.ps1 contentunderstanding
```

This updates the `Azure.AI.ContentUnderstanding.netstandard2.0.cs` API listing file used for API review.

### Step 5: Build and Run Playback Tests

Run the recorded/playback tests to verify the regenerated SDK doesn't break existing behavior. These tests replay previously recorded HTTP sessions — no live Azure resources needed.

**Preferred: Use the test runner script** (from the SDK package root directory):

```bash
cd sdk/contentunderstanding/Azure.AI.ContentUnderstanding

# Run all tests in playback mode (default)
skills/skills_20260217/sdkinternal-dotnet-test-run/scripts/test-run.sh

# Or explicitly specify playback mode and framework
skills/skills_20260217/sdkinternal-dotnet-test-run/scripts/test-run.sh --mode playback -t net10.0
```

The script sets `AZURE_TEST_MODE=Playback` which is the correct way to run playback tests in the Azure SDK test framework.

**Alternative: Run dotnet test directly** (set the environment variable manually):

```bash
cd sdk/contentunderstanding/Azure.AI.ContentUnderstanding/tests

AZURE_TEST_MODE=Playback dotnet test -f net10.0
```

**Note:** The test project targets multiple frameworks. Use whichever .NET runtime you have installed:
```bash
# Check which runtimes are available
dotnet --list-runtimes
```

**Expected result:** All tests should pass with 0 failures. As of the `4e98679` update, there are 97 playback tests.

If tests fail:
1. Check if model/API changes broke test assertions — update tests as needed
2. If API behavior changed, re-record with live Azure resources (requires provisioning test resources first, see `eng/common/TestResources/README.md`):
   ```bash
   # Provision live test resources (one-time setup)
   eng/common/TestResources/New-TestResources.ps1 contentunderstanding

   # Re-record tests
   dotnet test --filter TestCategory=Live
   ```

### Step 6: Update This Skill Document

If any customizations changed (added, removed, or modified), update the "Current Known Customizations" section below.

---

## Current Known Customizations

These customizations are hand-authored files in `src/` (outside `Generated/`). They are NOT overwritten during regeneration, but they depend on generated code that CAN change.

**After every regeneration**, go through each customization below:
1. Read the **"Still needed?"** section to decide if the customization is still required.
2. If still needed, follow **"What to verify after regeneration"** to check it still works.
3. If broken, follow **"How to fix"** instructions.

---

### Customization 1: Suppress & Replace Analyze/AnalyzeBinary Methods

**File**: `ContentUnderstandingClient.Customizations.cs`

**Reason this exists** (3 independent reasons — check each):

| # | Reason | Still needed when... | Can remove when... |
|---|--------|---------------------|--------------------|
| 1a | Hide `stringEncoding` param from public API — hardcode to `"utf16"` for .NET | Generated convenience methods still include a `stringEncoding` parameter | The emitter learns to omit `stringEncoding` from convenience methods, or the TypeSpec removes it |
| 1b | Auto-detect `contentType` for `AnalyzeBinary` — resolve via: explicit param > `BinaryData.MediaType` > `"application/octet-stream"` | Generated `AnalyzeBinary` convenience method does NOT auto-detect from `BinaryData.MediaType` | The emitter adds `BinaryData.MediaType` fallback logic |
| 1c | Wrap protocol methods with `OperationWithId` so `Operation.Id` returns the operation ID from `Operation-Location` header | Generated protocol methods return a plain `Operation<BinaryData>` whose `Id` does NOT return the operation ID | The emitter generates `Operation<T>` that exposes `Id` from `Operation-Location` header |

**Still needed?** — After regeneration, check the generated file `Generated/ContentUnderstandingClient.cs`. Look for:
1. Do the generated `Analyze`/`AnalyzeBinary` convenience methods still have a `stringEncoding` parameter? If yes → 1a still needed.
2. Does the generated `AnalyzeBinary` convenience method fall back to `BinaryData.MediaType`? If no → 1b still needed.
3. Does the generated protocol method return something that exposes operation ID from `Operation-Location`? If no → 1c still needed.

**What this file contains** (exact inventory):

**8 `[CodeGenSuppress]` attributes** — These suppress 4 convenience + 4 protocol methods (sync + async each):

```csharp
// Convenience methods suppressed (the 2nd param `string` is the stringEncoding we're hiding):
[CodeGenSuppress("AnalyzeAsync",       typeof(WaitUntil), typeof(string), typeof(string), typeof(IEnumerable<AnalyzeInput>), typeof(IDictionary<string, string>), typeof(ProcessingLocation?), typeof(CancellationToken))]
[CodeGenSuppress("Analyze",            typeof(WaitUntil), typeof(string), typeof(string), typeof(IEnumerable<AnalyzeInput>), typeof(IDictionary<string, string>), typeof(ProcessingLocation?), typeof(CancellationToken))]
[CodeGenSuppress("AnalyzeBinaryAsync", typeof(WaitUntil), typeof(string), typeof(string), typeof(BinaryData), typeof(string), typeof(string), typeof(ProcessingLocation?), typeof(CancellationToken))]
[CodeGenSuppress("AnalyzeBinary",      typeof(WaitUntil), typeof(string), typeof(string), typeof(BinaryData), typeof(string), typeof(string), typeof(ProcessingLocation?), typeof(CancellationToken))]

// Protocol methods suppressed (to wrap with OperationWithId):
[CodeGenSuppress("AnalyzeAsync",       typeof(WaitUntil), typeof(string), typeof(RequestContent), typeof(string), typeof(string), typeof(Guid?), typeof(RequestContext))]
[CodeGenSuppress("Analyze",            typeof(WaitUntil), typeof(string), typeof(RequestContent), typeof(string), typeof(string), typeof(Guid?), typeof(RequestContext))]
[CodeGenSuppress("AnalyzeBinaryAsync", typeof(WaitUntil), typeof(string), typeof(string), typeof(RequestContent), typeof(string), typeof(string), typeof(string), typeof(Guid?), typeof(RequestContext))]
[CodeGenSuppress("AnalyzeBinary",      typeof(WaitUntil), typeof(string), typeof(string), typeof(RequestContent), typeof(string), typeof(string), typeof(string), typeof(Guid?), typeof(RequestContext))]
```

**4 custom convenience methods** (sync + async × Analyze + AnalyzeBinary):
- `Analyze` / `AnalyzeAsync` — takes `(WaitUntil, string analyzerId, IEnumerable<AnalyzeInput> inputs, IDictionary<string, string>? modelDeployments, ProcessingLocation? processingLocation, CancellationToken)` — no `stringEncoding`.
- `AnalyzeBinary` / `AnalyzeBinaryAsync` — takes `(WaitUntil, string analyzerId, BinaryData binaryInput, string? inputRange, string? contentType, ProcessingLocation? processingLocation, CancellationToken)` — no `stringEncoding`, auto-detects `contentType`.

**4 custom protocol methods** (sync + async × Analyze + AnalyzeBinary):
- Same signatures as generated, but body uses `OperationWithId` wrapper and `WaitUntil.Started` trick.

**4 PATCH convenience methods** (emitter-fix: emitter doesn't generate convenience methods for PATCH operations):
- `UpdateAnalyzer(string analyzerId, ContentAnalyzer resource, CancellationToken)`
- `UpdateAnalyzerAsync(string analyzerId, ContentAnalyzer resource, CancellationToken)`
- `UpdateDefaults(IDictionary<string, string> modelDeployments, CancellationToken)` — serializes via `ContentUnderstandingModelFactory.ContentUnderstandingDefaults()` + `ModelReaderWriter.Write()` with `AzureAIContentUnderstandingContext.Default`
- `UpdateDefaultsAsync(IDictionary<string, string> modelDeployments, CancellationToken)`

**What to verify after regeneration:**

1. **Do `[CodeGenSuppress]` signatures still match?** Open the generated `ContentUnderstandingClient.cs` and check if the method signatures for `Analyze`, `AnalyzeBinary` (convention + protocol) match the `typeof(...)` lists. If the generator changed parameter types/order/count, update the attributes.
2. **Does `AnalyzeRequest1` still exist?** Our convenience `Analyze` methods construct `new AnalyzeRequest1(inputs.ToList(), modelDeployments ?? new ChangeTrackingDictionary<string, string>(), new ChangeTrackingDictionary<string, BinaryData>())`. If the generator renamed this spread model (e.g., to `AnalyzeRequest2`), update the reference.
3. **Do `CreateAnalyzeRequest()` / `CreateAnalyzeBinaryRequest()` still exist with the same signatures?** Our protocol methods call these to build the HTTP message. Check `Generated/ContentUnderstandingClient.RestClient.cs`.
4. **Does `AnalyzeResult.FromLroResponse()` still exist?** Our convenience methods use it for deserialization. Check `Generated/Models/AnalyzeResult.Serialization.cs`.
5. **Do `ContentUnderstandingModelFactory` and `AzureAIContentUnderstandingContext.Default` still exist?** Used by `UpdateDefaults`. Check `Generated/ContentUnderstandingModelFactory.cs` and `Generated/Models/AzureAIContentUnderstandingContext.cs`.
6. **Does the emitter now generate convenience methods for PATCH operations?** If yes, the `UpdateAnalyzer`/`UpdateDefaults` methods may now be generated and our custom ones would conflict. Check for `UpdateAnalyzer`/`UpdateDefaults` in the generated client.

**How to fix if broken:**
- Signature mismatch → Update the `typeof(...)` lists in `[CodeGenSuppress]` to match the new generated signatures.
- Renamed internal type → Find the new name in `Generated/` and update the reference.
- Generator now emits convenience PATCH methods → Remove our custom `UpdateAnalyzer`/`UpdateDefaults` methods, or suppress the generated ones if they don't match our API.

---

### Customization 2: OperationWithId Wrapper

**File**: `OperationWithId.cs`

**Reason**: The generated `Operation<BinaryData>` returned by protocol methods does not expose the operation ID from the `Operation-Location` response header. We need this ID for `GetResultFile()` and `DeleteResult()` APIs.

**Still needed?** — After regeneration, check: does the generated `Operation<BinaryData>` from `Analyze`/`AnalyzeBinary` protocol methods expose the operation ID via `.Id`? If no → still needed.

**What this file contains**: An `internal class OperationWithId : Operation<BinaryData>` that:
- Wraps the generated `Operation<BinaryData>`
- In constructor: calls `GetRawResponse()`, reads `Operation-Location` header, parses URI, extracts last path segment as operation ID
- Overrides `Id` property to return the extracted operation ID
- Delegates `Value`, `HasValue`, `HasCompleted`, `GetRawResponse()`, `UpdateStatus()`, `UpdateStatusAsync()` to inner operation

**What to verify after regeneration:**
1. Does `Operation<BinaryData>` still have the same abstract members? (Unlikely to change, but check if Azure.Core updated.)
2. Does the service still return the operation ID as the last path segment of `Operation-Location`? (Check a live response if unsure.)

**How to fix if broken:**
- If `Operation<T>` API changed, update the overrides.
- If this is no longer needed (generator exposes Id), delete this file AND remove the `OperationWithId` wrapping in `ContentUnderstandingClient.Customizations.cs` protocol methods.

---

### Customization 3: AudioVisualContent Deserialization Fix (KeyFrameTimesMs)

**File**: `AudioVisualContent.Customizations.cs`

**Reason**: The Content Understanding service returns `"KeyFrameTimesMs"` (PascalCase `K`) instead of `"keyFrameTimesMs"` (camelCase `k`) for the `AudioVisualContent` type. The generated deserializer only checks `"keyFrameTimesMs"`.

**Still needed?** — Test with a live request that returns audio/video content. Check the JSON response:
- If the response still has `"KeyFrameTimesMs"` (capital K) → still needed.
- If the response now uses `"keyFrameTimesMs"` only → can remove this customization.

**What this file contains**:
- `[CodeGenSuppress("DeserializeAudioVisualContent", typeof(JsonElement), typeof(ModelReaderWriterOptions))]` on the `AudioVisualContent` partial class
- A complete hand-maintained `DeserializeAudioVisualContent` method (copy of the generated one, plus the dual-casing fix for `keyFrameTimesMs`)

**The actual fix** — only this part differs from generated code:
```csharp
// Generated code has only:
//   if (prop.NameEquals("keyFrameTimesMs"u8))
// Our fix adds:
if (prop.NameEquals("keyFrameTimesMs"u8) || prop.NameEquals("KeyFrameTimesMs"u8))
{
    if (keyFrameTimesMs == null)  // only set once, in case both casings appear
    { ... }
}
```

**What to verify after regeneration — CRITICAL:**

This is the **highest-maintenance customization** because we own the entire deserializer. After regeneration:

1. Open `Generated/Models/AudioVisualContent.Serialization.cs` — the generated `DeserializeAudioVisualContent` will exist there even though it's suppressed (the generator doesn't know about suppressions). If the generator skips output for suppressed members, temporarily remove the `[CodeGenSuppress]` attribute, regenerate, and compare.
2. **Diff the generated version against our custom version** property-by-property:
   - Are there any **new properties** in the generated version? → Add their deserialization to our custom version.
   - Are there any **removed properties**? → Remove from our custom version.
   - Did any **property types change** (e.g., `int` → `long`)? → Update our custom version.
   - Did the **constructor call at the end** change its parameter list? → Update the `return new AudioVisualContent(...)` call.
3. **Current properties handled** (for reference when diffing):
   `kind`, `mimeType`, `analyzerId`, `category`, `path`, `markdown`, `fields`, `startTimeMs`, `endTimeMs`, `width`, `height`, `cameraShotTimesMs`, `keyFrameTimesMs` (with dual-casing fix), `transcriptPhrases`, `segments`, plus `additionalBinaryDataProperties` for unknown properties.

**How to fix if broken:**
- New property → Copy the deserialization block from the generated version into our custom method, at the correct position.
- Changed type → Update the local variable type and deserialization call.
- Changed constructor → Update the `return new AudioVisualContent(...)` parameters.

**How to remove when no longer needed:**
1. Delete the `[CodeGenSuppress("DeserializeAudioVisualContent", typeof(JsonElement), typeof(ModelReaderWriterOptions))]` attribute
2. Delete the entire `DeserializeAudioVisualContent` method from `AudioVisualContent.Customizations.cs`
3. If the file is now empty (no other customizations), delete the file

---

### Customization 4: ContentField .Value Property

**File**: `ContentField.Extensions.cs`

**Reason**: Generated `ContentField` subclasses have type-specific properties (`ValueString`, `ValueNumber`, etc.) but no unified `Value` property. Users would need to cast to the specific subtype. We add a polymorphic `Value` property using pattern matching.

**Still needed?** — After regeneration, check: does generated `ContentField` now have a `Value` property? Check `Generated/Models/ContentField.cs`. If yes → can remove. If no → still needed.

**What this file contains**:
```csharp
public partial class ContentField
{
    public object Value => this switch
    {
        StringField sf => sf.ValueString,
        NumberField nf => nf.ValueNumber,
        IntegerField inf => inf.ValueInteger,
        DateField df => df.ValueDate,
        TimeField tf => tf.ValueTime,
        BooleanField bf => bf.ValueBoolean,
        ObjectField of => of.ValueObject,
        ArrayField af => af.ValueArray,
        JsonField jf => jf.ValueJson,
        _ => null
    };
}
```

**What to verify after regeneration:**
1. Are all field subtypes still named the same? (`StringField`, `NumberField`, `IntegerField`, `DateField`, `TimeField`, `BooleanField`, `ObjectField`, `ArrayField`, `JsonField`)
2. Are their value properties still named the same? (`ValueString`, `ValueNumber`, `ValueInteger`, `ValueDate`, `ValueTime`, `ValueBoolean`, `ValueObject`, `ValueArray`, `ValueJson`)
3. Were any **new field subtypes** added? → Add them to the switch expression.

**How to fix:** Update the switch expression to match the current subtype names and properties.

---

### Customization 5: ArrayField Extensions

**File**: `ArrayField.Extensions.cs`

**Reason**: Generated `ArrayField` only has `ValueArray` (`IList<ContentField>`). We add `Count` and an `int` indexer for ergonomic access.

**Still needed?** — Check `Generated/Models/ArrayField.cs`. If it now has `Count` or an indexer → can remove ours. If not → still needed.

**What this file contains**:
```csharp
public partial class ArrayField
{
    public int Count => ValueArray?.Count ?? 0;
    public ContentField this[int index] { get { /* bounds check + return ValueArray[index] */ } }
}
```

**What to verify after regeneration:**
1. Does `ArrayField` still have `ValueArray` of type `IList<ContentField>`? If renamed → update.
2. Does the generator now emit `Count` or an indexer? If yes → remove ours to avoid conflict.

---

### Customization 6: ObjectField Extensions

**File**: `ObjectField.Extensions.cs`

**Reason**: Generated `ObjectField` only has `ValueObject` (`IDictionary<string, ContentField>`). We add a `string` indexer for `obj["fieldName"]` syntax.

**Still needed?** — Check `Generated/Models/ObjectField.cs`. If it now has a string indexer → can remove ours. If not → still needed.

**What this file contains**:
```csharp
public partial class ObjectField
{
    public ContentField this[string fieldName] { get { /* AssertNotNullOrEmpty + TryGetValue, throws KeyNotFoundException */ } }
}
```

**What to verify after regeneration:**
1. Does `ObjectField` still have `ValueObject` of type `IDictionary<string, ContentField>`? If renamed → update.
2. Does the generator now emit a string indexer? If yes → remove ours to avoid conflict.

---

### Customization 7: ContentFieldDictionaryExtensions

**File**: `ContentFieldDictionaryExtensions.cs`

**Reason**: Provides a null-safe `GetFieldOrDefault()` extension method on `IDictionary<string, ContentField>` that returns `null` instead of throwing.

**Still needed?** — This is a pure convenience extension. It's always needed unless the generator adds an equivalent method. Check `Generated/` for any `GetFieldOrDefault` method. If not found → still needed.

**What this file contains**:
```csharp
public static partial class ContentFieldDictionaryExtensions
{
    public static ContentField GetFieldOrDefault(this IDictionary<string, ContentField> fields, string fieldName)
    {
        // AssertNotNullOrEmpty, TryGetValue, return null if not found
    }
}
```

**What to verify after regeneration:**
1. Does `ContentField` still exist? (always check after major regeneration)
2. Does the generator now emit a similar method? If yes → remove ours.

---

### Customization 8: AZC0034 Warning Suppressions

**File**: `Suppression.cs`

**Reason**: Assembly-level `[SuppressMessage("Design", "AZC0034", ...)]` for types that intentionally share names with `FormRecognizer`/`DocumentIntelligence` SDKs.

**Still needed?** — Always needed as long as these type names exist in our SDK and conflict with other Azure namespaces.

**Current suppressed types** (18):
`AnalyzeResult`, `CopyAuthorization`, `DocumentBarcode`, `DocumentBarcodeKind`, `DocumentCaption`, `DocumentFigure`, `DocumentFootnote`, `DocumentFormula`, `DocumentFormulaKind`, `DocumentLine`, `DocumentPage`, `DocumentParagraph`, `DocumentSection`, `DocumentTable`, `DocumentTableCell`, `DocumentTableCellKind`, `DocumentWord`, `LengthUnit`

**What to verify after regeneration:**
1. Build the project. If you see new `AZC0034` warnings → add `[SuppressMessage]` entries for the new types.
2. If any of the 18 types above were removed from the generated code → remove the corresponding suppression (otherwise it's harmless dead code).

**How to check for new AZC0034 issues:**
```bash
cd sdk/contentunderstanding
dotnet build 2>&1 | grep AZC0034
```

---

## Troubleshooting

### dotnet build /t:GenerateCode fails

1. **Node.js not installed**: tsp-client requires Node.js 18+. Install from https://nodejs.org/
2. **npm ci fails**: Delete `node_modules` in `eng/common/tsp-client` and retry
3. **Emitter package mismatch**: Ensure `emitterPackageJsonPath` in `tsp-location.yaml` points to the correct file (`eng/azure-typespec-http-client-csharp-emitter-package.json` for data plane)

### Compilation errors after regeneration

1. **[CodeGenSuppress] mismatch** (Customization 1): Generated method signatures changed → update the `typeof(...)` lists. See "What to verify" in Customization 1.
2. **Internal spread model renamed** (Customization 1): `AnalyzeRequest1` or `ChangeTrackingDictionary` renamed → find new name in `Generated/Internal/`, update reference.
3. **AudioVisualContent new/changed properties** (Customization 3): Diff generated `AudioVisualContent.Serialization.cs` against our custom version. See "What to verify" in Customization 3.
4. **Field subtypes renamed** (Customizations 4-7): e.g., `StringField` renamed → update `ContentField.Extensions.cs` switch + other extension files.
5. **PATCH methods now generated** (Customization 1): Check if `UpdateAnalyzer`/`UpdateDefaults` now appear in generated client → remove custom versions or suppress generated ones.
6. **Serialization context renamed** (Customization 1): `AzureAIContentUnderstandingContext.Default` or `ContentUnderstandingModelFactory` changed → update `UpdateDefaults` methods.

### Export-API.ps1 fails

Ensure PowerShell 7+ is installed:
```bash
# Check version
pwsh --version

# Install on Ubuntu
sudo apt install -y powershell
```

### Tests fail

1. Check if model/API changes broke test assertions — update tests as needed
2. For recorded tests, ensure test recordings are up to date
3. If API behavior changed, re-record:
   ```bash
   dotnet test --filter TestCategory=Live
   ```

### tsp-client: command not found

Do **not** install tsp-client globally. Use from the repo:
```bash
npm exec --prefix eng/common/tsp-client --no -- tsp-client version
```

Or use `dotnet build /t:GenerateCode` which handles installation automatically.

---

## Related Files

- `tsp-location.yaml` — TypeSpec commit reference and emitter configuration
- `src/Generated/` — Auto-generated code (DO NOT edit manually)
- `src/ContentUnderstandingClient.Customizations.cs` — **Customizations 1** (Analyze methods, PATCH methods)
- `src/OperationWithId.cs` — **Customization 2** (Operation ID extraction)
- `src/AudioVisualContent.Customizations.cs` — **Customization 3** (KeyFrameTimesMs casing fix)
- `src/ContentField.Extensions.cs` — **Customization 4** (.Value property)
- `src/ArrayField.Extensions.cs` — **Customization 5** (Count, indexer)
- `src/ObjectField.Extensions.cs` — **Customization 6** (string indexer)
- `src/ContentFieldDictionaryExtensions.cs` — **Customization 7** (GetFieldOrDefault)
- `src/Suppression.cs` — **Customization 8** (AZC0034 suppressions)
- `eng/azure-typespec-http-client-csharp-emitter-package.json` — Emitter package definition
- `eng/common/tsp-client/` — tsp-client CLI tool
- `eng/CodeGeneration.targets` — MSBuild targets for `GenerateCode`

## Reference Documentation

- [.NET SDK TypeSpec Code Generation](https://github.com/Azure/azure-sdk-for-net/blob/main/doc/DataPlaneCodeGeneration/AzureSDKCodeGeneration_DataPlane_Quickstart.md)
- [Azure SDK .NET Design Guidelines](https://azure.github.io/azure-sdk/dotnet_introduction.html)
- [Azure SDK .NET Contributing Guide](https://github.com/Azure/azure-sdk-for-net/blob/main/CONTRIBUTING.md)
- [Long-Running Operations in .NET](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md)
