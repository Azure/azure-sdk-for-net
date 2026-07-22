---
name: azsdk-common-eval-authoring-skill
description: 'Author and validate Vally evals for Agent Skills under .github/skills. WHEN: "write a skill eval", "add trigger eval", "test skill routing", "add anti-trigger tests", "create skill capability eval", "harden skill graders". DO NOT USE FOR: single MCP tool prompt-to-tool coverage (use azsdk-common-eval-authoring-tool), multi-tool or multi-turn scenarios (use azsdk-common-eval-authoring-workflow), authoring SKILL.md itself (use skill-authoring).'
license: MIT
metadata:
  author: Microsoft
  version: "1.0.0"
  distribution: shared
compatibility: "copilot-chat, @microsoft/vally-cli 0.7.0"
---

# Skill Eval Authoring

Author Vally evals that verify **one Agent Skill's** routing and behavior in isolation, under `.github/skills/<skill>/evals/`. All the actual guidance — naming convention, placement, per-category requirements, glossary, grading patterns, grader catalog, anti-patterns, and worked examples — lives in one shared place so it never drifts across the three eval-authoring skills: the eval authoring guide at `eng/common/knowledge/eval-authoring/README.md`. This skill exists to route you there with skill-eval context already loaded, not to duplicate it.

## Triggers

USE FOR: write a skill eval, add trigger eval, test skill routing, add anti-trigger tests, create skill capability eval, harden skill graders
WHEN: "write a skill eval", "add trigger eval", "test skill routing", "add anti-trigger tests", "create skill capability eval", "harden skill graders"
DO NOT USE FOR: single MCP tool prompt-to-tool coverage (use azsdk-common-eval-authoring-tool), multi-tool or multi-turn scenarios (use azsdk-common-eval-authoring-workflow), authoring SKILL.md itself (use skill-authoring)

## Steps

1. Read the eval authoring guide (`eng/common/knowledge/eval-authoring/README.md`) Step 0 to find this repo's `vallyRoot`/`evalGlobs` for the skill tier, then the guide's "Skill" column throughout (naming, requirements, worked example).
2. Read the target `SKILL.md` — its `WHEN`/`DO NOT USE FOR` boundaries, invoked tools — and its existing `evals/`.
3. Write `eval.yaml` with routing stimuli (trigger + anti-trigger, `skill-invocation` grader) and capability stimuli together in the same file per the guide's naming convention and four-layer pattern. Split into additional `<behavior>.eval.yaml` files only once a skill's coverage genuinely grows large. For a boundary prompt, mount and **require** the intended competing skill while disallowing the skill under test — an anti-trigger with no competing skill mounted trivially "passes" (guide anti-pattern A7).
4. Supply concrete identifiers (repo path, package name, anything needed to reach the call) in every stimulus prompt — a vague prompt fails `tool-calls` with zero recorded calls, which looks like a routing bug but is really a missing-context prompt bug.
5. Validate locally per the guide's "Running evals locally" section. Do not finish or open a PR until the focused local eval passes; inspect `eval-results.md` and `results.jsonl` on failure.

## Rules

- Cover both activation and non-activation; anti-triggers should target neighboring skills, not random unrelated prompts.
- Omit `turn` for conversation-wide assertions; pin a turn only when that turn owns the behavior unambiguously.
- Never copy secrets or production-write identifiers into fixtures.
- Update existing specs additively unless the requested contract changed.

## References

- Eval authoring guide: `eng/common/knowledge/eval-authoring/README.md` — naming, placement, requirements, glossary, graders, anti-patterns, worked examples, local commands. Shared with `azsdk-common-eval-authoring-tool`/`azsdk-common-eval-authoring-workflow` — update it there, not per-skill.
- Repository-local eval README/configuration discovered in Step 0 (if present)
