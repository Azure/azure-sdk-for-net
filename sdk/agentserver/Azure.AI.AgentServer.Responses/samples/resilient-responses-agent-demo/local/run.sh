#!/usr/bin/env bash
# ─────────────────────────────────────────────────────────────────────────────
# Automated end-to-end resilient crash-recovery demo (.NET):
#   start agent (local file-backed store) -> stream -> crash -> restart -> recover -> verify.
#
# Credential-free by default (DEMO_ROUTE=echo). For the real research crash->recover:
#   az login
#   export FOUNDRY_PROJECT_ENDPOINT=https://<account>.services.ai.azure.com/api/projects/<project>
#   export AZURE_AI_MODEL_DEPLOYMENT_NAME=gpt-5.4-nano
#   DEMO_ROUTE=research ./run.sh
#
# Tunables (env): DEMO_ROUTE (echo|research), NUM_PHASES (research, default 3),
# CRASH_AFTER (research, default 5), PORT (8088).
# ─────────────────────────────────────────────────────────────────────────────
set -euo pipefail

HERE="$(cd "$(dirname "${BASH_SOURCE[0]}")" && pwd)"
DLL="$HERE/../src/resilient-responses-agent-demo/bin/Release/net10.0/ResilientResponsesAgentDemo.dll"

if [[ ! -f "$DLL" ]]; then
    echo "Build output not found — run ./setup.sh first." >&2
    exit 1
fi

PY="${PYTHON:-python3}"
if ! "$PY" -c "import httpx" 2>/dev/null; then
    echo "==> Installing httpx (test driver dependency) into a local venv"
    "$PY" -m venv "$HERE/.venv"
    "$HERE/.venv/bin/pip" install --quiet --upgrade pip httpx
    PY="$HERE/.venv/bin/python"
fi

exec "$PY" "$HERE/recovery_demo.py"
