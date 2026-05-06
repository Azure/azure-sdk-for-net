# PR scenario results

| Scenario | Expected result | Build link | Notes |
| --- | --- | --- | --- |
| S0 | PR validation stays off unless the caller opts in, so a PR build with a direct `Azure.Core` package change completes without any `Verify Codeowners` task | https://dev.azure.com/azure-sdk/29ec6040-b234-4e31-b139-33dc4287b756/_build/results?buildId=6255823 | `Analyze PRBatch_b1` and `Analyze PRBatch_b2` both succeeded, `Verify Readmes` succeeded, and the build timeline contains no `Verify Codeowners` task at all, confirming the default opt-out behavior. |
| S1 | `Azure.Core` is discovered in `PackageInfo` and skipped for CODEOWNERS because package info marks it with `ArtifactDetails.skipCodeownersVerification` | https://dev.azure.com/azure-sdk/29ec6040-b234-4e31-b139-33dc4287b756/_build/results?buildId=6257946 | `Verify Codeowners` succeeded in logs `350` and `413`; both logs contain `Skipping package: Azure.Core sdk/core/Azure.Core because package info marks it to skip CODEOWNERS verification.` |
