#Requires -Version 7.3
# Copyright (c) Microsoft Corporation. All rights reserved.
# Licensed under the MIT License.

# Compare trusted captures using the compact JSON.stringify text supplied by
# the GitHub-script adapter. Array order and object property order are material.
$ErrorActionPreference = 'Stop'
[Console]::InputEncoding = [Text.UTF8Encoding]::new($false, $true)
[Console]::OutputEncoding = [Text.UTF8Encoding]::new($false)
Import-Module (Join-Path $PSScriptRoot 'ReviewSerialization.psm1') -Force

function Raw-Property($Element, [string] $Name) {
    $value = Get-JsonProperty $Element $Name
    if ($null -eq $value) { return $null }
    return $value.GetRawText()
}
function Same-Property($Left, $Right, [string] $Name) {
    return [StringComparer]::Ordinal.Equals((Raw-Property $Left $Name), (Raw-Property $Right $Name))
}
function Same-JsPrimitive($Left, $Right) {
    if ($null -eq $Left -or $null -eq $Right) { return $null -eq $Left -and $null -eq $Right }
    if ($Left.ValueKind -ne $Right.ValueKind) { return $false }
    if ($Left.ValueKind -in @([Text.Json.JsonValueKind]::Object, [Text.Json.JsonValueKind]::Array)) { return $false }
    return [StringComparer]::Ordinal.Equals($Left.GetRawText(), $Right.GetRawText())
}
function Get-JsPrimitiveKey($Value) {
    if ($null -eq $Value) { return 'undefined:' }
    if ($Value.ValueKind -in @([Text.Json.JsonValueKind]::Object, [Text.Json.JsonValueKind]::Array)) { return $null }
    return $Value.ValueKind.ToString() + ':' + $Value.GetRawText()
}
function Get-PositiveSafeInteger($Value) {
    if ($null -eq $Value -or $Value.ValueKind -ne [Text.Json.JsonValueKind]::Number) { return $null }
    $number = $Value.GetDouble()
    if ([double]::IsInfinity($number) -or [double]::IsNaN($number) -or $number -le 0 -or $number -gt 9007199254740991 -or [Math]::Floor($number) -ne $number) { return $null }
    return [long]$number
}
function Js-Literal([string] $Value) {
    return ConvertTo-JsJsonText (ConvertTo-Json -InputObject $Value -Compress)
}
# Fast path for the common case: every original comment is unchanged and
# applied replies are appended. Fall back for any ambiguous or reordered case.
function Test-AppendedReplies($Expected, $Actual, [Collections.Generic.HashSet[long]] $OwnIds, $Options) {
    $before = Get-JsonProperty $Expected 'comments'; $after = Get-JsonProperty $Actual 'comments'
    if ($null -eq $before -or $before.ValueKind -ne [Text.Json.JsonValueKind]::Array -or $before.GetArrayLength() -eq 0 -or
        $null -eq $after -or $after.ValueKind -ne [Text.Json.JsonValueKind]::Array) { return $null }
    $beforeRaw = $before.GetRawText(); $afterRaw = $after.GetRawText()
    foreach ($id in $OwnIds) {
        $needle = '"databaseId":' + $id.ToString([Globalization.CultureInfo]::InvariantCulture)
        if ($beforeRaw.Contains($needle + ',', [StringComparison]::Ordinal) -or $beforeRaw.Contains($needle + '}', [StringComparison]::Ordinal)) { return $null }
    }
    $beforeThread = $Expected.GetRawText(); $afterThread = $Actual.GetRawText()
    $beforeSuffix = '"comments":' + $beforeRaw + '}'; $afterSuffix = '"comments":' + $afterRaw + '}'
    if (-not $beforeThread.EndsWith($beforeSuffix, [StringComparison]::Ordinal) -or -not $afterThread.EndsWith($afterSuffix, [StringComparison]::Ordinal)) { return $null }
    $prefix = $beforeRaw.Substring(0, $beforeRaw.Length - 1) + ','
    if (-not $afterRaw.StartsWith($prefix, [StringComparison]::Ordinal)) { return $null }
    $tail = [Text.Json.JsonDocument]::Parse(('[' + $afterRaw.Substring($prefix.Length)), $Options)
    try {
        $visible = $false; $extra = $false
        foreach ($comment in $tail.RootElement.EnumerateArray()) {
            $id = Get-PositiveSafeInteger (Get-JsonProperty $comment 'databaseId')
            if ($null -ne $id -and $OwnIds.Contains($id)) { $visible = $true } else { $extra = $true }
        }
        $samePrefix = [StringComparer]::Ordinal.Equals($beforeThread.Substring(0, $beforeThread.Length - $beforeSuffix.Length), $afterThread.Substring(0, $afterThread.Length - $afterSuffix.Length))
        return @{ visible = $visible; matches = $samePrefix -and -not $extra }
    } finally { $tail.Dispose() }
}
function Without-AppliedReplies($Thread, [Collections.Generic.HashSet[long]] $OwnIds) {
    $builder = [Text.StringBuilder]::new('{'); $first = $true
    foreach ($property in $Thread.EnumerateObject()) {
        if (-not $first) { [void]$builder.Append(',') }; $first = $false
        [void]$builder.Append((Js-Literal $property.Name)).Append(':')
        if ([StringComparer]::Ordinal.Equals($property.Name, 'comments')) {
            [void]$builder.Append('['); $firstComment = $true
            foreach ($comment in $property.Value.EnumerateArray()) {
                $id = Get-PositiveSafeInteger (Get-JsonProperty $comment 'databaseId')
                if ($null -ne $id -and $OwnIds.Contains($id)) { continue }
                if (-not $firstComment) { [void]$builder.Append(',') }; $firstComment = $false
                [void]$builder.Append($comment.GetRawText())
            }
            [void]$builder.Append(']')
        } else { [void]$builder.Append($property.Value.GetRawText()) }
    }
    [void]$builder.Append('}')
    return $builder.ToString()
}
try {
    $options = [Text.Json.JsonDocumentOptions]::new(); $options.MaxDepth = 10000
    $document = [Text.Json.JsonDocument]::Parse([Console]::In.ReadToEnd(), $options)
    $root = $document.RootElement
    $mode = Get-JsString (Get-JsonProperty $root 'mode')
    $expected = Get-JsonProperty $root 'expected'
    $current = Get-JsonProperty $root 'current'
    if ($null -eq $expected -or $null -eq $current) { throw 'Invalid freshness input.' }
    if ([StringComparer]::Ordinal.Equals($mode, 'publication')) {
        if (-not (Same-Property $current $expected 'threads')) { throw 'Review thread state or history changed before publication.' }
        if (-not (Same-Property $current $expected 'reviews')) { throw 'Review history changed before publication.' }
        if (-not (Same-JsPrimitive (Get-JsonProperty $current 'head_repo') (Get-JsonProperty $expected 'head_repo')) -or
            -not (Same-JsPrimitive (Get-JsonProperty $current 'base_repo') (Get-JsonProperty $expected 'base_repo'))) { throw 'Source repository identity changed before publication.' }
    } elseif ([StringComparer]::Ordinal.Equals($mode, 'mutation')) {
        $expectedThreads = Get-JsonProperty $expected 'threads'; $currentThreads = Get-JsonProperty $current 'threads'
        $roots = Get-JsonProperty $root 'rootIds'; $receipts = Get-JsonProperty $root 'receipts'
        if ($null -eq $currentThreads -or $currentThreads.ValueKind -ne [Text.Json.JsonValueKind]::Array -or
            $null -eq $roots -or $roots.ValueKind -ne [Text.Json.JsonValueKind]::Array) { throw 'Invalid mutation freshness input.' }
        if ($roots.GetArrayLength() -gt 0 -and ($null -eq $expectedThreads -or $expectedThreads.ValueKind -ne [Text.Json.JsonValueKind]::Array -or
            $null -eq $receipts -or $receipts.ValueKind -ne [Text.Json.JsonValueKind]::Array)) { throw 'Invalid mutation freshness input.' }
        $expectedByRoot = [Collections.Generic.Dictionary[string, object]]::new([StringComparer]::Ordinal)
        $currentById = [Collections.Generic.Dictionary[string, object]]::new([StringComparer]::Ordinal)
        $receiptsByRoot = [Collections.Generic.Dictionary[string, object]]::new([StringComparer]::Ordinal)
        $expectedIndexValid = $true; $invalidReceipt = $false
        foreach ($thread in $currentThreads.EnumerateArray()) {
            if ($thread.ValueKind -eq [Text.Json.JsonValueKind]::Null) { throw 'Invalid current thread.' }
            $key = Get-JsPrimitiveKey (Get-JsonProperty $thread 'id')
            if ($null -ne $key) { $currentById[$key] = $thread }
        }
        if ($roots.GetArrayLength() -gt 0) {
            foreach ($thread in $expectedThreads.EnumerateArray()) {
                $comments = Get-JsonProperty $thread 'comments'
                if ($null -eq $comments -or $comments.ValueKind -ne [Text.Json.JsonValueKind]::Array -or $comments.GetArrayLength() -eq 0) { $expectedIndexValid = $false; break }
                $key = Get-JsPrimitiveKey (Get-JsonProperty $comments[0] 'databaseId')
                if ($null -ne $key -and -not $expectedByRoot.ContainsKey($key)) { $expectedByRoot[$key] = $thread }
            }
            foreach ($receipt in $receipts.EnumerateArray()) {
                if ($receipt.ValueKind -eq [Text.Json.JsonValueKind]::Null) { $invalidReceipt = $true; break }
                $type = Get-JsonProperty $receipt 'type'; $provider = Get-JsonProperty $receipt 'provider'
                if ($null -eq $type -or $type.ValueKind -ne [Text.Json.JsonValueKind]::String -or -not [StringComparer]::Ordinal.Equals((Get-JsString $type), 'reply_to_pull_request_review_comment') -or
                    $null -eq $provider -or $provider.ValueKind -ne [Text.Json.JsonValueKind]::String -or -not [StringComparer]::Ordinal.Equals((Get-JsString $provider), 'github')) { continue }
                $key = Get-JsPrimitiveKey (Get-JsonProperty $receipt 'id')
                $replyId = Get-PositiveSafeInteger (Get-JsonProperty (Get-JsonProperty $receipt 'metadata') 'reply_id')
                if ($null -ne $key -and $null -ne $replyId) {
                    if (-not $receiptsByRoot.ContainsKey($key)) { $receiptsByRoot[$key] = [Collections.Generic.HashSet[long]]::new() }
                    [void]$receiptsByRoot[$key].Add($replyId)
                }
            }
        }
        foreach ($rootId in $roots.EnumerateArray()) {
            $rootKey = Get-JsPrimitiveKey $rootId; $expectedThread = $null
            if ($expectedIndexValid) {
                if ($null -ne $rootKey -and $expectedByRoot.ContainsKey($rootKey)) { $expectedThread = $expectedByRoot[$rootKey] }
            } else {
                foreach ($thread in $expectedThreads.EnumerateArray()) {
                    $comments = Get-JsonProperty $thread 'comments'
                    if ($null -eq $comments -or $comments.ValueKind -ne [Text.Json.JsonValueKind]::Array -or $comments.GetArrayLength() -eq 0) { throw 'Invalid captured thread.' }
                    if (Same-JsPrimitive (Get-JsonProperty $comments[0] 'databaseId') $rootId) { $expectedThread = $thread; break }
                }
            }
            $actualThread = $null
            if ($null -ne $expectedThread) {
                $key = Get-JsPrimitiveKey (Get-JsonProperty $expectedThread 'id')
                if ($null -ne $key -and $currentById.ContainsKey($key)) { $actualThread = $currentById[$key] }
            }
            if ($invalidReceipt) { throw 'Invalid mutation receipt.' }
            $ownIds = if ($null -ne $rootKey -and $receiptsByRoot.ContainsKey($rootKey)) { ,$receiptsByRoot[$rootKey] } else { ,([Collections.Generic.HashSet[long]]::new()) }
            if ($ownIds.Count -eq 0) { throw "Missing applied reply identity for thread root $($rootId.GetRawText())." }
            if ($null -eq $actualThread) { throw "Captured thread $($rootId.GetRawText()) is no longer available." }
            $fast = Test-AppendedReplies $expectedThread $actualThread $ownIds $options
            if ($null -ne $fast) {
                if (-not $fast.visible) { throw "Applied reply for $($rootId.GetRawText()) is no longer visible." }
                if (-not $fast.matches) { throw "Thread $($rootId.GetRawText()) changed after publication; refusing stale mutation." }
                continue
            }
            $comments = Get-JsonProperty $actualThread 'comments'; $visible = $false
            if ($null -eq $comments -or $comments.ValueKind -ne [Text.Json.JsonValueKind]::Array) { throw 'Invalid captured thread.' }
            foreach ($comment in $comments.EnumerateArray()) {
                $id = Get-PositiveSafeInteger (Get-JsonProperty $comment 'databaseId')
                if ($null -ne $id -and $ownIds.Contains($id)) { $visible = $true; break }
            }
            if (-not $visible) { throw "Applied reply for $($rootId.GetRawText()) is no longer visible." }
            if (-not [StringComparer]::Ordinal.Equals((Without-AppliedReplies $actualThread $ownIds), $expectedThread.GetRawText())) { throw "Thread $($rootId.GetRawText()) changed after publication; refusing stale mutation." }
        }
    } else { throw 'Invalid freshness mode.' }
    [Console]::Out.Write('{}')
    $document.Dispose()
} catch { [Console]::Error.WriteLine($_.Exception.Message); exit 1 }
