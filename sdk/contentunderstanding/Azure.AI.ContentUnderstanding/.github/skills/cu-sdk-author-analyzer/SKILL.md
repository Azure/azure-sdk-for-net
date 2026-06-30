---
name: cu-sdk-author-analyzer
description: Iteratively author and test a custom Azure AI Content Understanding analyzer for a folder of **document** files (PDFs, page images) of a single type. Walks layout extraction → schema authoring → validation → batch test → agent review → refine cycle using the typed ContentUnderstandingClient (.NET). Document modality only — audio, video, and image analyzers are planned for a later update. Use when the user wants to author a custom analyzer for invoices, contracts, forms, or any other single-type document set.
---

# Author a Custom Analyzer (single document type)

Author a custom Content Understanding analyzer for one document type
end-to-end: extract layout, draft a field schema, validate locally, create the
analyzer, batch-test it on sample files, and read a quality summary.

**This is an iterative, human-in-the-loop workflow.** You will typically run
the schema → test → review cycle multiple times to refine field descriptions
before you're happy with the extraction quality.

The workflow uses the typed `ContentUnderstandingClient` shipped in this
package — the same client `Sample04_CreateAnalyzer.md` and
`Sample01_AnalyzeBinary.md` use.

> **[COPILOT INTERACTION MODEL]:** This skill is designed to be interactive.
> At each step marked with **[ASK USER]**, pause execution and prompt the user
> for input or confirmation before proceeding. Do NOT silently skip these
> prompts. Use the `ask_questions` tool when available.

> **[USE INSTEAD]:** If the user's packet contains **multiple different
> document types** (for example, an invoice, a bank statement, and a loan
> application in one PDF), route them to the
> [`cu-sdk-author-analyzer-classify-route`](../cu-sdk-author-analyzer-classify-route/SKILL.md)
> skill instead. This skill assumes one document type per analyzer.

> **[ASK USER] Modality check (first thing to confirm):**
>
> "Are you working with **document** files — PDFs or images of pages? This
> skill currently supports document modalities only. Audio, video, and
> image analyzers are planned for a future update."
>
> - If the user says **document** → continue with this skill.
> - If the user says **audio**, **video**, or **image** → stop this skill and
>   point them at the typed-model samples
>   ([`Sample04_CreateAnalyzer.md`](../../../samples/Sample04_CreateAnalyzer.md)
>   with `prebuilt-audio` / `prebuilt-video` / `prebuilt-image`) or the
>   [REST tutorial](https://learn.microsoft.com/azure/ai-services/content-understanding/tutorial/create-custom-analyzer).

## Prerequisites

Required: the `Azure.AI.ContentUnderstanding` SDK built locally (the skill
tool references the built DLL by path), `.env` or environment variables
with `CONTENTUNDERSTANDING_ENDPOINT` (plus `CONTENTUNDERSTANDING_KEY` or
`az login`), and the model defaults configured for this resource (see
[`Sample00_UpdateDefaults.md`](../../../samples/Sample00_UpdateDefaults.md)).

> **[COPILOT] Probe first, then route on failure — do not duplicate setup logic here.**
>
> ```bash
> dotnet --version >/dev/null 2>&1 && echo 'dotnet: ok' || echo 'dotnet: MISSING'
> ( [ -f .env ] && grep -E '^CONTENTUNDERSTANDING_ENDPOINT=https?://' .env >/dev/null && echo 'endpoint: ok' ) || echo 'endpoint: MISSING'
> ( [ -f .env ] && grep -E '^CONTENTUNDERSTANDING_KEY=.+' .env >/dev/null && echo 'key: set' ) || echo 'key: empty'
> az account show >/dev/null 2>&1 && echo 'az: ok' || echo 'az: not logged in'
> ```
>
> | Failure | Route to |
> |---|---|
> | `dotnet: MISSING` | install .NET 10 SDK from https://dotnet.microsoft.com/download |
> | endpoint `MISSING` | create or edit `.env` at the repo root with `CONTENTUNDERSTANDING_ENDPOINT=https://<your-resource>.services.ai.azure.com/`, then resume |
> | endpoint `ok`, key `empty`, `az: not logged in` | run `az login` **or** add `CONTENTUNDERSTANDING_KEY` to `.env`, then resume |
> | All env checks pass but service calls fail with model errors | run [`Sample00_UpdateDefaults.md`](../../../samples/Sample00_UpdateDefaults.md) once for this resource, then resume |
> | All ok | ✅ Proceed to Step 1. |
>
> Never ask the user to paste an endpoint or API key into chat — they edit `.env` directly or run `az login`.

> **[ASK USER]** "How many representative documents do you have, and where are they?" — fewer than 3 is fine, but more is better for testing coverage.

## Package directory

```
sdk/contentunderstanding/Azure.AI.ContentUnderstanding
```

## Scripts and templates

```
.github/skills/
├── _shared/
│   ├── cu-skill.csproj            # Single tool project — three subcommands
│   ├── Program.cs                 # Dispatcher (extract-layout | create-and-test | create-and-test-router)
│   ├── SchemaValidator.cs         # Pure-C# schema validator (no service calls)
│   ├── ExtractLayoutCommand.cs    # Stage 1
│   ├── CreateAndTestCommand.cs    # Stage 2 (single-type)
│   └── CreateAndTestRouterCommand.cs   # Stage 2 (classify-and-route)
└── cu-sdk-author-analyzer/
    ├── SKILL.md (this file)
    └── templates/
        └── schema_template.json   # Starter schema for Step 2
```

The skill tool builds against the local `Azure.AI.ContentUnderstanding.dll`,
so before first use:

```bash
dotnet build sdk/contentunderstanding/Azure.AI.ContentUnderstanding/src/Azure.AI.ContentUnderstanding.csproj
```

## Workflow

### Step 1 — Extract layout for representative documents

The model behind Content Understanding sees the **text and structure** the
service extracts from your file, not the original pixels. Reviewing the
layout output is the fastest way to know what labels and headings you can
anchor your field descriptions to.

> **[ASK USER]** "Point me at one of your sample documents (or a folder of
> them). I'll run layout extraction so we can see what the model will be
> looking at."

Run:

```bash
dotnet run --project sdk/contentunderstanding/Azure.AI.ContentUnderstanding/.github/skills/_shared -- \
    extract-layout \
    --input <path-to-folder-or-file> \
    --output .local_only/layout/
```

This produces one `<doc>.layout.md` and one `<doc>.layout.json` per input.
Open the `.layout.md` file in VS Code and look for the **text anchors** you
want to extract from — labels (`"Invoice #:"`), section headings
(`"Bill To"`), table headers, etc.

> **Reference**: this is the same call pattern as
> [`Sample01_AnalyzeBinary.md`](../../../samples/Sample01_AnalyzeBinary.md)
> using `prebuilt-documentSearch`.

### Step 2 — Draft a JSON field schema

Start from the template instead of writing from scratch:

```bash
mkdir -p .local_only/schemas
cp sdk/contentunderstanding/Azure.AI.ContentUnderstanding/.github/skills/cu-sdk-author-analyzer/templates/schema_template.json \
   .local_only/schemas/<name>_v1.json
```

Then edit `.local_only/schemas/<name>_v1.json`: set `baseAnalyzerId`, replace every
`REPLACE:` placeholder, and add/remove fields. The schema is a JSON object
with two required top-level keys:

- `baseAnalyzerId` — which prebuilt analyzer your custom analyzer extends. Use the table below.
- `fieldSchema.fields` — the named fields you want to extract.

> **[COPILOT] Read best practices before drafting fields.** Before writing
> any field description, fetch the official CU best-practices page and apply
> its guidance:
>
> 🔗 https://learn.microsoft.com/azure/ai-services/content-understanding/concepts/best-practices
>
> Key principles that affect schema quality:
>
> - Be specific and concrete in field descriptions — vague descriptions
>   produce vague extractions.
> - Use **text anchors** (labels, headings, neighbouring fields) — never
>   visual cues like colour, font, or position-without-text-context. This
>   matches the two-stage pipeline rule documented in the [Content
>   Understanding best-practices guide][best-practices].
> - Include **format examples** and **alternative label names** when a value
>   can appear in multiple wordings or formats.
> - Prefer `"method": "extract"` when the value appears verbatim; use
>   `"generate"` only when the model needs to synthesise (summary,
>   classification label) and `"classify"` for fixed enumerations.
> - Keep the field count focused on what the user actually needs. Extra
>   fields cost tokens and can dilute extraction quality on the fields that
>   matter.

The template demonstrates **all three extraction methods** (`extract`,
`generate`, `classify`) plus the **nested object** and **array of objects**
shapes. Delete the example fields you don't need.

> **Template comment keys**: any key whose name starts with `_`
> (e.g. `_comment`, `_optional_enableOcr`) is stripped from the request body
> by `create-and-test` before it hits the service. Use them freely as
> inline documentation.

> **`models.completion` is effectively required**: whenever `fieldSchema` is
> present, the service needs a completion model. Leave the `models` block in
> the template populated unless you've run
> [`Sample00_UpdateDefaults.md`](../../../samples/Sample00_UpdateDefaults.md)
> to set resource defaults. Omitting it fails with `InvalidRequest:
> 'models.completion' is not set` *after* a misleadingly successful
> `[CREATE]` log line. `create-and-test` prints a `[WARN]` if the schema
> is missing it.

#### Choosing `baseAnalyzerId`

Only modality-level prebuilt analyzers are valid for `baseAnalyzerId`:

| Document modality | Use |
|---|---|
| Document (PDF, page images) | `prebuilt-document` |
| Audio (mp3, wav, m4a)       | `prebuilt-audio`    |
| Video (mp4, mov)            | `prebuilt-video`    |
| Image (jpg, png, tif)       | `prebuilt-image`    |

`*Search` variants and task-specific prebuilts (`prebuilt-invoice`,
`prebuilt-receipt`) are **not** valid as `baseAnalyzerId` for a custom
analyzer — the service returns `InvalidBaseAnalyzerId`. See the
[analyzer reference][analyzer-reference] for the authoritative list. The
local validator (Step 3) rejects any value not on that list.

#### Example single-type schema

```json
{
  "baseAnalyzerId": "prebuilt-document",
  "description": "Extract invoice header and totals.",
  "config": {
    "estimateFieldSourceAndConfidence": true,
    "returnDetails": true
  },
  "models": {
    "completion": "gpt-4.1",
    "embedding": "text-embedding-3-large"
  },
  "fieldSchema": {
    "name": "invoice_v1",
    "description": "Invoice header fields.",
    "fields": {
      "invoiceNumber": {
        "type": "string",
        "method": "extract",
        "description": "Invoice number printed near the 'Invoice #' label at the top of the page.",
        "estimateSourceAndConfidence": true
      },
      "totalAmount": {
        "type": "number",
        "method": "extract",
        "description": "Grand total at the bottom of the document; typically labelled 'Total' or 'Amount Due'. Excludes any 'Subtotal' value.",
        "estimateSourceAndConfidence": true
      }
    }
  }
}
```

> **Reference**: see
> [`Sample04_CreateAnalyzer.md`](../../../samples/Sample04_CreateAnalyzer.md)
> for the typed-model equivalent. The `create-and-test` tool sends the JSON
> directly so the schema may include any properties supported by the
> service, even if the typed model doesn't expose them.

> **Field-description rule (two-stage pipeline):** descriptions must reference
> **text content and structure** (labels, headings, neighbouring fields), not
> visual appearance (colour, font, size). See the [Content Understanding
> best-practices guide][best-practices] for the underlying rule.

### Step 3 — Validate the schema locally

```bash
dotnet run --project sdk/contentunderstanding/Azure.AI.ContentUnderstanding/.github/skills/_shared -- \
    create-and-test \
    --schema .local_only/schemas/invoice_v1.json \
    --input samples/sample_files/sample_invoice.pdf \
    --output .local_only/test_results/v1
```

The script runs the local validator first. If anything is wrong (unknown
`baseAnalyzerId`, missing `fieldSchema`, malformed entries) it exits with
code **2** *before* any service call.

### Step 4 — Read the stdout summary

After the script finishes you get something like:

```
========================================================================
[SUMMARY]

category: (single)  (3 documents)
---------------------------------
  field                          fill rate   avg conf
  invoiceNumber                  100.0%      0.962
  totalAmount                     66.7%      0.481

lowest-confidence fields:
  0.461  totalAmount  (mixed_financial_docs)
  0.732  invoiceNumber  (mixed_financial_docs)
========================================================================
```

For each input document the script writes two files into `--output`:

- `<doc>.json` — full per-document `AnalysisResult` (fields, grounding, confidences).
- `<doc>.llm.md` — same result rendered via the SDK's
  [`AnalysisResultExtensions.ToLlmInput`](../../../samples/Sample_Advanced_ToLlmInput.md) helper:
  YAML front matter (category, page range, fields) plus the document text.
  Drop this straight into an LLM prompt, or skim it in VS Code for a fast
  human review.

### Step 5 — Agent review and iterate

> **[COPILOT]** After the summary prints, do the following **automatically**
> before asking the user anything:
>
> 1. Open each `<doc>.llm.md` (and the underlying `<doc>.json` for grounding)
>    in `.local_only/test_results/` and compare extracted field values
>    against the source content. Use `.local_only/layout/<doc>.layout.md`
>    as ground truth — it shows the text the model actually saw.
> 2. Flag any field where:
>    - The extracted value looks wrong or is `null` when a value should be present
>    - Confidence is below 0.7
>    - The grounding location is unexpected
> 3. Present findings to the user with concrete diffs:
>    - "Field `invoiceNumber` extracted `'INV-001'` — does this look correct?"
>    - "Field `totalAmount` was empty, but I see `'$1,234.56'` near the
>      'Total' label in the layout — should I tighten the description?"
> 4. For each correction the user confirms, append to
>    `.local_only/ground_truth_<schema-name>.json`:
>    ```json
>    [
>      { "doc": "invoice_001.pdf", "field": "totalAmount", "correct_value": "1234.56" },
>      { "doc": "invoice_002.pdf", "field": "invoiceDate", "correct_value": "2026-01-15" }
>    ]
>    ```
>    This file is the agent's memory of correct answers across iterations.
> 5. Use the corrections to refine the field descriptions in a new schema
>    version (`.local_only/schemas/<name>_v2.json`).
> 6. Re-run Step 3–4 with the new schema. The `--reuse` flag on
>    `create-and-test` names analyzers by schema hash, so unchanged
>    schemas are a no-op on the create side and a changed schema gets a
>    fresh analyzer automatically.
>
> Repeat until all key fields reach **fill rate ≥ 80%** and
> **avg confidence ≥ 0.85**, or the user is satisfied.
>
> Stop and report to the user when any of:
> - Targets are met (success) — then proceed to **Step 6** to hand off.
> - Three consecutive iterations show no improvement (need a different
>   approach — different `baseAnalyzerId`, different `method`, or schema
>   redesign — escalate to the user).
> - The user signals they're done.

### Step 6 — Hand off the finished analyzer

This step is required when Step 5 succeeds. **Do not skip it.** Without a
clean handoff the user has a working analyzer in their resource but no
idea what its ID is, where the final schema lives, or how to call it from
their own code.

> **[COPILOT]** When Step 5 reaches success, report the following to the
> user in one message before stopping:
>
> 1. **Final analyzer ID** — the actual ID printed by `create-and-test`
>    on its last successful run (e.g. `invoice_v3_a1b2c3d4` when `--reuse`
>    is used). The user will need this to call the analyzer from their own
>    code.
> 2. **Final schema file** — the path to the last iteration of the schema
>    JSON (e.g. `.local_only/schemas/invoice_v3.json`). Recommend the user
>    save it somewhere outside `.local_only/` for future reference; they
>    can also inspect any existing analyzer's schema directly via the SDK
>    (see
>    [`Sample06_GetAnalyzer.md`](../../../samples/Sample06_GetAnalyzer.md)).
> 3. **Next-step samples** — point the user to:
>    - [`Sample04_CreateAnalyzer.md`](../../../samples/Sample04_CreateAnalyzer.md)
>      — how to (re)create a custom analyzer from a schema JSON in their own code.
>    - [`Sample01_AnalyzeBinary.md`](../../../samples/Sample01_AnalyzeBinary.md)
>      and
>      [`Sample02_AnalyzeUrl.md`](../../../samples/Sample02_AnalyzeUrl.md)
>      — how to call the analyzer on real input from their own code.
>
>    Remind the user that the analyzer you just built is **already deployed**
>    to their resource and ready to use directly via its ID — they only
>    need to re-create it from the schema if they want to bootstrap it in
>    another resource.

### Step 7 — Clean up (optional)

By default the analyzer is kept in your resource so you can re-use it. Pass
`--ephemeral` to delete it at the end of a run:

```bash
dotnet run --project sdk/contentunderstanding/Azure.AI.ContentUnderstanding/.github/skills/_shared -- \
    create-and-test \
    --schema .local_only/schemas/invoice_v1.json \
    --input samples/sample_files/sample_invoice.pdf \
    --output .local_only/test_results/v1 \
    --ephemeral
```

> **Iteration helper — `--reuse`:** add `--reuse` to name the analyzer by a
> sha1 of its schema (`<schema-stem>_<hash[:8]>`) and skip creation when an
> analyzer with that ID already exists. Re-running with the same schema is
> a no-op on the create side, so you don't pile up stale analyzers while
> iterating. Edit the schema → hash changes → new analyzer is created.

For explicit lifecycle management see
[`Sample06_GetAnalyzer.md`](../../../samples/Sample06_GetAnalyzer.md),
[`Sample07_ListAnalyzers.md`](../../../samples/Sample07_ListAnalyzers.md),
[`Sample08_UpdateAnalyzer.md`](../../../samples/Sample08_UpdateAnalyzer.md),
and
[`Sample09_DeleteAnalyzer.md`](../../../samples/Sample09_DeleteAnalyzer.md).

## Exit codes

| Code | Meaning |
|---|---|
| `0` | All documents analyzed successfully. |
| `1` | At least one service-side failure (network, throttling, invalid response). |
| `2` | Local user error — schema validator failure, missing flag, bad input path. No service call was made. |

## Related skills

- [`cu-sdk-author-analyzer-classify-route`](../cu-sdk-author-analyzer-classify-route/SKILL.md) — multi-doc-type packets.

<!-- LINKS -->
[best-practices]: https://learn.microsoft.com/azure/ai-services/content-understanding/concepts/best-practices
[analyzer-reference]: https://learn.microsoft.com/azure/ai-services/content-understanding/concepts/analyzer-reference#baseanalyzerid
