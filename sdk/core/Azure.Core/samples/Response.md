# Azure.Core Response samples

**NOTE:** Samples in this file apply only to packages that follow [Azure SDK Design Guidelines](https://azure.github.io/azure-sdk/dotnet_introduction.html). Names of such packages usually start with `Azure`.

Most client methods return one of the following types:
 - `Response` -  an HTTP response
 - `Response<T>` -  a value and HTTP response
 - `Pageable<T>` -  a collection of values retrieved in pages
 - `AsyncPageable<T>` - a collection of values asyncrounosly retrieved in pages
 - `*Operation<T>` - a long-running operation see [long running operation samples](LongRunningOperations.md)

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

## Iterating over pageable

`Pageable<T>` is a syncronous version of `AsyncPageable<T>`, it can be used with a normal `foreach` loop.

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
