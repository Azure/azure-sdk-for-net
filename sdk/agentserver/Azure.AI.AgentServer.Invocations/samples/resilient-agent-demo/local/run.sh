#!/usr/bin/env bash
# ─────────────────────────────────────────────────────────────────────────────
# Automated end-to-end resilient crash-recovery demo (.NET):
#   start agent (local file-backed store) -> dispatch run -> stream -> crash ->
#   restart -> recover -> reconnect -> verify the run completes across the crash.
#
# Credential-free by default (USE_FAKE_MODEL=1 => synthetic token stream). For the
# real research crash->recover (parity with the hosted demo):
#   az login
#   export FOUNDRY_PROJECT_ENDPOINT=https://<account>.services.ai.azure.com/api/projects/<project>
#   export AZURE_AI_MODEL_DEPLOYMENT_NAME=gpt-5.4-nano
#   export USE_FAKE_MODEL=0
#   ./run.sh
#
# Tunables (env): USE_FAKE_MODEL (1|0), NUM_PHASES (default 3), CRASH_AFTER
# (default 1 phase checkpoint), PORT (8088).
# ─────────────────────────────────────────────────────────────────────────────
set -euo pipefail

HERE="$(cd "$(dirname "${BASH_SOURCE[0]}")" && pwd)"
DLL="$HERE/../src/resilient-research-agent/bin/Release/net10.0/ResilientResearchAgentDemo.dll"

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
