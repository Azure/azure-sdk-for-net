#!/bin/bash
# Push test session recordings to Azure SDK Assets repository
# Usage: ./push-recordings.sh [--dry-run]

DRY_RUN=false

# Parse arguments
while [[ $# -gt 0 ]]; do
    case $1 in
        --dry-run|-d)
            DRY_RUN=true
            shift
            ;;
        *)
            shift
            ;;
    esac
done

# Find assets.json
SDK_DIR=$(pwd)
ASSETS_FILE="$SDK_DIR/assets.json"

if [[ ! -f "$ASSETS_FILE" ]]; then
    echo -e "\033[31mError: assets.json not found in current directory\033[0m"
    echo -e "\033[33mAre you in the SDK module directory?\033[0m"
    exit 1
fi

# Check if test-proxy is available
if ! command -v test-proxy &> /dev/null; then
    echo -e "\033[31mError: test-proxy command not found\033[0m"
    echo -e "\033[33mInstall test-proxy: dotnet tool install -g Azure.Sdk.Tools.TestProxy\033[0m"
    exit 1
fi

echo -e "\033[33mPushing recordings to Azure SDK Assets repository...\033[0m"
echo -e "\033[36mAssets file: $ASSETS_FILE\033[0m"

if [[ "$DRY_RUN" == true ]]; then
    echo -e "\033[35mDRY RUN - No changes will be made\033[0m"
    
    # Show current assets.json content
    echo -e "\n\033[33mCurrent assets.json:\033[0m"
    cat "$ASSETS_FILE"
    
    echo -e "\n\033[33mDry run complete. Use without --dry-run to actually push.\033[0m"
    exit 0
fi

# Push recordings
echo -e "\n\033[36mExecuting: test-proxy push -a assets.json\033[0m"
test-proxy push -a "$ASSETS_FILE"

EXIT_CODE=$?

if [[ $EXIT_CODE -eq 0 ]]; then
    echo -e "\n\033[32mRecordings pushed successfully!\033[0m"
    echo -e "\033[33mDon't forget to commit the updated assets.json\033[0m"
    
    # Show updated assets.json
    echo -e "\n\033[33mUpdated assets.json:\033[0m"
    cat "$ASSETS_FILE"
else
    echo -e "\n\033[31mFailed to push recordings (exit code: $EXIT_CODE)\033[0m"
    echo -e "\033[33mCheck your git credentials and network connection\033[0m"
fi

exit $EXIT_CODE
