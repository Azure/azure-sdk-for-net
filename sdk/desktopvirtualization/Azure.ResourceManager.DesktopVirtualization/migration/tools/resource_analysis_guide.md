# Resource Analysis Scripts

This document describes how to use the resource analysis scripts to analyze generated Azure Resource Manager SDK resources.

## Prerequisites

- Python 3.9+
- Generated SDK code in `src/Generated/` directory
- `tspCodeModel.json` file in the workspace root

## Scripts Overview

| Script | Purpose | Output |
|--------|---------|--------|
| `extract.py` | Extract `@armProviderSchema` decorator from tspCodeModel.json | `resourceSchema.json` |
| `match_resources.py` | Match generated resource classes with schema resources | `matchresult.txt` |
| `analyze_generated_resource.py` | Analyze resources and sort by resource ID length | `analyze_result.txt` |

## Usage

### Step 1: Extract Resource Schema

First, extract the `@armProviderSchema` decorator from `tspCodeModel.json`:

```bash
python3 extract.py
```

This creates `resourceSchema.json` containing all resource definitions including:
- Resource model IDs
- Resource ID patterns
- Resource types
- Methods (Create, Read, Delete, List, Action)

**Optional arguments:**
```bash
python3 extract.py [input_file] [output_file]
# Default: python3 extract.py tspCodeModel.json resourceSchema.json
```

### Step 2: Match Resources

Compare generated resource classes with the schema definitions:

```bash
python3 match_resources.py
```

This produces `matchresult.txt` showing:
- Matched resources (class pattern vs schema pattern)
- Unmatched classes (generated but not in schema)
- Unmatched schema resources (in schema but no generated class)

### Step 3: Analyze Generated Resources

Perform a comprehensive analysis of generated resources:

```bash
python3 analyze_generated_resource.py
```

This produces `analyze_result.txt` containing:
1. **Detailed analysis** of each resource class with match status
2. **Summary** of matched/unmatched counts
3. **Sorted list** of all resource IDs (shortest to longest)

## Example Workflow

```bash
# Navigate to the SDK directory
cd sdk/providerhub/Azure.ResourceManager.ProviderHub

# Step 1: Extract schema
python3 extract.py

# Step 2: Match resources (optional, for detailed matching info)
python3 match_resources.py

# Step 3: Analyze and sort resources
python3 analyze_generated_resource.py

# View results
cat analyze_result.txt
```

## Output Files

### resourceSchema.json

Contains the extracted `@armProviderSchema` decorator with all resource definitions:

```json
{
  "name": "Azure.ClientGenerator.Core.@armProviderSchema",
  "arguments": {
    "resources": [
      {
        "resourceModelId": "Microsoft.ProviderHub.CustomRollout",
        "resourceIdPattern": "/subscriptions/{subscriptionId}/providers/...",
        "resourceType": "Microsoft.ProviderHub/providerRegistrations/customRollouts",
        "methods": [...],
        "resourceName": "CustomRollout"
      }
    ]
  }
}
```

### matchresult.txt

Shows matching results between generated classes and schema:

```
================================================================================
MATCHES
================================================================================

CustomRolloutResource
  Class Pattern:  /subscriptions/{subscriptionId}/providers/...
  Schema Pattern: /subscriptions/{subscriptionId}/providers/...
  Schema Model:   Microsoft.ProviderHub.CustomRollout
  Resource Name:  CustomRollout
```

### analyze_result.txt

Contains detailed analysis and sorted resource IDs:

```
================================================================================
RESOURCE IDs (sorted by length, shortest to longest)
================================================================================
 1. [✓] ProviderRegistrationResource
    /subscriptions/{subscriptionId}/providers/Microsoft.ProviderHub/providerRegistrations/{providerNamespace}
 2. [✓] CustomRolloutResource
    /subscriptions/{subscriptionId}/providers/Microsoft.ProviderHub/providerRegistrations/{providerNamespace}/customRollouts/{rolloutName}
...
```

## How Matching Works

The scripts normalize resource ID patterns by replacing all `{parameterName}` placeholders with `{*}` for comparison. This allows matching patterns like:

- Class: `/subscriptions/{subscriptionId}/providers/.../customRollouts/{rolloutName}`
- Schema: `/subscriptions/{subscriptionId}/providers/.../customRollouts/{rolloutName}`

Both normalize to: `/subscriptions/{*}/providers/.../customRollouts/{*}`

## Troubleshooting

| Issue | Solution |
|-------|----------|
| `resourceSchema.json not found` | Run `extract.py` first |
| `src/Generated not found` | Ensure SDK code is generated |
| No matches found | Check if resource ID patterns match between generated code and schema |
