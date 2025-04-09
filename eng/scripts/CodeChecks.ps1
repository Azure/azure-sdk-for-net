#requires -version 5

[CmdletBinding()]
param (
    [Parameter(Position=0)]
    [string] $ServiceDirectory,

    [Parameter()]
    [string] $ProjectDirectory,

    [Parameter()]
    [string] $SDKType = "all",

    [Parameter()]
    [switch] $SpellCheckPublicApiSurface
)

Write-Host "Service Directory $ServiceDirectory"
Write-Host "Project Directory $ProjectDirectory"
Write-Host "SDK Type $SDKType"

$ErrorActionPreference = 'Stop'
$Env:NODE_OPTIONS = "--max-old-space-size=8192"
Set-StrictMode -Version 1

. (Join-Path $PSScriptRoot\..\common\scripts common.ps1)

[string[]] $errors = @()

# All errors should be logged using this function, as it tracks the errors in
# the $errors array, which is used in the finally block of the script to determine
# the return code.
function LogError([string]$message) {
    if ($env:TF_BUILD) {
        Write-Host ("##vso[task.logissue type=error]$message" -replace "`n","%0D%0A")
    }
    Write-Host -f Red "error: $message"
    $script:errors += $message
}

function Invoke-Block([scriptblock]$cmd) {
    $cmd | Out-String | Write-Verbose
    & $cmd

    # Need to check both of these cases for errors as they represent different items
    # - $?: did the powershell script block throw an error
    # - $lastexitcode: did a windows command executed by the script block end in error
    if ((-not $?) -or ($lastexitcode -ne 0)) {
        if ($error -ne $null)
        {
            LogError $error[0]
        }
        throw "Command failed to execute: $cmd"
    }
}

try {
    Write-Host "Restore ./node_modules"
    Invoke-Block {
        & npm ci --prefix $RepoRoot
    }

    if ($ProjectDirectory -and -not $ServiceDirectory)
    {
        if ($ProjectDirectory -match "sdk[\\/](?<projectdir>.*)[\\/]src")
        {
            $ServiceDirectory = $Matches['projectdir']
        }
    }
    if (-not $ProjectDirectory)
    {
        Write-Host "Force .NET Welcome experience"
        Invoke-Block {
            & dotnet msbuild -version
        }

        Write-Host "`nChecking that solutions are up to date"
        Join-Path "$PSScriptRoot/../../sdk" $ServiceDirectory  `
            | Resolve-Path `
            | % { Get-ChildItem $_ -Filter "Azure.*.sln" -Recurse } `
            | % {
                Write-Host "Checking $(Split-Path -Leaf $_)"
                $slnDir = Split-Path -Parent $_
                $sln = $_
                & dotnet sln $_ list `
                    | ? { $_ -ne 'Project(s)' -and $_ -ne '----------' } `
                    | % {
                            $proj = Join-Path $slnDir $_
                            if (-not (Test-Path $proj)) {
                                LogError "Missing project. Solution references a project which does not exist: $proj. [$sln] "
                            }
                        }
            }

        $debugLogging = $env:SYSTEM_DEBUG -eq "true"
        $logsFolder = $env:BUILD_ARTIFACTSTAGINGDIRECTORY
        $diagnosticArguments = ($debugLogging -and $logsFolder) ? "/binarylogger:$logsFolder/generatecode.binlog" : ""

        Write-Host "Re-generating clients"
        Invoke-Block {
            & dotnet msbuild $PSScriptRoot\..\service.proj /restore /t:GenerateCode /p:SDKType=$SDKType /p:ServiceDirectory=$ServiceDirectory $diagnosticArguments
        }
    }

    Write-Host "Re-generating snippets"
    Invoke-Block {
        & $PSScriptRoot\Update-Snippets.ps1 -ServiceDirectory $ServiceDirectory
    }

    Write-Host "Re-generating listings"
    Invoke-Block {
        & $PSScriptRoot\Export-API.ps1 -ServiceDirectory $ServiceDirectory -SDKType $SDKType -SpellCheckPublicApiSurface:$SpellCheckPublicApiSurface
    }

    Write-Host "Validating installation instructions"
    Join-Path "$PSScriptRoot/../../sdk" $ServiceDirectory  `
        | Resolve-Path `
        | % { Get-ChildItem $_ -Filter "README.md" -Recurse } `
        | % {
            $readmePath = $_
            $readmeContent = Get-Content $readmePath

            if ($readmeContent -Match "Install-Package")
            {
                LogError "README files should use dotnet CLI for installation instructions. '$readmePath'"
            }

            if ($readmeContent -Match "dotnet add .*--version")
            {
                LogError "Specific versions should not be specified in the installation instructions in '$readmePath'. For beta versions, include the --prerelease flag."
            }

            if ($readmeContent -Match "dotnet add")
            {
                $changelogPath = Join-Path $(Split-Path -Parent $readmePath) "CHANGELOG.md"
                $hasGa = $false
                $hasRelease = $false
                if (Test-Path $changelogPath)
                {
                    $changeLogEntries = Get-ChangeLogEntries -ChangeLogLocation $changelogPath
                    foreach ($key in $changeLogEntries.Keys)
                    {
                        $entry = $changeLogEntries[$key]
                        if ($entry.ReleaseStatus -ne "(Unreleased)")
                        {
                            $hasRelease = $true
                            if ($entry.ReleaseVersion -notmatch "beta" -and $entry.ReleaseVersion -notmatch "preview")
                            {
                                $hasGa = $true
                                break
                            }
                        }
                    }
                }
                if ($hasGa)
                {
                    if (-Not ($readmeContent -Match "dotnet add (?!.*--prerelease)"))
                    {
                        LogError `
"No GA installation instructions found in '$readmePath' but there was a GA entry in the Changelog '$changelogPath'. `
    Ensure that there are installation instructions that do not contain the --prerelease flag. You may also include `
    instructions for installing a beta that does include the --prerelease flag."
                    }
                }
                elseif ($hasRelease)
                {
                    if (-Not ($readmeContent -Match "dotnet add .*--prerelease$"))
                    {
                        LogError `
"No beta installation instructions found in '$readmePath' but there was a beta entry in the Changelog '$changelogPath'. `
    Ensure that there are installation instructions that contain the --prerelease flag."
                    }
                }
            }
        }

    if (-not $ProjectDirectory)
    {
        Write-Host "git diff"
        # prevent warning related to EOL differences which triggers an exception for some reason
        & git -c core.safecrlf=false diff --ignore-space-at-eol --exit-code
        if ($LastExitCode -ne 0) {
            $status = git status -s | Out-String
            $status = $status -replace "`n","`n    "
            LogError `
"Generated code is not up to date.`
    You may need to rebase on the latest main, `
    run 'eng\scripts\Update-Snippets.ps1 $ServiceDirectory' if you modified sample snippets or other *.md files (https://github.com/Azure/azure-sdk-for-net/blob/main/CONTRIBUTING.md#updating-sample-snippets), `
    run 'eng\scripts\Export-API.ps1 $ServiceDirectory' if you changed public APIs (https://github.com/Azure/azure-sdk-for-net/blob/main/CONTRIBUTING.md#public-api-additions). `
    run 'dotnet build /t:GenerateCode' to update the generated code and samples.`
    `
To reproduce this error locally, run 'eng\scripts\CodeChecks.ps1 -ServiceDirectory $ServiceDirectory'."
        }
    }
}
finally {
    Write-Host ""
    Write-Host "Summary:"
    Write-Host ""
    Write-Host "   $($errors.Length) error(s)"
    Write-Host ""

    foreach ($err in $errors) {
        Write-Host -f Red "error : $err"
    }

    if ($errors) {
        exit 1
    }
}
