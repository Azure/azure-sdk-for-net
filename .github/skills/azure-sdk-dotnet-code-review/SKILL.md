---
name: azure-sdk-dotnet-code-review
description: "MUST USE for every Azure SDK for .NET code review. WHEN: review this PR or pull request; review my changes, diff, patch, or commit; API review; pre-PR review; automatic GitHub Copilot review. Performs open-ended bug, security, correctness, reliability, and maintainability analysis plus Azure SDK API design, analyzer, packaging, testing, documentation, and generated-code checks. Applies management-plane guidance per owning library."
---

# Azure SDK for .NET Code Review

Perform a comprehensive code review using both the review agent's normal open-ended analysis and
the Azure SDK for .NET-specific rules in this skill.

The rules are **additional minimum checks, not an exhaustive checklist**. Never narrow the review
to only the cases named in the references.

## Package Context

For library-owned changes, identify the shipping library from project/package metadata and
established repository naming. Apply the management-specific clauses when its package ID is
`Azure.ResourceManager` or starts with `Azure.ResourceManager.`. A matching namespace, dependency,
or PR title alone does not establish ownership.

Review shared tooling and configuration by their affected libraries rather than forcing a single
package owner.

Classify each library independently in a mixed PR. Associate tests and samples with their owning
library, but review them in their own roles rather than as additional shipping API surfaces.
For the `Azure.ResourceManager` framework package, judge the actual framework role rather than
assuming every type is a service-specific resource or request model.

## Non-Negotiable Review Quality

- Review changed code and consequences caused by it. Do not mine unrelated, unchanged code.
- Read the PR description, linked issues, existing reviews, and resolved or outdated threads before
  commenting. Do not duplicate feedback or relitigate a settled decision without new evidence.
- Establish the local convention from surrounding code and repository configuration before judging
  a diff hunk.
- Every finding needs direct evidence, a concrete consequence, and a recommended correction.
- Check every documented exception and allowed case. Try to disprove a candidate finding before
  reporting it.
- Do not repeat a diagnostic that normal CI or analyzers will already report unless the PR changes
  the enforcement or adds an opt-out, suppression, baseline, allow-list entry, or equivalent escape
  hatch.
- Omit generic advice, speculative concerns, and observations that do not require a change.
- It is valid to return no findings.

Read [references/review-quality.md](references/review-quality.md) for the portable hard rules and
general evidence checks.

## Rule Layers

Apply the following layers. A more-specific repository rule wins over a general rule, but never
relaxes the hard breaking-change or Framework Design Guideline rules in `review-quality.md`.

1. **Open-ended review:** bugs, security, correctness, reliability, concurrency, resource lifetime,
   tests, performance, and maintainability.
2. **Hard rules:** `references/review-quality.md`.
3. **Azure SDK repository rules:** relevant sections of `references/repository-rules.md`,
   including management-specific clauses for the owning library.
4. **Derived convention:** local project, then repository, then ecosystem practice.

Do not emit duplicate findings when multiple layers identify the same problem.

## Workflow

### 1. Identify the change and gather context

Determine the changed files and the intended behavior. For a PR, read its description, linked
issues, prior review submissions, and all review threads before forming findings.

On a re-review, focus on commits and replies added since the previous review. Do not re-report old
findings or narrate fixes.

Released baselines are comparison evidence; novelty since a release alone does not put an API in
scope. Recover existing or prior baseline metadata when an in-scope comparison needs it. If that
evidence is unavailable, state the limitation rather than inventing a baseline or a finding.

### 2. Load only the relevant repository-rule sections

Use the changed paths and symbols to select sections from
[references/repository-rules.md](references/repository-rules.md):

| Changed area | Sections to consult |
|---|---|
| Root configuration, `eng/**`, shared props/targets | Authoritative Guidelines; Shared Configuration; Analyzer Warnings and Suppressions; Packaging, Versioning, Dependencies |
| `.github/CODEOWNERS*`, labels, ownership files | CODEOWNERS and Labels |
| `api/*.cs`, new or changed `public`/`protected` API | Breaking Changes; Client Design; Naming; Semantic Value Types; Commonly Overlooked; Generated Code |
| Client or model implementation under `src/**` | Client Design; Naming; Semantic Value Types; Analyzer Warnings and Suppressions; Implementation |
| Management library | Applicable sections above; management clauses in Naming and Packaging, Versioning, Dependencies |
| Tests, test projects, test infrastructure | Analyzer Warnings and Suppressions; Testing |
| `.csproj`, package versions, references, feeds, CPM files | Shared Configuration; Packaging, Versioning, Dependencies |
| README, samples, snippets, doc settings, links | Docs & Samples; Broken-Link Ignores |
| Generated output, TypeSpec/AutoRest configuration | Generated Code; Breaking Changes; Naming; Semantic Value Types |

Consult additional sections whenever the diff crosses concerns. Do not load an unrelated section
merely to manufacture findings.

### 3. Perform three passes

1. **Open-ended pass:** inspect the change without using the rule list as a boundary. Look for
   incorrect behavior and risks the written rules did not anticipate.
2. **Repository-rule pass:** apply the relevant Azure SDK checks systematically.
3. **Falsification pass:** challenge every candidate finding against surrounding code, CI/analyzer
   coverage, prior discussion, documented exceptions, and legitimate allowed cases.

### 4. Filter and report

Report only findings that survive all three passes.

For every finding:

- Prefer the most specific changed source or generator-input line that causes the issue. Use an
  API-listing line when it is the only suitable changed anchor; identify the real fix location
  and never recommend hand-editing the listing.
- State what can concretely go wrong.
- Recommend the smallest correct change.
- Use 🔴 for correctness, security, or breaking changes; 🟡 for actionable non-critical repository
  violations; ℹ️ only for a question that must be answered before correctness can be determined.
- Do not include rule IDs or process narration when the consequence explains the problem better.

When no candidate survives the evidence filter, leave no comments.

## References

- [Review quality and general rules](references/review-quality.md)
- [Azure SDK for .NET repository rules](references/repository-rules.md)
