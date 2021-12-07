#Requires -Version 7.0
param (
  [string]$inputJsonFile,
  [string]$outputJsonFile
)

function Get-SwaggerInfo()
{
    param(
        [string]$dir,
        [string]$AUTOREST_CONFIG_FILE = "autorest.md"
    )
    Set-Location $dir
    $swaggerInfoRegex = ".*github.*.com\/(?<org>.*)\/azure-rest-api-specs\/blob\/(?<commitID>[0-9a-f]{40})\/specification\/(?<specName>.*)\/resource-manager\/readme.md"
    $rawSwaggerInfoRegex = ".*github.*.com\/(?<org>.*)\/azure-rest-api-specs\/(?<commitID>[0-9a-f]{40})\/specification\/(?<specName>.*)\/resource-manager\/readme.md"
    $swaggerNoCommitRegex = ".*github.*.com\/(?<org>.*)\/azure-rest-api-specs\/.*\/specification\/(?<specName>.*)\/resource-manager\/readme.md"
    try
    {
        $content = Get-Content .\$AUTOREST_CONFIG_FILE -Raw
        if ($content -match $swaggerInfoRegex)
        {
            return $matches["org"], $matches["specName"], $matches["commitID"]
        }
        if ($content -match $rawSwaggerInfoRegex)
        {
            return $matches["org"], $matches["specName"], $matches["commitID"]
        }
        if ($content -match $swaggerNoCommitRegex)
        {
            return $matches["org"], $matches["specName"], ""
        }
    }
    catch
    {
        Write-Error "Error parsing swagger info"
        Write-Error $_
    }
    Write-Host "Cannot find swagger info"
    exit 1
}
function New-PackageFolder() {
  param(
      [string]$resourceProvider = "",
      [string]$packageName = "",
      [string]$sdkPath = "",
      [string]$commitid = "",
      [string]$AUTOREST_CONFIG_FILE = "autorest.md"
  )

  $projectFolder="$sdkPath/sdk/$packageName/Azure.ResourceManager.*"
  if (Test-Path -Path $projectFolder) {
    Write-Host "Path exists!"
    $folderinfo = Get-ChildItem -Path $projectFolder
    $foldername = $folderinfo.Name
    $projectFolder = "$sdkPath/sdk/$packageName/$foldername"
  } else {
    Write-Host "Path doesn't exist. create template."
    dotnet new -i $sdkPath/eng/templates/Azure.ResourceManager.Template
    $projectFolder="$sdkPath/sdk/$packageName/Azure.ResourceManager.$packageName"
    Write-Host "Create project folder $projectFolder"
    New-Item -Path $projectFolder -ItemType Directory
    Set-Location $projectFolder
    dotnet new azuremgmt --provider $packageName --includeCI true --force
  }

  # update the readme url if needed.
  if ($commitid -ne "") {
    Write-Host "Updating autorest.md file."
    $swaggerInfo = Get-SwaggerInfo -dir "$projectFolder/src"
    $org = $swaggerInfo[0]
    $rp = $swaggerInfo[1]
    $permalinks = "https://github.com/$org/azure-rest-api-specs/blob/$commitid/specification/$rp/resource-manager/readme.md"
    $requirefile = "require: $permalinks"
    $rquirefileRex = "require *:.*.md"
    $file="$projectFolder/src/$AUTOREST_CONFIG_FILE"
    (Get-Content $file) -replace $rquirefileRex, "$requirefile" | Set-Content $file
  }

  return $projectFolder
}

function Invoke-Generate() {
    param(
        [string]$swaggerPath = "",
        [string]$sdkfolder= ""
    )
    Set-Location $sdkfolder/src
    dotnet build /t:GenerateCode
}

function Get-ResourceProviderFromReadme($readmeFile) {
  $readmeFileRegex = "(?<specName>.*)/resource-manager/readme.md"
  try
   {
        if ($readmeFile -match $readmeFileRegex)
        {
            return $matches["specName"]
        }
    }
    catch
    {
        Write-Error "Error parsing reademe info"
        Write-Error $_
    }
    Write-Host "Cannot find resouce provider info"
    # exit 1
}

$inputJson = Get-Content $inputJsonFile | Out-String | ConvertFrom-Json
$swaggerDir = $inputJson.specFolder
$swaggerDir = $swaggerDir -replace "\\", "/"
$readmeFile = $inputJson.relatedReadmeMdFile
$readmeFile = $readmeFile -replace "\\", "/"
$commitid = $inputJson.headSha

$packageName = Get-ResourceProviderFromReadme $readmeFile
$sdkPath =  (Join-Path $PSScriptRoot .. ..)
$sdkPath = Resolve-Path $sdkPath
$sdkPath = $sdkPath -replace "\\", "/"
$packageFolder = New-PackageFolder -resourceProvider $resourceProvider -packageName $packageName -sdkPath $sdkPath -commitid $commitid
Invoke-Generate -swaggerPath $swaggerDir -sdkfolder $sdkPath/sdk/$packageName/Azure.ResourceManager.$packageName

$outputJson = [PSCustomObject]@{
    packages = @([pscustomobject]@{packageName=''; result='succeeded'; path=@("$packageFolder");packageFolder=@("$packageFolder")})
}
$outputJson | ConvertTo-Json -depth 100 | Out-File $outputJsonFile