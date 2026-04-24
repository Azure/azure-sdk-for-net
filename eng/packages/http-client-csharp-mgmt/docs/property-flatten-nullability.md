# Property Flatten — Nullability and Setter Behavior

When the management generator flattens a wrapper model (typically `properties`) onto its parent, it has to decide:

1. What type the flattened public property should have.
2. How its setter behaves when the caller passes `null`.
3. How its getter behaves when the wrapper is absent.
4. What types appear in the public constructor and model factory.

This document describes those rules. The behavior is implemented in `FlattenPropertyVisitor` (and its helpers in `PropertyHelpers`); see those types for the source of truth.

## Terminology

Throughout this document the following names refer to the same three things:

- **Parent** — the model on which the flattened public property is exposed (the `Foo` in the examples below).
- **Wrapper** — the original wrapping model that was flattened (the `FooProperties` in the examples). After flattening it is no longer publicly exposed; it becomes an **internal property on the parent** which is referred to in code snippets as `InternalWrapper`.
- **Inner property / leaf** — a property on the wrapper that is surfaced as a public property on the parent (the `Count` / `Name` in the examples).

Two flatten variants exist and follow the same rules:

| Variant | Trigger |
| --- | --- |
| **Property flatten** | The wrapper has a single inner property; the wrapper is fully replaced by it. |
| **Safe flatten** | The wrapper has multiple inner properties; selected ones are surfaced on the parent. |

---

## 1. When is the flattened public property `T?`?

**A flattened property is lifted to `Nullable<T>` / nullable reference iff the wrapping parent (e.g. `properties?:`) may be absent at runtime.** That is, when the wrapper is either declared nullable or declared optional (not required) on the wire.

This rule applies symmetrically to value types and reference types:

- Required, non-nullable wrapper → the public flattened property keeps the **inner property's original type**. A required `int` inner stays `int`; a required `string` stays `string`.
- Optional / nullable wrapper → the public flattened property is **lifted**. A required `int` inner becomes `int?`; a required `string` becomes a nullable reference. Inners that are already nullable are unaffected (`T?` stays `T?`).

> The inner leaf's own required/optional status does **not** affect the lift decision. If the parent is absent, every inner leaf is unobservable, so each must be able to express that absence to callers.

---

## 2. Getter behavior

- **Wrapper may be absent, scalar inner** — returns `default` when the wrapper is null, otherwise returns the inner value.
- **Required wrapper, collection inner** — the wrapper is lazily created on first read (when it has a setter) so the returned collection is never `null`. This avoids NREs during serialization of a required collection.
- **Wrapper guaranteed present, scalar inner** — returns the inner value directly with no null guard.

---

## 3. Setter behavior

Setters are emitted only when both the wrapper and the inner property had a setter, and never for collections (collections expose mutability through the returned list).

For non-collection inners the canonical pattern is **lazy-create the wrapper, then assign the leaf**:

```csharp
set
{
    if (InternalWrapper is null)
    {
        InternalWrapper = new Wrapper();
    }
    InternalWrapper.Foo = value;
}
```

This preserves the historical AutoRest semantic: writing one flattened leaf instantiates the wrapper if needed and leaves any **sibling** leaves on the same wrapper untouched.

### What `null` means

The interesting case is when the inner leaf is a non-nullable value type but the public property has been lifted to `T?` (because the wrapper may be absent). Behavior on `set value = null`:

- **Property flatten** — **no-op**. We refuse to silently erase the leaf to `default(T)`, and there is no way to "remove just this leaf" from a wrapper that may have other state.
- **Safe flatten, wrapper has a parameterless constructor** — **no-op**, same reasoning as property flatten.
- **Safe flatten, wrapper has no parameterless constructor** (the lifted leaf is the wrapper's only required ctor arg) — **the wrapper is set to `null`**. There is no other state on the wrapper to preserve, so `null` is interpreted as "erase the wrapper".

For inners that are already nullable (`T?`) or are reference types, the public type matches the inner type exactly and `null` is passed through to the inner property as a meaningful leaf value.

### Quick reference

| Inner leaf type | Wrapper required? | Public type | Setter on `null` |
| --- | --- | --- | --- |
| `T` (non-nullable value type) | required, non-nullable | `T` | (no `null` possible) |
| `T` (non-nullable value type) | optional / nullable | `T?` | **No-op** |
| `T` (non-nullable value type) | optional / nullable, no parameterless wrapper ctor | `T?` | **Wrapper set to `null`** |
| `T?` (already-nullable value type) | any | `T?` | Pass through; inner becomes `null` |
| Reference type | any | reference type | Pass through; inner becomes `null` |
| Collection | any | collection | **No setter generated** — mutate through getter |

---

## 4. Constructor and model-factory parameters

- **Public constructor parameter for a required leaf** — kept as the inner property's **original (non-nullable) type**. The wrapper is required, so the leaf is never observably absent at construction time, and accepting `Nullable<T>` here would be a footgun.
- **Public constructor parameter for an optional leaf** — lifted to nullable, defaults to `null`. Omitted leaves leave the wrapper unset.
- **Internal "all properties" constructor and the model factory entry** — every flattened leaf is lifted to nullable with a `null` default, purely as a convenience for mocking.

---

## 5. Examples

### 5.1 Required wrapper, required value-type leaf — no lift

```tsp
model Foo {
  properties: FooProperties;          // required wrapper
}
model FooProperties {
  count: int32;                       // required leaf
}
```

```csharp
public int Count
{
    get => InternalWrapper.Count;
    set
    {
        if (InternalWrapper is null)
        {
            InternalWrapper = new FooProperties();
        }
        InternalWrapper.Count = value;
    }
}
```

### 5.2 Optional wrapper, required value-type leaf — lifted, setter no-ops on null

```tsp
model Foo {
  properties?: FooProperties;         // optional wrapper
}
model FooProperties {
  count: int32;                       // required leaf
}
```

```csharp
public int? Count
{
    get => InternalWrapper is null ? default : InternalWrapper.Count;
    set
    {
        if (value.HasValue)
        {
            if (InternalWrapper is null)
            {
                InternalWrapper = new FooProperties();
            }
            InternalWrapper.Count = value.Value;
        }
    }
}
```

Setting `Count = null` does **not** clear sibling leaves on `InternalWrapper` and does **not** reset `Count` to `0`; it is silently ignored.

### 5.3 Optional wrapper whose only required ctor arg is the lifted leaf — null erases the wrapper

```csharp
public int? Count
{
    get => InternalWrapper is null ? default : InternalWrapper.Count;
    set => InternalWrapper = value.HasValue ? new FooProperties(value.Value) : null;
}
```

### 5.4 Optional wrapper, nullable reference leaf — pass-through

```csharp
public string Name
{
    get => InternalWrapper is null ? default : InternalWrapper.Name;
    set
    {
        if (InternalWrapper is null)
        {
            InternalWrapper = new FooProperties();
        }
        InternalWrapper.Name = value; // null is a valid leaf value
    }
}
```

---

## 6. Design rationale

- **Lift decision keyed on the wrapper, not the leaf.** The wrapper's presence is the only source of optionality the flatten introduces. A leaf cannot be "more required" than its parent.
- **Symmetry between value types and reference types.** Both surface the wrapper's optionality the same way — value types via `Nullable<T>`, reference types via nullable references — so callers see a uniform contract.
- **Null on a lifted value-type setter is conservative by default.** Erasing a leaf to `default(T)` would silently corrupt user data and is indistinguishable from "I want to clear this" without a wider API. The no-op fallback preserves prior values; the only exception is the safe-flatten case where the wrapper has no other state to preserve, in which case `null` cleanly removes the wrapper.
- **Constructor parameter types do not lift for required leaves.** A required leaf passed to a public constructor cannot have been "absent on the wire", so requiring `Nullable<T>` there would be a footgun.
