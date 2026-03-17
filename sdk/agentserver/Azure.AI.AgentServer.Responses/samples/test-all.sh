#!/usr/bin/env bash
# Run all sample test scripts sequentially.
# Each script starts its own server on a unique port and tears it down.
set -euo pipefail

SCRIPT_DIR="$(cd "$(dirname "$0")" && pwd)"

echo "Building samples..."
dotnet build "$SCRIPT_DIR/Samples.slnx" --verbosity quiet
echo ""

for sample in GettingStarted FunctionCalling MultiOutput ConversationHistory; do
    echo "━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━"
    bash "$SCRIPT_DIR/$sample/test.sh"
    echo ""
done

echo "━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━"
echo "All sample tests completed successfully!"
