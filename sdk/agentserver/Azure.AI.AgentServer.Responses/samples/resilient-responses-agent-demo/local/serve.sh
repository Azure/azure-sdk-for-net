#!/usr/bin/env bash
# ─────────────────────────────────────────────────────────────────────────────
# Start the resilient agent locally (.NET) with a file-backed state store — no
# hosted task API — so you can drive it yourself: stream a response, crash it,
# reconnect. See README.md "Manual exploration" for the curl recipe.
#
# Credential-free by default (DEMO_MODE routes: __ECHO_INPUT__, __ECHO_CRASH__,
# __FAIL__, "crash"). For the REAL research path you additionally need:
#   az login
#   export FOUNDRY_PROJECT_ENDPOINT=https://<account>.services.ai.azure.com/api/projects/<project>
#   export AZURE_AI_MODEL_DEPLOYMENT_NAME=gpt-5.4-nano
# ─────────────────────────────────────────────────────────────────────────────
set -euo pipefail

HERE="$(cd "$(dirname "${BASH_SOURCE[0]}")" && pwd)"
PROJ_DIR="$HERE/../src/resilient-responses-agent-demo"
DLL="$PROJ_DIR/bin/Release/net10.0/ResilientResponsesAgentDemo.dll"

if [[ ! -f "$DLL" ]]; then
    echo "Build output not found at $DLL — run ./setup.sh first." >&2
    exit 1
fi

# FOUNDRY_HOSTING_ENVIRONMENT UNSET => the SDK auto-selects the local file-backed
# task + response + stream store rooted at AGENTSERVER_STATE_ROOT. This is what
# removes the hosted /tasks API dependency.
unset FOUNDRY_HOSTING_ENVIRONMENT || true
export AGENTSERVER_STATE_ROOT="${AGENTSERVER_STATE_ROOT:-$HERE/.agentserver}"
# Enables the "crash"/__ECHO_*/__FAIL__ input sentinels.
export DEMO_MODE=1
export PORT="${PORT:-8088}"
export NUM_PHASES="${NUM_PHASES:-3}"
export INTRA_PHASE_COOLDOWN_SEC="${INTRA_PHASE_COOLDOWN_SEC:-1}"
export INTER_PHASE_COOLDOWN_SEC="${INTER_PHASE_COOLDOWN_SEC:-1}"
export TARGET_OUTPUT_TOKENS="${TARGET_OUTPUT_TOKENS:-80}"

PORT="${PORT:-8088}"
if (exec 3<>"/dev/tcp/127.0.0.1/${PORT}") 2>/dev/null; then
    exec 3>&- 3<&-
    echo "Port ${PORT} is already in use (a server may still be running). Stop it, or pick another port: PORT=8090 ./serve.sh" >&2
    exit 1
fi

echo "Starting resilient agent on http://localhost:${PORT}"
echo "  resilient root : ${AGENTSERVER_STATE_ROOT}  (tasks + responses are file-backed here)"
echo "  crash input  : POST /responses with input \"crash\"  (DEMO_MODE=1)"
echo "  echo (no LLM): POST /responses with input \"__ECHO_INPUT__ hello\""
echo "  stop         : Ctrl-C"
exec dotnet "$DLL"
