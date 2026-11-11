# Copyright (c) Microsoft Corporation. All rights reserved.
# Licensed under the MIT License.

# Verify receipts against input requirements independently recomputed from the
# captured snapshot and assigned items. Lengths and offsets use JavaScript/UTF-16
# code units. The Node adapter supplies trusted compact JSON.stringify input.
$ErrorActionPreference = 'Stop'
[Console]::InputEncoding = [Text.UTF8Encoding]::new($false, $true)
[Console]::OutputEncoding = [Text.UTF8Encoding]::new($false)

function Test-SafeInteger($Value) {
    if ($Value -isnot [byte] -and $Value -isnot [int] -and $Value -isnot [long] -and $Value -isnot [double] -and $Value -isnot [decimal]) { return $false }
    $number = [double]$Value
    return -not [double]::IsInfinity($number) -and -not [double]::IsNaN($number) -and [Math]::Abs($number) -le 9007199254740991 -and [Math]::Floor($number) -eq $number
}

try {
    Import-Module (Join-Path $PSScriptRoot 'ReviewSerialization.psm1') -Force
    $text = [Console]::In.ReadToEnd()
    $options = [System.Text.Json.JsonDocumentOptions]::new(); $options.MaxDepth = 10000
    $document = [System.Text.Json.JsonDocument]::Parse($text, $options)
    $root = $document.RootElement
    $snapshot = Get-JsonProperty $root 'snapshot'
    $batch = Get-JsonProperty $root 'batch'
    $results = Get-JsonProperty $root 'results'
    $limit = Get-JsonProperty $root 'maxBatchBytes'; $maxBatchBytes = [long]0
    if ($null -eq $snapshot -or $null -eq $batch -or $batch.ValueKind -ne [System.Text.Json.JsonValueKind]::Array -or
        $null -eq $results -or $results.ValueKind -ne [System.Text.Json.JsonValueKind]::Array -or
        $null -eq $limit -or $limit.ValueKind -ne [System.Text.Json.JsonValueKind]::Number -or -not $limit.TryGetInt64([ref]$maxBatchBytes) -or $maxBatchBytes -le 0) { throw 'Invalid delivery evidence.' }
    $nonceElement = Get-JsonProperty $root 'nonce'
    $receiptElements = Get-JsonProperty $root 'receipts'
    if ($null -eq $nonceElement -or $nonceElement.ValueKind -ne [System.Text.Json.JsonValueKind]::String -or
        $null -eq $receiptElements -or $receiptElements.ValueKind -ne [System.Text.Json.JsonValueKind]::Array) { throw 'Invalid delivery evidence.' }
    $nonce = Get-JsString $nonceElement
    if ($nonce -cnotmatch '^[a-f0-9]{32}$') { throw 'Invalid delivery evidence.' }
    $inputData = @{
        receipts = ConvertFrom-Json -InputObject $receiptElements.GetRawText() -AsHashtable -NoEnumerate -Depth 10000
        snapshotHash = Get-JsDigest ($snapshot.GetRawText())
    }
    $completed = [Collections.Generic.Dictionary[string, object]]::new([StringComparer]::Ordinal)
    foreach ($result in $results.EnumerateArray()) {
        if ($result.ValueKind -eq [System.Text.Json.JsonValueKind]::Null) { throw 'Invalid delivery evidence.' }
        $status = Get-JsonProperty $result 'status'
        if ($null -eq $status -or $status.ValueKind -ne [System.Text.Json.JsonValueKind]::String -or -not [StringComparer]::Ordinal.Equals((Get-JsString $status), 'complete')) { continue }
        $id = Get-JsonProperty $result 'id'
        if ($null -eq $id -or $id.ValueKind -ne [System.Text.Json.JsonValueKind]::String) { throw 'Invalid delivery evidence.' }
        $completed[(Get-JsString $id)] = $result
    }
    $items = [Collections.Generic.List[object]]::new()
    foreach ($assignment in $batch.EnumerateArray()) {
        $id = Get-JsonProperty $assignment 'id'
        if ($null -eq $id -or $id.ValueKind -ne [System.Text.Json.JsonValueKind]::String) { throw 'Invalid delivery evidence.' }
        $id = Get-JsString $id
        if (-not $completed.ContainsKey($id)) { continue }
        $required = [Collections.Generic.List[object]]::new()
        foreach ($req in (Get-JsRequiredInputs $assignment $maxBatchBytes)) { $required.Add(@{ key=$req.key; expectedLength=$req.content.Length }) }
        $tokensElement = Get-JsonProperty $completed[$id] 'delivery_tokens'
        $tokens = if (Test-JsTruthy $tokensElement) { ConvertFrom-Json -InputObject $tokensElement.GetRawText() -AsHashtable -NoEnumerate -Depth 10000 } else { ,@() }
        $items.Add(@{ id=$id; required=$required.ToArray(); tokens=$tokens })
    }
    foreach ($item in $items) {
        $required = $item.required
        $tokens = $item.tokens
        if ($required.Count -gt 0 -and ($tokens -isnot [array] -or $tokens.Count -gt 8192)) { throw "Missing delivery acknowledgements for $($item.id)." }
        if ($tokens -isnot [array]) { throw "Invalid delivery acknowledgements for $($item.id)." }
        $proofs = [System.Collections.Generic.HashSet[string]]::new([StringComparer]::Ordinal)
        foreach ($token in $tokens) {
            if ($token -isnot [string] -or ($required.Count -gt 0 -and $token -cnotmatch '^[a-f0-9]{64}$')) { throw "Missing delivery acknowledgements for $($item.id)." }
            $proof = [Convert]::ToHexString([Security.Cryptography.SHA256]::HashData([Text.Encoding]::UTF8.GetBytes($token))).ToLowerInvariant()
            [void]$proofs.Add($proof)
        }
        foreach ($req in $required) {
            # PowerShell coerces operands during comparisons; require strings
            # explicitly so numeric values cannot match string identities.
            $records = @($inputData.receipts | Where-Object {
                $_ -is [System.Collections.IDictionary] -and
                $_.snapshot -is [string] -and [StringComparer]::Ordinal.Equals($_.snapshot, $inputData.snapshotHash) -and
                $_.nonce -is [string] -and [StringComparer]::Ordinal.Equals($_.nonce, $nonce) -and
                $_.item -is [string] -and [StringComparer]::Ordinal.Equals($_.item, $item.id) -and
                $_.key -is [string] -and [StringComparer]::Ordinal.Equals($_.key, $req.key) -and
                $_.proof_hash -is [string] -and $proofs.Contains($_.proof_hash)
            })
            if (-not $records.Count) { throw "Missing delivery evidence for $($item.id)." }
            $total = $records[0].total
            if (-not (Test-SafeInteger $total) -or $total -lt 0 -or ($null -ne $req.expectedLength -and $total -ne $req.expectedLength)) { throw "Invalid delivery ranges for $($item.id)." }
            foreach ($row in $records) {
                if (-not (Test-SafeInteger $row.total) -or $row.total -ne $total -or -not (Test-SafeInteger $row.start) -or -not (Test-SafeInteger $row.end) -or $row.start -lt 0 -or $row.end -lt $row.start -or $row.end -gt $total) { throw "Invalid delivery ranges for $($item.id)." }
            }
            $end = 0
            foreach ($row in ($records | Sort-Object -Property @{ Expression = { $_.start }; Ascending = $true }, @{ Expression = { $_.end }; Ascending = $false })) {
                if ($row.start -gt $end) { break }
                $end = [Math]::Max($end, $row.end)
            }
            if ($end -ne $total) { throw "Incomplete delivery evidence for $($item.id)." }
        }
    }
    [Console]::Out.Write('{}')
    $document.Dispose()
} catch {
    [Console]::Error.WriteLine($_.Exception.Message)
    exit 1
}
