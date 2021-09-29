# Recognize invoices

This sample demonstrates how to recognize and extract common fields from invoices, using a pre-trained model. For a suggested approach to extracting information from invoices, see [strongly-typing a recognized form][strongly_typing_a_recognized_form].

To get started you'll need a Cognitive Services resource or a Form Recognizer resource.  See [README][README] for prerequisites and instructions.

## Creating a `FormRecognizerClient`

To create a new `FormRecognizerClient` you need the endpoint and credentials from your resource. In the sample below you'll use a Form Recognizer API key credential by creating an `AzureKeyCredential` object, that if needed, will allow you to update the API key without creating a new client.

You can set `endpoint` and `apiKey` based on an environment variable, a configuration setting, or any way that works for your application.

```C# Snippet:CreateFormRecognizerClient
string endpoint = "<endpoint>";
string apiKey = "<apiKey>";
var credential = new AzureKeyCredential(apiKey);
var client = new FormRecognizerClient(new Uri(endpoint), credential);
```

## Recognize invoices from a URI

To recognize invoices from a URI, use the `StartRecognizeInvoicesFromUriAsync` method.

For simplicity, we are not showing all the fields that the service returns. To see the list of all the supported fields returned by service and its corresponding types, consult: [here](https://aka.ms/formrecognizer/invoicefields).

```C# Snippet:FormRecognizerSampleRecognizeInvoicesUri
    Uri invoiceUri = <invoiceUri>;
    var options = new RecognizeInvoicesOptions() { Locale = "en-US" };

    RecognizeInvoicesOperation operation = await client.StartRecognizeInvoicesFromUriAsync(invoiceUri, options);
    Response<RecognizedFormCollection> operationResponse = await operation.WaitForCompletionAsync();
    RecognizedFormCollection invoices = operationResponse.Value;

    // To see the list of all the supported fields returned by service and its corresponding types, consult:
    // https://aka.ms/formrecognizer/invoicefields

    RecognizedForm invoice = invoices.Single();

    if (invoice.Fields.TryGetValue("InvoiceId", out FormField invoiceIdField))
    {
        if (invoiceIdField.Value.ValueType == FieldValueType.String)
        {
            string invoiceId = invoiceIdField.Value.AsString();
            Console.WriteLine($"Invoice Id: '{invoiceId}', with confidence {invoiceIdField.Confidence}");
        }
    }

    if (invoice.Fields.TryGetValue("VendorName", out FormField vendorNameField))
    {
        if (vendorNameField.Value.ValueType == FieldValueType.String)
        {
            string vendorName = vendorNameField.Value.AsString();
            Console.WriteLine($"Vendor Name: '{vendorName}', with confidence {vendorNameField.Confidence}");
        }
    }

    if (invoice.Fields.TryGetValue("CustomerName", out FormField customerNameField))
    {
        if (customerNameField.Value.ValueType == FieldValueType.String)
        {
            string customerName = customerNameField.Value.AsString();
            Console.WriteLine($"Customer Name: '{customerName}', with confidence {customerNameField.Confidence}");
        }
    }

    if (invoice.Fields.TryGetValue("Items", out FormField itemsField))
    {
        if (itemsField.Value.ValueType == FieldValueType.List)
        {
            foreach (FormField itemField in itemsField.Value.AsList())
            {
                Console.WriteLine("Item:");

                if (itemField.Value.ValueType == FieldValueType.Dictionary)
                {
                    IReadOnlyDictionary<string, FormField> itemFields = itemField.Value.AsDictionary();

                    if (itemFields.TryGetValue("Description", out FormField itemDescriptionField))
                    {
                        if (itemDescriptionField.Value.ValueType == FieldValueType.String)
                        {
                            string itemDescription = itemDescriptionField.Value.AsString();

                            Console.WriteLine($"  Description: '{itemDescription}', with confidence {itemDescriptionField.Confidence}");
                        }
                    }

                    if (itemFields.TryGetValue("UnitPrice", out FormField itemUnitPriceField))
                    {
                        if (itemUnitPriceField.Value.ValueType == FieldValueType.Float)
                        {
                            float itemUnitPrice = itemUnitPriceField.Value.AsFloat();

                            Console.WriteLine($"  UnitPrice: '{itemUnitPrice}', with confidence {itemUnitPriceField.Confidence}");
                        }
                    }

                    if (itemFields.TryGetValue("Quantity", out FormField itemQuantityField))
                    {
                        if (itemQuantityField.Value.ValueType == FieldValueType.Float)
                        {
                            float quantityAmount = itemQuantityField.Value.AsFloat();

                            Console.WriteLine($"  Quantity: '{quantityAmount}', with confidence {itemQuantityField.Confidence}");
                        }
                    }

                    if (itemFields.TryGetValue("Amount", out FormField itemAmountField))
                    {
                        if (itemAmountField.Value.ValueType == FieldValueType.Float)
                        {
                            float itemAmount = itemAmountField.Value.AsFloat();

                            Console.WriteLine($"  Amount: '{itemAmount}', with confidence {itemAmountField.Confidence}");
                        }
                    }
                }
            }
        }
    }

    if (invoice.Fields.TryGetValue("SubTotal", out FormField subTotalField))
    {
        if (subTotalField.Value.ValueType == FieldValueType.Float)
        {
            float subTotal = subTotalField.Value.AsFloat();
            Console.WriteLine($"Sub Total: '{subTotal}', with confidence {subTotalField.Confidence}");
        }
    }

    if (invoice.Fields.TryGetValue("TotalTax", out FormField totalTaxField))
    {
        if (totalTaxField.Value.ValueType == FieldValueType.Float)
        {
            float totalTax = totalTaxField.Value.AsFloat();
            Console.WriteLine($"Total Tax: '{totalTax}', with confidence {totalTaxField.Confidence}");
        }
    }

    if (invoice.Fields.TryGetValue("InvoiceTotal", out FormField invoiceTotalField))
    {
        if (invoiceTotalField.Value.ValueType == FieldValueType.Float)
        {
            float invoiceTotal = invoiceTotalField.Value.AsFloat();
            Console.WriteLine($"Invoice Total: '{invoiceTotal}', with confidence {invoiceTotalField.Confidence}");
        }
    }
}
```

## Recognize invoices from a given file

To recognize invoices from a given file, use the `StartRecognizeInvoicesAsync` method.

For simplicity, we are not showing all the fields that the service returns. To see the list of all the supported fields returned by service and its corresponding types, consult: [here](https://aka.ms/formrecognizer/invoicefields).

```C# Snippet:FormRecognizerSampleRecognizeInvoicesFileStream
string invoicePath = "<invoicePath>";

using var stream = new FileStream(invoicePath, FileMode.Open);
var options = new RecognizeInvoicesOptions() { Locale = "en-US" };

RecognizeInvoicesOperation operation = await client.StartRecognizeInvoicesAsync(stream, options);
Response<RecognizedFormCollection> operationResponse = await operation.WaitForCompletionAsync();
RecognizedFormCollection invoices = operationResponse.Value;

// To see the list of all the supported fields returned by service and its corresponding types, consult:
// https://aka.ms/formrecognizer/invoicefields

RecognizedForm invoice = invoices.Single();

if (invoice.Fields.TryGetValue("VendorName", out FormField vendorNameField))
{
    if (vendorNameField.Value.ValueType == FieldValueType.String)
    {
        string vendorName = vendorNameField.Value.AsString();
        Console.WriteLine($"Vendor Name: '{vendorName}', with confidence {vendorNameField.Confidence}");
    }
}

if (invoice.Fields.TryGetValue("CustomerName", out FormField customerNameField))
{
    if (customerNameField.Value.ValueType == FieldValueType.String)
    {
        string customerName = customerNameField.Value.AsString();
        Console.WriteLine($"Customer Name: '{customerName}', with confidence {customerNameField.Confidence}");
    }
}

if (invoice.Fields.TryGetValue("Items", out FormField itemsField))
{
    if (itemsField.Value.ValueType == FieldValueType.List)
    {
        foreach (FormField itemField in itemsField.Value.AsList())
        {
            Console.WriteLine("Item:");

            if (itemField.Value.ValueType == FieldValueType.Dictionary)
            {
                IReadOnlyDictionary<string, FormField> itemFields = itemField.Value.AsDictionary();

                if (itemFields.TryGetValue("Description", out FormField itemDescriptionField))
                {
                    if (itemDescriptionField.Value.ValueType == FieldValueType.String)
                    {
                        string itemDescription = itemDescriptionField.Value.AsString();

                        Console.WriteLine($"  Description: '{itemDescription}', with confidence {itemDescriptionField.Confidence}");
                    }
                }

                if (itemFields.TryGetValue("Quantity", out FormField itemQuantityField))
                {
                    if (itemQuantityField.Value.ValueType == FieldValueType.Float)
                    {
                        float quantityAmount = itemQuantityField.Value.AsFloat();

                        Console.WriteLine($"  Quantity: '{quantityAmount}', with confidence {itemQuantityField.Confidence}");
                    }
                }

                if (itemFields.TryGetValue("UnitPrice", out FormField itemUnitPriceField))
                {
                    if (itemUnitPriceField.Value.ValueType == FieldValueType.Float)
                    {
                        float itemUnitPrice = itemUnitPriceField.Value.AsFloat();

                        Console.WriteLine($"  UnitPrice: '{itemUnitPrice}', with confidence {itemUnitPriceField.Confidence}");
                    }
                }

                if (itemFields.TryGetValue("Tax", out FormField itemTaxPriceField))
                {
                    if (itemTaxPriceField.Value.ValueType == FieldValueType.Float)
                    {
                        try
                        {
                            float itemTax = itemTaxPriceField.Value.AsFloat();
                            Console.WriteLine($"  Tax: '{itemTax}', with confidence {itemTaxPriceField.Confidence}");
                        }
                        catch
                        {
                            string itemTaxText = itemTaxPriceField.ValueData.Text;
                            Console.WriteLine($"  Tax: '{itemTaxText}', with confidence {itemTaxPriceField.Confidence}");
                        }
                    }
                }

                if (itemFields.TryGetValue("Amount", out FormField itemAmountField))
                {
                    if (itemAmountField.Value.ValueType == FieldValueType.Float)
                    {
                        float itemAmount = itemAmountField.Value.AsFloat();

                        Console.WriteLine($"  Amount: '{itemAmount}', with confidence {itemAmountField.Confidence}");
                    }
                }
            }
        }
    }
}

if (invoice.Fields.TryGetValue("SubTotal", out FormField subTotalField))
{
    if (subTotalField.Value.ValueType == FieldValueType.Float)
    {
        float subTotal = subTotalField.Value.AsFloat();
        Console.WriteLine($"Sub Total: '{subTotal}', with confidence {subTotalField.Confidence}");
    }
}

if (invoice.Fields.TryGetValue("TotalTax", out FormField totalTaxField))
{
    if (totalTaxField.Value.ValueType == FieldValueType.Float)
    {
        float totalTax = totalTaxField.Value.AsFloat();
        Console.WriteLine($"Total Tax: '{totalTax}', with confidence {totalTaxField.Confidence}");
    }
}

if (invoice.Fields.TryGetValue("InvoiceTotal", out FormField invoiceTotalField))
{
    if (invoiceTotalField.Value.ValueType == FieldValueType.Float)
    {
        float invoiceTotal = invoiceTotalField.Value.AsFloat();
        Console.WriteLine($"Invoice Total: '{invoiceTotal}', with confidence {invoiceTotalField.Confidence}");
    }
}
```

To see the full example source files, see:

* [Recognize invoices from URI](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/formrecognizer/Azure.AI.FormRecognizer/tests/samples/Sample13_RecognizeInvoicesFromUri.cs)
* [Recognize invoices from file](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/formrecognizer/Azure.AI.FormRecognizer/tests/samples/Sample13_RecognizeInvoicesFromFile.cs)

[README]: https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/formrecognizer/Azure.AI.FormRecognizer#getting-started
[strongly_typing_a_recognized_form]: https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/formrecognizer/Azure.AI.FormRecognizer/samples/Sample4_StronglyTypingARecognizedForm.md