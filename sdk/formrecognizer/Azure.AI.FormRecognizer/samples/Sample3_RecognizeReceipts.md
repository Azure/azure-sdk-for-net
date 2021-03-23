# Recognize receipts

This sample demonstrates how to recognize and extract common fields from receipts, using a pre-trained receipt model. For a suggested approach to extracting information from receipts, see [strongly-typing a recognized form][strongly_typing_a_recognized_form].

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

## Recognize receipts from a URI

To recognize receipts from a URI, use the `StartRecognizeReceiptsFromUri` method. The returned value is a collection of `RecognizedForm` objects -- one for each page in the submitted document.

```C# Snippet:FormRecognizerSampleRecognizeReceiptFileFromUri
Uri receiptUri = <receiptUri>;

RecognizeReceiptsOperation operation = await client.StartRecognizeReceiptsFromUriAsync(receiptUri);
Response<RecognizedFormCollection> operationResponse = await operation.WaitForCompletionAsync();
RecognizedFormCollection receipts = operationResponse.Value;

// To see the list of the supported fields returned by service and its corresponding types, consult:
// https://aka.ms/formrecognizer/receiptfields

foreach (RecognizedForm receipt in receipts)
{
    if (receipt.Fields.TryGetValue("MerchantName", out FormField merchantNameField))
    {
        if (merchantNameField.Value.ValueType == FieldValueType.String)
        {
            string merchantName = merchantNameField.Value.AsString();

            Console.WriteLine($"Merchant Name: '{merchantName}', with confidence {merchantNameField.Confidence}");
        }
    }

    if (receipt.Fields.TryGetValue("TransactionDate", out FormField transactionDateField))
    {
        if (transactionDateField.Value.ValueType == FieldValueType.Date)
        {
            DateTime transactionDate = transactionDateField.Value.AsDate();

            Console.WriteLine($"Transaction Date: '{transactionDate}', with confidence {transactionDateField.Confidence}");
        }
    }

    if (receipt.Fields.TryGetValue("Items", out FormField itemsField))
    {
        if (itemsField.Value.ValueType == FieldValueType.List)
        {
            foreach (FormField itemField in itemsField.Value.AsList())
            {
                Console.WriteLine("Item:");

                if (itemField.Value.ValueType == FieldValueType.Dictionary)
                {
                    IReadOnlyDictionary<string, FormField> itemFields = itemField.Value.AsDictionary();

                    if (itemFields.TryGetValue("Name", out FormField itemNameField))
                    {
                        if (itemNameField.Value.ValueType == FieldValueType.String)
                        {
                            string itemName = itemNameField.Value.AsString();

                            Console.WriteLine($"  Name: '{itemName}', with confidence {itemNameField.Confidence}");
                        }
                    }

                    if (itemFields.TryGetValue("TotalPrice", out FormField itemTotalPriceField))
                    {
                        if (itemTotalPriceField.Value.ValueType == FieldValueType.Float)
                        {
                            float itemTotalPrice = itemTotalPriceField.Value.AsFloat();

                            Console.WriteLine($"  Total Price: '{itemTotalPrice}', with confidence {itemTotalPriceField.Confidence}");
                        }
                    }
                }
            }
        }
    }

    if (receipt.Fields.TryGetValue("Total", out FormField totalField))
    {
        if (totalField.Value.ValueType == FieldValueType.Float)
        {
            float total = totalField.Value.AsFloat();

            Console.WriteLine($"Total: '{total}', with confidence '{totalField.Confidence}'");
        }
    }
}
```

## Recognize receipts from a given file

To recognize receipts from a given file, use the `StartRecognizeReceipts` method. The returned value is a collection of `RecognizedForm` objects -- one for each page in the submitted document.

```C# Snippet:FormRecognizerSampleRecognizeReceiptFileStream
string receiptPath = "<receiptPath>";

using var stream = new FileStream(receiptPath, FileMode.Open);
var options = new RecognizeReceiptsOptions() { Locale = "en-US" };

RecognizeReceiptsOperation operation = await client.StartRecognizeReceiptsAsync(stream, options);
Response<RecognizedFormCollection> operationResponse = await operation.WaitForCompletionAsync();
RecognizedFormCollection receipts = operationResponse.Value;

// To see the list of the supported fields returned by service and its corresponding types, consult:
// https://aka.ms/formrecognizer/receiptfields

foreach (RecognizedForm receipt in receipts)
{
    if (receipt.Fields.TryGetValue("MerchantName", out FormField merchantNameField))
    {
        if (merchantNameField.Value.ValueType == FieldValueType.String)
        {
            string merchantName = merchantNameField.Value.AsString();

            Console.WriteLine($"Merchant Name: '{merchantName}', with confidence {merchantNameField.Confidence}");
        }
    }

    if (receipt.Fields.TryGetValue("TransactionDate", out FormField transactionDateField))
    {
        if (transactionDateField.Value.ValueType == FieldValueType.Date)
        {
            DateTime transactionDate = transactionDateField.Value.AsDate();

            Console.WriteLine($"Transaction Date: '{transactionDate}', with confidence {transactionDateField.Confidence}");
        }
    }

    if (receipt.Fields.TryGetValue("Items", out FormField itemsField))
    {
        if (itemsField.Value.ValueType == FieldValueType.List)
        {
            foreach (FormField itemField in itemsField.Value.AsList())
            {
                Console.WriteLine("Item:");

                if (itemField.Value.ValueType == FieldValueType.Dictionary)
                {
                    IReadOnlyDictionary<string, FormField> itemFields = itemField.Value.AsDictionary();

                    if (itemFields.TryGetValue("Name", out FormField itemNameField))
                    {
                        if (itemNameField.Value.ValueType == FieldValueType.String)
                        {
                            string itemName = itemNameField.Value.AsString();

                            Console.WriteLine($"  Name: '{itemName}', with confidence {itemNameField.Confidence}");
                        }
                    }

                    if (itemFields.TryGetValue("TotalPrice", out FormField itemTotalPriceField))
                    {
                        if (itemTotalPriceField.Value.ValueType == FieldValueType.Float)
                        {
                            float itemTotalPrice = itemTotalPriceField.Value.AsFloat();

                            Console.WriteLine($"  Total Price: '{itemTotalPrice}', with confidence {itemTotalPriceField.Confidence}");
                        }
                    }
                }
            }
        }
    }

    if (receipt.Fields.TryGetValue("Total", out FormField totalField))
    {
        if (totalField.Value.ValueType == FieldValueType.Float)
        {
            float total = totalField.Value.AsFloat();

            Console.WriteLine($"Total: '{total}', with confidence '{totalField.Confidence}'");
        }
    }
}
```

To see the full example source files, see:

* [Recognize receipts from URI](https://github.com/Azure/azure-sdk-for-net/blob/master/sdk/formrecognizer/Azure.AI.FormRecognizer/tests/samples/Sample3_RecognizeReceiptsFromUri.cs)
* [Recognize receipts from file](https://github.com/Azure/azure-sdk-for-net/blob/master/sdk/formrecognizer/Azure.AI.FormRecognizer/tests/samples/Sample3_RecognizeReceiptsFromFile.cs)

[README]: https://github.com/Azure/azure-sdk-for-net/tree/master/sdk/formrecognizer/Azure.AI.FormRecognizer#getting-started
[strongly_typing_a_recognized_form]: https://github.com/Azure/azure-sdk-for-net/tree/master/sdk/formrecognizer/Azure.AI.FormRecognizer/samples/Sample4_StronglyTypingARecognizedForm.md