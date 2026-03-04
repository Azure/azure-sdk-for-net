# API Analysis: `<BASELINE_VERSION>` → `<NEW_VERSION>`

## Summary

- **Spec PR**: https://github.com/Azure/azure-rest-api-specs/pull/<PR_NUMBER>
- **Spec PR Latest Full Commit Hash**: Commit SHA
- **Tag**: `<TAG_NAME>`
- **Track**: preview | stable
- **Baseline version**: `<BASELINE_VERSION>`
- **Breaking Changes**: X
- **New Features**: Y

---

## Breaking Changes

| Item | Kind | Before | After | Action |
|------|------|--------|-------|--------|
| `ExampleType` | Enum renamed | `OldName` | `NewName` | Add obsolete stub |
| `ExampleProp` | Property removed | `string` | — | Add obsolete backward-compat property |

---

## New Features

| Item | Description |
|------|-------------|
| `NewProperty` | Added to `SearchServiceData`. Nullable. |
| `NewSku` | New value on `SearchServiceSkuName`. |

---

## Recommended Customizations

### Renames — add to `autorest.md`

```yaml
rename-mapping:
  OldTypeName: NewTypeName
```

### Removed types — add obsolete stub in `src/Customization/Models/`

```csharp
[Obsolete("Use NewTypeName instead.")]
[EditorBrowsable(EditorBrowsableState.Never)]
public readonly partial struct OldTypeName : IEquatable<OldTypeName> { }
```

### Changed properties — add to partial class in `src/Customization/`

```csharp
public partial class AffectedModel
{
    [Obsolete("Use NewProperty instead.")]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public OldType OldProperty => /* map from NewProperty */;
}
```

---

## Notes for Spec Authors

- List any inconsistencies or issues worth raising with the spec team.
