# Overview 

Azure.Core provides shared primitives, abstractions, and helpers for .NET Azure SDK service client libraries. 
These shared APIs allow client libraries to expose common functionality in a consistent fashion, 
so that once you learn how to use these APIs in one client library, you will know how to use them in other client libraries.

The main shared concepts of Azure.Core (and so all Azure SDK libraries using Azure.Core) include:

1. Unified APIs for configuring service clients, e.g. configuring retries, logging.
2. Unified APIs for accessing HTTP responses.
3. Unified APIs for consuming long running operations (LROs).
4. Unified APIs for consuming asynchronous streams (```IAsyncEnumerable<T>```) by paging.
5. Unified exception hierarchy for reporting errors from service requests.
6. Abstractions for representing Azure SDK credentials.

The following sections will explain these shared concepts in more detail.

# Usage Scenarios and Samples

## Configuring Service Clients Using ```ClientOptions```
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
    options.RetryPolicy.Delay = TimeSpan.FromSeconds(1); // derfault is 0.8s

    // finally create BlobContainerClient, but many Azure SDK clients will work similarly
    var client = new BlobContainerClient(connectionString, "container", options);
}
```

## Accessing HTTP Response Details Using ```Response<T>```
_Service clients_ have methods that can be used to call Azure services. 
We refer to these client methods _service methods_.
_Service methods_ return a shared Azure.Core type ```Response<T>``` (in rare cases its non-generic sibling ```Response```).
This type provides access to both the deserialized result of the service call, 
and to the details of the HTTP response returned from the server.

```csharp
public async Task UsingResponseOfT()
{
    // create a client
    var client = new BlobContainerClient(connectionString, "container");

    // call a service method, which returns Response<T>
    Response<ContainerItem> response = await client.GetPropertiesAsync();

    // Response<T> has two main accessors. 
    // Value property for accessing the deserialized result of the call
    ContainerItem container = response.Value;

    // .. and GetRawResponse method for accessing all the details of the HTTP response
    Response http = response.GetRawResponse();

    // for example, you can access HTTP status
    int status = http.Status;

    // or the headers
    foreach(HttpHeader header = http.Headers) {
        Console.WriteLine($"{header.Name} {header.Value}");
    }

    // or the stream of the response content
    Stream content = http.ContentStream;

    // but, if you are not interested in all HTTP details, 
    // and just want the result of the service call,
    // Response<T> provides a cast to get you directly to the result
    ContainerItem result = await client.GetPropertiesAsync();
}
```

## Consuming Service Methods Returning ```IAsyncEnumerable<T>```
Coming soon ...

## Consuming Long Running Operations Using ```OperationT<T>```
Comming soon ...

# Installing
Typically, you will not need to install Azure.Core; 
it will be installed for you when you install one of the client libraries using it. 
In case you want to install it explicitly (to implement your own client library, for example), 
you can find the NuGet package [here](https://www.nuget.org/packages/Azure.Core).