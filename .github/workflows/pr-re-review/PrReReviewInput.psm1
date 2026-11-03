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
    param([Parameter(Mandatory)][string]$Repository, [Parameter(Mandatory)][int]$Number)

    $pullRequest = ConvertFrom-Json (Invoke-PrReReviewGhApi @("repos/$Repository/pulls/$Number"))
    $pages = ConvertFrom-Json (Invoke-PrReReviewGhApi @('--paginate', '--slurp', "repos/$Repository/pulls/$Number/files?per_page=100")) -NoEnumerate
    $files = @(foreach ($page in $pages) { foreach ($file in $page) { $file } })
    # A partial export would let the guard verify a review against an incomplete file list.
    if ($files.Count -ne $pullRequest.changed_files) {
        throw "GitHub listed $($files.Count) of the pull request's $($pullRequest.changed_files) changed files."
    }
    return [pscustomobject]@{ HeadSha = [string]$pullRequest.head.sha; Files = $files }
}

function Get-PrReReviewHeadContent {
    param([Parameter(Mandatory)][string]$Repository, [Parameter(Mandatory)][string]$HeadSha, [Parameter(Mandatory)][string]$Path)

    $encodedPath = ($Path -split '/' | ForEach-Object { [uri]::EscapeDataString($_) }) -join '/'
    try {
        $content = Invoke-PrReReviewGhApi @('-H', 'Accept: application/vnd.github.raw+json', "repos/$Repository/contents/${encodedPath}?ref=$HeadSha")
    } catch {
        return $null
    }
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
            'GitHub returned no patch for this removed file.'
        } else {
            $content = Get-PrReReviewHeadContent -Repository $Repository -HeadSha $HeadSha -Path $file.filename
            if ($null -eq $content) {
                'GitHub returned no patch, and the file has no text content at the head commit.'
            } else {
                "GitHub returned no patch; this is the file's full content at the head commit.`n$content"
            }
        }

        $renamed = if ($file.previous_filename) { ", renamed from $($file.previous_filename)" } else { '' }
        $text = "# Review input ${number}/${total}: $($file.filename) ($($file.status), +$($file.additions) -$($file.deletions)$renamed)`n" +
            "$($body.TrimEnd("`n"))`n" +
            "# End of review input ${number}/${total} [$marker]`n"
        [IO.File]::WriteAllText((Join-Path $InputDirectory $patchFile), $text)

        $list.Add([ordered]@{
            path = [string]$file.filename
            status = [string]$file.status
            additions = $file.additions
            deletions = $file.deletions
            previousPath = $file.previous_filename
            patchFile = $patchFile
        })
        $markers.Add([ordered]@{ path = [string]$file.filename; marker = $marker })
    }

    [IO.File]::WriteAllText((Join-Path $InputDirectory 'files.json'), (ConvertTo-Json -InputObject ([ordered]@{ headSha = $HeadSha; files = $list.ToArray() }) -Depth 5))
    [IO.File]::WriteAllText($markersFullPath, (ConvertTo-Json -InputObject ([ordered]@{ headSha = $HeadSha; files = $markers.ToArray() }) -Depth 5))
}

Export-ModuleMember -Function Invoke-PrReReviewGhApi, Get-PrReReviewPullRequestInput, Get-PrReReviewHeadContent, Export-PrReReviewInput
