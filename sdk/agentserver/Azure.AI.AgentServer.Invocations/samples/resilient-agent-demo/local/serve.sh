#!/usr/bin/env bash
# ─────────────────────────────────────────────────────────────────────────────
# Start the resilient research agent locally (.NET) with a file-backed state store
# — no hosted task API — so you can drive it yourself: dispatch a run, stream it,
# crash it, reconnect. See README.md "Manual exploration" for the curl recipe.
#
# Credential-free by default (USE_FAKE_MODEL=1 => synthetic token stream, so the
# full research/crash/recover/steer flow runs with NO Azure login). For the REAL
# model path (parity with the hosted demo) set:
#   az login
#   export FOUNDRY_PROJECT_ENDPOINT=https://<account>.services.ai.azure.com/api/projects/<project>
#   export AZURE_AI_MODEL_DEPLOYMENT_NAME=gpt-5.4-nano
#   export USE_FAKE_MODEL=0
# ─────────────────────────────────────────────────────────────────────────────
set -euo pipefail

HERE="$(cd "$(dirname "${BASH_SOURCE[0]}")" && pwd)"
PROJ_DIR="$HERE/../src/resilient-research-agent"
DLL="$PROJ_DIR/bin/Release/net10.0/ResilientResearchAgentDemo.dll"

if [[ ! -f "$DLL" ]]; then
    echo "Build output not found at $DLL — run ./setup.sh first." >&2
    exit 1
fi

# FOUNDRY_HOSTING_ENVIRONMENT UNSET => the SDK auto-selects the local file-backed
# task + stream store rooted at AGENTSERVER_STATE_ROOT. This is what removes the
# hosted /tasks API dependency.
unset FOUNDRY_HOSTING_ENVIRONMENT || true
export AGENTSERVER_STATE_ROOT="${AGENTSERVER_STATE_ROOT:-$HERE/.agentserver}"
# Pin the session so a restart's recovery scan finds the in-progress task and so
# POSTs on the same session steer the running run.
export FOUNDRY_AGENT_SESSION_ID="${FOUNDRY_AGENT_SESSION_ID:-local-demo-session}"
# Enables the "crash" message sentinel.
export DEMO_MODE=1
# Synthetic token stream => credential-free. Set USE_FAKE_MODEL=0 for the real model.
export USE_FAKE_MODEL="${USE_FAKE_MODEL:-1}"
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

echo "Starting resilient research agent on http://localhost:${PORT}"
echo "  resilient root : ${AGENTSERVER_STATE_ROOT}  (tasks + streams are file-backed here)"
echo "  session id     : ${FOUNDRY_AGENT_SESSION_ID}  (must match across restarts to recover)"
echo "  model          : $( [[ "${USE_FAKE_MODEL}" == "1" ]] && echo 'FAKE (synthetic tokens, no creds)' || echo 'REAL (Foundry Responses)' )"
echo "  dispatch       : POST /invocations {\"message\":\"<topic>\"}"
echo "  crash input    : POST /invocations {\"message\":\"crash\"}   (DEMO_MODE=1)"
echo "  stream         : GET  /invocations/{id}?last_event_id=N   (Accept: text/event-stream)"
echo "  stop           : Ctrl-C"
exec dotnet "$DLL"
