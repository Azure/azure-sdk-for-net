# Shared Naming Evals

This suite covers naming guidance without SDK generation. It retains member/model naming,
HTTP-role, exception, compatibility, scope and ambiguity cases from the authoring suite,
plus natural routing and negative routing cases. A standalone apply case also verifies
the required direct `client.tsp` edit and compile sequence with hermetic fixtures;
delegated authoring remains covered separately.

Numeric-version enum cases cover supported, unsupported, and unconfirmed TCGC/emitter
exact-name capabilities. They check scoped `exact(...)` proposals or blocked overrides,
unchanged wire values/other languages, and explicitly unverified generated names.

Apply cases stage a loaded `client.tsp` containing existing Java and Python overrides.
Graders require a direct scoped edit, preserve those overrides, prohibit MCP and SDK
generation tools, and verify the ordinary source file remains unchanged. The standalone
compile uses a local command shim that verifies `tsp compile .` is run against the staged
project and that the C#, Java and Python decorators are intact. Review and blocked cases
verify that read-only or unsafe contexts do not write. These cases do not verify emitted
SDK names.

Generic SDK customization anti-triggers retain a separate mock MCP fixture. They ensure
requests such as generated client renames, hidden operations and subclient creation still
route to `azsdk-common-generate-sdk-locally` and invoke
`azsdk_customized_code_update` rather than this naming skill.

From `.github/skills`, using Vally 0.14:

```powershell
node --test azsdk-common-typespec-naming\evals\fixtures\standalone-apply\mock-typespec-compiler\tsp.test.mjs
vally lint azsdk-common-typespec-naming --strict
vally lint -e azsdk-common-typespec-naming\evals\eval.yaml --strict
vally eval -e azsdk-common-typespec-naming\evals\eval.yaml --workers 1 --output jsonl --output-dir ..\..\artifacts\naming-evals
```

Use `--tag case=apply,apply-delegated,apply-blocked,review` for the write-boundary subset.
Explicit skill mounts avoid loading unrelated skills. Run serially to avoid local executor
filesystem provider races. The shared skill-eval pipeline discovers the suite.

Use `--tag case=numeric-enum` for the exact-name capability subset.

Authoring/assessment delegation is covered separately in the repository's
`evals/workflows/mock/typespec-naming-handoffs.eval.yaml`.
