#!/usr/bin/env bash
# Stage the checked-in AgentServer preview NuGet packages (the ".NET package drop")
# into this sample's build context. Run this BEFORE 'azd up', 'docker build', or a
# local 'dotnet build'/'dotnet run'.
#
# Packages are checked into the repo at sdk/agentserver/packages/ — this script just
# copies them into the per-sample staging dir (src/resilient-research-agent/packages/,
# gitignored) that the sample's nuget.config registers as a local NuGet source and that
# the Dockerfile's `COPY packages/ ...` restores from at image-build time.
#
# This mirrors the Python demo's build.sh, which stages *.whl into a wheels/ dir.
#
# To refresh the source packages (maintainer-only — devs shouldn't need to), see
# ../../../../packages/README.md.

set -euo pipefail

SCRIPT_DIR="$(cd "$(dirname "$0")" && pwd)"
# sample root -> Invocations -> agentserver
REPO_AGENTSERVER="$(cd "$SCRIPT_DIR/../../.." && pwd)"
CENTRAL_PACKAGES="$REPO_AGENTSERVER/packages"
STAGING_DIR="$SCRIPT_DIR/src/resilient-research-agent/packages"

if [[ ! -d "$CENTRAL_PACKAGES" ]] || ! ls "$CENTRAL_PACKAGES"/*.nupkg >/dev/null 2>&1; then
    echo "ERROR: no checked-in packages found at $CENTRAL_PACKAGES" >&2
    echo "       Did you pull the latest, or run packages/build-packages.sh?" >&2
    exit 1
fi

echo "==> Staging checked-in preview NuGet packages into the sample build context"
echo "    src:  $CENTRAL_PACKAGES"
echo "    dst:  $STAGING_DIR"
rm -rf "$STAGING_DIR"
mkdir -p "$STAGING_DIR"
cp "$CENTRAL_PACKAGES"/*.nupkg "$STAGING_DIR"/
ls -la "$STAGING_DIR"/*.nupkg

echo ""
echo "Done. Now run: azd up   (or docker build, or dotnet run from src/resilient-research-agent)."
