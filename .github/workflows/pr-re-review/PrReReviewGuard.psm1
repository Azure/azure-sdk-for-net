#Requires -Version 7.5

# Copyright (c) Microsoft Corporation. All rights reserved.
# Licensed under the MIT License.

$ErrorActionPreference = 'Stop'

# pr-re-review.md asks the agent for this line verbatim; Guard.Tests.ps1 keeps the two in sync.
$script:CoverageTemplate = 'Coverage: <fetched>/<total> threads fetched, <verified>/<unresolved> unresolved threads verified, <reviewed>/<changed> changed files reviewed'
$script:CoveragePattern = '^coverage\s*:\s*(?<fetched>[0-9]{1,6})\s*/\s*(?<total>[0-9]{1,6})\s+threads\s+fetched\s*,\s*(?<verified>[0-9]{1,6})\s*/\s*(?<unresolved>[0-9]{1,6})\s+unresolved\s+threads\s+verified\s*,\s*(?<reviewed>[0-9]{1,6})\s*/\s*(?<changed>[0-9]{1,6})\s+changed\s+files\s+reviewed\s*\.?$'
$script:ApiCoverageTemplate = 'API coverage: <reviewed>/<changed> API files reviewed'
$script:ApiCoveragePattern = '^api\s+coverage\s*:\s*(?<reviewed>[0-9]{1,6})\s*/\s*(?<changed>[0-9]{1,6})\s+API\s+files\s+reviewed\s*\.?$'
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
    param([switch]$ApiOnly)
    if ($ApiOnly) { return $script:ApiCoverageTemplate }
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
    param([Parameter(Mandatory)][AllowEmptyString()][string]$Body, [switch]$ApiOnly)

    $prefix = if ($ApiOnly) { '^api\s+coverage\s*:' } else { '^coverage\s*:' }
    $template = Get-PrReReviewCoverageTemplate -ApiOnly:$ApiOnly
    $candidates = @(
        foreach ($line in $Body -split '\r?\n') {
            $text = (($line -replace '[*_`]', '').Trim() -replace '^(?:>\s*)+', '' -replace '^[-+]\s+', '').Trim()
            if ($text -match $prefix) {
                $text
            }
        }
    )
    if ($candidates.Count -ne 1) {
        throw "The review body must contain exactly one $(if ($ApiOnly) { 'API coverage' } else { 'Coverage' }) line, but it has $($candidates.Count). Expected: $template"
    }
    return $candidates[0]
}

function Test-PrReReviewNonnegativeInteger {
    param($Value)
    return ($Value -is [byte] -or $Value -is [sbyte] -or $Value -is [int16] -or $Value -is [uint16] -or
        $Value -is [int32] -or $Value -is [uint32] -or $Value -is [int64] -or $Value -is [uint64]) -and $Value -ge 0
}

function Assert-PrReReviewApiExpected {
    param([System.Collections.IDictionary]$Expected)

    if ($Expected.Scope -cne 'api') { throw 'Invalid API input scope.' }
    foreach ($sha in @($Expected.HeadSha, $Expected.AnalyzedHeadSha)) {
        if ($sha -isnot [string] -or $sha -notmatch '^(?:[0-9a-f]{40}|[0-9a-f]{64})$') { throw 'Missing or malformed API review head SHA.' }
    }
    if ($Expected.HeadSha -cne $Expected.AnalyzedHeadSha) { throw 'The pull request head moved; refusing stale API review publication.' }
    if (!(Test-PrReReviewNonnegativeInteger $Expected.ChangedApiFiles) -or !(Test-PrReReviewNonnegativeInteger $Expected.ChangedFiles) -or $Expected.ChangedApiFiles -gt $Expected.ChangedFiles) {
        throw 'Missing or malformed independently captured API file count.'
    }
    if ($Expected.ApiFilePaths -isnot [array] -or $Expected.ApiFilePaths.Count -ne $Expected.ChangedApiFiles) {
        throw 'Missing or malformed independently captured API file set.'
    }
    $paths = [System.Collections.Generic.HashSet[string]]::new([StringComparer]::Ordinal)
    foreach ($path in $Expected.ApiFilePaths) {
        if ($path -isnot [string] -or !$path -or !$paths.Add($path)) { throw 'Missing or duplicate independently captured API file path.' }
    }
    if ($Expected.InlineTargets -isnot [array]) { throw 'Missing or malformed scoped source candidates.' }
    $sourcePaths = [System.Collections.Generic.HashSet[string]]::new([StringComparer]::Ordinal)
    foreach ($target in $Expected.InlineTargets) {
        if ($null -eq $target -or $target.path -isnot [string] -or !$target.path -or !$sourcePaths.Add($target.path) -or $target.lineRanges -isnot [array]) {
            throw 'Missing, duplicate, or malformed scoped source candidate.'
        }
        foreach ($range in $target.lineRanges) {
            if ($null -eq $range -or !(Test-PrReReviewNonnegativeInteger $range.start) -or !(Test-PrReReviewNonnegativeInteger $range.end) -or $range.start -eq 0 -or $range.end -lt $range.start) {
                throw 'Malformed scoped source diff range.'
            }
        }
    }
}

function Assert-PrReReviewApiOutput {
    param([System.Collections.IDictionary]$AgentOutput, [System.Collections.IDictionary]$Expected)
    $items = @($AgentOutput.items)
    foreach ($item in @($items | Where-Object { $_.type -cin @('submit_pull_request_review', 'create_pull_request_review_comment') })) {
        if ($item.Contains('repo') -and (!$Expected.Repository -or $item.repo -isnot [string] -or ![StringComparer]::OrdinalIgnoreCase.Equals($item.repo, $Expected.Repository))) {
            throw 'The review output targets a different repository than the captured API scope.'
        }
        if ($item.Contains('pull_request_number') -and (!(Test-PrReReviewNonnegativeInteger $item.pull_request_number) -or $item.pull_request_number -ne $Expected.Number)) {
            throw 'The review output targets a different pull request than the captured API scope.'
        }
    }
    if ($Expected.ChangedApiFiles -eq 0) {
        if ($items.Count -ne 1 -or $items[0].type -cne 'noop') {
            throw 'An empty API scope requires exactly one no-op, not a review or other publication.'
        }
        return 'API review not required: the pull request has no API-file changes.'
    }
    if (@($items | Where-Object { $_.type -ceq 'noop' }).Count -gt 0) {
        throw 'A no-op cannot replace the review of changed API files.'
    }
    foreach ($item in @($items | Where-Object { $_.type -ceq 'create_pull_request_review_comment' })) {
        if ($item.path -isnot [string] -or !$item.path) { throw 'An API finding needs a valid source path.' }
        if ($item.path -cmatch '^sdk/.+/api/[^/]+\.cs$' -or @($Expected.ApiFilePaths | Where-Object { [StringComparer]::Ordinal.Equals($_, $item.path) }).Count -gt 0) {
            throw 'Do not post inline on an API listing; map the symbol to its source file or use the review body.'
        }
        $targets = @($Expected.InlineTargets | Where-Object { [StringComparer]::Ordinal.Equals($_.path, $item.path) })
        if ($targets.Count -ne 1) { throw "The inline source path '$($item.path)' is not a unique scoped source candidate." }
        $line = 0
        if (![int]::TryParse([string]$item.line, [Globalization.NumberStyles]::None, [Globalization.CultureInfo]::InvariantCulture, [ref]$line) -or $line -le 0) {
            throw 'An inline API finding requires a positive source diff line.'
        }
        if (($item.side -and $item.side -cne 'RIGHT') -or $item.start_line) {
            throw 'Use a single current source diff line, or put the API finding in the review body.'
        }
        if (@($targets[0].lineRanges | Where-Object { $line -ge $_.start -and $line -le $_.end }).Count -eq 0) {
            throw "Line $line is not in the available source diff for '$($item.path)'; use the review body instead."
        }
    }
    $reviews = @($items | Where-Object { $_.type -ceq 'submit_pull_request_review' })
    if ($reviews.Count -ne 1 -or $reviews[0].body -isnot [string]) { throw 'A completed API review must submit exactly one text review.' }
    if ($reviews[0].event -cne 'COMMENT') { throw 'The API review must use the configured COMMENT event.' }
    foreach ($bodyLine in $reviews[0].body -split '\r?\n') {
        $text = (($bodyLine -replace '[*_`]', '').Trim() -replace '^(?:>\s*)+', '' -replace '^[-+]\s+', '').Trim()
        if ($text -match '^coverage\s*:') { throw 'An API-only review must not claim full PR or thread Coverage.' }
    }
    $line = Get-PrReReviewCoverageLine $reviews[0].body -ApiOnly
    $match = [regex]::Match($line, $script:ApiCoveragePattern, [Text.RegularExpressions.RegexOptions]::IgnoreCase)
    if (!$match.Success) { throw "The API coverage line must match: $script:ApiCoverageTemplate" }
    $reviewed = [int]$match.Groups['reviewed'].Value
    $changed = [int]$match.Groups['changed'].Value
    if ($reviewed -ne $changed) { throw "The API review is incomplete ($line)." }
    if ($changed -ne $Expected.ChangedApiFiles) { throw "The API coverage count $changed differs from the independently captured $($Expected.ChangedApiFiles) API files." }
    return "API-surface review coverage is complete: $line"
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

    if ($Expected -and $Expected.Contains('Scope')) {
        Assert-PrReReviewApiExpected $Expected
    }
    if ($Expected -and $Expected.Scope -ceq 'api') {
        $threadActions = @('resolve_pull_request_review_thread', 'unresolve_review_thread', 'reply_to_pull_request_review_comment')
        if (@($AgentOutput.items | Where-Object { $threadActions -ccontains $_.type }).Count -gt 0) {
            throw 'The first API-only review must leave existing thread state and replies untouched.'
        }
        $apiTypes = @('submit_pull_request_review', 'create_pull_request_review_comment', 'noop') + $script:IncompleteTypes
        if (@($AgentOutput.items | Where-Object { $apiTypes -cnotcontains $_.type }).Count -gt 0) {
            throw 'The API-only review contains an out-of-scope publication type.'
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
    if ($Expected -and $Expected.Scope -ceq 'api') {
        return Assert-PrReReviewApiOutput $AgentOutput $Expected
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

function Assert-PrReReviewReadCoverage {
    param(
        [AllowNull()]$AgentOutput,
        [Parameter(Mandatory)][AllowEmptyString()][string]$MarkersPath,
        [Parameter(Mandatory)][AllowEmptyString()][string]$SessionLogPath,
        [System.Collections.IDictionary]$Expected
    )

    if ($Expected -and $Expected.Contains('Scope')) { Assert-PrReReviewApiExpected $Expected }
    if (@($AgentOutput.items | Where-Object { $_.type -ceq 'submit_pull_request_review' }).Count -eq 0) {
        return 'No review was submitted, so there is no read coverage to verify.'
    }
    if (!$MarkersPath -or ![IO.File]::Exists($MarkersPath)) {
        throw "The guard cannot verify read coverage without the exported-patch markers at '$MarkersPath'."
    }
    $sessionLogs = @(
        if ($SessionLogPath -and [IO.File]::Exists($SessionLogPath)) {
            $SessionLogPath
        } elseif ($SessionLogPath -and [IO.Directory]::Exists($SessionLogPath)) {
            foreach ($session in [IO.Directory]::EnumerateDirectories($SessionLogPath)) {
                $eventLog = [IO.Path]::Combine($session, 'events.jsonl')
                if ([IO.File]::Exists($eventLog)) { $eventLog }
            }
        }
    )
    if ($sessionLogs.Count -eq 0) {
        throw "The guard cannot verify read coverage without the agent's tool log or session event logs at '$SessionLogPath'."
    }

    $markers = ConvertFrom-PrReReviewJson ([IO.File]::ReadAllText($MarkersPath))
    $files = @($markers.files)
    if ($Expected -and $Expected.Scope -ceq 'api') {
        if ($markers.files -isnot [array]) { throw 'The exported API file set is malformed.' }
        if ($markers.scope -cne 'api') { throw 'The read markers do not identify the API scope.' }
        if ($markers.headSha -cne $Expected.AnalyzedHeadSha) { throw 'The API read markers belong to a different head commit.' }
        if ($files.Count -ne $Expected.ChangedApiFiles -or @($Expected.ApiFilePaths).Count -ne $files.Count) {
            throw 'The exported read markers do not cover the independently captured API file set.'
        }
        $paths = [System.Collections.Generic.HashSet[string]]::new([StringComparer]::Ordinal)
        foreach ($file in $files) {
            if ($file.path -isnot [string] -or !$paths.Add($file.path)) { throw 'The API read marker paths are missing or duplicated.' }
        }
        foreach ($path in $Expected.ApiFilePaths) {
            if (!$paths.Contains($path)) { throw "The read markers omit API file '$path'." }
        }
    }
    foreach ($file in $files) {
        if ($file -isnot [System.Collections.IDictionary] -or $file.marker -isnot [string] -or $file.marker.Length -lt 16 -or $file.chunks -isnot [array] -or $file.chunks.Count -eq 0) {
            throw 'The guard cannot verify read coverage because the exported-patch markers are malformed.'
        }
        foreach ($chunk in $file.chunks) {
            if ($chunk -isnot [System.Collections.IDictionary] -or $chunk.content -isnot [string] -or $chunk.content.Length -eq 0) {
                throw 'The guard cannot verify read coverage because the exported-patch chunks are malformed.'
            }
        }
    }

    # Check for ordinary missed or truncated reads. The agent can influence its session log,
    # so these matches are not tamper-proof evidence and cannot establish comprehension.
    # Each complete chunk must appear in one successful tool result.
    $results = [System.Collections.Generic.List[string]]::new()
    foreach ($sessionLog in $sessionLogs) {
        foreach ($line in [IO.File]::ReadLines($sessionLog)) {
            if (!$line.Contains('"tool.execution_complete"', [StringComparison]::Ordinal)) { continue }
            try { $event = ConvertFrom-PrReReviewJson $line } catch { continue }
            if ($event -isnot [System.Collections.IDictionary] -or $event.type -cne 'tool.execution_complete' -or $event.data.success -eq $false) { continue }
            $content = $event.data.result.content
            if ($null -eq $content) { continue }
            $text = if ($content -is [string]) { $content } else { ConvertTo-Json -InputObject $content -Depth 20 -Compress }
            $results.Add($text)
        }
    }

    $unread = @(
        foreach ($file in $files) {
            foreach ($chunk in $file.chunks) {
                $expectedChunk = $chunk.content.TrimEnd([char[]]"`r`n")
                if (!$expectedChunk -or !@($results | Where-Object { $_.Contains($expectedChunk, [StringComparison]::Ordinal) }).Count) {
                    [string]$file.path
                    break
                }
            }
        }
    )
    if ($unread.Count -gt 0) {
        $listed = ($unread | Select-Object -First 10) -join ', '
        if ($unread.Count -gt 10) { $listed += ", and $($unread.Count - 10) more" }
        throw "The agent's tool log contains complete content for $($files.Count - $unread.Count) of $($files.Count) exported patches; missing: $listed. A re-review that did not read every changed file must call report_incomplete instead of submitting a review."
    }
    return "Read coverage check passed: the agent's tool log contains all $($files.Count) exported patches. This check is not tamper-proof."
}

Export-ModuleMember -Function ConvertFrom-PrReReviewJson, Get-PrReReviewCoverageTemplate, Get-PrReReviewTotals, Assert-PrReReviewOutput, Assert-PrReReviewReadCoverage
