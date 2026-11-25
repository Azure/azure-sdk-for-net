#Requires -Version 7.5

# Copyright (c) Microsoft Corporation. All rights reserved.
# Licensed under the MIT License.

$ErrorActionPreference = 'Stop'

function Invoke-PrReReviewGhApi {
    param([Parameter(Mandatory)][string[]]$Arguments, [switch]$Raw)

    if ($Raw) {
        return Read-PrReReviewNativeOutput -Command 'gh' -Arguments (@('api') + $Arguments)
    }
    $output = & gh api @Arguments
    if ($LASTEXITCODE -ne 0) {
        throw "gh api $($Arguments -join ' ') failed with exit code $LASTEXITCODE."
    }
    return ($output -join "`n")
}

function Read-PrReReviewNativeOutput {
    param([Parameter(Mandatory)][string]$Command, [Parameter(Mandatory)][string[]]$Arguments)

    # Capturing a native command's stdout splits it into lines and drops the final newline;
    # PowerShell 7.4+ keeps the exact bytes when the output is redirected to a file.
    $path = [IO.Path]::GetTempFileName()
    try {
        & $Command @Arguments > $path
        if ($LASTEXITCODE -ne 0) {
            throw "$Command $($Arguments -join ' ') failed with exit code $LASTEXITCODE."
        }
        $bytes = [IO.File]::ReadAllBytes($path)
        # Preserve the existing binary fallback, but do not replace invalid text bytes: distinct
        # files could otherwise decode identically and be reported as unchanged.
        if ([Array]::IndexOf($bytes, [byte]0) -ge 0) { return $null }
        try {
            return [Text.UTF8Encoding]::new($false, $true).GetString($bytes)
        } catch [Text.DecoderFallbackException] {
            throw "Cannot decode $Command output as UTF-8; refusing to review lossy text."
        }
    } finally {
        Remove-Item -LiteralPath $path -Force -ErrorAction SilentlyContinue
    }
}

function Get-PrReReviewPullRequestInput {
    param(
        [Parameter(Mandatory)][string]$Repository,
        [Parameter(Mandatory)][int]$Number,
        [Parameter(Mandatory)][string]$ExpectedHeadSha,
        [Parameter(Mandatory)][string]$ExpectedBaseSha
    )

    $pullRequest = ConvertFrom-Json (Invoke-PrReReviewGhApi @("repos/$Repository/pulls/$Number"))
    if ($pullRequest.head.sha -cne $ExpectedHeadSha -or $pullRequest.base.sha -cne $ExpectedBaseSha) {
        throw "The event head $ExpectedHeadSha or base $ExpectedBaseSha no longer matches the pull request head $($pullRequest.head.sha) and base $($pullRequest.base.sha)."
    }
    $pages = ConvertFrom-Json (Invoke-PrReReviewGhApi @('--paginate', '--slurp', "repos/$Repository/pulls/$Number/files?per_page=100")) -NoEnumerate
    $files = @(foreach ($page in $pages) { foreach ($file in $page) { $file } })
    # A partial export would let the guard verify a review against an incomplete file list.
    if ($files.Count -ne $pullRequest.changed_files) {
        throw "GitHub listed $($files.Count) of the pull request's $($pullRequest.changed_files) changed files."
    }
    $after = ConvertFrom-Json (Invoke-PrReReviewGhApi @("repos/$Repository/pulls/$Number"))
    if ($after.head.sha -cne $ExpectedHeadSha -or $after.base.sha -cne $ExpectedBaseSha) {
        throw "The pull request head or base changed while listing files: expected $ExpectedHeadSha/$ExpectedBaseSha, got $($after.head.sha)/$($after.base.sha)."
    }
    $mergeBaseSha = ''
    $missingExistingPatches = @($files | Where-Object { $null -eq $_.patch -and $_.status -cne 'added' })
    if ($missingExistingPatches.Count -gt 0) {
        # The PR diff compares against the merge base, which can differ from the base branch tip.
        $comparison = ConvertFrom-Json (Invoke-PrReReviewGhApi @("repos/$Repository/compare/$ExpectedBaseSha...${ExpectedHeadSha}?per_page=1"))
        $mergeBaseSha = [string]$comparison.merge_base_commit.sha
        if ($mergeBaseSha -notmatch '^(?:[0-9a-f]{40}|[0-9a-f]{64})$') {
            throw 'GitHub did not return a valid merge-base commit for the pull request.'
        }
    }
    return [pscustomobject]@{ HeadSha = $ExpectedHeadSha; MergeBaseSha = $mergeBaseSha; Files = $files }
}

function Assert-PrReReviewCurrentState {
    param(
        [Parameter(Mandatory)][string]$Repository,
        [Parameter(Mandatory)][int]$Number,
        [Parameter(Mandatory)][string]$ExpectedHeadSha,
        [Parameter(Mandatory)][string]$ExpectedBaseSha
    )

    $pullRequest = ConvertFrom-Json (Invoke-PrReReviewGhApi @("repos/$Repository/pulls/$Number"))
    if ($pullRequest.head.sha -cne $ExpectedHeadSha -or $pullRequest.base.sha -cne $ExpectedBaseSha) {
        throw "The event head $ExpectedHeadSha or base $ExpectedBaseSha no longer matches the pull request head $($pullRequest.head.sha) and base $($pullRequest.base.sha); refusing stale publication."
    }
    return "The pull request head and base still match the event."
}

function Get-PrReReviewHeadContent {
    param([Parameter(Mandatory)][string]$Repository, [Parameter(Mandatory)][string]$HeadSha, [Parameter(Mandatory)][string]$Path)

    $encodedPath = ($Path -split '/' | ForEach-Object { [uri]::EscapeDataString($_) }) -join '/'
    $content = Invoke-PrReReviewGhApi -Raw -Arguments @('-H', 'Accept: application/vnd.github.raw+json', "repos/$Repository/contents/${encodedPath}?ref=$HeadSha")
    if ($null -eq $content -or $content.Contains([char]0)) {
        return $null
    }
    return $content
}

function Get-PrReReviewLocalDiff {
    param([Parameter(Mandatory)][AllowEmptyString()][string]$Old, [Parameter(Mandatory)][AllowEmptyString()][string]$New)

    $directory = Join-Path ([IO.Path]::GetTempPath()) "pr-re-review-diff-$([guid]::NewGuid())"
    [void][IO.Directory]::CreateDirectory($directory)
    try {
        $oldPath = Join-Path $directory 'old'
        $newPath = Join-Path $directory 'new'
        $encoding = [Text.UTF8Encoding]::new($false)
        [IO.File]::WriteAllText($oldPath, $Old, $encoding)
        [IO.File]::WriteAllText($newPath, $New, $encoding)
        $output = & git -c core.autocrlf=false diff --no-index --no-color --no-ext-diff --unified=3 -- $oldPath $newPath
        # git diff --no-index exits 1 when the files differ, and a pwsh step in GitHub Actions exits
        # with $LASTEXITCODE, so reset it once that result is accepted.
        if ($LASTEXITCODE -gt 1) {
            throw "git diff --no-index failed with exit code $LASTEXITCODE."
        }
        $global:LASTEXITCODE = 0
        $lines = [string[]]@($output)
        for ($start = 0; $start -lt $lines.Count -and !$lines[$start].StartsWith('@@'); $start++) { }
        if ($start -eq $lines.Count) {
            return ''
        }
        return ($lines[$start..($lines.Count - 1)] -join "`n")
    } finally {
        Remove-Item -LiteralPath $directory -Recurse -Force -ErrorAction SilentlyContinue
    }
}

function Export-PrReReviewInput {
    param(
        [Parameter(Mandatory)][AllowEmptyCollection()][object[]]$Files,
        [Parameter(Mandatory)][string]$Repository,
        [Parameter(Mandatory)][string]$HeadSha,
        [AllowEmptyString()][string]$MergeBaseSha = '',
        [Parameter(Mandatory)][string]$InputDirectory,
        [Parameter(Mandatory)][string]$MarkersPath
    )

    $separators = [char[]]@([IO.Path]::DirectorySeparatorChar, [IO.Path]::AltDirectorySeparatorChar)
    $visibleRoot = [IO.Path]::GetFullPath($InputDirectory).TrimEnd($separators) + [IO.Path]::DirectorySeparatorChar
    $markersFullPath = [IO.Path]::GetFullPath($MarkersPath)
    if ($markersFullPath.StartsWith($visibleRoot, [StringComparison]::OrdinalIgnoreCase)) {
        throw "The markers file must be written outside the agent-visible directory '$InputDirectory'."
    }

    [void][IO.Directory]::CreateDirectory((Join-Path $InputDirectory 'patches'))
    [void][IO.Directory]::CreateDirectory([IO.Path]::GetDirectoryName($markersFullPath))

    $total = $Files.Count
    $width = [Math]::Max(4, "$total".Length)
    $list = [System.Collections.Generic.List[object]]::new()
    $markers = [System.Collections.Generic.List[object]]::new()
    $readCount = 0
    $characters = 0
    for ($i = 0; $i -lt $total; $i++) {
        $file = $Files[$i]
        $number = $i + 1
        $patchFile = "patches/$("$number".PadLeft($width, '0')).patch"
        $marker = [Convert]::ToHexString([Security.Cryptography.RandomNumberGenerator]::GetBytes(8)).ToLowerInvariant()

        # Zero line counts also describe binary changes, including binary renames. Only skip
        # the full-content fallback after confirming that the old and new blobs are identical.
        $unchangedRename = $false
        if ($null -eq $file.patch -and $file.status -ceq 'renamed' -and $file.additions -eq 0 -and $file.deletions -eq 0) {
            if (!$MergeBaseSha) { throw "GitHub returned no patch for '$($file.filename)', and the merge base is unavailable." }
            if (!$file.previous_filename) { throw "GitHub returned no patch or previous path for renamed file '$($file.filename)'." }
            $previousPath = ($file.previous_filename -split '/' | ForEach-Object { [uri]::EscapeDataString($_) }) -join '/'
            $previousMetadata = ConvertFrom-Json (Invoke-PrReReviewGhApi @("repos/$Repository/contents/${previousPath}?ref=$MergeBaseSha"))
            $unchangedRename = $file.sha -cmatch '^(?:[0-9a-f]{40}|[0-9a-f]{64})$' -and $previousMetadata.sha -ceq $file.sha
        }

        $body = if ($null -ne $file.patch) {
            [string]$file.patch
        } elseif ($file.status -ceq 'removed') {
            if (!$MergeBaseSha) { throw "GitHub returned no patch for removed file '$($file.filename)', and the merge base is unavailable." }
            $previous = Get-PrReReviewHeadContent -Repository $Repository -HeadSha $MergeBaseSha -Path $file.filename
            if ($null -eq $previous) {
                'GitHub returned no patch, and the removed file has no text content at the merge base.'
            } else {
                "GitHub returned no patch; this is the removed file's full content at the merge base.`n$previous"
            }
        } elseif ($unchangedRename) {
            'GitHub returned no patch; the renamed file has identical content at the merge base and head commit.'
        } else {
            $content = Get-PrReReviewHeadContent -Repository $Repository -HeadSha $HeadSha -Path $file.filename
            $headText = if ($null -eq $content) {
                'GitHub returned no patch, and the file has no text content at the head commit.'
            } else {
                "GitHub returned no patch; this is the file's full content at the head commit.`n$content"
            }
            if ($file.status -ceq 'added') {
                $headText
            } else {
                if (!$MergeBaseSha) { throw "GitHub returned no patch for '$($file.filename)', and the merge base is unavailable." }
                if ($file.status -cin @('renamed', 'copied') -and !$file.previous_filename) {
                    throw "GitHub returned no patch or previous path for $($file.status) file '$($file.filename)'."
                }
                $previousPath = if ($file.previous_filename) { [string]$file.previous_filename } else { [string]$file.filename }
                $previous = Get-PrReReviewHeadContent -Repository $Repository -HeadSha $MergeBaseSha -Path $previousPath
                # GitHub also omits patches for small changes to files with very long lines, such as compiled
                # workflow locks, so diff the text locally instead of exporting both full copies.
                if ($null -ne $previous -and $null -ne $content) {
                    $diff = Get-PrReReviewLocalDiff -Old $previous -New $content
                    if ($diff) {
                        "GitHub returned no patch; this diff from the merge base ($previousPath) to the head commit was computed locally.`n$diff"
                    } else {
                        "GitHub returned no patch, and the file's text is identical at the merge base ($previousPath) and the head commit."
                    }
                } else {
                    $baseText = if ($null -eq $previous) { 'The file has no text content at the merge base.' } else { $previous }
                    "GitHub returned no patch; full content at the merge base ($previousPath):`n$baseText`n$headText"
                }
            }
        }

        $renamed = if ($file.previous_filename) { ", renamed from $($file.previous_filename)" } else { '' }
        $text = "# Review input ${number}/${total}: $($file.filename) ($($file.status), +$($file.additions) -$($file.deletions)$renamed)`n" +
            "$($body.TrimEnd("`n"))`n" +
            "# End of review input ${number}/${total} [$marker]`n"

        # Keep each independently verifiable read small enough for a tool result, and cut at line
        # boundaries so no diff line loses its +/- prefix. Write each patch only once: agents size
        # the review from this directory, and a second full copy doubled their estimate.
        $readFiles = [System.Collections.Generic.List[string]]::new()
        $chunks = [System.Collections.Generic.List[object]]::new()
        if ($text.Length -le 4000) {
            [IO.File]::WriteAllText((Join-Path $InputDirectory $patchFile), $text)
            $readFiles.Add($patchFile)
            $chunks.Add([ordered]@{ content = $text })
        } else {
            for ($offset = 0; $offset -lt $text.Length;) {
                $length = [Math]::Min(4000, $text.Length - $offset)
                if ($offset + $length -lt $text.Length) {
                    $newline = $text.LastIndexOf([char]"`n", $offset + $length - 1, $length)
                    if ($newline -gt $offset) { $length = $newline - $offset + 1 }
                    elseif ([char]::IsHighSurrogate($text[$offset + $length - 1])) { $length-- }
                }
                $partNumber = $chunks.Count + 1
                $partFile = "patches/$number-part-$partNumber.txt"
                $partMarker = [Convert]::ToHexString([Security.Cryptography.RandomNumberGenerator]::GetBytes(8)).ToLowerInvariant()
                $partText = "# Review input part $partNumber [$partMarker]`n" + $text.Substring($offset, $length) + "`n# End of part [$partMarker]`n"
                [IO.File]::WriteAllText((Join-Path $InputDirectory $partFile), $partText)
                $readFiles.Add($partFile)
                $chunks.Add([ordered]@{ content = $partText })
                $offset += $length
            }
        }
        $readCount += $readFiles.Count
        foreach ($chunk in $chunks) { $characters += $chunk.content.Length }

        $list.Add([ordered]@{
            path = [string]$file.filename
            status = [string]$file.status
            additions = $file.additions
            deletions = $file.deletions
            previousPath = $file.previous_filename
            readFiles = $readFiles.ToArray()
        })
        $markers.Add([ordered]@{ path = [string]$file.filename; marker = $marker; chunks = $chunks.ToArray() })
    }

    # The read set's size comes before the file list so that a partial read of files.json shows it.
    $readSet = [ordered]@{ changedFiles = $total; readFiles = $readCount; characters = $characters }
    [IO.File]::WriteAllText((Join-Path $InputDirectory 'files.json'), (ConvertTo-Json -InputObject ([ordered]@{ headSha = $HeadSha; readSet = $readSet; files = $list.ToArray() }) -Depth 5))
    [IO.File]::WriteAllText($markersFullPath, (ConvertTo-Json -InputObject ([ordered]@{ headSha = $HeadSha; files = $markers.ToArray() }) -Depth 10))
}

$script:ReplayThreadsQuery = @'
query($owner: String!, $repo: String!, $number: Int!, $cursor: String) {
  repository(owner: $owner, name: $repo) {
    pullRequest(number: $number) {
      reviewThreads(first: 100, after: $cursor) {
        pageInfo { hasNextPage endCursor }
        nodes {
          id
          isResolved
          isOutdated
          isCollapsed
          comments(first: 100) {
            totalCount
            nodes {
              author { login }
              body
              createdAt
              publishedAt
              url
              path
              line
              originalLine
              pullRequestReview { submittedAt }
            }
          }
        }
      }
    }
  }
}
'@

function ConvertTo-PrReReviewReplayCutoff {
    param([Parameter(Mandatory)][AllowEmptyString()][string]$Value)

    $cutoff = [DateTimeOffset]::MinValue
    if ($Value -cnotmatch '^\d{4}-\d{2}-\d{2}T\d{2}:\d{2}:\d{2}(?:\.\d{1,7})?(?:Z|[+-]\d{2}:\d{2})$' -or
        ![DateTimeOffset]::TryParse($Value, [Globalization.CultureInfo]::InvariantCulture, [Globalization.DateTimeStyles]::None, [ref]$cutoff)) {
        throw "The history cutoff '$Value' must be an ISO 8601 time with a UTC offset, such as 2026-11-10T19:43:40Z."
    }
    return $cutoff
}

function Get-PrReReviewReplayInput {
    param(
        [Parameter(Mandatory)][string]$Repository,
        [Parameter(Mandatory)][string]$HeadSha,
        [Parameter(Mandatory)][string]$BaseSha
    )

    # A pull request's diff is the three-dot comparison of its base and head, so a replay gets the
    # same files from the commits alone, even after the pull request has moved on.
    $comparison = ConvertFrom-Json (Invoke-PrReReviewGhApi @("repos/$Repository/compare/$BaseSha...${HeadSha}?per_page=1"))
    $files = @($comparison.files | Where-Object { $_ })
    if ($files.Count -ge 300) {
        throw "GitHub listed $($files.Count) changed files for $BaseSha...$HeadSha, the most it lists for a comparison, so the list may be partial. Replays support pull requests with fewer than 300 changed files."
    }
    $mergeBaseSha = [string]$comparison.merge_base_commit.sha
    if ($mergeBaseSha -notmatch '^(?:[0-9a-f]{40}|[0-9a-f]{64})$') {
        throw 'GitHub did not return a valid merge-base commit for the replay.'
    }
    return [pscustomobject]@{ HeadSha = $HeadSha; MergeBaseSha = $mergeBaseSha; Files = $files }
}

function Test-PrReReviewVisibleBy {
    param([AllowNull()][AllowEmptyCollection()][object[]]$Timestamps, [Parameter(Mandatory)][DateTimeOffset]$Cutoff)

    # An item became visible at its latest timestamp; a comment drafted in a pending review stays hidden until the review is submitted.
    $times = @($Timestamps | Where-Object { $_ } | ForEach-Object { [DateTimeOffset]::Parse([string]$_, [Globalization.CultureInfo]::InvariantCulture) })
    return $times.Count -gt 0 -and ($times | Sort-Object -Descending | Select-Object -First 1) -le $Cutoff
}

function Get-PrReReviewReplayPages {
    param([Parameter(Mandatory)][string]$Path)

    $pages = ConvertFrom-Json -DateKind String -NoEnumerate (Invoke-PrReReviewGhApi @('--paginate', '--slurp', $Path))
    return ,@(foreach ($page in $pages) { foreach ($item in $page) { $item } })
}

function Export-PrReReviewHistory {
    param(
        [Parameter(Mandatory)][string]$Repository,
        [Parameter(Mandatory)][int]$Number,
        [Parameter(Mandatory)][string]$HeadSha,
        [Parameter(Mandatory)][string]$BaseSha,
        [Parameter(Mandatory)][AllowEmptyCollection()][object[]]$Files,
        [Parameter(Mandatory)][DateTimeOffset]$Cutoff,
        [Parameter(Mandatory)][string]$InputDirectory
    )

    $owner, $name = $Repository -split '/', 2
    $threads = [System.Collections.Generic.List[object]]::new()
    $cursor = $null
    for ($page = 1; ; $page++) {
        if ($page -gt 100) { throw "Pull request #$Number has more review-thread pages than a replay reads." }
        $arguments = @('graphql', '-f', "query=$script:ReplayThreadsQuery", '-F', "owner=$owner", '-F', "repo=$name", '-F', "number=$Number")
        if ($cursor) { $arguments += @('-f', "cursor=$cursor") }
        $connection = (ConvertFrom-Json -DateKind String (Invoke-PrReReviewGhApi $arguments)).data.repository.pullRequest.reviewThreads
        if ($null -eq $connection) { throw "Pull request #$Number was not found in $Repository." }
        foreach ($thread in $connection.nodes) {
            $nodes = @($thread.comments.nodes)
            if ($thread.comments.totalCount -gt $nodes.Count) { throw "Review thread $($thread.id) has more comments than a replay reads." }
            $comments = @(foreach ($comment in $nodes) {
                if (Test-PrReReviewVisibleBy @($comment.createdAt, $comment.publishedAt, $comment.pullRequestReview.submittedAt) $Cutoff) {
                    [ordered]@{ author = $comment.author.login; body = $comment.body; created_at = $comment.createdAt; html_url = $comment.url; path = $comment.path; line = $comment.line; original_line = $comment.originalLine }
                }
            })
            if ($nodes.Count -eq 0 -or $comments.Count -eq 0 -or $comments[0].html_url -cne $nodes[0].url) { continue }
            $threads.Add([ordered]@{ id = $thread.id; is_resolved = $thread.isResolved; is_outdated = $thread.isOutdated; is_collapsed = $thread.isCollapsed; total_count = $comments.Count; comments = $comments })
        }
        if (!$connection.pageInfo.hasNextPage) { break }
        $cursor = $connection.pageInfo.endCursor
    }

    $reviews = @(foreach ($review in (Get-PrReReviewReplayPages "repos/$Repository/pulls/$Number/reviews?per_page=100")) {
        if ($review.state -cne 'PENDING' -and (Test-PrReReviewVisibleBy @($review.submitted_at) $Cutoff)) {
            [ordered]@{ id = $review.id; user = [ordered]@{ login = $review.user.login }; state = $review.state; body = $review.body; submitted_at = $review.submitted_at; commit_id = $review.commit_id; html_url = $review.html_url }
        }
    })
    $comments = @(foreach ($comment in (Get-PrReReviewReplayPages "repos/$Repository/issues/$Number/comments?per_page=100")) {
        if (Test-PrReReviewVisibleBy @($comment.created_at) $Cutoff) {
            [ordered]@{ id = $comment.id; user = [ordered]@{ login = $comment.user.login }; body = $comment.body; created_at = $comment.created_at; html_url = $comment.html_url }
        }
    })
    $pullRequest = ConvertFrom-Json -DateKind String (Invoke-PrReReviewGhApi @("repos/$Repository/pulls/$Number"))
    $snapshot = [ordered]@{
        number = $Number
        title = $pullRequest.title
        body = $pullRequest.body
        state = 'open'
        draft = $false
        user = [ordered]@{ login = $pullRequest.user.login }
        html_url = $pullRequest.html_url
        base = [ordered]@{ ref = $pullRequest.base.ref; sha = $BaseSha }
        head = [ordered]@{ ref = $pullRequest.head.ref; sha = $HeadSha }
        changed_files = $Files.Count
        additions = [int](($Files | Measure-Object -Property additions -Sum).Sum)
        deletions = [int](($Files | Measure-Object -Property deletions -Sum).Sum)
    }

    $directory = Join-Path $InputDirectory 'history'
    [void][IO.Directory]::CreateDirectory($directory)
    [IO.File]::WriteAllText((Join-Path $directory 'pull-request.json'), (ConvertTo-Json -InputObject $snapshot -Depth 5))
    [IO.File]::WriteAllText((Join-Path $directory 'review-threads.json'), (ConvertTo-Json -InputObject ([ordered]@{ totalCount = $threads.Count; pageInfo = [ordered]@{ hasNextPage = $false }; review_threads = $threads.ToArray() }) -Depth 10))
    [IO.File]::WriteAllText((Join-Path $directory 'reviews.json'), (ConvertTo-Json -InputObject $reviews -Depth 5))
    [IO.File]::WriteAllText((Join-Path $directory 'issue-comments.json'), (ConvertTo-Json -InputObject $comments -Depth 5))
    return $threads.Count
}

Export-ModuleMember -Function Invoke-PrReReviewGhApi, Get-PrReReviewPullRequestInput, Assert-PrReReviewCurrentState, Get-PrReReviewHeadContent, Export-PrReReviewInput, ConvertTo-PrReReviewReplayCutoff, Get-PrReReviewReplayInput, Export-PrReReviewHistory
