# Sample Azure Function App for Azure Azure WebJobs Storage Queues

This sample Azure Function application shows usage of Azure Azure WebJobs Storage Queues extension.
`SampleFunctions` contains a pair of producer and consumer that work with an Azure Storage Queue
as well as sample configuration files `host.json` and `local.settings.json`. Settings present in `host.json` are optional and used values can be different than defaults.
Connection string present in `local.settings.json` points to [Azurite](https://github.com/Azure/Azurite), however any valid connection string will work.