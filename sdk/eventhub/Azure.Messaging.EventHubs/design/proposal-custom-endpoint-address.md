# Event Hubs: Custom Endpoint Support

Connections to the Azure Event Hubs service are made using the fully qualified namespace name assigned for the Event Hubs namespace as the root of the endpoint address.  Because the Event Hubs service ensures the appropriate CNAME records are configured in DNS as part of the provisioning process, this provides an endpoint address that is strongly associated with the Event Hubs namespace and easier for developers to remember.

While the standard approach works well under normal circumstances, it can be troublesome in certain environments when a proxy is in use or when an Express Route circuit is used with certain configurations.  In these scenarios, an alternative host name is needed to allow for proper routing to the Event Hubs service.

## Things to know before reading

- The names used in this document are intended for illustration only. Some names are not ideal and will need to be refined during discussions.

- Some details not related to the high-level concept are not illustrated; the scope of this is limited to the high level shape and paradigms for the feature area.

- Fake methods are used to illustrate "something needs to happen, but the details are unimportant."  As a general rule, if an operation is not directly related to one of the Service Bus or Event Hubs types, it can likely be assumed that it is for illustration only.  These methods will most often use ellipses for the parameter list, in order to help differentiate them.

## Terminology

- **Fully Qualified Namespace Name** is used to refer to the host name assigned to an Event Hubs namespace as part of the provisioning process.  It typically has the form `{{ Namespace Name }}.servicebus.windows.net`.

- **Event Hubs Host Name** is a synonym for the fully qualified namespace name.  It is a legacy term that sometimes appears in the Azure portal.

- **Custom Endpoint Address** is used to refer to a developer-provided endpoint address which is resolvable in their environment and which should be used when establishing the connection to the Event Hubs service.  It will typically have the form `sb://{{ custom host name }}`.

## Why this is needed

Some of our enterprise customers with environments using unconventional proxy configurations or with certain configurations of an Express Route circuit are unable to connect from their on-premises network to the Event Hubs service.  The [Event Hubs Private Link](https://learn.microsoft.com/azure/event-hubs/private-link-service) feature will unblock the Express Route scenario.  However, Private Link is a premium feature with cost considerations and which carries a set of [limitations](https://learn.microsoft.com/azure/private-link/private-link-service-overview#limitations).  It is also not certain that the Private Link feature will resolve all blocking issues, such as those related to local proxying.

## High level scenarios

### Connecting on a restricted network

A local hospital employs a strict set of network policies to ensure the safety of their network and the security of their patient information.  As part of this strategy, all traffic is routed through a security proxy which performs a threat analysis and logging of connections.

In order to allow for trusted internal applications to embrace cloud services, a special bank of IP addresses has been reserved which passes through a secure DMZ path rather than the security proxy.  In order for trusted connections to work appropriately, they must resolve to one of the reserved IP addresses using a CNAME configured in the local DNS service.

Because of these restrictions, applications are unable to perform direct connections to the Azure Event Hubs service using the standard endpoint address and require the ability to specify a custom host name to ensure they route through the proper intermediary for the connection to be made.

## Proposed approach

- Extend the `EventHubConnectionOptions` to allow a custom endpoint address to be specified.

- When establishing the connection to the Event Hubs service, use the custom endpoint address if it was specified.  If not, follow the current logic for determining and using the standard endpoint address.

- Once the connection is established, ignore the custom endpoint address in favor of the standard endpoint address when sending the AMQP open frame and for authorization purposes.

## Usage examples

### Create a client that uses a custom endpoint address

```csharp
var options = new EventHubProducerClientOptions();
options.ConnectionOptions.CustomEndpointAddress = new Uri("sb://eventhubs.mycompany.local");

await using var receiver = new EventHubProducerClient("<< CONNECTION STRING >>", "<< EVENT HUB NAME >>", options);
```

## API Skeleton

### `Azure.Messaging.EventHubs`
```csharp
public class EventHubConnectionOptions
{
    // New members
    public Uri CustomEndpointAddress { get; set; }
    
    // Existing members
    public EventHubsTransportType TransportType { get; set; } = EventHubsTransportType.AmqpTcp;
    public IWebProxy Proxy { get; set; } = null;
}
```