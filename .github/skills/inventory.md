# Copilot Skills Inventory

This document lists all available Copilot skills in the Azure SDK for .NET repository.

## PR Review & CI

| Skill | Description |
|---|---|
| [azure-sdk-mgmt-pr-review](azure-sdk-mgmt-pr-review/SKILL.md) | Review Azure SDK management-plane pull requests, check naming conventions, API compatibility, and code quality. |
| [mpg-migration-pr-review](mpg-migration-pr-review/SKILL.md) | Review Azure SDK management-plane migration PRs (Swagger/AutoRest → TypeSpec). Checks customization quality, TypeSpec decorator usage, and migration-specific anti-patterns on top of the standard mgmt PR review. |
| [mgmt-review-comment-resolution](mgmt-review-comment-resolution/SKILL.md) | Resolve review comments on Azure management-plane .NET SDK PRs. Handles renaming types/properties, changing property types, and other API surface adjustments by updating TypeSpec client.tsp and regenerating. |
| [analyze-ci-failures](analyze-ci-failures/SKILL.md) | Analyze CI failures on Azure SDK for .NET pull requests and post a comment with how-to-fix instructions. Use when a PR has failing checks, CI is red, or someone asks for help fixing CI. |
| [pre-commit-checks](pre-commit-checks/SKILL.md) | Pre-commit validation checks for azure-sdk-for-net. Runs dotnet format, exports public API listings, updates snippets, and regenerates code as needed. |

## Migration & Breaking Changes

| Skill | Description |
|---|---|
| [mpg-sdk-migration](mpg-sdk-migration/SKILL.md) | Migrate an Azure management-plane .NET SDK from Swagger/AutoRest to TypeSpec-based generation. Use when asked to migrate a service, do MPG migration, update spec, or bring SDK to latest TypeSpec. |
| [mitigate-breaking-changes](mitigate-breaking-changes/SKILL.md) | Patterns and techniques for mitigating breaking changes during Azure management-plane SDK migration from Swagger/AutoRest to TypeSpec. Covers SDK-side customizations (partial classes, CodeGenType, CodeGenSuppress) and TypeSpec decorator customizations (clientName, access, markAsPageable, alternateType). |

## Code Generation & Testing

| Skill | Description |
|---|---|
| [bump-mgmt-base-version](bump-mgmt-base-version/SKILL.md) | Bump the http-client-csharp base dependency version in http-client-csharp-mgmt. Updates emitter (npm) and generator (NuGet) references, rebuilds, and regenerates test projects. |
| [csharp-azure-spector-coverage-gaps](csharp-azure-spector-coverage-gaps/SKILL.md) | Discovers and implements gaps in Spector test coverage for the Azure C# HTTP client emitter. Use when asked to find missing Spector scenarios, add Spector test coverage, or implement a specific Spector spec for the Azure C# emitter. |
| [provisioning-library-regeneration](provisioning-library-regeneration/SKILL.md) | Regenerate Azure.Provisioning.* libraries to add new resources or features. Use when adding new resource types, enum values, or API versions to provisioning libraries. |
