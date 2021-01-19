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

```C# Snippet:FormRecognizerSampleRecognizeInvoicesUri
    Uri invoiceUri = <invoiceUri>;
    var options = new RecognizeInvoicesOptions() { Locale = "en-US" };

    RecognizeInvoicesOperation operation = await client.StartRecognizeInvoicesFromUriAsync(invoiceUri, options);
    Response<RecognizedFormCollection> operationResponse = await operation.WaitForCompletionAsync();
    RecognizedFormCollection invoices = operationResponse.Value;

    // To see the list of the supported fields returned by service and its corresponding types, consult:
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

    if (invoice.Fields.TryGetValue("InvoiceDate", out FormField invoiceDateField))
    {
        if (invoiceDateField.Value.ValueType == FieldValueType.Date)
        {
            DateTime invoiceDate = invoiceDateField.Value.AsDate();
            Console.WriteLine($"Invoice Date: '{invoiceDate}', with confidence {invoiceDateField.Confidence}");
        }
    }

    if (invoice.Fields.TryGetValue("DueDate", out FormField dueDateField))
    {
        if (dueDateField.Value.ValueType == FieldValueType.Date)
        {
            DateTime dueDate = dueDateField.Value.AsDate();
            Console.WriteLine($"Due Date: '{dueDate}', with confidence {dueDateField.Confidence}");
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

    if (invoice.Fields.TryGetValue("VendorAddress", out FormField vendorAddressField))
    {
        if (vendorAddressField.Value.ValueType == FieldValueType.String)
        {
            string vendorAddress = vendorAddressField.Value.AsString();
            Console.WriteLine($"Vendor Address: '{vendorAddress}', with confidence {vendorAddressField.Confidence}");
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

    if (invoice.Fields.TryGetValue("CustomerAddress", out FormField customerAddressField))
    {
        if (customerAddressField.Value.ValueType == FieldValueType.String)
        {
            string customerAddress = customerAddressField.Value.AsString();
            Console.WriteLine($"Customer Address: '{customerAddress}', with confidence {customerAddressField.Confidence}");
        }
    }

    if (invoice.Fields.TryGetValue("CustomerAddressRecipient", out FormField customerAddressRecipientField))
    {
        if (customerAddressRecipientField.Value.ValueType == FieldValueType.String)
        {
            string customerAddressRecipient = customerAddressRecipientField.Value.AsString();
            Console.WriteLine($"Customer address recipient: '{customerAddressRecipient}', with confidence {customerAddressRecipientField.Confidence}");
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

```C# Snippet:FormRecognizerSampleRecognizeInvoicesFileStream
string invoicePath = "<invoicePath>";

using var stream = new FileStream(invoicePath, FileMode.Open);
var options = new RecognizeInvoicesOptions() { Locale = "en-US" };

RecognizeInvoicesOperation operation = await client.StartRecognizeInvoicesAsync(stream, options);
Response<RecognizedFormCollection> operationResponse = await operation.WaitForCompletionAsync();
RecognizedFormCollection invoices = operationResponse.Value;

// To see the list of the supported fields returned by service and its corresponding types, consult:
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

* [Recognize invoices from URI](https://github.com/Azure/azure-sdk-for-net/blob/master/sdk/formrecognizer/Azure.AI.FormRecognizer/tests/samples/Sample13_RecognizeInvoicesFromUri.cs)
* [Recognize invoices from file](https://github.com/Azure/azure-sdk-for-net/blob/master/sdk/formrecognizer/Azure.AI.FormRecognizer/tests/samples/Sample13_RecognizeInvoicesFromFile.cs)

[README]: https://github.com/Azure/azure-sdk-for-net/tree/master/sdk/formrecognizer/Azure.AI.FormRecognizer#getting-started
[strongly_typing_a_recognized_form]: https://github.com/Azure/azure-sdk-for-net/tree/master/sdk/formrecognizer/Azure.AI.FormRecognizer/samples/Sample4_StronglyTypingARecognizedForm.md