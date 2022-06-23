#Requires -Version 7.0
param (
  [string]$inputJsonFile,
  [string]$outputJsonFile
)

. (Join-Path $PSScriptRoot automation GenerateAndBuildLib.ps1)

$inputJson = Get-Content $inputJsonFile | Out-String | ConvertFrom-Json
$swaggerDir = $inputJson.specFolder
$swaggerDir = $swaggerDir -replace "\\", "/"
$readmeFiles = $inputJson.relatedReadmeMdFiles
$commitid = $inputJson.headSha
$repoHttpsUrl = $inputJson.repoHttpsUrl

$generatedSDKPackages = New-Object 'Collections.Generic.List[System.Object]'

foreach ( $relateReadmeFile in $readmeFiles ) {
    $readmeFile = $relateReadmeFile -replace "\\", "/"
    
    $sdkPath =  (Join-Path $PSScriptRoot .. ..)
    $sdkPath = Resolve-Path $sdkPath
    $sdkPath = $sdkPath -replace "\\", "/"

    
    $readme = ""
    if ($commitid -ne "") {
    if ($repoHttpsUrl -ne "") {
        $readme = "$repoHttpsUrl/blob/$commitid/$readmeFile"
    } else {
        $readme = "https://github.com/$org/azure-rest-api-specs/blob/$commitid/$readmeFile"
    }
    } else {
        $readme = (Join-Path $swaggerDir $readmeFile)
    }

    Invoke-GenerateAndBuildSDK -readmeAbsolutePath $readme -sdkRootPath $sdkPath -generatedSDKPackages $generatedSDKPackages
}

$outputJson = [PSCustomObject]@{
    packages = $generatedSDKPackages
}
$outputJson | ConvertTo-Json -depth 100 | Out-File $outputJsonFile