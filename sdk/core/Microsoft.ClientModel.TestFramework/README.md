# Microsoft.ClientModel.TestFramework

A testing framework for .NET client libraries using System.ClientModel.

## Features

- **Recorded Testing**: Record and replay HTTP requests for consistent, deterministic tests
- **Sync/Async Testing**: Test both synchronous and asynchronous code paths with a single test
- **Test Utilities**: Mock credentials, pipeline components, and other testing helpers
- **Test Proxy Integration**: Built-in support for Azure SDK test proxy

## Getting Started

```csharp
[ClientTestFixture]
public class MyClientTests : RecordedTestBase<MyTestEnvironment>
{
    [Test]
    public async Task TestMyClient()
    {
        var client = CreateClient();
        var result = await client.GetDataAsync();
        Assert.IsNotNull(result);
    }
}
```

## Contributing

This project is part of the Azure SDK for .NET. Please see the [Azure SDK Contributing Guide](https://github.com/Azure/azure-sdk-for-net/blob/main/CONTRIBUTING.md) for details.