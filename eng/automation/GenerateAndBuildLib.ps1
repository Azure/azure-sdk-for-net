#Requires -Version 7.0

function Get-SwaggerInfo()
{
    param(
        [string]$dir,
        [string]$AUTOREST_CONFIG_FILE = "autorest.md"
    )
    Set-Location $dir
    $swaggerInfoRegex = ".*github.*.com\/(?<org>.*)\/azure-rest-api-specs\/blob\/(?<commitID>[0-9a-f]{40})\/specification\/(?<specName>.*)\/resource-manager\/readme.md"
    $rawSwaggerInfoRegex = ".*github.*.com\/(?<org>.*)\/azure-rest-api-specs\/(?<commitID>[0-9a-f]{40})\/specification\/(?<specName>.*)\/resource-manager\/readme.md"
    $swaggerNoCommitRegex = ".*github.*.com\/(?<org>.*)\/azure-rest-api-specs\/(blob\/)?(?<branch>.*)\/specification\/(?<specName>.*)\/resource-manager\/readme.md"
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

function Get-InputJsonFileInfo()
{
    param(
        [string]$dir,
        [string]$AUTOREST_CONFIG_FILE = "autorest.md"
    )
    Set-Location $dir
    $inputfileInfoRegex = ".*github.*.com\/(?<org>.*)\/azure-rest-api-specs\/blob\/(?<commitID>[0-9a-f]{40})\/specification\/(?<specName>.*)\/data-plane\/?<filePath>"
    $rawInputfileInfoRegex = ".*github.*.com\/(?<org>.*)\/azure-rest-api-specs\/(?<commitID>[0-9a-f]{40})\/specification\/(?<specName>.*)\/data-plane\/?<filePath>"
    $inputfileNoCommitRegex = ".*github.*.com\/(?<org>.*)\/azure-rest-api-specs\/(blob\/)?(?<branch>.*)\/specification\/(?<specName>.*)\/data-plane\/?<filePath>"
    try
    {
        $content = Get-Content .\$AUTOREST_CONFIG_FILE -Raw
        if ($content -match $inputfileInfoRegex)
        {
            return $matches["org"], $matches["specName"], $matches["commitID"], $matches["filePath"]
        }
        if ($content -match $rawInputfileInfoRegex)
        {
            return $matches["org"], $matches["specName"], $matches["commitID"], $matches["filePath"]
        }
        if ($content -match $inputfileNoCommitRegex)
        {
            return $matches["org"], $matches["specName"], "", $matches["filePath"]
        }
    }
    catch
    {
        Write-Error "Error parsing input file info"
        Write-Error $_
    }
    Write-Host "Cannot find input file info"
    exit 1
}
function New-DataPlanePackageFolder() {
  param(
      [string]$resourceProvider,
      [string]$ServiceGrouop = "DataPlane",
      [string]$packageName = "",
      [string]$sdkPath = "",
      [string]$inputfile = "",
      [string]$securityScope,
      [string]$AUTOREST_CONFIG_FILE = "autorest.md"
  )

  if ($packageName -eq "") {
      $packageName = $resourceProvider
  }

  $sdkPath = $sdkPath -replace "\\", "/"

  $projectFolder="$sdkPath/sdk/$resourceProvider/Azure.$ServiceGrouop.$packageName"
  if (Test-Path -Path $projectFolder) {
    Write-Host "Path exists!"
  } else {
    Write-Host "Path doesn't exist. create template."
    if ($inputfile -eq "") {
        Write-Error "Error: input file should not be empty."
        exit 1
    }
    dotnet new -i $sdkPath/eng/templates/Azure.ServiceTemplate.Template
    $projectFolder="$sdkPath/sdk/$resourceProvider/Azure.$ServiceGrouop.$packageName"
    Write-Host "Create project folder $projectFolder"
    New-Item -Path $projectFolder -ItemType Directory
    Set-Location $projectFolder
    dotnet new dataplane --libraryName DeviceUpdate --swagger $inputfile --securityScopes $securityScope --includeCI true --force
    dotnet sln remove src\Azure.$ServiceGrouop.$packageName.csproj
    dotnet sln add src\Azure.$ServiceGrouop.$packageName.csproj
    dotnet sln remove tests\Azure.$ServiceGrouop.$packageName.Tests.csproj
    dotnet sln add tests\Azure.$ServiceGrouop.$packageName.Tests.csproj
  }

  # update the Dataplane target flag


  # update the input-file url if needed.
  if ($inputfile -ne "") {
    Write-Host "Updating autorest.md file."
    $inputfile = "input-file: $inputfile"
    $inputfileRex = "input-file *:.*.json"
    $file="$projectFolder/src/$AUTOREST_CONFIG_FILE"
    (Get-Content $file) -replace $inputfileRex, "$inputfile" | Set-Content $file
  }

  return $projectFolder
}

function Invoke-Generate() {
    param(
        [string]$sdkfolder= ""
    )
    $sdkfolder = $sdkfolder -replace "\\", "/"
    Set-Location $sdkfolder/src
    dotnet build /t:GenerateCode
}