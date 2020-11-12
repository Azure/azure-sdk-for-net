# Requesting Azure Storage Service Versions

This sample demonstrates configuring the Blob Storage client to use a specific version of the service, rather than the default.  This is useful when the Azure environment that you are targeting supports a different version of Blob Storage service than is available in the Azure public cloud.  For example, if you are running Event Hubs on an Azure Stack Hub version 2002, the highest available  version for the Storage service is version 2017-11-09. In this case, you will need to use the following code to change the Blob Storage service API version to 2017-11-09. For more information on the Azure Storage service versions supported on Azure Stack Hub, please refer to the [Azure Stack documentation](https://docs.microsoft.com/azure-stack/user/azure-stack-acs-differences).

To begin, please ensure that you're familiar with the items discussed in the [Event Processor Handlers](https://github.com/Azure/azure-sdk-for-net/blob/master/sdk/eventhub/Azure.Messaging.EventHubs.Processor/samples/Sample03_EventProcessorHandlers.md) sample.  You'll also need to have the prerequisites and connection string information available, as discussed in the [Getting started](https://github.com/Azure/azure-sdk-for-net/blob/master/sdk/eventhub/Azure.Messaging.EventHubs.Processor/samples#getting-started) section of the README.

## Configuring the Blob Storage client

 This sample demonstrates using an [Azure.Core](https://docs.microsoft.com/dotnet/api/overview/azure/core-readme) pipeline policy to request the Blob  Storage client request use of a specific service version.  

```C# Snippet:EventHubs_Processor_Sample06_StorageVersionPolicy
/// <summary>
///   A pipeline policy to be applied to a Blob Container Client.  This policy
///   will be applied to every request sent by the client, making it possible
///   to specify the Azure Storage version they will target.
/// </summary>
///
private class StorageApiVersionPolicy : HttpPipelineSynchronousPolicy
{
    /// <summary>
    ///   The Azure Storage version we want to use.
    /// </summary>
    ///
    /// <remarks>
    ///   2017-11-09 is the latest version available in Azure Stack Hub 2002.
    ///   Other available versions could always be specified as long as all
    ///   operations used by the Event Processor Client are supported.
    /// </remarks>
    ///
    private string Version => @"2017-11-09";

    /// <summary>
    ///   A method that will be called before a request is sent to the Azure
    ///   Storage service.  Here we are overriding this method and injecting
    ///   the version we want to change to into the request headers.
    /// </summary>
    ///
    /// <param name="message">The message to be sent to the Azure Storage service.</param>
    ///
    public override void OnSendingRequest(HttpMessage message)
    {
        base.OnSendingRequest(message);
        message.Request.Headers.SetValue("x-ms-version", Version);
    }
}
```

```C# Snippet:EventHubs_Processor_Sample06_ChooseStorageVersion
var storageConnectionString = "<< CONNECTION STRING FOR THE STORAGE ACCOUNT >>";
var blobContainerName = "<< NAME OF THE BLOB CONTAINER >>";

var eventHubsConnectionString = "<< CONNECTION STRING FOR THE EVENT HUBS NAMESPACE >>";
var eventHubName = "<< NAME OF THE EVENT HUB >>";
var consumerGroup = "<< NAME OF THE EVENT HUB CONSUMER GROUP >>";

var storageClientOptions = new BlobClientOptions();

storageClientOptions.AddPolicy(
    new StorageApiVersionPolicy(),
    HttpPipelinePosition.PerCall);

var storageClient = new BlobContainerClient(
    storageConnectionString,
    blobContainerName,
    storageClientOptions);

var processor = new EventProcessorClient(
    storageClient,
    consumerGroup,
    eventHubsConnectionString,
    eventHubName);

try
{
    using var cancellationSource = new CancellationTokenSource();
    cancellationSource.CancelAfter(TimeSpan.FromSeconds(30));

    // The event handlers are not relevant for this sample; for
    // illustration, they're delegating the implementation to the
    // host application.

    processor.ProcessEventAsync += Application.ProcessorEventHandler;
    processor.ProcessErrorAsync += Application.ProcessorErrorHandler;

    try
    {
        await processor.StartProcessingAsync(cancellationSource.Token);
        await Task.Delay(Timeout.Infinite, cancellationSource.Token);
    }
    catch (TaskCanceledException)
    {
        // This is expected if the cancellation token is
        // signaled.
    }
    finally
    {
        // This may take up to the length of time defined
        // as part of the configured TryTimeout of the processor;
        // by default, this is 60 seconds.

        await processor.StopProcessingAsync();
    }
}
catch
{
    // The processor will automatically attempt to recover from any
    // failures, either transient or fatal, and continue processing.
    // Errors in the processor's operation will be surfaced through
    // its error handler.
    //
    // If this block is invoked, then something external to the
    // processor was the source of the exception.
}
finally
{
   // It is encouraged that you unregister your handlers when you have
   // finished using the Event Processor to ensure proper cleanup.  This
   // is especially important when using lambda expressions or handlers
   // in any form that may contain closure scopes or hold other references.

   processor.ProcessEventAsync -= Application.ProcessorEventHandler;
   processor.ProcessErrorAsync -= Application.ProcessorErrorHandler;
}
```