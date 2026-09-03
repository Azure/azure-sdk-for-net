# Create analyzers with workflow settings

> **Supported service API version:** `2026-06-01-preview`

This sample shows how to create custom analyzers using `ContentAnalyzerConfig.Workflow`. Omit `Workflow` (or set `ContentAnalyzerWorkflow.Default`) for standard extraction, or set `ContentAnalyzerWorkflow.Agentic` when an answer must be built from evidence across the document. The sample analyzes the same 20-item invoice with each workflow so you can compare results.

> **Analysis considerations:** Analysis supports **one input file per request** regardless of service API version or workflow. Agentic mode uses the **advanced contextualization** rate and typically takes longer and consumes more model tokens than the default workflow.

## Prerequisites

To get started you'll need a **Microsoft Foundry resource**. See [Sample 00: Configure model deployment defaults][sample00] for setup guidance.

## Define a shared invoice schema

Both analyzers use the same schema so the workflow is the only variable in the comparison. `InvoiceId` is a direct field, while `AverageItemPrice` is a derived field used to highlight workflow differences.

```C# Snippet:ContentUnderstandingCreateAnalyzerWorkflowSchema
var fieldSchema = new ContentFieldSchema(
    new Dictionary<string, ContentFieldDefinition>
    {
        ["InvoiceId"] = new ContentFieldDefinition
        {
            Type = ContentFieldType.String,
            Description = "Invoice identifier printed on the invoice. Return only the identifier value without its label."
        },
        ["AverageItemPrice"] = new ContentFieldDefinition
        {
            Type = ContentFieldType.Number,
            Description = "Calculate the arithmetic mean of all values in the UNIT PRICE column. Use only unit prices, not quantities, line amounts, subtotals, taxes, or totals."
        }
    })
{
    Name = "invoice_workflow_comparison",
    Description = "Invoice fields used to compare default and agentic workflows"
};
```

## Create analyzer with default workflow

`ContentAnalyzerWorkflow.Default` is selected when you omit `Workflow`. You can also set it explicitly:

```C# Snippet:ContentUnderstandingCreateAnalyzerWithDefaultWorkflow
var defaultWorkflowAnalyzer = new ContentAnalyzer
{
    BaseAnalyzerId = "prebuilt-document",
    Description = "Analyzer using default workflow",
    FieldSchema = fieldSchema,
    Config = new ContentAnalyzerConfig
    {
        ShouldReturnDetails = true
        // Workflow = ContentAnalyzerWorkflow.Default
    }
};
defaultWorkflowAnalyzer.Models["completion"] = "gpt-5.2";

Operation<ContentAnalyzer> defaultCreateOperation = await client.CreateAnalyzerAsync(
    WaitUntil.Completed,
    defaultAnalyzerId,
    defaultWorkflowAnalyzer);
```

## Create analyzer with agentic workflow

Set `ContentAnalyzerConfig.Workflow` to `ContentAnalyzerWorkflow.Agentic` when the answer must be built from evidence:

```C# Snippet:ContentUnderstandingCreateAnalyzerWithAgenticWorkflow
var agenticWorkflowAnalyzer = new ContentAnalyzer
{
    BaseAnalyzerId = "prebuilt-document",
    Description = "Analyzer using agentic workflow",
    FieldSchema = fieldSchema,
    Config = new ContentAnalyzerConfig
    {
        ShouldReturnDetails = true,
        Workflow = ContentAnalyzerWorkflow.Agentic
    }
};
agenticWorkflowAnalyzer.Models["completion"] = "gpt-5.2";

Operation<ContentAnalyzer> agenticCreateOperation = await client.CreateAnalyzerAsync(
    WaitUntil.Completed,
    agenticAnalyzerId,
    agenticWorkflowAnalyzer);
```

## Why use agentic workflow?

For straightforward field extraction, use the default workflow. Use agentic mode when an answer must be **built from evidence** instead of extracted from a single location — for example multistep reasoning, calculations, validation, or analysis of complex tables and figures.

In this sample, `InvoiceId` is a direct value that both workflows can extract. `AverageItemPrice` requires collecting many unit prices and calculating their mean, so it benefits from agentic reasoning. Agentic mode uses the **advanced contextualization** rate and typically consumes more model tokens and takes longer than the default workflow.

## Analyze with both workflows

Analyze the same local invoice PDF with both analyzers, then read the typed field values:

```C# Snippet:ContentUnderstandingCompareAnalyzerWorkflows
string invoicePath = "<localInvoiceFilePath>";
BinaryData invoiceData = BinaryData.FromBytes(File.ReadAllBytes(invoicePath));

Operation<AnalysisResult> defaultAnalysis = await client.AnalyzeBinaryAsync(
    WaitUntil.Completed,
    defaultAnalyzerId,
    invoiceData);
Operation<AnalysisResult> agenticAnalysis = await client.AnalyzeBinaryAsync(
    WaitUntil.Completed,
    agenticAnalyzerId,
    invoiceData);

DocumentContent defaultContent = (DocumentContent)defaultAnalysis.Value.Contents!.First();
DocumentContent agenticContent = (DocumentContent)agenticAnalysis.Value.Contents!.First();

string? defaultInvoiceId = (defaultContent.Fields["InvoiceId"] as ContentStringField)?.Value;
double? defaultAverageItemPrice = (defaultContent.Fields["AverageItemPrice"] as ContentNumberField)?.Value;
string? agenticInvoiceId = (agenticContent.Fields["InvoiceId"] as ContentStringField)?.Value;
double? agenticAverageItemPrice = (agenticContent.Fields["AverageItemPrice"] as ContentNumberField)?.Value;

Console.WriteLine($"Default workflow: InvoiceId={defaultInvoiceId}, AverageItemPrice={defaultAverageItemPrice}");
Console.WriteLine($"Agentic workflow: InvoiceId={agenticInvoiceId}, AverageItemPrice={agenticAverageItemPrice}");
```

Both workflows extract invoice ID `INV-2048`. The default workflow can approximate the derived average, and its result can vary between runs. The agentic workflow uses reasoning and calculation to return the expected average item price of `20.5` accurately.

## Next steps

- [Sample 04: Create a custom analyzer][sample04]
- [Sample 17: Analyze with semantic chunking][sample17]

[sample00]: https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/contentunderstanding/Azure.AI.ContentUnderstanding/samples/Sample00_UpdateDefaults.md
[sample04]: https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/contentunderstanding/Azure.AI.ContentUnderstanding/samples/Sample04_CreateAnalyzer.md
[sample17]: https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/contentunderstanding/Azure.AI.ContentUnderstanding/samples/Sample17_AnalyzeChunking.md
