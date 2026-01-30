#!/bin/bash
# Run all Azure SDK samples
# Usage: ./run-all-samples.sh [--live] [--continue-on-error]

LIVE=false
CONTINUE_ON_ERROR=false
FRAMEWORK="net462"

# Parse arguments
while [[ $# -gt 0 ]]; do
    case $1 in
        --live|-l)
            LIVE=true
            shift
            ;;
        --continue-on-error|-c)
            CONTINUE_ON_ERROR=true
            shift
            ;;
        -f|--framework)
            FRAMEWORK="$2"
            shift 2
            ;;
        *)
            shift
            ;;
    esac
done

# Find SDK directory and samples
SDK_DIR=$(pwd)
SAMPLES_DIR="$SDK_DIR/tests/samples"
TESTS_PROJECT=$(find "$SDK_DIR/tests" -name "*.csproj" -type f | head -1)

if [[ ! -d "$SAMPLES_DIR" ]]; then
    echo -e "\033[31mError: Samples directory not found at tests/samples/\033[0m"
    exit 1
fi

if [[ -z "$TESTS_PROJECT" ]]; then
    echo -e "\033[31mError: No test project found in tests/ directory\033[0m"
    exit 1
fi

# Set test mode
if [[ "$LIVE" == true ]]; then
    export AZURE_TEST_MODE="Live"
    echo -e "\033[35mRunning in LIVE mode (requires Azure credentials)\033[0m"
else
    export AZURE_TEST_MODE="Playback"
    echo -e "\033[36mRunning in PLAYBACK mode\033[0m"
fi

# Count sample files
SAMPLE_COUNT=$(find "$SAMPLES_DIR" -name "Sample*.cs" -type f | wc -l)

echo -e "\033[33mFound $SAMPLE_COUNT sample files\033[0m"
echo -e "\033[36mFramework: $FRAMEWORK\033[0m"
echo -e "\033[36mTest Project: $(basename $TESTS_PROJECT)\033[0m"

# Run all samples using test filter
echo -e "\n\033[33mRunning all samples...\033[0m"

FILTER="FullyQualifiedName~Samples"

dotnet test "$TESTS_PROJECT" -f "$FRAMEWORK" -v n --filter "$FILTER"

EXIT_CODE=$?

if [[ $EXIT_CODE -eq 0 ]]; then
    echo -e "\n\033[32mAll samples executed successfully!\033[0m"
else
    echo -e "\n\033[31mSome samples failed (exit code: $EXIT_CODE)\033[0m"
    if [[ "$CONTINUE_ON_ERROR" != true ]]; then
        exit $EXIT_CODE
    fi
fi

exit $EXIT_CODE
