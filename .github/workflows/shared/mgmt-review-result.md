---
jobs:
  validate_management_review_result:
    name: Validate management review verdict
    needs: [agent, capture_review_head, validate_review_result]
    if: needs.validate_review_result.outputs.outcome == 'review'
    runs-on: ubuntu-latest
    permissions:
      actions: read
      contents: read
      pull-requests: read
    steps:
      - name: Checkout trusted workflow validation code
        uses: actions/checkout@v7.0.1
        with:
          ref: ${{ github.workflow_sha }}
          sparse-checkout: .github/workflows/scripts
          persist-credentials: false
      - name: Download requested review output
        uses: actions/download-artifact@v8.0.1
        with:
          pattern: "{agent,agent-output-fallback}"
          merge-multiple: true
          path: ${{ runner.temp }}/review-result
      - name: Validate the published management verdict
        uses: actions/github-script@v9.0.0
        env:
          TARGET_PR_NUMBER: ${{ github.event.inputs.pr_number }}
          TARGET_HEAD_SHA: ${{ needs.capture_review_head.outputs.head_sha }}
        with:
          script: |
            const fs = require('fs');
            const path = require('path');
            const { validatePublishedReview } = require(path.join(process.env.GITHUB_WORKSPACE, '.github/workflows/scripts/mgmt-review-result.cjs'));
            const headSha = process.env.TARGET_HEAD_SHA;
            const pull_number = Number(process.env.TARGET_PR_NUMBER);
            const { data: pr } = await github.rest.pulls.get({ ...context.repo, pull_number });
            if (pr.state !== 'open' || pr.head.sha !== headSha) {
              throw new Error('The PR is closed or its head changed before verdict validation.');
            }
            const data = JSON.parse(fs.readFileSync(path.join(process.env.RUNNER_TEMP, 'review-result', 'agent_output.json'), 'utf8'));
            const reviews = await github.paginate(github.rest.pulls.listReviews, { ...context.repo, pull_number, per_page: 100 });
            const runUrl = `${process.env.GITHUB_SERVER_URL}/${context.repo.owner}/${context.repo.repo}/actions/runs/${context.runId}`;
            const result = validatePublishedReview({ data, reviews, headSha, runUrl, runAttempt: Number(process.env.GITHUB_RUN_ATTEMPT) });
            core.info(`Validated management verdict: ${JSON.stringify(result)}`);
---
