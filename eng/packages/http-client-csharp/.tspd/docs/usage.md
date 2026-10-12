### Prerequisite

- Install [Node.js](https://nodejs.org/download/) 20 or above. (Verify by running `node --version`)
- Install [**.NET 10.0 SDK**](https://dotnet.microsoft.com/download/dotnet/10.0) for your specific platform. (or a higher version within the 10.0.* band)

### Customizing Generated Code

For detailed instructions on how to customize the generated C# code, see the [Customization Guide](https://github.com/microsoft/typespec/blob/main/packages/http-client-csharp/.tspd/docs/customization.md).

### Async pagination cancellation

Generated `AsyncPageable<T>` collections forward cancellation from `WithCancellation` or
`GetAsyncEnumerator` to each page request, including when enumerating `AsPages()`.
The enumeration token is combined with the token passed to the client method or its
protocol `RequestContext`, so either token can cancel an in-flight page request.
Each enumeration manages its own combined token without modifying the request context.