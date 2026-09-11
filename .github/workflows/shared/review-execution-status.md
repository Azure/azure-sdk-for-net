---
jobs:
  capture_review_head:
    needs: activation
    if: needs.activation.outputs.daily_ai_credits_exceeded != 'true'
    runs-on: ubuntu-latest
    permissions:
      pull-requests: read
      checks: write
    outputs:
      head_sha: ${{ steps.capture.outputs.head_sha }}
      check_id: ${{ steps.capture.outputs.check_id }}
    steps:
      - name: Capture review head
        id: capture
        uses: actions/github-script@v9.0.0
        env:
          TARGET_PR_NUMBER: ${{ github.event.inputs.pr_number }}
          TARGET_HEAD_SHA: ${{ github.event.inputs.check_run_head_sha }}
        with:
          script: |
            const value = process.env.TARGET_PR_NUMBER || '';
            const prNumber = Number(value);
            if ((!/^[1-9][0-9]*$/.test(value)) || (!Number.isSafeInteger(prNumber))) {
              throw new Error('A positive integer pull request number is required');
            }
            const { data: pr } = await github.rest.pulls.get({
              ...context.repo,
              pull_number: prNumber
            });
            const headSha = (process.env.TARGET_HEAD_SHA || '').trim() || pr.head.sha;
            if (!/^[a-f0-9]{40}$/i.test(headSha)) {
              throw new Error('A full pull request head SHA is required');
            }
            const { data: check } = await github.rest.checks.create({
              ...context.repo,
              name: context.workflow,
              head_sha: headSha,
              external_id: `${context.runId}-${process.env.GITHUB_RUN_ATTEMPT}`,
              status: 'in_progress',
              details_url: `${process.env.GITHUB_SERVER_URL}/${context.repo.owner}/${context.repo.repo}/actions/runs/${context.runId}`
            });
            core.setOutput('head_sha', headSha);
            core.setOutput('check_id', String(check.id));
  agent:
    needs: capture_review_head
    pre-steps:
      - name: Record captured review head
        env:
          REVIEW_HEAD_SHA: ${{ needs.capture_review_head.outputs.head_sha }}
        run: |
          mkdir -p /tmp/gh-aw
          printf '%s\n' "$REVIEW_HEAD_SHA" > /tmp/gh-aw/review-head-sha
  publish_pr_check:
    needs: [capture_review_head, agent, detection, safe_outputs, validate_agent_output, dismiss_stale_change_requests]
    if: ${{ always() && needs.capture_review_head.result == 'success' }}
    runs-on: ubuntu-latest
    permissions:
      checks: write
    steps:
      - name: Publish review execution check
        uses: actions/github-script@v9.0.0
        env:
          TARGET_HEAD_SHA: ${{ needs.capture_review_head.outputs.head_sha }}
          TARGET_CHECK_ID: ${{ needs.capture_review_head.outputs.check_id }}
          AGENT_RESULT: ${{ needs.agent.result }}
          DETECTION_RESULT: ${{ needs.detection.result }}
          SAFE_OUTPUTS_RESULT: ${{ needs.safe_outputs.result }}
          VALIDATION_RESULT: ${{ needs.validate_agent_output.result }}
          DISMISSAL_RESULT: ${{ needs.dismiss_stale_change_requests.result }}
          OUTPUT_TYPES: ${{ needs.validate_agent_output.outputs.output_types }}
          OUTPUTS_APPLIED: ${{ needs.safe_outputs.outputs.process_safe_outputs_items_applied }}
          OUTPUTS_FAILED: ${{ needs.safe_outputs.outputs.process_safe_outputs_items_failed }}
          OUTPUTS_CANCELLED: ${{ needs.safe_outputs.outputs.process_safe_outputs_items_cancelled }}
          OUTPUTS_DEFERRED: ${{ needs.safe_outputs.outputs.process_safe_outputs_items_deferred }}
        with:
          script: |
            const headSha = process.env.TARGET_HEAD_SHA || '';
            if (!/^[a-f0-9]{40}$/i.test(headSha)) {
              throw new Error('A captured pull request head SHA is required');
            }
            const checkId = Number(process.env.TARGET_CHECK_ID);
            if ((!Number.isSafeInteger(checkId)) || (checkId <= 0)) {
              throw new Error('A captured check run ID is required');
            }
            const results = [
              process.env.AGENT_RESULT,
              process.env.DETECTION_RESULT,
              process.env.SAFE_OUTPUTS_RESULT,
              process.env.VALIDATION_RESULT
            ];
            const types = (process.env.OUTPUT_TYPES || '').split(',');
            const noopOnly = types.every(type => type === 'noop');
            const hasReviewResult = types.some(type =>
              ['submit_pull_request_review', 'add_comment'].includes(type)) || noopOnly;
            const applied = Number(process.env.OUTPUTS_APPLIED || 'NaN');
            const unapplied = ['OUTPUTS_FAILED', 'OUTPUTS_CANCELLED', 'OUTPUTS_DEFERRED']
              .map(name => Number(process.env[name] || 'NaN'));
            const outputsApplied = noopOnly ||
              ((Number.isSafeInteger(applied)) && (applied > 0) && (unapplied.every(count => count === 0)));
            const dismissalResult = process.env.DISMISSAL_RESULT;
            const dismissalCompleted = ['success', 'skipped'].includes(dismissalResult);
            const completed = results.every(result => result === 'success') && hasReviewResult && outputsApplied && dismissalCompleted;
            const conclusion = (results.includes('cancelled')) || (dismissalResult === 'cancelled') ? 'cancelled' :
              !completed ? 'failure' :
              noopOnly ? 'neutral' : 'success';
            const detailsUrl = `${process.env.GITHUB_SERVER_URL}/${context.repo.owner}/${context.repo.repo}/actions/runs/${context.runId}`;

            await github.rest.checks.update({
              ...context.repo,
              check_run_id: checkId,
              status: 'completed',
              conclusion,
              details_url: detailsUrl,
              output: {
                title: context.workflow,
                summary: completed ? (noopOnly ?
                  `No review was submitted because no action was needed. See ${detailsUrl}` :
                  `Review workflow completed. See ${detailsUrl}`) :
                  `Review workflow did not complete; no clean review is implied. See ${detailsUrl}`
              }
            });
            if ((!completed) && (conclusion !== 'cancelled')) {
              core.setFailed('Review execution or terminal-output validation failed');
            }
---

## Review execution budget

Read `/tmp/gh-aw/review-head-sha` and review only that captured head
Compare it with the current PR head and the checked-out commit before reading source and again before submitting a review
If either differs, emit a `noop` explaining that this run is stale and do not submit a review or request dismissal

At the start, read the current UTC time and record an 18-minute investigation deadline and a 22-minute completion deadline in your working notes
Check elapsed time before every new review phase, external request, and file batch
Stop starting new investigation work at 18 minutes and reserve the remaining time for reporting, before the 25-minute execution limit
If required review coverage remains incomplete, call `report_incomplete` with the completed checks, remaining scope, and blocking cause by 22 minutes
Do not submit a no-findings review, request stale-review dismissal, or use `noop` for incomplete coverage

Fetch metadata and changed-file pages once, verify pagination against the changed-file count, and retain a compact indexed result rather than repeatedly parsing console transcripts
Use local PR files for read-only analysis and the trusted scanner/schema helper instead of repeatedly retrieving generated source
Bound shell HTTP requests with `curl --connect-timeout 10 --max-time 60`, use at most two materially different attempts for a failed lookup, and report unavailable evidence without guessing

PR-head execution checks are published independently of agent tool calls and reflect failure or cancellation as well as completion
