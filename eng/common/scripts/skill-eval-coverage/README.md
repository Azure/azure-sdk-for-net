# Skill Eval coverage

A deterministic, warning-only check for the skills affected by a pull request.
It reads skill, Eval, and pipeline files as **data**. It does not install Vally,
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
   Eval YAML. Coverage needs at least one named stimulus with a nonempty prompt
   or a nonempty `turns` array of nonempty strings, and a match in a configured pipeline's literal
   `vallyRoot`/`evalGlobs`. Arbitrary fixture YAML, placeholders, invalid YAML,
   symlinks, oversized files and collector-relative paths containing whitespace
   do not count. This is a minimum presence check,
   **not** full Vally schema validation, routing quality, or behavioral grading.
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

## Files and configuration

```text
coverage.ts           # Shared inventory, minimal YAML checks, safe Markdown
check.ts              # Local working-tree/Git-diff CLI and check summary
github.ts             # Immutable GitHub reads and trusted comment updates
test/                 # Unit tests, real Git fixtures and fake HTTP tests
package-lock.json     # Exactly one frozen runtime dependency: yaml
```

The consumer owns its configuration in
[.github/skill-eval-coverage.json](../../../../.github/skill-eval-coverage.json).
That configuration names the skills root, workflow, approved links and pipelines
to inspect. No deployments or resource addresses are embedded in shared code.
It explicitly includes the separate TypeSpec-author benchmark pipeline, so that
skill is not falsely called uncovered or silently exempted.

The checker does not invent a second list of Eval discovery globs: it reads the
configured pipelines and reuses the shared pipeline glob-matching rules. Add a
separate suite by registering its pipeline with
literal `vallyRoot`/`evalGlobs` pairs. Unsupported/dynamic discovery is reported
as unclear configuration, not silently accepted. There are no blanket exclusions
for uncovered skills in this MVP. A config change, configured pipeline change or
shared skills configuration change inventories all skills. Do not widen pipeline
execution globs casually; that can run more model-backed Evals and is a separate
reviewed change.

The read-only PR job reads configuration from the PR checkout. The writer uses
default-branch configuration and recomputes independently, so PR code or a
modified report cannot choose the destination or content of a privileged comment.

## Workflow dependency locks

The two coverage workflows use readable, full release versions. Their exact action
commits and source-repository identities are recorded in the generated
[Actions lockfile](../../../../.github/workflows/actions.lock). This is a scoped
adoption of GitHub's
[workflow dependency lockfiles](https://docs.github.com/en/actions/concepts/security/workflow-dependency-lockfiles),
which are in public preview. Other repository workflows retain their existing pins.
Action versions and commits are unchanged by this migration.

The read-only coverage job runs the official generator's frozen online verification
for these two workflows. It fails on stale or invalid locks, without changing files,
accepting moved pins, or requiring write permissions. The existing GitHub Actions
Dependabot configuration maintains version updates and their matching lock entries.

After changing an action reference, regenerate and verify from the repository root:

```sh
gh extension install github/gh-actions-lock --pin v0.3.0
gh actions-lock .github/workflows/skill-eval.yml .github/workflows/skill-eval-coverage-comment.yml
gh actions-lock --verify .github/workflows/skill-eval.yml .github/workflows/skill-eval-coverage-comment.yml
```

Commit the generated lockfile with the workflow changes; never edit it by hand.
Review commit or repository-identity changes as dependency changes. This adoption
does not change repository or organization policies. The effective Actions policy
and hosted lockfile behavior must still be checked before merging the public-preview
migration; no policy relaxation is part of this change.

## Run locally

Requires **Node 24.14.1+** and Git. From the repository root:

```sh
cd eng/common/scripts/skill-eval-coverage
npm ci --ignore-scripts --no-audit --no-fund
npm test
cd ../../../..
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
`pull-requests: write`. It checks out only the default branch, installs only its
frozen parser with lifecycle scripts disabled, and never downloads PR artifacts,
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
No new PAT, service connection or repository settings are needed. After the team
has reviewed warnings and addressed gaps, blocking enforcement can be discussed
separately; this change does not make missing coverage fatal.
