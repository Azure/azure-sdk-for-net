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

## Creating a mock of the method that returns Pageable

For methods that return instances of `Pageable` or `AsyncPageable`, `Mock` can be used to create an instance of type that is derived from these classes:

```C# Snippet:ClientMockWithPageable
// Create a client mock
var mock = new Mock<SecretClient>();

// Create a Page
var deletedValue = SecretModelFactory.DeletedSecret(
    SecretModelFactory.SecretProperties(new Uri("http://example.com"))
);
var pageValues = new[] { deletedValue };
var page = Page<DeletedSecret>.FromValues(pageValues, default, new Mock<Response>().Object);

// Create a mock for the Pageable
var pageableMock = new Mock<Pageable<DeletedSecret>> { CallBase = true };

// Setup AsPages method in the Pageable mock
pageableMock.Setup(c => c.AsPages(It.IsAny<string>(), default))
    .Returns(new[] { page });

// Setup client method that returns Pageable
mock.Setup(c => c.GetDeletedSecrets(default))
    .Returns(pageableMock.Object);

// Use the client mock
SecretClient client = mock.Object;
DeletedSecret deletedSecret = client.GetDeletedSecrets().First();
```
