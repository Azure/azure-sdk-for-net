# Sample 16: Create Analyzer with Labeled Training Data

This sample demonstrates how to create custom analyzers using labeled training data from Azure Blob Storage.

## Overview

Labeled training data allows you to train custom analyzers on annotated sample documents. This is useful when you need domain-specific field extraction beyond what prebuilt analyzers provide.

For an easier labeling workflow, use **Azure AI Content Understanding Studio** at https://contentunderstanding.ai.azure.com/.

## Prerequisites

- An Azure Content Understanding resource
- Required models deployed: `gpt-4.1`, `text-embedding-3-large`
- (Optional) An Azure Blob Storage container with labeled training data

### Preparing labeled training data

Labeled receipt data is available in this repo at `tests/samples/sample_files/receipt_labels/`. To use real training data in LIVE mode:

1. Upload the `receipt_labels/` folder contents to an Azure Blob Storage container
2. Generate a container SAS URL with **List** and **Read** permissions
3. Set the environment variables below

### Environment variables

| Variable | Required | Description |
|---|---|---|
| `CONTENTUNDERSTANDING_ENDPOINT` | Yes | Azure Content Understanding endpoint URL |
| `CONTENTUNDERSTANDING_TRAINING_DATA_SAS_URL` | No | SAS URL for the Azure Blob container with labeled training data (Option A) |
| `CONTENTUNDERSTANDING_TRAINING_DATA_STORAGE_ACCOUNT` | No | Storage account name for auto-generating a SAS URL via User Delegation Key (Option B) |
| `CONTENTUNDERSTANDING_TRAINING_DATA_CONTAINER` | No | Container name, used together with storage account name (Option B) |
| `CONTENTUNDERSTANDING_TRAINING_DATA_PREFIX` | No | Path prefix within the container (e.g., `"receipt_labels/"`). Omit if files are at the container root |

> **Tip:** If `CONTENTUNDERSTANDING_TRAINING_DATA_SAS_URL` is not set but both `CONTENTUNDERSTANDING_TRAINING_DATA_STORAGE_ACCOUNT`
> and `CONTENTUNDERSTANDING_TRAINING_DATA_CONTAINER` are provided, the sample auto-generates a User Delegation SAS URL
> via `DefaultAzureCredential`. This avoids the need to manually create SAS tokens.

### Training data file structure

Each training document requires three files:
- `document.jpg` — The source document image
- `document.jpg.labels.json` — Field labels and annotations
- `document.jpg.result.json` — Pre-computed OCR results

## Example

### Create the analyzer

```C# Snippet:ContentUnderstandingCreateAnalyzerWithLabels
```

### Helper: Build receipt field schema

```C# Snippet:ContentUnderstandingBuildReceiptFieldSchema
```

### Helper: Generate User Delegation SAS URL

```C# Snippet:ContentUnderstandingGenerateUserDelegationSas
```

### Clean up

```C# Snippet:ContentUnderstandingDeleteAnalyzerWithLabels
```
