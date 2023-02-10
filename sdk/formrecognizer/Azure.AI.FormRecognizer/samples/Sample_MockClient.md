# Mock a client for testing using the Moq library

This sample illustrates how to use [Moq][moq] to create a unit test that mocks the response from a `DocumentAnalysisClient` method.

## Define a method that uses a DocumentAnalysisClient
To show the usage of mocks, define a method that will be tested with mocked objects. For this case, assume we have a custom model that's able to analyze groceries lists. We are going to create a method that will calculate whether the total price of a list is expensive (total price > $100), only if the recognized field has a confidence greater than 70%.

```C# Snippet:DocumentAnalysisMethodToTest
private static async Task<bool> IsExpensiveAsync(string modelId, Uri documentUri, DocumentAnalysisClient client)
{
    AnalyzeDocumentOperation operation = await client.AnalyzeDocumentFromUriAsync(WaitUntil.Completed, modelId, documentUri);
    AnalyzedDocument document = operation.Value.Documents[0];

    if (document.Fields.TryGetValue("totalPrice", out DocumentField totalPriceField)
        && totalPriceField.FieldType == DocumentFieldType.Double)
    {
        return totalPriceField.Confidence > 0.7f && totalPriceField.Value.AsDouble() > 100.0;
    }
    else
    {
        return false;
    }
}
```

## Create and set up mocks
To start, create a mock for the `DocumentAnalysisClient`. Most methods in this service make use of [Long-Running Operations][lros], so you'll likely need to create a mock operation as well.

```C# Snippet:DocumentAnalysisCreateMocks
var mockClient = new Mock<DocumentAnalysisClient>();
var mockOperation = new Mock<AnalyzeDocumentOperation>();
```

Then, set up the client methods that will be executed. In this case, we will call the `AnalyzeDocumentFromUriAsync` method.

```C# Snippet:DocumentAnalysisSetUpClientMock
var fakeModelId = Guid.NewGuid().ToString();
var fakeDocumentUri = new Uri("https://fake.document.uri");

mockClient.Setup(client => client.AnalyzeDocumentFromUriAsync(
        WaitUntil.Completed,
        fakeModelId,
        fakeDocumentUri,
        It.IsAny<AnalyzeDocumentOptions>(),
        It.IsAny<CancellationToken>()))
    .Returns(Task.FromResult(mockOperation.Object));
```

If you're mocking an operation object, you will also need to set up the methods that will be called from it. In this sample, we only need to set the property `Value`.

```C# Snippet:DocumentAnalysisSetUpOperationMock
var fieldValue = DocumentAnalysisModelFactory.DocumentFieldValueWithDoubleFieldType(150.0);

var fieldPolygon = new List<PointF>()
{
    new PointF(1f, 2f), new PointF(2f, 2f), new PointF(2f, 1f), new PointF(1f, 1f)
};
var fieldRegion = DocumentAnalysisModelFactory.BoundingRegion(1, fieldPolygon);
var fieldRegions = new List<BoundingRegion>() { fieldRegion };

var fieldSpans = new List<DocumentSpan>()
{
    DocumentAnalysisModelFactory.DocumentSpan(25, 32)
};

var field = DocumentAnalysisModelFactory.DocumentField(DocumentFieldType.Double, fieldValue, "$150.00", fieldRegions, fieldSpans, confidence: 0.85f);
var fields = new Dictionary<string, DocumentField>
{
    { "totalPrice", field }
};

var documentPolygon = new List<PointF>()
{
    new PointF(0f, 10f), new PointF(10f, 10f), new PointF(10f, 0f), new PointF(0f, 0f)
};
var documentRegion = DocumentAnalysisModelFactory.BoundingRegion(1, documentPolygon);
var documentRegions = new List<BoundingRegion>() { documentRegion };

var documentSpans = new List<DocumentSpan>()
{
    DocumentAnalysisModelFactory.DocumentSpan(0, 105)
};

var document = DocumentAnalysisModelFactory.AnalyzedDocument("groceries:groceries", documentRegions, documentSpans, fields, 0.95f);
var documents = new List<AnalyzedDocument>() { document };

var result = DocumentAnalysisModelFactory.AnalyzeResult("groceries", documents: documents);

mockOperation.SetupGet(op => op.Value)
    .Returns(result);
```

To keep the setup simple, we suggest that you only add the properties required by your tests when building your models. In this case, we only needed the `DocumentFieldType`, the field's `Confidence`, and the field's `Value`, while other properties could be set to `null`, `default`, or empty.

## Use mocks
Now, to validate if the groceries are expensive without making a network call, use the `DocumentAnalysisClient` mock.

```C# Snippet:DocumentAnalysisUseMocks
bool isExpensive = await IsExpensiveAsync(fakeModelId, fakeDocumentUri, mockClient.Object);
Assert.IsTrue(isExpensive);
```

[moq]: https://github.com/Moq/moq4/
[lros]: https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/formrecognizer/Azure.AI.FormRecognizer#long-running-operations
