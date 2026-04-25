#!/usr/bin/env bash
# Setup script for Azure AI Content Understanding .NET SDK users.
# Installs prerequisites, collects endpoint + credentials, writes
# appsettings.json, then verifies the resulting setup against the live
# Foundry endpoint with 5 checks.
# cspell:ignore esac dotnetver

set -euo pipefail

# ─── Resolve paths ────────────────────────────────────────────────────────────
SCRIPT_DIR="$(cd "$(dirname "${BASH_SOURCE[0]}")" && pwd)"
PACKAGE_ROOT="$(cd "$SCRIPT_DIR/../../../.." && pwd)"
APPSETTINGS="$PACKAGE_ROOT/appsettings.json"

API_VERSION="2025-11-01"

# ─── Colors ───────────────────────────────────────────────────────────────────
RED='\033[0;31m'
GREEN='\033[0;32m'
YELLOW='\033[1;33m'
BLUE='\033[0;34m'
BOLD='\033[1m'
DIM='\033[2m'
NC='\033[0m'

# ─── Args ─────────────────────────────────────────────────────────────────────
ENDPOINT_OVERRIDE=""
APIKEY_OVERRIDE=""
NON_INTERACTIVE=0
VERIFY_ONLY=0
VERBOSE=0

show_help() {
    cat <<EOF
Azure AI Content Understanding — .NET Setup

Usage: $(basename "$0") [options]

Options:
  --endpoint URL        Override endpoint (skip the endpoint prompt)
  --api-key KEY         Override API key (skip the API key prompt)
  --verify-only         Skip the install/config phase; only run the 5-check verification
  --non-interactive     Do not prompt; use existing appsettings.json / env vars / overrides
  --verbose             Show full HTTP responses during verification
  --help, -h            Show this help

Behavior:
  1. Probe and (optionally) install the .NET SDK.
  2. Detect existing env vars and appsettings.json; ask before overwriting.
  3. Collect endpoint, auth method (DefaultAzureCredential or API key),
     and model deployment names. Probes the Foundry resource for existing
     model defaults to prefill answers when possible.
  4. Write appsettings.json (gitignored).
  5. Run a 5-step verification against the live endpoint and report results.
EOF
}

while [[ $# -gt 0 ]]; do
    case "$1" in
        --help|-h)         show_help; exit 0 ;;
        --endpoint)        ENDPOINT_OVERRIDE="${2:-}"; shift 2 ;;
        --api-key)         APIKEY_OVERRIDE="${2:-}"; shift 2 ;;
        --verify-only)     VERIFY_ONLY=1; shift ;;
        --non-interactive) NON_INTERACTIVE=1; shift ;;
        --verbose)         VERBOSE=1; shift ;;
        *)                 echo -e "${RED}Unknown option: $1${NC}"; show_help; exit 1 ;;
    esac
done

# ─── Output helpers ───────────────────────────────────────────────────────────
section() { echo; echo -e "${BOLD}$1${NC}"; }
pass()    { echo -e "  ${GREEN}✓${NC} $1"; PASS=$((PASS + 1)); }
fail()    { echo -e "  ${RED}✗${NC} $1"; FAIL=$((FAIL + 1)); }
info()    { echo -e "  ${DIM}$1${NC}"; }
warn()    { echo -e "  ${YELLOW}⚠${NC} $1"; }
fix()     { echo -e "    ${YELLOW}Fix:${NC} $1"; }
prompt()  { local p="$1" var=$2 def="${3:-}"; local r=""; if [ -n "$def" ]; then read -r -p "  $p [$def]: " r || r=""; r="${r:-$def}"; else read -r -p "  $p: " r || r=""; fi; printf -v "$var" '%s' "$r"; }

# ─── Phase 1: Probe + install .NET SDK ────────────────────────────────────────
install_dotnet() {
    local os; os="$(uname -s)"
    case "$os" in
        Darwin)
            if command -v brew >/dev/null 2>&1; then
                echo "    Running: brew install --cask dotnet-sdk"
                brew install --cask dotnet-sdk || return 1
            else
                echo "    (Homebrew not found — install from https://brew.sh/ then re-run.)"
                return 1
            fi
            ;;
        Linux)
            echo "    Installing .NET SDK via the official install script..."
            local script="${TMPDIR:-/tmp}/dotnet-install.sh"
            if command -v curl >/dev/null 2>&1; then
                curl -sSL https://dot.net/v1/dotnet-install.sh -o "$script" || return 1
            elif command -v wget >/dev/null 2>&1; then
                wget -qO "$script" https://dot.net/v1/dotnet-install.sh || return 1
            else
                echo "    (Neither curl nor wget available — please install one, or install .NET manually.)"
                return 1
            fi
            chmod +x "$script"
            "$script" --channel 10.0 --install-dir "$HOME/.dotnet" || return 1
            export PATH="$HOME/.dotnet:$PATH"
            ;;
        *)
            echo "    (Unsupported platform for auto-install: $os)"
            return 1
            ;;
    esac
    hash -r 2>/dev/null || true
    return 0
}

probe_dotnet() {
    if ! command -v dotnet >/dev/null 2>&1; then
        return 1
    fi
    local v
    v=$(dotnet --version 2>/dev/null || echo "0.0.0")
    local major="${v%%.*}"
    if [ "$major" -lt 8 ]; then
        echo "  ✗ Found .NET SDK $v, need 8.0+ (10.0 recommended)."
        return 2
    fi
    DOTNET_VERSION="$v"
    return 0
}

if [ "$VERIFY_ONLY" = "0" ]; then
    section "Step 1: .NET SDK"
    DOTNET_VERSION=""
    if probe_dotnet; then
        pass "dotnet $DOTNET_VERSION"
    else
        rc=$?
        if [ "$rc" = "1" ]; then
            warn ".NET SDK not found on PATH."
        fi
        if [ "$NON_INTERACTIVE" = "1" ]; then
            fail ".NET SDK is required. Install it and re-run."
            exit 1
        fi
        echo
        local_reply=""
        read -r -p "  Install .NET SDK 10 now? (y/N): " local_reply || local_reply="n"
        if [[ "$local_reply" =~ ^[Yy]$ ]]; then
            if install_dotnet && probe_dotnet; then
                pass "dotnet $DOTNET_VERSION"
            else
                fail "Install failed. Install manually from https://dotnet.microsoft.com/download and re-run."
                exit 1
            fi
        else
            fail "Install .NET 10 manually then re-run."
            info "  macOS: brew install --cask dotnet-sdk"
            info "  Linux: curl -sSL https://dot.net/v1/dotnet-install.sh | bash -s -- --channel 10.0"
            info "  Windows: winget install Microsoft.DotNet.SDK.10  (use setup_user_env.ps1 instead)"
            exit 1
        fi
    fi
fi

# ─── Helpers: appsettings.json read/write ─────────────────────────────────────
read_appsetting() {
    local key="$1" default="${2:-}"
    if [ ! -f "$APPSETTINGS" ]; then
        printf '%s' "$default"
        return
    fi
    if command -v python3 >/dev/null 2>&1; then
        python3 -c "import json,sys
try:
  print(json.load(open('$APPSETTINGS')).get('$key',''))
except Exception:
  print('$default')" 2>/dev/null
    elif command -v jq >/dev/null 2>&1; then
        jq -r ".$key // \"$default\"" "$APPSETTINGS" 2>/dev/null
    else
        printf '%s' "$default"
    fi
}

write_appsettings() {
    local endpoint="$1" key="$2" gpt41="$3" gpt41mini="$4" embedding="$5"
    if command -v python3 >/dev/null 2>&1; then
        APP_FILE="$APPSETTINGS" \
        EP="$endpoint" KEY="$key" \
        G1="$gpt41" G1M="$gpt41mini" EMB="$embedding" \
        python3 - <<'PY'
import json, os
path = os.environ["APP_FILE"]
data = {}
if os.path.isfile(path):
    try:
        with open(path) as f:
            data = json.load(f) or {}
    except Exception:
        data = {}
data["CONTENTUNDERSTANDING_ENDPOINT"] = os.environ.get("EP", "")
data["CONTENTUNDERSTANDING_KEY"]      = os.environ.get("KEY", "")
data["GPT_4_1_DEPLOYMENT"]            = os.environ.get("G1", "gpt-4.1")
data["GPT_4_1_MINI_DEPLOYMENT"]       = os.environ.get("G1M", "gpt-4.1-mini")
data["TEXT_EMBEDDING_3_LARGE_DEPLOYMENT"] = os.environ.get("EMB", "text-embedding-3-large")
with open(path, "w") as f:
    json.dump(data, f, indent=2)
    f.write("\n")
PY
    else
        # Fallback: emit a fresh file (existing values are lost — warn earlier).
        cat > "$APPSETTINGS" <<EOF
{
  "CONTENTUNDERSTANDING_ENDPOINT": "$endpoint",
  "CONTENTUNDERSTANDING_KEY": "$key",
  "GPT_4_1_DEPLOYMENT": "$gpt41",
  "GPT_4_1_MINI_DEPLOYMENT": "$gpt41mini",
  "TEXT_EMBEDDING_3_LARGE_DEPLOYMENT": "$embedding"
}
EOF
    fi
}

# ─── Phase 2: Detect existing state + collect values ──────────────────────────
ENDPOINT=""
API_KEY=""
GPT41=""
GPT41MINI=""
EMBEDDING=""
SKIP_UPDATE_DEFAULTS=0

if [ "$VERIFY_ONLY" = "0" ]; then
    section "Step 2: Existing configuration"

    EXISTING_ENDPOINT="$(read_appsetting CONTENTUNDERSTANDING_ENDPOINT)"
    EXISTING_KEY="$(read_appsetting CONTENTUNDERSTANDING_KEY)"
    EXISTING_G1="$(read_appsetting GPT_4_1_DEPLOYMENT)"
    EXISTING_G1M="$(read_appsetting GPT_4_1_MINI_DEPLOYMENT)"
    EXISTING_EMB="$(read_appsetting TEXT_EMBEDDING_3_LARGE_DEPLOYMENT)"

    if [ -f "$APPSETTINGS" ]; then
        info "Existing appsettings.json detected at $APPSETTINGS"
        [ -n "$EXISTING_ENDPOINT" ] && info "  CONTENTUNDERSTANDING_ENDPOINT = $EXISTING_ENDPOINT"
        [ -n "$EXISTING_KEY" ]      && info "  CONTENTUNDERSTANDING_KEY      = ${EXISTING_KEY:0:4}…(masked)"
        [ -n "$EXISTING_G1" ]       && info "  GPT_4_1_DEPLOYMENT            = $EXISTING_G1"
        [ -n "$EXISTING_G1M" ]      && info "  GPT_4_1_MINI_DEPLOYMENT       = $EXISTING_G1M"
        [ -n "$EXISTING_EMB" ]      && info "  TEXT_EMBEDDING_3_LARGE_DEPLOYMENT = $EXISTING_EMB"
    fi
    if [ -n "${CONTENTUNDERSTANDING_ENDPOINT:-}" ]; then
        warn "Env var CONTENTUNDERSTANDING_ENDPOINT is set ('$CONTENTUNDERSTANDING_ENDPOINT'). It overrides appsettings.json at runtime."
    fi
    if [ -n "${CONTENTUNDERSTANDING_KEY:-}" ]; then
        warn "Env var CONTENTUNDERSTANDING_KEY is set. It overrides appsettings.json at runtime."
    fi

    section "Step 3: Endpoint and credentials"
    if [ -n "$ENDPOINT_OVERRIDE" ]; then
        ENDPOINT="$ENDPOINT_OVERRIDE"
        info "Using --endpoint override: $ENDPOINT"
    elif [ "$NON_INTERACTIVE" = "1" ]; then
        ENDPOINT="$EXISTING_ENDPOINT"
        [ -z "$ENDPOINT" ] && { fail "No endpoint configured (use --endpoint or run interactively)."; exit 1; }
    else
        prompt "Microsoft Foundry endpoint URL (e.g. https://my-foundry.services.ai.azure.com/)" ENDPOINT "$EXISTING_ENDPOINT"
        ENDPOINT="${ENDPOINT%/}"
        if [ -z "$ENDPOINT" ]; then fail "Endpoint is required."; exit 1; fi
    fi

    if [ -n "$APIKEY_OVERRIDE" ]; then
        API_KEY="$APIKEY_OVERRIDE"
        info "Using --api-key override (DefaultAzureCredential disabled)."
    elif [ "$NON_INTERACTIVE" = "1" ]; then
        API_KEY="$EXISTING_KEY"
    else
        echo
        echo "  Authentication method:"
        echo "    A) DefaultAzureCredential (recommended; uses 'az login')"
        echo "    B) API Key"
        local_choice=""
        read -r -p "  Select [A/b]: " local_choice || local_choice="A"
        if [[ "$local_choice" =~ ^[Bb]$ ]]; then
            prompt "API key (CONTENTUNDERSTANDING_KEY)" API_KEY "$EXISTING_KEY"
        else
            API_KEY=""
            if ! command -v az >/dev/null 2>&1; then
                warn "Azure CLI ('az') not found. Install it before running samples that use DefaultAzureCredential."
            else
                if ! az account show >/dev/null 2>&1; then
                    warn "Not signed in. Run 'az login' before running samples."
                fi
            fi
        fi
    fi

    # ─── Probe existing model defaults on the Foundry resource ───────────
    section "Step 4: Probing existing model defaults"
    PROBE_RC=1
    DEFAULTS_BODY=""
    if [ -z "$API_KEY" ] && command -v az >/dev/null 2>&1; then
        TOKEN="$(az account get-access-token --resource https://cognitiveservices.azure.com --query accessToken -o tsv 2>/dev/null || echo "")"
        AUTH_HEADER="Authorization: Bearer ${TOKEN}"
    elif [ -n "$API_KEY" ]; then
        AUTH_HEADER="Ocp-Apim-Subscription-Key: $API_KEY"
        TOKEN=""
    else
        AUTH_HEADER=""
        TOKEN=""
    fi

    if [ -z "$AUTH_HEADER" ] || { [ -z "${TOKEN:-}" ] && [ -z "$API_KEY" ]; }; then
        warn "Cannot probe: no access token (run 'az login') and no API key supplied."
        PROBE_RC=3
    elif ! command -v curl >/dev/null 2>&1; then
        warn "curl not available; skipping probe."
        PROBE_RC=1
    else
        TMP="$(mktemp)"
        HTTP_CODE=$(curl -sS -o "$TMP" -w "%{http_code}" -m 15 \
            -H "$AUTH_HEADER" -H "Content-Type: application/json" \
            "${ENDPOINT}/contentunderstanding/defaults?api-version=${API_VERSION}" 2>/dev/null || echo "000")
        DEFAULTS_BODY="$(cat "$TMP" 2>/dev/null || true)"
        rm -f "$TMP"
        if [ "$HTTP_CODE" = "200" ]; then
            if command -v python3 >/dev/null 2>&1; then
                eval "$(BODY="$DEFAULTS_BODY" python3 - <<'PY'
import json, os
try:
    body = json.loads(os.environ.get("BODY", "") or "{}")
except Exception:
    body = {}
deps = body.get("modelDeployments", {}) or {}
g1   = (deps.get("gpt-4.1") or "").replace("'", "'\\''")
g1m  = (deps.get("gpt-4.1-mini") or "").replace("'", "'\\''")
emb  = (deps.get("text-embedding-3-large") or "").replace("'", "'\\''")
print(f"DETECTED_G1='{g1}'")
print(f"DETECTED_G1M='{g1m}'")
print(f"DETECTED_EMB='{emb}'")
PY
)"
            fi
            if [ -n "${DETECTED_G1:-}" ] && [ -n "${DETECTED_G1M:-}" ] && [ -n "${DETECTED_EMB:-}" ]; then
                PROBE_RC=0
            elif [ -n "${DETECTED_G1:-}" ] || [ -n "${DETECTED_G1M:-}" ] || [ -n "${DETECTED_EMB:-}" ]; then
                PROBE_RC=10
            else
                PROBE_RC=2
            fi
        elif [ "$HTTP_CODE" = "401" ] || [ "$HTTP_CODE" = "403" ]; then
            PROBE_RC=3
        else
            PROBE_RC=1
        fi
    fi

    case "$PROBE_RC" in
        0)
            pass "All defaults detected: gpt-4.1=$DETECTED_G1, gpt-4.1-mini=$DETECTED_G1M, text-embedding-3-large=$DETECTED_EMB"
            if [ "$NON_INTERACTIVE" = "1" ]; then
                GPT41="$DETECTED_G1"; GPT41MINI="$DETECTED_G1M"; EMBEDDING="$DETECTED_EMB"
                SKIP_UPDATE_DEFAULTS=1
            else
                local_use=""
                read -r -p "  Use these detected values? (Y/n): " local_use || local_use="Y"
                if [[ ! "$local_use" =~ ^[Nn]$ ]]; then
                    GPT41="$DETECTED_G1"; GPT41MINI="$DETECTED_G1M"; EMBEDDING="$DETECTED_EMB"
                    SKIP_UPDATE_DEFAULTS=1
                fi
            fi
            ;;
        10)
            info "Partial defaults detected; missing entries will be prompted."
            GPT41="${DETECTED_G1:-}"
            GPT41MINI="${DETECTED_G1M:-}"
            EMBEDDING="${DETECTED_EMB:-}"
            ;;
        2)
            info "No model defaults configured on the resource yet (will be set by Sample00_UpdateDefaults)."
            ;;
        3)
            warn "Probe authentication failed. Run 'az login' and ensure the 'Cognitive Services User' role is assigned. Continuing with manual entry."
            ;;
        *)
            warn "Probe failed (HTTP $HTTP_CODE). Continuing with manual entry."
            ;;
    esac

    section "Step 5: Model deployment names"
    if [ "$NON_INTERACTIVE" = "1" ]; then
        GPT41="${GPT41:-${EXISTING_G1:-gpt-4.1}}"
        GPT41MINI="${GPT41MINI:-${EXISTING_G1M:-gpt-4.1-mini}}"
        EMBEDDING="${EMBEDDING:-${EXISTING_EMB:-text-embedding-3-large}}"
    else
        if [ -z "$GPT41" ]; then prompt "GPT_4_1_DEPLOYMENT" GPT41 "${EXISTING_G1:-gpt-4.1}"; else echo "  Using detected GPT_4_1_DEPLOYMENT=$GPT41"; fi
        if [ -z "$GPT41MINI" ]; then prompt "GPT_4_1_MINI_DEPLOYMENT" GPT41MINI "${EXISTING_G1M:-gpt-4.1-mini}"; else echo "  Using detected GPT_4_1_MINI_DEPLOYMENT=$GPT41MINI"; fi
        if [ -z "$EMBEDDING" ]; then prompt "TEXT_EMBEDDING_3_LARGE_DEPLOYMENT" EMBEDDING "${EXISTING_EMB:-text-embedding-3-large}"; else echo "  Using detected TEXT_EMBEDDING_3_LARGE_DEPLOYMENT=$EMBEDDING"; fi
    fi

    # ─── Phase 3: Write appsettings.json ─────────────────────────────────
    section "Step 6: Writing appsettings.json"
    write_appsettings "$ENDPOINT" "$API_KEY" "$GPT41" "$GPT41MINI" "$EMBEDDING"
    pass "Wrote $APPSETTINGS"
fi

# ─── Phase 4: Verification (5 checks) ─────────────────────────────────────────
PASS=0
FAIL=0

# In verify-only mode, hydrate creds from overrides → env → appsettings.json
if [ "$VERIFY_ONLY" = "1" ]; then
    ENDPOINT="${ENDPOINT_OVERRIDE:-${CONTENTUNDERSTANDING_ENDPOINT:-$(read_appsetting CONTENTUNDERSTANDING_ENDPOINT)}}"
    API_KEY="${APIKEY_OVERRIDE:-${CONTENTUNDERSTANDING_KEY:-$(read_appsetting CONTENTUNDERSTANDING_KEY)}}"
    ENDPOINT="${ENDPOINT%/}"
fi

echo
echo -e "${BOLD}=== Verification ===${NC}"

# Resolve auth method for verification
ACCESS_TOKEN=""
AUTH_METHOD=""
if [ -n "$API_KEY" ]; then
    AUTH_METHOD="API Key"
elif command -v az >/dev/null 2>&1; then
    ACCESS_TOKEN="$(az account get-access-token --resource https://cognitiveservices.azure.com --query accessToken -o tsv 2>/dev/null || echo "")"
    [ -n "$ACCESS_TOKEN" ] && AUTH_METHOD="DefaultAzureCredential (az cli)"
fi

http_get() {
    local url="$1"
    local tmpfile; tmpfile=$(mktemp)
    local hdr=""
    if [ -n "$API_KEY" ]; then
        hdr="Ocp-Apim-Subscription-Key: $API_KEY"
    elif [ -n "$ACCESS_TOKEN" ]; then
        hdr="Authorization: Bearer $ACCESS_TOKEN"
    fi
    local start_ms; start_ms=$(($(date +%s%N) / 1000000))
    RESP_CODE=$(curl -sS -o "$tmpfile" -w "%{http_code}" -m 30 \
        -H "Content-Type: application/json" \
        ${hdr:+-H "$hdr"} \
        "$url" 2>/dev/null) || RESP_CODE="000"
    local end_ms; end_ms=$(($(date +%s%N) / 1000000))
    RESP_TIME=$((end_ms - start_ms))
    RESP_BODY="$(cat "$tmpfile" 2>/dev/null || true)"
    rm -f "$tmpfile"
}

section "[1/5] Credentials"
if [ -z "$ENDPOINT" ]; then
    fail "CONTENTUNDERSTANDING_ENDPOINT not configured"
    fix "Re-run this script without --verify-only, or set the value in $APPSETTINGS."
    echo; echo -e "${RED}Cannot proceed without an endpoint. Fix and re-run.${NC}"; exit 1
else
    pass "Endpoint: $ENDPOINT"
fi
if [ -n "$AUTH_METHOD" ]; then
    pass "Auth method: $AUTH_METHOD"
else
    fail "No credentials available (no API key, az/azd login failed)"
    fix "Run 'az login' or set CONTENTUNDERSTANDING_KEY in $APPSETTINGS."
fi

section "[2/5] Endpoint reachable"
if [ -z "$AUTH_METHOD" ]; then
    fail "Skipped — no valid credentials (fix step 1 first)"
    DEFAULTS_BODY=""
else
    http_get "${ENDPOINT}/contentunderstanding/defaults?api-version=${API_VERSION}"
    [ "$VERBOSE" = "1" ] && info "HTTP $RESP_CODE (${RESP_TIME}ms) $RESP_BODY"
    case "$RESP_CODE" in
        200) pass "GET /contentunderstanding/defaults → 200 OK (${RESP_TIME}ms)"; DEFAULTS_BODY="$RESP_BODY" ;;
        401|403) fail "HTTP $RESP_CODE — auth/authz failed"; fix "Assign 'Cognitive Services User' role; if using API key, verify it in Azure Portal"; DEFAULTS_BODY="" ;;
        404) fail "HTTP 404 — Content Understanding may not be available in this region"; fix "https://learn.microsoft.com/azure/ai-services/content-understanding/language-region-support"; DEFAULTS_BODY="" ;;
        000) fail "Connection failed"; fix "Check endpoint URL: $ENDPOINT"; DEFAULTS_BODY="" ;;
        *)   fail "HTTP $RESP_CODE — Unexpected response"; DEFAULTS_BODY="" ;;
    esac
fi

section "[3/5] Model deployments"
REQUIRED=("gpt-4.1" "gpt-4.1-mini" "text-embedding-3-large")
if [ -z "$DEFAULTS_BODY" ]; then
    fail "Skipped — could not retrieve defaults"
elif ! command -v python3 >/dev/null 2>&1; then
    info "(python3 not available; skipping deployment parsing)"
else
    models_ok=true
    for m in "${REQUIRED[@]}"; do
        d="$(BODY="$DEFAULTS_BODY" M="$m" python3 -c "import json,os;print((json.loads(os.environ.get('BODY','') or '{}').get('modelDeployments') or {}).get(os.environ['M'],''))" 2>/dev/null)"
        if [ -n "$d" ]; then
            pass "$m → $d"
        else
            fail "$m — not mapped"
            models_ok=false
        fi
    done
    if [ "$models_ok" = "false" ]; then
        fix "Run Sample00_UpdateDefaults via cu-sdk-sample-run, or deploy missing models in Microsoft Foundry."
    fi
fi

section "[4/5] Prebuilt analyzers"
if [ -z "$AUTH_METHOD" ]; then
    fail "Skipped — no valid credentials"
else
    http_get "${ENDPOINT}/contentunderstanding/analyzers?api-version=${API_VERSION}"
    [ "$VERBOSE" = "1" ] && info "HTTP $RESP_CODE (${RESP_TIME}ms)"
    if [ "$RESP_CODE" = "200" ]; then
        if command -v python3 >/dev/null 2>&1; then
            eval "$(BODY="$RESP_BODY" python3 - <<'PY'
import json,os
try:
    items=json.loads(os.environ.get('BODY','') or '{}').get('value',[]) or []
except Exception:
    items=[]
prebuilt=[a.get('analyzerId','') for a in items if a.get('analyzerId','').startswith('prebuilt-')]
print(f"AC={len(items)}")
print(f"PC={len(prebuilt)}")
print("AN=\"" + ", ".join(prebuilt[:5]) + ("..." if len(prebuilt)>5 else "") + "\"")
PY
)"
        fi
        if [ "${AC:-0}" -gt 0 ]; then
            pass "${AC} analyzers found (${PC:-?} prebuilt: ${AN})"
        else
            fail "No analyzers returned"
        fi
    else
        fail "HTTP $RESP_CODE listing analyzers"
    fi
fi

section "[5/5] Quick smoke test"
if [ -z "$AUTH_METHOD" ]; then
    fail "Skipped — no valid credentials"
else
    http_get "${ENDPOINT}/contentunderstanding/analyzers/prebuilt-read?api-version=${API_VERSION}"
    [ "$VERBOSE" = "1" ] && info "HTTP $RESP_CODE (${RESP_TIME}ms)"
    if [ "$RESP_CODE" = "200" ]; then
        pass "prebuilt-read analyzer exists (${RESP_TIME}ms)"
    elif [ "$RESP_CODE" = "404" ]; then
        fail "prebuilt-read not found"
        fix "Verify the endpoint region supports Content Understanding."
    else
        fail "HTTP $RESP_CODE querying prebuilt-read"
    fi
fi

# ─── Summary ──────────────────────────────────────────────────────────────────
echo
TOTAL=$((PASS + FAIL))
echo -e "${BOLD}━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━${NC}"
if [ "$FAIL" = "0" ]; then
    echo -e "${GREEN}${BOLD}Result: $PASS / $TOTAL checks passed ✓${NC}"
    if [ "$VERIFY_ONLY" = "0" ]; then
        echo
        echo "Next steps:"
        echo "  1. cd $PACKAGE_ROOT"
        if [ "$SKIP_UPDATE_DEFAULTS" = "1" ]; then
            echo "  2. (Skipped) Sample00_UpdateDefaults — defaults already configured."
        else
            echo "  2. Configure model defaults (one-time per Foundry resource):"
            echo "       .github/skills/cu-sdk-sample-run/scripts/run_sample.sh Sample00_UpdateDefaults --run"
        fi
        echo "  3. Run a sample:"
        echo "       .github/skills/cu-sdk-sample-run/scripts/run_sample.sh Sample02_AnalyzeUrl --run"
    fi
else
    echo -e "${RED}${BOLD}Result: $FAIL failed, $PASS passed (out of $TOTAL checks)${NC}"
    echo -e "${YELLOW}Fix the issues above and re-run with --verify-only to recheck.${NC}"
fi
echo

exit "$FAIL"
