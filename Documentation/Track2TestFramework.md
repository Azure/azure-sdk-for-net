# Accquring TestFramework

To start using test framework import `sdk\core\Azure.Core\tests\TestFramework.props` into test `.csproj`:

``` xml
<Project Sdk="Microsoft.NET.Sdk">

...
  <Import Project="..\..\..\core\Azure.Core\tests\TestFramework.props" />
...

</Project>

```

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

__Limitation__: all method calls/properties that are being used have to be `virtual`.

# Recorded tests

Test framework provides an ability to record HTTP requests and responses and replay them for offline test runs.

To use recorded test functionality inherit from `RecordedTestBase` class and use `Recording.InstrumentClientOptions` method when creating the client instance.


``` C#
public class ConfigurationLiveTests: RecordedTestBase
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
public class ConfigurationLiveTests: RecordedTestBase
{
    public ConfigurationLiveTests(bool isAsync) : base(isAsync, RecordedTestMode.Record)
    {
    }
}
```

## Recording

When tests are run in recording mode session records are being saved to `artifacts/bin/<ProjectName>/<TFM>/SessionRecords` directory. You can copy recordings to the project directory manually or by executing `dotnet msbuild /t:UpdateSessionRecords` in the test project directory.

## Sanitizing

Secrets that are part of requests, responses, headers or connections strings should be sanitized before saving the record. Common headers like `Authentication` are sanitized automatically but if custom logic is required `RecordedTest.Sanitizer` should be used as extension point.

For example:

``` C#
    public class ConfigurationRecordedTestSanitizer : RecordedTestSanitizer
    {
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
## TokenCredential

If test uses `TokenCredential` to construct the client use `Recording.GetCredential(...)` to wrap it:

``` C#
    public abstract class KeysTestBase : RecordedTestBase
    {
        internal KeyClient GetClient()
        {
            return InstrumentClient
                (new KeyClient(
                    new Uri(recording.GetVariableFromEnvironment(AzureKeyVaultUrlEnvironmentVariable)),
/* --------> */     recording.GetCredential(new DefaultAzureCredential()),
                    recording.InstrumentClientOptions(new KeyClientOptions())));
        }
    }

```
