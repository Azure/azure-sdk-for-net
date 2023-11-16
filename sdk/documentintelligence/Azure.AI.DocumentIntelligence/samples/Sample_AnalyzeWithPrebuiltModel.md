# Analyze a document with a prebuilt model

This sample demonstrates how to analyze data from certain types of common documents with prebuilt models, using an invoice as an example. For more information about prebuilt models and which types of documents are supported, see the [service documentation][docint_models].

To get started you'll need a Cognitive Services resource or a Document Intelligence resource. See [README][README] for prerequisites and instructions.

## Creating a `DocumentIntelligenceClient`

To create a new `DocumentIntelligenceClient` you need the endpoint and credentials from your resource. In the sample below you'll use a Document Intelligence API key credential by creating an `AzureKeyCredential` object that, if needed, will allow you to update the API key without creating a new client.

You can set `endpoint` and `apiKey` based on an environment variable, a configuration setting, or any way that works for your application.

```C# Snippet:CreateDocumentIntelligenceClient
string endpoint = "<endpoint>";
string apiKey = "<apiKey>";
var client = new DocumentIntelligenceClient(new Uri(endpoint), new AzureKeyCredential(apiKey));
```

## Use a prebuilt model to analyze a document from a URI

To analyze a given file at a URI, use the `AnalyzeDocument` method. The returned value is an `AnalyzeResult` object containing data about the submitted document. Since we're analyzing an invoice, we'll pass the model ID `prebuilt-invoice` to the method.

For simplicity, we are not showing all the fields that the service returns. To see the list of all the supported fields returned by the service and its corresponding types, consult the [invoice model documentation][invoice_fields].

```C# Snippet:DocumentIntelligenceAnalyzeWithPrebuiltModelFromUriAsync
Uri uriSource = new Uri("<uriSource>");

var content = new AnalyzeDocumentContent()
{
    UrlSource = uriSource
};

Operation<AnalyzeResult> operation = await client.AnalyzeDocumentAsync(WaitUntil.Completed, "prebuilt-invoice", content);
AnalyzeResult result = operation.Value;

// To see the list of all the supported fields returned by service and its corresponding types for the
// prebuilt-invoice model, see:
// https://aka.ms/azsdk/formrecognizer/invoicefieldschema

for (int i = 0; i < result.Documents.Count; i++)
{
    Console.WriteLine($"Document {i}:");

    AnalyzedDocument document = result.Documents[i];

    if (document.Fields.TryGetValue("VendorName", out DocumentField vendorNameField)
        && vendorNameField.Type == DocumentFieldType.String)
    {
        string vendorName = vendorNameField.ValueString;
        Console.WriteLine($"Vendor Name: '{vendorName}', with confidence {vendorNameField.Confidence}");
    }

    if (document.Fields.TryGetValue("CustomerName", out DocumentField customerNameField)
        && customerNameField.Type == DocumentFieldType.String)
    {
        string customerName = customerNameField.ValueString;
        Console.WriteLine($"Customer Name: '{customerName}', with confidence {customerNameField.Confidence}");
    }

    if (document.Fields.TryGetValue("Items", out DocumentField itemsField)
        && itemsField.Type == DocumentFieldType.Array)
    {
        foreach (DocumentField itemField in itemsField.ValueArray)
        {
            Console.WriteLine("Item:");

            if (itemField.Type == DocumentFieldType.Object)
            {
                IReadOnlyDictionary<string, DocumentField> itemFields = itemField.ValueObject;

                if (itemFields.TryGetValue("Description", out DocumentField itemDescriptionField)
                    && itemDescriptionField.Type == DocumentFieldType.String)
                {
                    string itemDescription = itemDescriptionField.ValueString;
                    Console.WriteLine($"  Description: '{itemDescription}', with confidence {itemDescriptionField.Confidence}");
                }

                if (itemFields.TryGetValue("Amount", out DocumentField itemAmountField)
                    && itemAmountField.Type == DocumentFieldType.Currency)
                {
                    CurrencyValue itemAmount = itemAmountField.ValueCurrency;
                    Console.WriteLine($"  Amount: '{itemAmount.CurrencySymbol}{itemAmount.Amount}', with confidence {itemAmountField.Confidence}");
                }
            }
        }
    }

    if (document.Fields.TryGetValue("SubTotal", out DocumentField subTotalField)
        && subTotalField.Type == DocumentFieldType.Currency)
    {
        CurrencyValue subTotal = subTotalField.ValueCurrency;
        Console.WriteLine($"Sub Total: '{subTotal.CurrencySymbol}{subTotal.Amount}', with confidence {subTotalField.Confidence}");
    }

    if (document.Fields.TryGetValue("TotalTax", out DocumentField totalTaxField)
        && totalTaxField.Type == DocumentFieldType.Currency)
    {
        CurrencyValue totalTax = totalTaxField.ValueCurrency;
        Console.WriteLine($"Total Tax: '{totalTax.CurrencySymbol}{totalTax.Amount}', with confidence {totalTaxField.Confidence}");
    }

    if (document.Fields.TryGetValue("InvoiceTotal", out DocumentField invoiceTotalField)
        && invoiceTotalField.Type == DocumentFieldType.Currency)
    {
        CurrencyValue invoiceTotal = invoiceTotalField.ValueCurrency;
        Console.WriteLine($"Invoice Total: '{invoiceTotal.CurrencySymbol}{invoiceTotal.Amount}', with confidence {invoiceTotalField.Confidence}");
    }
}
```

[invoice_fields]: https://aka.ms/azsdk/formrecognizer/invoicefieldschema
[docint_models]: https://aka.ms/azsdk/formrecognizer/models

[README]: https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/documentintelligence/Azure.AI.DocumentIntelligence#getting-started
