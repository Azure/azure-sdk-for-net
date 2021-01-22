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
    $results = @{}

    foreach ($key in $releaseHighlights.Keys)
    {
        $keyInfo = $key.Split(":")
        $packageName = $keyInfo[0]
        $packageVersion = $keyInfo[1]

        $csvMetaData = Get-CSVMetadata
        $packageMetaData = $csvMetaData | Where-Object { $_.Package -eq $packageName }

        if ($packageMetaData.ServiceName -eq "template")
        {
            continue
        }

        $existingPackages = GetExistingPackageVersions -PackageName $packageName `
        -GroupId $packageMetaData.GroupId

        $versionExists = $existingPackages | Where-Object { $_ -eq $packageVersion }

        if ($null -eq $versionExists)
        {
            continue
        }

        $results.Add($key, $releaseHighlights[$key])
    }
    return $results
}

function Write-GeneralReleaseNotesSections ($releaseHighlights, $csvMetaData, $sectionName)
{
    $sectionContent = @()
    $sectionContent += ""
    foreach ($key in $releaseHighlights.Keys)
    {
        $keyInfo = $key.Split(":")
        $packageName = $keyInfo[0]
        $packageVersion = $keyInfo[1]
        $packageSemVer = [AzureEngSemanticVersion]::ParseVersionString($packageVersion)
        
        if ($null -eq $packageSemVer)
        {
            LogWarning "Invalid version [ $packageVersion ] detected"
            continue
        }

        if ($packageSemVer.VersionType -eq $sectionName)
        {
            $packageFriendlyName = ($csvMetaData | Where-Object { $_.Package -eq $packageName }).DisplayName
            $sectionContent += "- ${packageFriendlyName}"
        }
    }
    $sectionContent += ""
    return $sectionContent
}

function Write-GeneralReleaseNote ($releaseHighlights, $releaseFilePath)
{
    $csvMetaData = Get-CSVMetadata
    $releaseContent = Get-Content $releaseFilePath
    $newReleaseContent = @()
    $lineNumber = 0

    while ($lineNumber -lt $releaseContent.Count)
    {
        $line = $releaseContent[$lineNumber]
        if($line -match $SECTION_REGEX)
        {
            if (($matches["SectionName"] -eq "ga") -and ($matches["Command"] -eq "start"))
            {
                $newReleaseContent += $line


            }
        }

    }
}
