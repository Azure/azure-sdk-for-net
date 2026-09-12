---
jobs:
  capture_review_head:
    needs: activation
    runs-on: ubuntu-slim
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
  validate_review_result:
    needs: [capture_review_head, agent, safe_outputs, validate_agent_output]
    runs-on: ubuntu-slim
    permissions:
      actions: read
      checks: read
      contents: read
      pull-requests: read
    outputs:
      outcome: ${{ steps.validate.outputs.outcome }}
      review_event: ${{ steps.validate.outputs.review_event }}
    steps:
      - name: Download review output
        uses: actions/download-artifact@v8.0.1
        with:
          pattern: "{agent,agent-output-fallback}"
          merge-multiple: true
          path: ${{ runner.temp }}/review-result
      - name: Validate published review result
        id: validate
        uses: actions/github-script@v9.0.0
        env:
          TARGET_PR_NUMBER: ${{ github.event.inputs.pr_number }}
          TARGET_HEAD_SHA: ${{ needs.capture_review_head.outputs.head_sha }}
          CHECK_RUN_CONCLUSION: ${{ github.event.inputs.check_run_conclusion }}
          COMMENT_ID: ${{ needs.safe_outputs.outputs.comment_id }}
        with:
          script: |
            const fs = require('fs');
            const path = require('path');
            const output = JSON.parse(fs.readFileSync(path.join(process.env.RUNNER_TEMP, 'review-result', 'agent_output.json'), 'utf8'));
            const items = output.items;
            if ((!Array.isArray(items)) || (items.length === 0) || (!Array.isArray(output.errors)) || (output.errors.length !== 0)) {
              throw new Error('A valid terminal agent result is required');
            }
            if (items.every(item => item.type === 'noop')) {
              core.setOutput('outcome', 'noop');
              return;
            }

            const prNumber = Number(process.env.TARGET_PR_NUMBER);
            const headSha = process.env.TARGET_HEAD_SHA;
            const runUrl = `${process.env.GITHUB_SERVER_URL}/${context.repo.owner}/${context.repo.repo}/actions/runs/${context.runId}`;
            const isFromThisRun = value =>
              (value.user?.login === 'github-actions[bot]') &&
              (value.body?.includes(`Analyzed by ${context.workflow}:`)) &&
              (value.body?.split(/\s+/).includes(runUrl));
            const requestedReviews = items.filter(item => item.type === 'submit_pull_request_review');
            if (requestedReviews.length > 0) {
              const event = requestedReviews[0].event;
              if ((requestedReviews.length !== 1) || (!['COMMENT', 'REQUEST_CHANGES'].includes(event))) {
                throw new Error('Expected exactly one supported review event');
              }
              const reviews = await github.paginate(github.rest.pulls.listReviews, {
                ...context.repo, pull_number: prNumber, per_page: 100
              });
              const state = event === 'COMMENT' ? 'COMMENTED' : 'CHANGES_REQUESTED';
              if (!reviews.some(review => (isFromThisRun(review)) && (review.commit_id === headSha) && (review.state === state))) {
                throw new Error('The requested review was not published on the captured commit by this run');
              }
              core.setOutput('outcome', 'review');
              core.setOutput('review_event', event);
              return;
            }

            const header = `## \u{1F50D} CI Failure Analysis for PR #${prNumber}`;
            const isAnalysis = body => typeof body === 'string' && body.trimStart().split(/\r?\n/, 1)[0] === header;
            if ((items.length !== 1) || (items[0].type !== 'add_comment') || (!isAnalysis(items[0].body))) {
              throw new Error('Supplementary comments cannot substitute for a completed SDK review');
            }
            let ciFailed = process.env.CHECK_RUN_CONCLUSION === 'failure';
            if ((!ciFailed) && (process.env.CHECK_RUN_CONCLUSION !== 'success')) {
              const [checks, statuses] = await Promise.all([
                github.paginate(github.rest.checks.listForRef, {
                  ...context.repo, ref: headSha, filter: 'latest', per_page: 100
                }),
                github.rest.repos.getCombinedStatusForRef({ ...context.repo, ref: headSha })
              ]);
              ciFailed = checks.some(check => (check.name !== context.workflow) && (check.conclusion === 'failure')) ||
                ['failure', 'error'].includes(statuses.data.state);
            }
            if (!ciFailed) {
              throw new Error('Comment-only completion requires failed CI on the captured commit');
            }
            const commentId = Number(process.env.COMMENT_ID);
            if ((!Number.isSafeInteger(commentId)) || (commentId <= 0)) {
              throw new Error('No published CI-analysis comment was recorded');
            }
            const { data: comment } = await github.rest.issues.getComment({
              ...context.repo, comment_id: commentId
            });
            if ((!isFromThisRun(comment)) || (!isAnalysis(comment.body)) ||
                (!comment.issue_url?.endsWith(`/issues/${prNumber}`))) {
              throw new Error('The CI-analysis comment was not published on the target PR by this run');
            }
            core.setOutput('outcome', 'ci_analysis');
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
    needs: [activation, capture_review_head, agent, detection, safe_outputs, validate_agent_output, validate_review_result, dismiss_stale_change_requests]
    if: ${{ always() && needs.capture_review_head.result == 'success' }}
    runs-on: ubuntu-slim
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
          REVIEW_VALIDATION_RESULT: ${{ needs.validate_review_result.result }}
          REVIEW_OUTCOME: ${{ needs.validate_review_result.outputs.outcome }}
          REVIEW_EVENT: ${{ needs.validate_review_result.outputs.review_event }}
          DISMISSAL_RESULT: ${{ needs.dismiss_stale_change_requests.result }}
          QUOTA_EXCEEDED: ${{ needs.activation.outputs.daily_ai_credits_exceeded }}
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
              process.env.VALIDATION_RESULT,
              process.env.REVIEW_VALIDATION_RESULT
            ];
            const outcome = process.env.REVIEW_OUTCOME;
            const noopOnly = outcome === 'noop';
            const hasReviewResult = ['review', 'ci_analysis', 'noop'].includes(outcome);
            const applied = Number(process.env.OUTPUTS_APPLIED || 'NaN');
            const unapplied = ['OUTPUTS_FAILED', 'OUTPUTS_CANCELLED', 'OUTPUTS_DEFERRED']
              .map(name => Number(process.env[name] || 'NaN'));
            const outputsApplied = noopOnly ||
              ((Number.isSafeInteger(applied)) && (applied > 0) && (unapplied.every(count => count === 0)));
            const dismissalResult = process.env.DISMISSAL_RESULT;
            const dismissalCompleted = process.env.REVIEW_EVENT === 'COMMENT' ?
              dismissalResult === 'success' : ['success', 'skipped'].includes(dismissalResult);
            const completed = results.every(result => result === 'success') && hasReviewResult && outputsApplied && dismissalCompleted;
            const conclusion = (results.includes('cancelled')) || (dismissalResult === 'cancelled') ? 'cancelled' :
              !completed ? 'failure' :
              noopOnly ? 'neutral' : 'success';
            const detailsUrl = `${process.env.GITHUB_SERVER_URL}/${context.repo.owner}/${context.repo.repo}/actions/runs/${context.runId}`;
            const failureReason = process.env.QUOTA_EXCEEDED === 'true' ?
              'Review was not run because the daily AI-credit limit was reached' :
              'Review workflow did not complete; no clean review is implied';

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
                  outcome === 'ci_analysis' ? `CI failure analysis completed; no SDK review was performed. See ${detailsUrl}` :
                  `Review workflow completed. See ${detailsUrl}`) :
                  `${failureReason}. See ${detailsUrl}`
              }
            });
            if ((!completed) && (conclusion !== 'cancelled')) {
              core.setFailed(failureReason);
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
Schema and other supplementary comments do not complete an SDK review
A CI-analysis-only outcome requires the CI Failure Analysis header, failed CI for the captured commit, and the published analysis comment
Every completed non-blocking `COMMENT` review must also request the stale-review dismissal guard, even when no previous change request is expected
