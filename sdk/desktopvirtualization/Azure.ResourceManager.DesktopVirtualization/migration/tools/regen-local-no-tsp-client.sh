#!/usr/bin/env bash
set -euo pipefail

SCRIPT_DIR="$(cd "$(dirname "${BASH_SOURCE[0]}")" && pwd)"
DEFAULT_SDK_ROOT="$(cd "$SCRIPT_DIR/.." && pwd)"
DEFAULT_SPEC_ROOT="/home/codespace/code/spec/specification/desktopvirtualization/resource-manager/Microsoft.DesktopVirtualization/DesktopVirtualization"
DEFAULT_MGMT_ROOT="/home/codespace/code/sdk/eng/packages/http-client-csharp-mgmt"

SPEC_ROOT="${SPEC_ROOT:-$DEFAULT_SPEC_ROOT}"
SDK_ROOT="${SDK_ROOT:-$DEFAULT_SDK_ROOT}"
MGMT_ROOT="${MGMT_ROOT:-$DEFAULT_MGMT_ROOT}"
ENTRY_FILE=""
SKIP_BUILD="false"
GENERATOR_ONLY="false"
BUILD_SDK="true"
SAVE_INPUTS="true"

usage() {
  cat <<EOF
Usage: $(basename "$0") [options]

Generate Azure.ResourceManager.DesktopVirtualization from local spec using local emitter/generator,
without tsp-client.

Options:
  --spec-root <path>       Local spec folder containing client.tsp/main.tsp
  --sdk-root <path>        SDK package root (contains Configuration.json and src/)
  --mgmt-root <path>       Local mgmt emitter package root (eng/packages/http-client-csharp-mgmt)
  --entry-file <path>      Explicit TypeSpec entry file (overrides auto-detect)
  --skip-build             Skip building local emitter + generator
  --generator-only         Skip TypeSpec compile, run local generator DLL directly on SDK root
  --no-build-sdk           Skip final dotnet build verification for the SDK
  --no-save-inputs         Do not pass save-inputs=true to emitter
  -h, --help               Show this help

Environment overrides:
  SPEC_ROOT, SDK_ROOT, MGMT_ROOT

Examples:
  $(basename "$0")
  $(basename "$0") --generator-only
  $(basename "$0") --spec-root /path/to/spec --sdk-root /path/to/sdk --mgmt-root /path/to/http-client-csharp-mgmt
EOF
}

log() {
  printf '\n[%s] %s\n' "$(date +'%H:%M:%S')" "$*"
}

require_file() {
  local file_path="$1"
  if [[ ! -f "$file_path" ]]; then
    echo "Required file not found: $file_path" >&2
    exit 1
  fi
}

require_dir() {
  local dir_path="$1"
  if [[ ! -d "$dir_path" ]]; then
    echo "Required directory not found: $dir_path" >&2
    exit 1
  fi
}

while [[ $# -gt 0 ]]; do
  case "$1" in
    --spec-root)
      SPEC_ROOT="$2"
      shift 2
      ;;
    --sdk-root)
      SDK_ROOT="$2"
      shift 2
      ;;
    --mgmt-root)
      MGMT_ROOT="$2"
      shift 2
      ;;
    --entry-file)
      ENTRY_FILE="$2"
      shift 2
      ;;
    --skip-build)
      SKIP_BUILD="true"
      shift
      ;;
    --generator-only)
      GENERATOR_ONLY="true"
      shift
      ;;
    --no-build-sdk)
      BUILD_SDK="false"
      shift
      ;;
    --no-save-inputs)
      SAVE_INPUTS="false"
      shift
      ;;
    -h|--help)
      usage
      exit 0
      ;;
    *)
      echo "Unknown argument: $1" >&2
      usage
      exit 1
      ;;
  esac
done

require_dir "$SPEC_ROOT"
require_dir "$SDK_ROOT"
require_dir "$MGMT_ROOT"
require_dir "$SDK_ROOT/src"
require_file "$SDK_ROOT/Configuration.json"

GENERATOR_DLL="$MGMT_ROOT/dist/generator/Microsoft.TypeSpec.Generator.dll"

if [[ "$SKIP_BUILD" != "true" ]]; then
  log "Building local emitter + generator at $MGMT_ROOT"
  pushd "$MGMT_ROOT" >/dev/null
  npm install
  npm run build
  popd >/dev/null
fi

require_file "$GENERATOR_DLL"

if [[ "$GENERATOR_ONLY" != "true" ]]; then
  if [[ -z "$ENTRY_FILE" ]]; then
    if [[ -f "$SPEC_ROOT/client.tsp" ]]; then
      ENTRY_FILE="$SPEC_ROOT/client.tsp"
    elif [[ -f "$SPEC_ROOT/main.tsp" ]]; then
      ENTRY_FILE="$SPEC_ROOT/main.tsp"
    else
      echo "Cannot auto-detect TypeSpec entry file in $SPEC_ROOT (expected client.tsp or main.tsp)." >&2
      exit 1
    fi
  fi

  require_file "$ENTRY_FILE"

  log "Installing spec npm dependencies in $SPEC_ROOT"
  pushd "$SPEC_ROOT" >/dev/null
  npm install

  log "Running local TypeSpec compile with local emitter (no tsp-client)"
  COMPILE_CMD=(
    npx tsp compile "$ENTRY_FILE"
    --emit "$MGMT_ROOT"
    --option "@azure-typespec/http-client-csharp-mgmt.emitter-output-dir=$SDK_ROOT"
  )

  if [[ "$SAVE_INPUTS" == "true" ]]; then
    COMPILE_CMD+=(--option "@azure-typespec/http-client-csharp-mgmt.save-inputs=true")
  fi

  "${COMPILE_CMD[@]}"
  popd >/dev/null
fi

log "Running local generator directly"
pushd "$SDK_ROOT" >/dev/null
dotnet --roll-forward Major "$GENERATOR_DLL" . -g ManagementClientGenerator

if [[ "$BUILD_SDK" == "true" ]]; then
  log "Building SDK for validation"
  dotnet build src/Azure.ResourceManager.DesktopVirtualization.csproj /p:RunApiCompat=false
fi

popd >/dev/null
log "Completed local generation without tsp-client"
