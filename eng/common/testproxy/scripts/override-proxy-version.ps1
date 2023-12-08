<#
.SYNOPSIS
Replaces target test-proxy version present in target_version.txt.

.PARAMETER TargetVersion
The replacement version. Used in its entirety, so don't exclude parts of the version definition.
#>
[cmdletbinding(SupportsShouldProcess=$True)]
param(
   [Parameter(mandatory=$true)] [string] $TargetVersion
)

$versionFile = Join-Path $PSScriptRoot ".." "target_version.txt"
$existingVersionText = Get-Content -Raw -Path $versionFile
$existingVersion = $existingVersionText.Trim()

if ($PSCmdLet.ShouldProcess($versionFile)){
   Write-Host "Replacing version `"$existingVersion`" with version `"$TargetVersion`" in $versionFile."
   Set-Content -Path $versionFile -Value "$TargetVersion`n"   
}
else {
   Write-Host "Would replace version `"$existingVersion`" with version `"$TargetVersion`" in $versionFile."
}


