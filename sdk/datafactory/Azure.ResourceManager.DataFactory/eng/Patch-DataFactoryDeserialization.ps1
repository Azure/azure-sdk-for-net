# Copyright (c) Microsoft Corporation. All rights reserved.
# Licensed under the MIT License.

# Post-generation patch for DataFactory MPG migration.
#
# The Azure C# MPG generator (http-client-csharp-mgmt) does not yet recognize
# `@alternateType({identity: "Azure.Core.Expressions.DataFactoryElement"})`
# (and the analogous DataFactoryLinkedServiceReference / DataFactorySecret / DataFactorySecretString
# external identities) as framework types that have a JsonConverter.
#
# As a result it emits `T.DeserializeT(jsonElement, options)` calls into
# every generated <Model>.Serialization.cs file. Those static methods do not exist
# on the external `Azure.Core.Expressions.DataFactory` types (they only expose
# a public JsonConverter), which causes thousands of CS0117 build errors.
#
# The four affected types all have `[JsonConverter(...)]`, so we can replace each
# broken call with `JsonSerializer.Deserialize<T>(prop.Value.GetRawText())`.
# This script is idempotent — re-running it on already-patched files is a no-op.
#
# Run after every regeneration until the upstream MPG generator gains native
# support for these alternate-typed external identities.

[CmdletBinding()]
param(
    [string] $GeneratedRoot = (Join-Path $PSScriptRoot '..\src\Generated')
)

$ErrorActionPreference = 'Stop'
$root = (Resolve-Path $GeneratedRoot).Path

$elementRegex = '(DataFactoryElement<(?:[^<>]|<[^<>]*>)*>)\.DeserializeDataFactoryElement\((?<arg>[^,)]+),\s*options\)'
$plainTypes = 'DataFactoryLinkedServiceReference','DataFactorySecret','DataFactorySecretString','DataFactoryKeyVaultSecret'

$filesPatched = 0
Get-ChildItem $root -Filter '*.Serialization.cs' -File -Recurse | ForEach-Object {
    $path = $_.FullName
    $text = [System.IO.File]::ReadAllText($path)
    $original = $text

    $text = [System.Text.RegularExpressions.Regex]::Replace(
        $text, $elementRegex,
        'JsonSerializer.Deserialize<$1>(${arg}.GetRawText())')

    foreach ($t in $plainTypes) {
        $regex = "($t)\.Deserialize$t\((?<arg>[^,)]+),\s*options\)"
        $text = [System.Text.RegularExpressions.Regex]::Replace(
            $text, $regex,
            'JsonSerializer.Deserialize<$1>(${arg}.GetRawText())')
    }

    # The generator-side patch can leave dangling namespace prefixes like
    # `Core.Expressions.DataFactory.JsonSerializer.Deserialize<DataFactorySecret>(...)`
    # because the original code used the fully-qualified type. Strip them.
    $text = $text -replace '\bCore\.Expressions\.DataFactory\.JsonSerializer\.Deserialize\b', 'JsonSerializer.Deserialize'
    $text = $text -replace '\bAzure\.Core\.Expressions\.DataFactory\.JsonSerializer\.Deserialize\b', 'JsonSerializer.Deserialize'

    # Disambiguate DataFactorySecret: there is a generated local Models.DataFactorySecret
    # (discriminated polymorphic root) AND the external Azure.Core.Expressions.DataFactory.DataFactorySecret.
    # The alternate-typed properties use the external one; the bare name resolves to the local one.
    $text = $text -replace 'JsonSerializer\.Deserialize<DataFactorySecret>', 'JsonSerializer.Deserialize<Azure.Core.Expressions.DataFactory.DataFactorySecret>'

    if ($text -ne $original) {
        $filesPatched++
        [System.IO.File]::WriteAllText($path, $text)
    }
}

# Normalize internal local variable naming: generator alternates between
# `additionalProperties` (declaration) and `additionalBinaryDataProperties` (usage).
# Pick the declaration's name for each file and rewrite mismatched usages.
Get-ChildItem $root -Filter '*.Serialization.cs' -File -Recurse | ForEach-Object {
    $path = $_.FullName
    $text = [System.IO.File]::ReadAllText($path)
    $original = $text
    $hasAP = $text -match 'IDictionary<string,\s*BinaryData>\s+additionalProperties\s*='
    $hasABDP = $text -match 'IDictionary<string,\s*BinaryData>\s+additionalBinaryDataProperties\s*='
    if ($hasAP -and -not $hasABDP) {
        $text = [System.Text.RegularExpressions.Regex]::Replace($text,
            '\badditionalBinaryDataProperties\b', 'additionalProperties')
    }
    if ($text -ne $original) {
        [System.IO.File]::WriteAllText($path, $text)
    }
}

# Patch the invalid IDictionary<string, BinaryData>.ToRequestContent(parameters) call emitted
# by the generator in DataFactoryPipelineResource.cs (PipelineResources_CreateRun body param).
# Redirect to the custom DataFactoryParameterDictionaryHelper.ToRequestContent helper.
$pipelineFile = Join-Path $root 'DataFactoryPipelineResource.cs'
if (Test-Path $pipelineFile) {
    $text = [System.IO.File]::ReadAllText($pipelineFile)
    $original = $text
    $text = $text -replace 'IDictionary<string,\s*BinaryData>\.ToRequestContent\(parameters\)',
        'DataFactoryParameterDictionaryHelper.ToRequestContent(parameters)'
    if ($text -ne $original) {
        [System.IO.File]::WriteAllText($pipelineFile, $text)
        Write-Host "Patched DataFactoryPipelineResource.cs (ToRequestContent helper redirect)."
    }
}

# Patch ArmDataFactoryModelFactory.cs: the factory methods expose ETag? eTag publicly but the
# underlying ctors take string eTag (spec models SubResource.etag: string). Convert via ToString().
$factoryFile = Join-Path $root 'ArmDataFactoryModelFactory.cs'
if (Test-Path $factoryFile) {
    $text = [System.IO.File]::ReadAllText($factoryFile)
    $original = $text
    # Match the two affected ctor invocations: positional `eTag` argument inside a
    # `new DataFactoryPrivate{Endpoint|Link}...(...)` block.
    $text = [System.Text.RegularExpressions.Regex]::Replace(
        $text,
        '(new\s+(?:DataFactoryPrivateEndpointConnectionCreateOrUpdateContent|DataFactoryPrivateLinkResource)\s*\(\s*id,\s*name,\s*default,\s*)eTag(,\s*additionalBinaryDataProperties)',
        '$1eTag?.ToString()$2')
    if ($text -ne $original) {
        [System.IO.File]::WriteAllText($factoryFile, $text)
        Write-Host "Patched ArmDataFactoryModelFactory.cs (ETag? -> string conversion)."
    }
}

Write-Host "Patched $filesPatched generated DataFactory serialization files."
