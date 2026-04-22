#!/bin/bash
# Azure AI Content Understanding — Setup Check
# Validates endpoint, authentication, model deployments, and prebuilt analyzers.
#
# Usage: ./setup-check.sh [options]
#   --endpoint URL    Override endpoint
#   --api-key KEY     Override API key
#   --verbose         Show full HTTP responses
#   --help, -h        Show help

set -e

# ─── Resolve paths ────────────────────────────────────────────────────────────
SCRIPT_DIR="$(cd "$(dirname "${BASH_SOURCE[0]}")" && pwd)"
PACKAGE_ROOT="$(cd "$SCRIPT_DIR/../../../.." && pwd)"
APPSETTINGS="$PACKAGE_ROOT/appsettings.json"

API_VERSION="2025-11-01"

RED='\033[0;31m'
GREEN='\033[0;32m'
YELLOW='\033[1;33m'
BLUE='\033[0;34m'
CYAN='\033[0;36m'
BOLD='\033[1m'
DIM='\033[2m'
NC='\033[0m'

PASS=0
FAIL=0
TOTAL=5
VERBOSE=false

# ─── Parse arguments ──────────────────────────────────────────────────────────
ENDPOINT_OVERRIDE=""
APIKEY_OVERRIDE=""

show_help() {
    echo "Azure AI Content Understanding — Setup Check"
    echo ""
    echo "Usage: $(basename "$0") [options]"
    echo ""
    echo "Options:"
    echo "  --endpoint URL    Override endpoint (instead of appsettings.json / env)"
    echo "  --api-key KEY     Override API key"
    echo "  --verbose         Show full HTTP responses"
    echo "  --help, -h        Show this help"
    echo ""
    echo "Reads credentials from (in priority order):"
    echo "  1. Command-line flags"
    echo "  2. Environment variables (CONTENTUNDERSTANDING_ENDPOINT, AZURE_CONTENT_UNDERSTANDING_KEY)"
    echo "  3. appsettings.json in the package root"
}

while [[ $# -gt 0 ]]; do
    case $1 in
        --help|-h)
            show_help
            exit 0
            ;;
        --endpoint)
            ENDPOINT_OVERRIDE="$2"
            shift 2
            ;;
        --api-key)
            APIKEY_OVERRIDE="$2"
            shift 2
            ;;
        --verbose)
            VERBOSE=true
            shift
            ;;
        *)
            echo -e "${RED}Unknown option: $1${NC}"
            show_help
            exit 1
            ;;
    esac
done

# ─── Helpers ──────────────────────────────────────────────────────────────────
pass() { echo -e "  ${GREEN}✓${NC} $1"; PASS=$((PASS + 1)); }
fail() { echo -e "  ${RED}✗${NC} $1"; FAIL=$((FAIL + 1)); }
info() { echo -e "  ${DIM}$1${NC}"; }
fix()  { echo -e "    ${YELLOW}Fix:${NC} $1"; }

# Read a key from appsettings.json (requires python3 or jq)
read_appsetting() {
    local key="$1"
    local default="$2"
    if [ -f "$APPSETTINGS" ]; then
        if command -v python3 &>/dev/null; then
            python3 -c "import json; d=json.load(open('$APPSETTINGS')); print(d.get('$key',''))" 2>/dev/null || echo "$default"
        elif command -v jq &>/dev/null; then
            jq -r ".$key // empty" "$APPSETTINGS" 2>/dev/null || echo "$default"
        else
            echo "$default"
        fi
    else
        echo "$default"
    fi
}

# Get an access token via Azure CLI (DefaultAzureCredential-style)
get_access_token() {
    # Try az cli first
    if command -v az &>/dev/null; then
        local token
        token=$(az account get-access-token --resource "https://cognitiveservices.azure.com" --query accessToken -o tsv 2>/dev/null || echo "")
        if [ -n "$token" ] && [ "$token" != "null" ]; then
            echo "$token"
            return 0
        fi
    fi
    # Try azd cli
    if command -v azd &>/dev/null; then
        local token
        token=$(azd auth token --scope "https://cognitiveservices.azure.com/.default" 2>/dev/null || echo "")
        if [ -n "$token" ] && [ "$token" != "null" ]; then
            echo "$token"
            return 0
        fi
    fi
    echo ""
}

# Make an authenticated HTTP GET request; sets RESP_CODE, RESP_BODY, RESP_TIME
http_get() {
    local url="$1"
    local tmpfile
    tmpfile=$(mktemp)

    local auth_header=""
    if [ -n "$API_KEY" ]; then
        auth_header="Ocp-Apim-Subscription-Key: $API_KEY"
    elif [ -n "$ACCESS_TOKEN" ]; then
        auth_header="Authorization: Bearer $ACCESS_TOKEN"
    fi

    local start_ms
    start_ms=$(($(date +%s%N) / 1000000))

    RESP_CODE=$(curl -s -o "$tmpfile" -w "%{http_code}" \
        -H "Content-Type: application/json" \
        ${auth_header:+-H "$auth_header"} \
        "$url" 2>/dev/null) || RESP_CODE="000"

    local end_ms
    end_ms=$(($(date +%s%N) / 1000000))
    RESP_TIME=$((end_ms - start_ms))

    RESP_BODY=$(cat "$tmpfile")
    rm -f "$tmpfile"
}

# ─── Resolve credentials ─────────────────────────────────────────────────────
# Priority: flags > env > appsettings.json
ENDPOINT="${ENDPOINT_OVERRIDE:-${CONTENTUNDERSTANDING_ENDPOINT:-$(read_appsetting CONTENTUNDERSTANDING_ENDPOINT "")}}"
API_KEY="${APIKEY_OVERRIDE:-${AZURE_CONTENT_UNDERSTANDING_KEY:-$(read_appsetting AZURE_CONTENT_UNDERSTANDING_KEY "")}}"

# Ensure trailing slash is stripped for consistent URL building
ENDPOINT="${ENDPOINT%/}"

ACCESS_TOKEN=""
AUTH_METHOD=""

echo ""
echo -e "${BOLD}=== Azure AI Content Understanding — Setup Check ===${NC}"

# ─── Check 1: Credentials ────────────────────────────────────────────────────
echo ""
echo -e "${BLUE}[1/$TOTAL] Credentials${NC}"

check1_passed=true
if [ -z "$ENDPOINT" ]; then
    fail "CONTENTUNDERSTANDING_ENDPOINT not configured"
    fix "Create appsettings.json in $PACKAGE_ROOT with:"
    echo -e "    ${DIM}{ \"CONTENTUNDERSTANDING_ENDPOINT\": \"https://your-foundry.services.ai.azure.com/\" }${NC}"
    fix "Or: export CONTENTUNDERSTANDING_ENDPOINT=\"https://your-foundry.services.ai.azure.com/\""
    check1_passed=false
else
    pass "Endpoint: $ENDPOINT"
fi

if [ -n "$API_KEY" ]; then
    AUTH_METHOD="API Key"
    pass "Auth method: API Key"
else
    # Try to get token
    echo -ne "  ${DIM}Acquiring token via Azure CLI...${NC}\r"
    ACCESS_TOKEN=$(get_access_token)
    echo -ne "                                           \r"
    if [ -n "$ACCESS_TOKEN" ]; then
        AUTH_METHOD="DefaultAzureCredential (az cli)"
        pass "Auth method: $AUTH_METHOD"
    else
        AUTH_METHOD=""
        fail "No credentials available (no API key, az/azd login failed)"
        fix "Run 'az login' or 'azd login', or set AZURE_CONTENT_UNDERSTANDING_KEY"
        check1_passed=false
    fi
fi

if [ "$check1_passed" = false ]; then
    FAIL=$((FAIL > 0 ? FAIL : FAIL))
    # Can't proceed without credentials
    if [ -z "$ENDPOINT" ]; then
        echo ""
        echo -e "${RED}Cannot proceed without an endpoint. Fix check 1 and re-run.${NC}"
        echo ""
        exit 1
    fi
fi

# ─── Check 2: Endpoint reachable ─────────────────────────────────────────────
echo ""
echo -e "${BLUE}[2/$TOTAL] Endpoint reachable${NC}"

if [ -z "$AUTH_METHOD" ]; then
    fail "Skipped — no valid credentials (fix check 1 first)"
else
    DEFAULTS_URL="$ENDPOINT/contentunderstanding/defaults?api-version=$API_VERSION"
    http_get "$DEFAULTS_URL"

    if [ "$VERBOSE" = true ]; then
        info "GET $DEFAULTS_URL"
        info "HTTP $RESP_CODE (${RESP_TIME}ms)"
        info "$RESP_BODY"
    fi

    if [ "$RESP_CODE" = "200" ]; then
        pass "GET /contentunderstanding/defaults → $RESP_CODE OK (${RESP_TIME}ms)"
        DEFAULTS_BODY="$RESP_BODY"
    elif [ "$RESP_CODE" = "401" ] || [ "$RESP_CODE" = "403" ]; then
        fail "HTTP $RESP_CODE — Authentication/authorization failed"
        fix "Ensure you have the 'Cognitive Services User' role on your Foundry resource"
        fix "If using API key, verify it in Azure Portal → Keys and Endpoint"
        DEFAULTS_BODY=""
    elif [ "$RESP_CODE" = "404" ]; then
        fail "HTTP 404 — Endpoint not found"
        fix "Content Understanding may not be available in this region"
        fix "See: https://learn.microsoft.com/azure/ai-services/content-understanding/language-region-support"
        DEFAULTS_BODY=""
    elif [ "$RESP_CODE" = "000" ]; then
        fail "Connection failed — could not reach endpoint"
        fix "Check the endpoint URL: $ENDPOINT"
        fix "Verify network connectivity (proxy, firewall, VPN)"
        DEFAULTS_BODY=""
    else
        fail "HTTP $RESP_CODE — Unexpected response"
        if [ -n "$RESP_BODY" ]; then
            info "$(echo "$RESP_BODY" | head -3)"
        fi
        DEFAULTS_BODY=""
    fi
fi

# ─── Check 3: Model deployments ──────────────────────────────────────────────
echo ""
echo -e "${BLUE}[3/$TOTAL] Model deployments${NC}"

REQUIRED_MODELS=("gpt-4.1" "gpt-4.1-mini" "text-embedding-3-large")

if [ -z "$DEFAULTS_BODY" ]; then
    fail "Skipped — could not retrieve defaults (fix check 2 first)"
else
    # Parse model deployments from the JSON response
    models_ok=true
    model_count=0

    for model in "${REQUIRED_MODELS[@]}"; do
        # Extract the deployment name for this model
        deployment=""
        if command -v python3 &>/dev/null; then
            deployment=$(python3 -c "
import json, sys
try:
    data = json.loads(sys.stdin.read())
    deployments = data.get('modelDeployments', {})
    print(deployments.get('$model', ''))
except:
    print('')
" <<< "$DEFAULTS_BODY" 2>/dev/null)
        elif command -v jq &>/dev/null; then
            deployment=$(echo "$DEFAULTS_BODY" | jq -r ".modelDeployments[\"$model\"] // empty" 2>/dev/null)
        fi

        if [ -n "$deployment" ]; then
            pass "$model → $deployment"
            model_count=$((model_count + 1))
        else
            fail "$model — not mapped"
            models_ok=false
        fi
    done

    if [ "$models_ok" = false ]; then
        fix "Run Sample00_UpdateDefaults to configure model mappings:"
        echo -e "    ${DIM}.github/skills/cu-sdk-dotnet-sample-run/scripts/run-sample.sh Sample00_UpdateDefaults${NC}"
        fix "Or deploy missing models in Microsoft Foundry → Deployments → Deploy base model"
    fi
fi

# ─── Check 4: Prebuilt analyzers ─────────────────────────────────────────────
echo ""
echo -e "${BLUE}[4/$TOTAL] Prebuilt analyzers${NC}"

if [ -z "$AUTH_METHOD" ]; then
    fail "Skipped — no valid credentials"
else
    ANALYZERS_URL="$ENDPOINT/contentunderstanding/analyzers?api-version=$API_VERSION"
    http_get "$ANALYZERS_URL"

    if [ "$VERBOSE" = true ]; then
        info "GET $ANALYZERS_URL"
        info "HTTP $RESP_CODE (${RESP_TIME}ms)"
    fi

    if [ "$RESP_CODE" = "200" ]; then
        # Count analyzers
        analyzer_names=""
        analyzer_count=0
        if command -v python3 &>/dev/null; then
            eval "$(python3 -c "
import json, sys
try:
    data = json.loads(sys.stdin.read())
    items = data.get('value', [])
    names = [a.get('analyzerId','') for a in items if a.get('analyzerId','').startswith('prebuilt-')]
    print(f'analyzer_count={len(items)}')
    print(f'prebuilt_count={len(names)}')
    preview = ', '.join(names[:5])
    if len(names) > 5:
        preview += ', ...'
    print(f'analyzer_names=\"{preview}\"')
except:
    print('analyzer_count=0')
    print('prebuilt_count=0')
    print('analyzer_names=\"\"')
" <<< "$RESP_BODY" 2>/dev/null)"
        elif command -v jq &>/dev/null; then
            analyzer_count=$(echo "$RESP_BODY" | jq '.value | length' 2>/dev/null || echo 0)
            prebuilt_count=$(echo "$RESP_BODY" | jq '[.value[] | select(.analyzerId | startswith("prebuilt-"))] | length' 2>/dev/null || echo 0)
            analyzer_names=$(echo "$RESP_BODY" | jq -r '[.value[] | select(.analyzerId | startswith("prebuilt-")) | .analyzerId] | .[0:5] | join(", ")' 2>/dev/null || echo "")
        fi

        if [ "${analyzer_count:-0}" -gt 0 ]; then
            pass "${analyzer_count} analyzers found (${prebuilt_count:-?} prebuilt: ${analyzer_names})"
        else
            fail "No analyzers returned"
            fix "This may indicate a service issue. Check the Azure status page."
        fi
    else
        fail "HTTP $RESP_CODE listing analyzers"
        if [ -n "$RESP_BODY" ]; then
            info "$(echo "$RESP_BODY" | head -2)"
        fi
    fi
fi

# ─── Check 5: Quick smoke test ───────────────────────────────────────────────
echo ""
echo -e "${BLUE}[5/$TOTAL] Quick smoke test${NC}"

if [ -z "$AUTH_METHOD" ]; then
    fail "Skipped — no valid credentials"
else
    # Try to GET a known prebuilt analyzer
    SMOKE_URL="$ENDPOINT/contentunderstanding/analyzers/prebuilt-read?api-version=$API_VERSION"
    http_get "$SMOKE_URL"

    if [ "$VERBOSE" = true ]; then
        info "GET $SMOKE_URL"
        info "HTTP $RESP_CODE (${RESP_TIME}ms)"
    fi

    if [ "$RESP_CODE" = "200" ]; then
        pass "prebuilt-read analyzer exists (${RESP_TIME}ms)"
    elif [ "$RESP_CODE" = "404" ]; then
        fail "prebuilt-read analyzer not found"
        fix "This is unexpected — prebuilt-read should always exist."
        fix "Check that the endpoint region supports Content Understanding."
    else
        fail "HTTP $RESP_CODE querying prebuilt-read"
    fi
fi

# ─── Summary ──────────────────────────────────────────────────────────────────
echo ""
CHECKS=$((PASS + FAIL))
echo -e "${BOLD}━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━${NC}"
if [ $FAIL -eq 0 ]; then
    echo -e "${GREEN}${BOLD}Result: All $TOTAL sections passed ✓  ($CHECKS individual checks)${NC}"
    echo -e "${GREEN}Your environment is ready!${NC}"
else
    echo -e "${RED}${BOLD}Result: $FAIL failed ✗  ($PASS passed, $FAIL failed out of $CHECKS checks)${NC}"
    echo -e "${YELLOW}Fix the issues above and re-run this check.${NC}"
fi
echo ""

exit $FAIL
