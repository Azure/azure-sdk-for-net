---
name: cu-sdk-author-analyzer-classify-route
description: Create and test a classify-and-route Azure AI Content Understanding pipeline for packets that contain multiple document types (e.g. invoice + bank statement + loan application in one PDF). Walks per-type schema authoring → outer classifier wiring → batch test → category-aware stdout summary using the typed ContentUnderstandingClient (.NET). Use when the user has mixed-document packets.
---

# Author a Classify-and-Route Analyzer (mixed document packets)

Build a classify-and-route pipeline: one **outer classifier analyzer** that
segments and labels a multi-document packet, plus one **inner extractor
analyzer per document type**. The packet flows through the outer analyzer
once; each segment is automatically routed to the matching inner analyzer
for field extraction.

**This is an iterative, human-in-the-loop workflow.** You will typically run
the schema → test → review cycle multiple times to refine both the outer
classifier descriptions and each inner schema's field descriptions before
you're happy with both classification accuracy and extraction quality.

> **[USE INSTEAD]:** If every page in the user's documents is the **same
> type** (only invoices, only contracts, etc.), use
> [`cu-sdk-author-analyzer`](../cu-sdk-author-analyzer/SKILL.md) instead.
> Classify-and-route is for **mixed** packets.

> **[ASK USER] Modality check (first thing to confirm):**
>
> "Are you working with **document** files — PDFs or images of pages? This
> skill currently supports document modalities only. Audio, video, and
> image classifiers are planned for a future update."
>
> - If the user says **document** → continue with this skill.
> - If the user says **audio**, **video**, or **image** → stop this skill.
>   Audio/video classify-and-route is on the roadmap; for now point them at
>   the [REST tutorial](https://learn.microsoft.com/azure/ai-services/content-understanding/tutorial/create-custom-analyzer).

> **[COPILOT INTERACTION MODEL]:** At each step marked with **[ASK USER]**,
> pause execution and prompt the user before proceeding.

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
> | endpoint `MISSING` | create or edit `.env` with `CONTENTUNDERSTANDING_ENDPOINT=https://<your-resource>.services.ai.azure.com/`, then resume |
> | endpoint `ok`, key `empty`, `az: not logged in` | run `az login` **or** add `CONTENTUNDERSTANDING_KEY` to `.env`, then resume |
> | All env checks pass but service calls fail with model errors | run [`Sample00_UpdateDefaults.md`](../../../samples/Sample00_UpdateDefaults.md) once for this resource, then resume |
> | All ok | ✅ Proceed to the Packet check below. |
>
> Never ask the user to paste an endpoint or API key into chat — they edit `.env` directly or run `az login`.

> **[ASK USER] Packet check:**
> 1. "Does each document in your packet contain more than one type of form (e.g. an invoice page followed by a bank statement page)?" — if no, route to `cu-sdk-author-analyzer`.
> 2. "What types of documents appear in your packets?" — capture as the list of inner analyzers.

## Architecture

```
                       ┌──────────────────────────────┐
   mixed packet  ───►  │  outer (classifier) analyzer │
                       │  baseAnalyzerId: prebuilt-…  │
                       │  config.enableSegment: true  │
                       │  config.contentCategories:   │
                       │    invoice          ────────►│──┐
                       │    bank_statement   ────────►│──┼──► per-segment fields
                       │    loan_application ────────►│──┘
                       └──────────────────────────────┘
                                                       │
                       inner analyzers (1 per type)    │
                       ───────────────────────────     ▼
                       invoice extractor   ◄──── routes here for invoice pages
                       bank statement ext. ◄──── routes here for bank pages
                       loan app extractor  ◄──── routes here for loan pages
```

Key rules (also captured in the
[Content Understanding best-practices guide][best-practices] and the
[analyzer reference][analyzer-reference] under "classify-and-route"):

1. **Category descriptions reference text anchors**, not visual cues
   (matches the two-stage pipeline rule for fields).
2. **`config.enableSegment` must be `true`** so the classifier can carve up
   the packet before routing.
3. **Inner analyzers must exist before** the outer classifier is created.
   The provided tool handles ordering automatically.
4. **Category fill rate is per-category**, not packet-wide. The tool's
   stdout summary uses the right denominator.

## Package directory

```
sdk/contentunderstanding/Azure.AI.ContentUnderstanding
```

## Scripts and templates

```
.github/skills/
├── _shared/                       # The skill tool (single csproj, three subcommands)
└── cu-sdk-author-analyzer-classify-route/
    ├── SKILL.md (this file)
    └── templates/
        └── classifier_template.json   # Starter outer-classifier schema for Step 3
```

The skill tool builds against the local `Azure.AI.ContentUnderstanding.dll`,
so before first use:

```bash
dotnet build sdk/contentunderstanding/Azure.AI.ContentUnderstanding/src/Azure.AI.ContentUnderstanding.csproj
```

## Workflow

### Step 1 — Identify the document types

Run layout extraction (same as the single-type skill) on a representative
packet to see the section headings:

```bash
dotnet run --project sdk/contentunderstanding/Azure.AI.ContentUnderstanding/.github/skills/_shared -- \
    extract-layout \
    --input <packet.pdf> \
    --output .local_only/layout/
```

> **[COPILOT]** Read `.local_only/layout/<packet>.layout.md` **yourself** and
> identify section headings, page breaks, and content shifts that suggest
> different document types. Then present your analysis to the user for
> confirmation — do **not** ask the user to read the layout cold.
>
> Example presentation:
>
> > "Based on the layout in `<packet>.layout.md` I see these document types:
> >
> > - **Pages 1–2** — appears to be an *invoice* (top heading 'Invoice',
> >   contains 'Invoice #' label and a line-item table)
> > - **Pages 3–4** — appears to be a *bank statement* (top heading
> >   'Account Statement', contains account number and a transaction table)
> > - **Page 5** — appears to be a *loan application* (top heading 'Loan
> >   Application', applicant fields)
> >
> > Does this look right? Anything to add, remove, or rename before I
> > draft schemas?"
>
> Only fall back to a blank `[ASK USER]` ("What types do you see?") if the
> layout is too ambiguous to suggest types confidently.

### Step 2 — Draft one inner schema per type

Treat each type as a single-doc-type analyzer (pick `baseAnalyzerId` from
the modality-level prebuilts — see the
[analyzer reference][analyzer-reference] —
then add `fieldSchema.fields`). Field descriptions follow the
two-stage pipeline rule documented in the
[Content Understanding best-practices guide][best-practices]
— reference text and structure, never visual appearance. See
[`cu-sdk-author-analyzer`](../cu-sdk-author-analyzer/SKILL.md) Step 2 for
the full field-schema walkthrough.

> **[COPILOT] Read best practices before drafting fields.** Before writing
> any field description (in any inner schema or the outer classifier's
> category descriptions), fetch the official CU best-practices page and
> apply its guidance:
>
> 🔗 https://learn.microsoft.com/azure/ai-services/content-understanding/concepts/best-practices
>
> The same key principles apply here as in
> [`cu-sdk-author-analyzer`](../cu-sdk-author-analyzer/SKILL.md#step-2--draft-a-json-field-schema):
> be specific and concrete, use text anchors (not visual cues), include
> alternative labels and format examples, prefer `extract` for verbatim
> values, and keep the field count focused.

> **Reference**:
> [`Sample05_CreateClassifier.md`](../../../samples/Sample05_CreateClassifier.md)
> ships a complete worked example using
> `samples/sample_files/mixed_financial_docs.pdf` with three categories —
> Invoice, Bank_Statement, Loan_Application.

### Step 3 — Draft the outer classifier schema

The outer schema has **no** `fieldSchema`. Its job is classification + routing.
Start from the template:

```bash
mkdir -p .local_only/schemas
cp sdk/contentunderstanding/Azure.AI.ContentUnderstanding/.github/skills/cu-sdk-author-analyzer-classify-route/templates/classifier_template.json \
   .local_only/schemas/<name>_classifier_v1.json
```

Example after editing (descriptions intentionally generic so they survive
minor wording variants — see the **Category description rule** below the
example for guidance on writing your own):
```json
{
  "baseAnalyzerId": "prebuilt-document",
  "description": "Classify mixed financial packets and route to per-type extractors.",
  "config": {
    "enableSegment": true,
    "omitContent": true,
    "contentCategories": {
      "invoice": {
        "description": "A commercial invoice. Look for an invoice / bill heading or label, an invoice number, line-item table with quantities and prices, and a total amount.",
        "analyzerId": "invoice"
      },
      "bank_statement": {
        "description": "A bank or account statement. Look for an account-statement heading, an account number, a statement period or date range, and a transaction table with running balance.",
        "analyzerId": "bank_statement"
      },
      "loan_application": {
        "description": "A loan or credit application form. Look for an application heading, applicant or borrower fields, requested loan amount, and applicant signature.",
        "analyzerId": "loan_application"
      }
    }
  },
  "models": {
    "completion": "gpt-4.1",
    "embedding": "text-embedding-3-large"
  }
}
```

The `analyzerId` value in each category is **an alias** that the tool
resolves at runtime, matching the `--inner-schema alias=path` flags you
pass. Two exceptions skip alias resolution:

* Values starting with `prebuilt-` (e.g. `prebuilt-invoice`) are used as-is
  — no inner schema needed. Useful for routing a category at a service
  prebuilt extractor.
* Categories without an `analyzerId` at all are classification-only — the
  segment is labelled but no fields are extracted.

> **Why `omitContent: true`?** When omitted, the service also returns the
> raw, un-segmented document content as an extra entry in `contents`. That
> entry has no category, no fields, and shows up in the summary as a
> confusing `(uncategorized)` row. Setting `omitContent: true` removes it.

> **Category description rule — the example values above are demo-specific.**
>
> The category descriptions in the JSON above are tied to the demo packet
> `samples/sample_files/mixed_financial_docs.pdf` (which uses the literal
> headings `Invoice`, `Bank Statement`, `Loan Application`). **Do not copy
> them verbatim.** When authoring for the user's own packet, write
> descriptions based on what you observed in **the user's** layout output
> from Step 1 — use the actual headings, labels, and structural markers
> from their documents.
>
> Keep descriptions:
>
> - **Generic over surface form** — describe the *kind* of content
>   ("contains a transaction table with running balance") rather than
>   hardcoding one specific header string, so minor wording variants still
>   classify correctly.
> - **Concrete enough to be discriminative** — include at least one anchor
>   that distinguishes this category from the others in the packet.
> - **Text-anchored, not visual** — reference headings, labels, and
>   neighbouring text, never colour / font / position-without-text. Same
>   reason as the field-description rule in the
>   [Content Understanding best-practices guide][best-practices].

### Step 4 — Validate, create, and batch-test

```bash
dotnet run --project sdk/contentunderstanding/Azure.AI.ContentUnderstanding/.github/skills/_shared -- \
    create-and-test-router \
    --outer-schema .local_only/schemas/classifier.json \
    --inner-schema invoice=.local_only/schemas/invoice.json \
    --inner-schema bank_statement=.local_only/schemas/bank_statement.json \
    --inner-schema loan_application=.local_only/schemas/loan_application.json \
    --input samples/sample_files/mixed_financial_docs.pdf \
    --output .local_only/test_results/v1
```

> **Shortcut — `--schema-dir`:** if your inner schema filenames match the
> outer-schema category aliases (e.g. `.local_only/schemas/invoice_v1.json` for category
> `invoice`), replace every `--inner-schema alias=path` with a single
> `--schema-dir .local_only/schemas/`. The tool picks the newest matching file per
> alias (alphabetical sort, so `invoice_v2.json` wins over `invoice_v1.json`).

> **Iteration helper — `--reuse`:** add `--reuse` to name analyzers by a
> sha1 of their schema (`<stem>_<hash[:8]>`) and skip creation when an
> analyzer with that ID already exists. Re-running with the same schemas
> is a no-op on the create side, so you don't pile up stale analyzers while
> iterating. Edit a schema → hash changes → new analyzer is created.

The tool:

1. Validates every schema (exits with code **2** if any fails — no service
   call made).
2. Errors out if the outer schema references an alias that has no matching
   `--inner-schema`, or if you supply an `--inner-schema` that no category
   uses.
3. Creates inner analyzers first, then patches and creates the outer
   classifier.
4. Analyzes every input file, writing one JSON per file under `--output`.
5. Prints a **category-aware** stdout summary (per-category fill rate
   uses each category's segment count, not the packet-wide total).

### Step 5 — Read the category-aware summary

Example output:

```
========================================================================
[SUMMARY] (category-aware)

category: bank_statement  (1 segments)
--------------------------------------
  field                          fill rate   avg conf
  AccountNumber                  100.0%      0.918
  StatementPeriod                100.0%      0.882

category: invoice  (1 segments)
-------------------------------
  field                          fill rate   avg conf
  InvoiceNumber                  100.0%      0.962
  TotalAmount                    100.0%      0.531

category: loan_application  (1 segments)
----------------------------------------
  field                          fill rate   avg conf
  ApplicantName                  100.0%      0.875
  LoanAmount                     100.0%      0.799

lowest-confidence fields across all categories:
  0.531  [invoice] TotalAmount  (mixed_financial_docs)
  0.799  [loan_application] LoanAmount  (mixed_financial_docs)
  0.875  [loan_application] ApplicantName  (mixed_financial_docs)
========================================================================
```

For each input document the tool writes two files into `--output`:

- `<doc>.json` — full `AnalysisResult` with all per-segment fields and grounding.
- `<doc>.llm.md` — the same result rendered via the SDK's
  [`AnalysisResultExtensions.ToLlmInput`](../../../samples/Sample_Advanced_ToLlmInput.md) helper.
  For classify-and-route, the helper expands each classified segment into
  its own block with the **category in the YAML front matter**, separated by
  `*****` dividers — drop it into an LLM prompt or skim it in VS Code.

> **Template comment keys**: any key whose name starts with `_`
> (e.g. `_comment`, `_optional_returnDetails`) is stripped from both the
> outer and inner schemas before the request body is sent. Use them freely
> as inline documentation.

> **`models.completion` for inner schemas**: each inner schema (which has a
> `fieldSchema`) needs `models.completion` set unless the resource has
> defaults configured via
> [`Sample00_UpdateDefaults.md`](../../../samples/Sample00_UpdateDefaults.md).
> `create-and-test-router` prints a `[WARN]` per inner schema that is
> missing it, before any service call.

### Step 6 — Agent review and iterate

> **[COPILOT]** After the category-aware summary prints, do the following
> **automatically** before asking the user anything:
>
> 1. For each entry in `result.contents[]` in `<doc>.json`, verify the
>    assigned `category` matches what the page actually is. Use
>    `.local_only/layout/<doc>.layout.md` as ground truth.
>    - **Misclassified segment** → the **outer classifier's**
>      `contentCategories.<key>.description` needs strengthening, not the
>      inner schema. Add a discriminating anchor from the layout to the
>      category description and recreate the outer classifier.
> 2. For each correctly-classified segment, compare extracted field values
>    against the layout the same way as the single-type skill (see
>    [`cu-sdk-author-analyzer`](../cu-sdk-author-analyzer/SKILL.md#step-5--agent-review-and-iterate)).
>    Flag fields where:
>    - The extracted value looks wrong or is `null` when a value should be present
>    - Confidence is below 0.7
>    - The grounding location is unexpected
> 3. Present a per-category diff to the user:
>    - "In the `invoice` segment, field `TotalAmount` extracted `'1234'` —
>      I see `'$1,234.56'` near the 'Total' label. Should I tighten the
>      description?"
>    - "Page 5 was classified as `loan_application` but the heading is
>      actually 'Borrower Agreement' — should I add that wording to the
>      `loan_application` category description?"
> 4. Record user-confirmed corrections in per-category ground-truth files
>    (`.local_only/ground_truth_<category>.json`) so the agent remembers
>    correct answers across iterations:
>    ```json
>    [
>      { "doc": "mixed_packet_1.pdf", "segment": 0, "field": "TotalAmount", "correct_value": "1234.56" }
>    ]
>    ```
> 5. Update the affected schema(s) — outer classifier for classification
>    fixes, inner schemas for field fixes — as a new version
>    (`*_v2.json`).
> 6. Re-run Step 4 with the new schemas. `--reuse` rebuilds only the
>    analyzers whose schema hash changed.
>
> Repeat until every category has:
>
> - All segments classified correctly
> - Key fields **fill rate ≥ 80%** and **avg confidence ≥ 0.85** (computed
>   per-category, as the summary already does)
>
> Stop and report to the user when any of:
>
> - All targets met (success) — then proceed to **Step 7** to hand off.
> - Three consecutive iterations show no improvement on a given category
>   (escalate — may need a different `baseAnalyzerId`, schema redesign, or
>   a different category split).
> - The user signals they're done.

### Step 7 — Hand off the finished pipeline

This step is required when Step 6 succeeds. **Do not skip it.** Without a
clean handoff the user has a working classify-and-route pipeline in their
resource but no idea what the outer classifier ID is, which inner
analyzers it routes to, where the final schemas live, or how to call it
from their own code.

> **[COPILOT]** When Step 6 reaches success, report the following to the
> user in one message before stopping:
>
> 1. **All analyzer IDs built** — list both the **outer classifier** and
>    every **inner extractor**, with the actual IDs printed by
>    `create-and-test-router` (e.g.
>    `classifier_v2_a1b2c3d4` → routes to
>    `classifier_v2_a1b2c3d4_inner_invoice_b2c3d4e5`,
>    `..._inner_bank_statement_c3d4e5f6`,
>    `..._inner_loan_application_d4e5f6a7`). The user only needs to call
>    the **outer** analyzer in their own code; it routes to the inner
>    ones automatically.
> 2. **All schema files** — list the path to every schema JSON in the
>    final iteration: the outer classifier and each inner schema (e.g.
>    `.local_only/schemas/classifier_v2.json`,
>    `.local_only/schemas/invoice_v3.json`, etc.). Recommend the user save
>    them somewhere outside `.local_only/` for future reference; they can
>    also inspect any existing analyzer's schema directly via the SDK (see
>    [`Sample06_GetAnalyzer.md`](../../../samples/Sample06_GetAnalyzer.md)).
> 3. **Next-step samples** — point the user to:
>    - [`Sample05_CreateClassifier.md`](../../../samples/Sample05_CreateClassifier.md)
>      — how to (re)build the full classify-and-route pipeline from schema
>      JSON in their own code (handles inner-first creation ordering and
>      `contentCategories.analyzerId` wiring the same way our tool did).
>    - [`Sample01_AnalyzeBinary.md`](../../../samples/Sample01_AnalyzeBinary.md)
>      and
>      [`Sample02_AnalyzeUrl.md`](../../../samples/Sample02_AnalyzeUrl.md)
>      — how to call the analyzer on real input from their own code. Use
>      the **outer classifier's** analyzer ID as `analyzerId`.
>
>    Remind the user that the analyzers you just built are **already
>    deployed** to their resource and ready to use directly via their IDs
>    — they only need to re-create them from the schemas if they want to
>    bootstrap into another resource.

### Step 8 — Clean up (optional)

By default the tool leaves both the outer classifier **and** all inner
analyzers in your resource so you can re-use them. Pass `--ephemeral` to
delete all of them at the end of the run.

## Exit codes

| Code | Meaning |
|---|---|
| `0` | Every document analyzed successfully. |
| `1` | At least one service-side failure. |
| `2` | Local user error — schema validation, missing inner alias, bad path. No service call made. |

## Related skills

- [`cu-sdk-author-analyzer`](../cu-sdk-author-analyzer/SKILL.md) — single doc type.
- [Sample05_CreateClassifier.md](../../../samples/Sample05_CreateClassifier.md) — the reference SDK sample this skill is patterned on.

<!-- LINKS -->
[best-practices]: https://learn.microsoft.com/azure/ai-services/content-understanding/concepts/best-practices
[analyzer-reference]: https://learn.microsoft.com/azure/ai-services/content-understanding/concepts/analyzer-reference#baseanalyzerid
