# Owners and Labels Reference

## Owner Types

- **Source Owners** — Own packages and paths; requested to review PRs when package files change.
- **Service Owners** — Own service labels; `@`-mentioned when "Service Attention" label is applied to an issue.
- **Azure SDK Owners** — Own service labels; responsible for triaging issues for that service area (generally Azure SDK team members).
- **PR Label** — Used with a path to automatically apply a label to PRs changing files under that path.

To be valid at release, a package must have at least 2 source owners, a label, and that label should have Service Owners.

## Adding Package Owners

Use `azsdk_engsys_codeowner_add_package_owner`. Provide the GitHub username(s), package name, and target repository.

## Adding a Label to a Package

Use `azsdk_engsys_codeowner_add_package_label`. Provide the label name, package name, and target repository.

If adding fails because the label does not exist, prompt the user to use a different label or help them create a new one (see Creating a Service Label below).

## Adding Service Owners to a Label

Use `azsdk_engsys_codeowner_add_label_owner`. Provide the GitHub username(s), owner type (e.g. `ServiceOwner`), label name, and target repository.

## Creating a Service Label

Service labels identify Azure services. The label may already exist.

1. Collect the label from the user (e.g. `Storage`) and check with `azsdk_check_service_label`.
2. If it does not exist, collect a URL to public documentation for the service and create with `azsdk_create_service_label`.

This opens a PR to azure-sdk-tools. Once merged, associate the label with packages using `azsdk_engsys_codeowner_add_package_label` and `azsdk_engsys_codeowner_add_label_owner`.

### Label Naming Conventions

- DO NOT use "Azure" in the label — just the service name (e.g. `Storage`)
- Use the official service name as shown in Azure portal and documentation
- Use spaces if that is how the service is branded (e.g. `Key Vault` not `KeyVault`)