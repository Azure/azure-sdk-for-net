# Analyze with semantic chunking

> **Supported service API version:** `2026-06-01-preview`

This sample shows how to configure `SemanticChunkingStrategy` on a custom analyzer and read chunks from analysis results. The walkthrough uses the SDK sample file `sample_invoice.pdf` (under `tests/samples/SampleFiles/`).

## Prerequisites

To get started you'll need a **Microsoft Foundry resource**. See [Sample 00: Configure model deployment defaults][sample00] for setup guidance.

## Create analyzer with semantic chunking

```C# Snippet:ContentUnderstandingCreateAnalyzerWithSemanticChunking
var analyzer = new ContentAnalyzer
{
    BaseAnalyzerId = "prebuilt-document",
    Description = "Analyzer with semantic chunking",
    Config = new ContentAnalyzerConfig
    {
        ShouldReturnDetails = true,
        EnableLayout = true,
        ChunkingStrategy = new SemanticChunkingStrategy
        {
            MaxTokens = 300
        }
    }
};
string completionModel = "<completion-model-name>";
analyzer.Models["completion"] = completionModel;

await client.CreateAnalyzerAsync(
    WaitUntil.Completed,
    analyzerId,
    analyzer,
    allowReplace: true);
```

## Analyze with semantic chunking enabled

```C# Snippet:ContentUnderstandingAnalyzeWithSemanticChunking
// Use the SDK sample invoice shipped under tests/samples/SampleFiles/
string filePath = "sample_invoice.pdf";
BinaryData binaryData = BinaryData.FromBytes(File.ReadAllBytes(filePath));
Operation<AnalysisResult> operation = await client.AnalyzeBinaryAsync(
    WaitUntil.Completed,
    analyzerId,
    binaryData);

AnalysisResult result = operation.Value;
DocumentContent documentContent = (DocumentContent)result.Contents!.First();
```

## Read semantic chunks

```C# Snippet:ContentUnderstandingReadSemanticChunks
string[] chunkMarkdowns = (documentContent.Chunks ?? Enumerable.Empty<DocumentChunk>())
    .Select(chunk => string.Join(
        Environment.NewLine,
        chunk.Spans.Select(span => documentContent.Markdown.Substring(span.Offset, span.Length))))
    .ToArray();

Console.WriteLine($"Chunk count: {chunkMarkdowns.Length}");
for (int index = 0; index < chunkMarkdowns.Length; index++)
{
    Console.WriteLine($"--- Chunk {index + 1} ---");
    Console.WriteLine(chunkMarkdowns[index]);
}
```

Example output from `sample_invoice.pdf` (`MaxTokens = 300`):

```text
Chunk count: 3
--- Chunk 1 ---
CONTOSO LTD.


# INVOICE

Contoso Headquarters
123 456th St
New York, NY, 10001

INVOICE: INV-100

INVOICE DATE: 11/15/2019

DUE DATE: 12/15/2019

CUSTOMER NAME: MICROSOFT CORPORATION

SERVICE PERIOD: 10/14/2019 - 11/14/2019

CUSTOMER ID: CID-12345

Microsoft Corp
123 Other St,
Redmond WA, 98052

BILL TO:
Microsoft Finance
123 Bill St,
Redmond WA, 98052

SHIP TO:
Microsoft Delivery
123 Ship St,
Redmond WA, 98052

SERVICE ADDRESS:
Microsoft Services
123 Service St,
Redmond WA, 98052
<table>
<tr>
<th>SALESPERSON</th>
<th>P.O. NUMBER</th>
<th>REQUISITIONER</th>
<th>SHIPPED VIA</th>
<th>F.O.B. POINT</th>
<th>TERMS</th>
</tr>
<tr>
<td></td>
<td>PO-3333</td>
<td></td>
<td></td>
<td></td>
<td></td>
</tr>
</table>
--- Chunk 2 ---
<table>
<tr>
<th>DATE</th>
<th>ITEM CODE</th>
<th>DESCRIPTION</th>
<th>QTY</th>
<th>UM</th>
<th>PRICE</th>
<th>TAX</th>
<th>AMOUNT</th>
</tr>
<tr>
<td>3/4/2021</td>
<td>A123</td>
<td>Consulting Services</td>
<td>2</td>
<td>hours</td>
<td>$30.00</td>
<td>$6.00</td>
<td>$60.00</td>
</tr>
<tr>
<td>3/5/2021</td>
<td>B456</td>
<td>Document Fee</td>
<td>3</td>
<td></td>
<td>$10.00</td>
<td>$3.00</td>
<td>$30.00</td>
</tr>
<tr>
<td>3/6/2021</td>
<td>C789</td>
<td>Printing Fee</td>
<td>10</td>
<td>pages</td>
<td>$1.00</td>
<td>$1.00</td>
<td>$10.00</td>
</tr>
</table>
--- Chunk 3 ---
<table>
<tr>
<td>SUBTOTAL</td>
<td>$100.00</td>
</tr>
<tr>
<td>SALES TAX</td>
<td>$10.00</td>
</tr>
<tr>
<td>TOTAL</td>
<td>$110.00</td>
</tr>
<tr>
<td>PREVIOUS UNPAID BALANCE</td>
<td>$500.00</td>
</tr>
<tr>
<td>AMOUNT DUE</td>
<td>$610.00</td>
</tr>
</table>
THANK YOU FOR YOUR BUSINESS!

REMIT TO:
Contoso Billing
123 Remit St
New York, NY, 10001
```

Chunk boundaries can vary slightly by model and `MaxTokens`, but with this invoice the service typically separates header/party details, line items, and totals into distinct chunks.

## Next steps

- [Sample 16: Create analyzers with workflow settings][sample16]
- [Sample 10: Analyze with configs][sample10]

[sample00]: https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/contentunderstanding/Azure.AI.ContentUnderstanding/samples/Sample00_UpdateDefaults.md
[sample10]: https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/contentunderstanding/Azure.AI.ContentUnderstanding/samples/Sample10_AnalyzeConfigs.md
[sample16]: https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/contentunderstanding/Azure.AI.ContentUnderstanding/samples/Sample16_CreateAnalyzerWorkflow.md
