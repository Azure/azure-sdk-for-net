# Shared Naming Evals

This suite covers naming guidance without SDK generation. It retains member/model naming,
HTTP-role, exception, compatibility, scope and ambiguity cases from the authoring suite,
plus natural routing and negative routing cases. A standalone apply case also verifies
the required customization, TypeSpec validation, and compile sequence with hermetic
fixtures; delegated authoring remains covered separately.

Numeric-version enum coverage preserves valid emitter-produced member names without
inventing underscore overrides or exact-name capability blockers. Member and model
cases also cover date/time examples, URI naming without type conversions, consistent
abbreviation expansion, reusable domain models, and genuine method options bags.

Apply and review cases expose an isolated MCP fixture with the production customization
and validation argument names. The fixture performs no product edits or network calls.
Graders check the actual tool sequence, explicit `SpecInputs`, language/target/name
constraints, read-only tool absence and failure handling. The standalone compile uses a
local command shim that verifies `tsp compile .` is run against the staged project. These
cases do not verify emitted SDK names or substitute for tool integration tests.

From `.github/skills`, using Vally 0.14:

```powershell
node --test azsdk-common-typespec-naming\evals\fixtures\customization-mcp.test.mjs
vally lint azsdk-common-typespec-naming --strict
vally lint -e azsdk-common-typespec-naming\evals\eval.yaml --strict
vally eval -e azsdk-common-typespec-naming\evals\eval.yaml --workers 1 --output jsonl --output-dir ..\..\artifacts\naming-evals
```

Use `--tag case=apply,apply-delegated,apply-failure,review` for the tool-boundary subset.
Explicit skill mounts avoid loading unrelated skills. Run serially to avoid local executor
filesystem provider races. The shared skill-eval pipeline discovers the suite.

Use `--tag case=numeric-enum,member-semantics,body-role` for the reviewed naming subset.

Authoring/assessment delegation is covered separately in the repository's
`evals/workflows/mock/typespec-naming-handoffs.eval.yaml`.
