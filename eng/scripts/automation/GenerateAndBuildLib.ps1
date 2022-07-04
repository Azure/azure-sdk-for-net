#Requires -Version 7.0
$CI_YAML_FILE = "ci.yml"

#mgmt: resourceProvider to sdk package name map
$packageNameHash = [ordered]@{"vmware" = "avs"; 
                            "azure-kusto"="kusto";
                            "cosmos-db"="cosmosdb";
                            "customer-insights"="customerinsights";
                            "monitor"="insights";
                            "msi"="managedserviceidentity";
                            "web"="appservice"}

function Get-SwaggerInfo()
{
    param(
        [string]$dir,
        [string]$AUTOREST_CONFIG_FILE = "autorest.md"
    )
    $swaggerInfoRegex = ".*github.*.com\/(?<org>.*)\/azure-rest-api-specs\/blob\/(?<commitID>[0-9a-f]{40})\/specification\/(?<specName>.*)\/resource-manager\/readme.md"
    $rawSwaggerInfoRegex = ".*github.*.com\/(?<org>.*)\/azure-rest-api-specs\/(?<commitID>[0-9a-f]{40})\/specification\/(?<specName>.*)\/resource-manager\/readme.md"
    $swaggerNoCommitRegex = ".*github.*.com\/(?<org>.*)\/azure-rest-api-specs\/(blob\/)?(?<branch>.*)\/specification\/(?<specName>.*)\/resource-manager\/readme.md"
    try
    {
        $autorestfile = (Join-Path $dir $AUTOREST_CONFIG_FILE)
        $content = Get-Content $autorestfile -Raw
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

function CreateOrUpdateAutorestConfigFile() {
    param (
        [string]$autorestFilePath,
        [string]$inputfile = "",
        [string]$readme = "",
        [string]$autorestConfigYaml = ""
    )

    if ((Test-Path -Path $autorestFilePath) -and (![String]::IsNullOrWhiteSpace((Get-Content -Path $autorestFilePath)))) {
        if (($readme -ne "") -or ($inputfile -ne "")) {
            $requirRex = "require*:*";
            $inputfileRex = "input-file*:*"
            $fileContent = Get-Content -Path $autorestFilePath
            # clear
            $fileContent = $fileContent -notmatch $requirRex
            $fileContent = $fileContent -notmatch "- .*.md"
            $fileContent = $fileContent -notmatch "csharp: true"
            $fileContent = $fileContent -notmatch $inputfileRex
            $fileContent = $fileContent -notmatch "- .*.json"

            $startNum = ($fileContent | Select-String -Pattern '```').LineNumber[0]
            $configline = ""
            if ($readme -ne "") {
                Write-Host "Updating autorest.md file to config required readme file."
                $requirefile = $readme
                $configline = "require:" + [Environment]::NewLine + "- " + "$requirefile" + [Environment]::NewLine + "csharp: true"
            } elseif ($inputfile -ne "") {
                Write-Host "Updating autorest.md file to update input-file."
                if ($inputfile.StartsWith('-')) {
                    $configline = "input-file:" + [Environment]::NewLine + "$inputfile"
                } else {
                    $configline = "input-file:"  + "$inputfile"
                }
            }

            $fileContent[$startNum - 1] += ([Environment]::NewLine + $configline)
            $fileContent | Set-Content $autorestFilePath
            if ( !$? ) {
                Write-Error "Failed to update autorest.md. exit code: $?"
                exit 1
            }
        }
        
        # update autorest.md with configuration
        if ( $autorestConfigYaml -ne "") {
            Write-Host "Update autorest.md with configuration."
            $range = ($autorestConfigYaml | Select-String -Pattern '```').LineNumber
            if ( $range.count -gt 1) {
                $startNum = $range[0];
                $lines = $range[1] - $range[0] - 1
                $autorestConfigYaml = ($autorestConfigYaml | Select -Skip $startNum | Select -First $lines) |Out-String
            }

            Install-Module -Name powershell-yaml -Force -Verbose -Scope CurrentUser
            Import-Module powershell-yaml
            $yml = ConvertFrom-YAML $autorestConfigYaml

            $fileContent = Get-Content -Path $autorestFilePath
            Foreach ( $key in $yml.keys) {
                if ( ($key -eq "output-folder") -or ($key -eq "require")) {
                    continue;
                }
                $match = ($fileContent | Select-String -Pattern $key).LineNumber
                if ($match.count -gt 0) {
                    $fileContent[$match[0] - 1] = $key + ":" + $yml[$key];
                } else {
                    $startNum = ($fileContent | Select-String -Pattern '```').LineNumber[0]
                    $fileContent[$startNum - 1] += ([Environment]::NewLine + $key + ":" + $yml[$key])
                }
            }

            $fileContent | Out-File $autorestFilePath
        }
    } else {
        Write-Host "autorest.md does not exist. start to create one."
        if ( $autorestConfigYaml -ne "") {
            Write-Host "Create autorest.md with configuration."
            $autorestConfigYaml = "# Azure.IoT.DeviceUpdate" + [Environment]::NewLine + '``` yaml' +  [Environment]::NewLine + $autorestConfigYaml + '```' + [Environment]::NewLine;
            $autorestConfigYaml | Out-File $autorestFilePath
        } else {
            Write-Error "autorest.md does not exist, and no autorest configuration to create one."
        }
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
      [string]$autorestConfigYaml = "",
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
    CreateOrUpdateAutorestConfigFile -autorestFilePath $file -inputfile "$inputfile" -readme "$readme" -autorestConfigYaml "$autorestConfigYaml"
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
    CreateOrUpdateAutorestConfigFile -autorestFilePath $file -readme "$readme" -autorestConfigYaml "$autorestConfigYaml"
    Pop-Location

    $projFile = (Join-Path $projectFolder "src" "$namespace.csproj")
    (Get-Content $projFile) -replace "<Version>*.*.*-*.*</Version>", "<Version>1.0.0-beta.1</Version>" | Set-Content $projFile
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
        [string]$readme = "",
        [string]$AUTOREST_CONFIG_FILE = "autorest.md",
        [string]$outputJsonFile = "newPacakgeOutput.json"
    )
  
    if ($packageName -eq "") {
        $packageName = $service
    }

    $projectFolder = (Join-Path $sdkPath "sdk" $packageName "Azure.ResourceManager.*")
    $mgmtPackageName = ""
    $projectFolder = $projectFolder -replace "\\", "/"
    if (Test-Path -Path $projectFolder) {
      Write-Host "Path exists!"
      $folderinfo = Get-ChildItem -Path $projectFolder
      $mgmtPackageName = $folderinfo.Name
      $projectFolder = "$sdkPath/sdk/$packageName/$mgmtPackageName"
    } else {
      Write-Host "Path doesn't exist. create template."
      dotnet new -i $sdkPath/eng/templates/Azure.ResourceManager.Template
    #   $CaptizedPackageName = (Get-Culture ).TextInfo.ToTitleCase($packageName)
      $CaptizedPackageName = [System.Globalization.CultureInfo]::InvariantCulture.TextInfo.ToTitleCase($packageName)
      $mgmtPackageName = "Azure.ResourceManager.$CaptizedPackageName"
      $projectFolder="$sdkPath/sdk/$packageName/Azure.ResourceManager.$CaptizedPackageName"
      Write-Host "Create project folder $projectFolder"
      New-Item -Path $projectFolder -ItemType Directory
      Push-Location $projectFolder
      dotnet new azuremgmt --provider $packageName --includeCI true --force
      Pop-Location
    }
  
    # update the readme path.
    if ($readme -ne "") {
      Write-Host "Updating autorest.md file."
      $requirefile = "require: $readme"
      $rquirefileRex = "require *:.*.md"
      $file="$projectFolder/src/$AUTOREST_CONFIG_FILE"
      (Get-Content $file) -replace $rquirefileRex, "$requirefile" | Set-Content $file
    }
  
    Push-Location $sdkPath
    $relativeFolderPath = Resolve-Path $projectFolder -Relative
    Pop-Location
  
    $outputJson = [PSCustomObject]@{
      service = $service
      packageName = $mgmtPackageName
      projectFolder = $projectFolder
      path = @($relativeFolderPath)
    }
    $outputJson | ConvertTo-Json -depth 100 | Out-File $outputJsonFile
  
    return $projectFolder
}
function Invoke-Generate() {
    param(
        [string]$sdkfolder= ""
    )
    $sdkfolder = $sdkfolder -replace "\\", "/"
    dotnet build /t:GenerateCode  $sdkfolder/src
    if ( !$? ) {
        Write-Error "Failed to generate sdk."
        exit 1
    }
}

function Invoke-Build() {
    param(
        [string]$sdkfolder= ""
    )
    $sdkfolder = $sdkfolder -replace "\\", "/"
    dotnet build $sdkfolder
    if ( !$? ) {
        Write-Error "Failed to build sdk. exit code: $?"
        exit 1
    }
}

function Invoke-Pack() {
    param(
        [string]$sdkfolder= ""
    )
    $sdkfolder = $sdkfolder -replace "\\", "/"
    dotnet pack $sdkfolder /p:RunApiCompat=$false
    if ( !$? ) {
        Write-Error "Failed to build sdk package. exit code: $?"
        exit 1
    }
}
function Get-ResourceProviderFromReadme($readmeFile) {
    $readmeFile = $readmeFile -replace "\\", "/"
    $pathArray = $readmeFile.Split("/");

    if ( $pathArray.Count -lt 3) {
        Write-Error "Error: invalid readme file path."
        exit 1
    }

    $specName = $pathArray[-3]
    $serviceType = $pathArray[-2]
    Write-Host "specName:$specName, serviceType: $serviceType"

    return $specName, $serviceType
}

function Invoke-GenerateAndBuildSDK () {
    param(
        [string]$readmeAbsolutePath,
        [string]$sdkRootPath,
        [string]$autorestConfigYaml = "",
        [string]$downloadUrlPrefix = "",
        [object]$generatedSDKPackages
    )
    $readmeFile = $readmeAbsolutePath -replace "\\", "/"
    Write-Host "readmeFile:$readmeFile"
    $service, $serviceType = Get-ResourceProviderFromReadme $readmeFile
    Write-Host "service:$service, serviceType:$serviceType"
    
    if (!(Test-Path -Path $readmeFile)) {
        Write-Error "readme file does not exist."
        exit 1
    }
    
    $packagesToGen = @()
    $newpackageoutput = "newPackageOutput.json"
    if ( $serviceType -eq "resource-manager" ) {
        Write-Host "Generate resource-manager SDK client library."
        $package = $service
        if ($packageNameHash[$service] -ne "") {
            $package = $packageNameHash[$service]
        }
        New-MgmtPackageFolder -service $service -packageName $package -sdkPath $sdkRootPath -commitid $commitid -readme $readmeFile -outputJsonFile $newpackageoutput
        if ( !$?) {
            Write-Error "Failed to create sdk project folder. exit code: $?"
            exit 1
        }
        $newpackageoutputJson = Get-Content $newpackageoutput | Out-String | ConvertFrom-Json
        $packagesToGen = $packagesToGen + @($newpackageoutputJson)
        Remove-Item $newpackageoutput
    } else {
        Write-Host "Generate data-plane SDK client library."
        $namespace = ""
        if ( $autorestConfigYaml -ne "") {
            # support single package
            $range = ($autorestConfigYaml | Select-String -Pattern '```').LineNumber
            if ( $range.count -gt 1) {
                $startNum = $range[0];
                $lines = $range[1] - $range[0] - 1
                $autorestConfigYaml = ($autorestConfigYaml | Select -Skip $startNum | Select -First $lines) |Out-String
            }
            Install-Module -Name powershell-yaml -Force -Verbose -Scope CurrentUser
            Import-Module powershell-yaml
            $yml = ConvertFrom-YAML $autorestConfigYaml

            $outputFolder = $yml["output-folder"]
            if ($outputFolder -ne "") {
                $directories = $outputFolder.Split("/");
                $service = $directories[-2];
                $namespace = $directories[-1];
            }

            New-DataPlanePackageFolder -service $service -namespace $namespace -sdkPath $sdkRootPath -readme $readmeFile -autorestConfigYaml "$autorestConfigYaml" -outputJsonFile $newpackageoutput
            if ( !$? ) {
                Write-Error "Failed to create sdk project folder. exit code: $?"
                exit 1
            }
            $newpackageoutputJson = Get-Content $newpackageoutput | Out-String | ConvertFrom-Json
            $packagesToGen = $packagesToGen + @($newpackageoutputJson)
            Remove-Item $newpackageoutput
        } else {
            npx autorest --version=3.8.4 --csharp $readmeFile --csharp-sdks-folder=$sdkRootPath --skip-csproj --clear-output-folder=true
            $serviceSDKDirectory = (Join-Path $sdkPath sdk $service)
            $folders = Get-ChildItem $serviceSDKDirectory -Directory -exclude *.*Management*,Azure.ResourceManager*
            $folders |ForEach-Object {
                $folder=$_.Name
                New-DataPlanePackageFolder -service $service -namespace $folder -sdkPath $sdkRootPath -readme $readmeFile -outputJsonFile $newpackageoutput
                if ( !$? ) {
                    Write-Error "Failed to create sdk project folder. exit code: $?"
                    exit 1
                }
                $newpackageoutputJson = Get-Content $newpackageoutput | Out-String | ConvertFrom-Json
                $packagesToGen = $packagesToGen + @($newpackageoutputJson)
                Remove-Item $newpackageoutput
            }
        }
    }

    foreach ( $package in $packagesToGen )
    {
        $projectFolder = $newpackageoutputJson.projectFolder
        $path = $newpackageoutputJson.path
        $service = $newpackageoutputJson.service
        # $packageName = $newpackageoutputJson.packageName
        Write-Host "projectFolder:$projectFolder"

        GeneratePackage -projectFolder $projectFolder -sdkRootPath $sdkRootPath -path $path -downloadUrlPrefix $downloadUrlPrefix -generatedSDKPackages $generatedSDKPackages
    }
}

function GeneratePackage()
{
    param(
        [string]$projectFolder,
        [string]$sdkRootPath,
        [string]$path,
        [string]$downloadUrlPrefix="",
        [object]$generatedSDKPackages
    )

    $packageName = Split-Path $projectFolder -Leaf
    $projectFolder = $projectFolder -replace "\\", "/"
    $projectFolder -match "sdk/(?<service>.*)/"
    $service = $matches["service"]
    Write-Host "Generating code for " $packageName
    $artifacts = @()
    $apiViewArtifact = ""
    $hasBreakingChange = $null
    $content = $null
    $result = ""
    $srcPath = Join-Path $projectFolder 'src'

    # Generate Code
    Invoke-Generate -sdkfolder $projectFolder
    if ( !$?) {
        Write-Error "Failed to generate sdk. exit code: $?"
        exit 1
    }

    # Build
    Invoke-Build -sdkfolder $projectFolder
    if ( !$? ) {
        Write-Error "Failed to build sdk. exit code: $?"
        exit 1
    }

    # pack
    Invoke-Pack -sdkfolder $projectFolder
    if ( !$? ) {
        Write-Error "Failed to packe sdk. exit code: $?"
        exit 1
    }
    # Generate APIs
    pwsh $sdkRootPath/eng/scripts/Export-API.ps1 $service

    # breaking change validation
    $srcPath = Join-Path $projectFolder 'src'
    $hasBreakingChange = $null
    $content = $null
    $logFilePath = Join-Path "$srcPath" 'log.txt'
    if (!(Test-Path $logFilePath)) {
        New-Item $logFilePath
    }
    dotnet build $srcPath /t:RunApiCompat /p:TargetFramework=netstandard2.0 /flp:v=m`;LogFile=$logFilePath`
    if (!$LASTEXITCODE) {
        $hasBreakingChange = $false
    }
    else {
        $logFile = Get-Content -Path $logFilePath | select-object -skip 2
        $breakingChanges = $logFile -join ",`n"
        $content = "Breaking Changes: $breakingChanges"
        $hasBreakingChange = $true
    }

    if (Test-Path $logFilePath) {
        Remove-Item $logFilePath
    }

    $changelog = [PSCustomObject]@{
        content           = $content
        hasBreakingChange = $hasBreakingChange
    }

    # artifacts
    Push-Location $sdkRootPath
    $artifactsPath = (Join-Path "artifacts" "packages" "Debug" $packageName)
    [string[]]$artifacts += Get-ChildItem $artifactsPath -Filter *.nupkg -exclude *.symbols.nupkg -Recurse | Select-Object -ExpandProperty FullName | Resolve-Path -Relative
    $apiViewArtifact = ""
    if ( $artifacts.count -le 0) {
        Write-Error "Failed to generate sdk artifact"
    } else {
        $apiViewArtifact = $artifacts[0]
    }
    Pop-Location

    $full = $null
    if ($artifacts.count -gt 0) {
        $fileName = Split-Path $artifacts[0] -Leaf
        $full = "Download the $packageName package from [here]($downloadUrlPrefix/$fileName)"
    }
    $installInstructions = [PSCustomObject]@{
        full = $full
        lite = $full
    }
    $generatedSDKPackages.Add(@{packageName="$packageName"; 
                                result=$result;
                                path=@("$path");
                                packageFolder="$projectFolder";
                                artifacts=$artifacts;
                                apiViewArtifact=$apiViewArtifact;
                                language=".Net";
                                changelog= $changelog;
                                installInstructions = $installInstructions})
}
function UpdateExistingSDKByInputFiles()
{
    param(
        [string[]]$inputFilePaths,
        [string]$sdkRootPath,
        [string]$headSha = "",
        [string]$repoHttpsUrl,
        [object]$generatedSDKPackages
    )

    $autorestFilesPath = Get-ChildItem -Path "$sdkRootPath/sdk"  -Filter autorest.md -Recurse | Resolve-Path -Relative
    Write-Host "Updating autorest.md files for all the changed swaggers."
    [System.Collections.ArrayList] $sdksInfo = @()
    $regexToFindSha = "https:\/\/[^`"]*[\/][0-9a-f]{4,40}[\/]"
    foreach ($path in $autorestFilesPath) {
        $fileContent = Get-Content $path
        foreach ($inputFilePath in $inputFilePaths) {
            $escapedInputFilePath = [System.Text.RegularExpressions.Regex]::Escape($inputFilePath)
            $regexForMatchingShaAndPath = $regexToFindSha + $escapedInputFilePath

            foreach ($line in $fileContent) {
                if ($line -match $regexForMatchingShaAndPath) {
                    $fileContent -replace $regexToFindSha, "$repoHttpsUrl/blob/$headSha/" | Set-Content -Path $path

                    $sdkpath = (get-item $path).Directory.Parent.FullName | Resolve-Path -Relative
                    if (!$sdksInfo.Contains($sdkpath)) {
                        $sdksInfo.Add($sdkpath)
                    }
                    break
                }
            }
        }
    }

    # generate SDK
    foreach ($sdkpath in $sdksInfo) {
        $path = , $sdkPath
        $projectFolder = Join-Path $sdkRootPath $sdkPath
        $projectFolder = Resolve-Path -Path $projectFolder
        $projectFolder -match "sdk/(?<specName>.*)/data-plane|resource-manager"
        if (!$serviceWithReadme.Contains($matches["service"])) {
            $inputFileToGen.Add($file)
        }
        GeneratePackage -projectFolder $projectFolder -sdkRootPath $sdkRootPath -path $path -downloadUrlPrefix $downloadUrlPrefix -generatedSDKPackages $generatedSDKPackages
    }
    
}