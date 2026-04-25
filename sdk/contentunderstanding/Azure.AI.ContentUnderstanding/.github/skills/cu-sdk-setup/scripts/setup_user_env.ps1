# Setup script for Azure AI Content Understanding .NET SDK users (Windows / cross-platform PowerShell).
# Installs prerequisites, collects endpoint + credentials, writes appsettings.json,
# then verifies the resulting setup against the live Foundry endpoint with 5 checks.

[CmdletBinding()]
param(
    [string]$Endpoint = "",
    [string]$ApiKey = "",
    [switch]$VerifyOnly,
    [switch]$NonInteractive,
    [Alias("h")][switch]$Help
)

$ErrorActionPreference = "Stop"

# ─── Paths ────────────────────────────────────────────────────────────────────
$ScriptDir   = Split-Path -Parent $MyInvocation.MyCommand.Path
$PackageRoot = (Resolve-Path (Join-Path $ScriptDir "../../../..")).Path
$AppSettings = Join-Path $PackageRoot "appsettings.json"
$ApiVersion  = "2025-11-01"

# ─── Help ─────────────────────────────────────────────────────────────────────
if ($Help) {
    @"
Azure AI Content Understanding — .NET Setup

Usage: .\setup_user_env.ps1 [options]

Options:
  -Endpoint URL        Override endpoint (skip the endpoint prompt)
  -ApiKey KEY          Override API key (skip the API key prompt)
  -VerifyOnly          Skip install/config phase; only run the 5-check verification
  -NonInteractive      Do not prompt; use existing appsettings.json / env vars / overrides
  -Verbose             Show full HTTP responses during verification (built-in)
  -Help                Show this help

Behavior:
  1. Probe and (optionally) install the .NET SDK.
  2. Detect existing env vars and appsettings.json; ask before overwriting.
  3. Collect endpoint, auth method (DefaultAzureCredential or API key),
     and model deployment names. Probes the Foundry resource for existing
     model defaults to prefill answers when possible.
  4. Write appsettings.json (gitignored).
  5. Run a 5-step verification against the live endpoint and report results.
"@ | Write-Host
    exit 0
}

# ─── Output helpers ───────────────────────────────────────────────────────────
$script:Pass = 0
$script:Fail = 0
function Write-Section { param([string]$Msg) Write-Host ""; Write-Host $Msg -ForegroundColor White }
function Write-Pass    { param([string]$Msg) Write-Host "  ✓ $Msg" -ForegroundColor Green;  $script:Pass++ }
function Write-FailMsg { param([string]$Msg) Write-Host "  ✗ $Msg" -ForegroundColor Red;    $script:Fail++ }
function Write-WarnMsg { param([string]$Msg) Write-Host "  ⚠ $Msg" -ForegroundColor Yellow }
function Write-Info    { param([string]$Msg) Write-Host "  $Msg" -ForegroundColor DarkGray }
function Write-Fix     { param([string]$Msg) Write-Host "    Fix: $Msg" -ForegroundColor Yellow }

function Read-PromptDefault {
    param([string]$PromptText, [string]$Default = "")
    $suffix = if ($Default) { " [$Default]" } else { "" }
    $val = Read-Host "  $PromptText$suffix"
    if ([string]::IsNullOrWhiteSpace($val)) { return $Default }
    return $val
}

# ─── Phase 1: .NET SDK probe / install ────────────────────────────────────────
function Test-DotNet {
    $cmd = Get-Command dotnet -ErrorAction SilentlyContinue
    if (-not $cmd) { return @{ Ok = $false; Reason = "missing"; Version = "" } }
    try {
        $v = & dotnet --version 2>$null
        if (-not $v) { return @{ Ok = $false; Reason = "missing"; Version = "" } }
        $major = [int]($v -split '\.')[0]
        if ($major -lt 8) { return @{ Ok = $false; Reason = "too_old"; Version = $v } }
        return @{ Ok = $true; Version = $v }
    } catch {
        return @{ Ok = $false; Reason = "missing"; Version = "" }
    }
}

function Install-DotNet {
    if (Get-Command winget -ErrorAction SilentlyContinue) {
        Write-Host "    Running: winget install Microsoft.DotNet.SDK.10"
        $proc = Start-Process -FilePath winget -ArgumentList @("install","--exact","--id","Microsoft.DotNet.SDK.10","--accept-source-agreements","--accept-package-agreements") -NoNewWindow -PassThru -Wait
        if ($proc.ExitCode -ne 0) { return $false }
    } else {
        Write-Host "    winget not available; using the official install script."
        $tmp = Join-Path ([System.IO.Path]::GetTempPath()) "dotnet-install.ps1"
        Invoke-WebRequest -Uri https://dot.net/v1/dotnet-install.ps1 -OutFile $tmp -UseBasicParsing
        & $tmp -Channel 10.0 -InstallDir "$env:USERPROFILE\.dotnet"
        $env:PATH = "$env:USERPROFILE\.dotnet;$env:PATH"
    }
    return $true
}

if (-not $VerifyOnly) {
    Write-Section "Step 1: .NET SDK"
    $probe = Test-DotNet
    if ($probe.Ok) {
        Write-Pass "dotnet $($probe.Version)"
    } else {
        if ($probe.Reason -eq "too_old") {
            Write-WarnMsg "Found .NET SDK $($probe.Version), need 8.0+ (10.0 recommended)."
        } else {
            Write-WarnMsg ".NET SDK not found on PATH."
        }
        if ($NonInteractive) {
            Write-FailMsg ".NET SDK is required. Install it and re-run."
            exit 1
        }
        $reply = Read-Host "  Install .NET SDK 10 now? (y/N)"
        if ($reply -match '^[Yy]$') {
            if (Install-DotNet) {
                $probe2 = Test-DotNet
                if ($probe2.Ok) {
                    Write-Pass "dotnet $($probe2.Version)"
                } else {
                    Write-FailMsg "Install completed but probe still fails. Open a new shell and try again."
                    exit 1
                }
            } else {
                Write-FailMsg "Install failed. Install manually from https://dotnet.microsoft.com/download and re-run."
                exit 1
            }
        } else {
            Write-FailMsg "Install .NET 10 manually then re-run."
            Write-Info "  Windows:  winget install Microsoft.DotNet.SDK.10"
            Write-Info "  macOS:    brew install --cask dotnet-sdk"
            Write-Info "  Linux:    curl -sSL https://dot.net/v1/dotnet-install.sh | bash -s -- --channel 10.0"
            exit 1
        }
    }
}

# ─── Helpers: appsettings.json read/write ─────────────────────────────────────
function Read-AppSetting {
    param([string]$Key, [string]$Default = "")
    if (-not (Test-Path $AppSettings)) { return $Default }
    try {
        $data = Get-Content $AppSettings -Raw | ConvertFrom-Json
        if ($null -ne $data.$Key) { return [string]$data.$Key }
    } catch { }
    return $Default
}

function Write-AppSettings {
    param(
        [string]$Endpoint, [string]$ApiKey,
        [string]$Gpt41, [string]$Gpt41Mini, [string]$Embedding
    )
    $data = [ordered]@{}
    if (Test-Path $AppSettings) {
        try {
            (Get-Content $AppSettings -Raw | ConvertFrom-Json).PSObject.Properties | ForEach-Object {
                $data[$_.Name] = $_.Value
            }
        } catch { }
    }
    $data["CONTENTUNDERSTANDING_ENDPOINT"]            = $Endpoint
    $data["CONTENTUNDERSTANDING_KEY"]                 = $ApiKey
    $data["GPT_4_1_DEPLOYMENT"]                       = $Gpt41
    $data["GPT_4_1_MINI_DEPLOYMENT"]                  = $Gpt41Mini
    $data["TEXT_EMBEDDING_3_LARGE_DEPLOYMENT"]        = $Embedding
    ($data | ConvertTo-Json -Depth 10) | Set-Content -Path $AppSettings -Encoding utf8
}

# ─── Auth helpers (used by probes and verification) ───────────────────────────
function Get-AccessToken {
    if (Get-Command az -ErrorAction SilentlyContinue) {
        try {
            $t = & az account get-access-token --resource "https://cognitiveservices.azure.com" --query accessToken -o tsv 2>$null
            if ($t -and $t -ne "null") { return $t }
        } catch { }
    }
    return $null
}

function Invoke-Cu {
    param([string]$Url, [string]$Token, [string]$Key)
    $headers = @{ "Content-Type" = "application/json" }
    if ($Key)        { $headers["Ocp-Apim-Subscription-Key"] = $Key }
    elseif ($Token)  { $headers["Authorization"] = "Bearer $Token" }
    $start = [DateTime]::Now
    try {
        $resp = Invoke-WebRequest -Uri $Url -Headers $headers -Method GET -UseBasicParsing -TimeoutSec 30 -ErrorAction Stop
        return @{ Code = [int]$resp.StatusCode; Body = $resp.Content; Time = [int]([DateTime]::Now - $start).TotalMilliseconds }
    } catch [System.Net.WebException] {
        $code = if ($_.Exception.Response) { [int]$_.Exception.Response.StatusCode } else { 0 }
        $body = ""
        if ($_.Exception.Response) {
            try { $body = (New-Object System.IO.StreamReader($_.Exception.Response.GetResponseStream())).ReadToEnd() } catch { }
        }
        return @{ Code = $code; Body = $body; Time = [int]([DateTime]::Now - $start).TotalMilliseconds }
    } catch {
        return @{ Code = 0; Body = ""; Time = [int]([DateTime]::Now - $start).TotalMilliseconds }
    }
}

# ─── Phase 2: Collect ─────────────────────────────────────────────────────────
$EndpointFinal  = ""
$ApiKeyFinal    = ""
$Gpt41          = ""
$Gpt41Mini      = ""
$Embedding      = ""
$SkipUpdateDefaults = $false

if (-not $VerifyOnly) {
    Write-Section "Step 2: Existing configuration"

    $existingEndpoint  = Read-AppSetting "CONTENTUNDERSTANDING_ENDPOINT"
    $existingKey       = Read-AppSetting "CONTENTUNDERSTANDING_KEY"
    $existingG1        = Read-AppSetting "GPT_4_1_DEPLOYMENT"
    $existingG1M       = Read-AppSetting "GPT_4_1_MINI_DEPLOYMENT"
    $existingEmb       = Read-AppSetting "TEXT_EMBEDDING_3_LARGE_DEPLOYMENT"

    if (Test-Path $AppSettings) {
        Write-Info "Existing appsettings.json detected at $AppSettings"
        if ($existingEndpoint) { Write-Info "  CONTENTUNDERSTANDING_ENDPOINT = $existingEndpoint" }
        if ($existingKey)      { Write-Info ("  CONTENTUNDERSTANDING_KEY      = " + $existingKey.Substring(0,[Math]::Min(4,$existingKey.Length)) + "…(masked)") }
        if ($existingG1)       { Write-Info "  GPT_4_1_DEPLOYMENT            = $existingG1" }
        if ($existingG1M)      { Write-Info "  GPT_4_1_MINI_DEPLOYMENT       = $existingG1M" }
        if ($existingEmb)      { Write-Info "  TEXT_EMBEDDING_3_LARGE_DEPLOYMENT = $existingEmb" }
    }
    if ($env:CONTENTUNDERSTANDING_ENDPOINT) { Write-WarnMsg "Env var CONTENTUNDERSTANDING_ENDPOINT='$env:CONTENTUNDERSTANDING_ENDPOINT' overrides appsettings.json at runtime." }
    if ($env:CONTENTUNDERSTANDING_KEY)      { Write-WarnMsg "Env var CONTENTUNDERSTANDING_KEY is set; it overrides appsettings.json at runtime." }

    Write-Section "Step 3: Endpoint and credentials"
    if ($Endpoint) {
        $EndpointFinal = $Endpoint.TrimEnd('/')
        Write-Info "Using -Endpoint override: $EndpointFinal"
    } elseif ($NonInteractive) {
        $EndpointFinal = $existingEndpoint.TrimEnd('/')
        if (-not $EndpointFinal) { Write-FailMsg "No endpoint configured (use -Endpoint or run interactively)."; exit 1 }
    } else {
        $EndpointFinal = (Read-PromptDefault "Microsoft Foundry endpoint URL (e.g. https://my-foundry.services.ai.azure.com/)" $existingEndpoint).TrimEnd('/')
        if (-not $EndpointFinal) { Write-FailMsg "Endpoint is required."; exit 1 }
    }

    if ($ApiKey) {
        $ApiKeyFinal = $ApiKey
        Write-Info "Using -ApiKey override (DefaultAzureCredential disabled)."
    } elseif ($NonInteractive) {
        $ApiKeyFinal = $existingKey
    } else {
        Write-Host ""
        Write-Host "  Authentication method:"
        Write-Host "    A) DefaultAzureCredential (recommended; uses 'az login')"
        Write-Host "    B) API Key"
        $choice = Read-Host "  Select [A/b]"
        if ($choice -match '^[Bb]$') {
            $ApiKeyFinal = Read-PromptDefault "API key (CONTENTUNDERSTANDING_KEY)" $existingKey
        } else {
            $ApiKeyFinal = ""
            if (-not (Get-Command az -ErrorAction SilentlyContinue)) {
                Write-WarnMsg "Azure CLI ('az') not found. Install it before running samples that use DefaultAzureCredential."
            } else {
                $null = & az account show 2>$null
                if ($LASTEXITCODE -ne 0) { Write-WarnMsg "Not signed in. Run 'az login' before running samples." }
            }
        }
    }

    # ─── Probe existing model defaults ───────────────────────────────────
    Write-Section "Step 4: Probing existing model defaults"
    $probeRc = 1
    $detectedG1 = ""; $detectedG1M = ""; $detectedEmb = ""
    $token = $null
    if (-not $ApiKeyFinal) { $token = Get-AccessToken }
    if (-not $token -and -not $ApiKeyFinal) {
        Write-WarnMsg "Cannot probe: no access token (run 'az login') and no API key supplied."
        $probeRc = 3
    } else {
        $url = "$EndpointFinal/contentunderstanding/defaults?api-version=$ApiVersion"
        $r = Invoke-Cu -Url $url -Token $token -Key $ApiKeyFinal
        switch ($r.Code) {
            200 {
                try {
                    $body = $r.Body | ConvertFrom-Json
                    $deps = $body.modelDeployments
                    if ($deps) {
                        $detectedG1  = [string]$deps."gpt-4.1"
                        $detectedG1M = [string]$deps."gpt-4.1-mini"
                        $detectedEmb = [string]$deps."text-embedding-3-large"
                    }
                } catch { }
                if ($detectedG1 -and $detectedG1M -and $detectedEmb) { $probeRc = 0 }
                elseif ($detectedG1 -or $detectedG1M -or $detectedEmb) { $probeRc = 10 }
                else { $probeRc = 2 }
            }
            401 { $probeRc = 3 }
            403 { $probeRc = 3 }
            default { $probeRc = 1 }
        }
    }

    switch ($probeRc) {
        0 {
            Write-Pass "All defaults detected: gpt-4.1=$detectedG1, gpt-4.1-mini=$detectedG1M, text-embedding-3-large=$detectedEmb"
            if ($NonInteractive) {
                $Gpt41 = $detectedG1; $Gpt41Mini = $detectedG1M; $Embedding = $detectedEmb
                $SkipUpdateDefaults = $true
            } else {
                $useDetected = Read-Host "  Use these detected values? (Y/n)"
                if ($useDetected -notmatch '^[Nn]$') {
                    $Gpt41 = $detectedG1; $Gpt41Mini = $detectedG1M; $Embedding = $detectedEmb
                    $SkipUpdateDefaults = $true
                }
            }
        }
        10 {
            Write-Info "Partial defaults detected; missing entries will be prompted."
            $Gpt41 = $detectedG1; $Gpt41Mini = $detectedG1M; $Embedding = $detectedEmb
        }
        2  { Write-Info "No model defaults configured on the resource yet (will be set by Sample00_UpdateDefaults)." }
        3  { Write-WarnMsg "Probe authentication failed. Run 'az login' and ensure the 'Cognitive Services User' role is assigned. Continuing with manual entry." }
        default { Write-WarnMsg "Probe failed. Continuing with manual entry." }
    }

    Write-Section "Step 5: Model deployment names"
    $defG1  = if ($existingG1)  { $existingG1 }  else { "gpt-4.1" }
    $defG1M = if ($existingG1M) { $existingG1M } else { "gpt-4.1-mini" }
    $defEmb = if ($existingEmb) { $existingEmb } else { "text-embedding-3-large" }
    if ($NonInteractive) {
        if (-not $Gpt41)     { $Gpt41     = $defG1 }
        if (-not $Gpt41Mini) { $Gpt41Mini = $defG1M }
        if (-not $Embedding) { $Embedding = $defEmb }
    } else {
        if (-not $Gpt41)     { $Gpt41     = Read-PromptDefault "GPT_4_1_DEPLOYMENT"               $defG1 }  else { Write-Host "  Using detected GPT_4_1_DEPLOYMENT=$Gpt41" }
        if (-not $Gpt41Mini) { $Gpt41Mini = Read-PromptDefault "GPT_4_1_MINI_DEPLOYMENT"          $defG1M } else { Write-Host "  Using detected GPT_4_1_MINI_DEPLOYMENT=$Gpt41Mini" }
        if (-not $Embedding) { $Embedding = Read-PromptDefault "TEXT_EMBEDDING_3_LARGE_DEPLOYMENT" $defEmb } else { Write-Host "  Using detected TEXT_EMBEDDING_3_LARGE_DEPLOYMENT=$Embedding" }
    }

    Write-Section "Step 6: Writing appsettings.json"
    Write-AppSettings -Endpoint $EndpointFinal -ApiKey $ApiKeyFinal -Gpt41 $Gpt41 -Gpt41Mini $Gpt41Mini -Embedding $Embedding
    Write-Pass "Wrote $AppSettings"
}

# ─── Phase 4: Verification (5 checks) ─────────────────────────────────────────
$script:Pass = 0
$script:Fail = 0

if ($VerifyOnly) {
    if ($Endpoint) {
        $EndpointFinal = $Endpoint.TrimEnd('/')
    } else {
        $tmpEp = if ($env:CONTENTUNDERSTANDING_ENDPOINT) { $env:CONTENTUNDERSTANDING_ENDPOINT } else { Read-AppSetting "CONTENTUNDERSTANDING_ENDPOINT" }
        $EndpointFinal = $tmpEp.TrimEnd('/')
    }
    if ($ApiKey) {
        $ApiKeyFinal = $ApiKey
    } else {
        $ApiKeyFinal = if ($env:CONTENTUNDERSTANDING_KEY) { $env:CONTENTUNDERSTANDING_KEY } else { Read-AppSetting "CONTENTUNDERSTANDING_KEY" }
    }
}

Write-Host ""
Write-Host "=== Verification ===" -ForegroundColor White

$accessToken = $null
$authMethod  = ""
if ($ApiKeyFinal) {
    $authMethod = "API Key"
} else {
    $accessToken = Get-AccessToken
    if ($accessToken) { $authMethod = "DefaultAzureCredential (az cli)" }
}

Write-Section "[1/5] Credentials"
if (-not $EndpointFinal) {
    Write-FailMsg "CONTENTUNDERSTANDING_ENDPOINT not configured"
    Write-Fix "Re-run this script without -VerifyOnly, or set the value in $AppSettings."
    Write-Host ""; Write-Host "Cannot proceed without an endpoint. Fix and re-run." -ForegroundColor Red; exit 1
} else {
    Write-Pass "Endpoint: $EndpointFinal"
}
if ($authMethod) { Write-Pass "Auth method: $authMethod" }
else {
    Write-FailMsg "No credentials available (no API key, az login failed)"
    Write-Fix "Run 'az login' or set CONTENTUNDERSTANDING_KEY in $AppSettings."
}

Write-Section "[2/5] Endpoint reachable"
$defaultsBody = ""
if (-not $authMethod) {
    Write-FailMsg "Skipped — no valid credentials (fix step 1 first)"
} else {
    $r = Invoke-Cu -Url "$EndpointFinal/contentunderstanding/defaults?api-version=$ApiVersion" -Token $accessToken -Key $ApiKeyFinal
    if ($VerbosePreference -eq 'Continue') { Write-Info "HTTP $($r.Code) ($($r.Time)ms) $($r.Body)" }
    switch ($r.Code) {
        200 { Write-Pass "GET /contentunderstanding/defaults → 200 OK ($($r.Time)ms)"; $defaultsBody = $r.Body }
        401 { Write-FailMsg "HTTP 401 — auth failed"; Write-Fix "Assign 'Cognitive Services User' role; if using API key, verify it in Azure Portal" }
        403 { Write-FailMsg "HTTP 403 — authz failed"; Write-Fix "Assign 'Cognitive Services User' role" }
        404 { Write-FailMsg "HTTP 404 — Content Understanding may not be available in this region"; Write-Fix "https://learn.microsoft.com/azure/ai-services/content-understanding/language-region-support" }
        0   { Write-FailMsg "Connection failed"; Write-Fix "Check endpoint URL: $EndpointFinal" }
        default { Write-FailMsg "HTTP $($r.Code) — Unexpected response" }
    }
}

Write-Section "[3/5] Model deployments"
$required = @("gpt-4.1","gpt-4.1-mini","text-embedding-3-large")
if (-not $defaultsBody) {
    Write-FailMsg "Skipped — could not retrieve defaults"
} else {
    try { $deps = ($defaultsBody | ConvertFrom-Json).modelDeployments } catch { $deps = $null }
    $modelsOk = $true
    foreach ($m in $required) {
        $dep = if ($deps) { [string]$deps.$m } else { "" }
        if ($dep) { Write-Pass "$m → $dep" } else { Write-FailMsg "$m — not mapped"; $modelsOk = $false }
    }
    if (-not $modelsOk) {
        Write-Fix "Run Sample00_UpdateDefaults via cu-sdk-sample-run, or deploy missing models in Microsoft Foundry."
    }
}

Write-Section "[4/5] Prebuilt analyzers"
if (-not $authMethod) {
    Write-FailMsg "Skipped — no valid credentials"
} else {
    $r = Invoke-Cu -Url "$EndpointFinal/contentunderstanding/analyzers?api-version=$ApiVersion" -Token $accessToken -Key $ApiKeyFinal
    if ($r.Code -eq 200) {
        try {
            $items = (($r.Body | ConvertFrom-Json).value)
            $prebuilt = @($items | Where-Object { $_.analyzerId -like "prebuilt-*" } | Select-Object -ExpandProperty analyzerId)
            $preview = ($prebuilt | Select-Object -First 5) -join ", "
            if ($prebuilt.Count -gt 5) { $preview += ", ..." }
            Write-Pass "$($items.Count) analyzers found ($($prebuilt.Count) prebuilt: $preview)"
        } catch {
            Write-FailMsg "Could not parse response"
        }
    } else {
        Write-FailMsg "HTTP $($r.Code) listing analyzers"
    }
}

Write-Section "[5/5] Quick smoke test"
if (-not $authMethod) {
    Write-FailMsg "Skipped — no valid credentials"
} else {
    $r = Invoke-Cu -Url "$EndpointFinal/contentunderstanding/analyzers/prebuilt-read?api-version=$ApiVersion" -Token $accessToken -Key $ApiKeyFinal
    if ($r.Code -eq 200) {
        Write-Pass "prebuilt-read analyzer exists ($($r.Time)ms)"
    } elseif ($r.Code -eq 404) {
        Write-FailMsg "prebuilt-read not found"; Write-Fix "Verify the endpoint region supports Content Understanding."
    } else {
        Write-FailMsg "HTTP $($r.Code) querying prebuilt-read"
    }
}

# ─── Summary ──────────────────────────────────────────────────────────────────
Write-Host ""
$total = $script:Pass + $script:Fail
Write-Host "━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━" -ForegroundColor White
if ($script:Fail -eq 0) {
    Write-Host "Result: $($script:Pass) / $total checks passed ✓" -ForegroundColor Green
    if (-not $VerifyOnly) {
        Write-Host ""
        Write-Host "Next steps:"
        Write-Host "  1. cd $PackageRoot"
        if ($SkipUpdateDefaults) {
            Write-Host "  2. (Skipped) Sample00_UpdateDefaults — defaults already configured."
        } else {
            Write-Host "  2. Configure model defaults (one-time per Foundry resource):"
            Write-Host "       .github\skills\cu-sdk-sample-run\scripts\run_sample.ps1 Sample00_UpdateDefaults -Run"
        }
        Write-Host "  3. Run a sample:"
        Write-Host "       .github\skills\cu-sdk-sample-run\scripts\run_sample.ps1 Sample02_AnalyzeUrl -Run"
    }
} else {
    Write-Host "Result: $($script:Fail) failed, $($script:Pass) passed (out of $total checks)" -ForegroundColor Red
    Write-Host "Fix the issues above and re-run with -VerifyOnly to recheck." -ForegroundColor Yellow
}
Write-Host ""

exit $script:Fail
