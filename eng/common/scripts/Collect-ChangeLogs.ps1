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

    foreach ($changeLogEntry in $changeLogEntries.Values) {
        if ($changeLogEntry.ReleaseStatus -notmatch $date)
        {
            continue;
        }

        $version = $changeLogEntry.ReleaseVersion
        $githubAnchor = $changeLogEntry.ReleaseTitle.Replace("## ", "").Replace(".", "").Replace("(", "").Replace(")", "").Replace(" ", "-")
        $textInfo = (Get-Culture).TextInfo
        $highlightTitle = $textInfo.ToTitleCase($package.Replace("-", " ").Replace("@azure/",""))

        if (Test-Path "Function:GetPackageInstallNotes")
        {
            $InstallNotes += GetPackageInstallNotes -Package $package -Version $version
        }
        else
        {
            LogError "The function 'GetPackageInstallNotes' was not found."
            return $null
        }

        $ReleaseNotes += "### $highlightTitle $version [Changelog](https://github.com/Azure/azure-sdk-for-$LanguageShort/blob/master/sdk/$serviceDirectory/$package/CHANGELOG.md#$githubAnchor)`n"
        $changeLogEntry.ReleaseContent | %{ 

            $ReleaseNotes += $_.Replace("###", "####")
            $ReleaseNotes += "`n"            
        }
        $ReleaseNotes += "`n"
    }
}

return $InstallNotes, $ReleaseNotes