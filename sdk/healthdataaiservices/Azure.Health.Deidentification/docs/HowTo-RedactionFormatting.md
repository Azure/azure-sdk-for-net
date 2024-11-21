# Redaction Format Guide

## Prerequisites

1. Pass `RedactionFormat` to the API or Job parameters.
2. Must select `Redact` as `Operation` as well.
3. RedactionFormat supports up to 16 characters.

## Variables

Only supports a single instance of each variable type

### Type

`{type} => patient`

```text
    "inputText": "Hi my name is John Smith"
    "operation": "Redact",
    "redactionFormat": "<{type}>",

    # Output:
    Hi my name is <patient>
```

Also supports Upper and Title cases

```text
    {Type} => {Patient}
    {TYPE} => {PATIENT}
```

### Length

`*{len} => ******(length of entity)`

This will allow you to create a string matching the length of the PHI

```text
    "inputText": "Hi my name is John Smith"
    "operation": "Redact",
    "redactionFormat": "*{len}",

    # Output:
    Hi my name is **********
```
