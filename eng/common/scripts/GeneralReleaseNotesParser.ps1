param (
  [string]$ReleaseNotesLocation
)

. (Join-Path $PSScriptRoot common.ps1)

function ParseLinesAsIs ($lineNo, $entryHeader, $exitHeader = $null) 
{
    $content = @()
    $line = ""
    while (($lineNo -lt $ReleaseNotesContent.Count) -and ($ReleaseNotesContent[$lineNo] -ne $exitHeader))
    {
        $line = $ReleaseNotesContent[$lineNo]
        if ($line -ne $entryHeader)
        {
            $content += $line
        }
        $lineNo++
    }
    $sectionName = $entryHeader.Trim("# ")
    $ParsedReleaseNotesContent.Add($sectionName, $content)
    return $lineNo
}

function ReParseInstallationInstructionsSection 
{
    $SectionName = "Installation Instructions"
    $content = $ParsedReleaseNotesContent[$SectionName]
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
    $ParsedReleaseNotesContent[$SectionName] = $InstallationInstructionsSection
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

function ReParseChangeLogSection 
{
    $HEADER_REGEX = "^\#+(?<PackageName>.*)\[Changelog\]\((?<ChangelogUrl>.*)\)"
    $SectionName = "Changelog"
    $content = $ParsedReleaseNotesContent[$SectionName]

    $fillPreContent = $true
    $preContent = @()
    $mainContent = @{}

    foreach ($line in $content)
    {
        if ($line -match $HEADER_REGEX)
        {
            $fillPreContent = $False
            $PackageName = ($matches["PackageName"]).Trim()
            $ChangeLogLink = ($matches["ChangelogUrl"]).Trim()
            $mainContent[$PackageName] = @{}
            $mainContent[$PackageName].Add("ChangeLogLink", $ChangeLogLink)
            $mainContent[$PackageName].Add("Content", @())
            continue
        }
        if ($fillPreContent)
        {
            $preContent += $line
        }
        else {
            $mainContent[$PackageName]["Content"] += $line
        }
    }
    $ChangeLogSection = @{}
    $ChangeLogSection.Add("PreContent", $preContent)
    $ChangeLogSection.Add("MainContent", $mainContent)
    $ParsedReleaseNotesContent[$SectionName] = $ChangeLogSection
}

$ReleaseNotesContent = Get-Content -Path $ReleaseNotesLocation
$ParsedReleaseNotesContent = @{}
$lineNumber = 0

while ($lineNumber -lt $ReleaseNotesContent.Count)
{
    switch -Exact ($ReleaseNotesContent[$lineNumber])
    {
        "#### GA" {
            $lineNumber = ParseLinesAsIs -lineNo $lineNumber -entryHeader "#### GA" -exitHeader "#### Updates"
            Break;
        }
        "#### Updates" {
            $lineNumber = ParseLinesAsIs -lineNo $lineNumber -entryHeader "#### Updates" -exitHeader "#### Beta"
            Break;
        }
        "#### Beta" {
            $lineNumber = ParseLinesAsIs -lineNo $lineNumber -entryHeader "#### Beta" -exitHeader "## Installation Instructions"
            Break;
        }
        "## Installation Instructions" {
            $lineNumber = ParseLinesAsIs -lineNo $lineNumber -entryHeader "## Installation Instructions" -exitHeader "## Feedback"
            Break;
        }
        "## Feedback" {
            $lineNumber = ParseLinesAsIs -lineNo $lineNumber -entryHeader "## Feedback" -exitHeader "## Changelog"
            Break;
        }
        "## Changelog" {
            $lineNumber = ParseLinesAsIs -lineNo $lineNumber -entryHeader "## Changelog" -exitHeader "## Latest Releases"
            Break;
        }
        "## Latest Releases" {
            $lineNumber = ParseLinesAsIs -lineNo $lineNumber -entryHeader "## Latest Releases"
            Break;
        }
        Default {
            $lineNumber++
        }
    }
}

ReParseInstallationInstructionsSection
ReParseChangeLogSection
return $ParsedReleaseNotesContent