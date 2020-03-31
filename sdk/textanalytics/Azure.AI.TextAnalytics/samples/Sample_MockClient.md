# Mock a client for testing using the Moq library

This sample illustrates how to use [Moq][moq] to create a unit test that mocks the response from a `TextAnalyticsClient` method. For more examples of mocking, see [Moq samples][moq_samples].

## Create and setup mocks
For this test, create a mock for the `TextAnalyticsClient` and `Response`.

```C# Snippet:CreateMocks
var mockResponse = new Mock<Response>();
var mockClient = new Mock<TextAnalyticsClient>();
```

Then, set up the client methods that will be executed. In this case, we will call the `DetectLanguageAsync` method.

```C# Snippet:SetupMocks
Response<DetectedLanguage> response = Response.FromValue(TextAnalyticsModelFactory.DetectedLanguage("Spanish", "es", 1.00), mockResponse.Object);

mockClient.Setup(c => c.DetectLanguageAsync("Este documento está en español.", It.IsAny<string>(), It.IsAny<CancellationToken>()))
    .Returns(Task.FromResult(response));
```

## Use mocks
Now, to validate the detected language of the document without making a network call, use `TextAnalyticsClient` mock.

```C# Snippet:UseMocks
TextAnalyticsClient client = mockClient.Object;
DetectedLanguage language = await client.DetectLanguageAsync("Este documento está en español.");
Assert.AreEqual("Spanish", language.Name);
Assert.AreEqual("es", language.Iso6391Name);
Assert.AreEqual(1.00, language.Score);
```

[moq]: https://github.com/Moq/moq4/
[moq_samples]: (https://github.com/Azure/azure-sdk-for-net/blob/master/sdk/textanalytics/Azure.AI.TextAnalytics/tests/samples/SampleMoq.cs)