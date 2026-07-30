# CI Validation (Temporary)

This file exists only to trigger the `containerregistry` service CI pipeline on a branch based
on latest `main`, with no other changes.

Purpose: validate whether the `Azure.ResourceManager.ContainerRegistry` ApiCompat (CP0017)
failures seen in PR #61055 (`provisioning/onboard-containerregistry-tasks`) reproduce
independently of that PR's changes, i.e. whether they already exist on `main`.

Prior failure signatures under investigation (from PR #61055, build 6637434):
- `ContainerRegistryRunData` model-factory parameter name/order mismatch
- `ContainerRegistryTaskStepProperties` model-factory parameter name/order mismatch

This file is not intended to merge and should be deleted once validation is complete.
