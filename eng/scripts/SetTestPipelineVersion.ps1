# Overides the project file and CHANGELOG.md for the template project.
# This is to help with testing the release pipeline.

param (
  [Parameter(mandatory = $true)]
  $BuildID
)

. "${PSScriptRoot}\..\common\scripts\common.ps1"
$latestTags = git tag -l "Azure.Template_*"
$semVars = @()

$changeLogFile = "${PSScriptRoot}\..\..\sdk\template\Azure.Template\CHANGELOG.md"

Foreach ($tags in $latestTags)
{
  $semVars += $tags.Replace("Azure.Template_", "")
}

$semVarsSorted = [AzureEngSemanticVersion]::SortVersionStrings($semVars)
LogDebug "Last Published Version $($semVarsSorted[0])"

$newVersion = [AzureEngSemanticVersion]::ParseVersionString($semVarsSorted[0])
$newVersion.PrereleaseLabel = "beta"
$newVersion.PrereleaseNumber = $BuildID

LogDebug "Version to publish [ $($newVersion.ToString()) ]"

&"${PSScriptRoot}/Update-PkgVersion.ps1" -ServiceDirectory "template" `
-PackageName 'Azure.Template' -PackageDirName "Azure.Template" -NewVersionString $newVersion.ToString() `
-ReleaseDate (Get-Date -f "yyyy-MM-dd")
Set-Content -Path $changeLogFile -Value @"
# Release History
## $($newVersion.ToString()) ($(Get-Date -f "yyyy-MM-dd"))
- Test Release Pipeline
"@
