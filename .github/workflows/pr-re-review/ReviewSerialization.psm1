# Experimental JavaScript-compatible capture identity and input-selection functions.
$ErrorActionPreference = 'Stop'
$script:Utf8 = [Text.UTF8Encoding]::new($false)
$script:JsonTokens = [regex]::new('"(?:[^"\\]+|\\.)*"|[{}\[\],:]|[^{}\[\],:"]+', [Text.RegularExpressions.RegexOptions]::CultureInvariant -bor [Text.RegularExpressions.RegexOptions]::NonBacktracking)

function Get-JsonProperty($Element, [string] $Name) {
    if ($Element.ValueKind -ne [System.Text.Json.JsonValueKind]::Object) { return $null }
    $property = [System.Text.Json.JsonElement]::new()
    if (-not $Element.TryGetProperty($Name, [ref]$property)) { return $null }
    return $property
}
function Get-JsString($Element) {
    if ($null -eq $Element -or $Element.ValueKind -ne [System.Text.Json.JsonValueKind]::String) { throw 'Expected a captured string.' }
    $raw = $Element.GetRawText()
    return [regex]::Unescape($raw.Substring(1, $raw.Length - 2))
}
function Test-JsTruthy($Element) {
    if ($null -eq $Element) { return $false }
    switch ($Element.ValueKind) {
        ([System.Text.Json.JsonValueKind]::Null) { return $false }
        ([System.Text.Json.JsonValueKind]::False) { return $false }
        ([System.Text.Json.JsonValueKind]::Undefined) { return $false }
        ([System.Text.Json.JsonValueKind]::String) { return $Element.GetRawText().Length -gt 2 }
        ([System.Text.Json.JsonValueKind]::Number) { return $Element.GetDouble() -ne 0 }
        default { return $true }
    }
}
function Get-JsDigest([string] $Value) {
    return [Convert]::ToHexString([Security.Cryptography.SHA256]::HashData($script:Utf8.GetBytes($Value))).ToLowerInvariant()
}
function ConvertTo-JsJsonText([string] $Json) {
    # Match JSON.stringify for isolated surrogates and Unicode characters that
    # Json.NET escapes unnecessarily, without changing literal backslashes.
    $Json = [regex]::Replace($Json, '[\uD800-\uDBFF](?![\uDC00-\uDFFF])|(?<![\uD800-\uDBFF])[\uDC00-\uDFFF]', [Text.RegularExpressions.MatchEvaluator]{ param($match) '\u{0:x4}' -f [int][char]$match.Value[0] })
    return [regex]::Replace($Json, '(?<!\\)((?:\\\\)*)\\u(0085|2028|2029)', [Text.RegularExpressions.MatchEvaluator]{ param($match) $match.Groups[1].Value + [char][Convert]::ToInt32($match.Groups[2].Value, 16) })
}
# Element raw text must come from trusted compact JSON.stringify, not arbitrary JSON.
function Format-JsPrettyJson($Element) {
    $raw = $Element.GetRawText(); $result = [Text.StringBuilder]::new()
    $current = $script:JsonTokens.Match($raw); $previous = $null; $depth = 0; $position = 0
    while ($current.Success) {
        if ($current.Index -ne $position) { throw 'JSON tokenization skipped input.' }
        $position += $current.Length
        $next = $current.NextMatch(); $token = $current.Value
        switch -CaseSensitive ($token) {
            { $_ -ceq '{' -or $_ -ceq '[' } {
                [void]$result.Append($token)
                $close = if ($_ -ceq '{') { '}' } else { ']' }
                if ($next.Success -and $next.Value -cne $close) { $depth++; [void]$result.Append("`n").Append((' ' * (2 * $depth))) }
                break
            }
            { $_ -ceq '}' -or $_ -ceq ']' } {
                $open = if ($_ -ceq '}') { '{' } else { '[' }
                if ($null -ne $previous -and $previous -cne $open) { $depth--; [void]$result.Append("`n").Append((' ' * (2 * $depth))) }
                [void]$result.Append($token); break
            }
            ',' { [void]$result.Append($token).Append("`n").Append((' ' * (2 * $depth))); break }
            ':' { [void]$result.Append(': '); break }
            default { [void]$result.Append($token); break }
        }
        $previous = $token; $current = $next
    }
    if ($position -ne $raw.Length) { throw 'JSON tokenization skipped input.' }
    return $result.ToString()
}
function Get-JsRequiredInputs($Item, [long] $MaxBytes) {
    if ($MaxBytes -le 0) { throw 'Invalid delivery threshold.' }
    $thread = Get-JsonProperty $Item 'thread'
    if (Test-JsTruthy $thread) {
        $content = Format-JsPrettyJson $thread
        return ,@(@{ key = 'history:' + (Get-JsDigest $content); kind = 'history'; content = $content })
    }
    $file = Get-JsonProperty $Item 'file'
    $filename = if ($null -ne $file) { Get-JsonProperty $file 'filename' } else { $null }
    if ($null -eq $filename -or $filename.ValueKind -ne [System.Text.Json.JsonValueKind]::String) { throw 'Invalid delivery assignment.' }
    $result = [Collections.Generic.List[object]]::new()
    $patch = Get-JsonProperty $file 'patch'
    if ($null -ne $patch) {
        if ($patch.ValueKind -ne [System.Text.Json.JsonValueKind]::String) { throw 'Invalid captured patch.' }
        $content = Get-JsString $patch
        if ($script:Utf8.GetByteCount($content) -gt $MaxBytes) { $result.Add(@{ key = 'patch:' + (Get-JsDigest $content); kind = 'patch'; content = $content }) }
    }
    $statusElement = Get-JsonProperty $file 'status'
    $status = if ($null -ne $statusElement -and $statusElement.ValueKind -eq [System.Text.Json.JsonValueKind]::String) { Get-JsString $statusElement } else { $null }
    if ([StringComparer]::Ordinal.Equals($status, 'renamed')) {
        $previous = Get-JsonProperty $file 'previous_filename'
        if ($null -eq $previous -or $previous.ValueKind -ne [System.Text.Json.JsonValueKind]::String -or $previous.GetRawText().Length -eq 2) { throw 'Missing source path for delivery.' }
    }
    if ($null -eq $patch -and -not @('added', 'modified', 'removed', 'renamed').Where({ [StringComparer]::Ordinal.Equals($_, $status) }).Count) { throw 'Unsupported file status for omitted patch delivery.' }
    return ,$result.ToArray()
}
function Select-JsReviewBatch($Work, [long] $MaxItems, [long] $MaxBytes) {
    if ($null -eq $Work -or $Work.ValueKind -ne [Text.Json.JsonValueKind]::Array -or $MaxItems -le 0 -or $MaxBytes -le 0) { throw 'Invalid batch selection input.' }
    $count = 0; $bytes = [long]0; $firstIsThread = $false
    foreach ($item in $Work.EnumerateArray()) {
        $size = $script:Utf8.GetByteCount($item.GetRawText())
        $isThread = Test-JsTruthy (Get-JsonProperty $item 'thread')
        if ($count -gt 0 -and ($isThread -ne $firstIsThread -or $count -eq $MaxItems -or $bytes + $size -gt $MaxBytes)) { break }
        if ($count -eq 0) { $firstIsThread = $isThread }
        $count++; $bytes += $size
    }
    return $count
}
Export-ModuleMember -Function Get-JsonProperty, Get-JsString, Test-JsTruthy, Get-JsDigest, ConvertTo-JsJsonText, Format-JsPrettyJson, Get-JsRequiredInputs, Select-JsReviewBatch
