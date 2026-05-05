# PR CODEOWNERS test plan

## Goal

Validate that the PR-aware CODEOWNERS logic in `Test-CodeownersForArtifacts.ps1` only checks the package directories that should be checked for a given PR state.

## Scope

Run isolated scenarios on the existing draft PR branch. Each scenario must be the only package-affecting change present in the PR, on top of the baseline ENG implementation changes.

## Baseline strategy

1. Push a baseline branch state that contains the ENG implementation changes and reverts the earlier Azure.Template probe changes.
2. For each scenario:
   1. apply only the scenario-specific file changes;
   2. commit only those scenario changes;
   3. push the branch;
   4. wait for the `net - pullrequest` check to complete;
   5. inspect the check result and logs for the expected CODEOWNERS behavior;
   6. if the result matches expectation, record the scenario and build link in `pr.description.md`;
   7. revert the scenario commit so the branch returns to the baseline state before the next scenario.
3. If any scenario produces an unexpected result, stop immediately and summarize the mismatch.

## Algorithm

1. Establish a clean baseline:
   1. keep the PR-aware CODEOWNERS implementation commits;
   2. revert the earlier `Azure.Template` README/CHANGELOG probe commit so package routing is not contaminated by an old package change;
   3. add `test.plan.md` and `pr.description.md`.
2. Push the baseline branch and confirm the PR updates to the intended branch head.
3. Run Scenario S1 and inspect the resulting PR check.
4. Revert Scenario S1.
5. Run Scenario S2 and inspect the resulting PR check.
6. Revert Scenario S2.
7. Run Scenario S3 and inspect the resulting PR check.
8. Revert Scenario S3.
9. Run Scenario S4 and inspect the resulting PR check.
10. Revert Scenario S4 only if the scenario passes as expected and the branch needs to return to baseline.
11. If all scenarios match expectations, commit the final `pr.description.md` updates and push them.

## Exit codes and error handling

- **Success:** all scenarios match their expected results, each scenario is documented in `pr.description.md`, and the branch ends in the intended post-test state.
- **Unexpected pipeline result:** stop the run immediately, summarize expected vs actual behavior, and do not continue to later scenarios.
- **Push failure / check lookup failure / log retrieval failure:** stop the run and report which step could not be completed.
- **Scenario revert failure:** stop the run, summarize the branch state, and do not start the next scenario.

## Edge cases

- A service-level file change such as `sdk/template/ci.yml` can include package metadata without directly changing files in the package directory; that must be skipped in PR-aware CODEOWNERS validation.
- A new package directory may appear in `PackageInfo` even if it is not yet part of the service artifact list; for this test, the requirement is that it appears in `PackageInfo` and is skipped as a brand-new directory by CODEOWNERS validation.
- The ignored-package scenario must still directly touch the package directory so the test proves that artifact exclusion, not path non-matching, caused the skip.
- Only one scenario change may be present in the PR at a time; documentation-only baseline files are allowed.

## Test matrix

| ID | Scenario | Change | Expected evidence |
| --- | --- | --- | --- |
| S1 | Ignored existing package | Directly change a file under `sdk/core/Azure.Core/` | `PackageInfo` still includes the package, and CODEOWNERS logs skip it because the artifact is excluded via `skipCodeownersVerification` |
| S2 | Non-ignored existing package | Directly change a file under `sdk/template/Azure.Template/` | CODEOWNERS validation runs for `sdk/template/Azure.Template` and fails because no CODEOWNERS entry matches that directory |
| S3 | Indirect package inclusion without direct package change | Change `sdk/template/ci.yml` but do not change files under `sdk/template/Azure.Template/` | `Azure.Template` appears in `PackageInfo`, but CODEOWNERS logs the PR-context skip because the PR does not directly change files under the package directory |
| S4 | Brand-new package directory | Add a new package directory under `sdk/template/Azure.Template2/` with the minimum files required to be discovered by package-property generation | `Azure.Template2` appears in `PackageInfo`, and CODEOWNERS logs the brand-new-directory skip |

## Validation notes

- The primary check to watch is the external `net - pullrequest` PR status check.
- Scenario evidence should come from the build summary link plus the relevant log lines that show package discovery and CODEOWNERS behavior.
- `pr.description.md` should record one row per successful scenario with the observed build link.
