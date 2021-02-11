# Identity and Shared Access Credentials

This sample demonstrates using credentials to authorize clients with the Event Hubs service.  In most scenarios, credentials provide a better approach to security than connection strings for production applications.  One of the key benefits is support for in-place rotation to update access policies without the need to stop applications.  Most credential sources also allow for more fine-grained access control, when compared with the shared key approach favored by connection strings.

## Prerequisites

To begin, please ensure that you're familiar with the items discussed in the [Getting started](https://github.com/Azure/azure-sdk-for-net/tree/master/sdk/eventhub/Azure.Messaging.EventHubs/samples#getting-started) section of the README.  You will also need to the fully qualified namespace for the Event Hubs resource that you would like to use.  This can be found in the Azure Portal view of the Event Hubs namespace in the "Overview" tab.  In the center pane, the "essentials" area will list a "hostname."  This is the fully qualified namespace and is likely be similar to: `{your-namespace}.servicebus.windows.net`.

Depending on the type of authorization that you wish to use, additional setup may be necessary before using these examples.  Details for each authorization type can be found below.

### Identity authorization

**Azure.Identity**  

The `Azure.Identity` library is recommended for identity-based authentication across the different sources supported by the Azure platform for  [role-based access control (RBAC)](https://docs.microsoft.com/azure/role-based-access-control/overview).  This includes Azure Active Directory principals and Managed Identities.  To allow for the best developer experience, and one that supports promoting applications between environments without code changes, this sample will concentrate on the `DefaultAzureCredential`.  Please see the [Azure.Identity README](https://github.com/Azure/azure-sdk-for-net/blob/master/sdk/identity/Azure.Identity/README.md#defaultazurecredential) for details on configuring your environment for `DefaultAzureCredential` integration. 

**Role Assignments** 

Once your environment is configured, you'll need to ensure that the principal that you've chosen has access to your Event Hubs resources in Azure.  To do so, they will be assigned the [Azure Event Hubs Data Owner](https://docs.microsoft.com/azure/role-based-access-control/built-in-roles#azure-event-hubs-data-owner) role.  For those not familiar with role assignments, it is recommended to follow [these steps](https://docs.microsoft.com/azure/event-hubs/authenticate-managed-identity?tabs=latest#to-assign-azure-roles-using-the-azure-portal) in the Azure portal for the most intuitive experience.  

Roles may also be assigned via the [Azure CLI](https://docs.microsoft.com/cli/azure/role/assignment?view=azure-cli-latest#az_role_assignment_create) or [PowerShell](https://docs.microsoft.com/powershell/module/az.resources/new-azroleassignment), though these require more in-depth knowledge of the Azure platform and may be difficult for developers exploring Azure for the first time.  

### Event Hubs Shared Access Signature authorization

Shared access signatures (SAS) are recommended over shared access keys, when RBAC cannot be used.  A shared access signature allows for granular and time-limited access to Event Hubs resources.  In order to use SAS-based authorization, a token needs to be generated and the associated Event Hubs resource needs to be configured to authorize its use.

The steps to to generate a SAS token can be found in the article "[Authenticate access to Event Hubs resources using shared access signatures (SAS)](https://docs.microsoft.com/azure/event-hubs/authenticate-shared-access-signature)", with details for some additional languages detailed in the article "[Generate SAS token](https://docs.microsoft.com/rest/api/eventhub/generate-sas-token)".   Information about configuring SAS authorization can be found in the article "[Authorizing access to Event Hubs resources using Shared Access Signatures](https://docs.microsoft.com/azure/event-hubs/authorize-access-shared-access-signature)".

### Event Hubs Shared Access Key authorization

Shared access keys for Event Hubs authorization are generated when access policies are created for an Event Hubs namespace or one of its Event Hub instances.  Since these keys are most often used in association with a connection string, the article "[Get an Event Hubs connection string](https://docs.microsoft.com/azure/event-hubs/event-hubs-get-connection-string#get-connection-string-from-the-portal)" is the best source of information on generating and accessing them.  

In step 6 of the article, the policy that you select will be the name of your shared access key when used for credential authorization.  In step 7, you'll want to copy the "Primary key" rather than connection string.

## Client types

All of the client types within the Event Hubs client library support the use of [Azure.Identity](https://github.com/Azure/azure-sdk-for-net/tree/master/sdk/identity/Azure.Identity) authentication, as well as shared access credentials for shared access key and shared access signature use.  More information about client types can be found in [Sample02_EventHubsClients](https://github.com/Azure/azure-sdk-for-net/tree/master/sdk/eventhub/Azure.Messaging.EventHubs/samples/Sample02_EventHubsClients.md).

For illustration, the `EventHubProducerClient` is demonstrated in these examples, but the concept and form are common across clients.

## Publishing events with identity-based authorization

```C# Snippet:EventHubs_Sample06_DefaultAzureCredential
TokenCredential credential = new DefaultAzureCredential();

var fullyQualifiedNamespace = "<< NAMESPACE (likely similar to {your-namespace}.servicebus.windows.net) >>";
var eventHubName = "<< NAME OF THE EVENT HUB >>";

var producer = new EventHubProducerClient(fullyQualifiedNamespace, eventHubName, credential);

try
{
    using var eventBatch = await producer.CreateBatchAsync();

    for (var index = 0; index < 5; ++index)
    {
        var eventBody = new BinaryData($"Event #{ index }");
        var eventData = new EventData(eventBody);

        if (!eventBatch.TryAdd(eventData))
        {
            throw new Exception($"The event at { index } could not be added.");
        }
    }

    await producer.SendAsync(eventBatch);
}
finally
{
    await producer.CloseAsync();
}
```

## Publishing events with Shared Access Signature authorization

**COMING SOON**

## Publishing events with Shared Access Key authorization

**COMING SOON**

## Parsing a connection string for information

In some scenarios, it may be preferable to supplement token-based authorization with the components of a connection string rather than tracking them separately.  One common scenario for this approach is when your application uses different credentials locally and across the environments where it is hosted.  By using the fully qualified namespace and other values from the connection string, you may be able to reduce duplication and streamline your application's configuration.

This example illustrates parsing the fully qualified namespace and, optionally, the Event Hub name from the connection string and using it with identity-based authorization.

```C# Snippet:EventHubs_Sample06_ConnectionStringParse
var connectionString = "<< CONNECTION STRING FOR THE EVENT HUBS NAMESPACE >>";
var eventHubName = "<< NAME OF THE EVENT HUB >>";

EventHubsConnectionStringProperties properties =
    EventHubsConnectionStringProperties.Parse(connectionString);

TokenCredential credential = new DefaultAzureCredential();

var producer = new EventHubProducerClient(
    properties.FullyQualifiedNamespace,
    properties.EventHubName ?? eventHubName,
    credential);

try
{
    using var eventBatch = await producer.CreateBatchAsync();

    for (var index = 0; index < 5; ++index)
    {
        var eventBody = new BinaryData($"Event #{ index }");
        var eventData = new EventData(eventBody);

        if (!eventBatch.TryAdd(eventData))
        {
            throw new Exception($"The event at { index } could not be added.");
        }
    }

    await producer.SendAsync(eventBatch);
}
finally
{
    await producer.CloseAsync();
}
```


