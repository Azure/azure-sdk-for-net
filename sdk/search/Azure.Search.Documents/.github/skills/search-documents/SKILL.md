---
name: search-documents
description: '**UTILITY SKILL** — Domain knowledge for the Azure.Search.Documents SDK package. Covers architecture, code generation, key files, and common pitfalls. WHEN: regenerate search package; modify search client; fix search bug; add search feature; search type mapping.'
---

# Azure.Search.Documents — Package Skill

<!-- TODO: This is a placeholder skill. Domain experts should fill in the sections below
     with tribal knowledge specific to this package. Use the @azure/search-documents
     skill in the azure-sdk-for-js repo as a reference for the level of detail expected. -->

## Architecture

<!-- TODO: Describe the overall architecture, data flow patterns,
     and the relationship between generated and hand-authored code.
     What conventions does this package follow? -->

### Source Layout

All source lives under `src/`. The `Generated/` subdirectory contains auto-generated
partial classes and models — **never hand-edit files in `Generated/`**. Hand-authored
code elsewhere in `src/` extends the generated partial classes.

Directories: `Batching/`, `Generated/`, `Indexes/`, `Internal/`, `KnowledgeBases/`,
`Models/`, `Options/`, `Properties/`, `SearchDocument/`, `Serialization/`, `Spatial/`,
`Utilities/`.

<!-- TODO: Document the purpose of each directory and key files. -->

## Regeneration

TypeSpec source is configured in `tsp-location.yaml`.

<!-- TODO: Document the regeneration workflow for this package.
     - What command regenerates the client?
     - What files need manual updates after regeneration?
     - Are there any merge steps or special flags? -->

## The Clients

<!-- TODO: Document the clients in this package, their purposes,
     construction patterns, authentication, and any non-obvious behaviors. -->

## Key Hand-Authored Files

<!-- TODO: Document the key hand-authored files and their purposes. -->

## Type Mappings

<!-- TODO: Document property name differences between public API and wire format,
     any type conversions, null handling patterns, etc. -->

## Common Pitfalls

<!-- TODO: Document common mistakes and non-obvious behaviors. -->

## Testing Notes

<!-- TODO: Document test patterns, recorded test setup, environment requirements,
     and any special testing conventions for this package. -->
