# .NET System.ClientModel Test Framework

The .NET System.ClientModel Test Framework (Microsoft.ClientModel.TestFramework) is a comprehensive set of classes and utilities that help you write tests for client libraries built on System.ClientModel. It provides support for both recorded tests and unit tests, with built-in sync/async test capabilities that allow you to write a single async test method and automatically test both the synchronous and asynchronous versions of your client methods. The Test Framework uses NUnit as its underlying testing framework.

## Using the TestFramework

The Test Framework is released to the Azure SDK for .NET dev feed. To use it in your project, you'll need to configure access to the dev feed as described in the [Contributing Guide](../../CONTRIBUTING.md#nuget-package-dev-feed).

Once you have access to the dev feed, add a package reference to `Microsoft.ClientModel.TestFramework` in your test project.

Additionally, for recorded tests that use the test proxy, you'll need to add the `Azure.Sdk.Tools.TestProxy` tool to your repository's `.config/dotnet-tools.json` file so it can be automatically downloaded from the dev feed and used during test execution.

### Required Project Configuration

For proper test recording functionality, test projects must include a `SourcePath` assembly metadata attribute that specifies the source directory of the test project. This attribute is used by the Test Framework to locate the correct directory for storing session recording files, ensuring recordings are saved relative to your test source code rather than the compiled assembly location.

**Note**: If you're working in the azure-sdk-for-net repository, this is already added to all test projects by default.

Here's an example of adding this attribute to your test `.csproj` file:

``` xml
<ItemGroup>
  <AssemblyAttribute Include="System.Reflection.AssemblyMetadataAttribute">
    <_Parameter1>SourcePath</_Parameter1>
    <_Parameter2>$(MSBuildProjectDirectory)</_Parameter2>
  </AssemblyAttribute>
</ItemGroup>
```

**`$(MSBuildProjectDirectory)`**: This MSBuild property automatically resolves to the directory containing the `.csproj` file, ensuring the correct path is used regardless of build environment or developer machine setup

Without this attribute, the Test Framework falls back to using the assembly's output directory, which may not be the desired location for storing test recordings in your source tree.

## Key Concepts

**Sync/Async Testing**: Write async test methods and automatically test both sync and async versions of your client methods. The framework creates proxy classes that forward async calls to their sync overloads. **Note**: This works specifically for clients that follow the System.ClientModel pattern where methods are paired as `MethodName()` and `MethodNameAsync()` with identical parameter signatures.

**Recorded Tests**: Functional tests that can run in three modes - Live (against real services), Record (capture HTTP interactions), and Playback (replay captured interactions). Uses the Azure SDK Test Proxy for HTTP recording and playback.

**Test Environment**: Manages configuration variables and credentials for tests, with automatic sanitization of sensitive data during recording.

**Unit Testing**: Mock utilities for unit testing without requiring live services. Includes `MockPipelineTransport`, `MockPipelineResponse`, and `MockCredential` classes.

## Examples

Additional samples with explanations can be found in this repository, these are linked below:
- [Recorded Tests](samples/RecordedTests.md): complete guide showing how to set up recorded tests with TestEnvironment classes and credential management.
- [Sync/Async Testing](samples/SyncAsync.md): demonstrates writing a single async test that automatically validates both sync and async client method calls.
- [Unit Testing](samples/UnitTests.md): examples of using mock utilities to test error handling, retry logic, and authentication scenarios without live services.
- [Test Utilities](samples/TestUtilities.md): advanced testing patterns including environment variable management, randomization, and performance testing utilities.

### Recorded tests

The bulk of the functionality of the Test Framework is around supporting the ability to run recorded tests. This type of test can be thought of as a functional test as opposed to a unit test. A recorded test can be run in three different modes:
  - `Live` - The requests in the tests are run against live service resources.
  - `Record` - The requests in the tests are run against live resources and HTTP interactions are recorded for later playback.
  - `Playback` - The requests that your library generates when running a test are compared against the requests in the recording for that test. For each matched request, the corresponding response is extracted from the recording and "played back" as the response. The test will fail if a request issued by the library cannot be matched to the ones found in the session file, taking into account any sanitization or matching customizations that may have been applied to the request.

Under the hood, when tests are run in `Playback` or `Record` mode, requests are forwarded to the [Test Proxy](https://github.com/Azure/azure-sdk-tools/blob/main/tools/test-proxy/Azure.Sdk.Tools.TestProxy/README.md). The test proxy is a proxy server that runs locally on your machine automatically when in `Record` or `Playback` mode. The proxy is responsible for saving the requests and responses when running in `Record` mode and for returning the recorded responses when running in `Playback` mode.

#### Test resource creation and TestEnvironment

In order to actually run recorded tests in `Live` or `Record` mode, you will need service resources that the test can run against.

To access the variables output from your test-resources template, create a class that inherits from `TestEnvironment` and exposes required values as properties:

``` C#
public class SampleTestEnvironment : TestEnvironment
{
    // Variables retrieved using GetRecordedVariable will be recorded in recorded tests
    public string Endpoint => GetRecordedVariable("SAMPLE_ENDPOINT");
    public string SecretKey => GetRecordedVariable("SAMPLE_SECRET_KEY", options => options.IsSecret());
}
```

__NOTE:__ Make sure that variables containing secret values are not recorded or are sanitized. If you accidentally leak a secret, follow the guidance [here](https://dev.azure.com/azure-sdk/internal/_wiki/wikis/internal.wiki/101/Leaked-secret-procedure).

To sanitize variables use the `options` parameter of `GetRecordedVariable`:

``` C#
public string Key => GetRecordedVariable("SAMPLE_KEY", options => options.IsSecret());
```

If the client expects a Base64 secret value use the `SanitizedValue` parameter to use a Base64 compatible replacement value:

``` C#
public string Key => GetRecordedVariable("SAMPLE_KEY", options => options.IsSecret(SanitizedValue.Base64));
```

You can now retrieve these values in tests:

``` C#
public class ConfigurationTests : RecordedTestBase<SampleTestEnvironment>
{
    [Test]
    public async Task CanCallService()
    {
        var client = InstrumentClient(new SampleClient(
            new Uri(TestEnvironment.Endpoint), 
            new ApiKeyCredential(TestEnvironment.SecretKey)
        ));
        
        // Test implementation here
    }
}
```

#### Defining the recorded test class

To use recorded test functionality, define a class that inherits from the `RecordedTestBase<T>` class and use the `InstrumentClientOptions` method when creating the client instance. Pass the test environment class as the generic argument to `RecordedTestBase<T>`. If any tests should not be recorded, e.g. because the recording would be too large, apply the `LiveOnly` attribute at either the test or class level, as appropriate.

``` C#
public class ConfigurationTests : RecordedTestBase<SampleTestEnvironment>
{
    public ConfigurationTests(bool isAsync) : base(isAsync)
    {
    }

    [RecordedTest]
    public async Task CreateAndDeleteConfiguration()
    {
        var options = InstrumentClientOptions(new SampleClientOptions());
        var client = InstrumentClient(new SampleClient(
            new Uri(TestEnvironment.Endpoint), 
            TestEnvironment.Credential, 
            options
        ));
        
        // Test implementation here
    }
}
```

By default tests are run in playback mode. You can change the mode in several ways, including:
- Setting the `SYSTEM_CLIENTMODEL_TEST_MODE` environment variable to `Live`, `Playback`, or `Record`
- Passing the mode directly in the test class constructor: `base(isAsync, RecordedTestMode.Record)`

#### Sanitizing

Secrets that are part of requests, responses, headers, or connections strings should be sanitized before saving the record.
__Do not check in session records containing secrets.__ Common headers like `Authentication` are sanitized automatically, but if custom logic is required and/or if request or response body need to be sanitized, several properties of `RecordedTestBase` can be used to customize the sanitization process.

For example:

```C#
public class ConfigurationTests : RecordedTestBase<SampleTestEnvironment>
{
    public ConfigurationTests(bool isAsync) : base(isAsync)
    {
        // Add custom header sanitization
        SanitizedHeaders.Add(new HeaderRegexSanitizer("x-custom-header", "SANITIZED"));
    }
}
```

### Unit tests

The Test Framework provides several classes that can help you write unit tests for your client library. Unit tests are helpful for scenarios that would be tricky to test with a recorded test, such as simulating certain error scenarios.

The key types that are useful here are `MockPipelineResponse`, `MockPipelineTransport`, and `MockCredential`.

Here is an example of how these types can be used to write a test that validates an error scenario is handled correctly:

```C#
[Test]
public async Task AuthorizationHeadersAddedOnceWithRetries()
{
    // arrange
    var credential = new MockCredential("test-token", DateTimeOffset.UtcNow.AddHours(1));
    var transport = new MockPipelineTransport(
        new MockPipelineResponse(500), // First request fails
        new MockPipelineResponse(200)  // Second request succeeds
    );
    
    var options = new SampleClientOptions();
    options.Transport = transport;
    
    var client = new SampleClient(new Uri("https://example.com"), credential, options);
    
    // act
    var result = await client.GetDataAsync();
    
    // assert
    Assert.AreEqual(2, transport.Requests.Count);
    var authorizationHeaders = transport.Requests.SelectMany(r => r.Headers.Where(h => h.Name == "Authorization"));
    Assert.AreEqual(2, authorizationHeaders.Count()); // One per request
}
```

## Test settings

Test settings can be configured via `.runsettings` files. The Test Framework recognizes the following settings:

- `TestMode`: Override the test mode (`Live`, `Record`, `Playback`)
- `TestTimeout`: Set the global test timeout in seconds

## Advanced Features

### TokenCredential Support

If a test or sample uses `AuthenticationTokenProvider` to construct the client use `TestEnvironment.Credential`. This will ensure that the service principal used to provision the test resources will be used to authorize the service requests when running in `Record` mode.

``` C#
public abstract class SampleTestBase : RecordedTestBase<SampleTestEnvironment>
{
    internal SampleClient GetClient() =>
        InstrumentClient(new SampleClient(
            new Uri(TestEnvironment.Endpoint), 
            TestEnvironment.Credential
        ));
}
```

### Debugging Test Proxy

For debugging test proxy issues, set the `UseLocalDebugProxy` property to true in your test class:

```C#
public SampleTests(bool isAsync) : base(isAsync)
{
    UseLocalDebugProxy = true;
}
```

## Contributing

This project welcomes contributions and suggestions. Most contributions require you to agree to a Contributor License Agreement (CLA) declaring that you have the right to, and actually do, grant us the rights to use your contribution. For details, visit https://cla.microsoft.com.

When you submit a pull request, a CLA-bot will automatically determine whether you need to provide a CLA and decorate the PR appropriately (e.g., label, comment). Simply follow the instructions provided by the bot. You will only need to do this once across all repositories using our CLA.

This project has adopted the [Microsoft Open Source Code of Conduct][code_of_conduct]. For more information see the [Code of Conduct FAQ][code_of_conduct_faq] or contact opencode@microsoft.com with any additional questions or comments.

[source]: https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/core/Microsoft.ClientModel.TestFramework/src
[code_of_conduct]: https://opensource.microsoft.com/codeofconduct
[code_of_conduct_faq]: https://opensource.microsoft.com/codeofconduct/faq/