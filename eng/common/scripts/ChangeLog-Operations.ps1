# Common Changelog Operations
. "${PSScriptRoot}\logging.ps1"
. "${PSScriptRoot}\SemVer.ps1"

$RELEASE_TITLE_REGEX = "(?<releaseNoteTitle>^\#+\s+(?<version>$([AzureEngSemanticVersion]::SEMVER_REGEX))(\s+(?<releaseStatus>\(.+\))))"
$SECTION_HEADER_REGEX_SUFFIX = "##\s(?<sectionName>.*)"
$CHANGELOG_UNRELEASED_STATUS = "(Unreleased)"
$CHANGELOG_DATE_FORMAT = "yyyy-MM-dd"
$RecommendedSectionHeaders = @("Features Added", "Breaking Changes", "Bugs Fixed", "Other Changes")

# Returns a Collection of changeLogEntry object containing changelog info for all version present in the gived CHANGELOG
function Get-ChangeLogEntries {
  param (
    [Parameter(Mandatory = $true)]
    [String]$ChangeLogLocation
  )

  if (!(Test-Path $ChangeLogLocation)) {
    LogError "ChangeLog[${ChangeLogLocation}] does not exist"
    return $null
  }
  LogDebug "Extracting entries from [${ChangeLogLocation}]."
  return Get-ChangeLogEntriesFromContent (Get-Content -Path $ChangeLogLocation)
}

function Get-ChangeLogEntriesFromContent {
  param (
    [Parameter(Mandatory = $true)]
    $changeLogContent
  )

  if ($changeLogContent -is [string])
  {
    $changeLogContent = $changeLogContent.Split("`n")
  }
  elseif($changeLogContent -isnot [array])
  {
    LogError "Invalid ChangelogContent passed"
    return $null
  }

  $changelogEntry = $null
  $sectionName = $null
  $changeLogEntries = [Ordered]@{}
  $initialAtxHeader= "#"

  if ($changeLogContent[0] -match "(?<HeaderLevel>^#+)\s.*")
  {
    $initialAtxHeader = $matches["HeaderLevel"]
  }

  $sectionHeaderRegex = "^${initialAtxHeader}${SECTION_HEADER_REGEX_SUFFIX}"
  $changeLogEntries | Add-Member -NotePropertyName "InitialAtxHeader" -NotePropertyValue $initialAtxHeader
  $releaseTitleAtxHeader = $initialAtxHeader + "#"

  try {
    # walk the document, finding where the version specifiers are and creating lists
    foreach ($line in $changeLogContent) {
      if ($line -match $RELEASE_TITLE_REGEX) {
        $changeLogEntry = [pscustomobject]@{
          ReleaseVersion = $matches["version"]
          ReleaseStatus  =  $matches["releaseStatus"]
          ReleaseTitle   = "$releaseTitleAtxHeader {0} {1}" -f $matches["version"], $matches["releaseStatus"]
          ReleaseContent = @()
          Sections = @{}
        }
        $changeLogEntries[$changeLogEntry.ReleaseVersion] = $changeLogEntry
      }
      else {
        if ($changeLogEntry) {
          if ($line.Trim() -match $sectionHeaderRegex)
          {
            $sectionName = $matches["sectionName"].Trim()
            $changeLogEntry.Sections[$sectionName] = @()
            $changeLogEntry.ReleaseContent += $line
            continue
          }

          if ($sectionName)
          {
            $changeLogEntry.Sections[$sectionName] += $line
          }

          $changeLogEntry.ReleaseContent += $line
        }
      }
    }
  }
  catch {
    Write-Error "Error parsing Changelog."
    Write-Error $_
  }
  return $changeLogEntries
}

# Returns single changeLogEntry object containing the ChangeLog for a particular version
function Get-ChangeLogEntry {
  param (
    [Parameter(Mandatory = $true)]
    [String]$ChangeLogLocation,
    [Parameter(Mandatory = $true)]
    [String]$VersionString
  )
  $changeLogEntries = Get-ChangeLogEntries -ChangeLogLocation $ChangeLogLocation

  if ($changeLogEntries -and $changeLogEntries.Contains($VersionString)) {
    return $changeLogEntries[$VersionString]
  }
  return $null
}

#Returns the changelog for a particular version as string
function Get-ChangeLogEntryAsString {
  param (
    [Parameter(Mandatory = $true)]
    [String]$ChangeLogLocation,
    [Parameter(Mandatory = $true)]
    [String]$VersionString
  )

  $changeLogEntry = Get-ChangeLogEntry -ChangeLogLocation $ChangeLogLocation -VersionString $VersionString
  return ChangeLogEntryAsString $changeLogEntry
}

function ChangeLogEntryAsString($changeLogEntry) {
  if (!$changeLogEntry) {
    return "[Missing change log entry]"
  }
  [string]$releaseTitle = $changeLogEntry.ReleaseTitle
  [string]$releaseContent = $changeLogEntry.ReleaseContent -Join [Environment]::NewLine
  return $releaseTitle, $releaseContent -Join [Environment]::NewLine
}

function Confirm-ChangeLogEntry {
  param (
    [Parameter(Mandatory = $true)]
    [String]$ChangeLogLocation,
    [Parameter(Mandatory = $true)]
    [String]$VersionString,
    [boolean]$ForRelease = $false,
    [Switch]$SantizeEntry
  )

  $changeLogEntries = Get-ChangeLogEntries -ChangeLogLocation $ChangeLogLocation
  $changeLogEntry = $changeLogEntries[$VersionString]

  if (!$changeLogEntry) {
    LogError "ChangeLog[${ChangeLogLocation}] does not have an entry for version ${VersionString}."
    return $false
  }

  if ($SantizeEntry)
  {
    Remove-EmptySections -ChangeLogEntry $changeLogEntry -InitialAtxHeader $changeLogEntries.InitialAtxHeader
    Set-ChangeLogContent -ChangeLogLocation $ChangeLogLocation -ChangeLogEntries $changeLogEntries
  }

  Write-Host "Found the following change log entry for version '${VersionString}' in [${ChangeLogLocation}]."
  Write-Host "-----"
  Write-Host (ChangeLogEntryAsString $changeLogEntry)
  Write-Host "-----"

  if ([System.String]::IsNullOrEmpty($changeLogEntry.ReleaseStatus)) {
    LogError "Entry does not have a correct release status. Please ensure the status is set to a date '($CHANGELOG_DATE_FORMAT)' or '$CHANGELOG_UNRELEASED_STATUS' if not yet released. See https://aka.ms/azsdk/guideline/changelogs for more info."
    return $false
  }

  if ($ForRelease -eq $True)
  {
    LogDebug "Verifying like it's a release build because ForRelease parameter is set to true"
    return Confirm-LikeForRelease -changeLogEntry $changeLogEntry
  }

  # If the release status is a valid date then verify like its about to be released
  $status = $changeLogEntry.ReleaseStatus.Trim().Trim("()")
  if ($status -as [DateTime])
  {
    LogDebug "Verifying like it's a release build because the changelog entry has a valid date."
    return Confirm-LikeForRelease -changeLogEntry $changeLogEntry
  }

  return $true
}

function New-ChangeLogEntry {
  param (
    [Parameter(Mandatory = $true)]
    [ValidateNotNullOrEmpty()]
    [String]$Version,
    [String]$Status=$CHANGELOG_UNRELEASED_STATUS,
    [String]$InitialAtxHeader="#",
    [String[]]$Content
  )

  # Validate RelaseStatus
  $Status = $Status.Trim().Trim("()")
  if ($Status -ne "Unreleased") {
    try {
      $Status = ([DateTime]$Status).ToString($CHANGELOG_DATE_FORMAT)
    }
    catch {
        LogWarning "Invalid date [ $Status ] passed as status for Version [$Version]. Please use a valid date in the format '$CHANGELOG_DATE_FORMAT' or use '$CHANGELOG_UNRELEASED_STATUS'"
        return $null
    }
  }
  $Status = "($Status)"

  # Validate Version
  try {
    $Version = ([AzureEngSemanticVersion]::ParseVersionString($Version)).ToString()
  }
  catch {
    LogWarning "Invalid version [ $Version ]."
    return $null
  }

  if (!$Content) {
    $Content = @()
    $Content += ""

    $sectionsAtxHeader = $InitialAtxHeader + "##"
    foreach ($recommendedHeader in $RecommendedSectionHeaders)
    {
      $Content += "$sectionsAtxHeader $recommendedHeader"
      $Content += ""
    }
  }

  $releaseTitleAtxHeader = $initialAtxHeader + "#"

  $newChangeLogEntry = [pscustomobject]@{
    ReleaseVersion = $Version
    ReleaseStatus  = $Status
    ReleaseTitle   = "$releaseTitleAtxHeader $Version $Status"
    ReleaseContent = $Content
  }

  return $newChangeLogEntry
}

function Set-ChangeLogContent {
  param (
    [Parameter(Mandatory = $true)]
    [String]$ChangeLogLocation,
    [Parameter(Mandatory = $true)]
    $ChangeLogEntries
  )

  $changeLogContent = @()
  $changeLogContent += "$($ChangeLogEntries.InitialAtxHeader) Release History"
  $changeLogContent += ""

  try
  {
    $ChangeLogEntries = $ChangeLogEntries.Values | Sort-Object -Descending -Property ReleaseStatus, `
      @{e = {[AzureEngSemanticVersion]::new($_.ReleaseVersion)}}
  }
  catch {
    LogError "Problem sorting version in ChangeLogEntries"
    return
  }

  foreach ($changeLogEntry in $ChangeLogEntries) {
    $changeLogContent += $changeLogEntry.ReleaseTitle
    if ($changeLogEntry.ReleaseContent.Count -eq 0) {
      $changeLogContent += @("","")
    }
    else {
      $changeLogContent += $changeLogEntry.ReleaseContent
    }
  }

  Set-Content -Path $ChangeLogLocation -Value $changeLogContent
}

function Remove-EmptySections {
  param (
    [Parameter(Mandatory = $true)]
    $ChangeLogEntry,
    $InitialAtxHeader = "#"
  )

  $sectionHeaderRegex = "^${InitialAtxHeader}${SECTION_HEADER_REGEX_SUFFIX}"
  $releaseContent = $ChangeLogEntry.ReleaseContent

  if ($releaseContent.Count -gt 0)
  {
    $parsedSections = $ChangeLogEntry.Sections
    $sanitizedReleaseContent = New-Object System.Collections.ArrayList(,$releaseContent)
  
    foreach ($key in @($parsedSections.Keys)) 
    {
      if ([System.String]::IsNullOrWhiteSpace($parsedSections[$key]))
      {
        for ($i = 0; $i -lt $sanitizedReleaseContent.Count; $i++)
        {
          $line = $sanitizedReleaseContent[$i]
          if ($line -match $sectionHeaderRegex -and $matches["sectionName"].Trim() -eq $key)
          {
            $sanitizedReleaseContent.RemoveAt($i)
            while($i -lt $sanitizedReleaseContent.Count -and [System.String]::IsNullOrWhiteSpace($sanitizedReleaseContent[$i]))
            {
              $sanitizedReleaseContent.RemoveAt($i)
            }
            $ChangeLogEntry.Sections.Remove($key)
            break
          }
        }
      }
    }
    $ChangeLogEntry.ReleaseContent = $sanitizedReleaseContent.ToArray()
  }
}

function  Get-LatestReleaseDateFromChangeLog
{
  param (
    [Parameter(Mandatory = $true)]
    $ChangeLogLocation
  )
  $changeLogEntries = Get-ChangeLogEntries -ChangeLogLocation $ChangeLogLocation
  $latestVersion = $changeLogEntries[0].ReleaseStatus.Trim("()")
  return ($latestVersion -as [DateTime])
}

function Confirm-LikeForRelease {
  param (
    [Parameter(Mandatory = $true)]
    $changeLogEntry
  )

  $isValid = $true
  if ($changeLogEntry.ReleaseStatus -eq $CHANGELOG_UNRELEASED_STATUS) {
    LogError "Entry has no release date set. Please ensure to set a release date with format '$CHANGELOG_DATE_FORMAT'. See https://aka.ms/azsdk/guideline/changelogs for more info."
    $isValid = $false
  }
  else {
    $status = $changeLogEntry.ReleaseStatus.Trim().Trim("()")
    try {
      $releaseDate = [DateTime]$status
      if ($status -ne ($releaseDate.ToString($CHANGELOG_DATE_FORMAT)))
      {
        LogError "Date must be in the format $($CHANGELOG_DATE_FORMAT). See https://aka.ms/azsdk/guideline/changelogs for more info."
        $isValid = $false
      }
      if (((Get-Date).AddMonths(-1) -gt $releaseDate) -or ($releaseDate -gt (Get-Date).AddMonths(1)))
      {
        LogError "The date must be within +/- one month from today. See https://aka.ms/azsdk/guideline/changelogs for more info."
        $isValid = $false
      }
    }
    catch {
        LogError "Invalid date [ $status ] passed as status for Version [$($changeLogEntry.ReleaseVersion)]. See https://aka.ms/azsdk/guideline/changelogs for more info."
        $isValid = $false
    }
  }

  if ([System.String]::IsNullOrWhiteSpace($changeLogEntry.ReleaseContent)) {
    LogError "Entry has no content. Please ensure to provide some content of what changed in this version. See https://aka.ms/azsdk/guideline/changelogs for more info."
    $isValid = $false
  }

  $foundRecomendedSection = $false
  $emptySections = @()
  foreach ($key in $changeLogEntry.Sections.Keys)
  {
    $sectionContent = $changeLogEntry.Sections[$key]
    if ([System.String]::IsNullOrWhiteSpace(($sectionContent | Out-String)))
    {
      $emptySections += $key
    }
    if ($RecommendedSectionHeaders -contains $key)
    {
      $foundRecommendedSection = $true
    }
  }
  if ($emptySections.Count -gt 0)
  {
    LogError "The changelog entry has the following sections with no content ($($emptySections -join ', ')). Please ensure to either remove the empty sections or add content to the section."
    $isValid = $false
  }
  if (!$foundRecommendedSection)
  {
    LogWarning "The changelog entry did not contain any of the recommended sections ($($RecommendedSectionHeaders -join ', ')), please add at least one. See https://aka.ms/azsdk/guideline/changelogs for more info."
  }
  Write-Host "Changelog validation failed. Please fix errors above and try again."
  return $isValid
}