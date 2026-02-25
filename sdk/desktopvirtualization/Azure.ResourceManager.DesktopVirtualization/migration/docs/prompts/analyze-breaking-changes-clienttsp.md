# Prompt: Analyze Breaking Changes Fixable via client.tsp Decorators

Use this prompt after generating `toFix.txt` from `parse_breaking_changes.py` to determine which breaking changes can be resolved with `@@clientName` or `@@alternateType` decorators in `client.tsp`.

---

```
Analyze the breaking changes in the SUGGESTED ACTION CHECKLIST section of toFix.txt and determine which ones can be fixed via `@@clientName` or `@@alternateType` decorators in client.tsp (the TypeSpec client customization file).

Steps:
1. Read the full SUGGESTED ACTION CHECKLIST from toFix.txt (in the migration/tools/ folder).
2. Read the current client.tsp (in TempTypeSpecFiles/DesktopVirtualization/).
3. For each checklist item, search the TypeSpec source .tsp files (in TempTypeSpecFiles/DesktopVirtualization/) to find the original TypeSpec name of the type/property/enum-value involved. You need the EXACT TypeSpec name to write a @@clientName or @@alternateType decorator.
4. Classify each item into one of these categories:

   **A) Fixable with `@@clientName`** — The TypeSpec source has the type/property/enum-value but it generates a different C# name than the old SDK used. A `@@clientName(TypeSpecName, "DesiredCSharpName", "csharp")` decorator can rename it. Common sub-cases:
   - Acronym casing differences (e.g., TypeSpec `startVMOnConnect` generates `StartVMOnConnect` but old SDK had `StartVmOnConnect`)
   - Property renames (e.g., TypeSpec property is `type` but old SDK called it `UpdateType`)
   - Type renames (e.g., TypeSpec type is `MSIXImageURI` but old SDK called it `MsixImageUri`)
   - Enum value renames (e.g., TypeSpec `SxSStackListenerCheck` but old SDK had `SxsStackListenerCheck`)

   **B) Fixable with `@@alternateType`** — The TypeSpec source has the property but it generates a different C# type than the old SDK used. An `@@alternateType(TypeSpecProp, AlternateType, "csharp")` can change the generated type. Common sub-cases:
   - `string` → `Azure.Core.armResourceIdentifier` (generates `ResourceIdentifier`)
   - `string` → `TypeSpec.url` (generates `Uri`)
   - `string` → `Azure.Core.eTag` (generates `ETag`)

   **C) Needs existing clientName CHANGED** — There's already a @@clientName in client.tsp but it produces the wrong name (e.g., renames to `IsCloudPcResource` but old SDK had `IsCloudPCResource`).

   **D) NOT fixable with decorators** — The issue requires custom C# code, TypeSpec model/operation changes, or API baseline suppression. Sub-cases:
   - Missing types (not in TypeSpec source at all)
   - Missing methods/overloads on collections/resources
   - Setter/mutability changes (read-only vs read-write)
   - Constructor visibility (sealed types)
   - Virtual member restoration
   - Base type/interface changes
   - Enum↔extensible-string classification changes
   - Properties that don't exist in the TypeSpec model

5. Output a structured report with:
   - A table for each fixable category (A, B, C) showing: item #, TypeSpec target (e.g., `HostPoolProperties.startVMOnConnect`), decorator to add (e.g., `@@clientName(HostPoolProperties.startVMOnConnect, "StartVmOnConnect", "csharp")`), and which checklist items it resolves.
   - A summary of category D items grouped by sub-case, just listing the item numbers.
   - A final count: X items fixable via decorators, Y items need other approaches, out of Z total.

6. Save the report to `migration/tools/breaking_analysis.txt`.

7. Save a separate reasoning file to `migration/tools/breaking_analysis_reasoning.txt` that explains, for each category A/B/C item, WHY a `@@clientName` or `@@alternateType` decorator can fix it. For each item include:
   - The checklist item number and description
   - The TypeSpec source name (what it's called in .tsp) and the C# name the old SDK expected
   - What the code generator currently produces without the decorator and why it differs (e.g., "The C# emitter converts `startVMOnConnect` to `StartVMOnConnect` treating `VM` as one token, but the old SDK used `StartVmOnConnect` treating `Vm` as a regular word")
   - The exact decorator line to add/change
   - If an existing clientName needs to be changed (category C), show both the current and corrected decorator

Do NOT make any code changes — this is a research/analysis task only.
```
