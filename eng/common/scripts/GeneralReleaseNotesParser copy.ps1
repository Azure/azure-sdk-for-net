. (Join-Path $PSScriptRoot common.ps1)

$HIGHLIGHTS_HEADER_REGEX = "(?<PackageName>.*)\b(?<Version>\d+\.\d+\.\d+(\-\w+\.\d)?)"
if ($Language -eq 'java')
{
    $HIGHLIGHTS_HEADER_REGEX = "(?<GroupId>com.*?)\s(?<PackageName>.*)\b(?<Version>\d+\.\d+\.\d+(\-\w+\.\d)?)"
}

function ParseLinesAsIs ($lineNo, $releaseNotesContent, $parsedReleaseNotesContent, $entryHeader, $exitHeader = $null) 
{
    $content = @()
    $line = ""
    while (($lineNo -lt $releaseNotesContent.Count) -and ($releaseNotesContent[$lineNo] -ne $exitHeader))
    {
        $line = $releaseNotesContent[$lineNo]
        if ($line -ne $entryHeader)
        {
            $content += $line
        }
        $lineNo++
    }
    $sectionName = $entryHeader.Trim("# ")
    $parsedReleaseNotesContent.Add($sectionName, $content)
    return $lineNo, $parsedReleaseNotesContent
}

function ReParseInstallationInstructionsSection ($parsedReleaseNotesContent)
{
    $SectionName = "Installation Instructions"
    $content = $parsedReleaseNotesContent[$SectionName]
    $fillMainContent = $false
    $preContent = @()
    $mainContent = @()
    foreach ($line in $content) {
        if ($line.StartsWith('```'))
        {
            $fillMainContent = $true
            continue
        }
        if ($fillMainContent) 
        {
            $mainContent += $line
        }
        else 
        {
            $preContent += $line
        }
    }
    $InstallationInstructionsSection = @{}
    $InstallationInstructionsSection.Add("PreContent", $preContent)
    $mainContentTable = ReParseInstallationInstructionsMainContent($mainContent)
    $InstallationInstructionsSection.Add("MainContent", $mainContentTable)
    $parsedReleaseNotesContent[$SectionName] = $InstallationInstructionsSection
    return $parsedReleaseNotesContent
}

function ReParseInstallationInstructionsMainContent ($mainContent)
{
    if ($mainContent -isnot [Array]) 
    {
        $mainContent = $mainContent.Split("`n")
    }
    $mainContentTable = @{}

    foreach ($line in $mainContent) 
    {
        if ($line -match $PACKAGE_INSTALL_NOTES_REGEX)
        {
            $PackageName = ($matches["PackageName"]).Trim()
            $Version = ($matches["Version"]).Trim()
            $mainContentTable["${PackageName}${Version}"] = $line
        }
        else {
            continue
        }
    }
    return $mainContentTable
}

function ReParseChangeLogSection ($content)
{
    $HEADER_REGEX = "^\#+(?<HighlightHeader>.*)\[Changelog\]\((?<ChangelogUrl>.*)\)"
    if ($content -isnot [Array]) 
    {
        $content = $content.Split("`n")
    }

    $fillPreContent = $true
    $preContent = @()
    $mainContent = @{}

    foreach ($line in $content)
    {
        if ($line -match $HEADER_REGEX)
        {
            $fillPreContent = $False
            $HighlightHeader = ($matches["HighlightHeader"]).Trim()
            $ChangeLogLink = ($matches["ChangelogUrl"]).Trim()
            $mainContent[$HighlightHeader] = @{}
            $mainContent[$HighlightHeader].Add("ChangeLogLink", $ChangeLogLink)
            $mainContent[$HighlightHeader].Add("Content", @())
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

function ReParseRegularLines ($content) 
{
    $contentAsTable = @{}
    foreach ($line in $content) 
    {
        if ($line -eq "- _Add packages_")
        {
            continue
        }
        $contentAsTable.Add($line, $true)
    }
    return $contentAsTable
}

function ParseGeneralChangeLog ($releaseNotesLocation) 
{
    $ReleaseNotesContent = Get-Content -Path $releaseNotesLocation
    $ParsedReleaseNotesContent = @{}
    $PreContent = @()
    $lineNumber = 0

    foreach($line in $ReleaseNotesContent)
    {
        if ($line.StartsWith('#'))
        {
            break
        }
        $PreContent += $line
    }
    $parsedReleaseNotesContent.Add("PreContent", $PreContent)

    while ($lineNumber -lt $ReleaseNotesContent.Count)
    {
        switch -Exact ($ReleaseNotesContent[$lineNumber])
        {
            "#### GA" {
                $lineNumber, $ParsedReleaseNotesContent = ParseLinesAsIs -lineNo $lineNumber -releaseNotesContent $ReleaseNotesContent `
                -parsedReleaseNotesContent $ParsedReleaseNotesContent -entryHeader "#### GA" -exitHeader "#### Updates"
                Break;
            }
            "#### Updates" {
                $lineNumber, $ParsedReleaseNotesContent = ParseLinesAsIs -lineNo $lineNumber -releaseNotesContent $ReleaseNotesContent `
                -parsedReleaseNotesContent $ParsedReleaseNotesContent -entryHeader "#### Updates" -exitHeader "#### Beta"
                Break;
            }
            "#### Beta" {
                $lineNumber, $ParsedReleaseNotesContent = ParseLinesAsIs -lineNo $lineNumber -releaseNotesContent $ReleaseNotesContent `
                -parsedReleaseNotesContent $ParsedReleaseNotesContent -entryHeader "#### Beta" -exitHeader "## Installation Instructions"
                Break;
            }
            "## Installation Instructions" {
                $lineNumber, $ParsedReleaseNotesContent = ParseLinesAsIs -lineNo $lineNumber -releaseNotesContent $ReleaseNotesContent `
                -parsedReleaseNotesContent $ParsedReleaseNotesContent -entryHeader "## Installation Instructions" -exitHeader "## Feedback"
                Break;
            }
            "## Feedback" {
                $lineNumber, $ParsedReleaseNotesContent = ParseLinesAsIs -lineNo $lineNumber -releaseNotesContent $ReleaseNotesContent `
                -parsedReleaseNotesContent $ParsedReleaseNotesContent -entryHeader "## Feedback" -exitHeader "## Changelog"
                Break;
            }
            "## Changelog" {
                $lineNumber, $ParsedReleaseNotesContent = ParseLinesAsIs -lineNo $lineNumber -releaseNotesContent $ReleaseNotesContent `
                -parsedReleaseNotesContent $ParsedReleaseNotesContent -entryHeader "## Changelog" -exitHeader "## Latest Releases"
                Break;
            }
            "## Latest Releases" {
                $lineNumber, $ParsedReleaseNotesContent = ParseLinesAsIs -lineNo $lineNumber -releaseNotesContent $ReleaseNotesContent `
                -parsedReleaseNotesContent $ParsedReleaseNotesContent -entryHeader "## Latest Releases"
                Break;
            }
            Default {
                $lineNumber++
            }
        }
    }
    $ParsedReleaseNotesContent = ReParseInstallationInstructionsSection -parsedReleaseNotesContent $ParsedReleaseNotesContent
    $ParsedReleaseNotesContent["Changelog"] = ReParseChangeLogSection -content $ParsedReleaseNotesContent["Changelog"]
    $ParsedReleaseNotesContent["GA"] = ReParseRegularLines -content $ParsedReleaseNotesContent["GA"]
    $ParsedReleaseNotesContent["Updates"] = ReParseRegularLines -content $ParsedReleaseNotesContent["Updates"]
    $ParsedReleaseNotesContent["Beta"] = ReParseRegularLines -content $ParsedReleaseNotesContent["Beta"]
    return $ParsedReleaseNotesContent
}

function WriteReleaseNotesContentToFile ($parsedReleaseNotesContent, $filePath) 
{
    Set-Content -Path $filePath -Value ""
    foreach ($line in $parsedReleaseNotesContent["PreContent"])
    {
        Add-Content -Path $filePath -Value $line
    }

    ## TO DO

}