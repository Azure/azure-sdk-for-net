# PR scenario results

| Scenario | Expected result | Build link | Notes |
| --- | --- | --- | --- |
| S0 | PR validation stays off unless the caller opts in, so a PR build with a direct `Azure.Core` package change completes without any `Verify Codeowners` task | https://dev.azure.com/azure-sdk/29ec6040-b234-4e31-b139-33dc4287b756/_build/results?buildId=6255823 | `Analyze PRBatch_b1` and `Analyze PRBatch_b2` both succeeded, `Verify Readmes` succeeded, and the build timeline contains no `Verify Codeowners` task at all, confirming the default opt-out behavior. |
