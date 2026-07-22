---
name: azsdk-common-eval-authoring-workflow
description: 'Author and validate multi-tool, multi-turn, mock, and live Vally scenarios under evals/workflows. WHEN: "write a workflow eval", "add end-to-end eval", "test tool sequence", "create multi-turn eval", "add mock workflow scenario", "add live eval". DO NOT USE FOR: per-skill routing/capability evals (use azsdk-common-eval-authoring-skill), isolated prompt-to-tool tests (use azsdk-common-eval-authoring-tool).'
license: MIT
metadata:
  author: Microsoft
  version: "1.0.0"
  distribution: shared
compatibility: "copilot-chat, @microsoft/vally-cli 0.7.0"
---

# Workflow Eval Authoring

Author Vally evals that verify **multi-skill, multi-tool, or multi-turn** orchestration, state, and outcomes across an entire agent conversation, under `evals/workflows/`. All the actual guidance — naming convention, placement, per-category requirements, glossary, grading patterns, grader catalog, anti-patterns, and worked examples — lives in one shared place so it never drifts across the three eval-authoring skills: the eval authoring guide at `eng/common/knowledge/eval-authoring/README.md`. This skill exists to route you there with workflow-eval context already loaded, not to duplicate it.

## Triggers

USE FOR: write a workflow eval, add end-to-end eval, test tool sequence, create multi-turn eval, add mock workflow scenario, add live eval
WHEN: "write a workflow eval", "add end-to-end eval", "test tool sequence", "create multi-turn eval", "add mock workflow scenario", "add live eval"
DO NOT USE FOR: per-skill routing/capability evals (use azsdk-common-eval-authoring-skill), isolated prompt-to-tool tests (use azsdk-common-eval-authoring-tool)

## Steps

1. Read the eval authoring guide (`eng/common/knowledge/eval-authoring/README.md`) Step 0 to find this repo's `vallyRoot`/`evalGlobs` for the workflow tier, then the guide's "Workflow" column throughout (naming, requirements, worked example).
2. Use `evals/workflows/mock/` by default. Choose `live/` only when the behavior cannot be represented by the mock MCP; document writes, authentication, cleanup, and nightly-only execution.
3. Model one user goal per stimulus. Use `turns` only when conversation state matters; otherwise keep a single prompt. Mount every candidate skill explicitly, provide minimal file/git fixtures, and bound turns, tokens, workers, and timeout.
4. Combine process and outcome graders per the guide's four-layer pattern and grader catalog: required/disallowed skills and tools, ordering where essential, files/commands, response quality. Avoid overfitting to incidental call sequences and the guide's anti-patterns (e.g. boundary anti-triggers with no competing skill mounted).
5. Scope graders to `turn` only when that turn owns the assertion unambiguously; otherwise grade the full conversation.
6. Validate locally per the guide's "Running evals locally" section, building the matching MCP and priming git fixtures when required. Do not finish or open a PR until it passes; inspect every turn and tool call on failure.

## Rules

- Keep mock workflows hermetic and repeatable; use fake IDs and canned responses.
- Never run a live write scenario without the documented test area and safety environment.
- Preserve relative path invariants for `environment.skills`, `files`, and `git.source`.
- Use weights summing to `1.0` and a meaningful threshold when combining grader types.

## References

- Eval authoring guide: `eng/common/knowledge/eval-authoring/README.md` — naming, placement, requirements, glossary, graders, anti-patterns, worked examples, local commands. Shared with `azsdk-common-eval-authoring-skill`/`azsdk-common-eval-authoring-tool` — update it there, not per-skill.
- Repository-local eval README/configuration discovered in Step 0 (if present)
