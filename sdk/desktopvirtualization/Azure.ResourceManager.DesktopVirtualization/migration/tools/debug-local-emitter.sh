#!/usr/bin/env bash
set -euo pipefail

# ============================================================================
# debug-local-emitter.sh
#
# Prepares and launches a Node.js --inspect-brk session for debugging the
# local TypeScript emitter (@azure-typespec/http-client-csharp-mgmt).
#
# After the process starts, attach VS Code's JavaScript debugger or Chrome
# DevTools to the Node.js inspector (default: 127.0.0.1:9229). You can set
# breakpoints in the emitter source at:
#   eng/packages/http-client-csharp-mgmt/emitter/src/*.ts
# ============================================================================

SCRIPT_DIR="$(cd "$(dirname "${BASH_SOURCE[0]}")" && pwd)"
DEFAULT_SDK_ROOT="$(cd "$SCRIPT_DIR/../.." && pwd)"
DEFAULT_REPO_ROOT="$(git -C "$DEFAULT_SDK_ROOT" rev-parse --show-toplevel 2>/dev/null)"
DEFAULT_SPEC_ROOT="/home/codespace/code/spec/specification/desktopvirtualization/resource-manager/Microsoft.DesktopVirtualization/DesktopVirtualization"
DEFAULT_MGMT_ROOT="$DEFAULT_REPO_ROOT/eng/packages/http-client-csharp-mgmt"

SPEC_ROOT="${SPEC_ROOT:-$DEFAULT_SPEC_ROOT}"
SDK_ROOT="${SDK_ROOT:-$DEFAULT_SDK_ROOT}"
MGMT_ROOT="${MGMT_ROOT:-$DEFAULT_MGMT_ROOT}"
ENTRY_FILE=""
SKIP_BUILD="false"
SAVE_INPUTS="true"
INSPECT_PORT="9229"
DEBUG_GENERATOR="false"
USE_TEMP_FILES="false"

usage() {
  cat <<EOF
Usage: $(basename "$0") [options]

Build the local emitter, prepare the environment, and launch 'node --inspect-brk'
so you can debug the TypeScript emitter in VS Code or Chrome DevTools.

Options:
  --spec-root <path>       Local spec folder containing client.tsp/main.tsp
                           (default: $DEFAULT_SPEC_ROOT)
  --sdk-root <path>        SDK package root (contains Configuration.json and src/)
                           (default: auto-detected from script location)
  --mgmt-root <path>       Local mgmt emitter package root
                           (default: auto-detected from repo root)
  --entry-file <path>      Explicit TypeSpec entry file (overrides auto-detect)
  --skip-build             Skip building the local emitter + generator
  --no-save-inputs         Do not pass save-inputs=true to emitter
  --port <port>            Node.js inspector port (default: 9229)
  --debug-generator        Also pass debug=true so the C# generator waits for debugger
  --use-temp-files         Use TempTypeSpecFiles/ instead of --spec-root
                           (requires prior 'dotnet build /t:GenerateCode' to populate them)
  -h, --help               Show this help

Environment overrides:
  SPEC_ROOT, SDK_ROOT, MGMT_ROOT

After launch:
  1. VS Code: "JavaScript Debug Terminal" or "Attach to Node Process" launch config
  2. Chrome: open chrome://inspect and click the remote target
  3. Set breakpoints in eng/packages/http-client-csharp-mgmt/emitter/src/*.ts

Examples:
  $(basename "$0")
  $(basename "$0") --skip-build
  $(basename "$0") --skip-build --debug-generator
  $(basename "$0") --port 9230
  $(basename "$0") --use-temp-files --skip-build
EOF
}

log() {
  printf '\n\033[1;36m[%s] %s\033[0m\n' "$(date +'%H:%M:%S')" "$*"
}

require_file() {
  if [[ ! -f "$1" ]]; then
    echo "ERROR: Required file not found: $1" >&2
    exit 1
  fi
}

require_dir() {
  if [[ ! -d "$1" ]]; then
    echo "ERROR: Required directory not found: $1" >&2
    exit 1
  fi
}

while [[ $# -gt 0 ]]; do
  case "$1" in
    --spec-root)     SPEC_ROOT="$2";   shift 2 ;;
    --sdk-root)      SDK_ROOT="$2";    shift 2 ;;
    --mgmt-root)     MGMT_ROOT="$2";   shift 2 ;;
    --entry-file)    ENTRY_FILE="$2";  shift 2 ;;
    --skip-build)    SKIP_BUILD="true"; shift ;;
    --no-save-inputs) SAVE_INPUTS="false"; shift ;;
    --port)          INSPECT_PORT="$2"; shift 2 ;;
    --debug-generator) DEBUG_GENERATOR="true"; shift ;;
    --use-temp-files) USE_TEMP_FILES="true"; shift ;;
    -h|--help)       usage; exit 0 ;;
    *)
      echo "Unknown argument: $1" >&2
      usage
      exit 1
      ;;
  esac
done

# ---------------------------------------------------------------------------
# Validate paths
# ---------------------------------------------------------------------------
require_dir "$MGMT_ROOT"
require_dir "$SDK_ROOT"

log "Configuration:"
echo "  MGMT_ROOT  = $MGMT_ROOT"
echo "  SDK_ROOT   = $SDK_ROOT"
echo "  SPEC_ROOT  = $SPEC_ROOT"
echo "  SKIP_BUILD = $SKIP_BUILD"
echo "  PORT       = $INSPECT_PORT"

# ---------------------------------------------------------------------------
# Step 1: Build the local emitter (+ generator)
# ---------------------------------------------------------------------------
if [[ "$SKIP_BUILD" != "true" ]]; then
  log "Step 1: Building local emitter + generator at $MGMT_ROOT"
  pushd "$MGMT_ROOT" >/dev/null

  if [[ ! -d "node_modules" ]]; then
    log "  Running npm install (first time)..."
    npm install
  fi

  log "  Building emitter (tsc)..."
  npm run build:emitter

  log "  Building generator (dotnet build)..."
  npm run build:generator

  popd >/dev/null
else
  log "Step 1: Skipping build (--skip-build)"
fi

# Verify build output exists
require_file "$MGMT_ROOT/dist/emitter/index.js"
log "  Emitter entry point OK: $MGMT_ROOT/dist/emitter/index.js"

# ---------------------------------------------------------------------------
# Step 2: Determine the compile root and entry file
# ---------------------------------------------------------------------------
if [[ "$USE_TEMP_FILES" == "true" ]]; then
  COMPILE_ROOT="$SDK_ROOT/TempTypeSpecFiles"
  require_dir "$COMPILE_ROOT"
  log "Step 2: Using TempTypeSpecFiles as compile root"

  # Create symlink so TypeSpec compiler resolves packages from the local emitter
  if [[ -L "$COMPILE_ROOT/node_modules" ]]; then
    rm "$COMPILE_ROOT/node_modules"
  fi
  ln -sfn "$MGMT_ROOT/node_modules" "$COMPILE_ROOT/node_modules"
  log "  Symlinked node_modules -> $MGMT_ROOT/node_modules"

  # Auto-detect entry within TempTypeSpecFiles
  if [[ -z "$ENTRY_FILE" ]]; then
    # Look for DesktopVirtualization subfolder first, then top-level
    for candidate in \
      "$COMPILE_ROOT/DesktopVirtualization/client.tsp" \
      "$COMPILE_ROOT/DesktopVirtualization/main.tsp" \
      "$COMPILE_ROOT/client.tsp" \
      "$COMPILE_ROOT/main.tsp"; do
      if [[ -f "$candidate" ]]; then
        ENTRY_FILE="$candidate"
        break
      fi
    done
  fi
else
  COMPILE_ROOT="$SPEC_ROOT"
  require_dir "$COMPILE_ROOT"
  log "Step 2: Using spec root as compile root: $SPEC_ROOT"

  # Install spec dependencies
  if [[ -f "$COMPILE_ROOT/package.json" ]]; then
    log "  Installing spec npm dependencies..."
    pushd "$COMPILE_ROOT" >/dev/null
    npm install
    popd >/dev/null
  fi

  # Auto-detect entry file
  if [[ -z "$ENTRY_FILE" ]]; then
    if [[ -f "$SPEC_ROOT/client.tsp" ]]; then
      ENTRY_FILE="$SPEC_ROOT/client.tsp"
    elif [[ -f "$SPEC_ROOT/main.tsp" ]]; then
      ENTRY_FILE="$SPEC_ROOT/main.tsp"
    fi
  fi
fi

if [[ -z "$ENTRY_FILE" ]]; then
  echo "ERROR: Cannot auto-detect TypeSpec entry file (expected client.tsp or main.tsp)." >&2
  echo "  Looked in: $COMPILE_ROOT" >&2
  echo "  Use --entry-file to specify explicitly." >&2
  exit 1
fi

require_file "$ENTRY_FILE"
log "  Entry file: $ENTRY_FILE"

# ---------------------------------------------------------------------------
# Step 3: Locate tsp binary
# ---------------------------------------------------------------------------
TSP_BIN=""
if command -v tsp &>/dev/null; then
  TSP_BIN="$(which tsp)"
elif [[ -f "$MGMT_ROOT/node_modules/.bin/tsp" ]]; then
  TSP_BIN="$MGMT_ROOT/node_modules/.bin/tsp"
elif [[ -f "$COMPILE_ROOT/node_modules/.bin/tsp" ]]; then
  TSP_BIN="$COMPILE_ROOT/node_modules/.bin/tsp"
else
  echo "ERROR: Cannot find 'tsp' binary. Make sure @typespec/compiler is installed." >&2
  exit 1
fi
log "Step 3: Using tsp at $TSP_BIN"

# ---------------------------------------------------------------------------
# Step 4: Build the node --inspect-brk command
# ---------------------------------------------------------------------------
log "Step 4: Launching node --inspect-brk on port $INSPECT_PORT"
echo ""
echo "  ================================================================"
echo "  Attach your debugger now!"
echo "  - VS Code: use 'Attach to Node Process' or 'JavaScript Debug Terminal'"
echo "  - Chrome:  open chrome://inspect"
echo "  Listening on: 127.0.0.1:$INSPECT_PORT"
echo "  ================================================================"
echo ""

COMPILE_ARGS=(
  compile "$ENTRY_FILE"
  --emit "$MGMT_ROOT"
  --option "@azure-typespec/http-client-csharp-mgmt.emitter-output-dir=$SDK_ROOT"
)

if [[ "$SAVE_INPUTS" == "true" ]]; then
  COMPILE_ARGS+=(--option "@azure-typespec/http-client-csharp-mgmt.save-inputs=true")
fi

if [[ "$DEBUG_GENERATOR" == "true" ]]; then
  COMPILE_ARGS+=(--option "@azure-typespec/http-client-csharp-mgmt.debug=true")
fi

# Print the full command for reference
echo "Command:"
echo "  node --inspect-brk=0.0.0.0:$INSPECT_PORT $TSP_BIN ${COMPILE_ARGS[*]}"
echo ""

# ---------------------------------------------------------------------------
# Step 5: Run!
# ---------------------------------------------------------------------------
cleanup() {
  if [[ "$USE_TEMP_FILES" == "true" && -L "$SDK_ROOT/TempTypeSpecFiles/node_modules" ]]; then
    log "Cleaning up TempTypeSpecFiles/node_modules symlink"
    rm -f "$SDK_ROOT/TempTypeSpecFiles/node_modules"
  fi
}
trap cleanup EXIT

cd "$COMPILE_ROOT"
exec node "--inspect-brk=0.0.0.0:$INSPECT_PORT" "$TSP_BIN" "${COMPILE_ARGS[@]}"
