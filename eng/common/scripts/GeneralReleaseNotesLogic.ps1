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

    $releaseHighlights = @{}
    $addContent = $false

    foreach ($line in $content)
    {
        if ($line -match $HEADER_REGEX)
        {
            $packageName = ($matches["PackageName"]).Trim()
            $packageVersion = ($matches["PackageVersion"]).Trim()
            $changelogUrl = ($matches["ChangelogUrl"]).Trim()
            $key = "${packageName}:${packageVersion}"
            $releaseHighlights[$key] = @{}
            $releaseHighlights[$key]["ChangelogUrl"] = $changelogUrl
            $releaseHighlights[$key]["Content"] = @()
            $addContent = $true
            continue
        }
        elseif ($addContent) {
            $releaseHighlights[$key]["Content"] += $line
        }
    }
    return $releaseHighlights
}

function Filter-ReleaseHighlights ($releaseHighlights)
{
    foreach ($key in $releaseHighlights.Keys)
    {
        $keyInfo = $key.Split(":")
        $packageName = $keyInfo[0]
        $packageVersion = $keyInfo[1]

        $existingPackages = GetExistingPackageVersions -PackageName $packageName

        if ()
    }
}

function Write-GeneralReleaseNote ($releaseHighlights, $releaseFilePath)
{
    $releaseContent = Get-Content $releaseFilePath
    $newReleaseContent = @()
    $lineNumber = 0

    while ($lineNumber -lt $releaseContent.Count)
    {
        $line = $releaseContent[$lineNumber]

    }
}
