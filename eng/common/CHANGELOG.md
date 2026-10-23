# Common engineering release history

## Unreleased

### Bugs Fixed

- Release-plan completion uses the job's `AutoReleaseSdkPullRequestUrl` when no explicit `SdkPullRequest` is supplied. An absent or empty variable is initialized to an empty string at runtime before macro expansion, so manual runs do not pass an unresolved variable. Existing runtime values and explicit parameters are preserved.
- Direct calls to the shared completion script supply the current release-run URL from complete Azure Pipelines context when no URL argument is given. Matching the recorded run requires the corresponding CLI update.
