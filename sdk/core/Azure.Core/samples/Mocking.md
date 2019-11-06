# Azure.Core mocking samples

**NOTE:** Samples in this file apply only to packages that follow [Azure SDK Design Guidelines](https://azure.github.io/azure-sdk/dotnet_introduction.html). Names of such packages usually start with `Azure`. 

## Creating a mock of the client using Moq

You can use a combination of model factory and `Mock` class to create a mock of a client:

```C# Snippet:ClientMock
// Create a mock response
var mockResponse = new Mock<Response>();

// Create a mock value
var mockValue = SecretModelFactory.KeyVaultSecret(
    SecretModelFactory.SecretProperties(new Uri("http://example.com"))
);

// Create a client mock
var mock = new Mock<SecretClient>();

// Setup client method
mock.Setup(c => c.GetSecret("Name", null, default))
    .Returns(Response.FromValue(mockValue, mockResponse.Object));

// Use the client mock
SecretClient client = mock.Object;
KeyVaultSecret secret = client.GetSecret("Name");
```
