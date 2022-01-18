#Requires -Version 7.0
param (
  [string]$inputJsonFile="generateInput.json",
  [string]$outputJsonFile="output.json"
)

. (Join-Path $PSScriptRoot MgmtGenerateLib.ps1)

$inputJson = Get-Content $inputJsonFile | Out-String | ConvertFrom-Json
$swaggerDir = $inputJson.specFolder
$swaggerDir = $swaggerDir -replace "\\", "/"
$readmeFile = $inputJson.relatedReadmeMdFile
$readmeFile = $readmeFile -replace "\\", "/"
$commitid = $inputJson.headSha
Write-Host "swaggerDir:$swaggerDir, readmeFile:$readmeFile"

$packageName = Get-ResourceProviderFromReadme $readmeFile
$sdkPath =  (Join-Path $PSScriptRoot .. .. ..)
$sdkPath = Resolve-Path $sdkPath
$sdkPath = $sdkPath -replace "\\", "/"

$newpackageoutput = "newPackageOutput.json"
New-PackageFolder -resourceProvider $resourceProvider -packageName $packageName -sdkPath $sdkPath -commitid $commitid -readme $swaggerDir/$readmeFile -outputJsonFile $newpackageoutput
if ( $? -ne $True) {
  Write-Error "Failed to create sdk project folder. exit code: $?"
  exit 1
}
$newpackageoutputJson = Get-Content $newpackageoutput | Out-String | ConvertFrom-Json
$projectFolder = $newpackageoutputJson.projectFolder
$path = $newpackageoutputJson.path
Write-Host "projectFolder:$projectFolder"
Remove-Item $newpackageoutput

Invoke-Generate -swaggerPath $swaggerDir -sdkfolder $projectFolder
if ( $? -ne $True) {
  Write-Error "Failed to generate sdk. exit code: $?"
  exit 1
}
$outputJson = [PSCustomObject]@{
    packages = @([pscustomobject]@{packageName="$packageName"; result='succeeded'; path=@("$path");packageFolder="$path"})
}
$outputJson | ConvertTo-Json -depth 100 | Out-File $outputJsonFile