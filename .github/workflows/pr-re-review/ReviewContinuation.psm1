# Copyright (c) Microsoft Corporation. All rights reserved.
# Licensed under the MIT License.

# Pure continuation policy. Inputs must use trusted compact JSON.stringify
# encoding, never the pretty-printed exported snapshot. The Node adapter supplies
# its canonical snapshot hash; state initialization rejects representation drift.
# The streaming host owns JsonDocument lifetimes. This module does not read
# checkpoints, call GitHub, or start processes.
Import-Module (Join-Path $PSScriptRoot 'ReviewSerialization.psm1') -Scope Local
$script:Ordinal = [StringComparer]::Ordinal
$script:JsNonWhitespace = [regex]::new('[^\u0009-\u000d\u0020\u00a0\u1680\u2000-\u200a\u2028\u2029\u202f\u205f\u3000\ufeff]', [Text.RegularExpressions.RegexOptions]::CultureInvariant)

function Test-ContinuationText($Value) {
    return $null -ne $Value -and $Value.ValueKind -eq [Text.Json.JsonValueKind]::String -and $script:JsNonWhitespace.IsMatch((Get-JsString $Value))
}
function Test-ContinuationString($Value, [string[]] $Allowed) {
    if ($null -eq $Value -or $Value.ValueKind -ne [Text.Json.JsonValueKind]::String) { return $false }
    $text = Get-JsString $Value
    foreach ($candidate in $Allowed) { if ($script:Ordinal.Equals($text, $candidate)) { return $true } }
    return $false
}
function Test-ContinuationPositiveInteger($Value) {
    if ($null -eq $Value -or $Value.ValueKind -ne [Text.Json.JsonValueKind]::Number) { return $false }
    $number = $Value.GetDouble()
    return -not [double]::IsInfinity($number) -and -not [double]::IsNaN($number) -and $number -gt 0 -and $number -le 9007199254740991 -and [Math]::Floor($number) -eq $number
}
function Test-ContinuationSha($Value) {
    return $null -ne $Value -and $Value.ValueKind -eq [Text.Json.JsonValueKind]::String -and [regex]::IsMatch((Get-JsString $Value), '\A[a-fA-F0-9]{40}\z', [Text.RegularExpressions.RegexOptions]::CultureInvariant)
}
function New-ContinuationWorklist($Snapshot) {
    $files = Get-JsonProperty $Snapshot 'files'; $threads = Get-JsonProperty $Snapshot 'threads'
    $changed = Get-JsonProperty $Snapshot 'changed_files'
    if ($null -eq $files -or $files.ValueKind -ne [Text.Json.JsonValueKind]::Array -or $null -eq $threads -or $threads.ValueKind -ne [Text.Json.JsonValueKind]::Array -or
        -not (Test-ContinuationSha (Get-JsonProperty $Snapshot 'head_sha')) -or -not (Test-ContinuationSha (Get-JsonProperty $Snapshot 'base_sha')) -or
        -not (Test-ContinuationPositiveInteger (Get-JsonProperty $Snapshot 'pull_number')) -or $null -eq $changed -or $changed.ValueKind -ne [Text.Json.JsonValueKind]::Number -or
        $changed.GetDouble() -ne $files.GetArrayLength()) { throw 'Invalid review snapshot identity or file count.' }
    $fileItems = [Collections.Generic.List[object]]::new(); $threadItems = [Collections.Generic.List[object]]::new()
    $names = [Collections.Generic.HashSet[string]]::new($script:Ordinal); $ids = [Collections.Generic.HashSet[string]]::new($script:Ordinal)
    $index = 0
    foreach ($file in $files.EnumerateArray()) {
        $filename = Get-JsonProperty $file 'filename'
        if (-not (Test-ContinuationText $filename) -or -not $names.Add((Get-JsString $filename))) { throw 'Invalid or duplicate changed filename.' }
        $id = "file:$index"
        $fileItems.Add([pscustomobject]@{ Id=$id; Kind='file'; Value=$file; Json=('{"id":"' + $id + '","file":' + $file.GetRawText() + '}') })
        $index++
    }
    $index = 0
    foreach ($thread in $threads.EnumerateArray()) {
        $idElement = Get-JsonProperty $thread 'id'; $resolved = Get-JsonProperty $thread 'isResolved'; $comments = Get-JsonProperty $thread 'comments'
        if (-not (Test-ContinuationText $idElement) -or -not $ids.Add((Get-JsString $idElement)) -or $null -eq $resolved -or $resolved.ValueKind -notin @([Text.Json.JsonValueKind]::True,[Text.Json.JsonValueKind]::False) -or
            $null -eq $comments -or $comments.ValueKind -ne [Text.Json.JsonValueKind]::Array -or $comments.GetArrayLength() -eq 0 -or
            -not (Test-ContinuationPositiveInteger (Get-JsonProperty $comments[0] 'databaseId'))) { throw 'Invalid, incomplete or duplicate review thread.' }
        $id = "thread:$index"
        $threadItems.Add([pscustomobject]@{ Id=$id; Kind='thread'; Value=$thread; Json=('{"id":"' + $id + '","thread":' + $thread.GetRawText() + '}') })
        $index++
    }
    return ,@($threadItems.ToArray() + $fileItems.ToArray())
}
function ConvertTo-ContinuationResults([AllowEmptyCollection()][object[]] $Batch, $Response) {
    $results = Get-JsonProperty $Response 'results'
    if ($null -eq $results -or $results.ValueKind -ne [Text.Json.JsonValueKind]::Array) { throw 'Invalid worker result.' }
    $assigned = [Collections.Generic.Dictionary[string, object]]::new($script:Ordinal)
    foreach ($item in $Batch) { $assigned[$item.Id] = $item }
    $seen = [Collections.Generic.HashSet[string]]::new($script:Ordinal); $accepted = [Collections.Generic.List[object]]::new()
    foreach ($result in $results.EnumerateArray()) {
        $idElement = Get-JsonProperty $result 'id'
        if ($null -eq $idElement -or $idElement.ValueKind -ne [Text.Json.JsonValueKind]::String) { throw 'Unassigned or duplicate worker result.' }
        $id = Get-JsString $idElement
        if (-not $assigned.ContainsKey($id) -or -not $seen.Add($id)) { throw 'Unassigned or duplicate worker result.' }
        $status = Get-JsonProperty $result 'status'
        if (-not (Test-ContinuationString $status @('complete'))) {
            if (-not (Test-ContinuationString $status @('pending','blocked'))) { throw 'Invalid worker status.' }
            continue
        }
        $reason = Get-JsonProperty $result 'reasoning'; $findings = Get-JsonProperty $result 'findings'; $action = Get-JsonProperty $result 'action'; $reply = Get-JsonProperty $result 'reply'
        if (-not (Test-ContinuationText $reason) -or $null -eq $findings -or $findings.ValueKind -ne [Text.Json.JsonValueKind]::Array -or
            -not (Test-ContinuationString $action @('none','resolve','reopen'))) { throw 'Invalid worker completion or missing reasoning.' }
        $item = $assigned[$id]; $actionText = Get-JsString $action
        if ($script:Ordinal.Equals($item.Kind, 'file') -and -not $script:Ordinal.Equals($actionText, 'none')) { throw 'File result cannot change a thread.' }
        $isResolved = Test-JsTruthy (Get-JsonProperty $item.Value 'isResolved')
        if ($script:Ordinal.Equals($actionText, 'resolve') -and ($isResolved -or -not (Test-ContinuationText $reply))) { throw 'Resolving requires an unresolved thread and a substantive reply.' }
        if ($script:Ordinal.Equals($actionText, 'reopen') -and (-not $isResolved -or -not (Test-ContinuationText $reply))) { throw 'Reopening requires a resolved thread and a reply.' }
        if ($null -ne $reply -and $reply.ValueKind -ne [Text.Json.JsonValueKind]::Null -and $reply.ValueKind -ne [Text.Json.JsonValueKind]::String) { throw 'Invalid thread reply.' }
        $projected = [Collections.Generic.List[object]]::new()
        foreach ($finding in $findings.EnumerateArray()) {
            $path = Get-JsonProperty $finding 'path'; $line = Get-JsonProperty $finding 'line'; $body = Get-JsonProperty $finding 'body'; $side = Get-JsonProperty $finding 'side'
            if (-not (Test-ContinuationText $path) -or -not (Test-ContinuationPositiveInteger $line) -or -not (Test-ContinuationText $body) -or
                ($null -ne $side -and -not (Test-ContinuationString $side @('LEFT','RIGHT')))) { throw 'Invalid inline finding.' }
            $entry = [ordered]@{ path=(Get-JsString $path); line=[long]$line.GetDouble(); body=(Get-JsString $body) }
            if ($null -ne $side) { $entry.side = Get-JsString $side }
            $projected.Add($entry)
        }
        $entry = [ordered]@{ id=$id; status='complete'; reasoning=(Get-JsString $reason); findings=$projected.ToArray(); action=$actionText }
        if (Test-ContinuationText $reply) { $entry.reply = Get-JsString $reply }
        $accepted.Add($entry)
    }
    return ,$accepted.ToArray()
}
function New-ContinuationState($Snapshot, $SnapshotHash, [long] $MaxItems = 8, [long] $MaxBytes = 48000) {
    if ($SnapshotHash -isnot [string] -or $SnapshotHash -cnotmatch '\A[a-f0-9]{64}\z' -or
        -not $script:Ordinal.Equals((Get-JsDigest ($Snapshot.GetRawText())), $SnapshotHash)) { throw 'Snapshot representation does not match the canonical capture.' }
    if ($MaxItems -le 0 -or $MaxBytes -le 0) { throw 'Invalid batch limits.' }
    $work = New-ContinuationWorklist $Snapshot
    $pending = [Collections.Specialized.OrderedDictionary]::new($script:Ordinal)
    foreach ($item in $work) { $pending.Add($item.Id, $item) }
    return [pscustomobject]@{
        Snapshot=$Snapshot; SnapshotHash=$SnapshotHash; Work=$work; Pending=$pending
        Results=[Collections.Generic.List[object]]::new(); Attempts=[Collections.Generic.List[object]]::new()
        MaxItems=$MaxItems; MaxBytes=$MaxBytes; BatchLimit=$MaxItems; Serial=[long]0; Active=$null
    }
}
function Get-ContinuationCheckpoint($State) {
    return [ordered]@{
        head_sha=(Get-JsString (Get-JsonProperty $State.Snapshot 'head_sha'))
        base_sha=(Get-JsString (Get-JsonProperty $State.Snapshot 'base_sha'))
        snapshot_sha256=$State.SnapshotHash
        results=$State.Results.ToArray(); attempts=$State.Attempts.ToArray()
    }
}
function Get-ContinuationAssignment($State, $Nonce) {
    if ($null -ne $State.Active) { throw 'An assignment is already active.' }
    if ($Nonce -isnot [string] -or $Nonce -cnotmatch '\A[a-f0-9]{32}\z') { throw 'Invalid delivery nonce.' }
    if ($State.Pending.Count -eq 0) { return [ordered]@{complete=$true; ids=@()} }
    $prefix = [Collections.Generic.List[object]]::new()
    foreach ($item in $State.Pending.Values) {
        $prefix.Add($item)
        if ($prefix.Count -eq $State.MaxItems + 1) { break }
    }
    $options = [Text.Json.JsonDocumentOptions]::new(); $options.MaxDepth = 10000
    $document = [Text.Json.JsonDocument]::Parse(('[' + (($prefix | ForEach-Object {$_.Json}) -join ',') + ']'), $options)
    try { $count = [Math]::Min((Select-JsReviewBatch $document.RootElement $State.MaxItems $State.MaxBytes), $State.BatchLimit) }
    finally { $document.Dispose() }
    if ($count -le 0) { throw 'Invalid empty assignment.' }
    $assigned = [Collections.Generic.List[object]]::new()
    for ($i=0; $i -lt $count; $i++) { $assigned.Add($prefix[$i]) }
    $State.Serial++
    $State.Active = [pscustomobject]@{ Id=$State.Serial; Nonce=$Nonce; Batch=$assigned.ToArray() }
    return [ordered]@{complete=$false; attempt_id=$State.Active.Id; nonce=$Nonce; ids=@($assigned | ForEach-Object {$_.Id})}
}
function Complete-ContinuationAssignment($State, $AttemptId, $Nonce, $DeliveryVerified, $Response) {
    if ($null -eq $State.Active -or -not (Test-ContinuationPositiveInteger $AttemptId) -or $AttemptId.GetDouble() -ne $State.Active.Id) { throw 'Stale or missing active assignment.' }
    if ($Nonce -isnot [string] -or -not $script:Ordinal.Equals($Nonce, $State.Active.Nonce)) { throw 'Mismatched assignment nonce.' }
    if ($null -eq $DeliveryVerified -or $DeliveryVerified.ValueKind -ne [Text.Json.JsonValueKind]::True) { throw 'Missing verified delivery evidence.' }
    # Validate/project the entire response before changing any authoritative state.
    $accepted = ConvertTo-ContinuationResults $State.Active.Batch $Response
    $reason = Get-JsonProperty $Response 'reason'
    $reasonText = if ($null -ne $reason -and $reason.ValueKind -eq [Text.Json.JsonValueKind]::String) { Get-JsString $reason } else { '' }
    $pendingResults = [Collections.Generic.List[object]]::new()
    foreach ($result in (Get-JsonProperty $Response 'results').EnumerateArray()) {
        if (Test-ContinuationString (Get-JsonProperty $result 'status') @('complete')) { continue }
        $reasoning = Get-JsonProperty $result 'reasoning'
        $reasoningText = if ($null -ne $reasoning -and $reasoning.ValueKind -eq [Text.Json.JsonValueKind]::String) { Get-JsString $reasoning } else { '' }
        $pendingResults.Add([ordered]@{ id=(Get-JsString (Get-JsonProperty $result 'id')); status=(Get-JsString (Get-JsonProperty $result 'status')); reasoning=$reasoningText })
    }
    $attempt = [ordered]@{
        assigned=@($State.Active.Batch | ForEach-Object {$_.Id}); completed=@($accepted | ForEach-Object {$_.id})
        reason=$reasonText; pending=$pendingResults.ToArray()
    }
    foreach ($result in $accepted) { $State.Pending.Remove($result.id); $State.Results.Add($result) }
    $State.Attempts.Add($attempt)
    $State.BatchLimit = if ($accepted.Count -gt 0) { $State.MaxItems } else { [Math]::Max(1, [Math]::Floor($State.BatchLimit / 2)) }
    $attemptId = $State.Active.Id
    $State.Active = $null
    return [ordered]@{ attempt_id=$attemptId; accepted=$accepted; attempt=$attempt; remaining=$State.Pending.Count; batch_limit=$State.BatchLimit }
}
function ConvertTo-ContinuationJson($Value) {
    return ConvertTo-JsJsonText (ConvertTo-Json -InputObject $Value -Depth 100 -Compress)
}
function ConvertTo-ContinuationString($Value) {
    # JSON-domain JavaScript String(value), assuming the trusted native adapter
    # has preserved canonical finite numbers rather than reformatted them.
    if ($null -eq $Value) { return 'undefined' }
    switch ($Value.ValueKind) {
        ([Text.Json.JsonValueKind]::String) { return Get-JsString $Value }
        ([Text.Json.JsonValueKind]::Null) { return 'null' }
        ([Text.Json.JsonValueKind]::True) { return 'true' }
        ([Text.Json.JsonValueKind]::False) { return 'false' }
        ([Text.Json.JsonValueKind]::Number) { return $Value.GetRawText() }
        ([Text.Json.JsonValueKind]::Array) {
            $parts = [Collections.Generic.List[string]]::new()
            foreach ($entry in $Value.EnumerateArray()) {
                if ($entry.ValueKind -eq [Text.Json.JsonValueKind]::Null) { $parts.Add('') }
                else { $parts.Add((ConvertTo-ContinuationString $entry)) }
            }
            return $parts -join ','
        }
        ([Text.Json.JsonValueKind]::Object) {
            if ($null -ne (Get-JsonProperty $Value 'toString')) { throw 'Cannot convert object to primitive value.' }
            return '[object Object]'
        }
        default { throw 'Unsupported captured value.' }
    }
}
function ConvertTo-SafeInventoryText([string] $Value) {
    $safe = [regex]::Replace($Value, '[\uD800-\uDBFF][\uDC00-\uDFFF]|[^a-zA-Z0-9 .,:/(){}_-]', [Text.RegularExpressions.MatchEvaluator]{
        param($match)
        $point = if ($match.Value.Length -eq 2) { [char]::ConvertToUtf32($match.Value,0) } else { [int][char]$match.Value[0] }
        return '\u{' + $point.ToString('x',[Globalization.CultureInfo]::InvariantCulture) + '}'
    })
    $safe = $safe.Replace('//','\u{2f}/')
    return [regex]::Replace($safe, '(data|javascript|vbscript|about|mailto|tel|magnet):', [Text.RegularExpressions.MatchEvaluator]{param($match) $match.Groups[1].Value + '\u{3a}'}, [Text.RegularExpressions.RegexOptions]::IgnoreCase -bor [Text.RegularExpressions.RegexOptions]::CultureInvariant)
}
function Test-InventoryIdentifier([string] $Body, [string] $Identifier) {
    for ($at=$Body.IndexOf($Identifier,[StringComparison]::Ordinal); $at -ge 0; $at=$Body.IndexOf($Identifier,$at+1,[StringComparison]::Ordinal)) {
        $before = $at -eq 0 -or -not [regex]::IsMatch([string]$Body[$at-1], '[a-zA-Z0-9_.$:{}()\[\]<>]')
        $after = $at+$Identifier.Length -eq $Body.Length -or -not [regex]::IsMatch([string]$Body[$at+$Identifier.Length], '[a-zA-Z0-9_.$:{}()\[\]<>]')
        if ($before -and $after) { return $true }
    }
    return $false
}
function Get-ContinuationInventory($Snapshot) {
    $files = Get-JsonProperty $Snapshot 'files'; $threads = Get-JsonProperty $Snapshot 'threads'; $reviews = Get-JsonProperty $Snapshot 'reviews'
    $entries = Get-JsonProperty $Snapshot 'baseline_suppressions'; $relevant = $false
    $paths = [Collections.Generic.HashSet[string]]::new($script:Ordinal)
    foreach ($file in $files.EnumerateArray()) {
        $name = Get-JsString (Get-JsonProperty $file 'filename')
        if ([regex]::IsMatch($name,'\Aeng/apicompatbaselines/[^/]+\.xml\z')) {
            [void]$paths.Add($name)
            if (-not (Test-ContinuationString (Get-JsonProperty $file 'status') @('removed'))) { $relevant=$true }
        }
    }
    if ($relevant -and ($null -eq $entries -or $entries.ValueKind -ne [Text.Json.JsonValueKind]::Array)) { throw 'Missing captured baseline suppression inventory.' }
    $lines = [Collections.Generic.List[string]]::new()
    if (-not (Test-JsTruthy $entries)) { return ,$lines.ToArray() }
    if ($entries.ValueKind -ne [Text.Json.JsonValueKind]::Array) { throw 'Invalid baseline suppression inventory.' }
    foreach ($entry in $entries.EnumerateArray()) {
        $path = Get-JsonProperty $entry 'path'; $fields = Get-JsonProperty $entry 'fields'; $comment = Get-JsonProperty $entry 'nearby_comment'
        if ($null -eq $path -or $path.ValueKind -ne [Text.Json.JsonValueKind]::String -or -not $paths.Contains((Get-JsString $path)) -or
            $null -eq $fields -or $fields.ValueKind -ne [Text.Json.JsonValueKind]::Object -or
            -not (Test-JsTruthy (Get-JsonProperty $fields 'DiagnosticId')) -or -not (Test-JsTruthy (Get-JsonProperty $fields 'Target')) -or
            $null -eq $comment -or $comment.ValueKind -notin @([Text.Json.JsonValueKind]::Null,[Text.Json.JsonValueKind]::String)) { throw 'Invalid captured suppression.' }
        $names = [Collections.Generic.List[string]]::new()
        foreach ($field in $fields.EnumerateObject()) {
            if ($field.Value.ValueKind -ne [Text.Json.JsonValueKind]::String) { throw 'Invalid captured suppression.' }
            $names.Add($field.Name)
        }
        $names.Sort($script:Ordinal); $pairs = [Collections.Generic.List[string]]::new()
        foreach ($name in $names) { $pairs.Add((ConvertTo-SafeInventoryText $name) + '=' + (ConvertTo-SafeInventoryText (Get-JsString (Get-JsonProperty $fields $name)))) }
        $identity = '- 🟡 `' + (ConvertTo-SafeInventoryText (Get-JsString $path)) + '; ' + ($pairs -join '; ') + '; nearby comment: '
        $nearby = if (Test-JsTruthy $comment) { Get-JsString $comment } else { 'none identified' }
        $line = $identity + (ConvertTo-SafeInventoryText $nearby) + '`'
        $prior = $null; $priorReview = $null; $diagnostic = Get-JsString (Get-JsonProperty $fields 'DiagnosticId'); $target = Get-JsString (Get-JsonProperty $fields 'Target')
        foreach ($thread in $threads.EnumerateArray()) {
            foreach ($feedback in (Get-JsonProperty $thread 'comments').EnumerateArray()) {
                $feedbackPath = Get-JsonProperty $feedback 'path'; $body = Get-JsonProperty $feedback 'body'
                if ($null -ne $feedbackPath -and $feedbackPath.ValueKind -eq [Text.Json.JsonValueKind]::String -and $script:Ordinal.Equals((Get-JsString $feedbackPath),(Get-JsString $path)) -and
                    $null -ne $body -and $body.ValueKind -eq [Text.Json.JsonValueKind]::String -and (Test-InventoryIdentifier (Get-JsString $body) $diagnostic) -and (Test-InventoryIdentifier (Get-JsString $body) $target)) { $prior=$feedback; break }
            }
            if ($null -ne $prior) { break }
        }
        if (Test-JsTruthy $reviews) {
            if ($reviews.ValueKind -ne [Text.Json.JsonValueKind]::Array) { throw 'Invalid captured reviews.' }
            foreach ($review in $reviews.EnumerateArray()) {
                $reviewId = Get-JsonProperty $review 'id'; $body = Get-JsonProperty $review 'body'
                if ($null -eq $reviewId -or $reviewId.ValueKind -ne [Text.Json.JsonValueKind]::Number -or $null -eq $body -or $body.ValueKind -ne [Text.Json.JsonValueKind]::String) { continue }
                $number=$reviewId.GetDouble()
                if ([double]::IsInfinity($number) -or [double]::IsNaN($number) -or [Math]::Abs($number) -gt 9007199254740991 -or [Math]::Floor($number) -ne $number) { continue }
                foreach ($text in [regex]::Split((Get-JsString $body),'\r?\n')) { if ($text.StartsWith($identity,[StringComparison]::Ordinal)) { $priorReview=$review; break } }
                if ($null -ne $priorReview) { break }
            }
        }
        $references = [Collections.Generic.List[string]]::new()
        if ($null -ne $prior) { $references.Add('prior review comment ID ' + (ConvertTo-ContinuationString (Get-JsonProperty $prior 'databaseId'))) }
        if ($null -ne $priorReview) { $references.Add('prior review ID ' + (ConvertTo-ContinuationString (Get-JsonProperty $priorReview 'id'))) }
        if ($references.Count -gt 0) { $line += ' (' + ($references -join '; ') + ')' }
        $lines.Add($line)
    }
    return ,$lines.ToArray()
}
function New-ContinuationOutputs($Snapshot, $Ledger) {
    $work = New-ContinuationWorklist $Snapshot; $validated = ConvertTo-ContinuationResults $work $Ledger
    if ($validated.Count -ne $work.Count) { throw 'Incomplete review ledger; refusing publication.' }
    $items = [Collections.Generic.Dictionary[string, object]]::new($script:Ordinal); $changed = [Collections.Generic.Dictionary[string, object]]::new($script:Ordinal)
    foreach ($item in $work) { $items[$item.Id]=$item; if ($script:Ordinal.Equals($item.Kind,'file')) { $changed[(Get-JsString (Get-JsonProperty $item.Value 'filename'))]=$item.Value } }
    $outputs=[Collections.Generic.List[object]]::new(); $findings=[Collections.Generic.HashSet[string]]::new($script:Ordinal); $summaries=[Collections.Generic.List[string]]::new()
    $inlineCount=0; $replyCount=0; $resolveCount=0; $reopenCount=0
    foreach ($result in $validated) {
        $item=$items[$result.id]
        foreach ($finding in $result.findings) {
            if (-not $changed.ContainsKey($finding.path)) { throw 'Inline finding is outside the captured changed files.' }
            if ($findings.Add((ConvertTo-ContinuationJson $finding))) {
                $side=if ($finding.Contains('side')) {$finding.side} elseif (Test-ContinuationString (Get-JsonProperty $changed[$finding.path] 'status') @('removed')) {'LEFT'} else {'RIGHT'}
                $outputs.Add([ordered]@{type='create_pull_request_review_comment';path=$finding.path;line=$finding.line;body=$finding.body;side=$side}); $inlineCount++
            }
        }
        if (-not $script:Ordinal.Equals($item.Kind,'thread')) { continue }
        $comments=Get-JsonProperty $item.Value 'comments'; $root=[long](Get-JsonProperty $comments[0] 'databaseId').GetDouble()
        if ($result.Contains('reply')) { $outputs.Add([ordered]@{type='reply_to_pull_request_review_comment';comment_id=$root;body=$result.reply}); $replyCount++ }
        if ($script:Ordinal.Equals($result.action,'resolve') -or $script:Ordinal.Equals($result.action,'reopen')) {
            $outputs.Add([ordered]@{type='unresolve_review_thread';operation=$result.action;comment_id=$root;reason=$result.reasoning})
            if ($script:Ordinal.Equals($result.action,'resolve')) {$resolveCount++} else {$reopenCount++}
        }
        $action=if ($script:Ordinal.Equals($result.action,'none')) {'verified, unchanged'} else {'requested ' + $result.action}
        $summaries.Add("- Thread ${root}: $action. $($result.reasoning)")
    }
    if ($inlineCount -gt 100 -or $replyCount -gt 50 -or $resolveCount -gt 50 -or $reopenCount -gt 50) { throw 'Review exceeds configured safe-output limits.' }
    $threads=Get-JsonProperty $Snapshot 'threads'; $files=Get-JsonProperty $Snapshot 'files'; $unresolved=0
    foreach ($thread in $threads.EnumerateArray()) { if (-not (Test-JsTruthy (Get-JsonProperty $thread 'isResolved'))) {$unresolved++} }
    $inventory=Get-ContinuationInventory $Snapshot
    $inventoryText=if ($inventory.Count -gt 0) {"`n`n## New ApiCompat suppressions`n`n" + ($inventory -join "`n")} else {''}
    $conclusion=if ($findings.Count -gt 0) {"$($findings.Count) new finding(s); see inline comments."} elseif ($inventory.Count -gt 0) {'See the suppression inventory below.'} else {'No new findings.'}
    $text=$summaries -join "`n"; $tail=$text.Substring(0,[Math]::Min(12000,$text.Length))
    if ($text.Length -gt 12000) { $tail += "`n`nFurther thread conclusions are recorded in the review-progress artifact." }
    $total=$threads.GetArrayLength(); $fileCount=$files.GetArrayLength()
    $body="## Re-review summary`n`nCoverage: $total/$total threads fetched, $unresolved/$unresolved unresolved threads verified, $fileCount/$fileCount changed files reviewed`n`n$conclusion$inventoryText`n`n$tail"
    $white='[\u0009-\u000d\u0020\u00a0\u1680\u2000-\u200a\u2028\u2029\u202f\u205f\u3000\ufeff]'
    $body=[regex]::Replace($body,('\A'+$white+'+|'+$white+'+\z'),'')
    if ([Text.UTF8Encoding]::new($false).GetByteCount($body) -gt 60000) { throw 'Review summary exceeds the safe publication limit.' }
    $outputs.Add([ordered]@{type='submit_pull_request_review';event='COMMENT';body=$body})
    return ,$outputs.ToArray()
}
function Complete-ContinuationReview($State) {
    if ($State.Pending.Count -ne 0 -or $null -ne $State.Active) { throw 'Incomplete review ledger; refusing publication.' }
    $options=[Text.Json.JsonDocumentOptions]::new(); $options.MaxDepth=10000
    $ledger=[Text.Json.JsonDocument]::Parse((ConvertTo-ContinuationJson @{results=$State.Results.ToArray()}),$options)
    try { return ,(New-ContinuationOutputs $State.Snapshot $ledger.RootElement) }
    finally { $ledger.Dispose() }
}
function Test-ContinuationPropertyEqual($Left, $Right, [string] $Name) {
    $a=Get-JsonProperty $Left $Name; $b=Get-JsonProperty $Right $Name
    if ($null -eq $a -or $null -eq $b) { return $null -eq $a -and $null -eq $b }
    if ($a.ValueKind -ne $b.ValueKind -or $a.ValueKind -in @([Text.Json.JsonValueKind]::Object,[Text.Json.JsonValueKind]::Array)) { return $false }
    return $script:Ordinal.Equals($a.GetRawText(),$b.GetRawText())
}
function Trim-ContinuationText([string] $Value) {
    $white='[\u0009-\u000d\u0020\u00a0\u1680\u2000-\u200a\u2028\u2029\u202f\u205f\u3000\ufeff]'
    return [regex]::Replace($Value,('\A'+$white+'+|'+$white+'+\z'),'')
}
function Get-ContinuationWordPattern([string] $Word) {
    $builder=[Text.StringBuilder]::new()
    foreach ($letter in $Word.ToCharArray()) { [void]$builder.Append('[').Append($letter).Append([char]::ToUpperInvariant($letter)).Append(']') }
    return $builder.ToString()
}
function Assert-ContinuationPublication($Snapshot, $Progress, $Output, $AgentResult, $SnapshotHash, $ActualRouting, $RoutingError) {
    if (-not (Test-ContinuationString $AgentResult @('success'))) { throw 'Review controller did not complete successfully; refusing all publication.' }
    if ($SnapshotHash -isnot [string] -or -not $script:Ordinal.Equals((Get-JsDigest ($Snapshot.GetRawText())),$SnapshotHash)) { throw 'Snapshot representation does not match the canonical capture.' }
    $progressHash=Get-JsonProperty $Progress 'snapshot_sha256'
    if ($null -eq $progressHash -or $progressHash.ValueKind -ne [Text.Json.JsonValueKind]::String -or -not $script:Ordinal.Equals((Get-JsString $progressHash),$SnapshotHash) -or
        -not (Test-ContinuationPropertyEqual $Progress $Snapshot 'head_sha') -or -not (Test-ContinuationPropertyEqual $Progress $Snapshot 'base_sha')) { throw 'Review progress does not belong to the captured snapshot.' }
    $expected=New-ContinuationOutputs $Snapshot $Progress
    $items=Get-JsonProperty $Output 'items'; $errors=Get-JsonProperty $Output 'errors'
    if ($null -eq $items -or $items.ValueKind -ne [Text.Json.JsonValueKind]::Array -or $null -eq $errors -or $errors.ValueKind -ne [Text.Json.JsonValueKind]::Array -or
        $errors.GetArrayLength() -ne 0 -or $items.GetArrayLength() -ne $expected.Count) { throw 'Buffered outputs do not match the completed review ledger.' }
    # The trusted Node adapter supplies original JavaScript routing strings,
    # preserving String(value), numeric normalization and object-key semantics.
    # It captures coercion errors without bypassing the ordered checks above.
    if ($null -ne $RoutingError -and $RoutingError.ValueKind -ne [Text.Json.JsonValueKind]::Null) {
        if ($RoutingError.ValueKind -ne [Text.Json.JsonValueKind]::String) { throw 'Invalid routing serialization error.' }
        throw (Get-JsString $RoutingError)
    }
    if ($null -eq $ActualRouting -or $ActualRouting.ValueKind -ne [Text.Json.JsonValueKind]::Array -or $ActualRouting.GetArrayLength() -ne $expected.Count) { throw 'Buffered output routing differs from the accepted review results.' }
    $wanted=[Collections.Generic.List[string]]::new(); $actual=[Collections.Generic.List[string]]::new()
    foreach ($item in $expected) {
        $names=[Collections.Generic.List[string]]::new()
        foreach ($name in $item.Keys) { if (-not $script:Ordinal.Equals($name,'body') -and -not $script:Ordinal.Equals($name,'reason')) { $names.Add($name) } }
        $names.Sort($script:Ordinal); $canonical=[ordered]@{}
        foreach ($name in $names) {
            $value=$item[$name]
            if ($value -is [string]) { $canonical[$name]=$value }
            elseif ($value -is [long] -or $value -is [int]) { $canonical[$name]=$value.ToString([Globalization.CultureInfo]::InvariantCulture) }
            else { throw 'Invalid expected routing value.' }
        }
        $wanted.Add((ConvertTo-ContinuationJson $canonical))
    }
    foreach ($entry in $ActualRouting.EnumerateArray()) {
        if ($entry.ValueKind -ne [Text.Json.JsonValueKind]::String) { throw 'Buffered output routing differs from the accepted review results.' }
        $actual.Add((Get-JsString $entry))
    }
    $wanted.Sort($script:Ordinal); $actual.Sort($script:Ordinal)
    for ($i=0; $i -lt $wanted.Count; $i++) { if (-not $script:Ordinal.Equals($wanted[$i],$actual[$i])) { throw 'Buffered output routing differs from the accepted review results.' } }
    $body=$null
    foreach ($item in $items.EnumerateArray()) {
        if (Test-ContinuationString (Get-JsonProperty $item 'type') @('submit_pull_request_review')) { $body=Get-JsonProperty $item 'body'; break }
    }
    if ($null -eq $body -or $body.ValueKind -ne [Text.Json.JsonValueKind]::String) { throw 'Missing review coverage.' }
    $body=Get-JsString $body
    $white='[\u0009-\u000d\u0020\u00a0\u1680\u2000-\u200a\u2028\u2029\u202f\u205f\u3000\ufeff]'
    $label=Get-ContinuationWordPattern 'coverage'; $lines=[Collections.Generic.List[string]]::new()
    foreach ($line in [regex]::Split($body,'\r?\n')) {
        $line=Trim-ContinuationText ([regex]::Replace($line,'[*_`]',''))
        $line=[regex]::Replace($line,('\A(?:>'+ $white+'*)+'),'')
        $line=[regex]::Replace($line,('\A[-+]'+$white+'+'),'')
        $line=Trim-ContinuationText $line
        if ([regex]::IsMatch($line,('\A'+$label+$white+'*:'))) { $lines.Add($line) }
    }
    $w=$white+'*'; $space=$white+'+'
    $pair='([0-9]{1,6})'+$w+'/'+$w+'([0-9]{1,6})'
    $pattern='\A'+$label+$w+':'+$w+$pair+$space+(Get-ContinuationWordPattern 'threads')+$space+(Get-ContinuationWordPattern 'fetched')+$w+','+$w+$pair+$space+(Get-ContinuationWordPattern 'unresolved')+$space+(Get-ContinuationWordPattern 'threads')+$space+(Get-ContinuationWordPattern 'verified')+$w+','+$w+$pair+$space+(Get-ContinuationWordPattern 'changed')+$space+(Get-ContinuationWordPattern 'files')+$space+(Get-ContinuationWordPattern 'reviewed')+$w+'\.?\z'
    $threads=Get-JsonProperty $Snapshot 'threads'; $files=Get-JsonProperty $Snapshot 'files'; $unresolved=0
    foreach ($thread in $threads.EnumerateArray()) { if (-not (Test-JsTruthy (Get-JsonProperty $thread 'isResolved'))) {$unresolved++} }
    if ($lines.Count -ne 1) { throw 'Buffered review coverage differs from the captured complete ledger.' }
    $match=[regex]::Match($lines[0],$pattern)
    $counts=@($threads.GetArrayLength(),$threads.GetArrayLength(),$unresolved,$unresolved,$files.GetArrayLength(),$files.GetArrayLength())
    if (-not $match.Success) { throw 'Buffered review coverage differs from the captured complete ledger.' }
    for ($i=0; $i -lt 6; $i++) { if ([long]$match.Groups[$i+1].Value -ne $counts[$i]) { throw 'Buffered review coverage differs from the captured complete ledger.' } }
    $inventory=Get-ContinuationInventory $Snapshot
    if ($inventory.Count -gt 0) {
        $section="## New ApiCompat suppressions`n`n"+($inventory -join "`n"); $normalized=$body.Replace("`r`n","`n")
        $at=$normalized.IndexOf($section,[StringComparison]::Ordinal)
        if ($at -lt 0) { throw 'Buffered review omits or hides a captured baseline suppression.' }
        $prefix=$normalized.Substring(0,$at); $next=$at+$section.Length
        if ($normalized.IndexOf($section,$at+1,[StringComparison]::Ordinal) -ge 0 -or [regex]::IsMatch($prefix,('(?:\A|\n)'+$white+'*(?:```|~~~)')) -or $prefix.Contains('No new findings.',[StringComparison]::Ordinal) -or
            ($next -lt $normalized.Length -and $normalized[$next] -ne [char]10)) { throw 'Buffered review omits or hides a captured baseline suppression.' }
    }
}
Export-ModuleMember -Function New-ContinuationWorklist, ConvertTo-ContinuationResults, New-ContinuationState, Get-ContinuationCheckpoint, Get-ContinuationAssignment, Complete-ContinuationAssignment, New-ContinuationOutputs, ConvertTo-ContinuationJson, Assert-ContinuationPublication, Complete-ContinuationReview
