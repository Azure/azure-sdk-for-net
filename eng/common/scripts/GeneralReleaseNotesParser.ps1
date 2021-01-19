. (Join-Path $PSScriptRoot common.ps1)

function Parse-LinesAsIs ($lineNo, $releaseNotesContent, $exitHeader1, $exitHeader2) 
{
    $content = @()
    while(($lineNo -lt $releaseNotesContent.Count) -and 
    ($releaseNotesContent[$lineNo] -ne $exitHeader1) -and ($releaseNotesContent[$lineNo] -ne $exitHeader2))
    {
        $line = $releaseNotesContent[$lineNo]
        if (-not $line.StartsWith("[comment]"))
        {
            $content += $line
        }
        $lineNo++
    }
    return $content
}

function Parse-GeneralReleaseNotesFile ($releaseNotesLocation) 
{
    $releaseNotesContent = Get-Content -Path $releaseNotesLocation
    $lineNumber = 0

    while ($lineNumber -lt $ReleaseNotesContent.Count)
    {
        $line = $ReleaseNotesContent[$lineNumber]
        if ($line -eq "## Release highlights")
        {
            $releaseHighlights = Parse-LinesAsIs -lineNo ($lineNumber + 1) -releaseNotesContent $ReleaseNotesContent `
            -exitHeader1 "## Need help" -exitHeader2 "## Latest Releases"
            break
        }
        $lineNumber++

    }
    return $releaseHighlights
}


function Parse-ReleaseHighlights ($content)
{
    $HEADER_REGEX = "^\#+(?<HighlightHeader>.*)\[Changelog\]\((?<ChangelogUrl>.*)\)"
    if ($content -isnot [Array]) 
    {
        $content = $content.Split("`n")
    }

    $parsedContent = @{}

    foreach ($line in $content)
    {
        if ($line -match $HEADER_REGEX)
        {
            $HighlightHeader = ($matches["HighlightHeader"]).Trim()
            $ChangeLogLink = ($matches["ChangelogUrl"]).Trim()
            $parsedContent[$HighlightHeader] = @{}
            $parsedContent[$HighlightHeader].Add("ChangeLogLink", $ChangeLogLink)
            $parsedContent[$HighlightHeader].Add("Content", @())
            continue
        }
        if ($fillPreContent)
        {
            $preContent += $line
        }
        else {
            $mainContent[$HighlightHeader]["Content"] += $line
        }
    }
    $changeLogSection = @{}
    $changeLogSection.Add("PreContent", $preContent)
    $changeLogSection.Add("MainContent", $mainContent)
    return $changeLogSection
}
