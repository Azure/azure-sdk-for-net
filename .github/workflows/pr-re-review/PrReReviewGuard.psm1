#Requires -Version 7.5

# Copyright (c) Microsoft Corporation. All rights reserved.
# Licensed under the MIT License.

$ErrorActionPreference = 'Stop'

# pr-re-review.md asks the agent for this line verbatim; Guard.Tests.ps1 keeps the two in sync.
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
            throw "The pull request head moved from $($Expected.AnalyzedHeadSha) to $($Expected.HeadSha) during the re-review; refusing stale publication."
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
        if ($file -isnot [System.Collections.IDictionary] -or $file.marker -isnot [string] -or $file.marker.Length -lt 16 -or @($file.chunks).Count -eq 0) {
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
    foreach ($line in [IO.File]::ReadLines($SessionLogPath)) {
        if (!$line.Contains('"tool.execution_complete"', [StringComparison]::Ordinal)) { continue }
        try { $event = ConvertFrom-PrReReviewJson $line } catch { continue }
        if ($event -isnot [System.Collections.IDictionary] -or $event.type -cne 'tool.execution_complete' -or $event.data.success -eq $false) { continue }
        $content = $event.data.result.content
        if ($null -eq $content) { continue }
        $text = if ($content -is [string]) { $content } else { ConvertTo-Json -InputObject $content -Depth 20 -Compress }
        $results.Add($text)
    }

    $unread = @(
        foreach ($file in $files) {
            foreach ($chunk in $file.chunks) {
                $expected = $chunk.content.TrimEnd([char[]]"`r`n")
                if (!@($results | Where-Object { $_.Contains($expected, [StringComparison]::Ordinal) }).Count) {
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

function Test-PrReReviewReplayCommit {
    param([AllowEmptyString()][string]$Value, [Parameter(Mandatory)][string[]]$AllowedCommits)

    return $Value -cmatch '^[0-9a-f]{7,64}$' -and @($AllowedCommits | Where-Object { $_ -and $_.StartsWith($Value, [StringComparison]::Ordinal) }).Count -gt 0
}

$script:HeredocPattern = [regex]'\G(?<!<)<<(?!<)(?<dash>-?)[ \t]*(?:(?<quote>'')(?<word>[^''\n]*)''|(?<quote>")(?<word>[^"\n]*)"|(?<quote>\\)?(?<word>[A-Za-z0-9_]+))'

function Set-PrReReviewShellMask {
    param([char[]]$Mask, [int]$From, [int]$To)

    for ($k = $From; $k -le $To -and $k -lt $Mask.Length; $k++) { $Mask[$k] = '_' }
}

# Masks the quoted text, comments, command substitutions, and heredoc bodies in bash text from $Index to the
# unquoted $Close character, so that only the separators between commands stay visible. Returns $Close's index.
function Skip-PrReReviewShellText {
    param(
        [string]$Text, [char[]]$Mask, [int]$Index, [string]$Close,
        [AllowNull()][System.Collections.Generic.List[object]]$Substitutions,
        [AllowNull()][System.Collections.Generic.List[object]]$Heredocs
    )

    $pending = [System.Collections.Generic.List[object]]::new()
    $i = $Index
    while ($i -lt $Text.Length) {
        $c = $Text[$i]
        if ($Close -and $c -ceq $Close[0]) { return $i }
        if ($c -ceq '\') {
            Set-PrReReviewShellMask $Mask $i ($i + 1)
            $i += 2
        } elseif ($c -ceq "'") {
            $end = $Text.IndexOf([char]"'", $i + 1)
            if ($end -lt 0) { $end = $Text.Length - 1 }
            Set-PrReReviewShellMask $Mask $i $end
            $i = $end + 1
        } elseif ($c -ceq '"' -or $c -ceq '`' -or ($c -ceq '$' -and $i + 1 -lt $Text.Length -and $Text[$i + 1] -ceq '(')) {
            $end = Skip-PrReReviewShellQuote $Text $Mask $i $Substitutions
            Set-PrReReviewShellMask $Mask $i $end
            $i = $end + 1
        } elseif ($c -ceq '#' -and ($i -eq 0 -or [char]::IsWhiteSpace($Text[$i - 1]))) {
            $end = $Text.IndexOf([char]"`n", $i)
            if ($end -lt 0) { $end = $Text.Length }
            Set-PrReReviewShellMask $Mask $i ($end - 1)
            $i = $end
        } elseif ($c -ceq '<' -and ($match = $script:HeredocPattern.Match($Text, $i)).Success) {
            $pending.Add(@{ Delimiter = $match.Groups['word'].Value; StripTabs = $match.Groups['dash'].Value -ceq '-'; Quoted = $match.Groups['quote'].Success })
            $i += $match.Length
        } elseif ($c -ceq "`n" -and $pending.Count -gt 0) {
            # The command's heredoc bodies start on the next line; they belong to the command, not after it.
            $end = $i
            foreach ($heredoc in $pending) {
                $bodyStart = [Math]::Min($end + 1, $Text.Length)
                $bodyEnd = $Text.Length
                while ($end -lt $Text.Length) {
                    $lineStart = $end + 1
                    $end = $Text.IndexOf([char]"`n", $lineStart)
                    if ($end -lt 0) { $end = $Text.Length }
                    $line = $Text.Substring($lineStart, $end - $lineStart)
                    if ($heredoc.StripTabs) { $line = $line.TrimStart("`t") }
                    if ($line -ceq $heredoc.Delimiter) {
                        $bodyEnd = $lineStart
                        break
                    }
                }
                if ($null -ne $Heredocs) { $Heredocs.Add([pscustomobject]@{ Start = $bodyStart; End = [Math]::Max($bodyStart, $bodyEnd); Quoted = $heredoc.Quoted }) }
            }
            $pending.Clear()
            Set-PrReReviewShellMask $Mask $i ($end - 1)
            $i = $end
        } else {
            $i++
        }
    }
    return $i
}

# Returns the index of the character that ends the double-quoted string or command substitution starting at
# $Index, recording each command substitution in it.
function Skip-PrReReviewShellQuote {
    param([string]$Text, [char[]]$Mask, [int]$Index, [AllowNull()][System.Collections.Generic.List[object]]$Substitutions)

    $end = $Index + 1
    if ($Text[$Index] -ceq '$') {
        $end = Skip-PrReReviewShellText $Text $Mask ($Index + 2) ')' $null $null
        if ($null -ne $Substitutions) { $Substitutions.Add([pscustomobject]@{ Start = $Index + 2; End = $end }) }
    } elseif ($Text[$Index] -ceq '`') {
        while ($end -lt $Text.Length -and $Text[$end] -cne '`') { if ($Text[$end] -ceq '\') { $end += 2 } else { $end++ } }
        if ($null -ne $Substitutions) { $Substitutions.Add([pscustomobject]@{ Start = $Index + 1; End = [Math]::Min($end, $Text.Length) }) }
    } else {
        while ($end -lt $Text.Length -and $Text[$end] -cne '"') {
            if ($Text[$end] -ceq '\') {
                $end += 2
            } elseif ($Text[$end] -ceq '`' -or ($Text[$end] -ceq '$' -and $end + 1 -lt $Text.Length -and $Text[$end + 1] -ceq '(')) {
                $end = (Skip-PrReReviewShellQuote $Text $Mask $end $Substitutions) + 1
            } else {
                $end++
            }
        }
    }
    return $end
}

# Splits bash text into its commands, each with its source, the sources of its command substitutions, and the
# spans of its heredoc bodies within its source.
function Split-PrReReviewShellCommand {
    param([Parameter(Mandatory)][AllowEmptyString()][string]$Text)

    $mask = $Text.ToCharArray()
    $substitutions = [System.Collections.Generic.List[object]]::new()
    $heredocs = [System.Collections.Generic.List[object]]::new()
    [void](Skip-PrReReviewShellText $Text $mask 0 '' $substitutions $heredocs)
    $masked = [string]::new($mask)
    $commands = [System.Collections.Generic.List[object]]::new()
    $start = 0
    foreach ($end in @([regex]::Matches($masked, '(?<![<>])&(?!>)|[;|\n()]') | ForEach-Object Index) + $Text.Length) {
        $name = [regex]::Match($masked.Substring($start, $end - $start), '^\s*(?:(?:then|do|else|!)\s+|\w+=\S*\s+)*(?<name>[^\s<>]+)').Groups['name'].Value
        if ($name) {
            $within = { $_.Start -ge $start -and $_.Start -lt $end }
            $commands.Add([pscustomobject]@{
                Name = ($name -split '/')[-1]
                Source = $Text.Substring($start, $end - $start)
                Substitutions = @($substitutions | Where-Object $within | ForEach-Object { $Text.Substring($_.Start, $_.End - $_.Start) })
                Heredocs = @($heredocs | Where-Object $within | ForEach-Object { [pscustomobject]@{ Start = $_.Start - $start; End = $_.End - $start; Quoted = $_.Quoted } })
            })
        }
        $start = $end + 1
    }
    return ,$commands.ToArray()
}

# Returns the command substitutions in otherwise literal text, such as an unquoted heredoc body.
function Get-PrReReviewShellExpansion {
    param([Parameter(Mandatory)][AllowEmptyString()][string]$Text)

    $found = [System.Collections.Generic.List[object]]::new()
    $mask = $Text.ToCharArray()
    for ($i = 0; $i -lt $Text.Length; $i++) {
        if ($Text[$i] -ceq '\') {
            $i++
        } elseif ($Text[$i] -ceq '`' -or ($Text[$i] -ceq '$' -and $i + 1 -lt $Text.Length -and $Text[$i + 1] -ceq '(')) {
            $i = Skip-PrReReviewShellQuote $Text $mask $i $found
        }
    }
    return ,@($found | ForEach-Object { $Text.Substring($_.Start, $_.End - $_.Start) })
}

# Returns the files a command writes through output redirection and, for tee, through its file arguments.
function Get-PrReReviewShellTarget {
    param([Parameter(Mandatory)]$Command)

    $line = if ($Command.Heredocs.Count -gt 0) { $Command.Source.Substring(0, $Command.Heredocs[0].Start) } else { $Command.Source }
    $line = $line -replace '<<-?\s*(?:''[^'']*''|"[^"]*"|\\?\w+)', ''
    $targets = @([regex]::Matches($line, '(?<![0-9&])>>?\s*(?<target>"[^"]*"|''[^'']*''|[^\s;&|<>]+)') | ForEach-Object { $_.Groups['target'].Value.Trim('"', "'") })
    if ($Command.Name -ceq 'tee') {
        $targets += @(($line -replace '(?<![0-9&])>>?\s*\S+', '').Trim() -split '\s+' | Select-Object -Skip 1 | Where-Object { $_ -and $_ -notmatch '^-' } | ForEach-Object { $_.Trim('"', "'") })
    }
    return $targets
}

# Returns the files that safeoutputs commands publish by reading them with cat, such as a review body written earlier.
function Get-PrReReviewPublishedFile {
    param([Parameter(Mandatory)][AllowEmptyCollection()][string[]]$Commands)

    foreach ($text in $Commands) {
        foreach ($command in (Split-PrReReviewShellCommand $text)) {
            if ($command.Name -cne 'safeoutputs') { continue }
            foreach ($substitution in $command.Substitutions) {
                foreach ($nested in (Split-PrReReviewShellCommand $substitution)) {
                    if ($nested.Name -cne 'cat') { continue }
                    $nested.Source.Trim() -split '\s+' | Select-Object -Skip 1 | Where-Object { $_ -and $_ -notmatch '^(?:-|[0-9]*[<>&])' } | ForEach-Object { $_.Trim('"', "'") }
                }
            }
        }
    }
}

# A safeoutputs command only publishes, so only the commands nested in its arguments can read. Of those, cat reads
# only a local file or heredoc, though an unquoted heredoc still runs its command substitutions. A cat or tee heredoc
# that writes a published file is publication text too, so only the command substitutions that an unquoted delimiter
# lets it run can read.
function Get-PrReReviewShellReadText {
    param([Parameter(Mandatory)][AllowEmptyString()][string]$Text, [AllowEmptyCollection()][string[]]$PublishedFiles = @())

    $parts = foreach ($command in (Split-PrReReviewShellCommand $Text)) {
        if ($command.Name -ceq 'safeoutputs') {
            foreach ($substitution in $command.Substitutions) {
                foreach ($nested in (Split-PrReReviewShellCommand $substitution)) {
                    if ($nested.Name -cne 'cat') {
                        Get-PrReReviewShellReadText $nested.Source $PublishedFiles
                        continue
                    }
                    foreach ($heredoc in @($nested.Heredocs | Where-Object { !$_.Quoted })) {
                        foreach ($expansion in (Get-PrReReviewShellExpansion $nested.Source.Substring($heredoc.Start, $heredoc.End - $heredoc.Start))) {
                            Get-PrReReviewShellReadText $expansion $PublishedFiles
                        }
                    }
                }
            }
        } elseif ($command.Name -cin @('cat', 'tee') -and $command.Heredocs.Count -gt 0 -and @(Get-PrReReviewShellTarget $command | Where-Object { $PublishedFiles -ccontains $_ }).Count -gt 0) {
            $source = $command.Source
            foreach ($heredoc in @($command.Heredocs | Sort-Object Start -Descending)) {
                $body = $source.Substring($heredoc.Start, $heredoc.End - $heredoc.Start)
                $source = $source.Remove($heredoc.Start, $heredoc.End - $heredoc.Start)
                if (!$heredoc.Quoted) {
                    foreach ($expansion in (Get-PrReReviewShellExpansion $body)) { Get-PrReReviewShellReadText $expansion $PublishedFiles }
                }
            }
            $source
        } else {
            $command.Source
        }
    }
    return (@($parts) -join "`n")
}

function Find-PrReReviewReplayContamination {
    param(
        [Parameter(Mandatory)][AllowEmptyString()][string]$SessionLogPath,
        [Parameter(Mandatory)][string[]]$AllowedCommits
    )

    if (!$SessionLogPath -or ![IO.File]::Exists($SessionLogPath)) {
        throw "The guard cannot check the replay for reads of the current pull request without the agent's tool log at '$SessionLogPath'."
    }

    # The pull request, its history, and its branches have all moved on since the replayed run, so any
    # read that is not pinned to the replayed commits can leak what happened later, such as the fixes.
    $events = @(foreach ($line in [IO.File]::ReadLines($SessionLogPath)) {
        if (!$line.Contains('"tool.execution_start"', [StringComparison]::Ordinal)) { continue }
        try { $event = ConvertFrom-PrReReviewJson $line } catch { continue }
        if ($event -is [System.Collections.IDictionary] -and $event.type -ceq 'tool.execution_start' -and $event.data -is [System.Collections.IDictionary]) { $event.data }
    })
    $published = @(Get-PrReReviewPublishedFile @($events | Where-Object { $_.toolName -ceq 'bash' -and $_.arguments -is [System.Collections.IDictionary] } | ForEach-Object { [string]$_.arguments.command }))
    $found = [System.Collections.Generic.List[string]]::new()
    foreach ($data in $events) {
        $arguments = if ($data.arguments -is [System.Collections.IDictionary]) { $data.arguments } else { @{} }
        $call = "$($data.toolName) $(ConvertTo-Json -InputObject $data.arguments -Depth 20 -Compress)"
        if ($data.mcpServerName -ceq 'safeoutputs') { continue }
        if ($data.mcpServerName -ceq 'github') {
            $pinned = (Test-PrReReviewReplayCommit "$($arguments.ref)" $AllowedCommits) -or (Test-PrReReviewReplayCommit "$($arguments.sha)" $AllowedCommits)
            if ($data.mcpToolName -cne 'get_file_contents' -or !$pinned) { $found.Add($call) }
            continue
        }

        # Covers the GitHub MCP server mounted as a `github` command and direct requests to GitHub. One command
        # can chain several reads, so each invocation and URL must be pinned on its own.
        $text = if ($data.toolName -ceq 'bash') { Get-PrReReviewShellReadText ([string]$arguments.command) $published } else { $call }
        foreach ($invocation in [regex]::Matches($text, '(?:^|[\s;&|(`])github\s+(?<tool>[a-z_]+)(?<args>[^;&|\n`)]*)')) {
            $ref = [regex]::Match($invocation.Groups['args'].Value, '--(?:ref|sha)[=\s]+["'']?(?<commit>[0-9a-f]{7,64})\b')
            if ($invocation.Groups['tool'].Value -cne 'get_file_contents' -or !$ref.Success -or !(Test-PrReReviewReplayCommit $ref.Groups['commit'].Value $AllowedCommits)) {
                $found.Add("$($data.toolName) $($invocation.Value.Trim())")
            }
        }
        foreach ($url in [regex]::Matches($text, '(?i)(?<![\w.-])(?:https?://)?(?:[a-z0-9-]+\.)*(?:github\.com|githubusercontent\.com)/[^\s''"`<>|;&)]*')) {
            $content = [regex]::Match($url.Value, '(?i)^(?:https?://)?(?:raw\.githubusercontent\.com/[^/]+/[^/]+/(?<commit>[0-9a-f]{7,64})/|(?:www\.)?github\.com/[^/]+/[^/]+/(?:blob|raw)/(?<commit>[0-9a-f]{7,64})/|api\.github\.com/repos/[^/]+/[^/]+/contents/[^?#]*\?(?:[^#]*&)?ref=(?<commit>[0-9a-f]{7,64})(?:[&#]|$))')
            if (!$content.Success -or !(Test-PrReReviewReplayCommit $content.Groups['commit'].Value.ToLowerInvariant() $AllowedCommits)) {
                $found.Add("$($data.toolName) $($url.Value)")
            }
        }
    }
    return ,$found.ToArray()
}

function Get-PrReReviewReplayResult {
    param(
        [AllowNull()]$AgentOutput,
        [Parameter(Mandatory)][System.Collections.IDictionary]$Replay,
        [Parameter(Mandatory)][AllowEmptyString()][string]$MarkersPath,
        [Parameter(Mandatory)][AllowEmptyString()][string]$SessionLogPath
    )

    $expected = @{
        AnalyzedHeadSha = [string]$Replay.headSha
        HeadSha = [string]$Replay.headSha
        ChangedFiles = [int]$Replay.changedFiles
        ThreadsBefore = [int]$Replay.threads
        ThreadsNow = [int]$Replay.threads
    }
    $checks = [ordered]@{}
    foreach ($check in @(
        @{ Name = 'coverage'; Script = { Assert-PrReReviewOutput -AgentOutput $AgentOutput -Expected $expected } }
        @{ Name = 'readCoverage'; Script = { Assert-PrReReviewReadCoverage -AgentOutput $AgentOutput -MarkersPath $MarkersPath -SessionLogPath $SessionLogPath } }
    )) {
        try {
            $checks[$check.Name] = [ordered]@{ passed = $true; message = [string](& $check.Script) }
        } catch {
            $checks[$check.Name] = [ordered]@{ passed = $false; message = $_.Exception.Message }
        }
    }
    try {
        $contamination = Find-PrReReviewReplayContamination -SessionLogPath $SessionLogPath -AllowedCommits @($Replay.headSha, $Replay.baseSha, $Replay.mergeBaseSha)
    } catch {
        $contamination = @("unchecked: $($_.Exception.Message)")
    }

    $items = @(if ($AgentOutput -is [System.Collections.IDictionary] -and $AgentOutput.items -is [array]) { $AgentOutput.items })
    $types = @($items | ForEach-Object { $_.type })
    $incompleteTypes = $script:IncompleteTypes
    $outcome = if ($types -ccontains 'submit_pull_request_review') {
        if ($checks.coverage.passed -and $checks.readCoverage.passed) { 'would-publish' } else { 'blocked' }
    } elseif (@($types | Where-Object { $incompleteTypes -ccontains $_ }).Count -gt 0) {
        'incomplete'
    } else {
        'no-review'
    }
    return [ordered]@{
        pullRequest = $Replay.pullRequest
        headSha = $Replay.headSha
        baseSha = $Replay.baseSha
        historyCutoff = $Replay.historyCutoff
        outcome = $outcome
        coverage = $checks.coverage
        readCoverage = $checks.readCoverage
        contaminated = $contamination.Count -gt 0
        contamination = $contamination
        items = $items
    }
}

function Test-PrReReviewReplayStaged {
    param([Parameter(Mandatory)][AllowEmptyString()][string]$LockPath)

    if (!$LockPath -or ![IO.File]::Exists($LockPath)) {
        return $false
    }
    # Reads the compiler's layout: jobs at two spaces, steps at six, step keys deeper.
    $lines = [IO.File]::ReadAllLines($LockPath)
    $job = [array]::IndexOf($lines, '  safe_outputs:')
    if ($job -lt 0) {
        return $false
    }
    $publishSteps = 0
    $stagedSteps = 0
    $inPublish = $false
    $stagedLine = "GH_AW_SAFE_OUTPUTS_STAGED: `${{ github.event_name == 'workflow_dispatch' }}"
    for ($i = $job + 1; $i -lt $lines.Count -and ($lines[$i].Length -eq 0 -or $lines[$i].StartsWith('   ')); $i++) {
        if ($lines[$i] -cmatch '^      - name: (.+)$') {
            $inPublish = $Matches[1] -ceq 'Process Safe Outputs'
            if ($inPublish) { $publishSteps++ }
        } elseif ($inPublish -and $lines[$i].Trim() -ceq $stagedLine) {
            $stagedSteps++
            $inPublish = $false
        }
    }
    return $publishSteps -gt 0 -and $stagedSteps -eq $publishSteps
}

Export-ModuleMember -Function ConvertFrom-PrReReviewJson, Get-PrReReviewCoverageTemplate, Get-PrReReviewTotals, Assert-PrReReviewOutput, Assert-PrReReviewReadCoverage, Find-PrReReviewReplayContamination, Get-PrReReviewReplayResult, Test-PrReReviewReplayStaged
