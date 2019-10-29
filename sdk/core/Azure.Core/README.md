# Azure.Core shared library for .NET

Azure.Core provides shared primitives, abstractions, and helpers for modern .NET Azure SDK client libraries. 
These libraries follow the [Azure SDK Design Guidelines for .NET](https://azuresdkspecs.z5.web.core.windows.net/DotNetSpec.html) 
and can be easily identified by package and namespaces names starting with 'Azure', e.g. ```Azure.Storage.Blobs```. 
A more complete list of client libraries using Azure.Core can be found [here](https://github.com/Azure/azure-sdk-for-net#core-services). 

Azure.Core allows client libraries to expose common functionality in a consistent fashion, 
so that once you learn how to use these APIs in one client library, you will know how to use them in other client libraries.

The main shared concepts of Azure.Core (and so Azure SDK libraries using Azure.Core) include:

- Configuring service clients, e.g. configuring retries, logging.
- Accessing HTTP response details.
- Calling long running operations (LROs).
- Paging and asynchronous streams (```AsyncPageable<T>```) 
- Exceptions for reporting errors from service requests in a consistent fashion.
- Abstractions for representing Azure SDK credentials.

Below, you will find sections explaining these shared concepts in more detail.

## Installing
Typically, you will not need to install Azure.Core; 
it will be installed for you when you install one of the client libraries using it. 
In case you want to install it explicitly (to implement your own client library, for example), 
you can find the NuGet package [here](https://www.nuget.org/packages/Azure.Core).

## Usage Scenarios and Samples

### Configuring Service Clients Using ```ClientOptions```
Azure SDK client libraries typically expose one or more _service client_ types that 
are the main starting points for calling corresponding Azure services. 
You can easily find these client types as their names end with the word _Client_. 
For example, ```BlockBlobClient``` can be used to call blob storage service, 
and ```KeyClient``` can be used to access KeyVault service cryptographic keys. 

These client types can be instantiated by calling a simple constructor, 
or its overload that takes various configuration options. 
These options are passed as a parameter that extends ```ClientOptions``` class exposed by Azure.Core.
Various service specific options are usually added to its subclasses, but a set of SDK-wide options are 
available directly on ```ClientOptions```.

```csharp
public void ConfigureServiceClient()
{
    // BlobConnectionOptions inherits/extends ClientOptions
    ClientOptions options = new BlobConnectionOptions();     
    
    // configure retries
    options.RetryPolicy.MaxRetries = 5; // default is 3
    options.RetryPolicy.Mode = RetryMode.Exponential; // default is fixed retry policy
    options.RetryPolicy.Delay = TimeSpan.FromSeconds(1); // default is 0.8s

    // finally create BlobContainerClient, but many Azure SDK clients will work similarly
    var client = new BlobContainerClient(connectionString, "container", options);

    // if you don't specify the options, default options will be used, e.g.
    var clientWithDefaultOptions = new BlobContainerClient(connectionString, "container");
}
```

### Accessing HTTP Response Details Using ```Response<T>```
_Service clients_ have methods that can be used to call Azure services. 
We refer to these client methods _service methods_.
_Service methods_ return a shared Azure.Core type ```Response<T>``` (in rare cases its non-generic sibling, a raw ```Response```).
This type provides access to both the deserialized result of the service call, 
and to the details of the HTTP response returned from the server.

```C# Snippet:ResponseTHelloWorld
// create a client
var client = new SecretClient(new Uri("http://example.com"), new DefaultAzureCredential());

// call a service method, which returns Response<T>
Response<KeyVaultSecret> response = await client.GetSecretAsync("SecretName");

// Response<T> has two main accessors.
// Value property for accessing the deserialized result of the call
KeyVaultSecret secret = response.Value;

// .. and GetRawResponse method for accessing all the details of the HTTP response
Response http = response.GetRawResponse();

// for example, you can access HTTP status
int status = http.Status;

// or the headers
foreach (HttpHeader header in http.Headers)
{
    Console.WriteLine($"{header.Name} {header.Value}");
}
```

### Mocking
One of the most important cross-cutting features of our new client libraries using Azure.Core is that they are designed for mocking. 
Mocking is enabled by:

- providing a protected parameterless constructor on client types.
- making service methods virtual.
- providing APIs for constructing model types returned from virtual service methods. To find these factory methods look for types with the _ModelFactory_ suffix, e.g. `SecretModelFactory`.

For example, the ConfigurationClient.Get method can be mocked (with [Moq](https://github.com/moq/moq4)) as follows:

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

### Setting up console logging

```C# Snippet:ConsoleLogging
// Setup a listener to monitor logged events.
using AzureEventSourceListener listener = AzureEventSourceListener.CreateConsoleLogger();
```

### Reporting Errors ```RequestFailedException```
Coming soon ...

### Consuming Service Methods Returning ```AsyncPageable<T>```

``` C# Snippet:AsyncPageable
```

### Consuming Long Running Operations Using ```Operation<T>```
Comming soon ...
