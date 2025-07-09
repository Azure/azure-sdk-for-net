# Test .NET management plane SDK

## Frameworks

We use [NUnit 3][nunit] as our testing framework.

[Azure.Core.TestFramework's testing framework][core_tests] provides a set of reusable primitives that simplify writing tests for new Azure SDK libraries.

The installation of `Test proxy` is a prerequisite for running the tests. Please run the `test-proxy --version` to ensure that test proxy is installed on your computer. If it is not installed, Please refer to [this document](https://github.com/Azure/azure-sdk-tools/blob/main/tools/test-proxy/Azure.Sdk.Tools.TestProxy/README.md#installation) for the installation of the test proxy.

## Testing project structure

With the help of [Azure.ResourceManager.Template][mgmt_template], the basic testing project and file structure(see following for details) will be generated under `sdk\<service name>\Azure.ResourceManager.<service>\tests` directory.

```text
sdk\<service name>\Azure.ResourceManager.<service>\assets.json
sdk\<service name>\Azure.ResourceManager.<service>\tests\Azure.ResourceManager.<service>.Tests.csproj
sdk\<service name>\Azure.ResourceManager.<service>\tests\<service>ManagementTestBase.cs
sdk\<service name>\Azure.ResourceManager.<service>\tests\<service>ManagementTestEnvironment.cs
sdk\<service name>\Azure.ResourceManager.<service>\tests\Scenario
```

**Note**:

1. Considering that in Git directories exist implicitly, so you might need to create the `Scenario` directories by yourself after cloning the repo.

2. There is a reserved field `<service name>` in the `assets.json` file. Please replace it with the correct value before starting to write the tests. The `<service name>` is the path to the `assets.json` file, for example, in `\sdk\sqlmanagement\Azure.ResourceManager.Sql\assets.json`, `<service name>` would be `sqlmanagement`.

## Writing scenario tests

All the public APIs that are exposed to the customer need to be tested and they are distributed in the following three kinds of code files as shown below. Accordingly, you'd better put the tests of the same file's APIs in a separate file under the `Scenario` folder, thus facilitating the subsequent maintenance.

```text
sdk\<service name>\<package name>\src\Generated\Extensions\<service>Extensions.cs
sdk\<service name>\<package name>\src\Generated\<resource>Collection.cs
sdk\<service name>\<package name>\src\Generated\<resource>Resource.cs
```

For instance, if you want to test the `CreateOrUpdate` method in ExampleCollection.cs, the corresponding test file will be like:

```csharp
namespace Azure.ResourceManager.Service.Tests
{
    public class ExampleCollectionTests : ServiceManagementTestBase
    {
        public ExampleCollectionTests(bool isAsync)
            : base(isAsync)//, RecordedTestMode.Record)
        {
        }

        [TestCase]
        [RecordedTest]
        public async Task CreateOrUpdate()
        {
            SubscriptionResource subscription = await Client.GetDefaultSubscriptionAsync();
            ResourceGroupResource rg = await CreateResourceGroup(subscription, "testRg", AzureLocation.WestUS);
            string resourceName = Recording.GenerateAssetName("resource");
            ExampleResource resource = await rg.GetExamples().CreateOrUpdateAsync(WaitUntil.Completed, resourceName, new ExampleData());
            Assert.AreEqual(resourceName, resource.Data.Name);
        }
    }
}
```

We expose all of our APIs with both sync and async variants. To avoid writing each of our tests twice, the test framework automatically converts async API calls into their sync equivalents at runtime. Simply write your tests using only async APIs and the `Azure.Core.TestFramework` will wrap the client with a proxy that forwards everything to the sync overloads automatically. Visual Studio's test runner will show `*TestClass(True)` for the async variants and `*TestClass(False)` for the sync variants.

## Running tests

In order to run the tests, the following environment variables need to be set:

| Name | Value | Description |
| :--- | :---- | :---------- |
| AZURE_TEST_MODE | Record<sup>1</sup> | Specify in which mode the test will run |
| AZURE_AUTHORITY_HOST | https://login.microsoftonline.com<sup>2</sup> | The host of the Azure Active Directory authority |
| AZURE_SUBSCRIPTION_ID | TBD<sup>3</sup> | The Azure Subscription ID |
| AZURE_TENANT_ID | TBD<sup>3</sup> | The AAD Tenant ID |

**Note**:

1. Our testing framework supports three different test modes: `Live`, `Playback`, `Record`. In management plane, please set the `AZURE_TEST_MODE` to `Record` for your first test run, this will record HTTP requests and responses and store the record files in the `SessionRecords folder corresponding to the ./assets directory`. Properly supporting recorded tests does require a few extra considerations. All random values should be obtained via `this.Recording.Random` since we use the same seed on test playback to ensure our client code generates the same "random" values each time. You can't share any state between tests or rely on ordering because you don't know the order they'll be recorded or replayed. Any sensitive values are redacted via the [`ConfigurationRecordedTestSanitizer`][test_sanitizer]. After you have successfully recorded all the tests for the first time, you can change its value to `Playback`. If the tests locally fail due to recording session file mismatches at this point, the attribute `RecordedTest` will help enable automatically re-record failed tests.

2. Before initiating the Live and Record test, ensure that you are logged into your Azure account using either Azure CLI or Azure PowerShell.

3. You need to change its value depending on the Azure Cloud type you are using in your tests. `https://login.microsoftonline.com` only applies to Azure Public Cloud.

4. These values depend on the subscription you are using for testing. Please refer to this [document][env_variables] to get the values.

The easiest way to run the tests is via Visual Studio's test runner. Please note that the Visual Studio 2022 is required as one of the test target frameworks is `.NET 8.0`.

You can also run tests via the command line using `dotnet test`, but that will run tests for all supported platforms simultaneously and intermingle their output. You can run the tests for just one platform with `dotnet test -f net8.0` or `dotnet test -f net462`.

If you are using system environment variables, make sure to restart Visual Studio or the terminal after setting or changing the environment variables.

## Test proxy

The local recording files will be stored in `azure-sdk-for-net/.assets/{10-character}/net/sdk/{service name}/{service}/tests/SessionRecords`.

1. Restore recording files

If the value of the "tag" field is not empty in the `assets.json` file, it means that the service has recording files in the remote repository. You can use the following command or playback any cases to download them to your local machine.

```shell
cd azure-sdk-for-net/sdk/{service}/{package}
test-proxy restore -a ./assets.json
```

2. Run tests

The recording files generated during the testing will be directly saved to the SessionRecords directory under the `/.assets` folder. Similarly, the playback will also use the recording files in the same directory.

3. Push the recording files to the assets repository.

```shell
cd azure-sdk-for-net/sdk/{service}/{package}
test-proxy push -a ./assets.json
```

**[Note]**: Before you push to the assets repository, make sure you have the correct privilege. Check the guide [here](https://dev.azure.com/azure-sdk/internal/_wiki/wikis/internal.wiki/785/Externalizing-Recordings-(Asset-Sync)?anchor=permissions-to-%60azure/azure-sdk-assets%60).

The test-proxy push command will upload the corresponding SessionRecords files under the `/.assets` folder and update the tag in `assets.json`.

After the push is complete, you can find the corresponding tag in the `Switch branches/tags` section of the [azure-sdk-assets](https://github.com/Azure/azure-sdk-assets) repo  to verify the recording files you uploaded.

## Samples

Our samples are structured as unit tests so we can easily verify they're up to date and working correctly. These tests aren't recorded and make minimal use of test infrastructure to keep them easy to read.

<!-- LINKS -->
[nunit]: https://docs.nunit.org/
[core_tests]: https://github.com/Azure/azure-sdk-for-net/tree/master/sdk/core/Azure.Core.TestFramework
[mgmt_template]: https://github.com/Azure/azure-sdk-for-net/tree/main/eng/templates/Azure.ResourceManager.Template
[test_sanitizer]: https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/core/Azure.Core.TestFramework#sanitizing
[env_variables]: https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/resourcemanager/Azure.ResourceManager/docs/AuthUsingEnvironmentVariables.md
