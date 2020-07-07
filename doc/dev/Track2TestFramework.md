# Acquiring TestFramework

To start using Test Framework add a project reference using the alias `AzureCoreTestFramework` into your test `.csproj`:

``` xml
<Project Sdk="Microsoft.NET.Sdk">

...
   <ProjectReference Include="$(AzureCoreTestFramework)" />
...

</Project>

```
As an example, see the [Template](https://github.com/Azure/azure-sdk-for-net/blob/master/sdk/template/Azure.Template/tests/Azure.Template.Tests.csproj#L15) project.

# Sync-async tests

The test framework provides an ability to write test using async client methods and automatically run them using sync overloads. To write sync-async client tests inherit from `ClientTestBase` class and use `InstrumentClient` method call to wrap client into a proxy class that would automatically forward async calls to their sync overloads.

``` C#
public class ConfigurationLiveTests: ClientTestBase
{
    public ConfigurationLiveTests(bool isAsync) : base(isAsync)
    {
    }

    private ConfigurationClient GetClient()
    {
        return InstrumentClient(new ConfigurationClient(...));
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

In the test explorer async tests would display as `TestClassName(true)` and sync tests as `TestClassName(false)`.

When using sync-async tests with recorded tests two sessions files would get generated async test session would have `Async.json` suffix.

You can disable the sync-forwarding for an individual test by applying the `[AsyncOnly]` attribute to the test method.


__Limitation__: all method calls/properties that are being used have to be `virtual`.

# Test environment and live test resources

Follow the [live test resources management](../../eng/common/TestResources/README.md) to create a live test resources deployment template and get id deployed.

To use the environment provided by the `New-TestResources.ps1` create a class that inherits from `TestEnvironment` and exposes required values as properties:

``` C#
public class AppConfigurationTestEnvironment : TestEnvironment
{
    // Call the base constructor passing the service directory name
    public AppConfigurationTestEnvironment() : base("appconfiguration")
    {
    }

    // Variables retrieved using GetRecordedVariable would be recorded in recorded tests
    // Argument is the output name in the test-resources.json
    public string ConnectionString => GetRecordedVariable("APPCONFIGURATION_CONNECTION_STRING");
    // Variables retrieved using GetVariable would not be recorded but the method would throw if variable is not set
    public string SystemAssignedVault => GetVariable("IDENTITYTEST_IMDSTEST_SYSTEMASSIGNEDVAULT");
    // Variables retrieved using GetOptionalVariable would not be recorded and the method would return null if variable is not set
    public string TestPassword => GetOptionalVariable("AZURE_IDENTITY_TEST_PASSWORD") ?? "SANITIZED";
}
```

**NOTE:** Make sure that variables containing secret values are not recorded or are sanitized.

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

## TokenCredential

If a test or sample uses `TokenCredential` to construct the client use `TestEnvironment.Credential` to retrieve it.

``` C#
    public abstract class KeysTestBase : RecordedTestBase<KeyVaultTestEnvironment>
    {
        internal KeyClient GetClient()
        {
            return InstrumentClient
                (new KeyClient(
                    new Uri(TestEnvironment.KeyVaultUrl),
/* --------> */     TestEnvironment.Credential,
                    recording.InstrumentClientOptions(new KeyClientOptions())));
        }
    }

```

# Recorded tests

Test framework provides an ability to record HTTP requests and responses and replay them for offline test runs.

To use recorded test functionality inherit from `RecordedTestBase<T>` class and use `Recording.InstrumentClientOptions` method when creating the client instance. Pass the test environment class as a generic argument to `RecordedTestBase`.


``` C#
public class ConfigurationLiveTests: RecordedTestBase<AppConfigurationTestEnvironment>
{
    public ConfigurationLiveTests(bool isAsync) : base(isAsync)
    {
    }

    private ConfigurationClient GetClient()
    {
        return InstrumentClient(
            new ConfigurationClient(
                ...,
                Recording.InstrumentClientOptions(new ConfigurationClientOptions())));
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

By default tests are run in playback mode. To change the mode use `AZURE_TEST_MODE` environment variable and set it to one of the followind values: `Live`, `Playback`, `Record`.

In development scenarios where it's required to change mode quickly without restarting the Visual Studio use the two-parameter constructor of `RecordedTestBase` to change the mode:

``` C#
public class ConfigurationLiveTests: RecordedTestBase<AppConfigurationTestEnvironment>
{
    public ConfigurationLiveTests(bool isAsync) : base(isAsync, RecordedTestMode.Record)
    {
    }
}
```

## Recording

When tests are run in recording mode session records are being saved to `artifacts/bin/<ProjectName>/<TargetFramework>/SessionRecords` directory. You can copy recordings to the project directory manually or by executing `dotnet msbuild /t:UpdateSessionRecords` in the test project directory.

__NOTE:__ recordings are copied from `netcoreapp2.1` directory by default, make sure you are running the right target framework.

## Sanitizing

Secrets that are part of requests, responses, headers, or connections strings should be sanitized before saving the record. Common headers like `Authentication` are sanitized automatically but if custom logic is required and/or if request or response body need to be sanitied, the `RecordedTest.Sanitizer` should be used as extension point.

For example:

``` C#
    public class ConfigurationRecordedTestSanitizer : RecordedTestSanitizer
    {
        public ConfigurationRecordedTestSanitizer()
            base()
        {
            JsonPathSanitizers.Add("$..secret");
        }

        public override void SanitizeConnectionString(ConnectionString connectionString)
        {
            const string secretKey = "secret";

            if (connectionString.Pairs.ContainsKey(secretKey))
            {
                connectionString.Pairs[secretKey] = "";
            }
        }
    }

    public class ConfigurationLiveTests: RecordedTestBase
    {
        public ConfigurationLiveTests(bool isAsync) : base(isAsync)
        {
            Sanitizer = new ConfigurationRecordedTestSanitizer();
        }
    }
```

**Note:** `JsonPathSanitizers` takes [Json Path](https://www.newtonsoft.com/json/help/html/QueryJsonSelectToken.htm) format strings that will be validated against the body. If a match exists, the value will be sanitized.

## Matching

When tests are ran in replay mode HTTP method, uri and headers are used to match request to response. Some headers change on every request and are not controlled by the client code and should be ignored during the matching. Common headers like `Date`, `x-ms-date`, `x-ms-client-request-id`, `User-Agent`, `Request-Id` are ignored by default but if more headers need to be ignored use `Recording.Matcher` extensions point.


``` C#
    public class ConfigurationRecordMatcher : RecordMatcher
    {
        public ConfigurationRecordMatcher(RecordedTestSanitizer sanitizer) : base(sanitizer)
        {
            ExcludeHeaders.Add("Sync-Token");
        }
    }

    public class ConfigurationLiveTests: RecordedTestBase
    {
        public ConfigurationLiveTests(bool isAsync) : base(isAsync)
        {
            Sanitizer = new ConfigurationRecordedTestSanitizer();
            Matcher = new ConfigurationRecordMatcher(Sanitizer);
        }
    }
```

## Misc

You can use `Recording.GenerateId()` to generate repeatable random IDs.

You should only use `Recording.Random` for random values (and you MUST make the same number of random calls in the same order every test run)

You can use `Recording.Now` and `Recording.UtcNow` if you need certain values to capture the time the test was recorded

It's possible to add additional recording variables for advanced scenarios (like custom test configuration, etc.) by using `Recording.SetVariable` or `Recording.GetVariable`.

You can use `if (Mode == RecordingMode.Playback) { ... }` to change behavior for playback only scenarios (in particular to make polling times instantaneous)

You can use `using (Recording.DisableRecording()) { ... }` to disable recording in the code block (useful for polling methods)

# Support multi service version testing

To enable multi-version testing add the `ClientTestFixture` attribute listing all the service versions to the test class itself or a base class:

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

Add a `ServiceVersion` parameter to the test class constructor and use the provided service version to create the `ClientOptions` instance.

```C#
public BlobClientOptions GetOptions() =>
    new BlobClientOptions(_serviceVersion) { /* ... */ };
```

To control what service versions test would run against use the `ServiceVersion` attribute by setting it's `Min` or `Max` properties (inclusive).

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

**Note:** If test recordings are enabled, the recordings will be generated against the latests version of the service.
