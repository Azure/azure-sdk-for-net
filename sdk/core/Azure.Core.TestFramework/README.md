# Using the TestFramework

To start using the Test Framework, add a project reference using the alias `AzureCoreTestFramework` into your test `.csproj`:

``` xml
<Project Sdk="Microsoft.NET.Sdk">

...
   <ProjectReference Include="$(AzureCoreTestFramework)" />
...

</Project>
```

As an example, see the [Template](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/template/Azure.Template/tests/Azure.Template.Tests.csproj#L15) project.

## Sync-async tests

The test framework provides the ability to write tests using async client methods and automatically run them using sync overloads. To write sync-async client tests, inherit from `ClientTestBase` class and use the `InstrumentClient` method to wrap your client into a proxy class that automatically forwards async calls to their sync overloads.

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

When using sync-async tests with recorded tests two sessions files will be generated - the async test session will have `Async.json` suffix.

You can disable the sync-forwarding for an individual test by applying the `[AsyncOnly]` attribute to the test method.

__Limitation__: all method calls/properties that are being used have to be `virtual`.

## Test environment and live test resources

Follow the [live test resources management](https://github.com/azure/azure-sdk-for-net/tree/main/eng/common/TestResources/README.md) to create a live test resources deployment template and get it deployed. The deployment template should be named `test-resources.json` and will live under your service directory.

To use the environment provided by the `New-TestResources.ps1`, create a class that inherits from `TestEnvironment` and exposes required values as properties:

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

__NOTE:__ Make sure that variables containing secret values are not recorded or are sanitized.

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
then you can consider implementing `TestEnvironment.IsEnvironmentReadyAsync`. Test framework will probe the scenario couple of times before starting tests or
fail test run if resources don't become available:

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

### Running live tests serially

By default, NUnit does not run tests within each assembly in parallel, but this be [configured](https://docs.nunit.org/articles/nunit/technical-notes/usage/Framework-Parallel-Test-Execution.html).
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

## Test settings

Test settings can be configured via `.runsettings` files. See [nunit.runsettings](https://github.com/Azure/azure-sdk-for-net/blob/main/eng/nunit.runsettings) for available knobs.

There are two ways to work with `.runsettings`. Both are picked up by Visual Studio without restart.

- You can edit [nunit.runsettings](https://github.com/Azure/azure-sdk-for-net/blob/main/eng/nunit.runsettings) locally to achieve desired configuration.
- You can prepare few copies of `.runsettings` by cloning [nunit.runsettings](https://github.com/Azure/azure-sdk-for-net/blob/main/eng/nunit.runsettings).

Load them in Visual Studio (`Test>Configure Run Settings` menu) and switch between them. This option requires setting an environment variable `AZURE_SKIP_DEFAULT_RUN_SETTINGS=true`.

## TokenCredential

If a test or sample uses `TokenCredential` to construct the client use `TestEnvironment.Credential` to retrieve it.

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

## Recorded tests

The test framework provides an ability to record HTTP requests and responses and replay them for offline test runs. This allows the full suite of tests to be run as part of PR validation without running live tests. In general, live tests are run as part of a separate internal pipeline that runs nightly.

To use recorded test functionality inherit from `RecordedTestBase<T>` class and use `InstrumentClientOptions` method when creating the client instance. Pass the test environment class as a generic argument to `RecordedTestBase`.

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

When running tests in `Live` or `Record` mode, the Test Framework will prompt you to create the live test resources required for the tests if you don't have environment variables or an env file containing the required variables needed for the tests. This means that you do not have to manually run the New-TestResources script when attempting to run live tests! The Test Framework will also attempt to automatically extend the expiration of the test resource resource group whenever live tests are run. If the resource group specified in your .env file or environment variable has already expired and thus been deleted, the framework will prompt you to create a new resource group just like it would if an env variable required by the test was missing.

### Recording

When tests are run in recording mode, session records are saved to the project directory automatically in a folder named 'SessionRecords'.

### Sanitizing

Secrets that are part of requests, responses, headers, or connections strings should be sanitized before saving the record.
__Do not check in session records containing secrets.__ Common headers like `Authentication` are sanitized automatically, but if custom logic is required and/or if request or response body need to be sanitized, the `Sanitizer` property should be used as an extension point.

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

### Matching

When tests are run in `Playback` mode, the HTTP method, Uri, and headers are used to match the request to the recordings. Some headers change on every request and are not controlled by the client code and should be ignored during matching. Common headers like `Date`, `x-ms-date`, `x-ms-client-request-id`, `User-Agent`, `Request-Id` are ignored by default but if more headers need to be ignored, use the various matching properties to customize as needed.

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

### Ignoring intermittent service errors

If your live tests are impacted by temporary or intermittent services errors, be sure the service team is aware and has a plan to address the issues.
If these issues cannot be resolved, you can attribute test classes or test methods with `[IgnoreServiceError]` which takes a required HTTP status code, Azure service error, and optional error message substring.
This attribute, when used with `RecordedTestBase`-derived test fixtures and methods attributed with `[RecordedTest]`, which mark tests that failed with that specific error as "inconclusive", along with an optional
reason you specify and the original error information.

### Misc

You can use `Recording.GenerateId()` to generate repeatable random IDs.

You should only use `Recording.Random` for random values (and you MUST make the same number of random calls in the same order every test run)

You can use `Recording.Now` and `Recording.UtcNow` if you need certain values to capture the time the test was recorded.

It's possible to add additional recording variables for advanced scenarios (like custom test configuration, etc.) by using `Recording.SetVariable` or `Recording.GetVariable`.

You can use `if (Mode == RecordingMode.Playback) { ... }` to change behavior for playback only scenarios (in particular to make polling times instantaneous)

You can use `using (Recording.DisableRecording()) { ... }` to disable recording in the code block (useful for polling methods)

In order to enable testing with Fiddler, you can either set the  `AZURE_ENABLE_FIDDLER` environment variable or the `EnableFiddler` [runsetting](https://github.com/Azure/azure-sdk-for-net/blob/main/eng/nunit.runsettings) parameter to `true`.

## Support multi service version testing

To enable multi-version testing, add the `ClientTestFixture` attribute listing to all the service versions to the test class itself or a base class:

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

__Note:__ If test recordings are enabled, the recordings will be generated against the latests version of the service.

## Support for an additional test parameter

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

## Miscellaneous Helpers

There are various helpful classes that assist in writing tests for the Azure SDK. Below are some of them.

### TestEnvVar

[TestEnvVar](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core.TestFramework/src/TestEnvVar.cs) allows you to wrap a block of code with a using statement inside which the configured Environment variables will be set to your supplied values.
It ensures that the existing value of any configured environment variables are preserved before they are set them and restores them outside the scope of the using block.

```c#
using (var _ = new TestEnvVar("AZURE_TENANT_ID", "foo"))
{
    // Test code that relies on the value of AZURE_TENANT_ID
}

// The previous value of AZURE_TENANT_ID is set again here.
```

### TestAppContextSwitch

[TestAppContextSwitch](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core.TestFramework/src/TestAppContextSwitch.cs) allows you to wrap a block of code with a using statement inside which the configured [AppContext](https://docs.microsoft.com/dotnet/api/system.appcontext) switch will be set to your supplied values.
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
