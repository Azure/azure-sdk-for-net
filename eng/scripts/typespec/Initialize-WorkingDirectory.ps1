#Requires -Version 7.0

[CmdletBinding()]
param(
    [Parameter(Mandatory = $true, ParameterSetName = 'Produce')]
    [string] $OutputDirectory,
    [Parameter(Mandatory = $true, ParameterSetName = 'Consume')]
    [string] $BuildArtifactsPath,
    [string] $PrereleaseSuffix,
    [switch] $UseTypeSpecNext,
    [string] $EmitterPackagePath
)

$ErrorActionPreference = 'Stop'
Set-StrictMode -Version 3.0

. "$PSScriptRoot/../../common/scripts/common.ps1"
Set-ConsoleEncoding

if ($UseTypeSpecNext) {
    Write-Host "##vso[build.addbuildtag]typespec_next"
}

function Initialize-Package($emitterPackagePath) {
    # strip leading slash from emitterPackagePath if it exists
    if ($emitterPackagePath.StartsWith("/")) {
        $emitterPackagePath = $emitterPackagePath.Substring(1)
    }

    $packageRoot = Join-Path $RepoRoot $emitterPackagePath
    Push-Location $packageRoot
    try {
        if (Test-Path "./node_modules") {
            Remove-Item -Recurse -Force "./node_modules"
        }

        # install and list npm packages
        if ($BuildArtifactsPath) {
            # if we were passed a build_artifacts path, use the package.json and package-lock.json from there

            $BuildArtifactsPath = Resolve-Path $BuildArtifactsPath
            Write-Host "Using package.json and package-lock.json from $BuildArtifactsPath"
            Copy-Item "$BuildArtifactsPath/package.json" './package.json' -Force
            Copy-Item "$BuildArtifactsPath/package-lock.json" './package-lock.json' -Force

            Invoke-LoggedCommand "npm ci"
        }
        else {
            # if we were not passed a build_artifacts path, update package.json and package-lock.json if necessary and make
            # them available to other build jobs by copying them to the artifacts directory
            $emitterVersion = (npm pkg get version).Trim('"')

            if ($PrereleaseSuffix) {
                # set package versions
                $emitterVersion = "$($emitterVersion.Split('-')[0])$PrereleaseSuffix"
                Write-Host "Updating version package.json to the new emitter version`n"
                Invoke-LoggedCommand "npm pkg set version=$emitterVersion"

                Write-Host "Setting output variable 'emitterVersion' to $emitterVersion"
                Write-Host "##vso[task.setvariable variable=emitterVersion;isOutput=true]$emitterVersion"
            }

            # Update management package dependency if this is the http-client-csharp emitter
            if ($emitterPackagePath -eq "eng/azure-typespec-http-client-csharp") {
                Write-Host "Updating http-client-csharp-mgmt package dependency to version $emitterVersion"

                $mgmtPackagePath = Join-Path $RepoRoot "eng/packages/http-client-csharp-mgmt"
                Push-Location $mgmtPackagePath
                try {
                    # Update the dependency version
                    Invoke-LoggedCommand "npm pkg set dependencies[@azure-typespec/http-client-csharp]=$emitterVersion"

                    # Run npm install to update package-lock.json
                    Write-Host "Running npm install in management package directory"
                    Invoke-LoggedCommand "npm install"
                }
                finally {
                    Pop-Location
                }

                # Update AzureGeneratorVersion in Package.Data.props
                $propsFileContent = Get-Content $propsFilePath -Raw

                # Update the UnbrandedGeneratorVersion property in the file
                $pattern = '<AzureGeneratorVersion>[^<]*</AzureGeneratorVersion>'
                $replacement = '<AzureGeneratorVersion>' + $PackageVersion + '</AzureGeneratorVersion>'

                $updatedContent = $propsFileContent -replace $pattern, $replacement
                if ($updatedContent -eq $propsFileContent) {
                    Write-Warning "No changes were made to eng/Packages.Data.props. The AzureGeneratorVersion property might not exist or have a different format."
                    Write-Host "Current content around AzureGeneratorVersion:"
                    $propsFileContent | Select-String -Pattern "AzureGeneratorVersion" -Context 2, 2
                } else {
                    $propsFileUpdated = $true
                    # Write the updated file back
                    Set-Content -Path $propsFilePath -Value $updatedContent -NoNewline
                }
            }

            if ($UseTypeSpecNext) {
                if (Test-Path "./package-lock.json") {
                    Remove-Item -Force "./package-lock.json"
                }

                Write-Host "Using TypeSpec.Next"
                Invoke-LoggedCommand "npx -y @azure-tools/typespec-bump-deps@latest --add-npm-overrides package.json"
                Invoke-LoggedCommand "npm install"
            }
            else {
                Invoke-LoggedCommand "npm ci"
            }
        

            $lockFilesPath = Join-Path $OutputDirectory "lock-files"

            New-Item -ItemType Directory -Force -Path $lockFilesPath | Out-Null

            Write-Host "Copying package.json and package-lock.json to $lockFilesPath"

            Copy-Item "./package.json" -Destination (Join-Path $lockFilesPath "package.json") -Force
            Copy-Item "./package-lock.json" -Destination (Join-Path $lockFilesPath "package-lock.json") -Force

            Invoke-LoggedCommand "npm list --all" -GroupOutput
        }
    }
    finally {
        Pop-Location
    }
}

Initialize-Package $EmitterPackagePath
