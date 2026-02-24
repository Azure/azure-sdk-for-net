# How to Show Deleted Models (Manual Steps)

This describes how to identify which model classes were deleted between the baseline SDK and the current generated code, without using `migdiff.py`.

## Prerequisites

- You are in a `migration/` folder that contains an `info.txt` file.
- `info.txt` provides the following values:
  - **baseline commit id** — the commit to compare against.
  - **sdk path** — the absolute path to the SDK package.
  - **spec path** — the absolute path to the TypeSpec/Swagger specification.

Example `info.txt`:

```
spec path: /home/codespace/code/spec/specification/desktopvirtualization/resource-manager/Microsoft.DesktopVirtualization/DesktopVirtualization
sdk  path: /home/codespace/code/sdk/sdk/desktopvirtualization/Azure.ResourceManager.DesktopVirtualization
baseline commit id: b75a865e39f82ce1ac442ce7a9d040d45862ec5a
```

Extract the values, set shell variables, and `cd` to the SDK path:

```bash
BASELINE_COMMIT=$(grep 'baseline commit id:' info.txt | cut -d: -f2 | tr -d ' ')
SDK_PATH=$(grep 'sdk.*path:' info.txt | cut -d: -f2 | tr -d ' ')
MODELS_PATH=src/Generated/Models
# Change to the SDK path so git and find resolve the relative path
cd "$SDK_PATH"
```

## Step 1 - List model classes in the baseline

```bash
git ls-tree -r --name-only "$BASELINE_COMMIT" "$MODELS_PATH/" \
  | grep '\.cs$' | grep -v '\.Serialization\.cs$' \
  | sed "s#^$MODELS_PATH/##" | sort > /tmp/baseline_models.txt
```

## Step 2 - List model classes in the current code

```bash
find "$MODELS_PATH/" -type f -name '*.cs' \
  | grep -v '\.Serialization\.cs$' \
  | sed "s#^$MODELS_PATH/##" | sort > /tmp/current_models.txt
```

## Step 3 - Show deleted models

Use `comm` to find lines only in the baseline (i.e. deleted):

```bash
comm -23 /tmp/baseline_models.txt /tmp/current_models.txt
```

## (Optional) Show newly added models

```bash
comm -13 /tmp/baseline_models.txt /tmp/current_models.txt
```

## One-liner

Combine everything into a single command (after setting the variables above):

```bash
comm -23 \
  <(git ls-tree -r --name-only "$BASELINE_COMMIT" "$MODELS_PATH/" \
    | grep '\.cs$' | grep -v '\.Serialization\.cs$' | sed "s#^$MODELS_PATH/##" | sort) \
  <(find "$MODELS_PATH/" -type f -name '*.cs' \
    | grep -v '\.Serialization\.cs$' | sed "s#^$MODELS_PATH/##" | sort)
```