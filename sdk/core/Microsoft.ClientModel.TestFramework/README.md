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

This project welcomes contributions and suggestions. Most contributions require you to agree to a Contributor License Agreement (CLA) declaring that you have the right to, and actually do, grant us the rights to use your contribution. For details, visit https://cla.microsoft.com.

When you submit a pull request, a CLA-bot will automatically determine whether you need to provide a CLA and decorate the PR appropriately (e.g., label, comment). Simply follow the instructions provided by the bot. You will only need to do this once across all repositories using our CLA.

This project has adopted the [Microsoft Open Source Code of Conduct][code_of_conduct]. For more information see the [Code of Conduct FAQ][code_of_conduct_faq] or contact opencode@microsoft.com with any additional questions or comments.

[source]: https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/core/Microsoft.ClientModel.TestFramework/src
[code_of_conduct]: https://opensource.microsoft.com/codeofconduct
[code_of_conduct_faq]: https://opensource.microsoft.com/codeofconduct/faq/