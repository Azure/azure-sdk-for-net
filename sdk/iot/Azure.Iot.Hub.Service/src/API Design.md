# Azure Iot Hub Service API Design Doc
This document outlines the APIs for the Azure Iot Hub Service SDK

<details><summary><b>Type definition names</b></summary>
    
```
Configuration - TwinConfiguration
Module - ModuleIdentity
Device - DeviceIdentity
Twin - TwinData
Interface - PnpInterface
Property - PnpProperty
Reported - PnpReported
Desired - PnpDesired
```
</details>

<details><summary><b>Constructors</b></summary>
    
```csharp

```
</details>

<details><summary><b>Configurations</b></summary>
APIs for managing configurations for devices and modules

```csharp

```
</details>

<details><summary><b>Statistics</b></summary>
APIs for getting statistics about devices and modules, as well as service statistics

```csharp

```
</details>

<details><summary><b>Devices</b></summary>
APIs for managing device identities, device twins, and querying devices

```csharp

```
</details>

<details><summary><b>Modules</b></summary>
APIs for managing module identities, module twins, and querying modules

```csharp

```
</details>

<details><summary><b>Jobs</b></summary>
APIs for using IotHub v2 jobs

```csharp

```
</details>

<details><summary><b>Messages</b></summary>
Feedback messages, sending cloud to device messages (missing from current swagger), and purging cloud to device message queue

```csharp
public class CloudToDeviceMessages
{
    /// <summary>
    /// Retrieve feedback notification for cloud to device messages.
    /// </summary>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>TODO: Swagger defines the response as the Http response returned from the service (and not the feedback message).</returns>
    public virtual async Task<Response> GetMessageFeedbackAsync(CancellationToken cancellationToken = default) { }

    /// <summary>
    /// Complete a cloud to device feedback message. A completed message is deleted from the service's feedback queue.
    /// </summary>
    /// <param name="lockToken">The lock token obtained when the cloud to device message was received, and provided to resolve race conditions when completing a feedback message.
    /// TODO: lockToken is from the C2D message received on device or from message feedback received on service client?</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>The Http response.</returns>
    public virtual async Task<Response> CompleteMessageFeedbackAsync(string lockToken, CancellationToken cancellationToken = default) { }

    /// <summary>
    /// Abandon a cloud to device feedback message. An abandoned message is deleted from the service's feedback queue.
    /// </summary>
    /// <param name="lockToken">The lock token obtained when the cloud to device message was received, and provided to resolve race conditions when abandoning a feedback message.
    /// TODO: lockToken is from the C2D message received on device or from message feedback received on service client?</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>The Http response.</returns>
    public virtual async Task<Response> AbandonMessageFeedbackAsync(string lockToken, CancellationToken cancellationToken = default) { }

    /// <summary>
    /// Purge the cloud to device message queue for a device.
    /// </summary>
    /// <param name="deviceId">The unique identifier of the device.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>The result of the cloud to device message queue purge operation.</returns>
    public virtual async Task<Response<PurgeMessageQueueResult>> PurgeMessageQueueAsync(string deviceId, CancellationToken cancellationToken = default) { }
}
```
</details>

<details><summary><b>Files</b></summary>
APIs for getting file upload notifications (missing from current swagger)

```csharp

```
</details>

<details><summary><b>Fault Injection</b></summary>
Not sure if we'll expose these

```csharp

```
</details>

<details><summary><b>Query</b></summary>
APIs for querying on device or module identities

```csharp

```
</details>
