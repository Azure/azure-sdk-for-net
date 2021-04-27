# Strongly-typing a recognized form

This sample demonstrates how to use the fields in your recognized forms to create an object with strongly-typed fields. The output from the `StartRecognizeReceipts` method will be used to illustrate this sample, but note that a similar approach can be used for any custom form as long as you properly update the fields, names and types.

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

## Creating a wrapper class

Recognized receipts and custom forms are returned as `RecognizedForm` objects from the Form Recognizer client. Even though all recognized information can be obtained from them, sometimes they can be inconvenient to handle and, for this reason, we'll illustrate how to create a wrapper class to make the relevant fields easily accessible.

We'll be using a recognized receipt as a sample, so we'll call our wrapper class `Receipt`. To store items listed in the receipt, we'll use a similar wrapper called `ReceiptItem`. To see the full source files, see:

* [Receipt class](https://github.com/Azure/azure-sdk-for-net/blob/master/sdk/formrecognizer/Azure.AI.FormRecognizer/tests/samples/Receipt.cs)
* [ReceiptItem class](https://github.com/Azure/azure-sdk-for-net/blob/master/sdk/formrecognizer/Azure.AI.FormRecognizer/tests/samples/ReceiptItem.cs)

The `Receipt` class is composed of multiple `FormField<T>` properties. `FormField<T>` is a class defined in the main Form Recognizer library and used as a strongly-typed version of `FormField`, and it's more convenient to handle since there's no need to perform type checking.

`Receipt` has methods for converting a `FormField` into a strongly-typed `FormField<T>`. These methods are used in the constructor to convert fields we expect the service to return for a receipt, such as `MerchantName` or `TransactionDate`. You can use the same methods when writing a wrapper class for your custom forms, but you need to update the fields' names and types accordingly.

```C# Snippet:FormRecognizerSampleReceiptWrapper
public Receipt(RecognizedForm recognizedForm)
{
    // To see the list of the supported fields returned by service and its corresponding types, consult:
    // https://aka.ms/formrecognizer/receiptfields

    ReceiptType = ConvertStringField("ReceiptType", recognizedForm.Fields);
    MerchantAddress = ConvertStringField("MerchantAddress", recognizedForm.Fields);
    MerchantName = ConvertStringField("MerchantName", recognizedForm.Fields);
    MerchantPhoneNumber = ConvertPhoneNumberField("MerchantPhoneNumber", recognizedForm.Fields);
    Subtotal = ConvertFloatField("Subtotal", recognizedForm.Fields);
    Tax = ConvertFloatField("Tax", recognizedForm.Fields);
    Tip = ConvertFloatField("Tip", recognizedForm.Fields);
    Total = ConvertFloatField("Total", recognizedForm.Fields);
    TransactionDate = ConvertDateField("TransactionDate", recognizedForm.Fields);
    TransactionTime = ConvertTimeField("TransactionTime", recognizedForm.Fields);

    Items = ConvertReceiptItems(recognizedForm.Fields);
}
```

## Accessing fields in the strongly-typed receipt

Here we illustrate how to use the `Receipt` wrapper class described above.

```C# Snippet:FormRecognizerSampleStronglyTypingARecognizedForm
Uri receiptUri = <receiptUri>;

RecognizeReceiptsOperation operation = await client.StartRecognizeReceiptsFromUriAsync(receiptUri);
Response<RecognizedFormCollection> operationResponse = await operation.WaitForCompletionAsync();
RecognizedFormCollection recognizedForms = operationResponse.Value;

foreach (RecognizedForm recognizedForm in recognizedForms)
{
    Receipt receipt = new Receipt(recognizedForm);

    if (receipt.MerchantName != null)
    {
        string merchantName = receipt.MerchantName;
        Console.WriteLine($"Merchant Name: '{merchantName}', with confidence {receipt.MerchantName.Confidence}");
    }

    if (receipt.TransactionDate != null)
    {
        DateTime transactionDate = receipt.TransactionDate;
        Console.WriteLine($"Transaction Date: '{transactionDate}', with confidence {receipt.TransactionDate.Confidence}");
    }

    foreach (ReceiptItem item in receipt.Items)
    {
        Console.WriteLine("Item:");

        if (item.Name != null)
        {
            string name = item.Name;
            Console.WriteLine($"  Name: '{name}', with confidence {item.Name.Confidence}");
        }

        if (item.TotalPrice != null)
        {
            float totalPrice = item.TotalPrice;
            Console.WriteLine($"  Total Price: '{totalPrice}', with confidence {item.TotalPrice.Confidence}");
        }
    }

    if (receipt.Total != null)
    {
        float total = receipt.Total;
        Console.WriteLine($"Total: '{total}', with confidence {receipt.Total.Confidence}");
    }
}
```

Using `FormField<T>` to make your fields strongly-typed, and populating a custom wrapper class, such as `Receipt`, is the recommended approach for handling forms where fields have known labels.

To see the full example source files, see:

* [Strongly typing a recognized form](https://github.com/Azure/azure-sdk-for-net/blob/master/sdk/formrecognizer/Azure.AI.FormRecognizer/tests/samples/Sample4_StronglyTypingARecognizedForm.cs)

[README]: https://github.com/Azure/azure-sdk-for-net/tree/master/sdk/formrecognizer/Azure.AI.FormRecognizer#getting-started