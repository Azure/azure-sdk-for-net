# Analyze Invoice Sample

This sample demonstrates how to extract structured invoice fields from a document URL using Azure AI Content Understanding's prebuilt-invoice analyzer.

## What This Sample Does

1. **Analyzes an invoice** from a public URL
2. **Uses the prebuilt-invoice analyzer** for structured field extraction
3. **Extracts specific invoice fields**:
   - Customer name
   - Invoice total
   - Invoice date
   - Line items (with description, quantity, unit price, total price)
4. **Saves the complete result** to a JSON file for inspection

## Prerequisites

- .NET 8.0 or later
- Azure AI Content Understanding resource
- Configuration set up (see main samples README)

## Running the Sample

### From the AnalyzeInvoice directory:

```bash
dotnet run
```

### From the repository root:

```bash
dotnet run --project sdk/contentunderstanding/Azure.AI.ContentUnderstanding/samples/AnalyzeInvoice
```

## Configuration

This sample uses the shared configuration system. You can configure it in two ways:

### Option 1: Shared appsettings.json (Recommended)

Edit `samples/appsettings.json`:
```json
{
  "AzureContentUnderstanding": {
    "Endpoint": "https://your-resource-name.services.ai.azure.com/",
    "Key": "your-key-here"
  }
}
```

### Option 2: Environment Variables

```bash
export AZURE_CONTENT_UNDERSTANDING_ENDPOINT="https://your-resource-name.services.ai.azure.com/"
export AZURE_CONTENT_UNDERSTANDING_KEY="your-key-here"  # Optional if using DefaultAzureCredential
```

## Sample Output

```
🔍 Analyzing invoice from https://github.com/Azure-Samples/azure-ai-content-understanding-python/raw/refs/heads/main/data/invoice.pdf with prebuilt-invoice analyzer...

📄 Invoice Analysis Result:
==================================================

📋 Sample Field Extractions:
----------------------------------------
Customer Name: MICROSOFT CORPORATION
Invoice Total: $610.00
Invoice Date: 11/15/2019

🛒 Invoice Items (Array):
  Item 1:
    Description: Consulting Services
    Quantity: 2
    Unit Price: $30.00
    Total Price: $60.00
  Item 2:
    Description: Document Fee
    Quantity: 3
    Unit Price: $10.00
    Total Price: $30.00
  Item 3:
    Description: Printing Fee
    Quantity: 10
    Unit Price: $1.00
    Total Price: $10.00

📄 Total fields extracted: 15
💾 Invoice fields saved to JSON file for detailed inspection

✅ Analysis complete!
```

## Key Differences from Document Analyzer

- Uses **prebuilt-invoice** analyzer instead of prebuilt-documentAnalyzer
- Extracts **structured fields** specific to invoices
- Returns typed field values (string, number, date, array, object)
- Includes **line items** as array fields with nested object properties

## Understanding Invoice Fields

The prebuilt-invoice analyzer extracts many fields including:

- **Simple fields**: CustomerName, InvoiceId, InvoiceDate, DueDate, InvoiceTotal
- **Address fields**: BillingAddress, ShippingAddress, VendorAddress
- **Array fields**: Items (each with Description, Quantity, UnitPrice, TotalPrice)
- **Complex fields**: SubTotal, TotalTax, AmountDue, PreviousUnpaidBalance

Check the saved JSON file (`output/analyze_invoice_result_*.json`) to see all extracted fields.

## Related Samples

- **AnalyzeUrl**: Basic document analysis with prebuilt-documentAnalyzer
- **AnalyzeBinary**: Analyze local PDF files

## Learn More

- [Azure AI Content Understanding Documentation](https://learn.microsoft.com/azure/ai-services/content-understanding/)
- [Prebuilt Invoice Model](https://learn.microsoft.com/azure/ai-services/content-understanding/concept-invoice)
- [.NET SDK Reference](https://learn.microsoft.com/dotnet/api/azure.ai.contentunderstanding)



