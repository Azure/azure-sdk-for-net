# Create, Retrieve and Update status of a Configuration Settings Snapshot

Azure App Configuration allows users to create a point-in-time snapshot of their configuration store, providing them with the ability to treat settings as one consistent version. This feature enables applications to hold a consistent view of configuration, ensuring that there are no version mismatches to individual settings due to reading as updates were made.  Snapshots are immutable, ensuring that configuration can confidently be rolled back to a last-known-good configuration in the event of a problem. 

This sample illustrates how to create, retrieve, and modify the status of a `ConfigurationSnapshot`.

To get started, you'll need to instantiate the `ConfigurationClient` class. In order to do so, you have two options: provide the connection string of the Configuration Store or authenticate with Azure Active Directory. For detailed instructions, please refer to the [README](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/appconfiguration/Azure.Data.AppConfiguration/README.md#authenticate-the-client).

## Create a Snapshot

To create a snapshot, you need to create an instance of `ConfigurationSnapshot` and add filters to determine which configuration settings are included in the snapshot. The creation of a snapshot is an LRO (Long-Running Operation) method, and there are three ways to call the `CreateSnapshot` method:

### Automatic Polling

```C# Snippet:AzConfigSample11_CreateSnapshot_AutomaticPolling
var settingsFilter = new List<ConfigurationSettingsFilter> { new ConfigurationSettingsFilter("some_key") };
var settingsSnapshot = new ConfigurationSnapshot(settingsFilter);

var snapshotName = "some_snapshot";
var operation = client.CreateSnapshot(WaitUntil.Completed, snapshotName, settingsSnapshot);
var createdSnapshot = operation.Value;
Console.WriteLine($"Created configuration snapshot: {createdSnapshot.Name}, Status: {createdSnapshot.Status}");
```

### Automatic Polling with `WaitForCompletion`

```C# Snippet:AzConfigSample11_CreateSnapshot_AutomaticPollingLater
var settingsFilter = new List<ConfigurationSettingsFilter> { new ConfigurationSettingsFilter("some_key") };
var settingsSnapshot = new ConfigurationSnapshot(settingsFilter);

var snapshotName = "some_snapshot";
var operation = client.CreateSnapshot(WaitUntil.Started, snapshotName, settingsSnapshot);
operation.WaitForCompletion();

var createdSnapshot = operation.Value;
Console.WriteLine($"Created configuration snapshot: {createdSnapshot.Name}, status: {createdSnapshot.Status}");
```

### Manual Polling

```C# Snippet:AzConfigSample11_CreateSnapshot_ManualPolling
var settingsFilter = new List<ConfigurationSettingsFilter> { new ConfigurationSettingsFilter("some_key") };
var settingsSnapshot = new ConfigurationSnapshot(settingsFilter);

var snapshotName = "some_snapshot";
var operation = client.CreateSnapshot(WaitUntil.Started, snapshotName, settingsSnapshot);
while (true)
{
    operation.UpdateStatus();
    if (operation.HasCompleted)
        break;
    await Task.Delay(1000); // Add some delay for polling
}

var createdSnapshot = operation.Value;
Console.WriteLine($"Created configuration snapshot: {createdSnapshot.Name}, status: {createdSnapshot.Status}");
```

## Retrieve a Snapshot

After creating a configuration setting snapshot, you can retrieve it using the `GetSnapshot` method.

```C# Snippet:AzConfigSample11_GetSnapshot
var snapshotName = "some_snapshot";
ConfigurationSnapshot retrievedSnapshot = client.GetSnapshot(snapshotName);
Console.WriteLine($"Retrieved configuration snapshot: {retrievedSnapshot.Name}, status: {retrievedSnapshot.Status}");
```

## Archive a Snapshot

To archive a snapshot, you can use the `ArchiveSnapshot` method. This operation updates the status of the snapshot to `archived`.

```C# Snippet:AzConfigSample11_ArchiveSnapshot
var snapshotName = "some_snapshot";
ConfigurationSnapshot archivedSnapshot = client.ArchiveSnapshot(snapshotName);
Console.WriteLine($"Archived configuration snapshot: {archivedSnapshot.Name}, status: {archivedSnapshot.Status}");
```

## Recover a snapshot

To recover an archived snapshot, you can use the `RecoverSnapshot` method. This operation updates the status of the snapshot to `ready`.

```C# Snippet:AzConfigSample11_RecoverSnapshot
var snapshotName = "some_snapshot";
ConfigurationSnapshot recoveredSnapshot = client.RecoverSnapshot(snapshotName);
Console.WriteLine($"Recovered configuration snapshot: {recoveredSnapshot.Name}, status: {recoveredSnapshot.Status}");
```

## Retrieve all Snapshots

To retrieve all snapshots, you can use the `GetSnapshots` method.

```C# Snippet:AzConfigSample11_GetSnapshots
var count = 0;
foreach (var item in client.GetSnapshots(new SnapshotSelector()))
{
    count++;
    Console.WriteLine($"Retrieved configuration snapshot: {item.Name}, status {item.Status}");
}
Console.WriteLine($"Total number of snapshots retrieved: {count}");
```

## Get Configuration Settings for Snapshot

To retrieve the configuration settings for a snapshot, you can use the `GetConfigurationSettingsForSnapshot` method.

```C# Snippet:AzConfigSample11_GetConfigurationSettingsForSnapshot
var firstSetting = new ConfigurationSetting("first_key", "first_value");
client.AddConfigurationSetting(firstSetting);

var secondSetting = new ConfigurationSetting("second_key", "second_value");
client.AddConfigurationSetting(secondSetting);

var settingsFilter = new List<ConfigurationSettingsFilter> { new ConfigurationSettingsFilter(firstSetting.Key), new ConfigurationSettingsFilter(secondSetting.Key) };
var settingsSnapshot = new ConfigurationSnapshot(settingsFilter);

var snapshotName = "some_snapshot";
var operation = client.CreateSnapshot(WaitUntil.Completed, snapshotName, settingsSnapshot);
var createdSnapshot = operation.Value;
Console.WriteLine($"Created configuration snapshot: {createdSnapshot.Name}, Status: {createdSnapshot.Status}");

var count = 0;
foreach (var item in client.GetConfigurationSettingsForSnapshot(snapshotName))
{
    count++;
    Console.WriteLine($"Retrieved configuration setting: {item.Key}");
}
Console.WriteLine($"Total number of retrieved Configuration Settings for snapshot {snapshotName}: {count}");
```
