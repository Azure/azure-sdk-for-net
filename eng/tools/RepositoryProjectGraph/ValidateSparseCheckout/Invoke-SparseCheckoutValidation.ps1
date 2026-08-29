#Requires -Version 7.0

<#
.SYNOPSIS
Runs singleton artifact/matrix cases in a detached Git sparse checkout.

.DESCRIPTION
VALIDATION ONLY. The checkout is dedicated to this harness and is reset/cleaned between cases.
Every resolver fallback or setup/test failure is recorded as a failed case. Use FailureMode=Stop for
interactive diagnosis and FailureMode=Continue for unattended Windows or complete inventory runs.
#>
[CmdletBinding()]
param(
    [Parameter(Mandatory = $true)][string] $RepoRoot,
    [Parameter(Mandatory = $true)][string] $InputRoot,
    [Parameter(Mandatory = $true)][string] $ResultsRoot,
    [ValidateSet('Linux', 'Windows', 'macOS')][string] $TargetHost,
    [string] $WorktreeRoot,
    [string] $NuGetPackages,
    [string] $CacheRoot,
    [ValidateSet('x64', 'arm64')][string] $TestTargetArchitecture,
    [string] $ArtifactFilter = '.*',
    [string] $MatrixFilter = '.*',
    [int] $MaxCases = 0,
    [ValidateSet('Stop', 'Continue')][string] $FailureMode = 'Continue',
    [switch] $Resume,
    [switch] $ListOnly,
    [switch] $SkipRecordings,
    [switch] $SkipAzurite,
    [switch] $PreserveCurrentEnvironment,
    [ValidateRange(1, 360)][int] $TestTimeoutInMinutes = 60
)

Set-StrictMode -Version 3.0
$ErrorActionPreference = 'Stop'
. (Join-Path $PSScriptRoot 'Validation.Common.ps1')

function Invoke-CheckedGit([string[]] $ArgumentList, [string] $WorkingRepository) {
    $output = @(& git -C $WorkingRepository @ArgumentList 2>&1)
    $exitCode = $LASTEXITCODE
    $output | ForEach-Object { Write-Host $_ }
    if ($exitCode -ne 0) {
        throw "git $($ArgumentList -join ' ') failed with exit code $exitCode under '$WorkingRepository'."
    }
}

function Invoke-LoggedCommand {
    param(
        [Parameter(Mandatory = $true)][string] $FilePath,
        [Parameter(Mandatory = $true)][string[]] $ArgumentList,
        [Parameter(Mandatory = $true)][string] $WorkingDirectory,
        [Parameter(Mandatory = $true)][string] $LogPath,
        [int] $TimeoutInMinutes = 0
    )

    $parent = Split-Path -Parent $LogPath
    New-Item -ItemType Directory -Path $parent -Force | Out-Null
    [System.IO.File]::WriteAllText($LogPath, "> $FilePath $($ArgumentList -join ' ')`n")
    Write-Host "> $FilePath $($ArgumentList -join ' ')"

    if ($TimeoutInMinutes -gt 0) {
        # Run the complete process tree behind a real wall-clock timeout. VSTest's blame-hang
        # timeout only covers an unresponsive test, not a hung restore, build, or custom target.
        $startInfo = [System.Diagnostics.ProcessStartInfo]::new()
        $startInfo.FileName = $FilePath
        $startInfo.WorkingDirectory = $WorkingDirectory
        $startInfo.UseShellExecute = $false
        $startInfo.RedirectStandardOutput = $true
        $startInfo.RedirectStandardError = $true
        foreach ($argument in $ArgumentList) {
            $startInfo.ArgumentList.Add($argument)
        }

        $process = [System.Diagnostics.Process]::new()
        $process.StartInfo = $startInfo
        $startedAt = [DateTime]::UtcNow
        try {
            if (!$process.Start()) {
                throw "Unable to start '$FilePath'."
            }
            # Drain both streams concurrently to prevent a full pipe from blocking the child.
            $standardOutput = $process.StandardOutput.ReadToEndAsync()
            $standardError = $process.StandardError.ReadToEndAsync()
            $nextHeartbeat = $startedAt.AddMinutes(1)
            $timedOut = $false
            while (!$process.WaitForExit(1000)) {
                $now = [DateTime]::UtcNow
                if ($now -ge $startedAt.AddMinutes($TimeoutInMinutes)) {
                    $timedOut = $true
                    $process.Kill($true)
                    break
                }
                if ($now -ge $nextHeartbeat) {
                    Write-Host "$FilePath is still running ($([math]::Round(($now - $startedAt).TotalMinutes, 1)) minutes elapsed)."
                    $nextHeartbeat = $now.AddMinutes(1)
                }
            }
            $process.WaitForExit()
            $output = @($standardOutput.Result, $standardError.Result) -join ''
            if ($output) {
                [System.IO.File]::AppendAllText($LogPath, $output)
                $output -split "`r?`n" | Where-Object { $_ } | ForEach-Object { Write-Host $_ }
            }
            if ($timedOut) {
                $message = "Command exceeded its $TimeoutInMinutes-minute singleton timeout; the process tree was terminated."
                [System.IO.File]::AppendAllText($LogPath, "`n$message`n")
                Write-Warning $message
                return 124
            }
            return $process.ExitCode
        }
        finally {
            $process.Dispose()
        }
    }

    Push-Location $WorkingDirectory
    try {
        & $FilePath @ArgumentList 2>&1 | ForEach-Object {
            $line = [string]$_
            [System.IO.File]::AppendAllText($LogPath, "$line`n")
            Write-Host $line
        }
        return $LASTEXITCODE
    }
    finally {
        Pop-Location
    }
}

function Get-SafeCaseName([string] $Artifact, [string] $Matrix, [string] $ValidationKey) {
    $prefix = "$Artifact--$Matrix" -replace '[^A-Za-z0-9._-]', '_'
    if ($prefix.Length -gt 100) { $prefix = $prefix.Substring(0, 100) }
    $bytes = [System.Text.Encoding]::UTF8.GetBytes($ValidationKey)
    $hash = [Convert]::ToHexString([System.Security.Cryptography.SHA256]::HashData($bytes)).ToLowerInvariant()
    return "$prefix--$($hash.Substring(0, 12))"
}

function Split-AdditionalArguments([string] $Arguments) {
    if ([string]::IsNullOrWhiteSpace($Arguments)) { return @() }
    if ($Arguments -match '\$\(') {
        throw "Matrix argument '$Arguments' contains an unresolved pipeline variable."
    }
    return @([regex]::Matches($Arguments, '(?:[^\s"'']+|"[^"]*"|''[^'']*'')+') | ForEach-Object {
        $_.Value.Trim('"', "'")
    })
}

function Resolve-ManifestPath([string] $Root, [string] $Path) {
    if ([System.IO.Path]::IsPathRooted($Path)) { return [System.IO.Path]::GetFullPath($Path) }
    return [System.IO.Path]::GetFullPath((Join-Path $Root $Path))
}

function Test-IsPathWithin([string] $Root, [string] $Candidate) {
    $relative = [System.IO.Path]::GetRelativePath($Root, $Candidate)
    return !$relative.Equals('..', [StringComparison]::OrdinalIgnoreCase) -and
        !$relative.StartsWith("..$([System.IO.Path]::DirectorySeparatorChar)", [StringComparison]::OrdinalIgnoreCase) -and
        ![System.IO.Path]::IsPathRooted($relative)
}

function Set-MatrixEnvironment($Parameters, [System.Collections.Generic.HashSet[string]] $PreviousNames) {
    # Azure Pipelines exposes matrix values as normalized process environment variables. Clear the
    # previous case first so custom flags from one matrix entry cannot leak into the next entry.
    foreach ($name in $PreviousNames) {
        [Environment]::SetEnvironmentVariable($name, $null, 'Process')
    }
    $PreviousNames.Clear()
    if ($null -eq $Parameters) { return }

    foreach ($property in $Parameters.PSObject.Properties) {
        $value = [string]$property.Value
        if (!$value -or $value.StartsWith('env:', [StringComparison]::OrdinalIgnoreCase)) {
            continue
        }
        $name = ($property.Name -replace '[^A-Za-z0-9_]', '_').ToUpperInvariant()
        [Environment]::SetEnvironmentVariable($name, $value, 'Process')
        $null = $PreviousNames.Add($name)
    }
}

function Copy-CaseEvidence([string] $Worktree, [string] $CaseDirectory, [bool] $CollectCoverage, [bool] $CollectDumps) {
    $patterns = [System.Collections.Generic.List[object]]::new()
    if ($CollectCoverage) {
        $patterns.Add([pscustomobject]@{
            Root = Join-Path $Worktree 'sdk'
            Filter = 'coverage.cobertura.xml'
            Destination = 'coverage'
        })
    }
    if ($CollectDumps) {
        $patterns.Add([pscustomobject]@{
            Root = $Worktree
            Filter = '*.dmp'
            Destination = 'dumps'
        })
    }

    foreach ($pattern in $patterns) {
        if (!(Test-Path -LiteralPath $pattern.Root)) { continue }
        foreach ($file in Get-ChildItem -LiteralPath $pattern.Root -Filter $pattern.Filter -File -Recurse -ErrorAction SilentlyContinue) {
            # Preserve relative paths so same-named outputs from multiple projects do not collide.
            $relative = [System.IO.Path]::GetRelativePath($Worktree, $file.FullName)
            $destination = Join-Path (Join-Path $CaseDirectory $pattern.Destination) $relative
            New-Item -ItemType Directory -Path (Split-Path -Parent $destination) -Force | Out-Null
            Copy-Item -LiteralPath $file.FullName -Destination $destination -Force
        }
    }
}

function Write-RunSummary([object[]] $Results, $Manifest, [string] $Destination, [string] $HostName) {
    $passed = @($Results | Where-Object status -eq 'passed').Count
    $failed = @($Results | Where-Object status -eq 'failed').Count
    $skipped = @($Results | Where-Object status -eq 'resumed').Count
    $summary = [pscustomobject][ordered]@{
        schemaVersion = 1
        sourceCommit = $Manifest.sourceCommit
        checkoutGraphSha256 = $Manifest.checkoutGraphSha256
        harnessVersion = $Manifest.harnessVersion
        host = $HostName
        completedAtUtc = [DateTime]::UtcNow.ToString('o')
        cases = $Results.Count
        passed = $passed
        failed = $failed
        resumed = $skipped
        result = $failed -eq 0 ? 'passed' : 'failed'
    }
    $summary | ConvertTo-Json -Depth 20 | Set-Content -LiteralPath (Join-Path $Destination 'summary.json') -Encoding utf8

    $markdown = @(
        '# Sparse-checkout validation summary'
        ''
        "- Source commit: ``$($summary.sourceCommit)``"
        "- Checkout graph SHA-256: ``$($summary.checkoutGraphSha256)``"
        "- Harness version: ``$($summary.harnessVersion)``"
        "- Host: $HostName"
        "- Result: **$($summary.result)**"
        "- Cases: $($summary.cases); passed: $passed; failed: $failed; resumed: $skipped"
        ''
        '| Artifact | Matrix | Status | Phase | Evidence |'
        '|---|---|---|---|---|'
    )
    foreach ($result in $Results) {
        $markdown += "| $($result.artifactName) | $($result.matrixName) | $($result.status) | $($result.phase) | ``$($result.evidenceDirectory)`` |"
    }
    $markdown | Set-Content -LiteralPath (Join-Path $Destination 'summary.md') -Encoding utf8
    $Results | ForEach-Object { $_ | ConvertTo-Json -Depth 20 -Compress } |
        Set-Content -LiteralPath (Join-Path $Destination 'results.jsonl') -Encoding utf8
    return $summary
}

$RepoRoot = [System.IO.Path]::GetFullPath($RepoRoot)
$InputRoot = [System.IO.Path]::GetFullPath($InputRoot)
$ResultsRoot = [System.IO.Path]::GetFullPath($ResultsRoot)
if (!$TargetHost) {
    $TargetHost = $IsWindows ? 'Windows' : ($IsMacOS ? 'macOS' : 'Linux')
}
if (!$ListOnly -and (($TargetHost -eq 'Linux' -and !$IsLinux) -or
    ($TargetHost -eq 'Windows' -and !$IsWindows) -or
    ($TargetHost -eq 'macOS' -and !$IsMacOS))) {
    throw "TargetHost '$TargetHost' does not match the current operating system."
}
if (!$WorktreeRoot) {
    $WorktreeRoot = Join-Path ([System.IO.Path]::GetTempPath()) "azsdk-sparse-validation-$($TargetHost.ToLowerInvariant())"
}
$WorktreeRoot = [System.IO.Path]::GetFullPath($WorktreeRoot)
if (!$NuGetPackages) {
    $NuGetPackages = Join-Path (Split-Path -Parent $WorktreeRoot) 'azsdk-sparse-nuget'
}
$NuGetPackages = [System.IO.Path]::GetFullPath($NuGetPackages)
if (!$CacheRoot) {
    $CacheRoot = Join-Path (Split-Path -Parent $WorktreeRoot) 'azsdk-sparse-cache'
}
$CacheRoot = [System.IO.Path]::GetFullPath($CacheRoot)
if (Test-IsPathWithin $RepoRoot $WorktreeRoot) {
    throw 'WorktreeRoot must be a dedicated path outside RepoRoot.'
}
foreach ($path in @($InputRoot, $ResultsRoot, $NuGetPackages, $CacheRoot)) {
    if (Test-IsPathWithin $WorktreeRoot $path) {
        throw "Validation path '$path' cannot be inside the worktree because each case cleans it."
    }
}

$manifestPath = Join-Path $InputRoot 'manifest.json'
if (!(Test-Path -LiteralPath $manifestPath)) { throw "Input manifest does not exist: $manifestPath" }
$manifest = Get-Content -Raw -LiteralPath $manifestPath | ConvertFrom-Json -Depth 100
if ($manifest.schemaVersion -ne 1) { throw "Unsupported validation manifest schema '$($manifest.schemaVersion)'." }
$harnessVersion = Get-SparseCheckoutValidationHarnessVersion $PSScriptRoot
if ($manifest.harnessVersion -ne $harnessVersion) {
    throw "Input harness '$($manifest.harnessVersion)' does not match the executing harness '$harnessVersion'."
}
$packageInfoDirectory = Resolve-ManifestPath $InputRoot $manifest.packageInfoDirectory
$checkoutGraphPath = Resolve-ManifestPath $InputRoot $manifest.checkoutGraphPath
$casesPath = Resolve-ManifestPath $InputRoot $manifest.casesPath
foreach ($path in @($packageInfoDirectory, $checkoutGraphPath, $casesPath)) {
    if (!(Test-Path -LiteralPath $path)) { throw "Manifest input does not exist: $path" }
}
$packageInfoFileByArtifact = @{}
foreach ($file in Get-ChildItem -LiteralPath $packageInfoDirectory -Filter '*.json' -File -Recurse) {
    $package = Get-Content -Raw -LiteralPath $file.FullName | ConvertFrom-Json -Depth 100
    $artifactName = [string]$package.ArtifactName
    if (!$artifactName) { throw "PackageInfo '$($file.FullName)' has no ArtifactName." }
    if ($packageInfoFileByArtifact.ContainsKey($artifactName)) {
        throw "PackageInfo contains duplicate artifact '$artifactName'."
    }
    $packageInfoFileByArtifact[$artifactName] = $file.FullName
}
$actualGraphHash = (Get-FileHash -Algorithm SHA256 -LiteralPath $checkoutGraphPath).Hash.ToLowerInvariant()
if ($actualGraphHash -ne $manifest.checkoutGraphSha256) {
    throw 'checkout-graph.json does not match the manifest SHA-256.'
}
if ((Get-FileHash -Algorithm SHA256 -LiteralPath $casesPath).Hash.ToLowerInvariant() -ne $manifest.casesSha256) {
    throw 'cases.json does not match the manifest SHA-256.'
}
if ((Get-SparseCheckoutValidationDirectoryHash $packageInfoDirectory) -ne $manifest.packageInfoSha256) {
    throw 'PackageInfo does not match the manifest SHA-256.'
}
$repoCommit = (& git -C $RepoRoot rev-parse HEAD).Trim()
if ($LASTEXITCODE -ne 0 -or $repoCommit -ne $manifest.sourceCommit) {
    throw "Repository HEAD '$repoCommit' does not match manifest commit '$($manifest.sourceCommit)'."
}

$cases = @(
    Get-Content -Raw -LiteralPath $casesPath | ConvertFrom-Json -Depth 100 |
        Where-Object {
            $_.host -eq $TargetHost -and $_.artifactName -match $ArtifactFilter -and $_.matrixName -match $MatrixFilter
        }
)
if ($MaxCases -gt 0) { $cases = @($cases | Select-Object -First $MaxCases) }
if ($cases.Count -eq 0) { throw 'No validation cases matched the requested host and filters.' }

Write-Host "Selected $($cases.Count) $TargetHost cases from $($manifest.caseCount) manifest cases."
if ($ListOnly) {
    $cases | Select-Object artifactName, matrixName, targetFramework, buildConfiguration, additionalTestArguments |
        Format-Table -AutoSize
    return
}

New-Item -ItemType Directory -Path $ResultsRoot, $NuGetPackages, $CacheRoot -Force | Out-Null
$checkoutMarkerPath = "$WorktreeRoot.validation-checkout.json"
$existingCheckout = Test-Path -LiteralPath $WorktreeRoot
if ($existingCheckout) {
    if (!(Test-Path -LiteralPath $checkoutMarkerPath)) {
        throw "Refusing to clean unmarked checkout '$WorktreeRoot'. Expected harness marker '$checkoutMarkerPath'."
    }
    $checkoutMarker = Get-Content -Raw -LiteralPath $checkoutMarkerPath | ConvertFrom-Json
    if ($checkoutMarker.schemaVersion -ne 1 -or $checkoutMarker.repoRoot -ne $RepoRoot -or
        $checkoutMarker.repositoryKind -ne 'shared-clone') {
        throw "Checkout marker '$checkoutMarkerPath' does not belong to repository '$RepoRoot'."
    }
    & git -C $WorktreeRoot rev-parse --is-inside-work-tree *> $null
    if ($LASTEXITCODE -ne 0 -or !(Test-Path -LiteralPath (Join-Path $WorktreeRoot '.git') -PathType Container)) {
        throw "Checkout path is not the harness's Git clone: $WorktreeRoot"
    }
}
else {
    $parent = Split-Path -Parent $WorktreeRoot
    New-Item -ItemType Directory -Path $parent -Force | Out-Null
    # A local shared clone avoids copying objects while providing normal .git directory semantics.
    # Some repository tests intentionally discover their root from that directory.
    Invoke-CheckedGit @('clone', '--shared', '--no-checkout', '--no-tags', $RepoRoot, $WorktreeRoot) $RepoRoot
    Invoke-CheckedGit @('sparse-checkout', 'init', '--no-cone') $WorktreeRoot
    Invoke-CheckedGit @('checkout', '--detach', $manifest.sourceCommit) $WorktreeRoot
    [pscustomobject][ordered]@{ schemaVersion = 1; repoRoot = $RepoRoot; repositoryKind = 'shared-clone' } |
        ConvertTo-Json | Set-Content -LiteralPath $checkoutMarkerPath -Encoding utf8
}

$env:NUGET_PACKAGES = $NuGetPackages
$env:DOTNET_CLI_TELEMETRY_OPTOUT = '1'
$env:DOTNET_NOLOGO = '1'
$env:DOTNET_SKIP_FIRST_TIME_EXPERIENCE = '1'
$env:CI = 'true'
$env:TF_BUILD = 'True'
$env:BUILD_SOURCESDIRECTORY = $WorktreeRoot
$env:ASPNETCORE_Kestrel__Certificates__Default__Path = Join-Path $WorktreeRoot 'eng/common/testproxy/dotnet-devcert.pfx'
$env:ASPNETCORE_Kestrel__Certificates__Default__Password = 'password'

$resolverRelativePath = 'eng/scripts/Resolve-SparseCheckoutPaths.ps1'
$resolverPath = Join-Path $RepoRoot $resolverRelativePath
$dirtyResolver = @(& git -C $RepoRoot diff --name-only $manifest.sourceCommit -- $resolverRelativePath)
if ($LASTEXITCODE -ne 0 -or $dirtyResolver.Count -gt 0) {
    throw "Resolver '$resolverRelativePath' must match manifest commit '$($manifest.sourceCommit)'."
}
$runResults = [System.Collections.Generic.List[object]]::new()
$matrixEnvironmentNames = [System.Collections.Generic.HashSet[string]]::new([StringComparer]::OrdinalIgnoreCase)
$stopRequested = $false

foreach ($case in $cases) {
    $setupPolicy = "recordings=$(!$SkipRecordings)|azurite=$(!$SkipAzurite)|testArchitecture=$TestTargetArchitecture"
    $validationKey = "$($manifest.sourceCommit)|$($manifest.checkoutGraphSha256)|$($manifest.harnessVersion)|$setupPolicy|$($case.artifactName)|$($case.matrixName)"
    $caseName = Get-SafeCaseName $case.artifactName $case.matrixName $validationKey
    $caseDirectory = Join-Path (Join-Path $ResultsRoot 'cases') $caseName
    $resultPath = Join-Path $caseDirectory 'result.json'
    if ($Resume -and (Test-Path -LiteralPath $resultPath)) {
        $previous = Get-Content -Raw -LiteralPath $resultPath | ConvertFrom-Json -Depth 100
        if ($previous.validationKey -eq $validationKey -and $previous.status -eq 'passed') {
            Write-Host "RESUME passed: $($case.artifactName) / $($case.matrixName)"
            $previous.status = 'resumed'
            $runResults.Add($previous)
            continue
        }
    }

    if (Test-Path -LiteralPath $caseDirectory) {
        Remove-Item -LiteralPath $caseDirectory -Recurse -Force
    }
    New-Item -ItemType Directory -Path $caseDirectory -Force | Out-Null
    $started = [DateTime]::UtcNow
    $phase = 'initialize'
    $status = 'failed'
    $message = ''
    Write-Host "`n=== $($case.artifactName) / $($case.matrixName) ==="

    try {
        $phase = 'configure-matrix'
        if (!$PreserveCurrentEnvironment) {
            Set-MatrixEnvironment $case.matrixParameters $matrixEnvironmentNames
        }

        # This is a dedicated validation worktree. Cleaning prevents generated files from a prior
        # artifact from satisfying the next artifact's sparse checkout accidentally.
        $phase = 'clean-worktree'
        Invoke-CheckedGit @('reset', '--hard', $manifest.sourceCommit) $WorktreeRoot
        Invoke-CheckedGit @('clean', '-ffdx') $WorktreeRoot

        $phase = 'resolve-sparse-paths'
        $paths = @(& $resolverPath `
            -GraphPath $checkoutGraphPath `
            -ArtifactNames $case.artifactName `
            -ExpectedSourceCommit $manifest.sourceCommit)
        if ($paths.Count -eq 0) {
            throw 'Sparse resolver returned no paths; full-checkout fallback is forbidden during validation.'
        }
        $dynamicPaths = @($paths | Where-Object { $_ -match '^/sdk/[^/]+/\*$' })
        if ($dynamicPaths.Count -eq 0) {
            throw 'Sparse resolver returned no SDK service root.'
        }
        $paths | Set-Content -LiteralPath (Join-Path $caseDirectory 'sparse-paths.txt') -Encoding utf8

        $phase = 'materialize-sparse-worktree'
        $patterns = ($paths -join "`n") + "`n"
        $patterns | & git -C $WorktreeRoot sparse-checkout set --no-cone --stdin
        if ($LASTEXITCODE -ne 0) { throw 'git sparse-checkout set failed.' }
        Invoke-CheckedGit @('reset', '--hard', $manifest.sourceCommit) $WorktreeRoot
        Write-Host "SPARSE_CHECKOUT_CASE_RESULT=materialized artifact=$($case.artifactName) pathCount=$($paths.Count)"

        $phase = 'create-project-list'
        $casePackageInfo = Join-Path $caseDirectory 'PackageInfo'
        New-Item -ItemType Directory -Path $casePackageInfo -Force | Out-Null
        if (!$packageInfoFileByArtifact.ContainsKey([string]$case.artifactName)) {
            throw "PackageInfo has no singleton artifact '$($case.artifactName)'."
        }
        Copy-Item -LiteralPath $packageInfoFileByArtifact[[string]$case.artifactName] -Destination $casePackageInfo
        $projectListDirectory = Join-Path $WorktreeRoot 'projlist'
        & (Join-Path $WorktreeRoot 'eng/scripts/splittestdependencies/set-artifact-packages.ps1') `
            -ProjectNames $case.artifactName `
            -OutputPath $projectListDirectory `
            -PackageInfoFolder $casePackageInfo `
            -SetOverrideFile $true
        $projectListPath = Join-Path $projectListDirectory 'packages_Project_0.props'
        if (!(Test-Path -LiteralPath $projectListPath)) {
            throw "Project-list override was not generated: $projectListPath"
        }
        Copy-Item -LiteralPath $projectListPath -Destination (Join-Path $caseDirectory 'project-list.props')

        $phase = 'setup'
        $env:AGENT_TEMPDIRECTORY = Join-Path $CacheRoot 'agent-temp'
        New-Item -ItemType Directory -Path $env:AGENT_TEMPDIRECTORY -Force | Out-Null
        & (Join-Path $WorktreeRoot 'eng/common/scripts/trust-proxy-certificate.ps1')
        $testProxyVersionPath = Join-Path $WorktreeRoot 'eng/common/testproxy/target_version.txt'
        $testProxyVersion = (Get-Content -Raw -LiteralPath $testProxyVersionPath).Trim()
        $testProxyOverridePath = Join-Path $WorktreeRoot 'eng/target_proxy_version.txt'
        if (Test-Path -LiteralPath $testProxyOverridePath) {
            $testProxyVersion = (Get-Content -Raw -LiteralPath $testProxyOverridePath).Trim()
        }
        $testProxyInstallRoot = Join-Path $CacheRoot "test-proxy/$testProxyVersion"
        $testProxyBinaries = Join-Path $testProxyInstallRoot 'test-proxy'
        $testProxyExecutable = Join-Path $testProxyBinaries ($IsWindows ? 'test-proxy.exe' : 'test-proxy')
        if (!(Test-Path -LiteralPath $testProxyExecutable)) {
            & (Join-Path $WorktreeRoot 'eng/common/scripts/Install-TestProxy.ps1') `
                -TemplateRoot $WorktreeRoot `
                -BinariesDirectory $testProxyInstallRoot `
                -RunProxy $false
            if ($LASTEXITCODE -ne 0 -or !(Test-Path -LiteralPath $testProxyExecutable)) {
                throw "Test proxy installation failed for version '$testProxyVersion'."
            }
        }
        if ($testProxyBinaries -notin @($env:PATH -split [regex]::Escape([string][System.IO.Path]::PathSeparator))) {
            $env:PATH = "$testProxyBinaries$([System.IO.Path]::PathSeparator)$env:PATH"
        }
        $toolRestoreExitCode = Invoke-LoggedCommand 'dotnet' @('tool', 'restore') $WorktreeRoot (Join-Path $caseDirectory 'tool-restore.log')
        if ($toolRestoreExitCode -ne 0) { throw "dotnet tool restore failed with exit code $toolRestoreExitCode." }
        if (!$SkipRecordings) {
            & (Join-Path $WorktreeRoot 'eng/scripts/Restore-RecordingsShared.ps1') `
                -PackageInfoFolder $casePackageInfo `
                -ProjectNames $case.artifactName `
                -SourcesDirectory $WorktreeRoot `
                -SharedCloneRoot (Join-Path $CacheRoot 'recording-clones')
        }
        [Environment]::SetEnvironmentVariable('AZURE_AZURITE_LOCATION', $null, 'Process')
        if (!$SkipAzurite -and $case.artifactName -match '(?i)storage') {
            $azuriteLocation = Join-Path $CacheRoot 'azurite'
            if (!(Test-Path -LiteralPath (Join-Path $azuriteLocation 'node_modules/.bin/azurite'))) {
                & (Join-Path $WorktreeRoot 'eng/scripts/Install-Azurite.ps1') `
                    -AzuriteLocation $azuriteLocation -AzuriteVersion '3.11.0'
                if ($LASTEXITCODE -ne 0) { throw 'Azurite installation failed.' }
            }
            $env:AZURE_AZURITE_LOCATION = $azuriteLocation
        }

        $phase = 'test'
        $resultsDirectory = Join-Path $caseDirectory 'test-results'
        New-Item -ItemType Directory -Path $resultsDirectory -Force | Out-Null
        $relativeProjectList = [System.IO.Path]::GetRelativePath($WorktreeRoot, $projectListPath).Replace('\', '/')
        $testFilter = "(TestCategory!=Manually) & (TestCategory!=Live) & ($($case.additionalTestFilters))"
        $arguments = [System.Collections.Generic.List[string]]::new()
        @(
            'test', 'eng/service.proj',
            '--filter', $testFilter,
            '--framework', [string]$case.targetFramework,
            '--results-directory', $resultsDirectory,
            '--logger', "trx;LogFileName=$($case.targetFramework).trx",
            '--logger', 'console;verbosity=normal',
            '--blame-crash-dump-type', 'full',
            '--blame-hang-dump-type', 'full',
            '--blame-hang-timeout', "$TestTimeoutInMinutes`minutes",
            '/p:SDKType=all', '/p:ServiceDirectory=*',
            "/p:IncludeSrc=$(([string][bool]$case.includeSourceProjects).ToLowerInvariant())",
            '/p:IncludeSamples=false', '/p:IncludePerf=false',
            '/p:IncludeStress=false', '/p:IncludeIntegrationTests=false',
            '/p:RunApiCompat=false', '/p:InheritDocEnabled=false',
            "/p:Configuration=$($case.buildConfiguration)",
            "/p:CollectCoverage=$(([string]$case.collectCoverage).ToLowerInvariant())",
            '/p:EnableSourceLink=false',
            "/p:ProjectListOverrideFile=$relativeProjectList",
            '/p:EnableOverrideExclusions=true',
            "/binaryLogger:LogFile=$(Join-Path $caseDirectory 'test.binlog')"
        ) | ForEach-Object { $arguments.Add([string]$_) }
        if ($TestTargetArchitecture) {
            # Preserve every repository test setting while selecting the native host architecture
            # for an explicitly non-x64 structural-validation campaign.
            [xml]$runSettings = Get-Content -Raw -LiteralPath (Join-Path $WorktreeRoot 'eng/nunit.runsettings')
            $targetPlatform = $runSettings.SelectSingleNode('/RunSettings/RunConfiguration/TargetPlatform')
            if ($null -eq $targetPlatform) { throw 'eng/nunit.runsettings has no TargetPlatform element.' }
            $targetPlatform.InnerText = $TestTargetArchitecture
            $caseRunSettingsPath = Join-Path $caseDirectory 'nunit.runsettings'
            $runSettings.Save($caseRunSettingsPath)
            $arguments.Add('--settings')
            $arguments.Add($caseRunSettingsPath)
        }
        foreach ($argument in @(Split-AdditionalArguments $case.additionalTestArguments)) {
            $arguments.Add($argument)
        }
        $commandText = "dotnet " + ($arguments | ForEach-Object {
            $_ -match '\s' ? "`"$($_.Replace('"', '\"'))`"" : $_
        }) -join ' '
        $commandText | Set-Content -LiteralPath (Join-Path $caseDirectory 'command.txt') -Encoding utf8
        $exitCode = Invoke-LoggedCommand 'dotnet' $arguments.ToArray() $WorktreeRoot `
            (Join-Path $caseDirectory 'test.log') -TimeoutInMinutes $TestTimeoutInMinutes
        if ($exitCode -ne 0) {
            throw "dotnet test failed with exit code $exitCode."
        }

        $status = 'passed'
        $phase = 'complete'
    }
    catch {
        $message = $_.Exception.Message
        Write-Warning "$($case.artifactName) / $($case.matrixName) failed during $phase`: $message"
    }

    try {
        # The next singleton starts from git clean -ffdx, so retain generated diagnostics first.
        Copy-CaseEvidence $WorktreeRoot $caseDirectory ([bool]$case.collectCoverage) ($status -eq 'failed')
    }
    catch {
        $evidenceMessage = "Evidence collection failed: $($_.Exception.Message)"
        if ($status -eq 'passed') {
            $status = 'failed'
            $phase = 'collect-evidence'
            $message = $evidenceMessage
        }
        else {
            $message = "$message $evidenceMessage"
        }
        Write-Warning "$($case.artifactName) / $($case.matrixName): $evidenceMessage"
    }

    $finished = [DateTime]::UtcNow
    $result = [pscustomobject][ordered]@{
        schemaVersion = 1
        validationKey = $validationKey
        sourceCommit = $manifest.sourceCommit
        checkoutGraphSha256 = $manifest.checkoutGraphSha256
        harnessVersion = $manifest.harnessVersion
        artifactName = $case.artifactName
        matrixName = $case.matrixName
        host = $case.host
        targetFramework = $case.targetFramework
        buildConfiguration = $case.buildConfiguration
        additionalTestArguments = $case.additionalTestArguments
        matrixParameters = $case.matrixParameters
        recordingsEnabled = !$SkipRecordings
        azuriteEnabled = !$SkipAzurite
        testTargetArchitecture = $TestTargetArchitecture
        status = $status
        phase = $phase
        message = $message
        startedAtUtc = $started.ToString('o')
        finishedAtUtc = $finished.ToString('o')
        elapsedSeconds = [Math]::Round(($finished - $started).TotalSeconds, 3)
        evidenceDirectory = [System.IO.Path]::GetRelativePath($ResultsRoot, $caseDirectory).Replace('\', '/')
    }
    $result | ConvertTo-Json -Depth 20 | Set-Content -LiteralPath $resultPath -Encoding utf8
    $runResults.Add($result)
    Write-Host "SPARSE_CHECKOUT_CASE_RESULT=$status artifact=$($case.artifactName) phase=$phase"
    if ($status -eq 'failed' -and $FailureMode -eq 'Stop') {
        $stopRequested = $true
        break
    }
}

$summary = Write-RunSummary $runResults.ToArray() $manifest $ResultsRoot $TargetHost
Write-Host "Sparse validation result: $($summary.result); passed=$($summary.passed), failed=$($summary.failed), resumed=$($summary.resumed)"
Write-Host "Summary: $(Join-Path $ResultsRoot 'summary.md')"
if ($summary.failed -gt 0 -or $stopRequested) {
    throw 'One or more sparse-checkout validation cases failed.'
}
