---
name: mpg-migration-pr-review
description: Review Azure SDK management-plane migration PRs (Swagger/AutoRest → TypeSpec). Checks customization quality, TypeSpec decorator usage, and migration-specific anti-patterns on top of the standard mgmt PR review.
---

# Azure .NET Mgmt SDK Migration PR Review

Review Azure SDK for .NET management library **migration pull requests** (Swagger/AutoRest → TypeSpec) against migration-specific best practices. This skill **extends** the base `azure-sdk-mgmt-pr-review` skill with additional migration-focused checks.

The review is split into sequential phases:
1. **Phase 1: Versioning Review** (gate) — from base skill
2. **Phase 2: API Review** — from base skill
3. **Phase 3: Breaking Change Detection** — from base skill
4. **Phase 4: Migration Customization Review** — migration-specific (includes blocking rule 4.10: no manual edits to generated files)
5. **Phase 5: TypeSpec Decorator Preference Review** — migration-specific

## When to Use This Skill

Use this skill instead of `azure-sdk-mgmt-pr-review` when the PR is a **migration** from Swagger/AutoRest to TypeSpec. Indicators:
- PR title contains "Migrate to TypeSpec" or "MPG migration"
- PR adds `tsp-location.yaml` and deletes `src/autorest.md`
- PR adds `metadata.json` with TypeSpec emitter metadata
- Files under `src/Generated/` are completely regenerated (large diff)

## Phase 1–3: Base Review

Run the full review from the `azure-sdk-mgmt-pr-review` skill (Phase 1: Versioning, Phase 2: API Review, Phase 3: Breaking Change Detection). All rules from that skill apply.

**Migration-specific note for Phase 2**: Migrations often introduce newly generated enums/models with names that are technically valid C# but still too generic for the public API, such as `Scope`, `GroupScope`, `Sensitivity`, or `ManagedRuleSetException`. Flag these as contextual naming issues and recommend a `@@clientName(..., "csharp")` rename that adds service or resource context (for example, `FrontDoorRuleScope`).

**Migration-specific note for Phase 3**: In migration PRs, breaking changes are expected but must still be mitigated. Pay close attention to `ApiCompatBaseline.txt` — migration PRs are the most tempting place to add baseline entries, but they are still **not allowed**. Every ApiCompat error must be mitigated through customization code or TypeSpec decorators.

## Phase 4: Migration Customization Review

This phase reviews the quality and correctness of SDK customization code (`src/Custom*/` or `src/Customization*/`). Migration PRs often introduce large amounts of customization code, and these are the most common sources of review feedback.

### Instructions

1. Identify all customization files added or modified in the PR (files under `src/Custom*/`, `src/Customization*/`, or `src/Customized*/`).
2. For each customization file, check all rules below.
3. Add review comments directly to the PR for each violation found.

### 4.1 Every Customization Must Have a Justification Comment

Each customization file or significant customization block must include a comment explaining **why** the customization exists. The comment should indicate the root cause:
- Is it mitigating a breaking change?
- Is it working around a generator bug? (If so, link the issue.)
- Is it a naming convention fix?
- Is it adding backward-compatibility for a removed/changed API?

**Bad** — no explanation:
```csharp
[CodeGenSuppress("RedisData", typeof(ResourceIdentifier), typeof(string), ...)]
public partial class RedisData
{
```

**Good** — clear justification:
```csharp
// Suppress generated ctor that doesn't flatten properties from the Properties envelope.
// @flattenProperty in client.tsp restores these properties, but the generated ctor
// signature changed. This preserves the old ctor signature for backward compatibility.
[CodeGenSuppress("RedisData", typeof(ResourceIdentifier), typeof(string), ...)]
public partial class RedisData
{
```

### 4.2 CodeGenMember vs CodeGenSuppress — Use the Right Attribute

`[CodeGenMember]` and `[CodeGenSuppress]` have different semantics:

- **`[CodeGenMember("GeneratedName")]`** — Use when **renaming** a property. The custom property replaces the generated one, and the generator knows they are the same member. This preserves serialization, sample generation, and other downstream references.
- **`[CodeGenSuppress("MemberName", ...)]`** — Use when **removing** a member entirely. The generated member is suppressed and no replacement is expected by the generator.

**Rule**: If the customization is renaming a property (same data, different name), use `[CodeGenMember]`. If suppressing and rewriting with different behavior, use `[CodeGenSuppress]`.

**Bad** — using CodeGenSuppress for a rename:
```csharp
[CodeGenSuppress("Tls1_0")]
public partial struct RedisTlsVersion
{
    public static RedisTlsVersion Tls10 { get; } = new RedisTlsVersion("1.0");
}
```

**Good** — using CodeGenMember for a rename:
```csharp
[CodeGenMember("Tls1_0")]
public static RedisTlsVersion Tls10 { get; } = new RedisTlsVersion("1.0");
```

### 4.3 Redundant CodeGenType Attributes

`[CodeGenType("SpecName")]` is only needed when the custom class name **differs** from the spec/generated type name. If the custom partial class has the same name as the generated type, the attribute is redundant and should be removed.

**Bad** — redundant attribute:
```csharp
[CodeGenType("RedisPrivateLinkResource")]
public partial class RedisPrivateLinkResource
{
}
```

**Good** — no attribute needed when names match:
```csharp
public partial class RedisPrivateLinkResource
{
}
```

### 4.4 EditorBrowsableNever Misuse

`[EditorBrowsable(EditorBrowsableState.Never)]` should **only** be applied to backward-compatibility members that have a **replacement**. It signals "this member is obsolete, use the new one instead."

**Rule**: Never apply `[EditorBrowsable(EditorBrowsableState.Never)]` to:
- The only public constructor of a type
- The only version of a method or property (with no replacement)

If a member is the only public API for its purpose, it should not be hidden.

**Bad** — hiding the only public constructor:
```csharp
[EditorBrowsable(EditorBrowsableState.Never)]
public RedisData() { }  // This is the only public ctor!
```

**Good** — hiding a backward-compat overload that has a replacement:
```csharp
[EditorBrowsable(EditorBrowsableState.Never)]
public RedisData(string sku) { ... }  // Old ctor, replaced by new one below

public RedisData(RedisSku sku) { ... }  // New ctor
```

### 4.5 Migration Strategy: Rename vs Hide-and-Replace

In migration scenarios, when the generated code produces a different method/type name than the old SDK, the correct approach is to **rename the new thing to match the old name**, not to hide the old API and introduce a new one alongside it.

**Rule**: Use `@@clientName` in `client.tsp` to rename newly generated members to their old names. Do not suppress the generated member and add a new custom member with the old name that delegates to the generated one — this creates unnecessary maintenance burden.

**Bad** — hiding old and adding new:
```csharp
// Suppress the newly generated GetRedis and add back GetAllRedis
[CodeGenSuppress("GetRedis")]
public partial class MockableRedisSubscriptionResource
{
    [EditorBrowsable(EditorBrowsableState.Never)]
    public virtual AsyncPageable<RedisResource> GetAllRedisAsync(...) => GetRedisAsync(...);
    
    public virtual AsyncPageable<RedisResource> GetRedisAsync(...) { ... }
}
```

**Good** — rename in TypeSpec to preserve old name:
```typespec
// In client.tsp — rename to match old SDK name
@@clientName(Redis.list, "GetAllRedis", "csharp");
```

### 4.6 ModelFactory Customization Anti-Patterns

ModelFactory methods require special attention in migration PRs. Follow these rules:

1. **Do not suppress generated ModelFactory methods** unless there is a strong justification. The generated methods represent the spec accurately. Always assume generated code is correct in the sense of "this represents the spec the best."

2. **Do not create private `Core` helper methods** that call internal constructors. Instead, call the generated **public** ModelFactory method. Private Core methods break when new properties are added to the model because they depend on internal ctor signatures that change.

   **Bad** — private Core method calling internal ctor:
   ```csharp
   private static RedisData RedisDataCore(string name, RedisSku sku, ...)
   {
       return new RedisData(default, name, default, default, default, ...); // fragile
   }
   ```

   **Good** — call generated public method via ModelFactory class:
   ```csharp
   // Backward-compat overload delegates to the generated public method
   public static RedisData RedisData(string name, RedisSku sku)
   {
       return ArmRedisModelFactory.RedisData(name: name, sku: sku); // calls generated overload
   }
   ```

3. **Do not add excessive overloads.** Only add backward-compatibility overloads that existed in the previous stable version. Check the old `api/*.cs` file to verify.

### 4.7 Constructor Suppression — Fix the Root Cause

If a generated constructor has the wrong signature (e.g., missing flattened properties), do not suppress it and write a custom one. Instead, fix the **root cause** in `client.tsp`:

- **Missing flattened properties?** → Add `@@flattenProperty` decorator in `client.tsp`
- **Wrong property type?** → Use `@@alternateType` in `client.tsp`
- **Missing properties from the `Properties` envelope?** → The `Properties` property likely isn't being flattened; add the decorator

**Rule**: When reviewing `[CodeGenSuppress]` on constructors, always check whether `@@flattenProperty` or other TypeSpec decorators could fix the issue without customization code.

### 4.8 Using Statement Cleanup

Customization files should not have unnecessary `using` statements. If a customization file shows up in the diff only because of added/removed using statements with no other changes, flag it — the file should be cleaned up or not included in the PR.

### 4.9 Obsolete Members Must Throw NotSupportedException

When a member (property, method, constructor) is marked with `[Obsolete]`, it **must** throw `NotSupportedException` instead of providing a functional implementation. An obsolete member signals that it is no longer supported; keeping it functional encourages continued use and makes it harder to remove in the future. Throwing ensures callers get a clear signal to migrate.

**Rule**: Every `[Obsolete]`-attributed member should have a body that throws `NotSupportedException`. Do not delegate to the replacement member or return a default value.

**Bad** — obsolete member still functional:
```csharp
[Obsolete("Use LastUpdatedOn instead.")]
public DateTimeOffset? LastUpdated => LastUpdatedOn;  // still works — callers won't migrate
```

**Good** — obsolete member throws:
```csharp
[Obsolete("This property is now deprecated. Please use the new property `LastUpdatedOn` moving forward.")]
public DateTimeOffset? LastUpdated => throw new NotSupportedException("This property is now deprecated. Please use the new property `LastUpdatedOn` moving forward.");
```

### 4.10 No Manual Edits to Generated Files — MUST FIX (Blocking)

Files under `src/Generated/` must never be manually edited. All code in that directory must come exclusively from the generator. If the PR diff shows manual modifications to any file under `src/Generated/` (e.g., changing a property type, adding `#pragma` suppressions, fixing deserialization calls), this is a **blocking issue** that must be fixed before merge.

**How to detect**: Check `src/Generated/` files in the PR diff. If a generated file has changes that don't match what the generator would produce (e.g., hand-written code, pragmas, type changes), it's a manual edit.

**How to fix**: Use the correct customization mechanism:
- **`[CodeGenSuppress]`** in a `src/Custom/` partial class to suppress the broken generated member, then provide a corrected replacement in the same custom file.
- **TypeSpec decorators** (`@@clientName`, `@@alternateType`, `@@access`) in `client.tsp` to fix the root cause.
- **Generator bug fix** if no decorator or customization can resolve it.

Note: `[CodeGenSuppress]` only takes effect when the custom file exists **before** regeneration. After adding custom files, regenerate so the generator reads and honors the suppression.

**Bad** — manual edit to generated file:
```csharp
// In src/Generated/Models/SomeModel.cs (FORBIDDEN)
public int? StorageUnits  // was: public int StorageUnits
```

**Good** — proper suppression in custom code:
```csharp
// In src/Custom/SomeModel.cs
/// <summary> Backward compat: TypeSpec has int but old SDK had int?. </summary>
[CodeGenSuppress("StorageUnits", typeof(int))]
public partial class SomeModel
{
    public int? StorageUnits { get => ...; set => ...; }
}
```

## Phase 5: TypeSpec Decorator Preference Review

This phase checks whether the PR uses TypeSpec decorators where appropriate instead of SDK customization code. TypeSpec decorators are preferred because they:
- Are more maintainable (fewer files to touch when models change)
- Apply at the spec level (benefit all languages, not just C#)
- Reduce the amount of custom code that must be reviewed and maintained

### Important: Always Use `"csharp"` Scope

When adding decorators to the **spec repo** (`azure-rest-api-specs`), **always include the `"csharp"` scope** parameter. Decorators without a language scope affect all language emitters, which can break other SDKs. C#-specific backward-compatibility decorators must be scoped to `"csharp"` only.

**Bad** — no scope (affects all languages):
```typespec
@@clientName(Redis.list, "GetAllRedis");
@@flattenProperty(Redis.properties);
@@access(SomeModel, Access.public);
```

**Good** — scoped to C# only:
```typespec
@@clientName(Redis.list, "GetAllRedis", "csharp");
@@flattenProperty(Redis.properties, "csharp");
@@access(SomeModel, Access.public, "csharp");
```

### Instructions

1. For each customization file, determine whether the customization could be replaced by a TypeSpec decorator.
2. If a decorator could replace the customization, add a review comment suggesting the decorator approach.
3. When suggesting decorators, **always include the `"csharp"` scope parameter** in the example.

### 5.1 Use `@@flattenProperty` Instead of Wrapper Properties

When the `Properties` envelope property is not flattened and the customization manually wraps each property:

**Bad** — manual property wrapping in customization:
```csharp
[CodeGenSuppress("RedisData", typeof(ResourceIdentifier), typeof(string), ...)]
public partial class RedisData
{
    public string Sku => Properties.Sku;
    public string HostName => Properties.HostName;
    // ... many more wrapper properties
}
```

**Good** — use `@@flattenProperty` in `client.tsp`:
```typespec
@@flattenProperty(Redis.properties, "csharp");
```

### 5.2 Use `@@alternateType` Instead of Manual Type Conversion

When customization code changes a property's type (e.g., `string` → `ResourceIdentifier`, `string` → `AzureLocation`):

**Bad** — custom property + custom serialization:
```csharp
// In Customization/RedisData.cs
public new ResourceIdentifier SubnetId => new ResourceIdentifier(Properties.SubnetId);

// In Customization/RedisData.Serialization.cs
// ... custom serialization to handle the type change
```

**Good** — use `@@alternateType` in `client.tsp`:
```typespec
@@alternateType(Redis.properties.subnetId,
    Azure.ResourceManager.CommonTypes.ArmResourceIdentifier, "csharp");
```

### 5.3 Use `@@markAsPageable` Instead of Custom Pageable Wrappers

When the old SDK returned `Pageable<T>` / `AsyncPageable<T>` but the TypeSpec operation is not pageable:

**Bad** — custom wrapper:
```csharp
[CodeGenSuppress("GetUpgradeNotifications")]
public partial class RedisResource
{
    public virtual Pageable<UpgradeNotification> GetUpgradeNotifications(...)
    {
        return new SinglePagePageable<UpgradeNotification>(...);
    }
}
```

**Good** — use decorator (always with `"csharp"` scope):
```typespec
#suppress "@azure-tools/typespec-azure-core/no-legacy-usage" "migration"
@@markAsPageable(Redis.listUpgradeNotifications, "csharp");
```

### 5.4 Use `@@access` Before `[CodeGenType]` for Accessibility

When a type is generated as `internal` but needs to be `public`:

- **First try** `@@access` in `client.tsp` (spec-side, cleaner)
- **Fall back** to `[CodeGenType]` in custom code only if `@@access` is ineffective (common for nested/wrapper types)

If the PR uses `[CodeGenType]` without evidence that `@@access` was tried first, flag it.

## Output Format

### Posting Inline Review Comments

All findings **must** be posted as inline review comments directly on the PR using the GitHub API. Use the `gh api` CLI or GitHub MCP tools to create a pull request review with inline comments:

```
POST /repos/{owner}/{repo}/pulls/{pull_number}/reviews
{
  "event": "COMMENT",
  "body": "<summary of findings>",
  "comments": [
    { "path": "file.cs", "line": <line_number>, "body": "**[rule_id]** <comment>" }
  ]
}
```

Each inline comment should:
- Start with the rule ID in bold (e.g., `**[4.1]**`, `**[5.2]**`)
- Explain the specific violation
- Suggest the fix or improvement

The review body should include an overall summary with pass/fail per phase and counts of issues found.

### Report Structure

1. **Report Phase 1–3 results** (from base skill)
2. **Report Phase 4 results** (Migration Customization Review):
   - Post inline comments on each customization issue at the relevant file and line
   - Group findings by category (4.1–4.10)
3. **Report Phase 5 results** (TypeSpec Decorator Preference):
   - Post inline comments where a TypeSpec decorator could replace customization code
4. **Final summary** with counts: critical issues, should-fix issues, suggestions
