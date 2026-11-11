# Copyright (c) Microsoft Corporation. All rights reserved.
# Licensed under the MIT License.

# Serve captured history and oversized-patch pages over private MCP stdio and
# record nonce-bound delivery receipts. This backend has no GitHub token or listener.
# The trusted capture index provides canonical JavaScript hashes and required inputs.
$ErrorActionPreference = 'Stop'
[Console]::InputEncoding = [Text.UTF8Encoding]::new($false)
[Console]::OutputEncoding = [Text.UTF8Encoding]::new($false)
$utf8 = [Text.UTF8Encoding]::new($false)
if (-not $env:REVIEW_SNAPSHOT -or -not $env:REVIEW_RECEIPTS) { throw 'Missing private review-input configuration.' }
$snapshotText = [IO.File]::ReadAllText($env:REVIEW_SNAPSHOT, $utf8)
$snapshot = [System.Text.Json.JsonDocument]::Parse($snapshotText)
$inputDirectory = [IO.Path]::GetDirectoryName($env:REVIEW_SNAPSHOT)
$deliveryIndex = ConvertFrom-Json -InputObject ([IO.File]::ReadAllText([IO.Path]::Combine($inputDirectory, 'delivery-index.json'), $utf8)) -AsHashtable -NoEnumerate -DateKind String -Depth 100
$snapshotHash = $deliveryIndex.snapshot
$tool = [ordered]@{ name='read-review-input'; description='Deliver one page of an assigned captured thread history or oversized patch, with a trusted receipt.'; inputSchema=[ordered]@{ type='object'; properties=[ordered]@{ item=@{type='string'};nonce=@{type='string'};kind=@{type='string';enum=@('history','patch')};offset=@{type='integer'};limit=@{type='integer'} }; required=@('item','nonce','kind'); additionalProperties=$false } }
function Get-Property($element, [string]$name) {
    if ($element.ValueKind -ne [System.Text.Json.JsonValueKind]::Object) { return $null }
    $property = [System.Text.Json.JsonElement]::new()
    if (-not $element.TryGetProperty($name, [ref]$property)) { return $null }
    return $property
}
function Decode-JsString($element) {
    if ($null -eq $element -or $element.ValueKind -ne [System.Text.Json.JsonValueKind]::String) { throw 'Invalid captured string.' }
    # Decode the raw JSON string without replacing isolated UTF-16 surrogates.
    $raw = $element.GetRawText()
    return [regex]::Unescape($raw.Substring(1, $raw.Length - 2))
}
function Test-SafeInteger($value) {
    if ($value -isnot [byte] -and $value -isnot [int] -and $value -isnot [long] -and $value -isnot [double] -and $value -isnot [decimal]) { return $false }
    $n = [double]$value
    return -not [double]::IsInfinity($n) -and -not [double]::IsNaN($n) -and [Math]::Abs($n) -le 9007199254740991 -and [Math]::Floor($n) -eq $n
}
function Get-Digest([string]$value) {
    return [Convert]::ToHexString([Security.Cryptography.SHA256]::HashData($utf8.GetBytes($value))).ToLowerInvariant()
}
function Get-Page($arguments) {
    $item = $arguments.item; $nonce = $arguments.nonce; $kind = $arguments.kind
    $offset = 0; $limit = 4000
    if ($arguments.Contains('offset')) { $offset = $arguments['offset'] }
    if ($arguments.Contains('limit')) { $limit = $arguments['limit'] }
    if (-not (Test-SafeInteger $offset) -or $offset -lt 0 -or -not (Test-SafeInteger $limit) -or $limit -lt 1 -or $limit -gt 4000) { throw 'Invalid input page.' }
    $offset = [long]$offset; $limit = [long]$limit
    if ($item -isnot [string] -or $item -cnotmatch '\A(file|thread):(0|[1-9][0-9]*)\z') { throw 'Invalid delivery assignment.' }
    $category = $Matches[1]; $indexText = $Matches[2]; $index = 0
    if (-not [int]::TryParse($indexText, [ref]$index)) { throw 'Unknown delivery assignment.' }
    $root = $snapshot.RootElement
    $array = Get-Property $root $(if ($category -ceq 'thread') { 'threads' } else { 'files' })
    if ($null -eq $array -or $array.ValueKind -ne [System.Text.Json.JsonValueKind]::Array -or $index -ge $array.GetArrayLength()) { throw 'Unknown delivery assignment.' }
    $entry = $array[$index]
    if (-not $deliveryIndex.items.Contains($item)) { throw 'Missing captured delivery assignment.' }
    if ($kind -isnot [string]) { throw 'Input is not required for this assignment.' }
    $required = @($deliveryIndex.items[$item] | Where-Object { [StringComparer]::Ordinal.Equals($_.kind, $kind) })
    if ($required.Count -ne 1) { throw 'Input is not required for this assignment.' }
    $key = $required[0].key
    if ($category -ceq 'thread' -and [StringComparer]::Ordinal.Equals($kind, 'history')) {
        $content = [IO.File]::ReadAllText([IO.Path]::Combine($inputDirectory, "thread-$index.json"), $utf8)
    } elseif ($category -ceq 'file' -and [StringComparer]::Ordinal.Equals($kind, 'patch')) {
        $content = Decode-JsString (Get-Property $entry 'patch')
    } else { throw 'Input is not required for this assignment.' }
    if (-not [StringComparer]::Ordinal.Equals($key, ($kind + ':' + (Get-Digest $content)))) { throw 'Captured delivery content does not match its index.' }
    if ($offset -gt $content.Length) { throw 'Input is not required for this assignment.' }
    if ($nonce -isnot [string] -or $nonce -cnotmatch '\A[a-f0-9]{32}\z') { throw 'Invalid delivery nonce.' }
    $end = [Math]::Min($content.Length, $offset + $limit)
    $token = [Convert]::ToHexString([Security.Cryptography.RandomNumberGenerator]::GetBytes(32)).ToLowerInvariant()
    $row = [ordered]@{ snapshot=$snapshotHash;nonce=$nonce;item=$item;key=$key;start=$offset;end=$end;total=$content.Length;proof_hash=(Get-Digest $token) }
    $rowJson = ConvertTo-Json -InputObject $row -Depth 10 -Compress -EscapeHandling EscapeNonAscii
    [IO.File]::AppendAllText([IO.Path]::Combine($env:REVIEW_RECEIPTS, "$nonce.jsonl"), $rowJson + "`n", $utf8)
    return [ordered]@{ item=$item;kind=$kind;offset=$offset;total_characters=$content.Length;next_offset=$(if ($end -lt $content.Length) { $end } else { $null });content=$content.Substring([int]$offset, [int]($end - $offset));delivery_token=$token }
}
function Write-Result([string]$idJson, $result, [bool]$isError = $false) {
    if ($isError) { $response = [ordered]@{code=-32602;message=[string]$result} } else { $response = $result }
    $json = ConvertTo-Json -InputObject $response -Depth 50 -Compress -EscapeHandling EscapeNonAscii
    $key = if ($isError) { 'error' } else { 'result' }
    [Console]::Out.WriteLine('{"jsonrpc":"2.0","id":' + $idJson + ',"' + $key + '":' + $json + '}')
}
while ($null -ne ($line = [Console]::In.ReadLine())) {
    $document = $null; $idJson = 'null'
    try {
        if ($utf8.GetByteCount($line) -gt 65536) { throw 'MCP request exceeds the bounded input limit.' }
        $document = [System.Text.Json.JsonDocument]::Parse($line)
        if ($document.RootElement.ValueKind -eq [System.Text.Json.JsonValueKind]::Null) { throw 'Invalid JSON-RPC request.' }
        $id = Get-Property $document.RootElement 'id'
        if ($null -eq $id) { continue }
        $idJson = $id.GetRawText()
        $request = ConvertFrom-Json -InputObject $line -AsHashtable -NoEnumerate -DateKind String -Depth 100
        if ($request -isnot [System.Collections.IDictionary] -or $request.jsonrpc -isnot [string] -or -not [StringComparer]::Ordinal.Equals($request.jsonrpc, '2.0') -or $request.method -isnot [string]) { throw 'Invalid JSON-RPC request.' }
        switch -CaseSensitive ($request.method) {
            'initialize' { Write-Result $idJson ([ordered]@{protocolVersion='2024-11-05';capabilities=@{tools=@{}};serverInfo=@{name='review-input';version='1'}}); break }
            'ping' { Write-Result $idJson @{}; break }
            'tools/list' { Write-Result $idJson @{tools=@($tool)}; break }
            'tools/call' {
                if ($request.params -isnot [System.Collections.IDictionary] -or $request.params.name -isnot [string] -or -not [StringComparer]::Ordinal.Equals($request.params.name, 'read-review-input')) { throw 'Unsupported read-only MCP method or tool.' }
                $params = $request.params.arguments
                if ($null -eq $params) { $params = @{} }
                if ($params -isnot [System.Collections.IDictionary]) { throw 'Unsupported review input.' }
                foreach ($entry in $params.GetEnumerator()) { if ($entry.Key -cnotin @('item','nonce','kind','offset','limit')) { throw 'Unsupported review input.' } }
                $page = Get-Page $params
                $inner = ConvertTo-Json -InputObject $page -Depth 20 -Compress
                # Match JSON.stringify: keep valid Unicode readable, escape lone surrogates,
                # and undo Json.NET's extra escapes without changing literal backslashes.
                $inner = [regex]::Replace($inner, '[\uD800-\uDBFF](?![\uDC00-\uDFFF])|(?<![\uD800-\uDBFF])[\uDC00-\uDFFF]', [Text.RegularExpressions.MatchEvaluator]{ param($match) '\u{0:x4}' -f [int][char]$match.Value[0] })
                $inner = [regex]::Replace($inner, '(?<!\\)((?:\\\\)*)\\u(0085|2028|2029)', [Text.RegularExpressions.MatchEvaluator]{ param($match) $match.Groups[1].Value + [char][Convert]::ToInt32($match.Groups[2].Value, 16) })
                Write-Result $idJson @{content=@(@{type='text';text=$inner})}
                break
            }
            default { throw 'Unsupported read-only MCP method or tool.' }
        }
    } catch { Write-Result $idJson $_.Exception.Message $true }
    finally { if ($document) { $document.Dispose() } }
}
