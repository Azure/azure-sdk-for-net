#!/usr/bin/env pwsh
<#
.SYNOPSIS
  Capture the single final azsdk response without mixing process diagnostics into JSON.

.DESCRIPTION
  Reads the raw engine-stdout.txt, engine-stderr.txt, and engine-exit-code.txt from
  one invocation. Failed azsdk responses can be written to stderr between diagnostics,
  including upgrade notifications emitted after the command response.
  Preserves both streams, writes the original response to result.json only when
  unambiguous and consistent with the process outcome, and returns the engine exit code.
#>
[CmdletBinding()]
param(
    [Parameter(Mandatory)]
    [string]$ResultsDir,

    [ValidateRange(1, 10)]
    [int]$MaxIterations = 3
)

Set-StrictMode -Version Latest
$ErrorActionPreference = 'Stop'

$resultPath = Join-Path $ResultsDir 'result.json'
$errorsPath = Join-Path $ResultsDir 'engine-errors.txt'
if (Test-Path -LiteralPath $resultPath) {
    Remove-Item -LiteralPath $resultPath
}

function Get-JsonObjects([string]$text, [string]$stream) {
    $nextStart = 0
    foreach ($start in [regex]::Matches($text, '(?m)^[ \t]*\{')) {
        $offset = $start.Index + $start.Length - 1
        if ($offset -lt $nextStart) { continue }
        $depth = 0
        $inString = $false
        $escaped = $false
        $end = -1
        for ($i = $offset; $i -lt $text.Length; $i++) {
            $character = $text[$i]
            if ($inString) {
                if ($escaped) { $escaped = $false }
                elseif ($character -eq '\') { $escaped = $true }
                elseif ($character -eq '"') { $inString = $false }
            }
            elseif ($character -eq '"') { $inString = $true }
            elseif ($character -eq '{') { $depth++ }
            elseif ($character -eq '}') {
                $depth--
                if ($depth -eq 0) { $end = $i + 1; break }
            }
        }
        if ($end -lt 0) { throw "Unterminated JSON object in engine $stream." }
        $nextStart = $end
        $json = $text.Substring($offset, $end - $offset)
        $document = [System.Text.Json.JsonDocument]::Parse($json)
        try {
            $root = $document.RootElement
            $names = @($root.EnumerateObject() | ForEach-Object { $_.Name })
            if ('success' -cnotin $names -and 'attemptsUsed' -cnotin $names) { continue }
            $seen = [System.Collections.Generic.HashSet[string]]::new([System.StringComparer]::OrdinalIgnoreCase)
            foreach ($name in $names) {
                if (-not $seen.Add($name)) { throw "Duplicate response property '$name' in engine $stream." }
            }
            [pscustomobject]@{
                Text = $json
                Root = $root.Clone()
                Stream = $stream
                Prefix = $text.Substring(0, $offset)
                Suffix = $text.Substring($end)
            }
        }
        finally { $document.Dispose() }
    }
}

try {
    $stdout = [System.IO.File]::ReadAllText((Join-Path $ResultsDir 'engine-stdout.txt'))
    $stderr = [System.IO.File]::ReadAllText((Join-Path $ResultsDir 'engine-stderr.txt'))
    [System.IO.File]::WriteAllText($errorsPath, "Engine stdout:`n$stdout`nEngine stderr:`n$stderr")
    $exitText = [System.IO.File]::ReadAllText((Join-Path $ResultsDir 'engine-exit-code.txt')).Trim()
    $engineExit = 0
    if (-not [int]::TryParse($exitText, [ref]$engineExit) -or $engineExit -lt 0 -or $engineExit -gt 255) {
        throw 'Missing or invalid engine process exit code.'
    }
    $responses = @(Get-JsonObjects $stdout 'stdout'; Get-JsonObjects $stderr 'stderr')
    if ($responses.Count -ne 1) {
        throw "Expected one final engine response; found $($responses.Count)."
    }
    $response = $responses[0]
    if (($response.Stream -eq 'stdout' -and
            (-not [string]::IsNullOrWhiteSpace($response.Prefix) -or
             -not [string]::IsNullOrWhiteSpace($response.Suffix))) -or
        ($response.Stream -eq 'stderr' -and -not [string]::IsNullOrWhiteSpace($stdout))) {
        throw 'The engine response is not isolated on its expected output stream.'
    }
    $root = $response.Root
    $success = [System.Text.Json.JsonElement]::new()
    $attempts = [System.Text.Json.JsonElement]::new()
    $count = 0
    if (-not $root.TryGetProperty('success', [ref]$success) -or
        $success.ValueKind -notin @([System.Text.Json.JsonValueKind]::True, [System.Text.Json.JsonValueKind]::False)) {
        throw 'The engine response must contain Boolean success.'
    }
    if (-not $root.TryGetProperty('attemptsUsed', [ref]$attempts) -or
        $attempts.ValueKind -ne [System.Text.Json.JsonValueKind]::Number -or
        -not $attempts.TryGetInt32([ref]$count) -or $count -lt 0 -or $count -gt $MaxIterations) {
        throw 'The engine response must contain integer attemptsUsed within the configured bound.'
    }
    if ($success.GetBoolean() -ne ($engineExit -eq 0)) {
        throw 'The engine response success value contradicts its process exit code.'
    }
    $status = [System.Text.Json.JsonElement]::new()
    $errorValue = [System.Text.Json.JsonElement]::new()
    $expectedStatus = if ($success.GetBoolean()) { 'Succeeded' } else { 'Failed' }
    if ($root.TryGetProperty('operation_status', [ref]$status) -and
        $status.ValueKind -ne [System.Text.Json.JsonValueKind]::Null -and
        ($status.ValueKind -ne [System.Text.Json.JsonValueKind]::String -or $status.GetString() -cne $expectedStatus)) {
        throw "The engine response operation_status must be null or '$expectedStatus' for its outcome."
    }
    if ($root.TryGetProperty('response_error', [ref]$errorValue) -and
        $errorValue.ValueKind -notin @([System.Text.Json.JsonValueKind]::Null, [System.Text.Json.JsonValueKind]::String)) {
        throw 'The engine response response_error must be null or a string.'
    }
    if ($success.GetBoolean()) {
        if ($response.Stream -ne 'stdout') {
            throw 'A successful engine response must be on stdout.'
        }
        if ($errorValue.ValueKind -eq [System.Text.Json.JsonValueKind]::String -and $errorValue.GetString().Length -gt 0) {
            throw 'The engine success response contains an error.'
        }
    }
    [System.IO.File]::WriteAllText($resultPath, $response.Text)
}
catch {
    $diagnostic = "Engine response capture failed: $($_.Exception.Message)"
    Add-Content -LiteralPath $errorsPath -Value $diagnostic
    Write-Error $diagnostic -ErrorAction Continue
    exit 1
}

exit $engineExit
