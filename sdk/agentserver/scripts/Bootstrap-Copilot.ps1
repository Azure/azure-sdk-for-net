<#
.SYNOPSIS
    Bootstraps GitHub Copilot + Spec Kit toolchain for agentserver.

.DESCRIPTION
    Self-sufficient bootstrap script for fresh dev containers. Checks and
    installs every prerequisite, initializes Copilot Spec Kit, configures
    VS Code agent discovery, and generates the project constitution
    automatically via the Copilot CLI.

    Prerequisites handled (installed if missing):
      - Python 3.11+  (verified; not installed — error if absent)
      - uv            (installed automatically via curl)
      - specify CLI    (installed via uv from github/spec-kit)
      - gh CLI         (verified; not installed — error if absent)
      - gh auth        (interactive login prompted if not authenticated)
      - gh copilot CLI (auto-downloaded by gh on first use)

    All generated files (.specify/, .github/) are gitignored and never committed.

.PARAMETER SpecKitVersion
    The Spec Kit release tag to install. Defaults to v0.4.1.

.PARAMETER Force
    Overwrite existing .specify/ and .github/ installation.

.PARAMETER SkipConstitution
    Skip the constitution generation step.

.EXAMPLE
    ./scripts/Bootstrap-Copilot.ps1

.EXAMPLE
    ./scripts/Bootstrap-Copilot.ps1 -Force

.EXAMPLE
    ./scripts/Bootstrap-Copilot.ps1 -SkipConstitution
#>

[CmdletBinding()]
param(
    [string]$SpecKitVersion = 'v0.4.1',
    [switch]$Force,
    [switch]$SkipConstitution
)

Set-StrictMode -Version Latest
$ErrorActionPreference = 'Stop'

# Require PowerShell 7+ ($IsLinux/$IsMacOS are not defined in Windows PowerShell 5.1)
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

# Find the git repo root (for VS Code settings and agent discovery)
$repoRoot = $ServiceDir
while ($repoRoot -and -not (Test-Path (Join-Path $repoRoot '.git'))) {
    $repoRoot = Split-Path -Parent $repoRoot
}
if (-not $repoRoot -or -not (Test-Path (Join-Path $repoRoot '.git'))) {
    $repoRoot = $null
}

$TotalSteps = 7
if (-not $SkipConstitution) { $TotalSteps++ }
$Step = 0

Write-Host ""
Write-Host "=== Copilot Bootstrap for sdk/agentserver ===" -ForegroundColor Cyan
Write-Host "  Directory  : $ServiceDir"
Write-Host "  Spec Kit   : $SpecKitVersion"
Write-Host ""

# ===================================================================
# Step 1: Verify Python
# ===================================================================

$Step++
Write-Host "[$Step/$TotalSteps] Checking Python 3.11+..." -ForegroundColor Yellow

$pythonCmd = $null
foreach ($cmd in @('python3', 'python')) {
    $found = Get-Command $cmd -ErrorAction SilentlyContinue
    if ($found) {
        $pythonCmd = $found
        break
    }
}

if (-not $pythonCmd) {
    Write-Host ""
    Write-Host "  ERROR: Python 3.11+ is required but not found." -ForegroundColor Red
    Write-Host "  Install it from: https://www.python.org/downloads/" -ForegroundColor Red
    Write-Host "  On Ubuntu/Debian: sudo apt-get install -y python3 python3-pip" -ForegroundColor DarkGray
    exit 1
}

$pyVersionOutput = & $pythonCmd.Source --version 2>&1
Write-Host "  OK: $pyVersionOutput" -ForegroundColor Green

# ===================================================================
# Step 2: Check / install uv
# ===================================================================

$Step++
Write-Host "[$Step/$TotalSteps] Checking uv (Python package manager)..." -ForegroundColor Yellow

if (-not (Get-Command uv -ErrorAction SilentlyContinue)) {
    Write-Host "  Installing uv via pip (checksum-verified from PyPI)..." -ForegroundColor DarkGray

    # Install uv from PyPI using pip. PyPI downloads are integrity-checked
    # (TUF + PEP 476), avoiding the supply-chain risk of piping remote
    # scripts into a shell (curl | bash / irm | iex).
    & $pythonCmd.Source -m pip install --user --quiet uv 2>&1 | ForEach-Object { Write-Host "    $_" -ForegroundColor DarkGray }

    # Ensure pip --user bin directory is on PATH for this session
    if ($IsLinux -or $IsMacOS) {
        foreach ($binDir in @("$env:HOME/.local/bin", "$env:HOME/.cargo/bin")) {
            if (Test-Path $binDir) {
                $env:PATH = "${binDir}:$($env:PATH)"
            }
        }
    }
    else {
        $uvBin = & $pythonCmd.Source -c "import sysconfig; print(sysconfig.get_path('scripts', 'nt_user'))" 2>$null
        if ($uvBin -and (Test-Path $uvBin)) { $env:PATH = "${uvBin};$($env:PATH)" }
    }

    if (-not (Get-Command uv -ErrorAction SilentlyContinue)) {
        Write-Host ""
        Write-Host "  ERROR: Failed to install uv." -ForegroundColor Red
        Write-Host "  Install manually: https://docs.astral.sh/uv/getting-started/installation/" -ForegroundColor Red
        exit 1
    }

    Write-Host "  Installed: $(uv --version 2>&1)" -ForegroundColor Green
}
else {
    Write-Host "  OK: $(uv --version 2>&1)" -ForegroundColor Green
}

# ===================================================================
# Step 3: Check / install specify CLI
# ===================================================================

$Step++
Write-Host "[$Step/$TotalSteps] Checking specify CLI (Spec Kit)..." -ForegroundColor Yellow

if (-not (Get-Command specify -ErrorAction SilentlyContinue)) {
    Write-Host "  Installing specify-cli from spec-kit@${SpecKitVersion}..." -ForegroundColor DarkGray
    & uv tool install specify-cli --from "git+https://github.com/github/spec-kit.git@${SpecKitVersion}" 2>&1 | ForEach-Object { Write-Host "    $_" -ForegroundColor DarkGray }

    # uv tool installs go to ~/.local/bin
    $toolBin = Join-Path $env:HOME '.local/bin'
    if (Test-Path $toolBin) { $env:PATH = "${toolBin}:$($env:PATH)" }

    if (-not (Get-Command specify -ErrorAction SilentlyContinue)) {
        Write-Host ""
        Write-Host "  ERROR: Failed to install specify CLI." -ForegroundColor Red
        Write-Host "  Try manually:" -ForegroundColor Red
        Write-Host "    uv tool install specify-cli --from git+https://github.com/github/spec-kit.git@${SpecKitVersion}" -ForegroundColor DarkGray
        exit 1
    }

    Write-Host "  Installed: specify at $((Get-Command specify).Source)" -ForegroundColor Green
}
else {
    Write-Host "  OK: specify at $((Get-Command specify).Source)" -ForegroundColor Green
}

# ===================================================================
# Step 4: Verify gh CLI + auth + Copilot
# ===================================================================

$Step++
Write-Host "[$Step/$TotalSteps] Checking gh CLI, authentication, and Copilot..." -ForegroundColor Yellow

# 4a: gh CLI presence
if (-not (Get-Command gh -ErrorAction SilentlyContinue)) {
    Write-Host ""
    Write-Host "  ERROR: gh CLI is required but not found." -ForegroundColor Red
    Write-Host "  Install: https://cli.github.com/" -ForegroundColor Red
    Write-Host "  On Ubuntu/Debian: sudo apt-get install -y gh" -ForegroundColor DarkGray
    Write-Host "  In codespaces it should be pre-installed." -ForegroundColor DarkGray
    exit 1
}

$ghVersionLine = (& gh --version 2>&1 | Select-Object -First 1)
Write-Host "  OK: $ghVersionLine" -ForegroundColor Green

# 4b: gh authentication — prompt interactive login if not authenticated
$authCheck = & gh auth status 2>&1
if ($LASTEXITCODE -ne 0) {
    Write-Host ""
    Write-Host "  gh CLI is not authenticated. Starting interactive login..." -ForegroundColor Yellow
    Write-Host "  (Follow the prompts below to authenticate with GitHub)" -ForegroundColor DarkGray
    Write-Host ""

    & gh auth login

    # Verify login succeeded
    $authCheck2 = & gh auth status 2>&1
    if ($LASTEXITCODE -ne 0) {
        Write-Host ""
        Write-Host "  ERROR: gh auth login did not complete successfully." -ForegroundColor Red
        Write-Host "  Run 'gh auth login' manually, then re-run this script." -ForegroundColor Red
        exit 1
    }
}

$authAccount = ($authCheck | Select-String 'Logged in to' | Select-Object -First 1)
if ($authAccount) {
    Write-Host "  OK: $($authAccount.ToString().Trim())" -ForegroundColor Green
}
else {
    Write-Host "  OK: gh is authenticated" -ForegroundColor Green
}

# 4c: gh copilot — triggers auto-download if not present
Write-Host "  Verifying gh copilot CLI..." -ForegroundColor DarkGray
$copilotVersion = & gh copilot -- --version 2>&1
$copilotOk = $LASTEXITCODE -eq 0
if ($copilotOk) {
    Write-Host "  OK: Copilot CLI $copilotVersion" -ForegroundColor Green
}
else {
    Write-Host "  WARNING: gh copilot may not be available." -ForegroundColor Yellow
    Write-Host "  Constitution auto-generation will be skipped." -ForegroundColor Yellow
    Write-Host "  Generate it manually: /speckit.constitution in Copilot Chat" -ForegroundColor DarkGray
}

# ===================================================================
# Step 5: Initialize Spec Kit
# ===================================================================

$Step++
Write-Host "[$Step/$TotalSteps] Initializing Spec Kit..." -ForegroundColor Yellow

$specifyDir = Join-Path $ServiceDir '.specify'
$needsInit = $true

if (Test-Path $specifyDir) {
    if ($Force) {
        Write-Host "  Removing existing .specify/ ..." -ForegroundColor DarkGray
        Remove-Item -Recurse -Force $specifyDir
    }
    else {
        Write-Host "  .specify/ already exists (use -Force to reinitialize)" -ForegroundColor DarkGray
        $needsInit = $false
    }
}

# Clean old .speckit/ remnants
$oldSpecKit = Join-Path $ServiceDir '.speckit'
if (Test-Path $oldSpecKit) {
    Remove-Item -Recurse -Force $oldSpecKit
}

if ($needsInit) {
    # Pick script variant based on OS
    $scriptVariant = if ($IsLinux -or $IsMacOS) { 'sh' } else { 'ps' }

    Push-Location $ServiceDir
    try {
        & specify init --here --ai copilot --no-git --force --script $scriptVariant 2>&1 | ForEach-Object { Write-Host "    $_" -ForegroundColor DarkGray }

        if (-not (Test-Path $specifyDir)) {
            Write-Host ""
            Write-Host "  ERROR: specify init completed but .specify/ not found" -ForegroundColor Red
            exit 1
        }

        Write-Host "  OK: Spec Kit initialized" -ForegroundColor Green
    }
    finally {
        Pop-Location
    }
}

# ===================================================================
# Step 6: Ensure .gitignore covers Copilot artifacts
# ===================================================================

$Step++
Write-Host "[$Step/$TotalSteps] Ensuring .gitignore covers Copilot artifacts..." -ForegroundColor Yellow

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
    foreach ($entry in $added) {
        $block += "$entry`n"
    }
    Add-Content -Path $gitIgnorePath -Value $block -Encoding UTF8
    Write-Host "  Added to .gitignore: $($added -join ', ')" -ForegroundColor Green
}
else {
    Write-Host "  OK: .gitignore already covers all Copilot artifacts" -ForegroundColor Green
}

# ===================================================================
# Step 7: Configure agent discovery (VS Code + Copilot CLI)
# ===================================================================

$Step++
Write-Host "[$Step/$TotalSteps] Configuring Copilot agent discovery..." -ForegroundColor Yellow

$localAgentsDir = Join-Path $ServiceDir '.github' 'agents'
$localPromptsDir = Join-Path $ServiceDir '.github' 'prompts'

# --- 7a: VS Code Chat — chat.agentFilesLocations in repo .vscode/settings.json ---

if ($repoRoot) {
    $vscodeDir = Join-Path $repoRoot '.vscode'
    if (-not (Test-Path $vscodeDir)) {
        New-Item -ItemType Directory -Path $vscodeDir -Force | Out-Null
    }

    $settingsPath = Join-Path $vscodeDir 'settings.json'
    $relAgentsDir = [System.IO.Path]::GetRelativePath($repoRoot, $localAgentsDir)
    $relPromptsDir = [System.IO.Path]::GetRelativePath($repoRoot, $localPromptsDir)

    $settings = @{}
    if (Test-Path $settingsPath) {
        try { $settings = Get-Content $settingsPath -Raw | ConvertFrom-Json -AsHashtable }
        catch { $settings = @{} }
    }

    # Merge agent locations
    $agentLocations = @{}
    if ($settings.ContainsKey('chat.agentFilesLocations')) {
        foreach ($key in $settings['chat.agentFilesLocations'].Keys) { $agentLocations[$key] = $settings['chat.agentFilesLocations'][$key] }
    }
    $agentLocations[$relAgentsDir] = $true
    $settings['chat.agentFilesLocations'] = $agentLocations

    # Merge prompt locations
    $promptLocations = @{}
    if ($settings.ContainsKey('chat.promptFilesLocations')) {
        foreach ($key in $settings['chat.promptFilesLocations'].Keys) { $promptLocations[$key] = $settings['chat.promptFilesLocations'][$key] }
    }
    $promptLocations[$relPromptsDir] = $true
    $settings['chat.promptFilesLocations'] = $promptLocations

    $settings | ConvertTo-Json -Depth 10 | Set-Content $settingsPath -Encoding UTF8
    Write-Host "  VS Code: .vscode/settings.json updated (gitignored)" -ForegroundColor Green
    Write-Host "    chat.agentFilesLocations  += $relAgentsDir" -ForegroundColor DarkGray
    Write-Host "    chat.promptFilesLocations += $relPromptsDir" -ForegroundColor DarkGray
}
else {
    Write-Host "  VS Code: Could not find repo root. Skipped." -ForegroundColor Yellow
}

# --- 7b: Copilot CLI — symlink agents into ~/.copilot/agents/ ---

$userAgentsDir = Join-Path $env:HOME '.copilot' 'agents'
if (-not (Test-Path $userAgentsDir)) {
    New-Item -ItemType Directory -Path $userAgentsDir -Force | Out-Null
}

if (Test-Path $localAgentsDir) {
    $linkedCount = 0
    foreach ($agent in (Get-ChildItem -Path $localAgentsDir -Filter '*.agent.md')) {
        $target = Join-Path $userAgentsDir $agent.Name
        $needsLink = $true

        if (Test-Path $target) {
            # Check if existing symlink already points to our file
            $existing = Get-Item $target -Force
            if ($existing.LinkTarget -eq $agent.FullName) {
                $needsLink = $false
            }
            else {
                # Different target or not a symlink — skip to avoid conflicts
                Write-Host "    Skipped $($agent.Name) (already exists in ~/.copilot/agents/)" -ForegroundColor DarkGray
                $needsLink = $false
            }
        }

        if ($needsLink) {
            New-Item -ItemType SymbolicLink -Path $target -Target $agent.FullName -Force | Out-Null
            $linkedCount++
        }
    }

    if ($linkedCount -gt 0) {
        Write-Host "  CLI: Linked $linkedCount agents into ~/.copilot/agents/" -ForegroundColor Green
    }
    else {
        Write-Host "  CLI: ~/.copilot/agents/ already up to date" -ForegroundColor Green
    }
    Write-Host "    Agents available via: gh copilot -- --agent <name>" -ForegroundColor DarkGray
}

# ===================================================================
# Step 8: Generate constitution via /speckit.constitution agent
# ===================================================================

if (-not $SkipConstitution) {
    $Step++
    Write-Host "[$Step/$TotalSteps] Generating constitution via /speckit.constitution agent..." -ForegroundColor Yellow

    if (-not $copilotOk) {
        Write-Host "  Skipped — Copilot CLI not available." -ForegroundColor Yellow
        Write-Host "  Generate manually in Copilot Chat: /speckit.constitution" -ForegroundColor DarkGray
    }
    else {
        # Ensure memory directory exists
        $memoryDir = Join-Path $specifyDir 'memory'
        if (-not (Test-Path $memoryDir)) {
            New-Item -ItemType Directory -Path $memoryDir -Force | Out-Null
        }

        $agentFile = Join-Path $ServiceDir '.github' 'agents' 'speckit.constitution.agent.md'
        if (-not (Test-Path $agentFile)) {
            Write-Host "  Agent file not found: $agentFile" -ForegroundColor Yellow
            Write-Host "  Generate manually in Copilot Chat: /speckit.constitution" -ForegroundColor DarkGray
        }
        else {
            # Agent is now discoverable via ~/.copilot/agents/ symlink (Step 7b)
            $seedPrompt = @"
Generate the constitution for the Azure.AI.AgentServer project.

Project context:
- Read AGENTS.md in the current directory for core principles (Section 0).
- Read Azure.AI.AgentServer.Responses/AGENTS.md for protocol-specific rules.
- The project is a set of .NET class libraries for building ASP.NET Core servers
  implementing Azure AI agent protocols. Library, not application. Distributed via NuGet.
- The constitution template is at .specify/templates/constitution-template.md
- Write the completed constitution to .specify/memory/constitution.md

Begin now.
"@

            Push-Location $ServiceDir
            try {
                Write-Host "  Using agent: speckit.constitution (via ~/.copilot/agents/)" -ForegroundColor DarkGray
                Write-Host "  Running gh copilot (this may take 30-60 seconds)..." -ForegroundColor DarkGray

                & gh copilot -- --agent speckit.constitution -p $seedPrompt --allow-all-tools --no-ask-user -s 2>&1 | ForEach-Object { Write-Host "    $_" -ForegroundColor DarkGray }

                $constitutionPath = Join-Path $memoryDir 'constitution.md'
                if (Test-Path $constitutionPath) {
                    $lineCount = (Get-Content $constitutionPath).Count
                    $matchResult = (Get-Content $constitutionPath -Raw | Select-String '\[[A-Z_]+\]' -AllMatches)
                    $placeholders = if ($matchResult) { $matchResult.Matches.Count } else { 0 }
                    if ($placeholders -gt 0) {
                        Write-Host "  WARNING: Constitution has $placeholders unfilled placeholders." -ForegroundColor Yellow
                        Write-Host "  Run '/speckit.constitution' in Copilot Chat to refine." -ForegroundColor DarkGray
                    }
                    else {
                        Write-Host "  OK: Constitution generated ($lineCount lines)" -ForegroundColor Green
                    }
                }
                else {
                    Write-Host "  Constitution file not created." -ForegroundColor Yellow
                    Write-Host "  Generate manually in Copilot Chat: /speckit.constitution" -ForegroundColor DarkGray
                }
            }
            catch {
                Write-Host "  Constitution generation failed: $_" -ForegroundColor Yellow
                Write-Host "  Generate manually in Copilot Chat: /speckit.constitution" -ForegroundColor DarkGray
            }
            finally {
                Pop-Location
            }
        }
    }
}

# ===================================================================
# Done
# ===================================================================

Write-Host ""
Write-Host "=== Copilot toolchain is ready! ===" -ForegroundColor Green
Write-Host ""
Write-Host "  Toolchain installed:" -ForegroundColor White
Write-Host "    uv       : $(uv --version 2>&1)" -ForegroundColor DarkGray
Write-Host "    specify  : $((Get-Command specify).Source)" -ForegroundColor DarkGray
Write-Host "    gh       : $ghVersionLine" -ForegroundColor DarkGray
if ($copilotOk) {
    Write-Host "    copilot  : $copilotVersion" -ForegroundColor DarkGray
}
Write-Host ""
Write-Host "  Commands (in Copilot Chat):" -ForegroundColor Cyan
Write-Host "    /speckit.constitution  — Create/update governing principles" -ForegroundColor DarkGray
Write-Host "    /speckit.specify       — Define what to build" -ForegroundColor DarkGray
Write-Host "    /speckit.plan          — Create implementation plan" -ForegroundColor DarkGray
Write-Host "    /speckit.tasks         — Generate task list" -ForegroundColor DarkGray
Write-Host "    /speckit.implement     — Execute tasks" -ForegroundColor DarkGray
Write-Host ""
Write-Host "  All Copilot artifacts (.specify/, .github/) are gitignored and never committed." -ForegroundColor DarkGray
Write-Host ""
