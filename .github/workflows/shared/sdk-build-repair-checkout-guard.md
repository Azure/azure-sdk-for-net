---
jobs:
  agent:
    pre-steps:
      - name: Support allowlisted repair label bots in PR checkout
        shell: bash
        run: |
          set -euo pipefail
          node <<'NODE'
          const fs = require("node:fs");
          const path = require("node:path");
          const checkout = path.join(process.env.RUNNER_TEMP, "gh-aw/actions/checkout_pr_branch.cjs");
          const source = fs.readFileSync(checkout, "utf8");
          const original = '(context.payload.action === "opened" || context.payload.action === "synchronize") &&';
          const replacement = `(context.payload.action === "opened" || context.payload.action === "synchronize" ||
              (context.eventName === "pull_request" &&
               context.payload.action === "labeled" &&
               context.payload.label?.name === "auto-sdk-build-fix" &&
               isAllowedBot(actor, parseAllowedBots()))) &&`;
          if (source.split(original).length !== 2) {
            throw new Error("Unexpected gh-aw checkout helper; review the repair label bot workaround before upgrading.");
          }
          fs.writeFileSync(checkout, source.replace(original, replacement));
          NODE
---

<!-- Remove this import when gh-aw supports allowlisted bots on same-repository labeled PR events.
     Only the repair-label action is added; the helper still verifies the bot sender and both repository IDs. -->
