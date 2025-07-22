#!/bin/bash

# Bash version of Invoke-Cspell.ps1
#
# SYNOPSIS
# Invokes cspell using dependencies defined in adjacent ./package*.json
#
# PARAMETERS
# --job-type          Maps to cspell command (e.g. 'lint', 'trace', etc.). Default is 'lint'
# --scan-globs        List of glob expressions to be scanned (space-separated)
# --config-path       Location of cspell.json file to use when scanning
# --spell-check-root  Location of root folder for generating readable relative file paths
# --package-cache     Location of a working directory for npm packages
# --leave-cache       If set, the package cache will not be deleted
# --help              Display this help message
#
# EXAMPLES
# ./eng/common/spelling/invoke-cspell.sh --scan-globs 'sdk/*/*/PublicAPI/**/*.md'
# ./eng/common/spelling/invoke-cspell.sh --scan-globs 'sdk/storage/**' 'sdk/keyvault/**'
# ./eng/common/spelling/invoke-cspell.sh --scan-globs './README.md'

set -euo pipefail

# Default values
JOB_TYPE="lint"
SCAN_GLOBS=("**")
SCRIPT_DIR="$(cd "$(dirname "${BASH_SOURCE[0]}")" && pwd)"
CONFIG_PATH="$(realpath "${SCRIPT_DIR}/../../../.vscode/cspell.json")"
SPELL_CHECK_ROOT="$(realpath "${SCRIPT_DIR}/../../..")"
PACKAGE_CACHE="${TMPDIR:-/tmp}/cspell-tool-path"
LEAVE_CACHE=false

# Logging functions
log_error() {
    if [[ "${GITHUB_ACTIONS:-}" == "true" ]]; then
        echo "::error::$*"
    elif [[ "${SYSTEM_TEAMFOUNDATIONCOLLECTIONURI:-}" != "" ]]; then
        echo "##vso[task.LogIssue type=error;]$*"
    else
        echo "ERROR: $*" >&2
    fi
}

log_info() {
    echo "$*"
}

# Function to display help
show_help() {
    echo "Usage: $0 [OPTIONS]"
    echo ""
    echo "Invokes cspell using dependencies defined in adjacent ./package*.json"
    echo ""
    echo "OPTIONS:"
    echo "  --job-type TYPE           Maps to cspell command (default: lint)"
    echo "  --scan-globs GLOB...      List of glob expressions to be scanned"
    echo "  --config-path PATH        Location of cspell.json file"
    echo "  --spell-check-root PATH   Root folder for relative file paths"
    echo "  --package-cache PATH      Working directory for npm packages"
    echo "  --leave-cache             Don't delete package cache"
    echo "  --help                    Display this help message"
    echo ""
    echo "EXAMPLES:"
    echo "  $0 --scan-globs 'sdk/*/*/PublicAPI/**/*.md'"
    echo "  $0 --scan-globs 'sdk/storage/**' 'sdk/keyvault/**'"
    echo "  $0 --scan-globs './README.md'"
}

# Parse command line arguments
while [[ $# -gt 0 ]]; do
    case $1 in
        --job-type)
            JOB_TYPE="$2"
            shift 2
            ;;
        --scan-globs)
            SCAN_GLOBS=()
            shift
            while [[ $# -gt 0 && ! "$1" =~ ^-- ]]; do
                SCAN_GLOBS+=("$1")
                shift
            done
            ;;
        --config-path)
            CONFIG_PATH="$2"
            shift 2
            ;;
        --spell-check-root)
            SPELL_CHECK_ROOT="$2"
            shift 2
            ;;
        --package-cache)
            PACKAGE_CACHE="$2"
            shift 2
            ;;
        --leave-cache)
            LEAVE_CACHE=true
            shift
            ;;
        --help)
            show_help
            exit 0
            ;;
        *)
            log_error "Unknown option: $1"
            show_help
            exit 1
            ;;
    esac
done

# Check if npm is available
if ! command -v npm &> /dev/null; then
    log_error "Could not locate npm. Install NodeJS (includes npm) https://nodejs.org/en/download/"
    exit 1
fi

# Check if config file exists
if [[ ! -f "$CONFIG_PATH" ]]; then
    log_error "Could not locate config file $CONFIG_PATH"
    exit 1
fi

# Prepare the working directory if it does not already have requirements in place
if [[ ! -d "$PACKAGE_CACHE" ]]; then
    mkdir -p "$PACKAGE_CACHE"
fi

if [[ ! -f "$PACKAGE_CACHE/package.json" ]]; then
    cp "$SCRIPT_DIR/package.json" "$PACKAGE_CACHE/"
fi

if [[ ! -f "$PACKAGE_CACHE/package-lock.json" ]]; then
    cp "$SCRIPT_DIR/package-lock.json" "$PACKAGE_CACHE/"
fi

# Handle LICENSE file requirement
DELETE_NOT_EXCLUDED_FILE=false
NOT_EXCLUDED_FILE=""

if [[ -f "$SPELL_CHECK_ROOT/LICENSE" ]]; then
    NOT_EXCLUDED_FILE="$SPELL_CHECK_ROOT/LICENSE"
elif [[ -f "$SPELL_CHECK_ROOT/LICENSE.txt" ]]; then
    NOT_EXCLUDED_FILE="$SPELL_CHECK_ROOT/LICENSE.txt"
else
    # If there is no LICENSE file, fall back to creating a temporary file
    # The "files" list must always contain a file which exists, is not empty, and is
    # not excluded in ignorePaths. In this case it will be a file with the contents
    # "1" (no spelling errors will be detected)
    NOT_EXCLUDED_FILE="$SPELL_CHECK_ROOT/$(uuidgen 2>/dev/null || echo "temp_$(date +%s)_$$")"
    echo "1" > "$NOT_EXCLUDED_FILE"
    DELETE_NOT_EXCLUDED_FILE=true
fi

# Add the not excluded file to scan globs
SCAN_GLOBS+=("$NOT_EXCLUDED_FILE")

# Read and parse the original cspell config
CSPELL_CONFIG_CONTENT=$(cat "$CONFIG_PATH")

# Create a temporary modified config using jq
# Convert SCAN_GLOBS array to JSON array
SCAN_GLOBS_JSON=$(printf '%s\n' "${SCAN_GLOBS[@]}" | jq -R . | jq -s .)

# Modify the config to include our scan globs
MODIFIED_CONFIG=$(echo "$CSPELL_CONFIG_CONTENT" | jq --argjson files "$SCAN_GLOBS_JSON" '. + {files: $files}')

log_info "Setting config in: $CONFIG_PATH"

# Backup original config and set the modified one
echo "$MODIFIED_CONFIG" > "$CONFIG_PATH"

# Resolve absolute paths
CONFIG_PATH=$(realpath "$CONFIG_PATH")
SPELL_CHECK_ROOT=$(realpath "$SPELL_CHECK_ROOT")

# Store original location
ORIGINAL_LOCATION=$(pwd)

# Cleanup function
cleanup() {
    local exit_code=$?
    
    # Restore original location
    cd "$ORIGINAL_LOCATION"
    
    log_info "cspell run complete, restoring original configuration and removing temp file."
    
    # Restore original config
    echo "$CSPELL_CONFIG_CONTENT" > "$CONFIG_PATH"
    
    # Remove temporary file if created
    if [[ "$DELETE_NOT_EXCLUDED_FILE" == "true" && -f "$NOT_EXCLUDED_FILE" ]]; then
        rm -f "$NOT_EXCLUDED_FILE"
    fi
    
    # Remove package cache if not requested to leave it
    if [[ "$LEAVE_CACHE" == "false" && -d "$PACKAGE_CACHE" ]]; then
        rm -rf "$PACKAGE_CACHE"
    fi
    
    exit $exit_code
}

# Set up cleanup trap
trap cleanup EXIT INT TERM

# Change to package cache directory and run npm ci
cd "$PACKAGE_CACHE"
npm ci

# Run cspell with the modified configuration
COMMAND="npm exec --no -- cspell $JOB_TYPE --config $CONFIG_PATH --no-must-find-files --root $SPELL_CHECK_ROOT --relative"
log_info "$COMMAND"

npm exec --no -- cspell "$JOB_TYPE" --config "$CONFIG_PATH" --no-must-find-files --root "$SPELL_CHECK_ROOT" --relative