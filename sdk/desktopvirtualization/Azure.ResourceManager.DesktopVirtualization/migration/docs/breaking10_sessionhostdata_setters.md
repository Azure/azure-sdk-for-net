# Breaking #10: SessionHostData Property Setters Removed

## What Broke

8 properties on `SessionHostData` lost their setters:

| Property | Old (main) | New (this branch) |
|---|---|---|
| `AgentVersion` | `{ get; set; }` | `{ get; }` |
| `LastHeartBeatOn` | `{ get; set; }` | `{ get; }` |
| `OSVersion` | `{ get; set; }` | `{ get; }` |
| `Sessions` | `{ get; set; }` | `{ get; }` |
| `Status` | `{ get; set; }` | `{ get; }` |
| `SxsStackVersion` | `{ get; set; }` | `{ get; }` |
| `UpdateErrorMessage` | `{ get; set; }` | `{ get; }` |
| `UpdateState` | `{ get; set; }` | `{ get; }` |

3 other properties (`AllowNewSession`, `AssignedUser`, `FriendlyName`) **kept** their setters and are not affected.

---

## Why It Happens — The Chain of Causality

### 1. The old Swagger/AutoRest world (the `main` branch)

AutoRest didn't have a concept of per-property read/write visibility. When it generated `SessionHostData`, **every** property on the model got a setter — even server-only fields like `AgentVersion` or `Status`. This was technically wrong (you'd never set `AgentVersion` on a session host you're creating — the server populates it), but it was the generated public API that customers depend on.

### 2. The new TypeSpec definition

In the TSP source at `TempTypeSpecFiles/DesktopVirtualization/models.tsp`, the `SessionHostProperties` model correctly annotates each server-populated property with `@visibility(Lifecycle.Read)`:

```tsp
model SessionHostProperties {
  @visibility(Lifecycle.Read) agentVersion?: string;
  @visibility(Lifecycle.Read) lastHeartBeat?: utcDateTime;
  @visibility(Lifecycle.Read) osVersion?: string;
  @visibility(Lifecycle.Read) sessions?: int32;
  @visibility(Lifecycle.Read) status?: Status;
  @visibility(Lifecycle.Read) sxSStackVersion?: string;
  @visibility(Lifecycle.Read) updateErrorMessage?: string;
  @visibility(Lifecycle.Read) updateState?: UpdateState;

  // These three have NO visibility constraint → read-write:
  allowNewSession?: boolean;
  assignedUser?: string;
  friendlyName?: string;
}
```

`@visibility(Lifecycle.Read)` means "this property only appears in responses (output), not in requests (input)."

### 3. The `@@usage` decorator in client.tsp

In `TempTypeSpecFiles/DesktopVirtualization/client.tsp`:

```tsp
@@usage(SessionHostProperties, Usage.input, "csharp");
```

This marks `SessionHostProperties` as usable for **input** in C#. This is what gives `SessionHostData` its **public constructor** (without this, the class would have only an `internal` ctor and be output-only). However, this decorator operates at the **model level** — it doesn't override per-property `@visibility` annotations.

### 4. How the C# generator resolves this

The TypeSpec C# emitter does the following:

1. `@@usage(SessionHostProperties, Usage.input)` → make the model's constructor `public` and generate it as a writable data class.
2. **For each property**, check its `@visibility`:
   - No visibility constraint → generate `{ get; set; }` (writable)
   - `@visibility(Lifecycle.Read)` → generate `{ get; }` (read-only), **even on an input model**

This is correct semantics: the model can be used as input, but only the genuinely writable fields (`allowNewSession`, `assignedUser`, `friendlyName`) get setters. The server-populated fields are read-only.

### 5. The flattening layer adds no setters

`SessionHostData` (the public surface) wraps the `internal SessionHostProperties` class. Each property on `SessionHostData` delegates to `Properties.XYZ`. The generator only emits a setter on `SessionHostData` if the underlying `SessionHostProperties` property has a setter. Since 8 properties on `SessionHostProperties` are `{ get; }` only, the corresponding 8 on `SessionHostData` are also `{ get; }` only.

---

## Visual Summary of the Data Flow

```
TSP model definition
  @visibility(Lifecycle.Read) agentVersion   ──┐
  @visibility(Lifecycle.Read) sessions       ──┤ Read-only in TSP
  allowNewSession (no constraint)            ──┤ Read-write in TSP
                                               │
@@usage(SessionHostProperties, Usage.input)    │ Model-level: public ctor ✓
                                               │ Does NOT override per-property visibility
                                               ▼
C# generator emits:
  internal class SessionHostProperties
    AgentVersion { get; }        ← no setter (Lifecycle.Read)
    Sessions { get; }            ← no setter (Lifecycle.Read)
    AllowNewSession { get; set; } ← setter (no visibility constraint)
                                               ▼
  public class SessionHostData
    AgentVersion { get; }        ← delegates to Properties, no setter
    Sessions { get; }            ← delegates to Properties, no setter
    AllowNewSession { get; set; } ← delegates to Properties, has setter


Old AutoRest:  ALL properties got { get; set; } (bug — no visibility concept)
New TypeSpec:  Only 3 properties get { get; set; } (correct — visibility-aware)

Result: 8 properties lost their setters → breaking change
```

---

## Why `@@usage(Input)` Isn't Enough

A common misconception: "`@@usage(Input)` should make everything writable." It doesn't. The usage decorator controls **model-level** behavior (public ctor, inclusion in request bodies). The `@visibility(Lifecycle.Read)` on individual properties is a stronger, more specific constraint — it says "this property is never sent by the client" — and the generator respects that even on input-capable models.

There's no TSP-side fix for this without removing the `@visibility(Lifecycle.Read)` annotations, which would be semantically incorrect (these are genuinely server-populated fields). The fix needs to be an SDK-side shim with `[EditorBrowsable(Never)]` setters in a `src/Customize/SessionHostData.cs` partial class.
