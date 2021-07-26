# Azure.Core Response samples

**NOTE:** Samples in this file apply only to packages that follow [Azure SDK Design Guidelines](https://azure.github.io/azure-sdk/dotnet_introduction.html). Names of such packages usually start with `Azure`.

Most client methods return one of the following types:
 - `Response` -  an HTTP response
 - `Response<T>` -  a value and HTTP response
 - `Pageable<T>` -  a collection of values retrieved in pages
 - `AsyncPageable<T>` - a collection of values asynchronously retrieved in pages
 - `*Operation<T>` - a long-running operation see [long running operation samples](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md)

## Accessing HTTP response propreties

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

## Accessing HTTP response content

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

## Iterating over AsyncPageable using await foreach

This sample requires C# 8 compiler.

```C# Snippet:AsyncPageable
// call a service method, which returns AsyncPageable<T>
AsyncPageable<SecretProperties> allSecretProperties = client.GetPropertiesOfSecretsAsync();

await foreach (SecretProperties secretProperties in allSecretProperties)
{
    Console.WriteLine(secretProperties.Name);
}
```

## Iterating over AsyncPageable using while loop

If your project doesn't have C# 8.0 enabled you can still iterate over `AsyncPageable` using a `while` loop.

```C# Snippet:AsyncPageableLoop
// call a service method, which returns AsyncPageable<T>
AsyncPageable<SecretProperties> allSecretProperties = client.GetPropertiesOfSecretsAsync();

IAsyncEnumerator<SecretProperties> enumerator = allSecretProperties.GetAsyncEnumerator();
try
{
    while (await enumerator.MoveNextAsync())
    {
        SecretProperties secretProperties = enumerator.Current;
        Console.WriteLine(secretProperties.Name);
    }
}
finally
{
    await enumerator.DisposeAsync();
}
```

## Iterating over AsyncPageable pages

If you want to have control over receiving pages of values from the service use `AsyncPageable<T>.AsPages` method:

```C# Snippet:AsyncPageableAsPages
// call a service method, which returns AsyncPageable<T>
AsyncPageable<SecretProperties> allSecretProperties = client.GetPropertiesOfSecretsAsync();

await foreach (Page<SecretProperties> page in allSecretProperties.AsPages())
{
    // enumerate through page items
    foreach (SecretProperties secretProperties in page.Values)
    {
        Console.WriteLine(secretProperties.Name);
    }

    // get continuation token that can be used in AsPages call to resume enumeration
    Console.WriteLine(page.ContinuationToken);
}
```

## Using System.Linq.Async with AsyncPageable

The [`System.Linq.Async`](https://www.nuget.org/packages/System.Linq.Async) package provides a set of LINQ methods that operate on `IAsyncEnumerable<T>` type.
Because `AsyncPageable<T>` implements `IAsyncEnumerable<T>` you can use `System.Linq.Async` to easily query and transform the data.

### Convert to a `List<T>`

`ToListAsync` can be used to convert an `AsyncPageable` to a `List<T>`.  This might make several service calls if the data isn't returned in a single page.

```C# Snippet:SystemLinqAsyncToList
AsyncPageable<SecretProperties> allSecretProperties = client.GetPropertiesOfSecretsAsync();

// ToListAsync would convert asynchronous enumerable into a List<T>
List<SecretProperties> secretList = await allSecretProperties.ToListAsync();
```

### Take the first N elements

`Take` can be used to get only the first `N` elements of the `AsyncPageable`.  Using `Take` will make the fewest service calls required to get `N` items.

```C# Snippet:SystemLinqAsyncTake
AsyncPageable<SecretProperties> allSecretProperties = client.GetPropertiesOfSecretsAsync();

// Take would request enough pages to get 30 items
await foreach (var secretProperties in allSecretProperties.Take(30))
{
    Console.WriteLine(secretProperties.Name);
}
```

### More methods

`System.Linq.Async` provides other useful methods like `Select`, `Where`, `OrderBy`, `GroupBy`, etc. that provide functionality equivalent to their synchronous [`Enumerable` counterparts](https://docs.microsoft.com/dotnet/api/system.linq.enumerable).

### Beware client-side evaluation

`System.Linq.Async` LINQ operations are executed on the client so the following query would fetch all the items just to count them:

```C# Snippet:SystemLinqAsyncCount
// DANGER! DO NOT COPY: CountAsync as used here fetches all the secrets locally to count them.
int expensiveSecretCount = await client.GetPropertiesOfSecretsAsync().CountAsync();
```
The same warning applies to operators like `Where`.  Always prefer server-side filtering, aggregation, or projections of data if available.
## Iterating over pageable

`Pageable<T>` is a synchronous version of `AsyncPageable<T>`, it can be used with a normal `foreach` loop.

```C# Snippet:Pageable
// call a service method, which returns Pageable<T>
Pageable<SecretProperties> allSecretProperties = client.GetPropertiesOfSecrets();

foreach (SecretProperties secretProperties in allSecretProperties)
{
    Console.WriteLine(secretProperties.Name);
}
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
