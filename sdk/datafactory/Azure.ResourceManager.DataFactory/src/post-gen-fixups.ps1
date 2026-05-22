# Mechanical post-generation fixups for known MPG generator bugs.
# Re-run after every `dotnet build /t:GenerateCode` for this package.
#
# Covers (per mpg-rules.md §11):
#   §11.1 DataFactoryElement<T>.DeserializeDataFactoryElement does not exist (#59298)
#   §11.2 DataFactoryLinkedServiceReference / DataFactorySecret / DataFactorySecretString Deserialize* do not exist
#   §11.3 additionalProperties vs additionalBinaryDataProperties variable-name mismatch
#   §11.4 IDictionary<string, BinaryData>.ToRequestContent(parameters) does not exist

param(
    [string]$PackageRoot
)

$ErrorActionPreference = 'Stop'

if (-not $PackageRoot) {
    $PackageRoot = Resolve-Path (Join-Path $PSScriptRoot '..')
}

$pkg = Resolve-Path $PackageRoot
$generatedModels = Join-Path $pkg 'src\Generated\Models'
$generatedRoot   = Join-Path $pkg 'src\Generated'

Write-Host "Post-gen fixups for $pkg"

$deserializeTargets = @(
    'DataFactoryElement',
    'DataFactoryLinkedServiceReference',
    'DataFactorySecret',
    'DataFactorySecretString'
)

foreach ($t in $deserializeTargets) {
    $scalarPattern = if ($t -eq 'DataFactoryElement') {
        "DataFactoryElement<[^=;]*?>\.DeserializeDataFactoryElement\(prop\.Value, options\)"
    } else {
        "$t\.Deserialize$t\(prop\.Value, options\)"
    }
    $arrayPattern = if ($t -eq 'DataFactoryElement') {
        "array\.Add\(DataFactoryElement<[^=;]*?>\.DeserializeDataFactoryElement\(item, options\)\);"
    } else {
        "array\.Add\($t\.Deserialize$t\(item, options\)\);"
    }

    $stubScalar = "default /* TODO(#59298): Deserialize* not implemented; stub until generator fix */"
    $stubArray  = "array.Add(default); /* TODO(#59298): Deserialize* not implemented; stub until generator fix */"

    $changed = 0
    foreach ($f in Get-ChildItem -Path $generatedModels -Filter '*.Serialization.cs' -Recurse -File) {
        $orig = [System.IO.File]::ReadAllText($f.FullName)
        $new  = [regex]::Replace($orig, $scalarPattern, $stubScalar)
        $new  = [regex]::Replace($new,  $arrayPattern,  $stubArray)
        if ($new -ne $orig) {
            [System.IO.File]::WriteAllText($f.FullName, $new)
            $changed++
        }
    }
    Write-Host "  §11.1/2 ${t}: updated $changed files"
}

$mismatchChanged = 0
foreach ($f in Get-ChildItem -Path $generatedModels -Filter '*.Serialization.cs' -Recurse -File) {
    $content = [System.IO.File]::ReadAllText($f.FullName)
    $declaresLong  = $content -match 'IDictionary<string, BinaryData>\s+additionalBinaryDataProperties\s*=\s*new ChangeTrackingDictionary'
    $declaresShort = $content -match 'IDictionary<string, BinaryData>\s+additionalProperties\s*=\s*new ChangeTrackingDictionary'
    $orig = $content
    if ($declaresLong -and -not $declaresShort) {
        $content = $content -replace '(?<![\w])additionalProperties\.Add\(prop\.Name', 'additionalBinaryDataProperties.Add(prop.Name'
    } elseif ($declaresShort -and -not $declaresLong) {
        $content = $content -replace '(?<![\w])additionalBinaryDataProperties\.Add\(prop\.Name', 'additionalProperties.Add(prop.Name'
    }
    if ($content -ne $orig) {
        [System.IO.File]::WriteAllText($f.FullName, $content)
        $mismatchChanged++
    }
}
Write-Host "  §11.3 additionalProperties name mismatch: updated $mismatchChanged files"

$dictHelperChanged = 0
foreach ($f in Get-ChildItem -Path $generatedRoot -Filter '*.cs' -Recurse -File) {
    $content = [System.IO.File]::ReadAllText($f.FullName)
    if ($content -notmatch 'IDictionary<string, BinaryData>\.ToRequestContent\(parameters\)') { continue }
    $new = $content -replace 'IDictionary<string, BinaryData>\.ToRequestContent\(parameters\)', 'DataFactoryParameterDictionaryHelper.ToRequestContent(parameters)'
    [System.IO.File]::WriteAllText($f.FullName, $new)
    $dictHelperChanged++
}
Write-Host "  §11.4 IDictionary.ToRequestContent(parameters): updated $dictHelperChanged files"

# ETag conversion fixups: generator emits 'string eTag' parameter then assigns to ETag? property,
# and serialization passes ETag? value to ctor expecting string. Change param type to ETag?.
# Also applies to ArmDataFactoryModelFactory mocking helpers that mirror the same signature.
$etagChanged = 0
$etagTargets = @(
    'src\Generated\Models\SubResource.cs',
    'src\Generated\Models\DataFactoryPrivateLinkResource.cs',
    'src\Generated\Models\DataFactoryPrivateEndpointConnectionCreateOrUpdateContent.cs',
    'src\Generated\ArmDataFactoryModelFactory.cs'
)
foreach ($rel in $etagTargets) {
    $path = Join-Path $pkg $rel
    if (-not (Test-Path $path)) { continue }
    $content = [System.IO.File]::ReadAllText($path)
    $orig = $content
    # Matches 'string eTag' as a parameter (followed by ',' / ')' / ' = default ...')
    $content = [regex]::Replace($content, '(?<![\w])string eTag(?=\s*(?:,|\)|=))', 'ETag? eTag')
    if ($content -ne $orig) {
        [System.IO.File]::WriteAllText($path, $content)
        $etagChanged++
    }
}
Write-Host "  ETag conversion: updated $etagChanged files"

# CustomActivityReferenceObject: 'using Azure.ResourceManager.DataFactory;' brings the
# REST-operations 'LinkedServices' partial class into scope, colliding with the 'LinkedServices'
# property assigned in the parameterless / internal ctors. The using is unnecessary because
# DataFactoryLinkedServiceReference and DatasetReference both live in the .Models namespace.
$carImportChanged = 0
foreach ($name in @('CustomActivityReferenceObject.cs', 'CustomActivityReferenceObject.Serialization.cs')) {
    $path = Join-Path $generatedModels $name
    if (-not (Test-Path $path)) { continue }
    $content = [System.IO.File]::ReadAllText($path)
    $orig = $content
    $content = $content -replace 'using Azure\.ResourceManager\.DataFactory;\r?\n', ''
    if ($content -ne $orig) {
        [System.IO.File]::WriteAllText($path, $content)
        $carImportChanged++
    }
}
Write-Host "  CustomActivityReferenceObject using removal: updated $carImportChanged files"

# ApiCompat back-compat fixups: regenerated MPG models drop public setters and parameterless
# ctors that the previously-shipped contract exposed. Add them back via in-place edits on the
# generated .cs files. Each rule below is keyed by the offending member name; the regex matches
# only the targeted file/property to keep blast radius small.
$setterChanged = 0

function Add-PropertySetter([string]$path, [string]$propPattern) {
    if (-not (Test-Path $path)) { return $false }
    $content = [System.IO.File]::ReadAllText($path)
    $orig = $content
    $content = [regex]::Replace($content, "(public\s+[\w<>?,\s]+?\s+$propPattern\s*\{\s*get;)\s*\}", '$1 set; }')
    if ($content -ne $orig) {
        [System.IO.File]::WriteAllText($path, $content)
        return $true
    }
    return $false
}

if (Add-PropertySetter (Join-Path $generatedModels 'DatasetDataElement.cs') 'ColumnName') { $setterChanged++ }
if (Add-PropertySetter (Join-Path $generatedModels 'DatasetDataElement.cs') 'ColumnType') { $setterChanged++ }
if (Add-PropertySetter (Join-Path $generatedModels 'DatasetSchemaDataElement.cs') 'SchemaColumnName') { $setterChanged++ }
if (Add-PropertySetter (Join-Path $generatedModels 'DatasetSchemaDataElement.cs') 'SchemaColumnType') { $setterChanged++ }
if (Add-PropertySetter (Join-Path $generatedModels 'Office365TableOutputColumn.cs') 'Name') { $setterChanged++ }
if (Add-PropertySetter (Join-Path $generatedModels 'DataFactoryPrivateLinkResource.cs') 'Properties') { $setterChanged++ }
Write-Host "  Property setter restore: updated $setterChanged properties"

# DatasetSchemaDataElement and DatasetDataElement: expose AdditionalProperties as IDictionary (matches contract).
$addlChanged = 0
foreach ($name in @('DatasetSchemaDataElement.cs', 'DatasetDataElement.cs')) {
    $path = Join-Path $generatedModels $name
    if (-not (Test-Path $path)) { continue }
    $content = [System.IO.File]::ReadAllText($path)
    $orig = $content
    $content = $content -replace 'public IReadOnlyDictionary<string, BinaryData> AdditionalProperties\s*=>\s*new ReadOnlyDictionary<string, BinaryData>\(_additionalBinaryDataProperties\);',
        'public IDictionary<string, BinaryData> AdditionalProperties => _additionalBinaryDataProperties;'
    if ($content -ne $orig) {
        [System.IO.File]::WriteAllText($path, $content)
        $addlChanged++
    }
}
Write-Host "  AdditionalProperties type restore: updated $addlChanged files"

# Generator emits 'UnknownXxxYyy' as <BaseType>'s PersistableModelProxy; previously shipped
# contract used 'UnknownZzz' (the spec's original type name before client.tsp @@clientName
# renames). Rename the discriminator-unknown classes + fixup the proxy attribute so binary
# deserialization still resolves the type.
$unknownRenames = [ordered]@{
    'UnknownPipelineActivity'                       = 'UnknownActivity'
    'UnknownCopyActivitySource'                     = 'UnknownCopySource'
    'UnknownDataFactoryCredential'                  = 'UnknownCredential'
    'UnknownDataFactoryDataFlowProperties'          = 'UnknownDataFlow'
    'UnknownDataFactoryDatasetProperties'           = 'UnknownDataset'
    'UnknownDataFactoryIntegrationRuntimeProperties'= 'UnknownIntegrationRuntime'
    'UnknownDataFactoryLinkedServiceProperties'     = 'UnknownLinkedService'
    'UnknownDataFactoryTriggerProperties'           = 'UnknownTrigger'
}

$unknownRenamed = 0
foreach ($from in $unknownRenames.Keys) {
    $to = $unknownRenames[$from]
    $fromMain = Join-Path $generatedModels "$from.cs"
    if (Test-Path $fromMain) {
        Move-Item $fromMain (Join-Path $generatedModels "$to.cs") -Force
        $unknownRenamed++
    }
    $fromSer = Join-Path $generatedModels "$from.Serialization.cs"
    if (Test-Path $fromSer) {
        Move-Item $fromSer (Join-Path $generatedModels "$to.Serialization.cs") -Force
        $unknownRenamed++
    }
}
# Recursively rewrite every reference inside generated/non-customized sources. Replace longer
# names first so we don't partially rewrite (e.g. UnknownDataFactoryDataFlowProperties before
# UnknownDataFactoryDataset...). Sort keys by length descending.
$sortedKeys = $unknownRenames.Keys | Sort-Object { $_.Length } -Descending
foreach ($f in Get-ChildItem -Path $pkg -Filter '*.cs' -Recurse -File) {
    if ($f.FullName -like '*\Customized*') { continue }
    $content = [System.IO.File]::ReadAllText($f.FullName)
    $orig = $content
    foreach ($from in $sortedKeys) {
        $content = $content -replace "\b$from\b", $unknownRenames[$from]
    }
    if ($content -ne $orig) {
        [System.IO.File]::WriteAllText($f.FullName, $content)
        $unknownRenamed++
    }
}
Write-Host "  Unknown* discriminator rename: touched $unknownRenamed files"

# Generator emits internal parameterless .ctor() on these two models, but the shipped contract
# requires a public parameterless ctor (model construction for paginated results and mocking).
# Flip the internal modifier to public.
$ctorPromoted = 0
foreach ($name in @('DataFactoryPrivateLinkResource.cs', 'DataFactoryPrivateLinkResourceProperties.cs')) {
    $path = Join-Path $generatedModels $name
    if (-not (Test-Path $path)) { continue }
    $typeName = [System.IO.Path]::GetFileNameWithoutExtension($name)
    $content = [System.IO.File]::ReadAllText($path)
    $pattern = "internal\s+$typeName\s*\(\s*\)"
    $replacement = "public $typeName()"
    $new = [regex]::Replace($content, $pattern, $replacement, 1)
    if ($new -ne $content) {
        [System.IO.File]::WriteAllText($path, $new)
        $ctorPromoted++
    }
}
Write-Host "  PrivateLink parameterless ctor promoted to public: $ctorPromoted files"

Write-Host "Post-gen fixups complete."
