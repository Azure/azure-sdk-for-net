#Requires -Version 7.0
param (
  [string]$service,
  [string]$namespace,
  [string]$sdkPath,
  [string]$inputfiles="", #input files, separated by semicolon if more than one
  [string]$readme = "",
  [string]$securityScope="",
  [string]$securityHeaderName="",
  [string]$AUTOREST_CONFIG_FILE = "autorest.md"
)
. (Join-Path $PSScriptRoot GenerateAndBuildLib.ps1)
$sdkPath = Resolve-Path $sdkPath
# Generate dataplane library
$outputJsonFile = "newpackageoutput.json"
New-DataPlanePackageFolder -service $service -namespace $namespace -sdkPath $sdkPath -inputfiles $inputfiles -readme $readme -securityScope $securityScope -securityHeaderName $securityHeaderName -AUTOREST_CONFIG_FILE $AUTOREST_CONFIG_FILE -outputJsonFile $outputJsonFile
if ( $? -ne $True) {
  Write-Error "Failed to create sdk project folder. exit code: $?"
  exit 1
}
$outputJson = Get-Content $outputJsonFile | Out-String | ConvertFrom-Json
$projectFolder = $outputJson.projectFolder
Write-Host "projectFolder:$projectFolder"
Remove-Item $outputJsonFile
# Generate Code
Invoke-Generate -sdkfolder $projectFolder
if ( !$? ) {
  Write-Error "Failed to generate sdk."
  exit 1
}
# Build
Invoke-Build -sdkfolder $projectFolder
if ( !$? ) {
  Write-Error "Failed to build sdk. exit code: $?"
  exit 1
}
# Generate APIs
$repoRoot = (Join-Path $PSScriptRoot .. .. ..)
Push-Location $repoRoot
pwsh eng/scripts/Export-API.ps1 $service
Pop-Location
exit 0