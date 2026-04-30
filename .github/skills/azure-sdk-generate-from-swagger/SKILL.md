---
name: azure-sdk-generate-from-swagger
description: >
  Generate Azure SDKs from Swagger/OpenAPI specifications using AutoRest.
  Use this skill for any task that generates or regenerates SDKs from Swagger,
  including selecting API versions via AutoRest tags, updating AutoRest
  configuration files (autorest.md / readme.md), pinning Swagger commit SHAs,
  and running SDK generation for Azure management-plane SDKs (for example, .NET).
user-invocable: true
---

# Azure SDK Generation from Swagger (AutoRest)

## When to Use This Skill

Use this skill when performing SDK generation tasks driven by Swagger, including:

- Generating a new SDK from an existing Swagger API version
- Regenerating SDKs after Swagger updates
- Switching SDK generation to a new API version using AutoRest tags
- Pinning a specific Swagger commit SHA for reproducible SDK generation
- Troubleshooting SDK generation failures caused by Swagger or configuration changes

---

## Explicit Non?Goals

This skill does **NOT**:

- Edit or author TypeSpec (`.tsp`) files
- Convert Swagger to TypeSpec
- Publish SDKs or approve releases
- Perform breaking?change analysis or approval

All TypeSpec authoring must use the **azure-typespec-author** skill.

---

## Operating Principles (Non?Negotiable)

1. **Swagger is the source of truth**
   SDK generation must be driven exclusively by Swagger files.

2. **AutoRest configuration is mandatory**
   All SDK generation must be controlled through `autorest.md` or `readme.md`.

3. **Explicit API version selection**
   The target API version must be selected via an AutoRest tag.

4. **Swagger commit pinning is required**
   The Swagger commit SHA must be recorded in the AutoRest configuration.

5. **No configuration edits without a plan**
   Configuration files must not be edited until a grounded plan is produced.

6. **SDK generation must be validated**
   AutoRest must be run and its result reported.

---

## Workflow (Mandatory)

1. **Intake & Clarification**
   - SDK language
   - Swagger repo, path, and commit SHA
   - Target API version and AutoRest tag
   - SDK repository and AutoRest config location

2. **Generate SDK Plan**
   - Determine required AutoRest tag and inputs
   - Identify required configuration changes

3. **Apply Configuration Changes**
   - Update the identified AutoRest configuration file (`autorest.md` or `readme.md`)
   - Add or update:
     - AutoRest tag for the target API version
     - `input-file` entries pinned to the Swagger commit SHA
   - No SDK generation may proceed without these changes.

4. **Run SDK Generation**
   - Execute AutoRest with the selected tag
   - Capture generation output

5. **Summarize Results**
   - Files changed
   - API version and Swagger commit used
   - SDK generation success or failure

6. **Next Steps**
   - Testing and validation guidance
   - Follow?up actions if needed

---

## Related Skills

- **azure-typespec-author** — TypeSpec authoring and API versioning
- **check-package-readiness** — SDK release readiness checks
