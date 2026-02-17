#!/bin/bash
# Regression test for all Azure AI Content Understanding .NET SDK samples
# Runs every sample (Sample00–Sample15) and reports pass/fail results.
#
# Usage: ./test-sdk-dotnet-sample-run.sh
# Results are written to stdout and /tmp/test-sdk-dotnet-sample-run_results.txt

set -o pipefail

# Determine script directory and locate run-sample.sh
SCRIPT_DIR="$(cd "$(dirname "${BASH_SOURCE[0]}")" && pwd)"
PACKAGE_ROOT="$(cd "$SCRIPT_DIR/../../../.." && pwd)"
RUN_SAMPLE_SCRIPT="$PACKAGE_ROOT/.github/skills/sdk-dotnet-sample-run/scripts/run-sample.sh"

if [ ! -f "$RUN_SAMPLE_SCRIPT" ]; then
    echo "Error: run-sample.sh not found at: $RUN_SAMPLE_SCRIPT"
    echo "Ensure the sdk-dotnet-sample-run skill is installed."
    exit 1
fi

LOG=/tmp/test-sdk-dotnet-sample-run_results.txt
> "$LOG"

# All samples in order
samples=(
  Sample00_UpdateDefaults
  Sample01_AnalyzeBinary
  Sample02_AnalyzeUrl
  Sample03_AnalyzeInvoice
  Sample04_CreateAnalyzer
  Sample05_CreateClassifier
  Sample06_GetAnalyzer
  Sample07_ListAnalyzers
  Sample08_UpdateAnalyzer
  Sample09_DeleteAnalyzer
  Sample10_AnalyzeConfigs
  Sample11_AnalyzeReturnRawJson
  Sample12_GetResultFile
  Sample13_DeleteResult
  Sample14_CopyAnalyzer
  Sample15_GrantCopyAuth
)

echo "=== Content Understanding .NET SDK Sample Regression Test ==="
echo "Running ${#samples[@]} samples..."
echo "Start time: $(date)"
echo ""

start_time=$(date +%s)

for s in "${samples[@]}"; do
  sample_start=$(date +%s)
  output=$(bash "$RUN_SAMPLE_SCRIPT" "${s}.md" --run 2>&1)
  rc=$?
  sample_end=$(date +%s)
  elapsed=$((sample_end - sample_start))

  if [ $rc -eq 0 ]; then
    echo "PASS: $s (${elapsed}s)" | tee -a "$LOG"
  else
    # Check if it's a build error or runtime error
    if echo "$output" | grep -q "error CS"; then
      echo "FAIL(build): $s (${elapsed}s)" | tee -a "$LOG"
      echo "$output" | grep "error CS" | head -5 >> "$LOG"
    else
      echo "FAIL(runtime): $s (exit=$rc, ${elapsed}s)" | tee -a "$LOG"
      # Include last few lines of output for context
      echo "$output" | tail -5 >> "$LOG"
    fi
  fi
done

end_time=$(date +%s)
total_elapsed=$((end_time - start_time))

echo "" | tee -a "$LOG"
echo "=== SUMMARY ===" | tee -a "$LOG"
pass=$(grep -c "^PASS" "$LOG")
fail=$(grep -c "^FAIL" "$LOG")
echo "Passed: $pass / ${#samples[@]}" | tee -a "$LOG"
echo "Failed: $fail / ${#samples[@]}" | tee -a "$LOG"
echo "Total time: ${total_elapsed}s" | tee -a "$LOG"

if [ "$fail" -gt 0 ]; then
  echo "" | tee -a "$LOG"
  echo "Failed samples:" | tee -a "$LOG"
  grep "^FAIL" "$LOG" | tee -a /dev/null
fi

echo "" | tee -a "$LOG"
echo "End time: $(date)" | tee -a "$LOG"
echo "Full results: $LOG"
echo "DONE"

exit "$fail"
