#!/bin/bash

# Build and run the test data generator
# Usage: ./generate-test-data.sh [options]

set -e

SCRIPT_DIR="$(cd "$(dirname "${BASH_SOURCE[0]}")" && pwd)"
PROJECT_DIR="$SCRIPT_DIR"
OUTPUT_DIR="$SCRIPT_DIR/../TestAudio"

echo "Building Test Data Generator..."
dotnet build "$PROJECT_DIR/TestDataGenerator.csproj" --configuration Release

echo "Generating test data..."
dotnet run --project "$PROJECT_DIR/TestDataGenerator.csproj" --configuration Release -- --output "$OUTPUT_DIR" "$@"

echo "Test data generation complete!"
echo "Files generated in: $OUTPUT_DIR"