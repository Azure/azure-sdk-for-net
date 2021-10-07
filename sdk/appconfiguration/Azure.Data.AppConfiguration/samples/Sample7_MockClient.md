# Mock a client for testing using the Moq library

This sample illustrates how to use [Moq](https://github.com/Moq/moq4/) to create a unit test that mocks the response from a ConfigurationClient method. For more examples of mocking, see the [Azure.Data.AppConfiguration.Tests](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/appconfiguration/Azure.Data.AppConfiguration/tests/ConfigurationMockTests.cs) project.

## Define method that uses `ConfigurationClient`

To show the usage of mocks, define a method that will be tested with mocked objects. For more details about this sample method, see "[Update a Configuration If Unchanged](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/appconfiguration/Azure.Data.AppConfiguration/samples/Sample6_UpdateSettingIfUnchanged.md)" sample.  

```C# Snippet:AzConfigSample7_MethodToTest
private static async Task<int> UpdateAvailableVmsAsync(ConfigurationClient client, int releasedVMs, CancellationToken cancellationToken)
{
    while (!cancellationToken.IsCancellationRequested)
    {
        ConfigurationSetting setting = await client.GetConfigurationSettingAsync("available_vms", cancellationToken: cancellationToken);
        var availableVmsCount = int.Parse(setting.Value);
        setting.Value = (availableVmsCount + releasedVMs).ToString();

        try
        {
            ConfigurationSetting updatedSetting = await client.SetConfigurationSettingAsync(setting, onlyIfUnchanged: true, cancellationToken);
            return int.Parse(updatedSetting.Value);
        }
        catch (RequestFailedException e) when (e.Status == 412)
        {
        }
    }

    cancellationToken.ThrowIfCancellationRequested();
    return 0;
}
```

## Create and setup mocks

For this test, create a mock for the `ConfigurationClient` and `Response`.

```C# Snippet:AzConfigSample7_CreateMocks
var mockResponse = new Mock<Response>();
var mockClient = new Mock<ConfigurationClient>();
```

Then, set up the client methods that will be executed when `GetConfigurationSettingAsync` and `SetConfigurationSettingAsync` are called on the mock client.

```C# Snippet:AzConfigSample7_SetupMocks
Response<ConfigurationSetting> response = Response.FromValue(ConfigurationModelFactory.ConfigurationSetting("available_vms", "10"), mockResponse.Object);
mockClient.Setup(c => c.GetConfigurationSettingAsync("available_vms", It.IsAny<string>(), It.IsAny<CancellationToken>()))
    .Returns(Task.FromResult(response));
mockClient.Setup(c => c.SetConfigurationSettingAsync(It.IsAny<ConfigurationSetting>(), true, It.IsAny<CancellationToken>()))
    .Returns((ConfigurationSetting cs, bool onlyIfUnchanged, CancellationToken ct) => Task.FromResult(Response.FromValue(cs, new Mock<Response>().Object)));
```

## Use mocks

Now to validate `ReleaseVmsAsync` without making a network call use `ConfigurationClient` mock.

```C# Snippet:AzConfigSample7_UseMocks
ConfigurationClient client = mockClient.Object;
int availableVms = await UpdateAvailableVmsAsync(client, 2, default);
Assert.AreEqual(12, availableVms);
```


