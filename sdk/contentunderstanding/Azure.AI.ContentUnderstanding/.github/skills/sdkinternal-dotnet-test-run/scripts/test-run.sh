#!/bin/bash
#
# Unified Azure SDK Test Runner
#
# Supports: Playback, Record, Live modes; single/all samples; code coverage.
#
# Usage:
#   ./test-run.sh [options]
#
# Options:
#   --mode MODE           Test mode: playback (default), record, live
#   -f, --filter FILTER   Filter tests by name
#   --sample NAME         Run a single sample by method name
#   --samples             Run all samples
#   --list-samples        List available sample methods
#   --coverage            Collect code coverage (Playback mode)
#   --custom-only         Show coverage for custom code only
#   --report-only         Only generate HTML coverage report (no test run)
#   -t, --framework FW    Target framework (default: net10.0)
#   --continue-on-error   Don't stop on sample failures
#   --no-build            Skip build step (coverage mode)
#   -h, --help            Show help
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

# ── Defaults ──────────────────────────────────────────────────────────────────
MODE="playback"
FILTER=""
SAMPLE_NAME=""
RUN_SAMPLES=false
LIST_SAMPLES=false
COVERAGE=false
CUSTOM_ONLY=false
REPORT_ONLY=false
FRAMEWORK=""
CONTINUE_ON_ERROR=false
NO_BUILD=false

# ── Parse arguments ───────────────────────────────────────────────────────────
while [[ $# -gt 0 ]]; do
    case $1 in
        --mode|-m)
            MODE=$(echo "$2" | tr '[:upper:]' '[:lower:]')
            shift 2
            ;;
        -f|--filter)
            FILTER="$2"
            shift 2
            ;;
        --sample)
            SAMPLE_NAME="$2"
            shift 2
            ;;
        --samples)
            RUN_SAMPLES=true
            shift
            ;;
        --list-samples)
            LIST_SAMPLES=true
            shift
            ;;
        --coverage)
            COVERAGE=true
            shift
            ;;
        --custom-only|-c)
            CUSTOM_ONLY=true
            shift
            ;;
        --report-only|-r)
            REPORT_ONLY=true
            shift
            ;;
        -t|--framework)
            FRAMEWORK="$2"
            shift 2
            ;;
        --continue-on-error)
            CONTINUE_ON_ERROR=true
            shift
            ;;
        --no-build|-n)
            NO_BUILD=true
            shift
            ;;
        -h|--help)
            head -23 "$0" | tail -20
            exit 0
            ;;
        *)
            echo "Unknown option: $1"
            exit 1
            ;;
    esac
done

# ── Resolve framework default ────────────────────────────────────────────────
if [[ -z "$FRAMEWORK" ]]; then
    FRAMEWORK="net10.0"
fi

# ── Locate project ───────────────────────────────────────────────────────────
SDK_DIR=$(pwd)
SAMPLES_DIR="$SDK_DIR/tests/samples"
TESTS_PROJECT=$(find "$SDK_DIR/tests" -name "*.csproj" -type f | head -1)
TESTS_DIR="$SDK_DIR/tests"
TEST_RESULTS_DIR="$TESTS_DIR/TestResults"
COVERAGE_REPORT_DIR="$TESTS_DIR/CoverageReport"
ASSETS_FILE="$SDK_DIR/assets.json"

if [[ -z "$TESTS_PROJECT" ]]; then
    echo -e "\033[31mError: No test project found in tests/ directory\033[0m"
    exit 1
fi

# ── Helper: find latest coverage file ────────────────────────────────────────
find_coverage_file() {
    find "$TEST_RESULTS_DIR" -name "coverage.cobertura.xml" -type f 2>/dev/null | \
        xargs -I {} stat -c '%Y %n' {} 2>/dev/null | \
        sort -rn | head -1 | cut -d' ' -f2-
}

# ══════════════════════════════════════════════════════════════════════════════
#  List Samples
# ══════════════════════════════════════════════════════════════════════════════
if [[ "$LIST_SAMPLES" == true ]]; then
    if [[ ! -d "$SAMPLES_DIR" ]]; then
        echo -e "\033[31mError: Samples directory not found at tests/samples/\033[0m"
        exit 1
    fi

    echo -e "\033[33mAvailable sample methods:\033[0m"
    echo -e "\033[90m(Use these names with --sample)\033[0m"
    for sample in "$SAMPLES_DIR"/Sample*.cs; do
        if [[ -f "$sample" ]]; then
            filename=$(basename "$sample" .cs)
            perl -0777 -ne 'while (/\[(RecordedTest|Test)\][^\{]*public\s+async\s+Task\s+(\w+)\s*\(/g) { print "$2\n"; }' "$sample" | while read -r method; do
                echo -e "\033[36m  $method\033[0m \033[90m($filename)\033[0m"
            done
        fi
    done
    exit 0
fi

# ══════════════════════════════════════════════════════════════════════════════
#  Report-Only Mode (coverage)
# ══════════════════════════════════════════════════════════════════════════════
if [[ "$REPORT_ONLY" == true ]]; then
    COVERAGE_FILE=$(find_coverage_file)
    if [[ -z "$COVERAGE_FILE" ]]; then
        echo -e "\033[31mError: No coverage file found. Run tests with --coverage first.\033[0m"
        exit 1
    fi
    echo -e "\033[33mGenerating HTML report from: $COVERAGE_FILE\033[0m"
    dotnet tool run reportgenerator -- \
        "-reports:$COVERAGE_FILE" \
        "-targetdir:$COVERAGE_REPORT_DIR" \
        -reporttypes:Html
    echo -e "\033[32mHTML report generated: $COVERAGE_REPORT_DIR/index.html\033[0m"
    exit 0
fi

# ══════════════════════════════════════════════════════════════════════════════
#  Set Test Mode
# ══════════════════════════════════════════════════════════════════════════════
case "$MODE" in
    playback)
        export AZURE_TEST_MODE="Playback"
        ;;
    record)
        export AZURE_TEST_MODE="Record"
        ;;
    live)
        export AZURE_TEST_MODE="Live"
        ;;
    *)
        echo -e "\033[31mError: Invalid mode '$MODE'. Use: playback, record, live\033[0m"
        exit 1
        ;;
esac

# Override to Playback for coverage (coverage always runs against recordings)
if [[ "$COVERAGE" == true ]]; then
    export AZURE_TEST_MODE="Playback"
fi

# ── Header ────────────────────────────────────────────────────────────────────
echo "═══════════════════════════════════════════════════════════"
echo "  Azure SDK Test Runner"
echo "═══════════════════════════════════════════════════════════"
echo ""
echo -e "\033[36mTest Project: $(basename $TESTS_PROJECT)\033[0m"
echo -e "\033[36mFramework:    $FRAMEWORK\033[0m"
echo -e "\033[36mTest Mode:    $AZURE_TEST_MODE\033[0m"

if [[ -n "$SAMPLE_NAME" ]]; then
    echo -e "\033[36mSample:       $SAMPLE_NAME\033[0m"
elif [[ "$RUN_SAMPLES" == true ]]; then
    echo -e "\033[36mTarget:       All Samples\033[0m"
fi

if [[ "$COVERAGE" == true ]]; then
    echo -e "\033[36mCoverage:     Enabled\033[0m"
fi
echo ""

# ══════════════════════════════════════════════════════════════════════════════
#  Single Sample Run
# ══════════════════════════════════════════════════════════════════════════════
if [[ -n "$SAMPLE_NAME" ]]; then
    if [[ ! -d "$SAMPLES_DIR" ]]; then
        echo -e "\033[31mError: Samples directory not found at tests/samples/\033[0m"
        exit 1
    fi

    echo -e "\033[33mRunning sample: $SAMPLE_NAME\033[0m"
    FILTER="FullyQualifiedName~$SAMPLE_NAME"

    dotnet test "$TESTS_PROJECT" -f "$FRAMEWORK" -v n --filter "$FILTER"
    EXIT_CODE=$?

    if [[ $EXIT_CODE -eq 0 ]]; then
        echo -e "\n\033[32mSample executed successfully!\033[0m"
    else
        echo -e "\n\033[31mSample failed with exit code: $EXIT_CODE\033[0m"
    fi
    exit $EXIT_CODE
fi

# ══════════════════════════════════════════════════════════════════════════════
#  All Samples Run
# ══════════════════════════════════════════════════════════════════════════════
if [[ "$RUN_SAMPLES" == true ]]; then
    if [[ ! -d "$SAMPLES_DIR" ]]; then
        echo -e "\033[31mError: Samples directory not found at tests/samples/\033[0m"
        exit 1
    fi

    SAMPLE_COUNT=$(find "$SAMPLES_DIR" -name "Sample*.cs" -type f | wc -l)
    echo -e "\033[33mFound $SAMPLE_COUNT sample files. Running all samples...\033[0m"

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
fi

# ══════════════════════════════════════════════════════════════════════════════
#  Coverage Test Run
# ══════════════════════════════════════════════════════════════════════════════
if [[ "$COVERAGE" == true ]]; then
    TEST_ARGS=("test" "$TESTS_PROJECT" "-f" "$FRAMEWORK" "/p:CollectCoverage=true")

    if [[ "$NO_BUILD" == true ]]; then
        TEST_ARGS+=("--no-build")
    fi

    if [[ -n "$FILTER" ]]; then
        TEST_ARGS+=("--filter" "$FILTER")
        echo -e "\033[36mFilter: $FILTER\033[0m"
    fi

    echo -e "\033[33mRunning tests with coverage collection...\033[0m"
    echo ""

    dotnet "${TEST_ARGS[@]}"

    # Find and report coverage
    COVERAGE_FILE=$(find_coverage_file)
    if [[ -z "$COVERAGE_FILE" ]]; then
        echo -e "\033[33mWarning: No coverage file found\033[0m"
        exit 0
    fi

    echo ""
    echo -e "\033[36mCoverage data: $COVERAGE_FILE\033[0m"

    # Generate HTML report
    echo -e "\033[33mGenerating HTML report...\033[0m"
    dotnet tool run reportgenerator -- \
        "-reports:$COVERAGE_FILE" \
        "-targetdir:$COVERAGE_REPORT_DIR" \
        -reporttypes:Html 2>/dev/null || \
        echo "Note: ReportGenerator not available. Install with: dotnet tool install -g dotnet-reportgenerator-globaltool"

    echo -e "\033[36mHTML report: $COVERAGE_REPORT_DIR/index.html\033[0m"

    echo ""
    echo "═══════════════════════════════════════════════════════════"
    echo -e "\033[32m  Coverage collection complete!\033[0m"
    echo "═══════════════════════════════════════════════════════════"
    exit 0
fi

# ══════════════════════════════════════════════════════════════════════════════
#  Standard Test Run (Playback / Record / Live)
# ══════════════════════════════════════════════════════════════════════════════
TEST_ARGS=("test" "$TESTS_PROJECT" "-f" "$FRAMEWORK" "-v" "n")

if [[ -n "$FILTER" ]]; then
    TEST_ARGS+=("--filter" "FullyQualifiedName~$FILTER")
    echo -e "\033[36mFilter: $FILTER\033[0m"
fi

echo -e "\033[33mStarting test execution...\033[0m"

dotnet "${TEST_ARGS[@]}"
EXIT_CODE=$?

if [[ $EXIT_CODE -eq 0 ]]; then
    echo -e "\n\033[32mAll tests passed in $AZURE_TEST_MODE mode!\033[0m"

    if [[ "$MODE" == "record" ]]; then
        echo -e "\033[33mNext step: Push recordings with 'sdkinternal-dotnet-test-push' or 'test-proxy push -a assets.json'\033[0m"
    fi
else
    echo -e "\n\033[31mTests failed with exit code: $EXIT_CODE\033[0m"

    if [[ "$MODE" == "playback" ]]; then
        echo -e "\033[33mIf recordings are outdated, re-record with: ./test-run.sh --mode record\033[0m"
    fi
fi

exit $EXIT_CODE
