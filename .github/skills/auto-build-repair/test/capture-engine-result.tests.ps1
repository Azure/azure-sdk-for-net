#!/usr/bin/env pwsh
<#
.SYNOPSIS
  Hermetic regression coverage for CLI response capture and failed-repair reporting.
#>
[CmdletBinding()]
param(
    [string]$CapturePath = (Join-Path $PSScriptRoot '..' 'capture-engine-result.ps1'),
    [string]$EmitterPath = (Join-Path $PSScriptRoot '..' 'emit-repair-report.ps1')
)

Set-StrictMode -Version Latest
$ErrorActionPreference = 'Stop'
$CapturePath = (Resolve-Path $CapturePath).Path
$EmitterPath = (Resolve-Path $EmitterPath).Path
$failures = [System.Collections.Generic.List[string]]::new()

function Assert([bool]$condition, [string]$message) {
    if ($condition) { Write-Host "  [PASS] $message" }
    else { Write-Host "  [FAIL] $message"; $script:failures.Add($message) }
}

$tmp = Join-Path ([System.IO.Path]::GetTempPath()) ("capture-tests-" + [guid]::NewGuid().ToString('N'))
New-Item -ItemType Directory -Path $tmp | Out-Null
$success = '{"success":true,"attemptsUsed":1,"operation_status":"Succeeded","response_error":null}'
$failed = @'
{
  "success": false,
  "attemptsUsed": 2,
  "appliedPatches": [
    {
      "FilePath": "Customize/ArmStorageModelFactory.cs",
      "Description": "Added missing constructor argument",
      "ReplacementCount": 1
    }
  ],
  "buildResult": "Failed to regenerate TypeSpec client: npm error E403",
  "response_error": "No additional patches were applied.",
  "errorCode": "PatchesFailed",
  "operation_status": "Failed"
}
'@
$npmErrors = "[npm-tsp-client] npm error code E403`n[npm-tsp-client] npm error 403 Forbidden`n"
$upgradeWarning = 'A new version of azsdk is available. Run azsdk upgrade to update.'

function Test-Capture(
    [string]$name,
    [string]$stdout,
    [string]$stderr,
    [string]$engineExit = '0',
    [int]$expectedExit = 1,
    [string]$expectedResult = '',
    [int]$maxIterations = 3,
    [string]$missingFile = ''
) {
    Write-Host "Case: $name"
    $directory = Join-Path $tmp $name
    New-Item -ItemType Directory -Path $directory | Out-Null
    foreach ($file in @{
        'engine-stdout.txt' = $stdout
        'engine-stderr.txt' = $stderr
        'engine-exit-code.txt' = $engineExit
        'result.json' = $success
    }.GetEnumerator()) {
        if ($file.Key -ne $missingFile) {
            [System.IO.File]::WriteAllText((Join-Path $directory $file.Key), $file.Value)
        }
    }
    $output = & pwsh -NoProfile -File $CapturePath -ResultsDir $directory -MaxIterations $maxIterations 2>&1 | Out-String
    $actualExit = $LASTEXITCODE
    Assert ($actualExit -eq $expectedExit) "$name preserves the expected exit code ($expectedExit)"
    $resultPath = Join-Path $directory 'result.json'
    if ($expectedResult) {
        Assert (Test-Path -LiteralPath $resultPath) "$name captures the response"
        if (Test-Path -LiteralPath $resultPath) {
            Assert ([System.IO.File]::ReadAllText($resultPath) -ceq $expectedResult) "$name preserves the original response text"
        }
    }
    else {
        Assert (-not (Test-Path -LiteralPath $resultPath)) "$name cannot retain a stale success result"
        Assert ($output -match 'Engine response capture failed:') "$name surfaces the capture error"
        Assert ((Get-Content -Raw (Join-Path $directory 'engine-errors.txt')) -match 'Engine response capture failed:') `
            "$name retains the capture error for reporting"
    }
    foreach ($stream in @('stdout', 'stderr')) {
        $path = Join-Path $directory "engine-$stream.txt"
        if (Test-Path -LiteralPath $path) {
            $original = if ($stream -eq 'stdout') { $stdout } else { $stderr }
            Assert ([System.IO.File]::ReadAllText($path) -ceq $original) "$name preserves raw $stream"
        }
    }
    return $directory
}

try {
    Test-Capture 'success-stdout' $success 'warning' -expectedExit 0 -expectedResult $success | Out-Null
    Test-Capture 'failed-stderr-after-npm' '' "$npmErrors$failed" -engineExit 1 -expectedResult $failed | Out-Null
    Test-Capture 'stderr-trailing-log' '' "$failed`n$upgradeWarning" -engineExit 1 -expectedResult $failed | Out-Null
    Test-Capture 'stderr-prefix-and-suffix' '' "$npmErrors$failed`n$upgradeWarning" -engineExit 1 -expectedResult $failed | Out-Null
    Test-Capture 'stderr-trailing-json-log' '' "$failed`n{`"message`":`"$upgradeWarning`"}" -engineExit 1 -expectedResult $failed | Out-Null
    Test-Capture 'stderr-trailing-warning-crlf' '' "$failed`r`n$upgradeWarning`r`n" -engineExit 7 -expectedExit 7 -expectedResult $failed | Out-Null
    Test-Capture 'failed-stdout' $failed $npmErrors -engineExit 1 -expectedResult $failed | Out-Null
    Test-Capture 'failure-exit-seven' '' $failed -engineExit 7 -expectedExit 7 -expectedResult $failed | Out-Null
    Test-Capture 'whitespace' " `r`n$success`r`n " '' -expectedExit 0 -expectedResult $success | Out-Null
    $escaped = '{"success":false,"attemptsUsed":0,"buildResult":"Braces { } and escaped quote \" and slash \\"}'
    Test-Capture 'escaped-string-braces' '' $escaped -engineExit 1 -expectedResult $escaped | Out-Null
    Test-Capture 'unrelated-json-log' '' "{`"message`":`"log { }`"}`n$failed" -engineExit 1 -expectedResult $failed | Out-Null
    foreach ($newline in @("`n", "`r`n")) {
        $newlineName = if ($newline -eq "`n") { 'lf' } else { 'crlf' }
        $index = 0
        foreach ($wrapper in @(
            "[$newline  $failed$newline]",
            "[[$newline  $failed$newline]]",
            "[0,$newline  $failed$newline]",
            "[true, false, null,$newline  $failed$newline]",
            "[$newline  $failed,$newline  $failed$newline]",
            "[`"Brackets [ ] and braces { }`",$newline  $failed$newline]",
            "[`"Escaped quote \`" and slash \\`",$newline  $failed$newline]"
        )) {
            $name = "wrapped-array-$newlineName-$index"
            Test-Capture "$name-stderr" '' "$npmErrors$wrapper$newline$upgradeWarning" -engineExit 1 | Out-Null
            Test-Capture "$name-stdout" $wrapper '' -engineExit 1 | Out-Null
            $index++
        }
    }
    Test-Capture 'stderr-array-review-repro' '' "[`n {`"success`":false,`"attemptsUsed`":2}`n]" -engineExit 1 | Out-Null
    Test-Capture 'stdout-success-array' "[`n $success`n]" '' | Out-Null
    Test-Capture 'stderr-success-array' '' "[`n $success`n]" | Out-Null
    Test-Capture 'stderr-unclosed-array' '' "[`n $failed" -engineExit 1 | Out-Null
    Test-Capture 'stderr-mismatched-array' '' "[`n $failed`n}" -engineExit 1 | Out-Null
    Test-Capture 'stderr-malformed-array' '' "[invalid,`n $failed`n]" -engineExit 1 | Out-Null
    Test-Capture 'stderr-trailing-malformed-array' '' "$failed`n[`n {`"message`":`"log`"}," -engineExit 1 | Out-Null
    $arrayLog = "[`n {`"message`":`"Brackets [ ] and braces { }`",`"values`":[[],[1,true,null]]}`n]"
    Test-Capture 'stderr-array-diagnostics' '' "$npmErrors$arrayLog`n$failed`n$arrayLog`n$upgradeWarning" `
        -engineExit 1 -expectedResult $failed | Out-Null
    Test-Capture 'stderr-nested-response-array-log' '' "[`n $failed`n]`n$failed`n[`n $failed`n]" `
        -engineExit 1 -expectedResult $failed | Out-Null
    Test-Capture 'stdout-success-with-stderr-array-log' $success $arrayLog -expectedExit 0 -expectedResult $success | Out-Null
    Test-Capture 'stderr-tagged-diagnostics' '' "[INFO] starting`n[12:34:56] diagnostic`n$npmErrors$failed`n[warn] $upgradeWarning" `
        -engineExit 1 -expectedResult $failed | Out-Null
    Test-Capture 'stderr-empty-array-log' '' "[]`n$failed`n[]" -engineExit 1 -expectedResult $failed | Out-Null
    foreach ($bound in @(1, 3, 10)) {
        $response = "{`"success`":true,`"attemptsUsed`":$bound}"
        Test-Capture "bound-$bound" $response '' -maxIterations $bound -expectedExit 0 -expectedResult $response | Out-Null
    }
    $zero = '{"success":true,"attemptsUsed":0}'
    Test-Capture 'zero-attempts' $zero '' -expectedExit 0 -expectedResult $zero | Out-Null
    foreach ($outcome in @('true', 'false')) {
        $engineExit = if ($outcome -eq 'true') { 0 } else { 1 }
        foreach ($fields in @('', ',"operation_status":null,"response_error":null', ',"response_error":""')) {
            $response = "{`"success`":$outcome,`"attemptsUsed`":0$fields}"
            $stdout = if ($outcome -eq 'true') { $response } else { '' }
            $stderr = if ($outcome -eq 'false') { $response } else { '' }
            Test-Capture "optional-fields-$outcome-$($fields.Length)" $stdout $stderr `
                -engineExit $engineExit -expectedExit $engineExit -expectedResult $response | Out-Null
        }
        $invalidFields = @(
            @{ operation_status = 'true' },
            @{ operation_status = '1' },
            @{ operation_status = '[]' },
            @{ operation_status = '{}' },
            @{ operation_status = '""' },
            @{ operation_status = '"Pending"' },
            @{ operation_status = $(if ($outcome -eq 'true') { '"Failed"' } else { '"Succeeded"' }) },
            @{ response_error = 'true' },
            @{ response_error = '1' },
            @{ response_error = '[]' },
            @{ response_error = '{}' }
        )
        for ($index = 0; $index -lt $invalidFields.Count; $index++) {
            $field = @($invalidFields[$index].GetEnumerator())[0]
            $response = "{`"success`":$outcome,`"attemptsUsed`":0,`"$($field.Key)`":$($field.Value)}"
            $stdout = if ($outcome -eq 'true') { $response } else { '' }
            $stderr = if ($outcome -eq 'false') { $response } else { '' }
            Test-Capture "invalid-$outcome-$($field.Key)-$index" $stdout $stderr -engineExit $engineExit | Out-Null
        }
    }
    foreach ($case in @(
        @{ name = 'missing-response'; stdout = ''; stderr = $npmErrors },
        @{ name = 'malformed'; stdout = '{"success":true,}'; stderr = '' },
        @{ name = 'unterminated'; stdout = '{"success":true'; stderr = '' },
        @{ name = 'array'; stdout = "[$success]"; stderr = '' },
        @{ name = 'null'; stdout = 'null'; stderr = '' },
        @{ name = 'log-only-json'; stdout = '{"message":"diagnostic"}'; stderr = '' },
        @{ name = 'two-stdout-responses'; stdout = "$success`n$success"; stderr = '' },
        @{ name = 'two-stderr-responses'; stdout = ''; stderr = "$failed`n$failed"; engineExit = '1' },
        @{ name = 'both-stream-responses'; stdout = $success; stderr = $failed },
        @{ name = 'trailing-log'; stdout = "$success`ntrailing"; stderr = '' },
        @{ name = 'failed-stdout-trailing-log'; stdout = "$failed`n$upgradeWarning"; stderr = ''; engineExit = '1' },
        @{ name = 'stderr-trailing-second-response'; stdout = ''; stderr = "$failed`n$upgradeWarning`n$failed"; engineExit = '1' },
        @{ name = 'stderr-trailing-malformed-response'; stdout = ''; stderr = "$failed`n$upgradeWarning`n{`"success`":false,}"; engineExit = '1' },
        @{ name = 'stderr-trailing-unterminated-response'; stdout = ''; stderr = "$failed`n$upgradeWarning`n{`"success`":false"; engineExit = '1' },
        @{ name = 'stdout-log-prefix'; stdout = "diagnostic`n$success"; stderr = '' },
        @{ name = 'stderr-response-and-stdout-log'; stdout = 'diagnostic'; stderr = $failed; engineExit = '1' },
        @{ name = 'success-on-stderr'; stdout = ''; stderr = $success },
        @{ name = 'successful-json-failed-process'; stdout = $success; stderr = ''; engineExit = '1' },
        @{ name = 'failed-json-successful-process'; stdout = $failed; stderr = '' },
        @{ name = 'missing-success'; stdout = '{"attemptsUsed":0}'; stderr = '' },
        @{ name = 'string-success'; stdout = '{"success":"true","attemptsUsed":0}'; stderr = '' },
        @{ name = 'numeric-success'; stdout = '{"success":1,"attemptsUsed":0}'; stderr = '' },
        @{ name = 'null-success'; stdout = '{"success":null,"attemptsUsed":0}'; stderr = '' },
        @{ name = 'duplicate-success'; stdout = '{"success":false,"success":true,"attemptsUsed":0}'; stderr = '' },
        @{ name = 'case-duplicate-success'; stdout = '{"Success":false,"success":true,"attemptsUsed":0}'; stderr = '' },
        @{ name = 'missing-attempts'; stdout = '{"success":true}'; stderr = '' },
        @{ name = 'string-attempts'; stdout = '{"success":true,"attemptsUsed":"1"}'; stderr = '' },
        @{ name = 'fractional-attempts'; stdout = '{"success":true,"attemptsUsed":1.5}'; stderr = '' },
        @{ name = 'negative-attempts'; stdout = '{"success":true,"attemptsUsed":-1}'; stderr = '' },
        @{ name = 'excess-attempts'; stdout = '{"success":true,"attemptsUsed":4}'; stderr = '' },
        @{ name = 'overflow-attempts'; stdout = '{"success":true,"attemptsUsed":2147483648}'; stderr = '' },
        @{ name = 'contradictory-status'; stdout = '{"success":true,"attemptsUsed":1,"operation_status":"Failed"}'; stderr = '' },
        @{ name = 'contradictory-error'; stdout = '{"success":true,"attemptsUsed":1,"response_error":"failure"}'; stderr = '' },
        @{ name = 'invalid-status-type'; stdout = '{"success":true,"attemptsUsed":1,"operation_status":true}'; stderr = '' },
        @{ name = 'invalid-error-type'; stdout = '{"success":true,"attemptsUsed":1,"response_error":false}'; stderr = '' },
        @{ name = 'invalid-exit'; stdout = $success; stderr = ''; engineExit = 'unknown' },
        @{ name = 'negative-exit'; stdout = $success; stderr = ''; engineExit = '-1' },
        @{ name = 'overflow-exit'; stdout = $success; stderr = ''; engineExit = '256' },
        @{ name = 'missing-stdout'; stdout = $success; stderr = ''; missingFile = 'engine-stdout.txt' },
        @{ name = 'missing-stderr'; stdout = $success; stderr = ''; missingFile = 'engine-stderr.txt' },
        @{ name = 'missing-exit'; stdout = $success; stderr = ''; missingFile = 'engine-exit-code.txt' }
    )) {
        Test-Capture @case | Out-Null
    }

    $failedDirectory = Join-Path $tmp 'stderr-prefix-and-suffix'
    $reportPath = Join-Path $tmp 'report.md'
    & pwsh -NoProfile -File $EmitterPath -ResultsDir $failedDirectory `
        -EngineErrorsFile (Join-Path $failedDirectory 'engine-errors.txt') `
        -RepoRoot $tmp -Repo 'Azure/azure-sdk-for-net' -Pr 63564 -HeadSha '32b4580' `
        -PackagePath 'sdk/storage/Azure.ResourceManager.Storage' -OutFile $reportPath | Out-Null
    Assert ($LASTEXITCODE -eq 0) 'captured failed response renders successfully'
    $report = Get-Content -Raw $reportPath
    Assert ($report -match 'PatchesFailed' -and $report -match 'npm error E403') 'report retains the actual engine failure and regeneration error'
    Assert ($report -match '2 of 3') 'report shows the actual 2 of 3 attempts'
    Assert ($report.Contains($upgradeWarning)) 'report preserves trailing upgrade diagnostics'
    Assert ($report -notmatch 'MalformedEngineResult|Unknown of 3') 'report no longer misclassifies failed stderr JSON'
    Assert ($report -match '"status":"failed"' -and $report -match 'changes are not eligible for publication') `
        'captured failed response remains ineligible for publication'

    $arrayDirectory = Join-Path $tmp 'stderr-array-review-repro'
    & pwsh -NoProfile -File $EmitterPath -ResultsDir $arrayDirectory `
        -EngineErrorsFile (Join-Path $arrayDirectory 'engine-errors.txt') `
        -RepoRoot $tmp -Repo 'Azure/azure-sdk-for-net' -Pr 63564 -HeadSha '32b4580' `
        -PackagePath 'sdk/storage/Azure.ResourceManager.Storage' -OutFile $reportPath | Out-Null
    Assert ($LASTEXITCODE -eq 0) 'rejected array response renders a failure report'
    $report = Get-Content -Raw $reportPath
    Assert ($report -match 'NoEngineResult' -and $report -match 'Engine response capture failed:') `
        'array rejection and capture diagnostics remain visible in the report'
    Assert ($report -match 'Unknown of 3' -and $report -notmatch '2 of 3') `
        'report does not promote the nested attempt count'
    Assert ($report -match '"status":"failed"' -and $report -match 'changes are not eligible for publication') `
        'rejected array cannot authorize publication'
}
finally {
    Remove-Item -LiteralPath $tmp -Recurse -Force
}

if ($failures.Count -gt 0) { Write-Error "$($failures.Count) assertion(s) failed." }
Write-Host 'All response-capture assertions passed.'
