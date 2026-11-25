# Replaying a re-review

`pr-re-review.md` can replay an earlier re-review against the same commits and the review history that run saw. Use a replay to measure a change to the workflow, its prompt, or these helpers before it ships, by comparing what the replay finds with what the original run found.

## Start a replay

```powershell
gh workflow run pr-re-review.lock.yml --repo Azure/azure-sdk-for-net --ref <branch> `
  -f pull_request=64619 `
  -f head_sha=1a08b1c4cdac75614ce0052936c303b6216aba14 `
  -f base_sha=d367aa2a5525241d3792b9e9885e4db37d2f4c5a `
  -f history_cutoff=2026-11-10T19:03:22Z
```

- `--ref` selects the workflow and helpers to test. A replay runs that branch's prompt and helpers, not the default branch's.
- `head_sha` is the head in the original run's name, `Re-review PR #<number> at <head_sha>`.
- `base_sha` is the `PR_BASE_SHA` value in the log of the original run's `Export changed-file patches for the re-review` step.
- `history_cutoff` is when the original agent first read the review history: the timestamp of its first `pull_request_read` call in `events.jsonl` in the original run's `agent` artifact. If that artifact has expired, use the run's start time. Anything published after the cutoff, including the original run's own review, is hidden from the replay.

## What a replay changes

- **Changed files:** the patches come from GitHub's comparison of `base_sha...head_sha`, which is the pull request's diff at that head. GitHub lists at most 300 files for a comparison, so a replay fails rather than review a partial list.
- **Review history:** `history/` beside the patches holds the review threads, reviews, and conversation comments that were public at the cutoff. The prompt tells the agent to read them instead of the live pull request, and to read code only at the replayed commits.
- **Publishing:** nothing is published. A replay's safe outputs are staged, so `Process Safe Outputs` previews them instead of calling GitHub, and the live guard and `unresolve_review_thread` are skipped. `Evaluate the replayed re-review` records how the publication guard judged the run, and fails the job if the compiled workflow does not stage `Process Safe Outputs` for `workflow_dispatch`. Otherwise a replay ends green whatever its outcome, so read the outcome from the result.

## Read the result

The `pr-re-review-replay` artifact holds `replay-result.json`, and the job summary shows the same verdicts.

- `outcome`: `would-publish`, `blocked` (a review the guard would have refused), `incomplete` (`report_incomplete` or another incomplete-work output), or `no-review`.
- `coverage` and `readCoverage`: the publication guard's checks, evaluated against the replayed history and files.
- `contaminated` and `contamination`: tool calls that read the pull request, its history, or code at any other commit. They can reveal what happened after the cutoff, such as the fixes, so do not score a contaminated run unless every flagged call failed and returned nothing.
- `items`: everything the agent submitted, including the review body and inline comments to score.

The `agent` artifact's `aw_info.json` records the model the run used. Compare only replays that ran on the same model.

## Limits

- Thread resolution and outdated states, and the text of the pull request, comments, and reviews, are as they are now, not as they were at the cutoff. GitHub keeps no history for them.
- The contamination check recognizes the tool calls and shell forms agents use, including command substitutions and unquoted heredocs in a `safeoutputs` command, but it does not parse every shell construct, so a clean result is not proof.
- Replays count toward the workflow's daily AI-credit limit, which live re-reviews share. A re-review uses about 55 credits for a small pull request and about 170 to 210 for one near the size limit, of the default 5,000 a day, so dispatch replays in small batches.
- A re-review or replay whose read set is over 700,000 characters skips the agent and spends no AI credits. The `size_gate` job measures the read set with the exporter before the agent job starts. The limit, passed to `Invoke-PrReReviewSizeGate.ps1` by the workflow, is about the largest read set a replay has finished (#63806, 668,320 characters), so raise it only after replays of larger pull requests finish. A live oversized run fails and posts a PR conversation comment requesting manual review. A live run with an explicit incomplete agent output also fails and posts a manual-review notification. A later successful live review updates earlier notifications unless it requested thread reopening, whose completion is not independently reported. Replays never post notifications.
- Keep the expected findings for a replay out of `.github`. The agent can read the `.github` checkout, and a replay that sees the answers measures nothing.
