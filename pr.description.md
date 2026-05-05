# PR scenario results

| Scenario | Expected result | Build link | Notes |
| --- | --- | --- | --- |
| S1 | `Azure.Core` is discovered in `PackageInfo` and skipped for CODEOWNERS because package info marks it with `ArtifactDetails.skipCodeownersVerification` | https://dev.azure.com/azure-sdk/29ec6040-b234-4e31-b139-33dc4287b756/_build/results?buildId=6253825 | `Verify Codeowners` succeeded in logs `837` and `1308`; log `837` contains `Skipping package: Azure.Core sdk/core/Azure.Core because package info marks it to skip CODEOWNERS verification.` |
