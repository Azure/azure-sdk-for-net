#requires -version 5

[CmdletBinding()]
param (
    [Parameter(Position=0)]
    [string] $ServiceDirectory,

    [Parameter()]
    [string] $ProjectDirectory,

    [Parameter()]
    [string] $SDKType = "client"
)

$ErrorActionPreference = 'Stop'
Set-StrictMode -Version 1

[string[]] $errors = @()

function LogError([string]$message) {
    if ($env:TF_BUILD) {
        Write-Host "##vso[task.logissue type=error]$message"
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
            Write-Warning $error[0]
        }
        throw "Command failed to execute: $cmd"
    }
}

try {
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

        Write-Host "Re-generating clients"
        Invoke-Block {
            & dotnet msbuild $PSScriptRoot\..\service.proj /restore /t:GenerateCode /p:SDKType=$SDKType /p:ServiceDirectory=$ServiceDirectory

            # https://github.com/Azure/azure-sdk-for-net/issues/8584
            # & $repoRoot\storage\generate.ps1
        }
    }

    Write-Host "Re-generating snippets"
    Invoke-Block {
        & $PSScriptRoot\Update-Snippets.ps1 -ServiceDirectory $ServiceDirectory
    }

    Write-Host "Re-generating listings"
    Invoke-Block {
        & $PSScriptRoot\Export-API.ps1 -ServiceDirectory $ServiceDirectory -SDKType $SDKType
    }

    if (-not $ProjectDirectory)
    {
        Write-Host "git diff"
        # prevent warning related to EOL differences which triggers an exception for some reason
        & git -c core.safecrlf=false diff --ignore-space-at-eol --exit-code
        if ($LastExitCode -ne 0) {
            $status = git status -s | Out-String
            $status = $status -replace "`n","`n    "
            LogError "Generated code is not up to date. You may need to run eng\scripts\Update-Snippets.ps1 or sdk\storage\generate.ps1 or eng\scripts\Export-API.ps1"
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
