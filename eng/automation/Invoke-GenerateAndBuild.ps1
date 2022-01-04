#Requires -Version 7.0
param (
  [string]$inputJsonFile="generateInput.json",
  [string]$outputJsonFile="output.json"
)

function Get-SwaggerInfo()
{
    param(
        [string]$dir,
        [string]$AUTOREST_CONFIG_FILE = "autorest.md"
    )
    # Set-Location $dir
    Push-Location $dir
    $swaggerInfoRegex = ".*github.*.com\/(?<org>.*)\/azure-rest-api-specs\/blob\/(?<commitID>[0-9a-f]{40})\/specification\/(?<specName>.*)\/resource-manager\/readme.md"
    $rawSwaggerInfoRegex = ".*github.*.com\/(?<org>.*)\/azure-rest-api-specs\/(?<commitID>[0-9a-f]{40})\/specification\/(?<specName>.*)\/resource-manager\/readme.md"
    $swaggerNoCommitRegex = ".*github.*.com\/(?<org>.*)\/azure-rest-api-specs\/(blob\/)?(?<branch>.*)\/specification\/(?<specName>.*)\/resource-manager\/readme.md"
    try
    {
        $content = Get-Content .\$AUTOREST_CONFIG_FILE -Raw
        Pop-Location
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
      [string]$readme = "",
      [string]$AUTOREST_CONFIG_FILE = "autorest.md",
      [string]$outputJsonFile = "newPacakgeOutput.json"
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
    # Set-Location $projectFolder
    Push-Location $projectFolder
    dotnet new azuremgmt --provider $packageName --includeCI true --force
    Pop-Location
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
  } elseif ($readme -ne "") {
    Write-Host "Updating required file $readme in autorest.md file."
    $requirefile = "require: $readme"
    $rquirefileRex = "require *:.*.md"
    $file="$projectFolder/src/$AUTOREST_CONFIG_FILE"
    (Get-Content $file) -replace $rquirefileRex, "$requirefile" | Set-Content $file

    $readmefilestr = Get-Content $file
    Write-Output "autorest.md:$readmefilestr"
  }

  $path=$projectFolder
  $path=$path.Replace($sdkPath + "/", "")
  $outputJson = [PSCustomObject]@{
    projectFolder = $projectFolder
    path = $path
  }

  $outputJson | ConvertTo-Json -depth 100 | Out-File $outputJsonFile

  return $projectFolder
}

function Invoke-Generate() {
    param(
        [string]$swaggerPath = "",
        [string]$sdkfolder= ""
    )
    # Set-Location $sdkfolder/src
    Push-Location $sdkfolder/src
    dotnet build /t:GenerateCode
    Pop-Location

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

$newpackageoutput = "newPackageOutput.json"
New-PackageFolder -resourceProvider $resourceProvider -packageName $packageName -sdkPath $sdkPath -commitid $commitid -readme $readmeFile -outputJsonFile $newpackageoutput
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

$outputJson = [PSCustomObject]@{
    packages = @([pscustomobject]@{packageName="$packageName"; result='succeeded'; path=@("$path");packageFolder="$path"})
}
$outputJson | ConvertTo-Json -depth 100 | Out-File $outputJsonFile