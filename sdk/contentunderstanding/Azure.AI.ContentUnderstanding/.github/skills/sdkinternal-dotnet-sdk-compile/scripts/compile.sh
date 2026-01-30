#!/bin/bash
# Compile Azure SDK for .NET
# Usage: ./compile.sh [-c Debug|Release]

CONFIGURATION="Debug"

# Parse arguments
while [[ $# -gt 0 ]]; do
    case $1 in
        -c|--configuration)
            CONFIGURATION="$2"
            shift 2
            ;;
        *)
            shift
            ;;
    esac
done

# Find SDK root directory
SDK_DIR=$(pwd)
SRC_PROJECT="$SDK_DIR/src/*.csproj"
TESTS_PROJECT="$SDK_DIR/tests/*.csproj"

# Check if we're in SDK module directory
if ! ls $SRC_PROJECT 1>/dev/null 2>&1; then
    echo -e "\033[31mError: No src/*.csproj found. Are you in the SDK module directory?\033[0m"
    exit 1
fi

echo -e "\033[33mBuilding Azure SDK for .NET...\033[0m"
echo -e "\033[36mConfiguration: $CONFIGURATION\033[0m"

# Build main library
echo -e "\n\033[33mBuilding main library...\033[0m"
for proj in $SRC_PROJECT; do
    echo -e "\033[36m  Building: $(basename $proj)\033[0m"
    dotnet build "$proj" -c "$CONFIGURATION"
    if [[ $? -ne 0 ]]; then
        echo -e "\033[31mBuild failed for $(basename $proj)\033[0m"
        exit 1
    fi
done

# Build test project if exists
if ls $TESTS_PROJECT 1>/dev/null 2>&1; then
    echo -e "\n\033[33mBuilding test project...\033[0m"
    for proj in $TESTS_PROJECT; do
        echo -e "\033[36m  Building: $(basename $proj)\033[0m"
        dotnet build "$proj" -c "$CONFIGURATION"
        if [[ $? -ne 0 ]]; then
            echo -e "\033[31mBuild failed for $(basename $proj)\033[0m"
            exit 1
        fi
    done
fi

echo -e "\n\033[32mBuild completed successfully!\033[0m"
