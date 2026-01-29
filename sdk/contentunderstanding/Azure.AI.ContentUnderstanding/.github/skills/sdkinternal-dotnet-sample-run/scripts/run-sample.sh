#!/bin/bash
# Run a single Azure SDK sample
# Usage: ./run-sample.sh -s "Sample01_AnalyzeBinary" [--live] [--list]

SAMPLE_NAME=""
LIVE=false
LIST=false
FRAMEWORK="net462"

# Parse arguments
while [[ $# -gt 0 ]]; do
    case $1 in
        -s|--sample)
            SAMPLE_NAME="$2"
            shift 2
            ;;
        --live|-l)
            LIVE=true
            shift
            ;;
        --list)
            LIST=true
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

# List available samples
if [[ "$LIST" == true ]]; then
    echo -e "\033[33mAvailable samples:\033[0m"
    for sample in "$SAMPLES_DIR"/Sample*.cs; do
        if [[ -f "$sample" ]]; then
            echo -e "\033[36m  $(basename "$sample" .cs)\033[0m"
        fi
    done
    exit 0
fi

# Validate sample name
if [[ -z "$SAMPLE_NAME" ]]; then
    echo -e "\033[31mError: Sample name is required\033[0m"
    echo -e "\033[33mUsage: ./run-sample.sh -s \"Sample01_AnalyzeBinary\"\033[0m"
    echo -e "\033[33mUse --list to see available samples\033[0m"
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

echo -e "\033[33mRunning sample: $SAMPLE_NAME\033[0m"
echo -e "\033[36mFramework: $FRAMEWORK\033[0m"

# Build filter
FILTER="FullyQualifiedName~$SAMPLE_NAME"

# Run the sample
echo -e "\n\033[33mExecuting sample...\033[0m"
dotnet test "$TESTS_PROJECT" -f "$FRAMEWORK" -v n --filter "$FILTER"

EXIT_CODE=$?

if [[ $EXIT_CODE -eq 0 ]]; then
    echo -e "\n\033[32mSample executed successfully!\033[0m"
else
    echo -e "\n\033[31mSample failed with exit code: $EXIT_CODE\033[0m"
fi

exit $EXIT_CODE
