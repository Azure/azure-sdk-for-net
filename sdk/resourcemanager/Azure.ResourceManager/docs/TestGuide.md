# Test .NET management plane SDK

## Frameworks

We use [NUnit 3][nunit] as our testing framework.

[Azure.Core.TestFramework's testing framework][core_tests] provides a set of reusable primitives that simplify writing tests for new Azure SDK libraries.

## Testing project structure

With the help of [Azure.ResourceManager.Template][mgmt_template], the basic testing project and file structure(see following for details) will be generated under `sdk\<service name>\Azure.ResourceManager.<service>\tests` directory.

```text
sdk\<service name>\Azure.ResourceManager.<service>\tests\Azure.ResourceManager.<service>.Tests.csproj
sdk\<service name>\Azure.ResourceManager.<service>\tests\<service>ManagementTestBase.cs
sdk\<service name>\Azure.ResourceManager.<service>\tests\<service>ManagementTestEnvironment.cs
sdk\<service name>\Azure.ResourceManager.<service>\tests\Scenario
sdk\<service name>\Azure.ResourceManager.<service>\tests\SessionRecords
```

**Note**: 

1.Considering that in Git directories exist implicitly, so you might need to create the `Scenario` and `SessionRecords` directories by yourself after cloning the repo.

2. The recording files under SessionRecords will eventually be migrated to the assets repository by the test proxy. For more details, please refer to [these steps](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/resourcemanager/Azure.ResourceManager/docs/TestGuide.md#test-proxy).

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
| AZURE_CLIENT_ID | TBD<sup>3</sup> | The Service Principal Application ID |
| AZURE_CLIENT_SECRET | TBD<sup>3</sup> | A Service Principal Authentication Key |
| AZURE_SUBSCRIPTION_ID | TBD<sup>3</sup> | The Azure Subscription ID |
| AZURE_TENANT_ID | TBD<sup>3</sup> | The AAD Tenant ID |

**Note**:

1. Our testing framework supports three different test modes: `Live`, `Playback`, `Record`. In management plane, please set the `AZURE_TEST_MODE` to `Record` for your first test run, this will record HTTP requests and responses and store the record files in `SessionRecords` folder. Properly supporting recorded tests does require a few extra considerations. All random values should be obtained via `this.Recording.Random` since we use the same seed on test playback to ensure our client code generates the same "random" values each time. You can't share any state between tests or rely on ordering because you don't know the order they'll be recorded or replayed. Any sensitive values are redacted via the [`ConfigurationRecordedTestSanitizer`][test_sanitizer]. After you have successfully recorded all the tests for the first time, you can change its value to `Playback`. If the tests locally fail due to recording session file mismatches at this point, the attribute `RecordedTest` will help enable automatically re-record failed tests.

2. You need to change its value depending on the Azure Cloud type you are using in your tests. `https://login.microsoftonline.com` only applies to Azure Public Cloud.

3. These values depend on the subscription and token credential you are using for testing. Please refer to this [document][authenticate] to get the values.

The easiest way to run the tests is via Visual Studio's test runner. Please note that the Visual Studio 2022 is required as one of the test target frameworks is `.NET 6.0`.

You can also run tests via the command line using `dotnet test`, but that will run tests for all supported platforms simultaneously and intermingle their output. You can run the tests for just one platform with `dotnet test -f net6.0` or `dotnet test -f net462`.

If you are using system environment variables, make sure to restart Visual Studio or the terminal after setting or changing the environment variables.

## Test proxy

Using the test proxy tool, migrate the local recording files to the external repository [azure-sdk-assets](https://github.com/Azure/azure-sdk-assets). Please refer to [this document](https://github.com/Azure/azure-sdk-tools/blob/main/tools/test-proxy/Azure.Sdk.Tools.TestProxy/README.md#installation) for the installation of the test proxy.

> If an RP's root directory contains an `assets.json` file, it means that all local recording files for that RP have been migrated to the `azure-sdk-assets` repo.

1. How to migrate recordings
 
The Engineering System team provided a PowerShell script that can be used to migrate recordings automatically, but it needs to be executed once for each package. To get the script and guidance on how to run it, see: [Transitioning recording assets from language repositories into azure-sdk-assets](https://nam06.safelinks.protection.outlook.com/?url=https%3A%2F%2Fgithub.com%2FAzure%2Fazure-sdk-tools%2Fblob%2Fmain%2Feng%2Fcommon%2Ftestproxy%2Ftransition-scripts%2FREADME.md&data=05%7C01%7Cv-minghc%40microsoft.com%7C884353a5d83a4f7daef608db6d61e24b%7C72f988bf86f141af91ab2d7cd011db47%7C1%7C0%7C638224039445940738%7CUnknown%7CTWFpbGZsb3d8eyJWIjoiMC4wLjAwMDAiLCJQIjoiV2luMzIiLCJBTiI6Ik1haWwiLCJXVCI6Mn0%3D%7C3000%7C%7C%7C&sdata=ZKJqiD58%2FC6LvkWrG1iY2%2F7dRSQarAXsO9se7ftl1pE%3D&reserved=0)

2. Running tests

After migrating the recording files, you can run the tests again or execute the following command to download the recording files from the remote repository to the local machine:
```
cd azure-sdk-for-net/sdk/{service}/{package}
test-proxy restore -a ./assets.json
```
The local recording files will be stored in `azure-sdk-for-net/.assets/{10-character}/net/sdk/{service}/{package}/tests/SessionRecords`.

3. Push the recording files to the assets repository.

```
cd azure-sdk-for-net/sdk/{service}/{package}
test-proxy push -a ./assets.json
```
The test-proxy push command will upload the corresponding SessionRecords files under `\.assets` and update the tag in `assets.json`.

After the push is complete, you can find the corresponding tag in the `Switch branches/tags` section of the [azure-sdk-assets](https://github.com/Azure/azure-sdk-assets) repo  to verify the recording files you uploaded.

## Samples

Our samples are structured as unit tests so we can easily verify they're up to date and working correctly. These tests aren't recorded and make minimal use of test infrastructure to keep them easy to read.

<!-- LINKS -->
[nunit]: https://docs.nunit.org/
[core_tests]: https://github.com/Azure/azure-sdk-for-net/tree/master/sdk/core/Azure.Core.TestFramework
[mgmt_template]: https://github.com/Azure/azure-sdk-for-net/tree/main/eng/templates/Azure.ResourceManager.Template
[test_sanitizer]: https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/core/Azure.Core.TestFramework#sanitizing
[authenticate]: https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/resourcemanager/Azure.ResourceManager/docs/AuthUsingEnvironmentVariables.md
