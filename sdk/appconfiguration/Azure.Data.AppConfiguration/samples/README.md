# Azure App Configuration client SDK samples

This directory contains samples for the Azure App Configuration client SDK.  Each sample illustrates one or more capabilities of the library.

These include:
 - [Hello World](#hello-world): Create and delete a configuration setting.
 - [Hello World Extended](#hello-world-extended): Asynchronously create, update and delete configuration settings with labels.
 - [Set Read Only](#set-read-only): Make a configuration setting read-only, and then return it to a read-write state.
 - [Read Revision History](#read-revision-history): Read the revision history of a configuration setting that has been changed.
 - [Get Setting If Changed](#get-setting-if-changed): Save bandwidth by using a conditional request to retrieve a setting only if it is different from your local copy.
 - [Update Setting If Unchanged](#update-setting-if-unchanged): Prevent lost updates by using optimistic concurrency to update a setting only if your local updates were applied to the same version as the resource in the configuration store.
 - [Mock Client](#mock-client): Mock a client for testing using the [Moq library][moq].

 ## Prerequisites
 To run these samples, you will need:
 - An [Azure subscription][azure_sub].
 - A [Configuration Store][configuration_store].
 - To set the environment variable `APPCONFIGURATION_CONNECTION_STRING` to the connection string for your configuration store.

 For more details regarding prerequisites, see the [README for this library][root_readme].

## Hello World

In this sample, we introduce `ConfigurationClient` and `ConfigurationSetting`, two core classes in this library.  `ConfigurationClient` is used to call the Azure App Configuration service -- each method call sends a request to the service's REST API.  `ConfigurationSetting` is the primary entity stored in a Configuration Store and represents a key-value pair you use to configure your application.  The sample walks through the basics of adding, retrieving, and deleting a configuration setting.

[Hello World Sample](Sample1_HelloWorld.cs)

## Hello World Extended

In this sample, we take a step further with `ConfigurationClient` and show how to send requests to the service asychronously.  We also show how to create and retrieve configuration settings with labels, and provide an example scenario where labels are used to group configuration settings for beta and production application instances.

[Hello World Extended Sample](Sample2_HelloWorldExtended.cs)

## Set Read Only

In this sample, we show how to make a configuration setting read-only, as well as the exception that is thrown if you attempt to update it while it is in a read-only state.  We then show how to return the setting to a read-write state.

[Set Read Only Sample](Sample3_SetClearReadOnly.cs)

## Read Revision History

In this sample, we illustrate how to obtain the revision history of a configuration setting.  We first create a configuration setting, then make two separate updates to it.  Finally, we create a `SettingSelector` that uniquely identifies the configuration setting and use the selector to retrieve the configuration setting's revisions.  The sample uses a configuration setting with a timestamp in the key name to ensure the setting hasn't been used before and thereby minimize the size of the revision history.  It does not show that if you were to delete and recreate a configuration setting, the revision history would comprise both the history before the setting was deleted, and the history after it was recreated.

[Read Revision History Sample](Sample4_ReadRevisionHistory.cs)

## Get Setting If Changed

In this sample, we show how to make the `GetConfigurationSetting` operation conditional, so that the request it sends to the App Configuration service is a [conditional request][conditional_request_mdn].  In the Azure SDK, [conditional requests are not sent unless opted-into][conditional_request_guideline].  Making the `GetConfigurationSetting` operation conditional means that the requested configuration setting will only be returned if it has changed in the configuration store since it was last retrieved, which can save bandwidth.  We show how to examine the operation response's status code to determine whether or not a configuration setting was returned in the body of the response.

[Get Setting If Changed Sample](Sample5_GetSettingIfChanged.cs)

## Update Setting If Unchanged

In this sample, we show how to make the `SetConfigurationSetting` operation conditional, so that the request it sends to the App Configuration service is a [conditional request][conditional_request_mdn].  In the Azure SDK, [conditional requests are not sent unless opted-into][conditional_request_guideline].  Making the `SetConfigurationSetting` operation conditional allows us to ensure that the updates we made to the configuration setting are applied only if no other clients updated the configuration setting since the last time we retrieved it.  We walk through a hypothetical scenario where we release several virtual machines from our application's resource pool, and update the `available_vms` configuration setting to reflect this.  In this scenario, if another client were to have modified `available_vms` since we last retrieved it, and we updated it unconditionally, our update would overwrite their changes and the resulting value of `available_vms` would be incorrect.  We show in the sample how to implement optimistic concurrency to apply the update in a way that doesn't overwrite other clients' changes.

[Update Setting If Unchanged Sample](Sample6_UpdateSettingIfUnchanged.cs)

## Mock Client

In this sample, we give a simple example illustrating how the [Moq](moq) library can be used to mock a ConfigurationClient for use in testing.  For additional examples of using mocks in tests, please refer to [ConfigurationMockTests.cs][mock_tests].

[Mock Client Sample](Sample7_MockClient.cs)


<!-- Links -->

[azure_sub]: https://azure.microsoft.com/free/
[configuration_store]: https://docs.microsoft.com/azure/azure-app-configuration/quickstart-dotnet-core-app#create-an-app-configuration-store
[root_readme]: https://github.com/Azure/azure-sdk-for-net/tree/master/sdk/appconfiguration/Azure.Data.AppConfiguration/README.md
[conditional_request_mdn]: https://developer.mozilla.org/en-US/docs/Web/HTTP/Conditional_requests
[conditional_request_guideline]: https://azure.github.io/azure-sdk/general_design.html#conditional-requests
[moq]: https://github.com/Moq/moq4/
[mock_tests]: https://github.com/Azure/azure-sdk-for-net/blob/master/sdk/appconfiguration/Azure.Data.AppConfiguration/tests/ConfigurationMockTests.cs
