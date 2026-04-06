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
    [switch] $SkipDiffValidation
)

Write-Host "Service Directory $ServiceDirectory"
Write-Host "Project Directory $ProjectDirectory"
Write-Host "SDK Type $SDKType"

$ErrorActionPreference = 'Stop'
$Env:NODE_OPTIONS = "--max-old-space-size=8192"
Set-StrictMode -Version 1

. (Join-Path $PSScriptRoot\..\common\scripts common.ps1)
. (Join-Path $PSScriptRoot CodeChecks.Helpers.ps1)

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
    # When SkipDiffValidation is set, snapshot the current git state so we can later report
    # only the files that were changed by the code checks, not pre-existing changes.
    $preExistingChanges = @()
    if ($SkipDiffValidation) {
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
        # In PR builds, check if only CI config files changed for this service directory.
        # If so, skip expensive codegen/snippet/API operations since ci*.yml changes
        # don't affect generated code. Only apply this optimization in PR builds —
        # release and CI push pipelines should always run the full checks.
        $onlyCiConfigChanged = $false
        if ($env:BUILD_REASON -eq "PullRequest") {
            $onlyCiConfigChanged = Test-OnlyCiConfigChanged -ServiceDirectory $ServiceDirectory -RepoRoot $RepoRoot
            if ($onlyCiConfigChanged) {
                Write-Host "`nOnly CI config files (ci*.yml) changed in sdk/$ServiceDirectory — skipping codegen, snippets, and API export."
            }
        }

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
                                LogError `
"Missing project. Solution '$sln' references a project which does not exist: $proj.`
    To remove the stale reference, run: dotnet sln `"$sln`" remove `"$_`"`
    Or restore the missing project file if it was deleted unintentionally."
                            }
                        }
            }

        if ($SkipDiffValidation -and -not $onlyCiConfigChanged) {
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

        if (-not $onlyCiConfigChanged) {
            $debugLogging = $env:SYSTEM_DEBUG -eq "true"
            $logsFolder = $env:BUILD_ARTIFACTSTAGINGDIRECTORY
            $diagnosticArguments = ($debugLogging -and $logsFolder) ? "/binarylogger:$logsFolder/generatecode.binlog" : ""

            Write-Host "Re-generating clients"
            Invoke-Block {
                & dotnet msbuild $PSScriptRoot\..\service.proj /restore /t:GenerateCode /p:SDKType=$SDKType /p:ServiceDirectory=$ServiceDirectory $diagnosticArguments /p:ProjectListOverrideFile=""
            }
        }
    }

    if ($ServiceDirectory -ne "tools" -and -not $onlyCiConfigChanged) {
        Write-Host "Re-generating snippets"
        Invoke-Block {
            & $PSScriptRoot\Update-Snippets.ps1 -ServiceDirectory $ServiceDirectory
        }

        Write-Host "Re-generating listings"
        Invoke-Block {
            & $PSScriptRoot\Export-API.ps1 -ServiceDirectory $ServiceDirectory -SDKType $SDKType -SpellCheckPublicApiSurface:$SpellCheckPublicApiSurface
        }
    }
    elseif ($ServiceDirectory -eq "tools") {
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
                LogError `
"README '$readmePath' uses 'Install-Package' (NuGet Package Manager Console syntax).`
    Replace with the dotnet CLI equivalent: dotnet add package <PackageName>`
    See https://github.com/Azure/azure-sdk-for-net/blob/main/CONTRIBUTING.md for conventions."
            }

            if ($readmeContent -Match "dotnet add .*--version")
            {
                LogError `
"README '$readmePath' pins a specific version with --version.`
    Remove the --version flag so users always get the latest.`
    For beta packages, use '--prerelease' instead of '--version <x.y.z-beta.n>'."
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
"README '$readmePath' is missing GA installation instructions, but the changelog has a GA release.`
    Add a line like: dotnet add package <PackageName>`
    You may also include a separate beta install line with --prerelease."
                    }
                }
                elseif ($hasRelease)
                {
                    if (-Not ($readmeContent -Match "dotnet add .*--prerelease$"))
                    {
                        LogError `
"README '$readmePath' is missing beta installation instructions, but the changelog has a beta release.`
    Add a line like: dotnet add package <PackageName> --prerelease"
                    }
                }
            }
        }

    # TestDependsOnDependency validation is no longer needed. Cross-service dependency
    # testing is handled dynamically by Get-dotnet-AdditionalValidationPackagesFromPackageSet
    # in Language-Settings.ps1, which discovers dependents for ALL changed packages at PR time.

    if (-not $ProjectDirectory)
    {
        Write-Host "git diff"
        # prevent warning related to EOL differences which triggers an exception for some reason
        & git -c core.safecrlf=false diff --ignore-space-at-eol --exit-code
        if ($LastExitCode -ne 0) {
            $diffResult = Get-DiffCheckResult `
                -HasDiff $true `
                -SkipDiffValidation $SkipDiffValidation `
                -CurrentStatusLines (git status --porcelain) `
                -PreExistingChanges $preExistingChanges `
                -ServiceDirectory $ServiceDirectory

            switch ($diffResult.Action) {
                "error" {
                    LogError $diffResult.ErrorMessage
                }
                "report" {
                    if ($diffResult.Summary.NewStatusLines) {
                        $newStatus = ($diffResult.Summary.NewStatusLines | ForEach-Object { "    $_" }) -join "`n"
                        Write-Host ""
                        Write-Host -f Green "The following files were updated by code checks and should be included in your commit:"
                        Write-Host -f Yellow $newStatus
                    }
                    if ($diffResult.Summary.PreExistingCount -gt 0) {
                        Write-Host ""
                        Write-Host -f Cyan "Note: $($diffResult.Summary.PreExistingCount) file(s) already had changes before code checks ran and were excluded from the list above."
                    }
                }
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

    if ($SkipDiffValidation -and $errors) {
        Write-Host ""
        Write-Host -f Yellow "The above $($errors.Length) issue(s) require manual attention and cannot be auto-fixed."
    }

    if ($errors) {
        exit 1
    }
}
