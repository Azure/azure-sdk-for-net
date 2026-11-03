#Requires -Version 7.5

# Copyright (c) Microsoft Corporation. All rights reserved.
# Licensed under the MIT License.

$ErrorActionPreference = 'Stop'

# pr-re-review.md asks the agent for this line verbatim; Guard.Tests.ps1 keeps the two in sync.
$script:CoverageTemplate = 'Coverage: <fetched>/<total> threads fetched, <verified>/<unresolved> unresolved threads verified, <reviewed>/<changed> changed files reviewed'
$script:CoveragePattern = '^coverage\s*:\s*(?<fetched>[0-9]{1,6})\s*/\s*(?<total>[0-9]{1,6})\s+threads\s+fetched\s*,\s*(?<verified>[0-9]{1,6})\s*/\s*(?<unresolved>[0-9]{1,6})\s+unresolved\s+threads\s+verified\s*,\s*(?<reviewed>[0-9]{1,6})\s*/\s*(?<changed>[0-9]{1,6})\s+changed\s+files\s+reviewed\s*\.?$'
# The same output types that shared/agent-output-validation.md fails the run on.
$script:IncompleteTypes = @('report_incomplete', 'missing_tool', 'missing_data')

function ConvertFrom-PrReReviewJson {
    param([Parameter(Mandatory)][AllowEmptyString()][string]$Json)

    return ,(ConvertFrom-Json -InputObject $Json -AsHashtable -NoEnumerate -DateKind String -Depth 100)
}

function Get-PrReReviewCoverageTemplate {
    return $script:CoverageTemplate
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
    param([AllowNull()]$AgentOutput)

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
    return "Re-review coverage is complete: $line"
}

function Assert-PrReReviewReadCoverage {
    param(
        [AllowNull()]$AgentOutput,
        [Parameter(Mandatory)][AllowEmptyString()][string]$MarkersPath,
        [Parameter(Mandatory)][AllowEmptyString()][string]$SessionLogPath
    )

    if (@($AgentOutput.items | Where-Object { $_.type -ceq 'submit_pull_request_review' }).Count -eq 0) {
        return 'No review was submitted, so there is no read coverage to verify.'
    }
    if (!$MarkersPath -or ![IO.File]::Exists($MarkersPath)) {
        throw "The guard cannot verify read coverage without the exported-patch markers at '$MarkersPath'."
    }
    if (!$SessionLogPath -or ![IO.File]::Exists($SessionLogPath)) {
        throw "The guard cannot verify read coverage without the agent's tool log at '$SessionLogPath'."
    }

    $files = @((ConvertFrom-PrReReviewJson ([IO.File]::ReadAllText($MarkersPath))).files)
    foreach ($file in $files) {
        if ($file -isnot [System.Collections.IDictionary] -or $file.marker -isnot [string] -or $file.marker.Length -lt 16) {
            throw 'The guard cannot verify read coverage because the exported-patch markers are malformed.'
        }
    }

    # Only tool results reached the model. A read the CLI cut off as too large returns a notice instead of
    # the content, so it never contains the end-of-patch marker.
    $seen = [System.Text.StringBuilder]::new()
    foreach ($line in [IO.File]::ReadLines($SessionLogPath)) {
        if (!$line.Contains('"tool.execution_complete"', [StringComparison]::Ordinal)) { continue }
        try { $event = ConvertFrom-PrReReviewJson $line } catch { continue }
        if ($event -isnot [System.Collections.IDictionary] -or $event.type -cne 'tool.execution_complete') { continue }
        $content = $event.data.result.content
        if ($null -eq $content) { continue }
        $text = if ($content -is [string]) { $content } else { ConvertTo-Json -InputObject $content -Depth 20 -Compress }
        [void]$seen.Append($text).Append("`n")
    }
    $results = $seen.ToString()

    $unread = @($files | Where-Object { !$results.Contains($_.marker, [StringComparison]::Ordinal) } | ForEach-Object { [string]$_.path })
    if ($unread.Count -gt 0) {
        $listed = ($unread | Select-Object -First 10) -join ', '
        if ($unread.Count -gt 10) { $listed += ", and $($unread.Count - 10) more" }
        throw "The agent's tool log shows it read $($files.Count - $unread.Count) of $($files.Count) exported patches in full; unread: $listed. A re-review that did not read every changed file must call report_incomplete instead of submitting a review."
    }
    return "Read coverage verified from the tool log: all $($files.Count) exported patches were read in full."
}

Export-ModuleMember -Function ConvertFrom-PrReReviewJson, Get-PrReReviewCoverageTemplate, Assert-PrReReviewOutput, Assert-PrReReviewReadCoverage
