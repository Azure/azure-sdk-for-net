# Changelog

## Unreleased

- Add a deterministic warning-only check for changed skills, associated Evals,
  and actual pipeline discovery, including separate benchmark suites.
- Keep existing Vally lint failures independent and blocking.
- Add a trusted reporter that creates or updates one PR comment for both coverage
  outcomes, with the Eval dashboard, authoring guide and source-run links. The
  reporter never executes PR code with write credentials or runs model Evals.
- Reject collector-incompatible whitespace paths before counting Eval coverage.
- Require confirmed PR relevance before creating a comment; unknown scope can
  update an existing coverage comment but cannot create a new one.
- Isolate reporter unit tests from Actions annotations and the real job summary.
- Include the coverage/lint build result, attempt and skill revision in PR comments,
  separately from the coverage outcome and historical dashboard results.
- Keep the original blocking lint selectors independent of coverage configuration.
- Match Vally's nonempty string-array multi-turn contract instead of object turns.
- Use Node 24 consistently for lint, coverage checks and trusted PR reporting.
- Move the two coverage workflows' action pins to a generated workflow dependency
  lockfile, keeping readable release versions, the same action commits, and scoped
  read-only verification. Other workflows and repository policies are unchanged.
- Announce in coverage-warning comments that the warning will become a build
  blocker by November 9, 2026, while allowing authors to proceed during the grace
  period if other required checks pass. Track the separate enforcement change in
  [#17402](https://github.com/Azure/azure-sdk-tools/issues/17402).
