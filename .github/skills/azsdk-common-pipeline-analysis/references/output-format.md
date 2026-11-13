# Pipeline Analysis Output Format

Write the diagnosis as markdown so it reads cleanly in a GitHub PR comment or an
Azure DevOps pipeline summary. Order it: root cause first, then each failure,
then a short fix summary.

Include these parts:

1. **Header** — build ID or PR link, package path, and overall status.
2. **Root cause** — one or two plain sentences naming the underlying problem. If
   failures are unrelated, list each root cause separately.
3. **Failures** — for every failure: its category (test / build / validation /
   infrastructure), the exact `file:line` from the analysis output, the error
   text, and the specific fix.
4. **Verify** — the local command that reproduces each fixable failure
   (e.g. `python -m mypy --isolate <path>`, `dotnet test --filter <test>`).
5. **Summary** — counts of fixable-in-code, infrastructure (retry), and
   needs-human-input failures. Recommend `azsdk-common-pipeline-fixer` only when
   something is code-fixable.

## Rules

- Always cite the real `file:line` from the analysis output; never paraphrase it.
- Group cascading failures under their shared root cause instead of listing each.
- Mark infrastructure failures (network, throttling, agent crash) as retry, not code.
- See [failure patterns](failure-patterns.md) for category-to-fix mappings.
