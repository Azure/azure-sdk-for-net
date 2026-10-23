#Requires -Version 7.0
<#
.SYNOPSIS
Validate management-generator changes by regenerating selected SDKs.
.DESCRIPTION
Uses CI's Initialize-WorkingDirectory.ps1, Build-Emitter.ps1, tsp-client
 generate-config-files, and the normal GenerateCode target in an isolated worktree.
Defaults to the eligible priority SDKs and always schedules the slowest measured
SDKs first. Successful runs automatically update shared timing history. Nothing is
published or pushed unless explicitly requested. This workflow is intended for
small SDK groups; use CI for full-scope regeneration and required validation.
.PARAMETER GeneratorPullRequest
Optional Azure/azure-sdk-for-net PR to build from its current merge ref. Without it,
builds committed HEAD of this checkout (not uncommitted generator edits).
.PARAMETER Services
Exact SDK folder names. Defaults to the eligible services from the priority list.
.PARAMETER PublishPackages
Publish the npm tarball to CI's Azure DevOps feed using your existing npm credentials.
Never publishes to npmjs.org. NuGet artifacts are built but not published.
.PARAMETER CreateDraftPullRequest
After successful regeneration, commit only selected SDK/config changes, push a new
branch, and create a draft PR. Requires PublishPackages so its package refs are portable.
.EXAMPLE
./ValidateGeneratorSdkChanges.ps1 -GeneratorPullRequest 12345 -Services Azure.ResourceManager.KeyVault,Azure.ResourceManager.Dns -Parallel 2
.EXAMPLE
./ValidateGeneratorSdkChanges.ps1 -GeneratorPullRequest 12345 -PublishPackages -CreateDraftPullRequest
.EXAMPLE
./ValidateGeneratorSdkChanges.ps1 -WhatIf
#>
[CmdletBinding(SupportsShouldProcess)]
param(
    [ValidateRange(1, [int]::MaxValue)][int]$GeneratorPullRequest,
    [string[]]$Services = @(
        'Azure.ResourceManager.Compute', 'Azure.ResourceManager.Network',
        'Azure.ResourceManager.Storage', 'Azure.ResourceManager.KeyVault',
        'Azure.ResourceManager.Sql', 'Azure.ResourceManager.AppService',
        'Azure.ResourceManager.ContainerService', 'Azure.ResourceManager.Monitor',
        'Azure.ResourceManager.OperationalInsights', 'Azure.ResourceManager.ManagedServiceIdentities',
        'Azure.ResourceManager.Authorization', 'Azure.ResourceManager.Dns',
        'Azure.ResourceManager.PrivateDns', 'Azure.ResourceManager.TrafficManager',
        'Azure.ResourceManager.ContainerRegistry', 'Azure.ResourceManager.CosmosDB',
        'Azure.ResourceManager.PostgreSql', 'Azure.ResourceManager.MySql',
        'Azure.ResourceManager.Redis', 'Azure.ResourceManager.EventHubs', 'Azure.ResourceManager.ServiceBus'
    ),
    [ValidateRange(1, 64)][int]$Parallel = 4,
    [string]$OutputRoot,
    [switch]$PublishPackages,
    [switch]$CreateDraftPullRequest
)
$ErrorActionPreference = 'Stop'
Set-StrictMode -Version 3.0
Import-Module (Join-Path $PSScriptRoot GeneratorSdkValidation.psm1) -Force -DisableNameChecking

if ($CreateDraftPullRequest -and -not $PublishPackages) { throw '-CreateDraftPullRequest requires -PublishPackages. Local file URLs must not enter a PR.' }
$repoRoot = (Resolve-Path (Join-Path $PSScriptRoot '../../../../../..')).Path
$emitterRelativePath = 'eng/packages/http-client-csharp-mgmt'
$configRelativePath = 'eng/azure-typespec-http-client-csharp-mgmt-emitter-package.json'
$lockRelativePath = 'eng/azure-typespec-http-client-csharp-mgmt-emitter-package-lock.json'
$registry = 'https://pkgs.dev.azure.com/azure-sdk/public/_packaging/azure-sdk-for-js/npm/registry/'
$runId = "$(Get-Date -AsUTC -Format yyyyMMdd).$([DateTimeOffset]::UtcNow.ToUnixTimeMilliseconds())"
$manifest = Get-Content (Join-Path $repoRoot "$emitterRelativePath/package.json") -Raw | ConvertFrom-Json
$identity = Get-GeneratorSdkValidationIdentity -PackageName $manifest.name -Version $manifest.version -PullRequest $GeneratorPullRequest -RunId $runId
$scope = $Services -join ', '
if (-not $PSCmdlet.ShouldProcess($scope, "Build packaged MPG in a new worktree; regenerate with $Parallel workers; publish=$PublishPackages; draft PR=$CreateDraftPullRequest")) { return }
foreach ($tool in @('git', 'npm', 'dotnet', 'pwsh')) { $null = Get-Command $tool -ErrorAction Stop }
if ($GeneratorPullRequest -or $CreateDraftPullRequest) { $null = Get-Command gh -ErrorAction Stop }
if (-not $OutputRoot) { $OutputRoot = Join-Path (Split-Path $repoRoot) "mpg-local-runs/$runId" }
$OutputRoot = $ExecutionContext.SessionState.Path.GetUnresolvedProviderPathFromPSPath($OutputRoot)
if (Test-Path $OutputRoot) { throw "Output directory already exists: $OutputRoot. Choose a new directory; existing runs are never overwritten." }

# Resolve and pin the source before executing PR code. No checkout/reset of the caller.
if ($GeneratorPullRequest) {
    $pr = (Invoke-GeneratorSdkValidationCommand gh @('pr', 'view', "$GeneratorPullRequest", '--repo', 'Azure/azure-sdk-for-net', '--json', 'state,baseRefName,headRefOid') $repoRoot) -join "`n" | ConvertFrom-Json
    if ($pr.state -ne 'OPEN' -or $pr.baseRefName -ne 'main') { throw 'Expected an open generator PR targeting main.' }
    Invoke-GeneratorSdkValidationCommand git @('fetch', 'https://github.com/Azure/azure-sdk-for-net.git', "refs/pull/$GeneratorPullRequest/merge") $repoRoot | Out-Host
    $sourceSha = (Invoke-GeneratorSdkValidationCommand git @('rev-parse', 'FETCH_HEAD') $repoRoot | Select-Object -Last 1).Trim()
    $mergeHead = (Invoke-GeneratorSdkValidationCommand git @('rev-parse', "$sourceSha^2") $repoRoot | Select-Object -Last 1).Trim()
    if ($mergeHead -ne $pr.headRefOid) { throw 'PR head changed or merge ref is stale. Retry against the new head.' }
}
else {
    $sourceSha = (Invoke-GeneratorSdkValidationCommand git @('rev-parse', 'HEAD') $repoRoot | Select-Object -Last 1).Trim()
}
New-Item $OutputRoot -ItemType Directory | Out-Null
$worktree = Join-Path $OutputRoot sdk
$artifacts = Join-Path $OutputRoot artifacts
New-Item $artifacts -ItemType Directory | Out-Null
# Detached local runs cannot collide with an existing CI regeneration branch.
Invoke-GeneratorSdkValidationCommand git @('worktree', 'add', '--detach', $worktree, $sourceSha) $repoRoot | Out-Host
$packageRoot = Join-Path $worktree $emitterRelativePath
$manifest = Get-Content (Join-Path $packageRoot package.json) -Raw | ConvertFrom-Json
$identity = Get-GeneratorSdkValidationIdentity -PackageName $manifest.name -Version $manifest.version -PullRequest $GeneratorPullRequest -RunId $runId
$packages = @(Get-GeneratorSdkValidationServices -RepoRoot $worktree -Services $Services)
$commonGitDirectory = ((Invoke-GeneratorSdkValidationCommand git @('rev-parse', '--path-format=absolute', '--git-common-dir') $repoRoot) -join '').Trim()
$historyPath = Join-Path $commonGitDirectory 'mpg-local-regen/service-timings.json'
$packages = @(Get-GeneratorSdkValidationSchedule -Packages $packages -HistoryPath $historyPath)
# Honor package-specific instructions before regenerating SDK code.
foreach ($package in $packages) {
    if (Test-Path (Join-Path $package.FullName '.github/skills')) {
        throw "Read package-specific skills under $($package.FullName)/.github/skills before regenerating. Use a package-specific workflow for this SDK."
    }
}
@{
    SourceCommit = $sourceSha; SourcePullRequest = $GeneratorPullRequest; Version = $identity.Version
    Packages = @($packages.Name); Parallel = $Parallel; TimingHistoryPath = $historyPath; Published = $false
    Worktree = $worktree; StartedUtc = (Get-Date -AsUTC -Format o)
} | ConvertTo-Json -Depth 5 | Set-Content (Join-Path $OutputRoot run.json)
Write-Host "Source: $sourceSha; version: $($identity.Version); selected SDKs: $($packages.Count)"
Write-Host "Automatic slowest-first order starts with: $($packages.Name | Select-Object -First $Parallel)"

# CI scripts run in child PowerShell processes: their scope/exit handling cannot
# terminate the orchestrator or accidentally overwrite caller variables.
Invoke-GeneratorSdkValidationCommand pwsh @('-NoProfile', '-File', (Join-Path $worktree 'eng/scripts/typespec/Initialize-WorkingDirectory.ps1'), '-OutputDirectory', $artifacts, '-PrereleaseSuffix', "-alpha.$runId", '-EmitterPackagePath', $emitterRelativePath) $worktree | Out-Host
Invoke-GeneratorSdkValidationCommand pwsh @('-NoProfile', '-File', (Join-Path $worktree 'eng/scripts/typespec/Build-Emitter.ps1'), '-OutputDirectory', (Join-Path $artifacts packages), '-EmitterPackagePath', $emitterRelativePath, '-GeneratorVersion', $identity.Version) $worktree | Out-Host
$archives = @(Get-ChildItem (Join-Path $artifacts packages) -Filter '*.tgz')
if ($archives.Count -ne 1) { throw "Expected exactly one emitter tarball, found $($archives.Count)." }
$overrides = Join-Path $artifacts 'packages/overrides.json'
if ($PublishPackages) {
    Invoke-GeneratorSdkValidationCommand npm @('publish', $archives[0].FullName, '--registry', $registry, '--access', 'public') $worktree | Out-Host
    # Publication is not rolled back if a later generation task fails.
    $receiptPath = Join-Path $OutputRoot run.json
    $receipt = Get-Content $receiptPath -Raw | ConvertFrom-Json
    $receipt.Published = $true
    $receipt | ConvertTo-Json -Depth 5 | Set-Content $receiptPath
}
else {
    # The actual packed tarball is installed by tsp-client, not the local source tree.
    $localOverrides = @{ $manifest.name = "file:$($archives[0].FullName.Replace('\', '/'))" }
    $overrides = Join-Path $artifacts local-overrides.json
    $localOverrides | ConvertTo-Json | Set-Content $overrides
}
$tspClient = Join-Path $worktree 'eng/common/tsp-client'
Invoke-GeneratorSdkValidationCommand npm @('ci') $tspClient | Out-Host
Invoke-GeneratorSdkValidationCommand npm @('ci') $worktree | Out-Host
Invoke-GeneratorSdkValidationCommand npm @('exec', '--no', '--', 'tsp-client', 'generate-config-files', '--package-json', (Join-Path $artifacts 'lock-files/package.json'), '--emitter-package-json-path', (Join-Path $worktree $configRelativePath), '--overrides', $overrides) $tspClient | Out-Host
$results = Invoke-GeneratorSdkValidationParallel -Packages $packages -Parallel $Parallel -LogDirectory (Join-Path $OutputRoot logs) -HistoryPath $historyPath
$receiptPath = Join-Path $OutputRoot run.json
$receipt = Get-Content $receiptPath -Raw | ConvertFrom-Json
$receipt.Published = [bool]$PublishPackages
$receipt | Add-Member FinishedUtc (Get-Date -AsUTC -Format o)
$receipt | Add-Member Results @($results)
$receipt | ConvertTo-Json -Depth 8 | Set-Content $receiptPath
Write-Host "Regeneration complete. Worktree: $worktree; receipt: $receiptPath"
if (-not $CreateDraftPullRequest) { return }

# Never commit local tarball references, unrelated source/build drift, or failures.
Assert-GeneratorSdkValidationPortableConfig @((Join-Path $worktree $configRelativePath), (Join-Path $worktree $lockRelativePath))
$allowed = @($configRelativePath, $lockRelativePath)
$selectedPrefixes = @($packages | ForEach-Object { [IO.Path]::GetRelativePath($worktree, $_.FullName).Replace('\', '/') + '/' })
$changed = @(Invoke-GeneratorSdkValidationCommand git @('diff', '--name-only', 'HEAD') $worktree)
$changed += @(Invoke-GeneratorSdkValidationCommand git @('ls-files', '--others', '--exclude-standard') $worktree)
foreach ($path in $changed) {
    if ($path -in $allowed) { continue }
    if (-not @($selectedPrefixes | Where-Object { $path.StartsWith($_, [StringComparison]::Ordinal) }).Count) {
        throw "Unexpected change outside selected SDKs/config: $path. Inspect $worktree; nothing was committed or pushed."
    }
}
$remote = @(Invoke-GeneratorSdkValidationCommand git @('remote', 'get-url', '--push', '--all', 'origin') $worktree)
if (-not $remote.Count) { throw 'No origin push destination was found.' }
foreach ($url in $remote) {
    if ($url -notmatch '^(https://github\.com/|git@github\.com:)Azure/azure-sdk-for-net(\.git)?$') {
        throw 'Refusing to push to an unexpected origin push destination; expected Azure/azure-sdk-for-net on GitHub.'
    }
}
# Every accepted URL identifies the same upstream repository. Pin the URL used
# for collision checks and push rather than resolving the named remote again.
$remote = $remote[0]
$branch = $identity.Branch
$localRefs = @(Invoke-GeneratorSdkValidationCommand git @('for-each-ref', '--format=%(refname)', 'refs/heads/') $worktree)
$attempt = 0
while ("refs/heads/$branch" -in $localRefs -or @(
    Invoke-GeneratorSdkValidationCommand git @('ls-remote', '--heads', $remote, $branch) $worktree |
        Where-Object { $_ -cmatch "^[0-9a-f]+\s+refs/heads/$([regex]::Escape($branch))$" }
).Count) {
    $attempt++
    $branch = "$($identity.Branch)-local-$runId"
    if ($attempt -gt 1) { $branch += "-$attempt" }
}
Invoke-GeneratorSdkValidationCommand git @('switch', '-c', $branch) $worktree | Out-Host
$paths = @($configRelativePath, $lockRelativePath) + @($selectedPrefixes | ForEach-Object { $_.TrimEnd('/') })
Invoke-GeneratorSdkValidationCommand git (@('add', '--') + $paths) $worktree | Out-Host
Invoke-GeneratorSdkValidationCommand git @('diff', '--cached', '--check') $worktree | Out-Host
Invoke-GeneratorSdkValidationCommand git @('commit', '-m', "Regenerate SDKs with packaged MPG $($identity.Version)") $worktree | Out-Host
Invoke-GeneratorSdkValidationCommand git @('push', '-u', $remote, $branch) $worktree | Out-Host
$source = if ($GeneratorPullRequest) { "https://github.com/Azure/azure-sdk-for-net/pull/$GeneratorPullRequest" } else { "commit $sourceSha" }
$body = @"
Generated locally from $source at ``$sourceSha`` using packaged MPG ``$($identity.Version)``.

Selected SDKs: $($packages.Name -join ', '). Parallel workers: $Parallel.

Used CI packaging/configuration scripts and the normal GenerateCode target. All selected generation tasks passed. This is not a hosted CI/compliance validation result; required PR checks remain outstanding. NuGet artifacts were not published.

&#45; by copilot
"@
$bodyPath = Join-Path $OutputRoot pr-body.md
$body | Set-Content $bodyPath
Invoke-GeneratorSdkValidationCommand gh @('pr', 'create', '--repo', 'Azure/azure-sdk-for-net', '--base', 'main', '--head', $branch, '--draft', '--title', $identity.Title, '--body-file', $bodyPath) $worktree | Out-Host
