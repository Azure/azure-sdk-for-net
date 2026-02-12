---
name: sdkinternal-dotnet-user-skill-test
description: Run a regression test across all Azure AI Content Understanding .NET SDK samples. Executes every sample (Sample00–Sample15) via the sdk-dotnet-sample-run skill, reports pass/fail for each, and produces a summary. Use to validate that all samples compile and run correctly after script or sample markdown changes.
---

# Regression Test All .NET SDK Samples

Run all 16 Azure AI Content Understanding SDK samples end-to-end and report pass/fail results.

## What This Skill Does

1. Iterates through every sample (`Sample00_UpdateDefaults` through `Sample15_GrantCopyAuth`)
2. Runs each sample using the `sdk-dotnet-sample-run` skill's `run-sample.sh` script
3. Classifies failures as **build errors** (CS compiler errors) or **runtime errors**
4. Produces a summary with pass/fail counts and details of any failures
5. Writes detailed results to `/tmp/test-sdk-dotnet-sample-run_results.txt`

## Prerequisites

- All prerequisites from `sdk-dotnet-sample-run` must be met (endpoint, credentials, model deployments)
- For Sample15 (cross-resource copy), the cross-resource environment variables must be configured in `appsettings.json`. See the `sdk-dotnet-sample-run` skill documentation for details.
- Run `Sample00_UpdateDefaults` at least once to configure model deployment mappings

## Package Directory

```
sdk/contentunderstanding/Azure.AI.ContentUnderstanding
```

## Workflow

### Step 1: Navigate to Package Directory

```bash
cd sdk/contentunderstanding/Azure.AI.ContentUnderstanding
```

### Step 2: Ensure Credentials Are Configured

Verify `appsettings.json` exists with at minimum:

```json
{
  "CONTENTUNDERSTANDING_ENDPOINT": "https://your-foundry.services.ai.azure.com/"
}
```

For full coverage including Sample15, also configure the cross-resource settings (see `sdk-dotnet-sample-run` skill).

### Step 3: Run the Regression Test

```bash
# Run all samples (takes ~15-20 minutes)
bash .github/skills/sdkinternal-dotnet-user-skill-test/scripts/test-sdk-dotnet-sample-run.sh

# Or run in background and monitor
nohup bash .github/skills/sdkinternal-dotnet-user-skill-test/scripts/test-sdk-dotnet-sample-run.sh > /tmp/test-sdk-dotnet-sample-run_output.txt 2>&1 &
tail -f /tmp/test-sdk-dotnet-sample-run_output.txt
```

### Step 4: Review Results

Results are printed to stdout and also saved to `/tmp/test-sdk-dotnet-sample-run_results.txt`:

```
PASS: Sample00_UpdateDefaults
PASS: Sample01_AnalyzeBinary
...
FAIL(build): Sample04_CreateAnalyzer
  error CS0103: The name 'foo' does not exist in the current context
...

=== SUMMARY ===
Passed: 15 / 16
Failed: 1 / 16
FAIL(build): Sample04_CreateAnalyzer
```

## Expected Output

When all samples pass:

```
=== SUMMARY ===
Passed: 16 / 16
Failed: 0 / 16
DONE
```

## Failure Types

| Type | Meaning | Typical Cause |
|------|---------|---------------|
| `FAIL(build)` | C# compilation error | Sample markdown has incorrect code, script assembles code wrong, type/namespace issues |
| `FAIL(runtime)` | Program runs but exits non-zero | Service errors (endpoint down, missing role), missing env config, API changes |

## When to Run

- After modifying `run-sample.sh` or `run-sample.ps1`
- After editing any sample markdown file
- After SDK source code changes that may affect samples
- Before submitting PRs that touch sample infrastructure

## Troubleshooting

| Issue | Solution |
|-------|----------|
| Sample15 fails with DNS error | Configure cross-resource env vars in `appsettings.json` |
| Samples fail with auth errors | Run `az login` or configure API key |
| Build failures after SDK changes | Check the generated `Program.cs` in `.sample_runner/<SampleName>/` |
| All samples fail | Verify `appsettings.json` exists and endpoint is correct |

## Related Skills

- `sdk-dotnet-sample-run` — Run individual samples (this skill depends on it)
