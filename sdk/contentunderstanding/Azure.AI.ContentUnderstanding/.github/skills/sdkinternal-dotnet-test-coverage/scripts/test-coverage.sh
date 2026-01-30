#!/bin/bash
#
# Run Azure SDK tests with code coverage collection.
#
# Usage:
#   ./test-coverage.sh [options]
#
# Options:
#   -f, --filter FILTER     Test filter expression
#   -t, --framework FW      Target framework (default: net8.0)
#   -r, --report-only       Only generate HTML report
#   -c, --custom-only       Show custom code coverage only
#   -n, --no-build          Skip build step
#   -h, --help              Show help
#

set -e

# Default values
FILTER=""
FRAMEWORK="net8.0"
REPORT_ONLY=false
CUSTOM_ONLY=false
NO_BUILD=false

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
        -r|--report-only)
            REPORT_ONLY=true
            shift
            ;;
        -c|--custom-only)
            CUSTOM_ONLY=true
            shift
            ;;
        -n|--no-build)
            NO_BUILD=true
            shift
            ;;
        -h|--help)
            head -20 "$0" | tail -17
            exit 0
            ;;
        *)
            echo "Unknown option: $1"
            exit 1
            ;;
    esac
done

# Get directories
SCRIPT_DIR="$(cd "$(dirname "${BASH_SOURCE[0]}")" && pwd)"
SKILL_DIR="$(dirname "$SCRIPT_DIR")"
MODULE_DIR="$(dirname "$(dirname "$(dirname "$SKILL_DIR")")")"
TESTS_DIR="$MODULE_DIR/tests"
TEST_PROJECT="$TESTS_DIR/Azure.AI.ContentUnderstanding.Tests.csproj"
TEST_RESULTS_DIR="$TESTS_DIR/TestResults"
COVERAGE_REPORT_DIR="$TESTS_DIR/CoverageReport"

echo "═══════════════════════════════════════════════════════════"
echo "  Azure.AI.ContentUnderstanding Test Coverage"
echo "═══════════════════════════════════════════════════════════"
echo ""

# Find latest coverage file
find_coverage_file() {
    find "$TEST_RESULTS_DIR" -name "coverage.cobertura.xml" -type f 2>/dev/null | \
        xargs -I {} stat -c '%Y %n' {} 2>/dev/null | \
        sort -rn | head -1 | cut -d' ' -f2-
}

# Generate report only mode
if [ "$REPORT_ONLY" = true ]; then
    COVERAGE_FILE=$(find_coverage_file)
    if [ -z "$COVERAGE_FILE" ]; then
        echo "Error: No coverage file found. Run tests first."
        exit 1
    fi
    
    echo "Generating HTML report from: $COVERAGE_FILE"
    
    dotnet tool run reportgenerator -- \
        "-reports:$COVERAGE_FILE" \
        "-targetdir:$COVERAGE_REPORT_DIR" \
        -reporttypes:Html
    
    echo ""
    echo "HTML report generated: $COVERAGE_REPORT_DIR/index.html"
    exit 0
fi

# Set PLAYBACK mode
export AZURE_TEST_MODE="Playback"
echo "Test Mode: PLAYBACK"

# Build test command
TEST_ARGS=("test" "$TEST_PROJECT" "-f" "$FRAMEWORK" "/p:CollectCoverage=true")

if [ "$NO_BUILD" = true ]; then
    TEST_ARGS+=("--no-build")
fi

if [ -n "$FILTER" ]; then
    TEST_ARGS+=("--filter" "$FILTER")
    echo "Filter: $FILTER"
fi

echo "Framework: $FRAMEWORK"
echo ""

# Run tests with coverage
echo "Running tests with coverage collection..."
echo ""

dotnet "${TEST_ARGS[@]}"

# Find coverage file
COVERAGE_FILE=$(find_coverage_file)
if [ -z "$COVERAGE_FILE" ]; then
    echo ""
    echo "Warning: No coverage file found"
    exit 0
fi

echo ""
echo "Coverage data: $COVERAGE_FILE"

# Generate HTML report
echo ""
echo "Generating HTML report..."

dotnet tool run reportgenerator -- \
    "-reports:$COVERAGE_FILE" \
    "-targetdir:$COVERAGE_REPORT_DIR" \
    -reporttypes:Html 2>/dev/null || \
    echo "Note: ReportGenerator not available. Install with: dotnet tool install -g dotnet-reportgenerator-globaltool"

echo "HTML report: $COVERAGE_REPORT_DIR/index.html"

echo ""
echo "═══════════════════════════════════════════════════════════"
echo "  Coverage collection complete!"
echo "═══════════════════════════════════════════════════════════"
