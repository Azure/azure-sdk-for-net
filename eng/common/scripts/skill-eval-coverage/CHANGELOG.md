# Changelog

## Unreleased

- Add a deterministic warning-only check for changed skills and associated
  skill-local Evals, including nested benchmark suites without pipeline configuration.
- Keep existing Vally lint failures independent and blocking.
- Add a trusted reporter that creates or updates one PR comment for both coverage
  outcomes, with the Eval dashboard, authoring guide and source-run links. The
  reporter never executes PR code with write credentials or runs model Evals.
- Require confirmed PR relevance before creating a comment; unknown scope can
  update an existing coverage comment but cannot create a new one.
- Isolate reporter unit tests from Actions annotations and the real job summary.
- Include the coverage/lint build result, attempt and skill revision in PR comments,
  separately from the coverage outcome and historical dashboard results.
- Keep the original blocking lint selectors independent of coverage configuration.
- Match Vally's nonempty string-array multi-turn contract instead of object turns.
- Use Node 24 consistently for lint, coverage checks and trusted PR reporting.
- Pin workflow actions directly to exact commits, run checker tests in their own
  read-only workflow, and limit the trusted reporter to a sparse default-branch checkout.
- Use a frozen pnpm 12.6.0 parser install isolated from consuming workspaces.
- State that presence does not assess semantic coverage or prove behavioral correctness.
- Announce in coverage-warning comments that the warning will become a build
  blocker by November 9, 2026, while allowing authors to proceed during the grace
  period if other required checks pass. Track the separate enforcement change in
  [#17402](https://github.com/Azure/azure-sdk-tools/issues/17402).
