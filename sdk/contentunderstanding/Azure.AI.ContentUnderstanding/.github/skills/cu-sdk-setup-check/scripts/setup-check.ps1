# Azure AI Content Understanding — Setup Check
# Validates endpoint, authentication, model deployments, and prebuilt analyzers.
#
# Usage: .\setup-check.ps1 [options]
#   -Endpoint URL     Override endpoint
#   -ApiKey KEY       Override API key
#   -ShowVerbose      Show full HTTP responses
#   -Help             Show help

[CmdletBinding()]
param(
    [string]$Endpoint = "",
    [string]$ApiKey = "",
    [switch]$ShowVerbose,
    [Alias("h")]
    [switch]$Help
)

$ErrorActionPreference = "Stop"

# ─── Resolve paths ────────────────────────────────────────────────────────────
$ScriptDir = Split-Path -Parent $MyInvocation.MyCommand.Path
$PackageRoot = (Resolve-Path (Join-Path $ScriptDir "../../../..")).Path
$AppSettings = Join-Path $PackageRoot "appsettings.json"

$ApiVersion = "2025-11-01"
$Total = 5
$Pass = 0
$Fail = 0

# ─── Help ─────────────────────────────────────────────────────────────────────
if ($Help) {
    Write-Host "Azure AI Content Understanding — Setup Check"
    Write-Host ""
    Write-Host "Usage: .\setup-check.ps1 [options]"
    Write-Host ""
    Write-Host "Options:"
    Write-Host "  -Endpoint URL    Override endpoint (instead of appsettings.json / env)"
    Write-Host "  -ApiKey KEY      Override API key"
    Write-Host "  -ShowVerbose     Show full HTTP responses"
    Write-Host "  -Help            Show this help"
    Write-Host ""
    Write-Host "Reads credentials from (in priority order):"
    Write-Host "  1. Command-line parameters"
    Write-Host "  2. Environment variables (CONTENTUNDERSTANDING_ENDPOINT, AZURE_CONTENT_UNDERSTANDING_KEY)"
    Write-Host "  3. appsettings.json in the package root"
    exit 0
}

# ─── Helpers ──────────────────────────────────────────────────────────────────
function Write-Pass  { param([string]$Msg) Write-Host "  ✓ $Msg" -ForegroundColor Green;  $script:Pass++ }
function Write-Fail  { param([string]$Msg) Write-Host "  ✗ $Msg" -ForegroundColor Red;    $script:Fail++ }
function Write-Fix   { param([string]$Msg) Write-Host "    Fix: $Msg" -ForegroundColor Yellow }
function Write-Info  { param([string]$Msg) Write-Host "  $Msg" -ForegroundColor DarkGray }

function Read-AppSetting {
    param([string]$Key, [string]$Default = "")
    if (Test-Path $AppSettings) {
        try {
            $data = Get-Content $AppSettings -Raw | ConvertFrom-Json
            $val = $data.$Key
            if ($val) { return $val }
        } catch {}
    }
    return $Default
}

function Get-AccessToken {
    # Try az cli
    if (Get-Command az -ErrorAction SilentlyContinue) {
        try {
            $token = az account get-access-token --resource "https://cognitiveservices.azure.com" --query accessToken -o tsv 2>$null
            if ($token -and $token -ne "null") { return $token }
        } catch {}
    }
    # Try azd cli
    if (Get-Command azd -ErrorAction SilentlyContinue) {
        try {
            $token = azd auth token --scope "https://cognitiveservices.azure.com/.default" 2>$null
            if ($token -and $token -ne "null") { return $token }
        } catch {}
    }
    return ""
}

function Invoke-ApiGet {
    param([string]$Url)

    $headers = @{ "Content-Type" = "application/json" }
    if ($script:ResolvedApiKey) {
        $headers["Ocp-Apim-Subscription-Key"] = $script:ResolvedApiKey
    } elseif ($script:AccessToken) {
        $headers["Authorization"] = "Bearer $($script:AccessToken)"
    }

    $sw = [System.Diagnostics.Stopwatch]::StartNew()
    try {
        $response = Invoke-WebRequest -Uri $Url -Headers $headers -Method Get -UseBasicParsing -ErrorAction Stop
        $sw.Stop()
        return @{
            StatusCode = $response.StatusCode
            Body       = $response.Content
            TimeMs     = $sw.ElapsedMilliseconds
        }
    } catch {
        $sw.Stop()
        $statusCode = 0
        $body = ""
        if ($_.Exception.Response) {
            $statusCode = [int]$_.Exception.Response.StatusCode
            try {
                $stream = $_.Exception.Response.GetResponseStream()
                $reader = New-Object System.IO.StreamReader($stream)
                $body = $reader.ReadToEnd()
                $reader.Close()
            } catch {
                $body = $_.Exception.Message
            }
        } else {
            $body = $_.Exception.Message
        }
        return @{
            StatusCode = $statusCode
            Body       = $body
            TimeMs     = $sw.ElapsedMilliseconds
        }
    }
}

# ─── Resolve credentials ─────────────────────────────────────────────────────
$script:ResolvedEndpoint = if ($Endpoint) { $Endpoint }
    elseif ($env:CONTENTUNDERSTANDING_ENDPOINT) { $env:CONTENTUNDERSTANDING_ENDPOINT }
    else { Read-AppSetting "CONTENTUNDERSTANDING_ENDPOINT" "" }

$script:ResolvedApiKey = if ($ApiKey) { $ApiKey }
    elseif ($env:AZURE_CONTENT_UNDERSTANDING_KEY) { $env:AZURE_CONTENT_UNDERSTANDING_KEY }
    else { Read-AppSetting "AZURE_CONTENT_UNDERSTANDING_KEY" "" }

# Strip trailing slash
$script:ResolvedEndpoint = $script:ResolvedEndpoint.TrimEnd('/')

$script:AccessToken = ""
$script:AuthMethod = ""

Write-Host ""
Write-Host "=== Azure AI Content Understanding — Setup Check ===" -ForegroundColor White

# ─── Check 1: Credentials ────────────────────────────────────────────────────
Write-Host ""
Write-Host "[1/$Total] Credentials" -ForegroundColor Blue

$check1Passed = $true
if (-not $script:ResolvedEndpoint) {
    Write-Fail "CONTENTUNDERSTANDING_ENDPOINT not configured"
    Write-Fix "Create appsettings.json in $PackageRoot with:"
    Write-Info '  { "CONTENTUNDERSTANDING_ENDPOINT": "https://your-foundry.services.ai.azure.com/" }'
    Write-Fix 'Or: $env:CONTENTUNDERSTANDING_ENDPOINT = "https://your-foundry.services.ai.azure.com/"'
    $check1Passed = $false
} else {
    Write-Pass "Endpoint: $($script:ResolvedEndpoint)"
}

if ($script:ResolvedApiKey) {
    $script:AuthMethod = "API Key"
    Write-Pass "Auth method: API Key"
} else {
    Write-Host "  Acquiring token via Azure CLI..." -ForegroundColor DarkGray -NoNewline
    $script:AccessToken = Get-AccessToken
    Write-Host "`r                                           " -NoNewline
    Write-Host "`r" -NoNewline
    if ($script:AccessToken) {
        $script:AuthMethod = "DefaultAzureCredential (az cli)"
        Write-Pass "Auth method: $($script:AuthMethod)"
    } else {
        $script:AuthMethod = ""
        Write-Fail "No credentials available (no API key, az/azd login failed)"
        Write-Fix "Run 'az login' or 'azd login', or set AZURE_CONTENT_UNDERSTANDING_KEY"
        $check1Passed = $false
    }
}

if (-not $script:ResolvedEndpoint) {
    Write-Host ""
    Write-Host "Cannot proceed without an endpoint. Fix check 1 and re-run." -ForegroundColor Red
    Write-Host ""
    exit 1
}

# ─── Check 2: Endpoint reachable ─────────────────────────────────────────────
Write-Host ""
Write-Host "[2/$Total] Endpoint reachable" -ForegroundColor Blue

$DefaultsBody = ""

if (-not $script:AuthMethod) {
    Write-Fail "Skipped — no valid credentials (fix check 1 first)"
} else {
    $defaultsUrl = "$($script:ResolvedEndpoint)/contentunderstanding/defaults?api-version=$ApiVersion"
    $resp = Invoke-ApiGet -Url $defaultsUrl

    if ($ShowVerbose) {
        Write-Info "GET $defaultsUrl"
        Write-Info "HTTP $($resp.StatusCode) ($($resp.TimeMs)ms)"
        Write-Info $resp.Body
    }

    switch ($resp.StatusCode) {
        200 {
            Write-Pass "GET /contentunderstanding/defaults → 200 OK ($($resp.TimeMs)ms)"
            $DefaultsBody = $resp.Body
        }
        { $_ -eq 401 -or $_ -eq 403 } {
            Write-Fail "HTTP $($resp.StatusCode) — Authentication/authorization failed"
            Write-Fix "Ensure you have the 'Cognitive Services User' role on your Foundry resource"
            Write-Fix "If using API key, verify it in Azure Portal → Keys and Endpoint"
        }
        404 {
            Write-Fail "HTTP 404 — Endpoint not found"
            Write-Fix "Content Understanding may not be available in this region"
            Write-Fix "See: https://learn.microsoft.com/azure/ai-services/content-understanding/language-region-support"
        }
        0 {
            Write-Fail "Connection failed — could not reach endpoint"
            Write-Fix "Check the endpoint URL: $($script:ResolvedEndpoint)"
            Write-Fix "Verify network connectivity (proxy, firewall, VPN)"
        }
        default {
            Write-Fail "HTTP $($resp.StatusCode) — Unexpected response"
            if ($resp.Body) { Write-Info ($resp.Body | Select-Object -First 3) }
        }
    }
}

# ─── Check 3: Model deployments ──────────────────────────────────────────────
Write-Host ""
Write-Host "[3/$Total] Model deployments" -ForegroundColor Blue

$RequiredModels = @("gpt-4.1", "gpt-4.1-mini", "text-embedding-3-large")

if (-not $DefaultsBody) {
    Write-Fail "Skipped — could not retrieve defaults (fix check 2 first)"
} else {
    try {
        $defaults = $DefaultsBody | ConvertFrom-Json
        $deployments = $defaults.modelDeployments

        $modelsOk = $true
        foreach ($model in $RequiredModels) {
            $dep = $deployments.$model
            if ($dep) {
                Write-Pass "$model → $dep"
            } else {
                Write-Fail "$model — not mapped"
                $modelsOk = $false
            }
        }

        if (-not $modelsOk) {
            Write-Fix "Run Sample00_UpdateDefaults to configure model mappings:"
            Write-Info "  .github/skills/sdk-dotnet-sample-run/scripts/run-sample.sh Sample00_UpdateDefaults"
            Write-Fix "Or deploy missing models in Microsoft Foundry → Deployments → Deploy base model"
        }
    } catch {
        Write-Fail "Failed to parse defaults response"
        Write-Info $_.Exception.Message
    }
}

# ─── Check 4: Prebuilt analyzers ─────────────────────────────────────────────
Write-Host ""
Write-Host "[4/$Total] Prebuilt analyzers" -ForegroundColor Blue

if (-not $script:AuthMethod) {
    Write-Fail "Skipped — no valid credentials"
} else {
    $analyzersUrl = "$($script:ResolvedEndpoint)/contentunderstanding/analyzers?api-version=$ApiVersion"
    $resp = Invoke-ApiGet -Url $analyzersUrl

    if ($ShowVerbose) {
        Write-Info "GET $analyzersUrl"
        Write-Info "HTTP $($resp.StatusCode) ($($resp.TimeMs)ms)"
    }

    if ($resp.StatusCode -eq 200) {
        try {
            $data = $resp.Body | ConvertFrom-Json
            $items = $data.value
            $totalCount = $items.Count
            $prebuiltItems = $items | Where-Object { $_.analyzerId -like "prebuilt-*" }
            $prebuiltCount = @($prebuiltItems).Count
            $prebuiltNames = ($prebuiltItems | Select-Object -First 5 | ForEach-Object { $_.analyzerId }) -join ", "
            if ($prebuiltCount -gt 5) { $prebuiltNames += ", ..." }

            if ($totalCount -gt 0) {
                Write-Pass "$totalCount analyzers found ($prebuiltCount prebuilt: $prebuiltNames)"
            } else {
                Write-Fail "No analyzers returned"
                Write-Fix "This may indicate a service issue. Check the Azure status page."
            }
        } catch {
            Write-Fail "Failed to parse analyzers response"
            Write-Info $_.Exception.Message
        }
    } else {
        Write-Fail "HTTP $($resp.StatusCode) listing analyzers"
        if ($resp.Body) { Write-Info ($resp.Body.Substring(0, [Math]::Min(200, $resp.Body.Length))) }
    }
}

# ─── Check 5: Quick smoke test ───────────────────────────────────────────────
Write-Host ""
Write-Host "[5/$Total] Quick smoke test" -ForegroundColor Blue

if (-not $script:AuthMethod) {
    Write-Fail "Skipped — no valid credentials"
} else {
    $smokeUrl = "$($script:ResolvedEndpoint)/contentunderstanding/analyzers/prebuilt-read?api-version=$ApiVersion"
    $resp = Invoke-ApiGet -Url $smokeUrl

    if ($ShowVerbose) {
        Write-Info "GET $smokeUrl"
        Write-Info "HTTP $($resp.StatusCode) ($($resp.TimeMs)ms)"
    }

    if ($resp.StatusCode -eq 200) {
        Write-Pass "prebuilt-read analyzer exists ($($resp.TimeMs)ms)"
    } elseif ($resp.StatusCode -eq 404) {
        Write-Fail "prebuilt-read analyzer not found"
        Write-Fix "This is unexpected — prebuilt-read should always exist."
        Write-Fix "Check that the endpoint region supports Content Understanding."
    } else {
        Write-Fail "HTTP $($resp.StatusCode) querying prebuilt-read"
    }
}

# ─── Summary ──────────────────────────────────────────────────────────────────
Write-Host ""
$Checks = $Pass + $Fail
Write-Host ("━" * 50) -ForegroundColor White
if ($Fail -eq 0) {
    Write-Host "Result: All $Total sections passed ✓  ($Checks individual checks)" -ForegroundColor Green
    Write-Host "Your environment is ready!" -ForegroundColor Green
} else {
    Write-Host "Result: $Fail failed ✗  ($Pass passed, $Fail failed out of $Checks checks)" -ForegroundColor Red
    Write-Host "Fix the issues above and re-run this check." -ForegroundColor Yellow
}
Write-Host ""

exit $Fail
