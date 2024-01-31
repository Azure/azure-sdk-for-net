# .NET Azure SDK Test Framework

The .NET Azure SDK Test Framework, aka the Test Framework, is a set of classes that help you to write tests against the Azure SDK for .NET. It provides support for both recorded tests and unit tests. The Test Framework uses NUnit as its underlying testing framework. All Track 2 libraries (Azure.* naming) should use the Test Framework for their tests.

## Using the TestFramework

To start using the Test Framework, add a project reference using the alias `AzureCoreTestFramework` into your test `.csproj`:

``` xml
<Project Sdk="Microsoft.NET.Sdk">

...
   <ProjectReference Include="$(AzureCoreTestFramework)" />
...

</Project>
```

As an example, see the [Template](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/template/Azure.Template/tests/Azure.Template.Tests.csproj#L15) project. If you create a new project from the template, the Test Framework will be already referenced.

## Sync-async tests

The Test Framework provides the ability to write tests using async client methods and automatically run them using sync overloads. This means that you don't need to duplicate tests to cover calling both the sync and async overloads of service client methods. To write sync-async client tests, inherit from `ClientTestBase` class and use the `InstrumentClient` method to wrap your client into a proxy class. In addition to running the async tests as written, this proxy class will automatically create sync versions of the tests by forward async calls to their sync overloads.

``` C#
public class ConfigurationLiveTests: ClientTestBase
{
    public ConfigurationLiveTests(bool isAsync) : base(isAsync)
    {
    }

    private ConfigurationClient GetClient() =>
        InstrumentClient(
            new ConfigurationClient(
                ...,
                InstrumentClientOptions(
                    new ConfigurationClientClientOptions())));

    public async Task DeleteSettingNotFound()
    {
        ConfigurationClient service = GetClient();

        var response = await service.DeleteAsync("Setting");

        Assert.AreEqual(204, response.Status);
        response.Dispose();
    }
}
```

In the test explorer, async tests will display as `TestClassName(true)` and sync tests as `TestClassName(false)`.

You can disable the sync-forwarding for an individual test by applying the `[AsyncOnly]` attribute to the test method.

__Limitation__: all method calls/properties that are being used have to be `virtual`.

## Recorded tests

The bulk of the functionality of the Test Framework is around supporting the ability to run what we call recorded tests. This type of test can be thought of as a functional test as opposed to a unit test. A recorded test can be run in three different [modes](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core.TestFramework/src/RecordedTestMode.cs):
  - `Live` - The requests in the tests are run against live Azure resources.
  - `Record` - This is the same as live mode with one key difference - the HTTP traffic from your tests is saved locally on your machine in the form of session files. When using sync-async tests (which is the default behavior unless specifying `SyncOnly` or `AsyncOnly` attributes) with recorded tests two sessions files will be generated - the async test session will have `Async.json` suffix.
  - `Playback` - The requests that your library generates when running a test are compared against the requests in the recording for that test. For each matched request, the corresponding response is extracted from the recording and "played back" as the response. The test will fail if a request issued by the library cannot be matched to the ones found in the session file, taking into account any [sanitization](#sanitizing) or [matching](#matching) customizations that may have been applied to the request.

Under the hood, when tests are run in `Playback` or `Record` mode, requests are forwarded to the [Test Proxy](https://github.com/Azure/azure-sdk-tools/blob/main/tools/test-proxy/Azure.Sdk.Tools.TestProxy/README.md). The test proxy is a proxy server that runs locally on your machine automatically when in `Record` or `Playback` mode. The proxy is responsible for saving the requests and responses when running in `Record` mode and for returning the recorded responses when running in `Playback` mode. The proxy should be mostly transparent to the developer, other than when you are trying to [debug](#debugging-test-proxy).

### Test resource creation and TestEnvironment

In order to actually run recorded tests in `Live` or `Record` mode, you will need Azure resources that the test can run against. Follow the [live test resources management](https://github.com/azure/azure-sdk-for-net/tree/main/eng/common/TestResources/README.md) to create a live test resources deployment template and get it deployed. The deployment template should be named `test-resources.json`, or for bicep templates, `test-resources.bicep`, and will live in the root of your service directory.

When running tests in `Live` or `Record` mode locally, the Test Framework will prompt you to create the live test resources required for the tests if you don't have environment variables or an env file containing the required variables needed for the tests. This means that you do not have to manually run the New-TestResources script when attempting to run live tests! The Test Framework will also attempt to automatically extend the expiration of the test resource resource group whenever live tests are run. If the resource group specified in your .env file or environment variable has already expired and thus been deleted, the framework will prompt you to create a new resource group just like it would if an env variable required by the test was missing.

To access the variables output from your test-resources template, create a class that inherits from `TestEnvironment` and exposes required values as properties:

``` C#
public class AppConfigurationTestEnvironment : TestEnvironment
{
    // Variables retrieved using GetRecordedVariable will be recorded in recorded tests
    // Argument is the output name in the test-resources.json
    public string Endpoint => GetRecordedVariable("APPCONFIGURATION_ENDPOINT");
    // Variables retrieved using GetVariable will not be recorded but the method will throw if the variable is not set
    public string SystemAssignedVault => GetVariable("IDENTITYTEST_TEST_SYSTEMASSIGNEDVAULT");
}
```

__NOTE:__ Make sure that variables containing secret values are not recorded or are sanitized. If you accidentally leak a secret, follow the guidance [here](https://dev.azure.com/azure-sdk/internal/_wiki/wikis/internal.wiki/101/Leaked-secret-procedure).

To sanitize variables use the `options` parameter of `GetRecordedVariable`:

``` C#
    // HasSecretConnectionStringParameter would ensure the right connection string parameter is sanitized before storing the record
    public string ConnectionString => GetRecordedVariable("APPCONFIGURATION_CONNECTION_STRING", options => options.HasSecretConnectionStringParameter("secret"));
    // IsSecret would ensure the entire value is sanitized before storage
    public string Key => GetRecordedVariable("APPCONFIGURATION_KEY", options => options.IsSecret());
```

If the client expects a Base64 secret value use the `SanitizedValue` parameter to use a Base64 compatible replacement value:

``` C#
    // Connection string parameter would be replaced with Kg==
    public string ConnectionString => GetRecordedVariable("APPCONFIGURATION_CONNECTION_STRING", options => options.HasSecretConnectionStringParameter("secret", SanitizedValue.Base64));
    // Secret value would be replaced with Kg==
    public string Key => GetRecordedVariable("APPCONFIGURATION_KEY", options => options.IsSecret(SanitizedValue.Base64));
```

You can now retrieve these values in tests:

``` C#
public class ConfigurationLiveTests : RecordedTestBase<AppConfigurationTestEnvironment>
{
    [Test]
    public async Task DeleteSetting()
    {
        var connectionString = TestEnvironment.ConnectionString;
        var password = TestEnvironment.TestPassword;
        //...
    }
}
```

And samples:

``` C#
public partial class ConfigurationSamples: SamplesBase<AppConfigurationTestEnvironment>
{
    [Test]
    public void HelloWorld()
    {
        var connectionString = TestEnvironment.ConnectionString;

        #region Snippet:AzConfigSample1_CreateConfigurationClient
        var client = new ConfigurationClient(connectionString);
        #endregion
    }
}
```

If resources require some time to become eventually consistent and there's a scenario that can be used to detect if asynchronous process completed
then you can consider implementing `TestEnvironment.IsEnvironmentReadyAsync`. The Test Framework will probe the scenario couple of times before starting tests or
fail the test run if resources don't become available:

``` C#
public class AppConfigurationTestEnvironment : TestEnvironment
{
    // in addition to other members
    protected override async ValueTask<bool> IsEnvironmentReadyAsync()
    {
        var connectionString = TestEnvironment.ConnectionString;
        var client = new ConfigurationClient(connectionString);
        try
        {
            await service.GetConfigurationSettingAsync("Setting");
        }
        catch (RequestFailedException e) when (e.Status == 403)
        {
            return false;
        }
        return true;
    }
}
```

### Defining the recorded test class

To use recorded test functionality, define a class that inherits from the `RecordedTestBase<T>` class and use the `InstrumentClientOptions` method when creating the client instance. Pass the test environment class as the generic argument to `RecordedTestBase<T>`. If any tests should not be recorded, e.g. because the recording would be too large, apply the `LiveOnly` attribute at either the test or class level, as appropriate. These instances should be rare - the goal is to have all recorded tests run in all modes.

``` C#
public class ConfigurationLiveTests: RecordedTestBase<AppConfigurationTestEnvironment>
{
    public ConfigurationLiveTests(bool isAsync) : base(isAsync)
    {
    }

    private ConfigurationClient GetClient() =>
        InstrumentClient(
            new ConfigurationClient(
                ...,
                InstrumentClientOptions(
                    new ConfigurationClientClientOptions())));
    }

    public async Task DeleteSettingNotFound()
    {
        ConfigurationClient service = GetClient();

        var response = await service.DeleteAsync("Setting");

        Assert.AreEqual(204, response.Status);
        response.Dispose();
    }
}
```

By default tests are run in playback mode. To change the mode use the `AZURE_TEST_MODE` environment variable and set it to one of the following values: `Live`, `Playback`, `Record`.

In development scenarios where it's required to change mode quickly without restarting Visual Studio, use the two-parameter constructor of `RecordedTestBase` to change the mode, or use the `.runsettings` file as described [here](#test-settings).

Recorded tests can be attributed with the `RecordedTestAttribute` in lieu of the standard `TestAttribute` to enable functionality to automatically re-record tests that fail due to recording session file mismatches.
Tests that are auto-rerecorded will fail with the following error and succeed if re-run.

```text
Error Message:
   Test failed playback, but was successfully re-recorded (it should pass if re-run). Please copy updated recording to SessionFiles.
```

``` C#
public class ConfigurationLiveTests: RecordedTestBase<AppConfigurationTestEnvironment>
{
    public ConfigurationLiveTests(bool isAsync) : base(isAsync, RecordedTestMode.Record)
    {
        [RecordedTest]
        public void MyTest()
        {
            //...
        }
    }
}
```

In addition to the auto-rerecording functionality, using the RecordedTestAttribute also will automatically retry tests that fail due due to exceeding the global test time limit.

### Recording

Because of the quick growth of the repo size due to the presence of recordings, currently there is an ongoing effort to migrate them to the [Azure SDK Assets](https://github.com/Azure/azure-sdk-assets) repo. The location where session records are stored in your machine depends on whether migration already took place for your project or not.

For projects whose recordings have not been migrated yet, when tests are run in `Record` mode, session records are saved to the project directory automatically in a folder named 'SessionRecords'. The recordings contained in this folder must be pushed normally.

For projects whose recordings have already been migrated, when tests are run in `Record` mode, session records are saved in a local folder named '.assets', located at the root of this repo. This folder will be created automatically by the Test Framework and should not be committed with other changes. Instead, recordings must be pushed manually to the Azure SDK Assets repo with the help of the `test-proxy` command line tool.

To differentiate between the two types of projects, you just need to look for an `assets.json` file at your package directory. The file is only present if migration has taken place.

#### Installing the test-proxy tool

This step is only relevant if your project had its recordings migrated to the Azure SDK Assets repo.

In order to push new session records, you must have the `test-proxy` command line tool installed. It can be installed automatically when running the Test Framework in `Record` mode on Windows. You can check the installed version by invoking:
```PowerShell
test-proxy --version
```

If you need to install the `test-proxy` tool manually, check [Azure SDK Tools Test Proxy
](https://github.com/Azure/azure-sdk-tools/blob/main/tools/test-proxy/Azure.Sdk.Tools.TestProxy/README.md#installation) for installation options.

#### Pushing session records and updating assets.json

This step is only relevant if your project had its recordings migrated to the Azure SDK Assets repo.

The `assets.json` file located at your package directory is used by the Test Framework to figure out how to retrieve session records from the assets repo. In order to push new session records, you need to invoke:
```PowerShell
test-proxy push -a <path-to-assets.json>
```

On completion of the push, a newly created tag will be stamped into the `assets.json` file. This new tag must be committed and pushed to your package directory along with any other changes.

**NOTE**: Permission is required for updating the assets repository. If you failed when executing `test-proxy push` command, please [join a partner write team](https://dev.azure.com/azure-sdk/internal/_wiki/wikis/internal.wiki/785/Externalizing-Recordings-(Asset-Sync)?anchor=permissions-to-%60azure/azure-sdk-assets%60). Please notice that this is "Microsoft Internal", community contributors will need to work with the pull request reviewers to merge the assets.

### Sanitizing

Secrets that are part of requests, responses, headers, or connections strings should be sanitized before saving the record.
__Do not check in session records containing secrets.__ Common headers like `Authentication` are sanitized automatically, but if custom logic is required and/or if request or response body need to be sanitized, several properties of `RecordedTestBase` can be used to customize the sanitization process.

For example:

```C#
public class ConfigurationLiveTests: RecordedTestBase<AppConfigurationTestEnvironment>
{
    public ConfigurationLiveTests()
    {
        SanitizedHeaders.Add("example-header");
        SanitizeQueryParameters.Add("example-query-parameter");
    }
}
```

Another sanitization feature that is available involves sanitizing Json payloads.
By adding a [Json Path](https://www.newtonsoft.com/json/help/html/QueryJsonSelectToken.htm) formatted string to the `JsonPathSanitizers` property, you can sanitize the value for a specific JSON property in request/response bodies.

By default, the following values are added to the `JsonPathSanitizers` to be sanitized: `primaryKey`, `secondaryKey`, `primaryConnectionString`, `secondaryConnectionString`, and `connectionString`.

```c#
public class FormRecognizerLiveTests: RecordedTestBase<FormRecognizerTestEnvironment>
{
    public FormRecognizerLiveTests()
    {
        JsonPathSanitizers.Add("$..accessToken");
        JsonPathSanitizers.Add("$..source");
    }
}
```

If more advanced sanitization is needed, you can use any of the regex-based sanitizer properties of `RecordedTestBase`. These are listed below along with example usages.
- [BodyKeySanitizers](https://grep.app/search?q=BodyKeySanitizers&filter[repo][0]=Azure/azure-sdk-for-net)
- [BodyRegexSanitizers](https://grep.app/search?q=BodyRegexSanitizers&filter[repo][0]=Azure/azure-sdk-for-net)
- [UriRegexSanitizers](https://grep.app/search?q=UriRegexSanitizers&filter[repo][0]=Azure/azure-sdk-for-net)
- [HeaderRegexSanitizers](https://grep.app/search?q=HeaderRegexSanitizers&filter[repo][0]=Azure/azure-sdk-for-net)

_Note that when using any of the regex sanitizers, you must take care to ensure that the regex is specific enough to not match unintended values. When a regex is too broad and matches unintended values, this can result in the request or response being corrupted which may manifest in a `JsonReaderException`._

### Matching

When tests are run in `Playback` mode, the Test Proxy uses the HTTP method, Uri, and headers to match the request to the recordings. Some headers change on every request and are not controlled by the client code and should be ignored during matching. Common headers like `Date`, `x-ms-date`, `x-ms-client-request-id`, `User-Agent`, `Request-Id` are ignored by default but if more headers need to be ignored, use the various matching properties to customize as needed.

``` C#
    public class ConfigurationLiveTests: RecordedTestBase<AppConfigurationTestEnvironment>
    {
        public ConfigurationLiveTests()
        {
            IgnoredHeaders.Add("Sync-Token");
            IgnoredQueryParameters.Add("service-version");
        }
    }
```

### Running live tests serially

By default, NUnit does not run tests within each assembly in parallel, but this can be [configured](https://docs.nunit.org/articles/nunit/technical-notes/usage/Framework-Parallel-Test-Execution.html).
Especially for unit tests, this is often desirable; however, live and [recorded tests](#recorded-tests) may run into some issues. Thus, by default, the `RecordedTestBase` described below is attributed
as `[NonParallelizable]`.

However, when projects are built and tested in CIs, all projects are testing in parallel. This means, for example, you can have two or more assemblies running tests such as one backing up or restoring
a resource while another assembly's tests are trying to use that resource. The service may return an error like HTTP 409.

To isolate one or more projects so that they are tested serially, add a _service.projects_ file to your service directory e.g., _sdk/keyvault/service.projects_ with content like the following to set the
`TestInParallel` metadata to `false`:

```xml
<Project>
  <ItemGroup>
    <ProjectReference Update="$(MSBuildThisFileDirectory)Azure.Security.KeyVault.Administration/tests/*.csproj">
        <TestInParallel>false</TestInParallel>
    </ProjectReference>
  </ItemGroup>
</Project>
```

### TokenCredential

If a test or sample uses `TokenCredential` to construct the client use `TestEnvironment.Credential`. This will ensure that the service principal used to provision the test resources will be used to authorize the service requests when running in `Record` mode.

``` C#
public abstract class KeysTestBase : RecordedTestBase<KeyVaultTestEnvironment>
{
    internal KeyClient GetClient() =>
        InstrumentClient(
            new KeyClient(
                new Uri(TestEnvironment.KeyVaultUrl),TestEnvironment.Credential,
                InstrumentClientOptions(
                    new KeyClientOptions())));
}
```

### Ignoring intermittent service errors

If your live tests are impacted by temporary or intermittent services errors, be sure the service team is aware and has a plan to address the issues.
If these issues cannot be resolved, you can attribute test classes or test methods with `[IgnoreServiceError]` which takes a required HTTP status code, Azure service error, and optional error message substring.
This attribute, when used with `RecordedTestBase`-derived test fixtures`, will mark tests that failed with that specific error as "inconclusive", along with an optional reason you specify and the original error information.

### Debugging Test Proxy

The Test Proxy and Test Framework include detailed error messages for test failures. However, there will  always be times where it is necessary to debug to figure out what is going wrong, particularly if the issue actually exists in the Test Framework or Test Proxy code rather than in your test or client library.

In order to enable debug mode, set the `UseLocalDebugProxy` property to true in your class that inherits from `RecordedTestBase`:

```C#
public KeyClientLiveTests(bool isAsync, KeyClientOptions.ServiceVersion serviceVersion)
    : this(isAsync, serviceVersion, null /* RecordedTestMode.Record /* to re-record */)
{
    UseLocalDebugProxy = true;
}
```

__Note:__ A user can set the environment variable PROXY_DEBUG_MODE to a truthy value prior to invoking, just like if they set `UseLocalDebugProxy` in their code.

In order to debug the test proxy, you will need to clone the [azure-sdk-tools](https://github.com/Azure/azure-sdk-tools) repo. The best practice is to first create a fork of the repo, and then clone your fork locally.

Once you have cloned the repo, open the [Test Proxy solution](https://github.com/Azure/azure-sdk-tools/blob/main/tools/test-proxy/Azure.Sdk.Tools.TestProxy.sln) in your IDE.

If you are attempting to debug `Playback` mode, set a breakpoint in the HandlePlaybackRequest method of [RecordingHandler](https://github.com/Azure/azure-sdk-tools/blob/main/tools/test-proxy/Azure.Sdk.Tools.TestProxy/RecordingHandler.cs). If you are attempting to debug `Record` mode, set a breakpoint in the `HandleRecordRequestAsync` method of [RecordingHandler](https://github.com/Azure/azure-sdk-tools/blob/main/tools/test-proxy/Azure.Sdk.Tools.TestProxy/RecordingHandler.cs). It may also be helpful to put breakpoints in [Admin.cs](https://github.com/Azure/azure-sdk-tools/blob/main/tools/test-proxy/Azure.Sdk.Tools.TestProxy/Admin.cs) to verify that your sanitizers are being added as expected.

With your breakpoints set, run the Test Proxy project, and then run your test that you are trying to debug. You should see your breakpoints hit.

The key integration points between the Test Framework and the Test Proxy are:
 - InstrumentClientOptions method of `RecordedTestBase` - calling this on your client options will set the [ClientOptions.Transport property](https://learn.microsoft.com/dotnet/api/azure.core.clientoptions.transport?view=azure-dotnet) to be [ProxyTransport](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core.TestFramework/src/ProxyTransport.cs) to your client options when in `Playback` or `Record` mode. The ProxyTransport will send all requests to the Test Proxy.
 - [TestProxy.cs](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core.TestFramework/src/TestProxy.cs) - This class is responsible for starting and stopping the Test Proxy process, as well as reporting any errors that occur in the Test Proxy process. The Test Proxy process is started automatically when running tests in `Record` or `Playback` mode, and is stopped automatically when the test run is complete. The Test Proxy process is shared between tests and test classes within a process.

#### Including Test Proxy Logs

In order to enable Test Proxy logging, you can either set the `AZURE_ENABLE_TEST_PROXY_LOGGING` 
environment variable or the `EnableTestProxyLogging` [runsetting](https://github.com/Azure/azure-sdk-for-net/blob/main/eng/nunit.runsettings) parameter to `true`.

## Unit tests

The Test Framework provides several classes that can help you write unit tests for your client library.  Unit tests are helpful for scenarios that would be tricky to test with a recorded test, such as simulating certain error scenarios.

The key types that are useful here are [MockResponse](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core.TestFramework/src/MockResponse.cs), [MockTransport](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core.TestFramework/src/MockTransport.cs), and [MockCredential](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core.TestFramework/src/MockCredential.cs).

Here is an example of how these types can be used to write a test that validates an error scenario is handled correctly:

```C#
[Test]
public async Task AuthorizationHeadersAddedOnceWithRetries()
{
    // arrange
    var finalResponse = new MockResponse(200);
    var setting = new ConfigurationSetting
    {
        Key = "test-key",
        Value = "test-value"
    };
    finalResponse.SetContent(JsonSerializer.Serialize(setting));

    // The MockTransport allows us to specify the set of responses that will be returned
    // by the transport. In this case, we are specifying that the first request will
    // return a 503 - which is retriable, and the second request will return a 200.
    var mockTransport = new MockTransport(new MockResponse(503), finalResponse);
    var options = new ConfigurationClientOptions
    {
        Transport = mockTransport
    };
    var credential = new MockCredential();
    var uri = new Uri("https://localHost");
    var client = new ConfigurationClient(uri, credential, options);

    // act
    await client.GetConfigurationSettingAsync(setting.Key, setting.Label);

    // We can access the requests that were sent by the client using the Requests property
    var retriedRequest = mockTransport.Requests[1];

    // assert
    Assert.True(retriedRequest.Headers.TryGetValues("Authorization", out var authorizationHeaders));
    Assert.AreEqual(1, authorizationHeaders.Count());
}
```

## Test settings

Test settings can be configured via `.runsettings` files. See [nunit.runsettings](https://github.com/Azure/azure-sdk-for-net/blob/main/eng/nunit.runsettings) for available knobs.

There are two ways to work with `.runsettings`. Both are picked up by Visual Studio without restart.

- You can edit [nunit.runsettings](https://github.com/Azure/azure-sdk-for-net/blob/main/eng/nunit.runsettings) locally to achieve desired configuration.
- You can prepare few copies of `.runsettings` by cloning [nunit.runsettings](https://github.com/Azure/azure-sdk-for-net/blob/main/eng/nunit.runsettings).

Load them in Visual Studio (`Test>Configure Run Settings` menu) and switch between them. This option requires setting an environment variable `AZURE_SKIP_DEFAULT_RUN_SETTINGS=true`.

### Support multi service version testing

To enable multi-version testing, add the `ClientTestFixture` attribute containing all of the service versions to the test class itself or a base class:

```C#
[ClientTestFixture(
    BlobClientOptions.ServiceVersion.V2019_02_02,
    BlobClientOptions.ServiceVersion.V2019_07_07)]
public abstract class BlobTestBase : StorageTestBase
{
    private readonly BlobClientOptions.ServiceVersion _serviceVersion;

    public BlobTestBase(bool async, BlobClientOptions.ServiceVersion serviceVersion, RecordedTestMode? mode = null)
        : base(async, mode)
    {
        _serviceVersion = serviceVersion;
    }

    // ...
}
```
**Whenever a new ServiceVersion is added to the client library, the test class should be updated to include it.**

The `ServiceVersion` must be either an Enum that is convertible to an Int32 or a string in the format of a date with an optional preview qualifier `yyyy-MM-dd[-preview]`.
The list passed into `ClientTestFixture` must be homogenous.

By default these versions will only apply to live tests.  There is an overloaded constructor which adds a flag `recordAllVersions` to apply these versions to record and playback as well.
If this flag is set to true you will now get a version qualifier string added to the file name.

Add a `ServiceVersion` parameter to the test class constructor and use the provided service version to create the `ClientOptions` instance.

```C#
public BlobClientOptions GetOptions() =>
    new BlobClientOptions(_serviceVersion) { /* ... */ };
```

For Management plane setting this in the client options is handled by default in the `ManagementRecordedTestBase` class by calling the new constructor which takes in the ResourceType and apiVersion to use.

```C#
        public ResourceGroupOperationsTests(bool isAsync, string apiVersion)
            : base(isAsync, ResourceGroupResource.ResourceType, apiVersion)
        {
        }
```

To control what service versions a test will run against, use the `ServiceVersion` attribute by setting it's `Min` or `Max` properties (inclusive).

```C#
[Test]
[ServiceVersion(Min = BlobClientOptions.ServiceVersion.V2019_02_02)]
public async Task UploadOverwritesExistingBlob()
{
    // ...
}
```

How it looks it the test explorer:

![image](https://user-images.githubusercontent.com/1697911/72942831-52c7ca00-3d29-11ea-9b7e-2e54198d800d.png)

__Note:__ If test recordings are enabled, the recordings will be generated against the latest version of the service.

### Support for an additional test parameter

The `ClientTestFixture` attribute also supports specifying an additional array of parameter values to send to the test class.
Similar to the service versions, this results in the creation of a permutation of each test for each parameter value specified.
Example usage is shown below:

```c#
// Add a new test suite parameter with no serviceVersions variants
[ClientTestFixture(
    serviceVersions: default,
    additionalParameters: new object[] { TableEndpointType.Storage, TableEndpointType.CosmosTable })]
public class TableServiceLiveTestsBase : RecordedTestBase<TablesTestEnvironment>
{
    protected readonly TableEndpointType _endpointType;

    public TableServiceLiveTestsBase(bool isAsync, TableEndpointType endpointType, RecordedTestMode recordedTestMode)
        : base(isAsync, recordedTestMode)
    {
        _endpointType = endpointType;
    }
}
```

```c#
// Both serviceVersions variants and a new test suite parameter
[ClientTestFixture(
    serviceVersions: new object[] { TableClientOptions.ServiceVersion.V2019_02_02, TableClientOptions.ServiceVersion.V2019_07_07 },
    additionalParameters: new object[] { TableEndpointType.Storage, TableEndpointType.CosmosTable })]
public class TableServiceLiveTestsBase : RecordedTestBase<TablesTestEnvironment>
{
    protected readonly TableEndpointType _endpointType;
    TableClientOptions.ServiceVersion _serviceVersion

    public TableServiceLiveTestsBase(bool isAsync, TableClientOptions.ServiceVersion serviceVersion, TableEndpointType endpointType, RecordedTestMode recordedTestMode)
        : base(isAsync, recordedTestMode)
    {
        _serviceVersion = serviceVersion;
        _endpointType = endpointType;
    }
}
```

__Note:__ Additional parameter options work with test recordings and will create differentiated SessionRecords test class directory names for each additional parameter option.
For example:

`/SessionRecords/TableClientLiveTests(CosmosTable)/CreatedCustomEntitiesCanBeQueriedWithFiltersAsync.json`
`/SessionRecords/TableClientLiveTests(Storage)/CreatedCustomEntitiesCanBeQueriedWithFiltersAsync.json`

## Management libraries

Testing of management libraries uses the Test Framework and should generally be very similar to tests that you write for data plane libraries. There is an intermediate test class that you will likely want to derive from that lives within the management code base - [ManagementRecordedTestBase](https://github.com/Azure/azure-sdk-for-net/blob/babee31b3151e4512ac5a77a55c426c136335fbb/common/ManagementTestShared/ManagementRecordedTestBase.cs). To see examples of Track 2 Management tests using the Test Framework, take a look at the [Storage tests](https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/storage/Azure.ResourceManager.Storage/tests/Tests).

For details about testing management libraries, see [Test .NET management plane SDK](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/resourcemanager/Azure.ResourceManager/docs/TestGuide.md).

## Recording data plane tests on CI

Test framework provides an ability to re-record tests remotely using an Azure DevOps test pipeline. To re-record tests you need to have an open GitHub pull request.

To start recording invoke the `Start-DevOpsRecordings.ps1` script passing the PR number and sdk directories to re-record:

```powershell
> .\eng\scripts\Start-DevOpsRecordings.ps1 14153 storage iot tables
```

The `Start-DevOpsRecordings.ps1` would cancel all active recording runs unless `-NoCancel` switch is used.

After runs finish an artifact with recordings will be published.

To download and unpack all artifacts use the `Download-DevOpsRecordings.ps1` script passing the PR number.

```powershell
> .\eng\scripts\Download-DevOpsRecordings.ps1 14153
```

The `Download-DevOpsRecordings.ps1` would wait for active runs to finish before retrieving artifacts unless `-NoWait` switch is used.

__NOTE:__ these scripts require being [signed in with Azure CLI](https://docs.microsoft.com/cli/azure/authenticate-azure-cli?view=azure-cli-latest) and access to the [internal DevOps project](https://dev.azure.com/azure-sdk/internal/).

### Note on private/non-virtual fields in your clients (such as _clientDiagnostics) and InternalsVisibleTo

Some bindings require code on the customized side to access fields that are generated. For example:

```csharp
    // Generated\SparkSessionClient.cs
    public partial class SparkSessionClient
    {
        private readonly ClientDiagnostics _clientDiagnostics;
        ...
    }
```

```csharp
    // Customization\SparkSessionClient.cs
    internal virtual Response<SparkSession> GetSparkSession(int sessionId, bool? detailed = null, CancellationToken cancellationToken = default)
    {
        using var scope = _clientDiagnostics.CreateScope("SparkSessionClient.GetSparkSession");
        ...
    }
```

For this to work with tests, your test class must have an `InternalsVisibleTo` in your `AssemblyInfo.cs`:

```csharp
[assembly: InternalsVisibleTo("DynamicProxyGenAssembly2, PublicKey=0024000004800000940000000602000000240000525341310004000001000100c547cac37abd99c8db225ef2f6c8a3602f3b3606cc9891605d02baa56104f4cfc0734aa39b93bf7852f7d9266654753cc297e7d2edfe0bac1cdcf9f717241550e0a7b191195b7667bb4f64bcb8e2121380fd1d9d46ad2d92d2d15605093924cceaf74c4861eff62abf69b9291ed0a340e113be11e6a7d3113e92484cf7045cc7")]
```

If this is neglected, _clientDiagnostics will be null at test runtime.

## Miscellaneous

- You can use `Recording.GenerateId()` to generate repeatable random IDs.

- You should only use `Recording.Random` for random values (and you MUST make the same number of random calls in the same order every test run)

- You can use `Recording.Now` and `Recording.UtcNow` if you need to use date or time values that will be included in the recording.

- It's possible to add additional recording variables for advanced scenarios (like custom test configuration, etc.) by using `Recording.SetVariable` or `Recording.GetVariable`.

- You can use `if (Mode == RecordingMode.Playback) { ... }` to change behavior for playback only scenarios (in particular to make polling times instantaneous)

- You can use `using (Recording.DisableRecording()) { ... }` to disable recording in the code block (useful for polling methods)

- In order to observe test network traffic with Fiddler, you can either set the `AZURE_ENABLE_FIDDLER` environment variable or the `EnableFiddler` [runsetting](https://github.com/Azure/azure-sdk-for-net/blob/main/eng/nunit.runsettings) parameter to `true`.

Several classes that are useful when writing tests for the Azure SDK are highlighted below:

### TestEnvVar

[TestEnvVar](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core.TestFramework/src/TestEnvVar.cs) allows you to wrap a block of code with a using statement inside which the configured Environment variables will be set to your supplied values.
It ensures that the existing value of any configured environment variables are preserved before they are set them and restores them outside the scope of the using block.

```c#
using (var _ = new TestEnvVar("AZURE_TENANT_ID", "foo"))
{
    // Test code that relies on the value of AZURE_TENANT_ID
}

// The previous value of AZURE_TENANT_ID is set again here.
```

### TestAppContextSwitch

[TestAppContextSwitch](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core.TestFramework/src/TestAppContextSwitch.cs) allows you to wrap a block of code with a using statement inside which the configured [AppContext](https://docs.microsoft.com/dotnet/api/system.appcontext) switch will be set to your supplied values.
It ensures that the existing value of any configured switches are preserved before they are set them and restores them outside the scope of the using block.
Note: Even if an `AppContext` switch was un-set prior to setting it via `TestAppContextSwitch`, it will be unset after leaving the scope of the using block.

```c#
var isSet = AppContext.TryGetSwitch("Azure.Core.Pipeline.DisableHttpWebRequestTransport", out val))
// isSet is false

using (var _ = new TestAppContextSwitch("Azure.Core.Pipeline.DisableHttpWebRequestTransport", "true"))
{
    var isSet = AppContext.TryGetSwitch("Azure.Core.Pipeline.DisableHttpWebRequestTransport", out val))
    // isSet is true
    // val is true

}

var isSet = AppContext.TryGetSwitch("Azure.Core.Pipeline.DisableHttpWebRequestTransport", out val))
// isSet is false
```

### AsyncAssert

This type contains static helper methods that cover some of the gaps in NUnit when it comes to async assertions. For instance, attempting to assert that a specific exception is thrown using Assert.That, Assert.Throws, or Assert.ThrowsAsync all result in sync over async code, which can lead to test flakiness.

```c#
ServiceBusException exception = await AsyncAssert.ThrowsAsync<ServiceBusException>(
    async () => await args.CompleteMessageAsync(message, args.CancellationToken));
Assert.AreEqual(ServiceBusFailureReason.MessageLockLost, exception.Reason);
```
