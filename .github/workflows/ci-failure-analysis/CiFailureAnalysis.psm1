#Requires -Version 7.5

# Copyright (c) Microsoft Corporation. All rights reserved.
# Licensed under the MIT License.

$ErrorActionPreference = 'Stop'
$script:CheckName = 'Azure .NET CI Failure Analysis'

function ConvertFrom-CiJson {
    param([Parameter(Mandatory)][AllowEmptyString()][string]$Json)

    return ,(ConvertFrom-Json -InputObject $Json -AsHashtable -NoEnumerate -DateKind String -Depth 100)
}

function ConvertTo-CiJson {
    param([Parameter(Mandatory)][AllowNull()]$Value)

    return ConvertTo-Json -InputObject $Value -Depth 100 -Compress
}

function Test-CiNumber {
    param($Value)

    return $Value -is [byte] -or $Value -is [sbyte] -or
        $Value -is [int16] -or $Value -is [uint16] -or
        $Value -is [int32] -or $Value -is [uint32] -or
        $Value -is [int64] -or $Value -is [uint64] -or
        $Value -is [single] -or $Value -is [double] -or $Value -is [decimal]
}

function Get-CiPositiveInteger {
    param($Value, [string]$Name)

    if (!(Test-CiNumber $Value) -or $Value -le 0 -or $Value -gt 9007199254740991 -or
        [double]::IsNaN($Value) -or [math]::Truncate($Value) -ne $Value) {
        throw "Invalid $Name."
    }
    return $Value
}

function Test-CiEqual {
    param($Left, $Right)

    if ($null -eq $Left -or $null -eq $Right) {
        return $null -eq $Left -and $null -eq $Right
    }
    if ($Left -is [string] -and $Right -is [string]) {
        return [string]::Equals($Left, $Right, [StringComparison]::Ordinal)
    }
    if ($Left -is [bool] -and $Right -is [bool]) {
        return $Left -eq $Right
    }
    if ((Test-CiNumber $Left) -and (Test-CiNumber $Right)) {
        return $Left -eq $Right
    }
    return $false
}

function Get-CiEnvironmentInteger {
    param([string]$Value, [string]$Name)

    $number = 0L
    if ($Value -cnotmatch '^[1-9][0-9]*$' -or ![long]::TryParse($Value, [ref]$number)) {
        throw "Invalid $Name."
    }
    return Get-CiPositiveInteger $number $Name
}

function Get-CiContext {
    if (!$env:GITHUB_EVENT_PATH) {
        throw 'Missing GITHUB_EVENT_PATH.'
    }
    if ($env:GITHUB_REPOSITORY -cnotmatch '^[A-Za-z0-9_.-]+/[A-Za-z0-9_.-]+$') {
        throw 'Invalid GITHUB_REPOSITORY.'
    }
    $repository = $env:GITHUB_REPOSITORY.Split('/')
    $payload = ConvertFrom-CiJson ([IO.File]::ReadAllText($env:GITHUB_EVENT_PATH))
    if ($payload -isnot [System.Collections.IDictionary]) {
        throw 'Invalid GitHub event payload.'
    }
    return @{
        eventName = $env:GITHUB_EVENT_NAME
        payload = $payload
        repo = @{ owner = $repository[0]; repo = $repository[1] }
        serverUrl = $(if ($env:GITHUB_SERVER_URL) { $env:GITHUB_SERVER_URL } else { 'https://github.com' })
        apiUrl = $(if ($env:GITHUB_API_URL) { $env:GITHUB_API_URL } else { 'https://api.github.com' })
        runId = Get-CiEnvironmentInteger $env:GITHUB_RUN_ID 'workflow run ID'
        runAttempt = Get-CiEnvironmentInteger $(if ($env:GITHUB_RUN_ATTEMPT) { $env:GITHUB_RUN_ATTEMPT } else { '1' }) 'workflow run attempt'
    }
}

function Set-CiOutput {
    param([string]$Name, [string]$Value)

    if (!$env:GITHUB_OUTPUT) {
        throw 'Missing GITHUB_OUTPUT.'
    }
    if ($Name -cnotmatch '^[a-z_]+$' -or $Value.Contains("`r") -or $Value.Contains("`n")) {
        throw 'Invalid GitHub output.'
    }
    [IO.File]::AppendAllText($env:GITHUB_OUTPUT, "$Name=$Value`n", [Text.UTF8Encoding]::new($false))
}

function Invoke-CiApi {
    param($Context, [string]$Path, [string]$Method = 'GET', $Body)

    if (!$env:GITHUB_TOKEN) {
        throw 'Missing GITHUB_TOKEN.'
    }
    $base = [uri]($Context.apiUrl.TrimEnd('/') + '/')
    $uri = [uri]::new($base, $Path)
    if ($uri.Scheme -cne $base.Scheme -or $uri.Authority -cne $base.Authority -or
        !$uri.AbsolutePath.StartsWith($base.AbsolutePath, [StringComparison]::Ordinal) -or $uri.UserInfo) {
        throw 'Invalid GitHub API pagination URL.'
    }
    $parameters = @{
        Uri = $uri.AbsoluteUri
        Method = $Method
        Headers = @{
            Authorization = "Bearer $env:GITHUB_TOKEN"
            Accept = 'application/vnd.github+json'
            'X-GitHub-Api-Version' = '2022-11-28'
            'User-Agent' = 'azure-sdk-ci-failure-analysis'
        }
        MaximumRedirection = 0
        ErrorAction = 'Stop'
    }
    if ($null -ne $Body) {
        $parameters.ContentType = 'application/json; charset=utf-8'
        $parameters.Body = [Text.Encoding]::UTF8.GetBytes((ConvertTo-CiJson $Body))
    }
    # Invoke-RestMethod parses timestamps before the caller can preserve their original strings.
    $response = Invoke-WebRequest @parameters
    return @{
        data = ConvertFrom-CiJson $response.Content
        headers = $response.Headers
    }
}

function Get-CiCollection {
    param($Context, [string]$Path, [string]$Property)

    $items = [System.Collections.Generic.List[object]]::new()
    $visited = [System.Collections.Generic.HashSet[string]]::new([StringComparer]::Ordinal)
    do {
        if (!$visited.Add($Path)) {
            throw 'Repeated GitHub API pagination URL.'
        }
        $page = Invoke-CiApi -Context $Context -Path $Path
        if ($Property) {
            $values = $page.data[$Property]
        } else {
            $values = $page.data
        }
        if ($values -isnot [array]) {
            throw 'Malformed GitHub API collection.'
        }
        foreach ($value in $values) {
            $items.Add($value)
        }
        $link = $page.headers['Link'] -join ','
        $Path = $null
        if ($link -cmatch '<([^>]+)>\s*;\s*rel="?next"?(?:[,;]|$)') {
            $Path = $Matches[1]
        }
    } while ($Path)
    return ,$items.ToArray()
}

function Get-CiRepoPath {
    param($Context)

    return "repos/$($Context.repo.owner)/$($Context.repo.repo)"
}

function Test-CiFailureEvent {
    param($Context)

    $check = $Context.payload.check_run
    return (Test-CiEqual $Context.eventName 'check_run') -and
        (Test-CiEqual $Context.payload.action 'completed') -and
        (Test-CiEqual $check.name 'net - pullrequest') -and
        (Test-CiEqual $check.status 'completed') -and
        (Test-CiEqual $check.conclusion 'failure')
}

function Assert-CiEvent {
    param($Context)

    $check = $Context.payload.check_run
    $null = Get-CiPositiveInteger $check.id 'CI check run ID'
    $null = Get-CiPositiveInteger $Context.payload.repository.id 'repository ID'
    if ($check.head_sha -isnot [string] -or $check.head_sha -cnotmatch '^[0-9a-f]{40}$') {
        throw 'Invalid CI head SHA.'
    }
    $timestamp = [DateTimeOffset]::MinValue
    if ($check.completed_at -isnot [string] -or
        $check.completed_at -cnotmatch '^\d{4}-\d\d-\d\dT\d\d:\d\d:\d\d(?:\.\d+)?Z$' -or
        ![DateTimeOffset]::TryParse($check.completed_at, [Globalization.CultureInfo]::InvariantCulture,
            [Globalization.DateTimeStyles]::None, [ref]$timestamp)) {
        throw 'Invalid CI completion timestamp.'
    }
}

function Get-CiKey {
    param($Context, $PrNumber)

    $check = $Context.payload.check_run
    # Check-run events have no run_attempt; completed_at distinguishes repeated completions of the same ID.
    return "ci-failure-analysis:$($Context.payload.repository.id):${PrNumber}:$($check.head_sha):$($check.id):$($check.completed_at)"
}

function Get-CiWorkflowAttempt {
    param($Context)

    if ($null -ne $Context.runAttempt) {
        return Get-CiPositiveInteger $Context.runAttempt 'workflow run attempt'
    }
    return Get-CiEnvironmentInteger $(if ($env:GITHUB_RUN_ATTEMPT) { $env:GITHUB_RUN_ATTEMPT } else { '1' }) 'workflow run attempt'
}

function Get-CiRunUrl {
    param($Context)

    $id = Get-CiPositiveInteger $Context.runId 'workflow run ID'
    return "$($Context.serverUrl)/$($Context.repo.owner)/$($Context.repo.repo)/actions/runs/$id/attempts/$(Get-CiWorkflowAttempt $Context)"
}

function Test-CiCurrentCheck {
    param($Context, $Check)

    $event = $Context.payload.check_run
    return (Test-CiEqual $Check.id $event.id) -and
        (Test-CiEqual $Check.name $event.name) -and
        (Test-CiEqual $Check.status 'completed') -and
        (Test-CiEqual $Check.conclusion 'failure') -and
        (Test-CiEqual $Check.head_sha $event.head_sha) -and
        (Test-CiEqual $Check.completed_at $event.completed_at)
}

function Test-CiCurrentPr {
    param($Context, $Pr)

    return (Test-CiEqual $Pr.state 'open') -and
        (Test-CiEqual $Pr.draft $false) -and
        (Test-CiEqual $Pr.base.repo.id $Context.payload.repository.id) -and
        (Test-CiEqual $Pr.head.sha $Context.payload.check_run.head_sha)
}

function Test-CiReportExists {
    param($Context, $PrNumber)

    $marker = "<!-- $(Get-CiKey $Context $PrNumber) -->"
    $header = "## 🔍 CI Failure Analysis for PR #$PrNumber`n"
    $comments = Get-CiCollection -Context $Context -Path "$(Get-CiRepoPath $Context)/issues/$PrNumber/comments?per_page=100"
    foreach ($comment in $comments) {
        if ((Test-CiEqual $comment.user.login 'github-actions[bot]') -and
            (Test-CiEqual $comment.user.type 'Bot') -and $comment.body -is [string] -and
            $comment.body.StartsWith($header, [StringComparison]::Ordinal) -and
            $comment.body.Contains($marker, [StringComparison]::Ordinal)) {
            return $true
        }
    }
    return $false
}

function Initialize-CiFailureAnalysis {
    param([Parameter(Mandatory)]$Context)

    Set-CiOutput 'eligible' 'false'
    if (!(Test-CiFailureEvent $Context)) {
        Write-Host 'Skipping event: only completed, failed net - pullrequest checks are eligible.'
        return @{ eligible = $false }
    }
    Assert-CiEvent $Context
    $repoPath = Get-CiRepoPath $Context
    $check = (Invoke-CiApi -Context $Context -Path "$repoPath/check-runs/$($Context.payload.check_run.id)").data
    if (!(Test-CiCurrentCheck $Context $check)) {
        Write-Host 'Skipping a superseded CI completion.'
        return @{ eligible = $false }
    }

    $candidates = $Context.payload.check_run.pull_requests
    if (!$candidates -or $candidates.Count -eq 0) {
        $pullRequests = Get-CiCollection -Context $Context -Path "$repoPath/pulls?state=open&per_page=100"
        $candidates = @($pullRequests | Where-Object { Test-CiCurrentPr $Context $_ } |
            Sort-Object -Property updated_at -Descending -CaseSensitive -Stable)
    }

    foreach ($candidate in $candidates) {
        $prNumber = Get-CiPositiveInteger $candidate.number 'pull request number'
        $pr = (Invoke-CiApi -Context $Context -Path "$repoPath/pulls/$prNumber").data
        if (!(Test-CiCurrentPr $Context $pr)) {
            Write-Host "Skipping PR #${prNumber}: closed, draft, foreign repository, or superseded head."
            continue
        }

        $key = Get-CiKey $Context $prNumber
        $claims = Get-CiCollection -Context $Context -Property 'check_runs' -Path (
            "$repoPath/commits/$($check.head_sha)/check-runs?check_name=$([uri]::EscapeDataString($script:CheckName))&filter=all&per_page=100")
        $claimed = $false
        foreach ($claim in $claims) {
            if ((Test-CiEqual $claim.name $script:CheckName) -and (Test-CiEqual $claim.external_id $key)) {
                $claimed = $true
                break
            }
        }
        if ($claimed -or (Test-CiReportExists $Context $prNumber)) {
            Write-Host "Skipping PR #${prNumber}: this CI completion has already been claimed or reported."
            return @{ eligible = $false }
        }

        $claim = (Invoke-CiApi -Context $Context -Method 'POST' -Path "$repoPath/check-runs" -Body @{
            name = $script:CheckName
            head_sha = $check.head_sha
            external_id = $key
            status = 'in_progress'
            details_url = Get-CiRunUrl $Context
            output = @{
                title = $script:CheckName
                summary = "Analyzing failed net - pullrequest check $($check.id) completed at $($check.completed_at) for PR #$prNumber."
            }
        }).data
        $prepared = [ordered]@{
            eligible = $true
            prNumber = $prNumber
            claimId = Get-CiPositiveInteger $claim.id 'analysis check ID'
            headSha = $check.head_sha
            completedAt = $check.completed_at
            workflowRunId = $Context.runId
            workflowRunAttempt = Get-CiWorkflowAttempt $Context
        }
        Set-CiOutput 'analysis_context' (ConvertTo-CiJson $prepared)
        Set-CiOutput 'pr_number' $prNumber
        Set-CiOutput 'head_sha' $check.head_sha
        Set-CiOutput 'completed_at' $check.completed_at
        Set-CiOutput 'eligible' 'true'
        Write-Host "Claimed $key in check $($claim.id)."
        return $prepared
    }

    Write-Host 'No open, non-draft pull request matches the failed CI head.'
    return @{ eligible = $false }
}

function Get-CiOwnedClaim {
    param($Context, $Prepared)

    if (!(Test-CiFailureEvent $Context)) {
        throw 'Invalid CI failure event.'
    }
    Assert-CiEvent $Context
    $null = Get-CiPositiveInteger $Prepared.prNumber 'pull request number'
    $null = Get-CiPositiveInteger $Prepared.claimId 'analysis check ID'
    if (!(Test-CiEqual $Prepared.headSha $Context.payload.check_run.head_sha) -or
        !(Test-CiEqual $Prepared.completedAt $Context.payload.check_run.completed_at)) {
        throw 'Analysis context does not identify the triggering CI head and completion.'
    }
    if (!(Test-CiEqual $Prepared.workflowRunId $Context.runId) -or
        !(Test-CiEqual $Prepared.workflowRunAttempt (Get-CiWorkflowAttempt $Context))) {
        throw 'Analysis claim belongs to a different workflow run or attempt.'
    }
    $claim = (Invoke-CiApi -Context $Context -Path "$(Get-CiRepoPath $Context)/check-runs/$($Prepared.claimId)").data
    if (!(Test-CiEqual $claim.name $script:CheckName) -or
        !(Test-CiEqual $claim.head_sha $Context.payload.check_run.head_sha) -or
        !(Test-CiEqual $claim.external_id (Get-CiKey $Context $Prepared.prNumber)) -or
        !(Test-CiEqual $claim.details_url (Get-CiRunUrl $Context))) {
        throw 'Analysis claim does not belong to this workflow run and CI completion.'
    }
    return $claim
}

function Test-CiStillCurrent {
    param($Context, $Prepared)

    $repoPath = Get-CiRepoPath $Context
    $check = (Invoke-CiApi -Context $Context -Path "$repoPath/check-runs/$($Context.payload.check_run.id)").data
    if (!(Test-CiCurrentCheck $Context $check)) {
        return $false
    }
    $pr = (Invoke-CiApi -Context $Context -Path "$repoPath/pulls/$($Prepared.prNumber)").data
    return Test-CiCurrentPr $Context $pr
}

function Start-CiFailureAnalysis {
    param([Parameter(Mandatory)]$Context, [Parameter(Mandatory)]$Prepared)

    Set-CiOutput 'eligible' 'false'
    if (!(Test-CiFailureEvent $Context)) {
        return $false
    }
    $claim = Get-CiOwnedClaim $Context $Prepared
    if (!(Test-CiEqual $claim.status 'in_progress') -or
        !(Test-CiStillCurrent $Context $Prepared) -or
        (Test-CiReportExists $Context $Prepared.prNumber)) {
        Write-Host 'Skipping agent startup: the analysis is completed, superseded, or already reported.'
        return $false
    }
    Set-CiOutput 'eligible' 'true'
    return $true
}

function Copy-CiObject {
    param([System.Collections.IDictionary]$Value)

    $copy = [System.Collections.Specialized.OrderedDictionary]::new([StringComparer]::Ordinal)
    foreach ($entry in $Value.GetEnumerator()) {
        $copy.Add($entry.Key, $entry.Value)
    }
    return $copy
}

function Protect-CiAnalysisOutput {
    param([Parameter(Mandatory)]$Context, [Parameter(Mandatory)]$Prepared, $AgentOutput)

    $claim = Get-CiOwnedClaim $Context $Prepared
    if (!(Test-CiEqual $claim.status 'in_progress')) {
        throw 'Analysis claim is no longer active.'
    }
    if ($AgentOutput -isnot [System.Collections.IDictionary] -or
        $AgentOutput.items -isnot [array] -or $AgentOutput.items.Count -eq 0) {
        throw 'Missing or malformed CI analysis output.'
    }
    $allowed = @('add_comment', 'noop', 'report_incomplete', 'missing_data', 'missing_tool')
    foreach ($item in $AgentOutput.items) {
        if ($item -isnot [System.Collections.IDictionary] -or $item.type -isnot [string] -or $allowed -cnotcontains $item.type) {
            throw 'Unexpected CI analysis output item.'
        }
    }
    if ($AgentOutput.items.Where({ $_.type -ceq 'report_incomplete' }).Count -gt 0) {
        return @{ disposition = 'incomplete'; agentOutput = $AgentOutput }
    }
    $copy = Copy-CiObject $AgentOutput
    if (!(Test-CiStillCurrent $Context $Prepared)) {
        Write-Host 'Suppressing stale CI analysis output.'
        $copy['items'] = @(@{ type = 'noop'; message = 'The PR or CI completion is no longer current.' })
        return @{ disposition = 'skip'; agentOutput = $copy }
    }
    if (Test-CiReportExists $Context $Prepared.prNumber) {
        Write-Host 'Suppressing duplicate CI analysis output.'
        $copy['items'] = @(@{ type = 'noop'; message = 'This CI completion already has a report.' })
        return @{ disposition = 'duplicate'; agentOutput = $copy }
    }

    $comments = @($AgentOutput.items | Where-Object { $_.type -ceq 'add_comment' })
    $header = "## 🔍 CI Failure Analysis for PR #$($Prepared.prNumber)`n"
    if ($comments.Count -ne 1 -or $comments[0].body -isnot [string] -or
        !$comments[0].body.StartsWith($header, [StringComparison]::Ordinal)) {
        throw 'Expected exactly one CI failure analysis comment for the target PR.'
    }
    $marker = "<!-- $(Get-CiKey $Context $Prepared.prNumber) -->"
    $copy['items'] = @(
        foreach ($item in $AgentOutput.items) {
            if ($item.type -ceq 'add_comment') {
                $comment = Copy-CiObject $item
                $comment['body'] = "$($item.body)`n`n$marker"
                $comment
            } else {
                $item
            }
        }
    )
    return @{ disposition = 'publish'; agentOutput = $copy }
}

function Complete-CiFailureAnalysis {
    param([Parameter(Mandatory)]$Context, [Parameter(Mandatory)]$Prepared, [Parameter(Mandatory)]$JobResults)

    $claim = Get-CiOwnedClaim $Context $Prepared
    if (Test-CiEqual $claim.status 'completed') {
        return
    }
    $failedJobs = @(
        foreach ($name in $JobResults.Keys) {
            if ((Test-CiEqual $JobResults[$name] 'failure') -or (Test-CiEqual $JobResults[$name] 'cancelled')) {
                $name
            }
        }
    )
    if ($failedJobs.Count -gt 0) {
        $conclusion = 'failure'
        $summary = "CI failure analysis failed in: $($failedJobs -join ', ')."
    } elseif (!(Test-CiStillCurrent $Context $Prepared)) {
        $conclusion = 'skipped'
        $summary = 'CI failure analysis skipped because the PR or CI completion is no longer current.'
    } elseif (Test-CiReportExists $Context $Prepared.prNumber) {
        $conclusion = 'success'
        $summary = 'CI failure analysis comment published and verified.'
    } else {
        $conclusion = 'failure'
        $summary = 'CI failure analysis did not publish the expected report.'
    }

    $null = Invoke-CiApi -Context $Context -Method 'PATCH' -Path "$(Get-CiRepoPath $Context)/check-runs/$($Prepared.claimId)" -Body @{
        status = 'completed'
        conclusion = $conclusion
        output = @{ title = $script:CheckName; summary = "$summary See $(Get-CiRunUrl $Context)" }
    }
    Write-Host $summary
    if ($conclusion -ceq 'failure') {
        throw $summary
    }
}

Export-ModuleMember -Function ConvertFrom-CiJson, ConvertTo-CiJson, Get-CiContext,
    Initialize-CiFailureAnalysis, Start-CiFailureAnalysis, Protect-CiAnalysisOutput, Complete-CiFailureAnalysis
