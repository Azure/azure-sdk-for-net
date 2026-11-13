# Azure Communication Phone Numbers client library for .NET

Azure Communication Phone Numbers is managing phone numbers for Azure Communication Services.

[Source code][source] <!--| [Package (NuGet)][package]--> | [Product documentation][product_docs] | [Samples][source_samples]

## Getting started

### Install the package

Install the Azure Communication Phone Numbers client library for .NET with [NuGet][nuget]:

```dotnetcli
dotnet add package Azure.Communication.PhoneNumbers
```

### Prerequisites

You need an [Azure subscription][azure_sub] and a [Communication Service Resource][communication_resource_docs] to use this package.

To create a new Communication Service, you can use the [Azure Portal][communication_resource_create_portal], the [Azure PowerShell][communication_resource_create_power_shell], or the [.NET management client library][communication_resource_create_net].

<!--
Here's an example using the Azure CLI:

```Powershell
[To be ADDED]
```
-->

### Key concepts

This SDK provides functionality to easily manage `direct offer` and `direct routing` numbers.

The `direct offer` numbers come in three types: Geographic, Toll-Free and Mobile. Geographic and Mobile phone plans are phone plans associated with a location, whose phone numbers' area codes are associated with the area code of a geographic location. Toll-Free phone plans are phone plans not associated location. For example, in the US, toll-free numbers can come with area codes such as 800 or 888.
They are managed using the `PhoneNumbersClient`

The `direct routing` feature enables connecting your existing telephony infrastructure to ACS.
The configuration is managed using the `SipRoutingClient`, which provides methods for setting up SIP trunks and voice routing rules, in order to properly handle calls for your telephony subnet.

### Authenticate the client

Clients can be authenticated using connection string acquired from an Azure Communication Resources in the [Azure Portal][azure_portal].

```C# Snippet:CreatePhoneNumbersClient
// Get a connection string to our Azure Communication resource.
var connectionString = "<connection_string>";
var client = new PhoneNumbersClient(connectionString);
```

```C# Snippet:CreateSipRoutingClient
// Get a connection string to Azure Communication resource.
var connectionString = "<connection_string>";
var client = new SipRoutingClient(connectionString);
```

Clients also have the option to authenticate with Azure Active Directory Authentication. For more on this topic, see [Azure Identity][azure_identity].

```C# Snippet:CreatePhoneNumbersClientWithTokenCredential
// Get an endpoint to our Azure Communication resource.
var endpoint = new Uri("<endpoint_url>");
TokenCredential tokenCredential = new DefaultAzureCredential();
client = new PhoneNumbersClient(endpoint, tokenCredential);
```

```C# Snippet:CreateSipRoutingClientWithTokenCredential
// Get an endpoint to our Azure Communication resource.
var endpoint = new Uri("<endpoint_url>");
TokenCredential tokenCredential = new DefaultAzureCredential();
client = new SipRoutingClient(endpoint, tokenCredential);
```

### Phone numbers client

#### Phone number types overview
Phone numbers come in three types; Geographic, Toll-Free and Mobile. Toll-Free numbers are not associated with a location. For example, in the US, toll-free numbers can come with area codes such as 800 or 888. Geographic and Mobile phone numbers are phone numbers associated with a location.
 
Phone number types with the same country are grouped into a phone plan group with that phone number type. For example all Toll-Free phone numbers within the same country are grouped into a phone plan group.

#### Searching, purchasing and releasing phone numbers

Phone numbers can be searched through the search creation API by providing an area code, quantity of phone numbers, application type, phone number type and capabilities. The provided quantity of phone numbers will be reserved for ten minutes and can be purchased within this time. If the search is not purchased, the phone numbers will become available to others after ten minutes. If the search is purchased, then the phone numbers are acquired for the Azure resources.

Phone numbers can also be released using the release API.

#### Browsing and reserving phone numbers

The Browse and Reservations APIs provide an alternate way to acquire phone numbers via a shopping-cart-like experience. This is achieved by splitting the search operation, which finds and reserves numbers using a single LRO, into two separate synchronous steps: Browse and Reservation. 

The browse operation retrieves a random sample of phone numbers that are available for purchase for a given country, with optional filtering criteria to narrow down results. The returned phone numbers are not reserved for any customer.

Reservations represent a collection of phone numbers that are locked by a specific customer and are awaiting purchase. They have an expiration time of 15 minutes after the last modification or 2 hours from creation time. A reservation can include numbers from different countries, in contrast with the Search operation. Customers can create, retrieve, modify (add/remove numbers), delete, and purchase reservations. Purchasing a reservation is an LRO.

### SIP routing client

Direct routing feature allows connecting customer-provided telephony infrastructure to Azure Communication Resources. In order to setup routing configuration properly, customer needs to supply the SIP trunk configuration and SIP routing rules for calls. SIP routing client provides the necessary interface for setting this configuration.

When a call is made, the system tries to match the destination number with regex number patterns of defined routes. The first route to match the number will be selected. The order of regex matching is the same as the order of routes in configuration, therefore the order of routes matters.
Once a route is matched, the call is routed to the first trunk in the route's trunks list. If the trunk is not available, next trunk in the list is selected.

### Thread safety
We guarantee that all client instance methods are thread-safe and independent of each other ([guideline](https://azure.github.io/azure-sdk/dotnet_introduction.html#dotnet-service-methods-thread-safety)). This ensures that the recommendation of reusing client instances is always safe, even across threads.

### Additional concepts
<!-- CLIENT COMMON BAR -->
[Client options](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/README.md#configuring-service-clients-using-clientoptions) |
[Accessing the response](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/README.md#accessing-http-response-details-using-responset) |
[Long-running operations](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/README.md#consuming-long-running-operations-using-operationt) |
[Handling failures](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/README.md#reporting-errors-requestfailedexception) |
[Diagnostics](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/Diagnostics.md) |
[Mocking](https://learn.microsoft.com/dotnet/azure/sdk/unit-testing-mocking) |
[Client lifetime](https://devblogs.microsoft.com/azure-sdk/lifetime-management-and-thread-safety-guarantees-of-azure-sdk-net-clients/)
<!-- CLIENT COMMON BAR -->

## Examples

### PhoneNumbersClient

#### Creating a PhoneNumbersClient

To create a new `PhoneNumbersClient` you need a connection string to the Azure Communication Services resource that you can get from the Azure Portal once you have created the resource.

You can set `connectionString` based on an environment variable, a configuration setting, or any way that works for your application.

```C# Snippet:CreatePhoneNumbersClient
// Get a connection string to our Azure Communication resource.
var connectionString = "<connection_string>";
var client = new PhoneNumbersClient(connectionString);
```

#### Search phone numbers

Phone numbers need to be searched before they can be purchased. Search is a long running operation that can be started by `StartSearchAvailablePhoneNumbers` function that returns an `SearchAvailablePhoneNumbersOperation` object. `SearchAvailablePhoneNumbersOperation` can be used to update status of the operation and to check for completeness.

```C# Snippet:SearchPhoneNumbersAsync
var capabilities = new PhoneNumberCapabilities(calling: PhoneNumberCapabilityType.None, sms: PhoneNumberCapabilityType.Outbound);

var searchOperation = await client.StartSearchAvailablePhoneNumbersAsync(countryCode, PhoneNumberType.TollFree, PhoneNumberAssignmentType.Application, capabilities);
await searchOperation.WaitForCompletionAsync();
```

#### Purchase phone numbers

Phone numbers can be acquired through purchasing a search.

```C# Snippet:StartPurchaseSearchAsync
var purchaseOperation = await client.StartPurchasePhoneNumbersAsync(searchOperation.Value.SearchId);
await purchaseOperation.WaitForCompletionResponseAsync();
```

#### Listing purchased phone numbers

You can list all phone numbers that have been purchased for your resource.

```C# Snippet:GetPurchasedPhoneNumbersAsync
var purchasedPhoneNumbers = client.GetPurchasedPhoneNumbersAsync();

await foreach (var phoneNumber in purchasedPhoneNumbers)
{
    Console.WriteLine($"Phone number: {phoneNumber.PhoneNumber}, monthly cost: {phoneNumber.Cost}");
}
```

#### Release phone numbers

If you no longer need a phone number you can release it.

```C# Snippet:ReleasePhoneNumbersAsync
var purchasedPhoneNumber = "<purchased_phone_number>";
var releaseOperation = await client.StartReleasePhoneNumberAsync(purchasedPhoneNumber);
await releaseOperation.WaitForCompletionResponseAsync();
await WaitForCompletionResponseAsync(releaseOperation);
```

#### Acquiring phone numbers using the Reservations API

Using the Browse API, you can find phone numbers that are available for purchase. Note that these numbers are not reserved for any customer.

```C# Snippet:BrowseAvailablePhoneNumbersAsync
var browseRequest = new PhoneNumbersBrowseOptions("US", PhoneNumberType.TollFree);
var browseResponse = await client.BrowseAvailableNumbersAsync(browseRequest);
var availablePhoneNumbers = browseResponse.Value.PhoneNumbers;
```

Then, create a new reservation with the numbers from the Browse API response.
```C# Snippet:CreateReservationAsync
// Reserve the first two available phone numbers.
var phoneNumbersToReserve = availablePhoneNumbers.Take(2).ToList();

// The reservation ID needs to be a unique GUID.
var reservationId = Guid.NewGuid();

var request = new CreateOrUpdateReservationOptions(reservationId)
{
    PhoneNumbersToAdd = phoneNumbersToReserve
};
var response = await client.CreateOrUpdateReservationAsync(request);
var reservation = response.Value;
```

Partial failures are possible, so it is important to check the status of each individual phone number.
```C# Snippet:CheckForPartialFailure
var phoneNumbersWithError = reservation.PhoneNumbers.Values
    .Where(n => n.Status == PhoneNumberAvailabilityStatus.Error);

if (phoneNumbersWithError.Any())
{
    // Handle the error for the phone numbers that failed to reserve.
    foreach (var phoneNumber in phoneNumbersWithError)
    {
        Console.WriteLine($"Failed to reserve phone number {phoneNumber.Id}. Error Code: {phoneNumber.Error?.Code} - Message: {phoneNumber.Error?.Message}");
    }
}
```

Once all numbers are reserved, the reservation can be purchased.
```C# Snippet:StartPurchaseReservationAsync
var purchaseReservationOperation = await client.StartPurchaseReservationAsync(reservationId);
await purchaseReservationOperation.WaitForCompletionResponseAsync();
```

### SipRoutingClient

#### Retrieve SIP trunks and routes

Get the list of currently configured trunks or routes.

```C# Snippet:RetrieveListAsync
var trunksResponse = await client.GetTrunksAsync();
var routesResponse = await client.GetRoutesAsync();
```

#### Replace SIP trunks and routes

Replace the list of currently configured trunks or routes.

```C# Snippet:ReplaceAsync
// The service will not allow trunks that are used in any of the routes to be deleted, therefore first set the routes as empty list, and then update the routes.
var newTrunks = "<new_trunks_list>";
var newRoutes = "<new_routes_list>";
await client.SetRoutesAsync(new List<SipTrunkRoute>());
await client.SetTrunksAsync(newTrunks);
await client.SetRoutesAsync(newRoutes);
```

#### Manage single trunk

SIP trunks can be managed separately by using the `SipRoutingClient` to retrieve, set or delete a single trunk.

#### Retrieve single trunk

```C# Snippet:RetrieveTrunkAsync
// Get trunk object, based on it's FQDN.
var fqdnToRetrieve = "<fqdn>";
var trunkResponse = await client.GetTrunkAsync(fqdnToRetrieve);
```
#### Set single trunk

```C# Snippet:SetTrunkAsync
// Set function will either modify existing item or add new item to the collection.
// The trunk is matched based on it's FQDN.
var trunkToSet = "<trunk_to_set>";
await client.SetTrunkAsync(trunkToSet);
```

#### Delete single trunk

```C# Snippet:DeleteTrunkAsync
// Deletes trunk with supplied FQDN.
var fqdnToDelete = "<fqdn>";
await client.DeleteTrunkAsync(fqdnToDelete);
```

## Troubleshooting

## Next steps

[Read more about managing phone numbers][phone_numbers]

[Read more about direct routing][direct_routing]

## Contributing

This project welcomes contributions and suggestions. Most contributions require you to agree to a Contributor License Agreement (CLA) declaring that you have the right to, and actually do, grant us the rights to use your contribution. For details, visit [cla.microsoft.com][cla].

This project has adopted the [Microsoft Open Source Code of Conduct][coc]. For more information see the [Code of Conduct FAQ][coc_faq] or contact [opencode@microsoft.com][coc_contact] with any additional questions or comments.

<!-- LINKS -->

[azure_sub]: https://azure.microsoft.com/free/dotnet/
[azure_portal]: https://portal.azure.com
[azure_identity]: https://learn.microsoft.com/dotnet/api/azure.identity?view=azure-dotnet
[source]: https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/communication/Azure.Communication.PhoneNumbers/src
[source_samples]: https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/communication/Azure.Communication.PhoneNumbers/samples
[cla]: https://cla.microsoft.com
[coc]: https://opensource.microsoft.com/codeofconduct/
[coc_faq]: https://opensource.microsoft.com/codeofconduct/faq/
[coc_contact]: mailto:opencode@microsoft.com
<!--[package]: https://www.nuget.org/packages/Azure.Communication.PhoneNumbers-->
[phone_numbers]: https://learn.microsoft.com/azure/communication-services/quickstarts/telephony/get-phone-number?pivots=platform-azp
[product_docs]: https://learn.microsoft.com/azure/communication-services/overview
[nuget]: https://www.nuget.org/
[communication_resource_docs]: https://learn.microsoft.com/azure/communication-services/quickstarts/create-communication-resource?tabs=windows&pivots=platform-azp
[communication_resource_create_portal]: https://learn.microsoft.com/azure/communication-services/quickstarts/create-communication-resource?tabs=windows&pivots=platform-azp
[communication_resource_create_power_shell]: https://learn.microsoft.com/powershell/module/az.communication/new-azcommunicationservice
[communication_resource_create_net]: https://learn.microsoft.com/azure/communication-services/quickstarts/create-communication-resource?tabs=windows&pivots=platform-net
[direct_routing]: https://learn.microsoft.com/azure/communication-services/concepts/telephony/direct-routing-provisioning
