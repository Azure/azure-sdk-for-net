# Recognize receipts

This sample demonstrates how to recognize and extract common fields from US receipts, using a pre-trained receipt model.

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

To recognize receipts from a URI, use the `StartRecognizeReceiptsFromUri` method. The returned value is a collection of `RecognizedReceipt` objects -- one for each page in the submitted document.

```C# Snippet:FormRecognizerSampleRecognizeReceiptFileFromUri
Response<IReadOnlyList<RecognizedReceipt>> receipts = await client.StartRecognizeReceiptsFromUri(new Uri(receiptUri)).WaitForCompletionAsync();
foreach (var receipt in receipts.Value)
{
    USReceipt usReceipt = receipt.AsUSReceipt();

    string merchantName = usReceipt.MerchantName?.Value ?? default;
    DateTime transactionDate = usReceipt.TransactionDate?.Value ?? default;
    IReadOnlyList<USReceiptItem> items = usReceipt.Items ?? default;
    float subtotal = usReceipt.Subtotal?.Value ?? default;
    float tax = usReceipt.Tax?.Value ?? default;
    float tip = usReceipt.Tip?.Value ?? default;
    float total = usReceipt.Total?.Value ?? default;

    Console.WriteLine($"Recognized USReceipt fields:");
    Console.WriteLine($"    Merchant Name: '{merchantName}', with confidence {usReceipt.MerchantName.Confidence}");
    Console.WriteLine($"    Transaction Date: '{transactionDate}', with confidence {usReceipt.TransactionDate.Confidence}");

    for (int i = 0; i < items.Count; i++)
    {
        USReceiptItem item = usReceipt.Items[i];
        Console.WriteLine($"    Item {i}:  Name: '{item.Name.Value}', Quantity: '{item.Quantity?.Value}', Price: '{item.Price?.Value}'");
        Console.WriteLine($"    TotalPrice: '{item.TotalPrice.Value}'");
    }

    Console.WriteLine($"    Subtotal: '{subtotal}', with confidence '{usReceipt.Subtotal.Confidence}'");
    Console.WriteLine($"    Tax: '{tax}', with confidence '{usReceipt.Tax.Confidence}'");
    Console.WriteLine($"    Tip: '{tip}', with confidence '{usReceipt.Tip?.Confidence ?? 0.0f}'");
    Console.WriteLine($"    Total: '{total}', with confidence '{usReceipt.Total.Confidence}'");
}
```

## Recognize receipts from a given file

To recognize receipts from a given file, use the `StartRecognizeReceipts` method. The returned value is a collection of `RecognizedReceipt` objects -- one for each page in the submitted document.

```C# Snippet:FormRecognizerRecognizeReceiptFromFile
using (FileStream stream = new FileStream(receiptPath, FileMode.Open))
{
    Response<IReadOnlyList<RecognizedReceipt>> receipts = await client.StartRecognizeReceipts(stream).WaitForCompletionAsync();
    /*
     *
     */
}
```

To see the full example source files, see:

* [Recognize receipts from URI](https://github.com/Azure/azure-sdk-for-net/blob/master/sdk/formrecognizer/Azure.AI.FormRecognizer/tests/samples/Sample2_RecognizeReceiptsFromUri.cs)
* [Recognize receipts from file](https://github.com/Azure/azure-sdk-for-net/blob/master/sdk/formrecognizer/Azure.AI.FormRecognizer/tests/samples/Sample2_RecognizeReceiptsFromFile.cs)

[README]: https://github.com/Azure/azure-sdk-for-net/tree/master/sdk/formrecognizer/Azure.AI.FormRecognizer#getting-started