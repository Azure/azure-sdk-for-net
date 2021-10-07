# Mock a client for testing using the Moq library

This sample illustrates how to use [Moq][moq] to create a unit test that mocks the response from a `TextAnalyticsClient` method. For more examples of mocking, see [Moq samples][moq_samples].

## Define method that uses TextAnalyticsClient
To show the usage of mocks, define a method that will be tested with mocked objects. For this case, we are going to create a method that will verify if a document is writen in Spanish.

```C# Snippet:MethodToTest
private static async Task<bool> IsSpanishAsync(string document, TextAnalyticsClient client, CancellationToken cancellationToken)
{
    DetectedLanguage language = await client.DetectLanguageAsync(document, default, cancellationToken);
    return language.Iso6391Name == "es";
}
```

## Create and setup mocks
To start, create a mock for the `TextAnalyticsClient` and `Response`.

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
Now, to validate if the document is in Spanish without making a network call, use `TextAnalyticsClient` mock.

```C# Snippet:UseMocks
TextAnalyticsClient client = mockClient.Object;
bool result = await IsSpanishAsync("Este documento está en español.", client, default);
Assert.IsTrue(result);
```

[moq]: https://github.com/Moq/moq4/
[moq_samples]: https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/textanalytics/Azure.AI.TextAnalytics/tests/samples/SampleMoq.cs