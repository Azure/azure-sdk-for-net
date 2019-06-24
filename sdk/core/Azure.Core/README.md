# Overview 

Azure.Core provides shared primitives, abstractions, and helpers for .NET Azure SDK service client libraries. 
These shared APIs allow client libraries to expose common functionality in a consistent fashion, 
so that once you learn how to use these APIs in one client library, you will know how to use them in other client libraries.

The main shared concepts of Azure.Core (and so all Azure SDK libraries using Azure.Core) include:

1. Unified APIs for configuring service clients, e.g. configuring retries, logging.
2. Unified APIs for accessig HTTP responses.
3. Unified APis for consuming long running operations (LROs).
4. Unified APIs for consuming asynchronous enumerables and paging.
5. Unified exception hierarchy for reporting errors from service requests.
6. Abstractions for representing Azure SDK credentials.

The following sections will explain these shared concepts in more detail.

# Usage Scenarios and Samples

## Configuring Service Clients
Azure SDK client libraries typically expose one or more _service client_ types that 
are the main starting points for calling corresponding Azure services. 
You can easily find these client types as their names end with the word _Client_. 
For example, ```BlockBlobClient``` can be used to call storage blob services, 
and ```KeyClient``` can be used to access KeyVault service cryptographis keys. 

These client types can be instantiated by calling a relativelly simple contructor, 
or a constructor overload that takes various configuration options. 
These options are passed as a parameter that extends ```ClientOptions``` class exposed by Azure.Core.
Various service specific options are usually added to its subclasses, but a set of SDK-wide options are 
avaliable directly on ```ClientOptions```.

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

## Accessing HTTP Response
Comming soon ...

## Consuming Long Running Operations
Comming soon ...

## HttpPipeline

```csharp
public async Task HttpPipelineHelloWorld()
{
    // create http pipeline
    var options = new HttpPipeline.Options();
    HttpPipeline pipeline = HttpPipeline.Create(options, sdkName: "test", sdkVersion: "1.0");

    // create http message
    using (HttpMessage message = pipeline.CreateMessage(options, cancellation: default)) {

        // set message URI
        var uri = new Uri(@"https://raw.githubusercontent.com/Azure/azure-sdk-for-net/master/README.md");
        message.SetRequestLine(HttpVerb.Get, uri);

        // add headers
        message.AddHeader("Host", uri.Host);

        // send message
        await pipeline.SendMessageAsync(message).ConfigureAwait(false);

        // process response
        Response response = message.Response;
        if (response.Status == 200) {
            var reader = new StreamReader(response.ContentStream);
            string responseText = reader.ReadToEnd();
        }
        else throw new RequestFailedException(response);
    }       
}
```

# Installing
Nuget package Azure.Core avaliable on https://www.nuget.org/packages/Azure.Core/