#!/bin/bash
# Run Azure SDK tests in PLAYBACK mode
# Usage: ./test-playback.sh [-f "TestName"] [-t net462]

FILTER=""
FRAMEWORK="net462"

# Parse arguments
while [[ $# -gt 0 ]]; do
    case $1 in
        -f|--filter)
            FILTER="$2"
            shift 2
            ;;
        -t|--framework)
            FRAMEWORK="$2"
            shift 2
            ;;
        *)
            shift
            ;;
    esac
done

# Set test mode to Playback
export AZURE_TEST_MODE="Playback"

# Find test project
SDK_DIR=$(pwd)
TESTS_PROJECT=$(find "$SDK_DIR/tests" -name "*.csproj" -type f | head -1)

if [[ -z "$TESTS_PROJECT" ]]; then
    echo -e "\033[31mError: No test project found in tests/ directory\033[0m"
    exit 1
fi

echo -e "\033[33mRunning tests in PLAYBACK mode...\033[0m"
echo -e "\033[36mTest Project: $(basename $TESTS_PROJECT)\033[0m"
echo -e "\033[36mFramework: $FRAMEWORK\033[0m"
echo -e "\033[36mAZURE_TEST_MODE: $AZURE_TEST_MODE\033[0m"

# Build command
TEST_ARGS=("test" "$TESTS_PROJECT" "-f" "$FRAMEWORK" "-v" "n")

if [[ -n "$FILTER" ]]; then
    TEST_ARGS+=("--filter" "FullyQualifiedName~$FILTER")
    echo -e "\033[36mFilter: $FILTER\033[0m"
fi

echo -e "\n\033[33mStarting test execution...\033[0m"

# Run tests
dotnet "${TEST_ARGS[@]}"
EXIT_CODE=$?

if [[ $EXIT_CODE -eq 0 ]]; then
    echo -e "\n\033[32mAll tests passed in PLAYBACK mode!\033[0m"
else
    echo -e "\n\033[31mTests failed with exit code: $EXIT_CODE\033[0m"
    echo -e "\033[33mIf recordings are outdated, re-record with sdk-test-record\033[0m"
fi

exit $EXIT_CODE
