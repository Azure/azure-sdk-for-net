# React to Settings Change Notifications

The AppConfiguration service supports [EventGrid-based setting change notifications](https://learn.microsoft.com/azure/azure-app-configuration/howto-app-configuration-event). This sample shows how to use the Azure.Data.AppConfiguration library to process these notifications.

This sample assumes you have a shared long-lived instance of `ConfigurationClient`:

```C# Snippet:AzConfigSample8_ChangeNotification_SharedClient
// The shared ConfigurationClient used by application
ConfigurationClient SharedConfigurationClient;
```

When handling an EventGrid change notification, the AppConfiguration setting change event is represented by the `AppConfigurationKeyValueModifiedEventData` type.

There are three main properties on `AppConfigurationKeyValueModifiedEventData`:

1. `Key` - the key of the setting that changed.
2. `Label` - the label of the setting that changed.
3. `SyncToken` - because of the distributed nature of the AppConfiguration service, the synchronization token needs to be registered with the client to get the most up-to-date value of the setting. The `ConfigurationClient.UpdateSyncToken` is used to register the synchronization token.

The following sample parses the notification payload using the [Azure.Messaging.EventGrid](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/eventgrid/Azure.Messaging.EventGrid/README.md#receiving-and-deserializing-events) client library.
Next, it enumerates all events and handles all instances of  `AppConfigurationKeyValueModifiedEventData`.

```C# Snippet:AzConfigSample8_ChangeNotification
public void HandleEventGridNotification(string data)
{
    var events = EventGridEvent.ParseMany(new BinaryData(data));

    foreach (EventGridEvent eventGridEvent in events)
    {
        if (eventGridEvent.TryGetSystemEventData(out object systemData) &&
            systemData is AppConfigurationKeyValueModifiedEventData valueModifiedEventData)
        {
            SharedConfigurationClient.UpdateSyncToken(valueModifiedEventData.SyncToken);

            Response<ConfigurationSetting> updatedSetting = SharedConfigurationClient.GetConfigurationSetting(valueModifiedEventData.Key, valueModifiedEventData.Label);
            Console.WriteLine($"Setting was updated. Key: {updatedSetting.Value.Key} Value: {updatedSetting.Value.Value}");
        }
    }
}
```