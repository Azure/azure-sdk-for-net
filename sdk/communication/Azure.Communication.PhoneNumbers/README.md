# Azure Communication PhoneNumbers client library for .NET

> Server Version:

> Phone number client: 2020-07-20-preview1

Azure Communication PhoneNumbers is managing phone numbers for Azure Communication Services.

[Source code][source] <!--| [Package (NuGet)][package]--> | [Product documentation][product_docs] | [Samples][source_samples]

## Getting started

### Install the package

Install the Azure Communication PhoneNumbers client library for .NET with [NuGet][nuget]:

```Powershell
dotnet add package Azure.Communication.PhoneNumbers --version 1.0.0-beta.3
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

Phone plans come in two types; Geographic and Toll-Free. Geographic phone plans are phone plans associated with a location, whose phone numbers' area codes are associated with the area code of a geographic location. Toll-Free phone plans are phone plans not associated location. For example, in the US, toll-free numbers can come with area codes such as 800 or 888.

All geographic phone plans within the same country are grouped into a phone plan group with a Geographic phone number type. All Toll-Free phone plans within the same country are grouped into a phone plan group.

### Authenticate the client

Phone Number clients can be authenticated using connection string acquired from an Azure Communication Resources in the [Azure Portal][azure_portal].

```C# Snippet:CreatePhoneNumberAdministrationClient
// Get a connection string to our Azure Communication resource.
var connectionString = "<connection_string>";
var client = new PhoneNumberAdministrationClient(connectionString);
```

Phone Number clients also have the option to authenticate with Azure Active Directory Authentication. With this option,
`AZURE_CLIENT_SECRET`, `AZURE_CLIENT_ID` and `AZURE_TENANT_ID` environment variables need to be set up for authentication.

```C# Snippet:CreatePhoneNumberWithTokenCredential
var endpoint = "<endpoint_url>";
TokenCredential tokenCredential = new DefaultAzureCredential();
var client = new PhoneNumberAdministrationClient(new Uri(endpoint), tokenCredential);
```

### Reserving and acquiring numbers

Phone numbers reservation can be performed through the reservation creation API by providing a phone plan id, an area code and quantity of phone numbers. The provided quantity of phone numbers will be reserved for ten minutes. This reservation of phone numbers can either be cancelled or purchased. If the reservation is cancelled, then the phone numbers will become available to others. If the reservation is purchased, then the phone numbers are acquired for the Azure resources.

### Configuring / Assigning numbers

Phone numbers can be assigned to a callback URL via the configure number API. As part of the configuration, you will need an acquired phone number, callback URL and application id.

### Thread safety
We guarantee that all client instance methods are thread-safe and independent of each other ([guideline](https://azure.github.io/azure-sdk/dotnet_introduction.html#dotnet-service-methods-thread-safety)). This ensures that the recommendation of reusing client instances is always safe, even across threads.

### Additional concepts
<!-- CLIENT COMMON BAR -->
[Client options](https://github.com/Azure/azure-sdk-for-net/blob/master/sdk/core/Azure.Core/README.md#configuring-service-clients-using-clientoptions) |
[Accessing the response](https://github.com/Azure/azure-sdk-for-net/blob/master/sdk/core/Azure.Core/README.md#accessing-http-response-details-using-responset) |
[Long-running operations](https://github.com/Azure/azure-sdk-for-net/blob/master/sdk/core/Azure.Core/README.md#consuming-long-running-operations-using-operationt) |
[Handling failures](https://github.com/Azure/azure-sdk-for-net/blob/master/sdk/core/Azure.Core/README.md#reporting-errors-requestfailedexception) |
[Diagnostics](https://github.com/Azure/azure-sdk-for-net/blob/master/sdk/core/Azure.Core/samples/Diagnostics.md) |
[Mocking](https://github.com/Azure/azure-sdk-for-net/blob/master/sdk/core/Azure.Core/README.md#mocking) |
[Client lifetime](https://devblogs.microsoft.com/azure-sdk/lifetime-management-and-thread-safety-guarantees-of-azure-sdk-net-clients/)
<!-- CLIENT COMMON BAR -->

## Examples

### Get list of the countries that are supported by the service

```C#
string connectionString = "<connection_string>";
PhoneNumberAdministrationClient client = new PhoneNumberAdministrationClient(connectionString);
Pageable<PhoneNumberCountry> countries = client.GetAllSupportedCountries();

foreach (var country in countries)
{
    Console.WriteLine($"Country code {country.CountryCode}, Country name: {country.LocalizedName}");
}
```

### Get phone plan groups

Phone plan groups come in two types, Geographic and Toll-Free.

```C#
var phonePlanGroups = client.GetPhonePlanGroups(countryCode);

foreach (var group in phonePlanGroups)
{
    Console.WriteLine($"PhonePlanGroupId {group.PhonePlanGroupId}, Name: {group.LocalizedName}, PhoneNumberType: {group.PhoneNumberType}");
}
```

### Get phone plans

Unlike Toll-Free phone plans, area codes for Geographic Phone Plans are empty. Area codes are found in the Area Codes API.

```C#
var phonePlans = client.GetPhonePlans(countryCode, planGroupId);

foreach (var plan in phonePlans)
{
    Console.WriteLine($"PhonePlanId {plan.PhonePlanId}, Name: {plan.LocalizedName}");
    Console.WriteLine("Top 10 area codes");
    foreach (var areaCode in plan.AreaCodes.Take(10).ToList())
    {
        Console.WriteLine($"Area code: {areaCode}");
    }
}
```

### Get location options

For Geographic phone plans, you can query the available geographic locations. The locations options are structured like the geographic hierarchy of a country. For example, the US has states and within each state are cities.

```C#
var locationOptionsResponse = client.GetPhonePlanLocationOptions(countryCode, phonePlanGroupId, phonePlanId);
var locationOprions = locationOptionsResponse.Value.LocationOptions;

Console.WriteLine($"LabelId: {locationOprions.LabelId}, LabelName: {locationOprions.LabelName}");
foreach(var locationOption in locationOprions.Options)
{
    Console.WriteLine($"Name: {locationOption.Name}, Value: {locationOption.Value}");
}
```

### Get area codes

Fetching area codes for geographic phone plans will require that the location options queries be set. You must include the chain of geographic locations which traverse down the location options returned by the `GetLocationOptions` API.

```C#
var areaCodesResponse = client.GetAllAreaCodes(locationType, countryCode, planId, locationOptionsQueries);
var areaCodes = areaCodesResponse.Value;

foreach(var primaryAreaCode in areaCodes.PrimaryAreaCodes)
{
    Console.WriteLine("Primary area code" + primaryAreaCode);
}

foreach (var secondaryAreaCode in areaCodes.SecondaryAreaCodes)
{
    Console.WriteLine("Secondary area code" + secondaryAreaCode);
}
```

### Create reservation

```C#
var reservationOptions = new CreateReservationOptions(displayName, description, plans, areaCode) { Quantity = 1 };
var reservationOperation = await client.StartReservationAsync(reservationOptions).ConfigureAwait(false);
var reservationResponse = await reservationOperation.WaitForCompletionAsync().ConfigureAwait(false);

Console.WriteLine($"ReservationId: {reservationResponse.Value.ReservationId}, Status {reservationResponse.Value.Status}");
```

### Purchase reservation

```C#
var reservationPurchaseOperation = await client.StartPurchaseReservationAsync(reservationId).ConfigureAwait(false);
await reservationPurchaseOperation.WaitForCompletionAsync().ConfigureAwait(false);
```

### Configure phone number

```C#
var pstnConfiguration = new PstnConfiguration("<url>");
var phoneNumber = new PhoneNumber("<phone_number>");
client.ConfigureNumber(pstnConfiguration, phoneNumber);
```

### Release phone numbers

```C#
var releasePhoneNumberOperation = await client.StartReleasePhoneNumbersAsync(numbers).ConfigureAwait(false);
await releasePhoneNumberOperation.WaitForCompletionAsync().ConfigureAwait(false);

Console.WriteLine($"ReleaseId: {releasePhoneNumberOperation.Value.ReleaseId}, Status: {releasePhoneNumberOperation.Value.Status}");
```
## Troubleshooting

## Next steps

[Read more about Communication user access tokens][user_access_token]

## Contributing

This project welcomes contributions and suggestions. Most contributions require you to agree to a Contributor License Agreement (CLA) declaring that you have the right to, and actually do, grant us the rights to use your contribution. For details, visit [cla.microsoft.com][cla].

This project has adopted the [Microsoft Open Source Code of Conduct][coc]. For more information see the [Code of Conduct FAQ][coc_faq] or contact [opencode@microsoft.com][coc_contact] with any additional questions or comments.

<!-- LINKS -->

[azure_sub]: https://azure.microsoft.com/free/
[azure_portal]: https://portal.azure.com
[source]: https://github.com/Azure/azure-sdk-for-net/tree/master/sdk/communication/Azure.Communication.PhoneNumbers/src
[source_samples]: https://github.com/Azure/azure-sdk-for-net/blob/master/sdk/communication/Azure.Communication.PhoneNumbers/samples
[cla]: https://cla.microsoft.com
[coc]: https://opensource.microsoft.com/codeofconduct/
[coc_faq]: https://opensource.microsoft.com/codeofconduct/faq/
[coc_contact]: mailto:opencode@microsoft.com
<!--[package]: https://www.nuget.org/packages/Azure.Communication.PhoneNumbers-->
[product_docs]: https://docs.microsoft.com/azure/communication-services/overview
[nuget]: https://www.nuget.org/
[communication_resource_docs]: https://docs.microsoft.com/azure/communication-services/quickstarts/create-communication-resource?tabs=windows&pivots=platform-azp
[communication_resource_create_portal]: https://docs.microsoft.com/azure/communication-services/quickstarts/create-communication-resource?tabs=windows&pivots=platform-azp
[communication_resource_create_power_shell]: https://docs.microsoft.com/powershell/module/az.communication/new-azcommunicationservice
[communication_resource_create_net]: https://docs.microsoft.com/azure/communication-services/quickstarts/create-communication-resource?tabs=windows&pivots=platform-net
