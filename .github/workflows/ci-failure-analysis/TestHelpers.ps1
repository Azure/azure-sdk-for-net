#Requires -Version 7.5

# Copyright (c) Microsoft Corporation. All rights reserved.
# Licensed under the MIT License.

function Copy-TestJson {
    param($Value)

    return ,(ConvertFrom-CiJson (ConvertTo-CiJson $Value))
}

function New-CiFixture {
    param([string]$Directory)

    $check = @{
        id = 123
        name = 'net - pullrequest'
        status = 'completed'
        conclusion = 'failure'
        head_sha = 'a' * 40
        completed_at = '2026-09-10T18:00:00Z'
        html_url = 'https://dev.azure.com/azure-sdk/public/_build/results?buildId=456'
        pull_requests = @(@{ number = 42 })
    }
    $pr = @{
        number = 42
        state = 'open'
        draft = $false
        head = @{ sha = $check.head_sha }
        base = @{ repo = @{ id = 789 } }
        updated_at = $check.completed_at
    }
    $context = @{
        eventName = 'check_run'
        payload = @{ action = 'completed'; repository = @{ id = 789 }; check_run = Copy-TestJson $check }
        repo = @{ owner = 'Azure'; repo = 'azure-sdk-for-net' }
        serverUrl = 'https://github.com'
        apiUrl = 'https://api.github.com'
        runId = 1000
        runAttempt = 1
    }
    $state = @{
        check = $check
        prs = [System.Collections.Generic.List[object]]::new()
        claims = [System.Collections.Generic.List[object]]::new()
        comments = [System.Collections.Generic.List[object]]::new()
        calls = [System.Collections.Generic.List[object]]::new()
        failureOperation = ''
        failureMessage = 'GitHub unavailable'
    }
    $state.prs.Add($pr)
    return @{
        Context = $context
        State = $state
        Directory = $Directory
        EventPath = Join-Path $Directory 'event.json'
        OutputPath = Join-Path $Directory 'github-output.txt'
        AgentOutputPath = Join-Path $Directory 'agent-output.json'
    }
}

function Write-TestJson {
    param([string]$Path, $Value)

    [IO.File]::WriteAllText($Path, (ConvertTo-CiJson $Value), [Text.UTF8Encoding]::new($false))
}

function Set-TestEnvironment {
    param([System.Collections.IDictionary]$Values)

    $previous = @{}
    foreach ($key in $Values.Keys) {
        $previous[$key] = [Environment]::GetEnvironmentVariable($key)
        [Environment]::SetEnvironmentVariable($key, $Values[$key])
    }
    return $previous
}

function Restore-TestEnvironment {
    param([System.Collections.IDictionary]$Values)

    foreach ($key in $Values.Keys) {
        [Environment]::SetEnvironmentVariable($key, $Values[$key])
    }
}

function Set-CiFixtureEnvironment {
    param($Fixture)

    Write-TestJson $Fixture.EventPath $Fixture.Context.payload
    return Set-TestEnvironment @{
        GITHUB_EVENT_PATH = $Fixture.EventPath
        GITHUB_EVENT_NAME = $Fixture.Context.eventName
        GITHUB_REPOSITORY = "$($Fixture.Context.repo.owner)/$($Fixture.Context.repo.repo)"
        GITHUB_SERVER_URL = $Fixture.Context.serverUrl
        GITHUB_API_URL = $Fixture.Context.apiUrl
        GITHUB_RUN_ID = [string]$Fixture.Context.runId
        GITHUB_RUN_ATTEMPT = [string]$Fixture.Context.runAttempt
        GITHUB_OUTPUT = $Fixture.OutputPath
        GITHUB_TOKEN = 'offline-test-token'
        ANALYSIS_CONTEXT = $null
        ANALYSIS_RESULT = $null
        AGENT_OUTPUT = $Fixture.AgentOutputPath
    }
}

function Get-CiTestOutputs {
    param($Fixture)

    $values = @{}
    foreach ($line in [IO.File]::ReadAllLines($Fixture.OutputPath)) {
        $key, $value = $line.Split('=', 2)
        $values[$key] = $value
    }
    return $values
}

function Invoke-FakeCiRequest {
    param($State, [string]$Uri, [string]$Method, $Headers, $Body, $ContentType, $MaximumRedirection)

    $url = [uri]$Uri
    $path = $url.AbsolutePath -replace '^.*?/repos/Azure/azure-sdk-for-net', ''
    $args = if ($null -ne $Body) {
        ConvertFrom-CiJson ([Text.Encoding]::UTF8.GetString($Body))
    } else {
        @{}
    }
    $operation = switch -Regex ("$Method $path") {
        '^GET /check-runs/\d+$' { 'checks.get'; break }
        '^GET /commits/[a-f0-9]+/check-runs$' { 'checks.listForRef'; break }
        '^POST /check-runs$' { 'checks.create'; break }
        '^PATCH /check-runs/\d+$' { 'checks.update'; break }
        '^GET /pulls/\d+$' { 'pulls.get'; break }
        '^GET /pulls$' { 'pulls.list'; break }
        '^GET /issues/\d+/comments$' { 'issues.listComments'; break }
        default { throw "Unexpected offline API request: $Method $Uri" }
    }
    $State.calls.Add(@{
        name = $operation; args = $args; uri = $url.AbsoluteUri; method = $Method
        headers = $Headers; contentType = $ContentType; bodyBytes = $Body; maximumRedirection = $MaximumRedirection
    })
    if ($operation -ceq $State.failureOperation) {
        throw $State.failureMessage
    }
    switch ($operation) {
        'checks.get' {
            $id = [long]($path.Split('/')[-1])
            $data = if ($id -eq $State.check.id) { $State.check } else { $State.claims | Where-Object { $_.id -eq $id } }
            if (!$data) { throw "Unexpected check ID $id" }
        }
        'checks.listForRef' { $data = @{ check_runs = $State.claims.ToArray() } }
        'checks.create' {
            $data = Copy-TestJson $args
            $data['id'] = 900 + $State.claims.Count
            $State.claims.Add($data)
        }
        'checks.update' {
            $id = [long]($path.Split('/')[-1])
            $data = $State.claims | Where-Object { $_.id -eq $id }
            if (!$data) { throw "Unexpected check ID $id" }
            foreach ($key in $args.Keys) { $data[$key] = $args[$key] }
        }
        'pulls.get' {
            $id = [long]($path.Split('/')[-1])
            $data = $State.prs | Where-Object { $_.number -eq $id }
            if (!$data) { throw 'PR not found' }
        }
        'pulls.list' { $data = $State.prs.ToArray() }
        'issues.listComments' { $data = $State.comments.ToArray() }
    }
    return @{ Content = ConvertTo-CiJson $data; Headers = @{} }
}

function New-CiPrepared {
    param($Fixture)

    $prepared = Initialize-CiFailureAnalysis -Context $Fixture.Context
    $prepared.eligible | Should -BeTrue
    $prepared.prNumber | Should -Be 42
    $Fixture.State.claims.Count | Should -Be 1
    return $prepared
}

function New-CiAgentOutput {
    param([int]$PrNumber = 42)

    return @{ items = @(@{ type = 'add_comment'; body = "## 🔍 CI Failure Analysis for PR #$PrNumber`n`nActual error: error CS1002." }) }
}

function New-CiPostedComment {
    param([string]$Body)

    return @{ id = 600; body = $Body; user = @{ login = 'github-actions[bot]'; type = 'Bot' } }
}

function Add-CiPublishedReport {
    param($Fixture, $Prepared)

    $result = Protect-CiAnalysisOutput -Context $Fixture.Context -Prepared $Prepared -AgentOutput (New-CiAgentOutput)
    $Fixture.State.comments.Add((New-CiPostedComment $result.agentOutput.items[0].body))
}

function Get-CiWorkflowLines {
    param([string]$Name)

    return ,([IO.File]::ReadAllLines((Join-Path $PSScriptRoot '..' $Name)))
}

function Get-CiYamlValue {
    param([string[]]$Lines, [int]$Index)

    if ($Index -lt 0 -or $Index -ge $Lines.Count) {
        throw 'Missing YAML value.'
    }
    $indent = $Lines[$Index].Length - $Lines[$Index].TrimStart().Length
    $value = $Lines[$Index].Substring($Lines[$Index].IndexOf(':') + 1).Trim()
    if ($value -cin @('|', '>')) {
        $block = [System.Collections.Generic.List[string]]::new()
        for ($i = $Index + 1; $i -lt $Lines.Count; $i++) {
            $line = $Lines[$i]
            if ($line.Trim() -and $line.Length - $line.TrimStart().Length -le $indent) { break }
            $block.Add($(if ($line.Length -ge $indent + 2) { $line.Substring($indent + 2) } else { '' }))
        }
        return ($block -join $(if ($value -ceq '>') { ' ' } else { "`n" })).TrimEnd()
    }
    if (($value.StartsWith("'") -and $value.EndsWith("'")) -or ($value.StartsWith('"') -and $value.EndsWith('"'))) {
        return $value.Substring(1, $value.Length - 2)
    }
    return $value
}

function Get-CiJobLines {
    param([string[]]$Lines, [string]$Name)

    $start = [array]::IndexOf($Lines, "  ${Name}:")
    if ($start -lt 0) { throw "Missing job: $Name" }
    $end = $start + 1
    while ($end -lt $Lines.Count -and $Lines[$end] -cnotmatch '^  \S') { $end++ }
    return ,$Lines[($start + 1)..($end - 1)]
}

function Get-CiYamlProperty {
    param([string[]]$Lines, [string]$Name)

    for ($i = 0; $i -lt $Lines.Count; $i++) {
        if ($Lines[$i].TrimStart().StartsWith("${Name}:", [StringComparison]::Ordinal)) {
            return Get-CiYamlValue $Lines $i
        }
    }
    throw "Missing YAML property: $Name"
}

function Invoke-CiWorkflowExpression {
    param([string]$Expression, [System.Collections.IDictionary]$Values)

    $expression = $Expression.Trim() -replace '^\$\{\{\s*|\s*\}\}$', ''
    $path = '(?:github|needs|steps|inputs)(?:\.[A-Za-z_][A-Za-z0-9_-]*)+'
    $pattern = "\G\s*(?<token>fromJSON\($path\)(?:\.[A-Za-z_][A-Za-z0-9_-]*)*|$path|'(?:[^']|'')*'|==|!=|&&|\|\||[()!]|true\b|false\b|null\b|\d+)\s*"
    $position = 0
    $translated = [System.Collections.Generic.List[string]]::new()
    foreach ($match in [regex]::Matches($expression, $pattern)) {
        if ($match.Index -ne $position) { throw "Unsupported workflow expression: $Expression" }
        $token = $match.Groups['token'].Value
        $translated.Add($(switch -Regex -CaseSensitive ($token) {
            '^fromJSON\(([^)]+)\)(.*)$' {
                $argument = ($Matches[1].Split('.') | ForEach-Object { "'$_'" }) -join '.'
                '(ConvertFrom-CiJson -Json $Values.' + $argument + ')' + $Matches[2]
                break
            }
            '^(github|needs|steps|inputs)\.' { '$Values.' + (($token.Split('.') | ForEach-Object { "'$_'" }) -join '.'); break }
            '^==$' { '-eq'; break }
            '^!=$' { '-ne'; break }
            '^&&$' { '-and'; break }
            '^\|\|$' { '-or'; break }
            '^!$' { '-not'; break }
            '^(true|false|null)$' { '$' + $token; break }
            default { $token }
        }))
        $position += $match.Length
    }
    if ($position -ne $expression.Length -or $position -eq 0) {
        throw "Unsupported workflow expression: $Expression"
    }
    return & ([scriptblock]::Create('param($Values) ' + ($translated -join ' '))) $Values
}

function Get-CiWorkflowStep {
    param([string]$Filename, [string]$Name)

    $lines = Get-CiWorkflowLines $Filename
    $start = -1
    for ($i = 0; $i -lt $lines.Count; $i++) {
        if ($lines[$i].Trim() -ceq "- name: $Name") { $start = $i; break }
    }
    if ($start -lt 0) { throw "Missing step: $Name" }
    $indent = $lines[$start].Length - $lines[$start].TrimStart().Length
    $step = @{ Environment = @{}; Run = $null; Shell = $null }
    for ($i = $start + 1; $i -lt $lines.Count; $i++) {
        $line = $lines[$i]
        $depth = $line.Length - $line.TrimStart().Length
        if ($line.Trim() -and $depth -le $indent) { break }
        if ($depth -ne $indent + 2) { continue }
        if ($line.TrimStart().StartsWith('run:', [StringComparison]::Ordinal)) {
            $step.Run = Get-CiYamlValue $lines $i
        } elseif ($line.TrimStart().StartsWith('shell:', [StringComparison]::Ordinal)) {
            $step.Shell = Get-CiYamlValue $lines $i
        } elseif ($line.Trim() -ceq 'env:') {
            for ($j = $i + 1; $j -lt $lines.Count; $j++) {
                $entry = $lines[$j]
                if (!$entry.Trim()) { continue }
                if ($entry.Length - $entry.TrimStart().Length -le $depth) { break }
                $key = $entry.Trim().Split(':', 2)[0]
                $step.Environment[$key] = Get-CiYamlValue $lines $j
            }
        }
    }
    if (!$step.Run) { throw "Missing run block: $Name" }
    return $step
}

function Invoke-CiWorkflowStep {
    param([string]$Filename, [string]$Name, $Fixture, $Prepared, [string]$AnalysisResult = 'success')

    $step = Get-CiWorkflowStep $Filename $Name
    $step.Shell | Should -BeExactly 'pwsh'
    $values = @{
        github = @{ token = 'offline-workflow-token' }
        inputs = @{ analysis_context = ConvertTo-CiJson $Prepared }
        needs = @{
            prepare = @{ outputs = @{ analysis_context = ConvertTo-CiJson $Prepared } }
            analyze = @{ result = $AnalysisResult }
        }
        steps = @{ 'setup-agent-output-env' = @{ outputs = @{ GH_AW_AGENT_OUTPUT = $Fixture.AgentOutputPath } } }
    }
    $environment = @{}
    foreach ($key in $step.Environment.Keys) {
        $environment[$key] = Invoke-CiWorkflowExpression $step.Environment[$key] $values
    }
    $previous = Set-TestEnvironment $environment
    Push-Location (Join-Path $PSScriptRoot '..' '..' '..')
    try {
        & ([scriptblock]::Create($step.Run))
    } finally {
        Pop-Location
        Restore-TestEnvironment $previous
    }
}

function Invoke-CiTestProcess {
    param([string]$FilePath, [string[]]$Arguments, [System.Collections.IDictionary]$Environment, [string]$Directory)

    $start = [Diagnostics.ProcessStartInfo]::new($FilePath)
    $start.UseShellExecute = $false
    $start.RedirectStandardOutput = $true
    $start.RedirectStandardError = $true
    $start.StandardOutputEncoding = [Text.Encoding]::UTF8
    $start.StandardErrorEncoding = [Text.Encoding]::UTF8
    foreach ($argument in $Arguments) { $start.ArgumentList.Add($argument) }
    foreach ($key in $Environment.Keys) { $start.Environment[$key] = $Environment[$key] }
    foreach ($key in @('TEMP', 'TMP', 'TMPDIR')) { $start.Environment[$key] = $Directory }
    $start.WorkingDirectory = $Directory
    $process = [Diagnostics.Process]::Start($start)
    try {
        $stdout = $process.StandardOutput.ReadToEndAsync()
        $stderr = $process.StandardError.ReadToEndAsync()
        if (!$process.WaitForExit(30000)) {
            $process.Kill($true)
            throw 'Test subprocess timed out.'
        }
        return @{ ExitCode = $process.ExitCode; Stdout = $stdout.GetAwaiter().GetResult(); Stderr = $stderr.GetAwaiter().GetResult() }
    } finally {
        $process.Dispose()
    }
}
