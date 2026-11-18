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
- **Publishing:** nothing is published. `Evaluate the replayed re-review` records how the publication guard judged the run and then fails the job before `Process Safe Outputs`. Without a pull request in the event, the live guard step would also fail.

## Read the result

The `pr-re-review-replay` artifact holds `replay-result.json`, and the job summary shows the same verdicts.

- `outcome`: `would-publish`, `blocked` (a review the guard would have refused), `incomplete` (`report_incomplete` or another incomplete-work output), or `no-review`.
- `coverage` and `readCoverage`: the publication guard's checks, evaluated against the replayed history and files.
- `contaminated` and `contamination`: tool calls that read the pull request, its history, or code at any other commit. They can reveal what happened after the cutoff, such as the fixes, so do not score a contaminated run.
- `items`: everything the agent submitted, including the review body and inline comments to score.

The `agent` artifact's `aw_info.json` records the model the run used. Compare only replays that ran on the same model.

## Limits

- Thread resolution and outdated states, and the text of the pull request, comments, and reviews, are as they are now, not as they were at the cutoff. GitHub keeps no history for them.
- Replays count toward the workflow's daily AI-credit limit, which live re-reviews share. A live re-review uses about 50 to 110 credits of the default 5,000, so dispatch replays in small batches.
- Keep the expected findings for a replay out of `.github`. The agent can read the `.github` checkout, and a replay that sees the answers measures nothing.
