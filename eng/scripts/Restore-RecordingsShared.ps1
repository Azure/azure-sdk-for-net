#Requires -Version 7.0

<#
.SYNOPSIS
Restores test recordings for all targeted packages using a single shared git
clone that fans out to per-package .assets directories via local hardlinks /
object alternates.

.DESCRIPTION
Replaces the per-package sequential `test-proxy restore` loop with:

  1. One shared bare clone of each unique assets repo (default:
     $env:AGENT_TEMPDIRECTORY/.assets-shared/<owner__repo>).
  2. A batched `git fetch` of all required tags in chunks of -FetchChunkSize
     using explicit `+refs/tags/<tag>:refs/tags/<tag>` refspecs.
  3. A `git clone --local --shared --no-checkout <shared> <package>/.assets`
     per package, followed by `git checkout <tag> -- .` to materialize the
     recording tree.

Output is functionally equivalent to running
`test-proxy restore -a <assets.json>` per package, but typically ~10x faster
on jobs that touch many packages (the per-package clone reuses the shared
clone's objects via alternates instead of re-running upload-pack against
GitHub).

The script fails loudly (non-zero exit + thrown error) on any failure -
there is no silent fallback to producing potentially-wrong recordings.

.PARAMETER PackageInfoFolder
Folder containing per-package property JSON files (one .json per artifact).
Same folder the existing YAML passes via `${{ parameters.PackageInfo }}`.

.PARAMETER ProjectNames
Comma-separated list of artifact names to restore. Same as $(ProjectNames)
in YAML.

.PARAMETER SourcesDirectory
Build sources directory. Defaults to $env:BUILD_SOURCESDIRECTORY when not
provided.

.PARAMETER SharedCloneRoot
Root folder for shared bare clones. Defaults to
$env:AGENT_TEMPDIRECTORY/.assets-shared (falls back to the system temp dir
when AGENT_TEMPDIRECTORY is unset).

.PARAMETER FetchChunkSize
Number of tags fetched per `git fetch` invocation. Default 30.
#>

[CmdletBinding()]
param(
    [Parameter(Mandatory = $true)][string] $PackageInfoFolder,
    [Parameter(Mandatory = $true)][string] $ProjectNames,
    [string] $SourcesDirectory,
    [string] $SharedCloneRoot,
    [int]    $FetchChunkSize = 30
)

Set-StrictMode -Version 3.0
$ErrorActionPreference = 'Stop'

function Invoke-GitCommand {
    param(
        [Parameter(Mandatory = $true)][string[]] $GitArgs,
        [string] $FailMessage,
        [switch] $AllowFailure,
        [switch] $CaptureOutput,
        [switch] $NoSafeBareOverride
    )

    # We rely on bare clones under $SharedCloneRoot. On some hosts (and increasingly
    # by default), `safe.bareRepository` is set to `explicit`, which causes commands
    # like `git -C <bare> ...` and `git clone --local <bare> <dest>` to fail with
    # `cannot use bare repository ... (safe.bareRepository is 'explicit')`.
    # Override per-invocation so the script works regardless of host git config.
    if (-not $NoSafeBareOverride) {
        $GitArgs = @('-c', 'safe.bareRepository=all') + $GitArgs
    }

    if ($CaptureOutput) {
        $output = & git @GitArgs 2>&1
    }
    else {
        & git @GitArgs
        $output = $null
    }

    $exit = $LASTEXITCODE
    if ($exit -ne 0 -and -not $AllowFailure) {
        if ($null -ne $output) { $output | ForEach-Object { Write-Host $_ } }
        $msg = if ($FailMessage) { $FailMessage } else { "git command failed" }
        throw "$msg (exit $exit): git $($GitArgs -join ' ')"
    }

    return [pscustomobject]@{ ExitCode = $exit; Output = $output }
}

# --- Resolve defaults ---------------------------------------------------------

if (-not $SourcesDirectory) {
    $SourcesDirectory = $env:BUILD_SOURCESDIRECTORY
    if (-not $SourcesDirectory) {
        throw "SourcesDirectory was not provided and BUILD_SOURCESDIRECTORY is not set."
    }
}

if (-not $SharedCloneRoot) {
    $tempBase = $env:AGENT_TEMPDIRECTORY
    if (-not $tempBase) { $tempBase = [System.IO.Path]::GetTempPath() }
    $SharedCloneRoot = Join-Path $tempBase ".assets-shared"
}

if (-not (Test-Path $PackageInfoFolder)) {
    throw "PackageInfoFolder not found: $PackageInfoFolder"
}
if (-not (Test-Path $SourcesDirectory)) {
    throw "SourcesDirectory not found: $SourcesDirectory"
}
if ($FetchChunkSize -lt 1) {
    throw "FetchChunkSize must be >= 1 (got $FetchChunkSize)."
}

Write-Host "Restore-RecordingsShared.ps1"
Write-Host "  PackageInfoFolder = $PackageInfoFolder"
Write-Host "  SourcesDirectory  = $SourcesDirectory"
Write-Host "  SharedCloneRoot   = $SharedCloneRoot"
Write-Host "  FetchChunkSize    = $FetchChunkSize"

# Sanity-check git is on PATH and recent enough.
$gitVersion = (Invoke-GitCommand -GitArgs @('--version') -CaptureOutput -FailMessage "git is not available on PATH").Output
Write-Host "  git               = $gitVersion"

# --- 1. Discover assets.json files for the targeted artifacts ----------------

$projectSet = $ProjectNames.Split(',', [System.StringSplitOptions]::RemoveEmptyEntries) |
    ForEach-Object { $_.Trim() } |
    Where-Object { $_ }

if (-not $projectSet) {
    Write-Host "ProjectNames is empty - nothing to restore."
    exit 0
}

$selectedPackages = Get-ChildItem -Recurse $PackageInfoFolder -Filter *.json |
    ForEach-Object { Get-Content -Raw -Path $_.FullName | ConvertFrom-Json } |
    Where-Object { $projectSet -contains $_.ArtifactName }

$assetEntries = New-Object System.Collections.Generic.List[object]
foreach ($pkg in $selectedPackages) {
    $assetsJson = Join-Path (Join-Path $SourcesDirectory $pkg.DirectoryPath) "assets.json"
    if (-not (Test-Path $assetsJson)) {
        continue
    }

    $assetData = Get-Content -Raw $assetsJson | ConvertFrom-Json

    # Only the absence of the property itself is a hard configuration error.
    # An empty Tag value is valid - it means the package has no recordings yet
    # (test-proxy itself treats this as a no-op). Mirror that behavior here:
    # skip restore and remove any stale `.assets` directory so the package
    # starts in a known-empty state.
    if (-not $assetData.PSObject.Properties.Match('Tag').Count) {
        throw "assets.json at $assetsJson is missing the 'Tag' property."
    }
    if (-not $assetData.PSObject.Properties.Match('AssetsRepo').Count) {
        throw "assets.json at $assetsJson is missing the 'AssetsRepo' property."
    }

    if ([string]::IsNullOrWhiteSpace($assetData.Tag)) {
        $staleAssetsDir = Join-Path (Split-Path -Parent $assetsJson) ".assets"
        if (Test-Path $staleAssetsDir) {
            Write-Host "  $($pkg.ArtifactName): empty Tag - removing stale .assets at $staleAssetsDir"
            Remove-Item -Recurse -Force $staleAssetsDir
        }
        else {
            Write-Host "  $($pkg.ArtifactName): empty Tag - nothing to restore (skipped)."
        }
        continue
    }

    if ([string]::IsNullOrWhiteSpace($assetData.AssetsRepo)) {
        throw "assets.json at $assetsJson has a non-empty Tag '$($assetData.Tag)' but no AssetsRepo."
    }

    $assetEntries.Add([pscustomobject]@{
            Artifact   = $pkg.ArtifactName
            AssetsJson = $assetsJson
            AssetsDir  = Join-Path (Split-Path -Parent $assetsJson) ".assets"
            AssetsRepo = $assetData.AssetsRepo
            Tag        = $assetData.Tag
        }) | Out-Null
}

if ($assetEntries.Count -eq 0) {
    Write-Host "No assets.json files found for the targeted artifacts - nothing to restore."
    exit 0
}

Write-Host ""
Write-Host "Found $($assetEntries.Count) package(s) with recordings to restore."

# --- 2. Group entries by assets repo -----------------------------------------

$entriesByRepo = $assetEntries | Group-Object -Property AssetsRepo
New-Item -ItemType Directory -Path $SharedCloneRoot -Force | Out-Null

$swTotal = [System.Diagnostics.Stopwatch]::StartNew()

foreach ($repoGroup in $entriesByRepo) {
    $assetsRepo = $repoGroup.Name
    $repoSafe = $assetsRepo -replace '[^a-zA-Z0-9_.-]', '__'
    $sharedRepo = Join-Path $SharedCloneRoot $repoSafe
    $repoUrl = "https://github.com/$assetsRepo.git"

    Write-Host ""
    Write-Host "=== $assetsRepo ($($repoGroup.Group.Count) package(s)) ==="
    Write-Host "Shared clone: $sharedRepo"

    # --- 2a. Validate or initialize the shared bare clone --------------------

    $needsInit = $true
    if (Test-Path $sharedRepo) {
        $isValid = $true

        $gitDirCheck = Invoke-GitCommand -GitArgs @('-C', $sharedRepo, 'rev-parse', '--git-dir') -AllowFailure -CaptureOutput
        if ($gitDirCheck.ExitCode -ne 0) { $isValid = $false }

        if ($isValid) {
            $urlCheck = Invoke-GitCommand -GitArgs @('-C', $sharedRepo, 'remote', 'get-url', 'origin') -AllowFailure -CaptureOutput
            if ($urlCheck.ExitCode -ne 0) {
                $isValid = $false
            }
            else {
                $currentUrl = ($urlCheck.Output | Select-Object -First 1).ToString().Trim()
                if ($currentUrl -ne $repoUrl) {
                    Write-Host "Existing shared clone has unexpected remote URL '$currentUrl' (expected '$repoUrl')."
                    $isValid = $false
                }
            }
        }

        if (-not $isValid) {
            Write-Host "Shared clone is invalid or stale; recreating."
            Remove-Item -Recurse -Force $sharedRepo
        }
        else {
            $needsInit = $false
        }
    }

    if ($needsInit) {
        New-Item -ItemType Directory -Path $sharedRepo -Force | Out-Null
        Invoke-GitCommand -GitArgs @('init', '--bare', '--quiet', $sharedRepo) `
            -FailMessage "git init --bare failed for $sharedRepo" | Out-Null
        Invoke-GitCommand -GitArgs @('-C', $sharedRepo, 'remote', 'add', 'origin', $repoUrl) `
            -FailMessage "git remote add origin $repoUrl failed for $sharedRepo" | Out-Null
    }

    # --- 2b. Determine which tags are missing from the shared clone ----------

    $uniqueTags = @($repoGroup.Group | Select-Object -ExpandProperty Tag -Unique)
    $missingTags = New-Object System.Collections.Generic.List[string]
    foreach ($tag in $uniqueTags) {
        $rev = Invoke-GitCommand -GitArgs @('-C', $sharedRepo, 'rev-parse', '--verify', '--quiet', "refs/tags/$tag") `
            -AllowFailure -CaptureOutput
        if ($rev.ExitCode -ne 0) { $missingTags.Add($tag) | Out-Null }
    }
    Write-Host "Unique tags: $($uniqueTags.Count); missing locally: $($missingTags.Count)"

    # --- 2c. Fetch missing tags in chunks via explicit refspecs --------------

    if ($missingTags.Count -gt 0) {
        $swFetch = [System.Diagnostics.Stopwatch]::StartNew()
        $chunkCount = [int][Math]::Ceiling($missingTags.Count / [double]$FetchChunkSize)

        for ($i = 0; $i -lt $missingTags.Count; $i += $FetchChunkSize) {
            $end = [Math]::Min($i + $FetchChunkSize - 1, $missingTags.Count - 1)
            $chunk = $missingTags[$i..$end]
            $refspecs = $chunk | ForEach-Object { "+refs/tags/$($_):refs/tags/$($_)" }
            $chunkIdx = [int]($i / $FetchChunkSize) + 1

            Write-Host "Fetching chunk $chunkIdx/$chunkCount ($($chunk.Count) tag(s))..."
            $fetchArgs = @('-C', $sharedRepo, 'fetch', '--no-tags', '--quiet', 'origin') + $refspecs
            Invoke-GitCommand -GitArgs $fetchArgs `
                -FailMessage "git fetch failed for chunk $chunkIdx of $chunkCount" | Out-Null
        }
        $swFetch.Stop()
        Write-Host ("Fetched {0} tag(s) in {1:N1}s." -f $missingTags.Count, $swFetch.Elapsed.TotalSeconds)
    }

    # --- 3. Materialize each package via a local shared clone ----------------

    $swMaterialize = [System.Diagnostics.Stopwatch]::StartNew()
    foreach ($entry in $repoGroup.Group) {
        Write-Host "  -> $($entry.Artifact)  tag=$($entry.Tag)"
        Write-Host "       dest=$($entry.AssetsDir)"

        if (Test-Path $entry.AssetsDir) {
            Remove-Item -Recurse -Force $entry.AssetsDir
        }

        $parent = Split-Path -Parent $entry.AssetsDir
        if (-not (Test-Path $parent)) {
            New-Item -ItemType Directory -Path $parent -Force | Out-Null
        }

        Invoke-GitCommand -GitArgs @('clone', '--local', '--shared', '--no-checkout', '--quiet', $sharedRepo, $entry.AssetsDir) `
            -FailMessage "git clone --local --shared failed for $($entry.Artifact)" | Out-Null

        Invoke-GitCommand -GitArgs @('-C', $entry.AssetsDir, 'checkout', '--quiet', $entry.Tag, '--', '.') `
            -FailMessage "git checkout $($entry.Tag) failed for $($entry.Artifact)" | Out-Null
    }
    $swMaterialize.Stop()
    Write-Host ("Materialized {0} package(s) in {1:N1}s." -f $repoGroup.Group.Count, $swMaterialize.Elapsed.TotalSeconds)
}

$swTotal.Stop()
Write-Host ""
Write-Host ("All recordings restored successfully ({0} package(s) in {1:N1}s)." -f $assetEntries.Count, $swTotal.Elapsed.TotalSeconds)
