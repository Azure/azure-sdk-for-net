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
