#!/bin/bash
#
# Push test recordings to Azure SDK Assets repository.
# Optionally run full record → push → verify workflow.
#
# Usage:
#   ./test-push.sh [options]
#
# Options:
#   --dry-run              Preview what would be pushed
#   --workflow             Run full record → push → verify workflow
#   --skip-compile         Skip compilation step (workflow)
#   --skip-verify          Skip playback verification (workflow)
#   -f, --filter FILTER    Filter tests by name (workflow)
#   --framework FW         Target framework (default: net10.0)
#   -h, --help             Show help
#

set -e

# ── Ensure dotnet is on PATH ──────────────────────────────────────────────────
if ! command -v dotnet &> /dev/null; then
    if [[ -x "$HOME/.dotnet/dotnet" ]]; then
        export PATH="$HOME/.dotnet:$PATH"
    else
        echo -e "\033[31mError: dotnet command not found\033[0m"
        echo -e "\033[33mInstall .NET SDK: https://dot.net/download\033[0m"
        exit 1
    fi
fi

# ── Helper: find test-proxy executable ────────────────────────────────────────
find_test_proxy() {
    if command -v test-proxy &> /dev/null; then
        echo "test-proxy"
    elif command -v Azure.Sdk.Tools.TestProxy &> /dev/null; then
        echo "Azure.Sdk.Tools.TestProxy"
    else
        echo ""
    fi
}

# ── Defaults ──────────────────────────────────────────────────────────────────
DRY_RUN=false
WORKFLOW=false
SKIP_COMPILE=false
SKIP_VERIFY=false
FILTER=""
FRAMEWORK="net10.0"

# ── Parse arguments ───────────────────────────────────────────────────────────
while [[ $# -gt 0 ]]; do
    case $1 in
        --dry-run|-d)
            DRY_RUN=true
            shift
            ;;
        --workflow|-w)
            WORKFLOW=true
            shift
            ;;
        --skip-compile)
            SKIP_COMPILE=true
            shift
            ;;
        --skip-verify)
            SKIP_VERIFY=true
            shift
            ;;
        -f|--filter)
            FILTER="$2"
            shift 2
            ;;
        --framework)
            FRAMEWORK="$2"
            shift 2
            ;;
        -h|--help)
            head -18 "$0" | tail -15
            exit 0
            ;;
        *)
            echo "Unknown option: $1"
            exit 1
            ;;
    esac
done

# ── Locate project ───────────────────────────────────────────────────────────
SDK_DIR=$(pwd)
ASSETS_FILE="$SDK_DIR/assets.json"
SKILLS_DIR="$SDK_DIR/.github/skills"

write_step() {
    echo ""
    echo -e "\033[36m════════════════════════════════════════\033[0m"
    echo -e "\033[36m  Step $1: $2\033[0m"
    echo -e "\033[36m════════════════════════════════════════\033[0m"
}

# ══════════════════════════════════════════════════════════════════════════════
#  Push Only (no --workflow)
# ══════════════════════════════════════════════════════════════════════════════
if [[ "$WORKFLOW" != true ]]; then
    # Validate assets.json
    if [[ ! -f "$ASSETS_FILE" ]]; then
        echo -e "\033[31mError: assets.json not found in current directory\033[0m"
        echo -e "\033[33mAre you in the SDK module directory?\033[0m"
        exit 1
    fi

    echo "═══════════════════════════════════════════════════════════"
    echo "  Azure SDK Test Push"
    echo "═══════════════════════════════════════════════════════════"
    echo ""
    echo -e "\033[36mAssets file: $ASSETS_FILE\033[0m"

    # Dry run (no test-proxy needed)
    if [[ "$DRY_RUN" == true ]]; then
        echo -e "\033[35mDRY RUN — No changes will be made\033[0m"
        echo ""
        echo -e "\033[33mCurrent assets.json:\033[0m"
        cat "$ASSETS_FILE"
        echo ""
        echo -e "\033[33mDry run complete. Use without --dry-run to actually push.\033[0m"
        exit 0
    fi

    # Push recordings
    TEST_PROXY_EXE=$(find_test_proxy)
    if [[ -z "$TEST_PROXY_EXE" ]]; then
        echo -e "\033[31mError: test-proxy command not found\033[0m"
        echo -e "\033[33mInstall via repo script: pwsh eng/common/testproxy/install-test-proxy.ps1\033[0m"
        echo -e "\033[33mOr see: https://github.com/Azure/azure-sdk-tools/blob/main/tools/test-proxy/Azure.Sdk.Tools.TestProxy/README.md#installation\033[0m"
        exit 1
    fi

    echo -e "\033[33mPushing recordings to Azure SDK Assets repository...\033[0m"
    echo -e "\033[36mExecuting: $TEST_PROXY_EXE push -a assets.json\033[0m"

    "$TEST_PROXY_EXE" push -a "$ASSETS_FILE"
    EXIT_CODE=$?

    if [[ $EXIT_CODE -eq 0 ]]; then
        echo -e "\n\033[32mRecordings pushed successfully!\033[0m"
        echo -e "\033[33mDon't forget to commit the updated assets.json\033[0m"
        echo ""
        echo -e "\033[33mUpdated assets.json:\033[0m"
        cat "$ASSETS_FILE"
    else
        echo -e "\n\033[31mFailed to push recordings (exit code: $EXIT_CODE)\033[0m"
        echo -e "\033[33mCheck your git credentials and network connection\033[0m"
    fi

    exit $EXIT_CODE
fi

# ══════════════════════════════════════════════════════════════════════════════
#  Full Workflow: Record → Push → Verify
# ══════════════════════════════════════════════════════════════════════════════
START_TIME=$(date +%s)

echo "═══════════════════════════════════════════════════════════"
echo "  Azure SDK Workflow: Record and Push"
echo "═══════════════════════════════════════════════════════════"
echo -e "\033[90mStarted at: $(date)\033[0m"

# ── Step 1: Setup Environment ────────────────────────────────────────────────
write_step 1 "Setup Environment"
ENV_SCRIPT="$SKILLS_DIR/sdkinternal-dotnet-env-setup/scripts/load-env.sh"
if [[ -f "$ENV_SCRIPT" ]]; then
    source "$ENV_SCRIPT"
else
    echo -e "\033[33mWarning: load-env.sh not found, skipping environment setup\033[0m"
fi

# ── Step 2: Compile SDK ──────────────────────────────────────────────────────
if [[ "$SKIP_COMPILE" != true ]]; then
    write_step 2 "Compile SDK"
    COMPILE_SCRIPT="$SKILLS_DIR/sdkinternal-dotnet-sdk-compile/scripts/compile.sh"
    if [[ -f "$COMPILE_SCRIPT" ]]; then
        bash "$COMPILE_SCRIPT"
        if [[ $? -ne 0 ]]; then
            echo -e "\033[31mCompilation failed. Aborting workflow.\033[0m"
            exit 1
        fi
    else
        dotnet build
        if [[ $? -ne 0 ]]; then
            echo -e "\033[31mCompilation failed. Aborting workflow.\033[0m"
            exit 1
        fi
    fi
else
    echo -e "\033[33mSkipping compilation (--skip-compile)\033[0m"
fi

# ── Step 3: Record Tests ─────────────────────────────────────────────────────
write_step 3 "Record Tests"
export AZURE_TEST_MODE="Record"
TESTS_PROJECT=$(find "$SDK_DIR/tests" -name "*.csproj" -type f | head -1)

if [[ -z "$TESTS_PROJECT" ]]; then
    echo -e "\033[31mError: No test project found in tests/ directory\033[0m"
    exit 1
fi

TEST_ARGS=("test" "$TESTS_PROJECT" "-f" "$FRAMEWORK" "-v" "n")
if [[ -n "$FILTER" ]]; then
    TEST_ARGS+=("--filter" "FullyQualifiedName~$FILTER")
    echo -e "\033[36mFilter: $FILTER\033[0m"
fi

dotnet "${TEST_ARGS[@]}"
if [[ $? -ne 0 ]]; then
    echo -e "\033[31mRecording failed. Aborting workflow.\033[0m"
    exit 1
fi

# ── Step 4: Push Recordings ──────────────────────────────────────────────────
write_step 4 "Push Recordings"
if [[ -f "$ASSETS_FILE" ]]; then
    TEST_PROXY_EXE=$(find_test_proxy)
    if [[ -z "$TEST_PROXY_EXE" ]]; then
        echo -e "\033[31mError: test-proxy command not found\033[0m"
        echo -e "\033[33mInstall via repo script: pwsh eng/common/testproxy/install-test-proxy.ps1\033[0m"
        exit 1
    fi

    "$TEST_PROXY_EXE" push -a "$ASSETS_FILE"
    if [[ $? -ne 0 ]]; then
        echo -e "\033[31mPush failed. Aborting workflow.\033[0m"
        exit 1
    fi
else
    echo -e "\033[33mWarning: assets.json not found, skipping push\033[0m"
fi

# ── Step 5: Verify Playback ──────────────────────────────────────────────────
if [[ "$SKIP_VERIFY" != true ]]; then
    write_step 5 "Verify Playback"
    export AZURE_TEST_MODE="Playback"

    dotnet "${TEST_ARGS[@]}"
    if [[ $? -ne 0 ]]; then
        echo -e "\033[31mPlayback verification failed!\033[0m"
        exit 1
    fi
else
    echo -e "\033[33mSkipping playback verification (--skip-verify)\033[0m"
fi

# ── Summary ───────────────────────────────────────────────────────────────────
END_TIME=$(date +%s)
DURATION=$((END_TIME - START_TIME))
MINUTES=$((DURATION / 60))
SECONDS=$((DURATION % 60))

echo ""
echo -e "\033[32m═══════════════════════════════════════════════════════════\033[0m"
echo -e "\033[32m  Workflow Completed Successfully!\033[0m"
echo -e "\033[32m═══════════════════════════════════════════════════════════\033[0m"
echo -e "\033[90mDuration: ${MINUTES}m ${SECONDS}s\033[0m"
echo ""
echo -e "\033[33mNext steps:\033[0m"
echo "  1. Review the updated assets.json"
echo "  2. Commit your changes"
echo "  3. Create a pull request"
