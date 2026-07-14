#!/usr/bin/env bash
# ─────────────────────────────────────────────────────────────────────────────
# Maintainer-only: rebuild the checked-in preview NuGet packages (the ".NET
# package drop" — the .NET analogue of sdk/agentserver/wheels/*.whl on Python).
#
# Output: refreshes *.nupkg files in this directory (sdk/agentserver/packages/)
#         alongside this script and README.md. Devs consuming a sample do NOT
#         need to run this — the packages are checked in. See README.md.
#
# Packages included (Azure.AI.AgentServer.{Core, Responses, Invocations}):
#   - Core         — resilient-task + event-stream primitives
#   - Responses    — Responses protocol HTTP host (depends on Core)
#   - Invocations  — Invocations protocol HTTP host (depends on Core)
#
# Versions are taken from each project's <Version> in its .csproj. We pass
# -p:SkipDevBuildNumber=true so the repo's dev "-alpha.<date>" suffix is NOT
# appended — the drop ships the real beta version each package will publish as,
# and Responses records the correct Core dependency version (not a propagated
# override).
#
# When to run:
#   - After source changes to Core or Responses that need to ship in a sample's
#     container image, and before committing those source changes.
#
# Usage (from anywhere):
#   sdk/agentserver/packages/build-packages.sh
# ─────────────────────────────────────────────────────────────────────────────

set -euo pipefail

PACKAGES_DIR="$(cd "$(dirname "$0")" && pwd)"
AGENTSERVER_ROOT="$(cd "$PACKAGES_DIR/.." && pwd)"

PROJECTS=(
    "Azure.AI.AgentServer.Core/src/Azure.AI.AgentServer.Core.csproj"
    "Azure.AI.AgentServer.Responses/src/Azure.AI.AgentServer.Responses.csproj"
    "Azure.AI.AgentServer.Invocations/src/Azure.AI.AgentServer.Invocations.csproj"
)

echo "==> Rebuilding preview NuGet packages into: $PACKAGES_DIR"
# Remove stale nupkgs but preserve README.md and this script.
rm -f "$PACKAGES_DIR"/*.nupkg

for proj in "${PROJECTS[@]}"; do
    proj_path="$AGENTSERVER_ROOT/$proj"
    if [[ ! -f "$proj_path" ]]; then
        echo "  !! Skipping $proj — not found at $proj_path" >&2
        continue
    fi
    echo "  - $proj"
    dotnet pack "$proj_path" -c Release -o "$PACKAGES_DIR" --nologo \
        -p:SkipDevBuildNumber=true >/dev/null
done

# Drop the .symbols.nupkg — the drop ships lean, runtime-only packages.
rm -f "$PACKAGES_DIR"/*.symbols.nupkg

echo ""
echo "==> Refreshed packages:"
ls -la "$PACKAGES_DIR"/*.nupkg

echo ""
echo "Next: git add sdk/agentserver/packages/*.nupkg && commit."
