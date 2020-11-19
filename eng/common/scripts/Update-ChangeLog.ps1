# Note: This script will add or replace version title in change log

# Parameter description
# Version : Version to add or replace in change log
# Unreleased: Default is true. If it is set to false, then today's date will be set in verion title. If it is True then title will show "Unreleased"
# ReplaceLatestEntry: Replaces the latest changelog entry, including its content.

param (
  [Parameter(Mandatory = $true)]
  [String]$Version,
  [Parameter(Mandatory = $true)]
  [String]$ServiceDirectory,
  [Parameter(Mandatory = $true)]
  [String]$PackageName,
  [boolean]$Unreleased=$True,
  [boolean]$ReplaceLatestEntry = $False,
  [String]$ReleaseDate
)

if ($ReleaseDate -and ($Unreleased -eq $True)) {
    LogError "Do not pass 'ReleaseDate' arguement when 'Unreleased' is true"
    exit 1
}

. (Join-Path $PSScriptRoot common.ps1)

if ($ReleaseDate)
{
    try {
        $ReleaseStatus = ([DateTime]$ReleaseDate).ToString($CHANGELOG_DATE_FORMAT)
        $ReleaseStatus = "($ReleaseStatus)"
    }
    catch {
        LogError "Invalid 'ReleaseDate'. Please use a valid date in the format '$CHANGELOG_DATE_FORMAT'"
        exit 1
    }
}
elseif ($Unreleased) {
    $ReleaseStatus = $CHANGELOG_UNRELEASED_STATUS
}
else {
    $ReleaseStatus = "$(Get-Date -Format $CHANGELOG_DATE_FORMAT)"
    $ReleaseStatus = "($ReleaseStatus)"
}

if ($null -eq [AzureEngSemanticVersion]::ParseVersionString($Version))
{
    LogError "Version [$Version] is invalid. Please use a valid SemVer"
    exit(0)
}

$PkgProperties = Get-PkgProperties -PackageName $PackageName -ServiceDirectory $ServiceDirectory
$ChangeLogEntries = Get-ChangeLogEntries -ChangeLogLocation $PkgProperties.ChangeLogPath


if ($ChangeLogEntries.Contains($Version))
{
    if ($ChangeLogEntries[$Version].ReleaseStatus -eq $ReleaseStatus)
    {
        LogWarning "Version is already present in change log with specificed ReleaseStatus [$ReleaseStatus]"
        exit(0)
    }

    if ($Unreleased -and ($ChangeLogEntries[$Version].ReleaseStatus -ne $ReleaseStatus))
    {
        LogWarning "Version is already present in change log with a release date. Please review [$($PkgProperties.ChangeLogPath)]"
        exit(0)
    }

    if (!$Unreleased -and ($ChangeLogEntries[$Version].ReleaseStatus -ne $CHANGELOG_UNRELEASED_STATUS))
    {
        if ((Get-Date ($ChangeLogEntries[$Version].ReleaseStatus).Trim("()")) -gt (Get-Date $ReleaseStatus.Trim("()")))
        {
            LogWarning "New ReleaseDate for version [$Version] is older than existing release date in changelog. Please review [$($PkgProperties.ChangeLogPath)]"
            exit(0)
        }
    }
}

$PresentVersionsSorted = [AzureEngSemanticVersion]::SortVersionStrings($ChangeLogEntries.Keys)
$LatestVersion = $PresentVersionsSorted[0]

$LatestsSorted = [AzureEngSemanticVersion]::SortVersionStrings(@($LatestVersion, $Version))
if ($LatestsSorted[0] -ne $Version) {
    LogWarning "Passed Version [$Version] is older than the latestversion [$LatestVersion] in the changelog. Please use a more recent version."
    exit(0)
}

if ($ReplaceLatestEntry) 
{
    $ChangeLogEntries.Remove($LatestVersion)
    $newChangeLogEntry = New-ChangeLogEntry -Version $Version -Status $ReleaseStatus
    if ($newChangeLogEntry) {
        $ChangeLogEntries[$Version] = $newChangeLogEntry
    }
    else {
        LogError "Failed to create new changelog entry"
    }
}
elseif ($ChangeLogEntries.Contains($Version))
{
    $ChangeLogEntries[$Version].ReleaseVersion = $Version
    $ChangeLogEntries[$Version].ReleaseStatus = $ReleaseStatus
    $ChangeLogEntries[$Version].ReleaseTitle = "## $Version $ReleaseStatus"
}
else 
{
    $newChangeLogEntry = New-ChangeLogEntry -Version $Version -Status $ReleaseStatus
    if ($newChangeLogEntry) {
        $ChangeLogEntries[$Version] = $newChangeLogEntry
    }
    else {
        LogError "Failed to create new changelog entry"
    }
}

Set-ChangeLogContent -ChangeLogLocation $PkgProperties.ChangeLogPath -ChangeLogEntries $ChangeLogEntries


