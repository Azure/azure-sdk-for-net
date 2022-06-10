#Requires -Version 7.0
$CI_YAML_FILE = "ci.yml"
function Get-SwaggerInfo()
{
    param(
        [string]$dir,
        [string]$AUTOREST_CONFIG_FILE = "autorest.md"
    )
    Push-Location $dir
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
    Pop-Location
    exit 1
}

function Update-AutorestConfigFile() {
    param (
        [string]$autorestFilePath,
        [string]$inputfile = "",
        [string]$readme = ""
    )
    if (Test-Path -Path $autorestFilePath) {
        if ($readme -ne "") {
            Write-Host "Updating autorest.md file to config required readme file."
            $requirRex = "require*:*";
            $inputfileRex = "input-file *:*"
            $requirefile = $readme + [Environment]::NewLine + "- " + $readme.Replace("readme.md", "readme.csharp.md")
            if ((Get-Content $autorestFilePath | Select-String -Pattern $requirRex).Matches.Success) {
                (Get-Content $autorestFilePath) -notmatch "- .*.md" |Out-File $autorestFilePath
                (Get-Content $autorestFilePath) -notmatch $inputfileRex |Out-File $autorestFilePath
                (Get-Content $autorestFilePath) -notmatch "- .*.json" |Out-File $autorestFilePath
                (Get-Content $autorestFilePath) -replace $requirRex, ("require:" + [Environment]::NewLine + "- " + "$requirefile") | Set-Content $autorestFilePath
            } elseif ((Get-Content $autorestFilePath | Select-String -Pattern $inputfileRex).Matches.Success) {
                (Get-Content $autorestFilePath) -notmatch "- .*.json" |Out-File $autorestFilePath
                $requirefile = $requirefile + [Environment]::NewLine + "csharp: true";
                (Get-Content $autorestFilePath) -replace $inputfileRex, ("require:" + [Environment]::NewLine + "- " + "$requirefile") | Set-Content $autorestFilePath
            }
            if ( $? -ne $True) {
                Write-Error "Failed to update autorest.md. exit code: $?"
                exit 1
            }
        } elseif ($inputfile -ne "") {
            Write-Host "Updating autorest.md file to update input-file."
            $inputfileRex = "input-file *:*"
            if ((Get-Content $autorestFilePath | Select-String -Pattern $inputfileRex).Matches.Success) {
                (Get-Content $autorestFilePath) -notmatch "- .*.json" |Out-File $autorestFilePath
                (Get-Content $autorestFilePath) -replace $inputfileRex, ("input-file:" + [Environment]::NewLine + "$inputfile") | Set-Content $autorestFilePath
            } else {
                $startNum = (Get-Content $autorestFilePath | Select-String -Pattern '```').LineNumber[0]
                $fileContent = Get-Content -Path $autorestFilePath
                $fileContent[$startNum - 1] += ([Environment]::NewLine + "input-file:" + [Environment]::NewLine + "$inputfile")
                $fileContent | Set-Content $autorestFilePath
            }
            
            if ( $? -ne $True) {
                Write-Error "Failed to update autorest.md. exit code: $?"
                exit 1
            }
        }   
    } else {
        Write-Error "autorest.md doesn't exist."
        exit 1
    }
}

function Update-CIYmlFile() {
    param (
        [string]$ciFilePath,
        [string]$artifact
    )
    if (Test-Path -Path $ciFilePath) {
        $packageRex = "name *: $artifact"
        if ((Get-Content $ciFilePath | Select-String -Pattern $packageRex).Matches.Success) {
            Write-Host "CI already enabled."
        } else {
            $safeName = $artifact.Replace('.', '')
            $artifactsBlockRex = "Artifacts *:"
            $startNum = (Get-Content $ciFilePath | Select-String -Pattern $artifactsBlockRex).LineNumber[0]
            $fileContent = Get-Content -Path $ciFilePath
            $fileContent[$startNum - 1] += ([Environment]::NewLine + "    - " + "name: $artifact" + [Environment]::NewLine + "      safeName: $safeName")
            $fileContent | Set-Content $ciFilePath
        }
    } else {
        Write-Error "ci.yml doesn't exist."
        exit 1
    }
}

function New-DataPlanePackageFolder() {
  param(
      [string]$service,
      [string]$namespace,
      [string]$sdkPath = "",
      [string]$inputfiles = "", # input files, separated by semicolon if more than one
      [string]$readme = "",
      [string]$securityScope = "",
      [string]$securityHeaderName = "",
      [string]$AUTOREST_CONFIG_FILE = "autorest.md",
      [string]$outputJsonFile = "output.json"
  )

  $sdkPath = $sdkPath -replace "\\", "/"

  $inputfile = ""
  $fileArray = $inputfiles.Split(";")
  if (($inputfiles -ne "") -And ($fileArray.Length -gt 0)) {
    for ($i = 0; $i -lt $fileArray.Count ; $i++) {
        $inputfile = $inputfile + [Environment]::NewLine + "- " + $fileArray[$i]
    }
  }

  $serviceFolder = (Join-Path $sdkPath "sdk" $service)
  if (!(Test-Path -Path $serviceFolder)) {
    Write-Host "service folder does not exist! create the folder $serviceFolder"
    New-Item -Path $serviceFolder -ItemType Directory
  }
  $projectFolder=(Join-Path $sdkPath "sdk" $service $namespace)
  $ciymlFilePath =(Join-Path $sdkPath "sdk" $service $CI_YAML_FILE)
  $apifolder = (Join-Path $projectFolder "api")
  Write-Host "projectFolder:$projectFolder, apifolder:$apifolder"
  if ((Test-Path -Path $projectFolder) -And (Test-Path -Path $apifolder)) {
    Write-Host "Path exists!"
    # update the input-file url if needed.
    $file = (Join-Path $projectFolder "src" $AUTOREST_CONFIG_FILE)
    Update-AutorestConfigFile -autorestFilePath $file -inputfile $inputfile -readme $readme
    Update-CIYmlFile -ciFilePath $ciymlFilePath -artifact $namespace
  } else {
    Write-Host "Path doesn't exist. create template."
    if ($inputfile -eq "" -And $readme -eq "") {
        Write-Error "Error: input file should not be empty."
        exit 1
    }
    dotnet new -i $sdkPath/sdk/template
    Write-Host "Create project folder $projectFolder"
    if (Test-Path -Path $projectFolder) {
        Remove-Item -Path $projectFolder -ItemType Directory
    }

    Push-Location $serviceFolder
    $namespaceArray = $namespace.Split(".")
    if ( $namespaceArray.Count -lt 3) {
        Write-Error "Error: invalid namespace name."
        exit 1
    }

    $clientName = $namespaceArray[-1]
    $groupName = $namespaceArray[1]
    $dotnetNewCmd = "dotnet new azsdkdpg --name $namespace --clientName $clientName --groupName $groupName --serviceDirectory $service --force"
    if ($inputfile -ne "") {
        $dotnetNewCmd = $dotnetNewCmd + " --swagger '$inputfile'"
    }
    if ($securityScope -ne "") {
        $dotnetNewCmd = $dotnetNewCmd + " --securityScopes $securityScope";
    }

    if ($securityHeaderName -ne "") {
        $dotnetNewCmd = $dotnetNewCmd + " --securityHeaderName $securityHeaderName";
    }

    if (Test-Path -Path $ciymlFilePath) {
        Write-Host "ci.yml already exists. update it to include the new serviceDirectory."
        Update-CIYmlFile -ciFilePath $ciymlFilePath -artifact $namespace

        $dotnetNewCmd = $dotnetNewCmd + " --includeCI false"
    }
    # dotnet new azsdkdpg --name $namespace --clientName $clientName --groupName $groupName --serviceDirectory $service --swagger $inputfile --securityScopes $securityScope --securityHeaderName $securityHeaderName --includeCI true --force
    Write-Host "Invoke dotnet new command: $dotnetNewCmd"
    Invoke-Expression $dotnetNewCmd

    $file = (Join-Path $projectFolder "src" $AUTOREST_CONFIG_FILE)
    Write-Host "Updating configuration file: $file"
    Update-AutorestConfigFile -autorestFilePath $file -readme $readme
    Pop-Location
    # dotnet sln
    Push-Location $projectFolder
    dotnet sln remove src\$namespace.csproj
    dotnet sln add src\$namespace.csproj
    dotnet sln remove tests\$namespace.Tests.csproj
    dotnet sln add tests\$namespace.Tests.csproj
    Pop-Location
  }

  Push-Location $sdkPath
  $relativeFolderPath = Resolve-Path $projectFolder -Relative
  Pop-Location

  $outputJson = [PSCustomObject]@{
    service = $service
    packageName = $namespace
    projectFolder = $projectFolder
    path = @($relativeFolderPath)
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
    Push-Location $sdkfolder/src
    dotnet build /t:GenerateCode
    if ( !$? ) {
        Write-Error "Failed to generate sdk."
        Pop-Location
        exit 1
    }
    Pop-Location
}

function Invoke-Build() {
    param(
        [string]$sdkfolder= ""
    )
    $sdkfolder = $sdkfolder -replace "\\", "/"
    Push-Location $sdkfolder
    dotnet build
    if ( !$? ) {
        Write-Error "Failed to build sdk. exit code: $?"
        Pop-Location
        exit 1
    }
    Pop-Location
}

function Invoke-Pack() {
    param(
        [string]$sdkfolder= ""
    )
    $sdkfolder = $sdkfolder -replace "\\", "/"
    Push-Location $sdkfolder
    dotnet pack
    if ( !$? ) {
        Write-Error "Failed to build sdk package. exit code: $?"
        Pop-Location
        exit 1
    }
    Pop-Location
}
function Get-ResourceProviderFromReadme($readmeFile) {
    $readmeFileRegex = "(?<specName>.*)/(?<serviceType>.*)/readme.md"
    $readmeFileRegexWithSpec = "specification/(?<specName>.*)/(?<serviceType>.*)/readme.md"
    try
    {
        if ($readmeFile -match $readmeFileRegexWithSpec)
        {
            return $matches["specName"], $matches["serviceType"]
        }
        if ($readmeFile -match $readmeFileRegex)
        {
            return $matches["specName"], $matches["serviceType"]
        }
        
    }
    catch
    {
        Write-Error "Error parsing readme info"
        Write-Error $_
    }
    Write-Host "Cannot find resouce provider info"
    # exit 1
}
