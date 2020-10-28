# Common Changelog Operations

$RELEASE_TITLE_REGEX = "(?<releaseNoteTitle>^\#+.*(?<version>\b\d+\.\d+\.\d+([^0-9\s][^\s:]+)?)(\s(?<releaseStatus>\(Unreleased\)|\(\d{4}-\d{2}-\d{2}\)))?)"

# Returns a Collection of changeLogEntry object containing changelog info for all version present in the gived CHANGELOG
function Get-ChangeLogEntries {
  param (
    [Parameter(Mandatory = $true)]
    [String]$ChangeLogLocation
  )

  $changeLogEntries = @{}
  if (!(Test-Path $ChangeLogLocation)) {
    Write-Error "ChangeLog[${ChangeLogLocation}] does not exist"
    return $null
  }

  try {
    $contents = Get-Content $ChangeLogLocation
    # walk the document, finding where the version specifiers are and creating lists
    $changeLogEntry = $null
    foreach ($line in $contents) {
      if ($line -match $RELEASE_TITLE_REGEX) {
        $changeLogEntry = New-ChangeLogEntry -Version $matches["version"] -Status $matches["releaseStatus"] `
        -Title $line -Content @()
        $changeLogEntries[$changeLogEntry.ReleaseVersion] = $changeLogEntry
      }
      else {
        if ($changeLogEntry) {
          $changeLogEntry.ReleaseContent += $line
        }
      }
    }
  }
  catch {
    Write-Host "Error parsing $ChangeLogLocation."
    Write-Host $_.Exception.Message
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

  if ($changeLogEntries -and $changeLogEntries.ContainsKey($VersionString)) {
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
    [boolean]$ForRelease = $false
  )

  $changeLogEntry = Get-ChangeLogEntry -ChangeLogLocation $ChangeLogLocation -VersionString $VersionString

  if (!$changeLogEntry) {
    Write-Error "ChangeLog[${ChangeLogLocation}] does not have an entry for version ${VersionString}."
    return $false
  }

  Write-Host "Found the following change log entry for version '${VersionString}' in [${ChangeLogLocation}]."
  Write-Host "-----"
  Write-Host (ChangeLogEntryAsString $changeLogEntry)
  Write-Host "-----"

  if ([System.String]::IsNullOrEmpty($changeLogEntry.ReleaseStatus)) {
    Write-Error "Entry does not have a correct release status. Please ensure the status is set to a date '(yyyy-MM-dd)' or '(Unreleased)' if not yet released."
    return $false
  }

  if ($ForRelease -eq $True) {
    if ($changeLogEntry.ReleaseStatus -eq "(Unreleased)") {
      Write-Error "Entry has no release date set. Please ensure to set a release date with format 'yyyy-MM-dd'."
      return $false
    }

    if ([System.String]::IsNullOrWhiteSpace($changeLogEntry.ReleaseContent)) {
      Write-Error "Entry has no content. Please ensure to provide some content of what changed in this version."
      return $false
    }
  }
  return $true
}

function New-ChangeLogEntry {
  param (
    [Parameter(Mandatory = $true)]
    [String]$Version,
    [Parameter(Mandatory = $true)]
    [ValidateScript({$_.StartsWith('(') -and $_.EndsWith(')')})]
    [String]$Status,
    [String]$Title,
    [String[]]$Content
  )

  $newChangeLogEntry = [pscustomobject]@{ 
    ReleaseVersion = $Version
    ReleaseStatus  = $Status
    ReleaseTitle   = If ($Title) { $Title } Else { "## $Version $Status"}
    ReleaseContent = If ($Content) { $Content } Else { @("") }
  }

  return $newChangeLogEntry
}

function Add-ChangeLogEntry {
  param (
    [Parameter(Mandatory = $false)]
    [Hashtable]$ChangeLogEntries,
    [Parameter(Mandatory = $true)]
    [String]$NewEntryVersion,
    [String]$NewEntryReleaseStatus="(Unreleased)",
    [String]$NewEntryContent=""
  )

  if ($ChangeLogEntries.Contains($NewEntryVersion))
  {
    LogError "This Changelog already contains this entry. Do you mean to edit the entry?"
    exit 1
  }

  $newChangeLogEntry = New-ChangeLogEntry -Version $NewEntryVersion -Status $NewEntryReleaseStatus `
  -Content $NewEntryContent
  $ChangeLogEntries.Add($NewEntryVersion,$newChangeLogEntry)
  return $ChangeLogEntries
}

function Edit-ChangeLogEntry {
  param (
    [Parameter(Mandatory = $true)]
    [Hashtable]$ChangeLogEntries,
    [Parameter(Mandatory = $true)]
    [string]$VersionToEdit,
    [String]$NewEntryReleaseVersion,
    [String]$NewEntryReleaseStatus,
    [String]$NewEntryReleaseContent
  )

  if ($NewEntryReleaseVersion) { $ChangeLogEntries[$VersionToEdit].ReleaseVersion = $NewEntryReleaseVersion }
  if ($NewEntryReleaseStatus) {$ChangeLogEntries[$VersionToEdit].ReleaseStatus = $NewEntryReleaseStatus }
  if ($NewEntryReleaseContent) {$ChangeLogEntries[$VersionToEdit].ReleaseContent = $NewEntryReleaseContent }
  return $ChangeLogEntries
}

function Set-ChangeLogContent {
  param (
    [Parameter(Mandatory = $true)]
    [String]$ChangeLogLocation,
    [Parameter(Mandatory = $true)]
    $ChangeLogEntries
  )

  $changeLogContent = @()
  $changeLogContent += "# Release History"
  
  try {
    [AzureEngSemanticVersion]
  }
  catch {
    . "${PSScriptRoot}\SemVer.ps1."
  }

  $VersionsSorted = [AzureEngSemanticVersion]::SortVersionStrings($ChangeLogEntries.Keys)
  foreach ($version in $VersionsSorted) {
    $changeLogEntry = $ChangeLogEntries[$version]
    $changeLogContent += $changeLogEntry.ReleaseTitle
    foreach ($line in $changeLogEntry.ReleaseContent) {
      $changeLogContent += $line
    }
    $changeLogContent += ""
  }

  Set-Content -Path $ChangeLogLocation -Value $changeLogContent
}