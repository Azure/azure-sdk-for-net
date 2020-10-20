# Overides the project file and CHANGELOG.md for the template project using a custom preview version
# This is to help with testing the release pipeline.

[CmdletBinding(SupportsShouldProcess = $true)]
param(
  [Parameter(Mandatory = $true)]
  [string]$PreviewVersionNumber
)

. "${PSScriptRoot}\..\common\scripts\common.ps1"

$changeLogFile = "${PSScriptRoot}\..\..\sdk\template\Azure.Template\CHANGELOG.md"
$newVersion = "1.0.3-beta.$PreviewVersionNumber"

&"${PSScriptRoot}/Update-PkgVersion.ps1" -ServiceDirectory "template" `
-PackageName 'Azure.Template' -PackageDirName "Azure.Template" -NewVersionString $newVersion `
-ReleaseDate (Get-Date -f "yyyy-MM-dd")
Set-TestChangeLog -TestVersion $newVersion -changeLogFile $changeLogFile -ReleaseEntry "Test Release Pipeline"