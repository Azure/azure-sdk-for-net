---
name: azsdk-common-typespec-naming
description: 'Apply shared SDK naming guidance during TypeSpec authoring, customization, and read-only review. WHEN: "plan SDK names", "check TypeSpec SDK naming", "review SDK naming conventions", "fix naming in client.tsp", "add a language-scoped clientName override". Initially covers C# management SDKs.'
license: MIT
metadata:
  version: "1.0.0"
  distribution: shared
compatibility: "Guidance/review use local references. Apply uses scoped direct edits to TypeSpec naming overrides. TypeSpec validation tooling is still required."
---

# TypeSpec SDK Naming

One source of naming rules for authoring and read-only naming review. Read the [naming dispatcher](references/naming-conventions.md) and only its applicable profiles.

## Workflow

1. **Choose intent.** Guidance/planning and review are read-only. Use apply only when the user or calling authoring workflow authorizes edits. Never interpret review feedback alone as permission to fix.
2. **Select coverage.** Identify language and ARM/data-plane context from supplied evidence. Read the dispatcher's matching profile references before recommending names; invoking this skill does not load those rules. This is required in default client configuration planning as well as explicit naming requests. Resolve missing information only for affected naming decisions; do not block unrelated REST work.
3. **Evaluate.** Apply compatibility before naming style: supplied evidence of a shipped SDK name makes that name the required output unless an intentional breaking rename is explicitly authorized. Apply naming conventions only to unshipped names. Preserve wire contracts and other languages. Return targets, proposed names, scopes, rationale, exceptions and blockers. Ordinary declaration authoring remains with the caller.
4. **Apply only when authorized.** Follow the [apply workflow](references/apply.md): directly edit scoped naming overrides in `client.tsp` and necessary imports/loading. Do not call `azsdk_customized_code_update` for naming-only changes. Never edit SDK custom code or generated code for a TypeSpec naming fix.
5. **Report evidence.** Distinguish recommendations, applied changes and verified generated names. Review reports findings without writes or generation; after apply, validate as described in the apply workflow.

## Consumers

- `azure-typespec-author`: consult in guidance mode before authoring; use apply for planned SDK-only overrides.
- Copilot reviewers: use review mode on the supplied changed declarations and SDK evidence, never apply.
- Direct naming-only `client.tsp` requests use this skill; do not recursively invoke the full authoring workflow. Other SDK customization or generation requests remain with their existing workflows.

If invoked by another skill, return naming decisions to that workflow; do not start a separate assessment or SDK-generation workflow.
