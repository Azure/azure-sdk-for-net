---
name: code-review
description: "Review pull requests in Azure/azure-sdk-for-net. USE FOR: GitHub Copilot code review, PR reviews, review diffs, and finding high-confidence regressions or Azure SDK for .NET guideline violations. DO NOT USE FOR: implementing fixes, CI troubleshooting, APIView feedback, or releases."
---

# Azure SDK for .NET Code Review

Use this skill for broad PR reviews across the repository. Respect a narrower assigned review scope; for management SDK changes, consult the relevant API and compatibility guidance in [azure-sdk-mgmt-pr-review](../azure-sdk-mgmt-pr-review/SKILL.md) without adopting its separate workflow's review-submission protocol.

## Review process

1. Read the PR description and diff to establish the intended behavior. Identify affected packages and classify changes as SDK API or implementation, generated output, tests, samples/docs, generator, or repository infrastructure.
2. Check correctness and regressions before design conventions. Trace changed behavior through callers, request/response paths, tests, API listings, documentation, and package metadata when relevant. Inspect enough unchanged context to establish that a suspected problem is new and not handled elsewhere.
3. Apply only the relevant checks below. For `sdk/` changes, identify whether the library uses Azure.Core's HTTP pipeline, System.ClientModel, a non-HTTP protocol, or management-plane patterns before applying a guideline. Consult package-specific skills only for affected packages when they exist.
4. If public API changes, compare against the *released* API for that package and relevant target frameworks when available, not just the base branch. Examine API listings and ApiCompat evidence, but do not assume a passing ApiCompat check rules out behavioral or source-compatibility regressions. If the released baseline cannot be established, do not assert that a change breaks shipped API.
5. For changes outside SDK client libraries, review actual correctness, security, compatibility, and test implications without imposing SDK-specific conventions.

## SDK API design

Apply the [.NET API design guidelines](https://azure.github.io/azure-sdk/dotnet_introduction.html) to newly introduced or changed public SDK APIs, subject to the package's established design and compatibility obligations:

- **Clients and mocking:** For applicable service clients, check usable minimal constructors and options, immutable and thread-safe clients, and mockable protected constructors and virtual service methods. Check that model graphs returned by service methods can be constructed for tests. Avoid recommending stylistic API changes that would break a released surface. See [service clients](https://azure.github.io/azure-sdk/dotnet_introduction.html#dotnet-client) and [mocking](https://azure.github.io/azure-sdk/dotnet_introduction.html#dotnet-mocking).
- **Operations:** For Azure.Core-style service methods, check matching sync/async variants, optional cancellation or request context, correct `Response<T>`/`Task<Response<T>>` results, `Pageable<T>`/`AsyncPageable<T>` for paged operations, and `Operation<T>` with `WaitUntil` for long-running operations. Verify that cancellation actually reaches I/O and that new overloads do not make existing calls ambiguous. See [service methods](https://azure.github.io/azure-sdk/dotnet_introduction.html#dotnet-service-methods-sync-and-async), [paging](https://azure.github.io/azure-sdk/dotnet_introduction.html#dotnet-paging), and [LROs](https://azure.github.io/azure-sdk/dotnet_introduction.html#dotnet-longrunning).
- **Models and compatibility:** Check that service-owned fields are not publicly mutable when inappropriate, optional/unknown service values remain representable, and ETags and URIs use appropriate types. Look for removed or altered shipped public APIs and consequential source or behavior changes; a major version bump alone is not a license to remove existing API. Verify the actual released contract and overload set before claiming a break. See [models](https://azure.github.io/azure-sdk/dotnet_introduction.html#dotnet-model-types) and [versioning](https://azure.github.io/azure-sdk/dotnet_introduction.html#dotnet-versioning-no-api-breaking).

Do not enforce Azure.Core return types or `HttpPipeline` on System.ClientModel-based packages, non-HTTP clients, provisioning libraries, or generators. Prefer a package's existing compatible pattern when the general guideline does not apply.

## SDK implementation

Apply the [.NET implementation guidelines](https://azure.github.io/azure-sdk/dotnet_implementation.html) when the PR changes applicable client behavior:

- **HTTP requests and policies:** Azure.Core REST calls should use `HttpPipeline` so authentication, retries, logging, and transport configuration work. Check URI encoding, headers, request bodies, response lifetime, and thread safety of custom pipeline policies. See [HTTP pipeline use](https://azure.github.io/azure-sdk/dotnet_implementation.html#dotnet-usage-httppipeline).
- **Parameters and cancellation:** Check the documented ordering of newly added service-method parameters; put the optional cancellation token or request context last, and propagate it through the operation. Validate client-side parameters without rejecting values that the service should validate; in Azure.Core-based libraries, reuse the shared `Argument` helpers rather than introducing a competing validation class. See [parameters](https://azure.github.io/azure-sdk/dotnet_implementation.html#dotnet-parameter-request-context-presence) and [validation](https://azure.github.io/azure-sdk/dotnet_implementation.html#dotnet-parameter-validation-class).
- **Responses and diagnostics:** In Azure.Core-based clients, surface failed service requests as `RequestFailedException` (or an appropriate subtype) and check `ClientDiagnostics` scopes and exception recording for custom methods. Keep LRO completion/failure state consistent, including already-completed operations. For other client stacks, follow their established exception and diagnostics contracts. Avoid redundant or sensitive logging. See [LRO implementation](https://azure.github.io/azure-sdk/dotnet_implementation.html#dotnet-lro-return) and [distributed tracing](https://azure.github.io/azure-sdk/dotnet_implementation.html#dotnet-tracing).
- **Serialization:** In new custom JSON serialization, use the package's supported serialization pattern and handle missing optional fields, unknown values, and newer service responses without turning successful responses into failures. For Azure.Core-based JSON implementations, the guideline calls for `System.Text.Json`. See [JSON serialization](https://azure.github.io/azure-sdk/dotnet_implementation.html#dotnet-json-serialization-resilience).

Check that tests cover materially changed behavior and failure cases; check public API listings, samples, and changelogs when the change affects them. Do not demand tests or documentation changes without an identifiable coverage or user-facing gap.

## Findings

- Report only distinct, actionable problems introduced by the PR, with a concrete failure scenario or customer impact and a correction in the appropriate layer. Cite the specific guideline section when the finding depends on a guideline, and distinguish mandatory rules from recommendations.
- Prefer an inline comment on the relevant changed line. Do not attach a finding to an unrelated line or repeat existing review comments; use review-level feedback when no suitable changed line exists.
- Generated code can be a comment target **if** its changed line demonstrates a substantive defect. Name the TypeSpec, customization, or generator change needed to fix it; never suggest manually editing generated files. Use API listing files for analysis rather than as inline comment targets.
- Avoid speculative issues, style-only feedback, blanket checklist comments, or conclusions from unavailable baselines or tests. If evidence is missing, state the limitation instead of presenting a guess as a finding.
