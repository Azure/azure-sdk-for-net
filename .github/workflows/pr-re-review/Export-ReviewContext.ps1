# Copyright (c) Microsoft Corporation. All rights reserved.
# Licensed under the MIT License.

# Export trusted review context from compact JSON.stringify input. Receipt
# verification independently recomputes required inputs from the snapshot.
$ErrorActionPreference = 'Stop'
[Console]::InputEncoding = [Text.UTF8Encoding]::new($false, $true)
[Console]::OutputEncoding = [Text.UTF8Encoding]::new($false)
$utf8 = [Text.UTF8Encoding]::new($false)
Import-Module (Join-Path $PSScriptRoot 'ReviewSerialization.psm1') -Force

function Get-JsLiteral([string] $Value) {
    return ConvertTo-JsJsonText (ConvertTo-Json -InputObject $Value -Compress)
}
function Add-JsonProperty([Text.StringBuilder] $Builder, [string] $Name, $Value) {
    if ($null -eq $Value) { return }
    if ($Builder.Length -gt 1) { [void]$Builder.Append(',') }
    [void]$Builder.Append((Get-JsLiteral $Name)).Append(':').Append($Value.GetRawText())
}
function Add-JsonLiteral([Text.StringBuilder] $Builder, [string] $Name, [string] $Value) {
    if ($Builder.Length -gt 1) { [void]$Builder.Append(',') }
    [void]$Builder.Append((Get-JsLiteral $Name)).Append(':').Append((Get-JsLiteral $Value))
}
function Write-ContextFile([string] $Path, [string] $Content) {
    $options = [IO.FileStreamOptions]::new()
    $options.Mode = [IO.FileMode]::Create; $options.Access = [IO.FileAccess]::Write
    if (-not [OperatingSystem]::IsWindows()) {
        $options.UnixCreateMode = [IO.UnixFileMode]::UserRead -bor [IO.UnixFileMode]::UserWrite -bor [IO.UnixFileMode]::GroupRead -bor [IO.UnixFileMode]::OtherRead
    }
    $stream = [IO.File]::Open($Path, $options)
    try { $bytes = $utf8.GetBytes($Content); $stream.Write($bytes, 0, $bytes.Length) } finally { $stream.Dispose() }
}
function Write-PrettyJson([string] $Path, [string] $Json, $Options) {
    $parsed = [Text.Json.JsonDocument]::Parse($Json, $Options)
    try { Write-ContextFile $Path (Format-JsPrettyJson $parsed.RootElement) } finally { $parsed.Dispose() }
}

try {
    $text = [Console]::In.ReadToEnd()
    $options = [Text.Json.JsonDocumentOptions]::new(); $options.MaxDepth = 10000
    $document = [Text.Json.JsonDocument]::Parse($text, $options)
    $root = $document.RootElement
    $snapshot = Get-JsonProperty $root 'snapshot'
    $limit = Get-JsonProperty $root 'maxBatchBytes'; $maxBatchBytes = [long]0
    $directory = Get-JsString (Get-JsonProperty $root 'directory')
    $prefix = Get-JsString (Get-JsonProperty $root 'pathPrefix')
    if ($null -eq $snapshot -or $null -eq $limit -or $limit.ValueKind -ne [Text.Json.JsonValueKind]::Number -or
        -not $limit.TryGetInt64([ref]$maxBatchBytes) -or $maxBatchBytes -le 0) { throw 'Invalid delivery index input.' }
    [void][IO.Directory]::CreateDirectory($directory)
    $delivery = [ordered]@{ snapshot = Get-JsDigest ($snapshot.GetRawText()); items = [ordered]@{} }
    $files = Get-JsonProperty $snapshot 'files'; $threads = Get-JsonProperty $snapshot 'threads'; $reviews = Get-JsonProperty $snapshot 'reviews'
    if ($null -eq $files -or $files.ValueKind -ne [Text.Json.JsonValueKind]::Array -or $null -eq $threads -or $threads.ValueKind -ne [Text.Json.JsonValueKind]::Array -or
        ((Test-JsTruthy $reviews) -and $reviews.ValueKind -ne [Text.Json.JsonValueKind]::Array)) { throw 'Invalid captured delivery assignments.' }
    foreach ($mapping in @(@{category='file'; entries=$files}, @{category='thread'; entries=$threads})) {
        $number = 0
        foreach ($entry in $mapping.entries.EnumerateArray()) {
            $item = [Text.Json.JsonDocument]::Parse(('{"' + $mapping.category + '":' + $entry.GetRawText() + '}'), $options)
            try {
                $required = [Collections.Generic.List[object]]::new()
                foreach ($req in (Get-JsRequiredInputs $item.RootElement $maxBatchBytes)) { $required.Add(@{key=$req.key;kind=$req.kind}) }
                $delivery.items["$($mapping.category):$number"] = $required.ToArray()
            } finally { $item.Dispose() }
            $number++
        }
    }
    Write-ContextFile ([IO.Path]::Combine($directory, 'snapshot.json')) (Format-JsPrettyJson $snapshot)
    $mappedFiles = [Collections.Generic.List[string]]::new()
    $number = 0
    foreach ($entry in $files.EnumerateArray()) {
        $builder = [Text.StringBuilder]::new('{')
        Add-JsonLiteral $builder 'id' "file:$number"
        foreach ($name in @('filename','status','previous_filename')) { Add-JsonProperty $builder $name (Get-JsonProperty $entry $name) }
        $patch = Get-JsonProperty $entry 'patch'
        if ($null -ne $patch) {
            Write-ContextFile ([IO.Path]::Combine($directory, "file-$number.patch")) (Get-JsString $patch)
            Add-JsonLiteral $builder 'patch_path' ($prefix + "file-$number.patch")
        } else { [void]$builder.Append(',"patch_path":null') }
        [void]$builder.Append('}'); $mappedFiles.Add($builder.ToString()); $number++
    }
    $mappedThreads = [Collections.Generic.List[string]]::new(); $number = 0
    foreach ($entry in $threads.EnumerateArray()) {
        Write-ContextFile ([IO.Path]::Combine($directory, "thread-$number.json")) (Format-JsPrettyJson $entry)
        $builder = [Text.StringBuilder]::new('{')
        Add-JsonLiteral $builder 'id' "thread:$number"
        Add-JsonProperty $builder 'thread_id' (Get-JsonProperty $entry 'id')
        Add-JsonProperty $builder 'isResolved' (Get-JsonProperty $entry 'isResolved')
        $comments = Get-JsonProperty $entry 'comments'
        if ($null -eq $comments -or $comments.ValueKind -ne [Text.Json.JsonValueKind]::Array -or $comments.GetArrayLength() -eq 0 -or $comments[0].ValueKind -eq [Text.Json.JsonValueKind]::Null) { throw 'Invalid captured thread comments.' }
        Add-JsonProperty $builder 'path' (Get-JsonProperty $comments[0] 'path')
        Add-JsonLiteral $builder 'history_path' ($prefix + "thread-$number.json")
        [void]$builder.Append('}'); $mappedThreads.Add($builder.ToString()); $number++
    }
    $mappedReviews = [Collections.Generic.List[string]]::new(); $number = 0
    if (Test-JsTruthy $reviews) {
        foreach ($entry in $reviews.EnumerateArray()) {
            if ($entry.ValueKind -eq [Text.Json.JsonValueKind]::Null) { throw 'Invalid captured review.' }
            Write-ContextFile ([IO.Path]::Combine($directory, "review-$number.json")) (Format-JsPrettyJson $entry)
            $builder = [Text.StringBuilder]::new('{')
            Add-JsonProperty $builder 'id' (Get-JsonProperty $entry 'id')
            Add-JsonProperty $builder 'state' (Get-JsonProperty $entry 'state')
            Add-JsonLiteral $builder 'history_path' ($prefix + "review-$number.json")
            [void]$builder.Append('}'); $mappedReviews.Add($builder.ToString()); $number++
        }
    }
    $builder = [Text.StringBuilder]::new('{')
    foreach ($name in @('head_sha','base_sha','diff_base_sha')) { Add-JsonProperty $builder $name (Get-JsonProperty $snapshot $name) }
    foreach ($entry in @(@{name='files'; values=$mappedFiles}, @{name='threads'; values=$mappedThreads}, @{name='reviews'; values=$mappedReviews})) {
        if ($builder.Length -gt 1) { [void]$builder.Append(',') }
        [void]$builder.Append((Get-JsLiteral $entry.name)).Append(':[').Append(($entry.values -join ',')).Append(']')
    }
    [void]$builder.Append('}')
    Write-PrettyJson ([IO.Path]::Combine($directory, 'index.json')) $builder.ToString() $options
    $deliveryJson = ConvertTo-Json -InputObject $delivery -Depth 20 -Compress -EscapeHandling EscapeNonAscii
    Write-PrettyJson ([IO.Path]::Combine($directory, 'delivery-index.json')) $deliveryJson $options
    [Console]::Out.Write($deliveryJson)
    $document.Dispose()
} catch {
    [Console]::Error.WriteLine($_.Exception.Message)
    exit 1
}
