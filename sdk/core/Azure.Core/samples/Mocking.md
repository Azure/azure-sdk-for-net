# Azure.Core mocking samples

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
