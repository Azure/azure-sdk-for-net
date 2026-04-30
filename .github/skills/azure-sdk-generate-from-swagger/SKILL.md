name: azure-sdk-generate-from-swagger
description: Generate/regenerate Azure SDK for .NET libraries from Swagger/OpenAPI via AutoRest. Auto-resolves the Swagger commit SHA, pins inputs, validates the AutoRest tag, runs code generation, and reports a structured result.
user-invocable: true
---

# Azure SDK Generation from Swagger (AutoRest)

Single source of truth for any Swagger-driven SDK generation in `azure-sdk-for-net`. Designed to run with **minimal user input** -- most parameters are inferred from the workspace and the public spec repo. The user should normally need only one sentence:

> "Regenerate `Azure.ResourceManager.ServiceBus` at tag `package-2025-05-preview`."

Everything else (spec path, latest commit SHA, config file, generator command) is resolved automatically.

---

## When Invoked

Trigger phrases: "generate sdk from swagger", "regenerate sdk", "bump api version", "update autorest config", "pin swagger sha", "switch to tag X", "regen <PackageName>".

## Scope

**In scope**
- Edits to AutoRest configuration (`autorest.md` / `readme.md`) in the SDK package
- Selecting / switching the AutoRest **tag**
- Pinning every `input-file` (and `require`) URL to a specific Swagger commit SHA
- Running AutoRest / `GenerateCode` and reporting results

**Out of scope**
- Authoring or modifying `.tsp` files -- make those changes in `Azure/azure-rest-api-specs` directly
- Migrating a library from Swagger to TypeSpec -> `sdk-migration`
- Release / publish / changelog finalization -> handled outside this skill (`pre-commit-checks` covers pre-commit validation)
- Breaking-change review or `ApiCompatBaseline.txt` edits -> `mitigate-breaking-changes`

---

## Inputs

| Variable | Required? | Example | How it is resolved |
|----------|-----------|---------|--------------------|
| `PACKAGE_PATH` | yes (or inferable) | `sdk/servicebus/Azure.ResourceManager.ServiceBus` | From the user's message, the open file, or by searching the workspace for the package name |
| `AUTOREST_TAG` | yes | `package-2025-05-preview` | From the user's message |
| `SPEC_PATH` | optional | `specification/servicebus/resource-manager/Microsoft.ServiceBus/ServiceBus` | Inferred from the package's existing `autorest.md` `require:` URL; otherwise asked |
| `SPEC_COMMIT_SHA` | **never asked** | `f6bd06be22baf3a18504ffef0f590230850953e5` | Auto-resolved (see Phase 1). User-supplied SHA is honored only when explicitly provided |
| `SPEC_REPO` | default | `Azure/azure-rest-api-specs` | Default; overridden only if the existing config points elsewhere |
| `SPEC_BRANCH` | default | `main` | Default |
| `CONFIG_FILE` | default | `<PACKAGE_PATH>/src/autorest.md` | Auto-detected; falls back to `readme.md` in the same folder |

### Default Reporting Contract
At the end of every run, emit:
- AutoRest tag used
- Resolved Swagger commit SHA + short link
- Path of the AutoRest config that was edited
- List of files changed (config + `Generated/`)
- Generator exit status and first 50 lines of errors (if any)
- Suggested follow-ups (changelog, API export, tests)

---

## Hard Rules (Never Violate)

1. **Never** leave any `input-file` or `require` URL pointing at `main`, a branch, or an unpinned ref. Every URL must contain the resolved SHA.
2. **Never** hand-edit files under `src/Generated/` to "fix" generation -- fix the spec, the config, or escalate.
3. **Never** disable `ApiCompat`, `EnablePackageValidation`, or add entries to `ApiCompatBaseline.txt` to bypass breaking changes.
4. **Never** invent an AutoRest tag -- it must exist in the upstream spec's `readme.md` at the resolved SHA. If it does not, stop and surface the mismatch.
5. **Never** edit `.tsp` files from this skill -- TypeSpec edits belong in the `Azure/azure-rest-api-specs` repo.
6. **Never** bump the major version of the SDK package as part of regeneration.
7. **Preserve git history** -- modify the existing config file in place rather than delete + recreate.

---

## Workflow

### Phase 0 -- Resolve Inputs

1. From the user's message, extract `PACKAGE_PATH` (or package name) and `AUTOREST_TAG`.
2. If `PACKAGE_PATH` is missing, search the workspace for a folder matching the package name.
3. Locate the AutoRest config:
   - Prefer `<PACKAGE_PATH>/src/autorest.md`
   - Fallback `<PACKAGE_PATH>/src/readme.md`
   - If neither exists, stop and ask the user.
4. Parse the existing config to capture:
   - `require:` URL -> derive `SPEC_REPO`, current SHA, and the path to the spec's `readme.md`
   - `SPEC_PATH` -> directory portion of the `require:` URL
   - Any existing `tag:` selector
5. **State the resolved values** to the user before any edits (one compact block).

### Phase 1 -- Resolve the Swagger Commit SHA

Auto-resolve unless the user explicitly supplied one.

```
GET https://api.github.com/repos/{SPEC_REPO}/commits
    ?path={SPEC_PATH}
    &sha={SPEC_BRANCH}
    &per_page=1
```

- Use the returned `sha` as `SPEC_COMMIT_SHA`.
- If the API call fails (rate limit, no network), fall back to the SHA already pinned in the existing config and **warn the user** that auto-resolution failed.
- If a user-supplied SHA disagrees with the latest, prefer the user-supplied value and note the difference.

### Phase 2 -- Validate the AutoRest Tag

1. Fetch `https://raw.githubusercontent.com/{SPEC_REPO}/{SPEC_COMMIT_SHA}/{SPEC_PATH}/readme.md`.
2. Confirm the requested `AUTOREST_TAG` is defined (search for `### Tag: {AUTOREST_TAG}`).
3. Extract the `input-file:` list under that tag block -- these are the canonical inputs for the regenerated SDK.
4. If the tag is missing -> stop, list the available tags, ask the user to pick one.

### Phase 3 -- Plan Config Diff

Produce a precise diff of `CONFIG_FILE` covering only:

- The `tag:` line -> set to `AUTOREST_TAG`
- The `require:` URL -> rewrite the SHA segment to `SPEC_COMMIT_SHA`
- Any explicit `input-file:` URLs in the local config -> rewrite the SHA segment to `SPEC_COMMIT_SHA`
- (Optional) Add a top-of-file comment recording: tag, SHA, date, source spec path

Do **not** modify directives, namespace, modelerfour settings, or rename mappings unless the user asked for it.

### Phase 4 -- Apply Config Changes

Apply the diff via the file-edit tooling. After editing, re-read the file and verify:

- Exactly one `tag:` line, equal to `AUTOREST_TAG`
- Zero occurrences of `/main/` or unpinned refs in any spec URL
- All spec URLs share the same `SPEC_COMMIT_SHA`

If any check fails, revert the edit and stop.

### Phase 5 -- Run Code Generation

From the package's `src/` folder:

| Plane | Command |
|-------|---------|
| Management (`Azure.ResourceManager.*`) | `dotnet build /t:GenerateCode` |
| Data plane | `dotnet build /t:GenerateCode` (preferred) or `autorest --csharp` if the package has no MSBuild target |

After generation:
1. Run `dotnet build` and capture error count.
2. Run `pwsh eng/scripts/Export-API.ps1 <SERVICE_NAME>` to refresh the public API surface.
3. Run `dotnet pack --no-restore` to surface ApiCompat issues -- **do not** baseline them; report them.

### Phase 6 -- Triage Generation Errors

Use this decision table before escalating:

| Symptom | Likely Cause | Action |
|---------|--------------|--------|
| `tag` not found | Wrong tag, or upstream renamed it | Re-list tags from upstream `readme.md`; ask the user |
| `input-file` 404 | SHA does not contain the spec file (file moved/renamed) | Re-resolve SHA against the actual spec path; if the path moved, ask the user |
| AutoRest crashes / null-ref | Broken upstream spec at this SHA | Try the next-newer commit on the same path; report both SHAs |
| ApiCompat: `MembersMustExist`, `TypesMustExist`, `CannotRemoveAttribute` | Generation produced a breaking change | Stop. Report the breaking change. Do **not** edit `ApiCompatBaseline.txt`. Recommend the `sdk-migration` or `mitigate-breaking-changes` skill |
| Generated namespace / type names changed | Tag switched API version with renames | Report the renames; recommend `mitigate-breaking-changes` |
| Build fails only in `Generated/` | Stale custom code referencing old members | Fix the customization file; never edit `Generated/` |

Maximum 3 retry attempts per category; then escalate to the user with the captured logs.

### Phase 7 -- Report

Emit a single structured summary:

```
Tag:        package-2025-05-preview
SHA:        f6bd06be22baf3a18504ffef0f590230850953e5
Spec:       https://github.com/Azure/azure-rest-api-specs/tree/<SHA>/<SPEC_PATH>
Config:     sdk/<service>/<PACKAGE>/src/autorest.md
Files changed: <N> (config: 1, generated: <N-1>)
Build:      success | failed (<error_count> errors)
ApiCompat:  clean | <count> issues (listed below)
Follow-ups:
  - Update CHANGELOG.md
  - Run pre-commit-checks skill
  - Review API diff in api/<PACKAGE>.net*.cs
```

---

## Decision Trees

### Should I ask the user, or proceed?

```
PROCEED autonomously when:
  - Only the SHA changed (routine refresh on the same tag)
  - The tag exists in upstream readme.md
  - No ApiCompat errors after generation

ASK the user when:
  - Tag does not exist in upstream readme.md
  - Spec path no longer exists at the resolved SHA
  - Generation produces ApiCompat breaking changes
  - More than one candidate package matches the user's reference
  - The user supplied a SHA that does not contain the requested tag
```

### Which command should I run?

```
IF <PACKAGE_PATH>/src/<PACKAGE>.csproj defines a GenerateCode target
   -> dotnet build /t:GenerateCode
ELSE IF <PACKAGE_PATH>/src/autorest.md exists
   -> autorest --csharp <PACKAGE_PATH>/src/autorest.md
ELSE
   -> stop and ask
```

---

## Common Pitfalls

- Forgetting to update the `require:` URL -- it also embeds a SHA and must be repinned.
- Updating only the top-level `input-file` list while leaving SHA-pinned URLs in conditional blocks (`$(tag) == 'package-X'`).
- Running `autorest` without `--use:` -- picking up a different generator version than CI.
- Treating ApiCompat errors as generation failures -- they are **policy** failures and require the migration / mitigation skills.
- Editing `Generated/` to silence a build error -- always fix the cause upstream of the generator.
- Pinning to a SHA from a fork or a private branch -- only `Azure/azure-rest-api-specs@main` SHAs are CI-reproducible.

---

## Related Skills

- `sdk-migration` -- Migrating a library from Swagger/AutoRest to TypeSpec
- `mitigate-breaking-changes` -- Handling ApiCompat / public-surface changes after regeneration
- `pre-commit-checks` -- `dotnet format`, API export, snippet refresh before commit
- `analyze-ci-failures` -- Diagnosing CI failures after a regeneration PR is opened

