# Strongly-typing a recognized form

This sample demonstrates how to use the fields in your recognized forms to create an object with strongly typed fields. The pre-trained receipt model will be used to illustrate this sample, but note that a similar approach can be used for any custom form as long as you properly update the fields' names and types.

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

## Strongly typing a receipt

`FormField<T>` is a helper class used in this sample as a strongly-typed version of `FormField`. They have the same properties, except for `Value`, which returns a `T` instead of a `FieldValue`.

The known receipt fields returned by the service, such as `MerchantName` and `TransactionDate`, will be strongly-typed and put together into another helper class called `Receipt`.

```C# Snippet:FormRecognizerSampleStronglyTypingARecognizedForm
```

Using `FormField<T>` to make your fields strongly-typed, and populating a custom helper model class, such as `Receipt`, is the recommended approach for handling recognized custom forms in which expected labels are known.

To see the full example source files, see:

* [Strongly typing a recognized form](https://github.com/Azure/azure-sdk-for-net/blob/master/sdk/formrecognizer/Azure.AI.FormRecognizer/tests/samples/Sample4_StronglyTypingARecognizedForm.cs)
* [Receipt class](https://github.com/Azure/azure-sdk-for-net/blob/master/sdk/formrecognizer/Azure.AI.FormRecognizer/tests/samples/Receipt.cs)
* [ReceiptItem class](https://github.com/Azure/azure-sdk-for-net/blob/master/sdk/formrecognizer/Azure.AI.FormRecognizer/tests/samples/ReceiptItem.cs)
* [FormField<T> class](https://github.com/Azure/azure-sdk-for-net/blob/master/sdk/formrecognizer/Azure.AI.FormRecognizer/tests/samples/FormField{T}.cs)

[README]: https://github.com/Azure/azure-sdk-for-net/tree/master/sdk/formrecognizer/Azure.AI.FormRecognizer#getting-started