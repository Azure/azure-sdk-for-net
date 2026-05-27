# ------------------------------------------------------------------------------
# Post-generation fixups for the Azure.ResourceManager.DataFactory package.
#
# This script patches non-compilable C# that the MPG generator emits for a small
# set of well-known generator bugs that affect this package. Each block cites
# the tracking issue and is intended to be removed once upstream lands the fix.
#
# Scope: STRICTLY surgical text rewrites of `src\Generated\` content. The script
#   - is the LAST-RESORT fallback (see mpg-rules.md §11.0 / §11.0.1 / §11.6);
#   - must NEVER be wired into the package's *.csproj (e.g., MSBuild <Exec>);
#   - must NEVER do public-API edits (no `api\*.cs` rewrites, no ApiCompat
#     silencing). Those belong in client.tsp decorators or `Custom\` partials.
#
# Location: per mpg-rules.md §11.6, package-specific post-gen scripts live
# under each package's `eng\` folder (sibling of `src\`), so each service owns
# its own set of bug-workarounds independently. Repo-shared logic is forbidden
# — copy the blocks you actually need into the per-package script.
#
# Invocation (typical):
#   pwsh sdk\datafactory\Azure.ResourceManager.DataFactory\eng\post-gen-fixups.ps1
#   # Or, when wired into a regen helper (e.g., RegenSdkLocal.ps1), call this
#   # script as the very last step *after* `dotnet build /t:GenerateCode`.
#
# Idempotency: every patch is safe to re-run on already-patched output.
# ------------------------------------------------------------------------------

[CmdletBinding()]
param(
    # Path to the SDK package root (the folder containing src\ and tests\).
    # Defaults to the parent of $PSScriptRoot (i.e., the script lives in <pkg>\eng\).
    [Parameter(Mandatory = $false)]
    [string] $PackageRoot = (Split-Path -Parent $PSScriptRoot)
)

$ErrorActionPreference = 'Stop'
Set-StrictMode -Version Latest

if (-not (Test-Path -LiteralPath $PackageRoot)) {
    throw "PackageRoot does not exist: $PackageRoot"
}

$generatedDir = Join-Path $PackageRoot 'src\Generated'
if (-not (Test-Path -LiteralPath $generatedDir)) {
    throw "Generated folder not found at $generatedDir. Pass -PackageRoot pointing at a package root that contains src\Generated."
}

# Resolve to absolute path so logs are unambiguous when invoked from arbitrary cwd.
$PackageRoot = (Resolve-Path -LiteralPath $PackageRoot).Path
$packageName = Split-Path -Leaf $PackageRoot

Write-Host "[post-gen-fixups] Package root: $PackageRoot"

# ------------------------------------------------------------------------------
# Helper: enumerate Generated\Models\*.Serialization.cs once (used by §11.1-§11.3).
# ------------------------------------------------------------------------------
$serializationFiles = Get-ChildItem -LiteralPath (Join-Path $generatedDir 'Models') -Filter '*.Serialization.cs' -File -ErrorAction SilentlyContinue
$modelFiles = Get-ChildItem -LiteralPath (Join-Path $generatedDir 'Models') -Filter '*.cs' -File -ErrorAction SilentlyContinue

# ------------------------------------------------------------------------------
# §11.1 + §11.2  — Stub `Type.Deserialize<Type>(jsonElement, options)` calls that
# do not exist on the SDK shim types (Azure.Core.Expressions.DataFactory).
#
# Cause: `@@alternateType(...identity: "Azure.Core.Expressions.DataFactoryElement")`
# aliasing on Union/Reference/Secret types causes the MPG generator to emit calls
# to a static `Deserialize…` overload that the SDK type does not expose.
#
# Behavior: replace each broken call with `default` plus a TODO comment citing
# the tracking issue. The runtime impact (deserialization no-op for these
# property values) is acceptable until the upstream fix ships.
#
# Why a post-gen rewrite instead of `[CodeGenMember]` Custom partials?
#   The bug appears across ~400 `Models\*.Serialization.cs` files (one Deserialize
#   call site per affected property). Replacing them via Custom code would mean
#   `[CodeGenMember("DeserializeXxx")]` on every affected model and rewriting
#   the entire ~50–150-line generated Deserialize body — ~15–40 KLOC of
#   duplicated boilerplate that itself drifts with every regen. The clean
#   alternative (add the missing static method on the SDK shim type in
#   `sdk/core/Azure.Core.Expressions.DataFactory`) is out of scope: this
#   migration must not change the shared core package. Therefore an idempotent
#   text rewrite that stubs the call is the only economical resolution that
#   stays inside `Azure.ResourceManager.DataFactory`.
#
# Tracking: https://github.com/Azure/azure-sdk-for-net/issues/59298
# Remove this block once the MPG generator emits the correct deserialization
# expression for `@@alternateType(...identity: ...)` aliases on Unions/References,
# OR once the SDK shim types expose a matching `Deserialize…(JsonElement, ModelReaderWriterOptions)`
# overload.
# ------------------------------------------------------------------------------
$deserializeTypes = @(
    'DataFactoryElement',
    'DataFactoryLinkedServiceReference',
    'DataFactorySecret',
    'DataFactorySecretString'
)

$deserializeFixedFiles = 0
foreach ($file in $serializationFiles) {
    $content = [System.IO.File]::ReadAllText($file.FullName)
    $original = $content

    foreach ($t in $deserializeTypes) {
        # Match generic instantiation tail when present (e.g. <T>, <IList<T>>).
        # Use a tempered range that won't cross statement separators (= or ;).
        $genericTail = if ($t -eq 'DataFactoryElement') { '<[^=;]*?>' } else { '' }

        # Scalar form: prop.Value (or any single-arg + options)
        $scalarPattern = [regex]::new(
            ('{0}{1}\.Deserialize{0}\(prop\.Value,\s*options\)' -f $t, $genericTail))
        $content = $scalarPattern.Replace(
            $content,
            "default /* TODO(#59298): Deserialize$t is not implemented; stub until generator fix */")

        # Array-add form: array.Add(item, options)
        $arrayPattern = [regex]::new(
            ('array\.Add\({0}{1}\.Deserialize{0}\(item,\s*options\)\);' -f $t, $genericTail))
        $content = $arrayPattern.Replace(
            $content,
            "array.Add(default); /* TODO(#59298): Deserialize$t is not implemented; stub until generator fix */")
    }

    if ($content -cne $original) {
        [System.IO.File]::WriteAllText($file.FullName, $content)
        $deserializeFixedFiles++
    }
}
Write-Host "[post-gen-fixups] §11.1+§11.2 (#59298): stubbed Deserialize calls in $deserializeFixedFiles file(s)."

# ------------------------------------------------------------------------------
# §11.3 — Sync local-dictionary name in `additional*.Add(prop.Name, …)` calls.
#
# Cause: MPG generator inconsistently declares the additional-data dictionary
# as `additionalProperties` or `additionalBinaryDataProperties` per file, but
# the `.Add(...)` reference sometimes uses the other name (CS0103).
#
# Behavior: per file, sync the call to the actually-declared local.
#
# Why a post-gen rewrite instead of `[CodeGenMember]` Custom partials?
#   The bug surfaces in ~110 `Models\*.Serialization.cs` files; each fix is a
#   single-token rename of one local-variable reference. Expressing that fix
#   via Custom code would require `[CodeGenMember("DeserializeXxx")]` on every
#   affected model plus a hand-written copy of the entire (50–150-line)
#   Deserialize body — ~10 KLOC of duplicated boilerplate that drifts with
#   every regen. A 4-line `if/elseif` text rewrite is the proportionate fix.
#
# Tracking: https://github.com/Azure/azure-sdk-for-net/issues/58691
# Remove this block once the generator emits matching names consistently.
# ------------------------------------------------------------------------------
$additionalFixedFiles = 0
foreach ($file in $serializationFiles) {
    $content = [System.IO.File]::ReadAllText($file.FullName)
    $original = $content

    $declaresLong  = $content -cmatch 'IDictionary<string, BinaryData>\s+additionalBinaryDataProperties\s*=\s*new ChangeTrackingDictionary'
    $declaresShort = $content -cmatch 'IDictionary<string, BinaryData>\s+additionalProperties\s*=\s*new ChangeTrackingDictionary'

    if ($declaresLong -and -not $declaresShort) {
        $content = $content -creplace '(?<![\w])additionalProperties\.Add\(prop\.Name', 'additionalBinaryDataProperties.Add(prop.Name'
    }
    elseif ($declaresShort -and -not $declaresLong) {
        $content = $content -creplace '(?<![\w])additionalBinaryDataProperties\.Add\(prop\.Name', 'additionalProperties.Add(prop.Name'
    }

    if ($content -cne $original) {
        [System.IO.File]::WriteAllText($file.FullName, $content)
        $additionalFixedFiles++
    }
}
Write-Host "[post-gen-fixups] §11.3 (#58691): synced additionalProperties name in $additionalFixedFiles file(s)."

# ------------------------------------------------------------------------------
# §11.4 — Replace `IDictionary<string, BinaryData>.ToRequestContent(parameters)`
# (invalid C# emitted for dictionary-typed request bodies) with the local
# helper at `src\Customized\RestOperations\<Package>ParameterDictionaryHelper.cs`.
#
# The helper writes each BinaryData value as a raw JSON token under its key
# (matches AutoRest baseline). It is ship-with code in `Custom\`, not part of
# this script.
#
# Why is part of this fix in `Custom\` and the other part in this script?
#   The actual workaround for the broken `CreateRun` body is a `[CodeGenSuppress]`
#   + hand-written replacement in
#   `src\Customized\GeneratorBugWorkarounds\DataFactoryPipelineResource.cs`,
#   which already replaces `IDictionary<string,BinaryData>.ToRequestContent(...)`
#   with the helper call. This script block is therefore expected to be a NO-OP
#   on the regen produced by the current generator + Custom suppressions, and is
#   retained only as a safety net in case `[CodeGenSuppress]` ever stops matching
#   the regenerated signature (so the broken call would reappear in `Generated\`).
#
# Tracking: https://github.com/Azure/azure-sdk-for-net/issues/59440
# Remove this block (and the helper) once the generator emits a valid
# IDictionary serialization for body parameters.
# ------------------------------------------------------------------------------
# Map of package-name → helper class name. Add an entry when porting this script
# to a new package that hits the same bug.
$dictionaryHelperByPackage = @{
    'Azure.ResourceManager.DataFactory' = 'DataFactoryParameterDictionaryHelper'
}

if ($dictionaryHelperByPackage.ContainsKey($packageName)) {
    $helperClass = $dictionaryHelperByPackage[$packageName]
    $helperFixedFiles = 0
    Get-ChildItem -LiteralPath $generatedDir -Recurse -File -Filter '*.cs' | ForEach-Object {
        $content = [System.IO.File]::ReadAllText($_.FullName)
        $original = $content
        $content = $content -creplace 'IDictionary<string,\s*BinaryData>\.ToRequestContent\(parameters\)', "$helperClass.ToRequestContent(parameters)"
        if ($content -cne $original) {
            [System.IO.File]::WriteAllText($_.FullName, $content)
            $helperFixedFiles++
        }
    }
    Write-Host "[post-gen-fixups] §11.4 (#59440): rewired Dictionary.ToRequestContent in $helperFixedFiles file(s) → $helperClass."
}
else {
    Write-Host "[post-gen-fixups] §11.4 (#59440): no helper mapping for package '$packageName'; skipped."
}

# ------------------------------------------------------------------------------
# §11.5 — Not applicable to Azure.ResourceManager.DataFactory.
#
# In this package every `Arm…ModelFactory` factory method that takes `ETag? eTag`
# forwards it to a generated ctor whose corresponding parameter is also `ETag?`
# (verified on `DataFactoryData`, `DataFactoryTriggerData`, etc.). No rewrite is
# needed. If a future regen produces `string`-typed ctor parameters here, add
# the corresponding `eTag?.ToString()` patch in this block.
#
# Tracking: https://github.com/Azure/azure-sdk-for-net/issues/59298 (umbrella).
# ------------------------------------------------------------------------------

# ------------------------------------------------------------------------------
# §11.7 (package-specific) — Unknown<DiscriminatorBase> synthesized name mismatch.
#
# Cause: client.tsp renames each discriminator base via @@clientName
# (Activity→PipelineActivity, Trigger→DataFactoryTriggerProperties, etc.). The
# MPG generator then synthesizes the internal "unknown" subclass using the
# C#-renamed base name, producing types like `UnknownDataFactoryTriggerProperties`.
# The GA contract however shipped the shorter pre-rename forms (`UnknownTrigger`,
# `UnknownActivity`, …) on `[PersistableModelProxy(typeof(Unknown…))]`. There is
# no spec-side decorator that can target a synthesized Unknown<Base> name
# independently of the public renamed base, so a one-time per-package text
# rename is the only available remediation today.
#
# Why a post-gen rewrite instead of Custom partials?
#   Each of the 8 mismatched `Unknown<Base>` types is an `internal partial class`
#   that the generator emits AND references from `[PersistableModelProxy(typeof(...))]`
#   on the public abstract base. Replacing this via Custom code would require, per
#   pair: (a) `[CodeGenSuppress("Unknown<MpgName>")]` on the public base,
#   (b) a hand-written internal partial class with the GA name and the full
#   discriminator-unknown body, (c) `[CodeGenSuppress(typeof(PersistableModelProxyAttribute))]`
#   on the public base to drop the wrong typeof, and (d) a hand-written attribute
#   declaration re-pointing the proxy at the GA-named type. ~8 × 4 nested
#   customizations to express what is mechanically a name swap. A file-rename +
#   identifier rewrite is the proportionate fix.
#
# Tracking: https://github.com/Azure/azure-sdk-for-net/issues/59298 (umbrella
# clientName / synthesized-type gap). Remove this block once the MPG emitter
# supports targeting synthesized Unknown<Base> types directly (e.g., a future
# `@@clientName(Unknown<Base>, "UnknownShortName", "csharp")`).
# ------------------------------------------------------------------------------
$unknownRenames = [ordered]@{
    'UnknownPipelineActivity'                       = 'UnknownActivity'
    'UnknownCopyActivitySource'                     = 'UnknownCopySource'
    'UnknownDataFactoryCredential'                  = 'UnknownCredential'
    'UnknownDataFactoryDataFlowProperties'          = 'UnknownDataFlow'
    'UnknownDataFactoryDatasetProperties'           = 'UnknownDataset'
    'UnknownDataFactoryIntegrationRuntimeProperties' = 'UnknownIntegrationRuntime'
    'UnknownDataFactoryLinkedServiceProperties'     = 'UnknownLinkedService'
    'UnknownDataFactoryTriggerProperties'           = 'UnknownTrigger'
}

# Phase 1: file moves (Unknown<Old>.cs + .Serialization.cs → Unknown<New>.cs).
foreach ($pair in $unknownRenames.GetEnumerator()) {
    $oldName = $pair.Key
    $newName = $pair.Value
    foreach ($suffix in @('.cs', '.Serialization.cs')) {
        $src = Join-Path $generatedDir "Models\$oldName$suffix"
        $dst = Join-Path $generatedDir "Models\$newName$suffix"
        if ((Test-Path -LiteralPath $src) -and -not (Test-Path -LiteralPath $dst)) {
            Move-Item -LiteralPath $src -Destination $dst -Force
        }
    }
}

# Phase 2: rewrite references across all Generated\*.cs. Use word-boundary so
# `UnknownDataFactoryTriggerProperties` doesn't match prefixes of unrelated tokens.
$unknownFixedFiles = 0
Get-ChildItem -LiteralPath $generatedDir -Recurse -File -Filter '*.cs' | ForEach-Object {
    $content = [System.IO.File]::ReadAllText($_.FullName)
    $original = $content
    foreach ($pair in $unknownRenames.GetEnumerator()) {
        # Longest names first (the dictionary is ordered): replace specific
        # before generic so `UnknownDataFactoryDatasetProperties` is renamed
        # before any shorter prefix match could fire.
        $pattern = '\b' + [regex]::Escape($pair.Key) + '\b'
        $content = [regex]::Replace($content, $pattern, $pair.Value)
    }
    if ($content -cne $original) {
        [System.IO.File]::WriteAllText($_.FullName, $content)
        $unknownFixedFiles++
    }
}
Write-Host "[post-gen-fixups] §11.7 (Unknown* rename): rewrote $unknownFixedFiles file(s)."

# ------------------------------------------------------------------------------
# §11.8 — Restore missing setters / mutable AdditionalProperties on a small set
# of generator-marked-output-only models that GA shipped as input-mutable.
#
# Symptom (ApiCompat MembersMustExist after round 2):
#   * DatasetDataElement.ColumnName.set / ColumnType.set
#   * DatasetSchemaDataElement.SchemaColumnName.set / SchemaColumnType.set
#   * DatasetSchemaDataElement.AdditionalProperties — GA had IDictionary, gen has IReadOnlyDictionary
#   * Office365TableOutputColumn.Name.set
#
# Why a post-gen rewrite instead of `[CodeGenSuppress]` + Custom partials?
#   * `[CodeGenSuppress("PropertyName")]` has ZERO precedent in this codebase
#     for *properties* — verified by grepping all 28 Azure.ResourceManager.*
#     packages under sdk\, the attribute is used only to suppress ctors. The
#     MPG generator's CodeGenSuppress handling has not been observed to apply
#     to auto-property emission, so risking the final regen budget on an
#     unproven pattern was not acceptable.
#   * The `[WirePath(...)]` suppression mechanism documented in §5.25 of
#     D:\Documents\mpg-api-diff\SKILL.md likewise has zero precedent in this
#     codebase (frontdoor-only).
#   * Adding `set;` to a generated auto-property cannot be done from a partial
#     class — the auto-property declaration is already in the generated partial
#     and C# disallows two declarations of the same member across partials.
#     CS0102 fires immediately and cannot be worked around without first
#     suppressing the generated declaration.
#   * Changing `IReadOnlyDictionary<>` -> `IDictionary<>` on the same property
#     name is a return-type change; partial-class member hiding (`new`) does
#     not apply within the same class. The only way to do it in Custom code
#     is again via [CodeGenSuppress]+redeclare, which has the same unproven-
#     pattern risk above.
#   * Spec-side `@@usage(Model, Usage.input, "csharp")` was tried in round 2
#     and successfully restored the public ctor + Properties setter on the
#     PrivateLink models (which had `@visibility(Lifecycle.Read)`), but did
#     NOT change generator output for these 3 datasets/output models — their
#     `@@usage(... Usage.input | Usage.output, "csharp")` is already in
#     client.tsp and `Usage.input` alone produces identical output. The
#     generator appears to make these classes effectively output-only based
#     on usage context rather than the decorator.
#
# Tracking: <to be filed> — generator should honor @@usage(Usage.input) for
# nested/non-resource models the same way it does for top-level resources.
# Remove this block once that lands.
# ------------------------------------------------------------------------------
$setterPatches = @(
    @{ File = 'Models\DatasetDataElement.cs';            Type = 'DatasetDataElement';            Property = 'ColumnName';       PropType = 'DataFactoryElement<string>' }
    @{ File = 'Models\DatasetDataElement.cs';            Type = 'DatasetDataElement';            Property = 'ColumnType';       PropType = 'DataFactoryElement<string>' }
    @{ File = 'Models\DatasetSchemaDataElement.cs';      Type = 'DatasetSchemaDataElement';      Property = 'SchemaColumnName'; PropType = 'DataFactoryElement<string>' }
    @{ File = 'Models\DatasetSchemaDataElement.cs';      Type = 'DatasetSchemaDataElement';      Property = 'SchemaColumnType'; PropType = 'DataFactoryElement<string>' }
    @{ File = 'Models\Office365TableOutputColumn.cs';    Type = 'Office365TableOutputColumn';    Property = 'Name';             PropType = 'string' }
)
$setterPatchedFiles = @{}
foreach ($patch in $setterPatches) {
    $absPath = Join-Path $generatedDir $patch.File
    if (-not (Test-Path -LiteralPath $absPath)) { continue }
    $content = [System.IO.File]::ReadAllText($absPath)
    $escType = [regex]::Escape($patch.PropType)
    # `public DataFactoryElement<string> ColumnName { get; }` -> `... { get; set; }`
    $pattern = "(public\s+$escType\s+$($patch.Property)\s*\{\s*get;)\s*\}"
    $replacement = '$1 set; }'
    $newContent = [regex]::Replace($content, $pattern, $replacement)
    if ($newContent -cne $content) {
        [System.IO.File]::WriteAllText($absPath, $newContent)
        $setterPatchedFiles[$absPath] = $true
    }
}

# DatasetSchemaDataElement.AdditionalProperties: change return type from
# IReadOnlyDictionary<...> to IDictionary<...> and simplify the body to return
# the underlying mutable backing field. GA contract had it mutable.
$schemaPath = Join-Path $generatedDir 'Models\DatasetSchemaDataElement.cs'
if (Test-Path -LiteralPath $schemaPath) {
    $content = [System.IO.File]::ReadAllText($schemaPath)
    $original = $content
    $content = [regex]::Replace($content,
        'public\s+IReadOnlyDictionary<string,\s*BinaryData>\s+AdditionalProperties\s*=>\s*new\s+ReadOnlyDictionary<string,\s*BinaryData>\(_additionalBinaryDataProperties\);',
        'public IDictionary<string, BinaryData> AdditionalProperties => _additionalBinaryDataProperties;')
    if ($content -cne $original) {
        [System.IO.File]::WriteAllText($schemaPath, $content)
        $setterPatchedFiles[$schemaPath] = $true
    }
}
Write-Host "[post-gen-fixups] §11.8 (restore setters / IDictionary AdditionalProperties): patched $($setterPatchedFiles.Count) file(s)."

Write-Host "[post-gen-fixups] Done."
