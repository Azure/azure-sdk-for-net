. (Join-Path $PSScriptRoot common.ps1)

$SECTION_REGEX = "^\[(?<SectionName>\w+)\.(?<Command>\w+)\]:\s#\s\((?<Comment>.*)\)"

function Parse-GeneralReleaseNotesFile ($releaseNotesLocation) 
{
    $releaseNotesContent = Get-Content -Path $releaseNotesLocation
    $lineNumber = 0
    $releaseHighlights = @()
    $addLines = $false

    while ($lineNumber -lt $ReleaseNotesContent.Count)
    {
        $line = $ReleaseNotesContent[$lineNumber]
        if (($line -match $SECTION_REGEX) -and ($matches["SectionName"] -eq "releasehighlights"))
        {
            if ($matches["Command"] -eq "start")
            {
                $addLines = $true
            }
            if ($matches["Command"] -eq "end")
            {
                $addLines = $false
                break
            }
        }
        if ($addLines)
        {
            $releaseHighlights += $line
        }
        $lineNumber++

    }
    return Parse-ReleaseHighlights -content $releaseHighlights
}


function Parse-ReleaseHighlights ($content)
{
    $HEADER_REGEX = "^#{3}(?<PackageName>[^0-9]*)(?<PackageVersion>.*)\[Changelog\]\((?<ChangelogUrl>.*)\)"
    if ($content -isnot [Array]) 
    {
        $content = $content.Split("`n")
    }

    $parsedContent = @{}
    $addContent = $false

    foreach ($line in $content)
    {
        if ($line -match $HEADER_REGEX)
        {
            $packageFriendlyName = ($matches["PackageName"]).Trim()
            $packageVersion = ($matches["PackageVersion"]).Trim()
            $changelogUrl = ($matches["ChangelogUrl"]).Trim()
            $parsedContentKey = "${packageFriendlyName}:${packageVersion}"
            $parsedContent[$parsedContentKey] = @{}
            $parsedContent[$parsedContentKey]["ChangelogUrl"] = $changelogUrl
            $parsedContent[$parsedContentKey]["Content"] = @()
            $addContent = $true
            continue
        }
        elseif ($addContent) {
            $parsedContent[$parsedContentKey]["Content"] += $line
        }
    }
    return $parsedContent
}
