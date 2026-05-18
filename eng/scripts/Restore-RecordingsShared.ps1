#requires -Version 7.0
<#
.SYNOPSIS
  Restores test recordings for many packages using a single shared azure-sdk-assets
  partial clone instead of running `test-proxy restore` once per package.

.DESCRIPTION
  Compared to the per-package `test-proxy restore` loop, this script:
    * does ONE git init / partial clone of the assets repo per agent
    * does ONE multi-tag fetch (chunked) covering all package tags
    * for each package, materialises the test-proxy cache directory
      (<PROXY_ASSETS_FOLDER>/<short-hash>) by cloning --shared --local from
      the shared repo at the package's tag and applying a sparse-checkout
      matching what `test-proxy restore` would produce.

  test-proxy itself is never invoked. At playback time it will discover the
  pre-populated cache directories using the same short-hash naming scheme it
  uses on write (see Azure.Sdk.Tools.TestProxy.Common.ShortHashGenerator).

.PARAMETER PackageInfoFolder
  Folder of *.json package property files (from Get-PackageProperties / discovery).

.PARAMETER ProjectNames
  Comma-separated list of artifact names to restore (matches ProjectNames variable
  used by the rest of the PR pipeline). If empty, all package property files are
  considered.

.PARAMETER RepoRoot
  Local working copy of azure-sdk-for-net. Defaults to Build.SourcesDirectory.

.PARAMETER AssetsCacheRoot
  Where to materialise the test-proxy cache. Defaults to $env:PROXY_ASSETS_FOLDER
  or, if unset, "<Build.BinariesDirectory>/.assets" so that downstream
  test-proxy invocations find the same cache.

.PARAMETER SharedRepoPath
  Where to keep the single shared assets clone. Defaults to
  "<Build.BinariesDirectory>/.assets-shared".

.PARAMETER FetchChunkSize
  Maximum number of tags per `git fetch` invocation. 30 is safe on Windows shells.
#>
param(
    [Parameter(Mandatory)] [string] $PackageInfoFolder,
    [Parameter(Mandatory)] [string] $ProjectNames,
    [string] $RepoRoot = $env:BUILD_SOURCESDIRECTORY,
    [string] $AssetsCacheRoot,
    [string] $SharedRepoPath,
    [int]    $FetchChunkSize = 30
)

$ErrorActionPreference = 'Stop'
Set-StrictMode -Version Latest

# ---------- helpers ----------
function Get-ShortHash([string]$inputString, [int]$len = 10) {
    $sha = [System.Security.Cryptography.SHA1]::Create()
    try {
        $hash = $sha.ComputeHash([System.Text.Encoding]::UTF8.GetBytes($inputString))
        $b64  = [Convert]::ToBase64String($hash)
        return -join (($b64.ToCharArray() | Where-Object { [char]::IsLetterOrDigit($_) }) | Select-Object -First $len)
    } finally {
        $sha.Dispose()
    }
}

function Invoke-Git {
    param([string[]]$GitArgs, [string]$Cwd)
    if ($Cwd) { Push-Location $Cwd }
    try {
        $out = & git @GitArgs 2>&1
        if ($LASTEXITCODE -ne 0) {
            throw "git $($GitArgs -join ' ') failed (exit $LASTEXITCODE):`n$out"
        }
        return $out
    } finally {
        if ($Cwd) { Pop-Location }
    }
}

# ---------- resolve defaults ----------
if (-not $RepoRoot)        { throw "RepoRoot is required (set BUILD_SOURCESDIRECTORY or pass -RepoRoot)." }
$binDir = $env:BUILD_BINARIESDIRECTORY
if (-not $binDir)          { $binDir = Join-Path ([System.IO.Path]::GetTempPath()) 'restore-shared' }
if (-not $AssetsCacheRoot) {
    $AssetsCacheRoot = if ($env:PROXY_ASSETS_FOLDER) { $env:PROXY_ASSETS_FOLDER } else { Join-Path $binDir '.assets' }
}
if (-not $SharedRepoPath)  { $SharedRepoPath = Join-Path $binDir '.assets-shared' }

New-Item -ItemType Directory -Force -Path $AssetsCacheRoot | Out-Null
New-Item -ItemType Directory -Force -Path (Split-Path $SharedRepoPath -Parent) | Out-Null

Write-Host "RepoRoot         : $RepoRoot"
Write-Host "AssetsCacheRoot  : $AssetsCacheRoot"
Write-Host "SharedRepoPath   : $SharedRepoPath"
Write-Host ""

# ---------- discover target packages ----------
$total = [System.Diagnostics.Stopwatch]::StartNew()
$step  = [System.Diagnostics.Stopwatch]::StartNew()

$packageSet = @($ProjectNames -split ',' | ForEach-Object { $_.Trim() } | Where-Object { $_ })
if ($packageSet.Count -eq 0) {
    Write-Host "No ProjectNames passed; nothing to restore."
    return
}

$packageProps = Get-ChildItem -Recurse -File -Filter *.json -Path $PackageInfoFolder |
    ForEach-Object { Get-Content -Raw $_.FullName | ConvertFrom-Json } |
    Where-Object { $packageSet -contains $_.ArtifactName }

$entries = @()
foreach ($p in $packageProps) {
    $assetsRel = Join-Path $p.DirectoryPath 'assets.json'
    $assetsAbs = Join-Path $RepoRoot $assetsRel
    if (-not (Test-Path $assetsAbs)) { continue }
    $j = Get-Content -Raw $assetsAbs | ConvertFrom-Json
    if (-not $j.Tag) {
        # No recordings yet; nothing to restore — and that's OK
        continue
    }
    # AssetsJsonRelativeLocation is the path relative to RepoRoot, with forward slashes
    $relForHash = ($assetsRel -replace '\\','/')
    $hashInput  = $j.AssetsRepo + $relForHash
    $shortHash  = Get-ShortHash $hashInput
    # Sparse-checkout path that test-proxy uses today is derived from the
    # local DirectoryPath, prefixed by AssetsRepoPrefixPath.
    $sparsePath = ($j.AssetsRepoPrefixPath + '/' + ($p.DirectoryPath -replace '\\','/'))
    $entries += [PSCustomObject]@{
        Artifact     = $p.ArtifactName
        AssetsJson   = $assetsAbs
        Tag          = $j.Tag
        Repo         = $j.AssetsRepo
        Prefix       = $j.AssetsRepoPrefixPath
        SparsePath   = $sparsePath
        CacheDir     = Join-Path $AssetsCacheRoot $shortHash
    }
}

if ($entries.Count -eq 0) {
    Write-Host "No packages with assets to restore."
    return
}

$repoUrls = @($entries | Group-Object Repo)
if ($repoUrls.Count -ne 1) {
    throw "Shared-restore prototype only supports a single AssetsRepo; got: $($repoUrls.Name -join ', ')"
}
$repoUrl = "https://github.com/$($repoUrls[0].Name)"

Write-Host "Discovered $($entries.Count) packages with non-empty Tag in $([math]::Round($step.Elapsed.TotalSeconds,2))s"

# ---------- init shared partial clone ----------
$step.Restart()
if (-not (Test-Path (Join-Path $SharedRepoPath '.git'))) {
    if (Test-Path $SharedRepoPath) { Remove-Item -Recurse -Force $SharedRepoPath }
    New-Item -ItemType Directory -Force -Path $SharedRepoPath | Out-Null
    Invoke-Git -Cwd $SharedRepoPath -GitArgs @('init','-q')
    Invoke-Git -Cwd $SharedRepoPath -GitArgs @('remote','add','origin',$repoUrl)
    Invoke-Git -Cwd $SharedRepoPath -GitArgs @('config','--add','remote.origin.fetch','+refs/heads/*:refs/remotes/origin/*')
    # Reduce gc noise during many fetches/checkouts
    Invoke-Git -Cwd $SharedRepoPath -GitArgs @('config','gc.auto','0')
}
Write-Host "Shared clone ready at $SharedRepoPath in $([math]::Round($step.Elapsed.TotalSeconds,2))s"

# ---------- multi-tag fetch ----------
$step.Restart()
$tags = @($entries.Tag | Sort-Object -Unique)
$missingTags = @()
foreach ($t in $tags) {
    & git -C $SharedRepoPath rev-parse --verify --quiet "refs/tags/$t" *>$null
    if ($LASTEXITCODE -ne 0) { $missingTags += $t }
}
if ($missingTags.Count -gt 0) {
    $chunks = for ($i = 0; $i -lt $missingTags.Count; $i += $FetchChunkSize) {
        ,@($missingTags[$i..([Math]::Min($i+$FetchChunkSize-1, $missingTags.Count-1))])
    }
    $chunkIdx = 0
    foreach ($chunk in $chunks) {
        $chunkIdx++
        $refspecs = $chunk | ForEach-Object { "+refs/tags/${_}:refs/tags/${_}" }
        Write-Host "Fetching chunk $chunkIdx/$($chunks.Count) ($($chunk.Count) tags)..."
        $fetchArgs = @('fetch','--depth=1','--no-tags','origin') + $refspecs
        Invoke-Git -Cwd $SharedRepoPath -GitArgs $fetchArgs
    }
}
Write-Host "Fetched $($missingTags.Count) new tags in $([math]::Round($step.Elapsed.TotalSeconds,2))s ($($tags.Count) total, $($tags.Count - $missingTags.Count) reused)"

# ---------- materialise per-package cache dirs ----------
$step.Restart()
$failed = @()
foreach ($e in $entries) {
    try {
        if (Test-Path (Join-Path $e.CacheDir '.git')) {
            # Already initialised — ensure HEAD matches the desired tag
            $head = (Invoke-Git -Cwd $e.CacheDir -GitArgs @('rev-parse','HEAD')).Trim()
            $want = (Invoke-Git -Cwd $SharedRepoPath -GitArgs @('rev-parse',"refs/tags/$($e.Tag)")).Trim()
            if ($head -eq $want) { continue }
            Invoke-Git -Cwd $e.CacheDir -GitArgs @('-c','advice.detachedHead=false','checkout','--quiet',$e.Tag)
            continue
        }

        if (Test-Path $e.CacheDir) { Remove-Item -Recurse -Force $e.CacheDir }
        New-Item -ItemType Directory -Force -Path $e.CacheDir | Out-Null

        # `git clone --local --shared --no-checkout` reuses the shared object
        # store (alternates) and is effectively instantaneous.
        Invoke-Git -GitArgs @('clone','--quiet','--local','--shared','--no-checkout',$SharedRepoPath,$e.CacheDir)
        # Re-point origin at the real remote so future `test-proxy push` works.
        Invoke-Git -Cwd $e.CacheDir -GitArgs @('remote','set-url','origin',$repoUrl)
        Invoke-Git -Cwd $e.CacheDir -GitArgs @('sparse-checkout','init','--no-cone')
        # Match the sparse-checkout file test-proxy writes
        $sparseFile = Join-Path $e.CacheDir '.git\info\sparse-checkout'
        Set-Content -Path $sparseFile -Value @($e.SparsePath, 'eng/', '.gitignore') -Encoding ascii
        Invoke-Git -Cwd $e.CacheDir -GitArgs @('-c','advice.detachedHead=false','checkout','--quiet',$e.Tag)
    } catch {
        Write-Warning "Failed to restore $($e.Artifact): $($_.Exception.Message)"
        $failed += $e.Artifact
    }
}
Write-Host "Materialised $($entries.Count - $failed.Count) of $($entries.Count) package caches in $([math]::Round($step.Elapsed.TotalSeconds,2))s"

if ($failed.Count -gt 0) {
    Write-Host ""
    Write-Host "##vso[task.logissue type=warning]Restore failed for $($failed.Count) packages: $($failed -join ', ')"
    # Don't fail the build — downstream test-proxy can still retry on demand.
}

$total.Stop()
Write-Host ""
Write-Host "Restore Recordings (shared-clone) total: $([math]::Round($total.Elapsed.TotalSeconds,2))s"
