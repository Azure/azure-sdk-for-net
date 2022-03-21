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

function New-DataPlanePackageFolder() {
  param(
      [string]$service,
      [string]$namespace,
      [string]$sdkPath = "",
      [string]$inputfiles = "", # input files, separated by semicolon if more than one
      [string]$securityScope = "",
      [string]$securityHeaderName = "",
      [string]$AUTOREST_CONFIG_FILE = "autorest.md",
      [string]$outputJsonFile = "output.json"
  )

  $sdkPath = $sdkPath -replace "\\", "/"

  $inputfile = ""
  $fileArray = $inputfiles.Split(";")
  if ($inputfiles -ne "" && $fileArray.Length -gt 0) {
    $inputfile = $fileArray[0];
    for ($i = 1; $i -lt $fileArray.Count ; $i++) {
        $inputfile = $inputfile + [Environment]::NewLine + "- " + $fileArray[$i]
    }
  }
  $projectFolder="$sdkPath/sdk/$service/$namespace"
  if (Test-Path -Path $projectFolder) {
    Write-Host "Path exists!"
      # update the input-file url if needed.
    if ($inputfile -ne "") {
        Write-Host "Updating autorest.md file."
        $inputfileRex = "input-file *:"
        $file="$projectFolder/src/$AUTOREST_CONFIG_FILE"
        if (Test-Path -Path $file) {
            (Get-Content $file) -notmatch "- .*.json" |Out-File $file
            (Get-Content $file) -replace $inputfileRex, ("input-file:" + [Environment]::NewLine + "- " + "$inputfile") | Set-Content $file
            if ( $? -ne $True) {
            Write-Error "Failed to update autorest.md. exit code: $?"
            exit 1
            }
        } else {
            Write-Error "autorest.md doesn't exist."
            exit 1
        }
    }
  } else {
    Write-Host "Path doesn't exist. create template."
    if ($inputfile -eq "") {
        Write-Error "Error: input file should not be empty."
        exit 1
    }
    dotnet new -i $sdkPath/eng/templates/Azure.ServiceTemplate.Template
    Write-Host "Create project folder $projectFolder"
    New-Item -Path $projectFolder -ItemType Directory
    Set-Location $projectFolder
    $namespaceArray = $namespace.Split(".")
    if ( $namespaceArray.Count -lt 3) {
        Write-Error "Error: invalid namespace name."
        exit 1
    }

    $libraryName = $namespaceArray[-1]
    $groupName = $namespaceArray[1]
    $dotnetNewCmd = "dotnet new dataplane --libraryName $libraryName --groupName $groupName --swagger $inputfile --includeCI true --force"
    if ($securityScope -ne "") {
        $dotnetNewCmd = $dotnetNewCmd + " --securityScopes $securityScope";
    }

    if ($securityHeaderName -ne "") {
        $dotnetNewCmd = $dotnetNewCmd + " --securityHeaderName $securityHeaderName";
    }
    # dotnet new dataplane --libraryName $libraryName --swagger $inputfile --securityScopes $securityScope --securityHeaderName $securityHeaderName --includeCI true --force
    Write-Host "Invote dotnet new command: $dotnetNewCmd"
    Invoke-Expression $dotnetNewCmd

    # dotnet sln
    dotnet sln remove src\$namespace.csproj
    dotnet sln add src\$namespace.csproj
    dotnet sln remove tests\$namespace.Tests.csproj
    dotnet sln add tests\$namespace.Tests.csproj
  }

  $outputJson = [PSCustomObject]@{
    projectFolder = $projectFolder
  }

  $outputJson | ConvertTo-Json -depth 100 | Out-File $outputJsonFile
  return $projectFolder
}

function New-MgmtPackageFolder() {
    param(
        [string]$service = "",
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
        [string]$sdkfolder= ""
    )
    $sdkfolder = $sdkfolder -replace "\\", "/"
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
        Write-Error "Error parsing readme info"
        Write-Error $_
    }
    Write-Host "Cannot find resource provider info"
}