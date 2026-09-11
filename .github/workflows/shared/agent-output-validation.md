---
safe-outputs:
  report-incomplete:
    max: 1
    create-issue: false
jobs:
  validate_agent_output:
    needs: agent
    if: ${{ always() && needs.agent.result != 'skipped' }}
    runs-on: ubuntu-slim
    permissions:
      actions: read
    outputs:
      output_types: ${{ steps.validate.outputs.output_types }}
    steps:
      - name: Download terminal agent output
        uses: actions/download-artifact@v8.0.1
        with:
          pattern: "{agent,agent-output-fallback}"
          merge-multiple: true
          path: ${{ runner.temp }}/agent-result
      - name: Validate terminal agent output
        id: validate
        uses: actions/github-script@v9.0.0
        with:
          script: |
            const fs = require('fs');
            const path = require('path');
            const file = path.join(process.env.RUNNER_TEMP, 'agent-result', 'agent_output.json');
            const output = JSON.parse(fs.readFileSync(file, 'utf8'));

            if ((!Array.isArray(output?.items)) || (output.items.length === 0)) {
              throw new Error('Agent produced no terminal safe output; the task did not complete');
            }
            if ((!Array.isArray(output.errors)) || (output.errors.length !== 0)) {
              throw new Error('Agent output ingestion reported errors or an invalid result');
            }
            if (output.items.some(item => (!item) || (typeof item.type !== 'string') || (!item.type.trim()))) {
              throw new Error('Agent output contains an invalid item');
            }

            const types = [...new Set(output.items.map(item => item.type))];
            if (types.some(type => ['report_incomplete', 'missing_tool', 'missing_data'].includes(type))) {
              throw new Error('Agent reported incomplete work or unavailable tools/data; see the agent artifact');
            }
            core.setOutput('output_types', types.join(','));
            core.info('Agent produced a terminal output without ingestion or incomplete-work errors');
---

If required tools or infrastructure prevent completion, call `report_incomplete` with the failure and the work remaining rather than `noop`
Use `noop` only for a completed decision that no action is needed
