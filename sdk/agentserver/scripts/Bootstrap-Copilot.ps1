<#
.SYNOPSIS
    Sets up the Copilot development environment for sdk/agentserver.

.DESCRIPTION
    Idempotent bootstrap script that configures everything a developer needs
    for AI-assisted development on the AgentServer libraries. Safe to re-run
    at any time — each step auto-detects whether work is needed and skips
    what is already up-to-date.

    What it sets up:
      1. Prerequisites (Python 3.11+, uv, gh CLI, gh auth, Copilot CLI)
      2. Copilot context — injects AGENTS.md into VS Code custom instructions
         and validates Copilot CLI auto-discovery (both surfaces: Chat + CLI)
      3. Gitignore — ensures local-only artifacts are never committed
      4. Copilot CLI agent symlinks — spec-kit slash commands in ~/.copilot/agents/
      5. Spec Kit (optional) — specify CLI + project scaffold for spec-driven workflows

    All local artifacts (.specify/, .github/) are gitignored and never committed.

.PARAMETER Force
    Force re-initialization of Spec Kit (.specify/) even if it already exists.

.PARAMETER SkipSpecKit
    Skip Spec Kit installation and initialization entirely. Useful if you
    only want Copilot context setup without the spec-driven workflow.

.PARAMETER Clean
    Remove all files and directories created by this script, then exit.
    Does not uninstall tools (uv, gh, specify CLI). A subsequent run
    without -Clean will regenerate everything from scratch.

.EXAMPLE
    # From PowerShell:
    ./scripts/Bootstrap-Copilot.ps1

.EXAMPLE
    # From bash (e.g., dev containers):
    pwsh -File scripts/Bootstrap-Copilot.ps1

.EXAMPLE
    # Force re-initialize Spec Kit:
    pwsh -File scripts/Bootstrap-Copilot.ps1 -Force

.EXAMPLE
    # Copilot context only, no Spec Kit:
    pwsh -File scripts/Bootstrap-Copilot.ps1 -SkipSpecKit

.EXAMPLE
    # Remove all generated files (clean slate):
    pwsh -File scripts/Bootstrap-Copilot.ps1 -Clean
#>

[CmdletBinding()]
param(
    [switch]$Force,
    [switch]$SkipSpecKit,
    [switch]$Clean
)

Set-StrictMode -Version Latest
$ErrorActionPreference = 'Stop'

# ---------------------------------------------------------------------------
# Constants
# ---------------------------------------------------------------------------

# Spec Kit version this script expects. Upgraded here, not via parameter.
$script:RequiredSpecKitVersion = '0.5.0'
$script:RequiredSpecKitTag = "v$script:RequiredSpecKitVersion"

# Foundry SDK specs repo — used by AGENTS.md for protocol contract documents.
# This is an EMU-auth repo; cloning will silently skip if access is denied.
$script:SpecsRepoUrl = 'https://github.com/rapida_microsoft/foundrysdk_specs.git'
$script:SpecsRepoBranch = 'rapida/hosted-agent-container-spec'
$script:SpecsLocalPath = '/tmp/foundrysdk_specs'

# ---------------------------------------------------------------------------
# Require PowerShell 7+
# ---------------------------------------------------------------------------

if ($PSVersionTable.PSVersion.Major -lt 7) {
    Write-Error "This script requires PowerShell 7+. Install from https://learn.microsoft.com/powershell/scripting/install/installing-powershell"
    exit 1
}

# ---------------------------------------------------------------------------
# Resolve paths
# ---------------------------------------------------------------------------

$ServiceDir = Split-Path -Parent (Split-Path -Parent $PSScriptRoot)
if (-not (Test-Path (Join-Path $ServiceDir 'Azure.AI.AgentServer.sln'))) {
    $ServiceDir = Resolve-Path (Join-Path $PSScriptRoot '..')
}

$repoRoot = $ServiceDir
while ($repoRoot -and -not (Test-Path (Join-Path $repoRoot '.git'))) {
    $repoRoot = Split-Path -Parent $repoRoot
}
if (-not $repoRoot -or -not (Test-Path (Join-Path $repoRoot '.git'))) {
    $repoRoot = $null
}

# ---------------------------------------------------------------------------
# Clean mode — remove all generated artifacts and exit
# ---------------------------------------------------------------------------

if ($Clean) {
    Write-Host ""
    Write-Host "=== Cleaning Copilot dev environment ===" -ForegroundColor Cyan
    Write-Host "  Directory : $ServiceDir"
    Write-Host ""

    $removed = @()

    # 1. .specify/ (Spec Kit project scaffold, constitution, memory)
    $specifyDir = Join-Path $ServiceDir '.specify'
    if (Test-Path $specifyDir) {
        Remove-Item -Recurse -Force $specifyDir
        $removed += '.specify/'
    }

    # 2. .speckit/ (legacy remnant)
    $oldSpecKit = Join-Path $ServiceDir '.speckit'
    if (Test-Path $oldSpecKit) {
        Remove-Item -Recurse -Force $oldSpecKit
        $removed += '.speckit/'
    }

    # 3. .github/ (local agents + prompts created by Spec Kit init)
    $localGithub = Join-Path $ServiceDir '.github'
    if (Test-Path $localGithub) {
        Remove-Item -Recurse -Force $localGithub
        $removed += '.github/'
    }

    # 4. ~/.copilot/agents/speckit.* symlinks (only those pointing into our ServiceDir)
    $userAgentsDir = Join-Path $env:HOME '.copilot' 'agents'
    if (Test-Path $userAgentsDir) {
        $symlinkCount = 0
        foreach ($link in (Get-ChildItem -Path $userAgentsDir -Filter 'speckit.*')) {
            $target = $link.LinkTarget
            if ($target -and $target.StartsWith($ServiceDir)) {
                Remove-Item -Force $link.FullName
                $symlinkCount++
            }
        }
        if ($symlinkCount -gt 0) {
            $removed += "~/.copilot/agents/ ($symlinkCount speckit symlinks)"
        }
    }

    # 5. VS Code settings.json — remove agentserver-specific entries
    if ($repoRoot) {
        $settingsPath = Join-Path $repoRoot '.vscode' 'settings.json'
        if (Test-Path $settingsPath) {
            try {
                $settings = Get-Content $settingsPath -Raw | ConvertFrom-Json -AsHashtable
                $modified = $false

                # Remove agentserver AGENTS.md from codeGeneration.instructions
                if ($settings.ContainsKey('github.copilot.chat.codeGeneration.instructions')) {
                    $filtered = @()
                    foreach ($item in $settings['github.copilot.chat.codeGeneration.instructions']) {
                        if ($item -is [hashtable] -and $item.ContainsKey('file')) {
                            $normalized = $item['file'] -replace '\\', '/'
                            if ($normalized -like '*/agentserver/*' -or $normalized -like '*/agentserver/AGENTS.md') {
                                $modified = $true
                                continue
                            }
                        }
                        $filtered += $item
                    }
                    if ($filtered.Count -gt 0) {
                        $settings['github.copilot.chat.codeGeneration.instructions'] = $filtered
                    }
                    else {
                        $settings.Remove('github.copilot.chat.codeGeneration.instructions')
                    }
                }

                # Remove agentserver agent/prompt file locations
                foreach ($key in @('chat.agentFilesLocations', 'chat.promptFilesLocations')) {
                    if ($settings.ContainsKey($key)) {
                        $locations = @{}
                        foreach ($loc in $settings[$key].Keys) {
                            if ($loc -notlike '*agentserver*') {
                                $locations[$loc] = $settings[$key][$loc]
                            }
                            else {
                                $modified = $true
                            }
                        }
                        if ($locations.Count -gt 0) {
                            $settings[$key] = $locations
                        }
                        else {
                            $settings.Remove($key)
                        }
                    }
                }

                if ($modified) {
                    if ($settings.Count -gt 0) {
                        $settings | ConvertTo-Json -Depth 10 | Set-Content $settingsPath -Encoding UTF8
                    }
                    else {
                        Remove-Item $settingsPath -Force
                    }
                    $removed += '.vscode/settings.json (agentserver entries)'
                }
            }
            catch {
                Write-Host "  WARNING: Could not clean settings.json: $_" -ForegroundColor Yellow
            }
        }
    }

    # 6. Specs repo clone
    $specsDir = $script:SpecsLocalPath
    if (Test-Path $specsDir) {
        Remove-Item -Recurse -Force $specsDir
        $removed += $specsDir
    }

    # 7. Temp files from constitution generation
    foreach ($tmpFile in @(
        (Join-Path ([System.IO.Path]::GetTempPath()) 'copilot-constitution-prompt.txt'),
        (Join-Path ([System.IO.Path]::GetTempPath()) 'copilot-constitution.sh')
    )) {
        if (Test-Path $tmpFile) { Remove-Item -Force $tmpFile }
    }

    Write-Host ""
    if ($removed.Count -gt 0) {
        Write-Host "  Removed:" -ForegroundColor Green
        foreach ($item in $removed) {
            Write-Host "    - $item" -ForegroundColor DarkGray
        }
    }
    else {
        Write-Host "  Nothing to clean — environment was already clean." -ForegroundColor DarkGray
    }
    Write-Host ""
    Write-Host "  Run without -Clean to regenerate everything." -ForegroundColor DarkGray
    Write-Host ""
    exit 0
}

# ---------------------------------------------------------------------------
# Helpers
# ---------------------------------------------------------------------------

function Write-Step {
    param([string]$Message)
    $script:Step++
    Write-Host "[$script:Step/$script:TotalSteps] $Message" -ForegroundColor Yellow
}

function Write-Ok {
    param([string]$Message)
    Write-Host "  OK: $Message" -ForegroundColor Green
}

function Write-Skipped {
    param([string]$Message)
    Write-Host "  Skipped: $Message" -ForegroundColor DarkGray
}

function Write-Detail {
    param([string]$Message)
    Write-Host "  $Message" -ForegroundColor DarkGray
}

function Get-SpecifyVersion {
    # Parse version from 'uv tool list' output (e.g., "specify-cli v0.5.0")
    $output = uv tool list 2>$null | Select-String 'specify-cli'
    if ($output -and $output.ToString() -match 'v?(\d+\.\d+\.\d+)') {
        return $Matches[1]
    }
    return $null
}

# ---------------------------------------------------------------------------
# Calculate steps
# ---------------------------------------------------------------------------

$script:TotalSteps = 6  # prereqs, context, gitignore, symlinks, verify, specs sync
if (-not $SkipSpecKit) { $script:TotalSteps += 2 }  # +specify CLI, +spec kit init
$script:Step = 0

Write-Host ""
Write-Host "=== Copilot Dev Setup for sdk/agentserver ===" -ForegroundColor Cyan
Write-Host "  Directory : $ServiceDir"
Write-Host ""

# ===================================================================
# Step 1: Verify prerequisites (Python, uv, gh, Copilot CLI)
# ===================================================================

Write-Step "Checking prerequisites..."

# --- Python ---
$pythonCmd = $null
foreach ($cmd in @('python3', 'python')) {
    $found = Get-Command $cmd -ErrorAction SilentlyContinue
    if ($found) { $pythonCmd = $found; break }
}
if (-not $pythonCmd) {
    Write-Host "  ERROR: Python 3.11+ is required but not found." -ForegroundColor Red
    Write-Host "  Install: https://www.python.org/downloads/" -ForegroundColor Red
    exit 1
}
Write-Detail "Python   : $($pythonCmd.Source) ($(& $pythonCmd.Source --version 2>&1))"

# --- uv ---
if (-not (Get-Command uv -ErrorAction SilentlyContinue)) {
    Write-Detail "Installing uv via pip..."
    & $pythonCmd.Source -m pip install --user --quiet uv 2>&1 | ForEach-Object { Write-Detail "  $_" }

    if ($IsLinux -or $IsMacOS) {
        foreach ($binDir in @("$env:HOME/.local/bin", "$env:HOME/.cargo/bin")) {
            if (Test-Path $binDir) { $env:PATH = "${binDir}:$($env:PATH)" }
        }
    }
    else {
        $uvBin = & $pythonCmd.Source -c "import sysconfig; print(sysconfig.get_path('scripts', 'nt_user'))" 2>$null
        if ($uvBin -and (Test-Path $uvBin)) { $env:PATH = "${uvBin};$($env:PATH)" }
    }

    if (-not (Get-Command uv -ErrorAction SilentlyContinue)) {
        Write-Host "  ERROR: Failed to install uv." -ForegroundColor Red
        Write-Host "  Install manually: https://docs.astral.sh/uv/getting-started/installation/" -ForegroundColor Red
        exit 1
    }
    Write-Detail "uv       : installed ($(uv --version 2>&1))"
}
else {
    Write-Detail "uv       : $(uv --version 2>&1)"
}

# --- gh CLI ---
if (-not (Get-Command gh -ErrorAction SilentlyContinue)) {
    Write-Host "  ERROR: gh CLI is required but not found." -ForegroundColor Red
    Write-Host "  Install: https://cli.github.com/" -ForegroundColor Red
    exit 1
}
$ghVersionLine = (& gh --version 2>&1 | Select-Object -First 1)
Write-Detail "gh       : $ghVersionLine"

# --- gh auth ---
$authCheck = & gh auth status 2>&1
if ($LASTEXITCODE -ne 0) {
    Write-Host ""
    Write-Host "  gh CLI is not authenticated. Starting interactive login..." -ForegroundColor Yellow
    & gh auth login
    $authCheck2 = & gh auth status 2>&1
    if ($LASTEXITCODE -ne 0) {
        Write-Host "  ERROR: gh auth login did not complete successfully." -ForegroundColor Red
        exit 1
    }
}
$authAccount = ($authCheck | Select-String 'Logged in to' | Select-Object -First 1)
if ($authAccount) {
    Write-Detail "gh auth  : $($authAccount.ToString().Trim())"
}

# --- Copilot CLI ---
$copilotVersion = & gh copilot -- --version 2>&1
$copilotOk = $LASTEXITCODE -eq 0
if ($copilotOk) {
    Write-Detail "copilot  : $copilotVersion"
}
else {
    Write-Host "  WARNING: Copilot CLI not available. Constitution generation will be manual." -ForegroundColor Yellow
}

Write-Ok "All prerequisites satisfied"

# ===================================================================
# Step 2: Configure Copilot context (AGENTS.md injection)
# ===================================================================

Write-Step "Configuring Copilot context (AGENTS.md)..."

$contextConfigured = $false

# --- 2a: VS Code Chat — github.copilot.chat.codeGeneration.instructions ---

if ($repoRoot) {
    $vscodeDir = Join-Path $repoRoot '.vscode'
    if (-not (Test-Path $vscodeDir)) {
        New-Item -ItemType Directory -Path $vscodeDir -Force | Out-Null
    }

    $settingsPath = Join-Path $vscodeDir 'settings.json'
    $rootAgentsMd = Join-Path $ServiceDir 'AGENTS.md'
    $relRootAgentsMd = [System.IO.Path]::GetRelativePath($repoRoot, $rootAgentsMd) -replace '\\', '/'

    $settings = @{}
    if (Test-Path $settingsPath) {
        try { $settings = Get-Content $settingsPath -Raw | ConvertFrom-Json -AsHashtable }
        catch { $settings = @{} }
    }

    # Check if AGENTS.md is already in instructions
    $alreadyInjected = $false
    if ($settings.ContainsKey('github.copilot.chat.codeGeneration.instructions')) {
        $existing = $settings['github.copilot.chat.codeGeneration.instructions']
        if ($existing -is [System.Collections.IEnumerable]) {
            foreach ($item in $existing) {
                if ($item -is [hashtable] -and $item.ContainsKey('file')) {
                    $normalized = $item['file'] -replace '\\', '/'
                    if ($normalized -eq $relRootAgentsMd) {
                        $alreadyInjected = $true
                        break
                    }
                }
            }
        }
    }

    if (-not $alreadyInjected) {
        # Build clean instructions array (strip old agentserver entries, add current)
        $instructions = @()
        if ($settings.ContainsKey('github.copilot.chat.codeGeneration.instructions')) {
            $existing = $settings['github.copilot.chat.codeGeneration.instructions']
            if ($existing -is [System.Collections.IEnumerable]) {
                foreach ($item in $existing) {
                    if ($item -is [hashtable] -and $item.ContainsKey('file')) {
                        $normalized = $item['file'] -replace '\\', '/'
                        if ($normalized -notlike '*/agentserver/*/AGENTS.md' -and $normalized -notlike '*/agentserver/AGENTS.md') {
                            $instructions += $item
                        }
                    }
                    else {
                        $instructions += $item
                    }
                }
            }
        }

        $instructions += @{ file = $relRootAgentsMd }
        $settings['github.copilot.chat.codeGeneration.instructions'] = $instructions

        $settings | ConvertTo-Json -Depth 10 | Set-Content $settingsPath -Encoding UTF8
        Write-Detail "VS Code Chat: injected $relRootAgentsMd into codeGeneration.instructions"
        $contextConfigured = $true
    }
    else {
        Write-Detail "VS Code Chat: AGENTS.md already in codeGeneration.instructions"
    }
}
else {
    Write-Host "  WARNING: Could not find git repo root. VS Code settings skipped." -ForegroundColor Yellow
}

# --- 2b: Copilot CLI — auto-discovers AGENTS.md from working directory ---

Write-Detail "Copilot CLI: auto-discovers AGENTS.md when run from sdk/agentserver/"
Write-Detail "Per-protocol AGENTS.md files loaded on demand (see AGENTS.md Section 1)"

if ($contextConfigured) {
    Write-Ok "AGENTS.md context configured for both VS Code Chat and Copilot CLI"
}
else {
    Write-Ok "AGENTS.md context already configured"
}

# ===================================================================
# Step 3: Ensure .gitignore covers local artifacts
# ===================================================================

Write-Step "Checking .gitignore..."

$gitIgnorePath = Join-Path $ServiceDir '.gitignore'
$copilotIgnoreEntries = @('.specify/', '.speckit/', '.github/')
$gitIgnoreContent = if (Test-Path $gitIgnorePath) { Get-Content $gitIgnorePath -Raw } else { '' }
$added = @()

foreach ($entry in $copilotIgnoreEntries) {
    $pattern = [regex]::Escape($entry)
    if ($gitIgnoreContent -notmatch "(?m)^$pattern") {
        $added += $entry
    }
}

if ($added.Count -gt 0) {
    $block = "`n# Copilot + Spec Kit — local-only files (never committed)`n"
    $block += "# Bootstrap with: ./scripts/Bootstrap-Copilot.ps1`n"
    foreach ($entry in $added) { $block += "$entry`n" }
    Add-Content -Path $gitIgnorePath -Value $block -Encoding UTF8
    Write-Ok "Added to .gitignore: $($added -join ', ')"
}
else {
    Write-Ok ".gitignore already covers all local artifacts"
}

# ===================================================================
# Step 4: Configure Copilot agent symlinks
# ===================================================================

Write-Step "Configuring Copilot agent symlinks..."

$localAgentsDir = Join-Path $ServiceDir '.github' 'agents'
$userAgentsDir = Join-Path $env:HOME '.copilot' 'agents'
if (-not (Test-Path $userAgentsDir)) {
    New-Item -ItemType Directory -Path $userAgentsDir -Force | Out-Null
}

# Also register agent/prompt locations in VS Code settings
if ($repoRoot) {
    $settingsPath = Join-Path $repoRoot '.vscode' 'settings.json'
    $settings = @{}
    if (Test-Path $settingsPath) {
        try { $settings = Get-Content $settingsPath -Raw | ConvertFrom-Json -AsHashtable }
        catch { $settings = @{} }
    }

    $localPromptsDir = Join-Path $ServiceDir '.github' 'prompts'
    $relAgentsDir = [System.IO.Path]::GetRelativePath($repoRoot, $localAgentsDir)
    $relPromptsDir = [System.IO.Path]::GetRelativePath($repoRoot, $localPromptsDir)

    $needsWrite = $false

    # Agent locations
    $agentLocations = @{}
    if ($settings.ContainsKey('chat.agentFilesLocations')) {
        foreach ($key in $settings['chat.agentFilesLocations'].Keys) { $agentLocations[$key] = $settings['chat.agentFilesLocations'][$key] }
    }
    if (-not $agentLocations.ContainsKey($relAgentsDir)) {
        $agentLocations[$relAgentsDir] = $true
        $needsWrite = $true
    }
    $settings['chat.agentFilesLocations'] = $agentLocations

    # Prompt locations
    $promptLocations = @{}
    if ($settings.ContainsKey('chat.promptFilesLocations')) {
        foreach ($key in $settings['chat.promptFilesLocations'].Keys) { $promptLocations[$key] = $settings['chat.promptFilesLocations'][$key] }
    }
    if (-not $promptLocations.ContainsKey($relPromptsDir)) {
        $promptLocations[$relPromptsDir] = $true
        $needsWrite = $true
    }
    $settings['chat.promptFilesLocations'] = $promptLocations

    if ($needsWrite) {
        $settings | ConvertTo-Json -Depth 10 | Set-Content $settingsPath -Encoding UTF8
        Write-Detail "VS Code: registered agent + prompt file locations"
    }
}

# Symlink agents for Copilot CLI
if (Test-Path $localAgentsDir) {
    $linkedCount = 0
    $upToDate = 0
    foreach ($agent in (Get-ChildItem -Path $localAgentsDir -Filter '*.agent.md')) {
        $target = Join-Path $userAgentsDir $agent.Name
        if (Test-Path $target) {
            $existing = Get-Item $target -Force
            if ($existing.LinkTarget -eq $agent.FullName) {
                $upToDate++
                continue
            }
            else {
                Write-Detail "Skipped $($agent.Name) (already exists in ~/.copilot/agents/ from another source)"
                continue
            }
        }
        New-Item -ItemType SymbolicLink -Path $target -Target $agent.FullName -Force | Out-Null
        $linkedCount++
    }

    if ($linkedCount -gt 0) {
        Write-Ok "Linked $linkedCount agents into ~/.copilot/agents/"
    }
    elseif ($upToDate -gt 0) {
        Write-Ok "All $upToDate agent symlinks already up to date"
    }
    else {
        Write-Skipped "No agent files found in .github/agents/ (run Spec Kit init first)"
    }
}
else {
    Write-Skipped "No .github/agents/ directory yet (created by Spec Kit init)"
}

# ===================================================================
# Step 5: Verify Copilot context
# ===================================================================

Write-Step "Verifying Copilot context..."

$agentsMdPath = Join-Path $ServiceDir 'AGENTS.md'
if (Test-Path $agentsMdPath) {
    Write-Ok "AGENTS.md found at $agentsMdPath"
}
else {
    Write-Host "  ERROR: AGENTS.md not found at $agentsMdPath" -ForegroundColor Red
    exit 1
}

# Check for per-protocol AGENTS.md files
$protocolFiles = @()
foreach ($subDir in (Get-ChildItem -Path $ServiceDir -Directory -Filter 'Azure.AI.AgentServer.*')) {
    $protoAgents = Join-Path $subDir.FullName 'AGENTS.md'
    if (Test-Path $protoAgents) { $protocolFiles += $subDir.Name }
}
if ($protocolFiles.Count -gt 0) {
    Write-Detail "Per-protocol AGENTS.md found: $($protocolFiles -join ', ')"
    Write-Detail "These are loaded on demand when modifying those packages (see AGENTS.md Section 1)"
}

Write-Ok "Context ready for both VS Code Chat and Copilot CLI"

# ===================================================================
# Step 6: Sync Foundry SDK specs repo
# ===================================================================

Write-Step "Syncing Foundry SDK specs..."

$specsDir = $script:SpecsLocalPath
$needsClone = $false
$needsPull = $false

if (-not (Test-Path (Join-Path $specsDir '.git'))) {
    $needsClone = $true
}
else {
    # Verify it's the right repo and branch
    $remoteUrl = & git -C $specsDir remote get-url origin 2>$null
    $currentBranch = & git -C $specsDir branch --show-current 2>$null
    if ($remoteUrl -ne $script:SpecsRepoUrl -or $currentBranch -ne $script:SpecsRepoBranch) {
        Write-Detail "Stale clone detected (wrong remote/branch) — re-cloning..."
        Remove-Item -Recurse -Force $specsDir
        $needsClone = $true
    }
    else {
        $needsPull = $true
    }
}

if ($needsClone) {
    Write-Detail "Cloning $($script:SpecsRepoUrl) ($($script:SpecsRepoBranch))..."
    $cloneOutput = & git clone --branch $script:SpecsRepoBranch --single-branch --depth 1 $script:SpecsRepoUrl $specsDir 2>&1
    if ($LASTEXITCODE -ne 0) {
        $errorText = $cloneOutput -join ' '
        if ($errorText -match 'could not read Username|Authentication failed|Permission denied|403|404') {
            Write-Host "  WARNING: No access to specs repo (EMU auth required). Spec docs will not be available locally." -ForegroundColor Yellow
            Write-Detail "Repo: $($script:SpecsRepoUrl)"
            Write-Detail "This is optional — the library builds and tests without it."
        }
        else {
            Write-Host "  WARNING: git clone failed: $errorText" -ForegroundColor Yellow
        }
    }
    else {
        Write-Ok "Specs cloned to $specsDir"
    }
}
elseif ($needsPull) {
    Write-Detail "Pulling latest from $($script:SpecsRepoBranch)..."
    $pullOutput = & git -C $specsDir pull --ff-only 2>&1
    if ($LASTEXITCODE -ne 0) {
        Write-Detail "Pull failed (non-fatal): $pullOutput"
        Write-Detail "Using existing local copy"
    }
    else {
        Write-Ok "Specs updated ($specsDir)"
    }
}

# Verify spec docs are present
$specsDocsDir = Join-Path $specsDir 'specs' 'hosted-agents' 'container-spec' 'docs'
if (Test-Path $specsDocsDir) {
    $specFiles = (Get-ChildItem -Path $specsDocsDir -Filter '*.md' -File).Count
    Write-Detail "$specFiles spec documents found in $specsDocsDir"
}
else {
    Write-Detail "Spec docs not available (EMU auth may be required)"
}

# ===================================================================
# Steps 7-8: Spec Kit (optional)
# ===================================================================

if (-not $SkipSpecKit) {

    # --- Step 7: Install / upgrade specify CLI ---

    Write-Step "Checking Spec Kit CLI (specify)..."

    $currentVersion = Get-SpecifyVersion
    $needsInstall = $false

    if (-not (Get-Command specify -ErrorAction SilentlyContinue)) {
        Write-Detail "specify CLI not found — installing v$script:RequiredSpecKitVersion..."
        $needsInstall = $true
    }
    elseif ($null -eq $currentVersion) {
        Write-Detail "Could not determine specify version — reinstalling..."
        $needsInstall = $true
    }
    elseif ($currentVersion -ne $script:RequiredSpecKitVersion) {
        Write-Detail "specify v$currentVersion installed, upgrading to v$script:RequiredSpecKitVersion..."
        $needsInstall = $true
    }
    else {
        Write-Ok "specify v$currentVersion (up to date)"
    }

    if ($needsInstall) {
        & uv tool install specify-cli --from "git+https://github.com/github/spec-kit.git@$script:RequiredSpecKitTag" --force 2>&1 | ForEach-Object { Write-Detail "  $_" }

        $toolBin = Join-Path $env:HOME '.local/bin'
        if (Test-Path $toolBin) { $env:PATH = "${toolBin}:$($env:PATH)" }

        if (-not (Get-Command specify -ErrorAction SilentlyContinue)) {
            Write-Host "  ERROR: Failed to install specify CLI." -ForegroundColor Red
            Write-Host "  Try: uv tool install specify-cli --from git+https://github.com/github/spec-kit.git@$script:RequiredSpecKitTag" -ForegroundColor Red
            exit 1
        }

        Write-Ok "specify v$script:RequiredSpecKitVersion installed"
    }

    # --- Step 8: Initialize Spec Kit project ---

    Write-Step "Initializing Spec Kit project..."

    $specifyDir = Join-Path $ServiceDir '.specify'

    # Clean old .speckit/ remnants
    $oldSpecKit = Join-Path $ServiceDir '.speckit'
    if (Test-Path $oldSpecKit) {
        Remove-Item -Recurse -Force $oldSpecKit
        Write-Detail "Cleaned up legacy .speckit/ directory"
    }

    $needsInit = $false
    if (-not (Test-Path $specifyDir)) {
        $needsInit = $true
    }
    elseif ($Force) {
        Write-Detail "Removing existing .specify/ (-Force)..."
        Remove-Item -Recurse -Force $specifyDir
        $needsInit = $true
    }
    else {
        Write-Skipped ".specify/ already exists (use -Force to reinitialize)"
    }

    if ($needsInit) {
        $scriptVariant = if ($IsLinux -or $IsMacOS) { 'sh' } else { 'ps' }

        Push-Location $ServiceDir
        try {
            & specify init --here --ai copilot --no-git --force --script $scriptVariant 2>&1 | ForEach-Object { Write-Detail "  $_" }

            if (-not (Test-Path $specifyDir)) {
                Write-Host "  ERROR: specify init completed but .specify/ not found" -ForegroundColor Red
                exit 1
            }

            Write-Ok "Spec Kit project initialized"
        }
        finally {
            Pop-Location
        }
    }

    # --- Constitution: auto-generate if missing or still the unfilled template ---

    $constitutionPath = Join-Path $specifyDir 'memory' 'constitution.md'
    $constitutionIsTemplate = $false
    if (Test-Path $constitutionPath) {
        $content = Get-Content $constitutionPath -Raw
        # The template shipped by specify init has [PROJECT_NAME] and [PRINCIPLE_*] placeholders
        if ($content -match '\[PROJECT_NAME\]' -or $content -match '\[PRINCIPLE_1_NAME\]') {
            $constitutionIsTemplate = $true
            Write-Detail "Constitution is still the unfilled template — generating..."
        }
        else {
            $lineCount = (Get-Content $constitutionPath).Count
            Write-Detail "Constitution exists ($lineCount lines). To regenerate: /speckit.constitution in Chat"
        }
    }

    if (-not (Test-Path $constitutionPath) -or $constitutionIsTemplate) {
        if (-not $copilotOk) {
            Write-Host "  ACTION REQUIRED: Generate your project constitution" -ForegroundColor Yellow
            Write-Host "    Copilot CLI not available. In VS Code Copilot Chat, type: /speckit.constitution" -ForegroundColor White
        }
        else {
            $memoryDir = Join-Path $specifyDir 'memory'
            if (-not (Test-Path $memoryDir)) {
                New-Item -ItemType Directory -Path $memoryDir -Force | Out-Null
            }

            $agentFile = Join-Path $ServiceDir '.github' 'agents' 'speckit.constitution.agent.md'
            if (-not (Test-Path $agentFile)) {
                Write-Host "  ACTION REQUIRED: Generate your project constitution" -ForegroundColor Yellow
                Write-Host "    Agent file not found. In VS Code Copilot Chat, type: /speckit.constitution" -ForegroundColor White
            }
            else {
                # Ensure agent symlinks exist in ~/.copilot/agents/ — Step 4 may
                # have skipped them if .github/agents/ didn't exist yet (first run
                # after -Clean). The Copilot CLI resolves --agent names from there.
                $userAgentsDir = Join-Path $env:HOME '.copilot' 'agents'
                if (-not (Test-Path $userAgentsDir)) {
                    New-Item -ItemType Directory -Path $userAgentsDir -Force | Out-Null
                }
                $localAgentsDir = Join-Path $ServiceDir '.github' 'agents'
                foreach ($agent in (Get-ChildItem -Path $localAgentsDir -Filter '*.agent.md' -ErrorAction SilentlyContinue)) {
                    $target = Join-Path $userAgentsDir $agent.Name
                    if (-not (Test-Path $target)) {
                        New-Item -ItemType SymbolicLink -Path $target -Target $agent.FullName -Force | Out-Null
                    }
                }

                Write-Detail "Generating constitution via Copilot CLI..."

                $seedPrompt = @"
Generate the constitution for the Azure.AI.AgentServer project.
Read AGENTS.md and Azure.AI.AgentServer.Responses/AGENTS.md for protocol rules.
The project is a set of .NET class libraries for building ASP.NET Core servers
implementing Azure AI agent protocols. Library, not application. Distributed via NuGet.
Extract core principles, rules, and constraints that govern the project.
The constitution template is at .specify/templates/constitution-template.md.
Write the completed constitution to .specify/memory/constitution.md.
Begin now.
"@

                Push-Location $ServiceDir
                try {
                    # Write the prompt to a temp file to avoid quoting issues when
                    # shelling out to bash. Copilot CLI needs the native bash process
                    # environment — PowerShell's & operator alters stdio piping in
                    # ways that prevent the agent from writing files.
                    $promptFile = Join-Path ([System.IO.Path]::GetTempPath()) 'copilot-constitution-prompt.txt'
                    $seedPrompt | Set-Content $promptFile -Encoding UTF8 -NoNewline

                    if ($IsLinux -or $IsMacOS) {
                        $scriptFile = Join-Path ([System.IO.Path]::GetTempPath()) 'copilot-constitution.sh'

                        # Build a bash script using [char] codes for special
                        # characters to prevent PowerShell from interpreting
                        # bash syntax. This is the only reliable way to emit
                        # $PROMPT and $(cat ...) as literal bash from PowerShell.
                        $LF = [char]10        # newline
                        $DQ = [char]34        # double quote
                        $DS = [char]36        # dollar sign

                        $scriptContent = "#!/usr/bin/env bash" + $LF
                        $scriptContent += "cd '$ServiceDir'" + $LF
                        $scriptContent += "PROMPT=${DS}(cat '$promptFile')" + $LF
                        $scriptContent += "gh copilot -- --agent speckit.constitution --autopilot --max-autopilot-continues 5 --allow-all --no-ask-user -s -p ${DQ}${DS}PROMPT${DQ}" + $LF

                        Set-Content $scriptFile -Value $scriptContent -Encoding UTF8 -NoNewline
                        & chmod +x $scriptFile

                        & bash $scriptFile
                        Remove-Item $scriptFile -Force -ErrorAction SilentlyContinue
                    }
                    else {
                        # Windows — run directly via PowerShell (best effort)
                        & gh copilot -- --agent speckit.constitution --autopilot --max-autopilot-continues 5 --allow-all --no-ask-user -s -p $seedPrompt 2>&1 | ForEach-Object { Write-Detail "  $_" }
                    }

                    # Clean up temp file
                    Remove-Item $promptFile -Force -ErrorAction SilentlyContinue

                    # Re-read to check if placeholders were filled
                    if (Test-Path $constitutionPath) {
                        $newContent = Get-Content $constitutionPath -Raw
                        if ($newContent -notmatch '\[PROJECT_NAME\]' -and $newContent -notmatch '\[PRINCIPLE_1_NAME\]') {
                            $lineCount = (Get-Content $constitutionPath).Count
                            Write-Ok "Constitution generated ($lineCount lines)"
                        }
                        else {
                            Write-Host "  WARNING: Constitution still has unfilled placeholders." -ForegroundColor Yellow
                            Write-Host "    Refine in Copilot Chat: /speckit.constitution" -ForegroundColor DarkGray
                        }
                    }
                    else {
                        Write-Host "  WARNING: Constitution file not created." -ForegroundColor Yellow
                        Write-Host "    Generate in Copilot Chat: /speckit.constitution" -ForegroundColor DarkGray
                    }
                }
                catch {
                    Write-Host "  WARNING: Constitution generation failed: $_" -ForegroundColor Yellow
                    Write-Host "    Generate in Copilot Chat: /speckit.constitution" -ForegroundColor DarkGray
                }
                finally {
                    Pop-Location
                }
            }
        }
    }
}

# ===================================================================
# Done
# ===================================================================

Write-Host ""
Write-Host "=== Copilot dev environment is ready! ===" -ForegroundColor Green
Write-Host ""
Write-Host "  How to use Copilot with AgentServer:" -ForegroundColor White
Write-Host ""
Write-Host "  VS Code Copilot Chat:" -ForegroundColor Cyan
Write-Host "    AGENTS.md is auto-injected into every chat session" -ForegroundColor DarkGray
Write-Host "    Per-protocol rules loaded on demand when you modify those packages" -ForegroundColor DarkGray
Write-Host ""
Write-Host "  Copilot CLI:" -ForegroundColor Cyan
Write-Host "    cd sdk/agentserver && gh copilot" -ForegroundColor DarkGray
Write-Host "    CLI auto-discovers AGENTS.md from the working directory" -ForegroundColor DarkGray
Write-Host ""
if (-not $SkipSpecKit) {
    Write-Host "  Spec Kit commands (in Copilot Chat or CLI):" -ForegroundColor Cyan
    Write-Host "    /speckit.constitution  — Establish project principles" -ForegroundColor DarkGray
    Write-Host "    /speckit.specify       — Define what to build" -ForegroundColor DarkGray
    Write-Host "    /speckit.plan          — Create implementation plan" -ForegroundColor DarkGray
    Write-Host "    /speckit.tasks         — Generate task list" -ForegroundColor DarkGray
    Write-Host "    /speckit.implement     — Execute tasks" -ForegroundColor DarkGray
    Write-Host ""
}
Write-Host "  Local artifacts (.specify/, .github/) are gitignored and never committed." -ForegroundColor DarkGray
Write-Host ""
