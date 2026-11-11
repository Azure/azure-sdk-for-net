# Common engineering release history

## Unreleased

### Bugs Fixed

- `Mark-ReleasePlanCompletion.ps1` builds the current release run URL from `SYSTEM_COLLECTIONURI`, `SYSTEM_TEAMPROJECT` and `BUILD_BUILDID` when `-PipelineUrl` is not passed, so callers that bypass the shared completion template (such as Java's direct script call) record and look up the same run. An explicit `-PipelineUrl` always wins, and no URL is invented when any variable is missing. The run URL lets `azsdk` select the plan that recorded this run when no plan ID or SDK PR is supplied.
- Release-plan completion uses the job's `AutoReleaseSdkPullRequestUrl` when no explicit `SdkPullRequest` is supplied. An absent or empty variable is initialized to an empty string at runtime before macro expansion, so manual runs do not pass an unresolved variable. Empty initialization is logged. Existing runtime values and explicit parameters are preserved.
