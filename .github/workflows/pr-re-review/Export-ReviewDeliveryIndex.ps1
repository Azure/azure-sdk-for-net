# Copyright (c) Microsoft Corporation. All rights reserved.
# Licensed under the MIT License.

# Build the trusted reader index from one compact JSON.stringify snapshot.
# Receipt verification independently recomputes these requirements later.
$ErrorActionPreference = 'Stop'
[Console]::InputEncoding = [Text.UTF8Encoding]::new($false, $true)
[Console]::OutputEncoding = [Text.UTF8Encoding]::new($false)
Import-Module (Join-Path $PSScriptRoot 'ReviewSerialization.psm1') -Force
try {
    $text = [Console]::In.ReadToEnd()
    $options = [System.Text.Json.JsonDocumentOptions]::new(); $options.MaxDepth = 10000
    $document = [System.Text.Json.JsonDocument]::Parse($text, $options)
    $root = $document.RootElement
    $snapshot = Get-JsonProperty $root 'snapshot'
    $limit = Get-JsonProperty $root 'maxBatchBytes'; $maxBatchBytes = [long]0
    if ($null -eq $snapshot -or $null -eq $limit -or $limit.ValueKind -ne [System.Text.Json.JsonValueKind]::Number -or
        -not $limit.TryGetInt64([ref]$maxBatchBytes) -or $maxBatchBytes -le 0) { throw 'Invalid delivery index input.' }
    $index = [ordered]@{ snapshot = Get-JsDigest ($snapshot.GetRawText()); items = [ordered]@{} }
    foreach ($mapping in @(@{ name='files'; category='file' }, @{ name='threads'; category='thread' })) {
        $entries = Get-JsonProperty $snapshot $mapping.name
        if ($null -eq $entries -or $entries.ValueKind -ne [System.Text.Json.JsonValueKind]::Array) { throw 'Invalid captured delivery assignments.' }
        $number = 0
        foreach ($entry in $entries.EnumerateArray()) {
            $itemJson = '{"' + $mapping.category + '":' + $entry.GetRawText() + '}'
            $item = [System.Text.Json.JsonDocument]::Parse($itemJson, $options)
            try {
                $requirements = [Collections.Generic.List[object]]::new()
                foreach ($req in (Get-JsRequiredInputs $item.RootElement $maxBatchBytes)) { $requirements.Add(@{ key=$req.key; kind=$req.kind }) }
                $index.items["$($mapping.category):$number"] = $requirements.ToArray()
            } finally { $item.Dispose() }
            $number++
        }
    }
    [Console]::Out.Write((ConvertTo-Json -InputObject $index -Depth 20 -Compress -EscapeHandling EscapeNonAscii))
    $document.Dispose()
} catch {
    [Console]::Error.WriteLine($_.Exception.Message)
    exit 1
}
