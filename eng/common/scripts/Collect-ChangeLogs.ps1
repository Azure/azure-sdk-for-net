[CmdletBinding()]
param(
  [Parameter(Mandatory=$true)]
  [ValidateRange(1, 12)]
  [int] $Month
)

. (Join-Path $PSScriptRoot common.ps1)

$InstallNotes = "";
$ReleaseNotes = "";

$date = Get-Date -Month $month -Format "yyyy-MM"
$date += "-\d\d"

$allPackageProps = Get-AllPkgProperties

foreach ($packageProp in $allPackageProps) {
    $changeLogEntries = Get-ChangeLogEntries -ChangeLogLocation $packageProp.ChangeLogPath
    $package = $packageProp.Name
    $serviceDirectory = $packageProp.ServiceDirectory
    $groupId = $packageProp.Group

    foreach ($changeLogEntry in $changeLogEntries.Values) {
        if ($changeLogEntry.ReleaseStatus -notmatch $date)
        {
            continue;
        }

        $version = $changeLogEntry.ReleaseVersion
        $githubAnchor = $changeLogEntry.ReleaseTitle.Replace("## ", "").Replace(".", "").Replace("(", "").Replace(")", "").Replace(" ", "-")

        if (Test-Path "Function:GetPackageInstallNote")
        {
            $InstallNotes += GetPackageInstallNote -Package $package -Version $version -GroupId $groupId
        }
        else
        {
            LogError "The function 'GetPackageInstallNote' was not found."
            return $null
        }

        $highlightsTitle = "$package $version"
        if (-not ([string]::IsNullOrEmpty($groupId))
        {
            $highlightsTitle = "$groupId $highlightsTitle"
        }

        $ReleaseNotes += "### $groupId $package $version [Changelog](https://github.com/Azure/azure-sdk-for-$LanguageShort/blob/master/sdk/$serviceDirectory/$package/CHANGELOG.md#$githubAnchor)`n"
        $changeLogEntry.ReleaseContent | %{ 

            $ReleaseNotes += $_.Replace("###", "####")
            $ReleaseNotes += "`n"            
        }
        $ReleaseNotes += "`n"
    }
}

return $InstallNotes, $ReleaseNotes