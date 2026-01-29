#!/bin/bash
# Complete workflow: Record tests and push recordings
# Usage: ./run-workflow.sh [--skip-compile] [--skip-verify] [-f "TestName"]

SKIP_COMPILE=false
SKIP_VERIFY=false
FILTER=""
FRAMEWORK="net462"

# Parse arguments
while [[ $# -gt 0 ]]; do
    case $1 in
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
        *)
            shift
            ;;
    esac
done

write_step() {
    echo -e "\n\033[36m========================================\033[0m"
    echo -e "\033[36mStep $1: $2\033[0m"
    echo -e "\033[36m========================================\033[0m"
}

SDK_DIR=$(pwd)
SKILLS_DIR="$SDK_DIR/.github/skills"
START_TIME=$(date +%s)

echo -e "\033[33mAzure SDK Workflow: Record and Push\033[0m"
echo -e "\033[90mStarted at: $(date)\033[0m"

# Step 1: Setup Environment
write_step 1 "Setup Environment"
ENV_SCRIPT="$SKILLS_DIR/sdk-setup-env/scripts/load-env.sh"
if [[ -f "$ENV_SCRIPT" ]]; then
    source "$ENV_SCRIPT"
else
    echo -e "\033[33mWarning: load-env.sh not found, skipping environment setup\033[0m"
fi

# Step 2: Compile SDK
if [[ "$SKIP_COMPILE" != true ]]; then
    write_step 2 "Compile SDK"
    COMPILE_SCRIPT="$SKILLS_DIR/sdk-compile/scripts/compile.sh"
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

# Step 3: Record Tests
write_step 3 "Record Tests"
export AZURE_TEST_MODE="Record"
TESTS_PROJECT=$(find "$SDK_DIR/tests" -name "*.csproj" -type f | head -1)

TEST_ARGS=("test" "$TESTS_PROJECT" "-f" "$FRAMEWORK" "-v" "n")
if [[ -n "$FILTER" ]]; then
    TEST_ARGS+=("--filter" "FullyQualifiedName~$FILTER")
fi

dotnet "${TEST_ARGS[@]}"
if [[ $? -ne 0 ]]; then
    echo -e "\033[31mRecording failed. Aborting workflow.\033[0m"
    exit 1
fi

# Step 4: Push Recordings
write_step 4 "Push Recordings"
ASSETS_FILE="$SDK_DIR/assets.json"
if [[ -f "$ASSETS_FILE" ]]; then
    test-proxy push -a "$ASSETS_FILE"
    if [[ $? -ne 0 ]]; then
        echo -e "\033[31mPush failed. Aborting workflow.\033[0m"
        exit 1
    fi
else
    echo -e "\033[33mWarning: assets.json not found, skipping push\033[0m"
fi

# Step 5: Verify Playback
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

# Summary
END_TIME=$(date +%s)
DURATION=$((END_TIME - START_TIME))
MINUTES=$((DURATION / 60))
SECONDS=$((DURATION % 60))

echo -e "\n\033[32m========================================\033[0m"
echo -e "\033[32mWorkflow Completed Successfully!\033[0m"
echo -e "\033[32m========================================\033[0m"
echo -e "\033[90mDuration: ${MINUTES}m ${SECONDS}s\033[0m"
echo -e "\n\033[33mNext steps:\033[0m"
echo -e "  1. Review the updated assets.json"
echo -e "  2. Commit your changes"
echo -e "  3. Create a pull request"
