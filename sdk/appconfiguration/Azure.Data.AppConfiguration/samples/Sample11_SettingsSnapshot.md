# Update a Configuration If Unchanged

This sample illustrates how to create, retrieve, and modify the status of a `ConfigurationSettingSnapshot`. 

To get started, you'll need a connection string to the Azure App Configuration. See the [README](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/appconfiguration/Azure.Data.AppConfiguration/README.md) for links and instructions.

## Creating a snapshot

```C#
List<SnapshotSettingFilter> snapshotFilter = new(new SnapshotSettingFilter[] { new SnapshotSettingFilter(setting.Key) });
var settingsSnapshot = new ConfigurationSettingsSnapshot(snapshotFilter);

CreateSnapshotOperation createSnapshotOperation = client.CreateSnapshot(WaitUntil.Completed, "some_snapshot", settingsSnapshot);
ConfigurationSettingsSnapshot createdSnapshot = createSnapshotOperation.Value;
Console.WriteLine($"Created configuration setting snapshot is: {createdSnapshot}");
```

## Retrieving a snapshot
```C#
ConfigurationSettingsSnapshot retrievedSnapshot = client.GetSnapshot("some_snapshot");
Console.WriteLine($"Retrieved configuration setting snapshot is: {retrievedSnapshot}");
```

## Retrieving all snapshots

```C#
var count = 0;
foreach (ConfigurationSettingsSnapshot item in client.GetSnapshots())
{
    count++;
    Console.WriteLine($"Name {item.Name} status {item.Status}");
}
```

## Archiving and recovering snapshots

```C#
ConfigurationSettingsSnapshot archivedSnapshot = client.ArchiveSnapshot("some_snapshot");
Console.WriteLine($"Archived configuration setting snapshot is: {archivedSnapshot}");
```

```C#
ConfigurationSettingsSnapshot recoveredSnapshot = client.RecoverSnapshot("some_snapshot");
Console.WriteLine($"Recovered configuration setting snapshot is: {recoveredSnapshot}");
```

