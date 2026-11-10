#Requires -Version 7.5

# Copyright (c) Microsoft Corporation. All rights reserved.
# Licensed under the MIT License.

$ErrorActionPreference = 'Stop'

function Invoke-PrReReviewGhApi {
    param([Parameter(Mandatory)][string[]]$Arguments)

    $output = & gh api @Arguments
    if ($LASTEXITCODE -ne 0) {
        throw "gh api $($Arguments -join ' ') failed with exit code $LASTEXITCODE."
    }
    return ($output -join "`n")
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
    $missingExistingPatches = @($files | Where-Object { $null -eq $_.patch -and $_.status -cne 'added' -and ($_.status -ceq 'removed' -or $_.additions -ne 0 -or $_.deletions -ne 0) })
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
    $content = Invoke-PrReReviewGhApi @('-H', 'Accept: application/vnd.github.raw+json', "repos/$Repository/contents/${encodedPath}?ref=$HeadSha")
    if ($content.Contains([char]0)) {
        return $null
    }
    return $content
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
        } elseif ($file.status -cne 'added' -and $file.additions -eq 0 -and $file.deletions -eq 0) {
            'GitHub returned no patch and reports no line changes for this file.'
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
                $baseText = if ($null -eq $previous) { 'The file has no text content at the merge base.' } else { $previous }
                "GitHub returned no patch; full content at the merge base ($previousPath):`n$baseText`n$headText"
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

Export-ModuleMember -Function Invoke-PrReReviewGhApi, Get-PrReReviewPullRequestInput, Assert-PrReReviewCurrentState, Get-PrReReviewHeadContent, Export-PrReReviewInput
