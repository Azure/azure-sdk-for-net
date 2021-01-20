[CmdletBinding()]
param(
  [Parameter(Mandatory=$true)]
  [ValidateRange(1, 12)]
  [int] $Month
)

. (Join-Path $PSScriptRoot common.ps1)

$releaseHighlights = @{}

$date = Get-Date -Month $month -Format "yyyy-MM"
$date += "-\d\d"

$allPackageProps = Get-AllPkgProperties

foreach ($packageProp in $allPackageProps) {
    $changeLogEntries = Get-ChangeLogEntries -ChangeLogLocation $packageProp.ChangeLogPath
    $packageName = $packageProp.Name
    $serviceDirectory = $packageProp.ServiceDirectory

    foreach ($changeLogEntry in $changeLogEntries.Values) {
        if ($changeLogEntry.ReleaseStatus -notmatch $date)
        {
            continue;
        }

        $releaseVersion = $changeLogEntry.ReleaseVersion
        $githubAnchor = $changeLogEntry.ReleaseTitle.Replace("## ", "").Replace(".", "").Replace("(", "").Replace(")", "").Replace(" ", "-")

        $releaseTag = "${packageName}_${releaseVersion}"
        $key = "${packageName}:${releaseVersion}"

        $releaseHighlights[$key] = @{}
        $releaseHighlights[$key]["ChangelogUrl"] = "https://github.com/Azure/azure-sdk-for-${LanguageShort}/blob/${releaseTag}/sdk/${serviceDirectory}/${packageName}/CHANGELOG.md#${githubAnchor}"
        $releaseHighlights[$key]["Content"] = @()

        $changeLogEntry.ReleaseContent | %{ 

            $releaseHighlights[$key]["Content"] += $_.Replace("###", "####")
            $releaseHighlights[$key]["Content"] += "`n"            
        }
        $releaseHighlights[$key]["Content"] += "`n"
    }
}

return $releaseHighlights