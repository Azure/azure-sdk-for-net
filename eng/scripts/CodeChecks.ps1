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
    [switch] $SpellCheckPublicApiSurface,

    [Parameter()]
    [switch] $PreparePr
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

# Parses a single git status --porcelain line and returns the path(s) it contains.
# For renames ("old -> new"), returns both paths. Returns an empty array for blank/malformed lines.
function Get-PorcelainPaths([string]$line) {
    if ([string]::IsNullOrWhiteSpace($line)) { return @() }
    if ($line.Length -le 3) { return @() }
    # The porcelain format is "XY path" where XY are the two status characters.
    # Skip exactly 3 characters (XY + space) to get the path portion.
    $pathPart = $line.Substring(3)
    # Handle renames of the form "oldpath -> newpath".
    if ($pathPart -match '(.+?)\s->\s(.+)$') {
        return @($matches[1], $matches[2])
    }
    return @($pathPart)
}

# Given the current git status --porcelain lines and a list of pre-existing changed paths,
# returns an object describing which status lines are new (produced by code checks) versus
# which were already present before code checks ran.
function Get-CodeCheckSummary {
    param(
        [string[]]$CurrentStatusLines,
        [string[]]$PreExistingChanges
    )

    $newStatusLines = @()
    foreach ($line in $CurrentStatusLines) {
        # Wrap in @() to prevent PowerShell from unwrapping single-element arrays
        # to strings, which would cause $paths[-1] to return a character instead of a path.
        $paths = @(Get-PorcelainPaths $line)
        if (-not $paths) { continue }
        # For renames, check the destination (last) path against pre-existing changes.
        $checkPath = $paths[-1]
        if ($checkPath -notin $PreExistingChanges) {
            $newStatusLines += $line
        }
    }

    return @{
        NewStatusLines   = $newStatusLines
        PreExistingCount = ($PreExistingChanges | Measure-Object).Count
    }
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
    # In PreparePr mode, snapshot the current git state so we can later report
    # only the files that were changed by the code checks, not pre-existing changes.
    $preExistingChanges = @()
    if ($PreparePr) {
        $statusLines = git status --porcelain
        foreach ($line in $statusLines) {
            $preExistingChanges += Get-PorcelainPaths $line
        }
        $preExistingChanges = $preExistingChanges | Sort-Object -Unique
    }

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

        if ($PreparePr) {
            Write-Host "`nRunning dotnet format"
            Join-Path "$PSScriptRoot/../../sdk" $ServiceDirectory `
                | Resolve-Path `
                | % { Get-ChildItem $_ -Filter "*.csproj" -Recurse } `
                | % {
                    Write-Host "Formatting $(Split-Path -Leaf $_)"
                    Invoke-Block {
                        & dotnet format $_ --verbosity quiet
                    }
                }
        }

        $debugLogging = $env:SYSTEM_DEBUG -eq "true"
        $logsFolder = $env:BUILD_ARTIFACTSTAGINGDIRECTORY
        $diagnosticArguments = ($debugLogging -and $logsFolder) ? "/binarylogger:$logsFolder/generatecode.binlog" : ""

        Write-Host "Re-generating clients"
        Invoke-Block {
            & dotnet msbuild $PSScriptRoot\..\service.proj /restore /t:GenerateCode /p:SDKType=$SDKType /p:ServiceDirectory=$ServiceDirectory $diagnosticArguments /p:ProjectListOverrideFile=""
        }
    }

    if ($ServiceDirectory -ne "tools") {
        Write-Host "Re-generating snippets"
        Invoke-Block {
            & $PSScriptRoot\Update-Snippets.ps1 -ServiceDirectory $ServiceDirectory
        }

        Write-Host "Re-generating listings"
        Invoke-Block {
            & $PSScriptRoot\Export-API.ps1 -ServiceDirectory $ServiceDirectory -SDKType $SDKType -SpellCheckPublicApiSurface:$SpellCheckPublicApiSurface
        }
    }
    else {
        Write-Host "Skipping snippet and API listing generation for tools directory"
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
            if ($PreparePr) {
                $summary = Get-CodeCheckSummary -CurrentStatusLines (git status --porcelain) -PreExistingChanges $preExistingChanges
                if ($summary.NewStatusLines) {
                    $newStatus = ($summary.NewStatusLines | ForEach-Object { "    $_" }) -join "`n"
                    Write-Host ""
                    Write-Host -f Green "The following files were updated by code checks and should be included in your commit:"
                    Write-Host -f Yellow $newStatus
                }
                if ($summary.PreExistingCount -gt 0) {
                    Write-Host ""
                    Write-Host -f Cyan "Note: $($summary.PreExistingCount) file(s) already had changes before code checks ran and were excluded from the list above."
                }
            }
            else {
                LogError `
"Generated code is not up to date.`
    You may need to rebase on the latest main, `
    run 'eng\scripts\Update-Snippets.ps1 $ServiceDirectory' if you modified sample snippets or other *.md files (https://github.com/Azure/azure-sdk-for-net/blob/main/CONTRIBUTING.md#updating-sample-snippets), `
    run 'eng\scripts\Export-API.ps1 $ServiceDirectory' if you changed public APIs (https://github.com/Azure/azure-sdk-for-net/blob/main/CONTRIBUTING.md#public-api-additions). `
    run 'dotnet build /t:GenerateCode' to update the generated code and samples.`
    `
To fix this locally, run 'eng\scripts\CodeChecks.ps1 -ServiceDirectory $ServiceDirectory -PreparePr' and commit the resulting changes."
            }
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
