# Mock a client for testing using the Moq library

This sample illustrates how to use [Moq][moq] to create a unit test that mocks the response from a `FormRecognizerClient` method. For more examples of mocking, see [Moq samples][moq_samples].

## Define a method that uses a FormRecognizerClient
To show the usage of mocks, define a method that will be tested with mocked objects. For this case, assume we have a pre-trained custom model that's able to recognize groceries list. We are going to create a method that will calculate whether the total price of a list is expensive (total price > $100), only if the recognized field has a confidence greater than 70%.

```C# Snippet:FormRecognizerMethodToTest
private static async Task<bool> IsExpensiveAsync(string modelId, Uri documentUri, FormRecognizerClient client)
{
    RecognizeCustomFormsOperation operation = await client.StartRecognizeCustomFormsFromUriAsync(modelId, documentUri);

    Response<RecognizedFormCollection> response =  await operation.WaitForCompletionAsync();
    RecognizedForm form = response.Value[0];

    if (form.Fields.TryGetValue("totalPrice", out FormField totalPriceField)
        && totalPriceField.Value.ValueType == FieldValueType.Float)
    {
        return totalPriceField.Confidence > 0.7f && totalPriceField.Value.AsFloat() > 100f;
    }
    else
    {
        return false;
    }
}
```

## Create and setup mocks
To start, create a mock for the `FormRecognizerClient`. Most methods in this service make use of [Long-Running Operations][lros], so you'll likely need to create a mock operation as well.

```C# Snippet:FormRecognizerCreateMocks
var mockClient = new Mock<FormRecognizerClient>();
var mockOperation = new Mock<RecognizeCustomFormsOperation>();
```

Then, set up the client methods that will be executed. In this case, we will call the `StartRecognizeCustomFormsFromUriAsync` method.

```C# Snippet:FormRecognizerSetUpClientMock
var fakeModelId = Guid.NewGuid().ToString();
var fakeDocumentUri = new Uri("https://fake.document.uri");

mockClient.Setup(c => c.StartRecognizeCustomFormsFromUriAsync(fakeModelId, fakeDocumentUri,
    It.IsAny<RecognizeCustomFormsOptions>(), It.IsAny<CancellationToken>()))
    .Returns(Task.FromResult(mockOperation.Object));
```

If you're mocking an operation object, you will also need to set up the methods that will be called from it. In this sample, we only need to set `WaitForCompletionAsync`.

```C# Snippet:FormRecognizerSetUpOperationMock
var labelDataBox = FormRecognizerModelFactory.FieldBoundingBox(new List<PointF>()
    { new PointF(1f, 1f), new PointF(2f, 1f), new PointF(2f, 2f), new PointF(1f, 2f) });
var labelData = FormRecognizerModelFactory.FieldData(labelDataBox, 1, "Total price:", new List<FormElement>());

var valueDataBox = FormRecognizerModelFactory.FieldBoundingBox(new List<PointF>()
    { new PointF(4f, 1f), new PointF(5f, 1f), new PointF(5f, 2f), new PointF(4f, 2f) });
var valueData = FormRecognizerModelFactory.FieldData(valueDataBox, 1, "$150.00", new List<FormElement>());

var fieldValue = FormRecognizerModelFactory.FieldValueWithFloatValueType(150f);

var formField = FormRecognizerModelFactory.FormField("totalPrice", labelData, valueData, fieldValue, 0.85f);
var formPage = FormRecognizerModelFactory.FormPage(1, 8.5f, 11f, 0f, LengthUnit.Inch, new List<FormLine>(), new List<FormTable>());

var pageRange = FormRecognizerModelFactory.FormPageRange(1, 1);
var recognizedForm = FormRecognizerModelFactory.RecognizedForm("custom:groceries", pageRange,
    new Dictionary<string, FormField>() { { "totalPrice", formField } },
    new List<FormPage>() { formPage });
var recognizedFormCollection = FormRecognizerModelFactory.RecognizedFormCollection(new List<RecognizedForm>() { recognizedForm });

Response<RecognizedFormCollection> operationResponse = Response.FromValue(recognizedFormCollection, Mock.Of<Response>());

mockOperation.Setup(op => op.WaitForCompletionAsync(It.IsAny<CancellationToken>()))
    .Returns(new ValueTask<Response<RecognizedFormCollection>>(operationResponse));
```

To keep the setup simple, we suggest that you only add the properties required by your tests when building your models. In this case, we only needed the `FormType`, the field's `Confidence`, and the field's `Value`, while the other properties could be set to `null`, `default`, or empty.

## Use mocks
Now, to validate if the groceries are expensive without making a network call, use the `FormRecognizerClient` mock.

```C# Snippet:FormRecognizerUseMocks
bool result = await IsExpensiveAsync(fakeModelId, fakeDocumentUri, mockClient.Object);
Assert.IsTrue(result);
```

[moq]: https://github.com/Moq/moq4/
[moq_samples]: https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/formrecognizer/Azure.AI.FormRecognizer/tests/samples/Sample_MockClient.cs
[lros]: https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/formrecognizer/Azure.AI.FormRecognizer#long-running-operations
