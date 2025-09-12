#Requires -Version 7.0
$CI_YAML_FILE = "ci.yml"
$TSP_LOCATION_FILE = "tsp-location.yaml"

. (Join-Path $PSScriptRoot ".." ".." "common" "scripts" "Helpers" PSModule-Helpers.ps1)

#mgmt: swagger directory name to sdk directory name map
$packageNameHash = [ordered]@{
    "azure-kusto" = "kusto";
    "cosmos-db" = "cosmosdb";
    "msi" = "managedserviceidentity";
    "recoveryservicesbackup" = "recoveryservices-backup";
    "recoveryservicessiterecovery" = "recoveryservices-siterecovery";
    "security" = "securitycenter";
    "sql" = "sqlmanagement";
    "vmware" = "avs";
    "web" = "websites";
}

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
        Write-Host "[ERROR] Error parsing swagger info: $_"
    }
    Write-Host "Cannot find swagger info"
    exit 1
}

<#
.SYNOPSIS
create or update the autorest config file for sdk (autorest.md)

.DESCRIPTION
1. update input-file or require block according to the input parameter. If readme parameter is provided, autorest.md will
contain only require block, if input-file parameter is provided, autorest.md will contain only require block.
2. merge the autorestConfig to the autorest.md

.PARAMETER autorestFilePath
Path to the sdk autorest config file (autorest.md).

.PARAMETER namespace
The service namespace, it is equal to the SDK package folder name.

.PARAMETER inputfile
Paths to input-file.
e.g http://***/*.json for one input-file.
If more than one input-file path provided, please write as followin:
- http://****/*.json
- http://****/**.json

.PARAMETER readme
Path to readme file. If readme is provided, we will ignore inputfile parameter.

.EXAMPLE
Call function with default parameters.

CreateOrUpdateAutorestConfigFile -autorestFilePath <autorestFilePath> -namespace <namespace>

#>
function CreateOrUpdateAutorestConfigFile() {
    param (
        [string]$autorestFilePath,
        [string]$namespace,
        [string]$inputfile = "",
        [string]$readme = "",
        [string]$autorestConfigYaml = ""
    )

    $fileContent = ""
    if (Test-Path -Path $autorestFilePath) {
        $fileContent = Get-Content -Path $autorestFilePath -Raw
    }
    if (![String]::IsNullOrWhiteSpace($fileContent)) {
        if (($readme -ne "") -or ($inputfile -ne "")) {
            $configline = ""
            if ($readme) {
                Write-Host "Updating autorest.md file to config required readme file."
                $configline = "require:`n- ${readme}`n"
            } elseif ($inputfile) {
                Write-Host "Updating autorest.md file to update input-file."
                if ($inputfile.StartsWith('-')) {
                    $configline = "input-file:`n$inputfile`n"
                } else {
                    $configline = "input-file:"  + "$inputfile`n"
                }
            }

            $inputRegex = "(?:(?:input-file|require)\s*:\s*\r?\n(?:\s*-\s+.*\r?\n)+|(?:input-file|require):\s+.*)"
            $fileContent = $fileContent -replace $inputRegex, $configline
            $fileContent | Set-Content $autorestFilePath
        }

        # update autorest.md with configuration
        if ( $autorestConfigYaml) {
            Write-Host "Update autorest.md with configuration."
            $range = ($autorestConfigYaml | Select-String -Pattern '```').LineNumber
            if ( $range.count -gt 1) {
                $startNum = $range[0];
                $lines = $range[1] - $range[0] - 1
                $autorestConfigYaml = ($autorestConfigYaml | Select -Skip $startNum | Select -First $lines) |Out-String
            }

            Install-ModuleIfNotInstalled "powershell-yaml" "0.4.1" | Import-Module
            $yml = ConvertFrom-YAML $autorestConfigYaml

            $fileContent = Get-Content -Path $autorestFilePath
            foreach ( $key in $yml.keys) {
                if ( ($key -eq "output-folder") -or ($key -eq "require")) {
                    continue;
                }
                $match = ($fileContent | Select-String -Pattern $key).LineNumber
                if ($match.count -gt 0) {
                    $fileContent[$match[0] - 1] = $key + ": " + $yml[$key];
                } else {
                    $startNum = ($fileContent | Select-String -Pattern '```').LineNumber[0]
                    $fileContent[$startNum - 1] += ([Environment]::NewLine + $key + ": " + $yml[$key])
                }
            }

            $fileContent | Out-File $autorestFilePath
        }
    } else {
        Write-Host "autorest.md does not exist. start to create one."
        if ( $autorestConfigYaml ) {
            Write-Host "Create autorest.md with configuration."
            $autorestConfigYaml = "# $namespace`n"  + '``` yaml' + "`n$autorestConfigYaml" + '```' + "`n";
            $autorestConfigYaml | Out-File $autorestFilePath
        } else {
            Throw "[ERROR] autorest.md does not exist, and no autorest configuration to create one. Please provide the necessary autorest configuration."
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
        Throw "ci.yml doesn't exist."
    }
}

function RegisterMgmtSDKToMgmtCoreClient () {
    param(
        [string]$packagesPath
    )
    $track2MgmtDirs = Get-ChildItem -Path "$packagesPath" -Directory -Recurse -Depth 1 | Where-Object { $_.Name -match "(Azure.ResourceManager.)" -and $(Test-Path("$($_.FullName)/src")) } | Sort-Object -Property { (Split-Path $_.FullName -Parent) }
    Write-Host "Updating mgmt core client ci.mgmt.yml"
    #add path for each mgmt library into Azure.ResourceManager
    $armCiFile = "$packagesPath/resourcemanager/ci.mgmt.yml"
    $armLines = Get-Content $armCiFile
    $newLines = [System.Collections.ArrayList]::new()
    $startIndex = $track2MgmtDirs[0].FullName.Replace('\', '/').IndexOf(("/sdk/")) + 1
    $shouldRemove = $false
    foreach($line in $armLines) {
        if($line.StartsWith("  paths:")) {
            $newLines.Add($line) | Out-Null
            $newLines.Add("    include:") | Out-Null
            $newLines.Add("    - sdk/resourcemanager") | Out-Null
            $newLines.Add("    - common/ManagementTestShared") | Out-Null
            $newLines.Add("    - common/ManagementCoreShared") | Out-Null
            foreach($dir in $track2MgmtDirs) {
                $newLine = "    - $($dir.FullName.Replace('\', '/').Substring($startIndex, $dir.FullName.Length - $startIndex))"
                $newLines.Add($newLine) | Out-Null
            }
            $shouldRemove = $true
            Continue
        }

        if($shouldRemove) {
            if($line.StartsWith(" ")) {
                Continue
            }
            $shouldRemove = $false
        }

        $newLines.Add($line) | Out-Null
    }
    Set-Content -Path $armCiFile $newLines
}
<#
.SYNOPSIS
Prepare the SDK pacakge for data-plane.
Update the autorest.md.

#>
function Update-DataPlanePackageFolder() {
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
    CreateOrUpdateAutorestConfigFile -autorestFilePath $file -namespace $namespace -inputfile "$inputfile" -readme "$readme" -autorestConfigYaml "$autorestConfigYaml"
    Update-CIYmlFile -ciFilePath $ciymlFilePath -artifact $namespace
  } else {
    Write-Host "[ERROR] Project directory doesn't exist. It is a new .NET SDK. We will not support onboard a new SDK from swagger. Please contact the DotNet language support channel at $DotNetSupportChannelLink and include this spec pull request."
    exit 1
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

<#
.SYNOPSIS
Prepare the SDK pacakge for mangement-plane.
Update the autorest.md.

#>
function Update-MgmtPackageFolder() {
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
      Write-Host "[ERROR] Project directory doesn't exist. It is a new .NET SDK. We will not support onboard a new service SDK from swagger. Please contact the DotNet language support channel at $DotNetSupportChannelLink and include this spec pull request."
      exit 1
    }

    # update the readme path.
    if ($readme) {
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

function CreateOrUpdateTypeSpecConfigFile() {
    param (
        [string]$typespecConfigurationFile,
        [string]$directory,
        [string]$commit = "",
        [string]$repo = "",
        [string]$specRoot = "",
        [string]$additionalSubDirectories="" #additional directories needed, separated by semicolon if more than one

    )
    if (!(Test-Path -Path $typespecConfigurationFile)) {
        New-Item -Path $typespecConfigurationFile
    }

    Install-ModuleIfNotInstalled "powershell-yaml" "0.4.1" | Import-Module
    $configuration = Get-Content -Path $typespecConfigurationFile -Raw | ConvertFrom-Yaml
    if ( !$configuration) {
        $configuration = @{}
    }
    $configuration["directory"] = $directory
    if ($commit) {
        $configuration["commit"] = $commit
    } else {
        $configuration.Remove("commit")
    }
    if ($repo) {
        $configuration["repo"] = $repo
    } else {
        $configuration.Remove("repo")
    }

    if ($specRoot) {
        $configuration["spec-root-dir"] = $specRoot
    } else {
        $configuration.Remove("spec-root-dir")
    }

    if ($additionalSubDirectories) {
        $directoryArray = [string[]]$additionalSubDirectories.Split(";")
        $configuration["additionalDirectories"] = [Collections.Generic.List[string]]$directoryArray;
    } else {
        $configuration.Remove("additionalDirectories")
    }

    $configuration |ConvertTo-Yaml | Out-File $typespecConfigurationFile
}

function New-TypeSpecPackageFolder() {
    param(
        [string]$service,
        [string]$namespace,
        [string]$sdkPath = "",
        [string]$relatedTypeSpecProjectFolder,
        [string]$commit = "",
        [string]$repo = "",
        [string]$specRoot = "",
        [string]$additionalSubDirectories="", #additional directories needed, separated by semicolon if more than one
        [string]$outputJsonFile = "$PWD/output.json"
    )
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
        if (Test-Path -Path $projectFolder/src/autorest.md) {
            Remove-Item -Path $projectFolder/src/autorest.md
        }

        CreateOrUpdateTypeSpecConfigFile `
            -typespecConfigurationFile $projectFolder/$TSP_LOCATION_FILE `
            -directory $relatedTypeSpecProjectFolder `
            -commit $commit `
            -repo $repo `
            -specRoot $specRoot `
            -additionalSubDirectories $additionalSubDirectories

        Update-CIYmlFile -ciFilePath $ciymlFilePath -artifact $namespace
    } else {
        Write-Host "Path doesn't exist. create template."
        dotnet new -i $sdkPath/sdk/template
        Write-Host "Create project folder $projectFolder"
        if (Test-Path -Path $projectFolder) {
            Remove-Item -Path $projectFolder -ItemType Directory
        }

        Push-Location $serviceFolder
        $namespaceArray = $namespace.Split(".")
        if ( $namespaceArray.Count -lt 3) {
            Throw "[ERROR] Invalid namespace name provided: $namespace. Please provide valid namespace."
        }

        $endIndex = $namespaceArray.Count - 2
        $clientName = $namespaceArray[-1]
        $groupName = $namespaceArray[1..$endIndex] -join "."
        $dotnetNewCmd = "dotnet new azsdkdpg --name $namespace --clientName $clientName --groupName $groupName --serviceDirectory $service --force"

        if (Test-Path -Path $ciymlFilePath) {
            Write-Host "ci.yml already exists. update it to include the new serviceDirectory."
            Update-CIYmlFile -ciFilePath $ciymlFilePath -artifact $namespace

            $dotnetNewCmd = $dotnetNewCmd + " --includeCI false"
        }
        # dotnet new azsdkdpg --name $namespace --clientName $clientName --groupName $groupName --serviceDirectory $service --swagger $inputfile --securityScopes $securityScope --securityHeaderName $securityHeaderName --includeCI true --force
        Write-Host "Invoke dotnet new command: $dotnetNewCmd"
        Invoke-Expression $dotnetNewCmd

        $projFile = (Join-Path $projectFolder "src" "$namespace.csproj")
        $fileContent = Get-Content -Path $projFile
        $fileContent = $fileContent -replace '<Version>[^<]+</Version>', '<Version>1.0.0-beta.1</Version>'
        $fileContent | Out-File $projFile
        Pop-Location
        # dotnet sln
        Push-Location $projectFolder
        if (Test-Path -Path $projectFolder/src/autorest.md) {
            Remove-Item -Path $projectFolder/src/autorest.md
        }

        CreateOrUpdateTypeSpecConfigFile `
            -typespecConfigurationFile $projectFolder/$TSP_LOCATION_FILE `
            -directory $relatedTypeSpecProjectFolder `
            -commit $commit `
            -repo $repo `
            -specRoot $specRoot `
            -additionalSubDirectories $additionalSubDirectories

        dotnet sln remove src/$namespace.csproj
        dotnet sln add src/$namespace.csproj
        dotnet sln remove tests/$namespace.Tests.csproj
        dotnet sln add tests/$namespace.Tests.csproj
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

function Get-ResourceProviderFromReadme($readmeFile) {
    $readmeFile = $readmeFile -replace "\\", "/"
    $pathArray = $readmeFile.Split("/");

    if ( $pathArray.Count -lt 3) {
        Throw "[ERROR] Invalid readme file path: $readmeFile. A valid readme file path should contain specName and serviceType and be of the form <specName>/<serviceType>/readme.md, e.g. specification/deviceupdate/data-plane/readme.md"
    }

    $index = [array]::indexof($pathArray, "data-plane")
    if ($index -eq -1) {
        $index = [array]::indexof($pathArray, "resource-manager")
    }
    if ($index -ne -1) {
        $specName = $pathArray[$index-1]
        $serviceType = $pathArray[$index]
        Write-Host "specName: $specName, serviceType: $serviceType"

        return $specName, $serviceType
    }

    Throw "[ERROR] Fail to retrive the service name and type from $readmeFile. Please provide a valid readme file path, e.g. specification/deviceupdate/data-plane/readme.md"
}

<#
.SYNOPSIS
Generate and Build SDK via readme.md configuration file.

.DESCRIPTION
Generate and Build SDK for a service by readme.md file.

.PARAMETER readmeAbsolutePath
The absolute Path to the readme.md configuration file.

.PARAMETER sdkRootPath
Path to the root directory of azure-sdk-for-net repo.

.PARAMETER autorestConfigYaml
The autorest config string in yaml format

.PARAMETER downloadUrlPrefix
The download url prefix

.PARAMETER generatedSDKPackages
The out parameter which will store the genarated package information. It is an object array.

.EXAMPLE
Run script with default parameters.

Invoke-GenerateAndBuildSDK -readmeAbsolutePath <path-to-readme> -sdkRootPath <path-to-sdk-root-directory> -generatedSDKPackages <package-object-list>

#>

$DotNetSupportChannelLink = "https://aka.ms/azsdk/dotnet-teams-channel"
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

    if (!$readmeFile.StartsWith("http") -And !(Test-Path -Path $readmeFile)) {
        Write-Host "[ERROR] readme file '$readmeFile' does not exist. Please provide a valid readme file path."
        exit 1
    }

    $packagesToGen = @()
    $newPackageOutput = "newPackageOutput.json"
    if ( $serviceType -eq "resource-manager" ) {
        Write-Host "Generate resource-manager SDK client library."
        $package = $service
        if ($null -ne $packageNameHash[$service] -and $packageNameHash[$service] -ne "") {
            $package = $packageNameHash[$service]
            Write-Host "rename package name to $package"
        }
        $projectFolder = (Join-Path $sdkRootPath "sdk" $package "Azure.ResourceManager.*")
        if (Test-Path -Path $projectFolder) {
            Update-MgmtPackageFolder -service $service -packageName $package -sdkPath $sdkRootPath -commitid $commitid -readme $readmeFile -outputJsonFile $newpackageoutput
            if ( !$?) {
                Write-Host "[ERROR] Failed to create sdk project folder.service:$service,package:$package, sdkPath:$sdkRootPath,readme:$readmeFile.exit code: $?. Please review the detail errors for potential fixes. If the issue persists, contact the DotNet language support channel at $DotNetSupportChannelLink and include this spec pull request."
                exit 1
            }
            $newPackageOutputJson = Get-Content $newPackageOutput | Out-String | ConvertFrom-Json
            $packagesToGen = $packagesToGen + @($newPackageOutputJson)
            Remove-Item $newPackageOutput
        } else {
            Write-Host "Path doesn't exist. create template."
            Write-Host "[ERROR] The service $service is not onboarded yet. We will not support onboard a new service from swagger. Please contact the DotNet language support channel at $DotNetSupportChannelLink and include this spec pull request."
            exit 1
        }
    } else {
        Write-Host "Generate data-plane SDK client library."
        $namespace = ""
        if ( $autorestConfigYaml) {
            # support single package
            $range = ($autorestConfigYaml | Select-String -Pattern '```').LineNumber
            if ( $range.count -gt 1) {
                $startNum = $range[0];
                $lines = $range[1] - $range[0] - 1
                $autorestConfigYaml = ($autorestConfigYaml | Select -Skip $startNum | Select -First $lines) |Out-String
            }

            Install-ModuleIfNotInstalled "powershell-yaml" "0.4.1" | Import-Module
            $yml = ConvertFrom-YAML $autorestConfigYaml

            $outputFolder = $yml["output-folder"]
            if ($outputFolder) {
                $directories = $outputFolder.Split("/");
                $service = $directories[-2];
                $namespace = $directories[-1];
            }

            $projectFolder=(Join-Path $sdkRootPath "sdk" $service $namespace)
            if (Test-Path -Path $projectFolder) {
                Write-Host "Path exists!"
                Update-DataPlanePackageFolder -service $service -namespace $namespace -sdkPath $sdkRootPath -readme $readmeFile -autorestConfigYaml "$autorestConfigYaml" -outputJsonFile $newpackageoutput
                if ( !$? ) {
                    Write-Host "[ERROR] Failed to create sdk project folder.service:$service,namespace:$namespace, sdkPath:$sdkRootPath,readme:$readmeFile,autorestConfigYaml:$autorestConfigYaml.exit code: $?. Please review the detail errors for potential fixes. If the issue persists, contact the DotNet language support channel at $DotNetSupportChannelLink and include this spec pull request."
                    exit 1
                }
                $newPackageOutputJson = Get-Content $newPackageOutput | Out-String | ConvertFrom-Json
                $packagesToGen = $packagesToGen + @($newPackageOutputJson)
                Remove-Item $newPackageOutput
            } else {
                Write-Host "SDK project folder doesn't exist."
                Write-Host "[ERROR] The service $service is not onboarded yet. We will not support onboard a new service from swagger. Please contact the DotNet language support channel at $DotNetSupportChannelLink and include this spec pull request."
                exit 1
            }
        } else {
            # handle scenaro: multiple SDK packages one md file.
            # npx autorest --version=3.8.4 --csharp $readmeFile --csharp-sdks-folder=$sdkRootPath --skip-csproj --clear-output-folder=true
            # handle the sdk package already exists. The service may be onboarded before.
            $serviceSDKDirectory = (Join-Path $sdkRootPath "sdk" $service)
            $folders = Get-ChildItem $serviceSDKDirectory -Directory -exclude *.*Management*,Azure.ResourceManager*
            $regexForMatch="$service"
            if ($readmeAbsolutePath -match ".*$service(?<spec>.*)[/|\\]readme.md" ) {
                $regexForMatch = $matches["spec"] -replace "/|\\", "[/|\\]"
                $regexForMatch = "$service$regexForMatch"
            }
            foreach ($item in $folders) {
                $folder=$item.Name
                # filter out the valid sdk package by the readme path to process.
                $autorestFilePath = (Join-Path $serviceSDKDirectory $folder "src" "autorest.md")
                if (Test-Path -Path $autorestFilePath) {
                    $fileContent = Get-Content $autorestFilePath -Raw
                    if ($fileContent -match $regexForMatch) {
                        $projectFolder=(Join-Path $sdkRootPath "sdk" $service $folder)
                        if (Test-Path -Path $projectFolder) {
                            Write-Host "Path exists!"
                            Update-DataPlanePackageFolder -service $service -namespace $folder -sdkPath $sdkRootPath -readme $readmeFile -outputJsonFile $newpackageoutput
                            if ( !$? ) {
                                Write-Host "[ERROR] Failed to create sdk project folder.service:$service,namespace:$folder, sdkPath:$sdkRootPath,readme:$readmeFile. exit code: $?. Please review the detail errors for potential fixes. If the issue persists, contact the DotNet language support channel at $DotNetSupportChannelLink and include this spec pull request."
                                exit 1
                            }
                            $newPackageOutputJson = Get-Content $newPackageOutput | Out-String | ConvertFrom-Json
                            $packagesToGen = $packagesToGen + @($newPackageOutputJson)
                            Remove-Item $newPackageOutput
                        } else {
                            Write-Host "SDK project folder doesn't exist."
                            Write-Host "[ERROR] The service $service is not onboarded yet. We will not support onboard a new service from swagger. Please contact the DotNet language support channel at $DotNetSupportChannelLink and include this spec pull request."
                            exit 1
                        }
                    }
                }
            }
        }
    }

    foreach ( $package in $packagesToGen )
    {
        $projectFolder = $package.projectFolder
        $path = $package.path
        $service = $package.service
        # $packageName = $package.packageName
        Write-Host "projectFolder:$projectFolder"

        GeneratePackage -projectFolder $projectFolder -sdkRootPath $sdkRootPath -path $path -downloadUrlPrefix $downloadUrlPrefix -serviceType $serviceType -generatedSDKPackages $generatedSDKPackages
    }
}

function GeneratePackage()
{
    param(
        [string]$projectFolder,
        [string]$sdkRootPath,
        [string]$path,
        [string]$downloadUrlPrefix="",
        [string]$serviceType="data-plane",
        [switch]$skipGenerate,
        [object]$generatedSDKPackages,
        [string]$specRepoRoot=""
    )

    $packageName = Split-Path $projectFolder -Leaf
    $projectFolder = $projectFolder -replace "\\", "/"
    $projectFolder -match "sdk/(?<service>.*)/"
    $service = $matches["service"]
    Write-Host "Generating code for " $packageName
    $artifacts = @()
    $apiViewArtifact = ""
    $hasBreakingChange = $false
    $breakingChangeItems = @()
    $content = ""
    $result = "succeeded"
    $isGenerateSuccess = $true

    # Generate Code
    $srcPath = Join-Path $projectFolder 'src'
    if (!$skipGenerate) {
        # verify the existence of tsp-location.yaml and autorest.md
        Write-Host "Start to generate sdk $projectFolder"
        if($specRepoRoot -eq "") {
            dotnet build /t:GenerateCode $srcPath
        } else {
            dotnet build /t:GenerateCode $srcPath /p:SpecRepoRoot=$specRepoRoot
        }
        if ( !$?) {
            Write-Host "[ERROR] Failed to generate sdk for package:$packageName. Exit code: $?. Please review the detail errors for potential fixes. If the issue persists, contact the DotNet language support channel at $DotNetSupportChannelLink and include this spec pull request."
            $result = "failed"
            $isGenerateSuccess = $false
        }
    }

    if ($isGenerateSuccess) {
        # Build project when successfully generated the code
        Write-Host "Start to build sdk project: $srcPath"
        dotnet build $srcPath /p:RunApiCompat=$false
        if ( !$?) {
            Write-Host "[ERROR] Failed to build the sdk project: $packageName for service: $service. Exit code: $?. Please review the detail errors for potential fixes. If the issue persists, contact the DotNet language support channel at $DotNetSupportChannelLink and include this spec pull request."
            $result = "failed"
        } else {
            # Build the whole solution and generate artifacts if the project build successfully
            # Build the whole solution
            Write-Host "Start to build sdk solution: $projectFolder"
            $serviceProjFilePath = Join-Path $sdkRootPath 'eng' 'service.proj'
            dotnet build /p:Scope=$service /p:Project=$packageName /p:RunApiCompat=$false $serviceProjFilePath
            if ( !$? ) {
                Write-Host "[ERROR] Failed to build sdk solution:$packageName. Exit code: $?. Please review the detail errors for potential fixes. If the issue persists, contact the DotNet language support channel at $DotNetSupportChannelLink and include this spec pull request."
                $result = "failed"
            }
            # pack
            Write-Host "Start to pack sdk"
            dotnet pack $srcPath /p:RunApiCompat=$false
            if ( !$? ) {
                Write-Host "[ERROR] Failed to pack the sdk package: $packageName for service: $service. Exit code: $?. Please review the detail errors for potential fixes. If the issue persists, contact the DotNet language support channel at $DotNetSupportChannelLink and include this spec pull request."
                $result = "failed"
            } else {
                # artifacts
                Push-Location $sdkRootPath
                # check the artifact in Debug folder
                $artifactsPath = (Join-Path "artifacts" "packages" "Debug" $packageName)
                if (Test-Path $artifactsPath) {
                    $artifacts += Get-ChildItem $artifactsPath -Filter *.nupkg -exclude *.symbols.nupkg -Recurse | Select-Object -ExpandProperty FullName | Resolve-Path -Relative
                }
                if ($artifacts.count -eq 0) {
                    # check the artifact in Release folder
                    $artifactsPath = (Join-Path "artifacts" "packages" "Release" $packageName)
                    if (-not (Test-Path $artifactsPath)) {
                        Write-Host "[ERROR] Artifact folder not found for $artifactsPath. Please review the detail errors for potential fixes. If the issue persists, contact the DotNet language support channel at $DotNetSupportChannelLink and include this spec pull request."
                    }
                    else {
                        $artifacts += Get-ChildItem $artifactsPath -Filter *.nupkg -exclude *.symbols.nupkg -Recurse | Select-Object -ExpandProperty FullName | Resolve-Path -Relative
                    }
                }
                $apiViewArtifact = ""
                if ( $artifacts.count -eq 0) {
                    Write-Host "[ERROR] Failed to generate sdk artifact. Please review the detail errors for potential fixes. If the issue persists, contact the DotNet language support channel at $DotNetSupportChannelLink and include this spec pull request."
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
            }
            # Generate APIs
            Write-Host "Start to export api for $service"
            & $sdkRootPath/eng/scripts/Export-API.ps1 $service
            if ( !$? ) {
                Write-Host "[ERROR] Failed to export api for sdk. exit code: $?. Please review the detail errors for potential fixes. If the issue persists, contact the DotNet language support channel at $DotNetSupportChannelLink and include this spec pull request."
                $result = "failed"
            }
            # breaking change validation
            Write-Host "Start to validate breaking change. srcPath:$srcPath"
            $logFilePath = Join-Path "$srcPath" 'log.txt'
            if (!(Test-Path $logFilePath)) {
                New-Item $logFilePath
            }
            dotnet build "$srcPath" /t:RunApiCompat /p:TargetFramework=netstandard2.0 /flp:v=m`;LogFile=$logFilePath
            if (!$LASTEXITCODE) {
                $hasBreakingChange = $false
            }
            else {
                Write-Host "Breaking changes detected in the build log."
                $logFile = Get-Content -Path $logFilePath | select-object -SkipLast 1
                $regex = "error( ?):( ?)(?<breakingChange>.*) .*\["
                foreach ($line in $logFile) {
                    if ($line -match $regex) {
                        $breakingChangeItems += $matches["breakingChange"]
                    }
                }
                $breakingChanges = $breakingChangeItems -join ",`n"
                $content = "Breaking Changes: $breakingChanges"
                $hasBreakingChange = $true
            }

            if (Test-Path $logFilePath) {
                Remove-Item $logFilePath
            }
        }
    }

    $changelog = [PSCustomObject]@{
        content           = $content
        hasBreakingChange = $hasBreakingChange
        breakingChangeItems = $breakingChangeItems
    }

    $ciFilePath = "sdk/$service/ci.yml"
    if ( $serviceType -eq "resource-manager" ) {
        $ciFilePath = "sdk/$service/ci.mgmt.yml"
    }

    # get the sdk version
    $version = ""
    $projectFile = Join-Path $srcPath "$packageName.csproj"
    $csproj = new-object xml
    $csproj.PreserveWhitespace = $true
    $csproj.Load($projectFile)
    $versionNode = ($csproj | Select-Xml "Project/PropertyGroup/Version").Node
    if ($versionNode) {
        $version = $versionNode.InnerText
    }
    $packageDetails = @{
        version=$version;
        packageName="$packageName";
        result=$result;
        path=@("$path", "$ciFilePath");
        packageFolder="$projectFolder";
        artifacts=$artifacts;
        apiViewArtifact=$apiViewArtifact;
        language=".Net";
        changelog=$changelog;
    }

    if ($null -ne $installInstructions) {
        $packageDetails['installInstructions'] = $installInstructions
    }
    $generatedSDKPackages.Add($packageDetails)
}
function UpdateExistingSDKByInputFiles()
{
    param(
        [string[]]$inputFilePaths,
        [string]$sdkRootPath,
        [string]$headSha = "",
        [string]$repoHttpsUrl,
        [string]$downloadUrlPrefix="",
        [object]$generatedSDKPackages
    )

    $autorestFilesPath = Get-ChildItem -Path "$sdkRootPath/sdk"  -Filter autorest.md -Recurse | Resolve-Path -Relative
    Write-Host "Updating autorest.md files for all the changed swaggers."

    $sdksInfo = @{}
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
                    if (!$sdksInfo.ContainsKey($sdkpath)) {
                        $sdksInfo.Add($sdkpath, $inputFilePath)
                    }
                    break
                }
            }
        }
    }

    # generate SDK
    foreach ($sdkPath in $sdksInfo.Keys) {
        $path = , $sdkPath
        $inputFile = $sdksInfo["$sdkPath"]
        $inputFile -match "specification/(?<service>.*)/(?<serviceType>.*)"
        $serviceType = $matches["serviceType"]
        $projectFolder = Join-Path $sdkRootPath $sdkPath
        $projectFolder = Resolve-Path -Path $projectFolder
        GeneratePackage -projectFolder $projectFolder -sdkRootPath $sdkRootPath -path $path -downloadUrlPrefix "$downloadUrlPrefix" -serviceType $serviceType -generatedSDKPackages $generatedSDKPackages
    }

}

function GetSDKProjectFolder()
{
    param(
        [string]$typespecConfigurationFile,
        [string]$sdkRepoRoot
    )
    $tspConfigYaml = Get-Content -Path $typespecConfigurationFile -Raw

    Install-ModuleIfNotInstalled "powershell-yaml" "0.4.1" | Import-Module
    $yml = ConvertFrom-YAML $tspConfigYaml
    $service = ""
    $packageDir = ""
    if ($yml) {
        if ($yml["parameters"] -And $yml["parameters"]["service-dir"]) {
            $service = $yml["parameters"]["service-dir"]["default"];
        }
        if ($yml["options"] -And $yml["options"]["@azure-tools/typespec-csharp"]) {
            $csharpOpts = $yml["options"]["@azure-tools/typespec-csharp"]
            if ($csharpOpts["package-dir"]) {
                $packageDir = $csharpOpts["package-dir"]
            } elseif ($csharpOpts["namespace"]) {
                $packageDir = $csharpOpts["namespace"]
            }
            if ($csharpOpts["service-dir"]) {
                $service = $csharpOpts["service-dir"]
            }
        }
    }
    if ([string]::IsNullOrEmpty($service) -or [string]::IsNullOrEmpty($packageDir)) {
        throw "[ERROR] 'service-dir' or 'namespace'/'package-dir' not provided. Please configure these settings in the 'tspconfig.yaml' file."
    }
    $projectFolder = (Join-Path $sdkRepoRoot $service $packageDir)
    return $projectFolder
}
