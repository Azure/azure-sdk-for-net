# Skill Eval coverage

A deterministic, warning-only check for the skills affected by a pull request.
It discovers Evals inside each skill's folder and reads them as **data**. It does not install Vally,
start Copilot/MCP, execute commands from Evals, or use model quota.
Initial scope is the skill-coverage portion of
[#16345](https://github.com/Azure/azure-sdk-tools/issues/16345), not MCP-tool or
mock-handler coverage enforcement.

## What happens on a PR

1. The existing **Skill Evaluations** workflow keeps its independent, blocking
   Vally lint job and its original PR path scope. A read-only coverage job lists
   changed files on every PR update, including updates that revert all skill
   changes. Unrelated diffs skip skill-tree reads and do not create comments.
   Vally lint runs for changes to skills, its dependency project or the source
   workflow, regardless of coverage warnings. These original lint selectors are
   fixed independently of the PR's coverage configuration. If scope detection fails, lint
   still runs rather than being silently skipped.
2. Changes anywhere inside a skill, including its references and Evals, select
   that skill. Renames select both paths. Removing the last Eval warns; removing
   the whole skill skips it. An existing Eval need not change in the same PR.
3. The checker inventories the PR's immutable head tree and parses candidate
   Eval YAML in that skill's folder. Presence needs at least one named stimulus
   with a nonempty prompt or a nonempty `turns` array of nonempty strings.
   Arbitrary fixture YAML, placeholders, invalid YAML, symlinks and oversized files
   do not count. This is a minimum presence check,
   **not** full Vally schema validation, routing quality, or behavioral grading.
   It does not read pipeline configuration or verify that a runner selects the Eval.
   When `turns` is provided, a standalone `prompt` does not repair invalid turns.
4. The check summary and warning annotations explain uncovered skills. Coverage
   gaps exit successfully; unreadable data, failed requests and broken tooling
   fail the checker rather than produce a false coverage pass. There is no
   blanket `continue-on-error` and no change to the lint job's outcome.
5. After that workflow completes, **Skill Eval coverage comment** recomputes the
   result with trusted default-branch code and updates one bot-owned PR comment.
   **Both coverage-present and coverage-missing comments contain the Eval
   dashboard, authoring-guide and source-run links.** The comment also records the
   coverage/lint build result, attempt and exact skill revision. This build is not
   a model-backed Eval run. An unreadable report is
   labeled unknown, never passing. Creating a new comment requires confirmed
   relevant changes. If changed-file scope is unavailable or exceeds the supported
   limit, only an existing coverage comment can be updated to unknown; otherwise
   the unknown result appears in the check summary without creating a comment.
   If a later push removes all relevant skills,
   the existing comment is updated to explain that there are no remaining skills
   to check. Unrelated PRs do not get new comments.

The dashboard shows historical, published evaluation results. It requires the
existing corporate network/sign-in access and does not prove this PR passed an
Eval. This check neither queries the dashboard nor uploads results to it.

## Warning grace period

Coverage-warning comments announce that the warning will become a build blocker
by **November 9, 2026**. Until enforcement is enabled, missing Eval coverage is
warning-only: authors may proceed if all other required checks pass. Add or fix
the affected Evals before the deadline.

This change announces the timeline only. It does not enable blocking behavior or
an automatic date-based switch. The November 9 checkpoint requires a separate
change to promote coverage warnings to errors after reviewing the remaining gaps.
Existing lint failures and tooling errors remain blocking throughout the grace period.
Track that enforcement change in
[#17402](https://github.com/Azure/azure-sdk-tools/issues/17402).

## Files and configuration

```text
coverage.ts           # Shared inventory, minimal YAML checks, safe Markdown
check.ts              # Local working-tree/Git-diff CLI and check summary
github.ts             # Immutable GitHub reads and trusted comment updates
test/                 # Unit tests, real Git fixtures and fake HTTP tests
pnpm-lock.yaml        # Exactly one frozen runtime dependency: yaml
```

The consumer owns its configuration in
[.github/skill-eval-coverage.json](../../../../.github/skill-eval-coverage.json).
That configuration names the skills root, source workflow and approved report
links. No deployment addresses are embedded in shared code, and no pipeline paths
or runner globs are needed.

For each skill, candidates are `eval.yaml` or `eval.yml` at the skill root, or
`eval.yaml`, `eval.yml`, `*.eval.yaml` and `*.eval.yml` recursively under `evals/`
or `evaluate/evals/`. Paths inside `fixtures/` are excluded. This includes nested
TypeSpec-author benchmark Evals without knowing which pipeline executes them.
Whitespace in a valid Eval path does not change presence; runner compatibility
is a separate concern. A coverage-config or shared skills-config change inventories
all skills. Pipeline-only edits do not create coverage comments.

The read-only PR job reads configuration from the PR checkout. The writer uses
default-branch configuration and recomputes independently, so PR code or a
modified report cannot choose the destination or content of a privileged comment.

## Verification and coverage levels

The dedicated [script-test workflow](../../../../.github/workflows/skill-eval-coverage-tests.yml)
tests the checker and reporting contracts separately from the workflow that checks
actual PR skills. Actions use exact commit SHA pins with readable version comments.
Checker dependency installs use pnpm 12.6.0 with a frozen lockfile, disabled lifecycle
scripts and isolation from consuming repositories' workspaces.

This PR implements **Eval presence only**. A separate advisory agentic workflow can
compare declared skill capabilities with Eval metadata, prompts and graders and
identify likely semantic gaps. That second level does not run Evals and is not
implemented or made blocking here. Presence is not a semantic quality score or
evidence that the Evals pass.

## Run locally

Requires **Node 24.14.1+**, **pnpm 12.6.0** and Git. From the repository root:

```sh
pnpm --dir eng/common/scripts/skill-eval-coverage --ignore-workspace install --pm-on-fail=ignore --frozen-lockfile --ignore-scripts
node --test eng/common/scripts/skill-eval-coverage/test/*.test.ts
node eng/common/scripts/skill-eval-coverage/check.ts --all
node eng/common/scripts/skill-eval-coverage/check.ts --base origin/main --head HEAD
node eng/common/scripts/skill-eval-coverage/check.ts --all --json
```

`--all` includes tracked and untracked working files. `--base` checks the committed
head tree using a three-dot Git diff and needs the base's history available locally;
missing history is an error. Neither command posts a comment. The Node tests use
temporary Git repositories and fully fake API transport; they make no live writes.
Reporter unit tests isolate Actions reporting variables so synthetic scenarios
cannot add annotations or fixture reports to the real workflow summary.

Keep the existing local Vally lint step as documented in
[eng/skill-eval](../../../skill-eval/README.md). The coverage checker does not
replace lint or execute the model-backed Eval suites.

## Comment security and rollout

The `pull_request` job has only `contents: read` and `pull-requests: read`. The
separate `workflow_run` reporter has `contents: read`, `actions: read` and
`pull-requests: write`. Its sparse checkout includes only the default branch's
coverage package and report configuration. It installs its frozen parser with
lifecycle scripts disabled, and never downloads PR artifacts,
checks out PR code, evaluates YAML commands, or imports code from the PR.

The reporter validates the source workflow ID/path/repository, open PR, fork,
branch and exact head SHA. It rechecks the head just before writing and skips
obsolete/cancelled runs. Fork runs with no `pull_requests` metadata are resolved
using commit associations and independently verified PR identity; ambiguous
associations are skipped. Trees/file lists have completeness and size checks,
requests have deadlines, redirects are forbidden, and source text is escaped
before rendering. It updates only a `github-actions[bot]` comment with the stable
coverage marker. A concurrency group serializes updates for each source branch.

The reporter first becomes active **after its workflow and code reach the default
branch**. Its live fork permissions and comment delivery still need a normal PR
smoke check after merge; local fake-transport tests do not prove production delivery.
No new PAT, service connection or repository settings are needed. Blocking
enforcement is planned for the November 9 checkpoint in a separate change;
this change does not make missing coverage fatal.
