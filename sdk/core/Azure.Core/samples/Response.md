# Azure.Core Response samples

**NOTE:** Samples in this file apply only to packages that follow [Azure SDK Design Guidelines](https://azure.github.io/azure-sdk/dotnet_introduction.html). Names of such packages usually start with `Azure`.

Most client methods return one of the following types:

- `Response` - An HTTP response.
- `Response<T>` - A value and HTTP response.
- `Pageable<T>` - A collection of values retrieved synchronously in pages. See [Pagination with the Azure SDK for .NET](https://docs.microsoft.com/dotnet/azure/sdk/pagination).
- `AsyncPageable<T>` - A collection of values retrieved asynchronously in pages. See [Pagination with the Azure SDK for .NET](https://docs.microsoft.com/dotnet/azure/sdk/pagination).
- `*Operation<T>` - A long-running operation. See [long running operation samples](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md).

## Accessing HTTP response properties

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

## Accessing HTTP response content with ContentStream

```C# Snippet:ResponseTContent
// call a service method, which returns Response<T>
Response<KeyVaultSecret> response = await client.GetSecretAsync("SecretName");

Response http = response.GetRawResponse();

Stream contentStream = http.ContentStream;

// Rewind the stream
contentStream.Position = 0;

using (StreamReader reader = new StreamReader(contentStream))
{
    Console.WriteLine(reader.ReadToEnd());
}
```

## Accessing HTTP response well-known headers

You can access well known response headers via properties of `ResponseHeaders` object:

```C# Snippet:ResponseHeaders
// call a service method, which returns Response<T>
Response<KeyVaultSecret> response = await client.GetSecretAsync("SecretName");

Response http = response.GetRawResponse();

Console.WriteLine("ETag " + http.Headers.ETag);
Console.WriteLine("Content-Length " + http.Headers.ContentLength);
Console.WriteLine("Content-Type " + http.Headers.ContentType);
```

## Handling exceptions

When a service call fails `Azure.RequestFailedException` would get thrown. The exception type provides a Status property with an HTTP status code an an ErrorCode property with a service-specific error code.

```C# Snippet:RequestFailedException
try
{
    KeyVaultSecret secret = client.GetSecret("NonexistentSecret");
}
// handle exception with status code 404
catch (RequestFailedException e) when (e.Status == 404)
{
    // handle not found error
    Console.WriteLine("ErrorCode " + e.ErrorCode);
}
```

### Exception details

Some services may provide additional details when a service call fails. Apart from the error `Code` and `Message` that are part of the service contract, you should only use this information for diagnostics
since the values could change any time.

```C# Snippet:RequestFailedExceptionDetails
try
{
    KeyVaultSecret secret = client.SetSecret("DeletedSecret", "secret");
}
// handle exception with status code 404
catch (RequestFailedException e) when (e.Status == 409)
{
    ResponseError error = e.GetRawResponse().Content.ToObjectFromJson<ResponseError>();
    if (error.Code == "Conflict" &&
        (error.InnerError?.Code == "ObjectIsBeingDeleted" || error.InnerError?.Code == "ObjectIsDeletedButRecoverable"))
    {
        Console.WriteLine("Please try again with a different name.");
        return;
    }

    throw;
}
```
