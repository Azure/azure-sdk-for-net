#!/usr/bin/env bash
# ─────────────────────────────────────────────────────────────────────────────
# One-time setup for the LOCAL kit (.NET).
#
# Unlike the Python kit (venv + wheels), .NET just needs the SDK + the checked-in
# NuGet package drop. This script:
#   1. stages the central package drop (sdk/agentserver/packages) into the sample,
#   2. restores + builds the agent in Release,
# so serve.sh / run.sh start instantly (no rebuild).
#
#   ./setup.sh
# ─────────────────────────────────────────────────────────────────────────────
set -euo pipefail

HERE="$(cd "$(dirname "${BASH_SOURCE[0]}")" && pwd)"
SAMPLE_ROOT="$(cd "$HERE/.." && pwd)"
PROJ_DIR="$SAMPLE_ROOT/src/resilient-research-agent"

echo "==> Staging the NuGet package drop"
"$SAMPLE_ROOT/build.sh"

echo "==> Restoring + building (Release)"
dotnet build -c Release "$PROJ_DIR/ResilientResearchAgentDemo.csproj"

echo ""
echo "Done. Next:"
echo "  ./run.sh                        # automated crash -> recover demo (credential-free FAKE-model mode by default)"
echo "  ./serve.sh                      # run the agent yourself for manual exploration"
echo ""
echo "For the REAL multi-phase research crash->recover (parity with the hosted demo):"
echo "  az login"
echo "  export FOUNDRY_PROJECT_ENDPOINT=https://<account>.services.ai.azure.com/api/projects/<project>"
echo "  export AZURE_AI_MODEL_DEPLOYMENT_NAME=gpt-5.4-nano"
echo "  export USE_FAKE_MODEL=0"
echo "  ./run.sh"
