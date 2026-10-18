# Shared Naming Evals

This suite covers naming guidance without SDK generation. It retains member/model naming,
HTTP-role, exception, compatibility, scope and ambiguity cases from the authoring suite,
plus natural routing and negative routing cases. A standalone apply case also verifies
the required direct-edit, TypeSpec validation, and compile sequence with hermetic
fixtures; delegated authoring remains covered separately.

Numeric-version enum coverage preserves valid emitter-produced member names without
inventing underscore overrides or exact-name capability blockers. Member and model
cases also cover date/time examples, URI naming without type conversions, consistent
abbreviation expansion, reusable domain models, and genuine method options bags.

Apply and review cases expose an isolated MCP fixture with the production customization
and validation argument names. Customization calls are a trap: naming-only edits must
not invoke that tool, even when available. Validation checks the actual scoped override
and entrypoint import. Graders check direct edits, preserved source and existing
customizations, read-only tool absence, and the validation/compile sequence.
The standalone compile uses a local command shim that verifies `tsp compile .`
is run against the edited staged project. These
cases do not verify emitted SDK names or substitute for tool integration tests.

A separate case verifies direct edits without a customization tool. Another verifies
that updating an existing C# override does not create duplicates or alter other-language
overrides and trailing content. Missing project evidence remains a blocker.

From `.github/skills`, using Vally 0.14:

```powershell
node --test azsdk-common-typespec-naming\evals\fixtures\customization-mcp.test.mjs
vally lint azsdk-common-typespec-naming --strict
vally lint -e azsdk-common-typespec-naming\evals\eval.yaml --strict
vally eval -e azsdk-common-typespec-naming\evals\eval.yaml --workers 1 --output jsonl --output-dir ..\..\artifacts\naming-evals
```

Use `--tag case=apply,apply-delegated,apply-existing,missing-tool,review` for the tool-boundary subset.
Explicit skill mounts avoid loading unrelated skills. Run serially to avoid local executor
filesystem provider races. The shared skill-eval pipeline discovers the suite.

Use `--tag case=numeric-enum,member-semantics,body-role` for the reviewed naming subset.

Authoring delegation is covered separately in the repository's
`evals/workflows/mock/typespec-naming-handoffs.eval.yaml`.
