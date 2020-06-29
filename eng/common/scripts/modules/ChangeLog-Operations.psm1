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
    Write-Host "ChangeLog '{0}' was not found" -f $ChangeLogLocation
    exit 1
  }

  try {
    $contents = Get-Content $ChangeLogLocation
    # walk the document, finding where the version specifiers are and creating lists
    $changeLogEntry = $null
    foreach ($line in $contents) {
      if ($line -match $RELEASE_TITLE_REGEX) {
        $changeLogEntry = [pscustomobject]@{ 
          ReleaseVersion = $matches["version"]
          ReleaseStatus  = $matches["releaseStatus"]
          ReleaseTitle   = $line
          ReleaseContent = @() # Release content without the version title
        }
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

  if ($changeLogEntries.ContainsKey($VersionString)) {
    return $changeLogEntries[$VersionString]
  }
  Write-Error "Release Notes for the Specified version ${VersionString} was not found"
  exit 1
}

#Returns the changelog for a particular version as string
function Get-ChangeLogEntryAsString {
  param (
    [Parameter(Mandatory = $true)]
    [String]$ChangeLogLocation,
    [Parameter(Mandatory = $true)]
    [String]$VersionString
  )

  $changeLogEntries = Get-ChangeLogEntry -ChangeLogLocation $ChangeLogLocation -VersionString $VersionString
  [string]$releaseTitle = $changeLogEntries.ReleaseTitle
  [string]$releaseContent = $changeLogEntries.ReleaseContent -Join [Environment]::NewLine
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

  $changeLogEntries = Get-ChangeLogEntry -ChangeLogLocation $ChangeLogLocation -VersionString $VersionString

  if ([System.String]::IsNullOrEmpty($changeLogEntries.ReleaseStatus)) {
    Write-Host ("##[error]Changelog '{0}' has wrong release note title" -f $ChangeLogLocation)
    Write-Host "##[info]Ensure the release date is included i.e. (yyyy-MM-dd) or (Unreleased) if not yet released"
    exit 1
  }

  if ($ForRelease -eq $True) {
    $CurrentDate = Get-Date -Format "yyyy-MM-dd"
    if ($changeLogEntries.ReleaseStatus -ne "($CurrentDate)") {
      Write-Host ("##[warning]Incorrect Date: Please use the current date in the Changelog '{0}' before releasing the package" -f $ChangeLogLocation)
      exit 1
    }

    if ([System.String]::IsNullOrWhiteSpace($changeLogEntries.ReleaseContent)) {
      Write-Host ("##[error]Empty Release Notes for '{0}' in '{1}'" -f $VersionString, $ChangeLogLocation)
      Write-Host "##[info]Please ensure there is a release notes entry before releasing the package."
      exit 1
    }
  }

  Write-Host ($changeLogEntries | Format-Table | Out-String)
}
 
Export-ModuleMember -Function 'Get-ChangeLogEntries'
Export-ModuleMember -Function 'Get-ChangeLogEntry'
Export-ModuleMember -Function 'Get-ChangeLogEntryAsString'
Export-ModuleMember -Function 'Confirm-ChangeLogEntry'