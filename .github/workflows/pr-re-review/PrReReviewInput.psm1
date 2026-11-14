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

function Get-PrReReviewGitInput {
    param(
        [Parameter(Mandatory)][string]$Repository,
        [Parameter(Mandatory)][int]$Number,
        [Parameter(Mandatory)][string]$ExpectedHeadSha,
        [Parameter(Mandatory)][string]$ExpectedBaseSha,
        [Parameter(Mandatory)][string]$GitDirectory
    )

    if ($ExpectedHeadSha -cnotmatch '^(?:[0-9a-f]{40}|[0-9a-f]{64})$' -or $ExpectedBaseSha -cnotmatch '^(?:[0-9a-f]{40}|[0-9a-f]{64})$') {
        throw 'The event head and base must be full lowercase commit SHAs.'
    }
    $pullRequest = ConvertFrom-Json (Invoke-PrReReviewGhApi @("repos/$Repository/pulls/$Number"))
    if ($pullRequest.head.sha -cne $ExpectedHeadSha -or $pullRequest.base.sha -cne $ExpectedBaseSha) {
        throw 'The pull request head or base no longer matches the event.'
    }
    $expectedCount = 0
    if (![int]::TryParse([string]$pullRequest.changed_files, [ref]$expectedCount) -or $expectedCount -lt 0) {
        throw 'GitHub did not provide a valid changed-file count.'
    }

    # Git only reads the checked-out objects. Do not pass GitHub credentials to it,
    # and do not allow missing objects to trigger a network fetch during capture.
    $previousEnvironment = @{}
    foreach ($name in 'GH_TOKEN', 'GITHUB_TOKEN', 'GITHUB_CODESPACE_TOKEN', 'GH_ENTERPRISE_TOKEN', 'GITHUB_ENTERPRISE_TOKEN', 'GIT_ALLOW_PROTOCOL') {
        $previousEnvironment[$name] = [Environment]::GetEnvironmentVariable($name)
    }
    $inventoryPath = [IO.Path]::GetTempFileName()
    try {
        foreach ($name in 'GH_TOKEN', 'GITHUB_TOKEN', 'GITHUB_CODESPACE_TOKEN', 'GH_ENTERPRISE_TOKEN', 'GITHUB_ENTERPRISE_TOKEN') {
            [Environment]::SetEnvironmentVariable($name, $null)
        }
        $env:GIT_ALLOW_PROTOCOL = 'file'
        $shallow = (Read-PrReReviewNativeOutput -Command 'git' -Arguments @('-C', $GitDirectory, 'rev-parse', '--is-shallow-repository')).Trim()
        if ($shallow -cne 'false') { throw 'The local Git checkout is shallow; a complete history is required.' }
        $head = (Read-PrReReviewNativeOutput -Command 'git' -Arguments @('-C', $GitDirectory, 'rev-parse', '--verify', 'HEAD^{commit}')).Trim()
        if ($head -cne $ExpectedHeadSha) { throw 'The local checkout does not match the event head.' }
        $mergeBases = @((Read-PrReReviewNativeOutput -Command 'git' -Arguments @('-C', $GitDirectory, 'merge-base', '--all', $ExpectedBaseSha, $ExpectedHeadSha)) -split '\r?\n' | Where-Object { $_ })
        if ($mergeBases.Count -ne 1 -or $mergeBases[0] -cnotmatch '^(?:[0-9a-f]{40}|[0-9a-f]{64})$') {
            throw 'The event commits must have exactly one available merge base.'
        }
        $mergeBase = $mergeBases[0]

        & git -C $GitDirectory diff --name-status -z --find-renames=50% --no-ext-diff --no-textconv --ignore-submodules=none $mergeBase $ExpectedHeadSha -- > $inventoryPath
        if ($LASTEXITCODE -ne 0) { throw "Git could not enumerate the PR changes (exit code $LASTEXITCODE)." }
        $bytes = [IO.File]::ReadAllBytes($inventoryPath)
        $inventory = [Text.UTF8Encoding]::new($false, $true).GetString($bytes)
        if ($inventory.Length -gt 0 -and !$inventory.EndsWith([string][char]0, [StringComparison]::Ordinal)) {
            throw 'Git returned an incomplete NUL-delimited inventory.'
        }
        $tokens = if ($inventory.Length -eq 0) { @() } else { $inventory.Split([char]0)[0..($inventory.Split([char]0).Count - 2)] }
        $files = [Collections.Generic.List[object]]::new()
        for ($i = 0; $i -lt $tokens.Count;) {
            $code = $tokens[$i++]
            if ($code -cnotmatch '^(?:A|D|M|T|R[0-9]+|C[0-9]+)$' -or $i -ge $tokens.Count -or !$tokens[$i]) {
                throw 'Git returned a malformed changed-file record.'
            }
            $path = $tokens[$i++]
            $previous = $null
            $status = switch ($code[0]) {
                'A' { 'added' }
                'D' { 'removed' }
                'M' { 'modified' }
                'T' { 'modified' }
                'R' { 'renamed' }
                'C' { 'copied' }
            }
            if ($status -cin @('renamed', 'copied')) {
                if ($i -ge $tokens.Count -or !$tokens[$i]) { throw 'Git returned an incomplete rename or copy record.' }
                $previous = $path
                $path = $tokens[$i++]
            }
            $files.Add([pscustomobject]@{ filename = $path; previous_filename = $previous; status = $status; typeChange = ($code -ceq 'T'); additions = 0; deletions = 0; patch = '' })
        }
        if ($files.Count -ne $expectedCount) {
            throw "Git listed $($files.Count) changes, but GitHub reports $expectedCount changed files."
        }

        $diff = Read-PrReReviewNativeOutput -Command 'git' -Arguments @('-C', $GitDirectory, 'diff', '--binary', '--full-index', '--no-ext-diff', '--no-textconv', '--find-renames=50%', '--ignore-submodules=none', '--submodule=short', $mergeBase, $ExpectedHeadSha, '--')
        if ($null -eq $diff) { throw 'Git returned a diff that cannot be represented as text.' }
        $headers = [regex]::Matches($diff, '(?m)^diff --git ')
        if (($headers.Count -eq 0 -and $diff.Length -ne 0) -or ($headers.Count -gt 0 -and $headers[0].Index -ne 0)) {
            throw 'Git returned unexpected data before the diff sections.'
        }
        # Git emits a deletion and an addition section for a single type-change record.
        $expectedHeaders = $files.Count + @($files | Where-Object { $_.typeChange }).Count
        if ($headers.Count -ne $expectedHeaders) { throw 'Git returned a diff that does not match the changed-file inventory.' }
        $headerIndex = 0
        for ($i = 0; $i -lt $files.Count; $i++) {
            $start = $headers[$headerIndex].Index
            $headerIndex += if ($files[$i].typeChange) { 2 } else { 1 }
            $end = if ($headerIndex -lt $headers.Count) { $headers[$headerIndex].Index } else { $diff.Length }
            $patch = $diff.Substring($start, $end - $start)
            $files[$i].patch = $patch
            $inHunk = $false
            foreach ($line in $patch -split "`n") {
                if ($line.StartsWith('diff --git ', [StringComparison]::Ordinal)) { $inHunk = $false; continue }
                if ($line.StartsWith('@@ ', [StringComparison]::Ordinal)) { $inHunk = $true; continue }
                if ($inHunk -and $line.StartsWith('+', [StringComparison]::Ordinal)) { $files[$i].additions++ }
                elseif ($inHunk -and $line.StartsWith('-', [StringComparison]::Ordinal)) { $files[$i].deletions++ }
            }
        }
    } finally {
        Remove-Item -LiteralPath $inventoryPath -Force -ErrorAction SilentlyContinue
        foreach ($name in $previousEnvironment.Keys) { [Environment]::SetEnvironmentVariable($name, $previousEnvironment[$name]) }
    }

    $after = ConvertFrom-Json (Invoke-PrReReviewGhApi @("repos/$Repository/pulls/$Number"))
    if ($after.head.sha -cne $ExpectedHeadSha -or $after.base.sha -cne $ExpectedBaseSha -or $after.changed_files -ne $expectedCount) {
        throw 'The pull request head, base, or changed-file count changed while reading the local diff.'
    }
    return [pscustomobject]@{ HeadSha = $ExpectedHeadSha; MergeBaseSha = $mergeBase; Files = $files.ToArray() }
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
        [IO.File]::WriteAllText((Join-Path $InputDirectory $patchFile), $text)

        # Keep each independently verifiable read small enough for a tool result, and cut at line
        # boundaries so no diff line loses its +/- prefix. The original patch remains available for
        # context; large patches must be read through these parts.
        $readFiles = [System.Collections.Generic.List[string]]::new()
        $chunks = [System.Collections.Generic.List[object]]::new()
        if ($text.Length -le 4000) {
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

        $list.Add([ordered]@{
            path = [string]$file.filename
            status = [string]$file.status
            additions = $file.additions
            deletions = $file.deletions
            previousPath = $file.previous_filename
            patchFile = $patchFile
            readFiles = $readFiles.ToArray()
        })
        $markers.Add([ordered]@{ path = [string]$file.filename; marker = $marker; chunks = $chunks.ToArray() })
    }

    [IO.File]::WriteAllText((Join-Path $InputDirectory 'files.json'), (ConvertTo-Json -InputObject ([ordered]@{ headSha = $HeadSha; files = $list.ToArray() }) -Depth 5))
    [IO.File]::WriteAllText($markersFullPath, (ConvertTo-Json -InputObject ([ordered]@{ headSha = $HeadSha; files = $markers.ToArray() }) -Depth 10))
}

Export-ModuleMember -Function Invoke-PrReReviewGhApi, Get-PrReReviewPullRequestInput, Get-PrReReviewGitInput, Assert-PrReReviewCurrentState, Get-PrReReviewHeadContent, Export-PrReReviewInput
