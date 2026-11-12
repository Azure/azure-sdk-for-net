#Requires -Version 7.3
# Copyright (c) Microsoft Corporation. All rights reserved.
# Licensed under the MIT License.

# Select a bounded batch from trusted compact JSON.stringify input. Thread
# grouping and byte counts must match the Node controller's prior behavior.
param([switch] $Stream)
$ErrorActionPreference = 'Stop'
[Console]::InputEncoding = [Text.UTF8Encoding]::new($false, $true)
[Console]::OutputEncoding = [Text.UTF8Encoding]::new($false)
Import-Module (Join-Path $PSScriptRoot 'ReviewSerialization.psm1') -Force
$options = [Text.Json.JsonDocumentOptions]::new(); $options.MaxDepth = 10000
function Select-Batch([string] $Text) {
    $document = [Text.Json.JsonDocument]::Parse($Text, $options)
    try {
        $root = $document.RootElement
        $work = Get-JsonProperty $root 'work'; $itemLimit = Get-JsonProperty $root 'maxItems'; $byteLimit = Get-JsonProperty $root 'maxBytes'
        $maxItems = [long]0; $maxBytes = [long]0
        if ($null -eq $work -or $work.ValueKind -ne [Text.Json.JsonValueKind]::Array -or
            $null -eq $itemLimit -or $itemLimit.ValueKind -ne [Text.Json.JsonValueKind]::Number -or -not $itemLimit.TryGetInt64([ref]$maxItems) -or $maxItems -le 0 -or
            $null -eq $byteLimit -or $byteLimit.ValueKind -ne [Text.Json.JsonValueKind]::Number -or -not $byteLimit.TryGetInt64([ref]$maxBytes) -or $maxBytes -le 0) { throw 'Invalid batch selection input.' }
        $count = Select-JsReviewBatch $work $maxItems $maxBytes
        if ($Stream) {
            $idElement = Get-JsonProperty $root 'id'; $id = [long]0
            if ($null -eq $idElement -or $idElement.ValueKind -ne [Text.Json.JsonValueKind]::Number -or -not $idElement.TryGetInt64([ref]$id) -or $id -le 0 -or $id -gt 9007199254740991) { throw 'Invalid batch request identity.' }
            return '{"id":' + $id + ',"count":' + $count + '}'
        }
        return '{"count":' + $count + '}'
    } finally { $document.Dispose() }
}
try {
    if ($Stream) {
        while ($null -ne ($line = [Console]::In.ReadLine())) { [Console]::Out.WriteLine((Select-Batch $line)) }
    } else { [Console]::Out.Write((Select-Batch ([Console]::In.ReadToEnd()))) }
} catch { [Console]::Error.WriteLine($_.Exception.Message); exit 1 }
