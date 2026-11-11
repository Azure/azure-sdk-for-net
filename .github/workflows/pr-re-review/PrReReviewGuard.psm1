#Requires -Version 7.5

# Copyright (c) Microsoft Corporation. All rights reserved.
# Licensed under the MIT License.

$ErrorActionPreference = 'Stop'

# pr-re-review.md asks the agent for this line verbatim; PrReReviewGuard.Tests.ps1 keeps the two in sync.
$script:CoverageTemplate = 'Coverage: <fetched>/<total> threads fetched, <verified>/<unresolved> unresolved threads verified, <reviewed>/<changed> changed files reviewed'
$script:CoveragePattern = '^coverage\s*:\s*(?<fetched>[0-9]{1,6})\s*/\s*(?<total>[0-9]{1,6})\s+threads\s+fetched\s*,\s*(?<verified>[0-9]{1,6})\s*/\s*(?<unresolved>[0-9]{1,6})\s+unresolved\s+threads\s+verified\s*,\s*(?<reviewed>[0-9]{1,6})\s*/\s*(?<changed>[0-9]{1,6})\s+changed\s+files\s+reviewed\s*\.?$'
# The same output types that shared/agent-output-validation.md fails the run on.
$script:IncompleteTypes = @('report_incomplete', 'missing_tool', 'missing_data')
$script:TotalsQuery = @'
query($owner: String!, $repo: String!, $number: Int!, $cursor: String) {
  repository(owner: $owner, name: $repo) {
    pullRequest(number: $number) {
      headRefOid
      changedFiles
      reviewThreads(first: 100, after: $cursor) {
        totalCount
        pageInfo { hasNextPage endCursor }
        nodes { comments(first: 1) { nodes { publishedAt pullRequestReview { submittedAt } } } }
      }
    }
  }
}
'@

function ConvertFrom-PrReReviewJson {
    param([Parameter(Mandatory)][AllowEmptyString()][string]$Json)

    return ,(ConvertFrom-Json -InputObject $Json -AsHashtable -NoEnumerate -DateKind String -Depth 100)
}

function Get-PrReReviewCoverageTemplate {
    return $script:CoverageTemplate
}

function Get-PrReReviewTotals {
    param(
        [Parameter(Mandatory)][ValidatePattern('^[^/]+/[^/]+$')][string]$Repository,
        [Parameter(Mandatory)][ValidateRange(1, [int]::MaxValue)][int]$Number,
        [Parameter(Mandatory)][ValidatePattern('^[0-9a-f]{40}$')][string]$AnalyzedHeadSha,
        [Parameter(Mandatory)][DateTimeOffset]$Since,
        [Parameter(Mandatory)][string]$Token,
        [string]$GraphQLUrl = 'https://api.github.com/graphql'
    )

    $owner, $name = $Repository -split '/', 2
    $cursor = $null
    $before = 0
    for ($page = 1; $page -le 100; $page++) {
        $body = ConvertTo-Json -Compress -Depth 5 -InputObject @{
            query = $script:TotalsQuery
            variables = @{ owner = $owner; repo = $name; number = $Number; cursor = $cursor }
        }
        $response = Invoke-WebRequest -Method Post -Uri $GraphQLUrl -Body $body -ContentType 'application/json' -Headers @{ Authorization = "Bearer $Token" } -MaximumRetryCount 3 -RetryIntervalSec 5
        $result = ConvertFrom-PrReReviewJson $response.Content
        if ($result.errors) {
            throw "GitHub GraphQL returned errors: $(ConvertTo-Json -Compress -Depth 10 -InputObject $result.errors)"
        }
        $pullRequest = $result.data.repository.pullRequest
        if ($pullRequest -isnot [System.Collections.IDictionary]) {
            throw "Pull request #$Number was not found in $Repository."
        }
        $threads = $pullRequest.reviewThreads
        foreach ($thread in $threads.nodes) {
            # Threads opened after the run started may be missing from the agent's count, so only earlier ones set the floor.
            # A comment drafted in a pending review stays hidden until the review is submitted, so use the later timestamp.
            $first = @($thread.comments.nodes)[0]
            $public = @($first.publishedAt, $first.pullRequestReview.submittedAt) |
                Where-Object { $_ } |
                ForEach-Object { [DateTimeOffset]::Parse($_, [Globalization.CultureInfo]::InvariantCulture) } |
                Sort-Object -Descending |
                Select-Object -First 1
            if ($public -and $public -le $Since) {
                $before++
            }
        }
        if (!$threads.pageInfo.hasNextPage) {
            return @{
                AnalyzedHeadSha = $AnalyzedHeadSha
                HeadSha = $pullRequest.headRefOid
                ChangedFiles = [int]$pullRequest.changedFiles
                ThreadsBefore = $before
                ThreadsNow = [int]$threads.totalCount
            }
        }
        $cursor = $threads.pageInfo.endCursor
    }
    throw "Pull request #$Number has more review-thread pages than the guard reads."
}

function Get-PrReReviewCoverageLine {
    param([Parameter(Mandatory)][AllowEmptyString()][string]$Body)

    $candidates = @(
        foreach ($line in $Body -split '\r?\n') {
            $text = (($line -replace '[*_`]', '').Trim() -replace '^(?:>\s*)+', '' -replace '^[-+]\s+', '').Trim()
            if ($text -match '^coverage\s*:') {
                $text
            }
        }
    )
    if ($candidates.Count -ne 1) {
        throw "The review body must contain exactly one Coverage line, but it has $($candidates.Count). Expected: $script:CoverageTemplate"
    }
    return $candidates[0]
}

function Assert-PrReReviewOutput {
    param([AllowNull()]$AgentOutput, [System.Collections.IDictionary]$Expected)

    if ($AgentOutput -isnot [System.Collections.IDictionary] -or $AgentOutput.items -isnot [array]) {
        throw 'Re-review agent output is malformed.'
    }
    if ($AgentOutput.errors -isnot [array] -or $AgentOutput.errors.Count -ne 0) {
        throw 'Re-review agent output ingestion reported errors or omitted its error list.'
    }
    foreach ($item in $AgentOutput.items) {
        if ($item -isnot [System.Collections.IDictionary] -or $item.type -isnot [string] -or !$item.type.Trim()) {
            throw 'Re-review agent output contains an invalid item.'
        }
    }

    $incompleteTypes = $script:IncompleteTypes
    $incomplete = @($AgentOutput.items | ForEach-Object { $_.type } | Where-Object { $incompleteTypes -ccontains $_ } | Select-Object -Unique)
    $reviews = @($AgentOutput.items | Where-Object { $_.type -ceq 'submit_pull_request_review' })
    if ($incomplete.Count -gt 0) {
        # gh-aw submits buffered inline comments as a review even without submit_pull_request_review.
        if ($reviews.Count -gt 0 -or @($AgentOutput.items | Where-Object { $_.type -ceq 'create_pull_request_review_comment' }).Count -gt 0) {
            throw "The agent reported incomplete work ($($incomplete -join ', ')) but also submitted a review or inline review comments; a partial re-review must not be published."
        }
        return "The agent reported incomplete work ($($incomplete -join ', ')) and submitted no review; terminal validation fails the run."
    }
    if ($reviews.Count -ne 1) {
        throw "A completed re-review must submit exactly one submit_pull_request_review, but the agent submitted $($reviews.Count)."
    }
    if ($reviews[0].body -isnot [string]) {
        throw 'The re-review body is missing or is not text.'
    }

    $line = Get-PrReReviewCoverageLine $reviews[0].body
    $match = [regex]::Match($line, $script:CoveragePattern, [Text.RegularExpressions.RegexOptions]::IgnoreCase)
    if (!$match.Success) {
        throw "The review's Coverage line does not match the required format: $script:CoverageTemplate"
    }
    $counts = @{}
    foreach ($name in 'fetched', 'total', 'verified', 'unresolved', 'reviewed', 'changed') {
        $counts[$name] = [int]$match.Groups[$name].Value
    }
    if ($counts.unresolved -gt $counts.total) {
        throw "The review's Coverage line reports more unresolved threads ($($counts.unresolved)) than threads ($($counts.total))."
    }
    if ($counts.fetched -ne $counts.total -or $counts.verified -ne $counts.unresolved -or $counts.reviewed -ne $counts.changed) {
        throw "The re-review is incomplete ($line); the agent must call report_incomplete instead of submitting a review."
    }
    if ($Expected) {
        if ($counts.total -lt $Expected.ThreadsBefore -or $counts.total -gt $Expected.ThreadsNow) {
            throw "The review's Coverage line reports $($counts.total) review threads, but the pull request had $($Expected.ThreadsBefore) when the re-review started and has $($Expected.ThreadsNow) now."
        }
        if ($Expected.HeadSha -cne $Expected.AnalyzedHeadSha) {
            return "Re-review coverage is complete: $line (the head moved to $($Expected.HeadSha), so the changed-file total was not checked)"
        }
        if ($counts.changed -ne $Expected.ChangedFiles) {
            throw "The review's Coverage line reports $($counts.changed) changed files, but the pull request has $($Expected.ChangedFiles) at the reviewed head."
        }
    }
    return "Re-review coverage is complete: $line"
}

Export-ModuleMember -Function ConvertFrom-PrReReviewJson, Get-PrReReviewCoverageTemplate, Get-PrReReviewTotals, Assert-PrReReviewOutput
